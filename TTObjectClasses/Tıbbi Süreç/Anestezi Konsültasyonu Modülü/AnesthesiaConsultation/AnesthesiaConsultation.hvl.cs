
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesthesiaConsultation")] 

    /// <summary>
    /// Anestezi Konsültasyonu  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class AnesthesiaConsultation : EpisodeActionWithDiagnosis, IAllocateSpeciality
    {
        public class AnesthesiaConsultationList : TTObjectCollection<AnesthesiaConsultation> { }
                    
        public class ChildAnesthesiaConsultationCollection : TTObject.TTChildObjectCollection<AnesthesiaConsultation>
        {
            public ChildAnesthesiaConsultationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesthesiaConsultationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class AnesthesiaConsultationReportNQL_Class : TTReportNqlObject 
        {
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

            public DateTime? Consultationdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSULTATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIACONSULTATION"].AllPropertyDefs["PROCESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Protno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIACONSULTATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object ConsultationResult
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSULTATIONRESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIACONSULTATION"].AllPropertyDefs["CONSULTATIONRESULT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string DiplomaNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EmploymentRecordID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Rank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Work
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORK"]);
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

            public string Speciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public AnesthesiaConsultationReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public AnesthesiaConsultationReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected AnesthesiaConsultationReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetAnesthesiaConsultation_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIACONSULTATION"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcessDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIACONSULTATION"].AllPropertyDefs["PROCESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Masres
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASRES"]);
                }
            }

            public Guid? Reqmasres
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQMASRES"]);
                }
            }

            public Guid? Prodoc
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PRODOC"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
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

            public Object Konsultasyon_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KONSULTASYON_TURU"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
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

            public OLAP_GetAnesthesiaConsultation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetAnesthesiaConsultation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetAnesthesiaConsultation_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İşlem İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f6b0d3d6-f922-4ef8-a89d-49a37cf37065"); } }
            public static Guid AnesthesiaConsultation { get { return new Guid("24d08082-7f8f-45b8-9902-74422036037d"); } }
            public static Guid Request { get { return new Guid("82dd3a18-b12b-4c01-a187-b3414b5cbcf3"); } }
            public static Guid Completed { get { return new Guid("3b2ae285-947d-4867-b773-d008c7946d18"); } }
            public static Guid Approval { get { return new Guid("4b47c6d0-1261-4b6a-b2d9-fe243ad671c0"); } }
            public static Guid RequestAcception { get { return new Guid("d73873af-ebdd-4593-8328-df55d9d7d740"); } }
        }

        public static BindingList<AnesthesiaConsultation> GetByDateLimitAndPatient(TTObjectContext objectContext, DateTime DATELIMIT, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIACONSULTATION"].QueryDefs["GetByDateLimitAndPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATELIMIT", DATELIMIT);
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<AnesthesiaConsultation>(queryDef, paramList);
        }

        public static BindingList<AnesthesiaConsultation> GetByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIACONSULTATION"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<AnesthesiaConsultation>(queryDef, paramList);
        }

        public static BindingList<AnesthesiaConsultation.AnesthesiaConsultationReportNQL_Class> AnesthesiaConsultationReportNQL(string ANESTHESIACONSULTATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIACONSULTATION"].QueryDefs["AnesthesiaConsultationReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ANESTHESIACONSULTATION", ANESTHESIACONSULTATION);

            return TTReportNqlObject.QueryObjects<AnesthesiaConsultation.AnesthesiaConsultationReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AnesthesiaConsultation.AnesthesiaConsultationReportNQL_Class> AnesthesiaConsultationReportNQL(TTObjectContext objectContext, string ANESTHESIACONSULTATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIACONSULTATION"].QueryDefs["AnesthesiaConsultationReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ANESTHESIACONSULTATION", ANESTHESIACONSULTATION);

            return TTReportNqlObject.QueryObjects<AnesthesiaConsultation.AnesthesiaConsultationReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AnesthesiaConsultation.OLAP_GetAnesthesiaConsultation_Class> OLAP_GetAnesthesiaConsultation(DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIACONSULTATION"].QueryDefs["OLAP_GetAnesthesiaConsultation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<AnesthesiaConsultation.OLAP_GetAnesthesiaConsultation_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AnesthesiaConsultation.OLAP_GetAnesthesiaConsultation_Class> OLAP_GetAnesthesiaConsultation(TTObjectContext objectContext, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIACONSULTATION"].QueryDefs["OLAP_GetAnesthesiaConsultation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<AnesthesiaConsultation.OLAP_GetAnesthesiaConsultation_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Konsültasyon Tarihi
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

    /// <summary>
    /// Karar ve İşlem
    /// </summary>
        public object DecisionAndAction
        {
            get { return (object)this["DECISIONANDACTION"]; }
            set { this["DECISIONANDACTION"] = value; }
        }

    /// <summary>
    /// Anestezi Konsültasyon Bulguları
    /// </summary>
        public object ConsultationResult
        {
            get { return (object)this["CONSULTATIONRESULT"]; }
            set { this["CONSULTATIONRESULT"] = value; }
        }

    /// <summary>
    /// Şikayet
    /// </summary>
        public object Complaint
        {
            get { return (object)this["COMPLAINT"]; }
            set { this["COMPLAINT"] = value; }
        }

    /// <summary>
    /// Sistem Sorgulaması
    /// </summary>
        public object SystemQuery
        {
            get { return (object)this["SYSTEMQUERY"]; }
            set { this["SYSTEMQUERY"] = value; }
        }

    /// <summary>
    /// Muayene Özeti
    /// </summary>
        public object ExaminationSummary
        {
            get { return (object)this["EXAMINATIONSUMMARY"]; }
            set { this["EXAMINATIONSUMMARY"] = value; }
        }

    /// <summary>
    /// Konsültasyon İstek Açıklaması
    /// </summary>
        public object ConsultationRequestNote
        {
            get { return (object)this["CONSULTATIONREQUESTNOTE"]; }
            set { this["CONSULTATIONREQUESTNOTE"] = value; }
        }

    /// <summary>
    /// ASA
    /// </summary>
        public AnesthesiaASATypeEnum? ASAType
        {
            get { return (AnesthesiaASATypeEnum?)(int?)this["ASATYPE"]; }
            set { this["ASATYPE"] = value; }
        }

    /// <summary>
    /// Aydınlatılmış Onam Formu Verildi
    /// </summary>
        public bool? IsPatientApprovalFormGiven
        {
            get { return (bool?)this["ISPATIENTAPPROVALFORMGIVEN"]; }
            set { this["ISPATIENTAPPROVALFORMGIVEN"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

        virtual protected void CreateAnesthesiaTechniquesCollection()
        {
            _AnesthesiaTechniques = new AnesthesiaConsultationAnesthesiaTechniqueGrid.ChildAnesthesiaConsultationAnesthesiaTechniqueGridCollection(this, new Guid("716330b6-fe19-41c5-a858-823a64bfcbe9"));
            ((ITTChildObjectCollection)_AnesthesiaTechniques).GetChildren();
        }

        protected AnesthesiaConsultationAnesthesiaTechniqueGrid.ChildAnesthesiaConsultationAnesthesiaTechniqueGridCollection _AnesthesiaTechniques = null;
        public AnesthesiaConsultationAnesthesiaTechniqueGrid.ChildAnesthesiaConsultationAnesthesiaTechniqueGridCollection AnesthesiaTechniques
        {
            get
            {
                if (_AnesthesiaTechniques == null)
                    CreateAnesthesiaTechniquesCollection();
                return _AnesthesiaTechniques;
            }
        }

        virtual protected void CreateProcedureOrdersCollection()
        {
            _ProcedureOrders = new ProcedureOrder.ChildProcedureOrderCollection(this, new Guid("7ed5327c-4d3d-4dab-a60f-ad4e92d0dcc3"));
            ((ITTChildObjectCollection)_ProcedureOrders).GetChildren();
        }

        protected ProcedureOrder.ChildProcedureOrderCollection _ProcedureOrders = null;
    /// <summary>
    /// Child collection for Anestezi Konsültasyonu
    /// </summary>
        public ProcedureOrder.ChildProcedureOrderCollection ProcedureOrders
        {
            get
            {
                if (_ProcedureOrders == null)
                    CreateProcedureOrdersCollection();
                return _ProcedureOrders;
            }
        }

        protected AnesthesiaConsultation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesthesiaConsultation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesthesiaConsultation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesthesiaConsultation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesthesiaConsultation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTHESIACONSULTATION", dataRow) { }
        protected AnesthesiaConsultation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTHESIACONSULTATION", dataRow, isImported) { }
        public AnesthesiaConsultation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesthesiaConsultation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesthesiaConsultation() : base() { }

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