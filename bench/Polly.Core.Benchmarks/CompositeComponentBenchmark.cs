using Polly.Telemetry;
using Polly.Utils.Pipeline;

namespace Polly.Core.Benchmarks;

public class CompositeComponentBenchmark
{
    private ResilienceContext? _context;
    private PipelineComponent? _component;

    [GlobalSetup]
    public void Setup()
    {
        var first = PipelineComponent.Empty;
        var second = PipelineComponent.Empty;
        var source = new ResilienceTelemetrySource("a", "b", "c");
        var telemetry = new ResilienceStrategyTelemetry(source, null);

        _component = CompositeComponent.Create(new[] { first, second }, telemetry!, TimeProvider.System);
        _context = ResilienceContextPool.Shared.Get();
    }

    [Benchmark]
    public async Task Unfriendly()
        => await _component!.ExecuteCore(
            async (_, state) =>
                await Outcome.FromResultAsValueTask(state).ConfigureAwait(false), _context!, 42).ConfigureAwait(false);
}
