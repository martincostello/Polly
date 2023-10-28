```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method            | Mean     | Error   | StdDev  | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------ |---------:|--------:|--------:|------:|--------:|-------:|----------:|------------:|
| ExecuteTimeout_V7 | 292.0 ns | 4.94 ns | 7.23 ns |  1.00 |    0.00 | 0.0772 |     728 B |        1.00 |
| ExecuteTimeout_V8 | 298.1 ns | 4.63 ns | 6.33 ns |  1.02 |    0.03 |      - |         - |        0.00 |
