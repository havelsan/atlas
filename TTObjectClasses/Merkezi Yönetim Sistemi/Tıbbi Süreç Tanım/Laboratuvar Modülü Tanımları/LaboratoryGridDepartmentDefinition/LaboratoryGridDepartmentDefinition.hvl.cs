
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryGridDepartmentDefinition")] 

    public  partial class LaboratoryGridDepartmentDefinition : TTDefinitionSet
    {
        public class LaboratoryGridDepartmentDefinitionList : TTObjectCollection<LaboratoryGridDepartmentDefinition> { }
                    
        public class ChildLaboratoryGridDepartmentDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryGridDepartmentDefinition>
        {
            public ChildLaboratoryGridDepartmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryGridDepartmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLabGridDepartments_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? LaboratoryTest
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LABORATORYTEST"]);
                }
            }

            public GetLabGridDepartments_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabGridDepartments_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabGridDepartments_Class() : base() { }
        }

        public static BindingList<LaboratoryGridDepartmentDefinition.GetLabGridDepartments_Class> GetLabGridDepartments(Guid PARAMDEPARTMENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYGRIDDEPARTMENTDEFINITION"].QueryDefs["GetLabGridDepartments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEPARTMENT", PARAMDEPARTMENT);

            return TTReportNqlObject.QueryObjects<LaboratoryGridDepartmentDefinition.GetLabGridDepartments_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryGridDepartmentDefinition.GetLabGridDepartments_Class> GetLabGridDepartments(TTObjectContext objectContext, Guid PARAMDEPARTMENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYGRIDDEPARTMENTDEFINITION"].QueryDefs["GetLabGridDepartments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEPARTMENT", PARAMDEPARTMENT);

            return TTReportNqlObject.QueryObjects<LaboratoryGridDepartmentDefinition.GetLabGridDepartments_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Laboratuvar Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTest
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTEST"); }
            set { this["LABORATORYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Laboratuvar Bölümü İlişkisi
    /// </summary>
        public ResLaboratoryDepartment Department
        {
            get { return (ResLaboratoryDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryGridDepartmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryGridDepartmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryGridDepartmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryGridDepartmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryGridDepartmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYGRIDDEPARTMENTDEFINITION", dataRow) { }
        protected LaboratoryGridDepartmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYGRIDDEPARTMENTDEFINITION", dataRow, isImported) { }
        public LaboratoryGridDepartmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryGridDepartmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryGridDepartmentDefinition() : base() { }

    }
}