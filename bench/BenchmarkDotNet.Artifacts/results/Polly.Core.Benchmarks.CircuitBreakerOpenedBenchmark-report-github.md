```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method                    | Mean        | Error       | StdDev      | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |------------:|------------:|------------:|------:|--------:|-------:|----------:|------------:|
| ExecuteAsync_Exception_V7 | 20,211.1 ns | 1,314.78 ns | 1,927.18 ns | 36.51 |    4.48 | 0.3052 |    2888 B |       15.04 |
| ExecuteAsync_Exception_V8 | 15,024.9 ns |   332.65 ns |   497.89 ns | 26.92 |    0.85 | 0.1831 |    1816 B |        9.46 |
| ExecuteAsync_Outcome_V8   |    557.6 ns |    13.57 ns |    19.46 ns |  1.00 |    0.00 | 0.0200 |     192 B |        1.00 |
