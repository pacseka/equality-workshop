namespace Equality;

// ValueObject
public record Address
{
    public string Street { get; init; }

    public string City { get; init; }

    public string State { get; init; }

    public string ZipCode { get; init; }
}
