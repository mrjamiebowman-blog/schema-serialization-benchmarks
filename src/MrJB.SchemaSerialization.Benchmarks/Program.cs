using BenchmarkDotNet.Running;

Console.WriteLine("Schema Serialization Benchmarks: Starting");

// run Benchmarks
var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
