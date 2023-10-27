using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using Polly;
using Polly.CircuitBreaker;
using Polly.Hedging;
using Polly.RateLimiting;
using Polly.Retry;
using Polly.Timeout;

#pragma warning disable CA1050

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var resiliencePipeline = new ResiliencePipelineBuilder()
    .AddCircuitBreaker(new CircuitBreakerStrategyOptions())
    .AddRateLimiter(new RateLimiterStrategyOptions())
    .AddRetry(new RetryStrategyOptions())
    .AddTimeout(new TimeoutStrategyOptions());

var httpResiliencePipeline = new ResiliencePipelineBuilder<HttpResponseMessage>()
    .AddCircuitBreaker(new CircuitBreakerStrategyOptions<HttpResponseMessage>
    {
        ShouldHandle = new PredicateBuilder<HttpResponseMessage>()
            .Handle<HttpRequestException>()
            .HandleResult(response => response.StatusCode == HttpStatusCode.InternalServerError)
    })
    .AddHedging(new HedgingStrategyOptions<HttpResponseMessage>());

builder.Services.AddSingleton(resiliencePipeline.Build());
builder.Services.AddSingleton(httpResiliencePipeline.Build());

// See https://github.com/App-vNext/Polly/issues/1732#issuecomment-1782466692
var p = new DelegatingComponent(null!, null!);
p.ExecuteCore<int, int>(state => default, default);
p.ExecuteCore<int, int>(state => default, default);

var app = builder.Build();

var sampleTodos = new Todo[] {
    new(1, "Walk the dog"),
    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Clean the bathroom"),
    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
};

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}

internal class PipelineComponent
{
    public virtual TResult ExecuteCore<TResult, TState>(Func<TState, TResult> callback, TState state) => default!;
}

#pragma warning disable IDE0022
internal class DelegatingComponent(PipelineComponent component, PipelineComponent next) : PipelineComponent
{
    public override TResult ExecuteCore<TResult, TState>(Func<TState, TResult> callback, TState state)
    {
        // This way allocates a closure but doesn't cause IL3054
        return component.ExecuteCore((state) => next.ExecuteCore(callback, state), state);

        // This way doesn't allocate a closure but causes IL3054
        //return component.ExecuteCore(static (state) => state.next.ExecuteCore(state.callback, state.state), (next, callback, state));
    }
}
