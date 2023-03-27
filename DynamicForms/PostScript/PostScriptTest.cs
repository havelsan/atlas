using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicForms.PostScript
{
    public class PostScriptTest
    {
        public static object PostScript(string parameters)
        {
            if(!string.IsNullOrEmpty(parameters))
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(parameters.ToString());
            }

            return new ResponseTest()
            {
                Result = true
            };
        }
    }

}
