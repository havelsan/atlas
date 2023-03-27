
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FollowUpExamination")] 

    /// <summary>
    /// Hasta Kontrol Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class FollowUpExamination : PhysicianApplication, IReasonOfReject, IAppointmentDef, IAllocateSpeciality, ICheckTreatmentMaterialIsEmpty, IOAExamination, ITreatmentMaterialCollection
    {
        public class FollowUpExaminationList : TTObjectCollection<FollowUpExamination> { }
                    
        public class ChildFollowUpExaminationCollection : TTObject.TTChildObjectCollection<FollowUpExamination>
        {
            public ChildFollowUpExaminationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFollowUpExaminationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetFollowUpExamination_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FOLLOWUPEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Doctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTOR"]);
                }
            }

            public Guid? Resource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCE"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public Object Paid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAID"]);
                }
            }

            public Object Reasonforadmission
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADMISSION"]);
                }
            }

            public Object Procedurename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                }
            }

            public Object Subspeciality
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SUBSPECIALITY"]);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public bool? Foreign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Homecountry
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMECOUNTRY"]);
                }
            }

            public Object Countryofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNTRYOFBIRTH"]);
                }
            }

            public Object Returndescription
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RETURNDESCRIPTION"]);
                }
            }

            public OLAP_GetFollowUpExamination_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetFollowUpExamination_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetFollowUpExamination_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFollowUpExaminationNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Cityname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYNAME"]);
                }
            }

            public string Townname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOWNNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Reasonforadm
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADM"]);
                }
            }

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
                }
            }

            public string Fromres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FOLLOWUPEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FOLLOWUPEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FOLLOWUPEXAMINATION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FOLLOWUPEXAMINATION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docdiplomano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCDIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docemploymentrecordid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCEMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Doctitle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Dokrank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKRANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docmilitaryclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCMILITARYCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docwork
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCWORK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docspeciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCSPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFollowUpExaminationNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFollowUpExaminationNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFollowUpExaminationNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledFollowUpExamination_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetCancelledFollowUpExamination_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledFollowUpExamination_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledFollowUpExamination_Class() : base() { }
        }

        public static class States
        {
            public static Guid PatientNoShown { get { return new Guid("154388a2-b98a-433c-a864-19256bdd462b"); } }
    /// <summary>
    /// Muayene
    /// </summary>
            public static Guid Examination { get { return new Guid("39d4c957-b200-400b-afc3-066fc926ac1f"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("b1eec2a1-b2ef-4d1d-9b03-37cf04a9b4fe"); } }
    /// <summary>
    /// Doktor Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("d8ec9e40-9691-49d0-b679-712059dafe11"); } }
            public static Guid NursingorderDetails { get { return new Guid("4bb3badb-6b4e-4d92-9381-892ad2eda5cf"); } }
            public static Guid Cancelled { get { return new Guid("42f83b3b-5595-4b0c-9183-506cd967496b"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("352afee9-70ff-46c0-91ce-a880ef6e89e5"); } }
            public static Guid Appointment { get { return new Guid("8e4a09d1-f943-4de4-b1f5-f6a22ca93374"); } }
        }

        public static BindingList<FollowUpExamination> GetFollowUpExaminationByEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLLOWUPEXAMINATION"].QueryDefs["GetFollowUpExaminationByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<FollowUpExamination>(queryDef, paramList);
        }

        public static BindingList<FollowUpExamination.OLAP_GetFollowUpExamination_Class> OLAP_GetFollowUpExamination(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLLOWUPEXAMINATION"].QueryDefs["OLAP_GetFollowUpExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<FollowUpExamination.OLAP_GetFollowUpExamination_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FollowUpExamination.OLAP_GetFollowUpExamination_Class> OLAP_GetFollowUpExamination(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLLOWUPEXAMINATION"].QueryDefs["OLAP_GetFollowUpExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<FollowUpExamination.OLAP_GetFollowUpExamination_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FollowUpExamination.GetFollowUpExaminationNQL_Class> GetFollowUpExaminationNQL(string FOLLOWUPEXAMINATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLLOWUPEXAMINATION"].QueryDefs["GetFollowUpExaminationNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FOLLOWUPEXAMINATION", FOLLOWUPEXAMINATION);

            return TTReportNqlObject.QueryObjects<FollowUpExamination.GetFollowUpExaminationNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FollowUpExamination.GetFollowUpExaminationNQL_Class> GetFollowUpExaminationNQL(TTObjectContext objectContext, string FOLLOWUPEXAMINATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLLOWUPEXAMINATION"].QueryDefs["GetFollowUpExaminationNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FOLLOWUPEXAMINATION", FOLLOWUPEXAMINATION);

            return TTReportNqlObject.QueryObjects<FollowUpExamination.GetFollowUpExaminationNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FollowUpExamination.OLAP_GetCancelledFollowUpExamination_Class> OLAP_GetCancelledFollowUpExamination(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLLOWUPEXAMINATION"].QueryDefs["OLAP_GetCancelledFollowUpExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<FollowUpExamination.OLAP_GetCancelledFollowUpExamination_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FollowUpExamination.OLAP_GetCancelledFollowUpExamination_Class> OLAP_GetCancelledFollowUpExamination(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLLOWUPEXAMINATION"].QueryDefs["OLAP_GetCancelledFollowUpExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<FollowUpExamination.OLAP_GetCancelledFollowUpExamination_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Taburcu Tipi
    /// </summary>
        public DischargeTypeEnum? MTSDischargeType
        {
            get { return (DischargeTypeEnum?)(int?)this["MTSDISCHARGETYPE"]; }
            set { this["MTSDISCHARGETYPE"] = value; }
        }

    /// <summary>
    /// Tanının ICD10 kodu
    /// </summary>
        public string taniKodu
        {
            get { return (string)this["TANIKODU"]; }
            set { this["TANIKODU"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityDefinition DispatchedSpeciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("DISPATCHEDSPECIALITY"); }
            set { this["DISPATCHEDSPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Gönderilen XXXXXX
    /// </summary>
        public ResSection MTSHospitalSendingTo
        {
            get { return (ResSection)((ITTObject)this).GetParent("MTSHOSPITALSENDINGTO"); }
            set { this["MTSHOSPITALSENDINGTO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProcedureOrdersCollection()
        {
            _ProcedureOrders = new ProcedureOrder.ChildProcedureOrderCollection(this, new Guid("a03d89c5-baad-4dad-9b41-1736b227a62a"));
            ((ITTChildObjectCollection)_ProcedureOrders).GetChildren();
        }

        protected ProcedureOrder.ChildProcedureOrderCollection _ProcedureOrders = null;
        public ProcedureOrder.ChildProcedureOrderCollection ProcedureOrders
        {
            get
            {
                if (_ProcedureOrders == null)
                    CreateProcedureOrdersCollection();
                return _ProcedureOrders;
            }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("8684a31d-e5b1-4e69-9d48-8a3ce621a374"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
    /// <summary>
    /// Child collection for FollowUpExamination Çoklu Özel Durum
    /// </summary>
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _FollowUpExaminationAdditionalApplications = new FollowUpExaminationAdditionalApplication.ChildFollowUpExaminationAdditionalApplicationCollection(_SubactionProcedures, "FollowUpExaminationAdditionalApplications");
            _FollowUpExaminationProcedures = new FollowUpExaminationProcedure.ChildFollowUpExaminationProcedureCollection(_SubactionProcedures, "FollowUpExaminationProcedures");
        }

        private FollowUpExaminationAdditionalApplication.ChildFollowUpExaminationAdditionalApplicationCollection _FollowUpExaminationAdditionalApplications = null;
        public FollowUpExaminationAdditionalApplication.ChildFollowUpExaminationAdditionalApplicationCollection FollowUpExaminationAdditionalApplications
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _FollowUpExaminationAdditionalApplications;
            }            
        }

        private FollowUpExaminationProcedure.ChildFollowUpExaminationProcedureCollection _FollowUpExaminationProcedures = null;
        public FollowUpExaminationProcedure.ChildFollowUpExaminationProcedureCollection FollowUpExaminationProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _FollowUpExaminationProcedures;
            }            
        }

        protected FollowUpExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FollowUpExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FollowUpExamination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FollowUpExamination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FollowUpExamination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FOLLOWUPEXAMINATION", dataRow) { }
        protected FollowUpExamination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FOLLOWUPEXAMINATION", dataRow, isImported) { }
        public FollowUpExamination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FollowUpExamination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FollowUpExamination() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}