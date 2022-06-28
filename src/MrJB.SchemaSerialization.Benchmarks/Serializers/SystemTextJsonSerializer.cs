using BenchmarkDotNet.Attributes;
using MrJB.SchemaSerialization.Benchmarks.Models;
using System.Text.Json;

namespace MrJB.SchemaSerialization.Benchmarks.Serializers;

public class SystemTextJsonSerializer : BaseSerializer
{
    [Benchmark]
    public void SystemTextJson()
    {
        // system.text.json
        var json = JsonSerializer.Serialize(Customer1);
    }
}
