using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;

namespace RuleChecker.ServiceHost.Helpers
{
    static class AppSettingHelper
    {
        /// <summary>
        /// GetSettingsAsInteger
        /// </summary>
        /// <param name="configSection"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetSettingsAsInteger(this IConfigurationSection configSection, string key, int defaultValue)
        {
            var stringValue = configSection[key];
            int intValue = defaultValue;
            int.TryParse(stringValue, out intValue);
            return intValue;
        }

        /// <summary>
        /// GetSettingsAsLong
        /// </summary>
        /// <param name="configSection"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long GetSettingsAsLong(this IConfigurationSection configSection, string key, long defaultValue)
        {
            var stringValue = configSection[key];
            long longValue = defaultValue;
            long.TryParse(stringValue, out longValue);
            return longValue;
        }

        /// <summary>
        /// GetSettingsAsBoolean
        /// </summary>
        /// <param name="configSection"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool GetSettingsAsBoolean(this IConfigurationSection configSection, string key, bool defaultValue)
        {
            var stringValue = configSection[key];
            bool boolValue = defaultValue;
            bool.TryParse(stringValue, out boolValue);
            return boolValue;
        }

        public static TimeSpan GetSettingsAsTimeSpan(this IConfigurationSection configSection, string key, TimeSpan defaultValue)
        {
            var stringValue = configSection[key];
            TimeSpan timeSpanValue = defaultValue;
            TimeSpan.TryParse(stringValue, out timeSpanValue);
            return timeSpanValue;
        }
    }
}
