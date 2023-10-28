```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method  | Telemetry | Enrichment | Mean        | Error     | StdDev    | Allocated |
|-------- |---------- |----------- |------------:|----------:|----------:|----------:|
| **Execute** | **False**     | **False**      |    **84.17 ns** |  **1.644 ns** |  **2.461 ns** |         **-** |
| **Execute** | **False**     | **True**       |   **116.51 ns** | **14.607 ns** | **21.864 ns** |         **-** |
| **Execute** | **True**      | **False**      |   **629.53 ns** |  **8.412 ns** | **12.064 ns** |         **-** |
| **Execute** | **True**      | **True**       | **1,054.22 ns** | **16.169 ns** | **24.201 ns** |         **-** |
