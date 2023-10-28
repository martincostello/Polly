```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method                                         | Mean      | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------------- |----------:|---------:|---------:|------:|--------:|----------:|------------:|
| ExecuteOutcomeAsync                            |  93.58 ns | 3.068 ns | 4.498 ns |  1.00 |    0.00 |         - |          NA |
| ExecuteAsync_ResilienceContextAndState         | 196.37 ns | 4.536 ns | 6.648 ns |  2.10 |    0.12 |         - |          NA |
| ExecuteAsync_CancellationToken                 | 196.35 ns | 3.584 ns | 5.365 ns |  2.10 |    0.12 |         - |          NA |
| ExecuteAsync_GenericStrategy_CancellationToken | 191.34 ns | 3.144 ns | 4.609 ns |  2.05 |    0.10 |         - |          NA |
| Execute_ResilienceContextAndState              |  90.39 ns | 1.589 ns | 2.378 ns |  0.97 |    0.04 |         - |          NA |
| Execute_CancellationToken                      |  79.39 ns | 6.090 ns | 8.537 ns |  0.85 |    0.08 |         - |          NA |
| Execute_GenericStrategy_CancellationToken      |  71.06 ns | 0.837 ns | 1.146 ns |  0.76 |    0.04 |         - |          NA |
