using Core.Models;
using Infrastructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using TTDataDictionary;
using TTDefinitionManagement;
using TTInstanceManagement;
using static TTConnectionManager.ConnectionManager;
namespace Core.Services
{
    public class LookupService
    {
        public IList<EnumLookupItem> EnumList(string enumName)
        {
            var dataTypes = TTObjectDefManager.Instance.DataTypes;
            var queryEnumnTypes =
                from d in dataTypes.OfType<TTDataType>()where d.PrimitiveType is EnumType
                select d;
            var query =
                from e in queryEnumnTypes
                where e.Name == enumName
                select e;
            var targetDataType = query.FirstOrDefault();
            if (targetDataType == null)
                throw new ApplicationException(string.Format("{0} isimli enum bulunamadı", enumName));
            var enumType = targetDataType.PrimitiveType as EnumType;
            var result = enumType.ValueDefs.Values.Select(e => new EnumLookupItem{Name = e.DisplayText, Key = e.EnumValue.ToString(), Value = e.Value}).OrderBy(x => x.Value).ToList();
            return result;
        }

        public IList<LookupItem> ListDefList(string listDefName, string listFilterExpression, string linkFilterExpression)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[listDefName];
                TTList ttList = TTList.NewList(objectContext, listDef, listFilterExpression);
                ttList.LinkFilterExpression = linkFilterExpression;
                var lookupList = new List<LookupItem>();
                IList list = ttList.GetObjectListByExpression(null);
                if (listDef.IsValueList)
                {
                    string propName = listDef.ValueProperty.Name;
                    for (int i = 0; i < list.Count; i++)
                    {
                        TTObject obj = ttList.GetTTObjectFromList(list, i);
                        var itemKey = obj[GetIdentifierName(propName)];
                        var description = ttList.GetDisplayText(obj);
                        lookupList.Add(new LookupItem{ItemKey = itemKey.ToString(), Name = description});
                    }
                }
                else
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        TTObject obj = ttList.GetTTObjectFromList(list, i);
                        var itemKey = obj.ObjectID;
                        var description = ttList.GetDisplayText(obj);
                        lookupList.Add(new LookupItem{ItemKey = itemKey.ToString(), Name = description});
                    }
                }

                var orderedList = lookupList.OrderBy(e => e.Name).ToList();
                return orderedList;
            }
        }
    }
}