using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace AtlasDataModel
{
    public static class GuidStringValueConverter
    {

        public static readonly ValueConverter<Guid, string> Instance = new ValueConverter<Guid, string>(v => v.ToString(), v => Guid.Parse(v));

        public static readonly GuidToStringConverter InstanceForNullable = new GuidToStringConverter();

        public static string NullableGuidToString(Guid? guidValue)
        {
            if (guidValue.HasValue)
                return guidValue.Value.ToString();

            return string.Empty;
        }

        public static Guid? StringToNullableGuid(string stringValue)
        {
            if (Guid.TryParse(stringValue, out Guid guidValue))
                return guidValue;

            return null;
        }


    }
}
