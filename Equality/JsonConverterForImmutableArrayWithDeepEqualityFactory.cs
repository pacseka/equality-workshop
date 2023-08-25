using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Equality;
public class JsonConverterForImmutableArrayWithDeepEqualityFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
        => typeToConvert.IsGenericType
        && typeToConvert.GetGenericTypeDefinition() == typeof(ImmutableArrayWithDeepEquality<>);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var elementType = typeToConvert.GetGenericArguments()[0];

        var arrayType = typeof(JsonConverterForImmutableArrayWithDeepEquality<>);

        var converter = (JsonConverter)Activator.CreateInstance(
            arrayType.MakeGenericType(elementType),
            BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: null,
            culture: null)!;

        return converter;
    }

    private class JsonConverterForImmutableArrayWithDeepEquality<T> : JsonConverter<ImmutableArrayWithDeepEquality<T>>
    {
        public override ImmutableArrayWithDeepEquality<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            reader.Read();

            List<T> elements = new();

            while (reader.TokenType != JsonTokenType.EndArray)
            {
                var value = JsonSerializer.Deserialize<T>(ref reader, options);

                if (value is not null)
                {
                    elements.Add(value);
                }

                reader.Read();
            }

            return elements.ToImmutableArrayWithDeepEquality();
        }

        public override void Write(Utf8JsonWriter writer, ImmutableArrayWithDeepEquality<T> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.AsEnumerable(), options);
        }
    }
}
