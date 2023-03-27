
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SectionDefinition")] 

    public  partial class SectionDefinition : TerminologyManagerDef, ITMK
    {
        public class SectionDefinitionList : TTObjectCollection<SectionDefinition> { }
                    
        public class ChildSectionDefinitionCollection : TTObject.TTChildObjectCollection<SectionDefinition>
        {
            public ChildSectionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSectionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSectionDefinitionList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string Officename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetSectionDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSectionDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSectionDefinitionList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSectionDefinitionListDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string Officename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetSectionDefinitionListDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSectionDefinitionListDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSectionDefinitionListDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetSectionDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PARAGRAPHTOECODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARAGRAPHTOECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].AllPropertyDefs["PARAGRAPHTOECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? OfficeId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OFFICEID"]);
                }
            }

            public Guid? UnitId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["UNITID"]);
                }
            }

            public OLAP_GetSectionDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSectionDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSectionDefinition_Class() : base() { }
        }

        public static BindingList<SectionDefinition.GetSectionDefinitionList_Class> GetSectionDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].QueryDefs["GetSectionDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SectionDefinition.GetSectionDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SectionDefinition.GetSectionDefinitionList_Class> GetSectionDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].QueryDefs["GetSectionDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SectionDefinition.GetSectionDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SectionDefinition.GetSectionDefinitionListDefinition_Class> GetSectionDefinitionListDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].QueryDefs["GetSectionDefinitionListDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SectionDefinition.GetSectionDefinitionListDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SectionDefinition.GetSectionDefinitionListDefinition_Class> GetSectionDefinitionListDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].QueryDefs["GetSectionDefinitionListDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SectionDefinition.GetSectionDefinitionListDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SectionDefinition.OLAP_GetSectionDefinition_Class> OLAP_GetSectionDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].QueryDefs["OLAP_GetSectionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SectionDefinition.OLAP_GetSectionDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SectionDefinition.OLAP_GetSectionDefinition_Class> OLAP_GetSectionDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].QueryDefs["OLAP_GetSectionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SectionDefinition.OLAP_GetSectionDefinition_Class>(objectContext, queryDef, paramList, pi);
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

        public string PARAGRAPHTOECODE
        {
            get { return (string)this["PARAGRAPHTOECODE"]; }
            set { this["PARAGRAPHTOECODE"] = value; }
        }

    /// <summary>
    /// OfficeDefinition
    /// </summary>
        public OfficeDefinition OfficeId
        {
            get { return (OfficeDefinition)((ITTObject)this).GetParent("OFFICEID"); }
            set { this["OFFICEID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// DepartmentDefinition
    /// </summary>
        public DepartmentDefinition UnitId
        {
            get { return (DepartmentDefinition)((ITTObject)this).GetParent("UNITID"); }
            set { this["UNITID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SectionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SectionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SectionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SectionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SectionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SECTIONDEFINITION", dataRow) { }
        protected SectionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SECTIONDEFINITION", dataRow, isImported) { }
        public SectionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SectionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SectionDefinition() : base() { }

    }
}