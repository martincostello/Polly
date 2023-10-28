```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method                   | Mean     | Error    | StdDev   | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |---------:|---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| ExecuteCircuitBreaker_V7 | 230.7 ns | 18.49 ns | 27.10 ns | 225.2 ns |  1.00 |    0.00 | 0.0534 |     504 B |        1.00 |
| ExecuteCircuitBreaker_V8 | 423.3 ns | 42.91 ns | 60.16 ns | 383.5 ns |  1.89 |    0.44 |      - |         - |        0.00 |
