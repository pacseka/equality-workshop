namespace Equality.Classes.ValueObjects;
public static class HashCodeHelper
{
    public static int CombineHashCodes(IList<object> objects)
    {
        unchecked
        {
            return objects.Aggregate(17, (h, o) => h * 23 + (o?.GetHashCode() ?? 0));
        }
    }
}
