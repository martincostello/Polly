```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method             | Components | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------- |----------- |------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **ExecutePipeline_V7** | **1**          |    **90.24 ns** |  **1.555 ns** |  **2.279 ns** |  **1.00** |    **0.00** | **0.0323** |     **304 B** |        **1.00** |
| ExecutePipeline_V8 | 1          |   107.92 ns |  6.526 ns |  9.768 ns |  1.19 |    0.11 |      - |         - |        0.00 |
|                    |            |             |           |           |       |         |        |           |             |
| **ExecutePipeline_V7** | **2**          |   **253.41 ns** | **16.389 ns** | **23.505 ns** |  **1.00** |    **0.00** | **0.0587** |     **552 B** |        **1.00** |
| ExecutePipeline_V8 | 2          |   134.87 ns | 18.296 ns | 27.385 ns |  0.55 |    0.10 |      - |         - |        0.00 |
|                    |            |             |           |           |       |         |        |           |             |
| **ExecutePipeline_V7** | **5**          |   **475.87 ns** |  **2.347 ns** |  **3.513 ns** |  **1.00** |    **0.00** | **0.1373** |    **1296 B** |        **1.00** |
| ExecutePipeline_V8 | 5          |   175.10 ns |  0.799 ns |  1.171 ns |  0.37 |    0.00 |      - |         - |        0.00 |
|                    |            |             |           |           |       |         |        |           |             |
| **ExecutePipeline_V7** | **10**         | **1,037.66 ns** | **20.373 ns** | **30.493 ns** |  **1.00** |    **0.00** | **0.2689** |    **2536 B** |        **1.00** |
| ExecutePipeline_V8 | 10         |   357.17 ns |  7.065 ns | 10.132 ns |  0.34 |    0.01 |      - |         - |        0.00 |
