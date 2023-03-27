
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VaccineDefinition")] 

    /// <summary>
    /// Aşı Tanımlama Modülü
    /// </summary>
    public  partial class VaccineDefinition : TerminologyManagerDef
    {
        public class VaccineDefinitionList : TTObjectCollection<VaccineDefinition> { }
                    
        public class ChildVaccineDefinitionCollection : TTObject.TTChildObjectCollection<VaccineDefinition>
        {
            public ChildVaccineDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVaccineDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetVaccineDefinitionReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public PeriodCriterionEnum? PeriodCriterion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIODCRITERION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VACCINEDEFINITION"].AllPropertyDefs["PERIODCRITERION"].DataType;
                    return (PeriodCriterionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VACCINEDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VACCINEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? AutoAdd
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUTOADD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VACCINEDEFINITION"].AllPropertyDefs["AUTOADD"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public VaccinationAgeTypeEnum? AutoAddAgeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUTOADDAGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VACCINEDEFINITION"].AllPropertyDefs["AUTOADDAGETYPE"].DataType;
                    return (VaccinationAgeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? MaxPeriodRange
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXPERIODRANGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VACCINEDEFINITION"].AllPropertyDefs["MAXPERIODRANGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public PeriodUnitTypeEnum? MaxPeriodRangeUnit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXPERIODRANGEUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VACCINEDEFINITION"].AllPropertyDefs["MAXPERIODRANGEUNIT"].DataType;
                    return (PeriodUnitTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetVaccineDefinitionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVaccineDefinitionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVaccineDefinitionReportQuery_Class() : base() { }
        }

        public static BindingList<VaccineDefinition> GetVaccineDefinitionNQL(TTObjectContext objectContext, int AUTOADDAGETYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VACCINEDEFINITION"].QueryDefs["GetVaccineDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("AUTOADDAGETYPE", AUTOADDAGETYPE);

            return ((ITTQuery)objectContext).QueryObjects<VaccineDefinition>(queryDef, paramList);
        }

        public static BindingList<VaccineDefinition> GetAllVaccinesNQL(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VACCINEDEFINITION"].QueryDefs["GetAllVaccinesNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<VaccineDefinition>(queryDef, paramList);
        }

        public static BindingList<VaccineDefinition.GetVaccineDefinitionReportQuery_Class> GetVaccineDefinitionReportQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VACCINEDEFINITION"].QueryDefs["GetVaccineDefinitionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<VaccineDefinition.GetVaccineDefinitionReportQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<VaccineDefinition.GetVaccineDefinitionReportQuery_Class> GetVaccineDefinitionReportQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VACCINEDEFINITION"].QueryDefs["GetVaccineDefinitionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<VaccineDefinition.GetVaccineDefinitionReportQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<VaccineDefinition> GetVaccineDefinitionByObjectIDNQL(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VACCINEDEFINITION"].QueryDefs["GetVaccineDefinitionByObjectIDNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<VaccineDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Periyod Kriteri
    /// </summary>
        public PeriodCriterionEnum? PeriodCriterion
        {
            get { return (PeriodCriterionEnum?)(int?)this["PERIODCRITERION"]; }
            set { this["PERIODCRITERION"] = value; }
        }

    /// <summary>
    /// Aşı Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Aşı Tanımı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Aşı kartı oluşturulduğunda  aşıyı otomatik olarak ekle.
    /// </summary>
        public bool? AutoAdd
        {
            get { return (bool?)this["AUTOADD"]; }
            set { this["AUTOADD"] = value; }
        }

    /// <summary>
    /// Aşı Kartına Otomatik Eklenecek Yaş Grubu Aralığı
    /// </summary>
        public VaccinationAgeTypeEnum? AutoAddAgeType
        {
            get { return (VaccinationAgeTypeEnum?)(int?)this["AUTOADDAGETYPE"]; }
            set { this["AUTOADDAGETYPE"] = value; }
        }

    /// <summary>
    /// Maksimum Periyod Aralığı
    /// </summary>
        public int? MaxPeriodRange
        {
            get { return (int?)this["MAXPERIODRANGE"]; }
            set { this["MAXPERIODRANGE"] = value; }
        }

    /// <summary>
    /// Maksiumum Periyod Aralığı Birimi
    /// </summary>
        public PeriodUnitTypeEnum? MaxPeriodRangeUnit
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["MAXPERIODRANGEUNIT"]; }
            set { this["MAXPERIODRANGEUNIT"] = value; }
        }

        public SKRSAsiKodu SKRSAsiKodu
        {
            get { return (SKRSAsiKodu)((ITTObject)this).GetParent("SKRSASIKODU"); }
            set { this["SKRSASIKODU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateVaccinePeriodGridCollection()
        {
            _VaccinePeriodGrid = new VaccinePeriodGrid.ChildVaccinePeriodGridCollection(this, new Guid("85b3f9e1-9bcd-4899-acd9-8fffd82865a4"));
            ((ITTChildObjectCollection)_VaccinePeriodGrid).GetChildren();
        }

        protected VaccinePeriodGrid.ChildVaccinePeriodGridCollection _VaccinePeriodGrid = null;
        public VaccinePeriodGrid.ChildVaccinePeriodGridCollection VaccinePeriodGrid
        {
            get
            {
                if (_VaccinePeriodGrid == null)
                    CreateVaccinePeriodGridCollection();
                return _VaccinePeriodGrid;
            }
        }

        protected VaccineDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VaccineDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VaccineDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VaccineDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VaccineDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VACCINEDEFINITION", dataRow) { }
        protected VaccineDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VACCINEDEFINITION", dataRow, isImported) { }
        public VaccineDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VaccineDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VaccineDefinition() : base() { }

    }
}