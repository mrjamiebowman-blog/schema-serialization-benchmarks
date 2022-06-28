using System.Diagnostics.CodeAnalysis;

namespace MrJB.SchemaSerialization.Benchmarks.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class EventBusAttribute : Attribute
{
    public string? ReplyTo { get; set; }

    public string? ReplyToSessionId { get; set; }
    
    public EventBusAttribute([AllowNull] string replyTo, [AllowNull] string replyToSessionId)
    {
        ReplyTo = replyTo;
        ReplyToSessionId = replyToSessionId;
    }
}
