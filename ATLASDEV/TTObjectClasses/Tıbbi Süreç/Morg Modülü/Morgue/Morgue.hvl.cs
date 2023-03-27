
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Morgue")] 

    /// <summary>
    /// Morg İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class Morgue : EpisodeAction, IWorkListEpisodeAction
    {
        public class MorgueList : TTObjectCollection<Morgue> { }
                    
        public class ChildMorgueCollection : TTObject.TTChildObjectCollection<Morgue>
        {
            public ChildMorgueCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMorgueCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetMorgue_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? DateTimeOfDeath
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATETIMEOFDEATH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["DATETIMEOFDEATH"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? DiedClinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIEDCLINIC"]);
                }
            }

            public Guid? SenderDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SENDERDOCTOR"]);
                }
            }

            public Guid? DoctorFixed
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTORFIXED"]);
                }
            }

            public Guid? MernisDeathReasons
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MERNISDEATHREASONS"]);
                }
            }

            public StatisticalDeathReason? StatisticalDeathReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATISTICALDEATHREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["STATISTICALDEATHREASON"].DataType;
                    return (StatisticalDeathReason?)(int)dataType.ConvertValue(val);
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

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Admissiontype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADMISSIONTYPE"]);
                }
            }

            public DateTime? Admissiondate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
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

            public Guid? FromResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FROMRESOURCE"]);
                }
            }

            public OLAP_GetMorgue_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetMorgue_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetMorgue_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDeathPatientCount_Class : TTReportNqlObject 
        {
            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public bool? IsQuotaUsed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISQUOTAUSED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ISQUOTAUSED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetDeathPatientCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDeathPatientCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDeathPatientCount_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledMorgue_Class : TTReportNqlObject 
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

            public OLAP_GetCancelledMorgue_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledMorgue_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledMorgue_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMorgueRequests_Class : TTReportNqlObject 
        {
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

            public string Clinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doktorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doktorsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTORSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doktornamesurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTORNAMESURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMorgueRequests_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMorgueRequests_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMorgueRequests_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_HASTA_OLUM_Class : TTReportNqlObject 
        {
            public Guid? Hasta_olum_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_OLUM_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Hasta_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_KODU"]);
                }
            }

            public Object Hasta_basvuru_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public DateTime? Olum_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUM_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["DATETIMEOFDEATH"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DeathPlaceEnum? Olum_yeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUM_YERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["DEATHPLACE"].DataType;
                    return (DeathPlaceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Anne_olum_nedeni
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ANNE_OLUM_NEDENI"]);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Olum_otopsi_bilgisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OLUM_OTOPSI_BILGISI"]);
                }
            }

            public Guid? Duzenleyen_personel_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DUZENLEYEN_PERSONEL_KODU"]);
                }
            }

            public StatisticalDeathReason? Olum_nedeni
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUM_NEDENI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["STATISTICALDEATHREASON"].DataType;
                    return (StatisticalDeathReason?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Ex_kararini_veren_doktor_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EX_KARARINI_VEREN_DOKTOR_KODU"]);
                }
            }

            public DateTime? Tutanak_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TUTANAK_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["DATEOFDEATHREPORT"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Teslim_alan_tc_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESLIM_ALAN_TC_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["CITIZENSHIPNOOFADMITTED"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Teslim_alan_adi_soyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESLIM_ALAN_ADI_SOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["DEATHBODYADMITTEDTO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Teslim_alan_telefon_bilgisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESLIM_ALAN_TELEFON_BILGISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["PHONENUMBEROFADMITTED"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Teslim_alan_adresi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESLIM_ALAN_ADRESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["ADDRESOFADMITTED"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Teslim_eden_personel_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TESLIM_EDEN_PERSONEL_KODU"]);
                }
            }

            public DateTime? Kayit_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KAYIT_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public VEM_HASTA_OLUM_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_HASTA_OLUM_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_HASTA_OLUM_Class() : base() { }
        }

        [Serializable] 

        public partial class GetExPatientInEmergencyClinic_Class : TTReportNqlObject 
        {
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

            public long? Patientuniquerefno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Deathreason
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEATHREASON"]);
                }
            }

            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? MasterAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERACTION"]);
                }
            }

            public DateTime? Deathtime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEATHTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].AllPropertyDefs["DATETIMEOFDEATH"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? DiedClinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIEDCLINIC"]);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetExPatientInEmergencyClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExPatientInEmergencyClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExPatientInEmergencyClinic_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("247bca2d-cdb5-445e-9c35-4a16902a8294"); } }
    /// <summary>
    /// Dış İstek
    /// </summary>
            public static Guid OutRequest { get { return new Guid("0322d40c-300d-43e9-94ba-bc3bfbf56e69"); } }
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid Request { get { return new Guid("9ad0a2cc-4016-43b2-8c8b-69cbe3c949f2"); } }
            public static Guid Completed { get { return new Guid("48172d97-8c7d-4f7a-bbc7-ac00ea894e92"); } }
            public static Guid MorgueProcedure { get { return new Guid("2e586ccf-ab3a-4f2d-8747-d0e82a27bc2e"); } }
        }

        public static BindingList<Morgue.OLAP_GetMorgue_Class> OLAP_GetMorgue(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].QueryDefs["OLAP_GetMorgue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Morgue.OLAP_GetMorgue_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Morgue.OLAP_GetMorgue_Class> OLAP_GetMorgue(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].QueryDefs["OLAP_GetMorgue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Morgue.OLAP_GetMorgue_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Morgue.GetDeathPatientCount_Class> GetDeathPatientCount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].QueryDefs["GetDeathPatientCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Morgue.GetDeathPatientCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Morgue.GetDeathPatientCount_Class> GetDeathPatientCount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].QueryDefs["GetDeathPatientCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Morgue.GetDeathPatientCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Morgue.OLAP_GetCancelledMorgue_Class> OLAP_GetCancelledMorgue(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].QueryDefs["OLAP_GetCancelledMorgue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Morgue.OLAP_GetCancelledMorgue_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Morgue.OLAP_GetCancelledMorgue_Class> OLAP_GetCancelledMorgue(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].QueryDefs["OLAP_GetCancelledMorgue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Morgue.OLAP_GetCancelledMorgue_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Morgue.GetMorgueRequests_Class> GetMorgueRequests(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].QueryDefs["GetMorgueRequests"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Morgue.GetMorgueRequests_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Morgue.GetMorgueRequests_Class> GetMorgueRequests(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].QueryDefs["GetMorgueRequests"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Morgue.GetMorgueRequests_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Morgue.VEM_HASTA_OLUM_Class> VEM_HASTA_OLUM(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].QueryDefs["VEM_HASTA_OLUM"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Morgue.VEM_HASTA_OLUM_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Morgue.VEM_HASTA_OLUM_Class> VEM_HASTA_OLUM(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].QueryDefs["VEM_HASTA_OLUM"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Morgue.VEM_HASTA_OLUM_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Morgue.GetExPatientInEmergencyClinic_Class> GetExPatientInEmergencyClinic(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].QueryDefs["GetExPatientInEmergencyClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Morgue.GetExPatientInEmergencyClinic_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Morgue.GetExPatientInEmergencyClinic_Class> GetExPatientInEmergencyClinic(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MORGUE"].QueryDefs["GetExPatientInEmergencyClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Morgue.GetExPatientInEmergencyClinic_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İade Sebebi
    /// </summary>
        public object ReasonofReturn
        {
            get { return (object)this["REASONOFRETURN"]; }
            set { this["REASONOFRETURN"] = value; }
        }

    /// <summary>
    /// Cenazeyi Teslim Alanın Telefon Numarası
    /// </summary>
        public string PhoneNumberOfAdmitted
        {
            get { return (string)this["PHONENUMBEROFADMITTED"]; }
            set { this["PHONENUMBEROFADMITTED"] = value; }
        }

    /// <summary>
    /// Ana işlem tarafından iptal edildi
    /// </summary>
        public bool? CancelledByMasterAction
        {
            get { return (bool?)this["CANCELLEDBYMASTERACTION"]; }
            set { this["CANCELLEDBYMASTERACTION"] = value; }
        }

    /// <summary>
    /// Dış/İç Kabul
    /// </summary>
        public bool? IsOutRequest
        {
            get { return (bool?)this["ISOUTREQUEST"]; }
            set { this["ISOUTREQUEST"] = value; }
        }

    /// <summary>
    /// Morg Dolap No
    /// </summary>
        public string MorgueCupboardNo
        {
            get { return (string)this["MORGUECUPBOARDNO"]; }
            set { this["MORGUECUPBOARDNO"] = value; }
        }

    /// <summary>
    /// Mezarlık Ada ve Parsel Numarası
    /// </summary>
        public string GraveyardPlotNo
        {
            get { return (string)this["GRAVEYARDPLOTNO"]; }
            set { this["GRAVEYARDPLOTNO"] = value; }
        }

        public long? DiplomaNo
        {
            get { return (long?)this["DIPLOMANO"]; }
            set { this["DIPLOMANO"] = value; }
        }

    /// <summary>
    /// Ölüm Raporunun Numarası
    /// </summary>
        public int? DeathReportNo
        {
            get { return (int?)this["DEATHREPORTNO"]; }
            set { this["DEATHREPORTNO"] = value; }
        }

    /// <summary>
    /// Mezarlığa Gidiş Tarihi
    /// </summary>
        public DateTime? DateOfSentToGrave
        {
            get { return (DateTime?)this["DATEOFSENTTOGRAVE"]; }
            set { this["DATEOFSENTTOGRAVE"] = value; }
        }

    /// <summary>
    /// Cenazeyi Teslim Alanın TC Kimlik Numarası
    /// </summary>
        public string CitizenshipNoOfAdmitted
        {
            get { return (string)this["CITIZENSHIPNOOFADMITTED"]; }
            set { this["CITIZENSHIPNOOFADMITTED"] = value; }
        }

    /// <summary>
    /// Ölüm Nedenini Tespit Eden Kurum
    /// </summary>
        public string FoundationToFixDeath
        {
            get { return (string)this["FOUNDATIONTOFIXDEATH"]; }
            set { this["FOUNDATIONTOFIXDEATH"] = value; }
        }

    /// <summary>
    /// Cenazeyi Getirenin Telefonu
    /// </summary>
        public string PhoneNumberOfAdmittedFrom
        {
            get { return (string)this["PHONENUMBEROFADMITTEDFROM"]; }
            set { this["PHONENUMBEROFADMITTEDFROM"] = value; }
        }

    /// <summary>
    /// Ölümü Tespit Eden Dış Kurum Doktoru
    /// </summary>
        public string ExternalDoctorFixed
        {
            get { return (string)this["EXTERNALDOCTORFIXED"]; }
            set { this["EXTERNALDOCTORFIXED"] = value; }
        }

    /// <summary>
    /// Ölüm Raporunun Tarihi
    /// </summary>
        public DateTime? DateOfDeathReport
        {
            get { return (DateTime?)this["DATEOFDEATHREPORT"]; }
            set { this["DATEOFDEATHREPORT"] = value; }
        }

    /// <summary>
    /// Cenazeyi Getirenin Adresi
    /// </summary>
        public string AddressOfAdmittedFrom
        {
            get { return (string)this["ADDRESSOFADMITTEDFROM"]; }
            set { this["ADDRESSOFADMITTEDFROM"] = value; }
        }

    /// <summary>
    /// Ölüm Yeri
    /// </summary>
        public DeathPlaceEnum? DeathPlace
        {
            get { return (DeathPlaceEnum?)(int?)this["DEATHPLACE"]; }
            set { this["DEATHPLACE"] = value; }
        }

    /// <summary>
    /// Ölüyü Teslim Eden
    /// </summary>
        public string DeathBodyAdmittedFrom
        {
            get { return (string)this["DEATHBODYADMITTEDFROM"]; }
            set { this["DEATHBODYADMITTEDFROM"] = value; }
        }

    /// <summary>
    /// Karantina  Dolap No
    /// </summary>
        public string QuarantineCupboardNo
        {
            get { return (string)this["QUARANTINECUPBOARDNO"]; }
            set { this["QUARANTINECUPBOARDNO"] = value; }
        }

    /// <summary>
    /// Ölüm Sıra No
    /// </summary>
        public TTSequence DeathOrderNo
        {
            get { return GetSequence("DEATHORDERNO"); }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Eşyaları Teslim Alan
    /// </summary>
        public string MaterialsAdmittedTo
        {
            get { return (string)this["MATERIALSADMITTEDTO"]; }
            set { this["MATERIALSADMITTEDTO"] = value; }
        }

    /// <summary>
    /// Cenazeyi Teslim Alanın Adresi
    /// </summary>
        public string AddresOfAdmitted
        {
            get { return (string)this["ADDRESOFADMITTED"]; }
            set { this["ADDRESOFADMITTED"] = value; }
        }

    /// <summary>
    /// Dış Ölüm Sıra No
    /// </summary>
        public TTSequence OutDeathOrderNo
        {
            get { return GetSequence("OUTDEATHORDERNO"); }
        }

    /// <summary>
    /// Ölüm Tarihi ve Saati
    /// </summary>
        public DateTime? DateTimeOfDeath
        {
            get { return (DateTime?)this["DATETIMEOFDEATH"]; }
            set { this["DATETIMEOFDEATH"] = value; }
        }

    /// <summary>
    /// Ölüyü Teslim Alan
    /// </summary>
        public string DeathBodyAdmittedTo
        {
            get { return (string)this["DEATHBODYADMITTEDTO"]; }
            set { this["DEATHBODYADMITTEDTO"] = value; }
        }

    /// <summary>
    /// Cenazeyi Getirenin TC Kimlik Numarası
    /// </summary>
        public string CitizenshipNoOfAdmittedFrom
        {
            get { return (string)this["CITIZENSHIPNOOFADMITTEDFROM"]; }
            set { this["CITIZENSHIPNOOFADMITTEDFROM"] = value; }
        }

    /// <summary>
    /// İstatistiksel Ölüm Sebebi
    /// </summary>
        public StatisticalDeathReason? StatisticalDeathReason
        {
            get { return (StatisticalDeathReason?)(int?)this["STATISTICALDEATHREASON"]; }
            set { this["STATISTICALDEATHREASON"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

        public string TombVillage
        {
            get { return (string)this["TOMBVILLAGE"]; }
            set { this["TOMBVILLAGE"] = value; }
        }

    /// <summary>
    /// Hastanın Üzerinden Çıkanlar
    /// </summary>
        public string ObjectsFromPatient
        {
            get { return (string)this["OBJECTSFROMPATIENT"]; }
            set { this["OBJECTSFROMPATIENT"] = value; }
        }

    /// <summary>
    /// Ölümü Tespit Eden Dış Doktor TC
    /// </summary>
        public string ExternalDoctorFixedUniqueNo
        {
            get { return (string)this["EXTERNALDOCTORFIXEDUNIQUENO"]; }
            set { this["EXTERNALDOCTORFIXEDUNIQUENO"] = value; }
        }

    /// <summary>
    /// Yaralanma Mevcut
    /// </summary>
        public bool? InjuryExisting
        {
            get { return (bool?)this["INJURYEXISTING"]; }
            set { this["INJURYEXISTING"] = value; }
        }

    /// <summary>
    /// Yaralanma Tarihi
    /// </summary>
        public DateTime? InjuryDate
        {
            get { return (DateTime?)this["INJURYDATE"]; }
            set { this["INJURYDATE"] = value; }
        }

    /// <summary>
    /// Ölüm Nedeni Değerlendirme
    /// </summary>
        public object DeathReasonEvaluation
        {
            get { return (object)this["DEATHREASONEVALUATION"]; }
            set { this["DEATHREASONEVALUATION"] = value; }
        }

    /// <summary>
    /// Not
    /// </summary>
        public object Note
        {
            get { return (object)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Morga Gönder
    /// </summary>
        public bool? SendToMorgue
        {
            get { return (bool?)this["SENDTOMORGUE"]; }
            set { this["SENDTOMORGUE"] = value; }
        }

    /// <summary>
    /// Otopsi Yapılacak
    /// </summary>
        public bool? AutopsyToDo
        {
            get { return (bool?)this["AUTOPSYTODO"]; }
            set { this["AUTOPSYTODO"] = value; }
        }

    /// <summary>
    /// Hasta Merkeze Ex Geldi
    /// </summary>
        public bool? PatientCameEx
        {
            get { return (bool?)this["PATIENTCAMEEX"]; }
            set { this["PATIENTCAMEEX"] = value; }
        }

    /// <summary>
    /// Morga Gönderen Dış Doktor
    /// </summary>
        public string ExternalSenderDoctorToMorgue
        {
            get { return (string)this["EXTERNALSENDERDOCTORTOMORGUE"]; }
            set { this["EXTERNALSENDERDOCTORTOMORGUE"] = value; }
        }

    /// <summary>
    /// Morga Gönderen Dış Doktor TC Kimlik Numarası
    /// </summary>
        public string ExternalSenderDoctorMorgueUnR
        {
            get { return (string)this["EXTERNALSENDERDOCTORMORGUEUNR"]; }
            set { this["EXTERNALSENDERDOCTORMORGUEUNR"] = value; }
        }

    /// <summary>
    /// Ölüm Yeri
    /// </summary>
        public SKRSOlumYeri SKRSDeathPlace
        {
            get { return (SKRSOlumYeri)((ITTObject)this).GetParent("SKRSDEATHPLACE"); }
            set { this["SKRSDEATHPLACE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ölüm Nedeni Türü
    /// </summary>
        public SKRSOlumNedeniTuru SKRSDeathReason
        {
            get { return (SKRSOlumNedeniTuru)((ITTObject)this).GetParent("SKRSDEATHREASON"); }
            set { this["SKRSDEATHREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSYaralanmaninYeri SKRSInjuryPlace
        {
            get { return (SKRSYaralanmaninYeri)((ITTObject)this).GetParent("SKRSINJURYPLACE"); }
            set { this["SKRSINJURYPLACE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Morga Gönderen Doktor
    /// </summary>
        public ResUser SenderDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("SENDERDOCTOR"); }
            set { this["SENDERDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ölüm Sebebi
    /// </summary>
        public ReasonForDeathDefinition ReasonForDeath
        {
            get { return (ReasonForDeathDefinition)((ITTObject)this).GetParent("REASONFORDEATH"); }
            set { this["REASONFORDEATH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ölümü Tespit Eden Doktor
    /// </summary>
        public ResUser DoctorFixed
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTORFIXED"); }
            set { this["DOCTORFIXED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CupboardDefinition Cupboard
        {
            get { return (CupboardDefinition)((ITTObject)this).GetParent("CUPBOARD"); }
            set { this["CUPBOARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Vefat Ettiği Klinik
    /// </summary>
        public ResSection DiedClinic
        {
            get { return (ResSection)((ITTObject)this).GetParent("DIEDCLINIC"); }
            set { this["DIEDCLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser DeliveredBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("DELIVEREDBY"); }
            set { this["DELIVEREDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hemşire
    /// </summary>
        public ResUser Nurse
        {
            get { return (ResUser)((ITTObject)this).GetParent("NURSE"); }
            set { this["NURSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mernis Ölüm Sebepleri
    /// </summary>
        public MernisDeathReasonDefinition MernisDeathReasons
        {
            get { return (MernisDeathReasonDefinition)((ITTObject)this).GetParent("MERNISDEATHREASONS"); }
            set { this["MERNISDEATHREASONS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Eşyaları Teslim Eden
    /// </summary>
        public ResUser MaterialsAdmittedFrom
        {
            get { return (ResUser)((ITTObject)this).GetParent("MATERIALSADMITTEDFROM"); }
            set { this["MATERIALSADMITTEDFROM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Cenazenin Nakil Olduğu İl
    /// </summary>
        public SKRSILKodlari SKRSTombCity
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("SKRSTOMBCITY"); }
            set { this["SKRSTOMBCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Cenazenin Nakil Olduğu İlçe
    /// </summary>
        public SKRSIlceKodlari SKRSTombTown
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("SKRSTOMBTOWN"); }
            set { this["SKRSTOMBTOWN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDeathReasonDiagnosisCollection()
        {
            _DeathReasonDiagnosis = new DeathReasonDiagnosis.ChildDeathReasonDiagnosisCollection(this, new Guid("56858908-aaa8-44b1-b77b-efa246928796"));
            ((ITTChildObjectCollection)_DeathReasonDiagnosis).GetChildren();
        }

        protected DeathReasonDiagnosis.ChildDeathReasonDiagnosisCollection _DeathReasonDiagnosis = null;
        public DeathReasonDiagnosis.ChildDeathReasonDiagnosisCollection DeathReasonDiagnosis
        {
            get
            {
                if (_DeathReasonDiagnosis == null)
                    CreateDeathReasonDiagnosisCollection();
                return _DeathReasonDiagnosis;
            }
        }

        virtual protected void CreateTakenMaterialsCollection()
        {
            _TakenMaterials = new MorgueTakenMaterial.ChildMorgueTakenMaterialCollection(this, new Guid("d2982114-4afd-45c5-bd6b-740679511ca0"));
            ((ITTChildObjectCollection)_TakenMaterials).GetChildren();
        }

        protected MorgueTakenMaterial.ChildMorgueTakenMaterialCollection _TakenMaterials = null;
    /// <summary>
    /// Child collection for Alınan Eşyalar
    /// </summary>
        public MorgueTakenMaterial.ChildMorgueTakenMaterialCollection TakenMaterials
        {
            get
            {
                if (_TakenMaterials == null)
                    CreateTakenMaterialsCollection();
                return _TakenMaterials;
            }
        }

        virtual protected void CreateMoneyCollection()
        {
            _Money = new MorgueMoney.ChildMorgueMoneyCollection(this, new Guid("34b20faf-9de1-4dea-8bd3-904475e678f4"));
            ((ITTChildObjectCollection)_Money).GetChildren();
        }

        protected MorgueMoney.ChildMorgueMoneyCollection _Money = null;
    /// <summary>
    /// Child collection for Para
    /// </summary>
        public MorgueMoney.ChildMorgueMoneyCollection Money
        {
            get
            {
                if (_Money == null)
                    CreateMoneyCollection();
                return _Money;
            }
        }

        virtual protected void CreateGivenMaterialsCollection()
        {
            _GivenMaterials = new MorgueGivenMaterial.ChildMorgueGivenMaterialCollection(this, new Guid("52ad5093-ea3f-4872-8647-d06bd71128a9"));
            ((ITTChildObjectCollection)_GivenMaterials).GetChildren();
        }

        protected MorgueGivenMaterial.ChildMorgueGivenMaterialCollection _GivenMaterials = null;
    /// <summary>
    /// Child collection for Verilen Eşyalar
    /// </summary>
        public MorgueGivenMaterial.ChildMorgueGivenMaterialCollection GivenMaterials
        {
            get
            {
                if (_GivenMaterials == null)
                    CreateGivenMaterialsCollection();
                return _GivenMaterials;
            }
        }

        virtual protected void CreateMorgueTransplantCollection()
        {
            _MorgueTransplant = new Transplant.ChildTransplantCollection(this, new Guid("76da56ea-e7bc-4aac-8d06-5254f7a091d0"));
            ((ITTChildObjectCollection)_MorgueTransplant).GetChildren();
        }

        protected Transplant.ChildTransplantCollection _MorgueTransplant = null;
    /// <summary>
    /// Child collection for Morg Hasta Nakil
    /// </summary>
        public Transplant.ChildTransplantCollection MorgueTransplant
        {
            get
            {
                if (_MorgueTransplant == null)
                    CreateMorgueTransplantCollection();
                return _MorgueTransplant;
            }
        }

        virtual protected void CreateMorgueDeathTypeCollection()
        {
            _MorgueDeathType = new MorgueDeathType.ChildMorgueDeathTypeCollection(this, new Guid("9edddf76-7a06-4f03-93ea-72eb4b761bad"));
            ((ITTChildObjectCollection)_MorgueDeathType).GetChildren();
        }

        protected MorgueDeathType.ChildMorgueDeathTypeCollection _MorgueDeathType = null;
        public MorgueDeathType.ChildMorgueDeathTypeCollection MorgueDeathType
        {
            get
            {
                if (_MorgueDeathType == null)
                    CreateMorgueDeathTypeCollection();
                return _MorgueDeathType;
            }
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _MorgueTreatmentMaterials = new MorgueTreatmentMaterial.ChildMorgueTreatmentMaterialCollection(_TreatmentMaterials, "MorgueTreatmentMaterials");
        }

        private MorgueTreatmentMaterial.ChildMorgueTreatmentMaterialCollection _MorgueTreatmentMaterials = null;
        public MorgueTreatmentMaterial.ChildMorgueTreatmentMaterialCollection MorgueTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _MorgueTreatmentMaterials;
            }            
        }

        protected Morgue(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Morgue(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Morgue(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Morgue(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Morgue(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MORGUE", dataRow) { }
        protected Morgue(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MORGUE", dataRow, isImported) { }
        public Morgue(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Morgue(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Morgue() : base() { }

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