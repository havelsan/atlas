using System.Configuration;

namespace RuleCheckerService
{
    static class AppSettingHelper
    {
        public static int GetAppSettingAsInteger(string settingName, int defaultValue)
        {
            string settingValue = ConfigurationManager.AppSettings[settingName];

            if (string.IsNullOrEmpty(settingValue))
                return defaultValue;

            int settingIntValue = defaultValue;

            if (int.TryParse(settingValue, out settingIntValue))
            {
                return settingIntValue;
            }

            return defaultValue;
        }

        public static string GetAppSettingAsString(string settingName)
        {
            string settingValue = ConfigurationManager.AppSettings[settingName];

            return settingValue;
        }

    }
}
