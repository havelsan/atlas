
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalExamination")] 

    /// <summary>
    /// Oral Diagnoz ve Radyoloji İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
    public  partial class DentalExamination : BaseDentalEpisodeAction, INumaratorAppointment, ICreateSubEpisode, IAppointmentDef, IAllocateSpeciality, IOAExamination, IWorkListEpisodeAction, IDentalExamination
    {
        public class DentalExaminationList : TTObjectCollection<DentalExamination> { }
                    
        public class ChildDentalExaminationCollection : TTObject.TTChildObjectCollection<DentalExamination>
        {
            public ChildDentalExaminationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalExaminationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetDentalExamination_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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

            public OLAP_GetDentalExamination_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetDentalExamination_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetDentalExamination_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledDentalExamination_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? Resource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCE"]);
                }
            }

            public OLAP_GetCancelledDentalExamination_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledDentalExamination_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledDentalExamination_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDentalExaminationForWL_Class : TTReportNqlObject 
        {
            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? Isemergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Prioritystatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITYSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Patientnamesurname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAMESURNAME"]);
                }
            }

            public string Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Episodeactionname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPISODEACTIONNAME"]);
                }
            }

            public String Statename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATENAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Admissiontype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Telno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientClassTypeEnum? Hastaturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTATURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["PATIENTCLASSGROUP"].DataType;
                    return (PatientClassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ApplicationReasonEnum? Basvuruturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASVURUTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["APPLICATIONREASON"].DataType;
                    return (ApplicationReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? Examinationprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetDentalExaminationForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDentalExaminationForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDentalExaminationForWL_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("1625e127-4c89-49df-a2f2-2b45f5811d56"); } }
            public static Guid Examination { get { return new Guid("f16d3763-079c-438b-8abc-2cbabb4b9fed"); } }
            public static Guid Appointment { get { return new Guid("176799b9-b931-4940-9c7a-c17246c8648a"); } }
            public static Guid Cancelled { get { return new Guid("94556edc-97a7-438b-bffb-c1bc2663bc79"); } }
            public static Guid ProcedureRequested { get { return new Guid("840c7a0a-bbe1-4776-b33d-b19eef21c2b7"); } }
            public static Guid Completed { get { return new Guid("1a613989-bef7-4329-a092-cf9d4a705610"); } }
    /// <summary>
    /// Hasta Gelmedi
    /// </summary>
            public static Guid PatientNoShown { get { return new Guid("d1980f04-0366-45ea-986a-deb49423acf4"); } }
            public static Guid OrderedPatient { get { return new Guid("1c681901-e069-4bf8-a0c3-2cfc3b82ed8f"); } }
            public static Guid ExaminationCompleted { get { return new Guid("fc65d269-e859-47ae-8fa2-d8e462930639"); } }
        }

        public static BindingList<DentalExamination> GetUnCompletedDentalExams(TTObjectContext objectContext, string PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].QueryDefs["GetUnCompletedDentalExams"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<DentalExamination>(queryDef, paramList);
        }

        public static BindingList<DentalExamination.OLAP_GetDentalExamination_Class> OLAP_GetDentalExamination(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].QueryDefs["OLAP_GetDentalExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DentalExamination.OLAP_GetDentalExamination_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalExamination.OLAP_GetDentalExamination_Class> OLAP_GetDentalExamination(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].QueryDefs["OLAP_GetDentalExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DentalExamination.OLAP_GetDentalExamination_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DentalExamination.OLAP_GetCancelledDentalExamination_Class> OLAP_GetCancelledDentalExamination(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].QueryDefs["OLAP_GetCancelledDentalExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DentalExamination.OLAP_GetCancelledDentalExamination_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalExamination.OLAP_GetCancelledDentalExamination_Class> OLAP_GetCancelledDentalExamination(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].QueryDefs["OLAP_GetCancelledDentalExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DentalExamination.OLAP_GetCancelledDentalExamination_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DentalExamination> GetExcludesDentalProceduresAreCompleted(TTObjectContext objectContext, IList<Guid> STATE, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].QueryDefs["GetExcludesDentalProceduresAreCompleted"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATE", STATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DentalExamination>(queryDef, paramList);
        }

        public static BindingList<DentalExamination> GetAllDentalExaminationConsultations(TTObjectContext objectContext, string EPISODEOBJECTID, string OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].QueryDefs["GetAllDentalExaminationConsultations"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEOBJECTID", EPISODEOBJECTID);
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<DentalExamination>(queryDef, paramList);
        }

        public static BindingList<DentalExamination> GetDailyOpenDentalExaminations(TTObjectContext objectContext, DateTime DATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].QueryDefs["GetDailyOpenDentalExaminations"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return ((ITTQuery)objectContext).QueryObjects<DentalExamination>(queryDef, paramList);
        }

        public static BindingList<DentalExamination.GetDentalExaminationForWL_Class> GetDentalExaminationForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].QueryDefs["GetDentalExaminationForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalExamination.GetDentalExaminationForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DentalExamination.GetDentalExaminationForWL_Class> GetDentalExaminationForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALEXAMINATION"].QueryDefs["GetDentalExaminationForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalExamination.GetDentalExaminationForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Sol Alt
    /// </summary>
        public string LeftLowerJaw
        {
            get { return (string)this["LEFTLOWERJAW"]; }
            set { this["LEFTLOWERJAW"] = value; }
        }

    /// <summary>
    /// Sağ Üst
    /// </summary>
        public string RightUpperJaw
        {
            get { return (string)this["RIGHTUPPERJAW"]; }
            set { this["RIGHTUPPERJAW"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ProcessTime
        {
            get { return (DateTime?)this["PROCESSTIME"]; }
            set { this["PROCESSTIME"] = value; }
        }

    /// <summary>
    /// Sağ Alt
    /// </summary>
        public string RightLowerJaw
        {
            get { return (string)this["RIGHTLOWERJAW"]; }
            set { this["RIGHTLOWERJAW"] = value; }
        }

    /// <summary>
    /// Sol Üst
    /// </summary>
        public string LeftUpperJaw
        {
            get { return (string)this["LEFTUPPERJAW"]; }
            set { this["LEFTUPPERJAW"] = value; }
        }

    /// <summary>
    /// Diş Tedavi Dosyası
    /// </summary>
        public object DentalExaminationFile
        {
            get { return (object)this["DENTALEXAMINATIONFILE"]; }
            set { this["DENTALEXAMINATIONFILE"] = value; }
        }

    /// <summary>
    /// Genel Anestezi
    /// </summary>
        public bool? GeneralAnesthesia
        {
            get { return (bool?)this["GENERALANESTHESIA"]; }
            set { this["GENERALANESTHESIA"] = value; }
        }

    /// <summary>
    /// Triaj Kodu
    /// </summary>
        public TriajCode? TriajCode
        {
            get { return (TriajCode?)(int?)this["TRIAJCODE"]; }
            set { this["TRIAJCODE"] = value; }
        }

        public bool? IsFollowUpExam
        {
            get { return (bool?)this["ISFOLLOWUPEXAM"]; }
            set { this["ISFOLLOWUPEXAM"] = value; }
        }

    /// <summary>
    /// Anestezi Doktor Tescil No
    /// </summary>
        public string DrAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

    /// <summary>
    /// Kabul Durum
    /// </summary>
        public PatientExaminationEnum? DentalExaminationType
        {
            get { return (PatientExaminationEnum?)(int?)this["DENTALEXAMINATIONTYPE"]; }
            set { this["DENTALEXAMINATIONTYPE"] = value; }
        }

    /// <summary>
    /// IsConsultation
    /// </summary>
        public bool? IsConsultation
        {
            get { return (bool?)this["ISCONSULTATION"]; }
            set { this["ISCONSULTATION"] = value; }
        }

    /// <summary>
    /// Konsültasyon Sonucu Ve Öneriler
    /// </summary>
        public object ConsultationResultAndOffers
        {
            get { return (object)this["CONSULTATIONRESULTANDOFFERS"]; }
            set { this["CONSULTATIONRESULTANDOFFERS"] = value; }
        }

    /// <summary>
    /// İstek Açıklaması
    /// </summary>
        public object RequestDescription
        {
            get { return (object)this["REQUESTDESCRIPTION"]; }
            set { this["REQUESTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Muayene Birimi
    /// </summary>
        public ResSection ProcedureDepartment
        {
            get { return (ResSection)((ITTObject)this).GetParent("PROCEDUREDEPARTMENT"); }
            set { this["PROCEDUREDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser RequesterDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTERDOCTOR"); }
            set { this["REQUESTERDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection ConsultationRequestResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("CONSULTATIONREQUESTRESOURCE"); }
            set { this["CONSULTATIONREQUESTRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DentalCommitment DentalCommitment
        {
            get { return (DentalCommitment)((ITTObject)this).GetParent("DENTALCOMMITMENT"); }
            set { this["DENTALCOMMITMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSuggestedProsthesisCollection()
        {
            _SuggestedProsthesis = new DentalExaminationSuggestedProsthesis.ChildDentalExaminationSuggestedProsthesisCollection(this, new Guid("fb17af16-e1bc-4fb8-8707-214e33af9cfa"));
            ((ITTChildObjectCollection)_SuggestedProsthesis).GetChildren();
        }

        protected DentalExaminationSuggestedProsthesis.ChildDentalExaminationSuggestedProsthesisCollection _SuggestedProsthesis = null;
    /// <summary>
    /// Child collection for Önerilen Diş Protez
    /// </summary>
        public DentalExaminationSuggestedProsthesis.ChildDentalExaminationSuggestedProsthesisCollection SuggestedProsthesis
        {
            get
            {
                if (_SuggestedProsthesis == null)
                    CreateSuggestedProsthesisCollection();
                return _SuggestedProsthesis;
            }
        }

        virtual protected void CreateSuggestedTreatmentsCollection()
        {
            _SuggestedTreatments = new DentalExaminationSuggestedTreatment.ChildDentalExaminationSuggestedTreatmentCollection(this, new Guid("c3235376-c4f3-4119-bbc6-a435aa21a790"));
            ((ITTChildObjectCollection)_SuggestedTreatments).GetChildren();
        }

        protected DentalExaminationSuggestedTreatment.ChildDentalExaminationSuggestedTreatmentCollection _SuggestedTreatments = null;
    /// <summary>
    /// Child collection for Önerilen Diş Tedavi
    /// </summary>
        public DentalExaminationSuggestedTreatment.ChildDentalExaminationSuggestedTreatmentCollection SuggestedTreatments
        {
            get
            {
                if (_SuggestedTreatments == null)
                    CreateSuggestedTreatmentsCollection();
                return _SuggestedTreatments;
            }
        }

        virtual protected void CreateDentalConsultationRequestCollection()
        {
            _DentalConsultationRequest = new DentalConsultationRequest.ChildDentalConsultationRequestCollection(this, new Guid("c226fa4f-32a8-44cf-bc3d-dac2816444f5"));
            ((ITTChildObjectCollection)_DentalConsultationRequest).GetChildren();
        }

        protected DentalConsultationRequest.ChildDentalConsultationRequestCollection _DentalConsultationRequest = null;
        public DentalConsultationRequest.ChildDentalConsultationRequestCollection DentalConsultationRequest
        {
            get
            {
                if (_DentalConsultationRequest == null)
                    CreateDentalConsultationRequestCollection();
                return _DentalConsultationRequest;
            }
        }

        virtual protected void CreatekullanilmiyorDentalConsultationsCollection()
        {
            _kullanilmiyorDentalConsultations = new DentalConsultation.ChildDentalConsultationCollection(this, new Guid("adf219a6-f875-4656-985e-7c45b73c75c5"));
            ((ITTChildObjectCollection)_kullanilmiyorDentalConsultations).GetChildren();
        }

        protected DentalConsultation.ChildDentalConsultationCollection _kullanilmiyorDentalConsultations = null;
        public DentalConsultation.ChildDentalConsultationCollection kullanilmiyorDentalConsultations
        {
            get
            {
                if (_kullanilmiyorDentalConsultations == null)
                    CreatekullanilmiyorDentalConsultationsCollection();
                return _kullanilmiyorDentalConsultations;
            }
        }

        virtual protected void CreateLaboratoryCollection()
        {
            _Laboratory = new DentalLaboratoryProcedure.ChildDentalLaboratoryProcedureCollection(this, new Guid("614b33b5-7e0b-4718-8e9d-e7d0d34b07be"));
            ((ITTChildObjectCollection)_Laboratory).GetChildren();
        }

        protected DentalLaboratoryProcedure.ChildDentalLaboratoryProcedureCollection _Laboratory = null;
        public DentalLaboratoryProcedure.ChildDentalLaboratoryProcedureCollection Laboratory
        {
            get
            {
                if (_Laboratory == null)
                    CreateLaboratoryCollection();
                return _Laboratory;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _DentalProcedures = new DentalProcedure.ChildDentalProcedureCollection(_SubactionProcedures, "DentalProcedures");
            _DentalExaminationProcedures = new DentalExaminationProcedure.ChildDentalExaminationProcedureCollection(_SubactionProcedures, "DentalExaminationProcedures");
            _DentalConsultationProcedures = new DentalConsultationProcedure.ChildDentalConsultationProcedureCollection(_SubactionProcedures, "DentalConsultationProcedures");
        }

        private DentalProcedure.ChildDentalProcedureCollection _DentalProcedures = null;
        public DentalProcedure.ChildDentalProcedureCollection DentalProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _DentalProcedures;
            }            
        }

        private DentalExaminationProcedure.ChildDentalExaminationProcedureCollection _DentalExaminationProcedures = null;
        public DentalExaminationProcedure.ChildDentalExaminationProcedureCollection DentalExaminationProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _DentalExaminationProcedures;
            }            
        }

        private DentalConsultationProcedure.ChildDentalConsultationProcedureCollection _DentalConsultationProcedures = null;
        public DentalConsultationProcedure.ChildDentalConsultationProcedureCollection DentalConsultationProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _DentalConsultationProcedures;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _DentalExaminationTreatmentMaterials = new DentalExaminationTreatmentMaterial.ChildDentalExaminationTreatmentMaterialCollection(_TreatmentMaterials, "DentalExaminationTreatmentMaterials");
        }

        private DentalExaminationTreatmentMaterial.ChildDentalExaminationTreatmentMaterialCollection _DentalExaminationTreatmentMaterials = null;
        public DentalExaminationTreatmentMaterial.ChildDentalExaminationTreatmentMaterialCollection DentalExaminationTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _DentalExaminationTreatmentMaterials;
            }            
        }

        protected DentalExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalExamination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalExamination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalExamination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALEXAMINATION", dataRow) { }
        protected DentalExamination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALEXAMINATION", dataRow, isImported) { }
        public DentalExamination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalExamination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalExamination() : base() { }

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