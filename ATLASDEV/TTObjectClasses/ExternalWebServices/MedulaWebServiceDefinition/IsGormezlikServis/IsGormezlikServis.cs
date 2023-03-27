
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
    public  partial class IsGormezlikServis : TTObject
    {
        
                    
        public static partial class WebMethods
        {
                    
        }
                    
#region Methods
        /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dvo.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class IsgoremezlikRaporDVO {
        
        private RaporBilgisiDVO raporBilgisiField;
        
        private int isGoremezlikRaporTuruField;
        
        private int bransKoduField;
        
        private string protokolNoField;
        
        private string protokolTarihiField;
        
        private string duzenlemeTuruField;
        
        private string teshisField;
        
        private IsKazasiRaporDVO isKazasiRaporuField;
        
        private MeslekHastaligiRaporDVO meslekHastaligiRaporuField;
        
        private AnalikRaporDVO analikRaporuField;
        
        private EmzirmeRaporDVO emzirmeRaporuField;
        
        private HastalikRaporDVO hastalikRaporuField;
        
        private HakSahibiBilgisiDVO hakSahibiField;
        
        private string aciklamaField;
        
        private string olumField;
        
        private string klinikBulgularField;
        
        private string ronLabBilgileriField;
        
        private string kararField;
        
        private DoktorBilgisiDVO[] doktorArrField;
        
        private int bashekimOnayDurumuField;
        
        private string bashekimTCNoField;
        
        private int devammiField;
        
        private string yatisDevamField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public RaporBilgisiDVO raporBilgisi {
            get {
                return raporBilgisiField;
            }
            set {
                raporBilgisiField = value;
            }
        }
        
        /// <remarks/>
        public int isGoremezlikRaporTuru {
            get {
                return isGoremezlikRaporTuruField;
            }
            set {
                isGoremezlikRaporTuruField = value;
            }
        }
        
        /// <remarks/>
        public int bransKodu {
            get {
                return bransKoduField;
            }
            set {
                bransKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string protokolNo {
            get {
                return protokolNoField;
            }
            set {
                protokolNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string protokolTarihi {
            get {
                return protokolTarihiField;
            }
            set {
                protokolTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string duzenlemeTuru {
            get {
                return duzenlemeTuruField;
            }
            set {
                duzenlemeTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string teshis {
            get {
                return teshisField;
            }
            set {
                teshisField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public IsKazasiRaporDVO isKazasiRaporu {
            get {
                return isKazasiRaporuField;
            }
            set {
                isKazasiRaporuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public MeslekHastaligiRaporDVO meslekHastaligiRaporu {
            get {
                return meslekHastaligiRaporuField;
            }
            set {
                meslekHastaligiRaporuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public AnalikRaporDVO analikRaporu {
            get {
                return analikRaporuField;
            }
            set {
                analikRaporuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public EmzirmeRaporDVO emzirmeRaporu {
            get {
                return emzirmeRaporuField;
            }
            set {
                emzirmeRaporuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public HastalikRaporDVO hastalikRaporu {
            get {
                return hastalikRaporuField;
            }
            set {
                hastalikRaporuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public HakSahibiBilgisiDVO hakSahibi {
            get {
                return hakSahibiField;
            }
            set {
                hakSahibiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string olum {
            get {
                return olumField;
            }
            set {
                olumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string klinikBulgular {
            get {
                return klinikBulgularField;
            }
            set {
                klinikBulgularField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ronLabBilgileri {
            get {
                return ronLabBilgileriField;
            }
            set {
                ronLabBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string karar {
            get {
                return kararField;
            }
            set {
                kararField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("doktorArr", IsNullable=true)]
        public DoktorBilgisiDVO[] doktorArr {
            get {
                return doktorArrField;
            }
            set {
                doktorArrField = value;
            }
        }
        
        /// <remarks/>
        public int bashekimOnayDurumu {
            get {
                return bashekimOnayDurumuField;
            }
            set {
                bashekimOnayDurumuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bashekimTCNo {
            get {
                return bashekimTCNoField;
            }
            set {
                bashekimTCNoField = value;
            }
        }
        
        /// <remarks/>
        public int devammi {
            get {
                return devammiField;
            }
            set {
                devammiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string yatisDevam {
            get {
                return yatisDevamField;
            }
            set {
                yatisDevamField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dvo.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class RaporBilgisiDVO {
        
        private int raporTesisKoduField;
        
        private string tarihField;
        
        private string raporTesisAdiField;
        
        private string noField;
        
        private string raporTakipNoField;
        
        private int raporSiraNoField;
        
        private int aVakaTKazaField;
        
        /// <remarks/>
        public int raporTesisKodu {
            get {
                return raporTesisKoduField;
            }
            set {
                raporTesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string tarih {
            get {
                return tarihField;
            }
            set {
                tarihField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string raporTesisAdi {
            get {
                return raporTesisAdiField;
            }
            set {
                raporTesisAdiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string no {
            get {
                return noField;
            }
            set {
                noField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string raporTakipNo {
            get {
                return raporTakipNoField;
            }
            set {
                raporTakipNoField = value;
            }
        }
        
        /// <remarks/>
        public int raporSiraNo {
            get {
                return raporSiraNoField;
            }
            set {
                raporSiraNoField = value;
            }
        }
        
        /// <remarks/>
        public int AVakaTKaza {
            get {
                return aVakaTKazaField;
            }
            set {
                aVakaTKazaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtos.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class IgorIsKazasiMeslekHastalikDTO {
        
        private string yaraninTuruField;
        
        private string yaraninYeriField;
        
        private string nuksField;
        
        private int aVakaTkazaField;
        
        private System.Nullable<System.DateTime> isKazasiTarihiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string yaraninTuru {
            get {
                return yaraninTuruField;
            }
            set {
                yaraninTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string yaraninYeri {
            get {
                return yaraninYeriField;
            }
            set {
                yaraninYeriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string nuks {
            get {
                return nuksField;
            }
            set {
                nuksField = value;
            }
        }
        
        /// <remarks/>
        public int AVakaTkaza {
            get {
                return aVakaTkazaField;
            }
            set {
                aVakaTkazaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> isKazasiTarihi {
            get {
                return isKazasiTarihiField;
            }
            set {
                isKazasiTarihiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtos.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class IgorAnalikEmzirmeDTO {
        
        private int analikRaporTipiField;
        
        private int gebelikTipiField;
        
        private int gebelikHaftasi1Field;
        
        private int gebelikHaftasi2Field;
        
        private int bebekDogumHaftasiField;
        
        private int aktarmaHaftasiField;
        
        private System.Nullable<System.DateTime> bebekDogumTarihiField;
        
        private int canliCocukSayisiField;
        
        private int doganCocukSayisiField;
        
        private string norSezForField;
        
        private string anneTCKimlikNoField;
        
        /// <remarks/>
        public int analikRaporTipi {
            get {
                return analikRaporTipiField;
            }
            set {
                analikRaporTipiField = value;
            }
        }
        
        /// <remarks/>
        public int gebelikTipi {
            get {
                return gebelikTipiField;
            }
            set {
                gebelikTipiField = value;
            }
        }
        
        /// <remarks/>
        public int gebelikHaftasi1 {
            get {
                return gebelikHaftasi1Field;
            }
            set {
                gebelikHaftasi1Field = value;
            }
        }
        
        /// <remarks/>
        public int gebelikHaftasi2 {
            get {
                return gebelikHaftasi2Field;
            }
            set {
                gebelikHaftasi2Field = value;
            }
        }
        
        /// <remarks/>
        public int bebekDogumHaftasi {
            get {
                return bebekDogumHaftasiField;
            }
            set {
                bebekDogumHaftasiField = value;
            }
        }
        
        /// <remarks/>
        public int aktarmaHaftasi {
            get {
                return aktarmaHaftasiField;
            }
            set {
                aktarmaHaftasiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> bebekDogumTarihi {
            get {
                return bebekDogumTarihiField;
            }
            set {
                bebekDogumTarihiField = value;
            }
        }
        
        /// <remarks/>
        public int canliCocukSayisi {
            get {
                return canliCocukSayisiField;
            }
            set {
                canliCocukSayisiField = value;
            }
        }
        
        /// <remarks/>
        public int doganCocukSayisi {
            get {
                return doganCocukSayisiField;
            }
            set {
                doganCocukSayisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string norSezFor {
            get {
                return norSezForField;
            }
            set {
                norSezForField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string anneTCKimlikNo {
            get {
                return anneTCKimlikNoField;
            }
            set {
                anneTCKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtos.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class IgorMedulaRaporDTO {
        
        private int bashekimOnayField;
        
        private System.Nullable<System.DateTime> baslangicTarihiField;
        
        private System.Nullable<System.DateTime> bitisTarihiField;
        
        private System.Nullable<System.DateTime> isKontTarihiField;
        
        private System.Nullable<System.DateTime> XXXXXXYatisTarihiField;
        
        private System.Nullable<System.DateTime> XXXXXXCikisTarihiField;
        
        private string yatisDevamField;
        
        private System.Nullable<System.DateTime> taburcuTarihiField;
        
        private int taburcuKoduField;
        
        /// <remarks/>
        public int bashekimOnay {
            get {
                return bashekimOnayField;
            }
            set {
                bashekimOnayField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> baslangicTarihi {
            get {
                return baslangicTarihiField;
            }
            set {
                baslangicTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> bitisTarihi {
            get {
                return bitisTarihiField;
            }
            set {
                bitisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> isKontTarihi {
            get {
                return isKontTarihiField;
            }
            set {
                isKontTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> XXXXXXYatisTarihi {
            get {
                return XXXXXXYatisTarihiField;
            }
            set {
                XXXXXXYatisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> XXXXXXCikisTarihi {
            get {
                return XXXXXXCikisTarihiField;
            }
            set {
                XXXXXXCikisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string yatisDevam {
            get {
                return yatisDevamField;
            }
            set {
                yatisDevamField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> taburcuTarihi {
            get {
                return taburcuTarihiField;
            }
            set {
                taburcuTarihiField = value;
            }
        }
        
        /// <remarks/>
        public int taburcuKodu {
            get {
                return taburcuKoduField;
            }
            set {
                taburcuKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtos.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class DoktorBilgisiDTO {
        
        private string drTescilNoField;
        
        private string drAdiField;
        
        private string drSoyadiField;
        
        private string drBransKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string drTescilNo {
            get {
                return drTescilNoField;
            }
            set {
                drTescilNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string drAdi {
            get {
                return drAdiField;
            }
            set {
                drAdiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string drSoyadi {
            get {
                return drSoyadiField;
            }
            set {
                drSoyadiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string drBransKodu {
            get {
                return drBransKoduField;
            }
            set {
                drBransKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtos.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class KullaniciDTO {
        
        private string kullaniciadiField;
        
        private System.Nullable<System.DateTime> islemtarihiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string kullaniciadi {
            get {
                return kullaniciadiField;
            }
            set {
                kullaniciadiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> islemtarihi {
            get {
                return islemtarihiField;
            }
            set {
                islemtarihiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtos.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class HaksahibiBilgisiDTO {
        
        private string tckimlikNoField;
        
        private string sosyalGuvenlikNoField;
        
        private string sigortaliTuruField;
        
        private string provizyonTipiField;
        
        private System.Nullable<System.DateTime> provizyonTarihiField;
        
        private string adiField;
        
        private string soyadiField;
        
        private string cinsiyetField;
        
        private string adresField;
        
        private string telefonField;
        
        private string bagliBulunanBirimField;
        
        private string meslekField;
        
        private string mahiyetField;
        
        private string iskoluField;
        
        private string emeklimiField;
        
        private string yeniSubeKodField;
        
        private string eskiSubeKodField;
        
        private string isyeriNoField;
        
        private string naceKoduField;
        
        private string isyeriIlField;
        
        private string isyeriIlceField;
        
        private string cdField;
        
        private string aracinoField;
        
        private string sgmField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string tckimlikNo {
            get {
                return tckimlikNoField;
            }
            set {
                tckimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sosyalGuvenlikNo {
            get {
                return sosyalGuvenlikNoField;
            }
            set {
                sosyalGuvenlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sigortaliTuru {
            get {
                return sigortaliTuruField;
            }
            set {
                sigortaliTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string provizyonTipi {
            get {
                return provizyonTipiField;
            }
            set {
                provizyonTipiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> provizyonTarihi {
            get {
                return provizyonTarihiField;
            }
            set {
                provizyonTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string adi {
            get {
                return adiField;
            }
            set {
                adiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string soyadi {
            get {
                return soyadiField;
            }
            set {
                soyadiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string cinsiyet {
            get {
                return cinsiyetField;
            }
            set {
                cinsiyetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string adres {
            get {
                return adresField;
            }
            set {
                adresField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string telefon {
            get {
                return telefonField;
            }
            set {
                telefonField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bagliBulunanBirim {
            get {
                return bagliBulunanBirimField;
            }
            set {
                bagliBulunanBirimField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string meslek {
            get {
                return meslekField;
            }
            set {
                meslekField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string mahiyet {
            get {
                return mahiyetField;
            }
            set {
                mahiyetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string iskolu {
            get {
                return iskoluField;
            }
            set {
                iskoluField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string emeklimi {
            get {
                return emeklimiField;
            }
            set {
                emeklimiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string yeniSubeKod {
            get {
                return yeniSubeKodField;
            }
            set {
                yeniSubeKodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string eskiSubeKod {
            get {
                return eskiSubeKodField;
            }
            set {
                eskiSubeKodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string isyeriNo {
            get {
                return isyeriNoField;
            }
            set {
                isyeriNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string naceKodu {
            get {
                return naceKoduField;
            }
            set {
                naceKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string isyeriIl {
            get {
                return isyeriIlField;
            }
            set {
                isyeriIlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string isyeriIlce {
            get {
                return isyeriIlceField;
            }
            set {
                isyeriIlceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string cd {
            get {
                return cdField;
            }
            set {
                cdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string aracino {
            get {
                return aracinoField;
            }
            set {
                aracinoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sgm {
            get {
                return sgmField;
            }
            set {
                sgmField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtos.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class RaporBilgisiDTO {
        
        private int raporTesisKoduField;
        
        private System.Nullable<System.DateTime> tarihField;
        
        private int noField;
        
        private string raporTakipNoField;
        
        private int raporSiraNoField;
        
        private int raporTipiField;
        
        private string raporAcikKapaliField;
        
        private int aVakaTKazaField;
        
        private string raporTesisAdiField;
        
        /// <remarks/>
        public int raporTesisKodu {
            get {
                return raporTesisKoduField;
            }
            set {
                raporTesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> tarih {
            get {
                return tarihField;
            }
            set {
                tarihField = value;
            }
        }
        
        /// <remarks/>
        public int no {
            get {
                return noField;
            }
            set {
                noField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string raporTakipNo {
            get {
                return raporTakipNoField;
            }
            set {
                raporTakipNoField = value;
            }
        }
        
        /// <remarks/>
        public int raporSiraNo {
            get {
                return raporSiraNoField;
            }
            set {
                raporSiraNoField = value;
            }
        }
        
        /// <remarks/>
        public int raporTipi {
            get {
                return raporTipiField;
            }
            set {
                raporTipiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string raporAcikKapali {
            get {
                return raporAcikKapaliField;
            }
            set {
                raporAcikKapaliField = value;
            }
        }
        
        /// <remarks/>
        public int AVakaTKaza {
            get {
                return aVakaTKazaField;
            }
            set {
                aVakaTKazaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string raporTesisAdi {
            get {
                return raporTesisAdiField;
            }
            set {
                raporTesisAdiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtos.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class IsgoremezlikRaporDTO {
        
        private RaporBilgisiDTO raporBilgisiField;
        
        private int isGoremezlikRaporTuruField;
        
        private int bransKoduField;
        
        private int protokolNoField;
        
        private System.Nullable<System.DateTime> protokolTarihiField;
        
        private string teshisField;
        
        private string aciklamaField;
        
        private string olumField;
        
        private HaksahibiBilgisiDTO hakSahibiField;
        
        private KullaniciDTO kullaniciField;
        
        private string kararField;
        
        private string klinikBulgularField;
        
        private string ronLabBilgileriField;
        
        private string duzenlemeTuruField;
        
        private DoktorBilgisiDTO[] doktorArrField;
        
        private IgorMedulaRaporDTO medulaRaporField;
        
        private IgorAnalikEmzirmeDTO analikEmzirmeField;
        
        private IgorIsKazasiMeslekHastalikDTO iskazasiHastalikField;
        
        private int bashekimOnayDurumuField;
        
        private string bashekimTCNoField;
        
        private int devammiField;
        
        private string raporDurumuField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public RaporBilgisiDTO raporBilgisi {
            get {
                return raporBilgisiField;
            }
            set {
                raporBilgisiField = value;
            }
        }
        
        /// <remarks/>
        public int isGoremezlikRaporTuru {
            get {
                return isGoremezlikRaporTuruField;
            }
            set {
                isGoremezlikRaporTuruField = value;
            }
        }
        
        /// <remarks/>
        public int bransKodu {
            get {
                return bransKoduField;
            }
            set {
                bransKoduField = value;
            }
        }
        
        /// <remarks/>
        public int protokolNo {
            get {
                return protokolNoField;
            }
            set {
                protokolNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> protokolTarihi {
            get {
                return protokolTarihiField;
            }
            set {
                protokolTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string teshis {
            get {
                return teshisField;
            }
            set {
                teshisField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string olum {
            get {
                return olumField;
            }
            set {
                olumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public HaksahibiBilgisiDTO hakSahibi {
            get {
                return hakSahibiField;
            }
            set {
                hakSahibiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public KullaniciDTO kullanici {
            get {
                return kullaniciField;
            }
            set {
                kullaniciField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string karar {
            get {
                return kararField;
            }
            set {
                kararField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string klinikBulgular {
            get {
                return klinikBulgularField;
            }
            set {
                klinikBulgularField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ronLabBilgileri {
            get {
                return ronLabBilgileriField;
            }
            set {
                ronLabBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string duzenlemeTuru {
            get {
                return duzenlemeTuruField;
            }
            set {
                duzenlemeTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("doktorArr", IsNullable=true)]
        public DoktorBilgisiDTO[] doktorArr {
            get {
                return doktorArrField;
            }
            set {
                doktorArrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public IgorMedulaRaporDTO medulaRapor {
            get {
                return medulaRaporField;
            }
            set {
                medulaRaporField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public IgorAnalikEmzirmeDTO analikEmzirme {
            get {
                return analikEmzirmeField;
            }
            set {
                analikEmzirmeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public IgorIsKazasiMeslekHastalikDTO iskazasiHastalik {
            get {
                return iskazasiHastalikField;
            }
            set {
                iskazasiHastalikField = value;
            }
        }
        
        /// <remarks/>
        public int bashekimOnayDurumu {
            get {
                return bashekimOnayDurumuField;
            }
            set {
                bashekimOnayDurumuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bashekimTCNo {
            get {
                return bashekimTCNoField;
            }
            set {
                bashekimTCNoField = value;
            }
        }
        
        /// <remarks/>
        public int devammi {
            get {
                return devammiField;
            }
            set {
                devammiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string raporDurumu {
            get {
                return raporDurumuField;
            }
            set {
                raporDurumuField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dto.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class CevapDTO {
        
        private long raporIDField;
        
        private string hataMesajiField;
        
        private int sonucKoduField;
        
        private string raporTakipNoField;
        
        private int raporSiraNoField;
        
        private string dogumSonrasiIsbasiTarihiField;
        
        private IsgoremezlikRaporDTO isgoremezlikRaporField;
        
        private IsgoremezlikRaporDTO[] isgoremezlikRaporArrField;
        
        /// <remarks/>
        public long raporID {
            get {
                return raporIDField;
            }
            set {
                raporIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string hataMesaji {
            get {
                return hataMesajiField;
            }
            set {
                hataMesajiField = value;
            }
        }
        
        /// <remarks/>
        public int sonucKodu {
            get {
                return sonucKoduField;
            }
            set {
                sonucKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string raporTakipNo {
            get {
                return raporTakipNoField;
            }
            set {
                raporTakipNoField = value;
            }
        }
        
        /// <remarks/>
        public int raporSiraNo {
            get {
                return raporSiraNoField;
            }
            set {
                raporSiraNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string dogumSonrasiIsbasiTarihi {
            get {
                return dogumSonrasiIsbasiTarihiField;
            }
            set {
                dogumSonrasiIsbasiTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public IsgoremezlikRaporDTO isgoremezlikRapor {
            get {
                return isgoremezlikRaporField;
            }
            set {
                isgoremezlikRaporField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("isgoremezlikRaporArr", IsNullable=true)]
        public IsgoremezlikRaporDTO[] isgoremezlikRaporArr {
            get {
                return isgoremezlikRaporArrField;
            }
            set {
                isgoremezlikRaporArrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dvo.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class DoktorBilgisiDVO {
        
        private string drTescilNoField;
        
        private string drAdiField;
        
        private string drSoyadiField;
        
        private string drBransKoduField;
        
        private string tipiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string drTescilNo {
            get {
                return drTescilNoField;
            }
            set {
                drTescilNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string drAdi {
            get {
                return drAdiField;
            }
            set {
                drAdiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string drSoyadi {
            get {
                return drSoyadiField;
            }
            set {
                drSoyadiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string drBransKodu {
            get {
                return drBransKoduField;
            }
            set {
                drBransKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string tipi {
            get {
                return tipiField;
            }
            set {
                tipiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dvo.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class HakSahibiBilgisiDVO {
        
        private string tckimlikNoField;
        
        private string sosyalGuvenlikNoField;
        
        private string sigortaliTuruField;
        
        private string provizyonTipiField;
        
        private string provizyonTarihiField;
        
        private string adiField;
        
        private string soyadiField;
        
        private string adresField;
        
        private string telefonField;
        
        private string bagliBulunanBirimField;
        
        private string emeklimiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string tckimlikNo {
            get {
                return tckimlikNoField;
            }
            set {
                tckimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sosyalGuvenlikNo {
            get {
                return sosyalGuvenlikNoField;
            }
            set {
                sosyalGuvenlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sigortaliTuru {
            get {
                return sigortaliTuruField;
            }
            set {
                sigortaliTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string provizyonTipi {
            get {
                return provizyonTipiField;
            }
            set {
                provizyonTipiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string provizyonTarihi {
            get {
                return provizyonTarihiField;
            }
            set {
                provizyonTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string adi {
            get {
                return adiField;
            }
            set {
                adiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string soyadi {
            get {
                return soyadiField;
            }
            set {
                soyadiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string adres {
            get {
                return adresField;
            }
            set {
                adresField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string telefon {
            get {
                return telefonField;
            }
            set {
                telefonField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bagliBulunanBirim {
            get {
                return bagliBulunanBirimField;
            }
            set {
                bagliBulunanBirimField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string emeklimi {
            get {
                return emeklimiField;
            }
            set {
                emeklimiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dvo.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class HastalikRaporDVO {
        
        private string baslangicTarihiField;
        
        private string bitisTarihiField;
        
        private string raporDurumuField;
        
        private string isKontTarihiField;
        
        private string XXXXXXYatisTarihiField;
        
        private string XXXXXXCikisTarihiField;
        
        private string taburcuTarihiField;
        
        private int taburcuKoduField;
        
        private string nuksField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string baslangicTarihi {
            get {
                return baslangicTarihiField;
            }
            set {
                baslangicTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bitisTarihi {
            get {
                return bitisTarihiField;
            }
            set {
                bitisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string raporDurumu {
            get {
                return raporDurumuField;
            }
            set {
                raporDurumuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string isKontTarihi {
            get {
                return isKontTarihiField;
            }
            set {
                isKontTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string XXXXXXYatisTarihi {
            get {
                return XXXXXXYatisTarihiField;
            }
            set {
                XXXXXXYatisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string XXXXXXCikisTarihi {
            get {
                return XXXXXXCikisTarihiField;
            }
            set {
                XXXXXXCikisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string taburcuTarihi {
            get {
                return taburcuTarihiField;
            }
            set {
                taburcuTarihiField = value;
            }
        }
        
        /// <remarks/>
        public int taburcuKodu {
            get {
                return taburcuKoduField;
            }
            set {
                taburcuKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string nuks {
            get {
                return nuksField;
            }
            set {
                nuksField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dvo.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class EmzirmeRaporDVO {
        
        private string bebekDogumTarihiField;
        
        private int canliCocukSayisiField;
        
        private int doganCocukSayisiField;
        
        private string anneTcKimlikNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bebekDogumTarihi {
            get {
                return bebekDogumTarihiField;
            }
            set {
                bebekDogumTarihiField = value;
            }
        }
        
        /// <remarks/>
        public int canliCocukSayisi {
            get {
                return canliCocukSayisiField;
            }
            set {
                canliCocukSayisiField = value;
            }
        }
        
        /// <remarks/>
        public int doganCocukSayisi {
            get {
                return doganCocukSayisiField;
            }
            set {
                doganCocukSayisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string anneTcKimlikNo {
            get {
                return anneTcKimlikNoField;
            }
            set {
                anneTcKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dvo.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class AnalikRaporDVO {
        
        private string baslangicTarihiField;
        
        private string bitisTarihiField;
        
        private string raporDurumuField;
        
        private string isKontTarihiField;
        
        private string XXXXXXYatisTarihiField;
        
        private string XXXXXXCikisTarihiField;
        
        private string bebekDogumTarihiField;
        
        private int canliCocukSayisiField;
        
        private int doganCocukSayisiField;
        
        private string norSezForField;
        
        private string taburcuTarihiField;
        
        private int taburcuKoduField;
        
        private int analikRaporTipiField;
        
        private int gebelikTipiField;
        
        private int gebelikHaftasi1Field;
        
        private int gebelikHaftasi2Field;
        
        private int bebekDogumHaftasiField;
        
        private int aktarmaHaftasiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string baslangicTarihi {
            get {
                return baslangicTarihiField;
            }
            set {
                baslangicTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bitisTarihi {
            get {
                return bitisTarihiField;
            }
            set {
                bitisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string raporDurumu {
            get {
                return raporDurumuField;
            }
            set {
                raporDurumuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string isKontTarihi {
            get {
                return isKontTarihiField;
            }
            set {
                isKontTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string XXXXXXYatisTarihi {
            get {
                return XXXXXXYatisTarihiField;
            }
            set {
                XXXXXXYatisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string XXXXXXCikisTarihi {
            get {
                return XXXXXXCikisTarihiField;
            }
            set {
                XXXXXXCikisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bebekDogumTarihi {
            get {
                return bebekDogumTarihiField;
            }
            set {
                bebekDogumTarihiField = value;
            }
        }
        
        /// <remarks/>
        public int canliCocukSayisi {
            get {
                return canliCocukSayisiField;
            }
            set {
                canliCocukSayisiField = value;
            }
        }
        
        /// <remarks/>
        public int doganCocukSayisi {
            get {
                return doganCocukSayisiField;
            }
            set {
                doganCocukSayisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string norSezFor {
            get {
                return norSezForField;
            }
            set {
                norSezForField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string taburcuTarihi {
            get {
                return taburcuTarihiField;
            }
            set {
                taburcuTarihiField = value;
            }
        }
        
        /// <remarks/>
        public int taburcuKodu {
            get {
                return taburcuKoduField;
            }
            set {
                taburcuKoduField = value;
            }
        }
        
        /// <remarks/>
        public int analikRaporTipi {
            get {
                return analikRaporTipiField;
            }
            set {
                analikRaporTipiField = value;
            }
        }
        
        /// <remarks/>
        public int gebelikTipi {
            get {
                return gebelikTipiField;
            }
            set {
                gebelikTipiField = value;
            }
        }
        
        /// <remarks/>
        public int gebelikHaftasi1 {
            get {
                return gebelikHaftasi1Field;
            }
            set {
                gebelikHaftasi1Field = value;
            }
        }
        
        /// <remarks/>
        public int gebelikHaftasi2 {
            get {
                return gebelikHaftasi2Field;
            }
            set {
                gebelikHaftasi2Field = value;
            }
        }
        
        /// <remarks/>
        public int bebekDogumHaftasi {
            get {
                return bebekDogumHaftasiField;
            }
            set {
                bebekDogumHaftasiField = value;
            }
        }
        
        /// <remarks/>
        public int aktarmaHaftasi {
            get {
                return aktarmaHaftasiField;
            }
            set {
                aktarmaHaftasiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dvo.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class MeslekHastaligiRaporDVO {
        
        private string baslangicTarihiField;
        
        private string bitisTarihiField;
        
        private string raporDurumuField;
        
        private string isKontTarihiField;
        
        private string XXXXXXYatisTarihiField;
        
        private string XXXXXXCikisTarihiField;
        
        private string nuksField;
        
        private string yaraninTuruField;
        
        private string yaraninYeriField;
        
        private string taburcuTarihiField;
        
        private int taburcuKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string baslangicTarihi {
            get {
                return baslangicTarihiField;
            }
            set {
                baslangicTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bitisTarihi {
            get {
                return bitisTarihiField;
            }
            set {
                bitisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string raporDurumu {
            get {
                return raporDurumuField;
            }
            set {
                raporDurumuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string isKontTarihi {
            get {
                return isKontTarihiField;
            }
            set {
                isKontTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string XXXXXXYatisTarihi {
            get {
                return XXXXXXYatisTarihiField;
            }
            set {
                XXXXXXYatisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string XXXXXXCikisTarihi {
            get {
                return XXXXXXCikisTarihiField;
            }
            set {
                XXXXXXCikisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string nuks {
            get {
                return nuksField;
            }
            set {
                nuksField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string yaraninTuru {
            get {
                return yaraninTuruField;
            }
            set {
                yaraninTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string yaraninYeri {
            get {
                return yaraninYeriField;
            }
            set {
                yaraninYeriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string taburcuTarihi {
            get {
                return taburcuTarihiField;
            }
            set {
                taburcuTarihiField = value;
            }
        }
        
        /// <remarks/>
        public int taburcuKodu {
            get {
                return taburcuKoduField;
            }
            set {
                taburcuKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dvo.WS_isGoremezlik2011.sgk.gov.tr")]
    public partial class IsKazasiRaporDVO {
        
        private string baslangicTarihiField;
        
        private string bitisTarihiField;
        
        private string raporDurumuField;
        
        private string isKontTarihiField;
        
        private string XXXXXXYatisTarihiField;
        
        private string XXXXXXCikisTarihiField;
        
        private string nuksField;
        
        private string yaraninTuruField;
        
        private string yaraninYeriField;
        
        private string taburcuTarihiField;
        
        private int taburcuKoduField;
        
        private string isKazasiTarihiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string baslangicTarihi {
            get {
                return baslangicTarihiField;
            }
            set {
                baslangicTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bitisTarihi {
            get {
                return bitisTarihiField;
            }
            set {
                bitisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string raporDurumu {
            get {
                return raporDurumuField;
            }
            set {
                raporDurumuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string isKontTarihi {
            get {
                return isKontTarihiField;
            }
            set {
                isKontTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string XXXXXXYatisTarihi {
            get {
                return XXXXXXYatisTarihiField;
            }
            set {
                XXXXXXYatisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string XXXXXXCikisTarihi {
            get {
                return XXXXXXCikisTarihiField;
            }
            set {
                XXXXXXCikisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string nuks {
            get {
                return nuksField;
            }
            set {
                nuksField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string yaraninTuru {
            get {
                return yaraninTuruField;
            }
            set {
                yaraninTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string yaraninYeri {
            get {
                return yaraninYeriField;
            }
            set {
                yaraninYeriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string taburcuTarihi {
            get {
                return taburcuTarihiField;
            }
            set {
                taburcuTarihiField = value;
            }
        }
        
        /// <remarks/>
        public int taburcuKodu {
            get {
                return taburcuKoduField;
            }
            set {
                taburcuKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string isKazasiTarihi {
            get {
                return isKazasiTarihiField;
            }
            set {
                isKazasiTarihiField = value;
            }
        }
    }
        
#endregion Methods

    }
}