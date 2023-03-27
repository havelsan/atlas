
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhysicianApplication")] 

    /// <summary>
    /// Muayene,Kontrol Muayenesi,Konsültasyon, Klinik Doktor İşlemleri gibi doktor işlemlerinin ana objesi
    /// </summary>
    public  partial class PhysicianApplication : EpisodeActionWithDiagnosis, IDiagnosisOzelDurum
    {
        public class PhysicianApplicationList : TTObjectCollection<PhysicianApplication> { }
                    
        public class ChildPhysicianApplicationCollection : TTObject.TTChildObjectCollection<PhysicianApplication>
        {
            public ChildPhysicianApplicationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhysicianApplicationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetExaminationDetailsBySubepisodeId_Class : TTReportNqlObject 
        {
            public object Sikayet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIKAYET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["COMPLAINT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Devamliilac
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVAMLIILAC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["CONTINUOUSDRUGS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Kararveislem
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARARVEISLEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["DECISIONANDACTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Muayeneozeti
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENEOZETI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["EXAMINATIONSUMMARY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Aliskanliklar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALISKANLIKLAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["HABITS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Soygecmis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYGECMIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["PATIENTFAMILYHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Digerbilgiler
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIGERBILGILER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["PATIENTFOLDER"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Ozgecmis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OZGECMIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Hikayesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HIKAYESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["PATIENTSTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Fizikimuayene
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIZIKIMUAYENE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetExaminationDetailsBySubepisodeId_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExaminationDetailsBySubepisodeId_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExaminationDetailsBySubepisodeId_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysicianApplicationWithAnamnesis_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ProcessDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["PROCESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Doctorid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTORID"]);
                }
            }

            public Guid? Branchid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BRANCHID"]);
                }
            }

            public bool? IsPrivate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPRIVATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["ISPRIVATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetPhysicianApplicationWithAnamnesis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysicianApplicationWithAnamnesis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysicianApplicationWithAnamnesis_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForPoliclinic_Class : TTReportNqlObject 
        {
            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public String Defname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Uzmanlik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UZMANLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Type
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TYPE"]);
                }
            }

            public GetOldInfoForPoliclinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForPoliclinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForPoliclinic_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_HASTA_EPIKRIZ_2_Class : TTReportNqlObject 
        {
            public Guid? Hasta_epikriz_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_EPIKRIZ_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public DateTime? Epikriz_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPIKRIZ_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Epikriz_bilgisi_baslik
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPIKRIZ_BILGISI_BASLIK"]);
                }
            }

            public object Epikriz_bilgisi_aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPIKRIZ_BILGISI_ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["COMPLAINT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Guid? Hekim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEKIM_KODU"]);
                }
            }

            public Guid? Ekleyen_kullanici_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_HASTA_EPIKRIZ_2_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_HASTA_EPIKRIZ_2_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_HASTA_EPIKRIZ_2_Class() : base() { }
        }

        public static BindingList<PhysicianApplication.GetExaminationDetailsBySubepisodeId_Class> GetExaminationDetailsBySubepisodeId(string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].QueryDefs["GetExaminationDetailsBySubepisodeId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<PhysicianApplication.GetExaminationDetailsBySubepisodeId_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysicianApplication.GetExaminationDetailsBySubepisodeId_Class> GetExaminationDetailsBySubepisodeId(TTObjectContext objectContext, string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].QueryDefs["GetExaminationDetailsBySubepisodeId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<PhysicianApplication.GetExaminationDetailsBySubepisodeId_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PhysicianApplication.GetPhysicianApplicationWithAnamnesis_Class> GetPhysicianApplicationWithAnamnesis(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].QueryDefs["GetPhysicianApplicationWithAnamnesis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<PhysicianApplication.GetPhysicianApplicationWithAnamnesis_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysicianApplication.GetPhysicianApplicationWithAnamnesis_Class> GetPhysicianApplicationWithAnamnesis(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].QueryDefs["GetPhysicianApplicationWithAnamnesis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<PhysicianApplication.GetPhysicianApplicationWithAnamnesis_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PhysicianApplication.GetOldInfoForPoliclinic_Class> GetOldInfoForPoliclinic(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].QueryDefs["GetOldInfoForPoliclinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<PhysicianApplication.GetOldInfoForPoliclinic_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysicianApplication.GetOldInfoForPoliclinic_Class> GetOldInfoForPoliclinic(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].QueryDefs["GetOldInfoForPoliclinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<PhysicianApplication.GetOldInfoForPoliclinic_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysicianApplication.VEM_HASTA_EPIKRIZ_2_Class> VEM_HASTA_EPIKRIZ_2(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].QueryDefs["VEM_HASTA_EPIKRIZ_2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysicianApplication.VEM_HASTA_EPIKRIZ_2_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysicianApplication.VEM_HASTA_EPIKRIZ_2_Class> VEM_HASTA_EPIKRIZ_2(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].QueryDefs["VEM_HASTA_EPIKRIZ_2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysicianApplication.VEM_HASTA_EPIKRIZ_2_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Muayene Bitiş Tarihi
    /// </summary>
        public DateTime? ProcessEndDate
        {
            get { return (DateTime?)this["PROCESSENDDATE"]; }
            set { this["PROCESSENDDATE"] = value; }
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
    /// Devamlı İlaçlar
    /// </summary>
        public object ContinuousDrugs
        {
            get { return (object)this["CONTINUOUSDRUGS"]; }
            set { this["CONTINUOUSDRUGS"] = value; }
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
    /// Muayene Özeti
    /// </summary>
        public object ExaminationSummary
        {
            get { return (object)this["EXAMINATIONSUMMARY"]; }
            set { this["EXAMINATIONSUMMARY"] = value; }
        }

    /// <summary>
    /// Alışkanlıklar
    /// </summary>
        public object Habits
        {
            get { return (object)this["HABITS"]; }
            set { this["HABITS"] = value; }
        }

    /// <summary>
    /// Şema
    /// </summary>
        public object Image
        {
            get { return (object)this["IMAGE"]; }
            set { this["IMAGE"] = value; }
        }

        public bool? IsTreatmentMaterialEmpty
        {
            get { return (bool?)this["ISTREATMENTMATERIALEMPTY"]; }
            set { this["ISTREATMENTMATERIALEMPTY"] = value; }
        }

    /// <summary>
    /// Soygeçmiş
    /// </summary>
        public object PatientFamilyHistory
        {
            get { return (object)this["PATIENTFAMILYHISTORY"]; }
            set { this["PATIENTFAMILYHISTORY"] = value; }
        }

    /// <summary>
    /// Diğer Bilgiler
    /// </summary>
        public object PatientFolder
        {
            get { return (object)this["PATIENTFOLDER"]; }
            set { this["PATIENTFOLDER"] = value; }
        }

    /// <summary>
    /// Özgeçmiş / Soygeçmiş
    /// </summary>
        public object PatientHistory
        {
            get { return (object)this["PATIENTHISTORY"]; }
            set { this["PATIENTHISTORY"] = value; }
        }

    /// <summary>
    /// Hikayesi
    /// </summary>
        public object PatientStory
        {
            get { return (object)this["PATIENTSTORY"]; }
            set { this["PATIENTSTORY"] = value; }
        }

    /// <summary>
    /// Fizik Muayene
    /// </summary>
        public object PhysicalExamination
        {
            get { return (object)this["PHYSICALEXAMINATION"]; }
            set { this["PHYSICALEXAMINATION"] = value; }
        }

    /// <summary>
    /// Muayenenin Yapıldığı Tarih
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
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
    /// MTS Karar
    /// </summary>
        public object MTSConclusion
        {
            get { return (object)this["MTSCONCLUSION"]; }
            set { this["MTSCONCLUSION"] = value; }
        }

    /// <summary>
    /// OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction MasterPhysicianApplication
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("MASTERPHYSICIANAPPLICATION"); }
            set { this["MASTERPHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateExaminationInfoByBransCollection()
        {
            _ExaminationInfoByBrans = new ExaminationInfoByBrans.ChildExaminationInfoByBransCollection(this, new Guid("7f3e2890-6bc9-4992-b02a-28644cd7b373"));
            ((ITTChildObjectCollection)_ExaminationInfoByBrans).GetChildren();
        }

        protected ExaminationInfoByBrans.ChildExaminationInfoByBransCollection _ExaminationInfoByBrans = null;
        public ExaminationInfoByBrans.ChildExaminationInfoByBransCollection ExaminationInfoByBrans
        {
            get
            {
                if (_ExaminationInfoByBrans == null)
                    CreateExaminationInfoByBransCollection();
                return _ExaminationInfoByBrans;
            }
        }

        virtual protected void CreateConsultationsCollection()
        {
            _Consultations = new Consultation.ChildConsultationCollection(this, new Guid("b4ebd397-2487-4fc0-abb0-ec24558ecf95"));
            ((ITTChildObjectCollection)_Consultations).GetChildren();
        }

        protected Consultation.ChildConsultationCollection _Consultations = null;
        public Consultation.ChildConsultationCollection Consultations
        {
            get
            {
                if (_Consultations == null)
                    CreateConsultationsCollection();
                return _Consultations;
            }
        }

        virtual protected void CreateSingleNursingOrdersCollection()
        {
            _SingleNursingOrders = new SingleNursingOrder.ChildSingleNursingOrderCollection(this, new Guid("693407a0-c60d-4222-99f5-7f9af7569c83"));
            ((ITTChildObjectCollection)_SingleNursingOrders).GetChildren();
        }

        protected SingleNursingOrder.ChildSingleNursingOrderCollection _SingleNursingOrders = null;
        public SingleNursingOrder.ChildSingleNursingOrderCollection SingleNursingOrders
        {
            get
            {
                if (_SingleNursingOrders == null)
                    CreateSingleNursingOrdersCollection();
                return _SingleNursingOrders;
            }
        }

        virtual protected void CreatePatientInteviewFormsCollection()
        {
            _PatientInteviewForms = new PatientInterviewForm.ChildPatientInterviewFormCollection(this, new Guid("d0b84078-ffd3-41d0-b7c2-847f11721057"));
            ((ITTChildObjectCollection)_PatientInteviewForms).GetChildren();
        }

        protected PatientInterviewForm.ChildPatientInterviewFormCollection _PatientInteviewForms = null;
        public PatientInterviewForm.ChildPatientInterviewFormCollection PatientInteviewForms
        {
            get
            {
                if (_PatientInteviewForms == null)
                    CreatePatientInteviewFormsCollection();
                return _PatientInteviewForms;
            }
        }

        virtual protected void CreateSpecialityBasedObjectCollection()
        {
            _SpecialityBasedObject = new SpecialityBasedObject.ChildSpecialityBasedObjectCollection(this, new Guid("0c4c2979-a801-4dff-8f78-a02a9ab583a0"));
            ((ITTChildObjectCollection)_SpecialityBasedObject).GetChildren();
        }

        protected SpecialityBasedObject.ChildSpecialityBasedObjectCollection _SpecialityBasedObject = null;
        public SpecialityBasedObject.ChildSpecialityBasedObjectCollection SpecialityBasedObject
        {
            get
            {
                if (_SpecialityBasedObject == null)
                    CreateSpecialityBasedObjectCollection();
                return _SpecialityBasedObject;
            }
        }

        virtual protected void CreateExternalConsultationsCollection()
        {
            _ExternalConsultations = new ConsultationFromExternalHospital.ChildConsultationFromExternalHospitalCollection(this, new Guid("5cea5ff0-3d5a-400e-81ee-848002f38e43"));
            ((ITTChildObjectCollection)_ExternalConsultations).GetChildren();
        }

        protected ConsultationFromExternalHospital.ChildConsultationFromExternalHospitalCollection _ExternalConsultations = null;
        public ConsultationFromExternalHospital.ChildConsultationFromExternalHospitalCollection ExternalConsultations
        {
            get
            {
                if (_ExternalConsultations == null)
                    CreateExternalConsultationsCollection();
                return _ExternalConsultations;
            }
        }

        virtual protected void CreateOldSpecialityBasedObjectCollection()
        {
            _OldSpecialityBasedObject = new SpecialityBasedObject.ChildSpecialityBasedObjectCollection(this, new Guid("a42e0880-721e-465a-b915-750d01b103b3"));
            ((ITTChildObjectCollection)_OldSpecialityBasedObject).GetChildren();
        }

        protected SpecialityBasedObject.ChildSpecialityBasedObjectCollection _OldSpecialityBasedObject = null;
        public SpecialityBasedObject.ChildSpecialityBasedObjectCollection OldSpecialityBasedObject
        {
            get
            {
                if (_OldSpecialityBasedObject == null)
                    CreateOldSpecialityBasedObjectCollection();
                return _OldSpecialityBasedObject;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _SingleNursingOrderDetails = new SingleNursingOrderDetail.ChildSingleNursingOrderDetailCollection(_SubactionProcedures, "SingleNursingOrderDetails");
        }

        private SingleNursingOrderDetail.ChildSingleNursingOrderDetailCollection _SingleNursingOrderDetails = null;
        public SingleNursingOrderDetail.ChildSingleNursingOrderDetailCollection SingleNursingOrderDetails
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _SingleNursingOrderDetails;
            }            
        }

        override protected void CreateBaseMultipleDataEntriesCollectionViews()
        {
            base.CreateBaseMultipleDataEntriesCollectionViews();
            _SapScores = new SapsScore.ChildSapsScoreCollection(_BaseMultipleDataEntries, "SapScores");
            _ApacheScores = new ApacheScore.ChildApacheScoreCollection(_BaseMultipleDataEntries, "ApacheScores");
            _GlaskowScores = new GlaskowScore.ChildGlaskowScoreCollection(_BaseMultipleDataEntries, "GlaskowScores");
            _ApgarScores = new Apgar.ChildApgarCollection(_BaseMultipleDataEntries, "ApgarScores");
            _BallardNeuromuscularScores = new BallardNeuromuscular.ChildBallardNeuromuscularCollection(_BaseMultipleDataEntries, "BallardNeuromuscularScores");
            _BallardPhysicalScores = new BallardPhysical.ChildBallardPhysicalCollection(_BaseMultipleDataEntries, "BallardPhysicalScores");
            _GeneralInformation = new GeneralInformation.ChildGeneralInformationCollection(_BaseMultipleDataEntries, "GeneralInformation");
            _SnappeScores = new Snappe.ChildSnappeCollection(_BaseMultipleDataEntries, "SnappeScores");
            _Phototherapy = new Phototherapy.ChildPhototherapyCollection(_BaseMultipleDataEntries, "Phototherapy");
            _WeightChart = new WeightChart.ChildWeightChartCollection(_BaseMultipleDataEntries, "WeightChart");
            _Prisms = new Prism.ChildPrismCollection(_BaseMultipleDataEntries, "Prisms");
        }

        private SapsScore.ChildSapsScoreCollection _SapScores = null;
        public SapsScore.ChildSapsScoreCollection SapScores
        {
            get
            {
                if (_BaseMultipleDataEntries == null)
                    CreateBaseMultipleDataEntriesCollection();
                return _SapScores;
            }            
        }

        private ApacheScore.ChildApacheScoreCollection _ApacheScores = null;
        public ApacheScore.ChildApacheScoreCollection ApacheScores
        {
            get
            {
                if (_BaseMultipleDataEntries == null)
                    CreateBaseMultipleDataEntriesCollection();
                return _ApacheScores;
            }            
        }

        private GlaskowScore.ChildGlaskowScoreCollection _GlaskowScores = null;
        public GlaskowScore.ChildGlaskowScoreCollection GlaskowScores
        {
            get
            {
                if (_BaseMultipleDataEntries == null)
                    CreateBaseMultipleDataEntriesCollection();
                return _GlaskowScores;
            }            
        }

        private Apgar.ChildApgarCollection _ApgarScores = null;
        public Apgar.ChildApgarCollection ApgarScores
        {
            get
            {
                if (_BaseMultipleDataEntries == null)
                    CreateBaseMultipleDataEntriesCollection();
                return _ApgarScores;
            }            
        }

        private BallardNeuromuscular.ChildBallardNeuromuscularCollection _BallardNeuromuscularScores = null;
        public BallardNeuromuscular.ChildBallardNeuromuscularCollection BallardNeuromuscularScores
        {
            get
            {
                if (_BaseMultipleDataEntries == null)
                    CreateBaseMultipleDataEntriesCollection();
                return _BallardNeuromuscularScores;
            }            
        }

        private BallardPhysical.ChildBallardPhysicalCollection _BallardPhysicalScores = null;
        public BallardPhysical.ChildBallardPhysicalCollection BallardPhysicalScores
        {
            get
            {
                if (_BaseMultipleDataEntries == null)
                    CreateBaseMultipleDataEntriesCollection();
                return _BallardPhysicalScores;
            }            
        }

        private GeneralInformation.ChildGeneralInformationCollection _GeneralInformation = null;
        public GeneralInformation.ChildGeneralInformationCollection GeneralInformation
        {
            get
            {
                if (_BaseMultipleDataEntries == null)
                    CreateBaseMultipleDataEntriesCollection();
                return _GeneralInformation;
            }            
        }

        private Snappe.ChildSnappeCollection _SnappeScores = null;
        public Snappe.ChildSnappeCollection SnappeScores
        {
            get
            {
                if (_BaseMultipleDataEntries == null)
                    CreateBaseMultipleDataEntriesCollection();
                return _SnappeScores;
            }            
        }

        private Phototherapy.ChildPhototherapyCollection _Phototherapy = null;
        public Phototherapy.ChildPhototherapyCollection Phototherapy
        {
            get
            {
                if (_BaseMultipleDataEntries == null)
                    CreateBaseMultipleDataEntriesCollection();
                return _Phototherapy;
            }            
        }

        private WeightChart.ChildWeightChartCollection _WeightChart = null;
        public WeightChart.ChildWeightChartCollection WeightChart
        {
            get
            {
                if (_BaseMultipleDataEntries == null)
                    CreateBaseMultipleDataEntriesCollection();
                return _WeightChart;
            }            
        }

        private Prism.ChildPrismCollection _Prisms = null;
        public Prism.ChildPrismCollection Prisms
        {
            get
            {
                if (_BaseMultipleDataEntries == null)
                    CreateBaseMultipleDataEntriesCollection();
                return _Prisms;
            }            
        }

        protected PhysicianApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhysicianApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhysicianApplication(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhysicianApplication(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhysicianApplication(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHYSICIANAPPLICATION", dataRow) { }
        protected PhysicianApplication(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHYSICIANAPPLICATION", dataRow, isImported) { }
        public PhysicianApplication(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhysicianApplication(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhysicianApplication() : base() { }

    }
}