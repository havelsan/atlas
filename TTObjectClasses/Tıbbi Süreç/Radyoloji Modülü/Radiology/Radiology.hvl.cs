
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Radiology")] 

    /// <summary>
    /// Radyoloji
    /// </summary>
    public  partial class Radiology : EpisodeActionWithDiagnosis, IAllocateSpeciality, IEpisodeAction
    {
        public class RadiologyList : TTObjectCollection<Radiology> { }
                    
        public class ChildRadiologyCollection : TTObject.TTChildObjectCollection<Radiology>
        {
            public ChildRadiologyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class RadiologyRequestPatientInfoReportQuery_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object PreDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["PREDIAGNOSIS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public ToothNumberEnum? ToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["TOOTHNUMBER"].DataType;
                    return (ToothNumberEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DentalPositionEnum? DentalPosition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DENTALPOSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["DENTALPOSITION"].DataType;
                    return (DentalPositionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? DisTaahhutNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTAAHHUTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["DISTAAHHUTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? Anomali
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANOMALI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ANOMALI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AllCheck
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLCHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ALLCHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? SourceObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SOURCEOBJECTID"]);
                }
            }

            public Guid? TargetObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TARGETOBJECTID"]);
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public DateTime? Requestdate2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Requestdoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public long? Protocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Reasonforadm
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADM"]);
                }
            }

            public DateTime? Actdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
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

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public RadiologyRequestPatientInfoReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RadiologyRequestPatientInfoReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RadiologyRequestPatientInfoReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_RADYOLOJI_ORNEK_Class : TTReportNqlObject 
        {
            public Guid? Radyoloji_ornek_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RADYOLOJI_ORNEK_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public string Birim_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Kabul_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABUL_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Barkod_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BARKOD_NUMARASI"]);
                }
            }

            public DateTime? Barkod_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARKOD_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Calisma_baslama_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALISMA_BASLAMA_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Calisma_bitis_zamani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CALISMA_BITIS_ZAMANI"]);
                }
            }

            public Object Kabul_eden_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KABUL_EDEN_KULLANICI_KODU"]);
                }
            }

            public Object Ceken_teknisyen_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CEKEN_TEKNISYEN_KODU"]);
                }
            }

            public Object Hasta_hizmet_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTA_HIZMET_KODU"]);
                }
            }

            public Object Loinc_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["LOINC_KODU"]);
                }
            }

            public Object Tetkik_istenme_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TETKIK_ISTENME_DURUMU"]);
                }
            }

            public Object Erisim_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ERISIM_NUMARASI"]);
                }
            }

            public Object Ekleme_zamani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEME_ZAMANI"]);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
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

            public VEM_RADYOLOJI_ORNEK_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_RADYOLOJI_ORNEK_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_RADYOLOJI_ORNEK_Class() : base() { }
        }

        public static class States
        {
            public static Guid Reject { get { return new Guid("e7a2252f-a1a8-47fd-9a10-3b99d75de71c"); } }
    /// <summary>
    /// İşlemde
    /// </summary>
            public static Guid Procedure { get { return new Guid("26a6b5eb-f4da-49f0-95de-295336629488"); } }
            public static Guid Completed { get { return new Guid("056c2c8c-ac8a-4651-8e81-9b0e823fb282"); } }
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid Request { get { return new Guid("80db87ee-2193-4bc4-836b-53ea7686463e"); } }
        }

        public static BindingList<Radiology.RadiologyRequestPatientInfoReportQuery_Class> RadiologyRequestPatientInfoReportQuery(string PARAMRADOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].QueryDefs["RadiologyRequestPatientInfoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMRADOBJID", PARAMRADOBJID);

            return TTReportNqlObject.QueryObjects<Radiology.RadiologyRequestPatientInfoReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Radiology.RadiologyRequestPatientInfoReportQuery_Class> RadiologyRequestPatientInfoReportQuery(TTObjectContext objectContext, string PARAMRADOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].QueryDefs["RadiologyRequestPatientInfoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMRADOBJID", PARAMRADOBJID);

            return TTReportNqlObject.QueryObjects<Radiology.RadiologyRequestPatientInfoReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Radiology> GetByEpisodeAndClonedObjectID(TTObjectContext objectContext, Guid EPISODE, Guid CLONEDOBJECTID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].QueryDefs["GetByEpisodeAndClonedObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("CLONEDOBJECTID", CLONEDOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<Radiology>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Radiology.VEM_RADYOLOJI_ORNEK_Class> VEM_RADYOLOJI_ORNEK(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].QueryDefs["VEM_RADYOLOJI_ORNEK"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Radiology.VEM_RADYOLOJI_ORNEK_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Radiology.VEM_RADYOLOJI_ORNEK_Class> VEM_RADYOLOJI_ORNEK(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGY"].QueryDefs["VEM_RADYOLOJI_ORNEK"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Radiology.VEM_RADYOLOJI_ORNEK_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Teknisyen Notu
    /// </summary>
        public string TechnicianNote
        {
            get { return (string)this["TECHNICIANNOTE"]; }
            set { this["TECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// Kısa Anamnez ve Klinik Bulgular
    /// </summary>
        public object PreDiagnosis
        {
            get { return (object)this["PREDIAGNOSIS"]; }
            set { this["PREDIAGNOSIS"] = value; }
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
    /// Pozisyon
    /// </summary>
        public DentalPositionEnum? DentalPosition
        {
            get { return (DentalPositionEnum?)(int?)this["DENTALPOSITION"]; }
            set { this["DENTALPOSITION"] = value; }
        }

    /// <summary>
    /// Diş Taahhüt Numarası
    /// </summary>
        public int? DisTaahhutNo
        {
            get { return (int?)this["DISTAAHHUTNO"]; }
            set { this["DISTAAHHUTNO"] = value; }
        }

    /// <summary>
    /// Anomali
    /// </summary>
        public bool? Anomali
        {
            get { return (bool?)this["ANOMALI"]; }
            set { this["ANOMALI"] = value; }
        }

    /// <summary>
    /// Hepsini İşaretle
    /// </summary>
        public bool? AllCheck
        {
            get { return (bool?)this["ALLCHECK"]; }
            set { this["ALLCHECK"] = value; }
        }

    /// <summary>
    /// Açıklamalar
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kaynak Nesne IDsi
    /// </summary>
        public Guid? SourceObjectID
        {
            get { return (Guid?)this["SOURCEOBJECTID"]; }
            set { this["SOURCEOBJECTID"] = value; }
        }

    /// <summary>
    /// Hedef Nesne IDsi
    /// </summary>
        public Guid? TargetObjectID
        {
            get { return (Guid?)this["TARGETOBJECTID"]; }
            set { this["TARGETOBJECTID"] = value; }
        }

        public RadiologyRejectReasonDefinition RejectReason
        {
            get { return (RadiologyRejectReasonDefinition)((ITTObject)this).GetParent("REJECTREASON"); }
            set { this["REJECTREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan Doktor
    /// </summary>
        public ResUser RequestDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTDOCTOR"); }
            set { this["REQUESTDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Radyoloji İstek Şablonu İlişkisi
    /// </summary>
        public ActionTemplate RadiologyRequestTemplate
        {
            get { return (ActionTemplate)((ITTObject)this).GetParent("RADIOLOGYREQUESTTEMPLATE"); }
            set { this["RADIOLOGYREQUESTTEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMaterialsCollection()
        {
            _Materials = new RadiologyMaterial.ChildRadiologyMaterialCollection(this, new Guid("84ebdc81-6c3e-4a3f-892d-c1e5bb80901b"));
            ((ITTChildObjectCollection)_Materials).GetChildren();
        }

        protected RadiologyMaterial.ChildRadiologyMaterialCollection _Materials = null;
        public RadiologyMaterial.ChildRadiologyMaterialCollection Materials
        {
            get
            {
                if (_Materials == null)
                    CreateMaterialsCollection();
                return _Materials;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _RadiologyTests = new RadiologyTest.ChildRadiologyTestCollection(_SubactionProcedures, "RadiologyTests");
        }

        private RadiologyTest.ChildRadiologyTestCollection _RadiologyTests = null;
        public RadiologyTest.ChildRadiologyTestCollection RadiologyTests
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _RadiologyTests;
            }            
        }

        protected Radiology(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Radiology(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Radiology(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Radiology(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Radiology(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGY", dataRow) { }
        protected Radiology(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGY", dataRow, isImported) { }
        public Radiology(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Radiology(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Radiology() : base() { }

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