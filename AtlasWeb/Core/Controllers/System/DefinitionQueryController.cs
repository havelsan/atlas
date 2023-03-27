using Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.Collections;
using TTDefinitionManagement;
using TTInstanceManagement;
using Infrastructure.Filters;
using Infrastructure.Models;
using Core.Services;

using System;
using System.Dynamic;
using System.Text;
using System.Xml.Linq;
using TTVisual;
using Microsoft.AspNetCore.Mvc;
using TTUtils;

namespace Core.Controllers
{
    public class PagedResult
    {
        public IList<object> Data { get; set; }
        public int RecordCount { get; set; }

        public PagedResult()
        {
            Data = new List<object>();
        }
    }

    public class ListBoxSearchCriteria
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public string Column { get; set; }
        public string Width { get; set; }
    }

    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class DefinitionQueryController : Controller
    {
        private readonly ILanguageService _languageService;
        static int _PageSizeTreshold = 30;
        static int _MaxCriteriaSizeTreshold = 10;

        public DefinitionQueryController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public PagedResult Query([FromQuery] string definitionName, [FromQuery] int take = 0, [FromQuery] int skip = 0, [FromQuery] bool enablePaging = false, [FromQuery] bool requireTotalCount = false, [FromQuery] string filter = "", [FromQuery] string listFilterExpression = "")
        {
            string listDefName = definitionName;
            string linkFilterExpression = "";
            if (take > _PageSizeTreshold)
            {
                take = _PageSizeTreshold;
            }

            PagedResult result = new PagedResult();
            if (take == 0)
            {
                return result;
            }

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                List<object> list = null;
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[listDefName.Trim()];
                TTList ttList = TTList.NewList(objectContext, listDef, listFilterExpression);
                ttList.LinkFilterExpression = linkFilterExpression;
                var lookupList = new List<LookupItem>();
                if (!String.IsNullOrWhiteSpace(filter))
                {
                    filter = filter.ToUpper().Trim();
                }

                PaginationInfo pi = new PaginationInfo();
                //pi.MaxRows = skip + take;
                pi.Skip = skip;
                pi.PageSize = take;

                try
                {
                    ttList.GetObjectListByData(filter, pi);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error on listdef " + ttList.ListDef.Name + " filter : " + filter, ex);
                }

                if (ttList.FoundList != null)
                {
                    if (enablePaging)
                    {
                        if (requireTotalCount)
                        {
                            result.RecordCount = ttList.FoundList.Count + take;
                        }

                        list = new List<object>(ttList.FoundList.Count);
                        dynamic expObj = null;
                        for (int i = 0; i < ttList.FoundList.Count; i++)
                        {
                            if (i >= skip && i < skip + take)
                            {
                                try
                                {
                                    var obj = ttList.GetTTObjectFromList(ttList.FoundList, i);
                                    expObj = new ExpandoObject();
                                    expObj = obj.CreateExpandoFromObject();
                                    if (String.IsNullOrWhiteSpace(listDef.DisplayExpression))
                                        expObj.GeneratedDisplayExpression = obj.ToString();
                                    else
                                        expObj.GeneratedDisplayExpression = ttList.GetDisplayText(obj);
                                    list.Add(expObj);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                    else
                    {
                        list = new List<object>(ttList.FoundList.Count);
                        dynamic expObj = null;
                        for (int i = 0; i < ttList.FoundList.Count; i++)
                        {
                            try
                            {
                                var obj = ttList.GetTTObjectFromList(ttList.FoundList, i);
                                expObj = new ExpandoObject();
                                expObj = obj.CreateExpandoFromObject();
                                if (String.IsNullOrWhiteSpace(listDef.DisplayExpression))
                                    expObj.GeneratedDisplayExpression = obj.ToString();
                                else
                                    expObj.GeneratedDisplayExpression = ttList.GetDisplayText(obj);
                                list.Add(expObj);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }

                    objectContext.FullPartialllyLoadedObjects();
                }

                result.Data = list;

                var currentCulture = this.ControllerContext?.HttpContext?.Request?.Headers?.GetCurrentCulture();
                if (string.IsNullOrWhiteSpace(currentCulture) == false && currentCulture != TTUtils.Globals.NativeLanguageIdentifier)
                {
                    var i18nResult = TranslateResults(list);
                    result.Data = i18nResult as IList<object>;
                }

                return result;
            }
        }

        [HttpPost]
        public PagedResult DetailedQuery(IList<ListBoxSearchCriteria> criteriaList, int take = 0, int skip = 0, bool requireTotalCount = false, [FromQuery] string definitionName = "", [FromQuery] string listFilterExpression = "")
        {
            IList list = null;
            dynamic expObj = null;
            PagedResult result = new PagedResult();
            if (take > _PageSizeTreshold)
            {
                take = _PageSizeTreshold;
            }

            if (take == 0)
            {
                return result;
            }

            if (criteriaList == null)
            {
                return result;
            }

            if (criteriaList.Count > _MaxCriteriaSizeTreshold)
                criteriaList = criteriaList.Take(_MaxCriteriaSizeTreshold).ToList();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName.Trim()];
                TTList ttList = TTList.NewList(objectContext, listDef, listFilterExpression);
                list = ttList.GetObjectListByExpression(GetFilterExpression(criteriaList, ttList));
                if (list != null && list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i >= skip && i < skip + take)
                        {
                            try
                            {
                                var obj = ttList.GetTTObjectFromList(list, i);
                                expObj = new ExpandoObject();
                                expObj = obj.CreateExpandoFromObject();
                                if (String.IsNullOrWhiteSpace(listDef.DisplayExpression))
                                    expObj.GeneratedDisplayExpression = obj.ToString();
                                else
                                    expObj.GeneratedDisplayExpression = ttList.GetDisplayText(obj);
                                result.Data.Add(expObj);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }

                    if (requireTotalCount)
                    {
                        result.RecordCount = list.Count;
                    }
                }
            }

            return result;
        }

        [HttpGet]
        public IList<ListBoxSearchCriteria> GetListDefProperties([FromQuery] string definitionName)
        {
            IList<ListBoxSearchCriteria> result = new List<ListBoxSearchCriteria>();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName];
                int totalWidth = listDef.ListColumnDefsSorted.Sum(t => t.ColumnWidth);
                string width = null;
                TTListColumnDef listColumnDef = null;
                int total = 0;
                for (int i = 0; i < listDef.ListColumnDefsSorted.Count; i++)
                {
                    listColumnDef = listDef.ListColumnDefsSorted[i];
                    width = null;
                    if (totalWidth != 0)
                    {
                        var actualWidth = Convert.ToInt32(Math.Floor(((double)listColumnDef.ColumnWidth / (double)totalWidth) * 100d));
                        total += actualWidth;
                        if (i == listDef.ListColumnDefsSorted.Count - 1 && total != 100)
                        {
                            actualWidth += 100 - total;
                        }

                        width = actualWidth.ToString() + "%";
                    }

                    result.Add(new ListBoxSearchCriteria()
                    { Column = listColumnDef.MemberName, Label = listColumnDef.Caption, Width = width });
                }

                return result;
            }
        }

        private string GetFilterExpression(IList<ListBoxSearchCriteria> criteriaList, TTList _ttList)
        {
            TTListDef listDef = _ttList.ListDef;
            string filterExpression = null;
            foreach (ListBoxSearchCriteria ctl in criteriaList)
            {
                if (ctl.Column != null && listDef.ListPropertyDefs.ContainsKey(ctl.Column))
                {
                    TTListPropertyDef listPropertyDef = listDef.ListPropertyDefs[ctl.Column];
                    string searchValue = ctl.Value;
                    if (listPropertyDef.DataType.IsText == false)
                        searchValue = searchValue.Trim();
                    string filter = listPropertyDef.GetFilterExpression(searchValue);
                    if (filterExpression == null)
                        filterExpression = "(" + filter + ")";
                    else
                        filterExpression += " AND (" + filter + ")";
                }
            }

            return filterExpression;
        }

        [HttpGet]
        public IList<EnumLookupItem> GetEnum([FromQuery]string enumName)
        {
            LookupService service = new LookupService();
            return service.EnumList(enumName);
        }

        [HttpGet]
        public IList GetDefinitionsAll([FromQuery]string listDefName, [FromQuery]string listFilterExpression = "")
        {
            IList result = new List<object>();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[listDefName];
                TTList ttList = TTList.NewList(objectContext, listDef, listFilterExpression);
                ttList.LinkFilterExpression = "";
                var lookupList = new List<LookupItem>();
                ttList.GetObjectListByData("");
                var list = ttList.FoundList;
                dynamic expObj = null;
                try
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var obj = ttList.GetTTObjectFromList(list, i);
                        expObj = obj.CreateExpandoFromObject();
                        expObj.GeneratedDisplayExpression = ttList.GetDisplayText(obj);
                        result.Add(expObj);
                    }
                }
                catch
                {
                }

                var currentCulture = this.ControllerContext?.HttpContext?.Request?.Headers?.GetCurrentCulture();
                if (string.IsNullOrWhiteSpace(currentCulture) == false && currentCulture != TTUtils.Globals.NativeLanguageIdentifier)
                {
                    var i18nResult = TranslateResults(result);
                    return i18nResult;
                }

                return result;
            }
        }

        private IList TranslateResults(IList result)
        {
            var culture = this.ControllerContext?.HttpContext?.Request?.Headers?.GetCurrentCulture();

            var targetLiteralSet = _languageService.GetLiteralSet(culture);
            if (targetLiteralSet.Value.Count == 0)
            {
                return result;
            }

            foreach (ExpandoObject expandoObject in result)
            {
                CultureService.TranslateExpandoObject(expandoObject, targetLiteralSet.Value);
            }

            return result;
        }
      

        [HttpGet]
        public object GetDefinitionById([FromQuery]Guid definitionId, [FromQuery]string listDefName)
        {
            string listFilterExpression = "";
            string linkFilterExpression = "";
            TTObject obj = null;
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[listDefName];
                //result.DisplayExp = listDef.DisplayExpression ?? "o.GeneratedDisplayExpression";
                TTList ttList = TTList.NewList(objectContext, listDef, listFilterExpression);
                ttList.LinkFilterExpression = linkFilterExpression;
                var lookupList = new List<LookupItem>();
                obj = ttList.GetObject(definitionId);
                dynamic expendo = obj.CreateExpandoFromObject();
                expendo.GeneratedDisplayExpression = ttList.GetDisplayText(obj);
                var currentCulture = this.ControllerContext?.HttpContext?.Request?.Headers?.GetCurrentCulture();
                if (string.IsNullOrWhiteSpace(currentCulture) == false && currentCulture != TTUtils.Globals.NativeLanguageIdentifier)
                {
                    var targetLiteralSet = _languageService.GetLiteralSet(currentCulture);
                    CultureService.TranslateExpandoObject(expendo, targetLiteralSet.Value);
                }
                return expendo;
            }
        }


        [HttpPost]
        public LoadResult DevExtremePagingQueryForDefList(DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;
            string injectionFilter = loadOptions.Params.injectionFilter;
            using (var objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName.Trim()];
                TTList resultList = TTList.NewList(objectContext, listDef, string.Empty);
                
               
                result = DevexpressLoader.Load(objectContext, resultList, loadOptions, new Dictionary<string, object>(), searchText,injectionFilter,String.Empty);
            }
            return result;
        }

         [HttpPost]
        public object GetDiagnosisForTagBox(DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;

            using (var objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName.Trim()];
                TTList ttList = TTList.NewList(objectContext, listDef, string.Empty);

                result = DevexpressLoader.Load(objectContext, ttList, loadOptions, new Dictionary<string, object>(), searchText);
            }
            return result.data;
        }
    }
}