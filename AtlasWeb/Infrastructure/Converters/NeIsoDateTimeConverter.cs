using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace Infrastructure.Converters
{
    public class NeIsoDateTimeConverter : DateTimeConverterBase
    {
        private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";
        private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;
        private string _dateTimeFormat;
        private CultureInfo _culture;
        public string DateTimeFormat
        {
            get
            {
                return _dateTimeFormat ?? string.Empty;
            }

            set
            {
                _dateTimeFormat = (string.IsNullOrEmpty(value)) ? null : value;
            }
        }

        public CultureInfo Culture
        {
            get
            {
                return _culture ?? CultureInfo.CurrentCulture;
            }

            set
            {
                _culture = value;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            bool nullable = (objectType.GetGenericTypeDefinition() == typeof(Nullable<>));
#if !NET20
            Type t = (nullable) ? Nullable.GetUnderlyingType(objectType) : objectType;
#endif
            if (reader.TokenType == JsonToken.Null)
            {
                if (!nullable)
                {
                    throw new ApplicationException($"Cannot convert null value to.");
                }

                return null;
            }

            if (reader.TokenType == JsonToken.Date)
            {
#if !NET20
                if (t == typeof(DateTimeOffset))
                {
                    return (reader.Value is DateTimeOffset) ? reader.Value : new DateTimeOffset((DateTime)reader.Value);
                }

                // converter is expected to return a DateTime
                if (reader.Value is DateTimeOffset)
                {
                    return ((DateTimeOffset)reader.Value).DateTime;
                }

#endif
                return reader.Value;
            }

            if (reader.TokenType != JsonToken.String)
            {
                throw new ApplicationException("Unexpected token parsing date. Expected String, got {0}.");
            }

            string dateText = reader.Value.ToString();
            if (string.IsNullOrEmpty(dateText) && nullable)
            {
                return null;
            }

#if !NET20
            if (t == typeof(DateTimeOffset))
            {
                if (!string.IsNullOrEmpty(_dateTimeFormat))
                {
                    return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
                }
                else
                {
                    return DateTimeOffset.Parse(dateText, Culture, _dateTimeStyles);
                }
            }

#endif
            if (!string.IsNullOrEmpty(_dateTimeFormat))
            {
                return DateTime.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
            }
            else
            {
                return DateTime.Parse(dateText, Culture, _dateTimeStyles);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}