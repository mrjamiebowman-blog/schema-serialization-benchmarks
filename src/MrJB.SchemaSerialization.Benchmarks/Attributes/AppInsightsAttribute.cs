using System.Diagnostics.CodeAnalysis;

namespace MrJB.SchemaSerialization.Benchmarks.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class AppInsightsAttribute : Attribute
{
    public string? OperationId { get; set; }

    public string? ParentId { get; set; }

    public AppInsightsAttribute([AllowNull] string operationId, [AllowNull] string parentId)
    {
        OperationId = operationId;
        ParentId = parentId;
    }
}
