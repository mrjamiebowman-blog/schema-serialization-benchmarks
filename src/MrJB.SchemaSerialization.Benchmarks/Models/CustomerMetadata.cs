using MrJB.SchemaSerialization.Benchmarks.Attributes;

namespace MrJB.SchemaSerialization.Benchmarks.Models;

[EventBus("reply-topic", "session-id")]
[AppInsights("operation-id", "parent-id")]
public record CustomerMetadata : Customer
{

}
