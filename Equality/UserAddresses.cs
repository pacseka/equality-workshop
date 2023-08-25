namespace Equality;
public record UserAddresses
{
    private readonly ImmutableArrayWithDeepEquality<Address> _addresses;

    public static UserAddresses Empty => new();

    public UserAddresses(IEnumerable<Address> addresses = null)
    {
        _addresses = addresses?.ToImmutableArrayWithDeepEquality() ?? new List<Address>().ToImmutableArrayWithDeepEquality();
    }

    public UserAddresses Add(Address address)
    {
        var addresses = _addresses.Add(address);

        return new UserAddresses(addresses);
    }

    public IReadOnlyList<Address> Addresses => _addresses.ToList();
}
