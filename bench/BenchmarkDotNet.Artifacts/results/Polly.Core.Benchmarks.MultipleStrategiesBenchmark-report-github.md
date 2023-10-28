```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method                                         | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------------- |---------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| ExecuteStrategyPipeline_Generic_V7             | 1.313 μs | 0.0237 μs | 0.0354 μs |  1.00 |    0.00 | 0.2995 |    2824 B |        1.00 |
| ExecuteStrategyPipeline_Generic_V8             | 1.403 μs | 0.0255 μs | 0.0358 μs |  1.07 |    0.04 | 0.0038 |      40 B |        0.01 |
| ExecuteStrategyPipeline_GenericTelemetry_V8    | 2.372 μs | 0.0496 μs | 0.0742 μs |  1.81 |    0.07 | 0.0038 |      40 B |        0.01 |
| ExecuteStrategyPipeline_NonGeneric_V8          | 1.787 μs | 0.0869 μs | 0.1301 μs |  1.36 |    0.09 | 0.0038 |      40 B |        0.01 |
| ExecuteStrategyPipeline_NonGenericTelemetry_V8 | 2.910 μs | 0.2455 μs | 0.3674 μs |  2.22 |    0.26 | 0.0038 |      40 B |        0.01 |
