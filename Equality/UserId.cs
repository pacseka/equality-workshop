namespace Equality;

// ValueObject
public record UserId
{
    public static UserId Undefined => new()
    {
        Value = 0
    };

    public required int Value { get; init; }
}
