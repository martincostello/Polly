```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method                                         | Mean     | Error     | StdDev    | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------------- |---------:|----------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| ExecuteStrategyPipeline_Generic_V7             | 1.654 μs | 0.0246 μs | 0.0344 μs | 1.648 μs |  1.00 |    0.00 | 0.2975 |    2824 B |        1.00 |
| ExecuteStrategyPipeline_Generic_V8             | 1.572 μs | 0.0103 μs | 0.0148 μs | 1.574 μs |  0.95 |    0.02 | 0.0038 |      40 B |        0.01 |
| ExecuteStrategyPipeline_GenericTelemetry_V8    | 2.597 μs | 0.1356 μs | 0.1987 μs | 2.487 μs |  1.58 |    0.13 | 0.0038 |      40 B |        0.01 |
| ExecuteStrategyPipeline_NonGeneric_V8          | 1.542 μs | 0.1612 μs | 0.2312 μs | 1.405 μs |  0.94 |    0.14 | 0.0038 |      40 B |        0.01 |
| ExecuteStrategyPipeline_NonGenericTelemetry_V8 | 2.186 μs | 0.2143 μs | 0.3208 μs | 1.973 μs |  1.31 |    0.20 | 0.0038 |      40 B |        0.01 |
