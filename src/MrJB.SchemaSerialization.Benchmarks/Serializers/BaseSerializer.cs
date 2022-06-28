using MrJB.SchemaSerialization.Benchmarks.Models;

namespace MrJB.SchemaSerialization.Benchmarks.Serializers;
public abstract class BaseSerializer
{
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
}
