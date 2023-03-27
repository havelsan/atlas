using Core.Models;
using Core.Services;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TTDataDictionary;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTStorageManager.Security;

namespace Core.Controllers
{
    //[Authorize]
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class ObjectDefController : Controller
    {
        private readonly LookupService _lookupService;
        private readonly DefinitionService _definitionService;

        public ObjectDefController(DefinitionService definitionService, LookupService lookupService)
        {
            _definitionService = definitionService;
            _lookupService = lookupService;
        }

        public TTObjectDef GetObjectDefFromID(Guid objectDefId)
        {
            return _definitionService.GetObjectDefFromID(objectDefId);
        }

        public TTObjectDef GetObjectDefFromName(string name)
        {
            return _definitionService.GetObjectDefFromName(name);
        }

        public TTListDef GetListDefFromID(Guid listDefId)
        {
            return _definitionService.GetListDefFromID(listDefId);
        }

        public TTListDef GetListDefFromName(string name)
        {
            return _definitionService.GetListDefFromName(name);
        }

        public TTReportDef GetReportDefFromID(Guid reportDefId)
        {
            return _definitionService.GetReportDefFromID(reportDefId);
        }

        public TTReportDef GetReportDefFromName(string name)
        {
            return _definitionService.GetReportDefFromName(name);
        }

        public TTDataType GetDataTypeFromID(Guid dataTypeId)
        {
            return _definitionService.GetDataTypeFromID(dataTypeId);
        }

        public TTDataType GetDataTypeFromName(string name)
        {
            return _definitionService.GetDataTypeFromName(name);
        }

        public TTRole GetRoleFromID(Guid dataTypeId)
        {
            return _definitionService.GetRoleFromID(dataTypeId);
        }

        public TTRole GetRoleFromName(string name)
        {
            return _definitionService.GetRoleFromName(name);
        }

    
        internal static string GetObjectFolder(string rootPath, TTObjectDef objectDef)
        {
            var parentFolders = GetParentFolders(objectDef.ModuleDef);
            var targetFolder = rootPath;
            foreach (var subFolder in parentFolders.Reverse())
            {
                targetFolder = Path.Combine(targetFolder, subFolder);
            }

            return targetFolder;
        }

        internal static IEnumerable<string> GetParentFolders(TTModuleDef moduleDef)
        {
            yield return TTUtils.Globals.GetModuleName(moduleDef.Name);
            Guid? folderDefId = moduleDef.FolderDefID;
            while (folderDefId != null)
            {
                TTFolderDef folderDef = null;
                if (TTObjectDefManager.Instance.FolderDefs.ContainsKey(folderDefId))
                {
                    folderDef = TTObjectDefManager.Instance.FolderDefs[folderDefId];
                    yield return TTUtils.Globals.GetModuleName(folderDef.CodeName);
                    folderDefId = folderDef.ParentFolderDefID;
                }

                if (!folderDefId.HasValue)
                    yield break;
            }
        }

        private ReportDefinition MapToReportDefinition(TTReportDef reportDef, XmlSerializer serializer)
        {
            var reportDefinition = new ReportDefinition
            {
                ReportDefID = reportDef.ReportDefID,
                ModuleDefID = reportDef.ModuleDefID,
                ReportNO = reportDef.ReportNO,
                CodeName = reportDef.CodeName,
                InterfaceName = reportDef.InterfaceName,
                ModifiedName = reportDef.ModifiedName,
                Name = reportDef.Name,
                Caption = reportDef.Caption,
                Description = reportDef.Description,
                ReportXML = reportDef.ReportXML,
            };

            var rootElement = XElement.Parse(reportDefinition.ReportXML);
            var paramsElement = rootElement.Elements("PARAMS").FirstOrDefault();
            if (paramsElement != null)
            {
                reportDefinition.Parameters = serializer.Deserialize(paramsElement.CreateReader()) as ReportParameters;
                foreach (var reportParam in reportDefinition.Parameters.List)
                {
                    var dataTypeID = Guid.Parse(reportParam.DataTypeID);
                    TTDataType dataType = null;
                    if (TTObjectDefManager.Instance.DataTypes.TryGetValue(dataTypeID, out dataType))
                    {
                        reportParam.DataTypeName = dataType.CodeName;
                        reportParam.IsEnum = dataType.IsEnum;
                        if (dataType.IsEnum)
                        {
                            reportParam.EnumList = _lookupService.EnumList(dataType.CodeName);
                        }
                    }
                }
            }

            reportDefinition.ReportXML = string.Empty;

            return reportDefinition;
        }

        [HttpGet]
        public IEnumerable<ReportDefinition> GetReportDefList()
        {
            var reportDefinitionList = new List<ReportDefinition>();
            var reportDefList = TTObjectDefManager.Instance.ReportDefs.Values;
            var serializer = new XmlSerializer(typeof(ReportParameters));
            foreach (var reportDef in reportDefList)
            {
                var reportDefinition = MapToReportDefinition(reportDef, serializer);
                reportDefinitionList.Add(reportDefinition);
            }

            return reportDefinitionList;
        }

        [HttpGet]
        public ReportDefinition GetReportDefinition([FromQuery]string reportDefName)
        {
            var reportDefinition = new ReportDefinition();
            var serializer = new XmlSerializer(typeof(ReportParameters));
            if (TTObjectDefManager.Instance.ReportDefs.TryGetValue(reportDefName, out TTReportDef reportDef)) {

                return MapToReportDefinition(reportDef, serializer);
            }
            return reportDefinition;
        }

        [HttpGet]
        public IEnumerable<ObjectDefItem> GetObjectDefList()
        {
            var objectDefList = TTObjectDefManager.Instance.ObjectDefs;
            var query =
                from o in objectDefList.Values
                let modulePath = GetObjectFolder(".", o)
                orderby o.Name
                select new ObjectDefItem { ObjectDefID = o.ID, ObjectDefName = o.Name, ModulePath = modulePath, };
            return query.ToList();
        }

        [HttpGet]
        public IEnumerable<TTObjectStateDef> GetObjectStateDefs(string id)
        {
            Guid guidObjectDefID = Guid.Parse(id);
            if (!TTObjectDefManager.Instance.ObjectDefs.ContainsKey(guidObjectDefID))
                throw new ApplicationException($"Object definition with ID '{guidObjectDefID}' not found");
            var objectDef = TTObjectDefManager.Instance.ObjectDefs[guidObjectDefID];
            var stateDefinitions = objectDef.StateDefs.Values.ToList();
            return stateDefinitions;
        }

        public class GetListDefinitionInput
        {
            public Guid? ListDefID { get; set; }
            public string ListDefName { get; set; }
            public string UserFilterExpression { get; set; }
            public string LinkedRelationDefID { get; set; }
            public string ParentObjectID { get; set; }
        }


        [HttpPost]
        public ListDefinition GetListDefinition(GetListDefinitionInput input)
        {
            var listDefinition = new ListDefinition();
            TTListDef listDef = null;
            TTObjectRelationDef linkedRelDef = null;

            if (input.ListDefID.HasValue)
            {
                listDef = TTObjectDefManager.Instance.ListDefs[input.ListDefID];
            }
            else if (!string.IsNullOrWhiteSpace(input.ListDefName))
            {
                listDef = TTObjectDefManager.Instance.ListDefs[input.ListDefName];
            }

            if ( string.IsNullOrWhiteSpace(input.LinkedRelationDefID) == false)
            {
                var linkedRelationDefID = new Guid(input.LinkedRelationDefID);
                var targetObjectDef = listDef.ObjectDef;
                while (targetObjectDef != null)
                {
                    if ( targetObjectDef.ParentRelationDefs.TryGetValue(linkedRelationDefID, out TTObjectRelationDef relDef)  )
                    {
                        linkedRelDef = relDef;
                        break;
                    }
                    targetObjectDef = targetObjectDef.BaseObjectDef as TTObjectDef;
                }
            }
            

            if (listDef != null)
            {
                listDefinition.Name = listDef.Name;
                listDefinition.Caption = listDef.Caption;
                listDefinition.Description = listDef.Description;
                listDefinition.DisplayExpression = listDef.DisplayExpression;
                listDefinition.ValuePropertyName = listDef.ValuePropertyName;
                listDefinition.Columns = new List<ListColumnDefinition>();

                foreach (var columnDef in listDef.ListColumnDefsSorted)
                {
                    var columnDefinition = new ListColumnDefinition();
                    columnDefinition.Name = columnDef.MemberName;
                    columnDefinition.MemberName = columnDef.MemberName;
                    columnDefinition.Caption = columnDef.Caption;
                    columnDefinition.ColumnOrder = columnDef.ColumnOrder;
                    columnDefinition.ColumnWidth = columnDef.ColumnWidth;
                    if ( columnDef.PropertyDef != null)
                    {
                        var propDef = columnDef.PropertyDef;
                        columnDefinition.MemberName = propDef.CodeName;
                        if (propDef.DataType.IsEnum == true )
                        {
                            var columnLookup = new ListColumnLookupDefinition();
                            columnLookup.DataSource = _lookupService.EnumList(propDef.DataType.CodeName);
                            columnLookup.ValueExpression = "Value";
                            columnLookup.DisplayExpression = "Name";
                            columnDefinition.Lookup = columnLookup;
                        }
                    }
                    listDefinition.Columns.Add(columnDefinition);
                }

                using (TTObjectContext objectContext = new TTObjectContext(true))
                {
                    TTList ttList = TTList.NewList(objectContext, listDef, listDef.FilterExpression);
                    if (linkedRelDef != null)
                    {
                        if (Guid.TryParse(input.ParentObjectID, out Guid parentObjectID))
                        {
                            ttList.LinkFilterExpression = $"{linkedRelDef.ParentName} = {TTConnectionManager.ConnectionManager.GuidToString(parentObjectID)}";
                        }
                    }
                    IList list = ttList.GetObjectListByExpression(input.UserFilterExpression);
                    listDefinition.DataSource = list;
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return listDefinition;
        }

        [HttpGet]
        public Guid GetListDefinitionID([FromQuery]Guid listDefName)
        {
            var listDef = TTObjectDefManager.Instance.ListDefs[listDefName];
            if (listDef != null)
                return listDef.ListDefID;
            return Guid.Empty;
        }

        [HttpPost]
        public void DeleteDefinitionObject([FromBody]DefinitionObjectInput input)
        {
            using(var context = new TTObjectContext(false))
            {
                var targetObject = context.GetObject(input.ObjectID, input.ObjectDefName, false);
                var ifTTObject = targetObject as ITTObject;
                if ( ifTTObject != null)
                {
                    ifTTObject.Delete();
                    context.Save();
                }
            }
        }

        [HttpPost]
        public void ExportDefinitionObject([FromBody]DefinitionObjectInput input)
        {
            using (var context = new TTObjectContext(false))
            {
                var targetObject = context.GetObject(input.ObjectID, input.ObjectDefName, false);

                string exportXMLString = TTObjectContext.ExportToXML(new List<TTObject>{ targetObject });
                
                // targetObject.ExportToXML()
            }
        }

    }
}