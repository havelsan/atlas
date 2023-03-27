using Infrastructure.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Helpers
{
    public static class HttpHeaderHelper
    {
        public static Guid? GetHeaderValueAsGuid(this IHeaderDictionary headers, string name)
        {
            var stringValues = new StringValues();
            if (headers.TryGetValue(name, out stringValues))
            {
                var guidStringValue = stringValues.FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(guidStringValue))
                {
                    Guid guidValue;
                    if (Guid.TryParse(guidStringValue, out guidValue))
                        return guidValue;
                }
            }

            return null;
        }

        public static Guid? GetSelectedEpisodeActionID(this IHeaderDictionary headers)
        {
            return GetHeaderValueAsGuid(headers, CustomHeaderNames.ActiveEpisodeActionID);
        }

        public static Guid? GetSelectedEpisodeID(this IHeaderDictionary headers)
        {
            return GetHeaderValueAsGuid(headers, CustomHeaderNames.ActiveEpisodeID);
        }

        public static Guid? GetSelectedPatientID(this IHeaderDictionary headers)
        {
            return GetHeaderValueAsGuid(headers, CustomHeaderNames.ActivePatientID);
        }

        public static string GetCurrentCulture(this IHeaderDictionary headers)
        {
            var stringValues = new StringValues();
            if (headers.TryGetValue(CustomHeaderNames.CurrentCulture, out stringValues))
            {
                return stringValues.FirstOrDefault();
            }

            return null;
        }

        public static IEnumerable<string> GetHeaderValues(this IHeaderDictionary headers, string name)
        {
            var stringValues = new StringValues();
            if (headers.TryGetValue(name, out stringValues))
            {
                return stringValues;
            }

            return null;
        }
    }
}