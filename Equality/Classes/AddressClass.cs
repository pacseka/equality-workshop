using Equality.Classes.ValueObjects;

namespace Equality.Classes;
public class AddressClass : ValueObject
{
    public string Street { get; init; }

    public string City { get; init; }

    public string State { get; init; }

    public string ZipCode { get; init; }

    protected override IList<object> EqualityComponents => new List<object> { Street, City, State, ZipCode };
}
