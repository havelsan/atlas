using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Core.Controllers
{
    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //return serializer.Serialize(obj);
        }
        public static string ToJSON(this object obj, int recursionDepth)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings { MaxDepth = recursionDepth });
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //serializer.RecursionLimit = recursionDepth;
            //return serializer.Serialize(obj);
        }
    }
}
