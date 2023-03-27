using System.Collections.Generic;

namespace Infrastructure.Constants
{
    internal class CssClassNames
    {
        internal static readonly object FromControlClass = new
        {
        @class = "form-control"
        }

        ;
        internal static readonly IDictionary<string, object> FormControlClassList = new Dictionary<string, object>()
        {{"class", "form-control"}, };
    }
}