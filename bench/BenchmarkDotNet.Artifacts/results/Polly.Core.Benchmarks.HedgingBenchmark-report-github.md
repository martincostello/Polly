```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method                      | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |---------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| Hedging_Primary             | 1.060 μs | 0.0584 μs | 0.0874 μs |  1.00 |    0.00 | 0.0038 |      40 B |        1.00 |
| Hedging_Secondary           | 1.481 μs | 0.0577 μs | 0.0827 μs |  1.39 |    0.15 | 0.0191 |     184 B |        4.60 |
| Hedging_Primary_AsyncWork   | 3.925 μs | 0.1376 μs | 0.2059 μs |  3.73 |    0.37 | 0.2213 |    2076 B |       51.90 |
| Hedging_Secondary_AsyncWork | 4.886 μs | 0.2097 μs | 0.3008 μs |  4.56 |    0.29 | 0.2213 |    2095 B |       52.38 |
