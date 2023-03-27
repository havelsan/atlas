using Infrastructure.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using TTDataDictionary;

namespace Infrastructure.Converters
{
    public class BigCurrencyConverter : CustomCreationConverter<BigCurrency>
    {
        public override BigCurrency Create(Type objectType)
        {
            return new BigCurrency();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var bigCurrency = Create(objectType);
            JToken token = JToken.Load(reader);
            if (!token.IsNullOrEmpty())
            {
                bigCurrency = token.Value<decimal>();
            }

            return bigCurrency;
        }
    }
}
