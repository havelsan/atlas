using Infrastructure.Constants;
using System.Xml.Linq;

namespace Infrastructure.Helpers
{
    internal static class PropertyHelper
    {
        internal static string GetTextProperty(this XElement elementProperties)
        {
            return GetPropertyAsString(elementProperties, AttributeNames.Text);
        }

        internal static string GetPropertyAsString(this XElement elementProperties, string propertyName)
        {
            var text = (string)elementProperties.Attribute(propertyName);
            return text;
        }

        internal static int GetHeightPropertyValue(this XElement elementProperties)
        {
            return GetPropertyAsInteger(elementProperties, AttributeNames.Height);
        }

        internal static int GetWidthPropertyValue(this XElement elementProperties)
        {
            return GetPropertyAsInteger(elementProperties, AttributeNames.Width);
        }

        internal static int GetTopPropertyValue(this XElement elementProperties)
        {
            return GetPropertyAsInteger(elementProperties, AttributeNames.Top);
        }

        internal static int GetLeftPropertyValue(this XElement elementProperties)
        {
            return GetPropertyAsInteger(elementProperties, AttributeNames.Left);
        }

        internal static int GetPropertyAsInteger(this XElement elementProperties, string propertyName)
        {
            var stringValue = (string)elementProperties.Attribute(propertyName);
            int intValue = 0;
            int.TryParse(stringValue, out intValue);
            return intValue;
        }

        internal static bool GetPropertyAsBoolean(this XElement elementProperties, string propertyName)
        {
            var stringValue = (string)elementProperties.Attribute(propertyName);
            bool boolValue = false;
            bool.TryParse(stringValue, out boolValue);
            return boolValue;
        }
    }
}