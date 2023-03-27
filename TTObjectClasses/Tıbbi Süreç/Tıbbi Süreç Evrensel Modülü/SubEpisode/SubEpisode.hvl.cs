
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubEpisode")] 

    public  partial class SubEpisode : TTObject
    {
        public class SubEpisodeList : TTObjectCollection<SubEpisode> { }
                    
        public class ChildSubEpisodeCollection : TTObject.TTChildObjectCollection<SubEpisode>
        {
            public ChildSubEpisodeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubEpisodeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNotDiagnosisExistsByPatientGroup_Class : TTReportNqlObject 
        {
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

            public long? HospitalProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string Department
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENT"]);
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

            public GetNotDiagnosisExistsByPatientGroup_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNotDiagnosisExistsByPatientGroup_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNotDiagnosisExistsByPatientGroup_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientInformationBySubepisodeid_Class : TTReportNqlObject 
        {
            public long? Hasta_no
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTA_NO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Hasta_kimlik_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTA_KIMLIK_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Ad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Dogum_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUM_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Cinsiyet_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYET_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cinsiyet_deger
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYET_DEGER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Uyruk_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UYRUK_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Uyruk_deger
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UYRUK_DEGER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Anne_kimlik_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNE_KIMLIK_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Dogum_sirasi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOGUM_SIRASI"]);
                }
            }

            public double? Yabanci_hasta_kimlik_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YABANCI_HASTA_KIMLIK_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Hasta_mail_adresi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTA_MAIL_ADRESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["EMAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pasaport_no
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PASAPORT_NO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PASSPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Acik_adres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIK_ADRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Acik_adres_il
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIK_ADRES_IL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILKODLARI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Acik_adres_ilce
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIK_ADRES_ILCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILCEKODLARI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Bebek
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BEBEK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ISNEWBORN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string AddressNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDRESSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["ADDRESSNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Yabanci
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YABANCI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Sonuc_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SONUC_KODU"]);
                }
            }

            public Object Sonuc_mesaji
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SONUC_MESAJI"]);
                }
            }

            public GetPatientInformationBySubepisodeid_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientInformationBySubepisodeid_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientInformationBySubepisodeid_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaxProtocolNo_Class : TTReportNqlObject 
        {
            public Object Maxprotocolno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MAXPROTOCOLNO"]);
                }
            }

            public GetMaxProtocolNo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaxProtocolNo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaxProtocolNo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForSubEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Specialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetOldInfoForSubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForSubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForSubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByDateAndPatientGroupAndDepartment_Class : TTReportNqlObject 
        {
            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
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

            public long? HospitalProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public SubEpisodeStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (SubEpisodeStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Department
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENT"]);
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

            public GetByDateAndPatientGroupAndDepartment_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByDateAndPatientGroupAndDepartment_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByDateAndPatientGroupAndDepartment_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSubEpisodeExceptCancelled_Class : TTReportNqlObject 
        {
            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public string Ressectionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESSECTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public String Currentstatename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTSTATENAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
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

            public DateTime? ClosingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOSINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["CLOSINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public SubEpisodeStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (SubEpisodeStatusEnum?)(int)dataType.ConvertValue(val);
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

            public GetSubEpisodeExceptCancelled_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubEpisodeExceptCancelled_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubEpisodeExceptCancelled_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_HASTA_BASVURU_Class : TTReportNqlObject 
        {
            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Bagli_oldugu_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BAGLI_OLDUGU_BASVURU_KODU"]);
                }
            }

            public Guid? Hasta_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_KODU"]);
                }
            }

            public long? Defter_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFTER_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Gunluk_sira_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNLUK_SIRA_NUMARASI"]);
                }
            }

            public Object Hizmet_sunucu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HIZMET_SUNUCU"]);
                }
            }

            public Object Kayit_yeri
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KAYIT_YERI"]);
                }
            }

            public Object Kurum_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KURUM_KODU"]);
                }
            }

            public Object Tamamlayici_kurum_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TAMAMLAYICI_KURUM_KODU"]);
                }
            }

            public Object Online_protokol_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ONLINE_PROTOKOL_NUMARASI"]);
                }
            }

            public long? Protokol_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOKOL_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Kayit_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KAYIT_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Kabul_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABUL_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Kabul_sekli
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KABUL_SEKLI"]);
                }
            }

            public Object Sosyal_guvence_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SOSYAL_GUVENCE_DURUMU"]);
                }
            }

            public Guid? Hekim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEKIM_KODU"]);
                }
            }

            public Guid? Vaka_turu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["VAKA_TURU"]);
                }
            }

            public Object Sevk_gelis_tanisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SEVK_GELIS_TANISI"]);
                }
            }

            public Object Sevk_zamani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SEVK_ZAMANI"]);
                }
            }

            public Object Adli_vaka_gelis_sekli
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADLI_VAKA_GELIS_SEKLI"]);
                }
            }

            public Object Ambulansla_gelis_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMBULANSLA_GELIS_DURUMU"]);
                }
            }

            public Object Triaj_bilgisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TRIAJ_BILGISI"]);
                }
            }

            public string Sys_takip_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SYS_TAKIP_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["SYSTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Yatis_bilgisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YATIS_BILGISI"]);
                }
            }

            public Object Yatis_protokol_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YATIS_PROTOKOL_NUMARASI"]);
                }
            }

            public Object Basvuru_durum
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BASVURU_DURUM"]);
                }
            }

            public Object Klinik_birim_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KLINIK_BIRIM_KODU"]);
                }
            }

            public DateTime? Muayene_baslama_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENE_BASLAMA_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Muayene_bitis_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENE_BITIS_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Muayene_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MUAYENE_TURU"]);
                }
            }

            public Object Tedavi_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TEDAVI_TURU"]);
                }
            }

            public DateTime? Cikis_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CIKIS_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Cikis_sekli
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CIKIS_SEKLI"]);
                }
            }

            public Object Saglik_turizmi_ulke_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAGLIK_TURIZMI_ULKE_KODU"]);
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

            public VEM_HASTA_BASVURU_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_HASTA_BASVURU_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_HASTA_BASVURU_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForSubEpisodeByEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Specialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetOldInfoForSubEpisodeByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForSubEpisodeByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForSubEpisodeByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSubEpisodesForPatientFolder_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public SubEpisodeStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (SubEpisodeStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public InpatientStatusEnum? InpatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["INPATIENTSTATUS"].DataType;
                    return (InpatientStatusEnum?)(int)dataType.ConvertValue(val);
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

            public string Specialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClosingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOSINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["CLOSINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public GetSubEpisodesForPatientFolder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubEpisodesForPatientFolder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubEpisodesForPatientFolder_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_GunubirlikSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_GunubirlikSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_GunubirlikSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_GunubirlikSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_BasvuruSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_BasvuruSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_BasvuruSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_BasvuruSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_YatisSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_YatisSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_YatisSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_YatisSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_AyaktanSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_AyaktanSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_AyaktanSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_AyaktanSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientByProtocolNo_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetPatientByProtocolNo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientByProtocolNo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientByProtocolNo_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_TaniveHizmetBazliYatanHastaSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_TaniveHizmetBazliYatanHastaSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_TaniveHizmetBazliYatanHastaSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_TaniveHizmetBazliYatanHastaSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_TanilarVeHizmetlerBazliHastaSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_TanilarVeHizmetlerBazliHastaSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_TanilarVeHizmetlerBazliHastaSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_TanilarVeHizmetlerBazliHastaSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_TanisiVeIslemiOlanAltVakaSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_TanisiVeIslemiOlanAltVakaSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_TanisiVeIslemiOlanAltVakaSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_TanisiVeIslemiOlanAltVakaSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_TaniBazliBasvuruSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_TaniBazliBasvuruSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_TaniBazliBasvuruSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_TaniBazliBasvuruSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_TanisiOlanAltVakaSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_TanisiOlanAltVakaSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_TanisiOlanAltVakaSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_TanisiOlanAltVakaSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSubepisodesForENabiz_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Ressectionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESSECTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public SubEpisodeStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (SubEpisodeStatusEnum?)(int)dataType.ConvertValue(val);
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

            public string SYSTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SYSTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["SYSTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSubepisodesForENabiz_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubepisodesForENabiz_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubepisodesForENabiz_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSubepisodeByProtocolNoForPatientFolder_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public SubEpisodeStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (SubEpisodeStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public InpatientStatusEnum? InpatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["INPATIENTSTATUS"].DataType;
                    return (InpatientStatusEnum?)(int)dataType.ConvertValue(val);
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

            public string Specialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClosingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOSINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["CLOSINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public GetSubepisodeByProtocolNoForPatientFolder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubepisodeByProtocolNoForPatientFolder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubepisodeByProtocolNoForPatientFolder_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientsIDByNullSys_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string KPSPassword
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KPSPASSWORD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["KPSPASSWORD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KPSUserName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KPSUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["KPSUSERNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetPatientsIDByNullSys_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientsIDByNullSys_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientsIDByNullSys_Class() : base() { }
        }

        public static class States
        {
            public static Guid Opened { get { return new Guid("5a59efb0-668a-4bd4-abb2-6c94e95e470f"); } }
    /// <summary>
    /// Kapalı
    /// </summary>
            public static Guid Closed { get { return new Guid("822d32d5-ce95-415c-ae45-2767343deed6"); } }
    /// <summary>
    /// DİKKAT:Özellikle Statusu Cancelled yapılmadı
    /// </summary>
            public static Guid Cancelled { get { return new Guid("8c1e068a-982a-4c82-bd01-4628e7221f7b"); } }
        }

        public static BindingList<SubEpisode.GetNotDiagnosisExistsByPatientGroup_Class> GetNotDiagnosisExistsByPatientGroup(DateTime STARTDATE, DateTime ENDDATE, int RESOURCEFLAG, IList<string> RESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetNotDiagnosisExistsByPatientGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("RESOURCE", RESOURCE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetNotDiagnosisExistsByPatientGroup_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetNotDiagnosisExistsByPatientGroup_Class> GetNotDiagnosisExistsByPatientGroup(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int RESOURCEFLAG, IList<string> RESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetNotDiagnosisExistsByPatientGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("RESOURCE", RESOURCE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetNotDiagnosisExistsByPatientGroup_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetPatientInformationBySubepisodeid_Class> GetPatientInformationBySubepisodeid(string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetPatientInformationBySubepisodeid"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetPatientInformationBySubepisodeid_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetPatientInformationBySubepisodeid_Class> GetPatientInformationBySubepisodeid(TTObjectContext objectContext, string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetPatientInformationBySubepisodeid"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetPatientInformationBySubepisodeid_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode> GetInpatientAndDischargeByEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetInpatientAndDischargeByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisode>(queryDef, paramList);
        }

        public static BindingList<SubEpisode> GetByEpisodeAndStarterEpisodeAction(TTObjectContext objectContext, string EPISODE, string STARTEREPISODEACTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetByEpisodeAndStarterEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STARTEREPISODEACTION", STARTEREPISODEACTION);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisode>(queryDef, paramList);
        }

        public static BindingList<SubEpisode.GetMaxProtocolNo_Class> GetMaxProtocolNo(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetMaxProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetMaxProtocolNo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetMaxProtocolNo_Class> GetMaxProtocolNo(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetMaxProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetMaxProtocolNo_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Kabul Bazlı Görünüm
    /// </summary>
        public static BindingList<SubEpisode.GetOldInfoForSubEpisode_Class> GetOldInfoForSubEpisode(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetOldInfoForSubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetOldInfoForSubEpisode_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Kabul Bazlı Görünüm
    /// </summary>
        public static BindingList<SubEpisode.GetOldInfoForSubEpisode_Class> GetOldInfoForSubEpisode(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetOldInfoForSubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetOldInfoForSubEpisode_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisode> GetByEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisode>(queryDef, paramList);
        }

        public static BindingList<SubEpisode.GetByDateAndPatientGroupAndDepartment_Class> GetByDateAndPatientGroupAndDepartment(DateTime STARTDATE, DateTime ENDDATE, int PATIENTSTATUS1, int PATIENTSTATUS2, int PATIENTSTATUS3, IList<string> RESOURCE, int RESOURCEFLAG, int PATIENTSTATUS4, int INPATIENTSTATUSFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetByDateAndPatientGroupAndDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTSTATUS1", PATIENTSTATUS1);
            paramList.Add("PATIENTSTATUS2", PATIENTSTATUS2);
            paramList.Add("PATIENTSTATUS3", PATIENTSTATUS3);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("PATIENTSTATUS4", PATIENTSTATUS4);
            paramList.Add("INPATIENTSTATUSFLAG", INPATIENTSTATUSFLAG);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetByDateAndPatientGroupAndDepartment_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetByDateAndPatientGroupAndDepartment_Class> GetByDateAndPatientGroupAndDepartment(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int PATIENTSTATUS1, int PATIENTSTATUS2, int PATIENTSTATUS3, IList<string> RESOURCE, int RESOURCEFLAG, int PATIENTSTATUS4, int INPATIENTSTATUSFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetByDateAndPatientGroupAndDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTSTATUS1", PATIENTSTATUS1);
            paramList.Add("PATIENTSTATUS2", PATIENTSTATUS2);
            paramList.Add("PATIENTSTATUS3", PATIENTSTATUS3);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("PATIENTSTATUS4", PATIENTSTATUS4);
            paramList.Add("INPATIENTSTATUSFLAG", INPATIENTSTATUSFLAG);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetByDateAndPatientGroupAndDepartment_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetSubEpisodeExceptCancelled_Class> GetSubEpisodeExceptCancelled(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetSubEpisodeExceptCancelled"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisode.GetSubEpisodeExceptCancelled_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisode.GetSubEpisodeExceptCancelled_Class> GetSubEpisodeExceptCancelled(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetSubEpisodeExceptCancelled"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisode.GetSubEpisodeExceptCancelled_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisode> GetSpecialityBySubEpisodeFilter(TTObjectContext objectContext, string EPISODE, string OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetSpecialityBySubEpisodeFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisode>(queryDef, paramList);
        }

        public static BindingList<SubEpisode.VEM_HASTA_BASVURU_Class> VEM_HASTA_BASVURU(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["VEM_HASTA_BASVURU"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisode.VEM_HASTA_BASVURU_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.VEM_HASTA_BASVURU_Class> VEM_HASTA_BASVURU(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["VEM_HASTA_BASVURU"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisode.VEM_HASTA_BASVURU_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode> GetByObjectId(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetByObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisode>(queryDef, paramList);
        }

        public static BindingList<SubEpisode.GetOldInfoForSubEpisodeByEpisode_Class> GetOldInfoForSubEpisodeByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetOldInfoForSubEpisodeByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetOldInfoForSubEpisodeByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetOldInfoForSubEpisodeByEpisode_Class> GetOldInfoForSubEpisodeByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetOldInfoForSubEpisodeByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetOldInfoForSubEpisodeByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetSubEpisodesForPatientFolder_Class> GetSubEpisodesForPatientFolder(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetSubEpisodesForPatientFolder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetSubEpisodesForPatientFolder_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetSubEpisodesForPatientFolder_Class> GetSubEpisodesForPatientFolder(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetSubEpisodesForPatientFolder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetSubEpisodesForPatientFolder_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode> GetByPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisode>(queryDef, paramList);
        }

    /// <summary>
    /// Günübirlik sayısı
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_GunubirlikSayisi_Class> GunSonu_GunubirlikSayisi(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_GunubirlikSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_GunubirlikSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Günübirlik sayısı
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_GunubirlikSayisi_Class> GunSonu_GunubirlikSayisi(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_GunubirlikSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_GunubirlikSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta kabulü olan tekil başvuru sayısı
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_BasvuruSayisi_Class> GunSonu_BasvuruSayisi(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_BasvuruSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_BasvuruSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta kabulü olan tekil başvuru sayısı
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_BasvuruSayisi_Class> GunSonu_BasvuruSayisi(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_BasvuruSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_BasvuruSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Yatış Sayısı (Günübirlik hariç Yatışı olan başvuru sayısı)
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_YatisSayisi_Class> GunSonu_YatisSayisi(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_YatisSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_YatisSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Yatış Sayısı (Günübirlik hariç Yatışı olan başvuru sayısı)
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_YatisSayisi_Class> GunSonu_YatisSayisi(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_YatisSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_YatisSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ayaktan Hasta Sayısı (Yatış kabul zamanı boş olan tekil başvuru sayısı)
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_AyaktanSayisi_Class> GunSonu_AyaktanSayisi(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_AyaktanSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_AyaktanSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Ayaktan Hasta Sayısı (Yatış kabul zamanı boş olan tekil başvuru sayısı)
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_AyaktanSayisi_Class> GunSonu_AyaktanSayisi(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_AyaktanSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_AyaktanSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetPatientByProtocolNo_Class> GetPatientByProtocolNo(string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetPatientByProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetPatientByProtocolNo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetPatientByProtocolNo_Class> GetPatientByProtocolNo(TTObjectContext objectContext, string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetPatientByProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetPatientByProtocolNo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode> GetByProtocolNo(TTObjectContext objectContext, string PROTOCOLNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetByProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROTOCOLNO", PROTOCOLNO);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisode>(queryDef, paramList);
        }

    /// <summary>
    /// Gün Sonu 33 -Koroner kalp hastalığı tanısı ve anjiyografi işlemi olan/Gün Sonu 64 Kolorektal kanser tanısı ile operasyon geçiren/Gün Sonu 65 -Rektum kanser tanısı alan küretif rezeksiyon geçirenı/Gün Sonu 73- KKH tanısı konulmuş koroner anjiyografi yapılan/Gun Sonu 76 -By-pass olmuş Koroner kalp hastalığı tanısı almış 
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi_Class> GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi(IList<string> DIAGNOSECODELIST, IList<string> PROCEDURESUTKODULIST, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("PROCEDURESUTKODULIST", PROCEDURESUTKODULIST);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 33 -Koroner kalp hastalığı tanısı ve anjiyografi işlemi olan/Gün Sonu 64 Kolorektal kanser tanısı ile operasyon geçiren/Gün Sonu 65 -Rektum kanser tanısı alan küretif rezeksiyon geçirenı/Gün Sonu 73- KKH tanısı konulmuş koroner anjiyografi yapılan/Gun Sonu 76 -By-pass olmuş Koroner kalp hastalığı tanısı almış 
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi_Class> GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi(TTObjectContext objectContext, IList<string> DIAGNOSECODELIST, IList<string> PROCEDURESUTKODULIST, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("PROCEDURESUTKODULIST", PROCEDURESUTKODULIST);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 60-İskemik inme tanısı ile XXXXXXye yatırılarak intraarteriel girişimsel trombolitik tedavi veya trombektomi tedavi uygulanan 18 yaş üstü toplam hasta sayısı   
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi_Class> GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi(IList<string> DIAGNOSECODELIST, IList<string> PROCEDURESUTKODULIST, int MINAGE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("PROCEDURESUTKODULIST", PROCEDURESUTKODULIST);
            paramList.Add("MINAGE", MINAGE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 60-İskemik inme tanısı ile XXXXXXye yatırılarak intraarteriel girişimsel trombolitik tedavi veya trombektomi tedavi uygulanan 18 yaş üstü toplam hasta sayısı   
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi_Class> GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi(TTObjectContext objectContext, IList<string> DIAGNOSECODELIST, IList<string> PROCEDURESUTKODULIST, int MINAGE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("PROCEDURESUTKODULIST", PROCEDURESUTKODULIST);
            paramList.Add("MINAGE", MINAGE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 61-İskemik inme tanısı ile taburcu olan veya trombektomi tedavi uygulanan 18 yaş üstü toplam tekil hasta sayısı  
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi_Class> GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi(IList<string> DIAGNOSECODELIST, int MINAGE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("MINAGE", MINAGE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 61-İskemik inme tanısı ile taburcu olan veya trombektomi tedavi uygulanan 18 yaş üstü toplam tekil hasta sayısı  
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi_Class> GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi(TTObjectContext objectContext, IList<string> DIAGNOSECODELIST, int MINAGE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("MINAGE", MINAGE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 62 -İnme tanısı alan 18 yaş üstü toplam yatış yapılan hasta /Gün Sonu 58 -İskemik inme tanısı ile XXXXXXye yatırılan başvuru sayısı (18 yaş ve üstü) 
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi_Class> GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi(IList<string> DIAGNOSECODELIST, int MINAGE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("MINAGE", MINAGE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 62 -İnme tanısı alan 18 yaş üstü toplam yatış yapılan hasta /Gün Sonu 58 -İskemik inme tanısı ile XXXXXXye yatırılan başvuru sayısı (18 yaş ve üstü) 
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi_Class> GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi(TTObjectContext objectContext, IList<string> DIAGNOSECODELIST, int MINAGE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("MINAGE", MINAGE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// GunSonu56 İnme tanılı (18 yaş ve üstü ) başvuru sayısı /Gun Sonu 57-Geçici iskemik atak tanısı olan tekil sayısı (18 yaş ve üstü) 
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi_Class> GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi(IList<string> DIAGNOSECODELIST, int MINAGE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("MINAGE", MINAGE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// GunSonu56 İnme tanılı (18 yaş ve üstü ) başvuru sayısı /Gun Sonu 57-Geçici iskemik atak tanısı olan tekil sayısı (18 yaş ve üstü) 
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi_Class> GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi(TTObjectContext objectContext, IList<string> DIAGNOSECODELIST, int MINAGE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("MINAGE", MINAGE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 66 - Üriner Sistem Şikayeti ile Gelen 50 ile 80 Yaş Arası Top. Erkek Hast. Say.
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi_Class> GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi(IList<string> DIAGNOSECODELIST, int SKRSCINSIYETKODU, int MINAGE, int MAXAGE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("SKRSCINSIYETKODU", SKRSCINSIYETKODU);
            paramList.Add("MINAGE", MINAGE);
            paramList.Add("MAXAGE", MAXAGE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 66 - Üriner Sistem Şikayeti ile Gelen 50 ile 80 Yaş Arası Top. Erkek Hast. Say.
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi_Class> GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi(TTObjectContext objectContext, IList<string> DIAGNOSECODELIST, int SKRSCINSIYETKODU, int MINAGE, int MAXAGE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("SKRSCINSIYETKODU", SKRSCINSIYETKODU);
            paramList.Add("MINAGE", MINAGE);
            paramList.Add("MAXAGE", MAXAGE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 59-Trombolitik tedavi alan tüm iskemik inme tanısı ile XXXXXXye yatırılan sys
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniveHizmetBazliYatanHastaSayisi_Class> GunSonu_TaniveHizmetBazliYatanHastaSayisi(IList<string> DIAGNOSECODELIST, IList<string> PROCEDURESUTKODULIST, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniveHizmetBazliYatanHastaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("PROCEDURESUTKODULIST", PROCEDURESUTKODULIST);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniveHizmetBazliYatanHastaSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 59-Trombolitik tedavi alan tüm iskemik inme tanısı ile XXXXXXye yatırılan sys
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniveHizmetBazliYatanHastaSayisi_Class> GunSonu_TaniveHizmetBazliYatanHastaSayisi(TTObjectContext objectContext, IList<string> DIAGNOSECODELIST, IList<string> PROCEDURESUTKODULIST, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniveHizmetBazliYatanHastaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("PROCEDURESUTKODULIST", PROCEDURESUTKODULIST);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniveHizmetBazliYatanHastaSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 69- Prostat kanseri tanısı ile radyoterapi alan toplam tekil hasta sayıs
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TanilarVeHizmetlerBazliHastaSayisi_Class> GunSonu_TanilarVeHizmetlerBazliHastaSayisi(IList<string> DIAGNOSECODELIST, IList<string> PROCEDURESUTKODULIST, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TanilarVeHizmetlerBazliHastaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("PROCEDURESUTKODULIST", PROCEDURESUTKODULIST);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TanilarVeHizmetlerBazliHastaSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 69- Prostat kanseri tanısı ile radyoterapi alan toplam tekil hasta sayıs
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TanilarVeHizmetlerBazliHastaSayisi_Class> GunSonu_TanilarVeHizmetlerBazliHastaSayisi(TTObjectContext objectContext, IList<string> DIAGNOSECODELIST, IList<string> PROCEDURESUTKODULIST, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TanilarVeHizmetlerBazliHastaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODELIST", DIAGNOSECODELIST);
            paramList.Add("PROCEDURESUTKODULIST", PROCEDURESUTKODULIST);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TanilarVeHizmetlerBazliHastaSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 17 - Hasta kabulü, tanısı, işlem bilgisi olan başvuru sayısı
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TanisiVeIslemiOlanAltVakaSayisi_Class> GunSonu_TanisiVeIslemiOlanAltVakaSayisi(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TanisiVeIslemiOlanAltVakaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TanisiVeIslemiOlanAltVakaSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 17 - Hasta kabulü, tanısı, işlem bilgisi olan başvuru sayısı
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TanisiVeIslemiOlanAltVakaSayisi_Class> GunSonu_TanisiVeIslemiOlanAltVakaSayisi(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TanisiVeIslemiOlanAltVakaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TanisiVeIslemiOlanAltVakaSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Gun Sonu 22-Diyabet tanısı olan başvuru sayısı/
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniBazliBasvuruSayisi_Class> GunSonu_TaniBazliBasvuruSayisi(IList<string> DIAGNOSECODE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniBazliBasvuruSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODE", DIAGNOSECODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniBazliBasvuruSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Gun Sonu 22-Diyabet tanısı olan başvuru sayısı/
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TaniBazliBasvuruSayisi_Class> GunSonu_TaniBazliBasvuruSayisi(TTObjectContext objectContext, IList<string> DIAGNOSECODE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TaniBazliBasvuruSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSECODE", DIAGNOSECODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TaniBazliBasvuruSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 16 - Tanı bilgisi olan başvuru sayısı
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TanisiOlanAltVakaSayisi_Class> GunSonu_TanisiOlanAltVakaSayisi(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TanisiOlanAltVakaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TanisiOlanAltVakaSayisi_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Gün Sonu 16 - Tanı bilgisi olan başvuru sayısı
    /// </summary>
        public static BindingList<SubEpisode.GunSonu_TanisiOlanAltVakaSayisi_Class> GunSonu_TanisiOlanAltVakaSayisi(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GunSonu_TanisiOlanAltVakaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisode.GunSonu_TanisiOlanAltVakaSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetSubepisodesForENabiz_Class> GetSubepisodesForENabiz(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetSubepisodesForENabiz"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisode.GetSubepisodesForENabiz_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisode.GetSubepisodesForENabiz_Class> GetSubepisodesForENabiz(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetSubepisodesForENabiz"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisode.GetSubepisodesForENabiz_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisode.GetSubepisodeByProtocolNoForPatientFolder_Class> GetSubepisodeByProtocolNoForPatientFolder(string PROTOCOLNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetSubepisodeByProtocolNoForPatientFolder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROTOCOLNO", PROTOCOLNO);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetSubepisodeByProtocolNoForPatientFolder_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode.GetSubepisodeByProtocolNoForPatientFolder_Class> GetSubepisodeByProtocolNoForPatientFolder(TTObjectContext objectContext, string PROTOCOLNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetSubepisodeByProtocolNoForPatientFolder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROTOCOLNO", PROTOCOLNO);

            return TTReportNqlObject.QueryObjects<SubEpisode.GetSubepisodeByProtocolNoForPatientFolder_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisode> GetInpatientSubEpisodeByPatient(TTObjectContext objectContext, string UNIQUEREFNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetInpatientSubEpisodeByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisode>(queryDef, paramList);
        }

        public static BindingList<SubEpisode> GetByProtocolNoForInpatient(TTObjectContext objectContext, string PROTOCOLNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetByProtocolNoForInpatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROTOCOLNO", PROTOCOLNO);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisode>(queryDef, paramList);
        }

        public static BindingList<SubEpisode.GetPatientsIDByNullSys_Class> GetPatientsIDByNullSys(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetPatientsIDByNullSys"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisode.GetPatientsIDByNullSys_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisode.GetPatientsIDByNullSys_Class> GetPatientsIDByNullSys(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].QueryDefs["GetPatientsIDByNullSys"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisode.GetPatientsIDByNullSys_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kapanış Tarihi
    /// </summary>
        public DateTime? ClosingDate
        {
            get { return (DateTime?)this["CLOSINGDATE"]; }
            set { this["CLOSINGDATE"] = value; }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public SubEpisodeStatusEnum? PatientStatus
        {
            get { return (SubEpisodeStatusEnum?)(int?)this["PATIENTSTATUS"]; }
            set { this["PATIENTSTATUS"] = value; }
        }

        public string ProtocolNo
        {
            get { return (string)this["PROTOCOLNO"]; }
            set { this["PROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Açılış Tarihi
    /// </summary>
        public DateTime? OpeningDate
        {
            get { return (DateTime?)this["OPENINGDATE"]; }
            set { this["OPENINGDATE"] = value; }
        }

    /// <summary>
    /// Enabız sitemine 101 paketi gönderdiğimizde bize gönderdiği değer
    /// </summary>
        public string SYSTakipNo
        {
            get { return (string)this["SYSTAKIPNO"]; }
            set { this["SYSTAKIPNO"] = value; }
        }

    /// <summary>
    /// Online Protokol No
    /// </summary>
        public string OnlineProtokolNo
        {
            get { return (string)this["ONLINEPROTOKOLNO"]; }
            set { this["ONLINEPROTOKOLNO"] = value; }
        }

    /// <summary>
    /// Çıkış Zamanı
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Yatan statüsü
    /// </summary>
        public InpatientStatusEnum? InpatientStatus
        {
            get { return (InpatientStatusEnum?)(int?)this["INPATIENTSTATUS"]; }
            set { this["INPATIENTSTATUS"] = value; }
        }

    /// <summary>
    /// nabız 101 paketine eklenecek mi
    /// </summary>
        public bool? Sent101Package
        {
            get { return (bool?)this["SENT101PACKAGE"]; }
            set { this["SENT101PACKAGE"] = value; }
        }

    /// <summary>
    /// hasta geçmiş sağlık verisi görüntüleme
    /// </summary>
        public bool? IsPatientHistoryShown
        {
            get { return (bool?)this["ISPATIENTHISTORYSHOWN"]; }
            set { this["ISPATIENTHISTORYSHOWN"] = value; }
        }

        public InpatientAdmission InpatientAdmission
        {
            get { return (InpatientAdmission)((ITTObject)this).GetParent("INPATIENTADMISSION"); }
            set { this["INPATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode OldSubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("OLDSUBEPISODE"); }
            set { this["OLDSUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// ResSection
    /// </summary>
        public ResSection ResSection
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESSECTION"); }
            set { this["RESSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Episode
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction StarterEpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("STARTEREPISODEACTION"); }
            set { this["STARTEREPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubActionProcedure StarterSubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("STARTERSUBACTIONPROCEDURE"); }
            set { this["STARTERSUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientAdmission PatientAdmission
        {
            get { return (PatientAdmission)((ITTObject)this).GetParent("PATIENTADMISSION"); }
            set { this["PATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProtocolAddingSubEpisodesCollection()
        {
            _ProtocolAddingSubEpisodes = new ProtocolAddingSubEpisode.ChildProtocolAddingSubEpisodeCollection(this, new Guid("92c06de3-cfef-4e7d-be14-a04f842a4bab"));
            ((ITTChildObjectCollection)_ProtocolAddingSubEpisodes).GetChildren();
        }

        protected ProtocolAddingSubEpisode.ChildProtocolAddingSubEpisodeCollection _ProtocolAddingSubEpisodes = null;
        public ProtocolAddingSubEpisode.ChildProtocolAddingSubEpisodeCollection ProtocolAddingSubEpisodes
        {
            get
            {
                if (_ProtocolAddingSubEpisodes == null)
                    CreateProtocolAddingSubEpisodesCollection();
                return _ProtocolAddingSubEpisodes;
            }
        }

        virtual protected void CreateEpisodeActionsCollectionViews()
        {
            _Surgeries = new Surgery.ChildSurgeryCollection(_EpisodeActions, "Surgeries");
            _InPatientTreatmentClinicApplications = new InPatientTreatmentClinicApplication.ChildInPatientTreatmentClinicApplicationCollection(_EpisodeActions, "InPatientTreatmentClinicApplications");
            _OutPatientPrescriptions = new OutPatientPrescription.ChildOutPatientPrescriptionCollection(_EpisodeActions, "OutPatientPrescriptions");
            _NursingApplications = new NursingApplication.ChildNursingApplicationCollection(_EpisodeActions, "NursingApplications");
            _InPatientPhysicianApplications = new InPatientPhysicianApplication.ChildInPatientPhysicianApplicationCollection(_EpisodeActions, "InPatientPhysicianApplications");
            _PatientExaminations = new PatientExamination.ChildPatientExaminationCollection(_EpisodeActions, "PatientExaminations");
            _DentalExaminations = new DentalExamination.ChildDentalExaminationCollection(_EpisodeActions, "DentalExaminations");
            _TreatmentDischarges = new TreatmentDischarge.ChildTreatmentDischargeCollection(_EpisodeActions, "TreatmentDischarges");
        }

        virtual protected void CreateEpisodeActionsCollection()
        {
            _EpisodeActions = new EpisodeAction.ChildEpisodeActionCollection(this, new Guid("fd7492c2-d2d2-4918-bcbb-87f3174e9f89"));
            CreateEpisodeActionsCollectionViews();
            ((ITTChildObjectCollection)_EpisodeActions).GetChildren();
        }

        protected EpisodeAction.ChildEpisodeActionCollection _EpisodeActions = null;
        public EpisodeAction.ChildEpisodeActionCollection EpisodeActions
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _EpisodeActions;
            }
        }

        private Surgery.ChildSurgeryCollection _Surgeries = null;
        public Surgery.ChildSurgeryCollection Surgeries
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _Surgeries;
            }            
        }

        private InPatientTreatmentClinicApplication.ChildInPatientTreatmentClinicApplicationCollection _InPatientTreatmentClinicApplications = null;
        public InPatientTreatmentClinicApplication.ChildInPatientTreatmentClinicApplicationCollection InPatientTreatmentClinicApplications
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _InPatientTreatmentClinicApplications;
            }            
        }

        private OutPatientPrescription.ChildOutPatientPrescriptionCollection _OutPatientPrescriptions = null;
        public OutPatientPrescription.ChildOutPatientPrescriptionCollection OutPatientPrescriptions
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _OutPatientPrescriptions;
            }            
        }

        private NursingApplication.ChildNursingApplicationCollection _NursingApplications = null;
        public NursingApplication.ChildNursingApplicationCollection NursingApplications
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _NursingApplications;
            }            
        }

        private InPatientPhysicianApplication.ChildInPatientPhysicianApplicationCollection _InPatientPhysicianApplications = null;
        public InPatientPhysicianApplication.ChildInPatientPhysicianApplicationCollection InPatientPhysicianApplications
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _InPatientPhysicianApplications;
            }            
        }

        private PatientExamination.ChildPatientExaminationCollection _PatientExaminations = null;
        public PatientExamination.ChildPatientExaminationCollection PatientExaminations
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _PatientExaminations;
            }            
        }

        private DentalExamination.ChildDentalExaminationCollection _DentalExaminations = null;
        public DentalExamination.ChildDentalExaminationCollection DentalExaminations
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _DentalExaminations;
            }            
        }

        private TreatmentDischarge.ChildTreatmentDischargeCollection _TreatmentDischarges = null;
        public TreatmentDischarge.ChildTreatmentDischargeCollection TreatmentDischarges
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _TreatmentDischarges;
            }            
        }

        virtual protected void CreateSubActionProceduresCollection()
        {
            _SubActionProcedures = new SubActionProcedure.ChildSubActionProcedureCollection(this, new Guid("93bf265f-e43a-4b4b-8536-2eafa04fb0ce"));
            ((ITTChildObjectCollection)_SubActionProcedures).GetChildren();
        }

        protected SubActionProcedure.ChildSubActionProcedureCollection _SubActionProcedures = null;
        public SubActionProcedure.ChildSubActionProcedureCollection SubActionProcedures
        {
            get
            {
                if (_SubActionProcedures == null)
                    CreateSubActionProceduresCollection();
                return _SubActionProcedures;
            }
        }

        virtual protected void CreateAccountingProcessProceduresCollection()
        {
            _AccountingProcessProcedures = new AccountingProcessProcedure.ChildAccountingProcessProcedureCollection(this, new Guid("7fc6ffa1-5611-463f-9dfe-a7bb024e3860"));
            ((ITTChildObjectCollection)_AccountingProcessProcedures).GetChildren();
        }

        protected AccountingProcessProcedure.ChildAccountingProcessProcedureCollection _AccountingProcessProcedures = null;
        public AccountingProcessProcedure.ChildAccountingProcessProcedureCollection AccountingProcessProcedures
        {
            get
            {
                if (_AccountingProcessProcedures == null)
                    CreateAccountingProcessProceduresCollection();
                return _AccountingProcessProcedures;
            }
        }

        virtual protected void CreateAccountingProcessPackagesCollection()
        {
            _AccountingProcessPackages = new AccountingProcessPackage.ChildAccountingProcessPackageCollection(this, new Guid("de5374c6-e358-46ff-a5b6-7f19c77311d9"));
            ((ITTChildObjectCollection)_AccountingProcessPackages).GetChildren();
        }

        protected AccountingProcessPackage.ChildAccountingProcessPackageCollection _AccountingProcessPackages = null;
        public AccountingProcessPackage.ChildAccountingProcessPackageCollection AccountingProcessPackages
        {
            get
            {
                if (_AccountingProcessPackages == null)
                    CreateAccountingProcessPackagesCollection();
                return _AccountingProcessPackages;
            }
        }

        virtual protected void CreateAccountingProcessMaterialsCollection()
        {
            _AccountingProcessMaterials = new AccountingProcessMaterial.ChildAccountingProcessMaterialCollection(this, new Guid("f2afb4e8-803d-4560-be94-25ba2a3ff2b7"));
            ((ITTChildObjectCollection)_AccountingProcessMaterials).GetChildren();
        }

        protected AccountingProcessMaterial.ChildAccountingProcessMaterialCollection _AccountingProcessMaterials = null;
        public AccountingProcessMaterial.ChildAccountingProcessMaterialCollection AccountingProcessMaterials
        {
            get
            {
                if (_AccountingProcessMaterials == null)
                    CreateAccountingProcessMaterialsCollection();
                return _AccountingProcessMaterials;
            }
        }

        virtual protected void CreateCollectedPatientListCollection()
        {
            _CollectedPatientList = new CollectedPatientList.ChildCollectedPatientListCollection(this, new Guid("ba40d06f-e7dc-463b-a8d8-f58943d1942f"));
            ((ITTChildObjectCollection)_CollectedPatientList).GetChildren();
        }

        protected CollectedPatientList.ChildCollectedPatientListCollection _CollectedPatientList = null;
    /// <summary>
    /// Child collection for Alt Vaka ile ilişki
    /// </summary>
        public CollectedPatientList.ChildCollectedPatientListCollection CollectedPatientList
        {
            get
            {
                if (_CollectedPatientList == null)
                    CreateCollectedPatientListCollection();
                return _CollectedPatientList;
            }
        }

        virtual protected void CreatePayerInvoiceCollection()
        {
            _PayerInvoice = new PayerInvoice.ChildPayerInvoiceCollection(this, new Guid("0c3db48c-8e26-4746-9d59-782b2037e139"));
            ((ITTChildObjectCollection)_PayerInvoice).GetChildren();
        }

        protected PayerInvoice.ChildPayerInvoiceCollection _PayerInvoice = null;
    /// <summary>
    /// Child collection for Alt Epizot la ilişki
    /// </summary>
        public PayerInvoice.ChildPayerInvoiceCollection PayerInvoice
        {
            get
            {
                if (_PayerInvoice == null)
                    CreatePayerInvoiceCollection();
                return _PayerInvoice;
            }
        }

        virtual protected void CreateAccountingProcessActionsCollection()
        {
            _AccountingProcessActions = new AccountingProcessAction.ChildAccountingProcessActionCollection(this, new Guid("01dc8551-d436-4b32-ba60-f611b408348b"));
            ((ITTChildObjectCollection)_AccountingProcessActions).GetChildren();
        }

        protected AccountingProcessAction.ChildAccountingProcessActionCollection _AccountingProcessActions = null;
        public AccountingProcessAction.ChildAccountingProcessActionCollection AccountingProcessActions
        {
            get
            {
                if (_AccountingProcessActions == null)
                    CreateAccountingProcessActionsCollection();
                return _AccountingProcessActions;
            }
        }

        virtual protected void CreateAccountingProcessCollection()
        {
            _AccountingProcess = new AccountingProcess.ChildAccountingProcessCollection(this, new Guid("9ae72263-a5b9-4299-9090-04095706e35e"));
            ((ITTChildObjectCollection)_AccountingProcess).GetChildren();
        }

        protected AccountingProcess.ChildAccountingProcessCollection _AccountingProcess = null;
        public AccountingProcess.ChildAccountingProcessCollection AccountingProcess
        {
            get
            {
                if (_AccountingProcess == null)
                    CreateAccountingProcessCollection();
                return _AccountingProcess;
            }
        }

        virtual protected void CreateReadyToCollectedInvoiceDetailsCollection()
        {
            _ReadyToCollectedInvoiceDetails = new ReadyToCollectedInvoiceDetail.ChildReadyToCollectedInvoiceDetailCollection(this, new Guid("9ebff5bf-4bfc-46d6-9aca-857785d492a3"));
            ((ITTChildObjectCollection)_ReadyToCollectedInvoiceDetails).GetChildren();
        }

        protected ReadyToCollectedInvoiceDetail.ChildReadyToCollectedInvoiceDetailCollection _ReadyToCollectedInvoiceDetails = null;
        public ReadyToCollectedInvoiceDetail.ChildReadyToCollectedInvoiceDetailCollection ReadyToCollectedInvoiceDetails
        {
            get
            {
                if (_ReadyToCollectedInvoiceDetails == null)
                    CreateReadyToCollectedInvoiceDetailsCollection();
                return _ReadyToCollectedInvoiceDetails;
            }
        }

        virtual protected void CreateSubActionMaterialsCollection()
        {
            _SubActionMaterials = new SubActionMaterial.ChildSubActionMaterialCollection(this, new Guid("f5b0691f-8b26-45bd-b5ea-454049b04fdf"));
            ((ITTChildObjectCollection)_SubActionMaterials).GetChildren();
        }

        protected SubActionMaterial.ChildSubActionMaterialCollection _SubActionMaterials = null;
        public SubActionMaterial.ChildSubActionMaterialCollection SubActionMaterials
        {
            get
            {
                if (_SubActionMaterials == null)
                    CreateSubActionMaterialsCollection();
                return _SubActionMaterials;
            }
        }

        virtual protected void CreateInPatientRtfBySpecialitiesCollection()
        {
            _InPatientRtfBySpecialities = new InPatientRtfBySpeciality.ChildInPatientRtfBySpecialityCollection(this, new Guid("35330b1d-fe5f-4a54-854e-3d987f4ea98f"));
            ((ITTChildObjectCollection)_InPatientRtfBySpecialities).GetChildren();
        }

        protected InPatientRtfBySpeciality.ChildInPatientRtfBySpecialityCollection _InPatientRtfBySpecialities = null;
        public InPatientRtfBySpeciality.ChildInPatientRtfBySpecialityCollection InPatientRtfBySpecialities
        {
            get
            {
                if (_InPatientRtfBySpecialities == null)
                    CreateInPatientRtfBySpecialitiesCollection();
                return _InPatientRtfBySpecialities;
            }
        }

        virtual protected void CreateSubEpisodeProtocolsCollection()
        {
            _SubEpisodeProtocols = new SubEpisodeProtocol.ChildSubEpisodeProtocolCollection(this, new Guid("7cdf4443-4321-4175-b0c1-b6abe9b23204"));
            ((ITTChildObjectCollection)_SubEpisodeProtocols).GetChildren();
        }

        protected SubEpisodeProtocol.ChildSubEpisodeProtocolCollection _SubEpisodeProtocols = null;
        public SubEpisodeProtocol.ChildSubEpisodeProtocolCollection SubEpisodeProtocols
        {
            get
            {
                if (_SubEpisodeProtocols == null)
                    CreateSubEpisodeProtocolsCollection();
                return _SubEpisodeProtocols;
            }
        }

        virtual protected void CreateInPatientPhysicianProgressesCollection()
        {
            _InPatientPhysicianProgresses = new InPatientPhysicianProgresses.ChildInPatientPhysicianProgressesCollection(this, new Guid("b1b904d9-ddbc-46bc-9827-ad24e0e7c69b"));
            ((ITTChildObjectCollection)_InPatientPhysicianProgresses).GetChildren();
        }

        protected InPatientPhysicianProgresses.ChildInPatientPhysicianProgressesCollection _InPatientPhysicianProgresses = null;
        public InPatientPhysicianProgresses.ChildInPatientPhysicianProgressesCollection InPatientPhysicianProgresses
        {
            get
            {
                if (_InPatientPhysicianProgresses == null)
                    CreateInPatientPhysicianProgressesCollection();
                return _InPatientPhysicianProgresses;
            }
        }

        virtual protected void CreateENabizCollection()
        {
            _ENabiz = new ENabiz.ChildENabizCollection(this, new Guid("bad0a951-b3a0-4d69-8a90-5648614a2494"));
            ((ITTChildObjectCollection)_ENabiz).GetChildren();
        }

        protected ENabiz.ChildENabizCollection _ENabiz = null;
        public ENabiz.ChildENabizCollection ENabiz
        {
            get
            {
                if (_ENabiz == null)
                    CreateENabizCollection();
                return _ENabiz;
            }
        }

        virtual protected void CreateDiagnosisSubEpisodesCollection()
        {
            _DiagnosisSubEpisodes = new DiagnosisSubEpisode.ChildDiagnosisSubEpisodeCollection(this, new Guid("e05efea0-0c81-4e90-b444-66af6edb2a22"));
            ((ITTChildObjectCollection)_DiagnosisSubEpisodes).GetChildren();
        }

        protected DiagnosisSubEpisode.ChildDiagnosisSubEpisodeCollection _DiagnosisSubEpisodes = null;
        public DiagnosisSubEpisode.ChildDiagnosisSubEpisodeCollection DiagnosisSubEpisodes
        {
            get
            {
                if (_DiagnosisSubEpisodes == null)
                    CreateDiagnosisSubEpisodesCollection();
                return _DiagnosisSubEpisodes;
            }
        }

        virtual protected void CreateDPDetailsCollection()
        {
            _DPDetails = new DPDetail.ChildDPDetailCollection(this, new Guid("b17c19ee-66ae-4c11-9edf-d2f40fba3202"));
            ((ITTChildObjectCollection)_DPDetails).GetChildren();
        }

        protected DPDetail.ChildDPDetailCollection _DPDetails = null;
        public DPDetail.ChildDPDetailCollection DPDetails
        {
            get
            {
                if (_DPDetails == null)
                    CreateDPDetailsCollection();
                return _DPDetails;
            }
        }

        protected SubEpisode(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubEpisode(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubEpisode(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubEpisode(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubEpisode(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBEPISODE", dataRow) { }
        protected SubEpisode(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBEPISODE", dataRow, isImported) { }
        public SubEpisode(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubEpisode(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubEpisode() : base() { }

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