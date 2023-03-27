using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicForms.CheckScript
{
    public class DemoTestCheck
    {
        public static object CheckScript(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(parameters.ToString());
                return new ResponseTest()
                {
                    Result = param.Result,
                    Message = "Kontrolden geçemedi"
                };
            }
            return new ResponseTest()
            {
                Result = false,
                Message = "Kontrolden geçemedi"
            };
        }
    }
}
