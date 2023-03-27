
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DepartmentDefinition")] 

    public  partial class DepartmentDefinition : TerminologyManagerDef, ITMK
    {
        public class DepartmentDefinitionList : TTObjectCollection<DepartmentDefinition> { }
                    
        public class ChildDepartmentDefinitionCollection : TTObject.TTChildObjectCollection<DepartmentDefinition>
        {
            public ChildDepartmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDepartmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDepartmentDefinitionList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEPARTMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PCODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEPARTMENTDEFINITION"].AllPropertyDefs["PCODE"].DataType;
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

            public GetDepartmentDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDepartmentDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDepartmentDefinitionList_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetUnitDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEPARTMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MAINTOECODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTOECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEPARTMENTDEFINITION"].AllPropertyDefs["MAINTOECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? UnitEnclosureID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["UNITENCLOSUREID"]);
                }
            }

            public OLAP_GetUnitDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetUnitDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetUnitDefinition_Class() : base() { }
        }

        public static BindingList<DepartmentDefinition.GetDepartmentDefinitionList_Class> GetDepartmentDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEPARTMENTDEFINITION"].QueryDefs["GetDepartmentDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DepartmentDefinition.GetDepartmentDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DepartmentDefinition.GetDepartmentDefinitionList_Class> GetDepartmentDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEPARTMENTDEFINITION"].QueryDefs["GetDepartmentDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DepartmentDefinition.GetDepartmentDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DepartmentDefinition.OLAP_GetUnitDefinition_Class> OLAP_GetUnitDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEPARTMENTDEFINITION"].QueryDefs["OLAP_GetUnitDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DepartmentDefinition.OLAP_GetUnitDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DepartmentDefinition.OLAP_GetUnitDefinition_Class> OLAP_GetUnitDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEPARTMENTDEFINITION"].QueryDefs["OLAP_GetUnitDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DepartmentDefinition.OLAP_GetUnitDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public string NAME
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string PCODE
        {
            get { return (string)this["PCODE"]; }
            set { this["PCODE"] = value; }
        }

        public string SHORT_NAME
        {
            get { return (string)this["SHORT_NAME"]; }
            set { this["SHORT_NAME"] = value; }
        }

        public string MAINTOECODE
        {
            get { return (string)this["MAINTOECODE"]; }
            set { this["MAINTOECODE"] = value; }
        }

    /// <summary>
    /// UnitEnclosure_Department
    /// </summary>
        public UnitEnclosureDefinition UnitEnclosureID
        {
            get { return (UnitEnclosureDefinition)((ITTObject)this).GetParent("UNITENCLOSUREID"); }
            set { this["UNITENCLOSUREID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DepartmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DepartmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DepartmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DepartmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DepartmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEPARTMENTDEFINITION", dataRow) { }
        protected DepartmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEPARTMENTDEFINITION", dataRow, isImported) { }
        public DepartmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DepartmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DepartmentDefinition() : base() { }

    }
}