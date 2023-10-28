// See https://github.com/App-vNext/Polly/issues/1732#issuecomment-1782466692
var component1 = Polly.Utils.Pipeline.PipelineComponent.Empty;
var component2 = Polly.Utils.Pipeline.PipelineComponent.Empty;
var pipeline = Polly.Utils.Pipeline.CompositeComponent.Create([component1, component2], null!, null!);

await pipeline.ExecuteCore<int, int>((state, context) => default, default!, default);

Console.WriteLine("Hello Polly!");
