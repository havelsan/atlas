using System;
using System.Collections.Generic;
using System.Linq;
using TTInstanceManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Converters
{
    public class TTObjectJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof (TTObject).IsSubclassOf(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}