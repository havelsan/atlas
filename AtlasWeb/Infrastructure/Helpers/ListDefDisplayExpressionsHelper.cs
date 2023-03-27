using System.Linq;
using Infrastructure.Helpers;
using System.Collections.Generic;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTUtils;

namespace Infrastructure.Helpers
{
    public class ListDefDisplayExpressionsHelper
    {
        public static void AddToListDefDisplayExpression(TTObjectContext objectContext, IDictionary<string, object> listDisplayExpressions, string listDefName, TTObject ttObject)
        {
            var currentCulture = ActiveUserService.Instance.CurrentCulture;
            var listDef = TTObjectDefManager.Instance.ListDefs[listDefName];
            TTList ttList = TTList.NewList(objectContext, listDef, string.Empty);
            AddToListDefDisplayExpression(currentCulture, objectContext, listDisplayExpressions, ttList, ttObject);
        }

        public static void AddToListDefDisplayExpression(string currentCulture, TTObjectContext objectContext, IDictionary<string, object> listDisplayExpressions, TTList ttList, TTObject ttObject)
        {
            string itemKey = $"{ttObject.ObjectID}~{ttList.ListDef.Name}";
            if (listDisplayExpressions.ContainsKey(itemKey) == false)
            {
                dynamic expando = ttObject.CreateExpandoFromObject();
                expando.GeneratedDisplayExpression = ttList.GetDisplayText(ttObject);
                if (string.IsNullOrWhiteSpace(currentCulture) == false && currentCulture != TTUtils.Globals.NativeLanguageIdentifier)
                {
                    var lazyDictionary = ActiveUserService.LanguageServiceInstance.GetLiteralSet(currentCulture);
                    CultureService.TranslateExpandoObject(expando, lazyDictionary.Value);
                }
                listDisplayExpressions.Add(itemKey, expando);
            }
        }

        public static void AddToListDefDisplayExpressions(TTObjectContext objectContext, IDictionary<string, object> listDisplayExpressions, string listDefName, TTObject[] objList)
        {
            var languageService = ActiveUserService.LanguageServiceInstance;
            var currentCulture = ActiveUserService.Instance.CurrentCulture;
            if (objList == null && objList.Length == 0)
                return;
            TTListDef listDef = TTObjectDefManager.Instance.ListDefs[listDefName];
            if (listDef.ObjectDef == null)
                return;
            TTList ttList = TTList.NewList(objectContext, listDef, string.Empty);
            foreach (var ttObject in objList)
            {
                if (ttObject.ObjectDef.IsOfType(listDef.ObjectDef))
                    AddToListDefDisplayExpression(currentCulture, objectContext, listDisplayExpressions, ttList, ttObject);
            }
        }
    }
}
