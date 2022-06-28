using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace MrJB.SchemaSerialization.Benchmarks.Serializers;

public class NewtonSoftSerializer : BaseSerializer
{
    [Benchmark]
    public void NewtonSoft()
    {
        // system.text.json
        var json = JsonConvert.SerializeObject(Customer1);
    }
}
