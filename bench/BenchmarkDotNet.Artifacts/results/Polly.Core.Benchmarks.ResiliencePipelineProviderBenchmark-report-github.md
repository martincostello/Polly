```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method                 | Mean     | Error    | StdDev   | Allocated |
|----------------------- |---------:|---------:|---------:|----------:|
| GetPipeline_Ok         | 14.70 ns | 0.378 ns | 0.553 ns |         - |
| GetPipeline_Generic_Ok | 39.27 ns | 0.722 ns | 1.080 ns |         - |
