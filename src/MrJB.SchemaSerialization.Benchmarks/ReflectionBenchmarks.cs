﻿using BenchmarkDotNet.Attributes;
using MrJB.SchemaSerialization.Benchmarks.Attributes;
using MrJB.SchemaSerialization.Benchmarks.Bases;
using MrJB.SchemaSerialization.Benchmarks.Helpers;
using MrJB.SchemaSerialization.Benchmarks.Models;

namespace MrJB.SchemaSerialization.Benchmarks;

public class ReflectionBenchmarks : BaseSerializer
{
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
}
