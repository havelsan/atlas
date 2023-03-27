using DynamicForms.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.CheckScript
{
    public class CheckScriptTest
    {
        public static object CheckScript(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(parameters.ToString());
                return new ResponseTest()
                {
                    Result = param.result,
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
