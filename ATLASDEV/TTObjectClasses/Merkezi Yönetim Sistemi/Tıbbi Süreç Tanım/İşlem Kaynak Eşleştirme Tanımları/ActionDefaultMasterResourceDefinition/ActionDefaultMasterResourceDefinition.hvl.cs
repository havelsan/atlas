
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
namespace TTObjectClasses
{
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ActionDefaultMasterResourceDefinition")] 

    /// <summary>
    /// İşlemler Göre Standart Kaynak Tanımları
    /// </summary>
    public  partial class ActionDefaultMasterResourceDefinition : TTDefinitionSet
    {
        public class ActionDefaultMasterResourceDefinitionList : TTObjectCollection<ActionDefaultMasterResourceDefinition> { }
                    
        public class ChildActionDefaultMasterResourceDefinitionCollection : TTObject.TTChildObjectCollection<ActionDefaultMasterResourceDefinition>
        {
            public ChildActionDefaultMasterResourceDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildActionDefaultMasterResourceDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetActionDefaultMasterResourceDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public ActionTypeEnum? ActionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIONDEFAULTMASTERRESOURCEDEFINITION"].AllPropertyDefs["ACTIONTYPE"].DataType;
                    return (ActionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetActionDefaultMasterResourceDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActionDefaultMasterResourceDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActionDefaultMasterResourceDefinition_Class() : base() { }
        }

        public static BindingList<ActionDefaultMasterResourceDefinition.GetActionDefaultMasterResourceDefinition_Class> GetActionDefaultMasterResourceDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIONDEFAULTMASTERRESOURCEDEFINITION"].QueryDefs["GetActionDefaultMasterResourceDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ActionDefaultMasterResourceDefinition.GetActionDefaultMasterResourceDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ActionDefaultMasterResourceDefinition.GetActionDefaultMasterResourceDefinition_Class> GetActionDefaultMasterResourceDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIONDEFAULTMASTERRESOURCEDEFINITION"].QueryDefs["GetActionDefaultMasterResourceDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ActionDefaultMasterResourceDefinition.GetActionDefaultMasterResourceDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ActionDefaultMasterResourceDefinition> GetByActionType(TTObjectContext objectContext, ActionTypeEnum ACTIONTYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIONDEFAULTMASTERRESOURCEDEFINITION"].QueryDefs["GetByActionType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONTYPE", (int)ACTIONTYPE);

            return ((ITTQuery)objectContext).QueryObjects<ActionDefaultMasterResourceDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// İşlem Türü
    /// </summary>
        public ActionTypeEnum? ActionType
        {
            get { return (ActionTypeEnum?)(int?)this["ACTIONTYPE"]; }
            set { this["ACTIONTYPE"] = value; }
        }

        virtual protected void CreateMasterResourcesCollection()
        {
            _MasterResources = new ActionDefaultMasterResourceGrid.ChildActionDefaultMasterResourceGridCollection(this, new Guid("2f1df26f-4906-4bd0-a1d2-f77cd6e1d51e"));
            ((ITTChildObjectCollection)_MasterResources).GetChildren();
        }

        protected ActionDefaultMasterResourceGrid.ChildActionDefaultMasterResourceGridCollection _MasterResources = null;
        public ActionDefaultMasterResourceGrid.ChildActionDefaultMasterResourceGridCollection MasterResources
        {
            get
            {
                if (_MasterResources == null)
                    CreateMasterResourcesCollection();
                return _MasterResources;
            }
        }

        protected ActionDefaultMasterResourceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ActionDefaultMasterResourceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ActionDefaultMasterResourceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ActionDefaultMasterResourceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ActionDefaultMasterResourceDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACTIONDEFAULTMASTERRESOURCEDEFINITION", dataRow) { }
        protected ActionDefaultMasterResourceDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACTIONDEFAULTMASTERRESOURCEDEFINITION", dataRow, isImported) { }
        public ActionDefaultMasterResourceDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ActionDefaultMasterResourceDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ActionDefaultMasterResourceDefinition() : base() { }

    }
}