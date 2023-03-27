
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseInpatientAdmission")] 

    public  partial class BaseInpatientAdmission : EpisodeActionWithDiagnosis
    {
        public class BaseInpatientAdmissionList : TTObjectCollection<BaseInpatientAdmission> { }
                    
        public class ChildBaseInpatientAdmissionCollection : TTObject.TTChildObjectCollection<BaseInpatientAdmission>
        {
            public ChildBaseInpatientAdmissionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseInpatientAdmissionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetDailyInpatientTreatmentClinic_Class : TTReportNqlObject 
        {
            public Guid? Clinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLINIC"]);
                }
            }

            public Guid? Responsibledoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESPONSIBLEDOCTOR"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
                }
            }

            public OLAP_GetDailyInpatientTreatmentClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetDailyInpatientTreatmentClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetDailyInpatientTreatmentClinic_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetTreatmentClinicProcedure_Class : TTReportNqlObject 
        {
            public Guid? Clinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLINIC"]);
                }
            }

            public Guid? Responsibledoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESPONSIBLEDOCTOR"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
                }
            }

            public Guid? Room
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROOM"]);
                }
            }

            public Guid? RoomGroup
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROOMGROUP"]);
                }
            }

            public OLAP_GetTreatmentClinicProcedure_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetTreatmentClinicProcedure_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetTreatmentClinicProcedure_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetTreatmentClinicForHistory_Class : TTReportNqlObject 
        {
            public Guid? Clinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLINIC"]);
                }
            }

            public Guid? Responsibledoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESPONSIBLEDOCTOR"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
                }
            }

            public OLAP_GetTreatmentClinicForHistory_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetTreatmentClinicForHistory_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetTreatmentClinicForHistory_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysicalStateClinic_Class : TTReportNqlObject 
        {
            public Guid? PhysicalStateClinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PHYSICALSTATECLINIC"]);
                }
            }

            public GetPhysicalStateClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysicalStateClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysicalStateClinic_Class() : base() { }
        }

        public static BindingList<BaseInpatientAdmission.OLAP_GetDailyInpatientTreatmentClinic_Class> OLAP_GetDailyInpatientTreatmentClinic(string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].QueryDefs["OLAP_GetDailyInpatientTreatmentClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<BaseInpatientAdmission.OLAP_GetDailyInpatientTreatmentClinic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseInpatientAdmission.OLAP_GetDailyInpatientTreatmentClinic_Class> OLAP_GetDailyInpatientTreatmentClinic(TTObjectContext objectContext, string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].QueryDefs["OLAP_GetDailyInpatientTreatmentClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<BaseInpatientAdmission.OLAP_GetDailyInpatientTreatmentClinic_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseInpatientAdmission.OLAP_GetTreatmentClinicProcedure_Class> OLAP_GetTreatmentClinicProcedure(string BASEINPATIENTADMISSIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].QueryDefs["OLAP_GetTreatmentClinicProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BASEINPATIENTADMISSIONID", BASEINPATIENTADMISSIONID);

            return TTReportNqlObject.QueryObjects<BaseInpatientAdmission.OLAP_GetTreatmentClinicProcedure_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseInpatientAdmission.OLAP_GetTreatmentClinicProcedure_Class> OLAP_GetTreatmentClinicProcedure(TTObjectContext objectContext, string BASEINPATIENTADMISSIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].QueryDefs["OLAP_GetTreatmentClinicProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BASEINPATIENTADMISSIONID", BASEINPATIENTADMISSIONID);

            return TTReportNqlObject.QueryObjects<BaseInpatientAdmission.OLAP_GetTreatmentClinicProcedure_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseInpatientAdmission.OLAP_GetTreatmentClinicForHistory_Class> OLAP_GetTreatmentClinicForHistory(string BASEINPATIENTADMISSIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].QueryDefs["OLAP_GetTreatmentClinicForHistory"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BASEINPATIENTADMISSIONID", BASEINPATIENTADMISSIONID);

            return TTReportNqlObject.QueryObjects<BaseInpatientAdmission.OLAP_GetTreatmentClinicForHistory_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseInpatientAdmission.OLAP_GetTreatmentClinicForHistory_Class> OLAP_GetTreatmentClinicForHistory(TTObjectContext objectContext, string BASEINPATIENTADMISSIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].QueryDefs["OLAP_GetTreatmentClinicForHistory"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BASEINPATIENTADMISSIONID", BASEINPATIENTADMISSIONID);

            return TTReportNqlObject.QueryObjects<BaseInpatientAdmission.OLAP_GetTreatmentClinicForHistory_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseInpatientAdmission.GetPhysicalStateClinic_Class> GetPhysicalStateClinic(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].QueryDefs["GetPhysicalStateClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<BaseInpatientAdmission.GetPhysicalStateClinic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseInpatientAdmission.GetPhysicalStateClinic_Class> GetPhysicalStateClinic(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].QueryDefs["GetPhysicalStateClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<BaseInpatientAdmission.GetPhysicalStateClinic_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Yatış Sebebi
    /// </summary>
        public string ReasonForInpatientAdmission
        {
            get { return (string)this["REASONFORINPATIENTADMISSION"]; }
            set { this["REASONFORINPATIENTADMISSION"] = value; }
        }

    /// <summary>
    /// Dolap Verilmedi
    /// </summary>
        public bool? NoCupboard
        {
            get { return (bool?)this["NOCUPBOARD"]; }
            set { this["NOCUPBOARD"] = value; }
        }

    /// <summary>
    /// Emanette Kalanlar
    /// </summary>
        public string GivenAndTakenStatus
        {
            get { return (string)this["GIVENANDTAKENSTATUS"]; }
            set { this["GIVENANDTAKENSTATUS"] = value; }
        }

    /// <summary>
    /// Hemşirelik ekranında düşme mesajının son gösterilme tarihi
    /// </summary>
        public DateTime? RiskWarningLastSeenDate
        {
            get { return (DateTime?)this["RISKWARNINGLASTSEENDATE"]; }
            set { this["RISKWARNINGLASTSEENDATE"] = value; }
        }

        public bool? NeedCompanion
        {
            get { return (bool?)this["NEEDCOMPANION"]; }
            set { this["NEEDCOMPANION"] = value; }
        }

    /// <summary>
    /// Sıkı Temas İzolasyonu  
    /// </summary>
        public bool? HasTightContactIsolation
        {
            get { return (bool?)this["HASTIGHTCONTACTISOLATION"]; }
            set { this["HASTIGHTCONTACTISOLATION"] = value; }
        }

        public int? EstimatedInpatientDateCount
        {
            get { return (int?)this["ESTIMATEDINPATIENTDATECOUNT"]; }
            set { this["ESTIMATEDINPATIENTDATECOUNT"] = value; }
        }

    /// <summary>
    /// Tahmini Çıkış Tarihi
    /// </summary>
        public DateTime? EstimatedDischargeDate
        {
            get { return (DateTime?)this["ESTIMATEDDISCHARGEDATE"]; }
            set { this["ESTIMATEDDISCHARGEDATE"] = value; }
        }

    /// <summary>
    /// Tahmini Yatış Tarihi
    /// </summary>
        public DateTime? EstimatedInpatientDate
        {
            get { return (DateTime?)this["ESTIMATEDINPATIENTDATE"]; }
            set { this["ESTIMATEDINPATIENTDATE"] = value; }
        }

    /// <summary>
    /// Düşme Riskli Hasta
    /// </summary>
        public bool? HasFallingRisk
        {
            get { return (bool?)this["HASFALLINGRISK"]; }
            set { this["HASFALLINGRISK"] = value; }
        }

    /// <summary>
    /// Damlacık İzolasyonu  
    /// </summary>
        public bool? HasDropletIsolation
        {
            get { return (bool?)this["HASDROPLETISOLATION"]; }
            set { this["HASDROPLETISOLATION"] = value; }
        }

    /// <summary>
    /// Temas İzolasyonu  
    /// </summary>
        public bool? HasContactIsolation
        {
            get { return (bool?)this["HASCONTACTISOLATION"]; }
            set { this["HASCONTACTISOLATION"] = value; }
        }

    /// <summary>
    /// Solunum İzolasyonu 
    /// </summary>
        public bool? HasAirborneContactIsolation
        {
            get { return (bool?)this["HASAIRBORNECONTACTISOLATION"]; }
            set { this["HASAIRBORNECONTACTISOLATION"] = value; }
        }

    /// <summary>
    /// Yatan Hatanın XXXXXXden Çıkış Tarihi
    /// </summary>
        public DateTime? HospitalDischargeDate
        {
            get { return (DateTime?)this["HOSPITALDISCHARGEDATE"]; }
            set { this["HOSPITALDISCHARGEDATE"] = value; }
        }

    /// <summary>
    /// Vakada Hastanın Yattığı Tarih
    /// </summary>
        public DateTime? HospitalInPatientDate
        {
            get { return (DateTime?)this["HOSPITALINPATIENTDATE"]; }
            set { this["HOSPITALINPATIENTDATE"] = value; }
        }

    /// <summary>
    /// Oda
    /// </summary>
        public ResRoom Room
        {
            get { return (ResRoom)((ITTObject)this).GetParent("ROOM"); }
            set { this["ROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yattığı Klinik / Servis
    /// </summary>
        public ResWard PhysicalStateClinic
        {
            get { return (ResWard)((ITTObject)this).GetParent("PHYSICALSTATECLINIC"); }
            set { this["PHYSICALSTATECLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yatak
    /// </summary>
        public ResBed Bed
        {
            get { return (ResBed)((ITTObject)this).GetParent("BED"); }
            set { this["BED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// OdaGrup
    /// </summary>
        public ResRoomGroup RoomGroup
        {
            get { return (ResRoomGroup)((ITTObject)this).GetParent("ROOMGROUP"); }
            set { this["ROOMGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tedavi Göreceği Klinik / Servis
    /// </summary>
        public ResClinic TreatmentClinic
        {
            get { return (ResClinic)((ITTObject)this).GetParent("TREATMENTCLINIC"); }
            set { this["TREATMENTCLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yatış Sebebi
    /// </summary>
        public InpatientReasonDefinition InpatientReason
        {
            get { return (InpatientReasonDefinition)((ITTObject)this).GetParent("INPATIENTREASON"); }
            set { this["INPATIENTREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CupboardDefinition Cupboard
        {
            get { return (CupboardDefinition)((ITTObject)this).GetParent("CUPBOARD"); }
            set { this["CUPBOARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Episode Dosyası (Cilt)
    /// </summary>
        public EpisodeFolder EpisodeFolder
        {
            get { return (EpisodeFolder)((ITTObject)this).GetParent("EPISODEFOLDER"); }
            set { this["EPISODEFOLDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateInPatientTreatmentClinicApplicationsCollection()
        {
            _InPatientTreatmentClinicApplications = new InPatientTreatmentClinicApplication.ChildInPatientTreatmentClinicApplicationCollection(this, new Guid("ed54ab3c-6712-4b20-a31d-d351da01b8df"));
            ((ITTChildObjectCollection)_InPatientTreatmentClinicApplications).GetChildren();
        }

        protected InPatientTreatmentClinicApplication.ChildInPatientTreatmentClinicApplicationCollection _InPatientTreatmentClinicApplications = null;
        public InPatientTreatmentClinicApplication.ChildInPatientTreatmentClinicApplicationCollection InPatientTreatmentClinicApplications
        {
            get
            {
                if (_InPatientTreatmentClinicApplications == null)
                    CreateInPatientTreatmentClinicApplicationsCollection();
                return _InPatientTreatmentClinicApplications;
            }
        }

        virtual protected void CreateBedProceduresCollection()
        {
            _BedProcedures = new BaseBedProcedure.ChildBaseBedProcedureCollection(this, new Guid("3a78dfdc-3450-4908-b8a2-4f736ff75584"));
            ((ITTChildObjectCollection)_BedProcedures).GetChildren();
        }

        protected BaseBedProcedure.ChildBaseBedProcedureCollection _BedProcedures = null;
    /// <summary>
    /// Child collection for Yatak Hizmetinin Hangi Klinik İşleminden Girildiğini Belirler
    /// </summary>
        public BaseBedProcedure.ChildBaseBedProcedureCollection BedProcedures
        {
            get
            {
                if (_BedProcedures == null)
                    CreateBedProceduresCollection();
                return _BedProcedures;
            }
        }

        virtual protected void CreateRiskWarningLastSeenInfoCollection()
        {
            _RiskWarningLastSeenInfo = new RiskWarningLastSeenInfo.ChildRiskWarningLastSeenInfoCollection(this, new Guid("ce5ed5c3-e77b-4680-9fab-c7e07bf00491"));
            ((ITTChildObjectCollection)_RiskWarningLastSeenInfo).GetChildren();
        }

        protected RiskWarningLastSeenInfo.ChildRiskWarningLastSeenInfoCollection _RiskWarningLastSeenInfo = null;
        public RiskWarningLastSeenInfo.ChildRiskWarningLastSeenInfoCollection RiskWarningLastSeenInfo
        {
            get
            {
                if (_RiskWarningLastSeenInfo == null)
                    CreateRiskWarningLastSeenInfoCollection();
                return _RiskWarningLastSeenInfo;
            }
        }

        protected BaseInpatientAdmission(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseInpatientAdmission(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseInpatientAdmission(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseInpatientAdmission(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseInpatientAdmission(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEINPATIENTADMISSION", dataRow) { }
        protected BaseInpatientAdmission(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEINPATIENTADMISSION", dataRow, isImported) { }
        public BaseInpatientAdmission(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseInpatientAdmission(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseInpatientAdmission() : base() { }

    }
}