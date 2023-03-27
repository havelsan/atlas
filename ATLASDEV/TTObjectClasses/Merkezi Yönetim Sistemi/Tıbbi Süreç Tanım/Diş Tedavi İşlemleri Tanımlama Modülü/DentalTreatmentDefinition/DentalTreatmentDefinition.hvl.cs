
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalTreatmentDefinition")] 

    /// <summary>
    /// Diş Tedavi Tanımları
    /// </summary>
    public  partial class DentalTreatmentDefinition : ProcedureDefinition
    {
        public class DentalTreatmentDefinitionList : TTObjectCollection<DentalTreatmentDefinition> { }
                    
        public class ChildDentalTreatmentDefinitionCollection : TTObject.TTChildObjectCollection<DentalTreatmentDefinition>
        {
            public ChildDentalTreatmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalTreatmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDentalTreatmentDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EnglishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGLISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public GetDentalTreatmentDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDentalTreatmentDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDentalTreatmentDefinition_Class() : base() { }
        }

        public static BindingList<DentalTreatmentDefinition.GetDentalTreatmentDefinition_Class> GetDentalTreatmentDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTDEFINITION"].QueryDefs["GetDentalTreatmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalTreatmentDefinition.GetDentalTreatmentDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DentalTreatmentDefinition.GetDentalTreatmentDefinition_Class> GetDentalTreatmentDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTDEFINITION"].QueryDefs["GetDentalTreatmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalTreatmentDefinition.GetDentalTreatmentDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DentalTreatmentDefinition> GetDentalTreatmentDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTDEFINITION"].QueryDefs["GetDentalTreatmentDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DentalTreatmentDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kategori
    /// </summary>
        public DentalRequestTypeEnum? Category
        {
            get { return (DentalRequestTypeEnum?)(int?)this["CATEGORY"]; }
            set { this["CATEGORY"] = value; }
        }

    /// <summary>
    /// Diş No
    /// </summary>
        public ToothNumberEnum? ToothNumber
        {
            get { return (ToothNumberEnum?)(int?)this["TOOTHNUMBER"]; }
            set { this["TOOTHNUMBER"] = value; }
        }

    /// <summary>
    /// Tedavi İstek Türü
    /// </summary>
        public DentalRequestTypeDefinition DentalRequestType
        {
            get { return (DentalRequestTypeDefinition)((ITTObject)this).GetParent("DENTALREQUESTTYPE"); }
            set { this["DENTALREQUESTTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDepartmentsCollection()
        {
            _Departments = new DentalTreatmentDepartmentGrid.ChildDentalTreatmentDepartmentGridCollection(this, new Guid("eef2d87b-b900-4c90-b0eb-eccc271ba8e2"));
            ((ITTChildObjectCollection)_Departments).GetChildren();
        }

        protected DentalTreatmentDepartmentGrid.ChildDentalTreatmentDepartmentGridCollection _Departments = null;
    /// <summary>
    /// Child collection for Diş Tedavi Yapılacak Birimler
    /// </summary>
        public DentalTreatmentDepartmentGrid.ChildDentalTreatmentDepartmentGridCollection Departments
        {
            get
            {
                if (_Departments == null)
                    CreateDepartmentsCollection();
                return _Departments;
            }
        }

        protected DentalTreatmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalTreatmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalTreatmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalTreatmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalTreatmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALTREATMENTDEFINITION", dataRow) { }
        protected DentalTreatmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALTREATMENTDEFINITION", dataRow, isImported) { }
        public DentalTreatmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalTreatmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalTreatmentDefinition() : base() { }

    }
}