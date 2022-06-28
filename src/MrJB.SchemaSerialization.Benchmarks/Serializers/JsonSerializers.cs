using BenchmarkDotNet.Attributes;
using MrJB.SchemaSerialization.Benchmarks.Models;

namespace MrJB.SchemaSerialization.Benchmarks.Serializers;

public class JsonSerializers : BaseSerializer
{
    [BenchmarkCategory(Categories.JsonSerializers)]
    [Benchmark(Description = "JSON.Net")]
    public void JsonNet()
    {
        // JSON.NET
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(Customer1);
    }

    [BenchmarkCategory(Categories.JsonSerializers)]
    [Benchmark(Description = "System.Text.Json")]
    public void SystemTextJson()
    {
        // system.text.json
        var json = System.Text.Json.JsonSerializer.Serialize(Customer1);
    }
}
