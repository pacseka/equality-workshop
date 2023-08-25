namespace Equality;

// ValueObject or Entity
public record User
{

    private UserAddresses _userAddresses;

    public static User None => new()
    {
        Id = 0,
        FirstName = string.Empty,
        LastName = string.Empty,
        UserId = UserId.Undefined,
        _userAddresses = UserAddresses.Empty

        #region Equality
        //Equality azonnal elromlik
        //AnotherAddresses = new List<Address>()
        #endregion
    };

    public User(IReadOnlyList<Address> addresses = null)
    {
        _userAddresses = new UserAddresses(addresses ?? new List<Address>());
    }

    public UserId UserId { get; init; }

    public required int Id { get; set; }

    public string LastName { get; init; }

    public string FirstName { get; init; }

    public IReadOnlyList<Address> Addresses => _userAddresses.Addresses;

    public User AddAddress(Address address)
    {
        var userAddresses = _userAddresses.Add(address);

        //var user = new User(userAddresses.Addresses);

        return this with
        {
            _userAddresses = userAddresses
        };
    }

    #region AnotherAddresses - ez így rossz
    public IReadOnlyList<Address> AnotherAddresses { get; init; }

    public User AddAnotherAddress(Address address)
    {
        var anotherAddresses = AnotherAddresses?.ToList() ?? new List<Address>();

        anotherAddresses.Add(address);

        return this with
        {
            AnotherAddresses = anotherAddresses
        };
    }
    #endregion AnotherAddresses
}
