using Equality.Classes.ValueObjects;

namespace Equality.Classes;
public class UserAddressesClass : ValueObject
{
    private readonly IReadOnlyList<AddressClass> _addresses;

    public UserAddressesClass(IReadOnlyList<AddressClass> addresses = null)
    {
        _addresses = addresses ?? new List<AddressClass>();
    }

    public UserAddressesClass Add(AddressClass address)
    {
        var addresses = _addresses.ToList();
        addresses.Add(address);

        return new UserAddressesClass(addresses);
    }

    protected override IList<object> EqualityComponents => new List<object>(_addresses);
}
