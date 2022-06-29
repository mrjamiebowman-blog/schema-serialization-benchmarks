using Avro;
using Avro.Reflect;
using BenchmarkDotNet.Attributes;
using MrJB.SchemaSerialization.Benchmarks.Bases;
using MrJB.SchemaSerialization.Benchmarks.Models;

namespace MrJB.SchemaSerialization.Benchmarks;

/// <summary>
/// Will benchmark on JSON/XML/Binary/Avro serializers.
/// </summary>
public class SerializerBenchmarks : BaseSerializer
{
    /// <summary>
    /// JSON.NET Benchmark
    /// </summary>
    [BenchmarkCategory(Categories.JsonSerializers)]
    [Benchmark(Description = "JSON.Net")]
    public void JsonNet()
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(CustomerMetadata1);
    }

    /// <summary>
    /// System.Text.Json Benchmark
    /// </summary>
    [BenchmarkCategory(Categories.JsonSerializers)]
    [Benchmark(Description = "System.Text.Json")]
    public void SystemTextJson()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(CustomerMetadata1);
    }

    /// <summary>
    /// Avro Serialization
    /// </summary>
    [BenchmarkCategory(Categories.JsonSerializers)]
    [Benchmark(Description = "Avro Serialization")]
    public void AvroSerialize()
    {
        var unionSchema = CustomerSchema as UnionSchema;

        var cache = new ClassCache();
        cache.LoadClassCache(typeof(Customer), unionSchema[0]);

    }

    /// <summary>
    /// Avro DeSerialization
    /// </summary>
    [BenchmarkCategory(Categories.JsonSerializers)]
    [Benchmark(Description = "Avro Deserialization")]
    public void AvroDeserialize()
    {

    }

    // TODO: utf8 

    // TODO: protobuf
}
