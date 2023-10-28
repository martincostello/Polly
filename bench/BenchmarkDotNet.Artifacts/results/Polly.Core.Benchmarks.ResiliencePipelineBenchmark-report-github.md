```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method                                         | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| ExecuteOutcomeAsync                            |  99.22 ns |  2.351 ns |  3.372 ns |  1.00 |    0.00 |         - |          NA |
| ExecuteAsync_ResilienceContextAndState         | 164.60 ns |  3.760 ns |  5.628 ns |  1.66 |    0.08 |         - |          NA |
| ExecuteAsync_CancellationToken                 | 170.61 ns |  4.835 ns |  6.934 ns |  1.72 |    0.09 |         - |          NA |
| ExecuteAsync_GenericStrategy_CancellationToken | 171.14 ns | 12.366 ns | 17.335 ns |  1.73 |    0.18 |         - |          NA |
| Execute_ResilienceContextAndState              |  81.45 ns |  2.321 ns |  3.177 ns |  0.82 |    0.05 |         - |          NA |
| Execute_CancellationToken                      |  80.70 ns |  1.248 ns |  1.868 ns |  0.81 |    0.03 |         - |          NA |
| Execute_GenericStrategy_CancellationToken      |  81.57 ns |  1.336 ns |  1.916 ns |  0.82 |    0.03 |         - |          NA |
