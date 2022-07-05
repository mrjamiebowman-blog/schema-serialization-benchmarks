using Avro.IO;
using Avro.Reflect;
using BenchmarkDotNet.Attributes;
using MrJB.SchemaSerialization.Benchmarks.Attributes;
using MrJB.SchemaSerialization.Benchmarks.Bases;
using MrJB.SchemaSerialization.Benchmarks.Helpers;
using MrJB.SchemaSerialization.Benchmarks.Models;
using SolTechnology.Avro;

namespace MrJB.SchemaSerialization.Benchmarks;

/// <summary>
/// Will benchmark on JSON/XML/Binary/Avro serializers.
/// </summary>
public class Benchmarks : BaseSerializer
{
    /// <summary>
    /// JSON.NET Benchmark
    /// </summary>
    [BenchmarkCategory(Categories.JsonSerializers)]
    [Benchmark(Description = "JSON.Net")]
    public void JsonNet()
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(Customer1);
    }

    /// <summary>
    /// System.Text.Json Benchmark
    /// </summary>
    [BenchmarkCategory(Categories.JsonSerializers)]
    [Benchmark(Description = "System.Text.Json")]
    public void SystemTextJson()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(Customer1);
    }

    [BenchmarkCategory(Categories.Reflection)]
    [Benchmark(Description = "Set Attribute Values")]
    public void SetAttributeValues()
    {
        // event bus (attribute values)
        AttributeHelper.SetPropertyAttributeValue<Customer, string?, EventBusAttribute>(CustomerMetadata1, attr => attr.ReplyTo);
        AttributeHelper.SetPropertyAttributeValue<Customer, string?, EventBusAttribute>(CustomerMetadata1, attr => attr.ReplyToSessionId);

        // app insight (attribute values)
        AttributeHelper.SetPropertyAttributeValue<Customer, string?, AppInsightsAttribute>(CustomerMetadata1, attr => attr.OperationId);
        AttributeHelper.SetPropertyAttributeValue<Customer, string?, AppInsightsAttribute>(CustomerMetadata1, attr => attr.ParentId);
    }

    [BenchmarkCategory(Categories.Reflection)]
    [Benchmark(Description = "Read Attribute Values")]
    public void ReadAttributeValues()
    {
        // event bus (attribute values)
        var replyTo = AttributeHelper.GetPropertyAttributeValue<Customer, string?, EventBusAttribute>(CustomerMetadata1, attr => attr.ReplyTo);
        var replyToSessionId = AttributeHelper.GetPropertyAttributeValue<Customer, string?, EventBusAttribute>(CustomerMetadata1, attr => attr.ReplyToSessionId);

        // app insight (attribute values)
        var operationId = AttributeHelper.GetPropertyAttributeValue<Customer, string?, AppInsightsAttribute>(CustomerMetadata1, attr => attr.OperationId);
        var parentId = AttributeHelper.GetPropertyAttributeValue<Customer, string?, AppInsightsAttribute>(CustomerMetadata1, attr => attr.ParentId);
    }

    /// <summary>
    /// Avro Serialization
    /// </summary>
    [BenchmarkCategory(Categories.JsonSerializers)]
    [Benchmark(Description = "AvroConvert Serialization")]
    public void AvroConvertSerialize()
    {
        var result = AvroConvert.Serialize(Customer1);
    }

    /// <summary>
    /// Avro DeSerialization
    /// </summary>
    [BenchmarkCategory(Categories.JsonSerializers)]
    [Benchmark(Description = "AvroConvert Deserialization")]
    public void AvroConvertDeserialize()
    {
        var result = AvroConvert.Deserialize<Customer>(_avroCustomerSchemaBytes);
    }

    /// <summary>
    /// Avro Serialization
    /// </summary>
    [BenchmarkCategory(Categories.JsonSerializers)]
    [Benchmark(Description = "Avro Serialization")]
    public void AvroSerialize()
    {
        // avro schema
        var avroWriter = new ReflectWriter<Customer>(CustomerSchema);

        using (var stream = new MemoryStream(256))
        {
            avroWriter.Write(Customer1, new BinaryEncoder(stream));

            // used for deserialization.
            string base64 = Convert.ToBase64String((stream.ToArray()));
        }
    }

    /// <summary>
    /// Avro DeSerialization
    /// </summary>
    [BenchmarkCategory(Categories.JsonSerializers)]
    [Benchmark(Description = "Avro Deserialization")]
    public void AvroDeserialize()
    {
        // bytes
        var encodedBytes = "AApKYW1pZQxCb3dtYW4ybm9yZXBseUBtcmphbWllYm93bWFuLmNvbRAxMTIzNDU2Nw==";
        byte[] bytes = Convert.FromBase64String(encodedBytes);

        // deserialize
        var avroReader = new ReflectReader<Customer>(CustomerSchema, CustomerSchema);

        using (var stream2 = new MemoryStream(bytes))
        {
            var deserialized = avroReader.Read(null, new BinaryDecoder(stream2));
        }

    }

    // TODO: data contracts

    // TODO: utf8 

    // TODO: protobuf
}
