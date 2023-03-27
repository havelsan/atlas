using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Reflection;
using TTInstanceManagement;
using TTStorageManager.Attributes;
using Infrastructure.Models;
using TTDefinitionManagement;

namespace Infrastructure.Helpers
{
    public static class Util
    {
        public static List<ValidationConfig> GetValidationConfigs(List<ValidationAttribute> attributes)
        {
            List<ValidationConfig> configs = null;
            if (attributes != null && attributes.Count > 0)
            {
                configs = new List<ValidationConfig>();
                foreach (var attr in attributes)
                {
                    if ((attr as StringLengthAttribute) != null)
                    {
                        var range = attr as StringLengthAttribute;
                        configs.Add(new ValidationConfig()
                        {Type = "Length", Message = range.ErrorMessage, Min = range.MinimumLength, Max = range.MaximumLength});
                    }
                }
            }

            return configs;
        }

        public static ExpandoObject CreateExpandoFromObject(this TTObject source, IEnumerable<TTListColumnDef> listColumnDefs= null)
        {
            var result = new ExpandoObject();
            IDictionary<string, object> dictionary = result;
            dictionary["ObjectID"] = source.ObjectID;
            dictionary["ObjectDefID"] = source.ObjectDef.ID;
            foreach (var propertydef in source.ObjectDef.AllPropertyDefs.Values)
            {
                dictionary[propertydef.CodeName] = source[propertydef.CodeName];
            }

            foreach (var reldef in source.ObjectDef.AllParentRelationDefs.Values)
            {
                dictionary[reldef.CodeName] = source[reldef.CodeName];
            }

            var seriliazableCustomProperties =
                from p in source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty)where p.GetCustomAttribute(typeof (TTSerializePropertyAttribute), true) != null
                select p;
            foreach (var propertyInfo in seriliazableCustomProperties)
            {
                dictionary[propertyInfo.Name] = propertyInfo.GetValue(source);
            }

            if ( listColumnDefs != null)
            {
                foreach(var listColumnDef in listColumnDefs)
                {
                    if (dictionary.Keys.Contains(listColumnDef.MemberName) == false )
                    {
                        var propertyValue = TTUtils.Globals.FollowPropertyPath(source, listColumnDef.MemberName);
                        if (propertyValue != null)
                        {
                            var targetPropertName = listColumnDef.PropertyDef?.CodeName ?? listColumnDef.MemberName;
                            dictionary[targetPropertName] = propertyValue;
                        }
                    }
                }
            }

            return result;
        }
    }
}