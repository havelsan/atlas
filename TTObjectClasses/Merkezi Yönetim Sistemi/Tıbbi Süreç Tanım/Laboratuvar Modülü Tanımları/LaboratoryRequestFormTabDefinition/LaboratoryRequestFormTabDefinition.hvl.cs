
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryRequestFormTabDefinition")] 

    public  partial class LaboratoryRequestFormTabDefinition : TTDefinitionSet
    {
        public class LaboratoryRequestFormTabDefinitionList : TTObjectCollection<LaboratoryRequestFormTabDefinition> { }
                    
        public class ChildLaboratoryRequestFormTabDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryRequestFormTabDefinition>
        {
            public ChildLaboratoryRequestFormTabDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryRequestFormTabDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLabTabsReportNQL_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUESTFORMTABDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? TabOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUESTFORMTABDEFINITION"].AllPropertyDefs["TABORDER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string TabDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUESTFORMTABDEFINITION"].AllPropertyDefs["TABDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? LaboratoryDepartment
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LABORATORYDEPARTMENT"]);
                }
            }

            public Guid? Environment
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ENVIRONMENT"]);
                }
            }

            public GetLabTabsReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabTabsReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabTabsReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabTabsNQL_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUESTFORMTABDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? TabOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUESTFORMTABDEFINITION"].AllPropertyDefs["TABORDER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string TabDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUESTFORMTABDEFINITION"].AllPropertyDefs["TABDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? LaboratoryDepartment
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LABORATORYDEPARTMENT"]);
                }
            }

            public Guid? Environment
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ENVIRONMENT"]);
                }
            }

            public GetLabTabsNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabTabsNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabTabsNQL_Class() : base() { }
        }

        public static BindingList<LaboratoryRequestFormTabDefinition.GetLabTabsReportNQL_Class> GetLabTabsReportNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUESTFORMTABDEFINITION"].QueryDefs["GetLabTabsReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryRequestFormTabDefinition.GetLabTabsReportNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryRequestFormTabDefinition.GetLabTabsReportNQL_Class> GetLabTabsReportNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUESTFORMTABDEFINITION"].QueryDefs["GetLabTabsReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryRequestFormTabDefinition.GetLabTabsReportNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryRequestFormTabDefinition> GetLabTabs(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUESTFORMTABDEFINITION"].QueryDefs["GetLabTabs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryRequestFormTabDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<LaboratoryRequestFormTabDefinition.GetLabTabsNQL_Class> GetLabTabsNQL(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUESTFORMTABDEFINITION"].QueryDefs["GetLabTabsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryRequestFormTabDefinition.GetLabTabsNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryRequestFormTabDefinition.GetLabTabsNQL_Class> GetLabTabsNQL(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUESTFORMTABDEFINITION"].QueryDefs["GetLabTabsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryRequestFormTabDefinition.GetLabTabsNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string TabDescription
        {
            get { return (string)this["TABDESCRIPTION"]; }
            set { this["TABDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Tab Sırası
    /// </summary>
        public int? TabOrder
        {
            get { return (int?)this["TABORDER"]; }
            set { this["TABORDER"] = value; }
        }

    /// <summary>
    /// Tab Adı
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

    /// <summary>
    /// Acil çalışılır
    /// </summary>
        public bool? UrgentProcess
        {
            get { return (bool?)this["URGENTPROCESS"]; }
            set { this["URGENTPROCESS"] = value; }
        }

        public ResLaboratoryDepartment LaboratoryDepartment
        {
            get { return (ResLaboratoryDepartment)((ITTObject)this).GetParent("LABORATORYDEPARTMENT"); }
            set { this["LABORATORYDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public LaboratoryEnvironmentDefinition Environment
        {
            get { return (LaboratoryEnvironmentDefinition)((ITTObject)this).GetParent("ENVIRONMENT"); }
            set { this["ENVIRONMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryRequestFormTabDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryRequestFormTabDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryRequestFormTabDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryRequestFormTabDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryRequestFormTabDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYREQUESTFORMTABDEFINITION", dataRow) { }
        protected LaboratoryRequestFormTabDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYREQUESTFORMTABDEFINITION", dataRow, isImported) { }
        public LaboratoryRequestFormTabDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryRequestFormTabDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryRequestFormTabDefinition() : base() { }

    }
}