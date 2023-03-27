
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
    public  partial class MHRSServis : TTObject
    {
        public static partial class WebMethods
        {
                    
        }
                    
#region Methods
        /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuAltKlinikVeHekimlerSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int ilKoduField;
        
        private int ilceKoduField;
        
        private bool ilceKoduFieldSpecified;
        
        private int kurumKoduField;
        
        private bool kurumKoduFieldSpecified;
        
        private int semtPoliklinikKoduField;
        
        private bool semtPoliklinikKoduFieldSpecified;
        
        private int klinikKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int IlKodu {
            get {
                return ilKoduField;
            }
            set {
                ilKoduField = value;
            }
        }
        
        /// <remarks/>
        public int IlceKodu {
            get {
                return ilceKoduField;
            }
            set {
                ilceKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IlceKoduSpecified {
            get {
                return ilceKoduFieldSpecified;
            }
            set {
                ilceKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int KurumKodu {
            get {
                return kurumKoduField;
            }
            set {
                kurumKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KurumKoduSpecified {
            get {
                return kurumKoduFieldSpecified;
            }
            set {
                kurumKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int SemtPoliklinikKodu {
            get {
                return semtPoliklinikKoduField;
            }
            set {
                semtPoliklinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SemtPoliklinikKoduSpecified {
            get {
                return semtPoliklinikKoduFieldSpecified;
            }
            set {
                semtPoliklinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class YetkilendirmeGirisBilgileriType {
        
        private long kullaniciKoduField;
        
        private string kullaniciSifreField;
        
        private int kulaniciTuruField;
        
        /// <remarks/>
        public long KullaniciKodu {
            get {
                return kullaniciKoduField;
            }
            set {
                kullaniciKoduField = value;
            }
        }
        
        /// <remarks/>
        public string KullaniciSifre {
            get {
                return kullaniciSifreField;
            }
            set {
                kullaniciSifreField = value;
            }
        }
        
        /// <remarks/>
        public int KulaniciTuru {
            get {
                return kulaniciTuruField;
            }
            set {
                kulaniciTuruField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuVatandasSorgulamaObjCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private VatandasBilgileriType vatandasBilgileriField;
        
        private RandevuVatandasSorgulamaObjCevapTypeVatandasRandevuBilgileri[] vatandasRandevuBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public VatandasBilgileriType VatandasBilgileri {
            get {
                return vatandasBilgileriField;
            }
            set {
                vatandasBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("VatandasRandevuBilgileri")]
        public RandevuVatandasSorgulamaObjCevapTypeVatandasRandevuBilgileri[] VatandasRandevuBilgileri {
            get {
                return vatandasRandevuBilgileriField;
            }
            set {
                vatandasRandevuBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class TemelCevapBilgileriType {
        
        private bool servisBasarisiField;
        
        private string servisZamaniField;
        
        private string aciklamaField;
        
        /// <remarks/>
        public bool ServisBasarisi {
            get {
                return servisBasarisiField;
            }
            set {
                servisBasarisiField = value;
            }
        }
        
        /// <remarks/>
        public string ServisZamani {
            get {
                return servisZamaniField;
            }
            set {
                servisZamaniField = value;
            }
        }
        
        /// <remarks/>
        public string Aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class VatandasBilgileriType {
        
        private string tCKimlikNoField;
        
        private string adField;
        
        private string soyadField;
        
        private VatandasIletisimBilgileriType vatandasIletisimBilgileriField;
        
        private int cinsiyetField;
        
        private string dogumTarihiField;
        
        private string dogumYeriField;
        
        private bool engelliField;
        
        private bool engelliFieldSpecified;
        
        private bool kimsesizField;
        
        private bool kimsesizFieldSpecified;
        
        /// <remarks/>
        public string TCKimlikNo {
            get {
                return tCKimlikNoField;
            }
            set {
                tCKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        public string Ad {
            get {
                return adField;
            }
            set {
                adField = value;
            }
        }
        
        /// <remarks/>
        public string Soyad {
            get {
                return soyadField;
            }
            set {
                soyadField = value;
            }
        }
        
        /// <remarks/>
        public VatandasIletisimBilgileriType VatandasIletisimBilgileri {
            get {
                return vatandasIletisimBilgileriField;
            }
            set {
                vatandasIletisimBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int Cinsiyet {
            get {
                return cinsiyetField;
            }
            set {
                cinsiyetField = value;
            }
        }
        
        /// <remarks/>
        public string DogumTarihi {
            get {
                return dogumTarihiField;
            }
            set {
                dogumTarihiField = value;
            }
        }
        
        /// <remarks/>
        public string DogumYeri {
            get {
                return dogumYeriField;
            }
            set {
                dogumYeriField = value;
            }
        }
        
        /// <remarks/>
        public bool Engelli {
            get {
                return engelliField;
            }
            set {
                engelliField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EngelliSpecified {
            get {
                return engelliFieldSpecified;
            }
            set {
                engelliFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public bool Kimsesiz {
            get {
                return kimsesizField;
            }
            set {
                kimsesizField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KimsesizSpecified {
            get {
                return kimsesizFieldSpecified;
            }
            set {
                kimsesizFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class VatandasIletisimBilgileriType {
        
        private TelefonIletisimBilgileriType[] telefonIletisimBilgileriField;
        
        private string emailField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TelefonIletisimBilgileri")]
        public TelefonIletisimBilgileriType[] TelefonIletisimBilgileri {
            get {
                return telefonIletisimBilgileriField;
            }
            set {
                telefonIletisimBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string Email {
            get {
                return emailField;
            }
            set {
                emailField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class TelefonIletisimBilgileriType {
        
        private string alanKoduField;
        
        private string telefonNoField;
        
        private int numaraTipiField;
        
        /// <remarks/>
        public string AlanKodu {
            get {
                return alanKoduField;
            }
            set {
                alanKoduField = value;
            }
        }
        
        /// <remarks/>
        public string TelefonNo {
            get {
                return telefonNoField;
            }
            set {
                telefonNoField = value;
            }
        }
        
        /// <remarks/>
        public int NumaraTipi {
            get {
                return numaraTipiField;
            }
            set {
                numaraTipiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class RandevuVatandasSorgulamaObjCevapTypeVatandasRandevuBilgileri {
        
        private string randevuHrnField;
        
        private string tarihField;
        
        private string kurumAdField;
        
        private string klinikAdiField;
        
        private string eskiAltKlinikAdiField;
        
        private string yeniAltKlinikAdiField;
        
        private string hekimAdiSoyadiField;
        
        private int kayitDurumKoduField;
        
        private int durumKoduField;
        
        /// <remarks/>
        public string RandevuHrn {
            get {
                return randevuHrnField;
            }
            set {
                randevuHrnField = value;
            }
        }
        
        /// <remarks/>
        public string Tarih {
            get {
                return tarihField;
            }
            set {
                tarihField = value;
            }
        }
        
        /// <remarks/>
        public string KurumAd {
            get {
                return kurumAdField;
            }
            set {
                kurumAdField = value;
            }
        }
        
        /// <remarks/>
        public string KlinikAdi {
            get {
                return klinikAdiField;
            }
            set {
                klinikAdiField = value;
            }
        }
        
        /// <remarks/>
        public string EskiAltKlinikAdi {
            get {
                return eskiAltKlinikAdiField;
            }
            set {
                eskiAltKlinikAdiField = value;
            }
        }
        
        /// <remarks/>
        public string YeniAltKlinikAdi {
            get {
                return yeniAltKlinikAdiField;
            }
            set {
                yeniAltKlinikAdiField = value;
            }
        }
        
        /// <remarks/>
        public string HekimAdiSoyadi {
            get {
                return hekimAdiSoyadiField;
            }
            set {
                hekimAdiSoyadiField = value;
            }
        }
        
        /// <remarks/>
        public int KayitDurumKodu {
            get {
                return kayitDurumKoduField;
            }
            set {
                kayitDurumKoduField = value;
            }
        }
        
        /// <remarks/>
        public int DurumKodu {
            get {
                return durumKoduField;
            }
            set {
                durumKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuVatandasSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private string tCKimlikNoField;
        
        private string adField;
        
        private string soyadField;
        
        private string dogumTarihiField;
        
        private int cinsiyetField;
        
        private bool cinsiyetFieldSpecified;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string TCKimlikNo {
            get {
                return tCKimlikNoField;
            }
            set {
                tCKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        public string Ad {
            get {
                return adField;
            }
            set {
                adField = value;
            }
        }
        
        /// <remarks/>
        public string Soyad {
            get {
                return soyadField;
            }
            set {
                soyadField = value;
            }
        }
        
        /// <remarks/>
        public string DogumTarihi {
            get {
                return dogumTarihiField;
            }
            set {
                dogumTarihiField = value;
            }
        }
        
        /// <remarks/>
        public int Cinsiyet {
            get {
                return cinsiyetField;
            }
            set {
                cinsiyetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CinsiyetSpecified {
            get {
                return cinsiyetFieldSpecified;
            }
            set {
                cinsiyetFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumBilgileriType {
        
        private int kurumKoduField;
        
        private bool kurumKoduFieldSpecified;
        
        private long islemYapanKisiTCNoField;
        
        private string gonderenBirimField;
        
        /// <remarks/>
        public int KurumKodu {
            get {
                return kurumKoduField;
            }
            set {
                kurumKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KurumKoduSpecified {
            get {
                return kurumKoduFieldSpecified;
            }
            set {
                kurumKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public long IslemYapanKisiTCNo {
            get {
                return islemYapanKisiTCNoField;
            }
            set {
                islemYapanKisiTCNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string GonderenBirim {
            get {
                return gonderenBirimField;
            }
            set {
                gonderenBirimField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class YesilListeVatandasSilmeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class YesilListeVatandasSilmeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int klinikKoduField;
        
        private string tCKimlikNoField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string TCKimlikNo {
            get {
                return tCKimlikNoField;
            }
            set {
                tCKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumIstisnaEklemeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private IstisnaDetayBilgileriType[] istisnaDetayBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IstisnaDetayBilgileri")]
        public IstisnaDetayBilgileriType[] IstisnaDetayBilgileri {
            get {
                return istisnaDetayBilgileriField;
            }
            set {
                istisnaDetayBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class IstisnaDetayBilgileriType {
        
        private long istisnaIdField;
        
        private int kurumKoduField;
        
        private int klinikKoduField;
        
        private string hekimKoduField;
        
        private TarihBilgileriType tarihBilgileriField;
        
        private int aksiyonKoduField;
        
        private string aciklamaField;
        
        private string emailField;
        
        private int istisnaTipiField;
        
        private int istisnaDurumKoduField;
        
        private string redNedeniField;
        
        /// <remarks/>
        public long IstisnaId {
            get {
                return istisnaIdField;
            }
            set {
                istisnaIdField = value;
            }
        }
        
        /// <remarks/>
        public int KurumKodu {
            get {
                return kurumKoduField;
            }
            set {
                kurumKoduField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int AksiyonKodu {
            get {
                return aksiyonKoduField;
            }
            set {
                aksiyonKoduField = value;
            }
        }
        
        /// <remarks/>
        public string Aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
        
        /// <remarks/>
        public string Email {
            get {
                return emailField;
            }
            set {
                emailField = value;
            }
        }
        
        /// <remarks/>
        public int istisnaTipi {
            get {
                return istisnaTipiField;
            }
            set {
                istisnaTipiField = value;
            }
        }
        
        /// <remarks/>
        public int IstisnaDurumKodu {
            get {
                return istisnaDurumKoduField;
            }
            set {
                istisnaDurumKoduField = value;
            }
        }
        
        /// <remarks/>
        public string RedNedeni {
            get {
                return redNedeniField;
            }
            set {
                redNedeniField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class TarihBilgileriType {
        
        private string baslangicTarihiField;
        
        private string bitisTarihiField;
        
        /// <remarks/>
        public string BaslangicTarihi {
            get {
                return baslangicTarihiField;
            }
            set {
                baslangicTarihiField = value;
            }
        }
        
        /// <remarks/>
        public string BitisTarihi {
            get {
                return bitisTarihiField;
            }
            set {
                bitisTarihiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class IstisnaDokumanType {
        
        private string istisnaDokumanAdiField;
        
        private byte[] istisnaDokumanField;
        
        /// <remarks/>
        public string IstisnaDokumanAdi {
            get {
                return istisnaDokumanAdiField;
            }
            set {
                istisnaDokumanAdiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] IstisnaDokuman {
            get {
                return istisnaDokumanField;
            }
            set {
                istisnaDokumanField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumIstisnaEklemeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private string hekimKoduField;
        
        private int klinikKoduField;
        
        private TarihBilgileriType tarihBilgileriField;
        
        private int aksiyonKoduField;
        
        private string aciklamaField;
        
        private string emailField;
        
        private TelefonIletisimBilgileriType telefonIletisimBilgileriField;
        
        private IstisnaDokumanType istisnaDokumanBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int AksiyonKodu {
            get {
                return aksiyonKoduField;
            }
            set {
                aksiyonKoduField = value;
            }
        }
        
        /// <remarks/>
        public string Aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
        
        /// <remarks/>
        public string Email {
            get {
                return emailField;
            }
            set {
                emailField = value;
            }
        }
        
        /// <remarks/>
        public TelefonIletisimBilgileriType TelefonIletisimBilgileri {
            get {
                return telefonIletisimBilgileriField;
            }
            set {
                telefonIletisimBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public IstisnaDokumanType IstisnaDokumanBilgileri {
            get {
                return istisnaDokumanBilgileriField;
            }
            set {
                istisnaDokumanBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class TelefonTipiBilgileriType {
        
        private int numaraTipiField;
        
        private string aciklamaField;
        
        /// <remarks/>
        public int NumaraTipi {
            get {
                return numaraTipiField;
            }
            set {
                numaraTipiField = value;
            }
        }
        
        /// <remarks/>
        public string Aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class TelefonTipiSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private TelefonTipiBilgileriType[] telefonTipiBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TelefonTipiBilgileri")]
        public TelefonTipiBilgileriType[] TelefonTipiBilgileri {
            get {
                return telefonTipiBilgileriField;
            }
            set {
                telefonTipiBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class TelefonTipiSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumHekimEklemeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumHekimEklemeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int klinikKoduField;
        
        private string hekimKoduField;
        
        private bool geciciGorevliField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public bool GeciciGorevli {
            get {
                return geciciGorevliField;
            }
            set {
                geciciGorevliField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumHekimSilmeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumHekimSilmeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int klinikKoduField;
        
        private string hekimKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumIstisnaSilmeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private long istisnaIdField;
        
        private bool istisnaIdFieldSpecified;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public long IstisnaId {
            get {
                return istisnaIdField;
            }
            set {
                istisnaIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IstisnaIdSpecified {
            get {
                return istisnaIdFieldSpecified;
            }
            set {
                istisnaIdFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumIstisnaSilmeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private long istisnaIdField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public long IstisnaId {
            get {
                return istisnaIdField;
            }
            set {
                istisnaIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelGuncellemeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private long taslakCetvelIdField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public long TaslakCetvelId {
            get {
                return taslakCetvelIdField;
            }
            set {
                taslakCetvelIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelGuncellemeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private long taslakCetvelIdField;
        
        private CetvelDetayBilgileriType cetvelDetayBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public long TaslakCetvelId {
            get {
                return taslakCetvelIdField;
            }
            set {
                taslakCetvelIdField = value;
            }
        }
        
        /// <remarks/>
        public CetvelDetayBilgileriType CetvelDetayBilgileri {
            get {
                return cetvelDetayBilgileriField;
            }
            set {
                cetvelDetayBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class CetvelDetayBilgileriType {
        
        private HekimKlinikBilgileriType hekimKlinikBilgileriField;
        
        private int aksiyonKoduField;
        
        private int tedaviSuresiField;
        
        private bool tedaviSuresiFieldSpecified;
        
        private int slotBasinaDusenHastaSayisiField;
        
        private bool slotBasinaDusenHastaSayisiFieldSpecified;
        
        private TarihBilgileriType tarihBilgileriField;
        
        /// <remarks/>
        public HekimKlinikBilgileriType HekimKlinikBilgileri {
            get {
                return hekimKlinikBilgileriField;
            }
            set {
                hekimKlinikBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int AksiyonKodu {
            get {
                return aksiyonKoduField;
            }
            set {
                aksiyonKoduField = value;
            }
        }
        
        /// <remarks/>
        public int TedaviSuresi {
            get {
                return tedaviSuresiField;
            }
            set {
                tedaviSuresiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TedaviSuresiSpecified {
            get {
                return tedaviSuresiFieldSpecified;
            }
            set {
                tedaviSuresiFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int SlotBasinaDusenHastaSayisi {
            get {
                return slotBasinaDusenHastaSayisiField;
            }
            set {
                slotBasinaDusenHastaSayisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SlotBasinaDusenHastaSayisiSpecified {
            get {
                return slotBasinaDusenHastaSayisiFieldSpecified;
            }
            set {
                slotBasinaDusenHastaSayisiFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class HekimKlinikBilgileriType {
        
        private HekimBilgileriType hekimBilgileriField;
        
        private int klinikKoduField;
        
        private string klinikAdiField;
        
        private AltKlinikBilgileriType altKlinikBilgileriField;
        
        /// <remarks/>
        public HekimBilgileriType HekimBilgileri {
            get {
                return hekimBilgileriField;
            }
            set {
                hekimBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string KlinikAdi {
            get {
                return klinikAdiField;
            }
            set {
                klinikAdiField = value;
            }
        }
        
        /// <remarks/>
        public AltKlinikBilgileriType AltKlinikBilgileri {
            get {
                return altKlinikBilgileriField;
            }
            set {
                altKlinikBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class HekimBilgileriType {
        
        private string hekimKoduField;
        
        private string adField;
        
        private string soyadField;
        
        private int cinsiyetField;
        
        private bool cinsiyetFieldSpecified;
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public string Ad {
            get {
                return adField;
            }
            set {
                adField = value;
            }
        }
        
        /// <remarks/>
        public string Soyad {
            get {
                return soyadField;
            }
            set {
                soyadField = value;
            }
        }
        
        /// <remarks/>
        public int Cinsiyet {
            get {
                return cinsiyetField;
            }
            set {
                cinsiyetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CinsiyetSpecified {
            get {
                return cinsiyetFieldSpecified;
            }
            set {
                cinsiyetFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class AltKlinikBilgileriType {
        
        private int altKlinikKoduField;
        
        private string altKlinikAdiField;
        
        /// <remarks/>
        public int AltKlinikKodu {
            get {
                return altKlinikKoduField;
            }
            set {
                altKlinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string AltKlinikAdi {
            get {
                return altKlinikAdiField;
            }
            set {
                altKlinikAdiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumAltKlinikSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private AltKlinikBilgileriType[] altKlinikBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AltKlinikBilgileri")]
        public AltKlinikBilgileriType[] AltKlinikBilgileri {
            get {
                return altKlinikBilgileriField;
            }
            set {
                altKlinikBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumAltKlinikSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int klinikKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKesinCetvelGuncellemeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private long kesinCetvelIdField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public long KesinCetvelId {
            get {
                return kesinCetvelIdField;
            }
            set {
                kesinCetvelIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKesinCetvelGuncellemeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private long kesinCetvelIdField;
        
        private CetvelDetayBilgileriType cetvelDetayBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public long KesinCetvelId {
            get {
                return kesinCetvelIdField;
            }
            set {
                kesinCetvelIdField = value;
            }
        }
        
        /// <remarks/>
        public CetvelDetayBilgileriType CetvelDetayBilgileri {
            get {
                return cetvelDetayBilgileriField;
            }
            set {
                cetvelDetayBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class TaslakCetvelCevapType {
        
        private string referansNoField;
        
        private string aciklamaField;
        
        private long[] taslakCetvelIdField;
        
        /// <remarks/>
        public string ReferansNo {
            get {
                return referansNoField;
            }
            set {
                referansNoField = value;
            }
        }
        
        /// <remarks/>
        public string Aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TaslakCetvelId")]
        public long[] TaslakCetvelId {
            get {
                return taslakCetvelIdField;
            }
            set {
                taslakCetvelIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelEklemeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private TaslakCetvelCevapType[] taslakCetvelCevapField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TaslakCetvelCevap")]
        public TaslakCetvelCevapType[] TaslakCetvelCevap {
            get {
                return taslakCetvelCevapField;
            }
            set {
                taslakCetvelCevapField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class TaslakCetvelBilgileriType {
        
        private string referansNoField;
        
        private CetvelDetayBilgileriType cetvelDetayBilgileriField;
        
        /// <remarks/>
        public string ReferansNo {
            get {
                return referansNoField;
            }
            set {
                referansNoField = value;
            }
        }
        
        /// <remarks/>
        public CetvelDetayBilgileriType CetvelDetayBilgileri {
            get {
                return cetvelDetayBilgileriField;
            }
            set {
                cetvelDetayBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelEklemeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private TaslakCetvelBilgileriType[] taslakCetvelBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TaslakCetvelBilgileri")]
        public TaslakCetvelBilgileriType[] TaslakCetvelBilgileri {
            get {
                return taslakCetvelBilgileriField;
            }
            set {
                taslakCetvelBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelTarihleriGuncelleCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelTarihleriGuncelleTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private long taslakCetvelIdField;
        
        private TarihBilgileriType tarihBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public long TaslakCetvelId {
            get {
                return taslakCetvelIdField;
            }
            set {
                taslakCetvelIdField = value;
            }
        }
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumSemtPoliklinikSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KurumType[] semtPoliklinikleriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SemtPoliklinikleri")]
        public KurumType[] SemtPoliklinikleri {
            get {
                return semtPoliklinikleriField;
            }
            set {
                semtPoliklinikleriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumType {
        
        private int kurumKoduField;
        
        private string kurumAdField;
        
        /// <remarks/>
        public int KurumKodu {
            get {
                return kurumKoduField;
            }
            set {
                kurumKoduField = value;
            }
        }
        
        /// <remarks/>
        public string KurumAd {
            get {
                return kurumAdField;
            }
            set {
                kurumAdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumSemtPoliklinikSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumBelirsizRandevuSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int klinikKoduField;
        
        private bool klinikKoduFieldSpecified;
        
        private string hekimKoduField;
        
        private TarihBilgileriType tarihBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KlinikKoduSpecified {
            get {
                return klinikKoduFieldSpecified;
            }
            set {
                klinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumAdAdresType {
        
        private string kurumAdField;
        
        private string kurumAdresiField;
        
        /// <remarks/>
        public string KurumAd {
            get {
                return kurumAdField;
            }
            set {
                kurumAdField = value;
            }
        }
        
        /// <remarks/>
        public string KurumAdresi {
            get {
                return kurumAdresiField;
            }
            set {
                kurumAdresiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumBilgileriSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KurumAdAdresType[] kurumAdAdresField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KurumAdAdres")]
        public KurumAdAdresType[] KurumAdAdres {
            get {
                return kurumAdAdresField;
            }
            set {
                kurumAdAdresField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumBilgileriSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int ilKoduField;
        
        private bool ilKoduFieldSpecified;
        
        private int ilceKoduField;
        
        private bool ilceKoduFieldSpecified;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int IlKodu {
            get {
                return ilKoduField;
            }
            set {
                ilKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IlKoduSpecified {
            get {
                return ilKoduFieldSpecified;
            }
            set {
                ilKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int IlceKodu {
            get {
                return ilceKoduField;
            }
            set {
                ilceKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IlceKoduSpecified {
            get {
                return ilceKoduFieldSpecified;
            }
            set {
                ilceKoduFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class taslakKesinMapType {
        
        private long taslakCetvelIdField;
        
        private long kesinCetvelIdField;
        
        /// <remarks/>
        public long TaslakCetvelId {
            get {
                return taslakCetvelIdField;
            }
            set {
                taslakCetvelIdField = value;
            }
        }
        
        /// <remarks/>
        public long KesinCetvelId {
            get {
                return kesinCetvelIdField;
            }
            set {
                kesinCetvelIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelKesinlestirmeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private taslakKesinMapType[] taslakKesinMapField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("taslakKesinMap", IsNullable=true)]
        public taslakKesinMapType[] taslakKesinMap {
            get {
                return taslakKesinMapField;
            }
            set {
                taslakKesinMapField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelKesinlestirmeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private TarihBilgileriType tarihBilgileriField;
        
        private HekimBilgileriType hekimBilgileriField;
        
        private int klinikKoduField;
        
        private bool klinikKoduFieldSpecified;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public HekimBilgileriType HekimBilgileri {
            get {
                return hekimBilgileriField;
            }
            set {
                hekimBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KlinikKoduSpecified {
            get {
                return klinikKoduFieldSpecified;
            }
            set {
                klinikKoduFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KlinikBilgileriSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KlinikBilgileriType[] klinikBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KlinikBilgileri")]
        public KlinikBilgileriType[] KlinikBilgileri {
            get {
                return klinikBilgileriField;
            }
            set {
                klinikBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KlinikBilgileriType {
        
        private int klinikKoduField;
        
        private string klinikAdiField;
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string KlinikAdi {
            get {
                return klinikAdiField;
            }
            set {
                klinikAdiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KlinikBilgileriSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class YesilListeVatandasEklemeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class YesilListeVatandasEklemeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private string tCKimlikNoField;
        
        private int klinikKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string TCKimlikNo {
            get {
                return tCKimlikNoField;
            }
            set {
                tCKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KskRandevuVatandasSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private VatandasBilgileriType vatandasBilgileriField;
        
        private KskRandevuVatandasSorgulamaCevapTypeKskVatandasRandevuBilgileri[] kskVatandasRandevuBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public VatandasBilgileriType VatandasBilgileri {
            get {
                return vatandasBilgileriField;
            }
            set {
                vatandasBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KskVatandasRandevuBilgileri")]
        public KskRandevuVatandasSorgulamaCevapTypeKskVatandasRandevuBilgileri[] KskVatandasRandevuBilgileri {
            get {
                return kskVatandasRandevuBilgileriField;
            }
            set {
                kskVatandasRandevuBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class KskRandevuVatandasSorgulamaCevapTypeKskVatandasRandevuBilgileri {
        
        private string randevuHrnField;
        
        private string tarihField;
        
        private int kurumKoduField;
        
        private string kurumAdField;
        
        private int klinikKoduField;
        
        private string klinikAdiField;
        
        private string eskiAltKlinikAdiField;
        
        private string yeniAltKlinikAdiField;
        
        private string hekimKoduField;
        
        private string hekimAdiSoyadiField;
        
        private int kayitDurumKoduField;
        
        private int durumKoduField;
        
        private string randevuNotuField;
        
        /// <remarks/>
        public string RandevuHrn {
            get {
                return randevuHrnField;
            }
            set {
                randevuHrnField = value;
            }
        }
        
        /// <remarks/>
        public string Tarih {
            get {
                return tarihField;
            }
            set {
                tarihField = value;
            }
        }
        
        /// <remarks/>
        public int KurumKodu {
            get {
                return kurumKoduField;
            }
            set {
                kurumKoduField = value;
            }
        }
        
        /// <remarks/>
        public string KurumAd {
            get {
                return kurumAdField;
            }
            set {
                kurumAdField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string KlinikAdi {
            get {
                return klinikAdiField;
            }
            set {
                klinikAdiField = value;
            }
        }
        
        /// <remarks/>
        public string EskiAltKlinikAdi {
            get {
                return eskiAltKlinikAdiField;
            }
            set {
                eskiAltKlinikAdiField = value;
            }
        }
        
        /// <remarks/>
        public string YeniAltKlinikAdi {
            get {
                return yeniAltKlinikAdiField;
            }
            set {
                yeniAltKlinikAdiField = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public string HekimAdiSoyadi {
            get {
                return hekimAdiSoyadiField;
            }
            set {
                hekimAdiSoyadiField = value;
            }
        }
        
        /// <remarks/>
        public int KayitDurumKodu {
            get {
                return kayitDurumKoduField;
            }
            set {
                kayitDurumKoduField = value;
            }
        }
        
        /// <remarks/>
        public int DurumKodu {
            get {
                return durumKoduField;
            }
            set {
                durumKoduField = value;
            }
        }
        
        /// <remarks/>
        public string RandevuNotu {
            get {
                return randevuNotuField;
            }
            set {
                randevuNotuField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KskRandevuVatandasSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private string tCKimlikNoField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string TCKimlikNo {
            get {
                return tCKimlikNoField;
            }
            set {
                tCKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKlinikSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KlinikBilgileriType[] klinikBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KlinikBilgileri")]
        public KlinikBilgileriType[] KlinikBilgileri {
            get {
                return klinikBilgileriField;
            }
            set {
                klinikBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKlinikSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class IstisnaOnayCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class IstisnaOnayTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private long istisnaIdField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public long IstisnaId {
            get {
                return istisnaIdField;
            }
            set {
                istisnaIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KlinikHekimBilgileriType {
        
        private int klinikKoduField;
        
        private string klinikAdiField;
        
        private HekimBilgileriType[] hekimBilgileriField;
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string KlinikAdi {
            get {
                return klinikAdiField;
            }
            set {
                klinikAdiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HekimBilgileri")]
        public HekimBilgileriType[] HekimBilgileri {
            get {
                return hekimBilgileriField;
            }
            set {
                hekimBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumHekimSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KlinikHekimBilgileriType[] klinikHekimBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KlinikHekimBilgileri")]
        public KlinikHekimBilgileriType[] KlinikHekimBilgileri {
            get {
                return klinikHekimBilgileriField;
            }
            set {
                klinikHekimBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumHekimSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int klinikKoduField;
        
        private bool klinikKoduFieldSpecified;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KlinikKoduSpecified {
            get {
                return klinikKoduFieldSpecified;
            }
            set {
                klinikKoduFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumAltKlinikEklemeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private int altKlinikKoduField;
        
        private bool altKlinikKoduFieldSpecified;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int AltKlinikKodu {
            get {
                return altKlinikKoduField;
            }
            set {
                altKlinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AltKlinikKoduSpecified {
            get {
                return altKlinikKoduFieldSpecified;
            }
            set {
                altKlinikKoduFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumAltKlinikEklemeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int klinikKoduField;
        
        private string altKlinikAdiField;
        
        private bool goruntuluRandevuField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string AltKlinikAdi {
            get {
                return altKlinikAdiField;
            }
            set {
                altKlinikAdiField = value;
            }
        }

        /// <remarks/>
        public bool GoruntuluRandevu
        {
            get
            {
                return goruntuluRandevuField;
            }
            set
            {
                goruntuluRandevuField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuNotuDuzenlemeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuNotuDuzenlemeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private string randevuHrnField;
        
        private string randevuNotuField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string RandevuHrn {
            get {
                return randevuHrnField;
            }
            set {
                randevuHrnField = value;
            }
        }
        
        /// <remarks/>
        public string RandevuNotu {
            get {
                return randevuNotuField;
            }
            set {
                randevuNotuField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumIstisnaSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private IstisnaDetayBilgileriType[] istisnaDetayBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IstisnaDetayBilgileri")]
        public IstisnaDetayBilgileriType[] IstisnaDetayBilgileri {
            get {
                return istisnaDetayBilgileriField;
            }
            set {
                istisnaDetayBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumIstisnaSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private TarihBilgileriType tarihBilgileriField;
        
        private int klinikKoduField;
        
        private bool klinikKoduFieldSpecified;
        
        private HekimBilgileriType hekimBilgileriField;
        
        private int aksiyonKoduField;
        
        private bool aksiyonKoduFieldSpecified;
        
        private int istisnaDurumKoduField;
        
        private bool istisnaDurumKoduFieldSpecified;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KlinikKoduSpecified {
            get {
                return klinikKoduFieldSpecified;
            }
            set {
                klinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public HekimBilgileriType HekimBilgileri {
            get {
                return hekimBilgileriField;
            }
            set {
                hekimBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int AksiyonKodu {
            get {
                return aksiyonKoduField;
            }
            set {
                aksiyonKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AksiyonKoduSpecified {
            get {
                return aksiyonKoduFieldSpecified;
            }
            set {
                aksiyonKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int IstisnaDurumKodu {
            get {
                return istisnaDurumKoduField;
            }
            set {
                istisnaDurumKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IstisnaDurumKoduSpecified {
            get {
                return istisnaDurumKoduFieldSpecified;
            }
            set {
                istisnaDurumKoduFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumIsKuraliEklemeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private int isKuraliIdField;
        
        private bool isKuraliIdFieldSpecified;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int IsKuraliId {
            get {
                return isKuraliIdField;
            }
            set {
                isKuraliIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsKuraliIdSpecified {
            get {
                return isKuraliIdFieldSpecified;
            }
            set {
                isKuraliIdFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumIsKuraliEklemeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int klinikKoduField;
        
        private bool klinikKoduFieldSpecified;
        
        private string hekimKoduField;
        
        private int isKuraliTipiKoduField;
        
        private int zamanKriteriField;
        
        private bool zamanKriteriFieldSpecified;
        
        private string degerField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KlinikKoduSpecified {
            get {
                return klinikKoduFieldSpecified;
            }
            set {
                klinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public int IsKuraliTipiKodu {
            get {
                return isKuraliTipiKoduField;
            }
            set {
                isKuraliTipiKoduField = value;
            }
        }
        
        /// <remarks/>
        public int ZamanKriteri {
            get {
                return zamanKriteriField;
            }
            set {
                zamanKriteriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ZamanKriteriSpecified {
            get {
                return zamanKriteriFieldSpecified;
            }
            set {
                zamanKriteriFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Deger {
            get {
                return degerField;
            }
            set {
                degerField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelSilmeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private long[] taslakCetvelIdField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TaslakCetvelId")]
        public long[] TaslakCetvelId {
            get {
                return taslakCetvelIdField;
            }
            set {
                taslakCetvelIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelSilmeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private long[] taslakCetvelIdField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TaslakCetvelId")]
        public long[] TaslakCetvelId {
            get {
                return taslakCetvelIdField;
            }
            set {
                taslakCetvelIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class DurumKoduBilgileriType {
        
        private int durumKoduField;
        
        private string aciklamaField;
        
        /// <remarks/>
        public int DurumKodu {
            get {
                return durumKoduField;
            }
            set {
                durumKoduField = value;
            }
        }
        
        /// <remarks/>
        public string Aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class DurumKoduSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private DurumKoduBilgileriType[] durumKoduBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DurumKoduBilgileri")]
        public DurumKoduBilgileriType[] DurumKoduBilgileri {
            get {
                return durumKoduBilgileriField;
            }
            set {
                durumKoduBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class DurumKoduSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class YesilListeVatandasOnaylamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class YesilListeVatandasOnaylamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private string tCKimlikNoField;
        
        private int klinikKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string TCKimlikNo {
            get {
                return tCKimlikNoField;
            }
            set {
                tCKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuXXXXXXVeSemtPoliklinikleriSorgulamaObjCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KurumType[] XXXXXXlerField;
        
        private KurumType[] semtPoliklinikleriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("XXXXXXler")]
        public KurumType[] XXXXXXler {
            get {
                return XXXXXXlerField;
            }
            set {
                XXXXXXlerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SemtPoliklinikleri")]
        public KurumType[] SemtPoliklinikleri {
            get {
                return semtPoliklinikleriField;
            }
            set {
                semtPoliklinikleriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuXXXXXXVeSemtPoliklinikleriSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int ilKoduField;
        
        private int ilceKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int IlKodu {
            get {
                return ilKoduField;
            }
            set {
                ilKoduField = value;
            }
        }
        
        /// <remarks/>
        public int IlceKodu {
            get {
                return ilceKoduField;
            }
            set {
                ilceKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuDurumSonucType {
        
        private string randevuHrnField;
        
        private bool guncellemeBasarisiField;
        
        private string hataKoduField;
        
        private string aciklamaField;
        
        /// <remarks/>
        public string RandevuHrn {
            get {
                return randevuHrnField;
            }
            set {
                randevuHrnField = value;
            }
        }
        
        /// <remarks/>
        public bool GuncellemeBasarisi {
            get {
                return guncellemeBasarisiField;
            }
            set {
                guncellemeBasarisiField = value;
            }
        }
        
        /// <remarks/>
        public string HataKodu {
            get {
                return hataKoduField;
            }
            set {
                hataKoduField = value;
            }
        }
        
        /// <remarks/>
        public string Aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuDurumGuncelleCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private RandevuDurumSonucType[] randevuDurumSonucField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RandevuDurumSonuc")]
        public RandevuDurumSonucType[] RandevuDurumSonuc {
            get {
                return randevuDurumSonucField;
            }
            set {
                randevuDurumSonucField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuDurumGuncelleTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private RandevuDurumGuncelleTalepTypeRandevuBilgileri[] randevuBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RandevuBilgileri")]
        public RandevuDurumGuncelleTalepTypeRandevuBilgileri[] RandevuBilgileri {
            get {
                return randevuBilgileriField;
            }
            set {
                randevuBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class RandevuDurumGuncelleTalepTypeRandevuBilgileri {
        
        private string randevuHrnField;
        
        private int durumKoduField;
        
        private string gelisZamaniField;
        
        private string randevuGerceklesmeZamaniField;
        
        /// <remarks/>
        public string RandevuHrn {
            get {
                return randevuHrnField;
            }
            set {
                randevuHrnField = value;
            }
        }
        
        /// <remarks/>
        public int DurumKodu {
            get {
                return durumKoduField;
            }
            set {
                durumKoduField = value;
            }
        }
        
        /// <remarks/>
        public string GelisZamani {
            get {
                return gelisZamaniField;
            }
            set {
                gelisZamaniField = value;
            }
        }
        
        /// <remarks/>
        public string RandevuGerceklesmeZamani {
            get {
                return randevuGerceklesmeZamaniField;
            }
            set {
                randevuGerceklesmeZamaniField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumBazliKumulatifVeriBilgisiType {
        
        private TarihBilgileriType tarihBilgileriField;
        
        private int kurumKoduField;
        
        private int gerceklesenRandevuSayisiField;
        
        private int gerceklesmeyenRandevuSayisiField;
        
        private int belirsizRandevuSayisiField;
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KurumKodu {
            get {
                return kurumKoduField;
            }
            set {
                kurumKoduField = value;
            }
        }
        
        /// <remarks/>
        public int GerceklesenRandevuSayisi {
            get {
                return gerceklesenRandevuSayisiField;
            }
            set {
                gerceklesenRandevuSayisiField = value;
            }
        }
        
        /// <remarks/>
        public int GerceklesmeyenRandevuSayisi {
            get {
                return gerceklesmeyenRandevuSayisiField;
            }
            set {
                gerceklesmeyenRandevuSayisiField = value;
            }
        }
        
        /// <remarks/>
        public int BelirsizRandevuSayisi {
            get {
                return belirsizRandevuSayisiField;
            }
            set {
                belirsizRandevuSayisiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKumulatifVeriSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KurumBazliKumulatifVeriBilgisiType[] kurumBazliKumulatifVeriBilgisiField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KurumBazliKumulatifVeriBilgisi")]
        public KurumBazliKumulatifVeriBilgisiType[] KurumBazliKumulatifVeriBilgisi {
            get {
                return kurumBazliKumulatifVeriBilgisiField;
            }
            set {
                kurumBazliKumulatifVeriBilgisiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKumulatifVeriSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private TarihBilgileriType tarihBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKlinikSilmeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKlinikSilmeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int klinikKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class IsKuraliTipiType {
        
        private int isKuraliTipiKoduField;
        
        private string aciklamaField;
        
        /// <remarks/>
        public int IsKuraliTipiKodu {
            get {
                return isKuraliTipiKoduField;
            }
            set {
                isKuraliTipiKoduField = value;
            }
        }
        
        /// <remarks/>
        public string Aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class IsKuraliTipiSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private IsKuraliTipiType[] isKuraliTipiField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IsKuraliTipi")]
        public IsKuraliTipiType[] IsKuraliTipi {
            get {
                return isKuraliTipiField;
            }
            set {
                isKuraliTipiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class IsKuraliTipiSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumRandevuSorgulamaObjCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KurumRandevuSorgulamaObjCevapTypeKurumRandevuBilgileri[] kurumRandevuBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KurumRandevuBilgileri")]
        public KurumRandevuSorgulamaObjCevapTypeKurumRandevuBilgileri[] KurumRandevuBilgileri {
            get {
                return kurumRandevuBilgileriField;
            }
            set {
                kurumRandevuBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class KurumRandevuSorgulamaObjCevapTypeKurumRandevuBilgileri {
        
        private string randevuHrnField;
        
        private TarihBilgileriType tarihBilgileriField;
        
        private string kurumAdField;
        
        private KlinikBilgileriType klinikBilgileriField;
        
        private int altKlinikKoduField;
        
        private string eskiAltKlinikAdiField;
        
        private string yeniAltKlinikAdiField;
        
        private string hekimKoduField;
        
        private string hekimAdiSoyadiField;
        
        private long hastaTCKimlikNoField;
        
        private string hastaAdiField;
        
        private string hastaSoyadiField;
        
        private string hastaDogumTarihiField;
        
        private int cinsiyetField;
        
        private TelefonIletisimBilgileriType[] vatandasTelefonBilgileriField;
        
        private int kayitDurumKoduField;
        
        private int durumKoduField;
        
        private bool refakatciIstiyormuField;
        
        private bool engelliField;
        
        private bool kimsesizField;
        
        private bool yuksekRiskliGebeField;
        
        private int randevuTuruField;
        
        private string randevuNotuField;
        
        private bool sanalTCField;
        
        private string eklenmeZamaniField;
        
        private int ekleyenKullaniciTipiField;
        
        /// <remarks/>
        public string RandevuHrn {
            get {
                return randevuHrnField;
            }
            set {
                randevuHrnField = value;
            }
        }
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string KurumAd {
            get {
                return kurumAdField;
            }
            set {
                kurumAdField = value;
            }
        }
        
        /// <remarks/>
        public KlinikBilgileriType KlinikBilgileri {
            get {
                return klinikBilgileriField;
            }
            set {
                klinikBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int AltKlinikKodu {
            get {
                return altKlinikKoduField;
            }
            set {
                altKlinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string EskiAltKlinikAdi {
            get {
                return eskiAltKlinikAdiField;
            }
            set {
                eskiAltKlinikAdiField = value;
            }
        }
        
        /// <remarks/>
        public string YeniAltKlinikAdi {
            get {
                return yeniAltKlinikAdiField;
            }
            set {
                yeniAltKlinikAdiField = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public string HekimAdiSoyadi {
            get {
                return hekimAdiSoyadiField;
            }
            set {
                hekimAdiSoyadiField = value;
            }
        }
        
        /// <remarks/>
        public long HastaTCKimlikNo {
            get {
                return hastaTCKimlikNoField;
            }
            set {
                hastaTCKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        public string HastaAdi {
            get {
                return hastaAdiField;
            }
            set {
                hastaAdiField = value;
            }
        }
        
        /// <remarks/>
        public string HastaSoyadi {
            get {
                return hastaSoyadiField;
            }
            set {
                hastaSoyadiField = value;
            }
        }
        
        /// <remarks/>
        public string HastaDogumTarihi {
            get {
                return hastaDogumTarihiField;
            }
            set {
                hastaDogumTarihiField = value;
            }
        }
        
        /// <remarks/>
        public int Cinsiyet {
            get {
                return cinsiyetField;
            }
            set {
                cinsiyetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("VatandasTelefonBilgileri")]
        public TelefonIletisimBilgileriType[] VatandasTelefonBilgileri {
            get {
                return vatandasTelefonBilgileriField;
            }
            set {
                vatandasTelefonBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KayitDurumKodu {
            get {
                return kayitDurumKoduField;
            }
            set {
                kayitDurumKoduField = value;
            }
        }
        
        /// <remarks/>
        public int DurumKodu {
            get {
                return durumKoduField;
            }
            set {
                durumKoduField = value;
            }
        }
        
        /// <remarks/>
        public bool RefakatciIstiyormu {
            get {
                return refakatciIstiyormuField;
            }
            set {
                refakatciIstiyormuField = value;
            }
        }
        
        /// <remarks/>
        public bool Engelli {
            get {
                return engelliField;
            }
            set {
                engelliField = value;
            }
        }
        
        /// <remarks/>
        public bool Kimsesiz {
            get {
                return kimsesizField;
            }
            set {
                kimsesizField = value;
            }
        }
        
        /// <remarks/>
        public bool YuksekRiskliGebe {
            get {
                return yuksekRiskliGebeField;
            }
            set {
                yuksekRiskliGebeField = value;
            }
        }
        
        /// <remarks/>
        public int RandevuTuru {
            get {
                return randevuTuruField;
            }
            set {
                randevuTuruField = value;
            }
        }
        
        /// <remarks/>
        public string RandevuNotu {
            get {
                return randevuNotuField;
            }
            set {
                randevuNotuField = value;
            }
        }
        
        /// <remarks/>
        public bool SanalTC {
            get {
                return sanalTCField;
            }
            set {
                sanalTCField = value;
            }
        }
        
        /// <remarks/>
        public string EklenmeZamani {
            get {
                return eklenmeZamaniField;
            }
            set {
                eklenmeZamaniField = value;
            }
        }
        
        /// <remarks/>
        public int EkleyenKullaniciTipi {
            get {
                return ekleyenKullaniciTipiField;
            }
            set {
                ekleyenKullaniciTipiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumRandevuSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int klinikKoduField;
        
        private string hekimKoduField;
        
        private TarihBilgileriType tarihBilgileriField;
        
        private int durumKoduField;
        
        private bool durumKoduFieldSpecified;
        
        private int kayitDurumKoduField;
        
        private bool kayitDurumKoduFieldSpecified;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int DurumKodu {
            get {
                return durumKoduField;
            }
            set {
                durumKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DurumKoduSpecified {
            get {
                return durumKoduFieldSpecified;
            }
            set {
                durumKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int KayitDurumKodu {
            get {
                return kayitDurumKoduField;
            }
            set {
                kayitDurumKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KayitDurumKoduSpecified {
            get {
                return kayitDurumKoduFieldSpecified;
            }
            set {
                kayitDurumKoduFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuIptalCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private string randevuHrnField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string RandevuHrn {
            get {
                return randevuHrnField;
            }
            set {
                randevuHrnField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuIptalTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private string randevuHrnField;
        
        private string onlineProtokolField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string RandevuHrn {
            get {
                return randevuHrnField;
            }
            set {
                randevuHrnField = value;
            }
        }
        
        /// <remarks/>
        public string OnlineProtokol {
            get {
                return onlineProtokolField;
            }
            set {
                onlineProtokolField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKesinCetvelSilmeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private long[] kesinCetvelIdField;
        
        private long[] istisnaIdField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KesinCetvelId")]
        public long[] KesinCetvelId {
            get {
                return kesinCetvelIdField;
            }
            set {
                kesinCetvelIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IstisnaId")]
        public long[] IstisnaId {
            get {
                return istisnaIdField;
            }
            set {
                istisnaIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKesinCetvelSilmeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private long[] kesinCetvelIdField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KesinCetvelId")]
        public long[] KesinCetvelId {
            get {
                return kesinCetvelIdField;
            }
            set {
                kesinCetvelIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class CetvelOzetType {
        
        private int bosRandevuSayisiField;
        
        private string tarihField;
        
        private string hekimKoduField;
        
        private string hekimAdiSoyadiField;
        
        private int cinsiyetField;
        
        private KlinikBilgileriType klinikBilgileriField;
        
        private int kurumKoduField;
        
        private string kurumAdField;
        
        private string altKlinikAdiField;
        
        /// <remarks/>
        public int BosRandevuSayisi {
            get {
                return bosRandevuSayisiField;
            }
            set {
                bosRandevuSayisiField = value;
            }
        }
        
        /// <remarks/>
        public string Tarih {
            get {
                return tarihField;
            }
            set {
                tarihField = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public string HekimAdiSoyadi {
            get {
                return hekimAdiSoyadiField;
            }
            set {
                hekimAdiSoyadiField = value;
            }
        }
        
        /// <remarks/>
        public int Cinsiyet {
            get {
                return cinsiyetField;
            }
            set {
                cinsiyetField = value;
            }
        }
        
        /// <remarks/>
        public KlinikBilgileriType KlinikBilgileri {
            get {
                return klinikBilgileriField;
            }
            set {
                klinikBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KurumKodu {
            get {
                return kurumKoduField;
            }
            set {
                kurumKoduField = value;
            }
        }
        
        /// <remarks/>
        public string KurumAd {
            get {
                return kurumAdField;
            }
            set {
                kurumAdField = value;
            }
        }
        
        /// <remarks/>
        public string AltKlinikAdi {
            get {
                return altKlinikAdiField;
            }
            set {
                altKlinikAdiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuCetvelOzetSorgulamaObjCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private CetvelOzetType[] cetvelOzetListesiField;
        
        private CetvelOzetType[] alternatifCetvelOzetListesiField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CetvelOzetListesi")]
        public CetvelOzetType[] CetvelOzetListesi {
            get {
                return cetvelOzetListesiField;
            }
            set {
                cetvelOzetListesiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AlternatifCetvelOzetListesi")]
        public CetvelOzetType[] AlternatifCetvelOzetListesi {
            get {
                return alternatifCetvelOzetListesiField;
            }
            set {
                alternatifCetvelOzetListesiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuCetvelOzetSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int ilKoduField;
        
        private int ilceKoduField;
        
        private bool ilceKoduFieldSpecified;
        
        private int altKlinikKoduField;
        
        private bool altKlinikKoduFieldSpecified;
        
        private string tarihField;
        
        private string tCKimlikNoField;
        
        private int kurumKoduField;
        
        private bool kurumKoduFieldSpecified;
        
        private int semtPoliklinikKoduField;
        
        private bool semtPoliklinikKoduFieldSpecified;
        
        private int klinikKoduField;
        
        private bool klinikKoduFieldSpecified;
        
        private string hekimKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int IlKodu {
            get {
                return ilKoduField;
            }
            set {
                ilKoduField = value;
            }
        }
        
        /// <remarks/>
        public int IlceKodu {
            get {
                return ilceKoduField;
            }
            set {
                ilceKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IlceKoduSpecified {
            get {
                return ilceKoduFieldSpecified;
            }
            set {
                ilceKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int AltKlinikKodu {
            get {
                return altKlinikKoduField;
            }
            set {
                altKlinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AltKlinikKoduSpecified {
            get {
                return altKlinikKoduFieldSpecified;
            }
            set {
                altKlinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Tarih {
            get {
                return tarihField;
            }
            set {
                tarihField = value;
            }
        }
        
        /// <remarks/>
        public string TCKimlikNo {
            get {
                return tCKimlikNoField;
            }
            set {
                tCKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        public int KurumKodu {
            get {
                return kurumKoduField;
            }
            set {
                kurumKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KurumKoduSpecified {
            get {
                return kurumKoduFieldSpecified;
            }
            set {
                kurumKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int SemtPoliklinikKodu {
            get {
                return semtPoliklinikKoduField;
            }
            set {
                semtPoliklinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SemtPoliklinikKoduSpecified {
            get {
                return semtPoliklinikKoduFieldSpecified;
            }
            set {
                semtPoliklinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KlinikKoduSpecified {
            get {
                return klinikKoduFieldSpecified;
            }
            set {
                klinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class AksiyonBilgileriType {
        
        private int aksiyonKoduField;
        
        private string aciklamaField;
        
        private int aksiyonTipiField;
        
        private int mustesnaField;
        
        private int gunField;
        
        private long islemTipiField;
        
        /// <remarks/>
        public int AksiyonKodu {
            get {
                return aksiyonKoduField;
            }
            set {
                aksiyonKoduField = value;
            }
        }
        
        /// <remarks/>
        public string Aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
        
        /// <remarks/>
        public int AksiyonTipi {
            get {
                return aksiyonTipiField;
            }
            set {
                aksiyonTipiField = value;
            }
        }
        
        /// <remarks/>
        public int Mustesna {
            get {
                return mustesnaField;
            }
            set {
                mustesnaField = value;
            }
        }
        
        /// <remarks/>
        public int Gun {
            get {
                return gunField;
            }
            set {
                gunField = value;
            }
        }
        
        /// <remarks/>
        public long IslemTipi {
            get {
                return islemTipiField;
            }
            set {
                islemTipiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class AksiyonBilgileriSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private AksiyonBilgileriType[] aksiyonBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AksiyonBilgileri")]
        public AksiyonBilgileriType[] AksiyonBilgileri {
            get {
                return aksiyonBilgileriField;
            }
            set {
                aksiyonBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class AksiyonBilgileriSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuCetvelOzetDetaySorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylari[] calismaGunDetaylariField;
        
        private RandevuCetvelOzetDetaySorgulamaCevapTypeRandevuGunDurumlari[] randevuGunDurumlariField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CalismaGunDetaylari")]
        public RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylari[] CalismaGunDetaylari {
            get {
                return calismaGunDetaylariField;
            }
            set {
                calismaGunDetaylariField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RandevuGunDurumlari")]
        public RandevuCetvelOzetDetaySorgulamaCevapTypeRandevuGunDurumlari[] RandevuGunDurumlari {
            get {
                return randevuGunDurumlariField;
            }
            set {
                randevuGunDurumlariField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylari {
        
        private string tarihField;
        
        private RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylariCalismaSaatleri[] calismaSaatleriField;
        
        /// <remarks/>
        public string Tarih {
            get {
                return tarihField;
            }
            set {
                tarihField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CalismaSaatleri")]
        public RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylariCalismaSaatleri[] CalismaSaatleri {
            get {
                return calismaSaatleriField;
            }
            set {
                calismaSaatleriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylariCalismaSaatleri {
        
        private int saatField;
        
        private RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylariCalismaSaatleriSlotlar[] slotlarField;
        
        /// <remarks/>
        public int Saat {
            get {
                return saatField;
            }
            set {
                saatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Slotlar")]
        public RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylariCalismaSaatleriSlotlar[] Slotlar {
            get {
                return slotlarField;
            }
            set {
                slotlarField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class RandevuCetvelOzetDetaySorgulamaCevapTypeCalismaGunDetaylariCalismaSaatleriSlotlar {
        
        private string baslangicField;
        
        private string bitisField;
        
        private string durumField;
        
        private bool egitimArastirmaUyarisiField;
        
        private long kesinCetvelIdField;
        
        private AltKlinikBilgileriType altKlinikBilgileriField;
        
        private int randevuTuruField;
        
        /// <remarks/>
        public string Baslangic {
            get {
                return baslangicField;
            }
            set {
                baslangicField = value;
            }
        }
        
        /// <remarks/>
        public string Bitis {
            get {
                return bitisField;
            }
            set {
                bitisField = value;
            }
        }
        
        /// <remarks/>
        public string Durum {
            get {
                return durumField;
            }
            set {
                durumField = value;
            }
        }
        
        /// <remarks/>
        public bool EgitimArastirmaUyarisi {
            get {
                return egitimArastirmaUyarisiField;
            }
            set {
                egitimArastirmaUyarisiField = value;
            }
        }
        
        /// <remarks/>
        public long KesinCetvelId {
            get {
                return kesinCetvelIdField;
            }
            set {
                kesinCetvelIdField = value;
            }
        }
        
        /// <remarks/>
        public AltKlinikBilgileriType AltKlinikBilgileri {
            get {
                return altKlinikBilgileriField;
            }
            set {
                altKlinikBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int RandevuTuru {
            get {
                return randevuTuruField;
            }
            set {
                randevuTuruField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class RandevuCetvelOzetDetaySorgulamaCevapTypeRandevuGunDurumlari {
        
        private string tarihField;
        
        private string durumField;
        
        /// <remarks/>
        public string Tarih {
            get {
                return tarihField;
            }
            set {
                tarihField = value;
            }
        }
        
        /// <remarks/>
        public string Durum {
            get {
                return durumField;
            }
            set {
                durumField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuCetvelOzetDetaySorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int kurumKoduField;
        
        private int klinikKoduField;
        
        private string hekimKoduField;
        
        private string tarihField;
        
        private string tCKimlikNoField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KurumKodu {
            get {
                return kurumKoduField;
            }
            set {
                kurumKoduField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public string Tarih {
            get {
                return tarihField;
            }
            set {
                tarihField = value;
            }
        }
        
        /// <remarks/>
        public string TCKimlikNo {
            get {
                return tCKimlikNoField;
            }
            set {
                tCKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class IlceType {
        
        private int ilceKoduField;
        
        private string ilceAdiField;
        
        /// <remarks/>
        public int IlceKodu {
            get {
                return ilceKoduField;
            }
            set {
                ilceKoduField = value;
            }
        }
        
        /// <remarks/>
        public string IlceAdi {
            get {
                return ilceAdiField;
            }
            set {
                ilceAdiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuIlceVeXXXXXXVeSemtPoliklinikleriSorgulamaObjCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private IlceType[] ilcelerField;
        
        private KurumType[] XXXXXXlerField;
        
        private KurumType[] semtPoliklinikleriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Ilceler")]
        public IlceType[] Ilceler {
            get {
                return ilcelerField;
            }
            set {
                ilcelerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("XXXXXXler")]
        public KurumType[] XXXXXXler {
            get {
                return XXXXXXlerField;
            }
            set {
                XXXXXXlerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SemtPoliklinikleri")]
        public KurumType[] SemtPoliklinikleri {
            get {
                return semtPoliklinikleriField;
            }
            set {
                semtPoliklinikleriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuIlceVeXXXXXXVeSemtPoliklinikleriSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int ilKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int IlKodu {
            get {
                return ilKoduField;
            }
            set {
                ilKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKesinCetvelSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KurumKesinCetvelSorgulamaCevapTypeKesinCetvelDetayBilgileri[] kesinCetvelDetayBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KesinCetvelDetayBilgileri")]
        public KurumKesinCetvelSorgulamaCevapTypeKesinCetvelDetayBilgileri[] KesinCetvelDetayBilgileri {
            get {
                return kesinCetvelDetayBilgileriField;
            }
            set {
                kesinCetvelDetayBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class KurumKesinCetvelSorgulamaCevapTypeKesinCetvelDetayBilgileri {
        
        private long kesinCetvelIdField;
        
        private long taslakCetvelIdField;
        
        private bool taslakCetvelIdFieldSpecified;
        
        private CetvelDetayBilgileriType cetvelDetayBilgileriField;
        
        /// <remarks/>
        public long KesinCetvelId {
            get {
                return kesinCetvelIdField;
            }
            set {
                kesinCetvelIdField = value;
            }
        }
        
        /// <remarks/>
        public long TaslakCetvelId {
            get {
                return taslakCetvelIdField;
            }
            set {
                taslakCetvelIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TaslakCetvelIdSpecified {
            get {
                return taslakCetvelIdFieldSpecified;
            }
            set {
                taslakCetvelIdFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public CetvelDetayBilgileriType CetvelDetayBilgileri {
            get {
                return cetvelDetayBilgileriField;
            }
            set {
                cetvelDetayBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKesinCetvelSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private TarihBilgileriType tarihBilgileriField;
        
        private int klinikKoduField;
        
        private bool klinikKoduFieldSpecified;
        
        private int altKlinikKoduField;
        
        private bool altKlinikKoduFieldSpecified;
        
        private HekimBilgileriType hekimBilgileriField;
        
        private int aksiyonKoduField;
        
        private bool aksiyonKoduFieldSpecified;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KlinikKoduSpecified {
            get {
                return klinikKoduFieldSpecified;
            }
            set {
                klinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int AltKlinikKodu {
            get {
                return altKlinikKoduField;
            }
            set {
                altKlinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AltKlinikKoduSpecified {
            get {
                return altKlinikKoduFieldSpecified;
            }
            set {
                altKlinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public HekimBilgileriType HekimBilgileri {
            get {
                return hekimBilgileriField;
            }
            set {
                hekimBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int AksiyonKodu {
            get {
                return aksiyonKoduField;
            }
            set {
                aksiyonKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AksiyonKoduSpecified {
            get {
                return aksiyonKoduFieldSpecified;
            }
            set {
                aksiyonKoduFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumIsKuraliSilmeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private int isKuraliIdField;
        
        private bool isKuraliIdFieldSpecified;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int IsKuraliId {
            get {
                return isKuraliIdField;
            }
            set {
                isKuraliIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsKuraliIdSpecified {
            get {
                return isKuraliIdFieldSpecified;
            }
            set {
                isKuraliIdFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumIsKuraliSilmeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int isKuraliIdField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int IsKuraliId {
            get {
                return isKuraliIdField;
            }
            set {
                isKuraliIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKlinikEklemeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumKlinikEklemeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int klinikKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuSemtPoliklinikleriVeKliniklerSorgulamaObjCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KurumType[] semtPoliklinikleriField;
        
        private KlinikBilgileriType[] klinikBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SemtPoliklinikleri")]
        public KurumType[] SemtPoliklinikleri {
            get {
                return semtPoliklinikleriField;
            }
            set {
                semtPoliklinikleriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KlinikBilgileri")]
        public KlinikBilgileriType[] KlinikBilgileri {
            get {
                return klinikBilgileriField;
            }
            set {
                klinikBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuSemtPoliklinikleriVeKliniklerSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int kurumKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KurumKodu {
            get {
                return kurumKoduField;
            }
            set {
                kurumKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class YesilListeBilgileriType {
        
        private int klinikKoduField;
        
        private string klinikAdiField;
        
        private string eklenmeZamaniField;
        
        private int onayDurumuField;
        
        private string onaylanmaZamaniField;
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string KlinikAdi {
            get {
                return klinikAdiField;
            }
            set {
                klinikAdiField = value;
            }
        }
        
        /// <remarks/>
        public string EklenmeZamani {
            get {
                return eklenmeZamaniField;
            }
            set {
                eklenmeZamaniField = value;
            }
        }
        
        /// <remarks/>
        public int OnayDurumu {
            get {
                return onayDurumuField;
            }
            set {
                onayDurumuField = value;
            }
        }
        
        /// <remarks/>
        public string OnaylanmaZamani {
            get {
                return onaylanmaZamaniField;
            }
            set {
                onaylanmaZamaniField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class YesilListeVatandasSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private YesilListeBilgileriType[] yesilListeBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("YesilListeBilgileri")]
        public YesilListeBilgileriType[] YesilListeBilgileri {
            get {
                return yesilListeBilgileriField;
            }
            set {
                yesilListeBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class YesilListeVatandasSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private string tCKimlikNoField;
        
        private int klinikKoduField;
        
        private bool klinikKoduFieldSpecified;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string TCKimlikNo {
            get {
                return tCKimlikNoField;
            }
            set {
                tCKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KlinikKoduSpecified {
            get {
                return klinikKoduFieldSpecified;
            }
            set {
                klinikKoduFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KurumTaslakCetvelSorgulamaCevapTypeTaslakCetvelDetayBilgileri[] taslakCetvelDetayBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TaslakCetvelDetayBilgileri")]
        public KurumTaslakCetvelSorgulamaCevapTypeTaslakCetvelDetayBilgileri[] TaslakCetvelDetayBilgileri {
            get {
                return taslakCetvelDetayBilgileriField;
            }
            set {
                taslakCetvelDetayBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelSorgulamaCevapTypeTaslakCetvelDetayBilgileri {
        
        private long taslakCetvelIdField;
        
        private CetvelDetayBilgileriType cetvelDetayBilgileriField;
        
        /// <remarks/>
        public long TaslakCetvelId {
            get {
                return taslakCetvelIdField;
            }
            set {
                taslakCetvelIdField = value;
            }
        }
        
        /// <remarks/>
        public CetvelDetayBilgileriType CetvelDetayBilgileri {
            get {
                return cetvelDetayBilgileriField;
            }
            set {
                cetvelDetayBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumTaslakCetvelSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private TarihBilgileriType tarihBilgileriField;
        
        private int klinikKoduField;
        
        private bool klinikKoduFieldSpecified;
        
        private int altKlinikKoduField;
        
        private bool altKlinikKoduFieldSpecified;
        
        private HekimBilgileriType hekimBilgileriField;
        
        private int aksiyonKoduField;
        
        private bool aksiyonKoduFieldSpecified;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public TarihBilgileriType TarihBilgileri {
            get {
                return tarihBilgileriField;
            }
            set {
                tarihBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KlinikKoduSpecified {
            get {
                return klinikKoduFieldSpecified;
            }
            set {
                klinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int AltKlinikKodu {
            get {
                return altKlinikKoduField;
            }
            set {
                altKlinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AltKlinikKoduSpecified {
            get {
                return altKlinikKoduFieldSpecified;
            }
            set {
                altKlinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public HekimBilgileriType HekimBilgileri {
            get {
                return hekimBilgileriField;
            }
            set {
                hekimBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int AksiyonKodu {
            get {
                return aksiyonKoduField;
            }
            set {
                aksiyonKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AksiyonKoduSpecified {
            get {
                return aksiyonKoduFieldSpecified;
            }
            set {
                aksiyonKoduFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuKlinikSorgulamaObjCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KlinikBilgileriType[] klinikBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KlinikBilgileri")]
        public KlinikBilgileriType[] KlinikBilgileri {
            get {
                return klinikBilgileriField;
            }
            set {
                klinikBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuKlinikSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int kurumKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KurumKodu {
            get {
                return kurumKoduField;
            }
            set {
                kurumKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class IstisnaRedCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class IstisnaRedTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private long istisnaIdField;
        
        private string redNedeniField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public long IstisnaId {
            get {
                return istisnaIdField;
            }
            set {
                istisnaIdField = value;
            }
        }
        
        /// <remarks/>
        public string RedNedeni {
            get {
                return redNedeniField;
            }
            set {
                redNedeniField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KayitDurumKoduBilgileriType {
        
        private int kayitDurumKoduField;
        
        private string aciklamaField;
        
        /// <remarks/>
        public int KayitDurumKodu {
            get {
                return kayitDurumKoduField;
            }
            set {
                kayitDurumKoduField = value;
            }
        }
        
        /// <remarks/>
        public string Aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KayitDurumKoduSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KayitDurumKoduBilgileriType[] kayitDurumKoduBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KayitDurumKoduBilgileri")]
        public KayitDurumKoduBilgileriType[] KayitDurumKoduBilgileri {
            get {
                return kayitDurumKoduBilgileriField;
            }
            set {
                kayitDurumKoduBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KayitDurumKoduSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumIsKuraliSorgulamaCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private KurumIsKuraliSorgulamaCevapTypeIsKuraliBilgileri[] isKuraliBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IsKuraliBilgileri")]
        public KurumIsKuraliSorgulamaCevapTypeIsKuraliBilgileri[] IsKuraliBilgileri {
            get {
                return isKuraliBilgileriField;
            }
            set {
                isKuraliBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class KurumIsKuraliSorgulamaCevapTypeIsKuraliBilgileri {
        
        private int isKuraliIdField;
        
        private int klinikKoduField;
        
        private bool klinikKoduFieldSpecified;
        
        private string hekimKoduField;
        
        private int isKuraliTipiKoduField;
        
        private int zamanKriteriField;
        
        private bool zamanKriteriFieldSpecified;
        
        private string degerField;
        
        /// <remarks/>
        public int IsKuraliId {
            get {
                return isKuraliIdField;
            }
            set {
                isKuraliIdField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KlinikKoduSpecified {
            get {
                return klinikKoduFieldSpecified;
            }
            set {
                klinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public int IsKuraliTipiKodu {
            get {
                return isKuraliTipiKoduField;
            }
            set {
                isKuraliTipiKoduField = value;
            }
        }
        
        /// <remarks/>
        public int ZamanKriteri {
            get {
                return zamanKriteriField;
            }
            set {
                zamanKriteriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ZamanKriteriSpecified {
            get {
                return zamanKriteriFieldSpecified;
            }
            set {
                zamanKriteriFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Deger {
            get {
                return degerField;
            }
            set {
                degerField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumIsKuraliSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int klinikKoduField;
        
        private bool klinikKoduFieldSpecified;
        
        private string hekimKoduField;
        
        private int isKuraliTipiKoduField;
        
        private bool isKuraliTipiKoduFieldSpecified;
        
        private int zamanKriteriField;
        
        private bool zamanKriteriFieldSpecified;
        
        private string degerField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int KlinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KlinikKoduSpecified {
            get {
                return klinikKoduFieldSpecified;
            }
            set {
                klinikKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public int IsKuraliTipiKodu {
            get {
                return isKuraliTipiKoduField;
            }
            set {
                isKuraliTipiKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsKuraliTipiKoduSpecified {
            get {
                return isKuraliTipiKoduFieldSpecified;
            }
            set {
                isKuraliTipiKoduFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int ZamanKriteri {
            get {
                return zamanKriteriField;
            }
            set {
                zamanKriteriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ZamanKriteriSpecified {
            get {
                return zamanKriteriFieldSpecified;
            }
            set {
                zamanKriteriFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Deger {
            get {
                return degerField;
            }
            set {
                degerField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumAltKlinikAdiGuncellemeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumAltKlinikAdiGuncellemeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int altKlinikKoduField;
        
        private string altKlinikAdiField;
        
        private bool lokasyonDegisikligineDusurmeField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int AltKlinikKodu {
            get {
                return altKlinikKoduField;
            }
            set {
                altKlinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public string AltKlinikAdi {
            get {
                return altKlinikAdiField;
            }
            set {
                altKlinikAdiField = value;
            }
        }
        
        /// <remarks/>
        public bool LokasyonDegisikligineDusurme {
            get {
                return lokasyonDegisikligineDusurmeField;
            }
            set {
                lokasyonDegisikligineDusurmeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KskVatandasTicketUretmeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private string ticketField;
        
        private string parolaField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string Ticket {
            get {
                return ticketField;
            }
            set {
                ticketField = value;
            }
        }
        
        /// <remarks/>
        public string Parola {
            get {
                return parolaField;
            }
            set {
                parolaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KskVatandasTicketUretmeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private string randevu_alinan_tc_kimlik_noField;
        
        private string randevu_alan_tc_kimlik_noField;
        
        private VatandasIletisimBilgileriType vatandasIletisimBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string randevu_alinan_tc_kimlik_no {
            get {
                return randevu_alinan_tc_kimlik_noField;
            }
            set {
                randevu_alinan_tc_kimlik_noField = value;
            }
        }
        
        /// <remarks/>
        public string randevu_alan_tc_kimlik_no {
            get {
                return randevu_alan_tc_kimlik_noField;
            }
            set {
                randevu_alan_tc_kimlik_noField = value;
            }
        }
        
        /// <remarks/>
        public VatandasIletisimBilgileriType VatandasIletisimBilgileri {
            get {
                return vatandasIletisimBilgileriField;
            }
            set {
                vatandasIletisimBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuEklemeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private string randevuHrnField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public string RandevuHrn {
            get {
                return randevuHrnField;
            }
            set {
                randevuHrnField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuZamanBilgisiType {
        
        private string randevuBaslangicZamaniField;
        
        private string randevuBitisZamaniField;
        
        /// <remarks/>
        public string RandevuBaslangicZamani {
            get {
                return randevuBaslangicZamaniField;
            }
            set {
                randevuBaslangicZamaniField = value;
            }
        }
        
        /// <remarks/>
        public string RandevuBitisZamani {
            get {
                return randevuBitisZamaniField;
            }
            set {
                randevuBitisZamaniField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuEklemeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private long kesinCetvelIdField;
        
        private RandevuZamanBilgisiType randevuZamanBilgisiField;
        
        private VatandasBilgileriType vatandasBilgileriField;
        
        private bool refakatciIstiyormuField;
        
        private bool refakatciIstiyormuFieldSpecified;
        
        private string randevuNotuField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public long KesinCetvelId {
            get {
                return kesinCetvelIdField;
            }
            set {
                kesinCetvelIdField = value;
            }
        }
        
        /// <remarks/>
        public RandevuZamanBilgisiType RandevuZamanBilgisi {
            get {
                return randevuZamanBilgisiField;
            }
            set {
                randevuZamanBilgisiField = value;
            }
        }
        
        /// <remarks/>
        public VatandasBilgileriType VatandasBilgileri {
            get {
                return vatandasBilgileriField;
            }
            set {
                vatandasBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public bool RefakatciIstiyormu {
            get {
                return refakatciIstiyormuField;
            }
            set {
                refakatciIstiyormuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RefakatciIstiyormuSpecified {
            get {
                return refakatciIstiyormuFieldSpecified;
            }
            set {
                refakatciIstiyormuFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string RandevuNotu {
            get {
                return randevuNotuField;
            }
            set {
                randevuNotuField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumAltKlinikSilmeCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class KurumAltKlinikSilmeTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        private int altKlinikKoduField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public int AltKlinikKodu {
            get {
                return altKlinikKoduField;
            }
            set {
                altKlinikKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuIlSorgulamaObjCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private RandevuIlSorgulamaObjCevapTypeIlBilgileri[] ilBilgileriField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IlBilgileri")]
        public RandevuIlSorgulamaObjCevapTypeIlBilgileri[] IlBilgileri {
            get {
                return ilBilgileriField;
            }
            set {
                ilBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class RandevuIlSorgulamaObjCevapTypeIlBilgileri {
        
        private int koduField;
        
        private string adiField;
        
        /// <remarks/>
        public int Kodu {
            get {
                return koduField;
            }
            set {
                koduField = value;
            }
        }
        
        /// <remarks/>
        public string Adi {
            get {
                return adiField;
            }
            set {
                adiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuIlSorgulamaTalepType {
        
        private YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileriField;
        
        private KurumBilgileriType kurumBilgileriField;
        
        /// <remarks/>
        public YetkilendirmeGirisBilgileriType YetkilendirmeGirisBilgileri {
            get {
                return yetkilendirmeGirisBilgileriField;
            }
            set {
                yetkilendirmeGirisBilgileriField = value;
            }
        }
        
        /// <remarks/>
        public KurumBilgileriType KurumBilgileri {
            get {
                return kurumBilgileriField;
            }
            set {
                kurumBilgileriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class RandevuAltKlinikVeHekimlerSorgulamaObjCevapType {
        
        private TemelCevapBilgileriType temelCevapBilgileriField;
        
        private AltKlinikBilgileriType[] altKlinikBilgileriField;
        
        private RandevuAltKlinikVeHekimlerSorgulamaObjCevapTypeHekimler[] hekimlerField;
        
        /// <remarks/>
        public TemelCevapBilgileriType TemelCevapBilgileri {
            get {
                return temelCevapBilgileriField;
            }
            set {
                temelCevapBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AltKlinikBilgileri")]
        public AltKlinikBilgileriType[] AltKlinikBilgileri {
            get {
                return altKlinikBilgileriField;
            }
            set {
                altKlinikBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Hekimler")]
        public RandevuAltKlinikVeHekimlerSorgulamaObjCevapTypeHekimler[] Hekimler {
            get {
                return hekimlerField;
            }
            set {
                hekimlerField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://xxxxxx.com")]
    public partial class RandevuAltKlinikVeHekimlerSorgulamaObjCevapTypeHekimler {
        
        private string hekimKoduField;
        
        private string adSoyadField;
        
        /// <remarks/>
        public string HekimKodu {
            get {
                return hekimKoduField;
            }
            set {
                hekimKoduField = value;
            }
        }
        
        /// <remarks/>
        public string AdSoyad {
            get {
                return adSoyadField;
            }
            set {
                adSoyadField = value;
            }
        }
    }
        
#endregion Methods

    }
}