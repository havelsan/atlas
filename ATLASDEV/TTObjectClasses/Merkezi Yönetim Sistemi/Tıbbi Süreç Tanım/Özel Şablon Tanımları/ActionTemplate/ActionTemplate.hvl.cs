
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ActionTemplate")] 

    public  partial class ActionTemplate : TTObject
    {
        public class ActionTemplateList : TTObjectCollection<ActionTemplate> { }
                    
        public class ChildActionTemplateCollection : TTObject.TTChildObjectCollection<ActionTemplate>
        {
            public ChildActionTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildActionTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetActionTemplate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIONTEMPLATE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIONTEMPLATE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetActionTemplate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActionTemplate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActionTemplate_Class() : base() { }
        }

        public static BindingList<ActionTemplate.GetActionTemplate_Class> GetActionTemplate(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIONTEMPLATE"].QueryDefs["GetActionTemplate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ActionTemplate.GetActionTemplate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ActionTemplate.GetActionTemplate_Class> GetActionTemplate(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIONTEMPLATE"].QueryDefs["GetActionTemplate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ActionTemplate.GetActionTemplate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Şablon Açıklaması
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Şablon No
    /// </summary>
        public TTSequence ID
        {
            get { return GetSequence("ID"); }
        }

        public BaseAction Action
        {
            get { return (BaseAction)((ITTObject)this).GetParent("ACTION"); }
            set { this["ACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ActionTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ActionTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ActionTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ActionTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ActionTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACTIONTEMPLATE", dataRow) { }
        protected ActionTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACTIONTEMPLATE", dataRow, isImported) { }
        public ActionTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ActionTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ActionTemplate() : base() { }

    }
}