
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalProsthesisProcedure")] 

    /// <summary>
    /// Diş Protez Prosedür
    /// </summary>
    public  partial class DentalProsthesisProcedure : BaseDentalProsthesis, IWorkListEpisodeAction, ITreatmentMaterialCollection
    {
        public class DentalProsthesisProcedureList : TTObjectCollection<DentalProsthesisProcedure> { }
                    
        public class ChildDentalProsthesisProcedureCollection : TTObject.TTChildObjectCollection<DentalProsthesisProcedure>
        {
            public ChildDentalProsthesisProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalProsthesisProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class DentalProthesisPrintOutSQL_Class : TTReportNqlObject 
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

            public DateTime? HospitalInPatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? HospitalDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
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

            public DentalProthesisPrintOutSQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DentalProthesisPrintOutSQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DentalProthesisPrintOutSQL_Class() : base() { }
        }

        [Serializable] 

        public partial class DentalProthesisProcedureNQL_Class : TTReportNqlObject 
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

            public DateTime? HospitalInPatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? HospitalDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
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

            public DentalProthesisProcedureNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DentalProthesisProcedureNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DentalProthesisProcedureNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_DISPROTEZ_Class : TTReportNqlObject 
        {
            public Guid? Disprotez_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISPROTEZ_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public DateTime? Islem_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEM_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public Guid? Hasta_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_KODU"]);
                }
            }

            public Object Teknisyen_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TEKNISYEN_KODU"]);
                }
            }

            public Guid? Hekim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEKIM_KODU"]);
                }
            }

            public Guid? Birim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BIRIM_KODU"]);
                }
            }

            public Object Is_turu_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IS_TURU_KODU"]);
                }
            }

            public Object Parca_sayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PARCA_SAYISI"]);
                }
            }

            public Object Ayak_sayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AYAK_SAYISI"]);
                }
            }

            public Object Govde_sayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GOVDE_SAYISI"]);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].AllPropertyDefs["DENTALPROSTHESISDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Laboratuvar_birim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LABORATUVAR_BIRIM_KODU"]);
                }
            }

            public Object Rpt_sebebi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RPT_SEBEBI"]);
                }
            }

            public DateTime? Barkod_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARKOD_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Odendi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ODENDI"]);
                }
            }

            public DateTime? Kayit_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KAYIT_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Kasik_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KASIK_TURU"]);
                }
            }

            public string Lab_aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LAB_ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Olcu_laba_gonderildi_zaman
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OLCU_LABA_GONDERILDI_ZAMAN"]);
                }
            }

            public Object Olcu_alindi_zaman
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OLCU_ALINDI_ZAMAN"]);
                }
            }

            public Object Ekleyen_kullanici
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI"]);
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

            public VEM_DISPROTEZ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_DISPROTEZ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_DISPROTEZ_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_DISPROTEZ_DETAY_Class : TTReportNqlObject 
        {
            public Guid? Disprotez_detay_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISPROTEZ_DETAY_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Disprotez_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISPROTEZ_KODU"]);
                }
            }

            public Object Plan_zamani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PLAN_ZAMANI"]);
                }
            }

            public Object Is_turu_alt_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IS_TURU_ALT_KODU"]);
                }
            }

            public DateTime? Bitis_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BITIS_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].AllPropertyDefs["PROCESSENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Firma_alim_zamani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FIRMA_ALIM_ZAMANI"]);
                }
            }

            public Object Firma_teslim_zamani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FIRMA_TESLIM_ZAMANI"]);
                }
            }

            public Object Sartname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SARTNAME"]);
                }
            }

            public Object Onay_zamani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ONAY_ZAMANI"]);
                }
            }

            public Object Asama_rpt_onay
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ASAMA_RPT_ONAY"]);
                }
            }

            public Object Randevu_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RANDEVU_KODU"]);
                }
            }

            public Object Olcu_ret_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OLCU_RET_TARIHI"]);
                }
            }

            public string Olcu_ret_sebebi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLCU_RET_SEBEBI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].AllPropertyDefs["REASONOFRETURN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Olcu_dokum_zamani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OLCU_DOKUM_ZAMANI"]);
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

            public VEM_DISPROTEZ_DETAY_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_DISPROTEZ_DETAY_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_DISPROTEZ_DETAY_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Completed { get { return new Guid("d290b31c-dc03-4203-90b6-0a105bcc2af5"); } }
            public static Guid Rejected { get { return new Guid("64f6a1ae-9696-4dca-81f7-11f58336e597"); } }
            public static Guid OuterLabResultApproval { get { return new Guid("6bd84079-3232-4942-9056-1a52a958f428"); } }
            public static Guid OuterLabCompleted { get { return new Guid("9ae1898c-9db5-400d-8ce0-5059271b9bd0"); } }
            public static Guid ApprovalTechnicanProcedure { get { return new Guid("a56be5e1-3893-4f11-9ec5-79e04e715b3f"); } }
            public static Guid ProtesisProcedure { get { return new Guid("87366ec3-45e6-43c9-bada-89961a1b3b63"); } }
            public static Guid OuterLabResultEntry { get { return new Guid("1d227500-6a41-42d9-9e54-a9bb992735d4"); } }
            public static Guid OuterLabRequestApproval { get { return new Guid("4dd12c9a-a6d1-4749-b1f6-fc90fa824cd9"); } }
            public static Guid ResultApproval { get { return new Guid("69fae170-ef51-4255-950a-d109e50bdab1"); } }
            public static Guid Cancelled { get { return new Guid("53621706-64ea-423d-a86f-98ae9b34fc97"); } }
            public static Guid TechnicianProcedure { get { return new Guid("ab5180f0-5f19-44c3-a58f-fe384d304dc3"); } }
        }

        public static BindingList<DentalProsthesisProcedure.DentalProthesisPrintOutSQL_Class> DentalProthesisPrintOutSQL(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].QueryDefs["DentalProthesisPrintOutSQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DentalProsthesisProcedure.DentalProthesisPrintOutSQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalProsthesisProcedure.DentalProthesisPrintOutSQL_Class> DentalProthesisPrintOutSQL(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].QueryDefs["DentalProthesisPrintOutSQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DentalProsthesisProcedure.DentalProthesisPrintOutSQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DentalProsthesisProcedure.DentalProthesisProcedureNQL_Class> DentalProthesisProcedureNQL(string DENTALPROSTHESISPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].QueryDefs["DentalProthesisProcedureNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DENTALPROSTHESISPROCEDURE", DENTALPROSTHESISPROCEDURE);

            return TTReportNqlObject.QueryObjects<DentalProsthesisProcedure.DentalProthesisProcedureNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalProsthesisProcedure.DentalProthesisProcedureNQL_Class> DentalProthesisProcedureNQL(TTObjectContext objectContext, string DENTALPROSTHESISPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].QueryDefs["DentalProthesisProcedureNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DENTALPROSTHESISPROCEDURE", DENTALPROSTHESISPROCEDURE);

            return TTReportNqlObject.QueryObjects<DentalProsthesisProcedure.DentalProthesisProcedureNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DentalProsthesisProcedure.VEM_DISPROTEZ_Class> VEM_DISPROTEZ(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].QueryDefs["VEM_DISPROTEZ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalProsthesisProcedure.VEM_DISPROTEZ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalProsthesisProcedure.VEM_DISPROTEZ_Class> VEM_DISPROTEZ(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].QueryDefs["VEM_DISPROTEZ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalProsthesisProcedure.VEM_DISPROTEZ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DentalProsthesisProcedure.VEM_DISPROTEZ_DETAY_Class> VEM_DISPROTEZ_DETAY(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].QueryDefs["VEM_DISPROTEZ_DETAY"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalProsthesisProcedure.VEM_DISPROTEZ_DETAY_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalProsthesisProcedure.VEM_DISPROTEZ_DETAY_Class> VEM_DISPROTEZ_DETAY(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISPROCEDURE"].QueryDefs["VEM_DISPROTEZ_DETAY"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalProsthesisProcedure.VEM_DISPROTEZ_DETAY_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Diş Rengi
    /// </summary>
        public string ToothColor
        {
            get { return (string)this["TOOTHCOLOR"]; }
            set { this["TOOTHCOLOR"] = value; }
        }

    /// <summary>
    /// Karar
    /// </summary>
        public string Decision
        {
            get { return (string)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

    /// <summary>
    /// Teknisyene İşlem  Açıklaması
    /// </summary>
        public string DefinitionToTechnician
        {
            get { return (string)this["DEFINITIONTOTECHNICIAN"]; }
            set { this["DEFINITIONTOTECHNICIAN"] = value; }
        }

    /// <summary>
    /// Diş Protez Açıklaması
    /// </summary>
        public string DentalProsthesisDescription
        {
            get { return (string)this["DENTALPROSTHESISDESCRIPTION"]; }
            set { this["DENTALPROSTHESISDESCRIPTION"] = value; }
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
    /// Teknisyen Notu
    /// </summary>
        public string TechnicianNote
        {
            get { return (string)this["TECHNICIANNOTE"]; }
            set { this["TECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// Dış Labaratuar Adı
    /// </summary>
        public string OuterLabName
        {
            get { return (string)this["OUTERLABNAME"]; }
            set { this["OUTERLABNAME"] = value; }
        }

    /// <summary>
    /// İşlem Bitiş Tarihi
    /// </summary>
        public DateTime? ProcessEndDate
        {
            get { return (DateTime?)this["PROCESSENDDATE"]; }
            set { this["PROCESSENDDATE"] = value; }
        }

    /// <summary>
    /// İade Sebebi
    /// </summary>
        public string ReasonOfReturn
        {
            get { return (string)this["REASONOFRETURN"]; }
            set { this["REASONOFRETURN"] = value; }
        }

    /// <summary>
    /// Protez Ölçüsü
    /// </summary>
        public string ProsthesisMeasurement
        {
            get { return (string)this["PROSTHESISMEASUREMENT"]; }
            set { this["PROSTHESISMEASUREMENT"] = value; }
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
    /// Anomali
    /// </summary>
        public bool? Anomali
        {
            get { return (bool?)this["ANOMALI"]; }
            set { this["ANOMALI"] = value; }
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
    /// Anestezi Doktor Tescil No
    /// </summary>
        public string DrAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

    /// <summary>
    /// Protez Birimi
    /// </summary>
        public ResSection ProcedureDepartment
        {
            get { return (ResSection)((ITTObject)this).GetParent("PROCEDUREDEPARTMENT"); }
            set { this["PROCEDUREDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Teknisyen İşlemleri Birimi
    /// </summary>
        public ResSection TechnicalDepartment
        {
            get { return (ResSection)((ITTObject)this).GetParent("TECHNICALDEPARTMENT"); }
            set { this["TECHNICALDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DentalProsthesisRequestSuggestedProsthesis SuggestedProsthesis
        {
            get { return (DentalProsthesisRequestSuggestedProsthesis)((ITTObject)this).GetParent("SUGGESTEDPROSTHESIS"); }
            set { this["SUGGESTEDPROSTHESIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DentalProsthesisRequest DentalProsthesisRequest
        {
            get 
            {   
                if (EpisodeAction is DentalProsthesisRequest)
                    return (DentalProsthesisRequest)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        virtual protected void CreateRowMaterialsCollection()
        {
            _RowMaterials = new DentalProsthesisRowMaterial.ChildDentalProsthesisRowMaterialCollection(this, new Guid("b2bfd7ad-ea3d-4fca-94fa-921f0daccf3e"));
            ((ITTChildObjectCollection)_RowMaterials).GetChildren();
        }

        protected DentalProsthesisRowMaterial.ChildDentalProsthesisRowMaterialCollection _RowMaterials = null;
    /// <summary>
    /// Child collection for DentalProsthesis_ DentalProsthesisRowMaterial
    /// </summary>
        public DentalProsthesisRowMaterial.ChildDentalProsthesisRowMaterialCollection RowMaterials
        {
            get
            {
                if (_RowMaterials == null)
                    CreateRowMaterialsCollection();
                return _RowMaterials;
            }
        }

        virtual protected void CreateUsedSetCollection()
        {
            _UsedSet = new DentalProsthesisUsedSet.ChildDentalProsthesisUsedSetCollection(this, new Guid("4181dac2-c93b-45b7-9b14-e4117da89afe"));
            ((ITTChildObjectCollection)_UsedSet).GetChildren();
        }

        protected DentalProsthesisUsedSet.ChildDentalProsthesisUsedSetCollection _UsedSet = null;
    /// <summary>
    /// Child collection for DentalProsthesis_ DentalProsthesisUsedSet
    /// </summary>
        public DentalProsthesisUsedSet.ChildDentalProsthesisUsedSetCollection UsedSet
        {
            get
            {
                if (_UsedSet == null)
                    CreateUsedSetCollection();
                return _UsedSet;
            }
        }

        protected DentalProsthesisProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalProsthesisProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalProsthesisProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalProsthesisProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalProsthesisProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALPROSTHESISPROCEDURE", dataRow) { }
        protected DentalProsthesisProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALPROSTHESISPROCEDURE", dataRow, isImported) { }
        public DentalProsthesisProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalProsthesisProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalProsthesisProcedure() : base() { }

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