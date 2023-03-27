using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TTConnectionManager;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTUtils;

namespace Core.Models
{
    public class LoadResult
    {
        public IEnumerable data;
        public int totalCount;
        public int groupCount;
        public object[] summary;

        public List<T> GetData<T>()
        {
            return data.Cast<T>().ToList();
        }
        public List<dynamic> GetAsDynamic(IEnumerable value)
        {
            List<dynamic> result = new List<dynamic>();
            if (value == null)
            {
                return result;
            }

            if(value.Cast<object>().FirstOrDefault() == null)
            {
                return result;
            }
            var type = TypeDescriptor.GetProperties(value.Cast<object>().FirstOrDefault().GetType());
            
            foreach (var item in value)
            {
                IDictionary<string, object> expando = new ExpandoObject();
                foreach (PropertyDescriptor property in type)
                {
                    expando.Add(property.Name, property.GetValue(item));

                }
                result.Add(expando);
            }

            return result;
        }
    }
}
