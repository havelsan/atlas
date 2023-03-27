using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicForms.PostScript
{
    public class DemoTestPost
    {
        public static object PostScript(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(parameters.ToString());
                return new ResponseTest()
                {
                    Result = param.Result,
                    Message = "Test"
                };
            }

            return new ResponseTest()
            {
                Result = true,
                Message = "Test"
            };
        }
    }

    
}
