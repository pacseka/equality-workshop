using Equality.Classes;
using KellermanSoftware.CompareNetObjects;

namespace Equality;

[TestClass]
public class EqualityTests
{
    [TestMethod]
    public void CheckImplementedEquality()
    {
        // Arrange
        var addresses = new List<Address>
        {
            new()
            {
                Street = "123 Main St",
                City = "AnyTown",
                State = "NY",
                ZipCode = "12345"
            }
        };

        var user1 = new User(addresses)
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };

        user1 = user1.AddAddress(new Address
        {
            State = "WA"
        });

        var user2 = new User(addresses)
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };

        user2 = user2.AddAddress(new Address
        {
            State = "WA"
        });

        // Act
        var areEqual = user1.Equals(user2);

        // Assert
        Assert.IsTrue(areEqual);
    }

    [TestMethod]
    public void CheckNotImplementedEquality()
    {
        // Arrange
        var addresses = new List<Address>
        {
            new()
            {
                Street = "123 Main St",
                City = "AnyTown",
                State = "NY",
                ZipCode = "12345"
            }
        };

        var user1 = new User(addresses)
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };

        user1 = user1.AddAnotherAddress(new Address
        {
            State = "WA"
        });

        var user2 = new User(addresses)
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };

        user2 = user2.AddAnotherAddress(new Address
        {
            State = "WA"
        });

        // Act
        var areEqual = user1.Equals(user2);

        // Assert
        Assert.IsFalse(areEqual);
    }

    [TestMethod]
    public void CheckNoneEquality()
    {
        // Act
        var areEqual = User.None.Equals(User.None);

        // Assert
        Assert.IsTrue(areEqual);
    }

    [TestMethod]
    public void CheckEntityId()
    {
        // Act
        var areEqual = UserId.Undefined.Equals(User.None.UserId);

        // Assert
        Assert.IsTrue(areEqual);
    }


    [TestMethod]
    public void CheckClassEquality()
    {
        // Arrange
        var user1 = new UserClass
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };

        user1 = user1.AddAddress(new AddressClass
        {
            State = "WA"
        });

        var user2 = new UserClass
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };

        user2 = user2.AddAddress(new AddressClass
        {
            State = "WA"
        });

        // Act
        var areEqual = user1.Equals(user2);

        // Assert
        Assert.IsTrue(areEqual);
    }

    // https://github.com/GregFinzer/Compare-Net-Objects
    [TestMethod]
    public void CompareDifferentObjects()
    {
        // Arrange
        var user1 = new User
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };

        user1 = user1.AddAddress(new Address
        {
            State = "WA"
        });



        var user2 = new UserClass
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };

        user2 = user2.AddAddress(new AddressClass
        {
            State = "WA"
        });

        var compare = new CompareLogic
        {
            Config =
            {
                IgnoreObjectTypes = true
            }
        };

        // Act
        var result = compare.Compare(user1, user2);

        // Assert
        Assert.IsTrue(result.AreEqual);
    }
}
