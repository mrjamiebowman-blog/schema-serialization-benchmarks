// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;

Console.WriteLine("Schema Serialization Benchmarks: Starting");

// Benchmark: System.Text.Json

// Benchmark: Newtonsoft.JSON

// Benchmark: AutoMapper

// Benchmark: Reflection

// Benchmark: Custom Attributes

// run Benchmarks
var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
