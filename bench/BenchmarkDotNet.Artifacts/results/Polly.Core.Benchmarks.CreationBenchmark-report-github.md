```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method      | Mean       | Error     | StdDev    | Gen0   | Allocated |
|------------ |-----------:|----------:|----------:|-------:|----------:|
| Fallback_V7 |   111.4 ns |   8.03 ns |  12.02 ns | 0.0509 |     480 B |
| Fallback_V8 | 6,426.2 ns | 639.95 ns | 938.03 ns | 0.5798 |    5472 B |
