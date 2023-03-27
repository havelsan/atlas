using Infrastructure.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using TTDataDictionary;

namespace Infrastructure.Converters
{
    public class CurrencyConverter : CustomCreationConverter<Currency>
    {
        public override Currency Create(Type objectType)
        {
            return new Currency();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var currency = Create(objectType);
            JToken token = JToken.Load(reader);
            if (!token.IsNullOrEmpty())
            {
                currency = token.Value<double>();
            }

            return currency;
        }
    }
}
