using System.Net;
using System.Net.Http;
using Polly;
using Polly.CircuitBreaker;
using Polly.Hedging;
using Polly.RateLimiting;
using Polly.Retry;
using Polly.Timeout;

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

_ = resiliencePipeline.Build();
_ = httpResiliencePipeline.Build();

// See https://github.com/App-vNext/Polly/issues/1732#issuecomment-1782466692
var p1 = Polly.Utils.Pipeline.PipelineComponent.Empty;
var p2 = Polly.Utils.Pipeline.PipelineComponent.Empty;
var p3 = Polly.Utils.Pipeline.CompositeComponent.Create([p1, p2], null!, null!);
var p4 = new Polly.Utils.Pipeline.BridgeComponent(null!);

await p1.ExecuteCore<int, int>((state, context) => default, default!, default);
await p2.ExecuteCore<int, int>((state, context) => default, default!, default);
await p3.ExecuteCore<int, int>((state, context) => default, default!, default);
await p4.ExecuteCore<int, int>((state, context) => default, default!, default);

Console.WriteLine("Hello Polly!");
