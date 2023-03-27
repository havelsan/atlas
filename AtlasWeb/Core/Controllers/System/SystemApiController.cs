using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTUtils;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class SystemApiController : Controller
    {
        public class DynamicComponentInfoDVO
        {
            public string ComponentName { get; set; }
            public string ModuleName { get; set; }
            public string ModulePath { get; set; }
            public string objectID { get; set; }
        }

        [HttpGet]
        public DynamicComponentInfoDVO GetNewObjectDynamicComponentInfo([FromQuery] string ObjectDefName, [FromQuery] string formDefId = null)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            var objectDefList = TTObjectDefManager.Instance.ObjectDefs;
            var objectDef = objectDefList.Values.Where(d => d.Name.ToUpperInvariant() == ObjectDefName.ToUpperInvariant()).FirstOrDefault();
            if (objectDef == null)
                return dynamicComponentInfo;
            var subFolders = objectDef.ModuleDef.GetParentFolders();
            var folderPath = string.Join("/", subFolders.Reverse());
            var moduleName = objectDef.ModuleDef.Name.GetTsModuleName();
            var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
            string componentName = string.Empty;
            Guid? targetFormDefID = null;
            if (!string.IsNullOrEmpty(formDefId))
            {
                Guid tempFormDefID;
                if (Guid.TryParse(formDefId, out tempFormDefID))
                {
                    targetFormDefID = tempFormDefID;
                }
            }

            if (targetFormDefID.HasValue)
            {
                var formDef = objectDef.FormDefs.Values.FirstOrDefault(f => f.FormDefID == targetFormDefID.Value);
                if ( formDef == null)
                {
                    formDef = objectDef.DefinitionFormDefs.Values.FirstOrDefault(f => f.FormDefID == targetFormDefID.Value);
                }
                componentName = formDef.CodeName;
            }
            else
            {
                foreach (TTObjectStateDef state in objectDef.StateDefs)
                {
                    if (state.IsEntry)
                    {
                        componentName = state.FormDef.CodeName;
                        break;
                    }
                }
            }

            dynamicComponentInfo.ComponentName = componentName;
            dynamicComponentInfo.ModuleName = moduleName;
            dynamicComponentInfo.ModulePath = modulePath;
            dynamicComponentInfo.objectID = string.Empty;
            return dynamicComponentInfo;
        }

        [HttpGet]
        public DynamicComponentInfoDVO GetDynamicComponentInfo([FromQuery] string ObjectId, [FromQuery] string ObjectDefName, [FromQuery] string formDefId = null)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                Guid objectDefID = new Guid();
                bool objectDefIsGuid = Guid.TryParse(ObjectDefName, out objectDefID);
                TTObject obj = null;
                if (objectDefIsGuid)
                    obj = objectContext.GetObject(new Guid(ObjectId), new Guid(ObjectDefName));
                else
                    obj = objectContext.GetObject(new Guid(ObjectId), ObjectDefName);

                var subFolders = GetParentFolders(obj.ObjectDef.ModuleDef);
                var folderPath = string.Join("/", subFolders.Reverse());
                var moduleName = obj.ObjectDef.ModuleDef.Name.GetTsModuleName();
                var modulePath = TTUtils.Globals.GetTsModulePath(moduleName, subFolders);
                string componentName = string.Empty;
                Guid? targetFormDefID = null;
                if (!string.IsNullOrEmpty(formDefId))
                {
                    Guid tempFormDefID;
                    if (Guid.TryParse(formDefId, out tempFormDefID))
                    {
                        targetFormDefID = tempFormDefID;
                    }
                }

                if (targetFormDefID.HasValue)
                {
                    var FormDef = obj.ObjectDef.FormDefs.Values.FirstOrDefault(f => f.FormDefID == targetFormDefID);
                    if (FormDef == null)
                    {
                        FormDef = obj.ObjectDef.DefinitionFormDefs.Values.FirstOrDefault(f => f.FormDefID == targetFormDefID.Value);
                    }
                    componentName = FormDef.CodeName;
                }
                else if (obj.CurrentStateDef != null)
                    componentName = obj.CurrentStateDef.FormDef.CodeName;
                dynamicComponentInfo.ComponentName = componentName;
                dynamicComponentInfo.ModuleName = moduleName;
                dynamicComponentInfo.ModulePath = modulePath;
                dynamicComponentInfo.objectID = ObjectId;
                objectContext.FullPartialllyLoadedObjects();
                return dynamicComponentInfo;
            }
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
    }
}