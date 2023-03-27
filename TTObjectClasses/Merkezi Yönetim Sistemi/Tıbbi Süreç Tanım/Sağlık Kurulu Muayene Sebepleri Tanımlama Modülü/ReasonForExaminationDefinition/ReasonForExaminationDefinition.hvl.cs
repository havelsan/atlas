
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReasonForExaminationDefinition")] 

    /// <summary>
    /// Sağlık Kurulu Muayene Edecek Birim(ler) / XXXXXX(ler) Tanımlama
    /// </summary>
    public  partial class ReasonForExaminationDefinition : TerminologyManagerDef
    {
        public class ReasonForExaminationDefinitionList : TTObjectCollection<ReasonForExaminationDefinition> { }
                    
        public class ChildReasonForExaminationDefinitionCollection : TTObject.TTChildObjectCollection<ReasonForExaminationDefinition>
        {
            public ChildReasonForExaminationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReasonForExaminationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetReasonForExaminationDefinition_Class : TTReportNqlObject 
        {
            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Reason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
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

            public ExaminationTypeEnum? ExaminationType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["EXAMINATIONTYPE"].DataType;
                    return (ExaminationTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public HealthCommitteeTypeEnum? HealthCommitteeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEALTHCOMMITTEETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["HEALTHCOMMITTEETYPE"].DataType;
                    return (HealthCommitteeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetReasonForExaminationDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReasonForExaminationDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReasonForExaminationDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetHealthCommitteeReasons_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Reason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public OLAP_GetHealthCommitteeReasons_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetHealthCommitteeReasons_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetHealthCommitteeReasons_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAutomaticallyCreatables_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Reason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAutomaticallyCreatables_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAutomaticallyCreatables_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAutomaticallyCreatables_Class() : base() { }
        }

    /// <summary>
    /// Get the ReasonForExaminationDefinition by objectID
    /// </summary>
        public static BindingList<ReasonForExaminationDefinition> GetReasonForExaminationDefinitionByID(TTObjectContext objectContext, string OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].QueryDefs["GetReasonForExaminationDefinitionByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ReasonForExaminationDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Gets all instances
    /// </summary>
        public static BindingList<ReasonForExaminationDefinition> GetReasonForExaminationDefinitions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].QueryDefs["GetReasonForExaminationDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ReasonForExaminationDefinition>(queryDef, paramList);
        }

        public static BindingList<ReasonForExaminationDefinition.GetReasonForExaminationDefinition_Class> GetReasonForExaminationDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].QueryDefs["GetReasonForExaminationDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForExaminationDefinition.GetReasonForExaminationDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReasonForExaminationDefinition.GetReasonForExaminationDefinition_Class> GetReasonForExaminationDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].QueryDefs["GetReasonForExaminationDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForExaminationDefinition.GetReasonForExaminationDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReasonForExaminationDefinition.OLAP_GetHealthCommitteeReasons_Class> OLAP_GetHealthCommitteeReasons(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].QueryDefs["OLAP_GetHealthCommitteeReasons"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForExaminationDefinition.OLAP_GetHealthCommitteeReasons_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReasonForExaminationDefinition.OLAP_GetHealthCommitteeReasons_Class> OLAP_GetHealthCommitteeReasons(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].QueryDefs["OLAP_GetHealthCommitteeReasons"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForExaminationDefinition.OLAP_GetHealthCommitteeReasons_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReasonForExaminationDefinition> GetReasonForExaminationDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].QueryDefs["GetReasonForExaminationDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ReasonForExaminationDefinition>(queryDef, paramList);
        }

        public static BindingList<ReasonForExaminationDefinition.GetAutomaticallyCreatables_Class> GetAutomaticallyCreatables(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].QueryDefs["GetAutomaticallyCreatables"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForExaminationDefinition.GetAutomaticallyCreatables_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReasonForExaminationDefinition.GetAutomaticallyCreatables_Class> GetAutomaticallyCreatables(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].QueryDefs["GetAutomaticallyCreatables"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReasonForExaminationDefinition.GetAutomaticallyCreatables_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Muayene Tipi
    /// </summary>
        public string Reason
        {
            get { return (string)this["REASON"]; }
            set { this["REASON"] = value; }
        }

    /// <summary>
    /// Muayene Sebep Tipi
    /// </summary>
        public ReasonForExaminationTypeEnum? ReasonForExaminationType
        {
            get { return (ReasonForExaminationTypeEnum?)(int?)this["REASONFOREXAMINATIONTYPE"]; }
            set { this["REASONFOREXAMINATIONTYPE"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Muayene Türü
    /// </summary>
        public ExaminationTypeEnum? ExaminationType
        {
            get { return (ExaminationTypeEnum?)(int?)this["EXAMINATIONTYPE"]; }
            set { this["EXAMINATIONTYPE"] = value; }
        }

    /// <summary>
    /// Hangi tür kurul tarafından görüleceği. Boş olması durumunda normal sağlık kurulu tarafından görülür.
    /// </summary>
        public HealthCommitteeTypeEnum? HealthCommitteeType
        {
            get { return (HealthCommitteeTypeEnum?)(int?)this["HEALTHCOMMITTEETYPE"]; }
            set { this["HEALTHCOMMITTEETYPE"] = value; }
        }

    /// <summary>
    /// Teşhis Girilmesi Zorunlu
    /// </summary>
        public bool? IsForcedDiagnosis
        {
            get { return (bool?)this["ISFORCEDDIAGNOSIS"]; }
            set { this["ISFORCEDDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Muayene Bitmeden Rapor Çıktısı Alınabilir
    /// </summary>
        public bool? IsPrintReportBeforeExam
        {
            get { return (bool?)this["ISPRINTREPORTBEFOREEXAM"]; }
            set { this["ISPRINTREPORTBEFOREEXAM"] = value; }
        }

    /// <summary>
    /// Poliklinik Ekranından Rapora Ulaşılabilsin
    /// </summary>
        public bool? IsPoliclinicAllowedReport
        {
            get { return (bool?)this["ISPOLICLINICALLOWEDREPORT"]; }
            set { this["ISPOLICLINICALLOWEDREPORT"] = value; }
        }

    /// <summary>
    /// Kontrol Süresi
    /// </summary>
        public int? ControlTime
        {
            get { return (int?)this["CONTROLTIME"]; }
            set { this["CONTROLTIME"] = value; }
        }

    /// <summary>
    /// Kontrol Süresi Birimi
    /// </summary>
        public UnitOfTimeEnum? ControlUnitOfTime
        {
            get { return (UnitOfTimeEnum?)(int?)this["CONTROLUNITOFTIME"]; }
            set { this["CONTROLUNITOFTIME"] = value; }
        }

    /// <summary>
    /// Rapor entegrasyon sürecinde çalıştırılacak mı
    /// </summary>
        public bool? IntegratedReporting
        {
            get { return (bool?)this["INTEGRATEDREPORTING"]; }
            set { this["INTEGRATEDREPORTING"] = value; }
        }

    /// <summary>
    /// Paket Hizmeti
    /// </summary>
        public PackageProcedureDefinition PackageProcedure
        {
            get { return (PackageProcedureDefinition)((ITTObject)this).GetParent("PACKAGEPROCEDURE"); }
            set { this["PACKAGEPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HCReportTypeDefinition HCReportTypeDefinition
        {
            get { return (HCReportTypeDefinition)((ITTObject)this).GetParent("HCREPORTTYPEDEFINITION"); }
            set { this["HCREPORTTYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sağlık Kurulu Heyeti
    /// </summary>
        public MemberOfHealthCommitteeDefinition MemberOfHealthCommittee
        {
            get { return (MemberOfHealthCommitteeDefinition)((ITTObject)this).GetParent("MEMBEROFHEALTHCOMMITTEE"); }
            set { this["MEMBEROFHEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateHospitalsUnitsCollection()
        {
            _HospitalsUnits = new HospitalsUnitsDefinitionGrid.ChildHospitalsUnitsDefinitionGridCollection(this, new Guid("f099bc1f-aeeb-4853-8537-71e638010d5a"));
            ((ITTChildObjectCollection)_HospitalsUnits).GetChildren();
        }

        protected HospitalsUnitsDefinitionGrid.ChildHospitalsUnitsDefinitionGridCollection _HospitalsUnits = null;
        public HospitalsUnitsDefinitionGrid.ChildHospitalsUnitsDefinitionGridCollection HospitalsUnits
        {
            get
            {
                if (_HospitalsUnits == null)
                    CreateHospitalsUnitsCollection();
                return _HospitalsUnits;
            }
        }

        virtual protected void CreateSystemForDisabledReportGridCollection()
        {
            _SystemForDisabledReportGrid = new SystemForDisabledReportGrid.ChildSystemForDisabledReportGridCollection(this, new Guid("b7ce7ca2-1b98-4f1d-a363-651bc1436a6f"));
            ((ITTChildObjectCollection)_SystemForDisabledReportGrid).GetChildren();
        }

        protected SystemForDisabledReportGrid.ChildSystemForDisabledReportGridCollection _SystemForDisabledReportGrid = null;
        public SystemForDisabledReportGrid.ChildSystemForDisabledReportGridCollection SystemForDisabledReportGrid
        {
            get
            {
                if (_SystemForDisabledReportGrid == null)
                    CreateSystemForDisabledReportGridCollection();
                return _SystemForDisabledReportGrid;
            }
        }

        virtual protected void CreateHCRequestReasonCollection()
        {
            _HCRequestReason = new HCRequestReason.ChildHCRequestReasonCollection(this, new Guid("c39f170f-1dfb-4a3e-bde6-a92106ed2127"));
            ((ITTChildObjectCollection)_HCRequestReason).GetChildren();
        }

        protected HCRequestReason.ChildHCRequestReasonCollection _HCRequestReason = null;
        public HCRequestReason.ChildHCRequestReasonCollection HCRequestReason
        {
            get
            {
                if (_HCRequestReason == null)
                    CreateHCRequestReasonCollection();
                return _HCRequestReason;
            }
        }

        protected ReasonForExaminationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReasonForExaminationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReasonForExaminationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReasonForExaminationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReasonForExaminationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REASONFOREXAMINATIONDEFINITION", dataRow) { }
        protected ReasonForExaminationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REASONFOREXAMINATIONDEFINITION", dataRow, isImported) { }
        public ReasonForExaminationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReasonForExaminationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReasonForExaminationDefinition() : base() { }

    }
}