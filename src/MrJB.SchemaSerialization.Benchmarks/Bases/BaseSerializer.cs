using Avro;
using MrJB.SchemaSerialization.Benchmarks.Models;

namespace MrJB.SchemaSerialization.Benchmarks.Bases;

public abstract class BaseSerializer
{
    public BaseSerializer()
    {
        // load avro schema
        CustomerSchema = LoadAvroSchema();

        // AvroConvert
        _avroCustomerSchemaBytes = File.ReadAllBytes("Avro/customer.data");
    }

    #region Models 

    public Customer Customer1 = new Customer
    {
        FirstName = "Jamie",
        LastName = "Bowman",
        EmailAddress = "noreply@mrjamiebowman.com",
        PhoneNumber = "11234567"
    };

    public CustomerMetadata CustomerMetadata1 = new CustomerMetadata
    {
        FirstName = "Jamie",
        LastName = "Bowman",
        EmailAddress = "noreply@mrjamiebowman.com",
        PhoneNumber = "11234567"
    };

    #endregion

    #region Apache Avro

    public Schema CustomerSchema;

    // AvroConvert
    public Byte[] _avroCustomerSchemaBytes;
    
    public Schema LoadAvroSchema()
    {
        var text = File.ReadAllText("Avro/customer.avro");
        var schema = Schema.Parse(text);
        return schema;
    }

    #endregion
}
