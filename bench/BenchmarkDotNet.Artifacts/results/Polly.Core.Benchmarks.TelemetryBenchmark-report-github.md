```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 7.0.403
  [Host] : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method  | Telemetry | Enrichment | Mean      | Error     | StdDev    | Median    | Allocated |
|-------- |---------- |----------- |----------:|----------:|----------:|----------:|----------:|
| **Execute** | **False**     | **False**      |  **94.51 ns** |  **3.687 ns** |  **5.287 ns** |  **93.64 ns** |         **-** |
| **Execute** | **False**     | **True**       |  **92.50 ns** |  **1.448 ns** |  **2.167 ns** |  **92.46 ns** |         **-** |
| **Execute** | **True**      | **False**      | **591.22 ns** | **38.184 ns** | **55.970 ns** | **562.07 ns** |         **-** |
| **Execute** | **True**      | **True**       | **929.80 ns** | **13.760 ns** | **20.595 ns** | **931.06 ns** |         **-** |
