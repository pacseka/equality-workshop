using Equality.Classes.ValueObjects;

namespace Equality.Classes;
public class UserClass : ValueObject
{
    private UserAddressesClass _addresses;

    public UserClass(IReadOnlyList<AddressClass> addresses = null)
    {
        _addresses = new UserAddressesClass(addresses ?? new List<AddressClass>());
    }

    public int Id { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public UserClass AddAddress(AddressClass address)
    {
        var addresses = _addresses.Add(address);

        return new UserClass
        {
            Id = Id,
            LastName = LastName,
            FirstName = FirstName,
            _addresses = addresses
        };
    }

    protected override IList<object> EqualityComponents => new List<object> { Id, LastName, FirstName, _addresses };
}
