
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WorkStatusDefinition")] 

    /// <summary>
    /// Çalışma Durumu Tanımlama
    /// </summary>
    public  partial class WorkStatusDefinition : TTDefinitionSet
    {
        public class WorkStatusDefinitionList : TTObjectCollection<WorkStatusDefinition> { }
                    
        public class ChildWorkStatusDefinitionCollection : TTObject.TTChildObjectCollection<WorkStatusDefinition>
        {
            public ChildWorkStatusDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWorkStatusDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWorkStatusDefinitionNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKSTATUSDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKSTATUSDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SortName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SORTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKSTATUSDEFINITION"].AllPropertyDefs["SORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetWorkStatusDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkStatusDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkStatusDefinitionNQL_Class() : base() { }
        }

        public static BindingList<WorkStatusDefinition.GetWorkStatusDefinitionNQL_Class> GetWorkStatusDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKSTATUSDEFINITION"].QueryDefs["GetWorkStatusDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkStatusDefinition.GetWorkStatusDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WorkStatusDefinition.GetWorkStatusDefinitionNQL_Class> GetWorkStatusDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKSTATUSDEFINITION"].QueryDefs["GetWorkStatusDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkStatusDefinition.GetWorkStatusDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WorkStatusDefinition> GetWorkStatusByExternalCode(TTObjectContext objectContext, string EXTERNALCODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKSTATUSDEFINITION"].QueryDefs["GetWorkStatusByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<WorkStatusDefinition>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Harici Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public string SortName_Shadow
        {
            get { return (string)this["SORTNAME_SHADOW"]; }
        }

    /// <summary>
    /// Sıralama Kodu
    /// </summary>
        public string SortName
        {
            get { return (string)this["SORTNAME"]; }
            set { this["SORTNAME"] = value; }
        }

        protected WorkStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WorkStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WorkStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WorkStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WorkStatusDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WORKSTATUSDEFINITION", dataRow) { }
        protected WorkStatusDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WORKSTATUSDEFINITION", dataRow, isImported) { }
        public WorkStatusDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WorkStatusDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WorkStatusDefinition() : base() { }

    }
}