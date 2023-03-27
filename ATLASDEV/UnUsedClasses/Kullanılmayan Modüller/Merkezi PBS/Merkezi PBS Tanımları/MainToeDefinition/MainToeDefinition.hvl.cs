
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainToeDefinition")] 

    public  partial class MainToeDefinition : TerminologyManagerDef, ITMK
    {
        public class MainToeDefinitionList : TTObjectCollection<MainToeDefinition> { }
                    
        public class ChildMainToeDefinitionCollection : TTObject.TTChildObjectCollection<MainToeDefinition>
        {
            public ChildMainToeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainToeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMainToeDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string MAINTOECODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTOECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTOEDEFINITION"].AllPropertyDefs["MAINTOECODE"].DataType;
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

            public GetMainToeDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMainToeDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMainToeDefinitionList_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetMainToeDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string MAINTOECODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTOECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTOEDEFINITION"].AllPropertyDefs["MAINTOECODE"].DataType;
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

            public OLAP_GetMainToeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetMainToeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetMainToeDefinition_Class() : base() { }
        }

        public static BindingList<MainToeDefinition.GetMainToeDefinitionList_Class> GetMainToeDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTOEDEFINITION"].QueryDefs["GetMainToeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MainToeDefinition.GetMainToeDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MainToeDefinition.GetMainToeDefinitionList_Class> GetMainToeDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTOEDEFINITION"].QueryDefs["GetMainToeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MainToeDefinition.GetMainToeDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MainToeDefinition.OLAP_GetMainToeDefinition_Class> OLAP_GetMainToeDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTOEDEFINITION"].QueryDefs["OLAP_GetMainToeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MainToeDefinition.OLAP_GetMainToeDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MainToeDefinition.OLAP_GetMainToeDefinition_Class> OLAP_GetMainToeDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTOEDEFINITION"].QueryDefs["OLAP_GetMainToeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MainToeDefinition.OLAP_GetMainToeDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public string MAINTOECODE
        {
            get { return (string)this["MAINTOECODE"]; }
            set { this["MAINTOECODE"] = value; }
        }

    /// <summary>
    /// DepartmentDefinition
    /// </summary>
        public DepartmentDefinition UnitId
        {
            get { return (DepartmentDefinition)((ITTObject)this).GetParent("UNITID"); }
            set { this["UNITID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MainToeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainToeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainToeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainToeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainToeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTOEDEFINITION", dataRow) { }
        protected MainToeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTOEDEFINITION", dataRow, isImported) { }
        public MainToeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainToeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainToeDefinition() : base() { }

    }
}