```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method             | Components | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------- |----------- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **ExecutePipeline_V7** | **1**          |   **103.5 ns** |  **13.11 ns** |  **18.80 ns** |  **1.00** |    **0.00** | **0.0322** |     **304 B** |        **1.00** |
| ExecutePipeline_V8 | 1          |   106.4 ns |  10.87 ns |  16.27 ns |  1.07 |    0.34 |      - |         - |        0.00 |
|                    |            |            |           |           |       |         |        |           |             |
| **ExecutePipeline_V7** | **2**          |   **283.5 ns** |  **10.64 ns** |  **15.93 ns** |  **1.00** |    **0.00** | **0.0587** |     **552 B** |        **1.00** |
| ExecutePipeline_V8 | 2          |   209.9 ns |  16.68 ns |  24.96 ns |  0.74 |    0.09 |      - |         - |        0.00 |
|                    |            |            |           |           |       |         |        |           |             |
| **ExecutePipeline_V7** | **5**          |   **785.2 ns** | **113.88 ns** | **166.92 ns** |  **1.00** |    **0.00** | **0.1373** |    **1296 B** |        **1.00** |
| ExecutePipeline_V8 | 5          |   250.3 ns |   4.50 ns |   6.45 ns |  0.33 |    0.07 |      - |         - |        0.00 |
|                    |            |            |           |           |       |         |        |           |             |
| **ExecutePipeline_V7** | **10**         | **1,216.4 ns** |  **18.40 ns** |  **25.80 ns** |  **1.00** |    **0.00** | **0.2689** |    **2536 B** |        **1.00** |
| ExecutePipeline_V8 | 10         |   454.5 ns |  13.45 ns |  19.71 ns |  0.37 |    0.02 |      - |         - |        0.00 |
