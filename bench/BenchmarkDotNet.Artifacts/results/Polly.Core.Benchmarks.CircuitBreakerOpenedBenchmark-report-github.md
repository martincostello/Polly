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
| ExecuteAsync_Exception_V7 | 28,006.2 ns | 3,296.96 ns | 4,934.74 ns | 50.77 |    8.12 | 0.3052 |    2888 B |       15.04 |
| ExecuteAsync_Exception_V8 | 21,172.9 ns | 1,745.06 ns | 2,611.92 ns | 38.65 |    5.76 | 0.1831 |    1816 B |        9.46 |
| ExecuteAsync_Outcome_V8   |    550.5 ns |    20.81 ns |    31.15 ns |  1.00 |    0.00 | 0.0200 |     192 B |        1.00 |
