#if SYSTEM_TEXT_JSON
using System;
using System.Text.Json;
using JWT.Serializers.Converters;

namespace JWT.Serializers
{
    /// <summary>
    /// JSON serializer using Newtonsoft.Json implementation.
    /// </summary>
    public sealed class SystemTextSerializer : IJsonSerializer
    {
        // TODO: Add the default settings and if user adds own settings apply this converter
        private static JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new DictionaryStringObjectJsonConverterCustomWrite()
            }
        };
        
        /// <inheritdoc />
        /// <exception cref="ArgumentNullException" />
        public string Serialize(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return JsonSerializer.Serialize(obj, JsonSerializerOptions);
        }


        /// <inheritdoc />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public object Deserialize(Type type, string json)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));
            if (String.IsNullOrEmpty(json))
                throw new ArgumentException(nameof(json));

            return JsonSerializer.Deserialize(json, type, JsonSerializerOptions);
        }
    }
}
#endif