namespace MrJB.SchemaSerialization.Benchmarks.Models;

public record Customer
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string EmailAddress { get; set; }

    public string PhoneNumber { get; set; }
}
