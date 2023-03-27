
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ConsultationFromOtherHospital")] 

    /// <summary>
    /// Dış XXXXXXlerden Konsültasyon
    /// </summary>
    public  partial class ConsultationFromOtherHospital : EpisodeActionWithDiagnosis, IAllocateSpeciality, IReasonOfReject, IWorkListEpisodeAction, INumaratorAppointment
    {
        public class ConsultationFromOtherHospitalList : TTObjectCollection<ConsultationFromOtherHospital> { }
                    
        public class ChildConsultationFromOtherHospitalCollection : TTObject.TTChildObjectCollection<ConsultationFromOtherHospital>
        {
            public ChildConsultationFromOtherHospitalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildConsultationFromOtherHospitalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetConsultationFromOtherHospitalInfo_Class : TTReportNqlObject 
        {
            public object ConsultationResultAndOffers
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSULTATIONRESULTANDOFFERS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].AllPropertyDefs["CONSULTATIONRESULTANDOFFERS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string RequestDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].AllPropertyDefs["REQUESTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Symptom
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SYMPTOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].AllPropertyDefs["SYMPTOM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Requesterdepartmentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTERDEPARTMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Requesterhospitalname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTERHOSPITALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOTHERHOSPITAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Requestedhospitalname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDHOSPITALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOTHERHOSPITAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Requestedhospitalobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTEDHOSPITALOBJECTID"]);
                }
            }

            public string Requesteddepartmentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDDEPARTMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].AllPropertyDefs["RESOURCENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Requestedexternalhospitalname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDEXTERNALHOSPITALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALHOSPITALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Requestedexternalhospobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTEDEXTERNALHOSPOBJECTID"]);
                }
            }

            public string Requestedexternaldeptname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDEXTERNALDEPTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Procedurespecialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURESPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
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

            public DateTime? Patientbirthdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientcityofbirth
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTCITYOFBIRTH"]);
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

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public GetConsultationFromOtherHospitalInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetConsultationFromOtherHospitalInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetConsultationFromOtherHospitalInfo_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetConsultationsToOtherHospitals_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public OLAP_GetConsultationsToOtherHospitals_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetConsultationsToOtherHospitals_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetConsultationsToOtherHospitals_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetConsultationFromOtherHospitalNew_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Reqmasres
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQMASRES"]);
                }
            }

            public Guid? Masres
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASRES"]);
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

            public OLAP_GetConsultationFromOtherHospitalNew_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetConsultationFromOtherHospitalNew_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetConsultationFromOtherHospitalNew_Class() : base() { }
        }

        public static class States
        {
            public static Guid Request { get { return new Guid("d2c1b080-888f-49c6-8766-73edd77b588b"); } }
            public static Guid Rejected { get { return new Guid("5f6129c7-f989-408a-b04d-80a5bc4503e4"); } }
            public static Guid Approval { get { return new Guid("e8cb8f45-f924-4abe-ae71-867ce897117d"); } }
            public static Guid Completed { get { return new Guid("2d50d546-27fc-421d-acf3-86857d3d4bf6"); } }
            public static Guid Cancelled { get { return new Guid("61f06268-33d0-481b-a645-f2a6e35fe075"); } }
            public static Guid ConsultationInOtherHospital { get { return new Guid("b9f3b2e8-2b58-477f-8346-c2108e1112e1"); } }
            public static Guid ResultEntry { get { return new Guid("12bae6ad-7f37-490a-a01d-f97ab216c9fd"); } }
    /// <summary>
    /// Sıraya Eklendi
    /// </summary>
            public static Guid InsertedIntoQueue { get { return new Guid("98e86983-a36e-4a2f-af91-70422d06836a"); } }
        }

    /// <summary>
    /// Dış XXXXXX Konsultasyon İstek Rapor NQL i
    /// </summary>
        public static BindingList<ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class> GetConsultationFromOtherHospitalInfo(string CONSULTATIONFROMOTHERHOSPITAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].QueryDefs["GetConsultationFromOtherHospitalInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CONSULTATIONFROMOTHERHOSPITAL", CONSULTATIONFROMOTHERHOSPITAL);

            return TTReportNqlObject.QueryObjects<ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Dış XXXXXX Konsultasyon İstek Rapor NQL i
    /// </summary>
        public static BindingList<ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class> GetConsultationFromOtherHospitalInfo(TTObjectContext objectContext, string CONSULTATIONFROMOTHERHOSPITAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].QueryDefs["GetConsultationFromOtherHospitalInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CONSULTATIONFROMOTHERHOSPITAL", CONSULTATIONFROMOTHERHOSPITAL);

            return TTReportNqlObject.QueryObjects<ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ConsultationFromOtherHospital.OLAP_GetConsultationsToOtherHospitals_Class> OLAP_GetConsultationsToOtherHospitals(string SITEID, string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].QueryDefs["OLAP_GetConsultationsToOtherHospitals"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SITEID", SITEID);
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<ConsultationFromOtherHospital.OLAP_GetConsultationsToOtherHospitals_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ConsultationFromOtherHospital.OLAP_GetConsultationsToOtherHospitals_Class> OLAP_GetConsultationsToOtherHospitals(TTObjectContext objectContext, string SITEID, string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].QueryDefs["OLAP_GetConsultationsToOtherHospitals"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SITEID", SITEID);
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<ConsultationFromOtherHospital.OLAP_GetConsultationsToOtherHospitals_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ConsultationFromOtherHospital.OLAP_GetConsultationFromOtherHospitalNew_Class> OLAP_GetConsultationFromOtherHospitalNew(DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].QueryDefs["OLAP_GetConsultationFromOtherHospitalNew"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<ConsultationFromOtherHospital.OLAP_GetConsultationFromOtherHospitalNew_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ConsultationFromOtherHospital.OLAP_GetConsultationFromOtherHospitalNew_Class> OLAP_GetConsultationFromOtherHospitalNew(TTObjectContext objectContext, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONFROMOTHERHOSPITAL"].QueryDefs["OLAP_GetConsultationFromOtherHospitalNew"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<ConsultationFromOtherHospital.OLAP_GetConsultationFromOtherHospitalNew_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Konsültasyonu Yapan Doktor Adı
    /// </summary>
        public string ConsultedDoctorName
        {
            get { return (string)this["CONSULTEDDOCTORNAME"]; }
            set { this["CONSULTEDDOCTORNAME"] = value; }
        }

    /// <summary>
    /// Anamnez Bulgular
    /// </summary>
        public string Symptom
        {
            get { return (string)this["SYMPTOM"]; }
            set { this["SYMPTOM"] = value; }
        }

    /// <summary>
    /// İstek Açıklaması
    /// </summary>
        public string RequestDescription
        {
            get { return (string)this["REQUESTDESCRIPTION"]; }
            set { this["REQUESTDESCRIPTION"] = value; }
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
    /// Gönderilen XXXXXXde oluşan konsültasyon işleminin objectID sini tutar.
    /// </summary>
        public string SourceObjectID
        {
            get { return (string)this["SOURCEOBJECTID"]; }
            set { this["SOURCEOBJECTID"] = value; }
        }

        public string MessageID
        {
            get { return (string)this["MESSAGEID"]; }
            set { this["MESSAGEID"] = value; }
        }

    /// <summary>
    /// Konsültasyonu İsteyen Doktor Adı
    /// </summary>
        public string RequesterDoctorName
        {
            get { return (string)this["REQUESTERDOCTORNAME"]; }
            set { this["REQUESTERDOCTORNAME"] = value; }
        }

    /// <summary>
    /// Gönderen XXXXXXdeki konsültasyon işleminin objectID sini tutar.
    /// </summary>
        public string TargetObjectID
        {
            get { return (string)this["TARGETOBJECTID"]; }
            set { this["TARGETOBJECTID"] = value; }
        }

    /// <summary>
    /// Protocol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

        public string RequesterResourceName
        {
            get { return (string)this["REQUESTERRESOURCENAME"]; }
            set { this["REQUESTERRESOURCENAME"] = value; }
        }

    /// <summary>
    /// Ayaktan Hasta Reçetesi
    /// </summary>
        public object OutPatientPrescriptionText
        {
            get { return (object)this["OUTPATIENTPRESCRIPTIONTEXT"]; }
            set { this["OUTPATIENTPRESCRIPTIONTEXT"] = value; }
        }

    /// <summary>
    /// İstek Yapan Doktor
    /// </summary>
        public ResUser RequesterDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTERDOCTOR"); }
            set { this["REQUESTERDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan Birim
    /// </summary>
        public ResSection RequesterResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("REQUESTERRESOURCE"); }
            set { this["REQUESTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapılan Dış XXXXXX Birimi
    /// </summary>
        public SpecialityDefinition RequestedExternalDepartment
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("REQUESTEDEXTERNALDEPARTMENT"); }
            set { this["REQUESTEDEXTERNALDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapılan XXXXXX XXXXXX
    /// </summary>
        public ReferableHospital RequestedReferableHospital
        {
            get { return (ReferableHospital)((ITTObject)this).GetParent("REQUESTEDREFERABLEHOSPITAL"); }
            set { this["REQUESTEDREFERABLEHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapılan XXXXXX XXXXXX Birimi
    /// </summary>
        public ReferableResource RequestedReferableResource
        {
            get { return (ReferableResource)((ITTObject)this).GetParent("REQUESTEDREFERABLERESOURCE"); }
            set { this["REQUESTEDREFERABLERESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapılan Dış XXXXXX
    /// </summary>
        public ExternalHospitalDefinition RequestedExternalHospital
        {
            get { return (ExternalHospitalDefinition)((ITTObject)this).GetParent("REQUESTEDEXTERNALHOSPITAL"); }
            set { this["REQUESTEDEXTERNALHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan XXXXXX
    /// </summary>
        public ResOtherHospital RequesterHospital
        {
            get { return (ResOtherHospital)((ITTObject)this).GetParent("REQUESTERHOSPITAL"); }
            set { this["REQUESTERHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTreamentsMaterialShadowsCollection()
        {
            _TreamentsMaterialShadows = new TreatmentMaterialShadow.ChildTreatmentMaterialShadowCollection(this, new Guid("bd5889e4-d9a5-4e3f-87c3-6025297b1637"));
            ((ITTChildObjectCollection)_TreamentsMaterialShadows).GetChildren();
        }

        protected TreatmentMaterialShadow.ChildTreatmentMaterialShadowCollection _TreamentsMaterialShadows = null;
    /// <summary>
    /// Child collection for Malzeme Sarf
    /// </summary>
        public TreatmentMaterialShadow.ChildTreatmentMaterialShadowCollection TreamentsMaterialShadows
        {
            get
            {
                if (_TreamentsMaterialShadows == null)
                    CreateTreamentsMaterialShadowsCollection();
                return _TreamentsMaterialShadows;
            }
        }

        protected ConsultationFromOtherHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ConsultationFromOtherHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ConsultationFromOtherHospital(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ConsultationFromOtherHospital(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ConsultationFromOtherHospital(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONSULTATIONFROMOTHERHOSPITAL", dataRow) { }
        protected ConsultationFromOtherHospital(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONSULTATIONFROMOTHERHOSPITAL", dataRow, isImported) { }
        public ConsultationFromOtherHospital(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ConsultationFromOtherHospital(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ConsultationFromOtherHospital() : base() { }

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