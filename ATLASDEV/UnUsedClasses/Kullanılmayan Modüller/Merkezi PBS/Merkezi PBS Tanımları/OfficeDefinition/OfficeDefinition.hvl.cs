
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OfficeDefinition")] 

    public  partial class OfficeDefinition : TerminologyManagerDef, ITMK
    {
        public class OfficeDefinitionList : TTObjectCollection<OfficeDefinition> { }
                    
        public class ChildOfficeDefinitionCollection : TTObject.TTChildObjectCollection<OfficeDefinition>
        {
            public ChildOfficeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOfficeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOfficeDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEPARTMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unitenclosurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITENCLOSURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITENCLOSUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOfficeDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOfficeDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOfficeDefinitionList_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetOfficeDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? UnitId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["UNITID"]);
                }
            }

            public OLAP_GetOfficeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetOfficeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetOfficeDefinition_Class() : base() { }
        }

        public static BindingList<OfficeDefinition.GetOfficeDefinitionList_Class> GetOfficeDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OFFICEDEFINITION"].QueryDefs["GetOfficeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OfficeDefinition.GetOfficeDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OfficeDefinition.GetOfficeDefinitionList_Class> GetOfficeDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OFFICEDEFINITION"].QueryDefs["GetOfficeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OfficeDefinition.GetOfficeDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OfficeDefinition.OLAP_GetOfficeDefinition_Class> OLAP_GetOfficeDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OFFICEDEFINITION"].QueryDefs["OLAP_GetOfficeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OfficeDefinition.OLAP_GetOfficeDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OfficeDefinition.OLAP_GetOfficeDefinition_Class> OLAP_GetOfficeDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OFFICEDEFINITION"].QueryDefs["OLAP_GetOfficeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OfficeDefinition.OLAP_GetOfficeDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sıra Nu
    /// </summary>
        public int? SEQUENCE
        {
            get { return (int?)this["SEQUENCE"]; }
            set { this["SEQUENCE"] = value; }
        }

        public string NAME
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string SHORT_NAME
        {
            get { return (string)this["SHORT_NAME"]; }
            set { this["SHORT_NAME"] = value; }
        }

        public string PCODE
        {
            get { return (string)this["PCODE"]; }
            set { this["PCODE"] = value; }
        }

    /// <summary>
    /// DepartmentDef_Office
    /// </summary>
        public DepartmentDefinition UnitId
        {
            get { return (DepartmentDefinition)((ITTObject)this).GetParent("UNITID"); }
            set { this["UNITID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OfficeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OfficeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OfficeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OfficeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OfficeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OFFICEDEFINITION", dataRow) { }
        protected OfficeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OFFICEDEFINITION", dataRow, isImported) { }
        public OfficeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OfficeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OfficeDefinition() : base() { }

    }
}