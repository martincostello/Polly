using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Polly.Fallback;

namespace Polly.Core.Tests.Fallback;

public class FallbackResilienceStrategyBuilderExtensionsTests
{
    public static readonly TheoryData<Action<ResilienceStrategyBuilder<int>>> FallbackOverloadsGeneric = new()
    {
        builder =>
        {
            builder.AddFallback(new FallbackStrategyOptions<int>{ FallbackAction = (_, _) =>  new ValueTask<int>(0) });
        },
        builder =>
        {
            builder.AddFallback(handle => handle.HandleResult(1), (_, _) =>  new ValueTask<int>(0));
        },
    };

    [MemberData(nameof(FallbackOverloadsGeneric))]
    [Theory]
    public void AddFallback_Generic_Ok(Action<ResilienceStrategyBuilder<int>> configure)
    {
        var builder = new ResilienceStrategyBuilder<int>();
        configure(builder);
        builder.Build().Strategy.Should().BeOfType<FallbackResilienceStrategy>();
    }

    [Fact]
    public void AddFallback_Ok()
    {
        var options = new FallbackStrategyOptions();
        options.Handler.SetFallback<int>(handler =>
        {
            handler.ShouldHandle.HandleResult(-1).HandleException<InvalidOperationException>();
            handler.FallbackAction = (_, args) =>
            {
                args.Context.Should().NotBeNull();
                return new ValueTask<int>(1);
            };
        });

        var strategy = new ResilienceStrategyBuilder().AddFallback(options).Build();

        strategy.Execute<int>(_ => -1).Should().Be(1);
        strategy.Execute<int>(_ => throw new InvalidOperationException()).Should().Be(1);
    }

    [Fact]
    public void AddFallback_InvalidOptions_Throws()
    {
        new ResilienceStrategyBuilder()
            .Invoking(b => b.AddFallback(new FallbackStrategyOptions { Handler = null! }))
            .Should()
            .Throw<ValidationException>()
            .WithMessage("The fallback strategy options are invalid.*");
    }

    [Fact]
    public void AddFallbackT_InvalidOptions_Throws()
    {
        new ResilienceStrategyBuilder<double>()
            .Invoking(b => b.AddFallback(new FallbackStrategyOptions<double> { ShouldHandle = null! }))
            .Should()
            .Throw<ValidationException>()
            .WithMessage("The fallback strategy options are invalid.*");
    }
}
