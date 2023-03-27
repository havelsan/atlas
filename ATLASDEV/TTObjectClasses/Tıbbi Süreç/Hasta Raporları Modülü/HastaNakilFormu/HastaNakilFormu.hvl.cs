
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaNakilFormu")] 

    public  partial class HastaNakilFormu : TTObject
    {
        public class HastaNakilFormuList : TTObjectCollection<HastaNakilFormu> { }
                    
        public class ChildHastaNakilFormuCollection : TTObject.TTChildObjectCollection<HastaNakilFormu>
        {
            public ChildHastaNakilFormuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaNakilFormuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<HastaNakilFormu> GetHastaNakilFormuBySubepisode(TTObjectContext objectContext, Guid SUBEPISODEID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTANAKILFORMU"].QueryDefs["GetHastaNakilFormuBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return ((ITTQuery)objectContext).QueryObjects<HastaNakilFormu>(queryDef, paramList);
        }

    /// <summary>
    /// Sevk Nedeni Açıklama
    /// </summary>
        public string SevkNedeniAciklama
        {
            get { return (string)this["SEVKNEDENIACIKLAMA"]; }
            set { this["SEVKNEDENIACIKLAMA"] = value; }
        }

        public string SistolikKanBasinci
        {
            get { return (string)this["SISTOLIKKANBASINCI"]; }
            set { this["SISTOLIKKANBASINCI"] = value; }
        }

    /// <summary>
    /// Naklin Talep Edildiği Zaman
    /// </summary>
        public DateTime? TalepEdildigiZaman
        {
            get { return (DateTime?)this["TALEPEDILDIGIZAMAN"]; }
            set { this["TALEPEDILDIGIZAMAN"] = value; }
        }

    /// <summary>
    /// Diastolik Kan Basıncı
    /// </summary>
        public string DiastolikKanBasinci
        {
            get { return (string)this["DIASTOLIKKANBASINCI"]; }
            set { this["DIASTOLIKKANBASINCI"] = value; }
        }

    /// <summary>
    /// Solunum Sayısı
    /// </summary>
        public string SolunumSayisi
        {
            get { return (string)this["SOLUNUMSAYISI"]; }
            set { this["SOLUNUMSAYISI"] = value; }
        }

    /// <summary>
    /// Glaskow Koma Skalasi
    /// </summary>
        public string GlaskowKomaSkalasi
        {
            get { return (string)this["GLASKOWKOMASKALASI"]; }
            set { this["GLASKOWKOMASKALASI"] = value; }
        }

    /// <summary>
    /// Gözler
    /// </summary>
        public string Gozler
        {
            get { return (string)this["GOZLER"]; }
            set { this["GOZLER"] = value; }
        }

    /// <summary>
    /// Ateş
    /// </summary>
        public string Ates
        {
            get { return (string)this["ATES"]; }
            set { this["ATES"] = value; }
        }

    /// <summary>
    /// Nabız Sayısı
    /// </summary>
        public string NabizSayisi
        {
            get { return (string)this["NABIZSAYISI"]; }
            set { this["NABIZSAYISI"] = value; }
        }

    /// <summary>
    /// Kan Şekeri
    /// </summary>
        public string KanSekeri
        {
            get { return (string)this["KANSEKERI"]; }
            set { this["KANSEKERI"] = value; }
        }

    /// <summary>
    /// Sözel
    /// </summary>
        public string Sozel
        {
            get { return (string)this["SOZEL"]; }
            set { this["SOZEL"] = value; }
        }

    /// <summary>
    /// Motor
    /// </summary>
        public string Motor
        {
            get { return (string)this["MOTOR"]; }
            set { this["MOTOR"] = value; }
        }

    /// <summary>
    /// Vital Bulgular
    /// </summary>
        public object VitalBulgular
        {
            get { return (object)this["VITALBULGULAR"]; }
            set { this["VITALBULGULAR"] = value; }
        }

        public object PatolojikMuayeneBilgileri
        {
            get { return (object)this["PATOLOJIKMUAYENEBILGILERI"]; }
            set { this["PATOLOJIKMUAYENEBILGILERI"] = value; }
        }

        public object TetkikBilgileri
        {
            get { return (object)this["TETKIKBILGILERI"]; }
            set { this["TETKIKBILGILERI"] = value; }
        }

        public object YapilanMedikalIslemler
        {
            get { return (object)this["YAPILANMEDIKALISLEMLER"]; }
            set { this["YAPILANMEDIKALISLEMLER"] = value; }
        }

        public object YapilacakMedikalIslemler
        {
            get { return (object)this["YAPILACAKMEDIKALISLEMLER"]; }
            set { this["YAPILACAKMEDIKALISLEMLER"] = value; }
        }

        public object IstenilenMedikalIslemler
        {
            get { return (object)this["ISTENILENMEDIKALISLEMLER"]; }
            set { this["ISTENILENMEDIKALISLEMLER"] = value; }
        }

        public object Gereksinimler
        {
            get { return (object)this["GEREKSINIMLER"]; }
            set { this["GEREKSINIMLER"] = value; }
        }

        public string MalzemeSayisi
        {
            get { return (string)this["MALZEMESAYISI"]; }
            set { this["MALZEMESAYISI"] = value; }
        }

        public string HastaYakiniAdi
        {
            get { return (string)this["HASTAYAKINIADI"]; }
            set { this["HASTAYAKINIADI"] = value; }
        }

        public string HastaYakiniSoyadi
        {
            get { return (string)this["HASTAYAKINISOYADI"]; }
            set { this["HASTAYAKINISOYADI"] = value; }
        }

        public string HastaYakiniTel
        {
            get { return (string)this["HASTAYAKINITEL"]; }
            set { this["HASTAYAKINITEL"] = value; }
        }

        public string HastaYakiniAdresi
        {
            get { return (string)this["HASTAYAKINIADRESI"]; }
            set { this["HASTAYAKINIADRESI"] = value; }
        }

        public object EkAciklama
        {
            get { return (object)this["EKACIKLAMA"]; }
            set { this["EKACIKLAMA"] = value; }
        }

        public string HekimAdi
        {
            get { return (string)this["HEKIMADI"]; }
            set { this["HEKIMADI"] = value; }
        }

        public string HekimSoyadi
        {
            get { return (string)this["HEKIMSOYADI"]; }
            set { this["HEKIMSOYADI"] = value; }
        }

        public string HekimTel
        {
            get { return (string)this["HEKIMTEL"]; }
            set { this["HEKIMTEL"] = value; }
        }

        public string HekimTC
        {
            get { return (string)this["HEKIMTC"]; }
            set { this["HEKIMTC"] = value; }
        }

        public string PersonelAdi
        {
            get { return (string)this["PERSONELADI"]; }
            set { this["PERSONELADI"] = value; }
        }

        public string PersonelSoyad
        {
            get { return (string)this["PERSONELSOYAD"]; }
            set { this["PERSONELSOYAD"] = value; }
        }

        public string PersonelTel
        {
            get { return (string)this["PERSONELTEL"]; }
            set { this["PERSONELTEL"] = value; }
        }

        public string SolunumIslemi
        {
            get { return (string)this["SOLUNUMISLEMI"]; }
            set { this["SOLUNUMISLEMI"] = value; }
        }

        public SKRSDurum AdliVakaDurum
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("ADLIVAKADURUM"); }
            set { this["ADLIVAKADURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSPersonelBransKodu BransIhtiyaci
        {
            get { return (SKRSPersonelBransKodu)((ITTObject)this).GetParent("BRANSIHTIYACI"); }
            set { this["BRANSIHTIYACI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSDurum DoktorIhtiyacDurumu
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("DOKTORIHTIYACDURUMU"); }
            set { this["DOKTORIHTIYACDURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSDurum HastaHukumDurum
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("HASTAHUKUMDURUM"); }
            set { this["HASTAHUKUMDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKlinikler HastaninBulunduguKlinik
        {
            get { return (SKRSKlinikler)((ITTObject)this).GetParent("HASTANINBULUNDUGUKLINIK"); }
            set { this["HASTANINBULUNDUGUKLINIK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKlinikler NakilEdilmekIstenilenKlinik
        {
            get { return (SKRSKlinikler)((ITTObject)this).GetParent("NAKILEDILMEKISTENILENKLINIK"); }
            set { this["NAKILEDILMEKISTENILENKLINIK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKlinikler NakilKabulEdenKlinik
        {
            get { return (SKRSKlinikler)((ITTObject)this).GetParent("NAKILKABULEDENKLINIK"); }
            set { this["NAKILKABULEDENKLINIK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKurumlar KabulEdenKurum
        {
            get { return (SKRSKurumlar)((ITTObject)this).GetParent("KABULEDENKURUM"); }
            set { this["KABULEDENKURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSILKodlari KabulEdenKurumIli
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("KABULEDENKURUMILI"); }
            set { this["KABULEDENKURUMILI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKanGrubu KabnGrubu
        {
            get { return (SKRSKanGrubu)((ITTObject)this).GetParent("KABNGRUBU"); }
            set { this["KABNGRUBU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKurumlar KomutaKontrolMerkezi
        {
            get { return (SKRSKurumlar)((ITTObject)this).GetParent("KOMUTAKONTROLMERKEZI"); }
            set { this["KOMUTAKONTROLMERKEZI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSNAKILYOLU NakilGerceklestirmeYolu
        {
            get { return (SKRSNAKILYOLU)((ITTObject)this).GetParent("NAKILGERCEKLESTIRMEYOLU"); }
            set { this["NAKILGERCEKLESTIRMEYOLU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSSEVKNEDENI SevkNedeni
        {
            get { return (SKRSSEVKNEDENI)((ITTObject)this).GetParent("SEVKNEDENI"); }
            set { this["SEVKNEDENI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSSOLUNUM Solunum
        {
            get { return (SKRSSOLUNUM)((ITTObject)this).GetParent("SOLUNUM"); }
            set { this["SOLUNUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKlinikler TalepEdenKlinik
        {
            get { return (SKRSKlinikler)((ITTObject)this).GetParent("TALEPEDENKLINIK"); }
            set { this["TALEPEDENKLINIK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSDurum TeyitliVakaDurumu
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("TEYITLIVAKADURUMU"); }
            set { this["TEYITLIVAKADURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSTRANSPORTMALZEMESI TransportMalzemesi
        {
            get { return (SKRSTRANSPORTMALZEMESI)((ITTObject)this).GetParent("TRANSPORTMALZEMESI"); }
            set { this["TRANSPORTMALZEMESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSTRIAJKODU TriajKodu
        {
            get { return (SKRSTRIAJKODU)((ITTObject)this).GetParent("TRIAJKODU"); }
            set { this["TRIAJKODU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSHastaNakilTipi HastaNakilTipi
        {
            get { return (SKRSHastaNakilTipi)((ITTObject)this).GetParent("HASTANAKILTIPI"); }
            set { this["HASTANAKILTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBilinc Bilinc
        {
            get { return (SKRSBilinc)((ITTObject)this).GetParent("BILINC"); }
            set { this["BILINC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateHastaNakilTanilarCollection()
        {
            _HastaNakilTanilar = new HastaNakilTanilar.ChildHastaNakilTanilarCollection(this, new Guid("30c72fc8-3609-4694-807f-6bd9b8b0a6ce"));
            ((ITTChildObjectCollection)_HastaNakilTanilar).GetChildren();
        }

        protected HastaNakilTanilar.ChildHastaNakilTanilarCollection _HastaNakilTanilar = null;
        public HastaNakilTanilar.ChildHastaNakilTanilarCollection HastaNakilTanilar
        {
            get
            {
                if (_HastaNakilTanilar == null)
                    CreateHastaNakilTanilarCollection();
                return _HastaNakilTanilar;
            }
        }

        protected HastaNakilFormu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaNakilFormu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaNakilFormu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaNakilFormu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaNakilFormu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTANAKILFORMU", dataRow) { }
        protected HastaNakilFormu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTANAKILFORMU", dataRow, isImported) { }
        public HastaNakilFormu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaNakilFormu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaNakilFormu() : base() { }

    }
}