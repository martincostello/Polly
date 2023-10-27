using Polly.Telemetry;
using Polly.Utils.Pipeline;

namespace Polly.Core.Benchmarks;

public class CompositeComponentBenchmark
{
    private ResilienceContext? _context;
    private PipelineComponent? _unfriendly;
    private PipelineComponent? _friendly;

    [GlobalSetup]
    public void Setup()
    {
        var first = PipelineComponent.Empty;
        var second = PipelineComponent.Empty;
        var source = new ResilienceTelemetrySource("a", "b", "c");
        var telemetry = new ResilienceStrategyTelemetry(source, null);

        _unfriendly = CompositeComponent.Create(new[] { first, second }, telemetry!, TimeProvider.System, false);
        _friendly = CompositeComponent.Create(new[] { first, second }, telemetry, TimeProvider.System, true);
        _context = ResilienceContextPool.Shared.Get();
    }

    [Benchmark(Baseline = true)]
    public async Task Unfriendly()
        => await _unfriendly!.ExecuteCore(
            async (_, state) =>
                await Outcome.FromResultAsValueTask(state).ConfigureAwait(false), _context!, 42).ConfigureAwait(false);

    [Benchmark]
    public async Task Friendly()
        => await _friendly!.ExecuteCore(
            async (_, state) =>
                await Outcome.FromResultAsValueTask(state).ConfigureAwait(false), _context!, 42).ConfigureAwait(false);
}
