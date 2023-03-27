
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResUser")] 

    /// <summary>
    /// Kullanıcı
    /// </summary>
    public  partial class ResUser : Resource, ITTUserObject
    {
        public class ResUserList : TTObjectCollection<ResUser> { }
                    
        public class ChildResUserCollection : TTObject.TTChildObjectCollection<ResUser>
        {
            public ChildResUserCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResUserCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetResDoctor_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTypeEnum? UserType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["USERTYPE"].DataType;
                    return (UserTypeEnum?)(int)dataType.ConvertValue(val);
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

            public Guid? Speciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SPECIALITY"]);
                }
            }

            public OLAP_GetResDoctor_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetResDoctor_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetResDoctor_Class() : base() { }
        }

        [Serializable] 

        public partial class ClinicDoctorListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ClinicDoctorListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ClinicDoctorListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ClinicDoctorListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class CashierListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CashierListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CashierListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CashierListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetDoctorCount_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
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

            public OLAP_GetDoctorCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetDoctorCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetDoctorCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUserByID_Class : TTReportNqlObject 
        {
            public Guid? Userid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["USERID"]);
                }
            }

            public string Adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ErecetePassword
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERECETEPASSWORD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["ERECETEPASSWORD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetUserByID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserByID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserByID_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetNurseCount_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public OLAP_GetNurseCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetNurseCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetNurseCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUserInfoNQL_Class : TTReportNqlObject 
        {
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
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

            public GetUserInfoNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserInfoNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserInfoNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetResUser_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public GetResUser_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResUser_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResUser_Class() : base() { }
        }

        [Serializable] 

        public partial class DoctorListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public DoctorListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DoctorListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DoctorListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDoctorAndNurseNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDoctorAndNurseNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDoctorAndNurseNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDoctorAndNurseNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllUserReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAllUserReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllUserReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllUserReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetConsultationUserNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetConsultationUserNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetConsultationUserNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetConsultationUserNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_PERSONEL_Class : TTReportNqlObject 
        {
            public Guid? Personel_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PERSONEL_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public string Ad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Onceki_soyad
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ONCEKI_SOYAD"]);
                }
            }

            public DateTime? Dogum_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUM_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Dogum_yeri
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOGUM_YERI"]);
                }
            }

            public Guid? Cinsiyet
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CINSIYET"]);
                }
            }

            public string Anne_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNE_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["MOTHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Baba_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BABA_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ev_telefonu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EV_TELEFONU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["PHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Cep_telefonu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CEP_TELEFONU"]);
                }
            }

            public Object Eposta_adresi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPOSTA_ADRESI"]);
                }
            }

            public Object Ogrenim_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OGRENIM_DURUMU"]);
                }
            }

            public long? Tc_kimlik_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TC_KIMLIK_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Kan_grubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KAN_GRUBU"]);
                }
            }

            public Guid? Ulke_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ULKE_KODU"]);
                }
            }

            public Object Adres_tipi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADRES_TIPI"]);
                }
            }

            public Object Adres_kodu_seviyesi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADRES_KODU_SEVIYESI"]);
                }
            }

            public Object Acik_adres
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACIK_ADRES"]);
                }
            }

            public Guid? Il_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["IL_KODU"]);
                }
            }

            public Guid? Ilce_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ILCE_KODU"]);
                }
            }

            public string Sicil_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SICIL_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Emekli_sicil_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EMEKLI_SICIL_NUMARASI"]);
                }
            }

            public Object XXXXXXlik_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["XXXXXXLIK_DURUMU"]);
                }
            }

            public Object Klinik_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KLINIK_KODU"]);
                }
            }

            public string Dr_tescil_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DR_TESCIL_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["SPECIALITYREGISTRYNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dr_diploma_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DR_DIPLOMA_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Medula_brans_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULA_BRANS_KODU"]);
                }
            }

            public Object Calisma_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CALISMA_DURUMU"]);
                }
            }

            public UserTitleEnum? Unvan_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNVAN_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public UserTypeEnum? Gorev_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GOREV_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["USERTYPE"].DataType;
                    return (UserTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Calisma_sekli
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CALISMA_SEKLI"]);
                }
            }

            public Object Memuriyet_tipi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEMURIYET_TIPI"]);
                }
            }

            public Object Ise_baslama_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISE_BASLAMA_TARIHI"]);
                }
            }

            public Object Isten_ayrilma_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISTEN_AYRILMA_TARIHI"]);
                }
            }

            public Object Isten_ayrilma_nedeni
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISTEN_AYRILMA_NEDENI"]);
                }
            }

            public Object Memuriyete_baslama_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEMURIYETE_BASLAMA_TARIHI"]);
                }
            }

            public Object Kadro_unvan_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KADRO_UNVAN_KODU"]);
                }
            }

            public Object Imza_unvan_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IMZA_UNVAN_KODU"]);
                }
            }

            public Object Akademik_unvan_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AKADEMIK_UNVAN_KODU"]);
                }
            }

            public Object Calistigi_birim_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CALISTIGI_BIRIM_KODU"]);
                }
            }

            public Object Kadrolu_gorev_yeri
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KADROLU_GOREV_YERI"]);
                }
            }

            public Object Engellilik_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ENGELLILIK_DURUMU"]);
                }
            }

            public Object Devlet_hizmet_yukumluluk_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DEVLET_HIZMET_YUKUMLULUK_KODU"]);
                }
            }

            public Boolean? Aktiflik_bilgisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AKTIFLIK_BILGISI"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Object Fotograf_bilgisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FOTOGRAF_BILGISI"]);
                }
            }

            public Object Fotograf_dosya_yolu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FOTOGRAF_DOSYA_YOLU"]);
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

            public VEM_PERSONEL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_PERSONEL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_PERSONEL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetdoctorsForMHRS_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Doktoradi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTORADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Tc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Uzmanlikdali
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UZMANLIKDALI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mhrsadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKLINIKLER"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mhrskodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKLINIKLER"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetdoctorsForMHRS_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetdoctorsForMHRS_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetdoctorsForMHRS_Class() : base() { }
        }

        [Serializable] 

        public partial class SpecialistDoctorListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SpecialistDoctorListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SpecialistDoctorListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SpecialistDoctorListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTechnicianListNQL_Class : TTReportNqlObject 
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

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Location
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["LOCATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DeskPhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESKPHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DESKPHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string WorkPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORKPLACE"].DataType;
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

            public string LogonName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOGONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["LOGONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateOfPromotion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEOFPROMOTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DATEOFPROMOTION"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string PhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["PHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SpecialityRegistryNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYREGISTRYNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["SPECIALITYREGISTRYNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateOfLeave
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEOFLEAVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DATEOFLEAVE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public UserTypeEnum? UserType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["USERTYPE"].DataType;
                    return (UserTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["STATUS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DiplomaRegisterNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMAREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMAREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateOfJoin
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEOFJOIN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DATEOFJOIN"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ExternalID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EXTERNALID"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public bool? SentToMHRS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENTTOMHRS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["SENTTOMHRS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? StaffOfficer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STAFFOFFICER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["STAFFOFFICER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? UsesESignature
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USESESIGNATURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["USESESIGNATURE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ErecetePassword
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERECETEPASSWORD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["ERECETEPASSWORD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? TakesPerformanceScore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKESPERFORMANCESCORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TAKESPERFORMANCESCORE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MkysUserName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["MKYSUSERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MkysPassword
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSPASSWORD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["MKYSPASSWORD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? PreDischargeLimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDISCHARGELIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["PREDISCHARGELIMIT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string TitleCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string StatusDefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUSDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["STATUSDEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EMail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RecordType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["RECORDTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RecordCompany
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDCOMPANY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["RECORDCOMPANY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RecordCompanyCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDCOMPANYCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["RECORDCOMPANYCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RecordDefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["RECORDDEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IntegrationId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTEGRATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["INTEGRATIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IntegrationVersion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTEGRATIONVERSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["INTEGRATIONVERSION"].DataType;
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

            public DateTime? FirstWorkHealthExamDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTWORKHEALTHEXAMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["FIRSTWORKHEALTHEXAMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SecondWorkHealthExamDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECONDWORKHEALTHEXAMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["SECONDWORKHEALTHEXAMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ThirdWorkHealthExamDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["THIRDWORKHEALTHEXAMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["THIRDWORKHEALTHEXAMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? FourthWorkHealthExamDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOURTHWORKHEALTHEXAMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["FOURTHWORKHEALTHEXAMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsClinician
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCLINICIAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["ISCLINICIAN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetTechnicianListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTechnicianListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTechnicianListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDoctorandTechnicianList_Class : TTReportNqlObject 
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

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Location
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["LOCATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DeskPhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESKPHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DESKPHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string WorkPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORKPLACE"].DataType;
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

            public string LogonName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOGONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["LOGONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateOfPromotion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEOFPROMOTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DATEOFPROMOTION"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string PhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["PHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SpecialityRegistryNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYREGISTRYNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["SPECIALITYREGISTRYNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateOfLeave
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEOFLEAVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DATEOFLEAVE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public UserTypeEnum? UserType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["USERTYPE"].DataType;
                    return (UserTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["STATUS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DiplomaRegisterNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMAREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMAREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateOfJoin
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEOFJOIN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DATEOFJOIN"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ExternalID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EXTERNALID"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public bool? SentToMHRS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENTTOMHRS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["SENTTOMHRS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? StaffOfficer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STAFFOFFICER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["STAFFOFFICER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? UsesESignature
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USESESIGNATURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["USESESIGNATURE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ErecetePassword
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERECETEPASSWORD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["ERECETEPASSWORD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? TakesPerformanceScore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKESPERFORMANCESCORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TAKESPERFORMANCESCORE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MkysUserName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["MKYSUSERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MkysPassword
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSPASSWORD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["MKYSPASSWORD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? PreDischargeLimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDISCHARGELIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["PREDISCHARGELIMIT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string TitleCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string StatusDefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUSDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["STATUSDEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EMail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RecordType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["RECORDTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RecordCompany
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDCOMPANY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["RECORDCOMPANY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RecordCompanyCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDCOMPANYCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["RECORDCOMPANYCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RecordDefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["RECORDDEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IntegrationId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTEGRATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["INTEGRATIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IntegrationVersion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTEGRATIONVERSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["INTEGRATIONVERSION"].DataType;
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

            public DateTime? FirstWorkHealthExamDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTWORKHEALTHEXAMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["FIRSTWORKHEALTHEXAMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SecondWorkHealthExamDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECONDWORKHEALTHEXAMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["SECONDWORKHEALTHEXAMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ThirdWorkHealthExamDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["THIRDWORKHEALTHEXAMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["THIRDWORKHEALTHEXAMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? FourthWorkHealthExamDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOURTHWORKHEALTHEXAMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["FOURTHWORKHEALTHEXAMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsClinician
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCLINICIAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["ISCLINICIAN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetDoctorandTechnicianList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDoctorandTechnicianList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDoctorandTechnicianList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSpecialitiesForDP_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public bool? IsMinorSpeciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMINORSPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["ISMINORSPECIALITY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetSpecialitiesForDP_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSpecialitiesForDP_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSpecialitiesForDP_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDoctorBySpecialtyForDP_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public Object Doctortitle
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCTORTITLE"]);
                }
            }

            public GetDoctorBySpecialtyForDP_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDoctorBySpecialtyForDP_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDoctorBySpecialtyForDP_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUserSpecialityByCodeAndUser_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUserSpecialityByCodeAndUser_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserSpecialityByCodeAndUser_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserSpecialityByCodeAndUser_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllDoctorForDP_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAllDoctorForDP_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllDoctorForDP_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllDoctorForDP_Class() : base() { }
        }

        [Serializable] 

        public partial class GetClinicDoctorListForEpicrisis_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetClinicDoctorListForEpicrisis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetClinicDoctorListForEpicrisis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetClinicDoctorListForEpicrisis_Class() : base() { }
        }

        [Serializable] 

        public partial class RadiologyUsersNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public RadiologyUsersNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RadiologyUsersNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RadiologyUsersNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNurseUser_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public GetNurseUser_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNurseUser_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNurseUser_Class() : base() { }
        }

        [Serializable] 

        public partial class GetResUserForSMS_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["PHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTypeEnum? UserType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["USERTYPE"].DataType;
                    return (UserTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateOfLeave
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEOFLEAVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DATEOFLEAVE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetResUserForSMS_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResUserForSMS_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResUserForSMS_Class() : base() { }
        }

        public static BindingList<ResUser> GetByUserResourceAndUserType(TTObjectContext objectContext, UserTypeEnum USERTYPE, string USERRESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetByUserResourceAndUserType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USERTYPE", (int)USERTYPE);
            paramList.Add("USERRESOURCE", USERRESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList);
        }

        public static BindingList<ResUser.OLAP_GetResDoctor_Class> OLAP_GetResDoctor(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["OLAP_GetResDoctor"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.OLAP_GetResDoctor_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResUser.OLAP_GetResDoctor_Class> OLAP_GetResDoctor(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["OLAP_GetResDoctor"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.OLAP_GetResDoctor_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResUser> GetResUserByObjectID(TTObjectContext objectContext, string TTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUserByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList);
        }

        public static BindingList<ResUser.ClinicDoctorListNQL_Class> ClinicDoctorListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["ClinicDoctorListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.ClinicDoctorListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.ClinicDoctorListNQL_Class> ClinicDoctorListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["ClinicDoctorListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.ClinicDoctorListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser> GetResUserByID(TTObjectContext objectContext, string USERID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUserByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USERID", USERID);

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList);
        }

        public static BindingList<ResUser> GetResUserByExternalID(TTObjectContext objectContext, string EXTERNALID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUserByExternalID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALID", EXTERNALID);

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList);
        }

        public static BindingList<ResUser> GetAllUser(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetAllUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Veznedar listesi
    /// </summary>
        public static BindingList<ResUser.CashierListNQL_Class> CashierListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["CashierListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.CashierListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Veznedar listesi
    /// </summary>
        public static BindingList<ResUser.CashierListNQL_Class> CashierListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["CashierListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.CashierListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.OLAP_GetDoctorCount_Class> OLAP_GetDoctorCount(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["OLAP_GetDoctorCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.OLAP_GetDoctorCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResUser.OLAP_GetDoctorCount_Class> OLAP_GetDoctorCount(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["OLAP_GetDoctorCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.OLAP_GetDoctorCount_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Kullanıcı bilgilerinin get eder
    /// </summary>
        public static BindingList<ResUser.GetUserByID_Class> GetUserByID(string USERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetUserByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USERID", USERID);

            return TTReportNqlObject.QueryObjects<ResUser.GetUserByID_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Kullanıcı bilgilerinin get eder
    /// </summary>
        public static BindingList<ResUser.GetUserByID_Class> GetUserByID(TTObjectContext objectContext, string USERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetUserByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USERID", USERID);

            return TTReportNqlObject.QueryObjects<ResUser.GetUserByID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResUser.OLAP_GetNurseCount_Class> OLAP_GetNurseCount(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["OLAP_GetNurseCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.OLAP_GetNurseCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResUser.OLAP_GetNurseCount_Class> OLAP_GetNurseCount(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["OLAP_GetNurseCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.OLAP_GetNurseCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResUser.GetUserInfoNQL_Class> GetUserInfoNQL(string USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetUserInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<ResUser.GetUserInfoNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResUser.GetUserInfoNQL_Class> GetUserInfoNQL(TTObjectContext objectContext, string USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetUserInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<ResUser.GetUserInfoNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResUser.GetResUser_Class> GetResUser(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetResUser_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetResUser_Class> GetResUser(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetResUser_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser> GetByUserResourceAndUserTypes(TTObjectContext objectContext, string USERRESOURCE, IList<UserTypeEnum> USERTYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetByUserResourceAndUserTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USERRESOURCE", USERRESOURCE);
            paramList.Add("USERTYPE", Globals.EnumListToIntList((IList)USERTYPE));

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList);
        }

        public static BindingList<ResUser> GetResUserByUserType(TTObjectContext objectContext, UserTypeEnum USERTYPE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUserByUserType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USERTYPE", (int)USERTYPE);

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResUser.DoctorListNQL_Class> DoctorListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["DoctorListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.DoctorListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.DoctorListNQL_Class> DoctorListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["DoctorListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.DoctorListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser> GetResUserByUniqeRefNo(TTObjectContext objectContext, string UNIQUEREFNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUserByUniqeRefNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList);
        }

        public static BindingList<ResUser> GetResUserByUserTypeAndResource(TTObjectContext objectContext, UserTypeEnum USERTYPE, Guid RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUserByUserTypeAndResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USERTYPE", (int)USERTYPE);
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList);
        }

        public static BindingList<ResUser.GetDoctorAndNurseNQL_Class> GetDoctorAndNurseNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetDoctorAndNurseNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetDoctorAndNurseNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetDoctorAndNurseNQL_Class> GetDoctorAndNurseNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetDoctorAndNurseNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetDoctorAndNurseNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser> GetActiveResUserByUniqeRefNo(TTObjectContext objectContext, string UNIQUEREFNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetActiveResUserByUniqeRefNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList);
        }

        public static BindingList<ResUser> DoctorListObjectNQL(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["DoctorListObjectNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResUser.GetAllUserReportNQL_Class> GetAllUserReportNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetAllUserReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetAllUserReportNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetAllUserReportNQL_Class> GetAllUserReportNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetAllUserReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetAllUserReportNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser> GetResUserByName(TTObjectContext objectContext, string NAME, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUserByName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NAME", NAME);

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResUser.GetConsultationUserNQL_Class> GetConsultationUserNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetConsultationUserNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetConsultationUserNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetConsultationUserNQL_Class> GetConsultationUserNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetConsultationUserNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetConsultationUserNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.VEM_PERSONEL_Class> VEM_PERSONEL(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["VEM_PERSONEL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.VEM_PERSONEL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResUser.VEM_PERSONEL_Class> VEM_PERSONEL(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["VEM_PERSONEL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.VEM_PERSONEL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResUser.GetdoctorsForMHRS_Class> GetdoctorsForMHRS(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetdoctorsForMHRS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetdoctorsForMHRS_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResUser.GetdoctorsForMHRS_Class> GetdoctorsForMHRS(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetdoctorsForMHRS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetdoctorsForMHRS_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Uzman Doktor Listesi(Performans alan doktorlar.)
    /// </summary>
        public static BindingList<ResUser.SpecialistDoctorListNQL_Class> SpecialistDoctorListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["SpecialistDoctorListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.SpecialistDoctorListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Uzman Doktor Listesi(Performans alan doktorlar.)
    /// </summary>
        public static BindingList<ResUser.SpecialistDoctorListNQL_Class> SpecialistDoctorListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["SpecialistDoctorListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.SpecialistDoctorListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser> GetResUserByInjection(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUserByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResUser.GetTechnicianListNQL_Class> GetTechnicianListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetTechnicianListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetTechnicianListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetTechnicianListNQL_Class> GetTechnicianListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetTechnicianListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetTechnicianListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser> GetSpecialistDoctorByResource(TTObjectContext objectContext, Guid RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetSpecialistDoctorByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList);
        }

        public static BindingList<ResUser.GetDoctorandTechnicianList_Class> GetDoctorandTechnicianList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetDoctorandTechnicianList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetDoctorandTechnicianList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetDoctorandTechnicianList_Class> GetDoctorandTechnicianList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetDoctorandTechnicianList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetDoctorandTechnicianList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetSpecialitiesForDP_Class> GetSpecialitiesForDP(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetSpecialitiesForDP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetSpecialitiesForDP_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetSpecialitiesForDP_Class> GetSpecialitiesForDP(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetSpecialitiesForDP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetSpecialitiesForDP_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetDoctorBySpecialtyForDP_Class> GetDoctorBySpecialtyForDP(Guid SPECIALTY, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetDoctorBySpecialtyForDP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIALTY", SPECIALTY);

            return TTReportNqlObject.QueryObjects<ResUser.GetDoctorBySpecialtyForDP_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetDoctorBySpecialtyForDP_Class> GetDoctorBySpecialtyForDP(TTObjectContext objectContext, Guid SPECIALTY, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetDoctorBySpecialtyForDP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIALTY", SPECIALTY);

            return TTReportNqlObject.QueryObjects<ResUser.GetDoctorBySpecialtyForDP_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser> GetNurseUserWithAllInf(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetNurseUserWithAllInf"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList);
        }

        public static BindingList<ResUser> GetSpecialistDoctorWithAllInf(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetSpecialistDoctorWithAllInf"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Kullanıcının yetkili olduğu birimleri getiren query
    /// </summary>
        public static BindingList<ResUser.GetUserSpecialityByCodeAndUser_Class> GetUserSpecialityByCodeAndUser(Guid OBJECTID, string CODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetUserSpecialityByCodeAndUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("CODE", CODE);

            return TTReportNqlObject.QueryObjects<ResUser.GetUserSpecialityByCodeAndUser_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Kullanıcının yetkili olduğu birimleri getiren query
    /// </summary>
        public static BindingList<ResUser.GetUserSpecialityByCodeAndUser_Class> GetUserSpecialityByCodeAndUser(TTObjectContext objectContext, Guid OBJECTID, string CODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetUserSpecialityByCodeAndUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("CODE", CODE);

            return TTReportNqlObject.QueryObjects<ResUser.GetUserSpecialityByCodeAndUser_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResUser> GetConsultationUserList(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetConsultationUserList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Active'ine bakılmaksızın resuser listesi
    /// </summary>
        public static BindingList<ResUser> GetUserByUniqueRefnoWithoutActive(TTObjectContext objectContext, string UNIQUEREFNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetUserByUniqueRefnoWithoutActive"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList);
        }

        public static BindingList<ResUser.GetAllDoctorForDP_Class> GetAllDoctorForDP(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetAllDoctorForDP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetAllDoctorForDP_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetAllDoctorForDP_Class> GetAllDoctorForDP(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetAllDoctorForDP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetAllDoctorForDP_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetClinicDoctorListForEpicrisis_Class> GetClinicDoctorListForEpicrisis(Guid RESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetClinicDoctorListForEpicrisis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCE", RESOURCE);

            return TTReportNqlObject.QueryObjects<ResUser.GetClinicDoctorListForEpicrisis_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResUser.GetClinicDoctorListForEpicrisis_Class> GetClinicDoctorListForEpicrisis(TTObjectContext objectContext, Guid RESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetClinicDoctorListForEpicrisis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCE", RESOURCE);

            return TTReportNqlObject.QueryObjects<ResUser.GetClinicDoctorListForEpicrisis_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResUser> GetClinicDoctorList(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetClinicDoctorList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResUser>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Radyoloji Birimi ile ilişkili kullanıcılar
    /// </summary>
        public static BindingList<ResUser.RadiologyUsersNQL_Class> RadiologyUsersNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["RadiologyUsersNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.RadiologyUsersNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Radyoloji Birimi ile ilişkili kullanıcılar
    /// </summary>
        public static BindingList<ResUser.RadiologyUsersNQL_Class> RadiologyUsersNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["RadiologyUsersNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.RadiologyUsersNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResUser.GetNurseUser_Class> GetNurseUser(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetNurseUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetNurseUser_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResUser.GetNurseUser_Class> GetNurseUser(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetNurseUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetNurseUser_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// SMS Kullanıcı NQL
    /// </summary>
        public static BindingList<ResUser.GetResUserForSMS_Class> GetResUserForSMS(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUserForSMS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetResUserForSMS_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// SMS Kullanıcı NQL
    /// </summary>
        public static BindingList<ResUser.GetResUserForSMS_Class> GetResUserForSMS(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["GetResUserForSMS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResUser.GetResUserForSMS_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Görev Yeri
    /// </summary>
        public string WorkPlace
        {
            get { return (string)this["WORKPLACE"]; }
            set { this["WORKPLACE"] = value; }
        }

    /// <summary>
    /// Görevi
    /// </summary>
        public string Work
        {
            get { return (string)this["WORK"]; }
            set { this["WORK"] = value; }
        }

    /// <summary>
    /// Sicil No
    /// </summary>
        public string EmploymentRecordID
        {
            get { return (string)this["EMPLOYMENTRECORDID"]; }
            set { this["EMPLOYMENTRECORDID"] = value; }
        }

    /// <summary>
    /// Kullanıcı İsmi
    /// </summary>
        public string LogonName
        {
            get { return (string)this["LOGONNAME"]; }
            set { this["LOGONNAME"] = value; }
        }

    /// <summary>
    /// Terfi Tarihi
    /// </summary>
        public DateTime? DateOfPromotion
        {
            get { return (DateTime?)this["DATEOFPROMOTION"]; }
            set { this["DATEOFPROMOTION"] = value; }
        }

    /// <summary>
    /// Ünvan
    /// </summary>
        public UserTitleEnum? Title
        {
            get { return (UserTitleEnum?)(int?)this["TITLE"]; }
            set { this["TITLE"] = value; }
        }

    /// <summary>
    /// Telefon No
    /// </summary>
        public string PhoneNumber
        {
            get { return (string)this["PHONENUMBER"]; }
            set { this["PHONENUMBER"] = value; }
        }

    /// <summary>
    /// Uzmanlık Tescil No
    /// </summary>
        public string SpecialityRegistryNo
        {
            get { return (string)this["SPECIALITYREGISTRYNO"]; }
            set { this["SPECIALITYREGISTRYNO"] = value; }
        }

    /// <summary>
    /// Ayrılış Tarihi
    /// </summary>
        public DateTime? DateOfLeave
        {
            get { return (DateTime?)this["DATEOFLEAVE"]; }
            set { this["DATEOFLEAVE"] = value; }
        }

    /// <summary>
    /// Kullanıcı Tipi
    /// </summary>
        public UserTypeEnum? UserType
        {
            get { return (UserTypeEnum?)(int?)this["USERTYPE"]; }
            set { this["USERTYPE"] = value; }
        }

        public bool? Status
        {
            get { return (bool?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Diploma Tescil No
    /// </summary>
        public string DiplomaRegisterNo
        {
            get { return (string)this["DIPLOMAREGISTERNO"]; }
            set { this["DIPLOMAREGISTERNO"] = value; }
        }

    /// <summary>
    /// Giriş Tarihi
    /// </summary>
        public DateTime? DateOfJoin
        {
            get { return (DateTime?)this["DATEOFJOIN"]; }
            set { this["DATEOFJOIN"] = value; }
        }

    /// <summary>
    /// Dış Sistem ID
    /// </summary>
        public string ExternalID
        {
            get { return (string)this["EXTERNALID"]; }
            set { this["EXTERNALID"] = value; }
        }

    /// <summary>
    /// Diploma No
    /// </summary>
        public string DiplomaNo
        {
            get { return (string)this["DIPLOMANO"]; }
            set { this["DIPLOMANO"] = value; }
        }

    /// <summary>
    /// MHRS'ye Bildir
    /// </summary>
        public bool? SentToMHRS
        {
            get { return (bool?)this["SENTTOMHRS"]; }
            set { this["SENTTOMHRS"] = value; }
        }

    /// <summary>
    /// Kurmay
    /// </summary>
        public bool? StaffOfficer
        {
            get { return (bool?)this["STAFFOFFICER"]; }
            set { this["STAFFOFFICER"] = value; }
        }

    /// <summary>
    /// Elektronik İmza Kullanır
    /// </summary>
        public bool? UsesESignature
        {
            get { return (bool?)this["USESESIGNATURE"]; }
            set { this["USESESIGNATURE"] = value; }
        }

    /// <summary>
    /// E Reçete Şifresi
    /// </summary>
        public string ErecetePassword
        {
            get { return (string)this["ERECETEPASSWORD"]; }
            set { this["ERECETEPASSWORD"] = value; }
        }

        public bool? TakesPerformanceScore
        {
            get { return (bool?)this["TAKESPERFORMANCESCORE"]; }
            set { this["TAKESPERFORMANCESCORE"] = value; }
        }

        public string MkysUserName
        {
            get { return (string)this["MKYSUSERNAME"]; }
            set { this["MKYSUSERNAME"] = value; }
        }

        public string MkysPassword
        {
            get { return (string)this["MKYSPASSWORD"]; }
            set { this["MKYSPASSWORD"] = value; }
        }

        public int? PreDischargeLimit
        {
            get { return (int?)this["PREDISCHARGELIMIT"]; }
            set { this["PREDISCHARGELIMIT"] = value; }
        }

        public string TitleCode
        {
            get { return (string)this["TITLECODE"]; }
            set { this["TITLECODE"] = value; }
        }

        public string StatusDefinition
        {
            get { return (string)this["STATUSDEFINITION"]; }
            set { this["STATUSDEFINITION"] = value; }
        }

    /// <summary>
    /// Hastanın Güncel 'EMail' Bilgisini Taşıyan Alandır
    /// </summary>
        public string EMail
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

        public string RecordType
        {
            get { return (string)this["RECORDTYPE"]; }
            set { this["RECORDTYPE"] = value; }
        }

        public string RecordCompany
        {
            get { return (string)this["RECORDCOMPANY"]; }
            set { this["RECORDCOMPANY"] = value; }
        }

        public string RecordCompanyCode
        {
            get { return (string)this["RECORDCOMPANYCODE"]; }
            set { this["RECORDCOMPANYCODE"] = value; }
        }

        public string RecordDefinition
        {
            get { return (string)this["RECORDDEFINITION"]; }
            set { this["RECORDDEFINITION"] = value; }
        }

        public string IntegrationId
        {
            get { return (string)this["INTEGRATIONID"]; }
            set { this["INTEGRATIONID"] = value; }
        }

        public string IntegrationVersion
        {
            get { return (string)this["INTEGRATIONVERSION"]; }
            set { this["INTEGRATIONVERSION"] = value; }
        }

        public string KPSUserName
        {
            get { return (string)this["KPSUSERNAME"]; }
            set { this["KPSUSERNAME"] = value; }
        }

        public string KPSPassword
        {
            get { return (string)this["KPSPASSWORD"]; }
            set { this["KPSPASSWORD"] = value; }
        }

    /// <summary>
    /// İş sağlığı ve güvenliği Sağlık tarama 1. muayene randevusu
    /// </summary>
        public DateTime? FirstWorkHealthExamDate
        {
            get { return (DateTime?)this["FIRSTWORKHEALTHEXAMDATE"]; }
            set { this["FIRSTWORKHEALTHEXAMDATE"] = value; }
        }

    /// <summary>
    /// İş sağlığı ve güvenliği Sağlık tarama 2. muayene randevusu
    /// </summary>
        public DateTime? SecondWorkHealthExamDate
        {
            get { return (DateTime?)this["SECONDWORKHEALTHEXAMDATE"]; }
            set { this["SECONDWORKHEALTHEXAMDATE"] = value; }
        }

    /// <summary>
    /// İş sağlığı ve güvenliği Sağlık tarama 3. muayene randevusu
    /// </summary>
        public DateTime? ThirdWorkHealthExamDate
        {
            get { return (DateTime?)this["THIRDWORKHEALTHEXAMDATE"]; }
            set { this["THIRDWORKHEALTHEXAMDATE"] = value; }
        }

    /// <summary>
    /// İş sağlığı ve güvenliği Sağlık tarama 4. muayene randevusu
    /// </summary>
        public DateTime? FourthWorkHealthExamDate
        {
            get { return (DateTime?)this["FOURTHWORKHEALTHEXAMDATE"]; }
            set { this["FOURTHWORKHEALTHEXAMDATE"] = value; }
        }

        public bool? IsClinician
        {
            get { return (bool?)this["ISCLINICIAN"]; }
            set { this["ISCLINICIAN"] = value; }
        }

    /// <summary>
    /// Kişi
    /// </summary>
        public Person Person
        {
            get { return (Person)((ITTObject)this).GetParent("PERSON"); }
            set { this["PERSON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public RankDefinitions Rank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("RANK"); }
            set { this["RANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// XXXXXX Sınıf
    /// </summary>
        public MilitaryClassDefinitions MilitaryClass
        {
            get { return (MilitaryClassDefinitions)((ITTObject)this).GetParent("MILITARYCLASS"); }
            set { this["MILITARYCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// e-imza
    /// </summary>
        public UserDigitalSignature UserDigitalSignature
        {
            get { return (UserDigitalSignature)((ITTObject)this).GetParent("USERDIGITALSIGNATURE"); }
            set { this["USERDIGITALSIGNATURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kuvvet
    /// </summary>
        public ForcesCommand ForcesCommand
        {
            get { return (ForcesCommand)((ITTObject)this).GetParent("FORCESCOMMAND"); }
            set { this["FORCESCOMMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İdari Ünvanı
    /// </summary>
        public AdministrativeStatusType AdministrativeStatusType
        {
            get { return (AdministrativeStatusType)((ITTObject)this).GetParent("ADMINISTRATIVESTATUSTYPE"); }
            set { this["ADMINISTRATIVESTATUSTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Title
    /// </summary>
        public UserTitleDefinition UserTitle
        {
            get { return (UserTitleDefinition)((ITTObject)this).GetParent("USERTITLE"); }
            set { this["USERTITLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CKYSUserType CKYSUserType
        {
            get { return (CKYSUserType)((ITTObject)this).GetParent("CKYSUSERTYPE"); }
            set { this["CKYSUSERTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientAdmissionCount PACount
        {
            get { return (PatientAdmissionCount)((ITTObject)this).GetParent("PACOUNT"); }
            set { this["PACOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DoctorQuotaDefinition DoctorQuota
        {
            get { return (DoctorQuotaDefinition)((ITTObject)this).GetParent("DOCTORQUOTA"); }
            set { this["DOCTORQUOTA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCollectiveInvoiceOpsCollection()
        {
            _CollectiveInvoiceOps = new CollectiveInvoiceOp.ChildCollectiveInvoiceOpCollection(this, new Guid("87336dc3-c540-462f-81dc-e8af46d0ea55"));
            ((ITTChildObjectCollection)_CollectiveInvoiceOps).GetChildren();
        }

        protected CollectiveInvoiceOp.ChildCollectiveInvoiceOpCollection _CollectiveInvoiceOps = null;
    /// <summary>
    /// Child collection for Kullanıcı
    /// </summary>
        public CollectiveInvoiceOp.ChildCollectiveInvoiceOpCollection CollectiveInvoiceOps
        {
            get
            {
                if (_CollectiveInvoiceOps == null)
                    CreateCollectiveInvoiceOpsCollection();
                return _CollectiveInvoiceOps;
            }
        }

        virtual protected void CreateResUserTakeOffFromWorksCollection()
        {
            _ResUserTakeOffFromWorks = new ResUserTakeOffFromWork.ChildResUserTakeOffFromWorkCollection(this, new Guid("cdf95789-85f7-484b-9b25-f64a288ef149"));
            ((ITTChildObjectCollection)_ResUserTakeOffFromWorks).GetChildren();
        }

        protected ResUserTakeOffFromWork.ChildResUserTakeOffFromWorkCollection _ResUserTakeOffFromWorks = null;
        public ResUserTakeOffFromWork.ChildResUserTakeOffFromWorkCollection ResUserTakeOffFromWorks
        {
            get
            {
                if (_ResUserTakeOffFromWorks == null)
                    CreateResUserTakeOffFromWorksCollection();
                return _ResUserTakeOffFromWorks;
            }
        }

        virtual protected void CreateAPRCollection()
        {
            _APR = new AccountPayableReceivable.ChildAccountPayableReceivableCollection(this, new Guid("dc6e4b71-f387-4bc7-89ef-6168389675d0"));
            ((ITTChildObjectCollection)_APR).GetChildren();
        }

        protected AccountPayableReceivable.ChildAccountPayableReceivableCollection _APR = null;
    /// <summary>
    /// Child collection for Kullanıcı ile ilişki
    /// </summary>
        public AccountPayableReceivable.ChildAccountPayableReceivableCollection APR
        {
            get
            {
                if (_APR == null)
                    CreateAPRCollection();
                return _APR;
            }
        }

        virtual protected void CreateUserResourcesCollection()
        {
            _UserResources = new UserResource.ChildUserResourceCollection(this, new Guid("737e206e-1260-4c1e-bbac-eb47ddbc3fb2"));
            ((ITTChildObjectCollection)_UserResources).GetChildren();
        }

        protected UserResource.ChildUserResourceCollection _UserResources = null;
        public UserResource.ChildUserResourceCollection UserResources
        {
            get
            {
                if (_UserResources == null)
                    CreateUserResourcesCollection();
                return _UserResources;
            }
        }

        virtual protected void CreateManipulationCollection()
        {
            _Manipulation = new Manipulation.ChildManipulationCollection(this, new Guid("a3fd72aa-6d12-4dda-84f5-c4a5ea2a8fb6"));
            ((ITTChildObjectCollection)_Manipulation).GetChildren();
        }

        protected Manipulation.ChildManipulationCollection _Manipulation = null;
    /// <summary>
    /// Child collection for Technician
    /// </summary>
        public Manipulation.ChildManipulationCollection Manipulation
        {
            get
            {
                if (_Manipulation == null)
                    CreateManipulationCollection();
                return _Manipulation;
            }
        }

        virtual protected void CreateUserOptionsCollection()
        {
            _UserOptions = new UserOption.ChildUserOptionCollection(this, new Guid("405f2885-c395-4f85-a2cf-ee52d81e99a7"));
            ((ITTChildObjectCollection)_UserOptions).GetChildren();
        }

        protected UserOption.ChildUserOptionCollection _UserOptions = null;
        public UserOption.ChildUserOptionCollection UserOptions
        {
            get
            {
                if (_UserOptions == null)
                    CreateUserOptionsCollection();
                return _UserOptions;
            }
        }

        virtual protected void CreateFavoriteDiagnosisCollection()
        {
            _FavoriteDiagnosis = new FavoriteDiagnosis.ChildFavoriteDiagnosisCollection(this, new Guid("1d072422-3bd0-468f-9e86-a578253bcd2d"));
            ((ITTChildObjectCollection)_FavoriteDiagnosis).GetChildren();
        }

        protected FavoriteDiagnosis.ChildFavoriteDiagnosisCollection _FavoriteDiagnosis = null;
    /// <summary>
    /// Child collection for Kullanıcı
    /// </summary>
        public FavoriteDiagnosis.ChildFavoriteDiagnosisCollection FavoriteDiagnosis
        {
            get
            {
                if (_FavoriteDiagnosis == null)
                    CreateFavoriteDiagnosisCollection();
                return _FavoriteDiagnosis;
            }
        }

        virtual protected void CreateMedulaSavedQueriesCollection()
        {
            _MedulaSavedQueries = new MedulaSavedQueries.ChildMedulaSavedQueriesCollection(this, new Guid("a57e0248-8f27-47f0-9abb-8128d1e4d601"));
            ((ITTChildObjectCollection)_MedulaSavedQueries).GetChildren();
        }

        protected MedulaSavedQueries.ChildMedulaSavedQueriesCollection _MedulaSavedQueries = null;
    /// <summary>
    /// Child collection for Kullanıcı
    /// </summary>
        public MedulaSavedQueries.ChildMedulaSavedQueriesCollection MedulaSavedQueries
        {
            get
            {
                if (_MedulaSavedQueries == null)
                    CreateMedulaSavedQueriesCollection();
                return _MedulaSavedQueries;
            }
        }

        virtual protected void CreateFavoriteDrugsCollection()
        {
            _FavoriteDrugs = new FavoriteDrug.ChildFavoriteDrugCollection(this, new Guid("a750fcbc-f197-44b6-b372-d28c872c2383"));
            ((ITTChildObjectCollection)_FavoriteDrugs).GetChildren();
        }

        protected FavoriteDrug.ChildFavoriteDrugCollection _FavoriteDrugs = null;
        public FavoriteDrug.ChildFavoriteDrugCollection FavoriteDrugs
        {
            get
            {
                if (_FavoriteDrugs == null)
                    CreateFavoriteDrugsCollection();
                return _FavoriteDrugs;
            }
        }

        virtual protected void CreateResUserPatientGroupMatchesCollection()
        {
            _ResUserPatientGroupMatches = new ResUserPatientGroupMatch.ChildResUserPatientGroupMatchCollection(this, new Guid("cf8e6c02-bae9-4c73-8e3f-5be4041577db"));
            ((ITTChildObjectCollection)_ResUserPatientGroupMatches).GetChildren();
        }

        protected ResUserPatientGroupMatch.ChildResUserPatientGroupMatchCollection _ResUserPatientGroupMatches = null;
        public ResUserPatientGroupMatch.ChildResUserPatientGroupMatchCollection ResUserPatientGroupMatches
        {
            get
            {
                if (_ResUserPatientGroupMatches == null)
                    CreateResUserPatientGroupMatchesCollection();
                return _ResUserPatientGroupMatches;
            }
        }

        virtual protected void CreateForensicMedicalReportCollection()
        {
            _ForensicMedicalReport = new ForensicMedicalReport.ChildForensicMedicalReportCollection(this, new Guid("a21d8984-3e2e-4d9b-898b-6f46f6f7ea3c"));
            ((ITTChildObjectCollection)_ForensicMedicalReport).GetChildren();
        }

        protected ForensicMedicalReport.ChildForensicMedicalReportCollection _ForensicMedicalReport = null;
    /// <summary>
    /// Child collection for Sorumlu Kisi
    /// </summary>
        public ForensicMedicalReport.ChildForensicMedicalReportCollection ForensicMedicalReport
        {
            get
            {
                if (_ForensicMedicalReport == null)
                    CreateForensicMedicalReportCollection();
                return _ForensicMedicalReport;
            }
        }

        virtual protected void CreateUserTemplatesCollection()
        {
            _UserTemplates = new UserTemplate.ChildUserTemplateCollection(this, new Guid("75cc0077-c9b2-4a2c-8c97-d3414b33981a"));
            ((ITTChildObjectCollection)_UserTemplates).GetChildren();
        }

        protected UserTemplate.ChildUserTemplateCollection _UserTemplates = null;
        public UserTemplate.ChildUserTemplateCollection UserTemplates
        {
            get
            {
                if (_UserTemplates == null)
                    CreateUserTemplatesCollection();
                return _UserTemplates;
            }
        }

        virtual protected void CreateResponsibleUsersCollection()
        {
            _ResponsibleUsers = new ResponsibleUsersGrid.ChildResponsibleUsersGridCollection(this, new Guid("0eb14cf3-0635-48d0-b6dc-28ed29e3b6bd"));
            ((ITTChildObjectCollection)_ResponsibleUsers).GetChildren();
        }

        protected ResponsibleUsersGrid.ChildResponsibleUsersGridCollection _ResponsibleUsers = null;
        public ResponsibleUsersGrid.ChildResponsibleUsersGridCollection ResponsibleUsers
        {
            get
            {
                if (_ResponsibleUsers == null)
                    CreateResponsibleUsersCollection();
                return _ResponsibleUsers;
            }
        }

        virtual protected void CreateUserSearchCriteriaCollection()
        {
            _UserSearchCriteria = new UserSearchCriteria.ChildUserSearchCriteriaCollection(this, new Guid("a2f26549-d597-4093-9a4d-c03a7701dbe6"));
            ((ITTChildObjectCollection)_UserSearchCriteria).GetChildren();
        }

        protected UserSearchCriteria.ChildUserSearchCriteriaCollection _UserSearchCriteria = null;
        public UserSearchCriteria.ChildUserSearchCriteriaCollection UserSearchCriteria
        {
            get
            {
                if (_UserSearchCriteria == null)
                    CreateUserSearchCriteriaCollection();
                return _UserSearchCriteria;
            }
        }

        virtual protected void CreateGridColumnOptionCollection()
        {
            _GridColumnOption = new UserBasedGridColumnOption.ChildUserBasedGridColumnOptionCollection(this, new Guid("78aa858c-957b-406f-9f2a-268e6e4d2f28"));
            ((ITTChildObjectCollection)_GridColumnOption).GetChildren();
        }

        protected UserBasedGridColumnOption.ChildUserBasedGridColumnOptionCollection _GridColumnOption = null;
        public UserBasedGridColumnOption.ChildUserBasedGridColumnOptionCollection GridColumnOption
        {
            get
            {
                if (_GridColumnOption == null)
                    CreateGridColumnOptionCollection();
                return _GridColumnOption;
            }
        }

        virtual protected void CreateDPDetailLogsCollection()
        {
            _DPDetailLogs = new DPDetailLog.ChildDPDetailLogCollection(this, new Guid("f64e79ec-6f1d-458c-b2fc-32b55a972932"));
            ((ITTChildObjectCollection)_DPDetailLogs).GetChildren();
        }

        protected DPDetailLog.ChildDPDetailLogCollection _DPDetailLogs = null;
        public DPDetailLog.ChildDPDetailLogCollection DPDetailLogs
        {
            get
            {
                if (_DPDetailLogs == null)
                    CreateDPDetailLogsCollection();
                return _DPDetailLogs;
            }
        }

        virtual protected void CreateDPMastersCollection()
        {
            _DPMasters = new DPMaster.ChildDPMasterCollection(this, new Guid("381c645a-f4cb-414e-80d9-3afef2da026a"));
            ((ITTChildObjectCollection)_DPMasters).GetChildren();
        }

        protected DPMaster.ChildDPMasterCollection _DPMasters = null;
        public DPMaster.ChildDPMasterCollection DPMasters
        {
            get
            {
                if (_DPMasters == null)
                    CreateDPMastersCollection();
                return _DPMasters;
            }
        }

        virtual protected void CreateResUserUsableStoresCollection()
        {
            _ResUserUsableStores = new ResUserUsableStore.ChildResUserUsableStoreCollection(this, new Guid("4ca8b1ee-f7c9-432c-b39f-115cf7eb5cd0"));
            ((ITTChildObjectCollection)_ResUserUsableStores).GetChildren();
        }

        protected ResUserUsableStore.ChildResUserUsableStoreCollection _ResUserUsableStores = null;
        public ResUserUsableStore.ChildResUserUsableStoreCollection ResUserUsableStores
        {
            get
            {
                if (_ResUserUsableStores == null)
                    CreateResUserUsableStoresCollection();
                return _ResUserUsableStores;
            }
        }

        virtual protected void CreateResUserAdministrationWorksCollection()
        {
            _ResUserAdministrationWorks = new PersonnelAdministration.ChildPersonnelAdministrationCollection(this, new Guid("8b2236d1-a88c-48f8-92b3-5b55fd117140"));
            ((ITTChildObjectCollection)_ResUserAdministrationWorks).GetChildren();
        }

        protected PersonnelAdministration.ChildPersonnelAdministrationCollection _ResUserAdministrationWorks = null;
        public PersonnelAdministration.ChildPersonnelAdministrationCollection ResUserAdministrationWorks
        {
            get
            {
                if (_ResUserAdministrationWorks == null)
                    CreateResUserAdministrationWorksCollection();
                return _ResUserAdministrationWorks;
            }
        }

        protected ResUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResUser(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResUser(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResUser(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESUSER", dataRow) { }
        protected ResUser(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESUSER", dataRow, isImported) { }
        public ResUser(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResUser(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResUser() : base() { }

    }
}