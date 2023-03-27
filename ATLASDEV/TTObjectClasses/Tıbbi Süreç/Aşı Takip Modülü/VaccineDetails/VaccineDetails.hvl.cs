
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VaccineDetails")] 

    public  partial class VaccineDetails : TTObject
    {
        public class VaccineDetailsList : TTObjectCollection<VaccineDetails> { }
                    
        public class ChildVaccineDetailsCollection : TTObject.TTChildObjectCollection<VaccineDetails>
        {
            public ChildVaccineDetailsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVaccineDetailsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOldInfoForVaccine_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public String Objectdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEF"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetOldInfoForVaccine_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForVaccine_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForVaccine_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoCountForVaccine_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetOldInfoCountForVaccine_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoCountForVaccine_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoCountForVaccine_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("6fd8b801-2b2c-433f-afe3-987496a9595a"); } }
    /// <summary>
    /// Uygulandı
    /// </summary>
            public static Guid Completed { get { return new Guid("cc32375b-8689-4abd-9b53-99adc1b63697"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Canceled { get { return new Guid("b693f480-ba1b-4088-93e8-24c4e1c7c820"); } }
    /// <summary>
    /// Silindi
    /// </summary>
            public static Guid Deleted { get { return new Guid("27c95447-c3ba-4345-90fb-4150ffd51587"); } }
        }

    /// <summary>
    /// Hasta Aşı Geçmişi
    /// </summary>
        public static BindingList<VaccineDetails.GetOldInfoForVaccine_Class> GetOldInfoForVaccine(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VACCINEDETAILS"].QueryDefs["GetOldInfoForVaccine"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<VaccineDetails.GetOldInfoForVaccine_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Aşı Geçmişi
    /// </summary>
        public static BindingList<VaccineDetails.GetOldInfoForVaccine_Class> GetOldInfoForVaccine(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VACCINEDETAILS"].QueryDefs["GetOldInfoForVaccine"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<VaccineDetails.GetOldInfoForVaccine_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Aşı Sayısı
    /// </summary>
        public static BindingList<VaccineDetails.GetOldInfoCountForVaccine_Class> GetOldInfoCountForVaccine(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VACCINEDETAILS"].QueryDefs["GetOldInfoCountForVaccine"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<VaccineDetails.GetOldInfoCountForVaccine_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Aşı Sayısı
    /// </summary>
        public static BindingList<VaccineDetails.GetOldInfoCountForVaccine_Class> GetOldInfoCountForVaccine(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VACCINEDETAILS"].QueryDefs["GetOldInfoCountForVaccine"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<VaccineDetails.GetOldInfoCountForVaccine_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// Randevu Tarihi
    /// </summary>
        public DateTime? AppointmentDate
        {
            get { return (DateTime?)this["APPOINTMENTDATE"]; }
            set { this["APPOINTMENTDATE"] = value; }
        }

    /// <summary>
    /// Uygulama Tarihi
    /// </summary>
        public DateTime? ApplicationDate
        {
            get { return (DateTime?)this["APPLICATIONDATE"]; }
            set { this["APPLICATIONDATE"] = value; }
        }

    /// <summary>
    /// Dış Merkezde Uygulandı.
    /// </summary>
        public bool? DisMerkezMi
        {
            get { return (bool?)this["DISMERKEZMI"]; }
            set { this["DISMERKEZMI"] = value; }
        }

    /// <summary>
    /// Not
    /// </summary>
        public string Notes
        {
            get { return (string)this["NOTES"]; }
            set { this["NOTES"] = value; }
        }

    /// <summary>
    /// Dış  Merkez
    /// </summary>
        public string DisMerkez
        {
            get { return (string)this["DISMERKEZ"]; }
            set { this["DISMERKEZ"] = value; }
        }

    /// <summary>
    /// Aşı Durumu
    /// </summary>
        public VaccineStateEnum? VaccineState
        {
            get { return (VaccineStateEnum?)(int?)this["VACCINESTATE"]; }
            set { this["VACCINESTATE"] = value; }
        }

    /// <summary>
    /// Aşı Anti Serumu Karekodu
    /// </summary>
        public string AsiAntiSerumuKarekodu
        {
            get { return (string)this["ASIANTISERUMUKAREKODU"]; }
            set { this["ASIANTISERUMUKAREKODU"] = value; }
        }

    /// <summary>
    /// Aşı Karekodu
    /// </summary>
        public string AsiKarekodu
        {
            get { return (string)this["ASIKAREKODU"]; }
            set { this["ASIKAREKODU"] = value; }
        }

    /// <summary>
    /// Aşı Sulandırıcı Karekodu
    /// </summary>
        public string AsiSulandiriciKarekodu
        {
            get { return (string)this["ASISULANDIRICIKAREKODU"]; }
            set { this["ASISULANDIRICIKAREKODU"] = value; }
        }

    /// <summary>
    /// Aşının Son Kullanma Tarihi
    /// </summary>
        public DateTime? AsininSonKullanmaTarihi
        {
            get { return (DateTime?)this["ASININSONKULLANMATARIHI"]; }
            set { this["ASININSONKULLANMATARIHI"] = value; }
        }

    /// <summary>
    /// Sorgu Numarası
    /// </summary>
        public string SorguNumarasi
        {
            get { return (string)this["SORGUNUMARASI"]; }
            set { this["SORGUNUMARASI"] = value; }
        }

    /// <summary>
    /// Barkodu
    /// </summary>
        public string Barkod
        {
            get { return (string)this["BARKOD"]; }
            set { this["BARKOD"] = value; }
        }

    /// <summary>
    /// Seri Numarası
    /// </summary>
        public string SeriNumarasi
        {
            get { return (string)this["SERINUMARASI"]; }
            set { this["SERINUMARASI"] = value; }
        }

    /// <summary>
    /// Parti Numarası
    /// </summary>
        public string PartiNumarasi
        {
            get { return (string)this["PARTINUMARASI"]; }
            set { this["PARTINUMARASI"] = value; }
        }

    /// <summary>
    /// Kırılım Bilgisi
    /// </summary>
        public string KirilimBilgisi
        {
            get { return (string)this["KIRILIMBILGISI"]; }
            set { this["KIRILIMBILGISI"] = value; }
        }

    /// <summary>
    /// Gezici Hizmet Mi?
    /// </summary>
        public bool? GeziciHizmetMi
        {
            get { return (bool?)this["GEZICIHIZMETMI"]; }
            set { this["GEZICIHIZMETMI"] = value; }
        }

    /// <summary>
    /// Bildirim Durumu
    /// </summary>
        public string BildirimDurumu
        {
            get { return (string)this["BILDIRIMDURUMU"]; }
            set { this["BILDIRIMDURUMU"] = value; }
        }

    /// <summary>
    /// Sorgu Sonucu
    /// </summary>
        public string SorguSonucu
        {
            get { return (string)this["SORGUSONUCU"]; }
            set { this["SORGUSONUCU"] = value; }
        }

    /// <summary>
    /// Aşı Erteleme Süresi
    /// </summary>
        public int? VaccinePostponeTime
        {
            get { return (int?)this["VACCINEPOSTPONETIME"]; }
            set { this["VACCINEPOSTPONETIME"] = value; }
        }

    /// <summary>
    /// Aşı Adı
    /// </summary>
        public string VaccineName
        {
            get { return (string)this["VACCINENAME"]; }
            set { this["VACCINENAME"] = value; }
        }

    /// <summary>
    /// Periyod Adı
    /// </summary>
        public string PeriodName
        {
            get { return (string)this["PERIODNAME"]; }
            set { this["PERIODNAME"] = value; }
        }

    /// <summary>
    /// Periyod Süresi
    /// </summary>
        public int? PeriodRange
        {
            get { return (int?)this["PERIODRANGE"]; }
            set { this["PERIODRANGE"] = value; }
        }

    /// <summary>
    /// Birim
    /// </summary>
        public PeriodUnitTypeEnum? PeriodUnit
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["PERIODUNIT"]; }
            set { this["PERIODUNIT"] = value; }
        }

        public string IslemYapan
        {
            get { return (string)this["ISLEMYAPAN"]; }
            set { this["ISLEMYAPAN"] = value; }
        }

        public string BilgiAlinanKisiAdiSoyadi
        {
            get { return (string)this["BILGIALINANKISIADISOYADI"]; }
            set { this["BILGIALINANKISIADISOYADI"] = value; }
        }

        public string BilgiAlinanKisiTel
        {
            get { return (string)this["BILGIALINANKISITEL"]; }
            set { this["BILGIALINANKISITEL"] = value; }
        }

    /// <summary>
    /// Ortaya Çıkış Tarihi
    /// </summary>
        public DateTime? ASIEOrtayaCikisTarihi
        {
            get { return (DateTime?)this["ASIEORTAYACIKISTARIHI"]; }
            set { this["ASIEORTAYACIKISTARIHI"] = value; }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAsiYapilmamaDurumu SKRSAsiYapilmamaDurumu
        {
            get { return (SKRSAsiYapilmamaDurumu)((ITTObject)this).GetParent("SKRSASIYAPILMAMADURUMU"); }
            set { this["SKRSASIYAPILMAMADURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAsiYapilmamaNedeni SKRSAsiYapilmamaNedeni
        {
            get { return (SKRSAsiYapilmamaNedeni)((ITTObject)this).GetParent("SKRSASIYAPILMAMANEDENI"); }
            set { this["SKRSASIYAPILMAMANEDENI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtki SKRSAsiSonrasiIstenmeyenEtki
        {
            get { return (SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtki)((ITTObject)this).GetParent("SKRSASISONRASIISTENMEYENETKI"); }
            set { this["SKRSASISONRASIISTENMEYENETKI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSASIISLEMTURU SKRSASIISLEMTURU
        {
            get { return (SKRSASIISLEMTURU)((ITTObject)this).GetParent("SKRSASIISLEMTURU"); }
            set { this["SKRSASIISLEMTURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKurumlar SKRSKurumlar
        {
            get { return (SKRSKurumlar)((ITTObject)this).GetParent("SKRSKURUMLAR"); }
            set { this["SKRSKURUMLAR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAsiKodu SKRSAsiKodu
        {
            get { return (SKRSAsiKodu)((ITTObject)this).GetParent("SKRSASIKODU"); }
            set { this["SKRSASIKODU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public VaccineFollowUp VaccineFollowUp
        {
            get { return (VaccineFollowUp)((ITTObject)this).GetParent("VACCINEFOLLOWUP"); }
            set { this["VACCINEFOLLOWUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAsininDozu SKRSAsininDozu
        {
            get { return (SKRSAsininDozu)((ITTObject)this).GetParent("SKRSASININDOZU"); }
            set { this["SKRSASININDOZU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAsininUygulamaSekli SKRSAsininUygulamaSekli
        {
            get { return (SKRSAsininUygulamaSekli)((ITTObject)this).GetParent("SKRSASININUYGULAMASEKLI"); }
            set { this["SKRSASININUYGULAMASEKLI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAsininSaglandigiKaynak SKRSAsininSaglandigiKaynak
        {
            get { return (SKRSAsininSaglandigiKaynak)((ITTObject)this).GetParent("SKRSASININSAGLANDIGIKAYNAK"); }
            set { this["SKRSASININSAGLANDIGIKAYNAK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAsiUygulamaYeri SKRSAsiUygulamaYeri
        {
            get { return (SKRSAsiUygulamaYeri)((ITTObject)this).GetParent("SKRSASIUYGULAMAYERI"); }
            set { this["SKRSASIUYGULAMAYERI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResponsibleNurse
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLENURSE"); }
            set { this["RESPONSIBLENURSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAsiOzelDurumNedeni SKRSAsiOzelDurumNedeni
        {
            get { return (SKRSAsiOzelDurumNedeni)((ITTObject)this).GetParent("SKRSASIOZELDURUMNEDENI"); }
            set { this["SKRSASIOZELDURUMNEDENI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected VaccineDetails(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VaccineDetails(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VaccineDetails(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VaccineDetails(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VaccineDetails(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VACCINEDETAILS", dataRow) { }
        protected VaccineDetails(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VACCINEDETAILS", dataRow, isImported) { }
        public VaccineDetails(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VaccineDetails(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VaccineDetails() : base() { }

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