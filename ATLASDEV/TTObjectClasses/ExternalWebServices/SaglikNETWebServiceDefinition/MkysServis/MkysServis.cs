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
    public partial class MkysServis : TTObject
    {
        public static partial class WebMethods
        {

        }

        #region Methods

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", IsNullable = false)]
        public partial class SoapKontrol
        {

            private string mkysKullaniciAdiField;

            private string mkysSifreField;

            private string firmaKullaniciAdiField;

            private string firmaSifreField;

            private System.Nullable<int> birimKayitNoField;

            private System.Xml.XmlAttribute[] anyAttrField;

            /// <remarks/>
            public string mkysKullaniciAdi
            {
                get
                {
                    return this.mkysKullaniciAdiField;
                }
                set
                {
                    this.mkysKullaniciAdiField = value;
                }
            }

            /// <remarks/>
            public string mkysSifre
            {
                get
                {
                    return this.mkysSifreField;
                }
                set
                {
                    this.mkysSifreField = value;
                }
            }

            /// <remarks/>
            public string firmaKullaniciAdi
            {
                get
                {
                    return this.firmaKullaniciAdiField;
                }
                set
                {
                    this.firmaKullaniciAdiField = value;
                }
            }

            /// <remarks/>
            public string firmaSifre
            {
                get
                {
                    return this.firmaSifreField;
                }
                set
                {
                    this.firmaSifreField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> birimKayitNo
            {
                get
                {
                    return this.birimKayitNoField;
                }
                set
                {
                    this.birimKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAnyAttributeAttribute()]
            public System.Xml.XmlAttribute[] AnyAttr
            {
                get
                {
                    return this.anyAttrField;
                }
                set
                {
                    this.anyAttrField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class firmaBilgileriGetTumuSonuc
        {

            private string unvanField;

            private string vergiDairesiField;

            private string vergiNumarasiField;

            /// <remarks/>
            public string unvan
            {
                get
                {
                    return this.unvanField;
                }
                set
                {
                    this.unvanField = value;
                }
            }

            /// <remarks/>
            public string vergiDairesi
            {
                get
                {
                    return this.vergiDairesiField;
                }
                set
                {
                    this.vergiDairesiField = value;
                }
            }

            /// <remarks/>
            public string vergiNumarasi
            {
                get
                {
                    return this.vergiNumarasiField;
                }
                set
                {
                    this.vergiNumarasiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class mukerrerStokHareketItem
        {

            private int stokHareketIDField;

            private string belgeNoField;

            private System.Nullable<System.DateTime> belgeTarihiField;

            private System.Nullable<int> islemKayitNoField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class AyniyatDayanikliTasinir
        {

            private System.Nullable<int> demirbasKayitIdField;

            private System.Nullable<long> kunyeNoField;

            private string cihazinAdiField;

            private System.Nullable<ECihazDurumu> cihazinDurumuField;

            private string calismamaNedeniField;

            private string markaIsmiField;

            private string modelNoField;

            private string seriNoField;

            private string katalogNoField;

            private string menseiField;

            private string sinifiField;

            private string barkodField;

            private string lotPartiNoField;

            private System.Nullable<int> garantiSuresiField;

            private System.Nullable<int> uretimYiliField;

            private System.Nullable<int> edinmeYiliField;

            private string bakimHizmetDurumuField;

            private System.Nullable<long> stokHareketIdField;

            private System.Nullable<int> birimKayitIdField;

            private string birimAdiField;

            private string zimmetSahibiTcField;

            private string zimmetSahibiField;

            private System.Nullable<System.DateTime> zimmetTarihiField;

            private System.Nullable<int> zimmetBirimiField;

            private string zimmetBirimiAdiField;

            private string lokasyonIdField;

            private string lokasyonAdiField;

            private string tasinirSicilNoField;

            private System.Nullable<int> birimDepoIdField;

            private System.Nullable<int> malzemeKayitIdField;

            private System.Nullable<EButceTuru> butceTuruField;

            private System.Nullable<decimal> fiyatField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> DemirbasKayitId
            {
                get
                {
                    return this.demirbasKayitIdField;
                }
                set
                {
                    this.demirbasKayitIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> KunyeNo
            {
                get
                {
                    return this.kunyeNoField;
                }
                set
                {
                    this.kunyeNoField = value;
                }
            }

            /// <remarks/>
            public string CihazinAdi
            {
                get
                {
                    return this.cihazinAdiField;
                }
                set
                {
                    this.cihazinAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<ECihazDurumu> CihazinDurumu
            {
                get
                {
                    return this.cihazinDurumuField;
                }
                set
                {
                    this.cihazinDurumuField = value;
                }
            }

            /// <remarks/>
            public string CalismamaNedeni
            {
                get
                {
                    return this.calismamaNedeniField;
                }
                set
                {
                    this.calismamaNedeniField = value;
                }
            }

            /// <remarks/>
            public string MarkaIsmi
            {
                get
                {
                    return this.markaIsmiField;
                }
                set
                {
                    this.markaIsmiField = value;
                }
            }

            /// <remarks/>
            public string ModelNo
            {
                get
                {
                    return this.modelNoField;
                }
                set
                {
                    this.modelNoField = value;
                }
            }

            /// <remarks/>
            public string SeriNo
            {
                get
                {
                    return this.seriNoField;
                }
                set
                {
                    this.seriNoField = value;
                }
            }

            /// <remarks/>
            public string KatalogNo
            {
                get
                {
                    return this.katalogNoField;
                }
                set
                {
                    this.katalogNoField = value;
                }
            }

            /// <remarks/>
            public string Mensei
            {
                get
                {
                    return this.menseiField;
                }
                set
                {
                    this.menseiField = value;
                }
            }

            /// <remarks/>
            public string Sinifi
            {
                get
                {
                    return this.sinifiField;
                }
                set
                {
                    this.sinifiField = value;
                }
            }

            /// <remarks/>
            public string Barkod
            {
                get
                {
                    return this.barkodField;
                }
                set
                {
                    this.barkodField = value;
                }
            }

            /// <remarks/>
            public string LotPartiNo
            {
                get
                {
                    return this.lotPartiNoField;
                }
                set
                {
                    this.lotPartiNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> GarantiSuresi
            {
                get
                {
                    return this.garantiSuresiField;
                }
                set
                {
                    this.garantiSuresiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> UretimYili
            {
                get
                {
                    return this.uretimYiliField;
                }
                set
                {
                    this.uretimYiliField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> EdinmeYili
            {
                get
                {
                    return this.edinmeYiliField;
                }
                set
                {
                    this.edinmeYiliField = value;
                }
            }

            /// <remarks/>
            public string BakimHizmetDurumu
            {
                get
                {
                    return this.bakimHizmetDurumuField;
                }
                set
                {
                    this.bakimHizmetDurumuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> StokHareketId
            {
                get
                {
                    return this.stokHareketIdField;
                }
                set
                {
                    this.stokHareketIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BirimKayitId
            {
                get
                {
                    return this.birimKayitIdField;
                }
                set
                {
                    this.birimKayitIdField = value;
                }
            }

            /// <remarks/>
            public string BirimAdi
            {
                get
                {
                    return this.birimAdiField;
                }
                set
                {
                    this.birimAdiField = value;
                }
            }

            /// <remarks/>
            public string ZimmetSahibiTc
            {
                get
                {
                    return this.zimmetSahibiTcField;
                }
                set
                {
                    this.zimmetSahibiTcField = value;
                }
            }

            /// <remarks/>
            public string ZimmetSahibi
            {
                get
                {
                    return this.zimmetSahibiField;
                }
                set
                {
                    this.zimmetSahibiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> ZimmetTarihi
            {
                get
                {
                    return this.zimmetTarihiField;
                }
                set
                {
                    this.zimmetTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> ZimmetBirimi
            {
                get
                {
                    return this.zimmetBirimiField;
                }
                set
                {
                    this.zimmetBirimiField = value;
                }
            }

            /// <remarks/>
            public string ZimmetBirimiAdi
            {
                get
                {
                    return this.zimmetBirimiAdiField;
                }
                set
                {
                    this.zimmetBirimiAdiField = value;
                }
            }

            /// <remarks/>
            public string LokasyonId
            {
                get
                {
                    return this.lokasyonIdField;
                }
                set
                {
                    this.lokasyonIdField = value;
                }
            }

            /// <remarks/>
            public string LokasyonAdi
            {
                get
                {
                    return this.lokasyonAdiField;
                }
                set
                {
                    this.lokasyonAdiField = value;
                }
            }

            /// <remarks/>
            public string TasinirSicilNo
            {
                get
                {
                    return this.tasinirSicilNoField;
                }
                set
                {
                    this.tasinirSicilNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BirimDepoId
            {
                get
                {
                    return this.birimDepoIdField;
                }
                set
                {
                    this.birimDepoIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> MalzemeKayitId
            {
                get
                {
                    return this.malzemeKayitIdField;
                }
                set
                {
                    this.malzemeKayitIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<EButceTuru> ButceTuru
            {
                get
                {
                    return this.butceTuruField;
                }
                set
                {
                    this.butceTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> Fiyat
            {
                get
                {
                    return this.fiyatField;
                }
                set
                {
                    this.fiyatField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum ECihazDurumu
        {

            /// <remarks/>
            Aktif,

            /// <remarks/>
            Pasif,

            /// <remarks/>
            Arizali,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EButceTuru
        {

            /// <remarks/>
            GenelButce,

            /// <remarks/>
            DonerSermaye,

            /// <remarks/>
            OzelButce,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class AyniyatDayanikliTasinirSorgu
        {

            private System.Nullable<int> birimKayitIdField;

            private System.Nullable<int> demirbasKayitIdField;

            private System.Nullable<long> kunyeNoField;

            private string cihazinAdiField;

            private System.Nullable<ECihazDurumu> cihazinDurumuField;

            private string calismamaNedeniField;

            private string markaIsmiField;

            private string modelNoField;

            private string seriNoField;

            private string barkodField;

            private string lotPartiNoField;

            private System.Nullable<int> garantiSuresiField;

            private System.Nullable<int> uretimYiliField;

            private System.Nullable<int> edinmeYiliField;

            private string tasinirKoduField;

            private System.Nullable<long> stokHareketIdField;

            private System.Nullable<int> birimDepoIdField;

            private System.Nullable<System.DateTime> tarihtenSonraDegisenlerField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BirimKayitId
            {
                get
                {
                    return this.birimKayitIdField;
                }
                set
                {
                    this.birimKayitIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> DemirbasKayitId
            {
                get
                {
                    return this.demirbasKayitIdField;
                }
                set
                {
                    this.demirbasKayitIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> KunyeNo
            {
                get
                {
                    return this.kunyeNoField;
                }
                set
                {
                    this.kunyeNoField = value;
                }
            }

            /// <remarks/>
            public string CihazinAdi
            {
                get
                {
                    return this.cihazinAdiField;
                }
                set
                {
                    this.cihazinAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<ECihazDurumu> CihazinDurumu
            {
                get
                {
                    return this.cihazinDurumuField;
                }
                set
                {
                    this.cihazinDurumuField = value;
                }
            }

            /// <remarks/>
            public string CalismamaNedeni
            {
                get
                {
                    return this.calismamaNedeniField;
                }
                set
                {
                    this.calismamaNedeniField = value;
                }
            }

            /// <remarks/>
            public string MarkaIsmi
            {
                get
                {
                    return this.markaIsmiField;
                }
                set
                {
                    this.markaIsmiField = value;
                }
            }

            /// <remarks/>
            public string ModelNo
            {
                get
                {
                    return this.modelNoField;
                }
                set
                {
                    this.modelNoField = value;
                }
            }

            /// <remarks/>
            public string SeriNo
            {
                get
                {
                    return this.seriNoField;
                }
                set
                {
                    this.seriNoField = value;
                }
            }

            /// <remarks/>
            public string Barkod
            {
                get
                {
                    return this.barkodField;
                }
                set
                {
                    this.barkodField = value;
                }
            }

            /// <remarks/>
            public string LotPartiNo
            {
                get
                {
                    return this.lotPartiNoField;
                }
                set
                {
                    this.lotPartiNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> GarantiSuresi
            {
                get
                {
                    return this.garantiSuresiField;
                }
                set
                {
                    this.garantiSuresiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> UretimYili
            {
                get
                {
                    return this.uretimYiliField;
                }
                set
                {
                    this.uretimYiliField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> EdinmeYili
            {
                get
                {
                    return this.edinmeYiliField;
                }
                set
                {
                    this.edinmeYiliField = value;
                }
            }

            /// <remarks/>
            public string TasinirKodu
            {
                get
                {
                    return this.tasinirKoduField;
                }
                set
                {
                    this.tasinirKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> StokHareketId
            {
                get
                {
                    return this.stokHareketIdField;
                }
                set
                {
                    this.stokHareketIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BirimDepoId
            {
                get
                {
                    return this.birimDepoIdField;
                }
                set
                {
                    this.birimDepoIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> TarihtenSonraDegisenler
            {
                get
                {
                    return this.tarihtenSonraDegisenlerField;
                }
                set
                {
                    this.tarihtenSonraDegisenlerField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class BiyomedikalDayanikliTasinir
        {

            private System.Nullable<int> demirbasKayitIdField;

            private System.Nullable<long> kunyeNoField;

            private string cihazinAdiField;

            private System.Nullable<ECihazDurumu> cihazinDurumuField;

            private string calismamaNedeniField;

            private System.Nullable<EMalzemeEkKapsami> malzemeEkKapsamiField;

            private System.Nullable<int> biyomedikalHizmetTurIdField;

            private string biyomedikalHizmetTuruField;

            private System.Nullable<int> biyomedikalTurIdField;

            private string biyomedikalTurAdiField;

            private System.Nullable<int> biyomedikalTanimIdField;

            private string biyomedikalTanimAdiField;

            private System.Nullable<int> biyomedikalBransIdField;

            private string biyomedikalBransAdiField;

            private System.Nullable<int> biyomedikalYerIdField;

            private string biyomedikalYerAdiField;

            private System.Nullable<int> biyomedikalMarkaIdField;

            private string biyomedikalMarkaAdiField;

            private string modelNoField;

            private string seriNoField;

            private string barkodField;

            private string lotPartiNoField;

            private System.Nullable<int> garantiSuresiField;

            private System.Nullable<int> uretimYiliField;

            private System.Nullable<int> edinmeYiliField;

            private System.Nullable<long> stokHareketIdField;

            private System.Nullable<int> birimKayitIdField;

            private string birimAdiField;

            private string zimmetSahibiTcField;

            private string zimmetSahibiField;

            private System.Nullable<System.DateTime> zimmetTarihiField;

            private System.Nullable<int> zimmetBirimiField;

            private string zimmetBirimiAdiField;

            private string lokasyonIdField;

            private string lokasyonAdiField;

            private string tasinirSicilNoField;

            private System.Nullable<int> birimDepoIdField;

            private System.Nullable<int> malzemeKayitIdField;

            private System.Nullable<EButceTuru> butceTuruField;

            private System.Nullable<decimal> fiyatField;

            private System.Nullable<EMalzemeNiteligi> cihazNiteligiField;

            private System.Nullable<EHizmetTedarikTuru> hizmetTedarikTuruField;

            private System.Nullable<System.DateTime> sozlesmeBaslangicTarihiField;

            private System.Nullable<System.DateTime> sozlesmeBitisTarihiField;

            private string sorumluPersonelTcField;

            private string sorumluPersonelField;

            private string firmaVergiNoField;

            private string firmaAdiField;

            private System.Nullable<System.DateTime> garantiBaslangicTarihiField;

            private System.Nullable<System.DateTime> garantiBitisTarihiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> DemirbasKayitId
            {
                get
                {
                    return this.demirbasKayitIdField;
                }
                set
                {
                    this.demirbasKayitIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> KunyeNo
            {
                get
                {
                    return this.kunyeNoField;
                }
                set
                {
                    this.kunyeNoField = value;
                }
            }

            /// <remarks/>
            public string CihazinAdi
            {
                get
                {
                    return this.cihazinAdiField;
                }
                set
                {
                    this.cihazinAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<ECihazDurumu> CihazinDurumu
            {
                get
                {
                    return this.cihazinDurumuField;
                }
                set
                {
                    this.cihazinDurumuField = value;
                }
            }

            /// <remarks/>
            public string CalismamaNedeni
            {
                get
                {
                    return this.calismamaNedeniField;
                }
                set
                {
                    this.calismamaNedeniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<EMalzemeEkKapsami> MalzemeEkKapsami
            {
                get
                {
                    return this.malzemeEkKapsamiField;
                }
                set
                {
                    this.malzemeEkKapsamiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BiyomedikalHizmetTurId
            {
                get
                {
                    return this.biyomedikalHizmetTurIdField;
                }
                set
                {
                    this.biyomedikalHizmetTurIdField = value;
                }
            }

            /// <remarks/>
            public string BiyomedikalHizmetTuru
            {
                get
                {
                    return this.biyomedikalHizmetTuruField;
                }
                set
                {
                    this.biyomedikalHizmetTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BiyomedikalTurId
            {
                get
                {
                    return this.biyomedikalTurIdField;
                }
                set
                {
                    this.biyomedikalTurIdField = value;
                }
            }

            /// <remarks/>
            public string BiyomedikalTurAdi
            {
                get
                {
                    return this.biyomedikalTurAdiField;
                }
                set
                {
                    this.biyomedikalTurAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BiyomedikalTanimId
            {
                get
                {
                    return this.biyomedikalTanimIdField;
                }
                set
                {
                    this.biyomedikalTanimIdField = value;
                }
            }

            /// <remarks/>
            public string BiyomedikalTanimAdi
            {
                get
                {
                    return this.biyomedikalTanimAdiField;
                }
                set
                {
                    this.biyomedikalTanimAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BiyomedikalBransId
            {
                get
                {
                    return this.biyomedikalBransIdField;
                }
                set
                {
                    this.biyomedikalBransIdField = value;
                }
            }

            /// <remarks/>
            public string BiyomedikalBransAdi
            {
                get
                {
                    return this.biyomedikalBransAdiField;
                }
                set
                {
                    this.biyomedikalBransAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BiyomedikalYerId
            {
                get
                {
                    return this.biyomedikalYerIdField;
                }
                set
                {
                    this.biyomedikalYerIdField = value;
                }
            }

            /// <remarks/>
            public string BiyomedikalYerAdi
            {
                get
                {
                    return this.biyomedikalYerAdiField;
                }
                set
                {
                    this.biyomedikalYerAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BiyomedikalMarkaId
            {
                get
                {
                    return this.biyomedikalMarkaIdField;
                }
                set
                {
                    this.biyomedikalMarkaIdField = value;
                }
            }

            /// <remarks/>
            public string BiyomedikalMarkaAdi
            {
                get
                {
                    return this.biyomedikalMarkaAdiField;
                }
                set
                {
                    this.biyomedikalMarkaAdiField = value;
                }
            }

            /// <remarks/>
            public string ModelNo
            {
                get
                {
                    return this.modelNoField;
                }
                set
                {
                    this.modelNoField = value;
                }
            }

            /// <remarks/>
            public string SeriNo
            {
                get
                {
                    return this.seriNoField;
                }
                set
                {
                    this.seriNoField = value;
                }
            }

            /// <remarks/>
            public string Barkod
            {
                get
                {
                    return this.barkodField;
                }
                set
                {
                    this.barkodField = value;
                }
            }

            /// <remarks/>
            public string LotPartiNo
            {
                get
                {
                    return this.lotPartiNoField;
                }
                set
                {
                    this.lotPartiNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> GarantiSuresi
            {
                get
                {
                    return this.garantiSuresiField;
                }
                set
                {
                    this.garantiSuresiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> UretimYili
            {
                get
                {
                    return this.uretimYiliField;
                }
                set
                {
                    this.uretimYiliField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> EdinmeYili
            {
                get
                {
                    return this.edinmeYiliField;
                }
                set
                {
                    this.edinmeYiliField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> StokHareketId
            {
                get
                {
                    return this.stokHareketIdField;
                }
                set
                {
                    this.stokHareketIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BirimKayitId
            {
                get
                {
                    return this.birimKayitIdField;
                }
                set
                {
                    this.birimKayitIdField = value;
                }
            }

            /// <remarks/>
            public string BirimAdi
            {
                get
                {
                    return this.birimAdiField;
                }
                set
                {
                    this.birimAdiField = value;
                }
            }

            /// <remarks/>
            public string ZimmetSahibiTc
            {
                get
                {
                    return this.zimmetSahibiTcField;
                }
                set
                {
                    this.zimmetSahibiTcField = value;
                }
            }

            /// <remarks/>
            public string ZimmetSahibi
            {
                get
                {
                    return this.zimmetSahibiField;
                }
                set
                {
                    this.zimmetSahibiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> ZimmetTarihi
            {
                get
                {
                    return this.zimmetTarihiField;
                }
                set
                {
                    this.zimmetTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> ZimmetBirimi
            {
                get
                {
                    return this.zimmetBirimiField;
                }
                set
                {
                    this.zimmetBirimiField = value;
                }
            }

            /// <remarks/>
            public string ZimmetBirimiAdi
            {
                get
                {
                    return this.zimmetBirimiAdiField;
                }
                set
                {
                    this.zimmetBirimiAdiField = value;
                }
            }

            /// <remarks/>
            public string LokasyonId
            {
                get
                {
                    return this.lokasyonIdField;
                }
                set
                {
                    this.lokasyonIdField = value;
                }
            }

            /// <remarks/>
            public string LokasyonAdi
            {
                get
                {
                    return this.lokasyonAdiField;
                }
                set
                {
                    this.lokasyonAdiField = value;
                }
            }

            /// <remarks/>
            public string TasinirSicilNo
            {
                get
                {
                    return this.tasinirSicilNoField;
                }
                set
                {
                    this.tasinirSicilNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BirimDepoId
            {
                get
                {
                    return this.birimDepoIdField;
                }
                set
                {
                    this.birimDepoIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> MalzemeKayitId
            {
                get
                {
                    return this.malzemeKayitIdField;
                }
                set
                {
                    this.malzemeKayitIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<EButceTuru> ButceTuru
            {
                get
                {
                    return this.butceTuruField;
                }
                set
                {
                    this.butceTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> Fiyat
            {
                get
                {
                    return this.fiyatField;
                }
                set
                {
                    this.fiyatField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<EMalzemeNiteligi> CihazNiteligi
            {
                get
                {
                    return this.cihazNiteligiField;
                }
                set
                {
                    this.cihazNiteligiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<EHizmetTedarikTuru> HizmetTedarikTuru
            {
                get
                {
                    return this.hizmetTedarikTuruField;
                }
                set
                {
                    this.hizmetTedarikTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> SozlesmeBaslangicTarihi
            {
                get
                {
                    return this.sozlesmeBaslangicTarihiField;
                }
                set
                {
                    this.sozlesmeBaslangicTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> SozlesmeBitisTarihi
            {
                get
                {
                    return this.sozlesmeBitisTarihiField;
                }
                set
                {
                    this.sozlesmeBitisTarihiField = value;
                }
            }

            /// <remarks/>
            public string SorumluPersonelTc
            {
                get
                {
                    return this.sorumluPersonelTcField;
                }
                set
                {
                    this.sorumluPersonelTcField = value;
                }
            }

            /// <remarks/>
            public string SorumluPersonel
            {
                get
                {
                    return this.sorumluPersonelField;
                }
                set
                {
                    this.sorumluPersonelField = value;
                }
            }

            /// <remarks/>
            public string FirmaVergiNo
            {
                get
                {
                    return this.firmaVergiNoField;
                }
                set
                {
                    this.firmaVergiNoField = value;
                }
            }

            /// <remarks/>
            public string FirmaAdi
            {
                get
                {
                    return this.firmaAdiField;
                }
                set
                {
                    this.firmaAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> GarantiBaslangicTarihi
            {
                get
                {
                    return this.garantiBaslangicTarihiField;
                }
                set
                {
                    this.garantiBaslangicTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> GarantiBitisTarihi
            {
                get
                {
                    return this.garantiBitisTarihiField;
                }
                set
                {
                    this.garantiBitisTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EMalzemeEkKapsami
        {

            /// <remarks/>
            Ek13,

            /// <remarks/>
            Ek14,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EMalzemeNiteligi
        {

            /// <remarks/>
            Demirbas,

            /// <remarks/>
            HizmetAlim,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EHizmetTedarikTuru
        {

            /// <remarks/>
            SonucSutKarsiligiHizmetAlimi,

            /// <remarks/>
            ProtokolKapsamiKurumlarArasiHizmetAlimi,

            /// <remarks/>
            KitSarfKarsiligiHizmetAlimi,

            /// <remarks/>
            SozlesmeKapsamiFirma,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class BiyomedikalDayanikliTasinirSorgu
        {

            private System.Nullable<EMalzemeNiteligi> cihazNiteligiField;

            private System.Nullable<int> birimKayitIdField;

            private System.Nullable<int> demirbasKayitIdField;

            private System.Nullable<long> kunyeNoField;

            private string cihazinAdiField;

            private System.Nullable<ECihazDurumu> cihazinDurumuField;

            private string calismamaNedeniField;

            private System.Nullable<EMalzemeEkKapsami> malzemeEkKapsamiField;

            private System.Nullable<int> biyomedikalTurIdField;

            private System.Nullable<int> biyomedikalTanimIdField;

            private System.Nullable<int> biyomedikalBransIdField;

            private System.Nullable<int> biyomedikalYerIdField;

            private System.Nullable<int> biyomedikalMarkaIdField;

            private string modelNoField;

            private string seriNoField;

            private string barkodField;

            private string lotPartiNoField;

            private System.Nullable<int> garantiSuresiField;

            private System.Nullable<int> uretimYiliField;

            private System.Nullable<int> edinmeYiliField;

            private string tasinirKoduField;

            private System.Nullable<long> stokHareketIdField;

            private System.Nullable<int> birimDepoIdField;

            private System.Nullable<System.DateTime> tarihtenSonraDegisenlerField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<EMalzemeNiteligi> CihazNiteligi
            {
                get
                {
                    return this.cihazNiteligiField;
                }
                set
                {
                    this.cihazNiteligiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BirimKayitId
            {
                get
                {
                    return this.birimKayitIdField;
                }
                set
                {
                    this.birimKayitIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> DemirbasKayitId
            {
                get
                {
                    return this.demirbasKayitIdField;
                }
                set
                {
                    this.demirbasKayitIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> KunyeNo
            {
                get
                {
                    return this.kunyeNoField;
                }
                set
                {
                    this.kunyeNoField = value;
                }
            }

            /// <remarks/>
            public string CihazinAdi
            {
                get
                {
                    return this.cihazinAdiField;
                }
                set
                {
                    this.cihazinAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<ECihazDurumu> CihazinDurumu
            {
                get
                {
                    return this.cihazinDurumuField;
                }
                set
                {
                    this.cihazinDurumuField = value;
                }
            }

            /// <remarks/>
            public string CalismamaNedeni
            {
                get
                {
                    return this.calismamaNedeniField;
                }
                set
                {
                    this.calismamaNedeniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<EMalzemeEkKapsami> MalzemeEkKapsami
            {
                get
                {
                    return this.malzemeEkKapsamiField;
                }
                set
                {
                    this.malzemeEkKapsamiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BiyomedikalTurId
            {
                get
                {
                    return this.biyomedikalTurIdField;
                }
                set
                {
                    this.biyomedikalTurIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BiyomedikalTanimId
            {
                get
                {
                    return this.biyomedikalTanimIdField;
                }
                set
                {
                    this.biyomedikalTanimIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BiyomedikalBransId
            {
                get
                {
                    return this.biyomedikalBransIdField;
                }
                set
                {
                    this.biyomedikalBransIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BiyomedikalYerId
            {
                get
                {
                    return this.biyomedikalYerIdField;
                }
                set
                {
                    this.biyomedikalYerIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BiyomedikalMarkaId
            {
                get
                {
                    return this.biyomedikalMarkaIdField;
                }
                set
                {
                    this.biyomedikalMarkaIdField = value;
                }
            }

            /// <remarks/>
            public string ModelNo
            {
                get
                {
                    return this.modelNoField;
                }
                set
                {
                    this.modelNoField = value;
                }
            }

            /// <remarks/>
            public string SeriNo
            {
                get
                {
                    return this.seriNoField;
                }
                set
                {
                    this.seriNoField = value;
                }
            }

            /// <remarks/>
            public string Barkod
            {
                get
                {
                    return this.barkodField;
                }
                set
                {
                    this.barkodField = value;
                }
            }

            /// <remarks/>
            public string LotPartiNo
            {
                get
                {
                    return this.lotPartiNoField;
                }
                set
                {
                    this.lotPartiNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> GarantiSuresi
            {
                get
                {
                    return this.garantiSuresiField;
                }
                set
                {
                    this.garantiSuresiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> UretimYili
            {
                get
                {
                    return this.uretimYiliField;
                }
                set
                {
                    this.uretimYiliField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> EdinmeYili
            {
                get
                {
                    return this.edinmeYiliField;
                }
                set
                {
                    this.edinmeYiliField = value;
                }
            }

            /// <remarks/>
            public string TasinirKodu
            {
                get
                {
                    return this.tasinirKoduField;
                }
                set
                {
                    this.tasinirKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> StokHareketId
            {
                get
                {
                    return this.stokHareketIdField;
                }
                set
                {
                    this.stokHareketIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> BirimDepoId
            {
                get
                {
                    return this.birimDepoIdField;
                }
                set
                {
                    this.birimDepoIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> TarihtenSonraDegisenler
            {
                get
                {
                    return this.tarihtenSonraDegisenlerField;
                }
                set
                {
                    this.tarihtenSonraDegisenlerField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class zimmetListesiGetDataResultItem
        {

            private int stokHareketIDField;

            private string tasinirKoduField;

            private string malzemeAdiField;

            private decimal fiyatField;

            private string aciklamaField;

            private int miktarField;

            private string sicilNoField;

            private int edinimYiliField;

            private string demirbasNoField;

            private string hbysdetayIDField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string tasinirKodu
            {
                get
                {
                    return this.tasinirKoduField;
                }
                set
                {
                    this.tasinirKoduField = value;
                }
            }

            /// <remarks/>
            public string malzemeAdi
            {
                get
                {
                    return this.malzemeAdiField;
                }
                set
                {
                    this.malzemeAdiField = value;
                }
            }

            /// <remarks/>
            public decimal fiyat
            {
                get
                {
                    return this.fiyatField;
                }
                set
                {
                    this.fiyatField = value;
                }
            }

            /// <remarks/>
            public string aciklama
            {
                get
                {
                    return this.aciklamaField;
                }
                set
                {
                    this.aciklamaField = value;
                }
            }

            /// <remarks/>
            public int miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public string sicilNo
            {
                get
                {
                    return this.sicilNoField;
                }
                set
                {
                    this.sicilNoField = value;
                }
            }

            /// <remarks/>
            public int edinimYili
            {
                get
                {
                    return this.edinimYiliField;
                }
                set
                {
                    this.edinimYiliField = value;
                }
            }

            /// <remarks/>
            public string demirbasNo
            {
                get
                {
                    return this.demirbasNoField;
                }
                set
                {
                    this.demirbasNoField = value;
                }
            }

            /// <remarks/>
            public string hbysdetayID
            {
                get
                {
                    return this.hbysdetayIDField;
                }
                set
                {
                    this.hbysdetayIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class zimmetListesiGetItem
        {

            private int butceYiliField;

            private int depoKayitNoField;

            private System.Nullable<int> islemSiraNoField;

            private string belgeNoField;

            private EButceTurID butceTurIDField;

            /// <remarks/>
            public int butceYili
            {
                get
                {
                    return this.butceYiliField;
                }
                set
                {
                    this.butceYiliField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> islemSiraNo
            {
                get
                {
                    return this.islemSiraNoField;
                }
                set
                {
                    this.islemSiraNoField = value;
                }
            }

            /// <remarks/>
            public string belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            public EButceTurID butceTurID
            {
                get
                {
                    return this.butceTurIDField;
                }
                set
                {
                    this.butceTurIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EButceTurID
        {

            /// <remarks/>
            genelButce,

            /// <remarks/>
            donerSermaye,

            /// <remarks/>
            ozelButce,

            /// <remarks/>
            yurtdisiButce,

            /// <remarks/>
            sgkButce,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class kayittanDusmeListItem
        {

            private int girisStokHareketIDField;

            private decimal miktarField;

            private string hbysKayitNoField;

            /// <remarks/>
            public int girisStokHareketID
            {
                get
                {
                    return this.girisStokHareketIDField;
                }
                set
                {
                    this.girisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public decimal miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public string hbysKayitNo
            {
                get
                {
                    return this.hbysKayitNoField;
                }
                set
                {
                    this.hbysKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(amortismanDetaySonucItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(amortismanInsertSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(amortismanDetayListItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(amortismanInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(sonKullanmaTarihiUpdateItemList))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(sonKullanmaUpdateInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(malzemeBilgileriUpdateItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(girisiOlmayanCikislarItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ilacJenerikAdiItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ilacAtcItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ilacItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ilacSorgulamaSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(yonetimHesabiCetveliItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(yonetimHesabiKriter))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ayniyatMakbuzuUpdateItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(stokHareketLogItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(stokHareketYilSonuItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(yilSonuKriter))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(firmaBilgileriGetItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(firmaBilgileriGetVergiNoSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(unvanTurItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(mkysSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(stokHareketUpdateItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(depoYetkiKontrolSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(depoYetkiKontrolItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(aracModelItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(stokSeviyesiInsertSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(stokSeviyesiInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(cikisKontrolSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(sifreDegistirSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ihtiyacFazlasiItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ihtiyacFazlasiKriterItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(zimmetItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(zimmettenAlSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(zimmettenAlListItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(zimmettenAlInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(sonucZimmetListItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(zimmetInsertSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(zimmetListItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(zimmetInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(kitapInsertUpdateSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(kitapInsertUpdateItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(sonucKayittanDusmeListItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(kayittanDusmeSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(kayittanDusmeInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(demirbasDevirSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(demirbasDevirItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(degerArtisiSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(degerArtisiInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(aracInsertSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(aracInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(cikisFisDetayItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(girisMakbuzDetayItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(cikisFisiItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(cikisFisleriKriter))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(depoGirisMakbuzGetKriter))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(girisMakbuzItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(kisiInsertSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(kisiInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(kisiKontrolSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzKontrolSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(stokHareketBirlikKriter))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(stokHareketItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(stokHareketKriter))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ihtiyacFazlasiIadeItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ihtiyacFazlasiSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ihtiyacFazlasiInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(devirFisiItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(malzemeSiniflandirmaItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(malzemeTibbiSarfItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(malzemeItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(kurumlardanGelenDevirItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(kurumlardanGelenDevirKriter))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(birimUpdateItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(birimKayitIslemleriSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(birimInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(stokHareketSilSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzIptalSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzSilmeSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzDetayInsertGirisSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzDetayInsertGirisItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzInsertCikisSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(stokHareketCikisItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzInsertCikisItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(sonucStokHareketItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(sonucMakbuzDetayItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzInsertGirisSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(demirbasGirisItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzDetayGirisItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzInsertGirisItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(depoUpdateItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(depoKayitIslemleriSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(depoInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(birimDepoItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(birimItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ntKodItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ihaleTarihiUpdateResult))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ihaleTarihiUpdateInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(yetkiKontrolSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ilacEtkenMaddeItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(devirGerceklestiriciSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(devirGerceklestiYapItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(malzemeTeknikOzellikResult))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(teknikOzellikInsertItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(universiteXXXXXXleriSonucItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(yilSonuDevriSonucItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(yilSonuDevriItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(giriseAitCikislarResultItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(malzemeZimmetBilgisiResult))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(demirbasGetDataResult))]

        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzUpdateSonuc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzDetayUpdateItem))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(makbuzUpdateItem))]

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class entitiesBaseClass
        {
        }



        /// <remarks>

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzUpdateItem : entitiesBaseClass
        {

            private long ayniyatMakbuzIdField;

            private EButceTurID butceTurIDField;

            private int makbuzNoField;

            private System.DateTime makbuzTarihiField;

            private string muayeneNoField;

            private System.Nullable<System.DateTime> muayeneTarihiField;

            private string dayanagiBelgeNoField;

            private System.Nullable<System.DateTime> dayanagiBelgeTarihiField;

            private int depoKayitNoField;

            private string teslimEdenField;

            private string fisAciklamaField;

            private string teslimAlanField;

            private string hbysIDField;

            private System.Nullable<System.DateTime> ihaleTarihiField;

            private string ihaleKayitNoField;

            private string firmaVergiKayitNoField;

            private makbuzDetayUpdateItem[] makbuzDetayListField;

            /// <remarks/>
            public long ayniyatMakbuzId
            {
                get
                {
                    return this.ayniyatMakbuzIdField;
                }
                set
                {
                    this.ayniyatMakbuzIdField = value;
                }
            }

            /// <remarks/>
            public EButceTurID butceTurID
            {
                get
                {
                    return this.butceTurIDField;
                }
                set
                {
                    this.butceTurIDField = value;
                }
            }

            /// <remarks/>
            public int makbuzNo
            {
                get
                {
                    return this.makbuzNoField;
                }
                set
                {
                    this.makbuzNoField = value;
                }
            }

            /// <remarks/>
            public System.DateTime makbuzTarihi
            {
                get
                {
                    return this.makbuzTarihiField;
                }
                set
                {
                    this.makbuzTarihiField = value;
                }
            }

            /// <remarks/>
            public string muayeneNo
            {
                get
                {
                    return this.muayeneNoField;
                }
                set
                {
                    this.muayeneNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> muayeneTarihi
            {
                get
                {
                    return this.muayeneTarihiField;
                }
                set
                {
                    this.muayeneTarihiField = value;
                }
            }

            /// <remarks/>
            public string dayanagiBelgeNo
            {
                get
                {
                    return this.dayanagiBelgeNoField;
                }
                set
                {
                    this.dayanagiBelgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> dayanagiBelgeTarihi
            {
                get
                {
                    return this.dayanagiBelgeTarihiField;
                }
                set
                {
                    this.dayanagiBelgeTarihiField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string teslimEden
            {
                get
                {
                    return this.teslimEdenField;
                }
                set
                {
                    this.teslimEdenField = value;
                }
            }

            /// <remarks/>
            public string fisAciklama
            {
                get
                {
                    return this.fisAciklamaField;
                }
                set
                {
                    this.fisAciklamaField = value;
                }
            }

            /// <remarks/>
            public string teslimAlan
            {
                get
                {
                    return this.teslimAlanField;
                }
                set
                {
                    this.teslimAlanField = value;
                }
            }

            /// <remarks/>
            public string hbysID
            {
                get
                {
                    return this.hbysIDField;
                }
                set
                {
                    this.hbysIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> ihaleTarihi
            {
                get
                {
                    return this.ihaleTarihiField;
                }
                set
                {
                    this.ihaleTarihiField = value;
                }
            }

            /// <remarks/>
            public string ihaleKayitNo
            {
                get
                {
                    return this.ihaleKayitNoField;
                }
                set
                {
                    this.ihaleKayitNoField = value;
                }
            }

            /// <remarks/>
            public string firmaVergiKayitNo
            {
                get
                {
                    return this.firmaVergiKayitNoField;
                }
                set
                {
                    this.firmaVergiKayitNoField = value;
                }
            }

            /// <remarks/>
            public makbuzDetayUpdateItem[] makbuzDetayList
            {
                get
                {
                    return this.makbuzDetayListField;
                }
                set
                {
                    this.makbuzDetayListField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzDetayUpdateItem : entitiesBaseClass
        {

            private long makbuzDetayKayitNoField;

            private decimal vergisizBirimFiyatField;

            private System.Nullable<decimal> indirimOraniField;

            private System.Nullable<decimal> kdvOraniField;

            private string hbysMakbuzDetayKayitNoField;

            /// <remarks/>
            public long makbuzDetayKayitNo
            {
                get
                {
                    return this.makbuzDetayKayitNoField;
                }
                set
                {
                    this.makbuzDetayKayitNoField = value;
                }
            }

            /// <remarks/>
            public decimal vergisizBirimFiyat
            {
                get
                {
                    return this.vergisizBirimFiyatField;
                }
                set
                {
                    this.vergisizBirimFiyatField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> indirimOrani
            {
                get
                {
                    return this.indirimOraniField;
                }
                set
                {
                    this.indirimOraniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> kdvOrani
            {
                get
                {
                    return this.kdvOraniField;
                }
                set
                {
                    this.kdvOraniField = value;
                }
            }

            /// <remarks/>
            public string hbysMakbuzDetayKayitNo
            {
                get
                {
                    return this.hbysMakbuzDetayKayitNoField;
                }
                set
                {
                    this.hbysMakbuzDetayKayitNoField = value;
                }
            }
        }
        /// </remarks>

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzUpdateSonuc : entitiesBaseClass
        {

            private string mesajField;

            private bool basariDurumuField;

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class amortismanDetaySonucItem : entitiesBaseClass
        {

            private int amortismanDetayIDField;

            private int amortismanIDField;

            private string hbysKayitNoField;

            /// <remarks/>
            public int amortismanDetayID
            {
                get
                {
                    return this.amortismanDetayIDField;
                }
                set
                {
                    this.amortismanDetayIDField = value;
                }
            }

            /// <remarks/>
            public int amortismanID
            {
                get
                {
                    return this.amortismanIDField;
                }
                set
                {
                    this.amortismanIDField = value;
                }
            }

            /// <remarks/>
            public string hbysKayitNo
            {
                get
                {
                    return this.hbysKayitNoField;
                }
                set
                {
                    this.hbysKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class amortismanInsertSonuc : entitiesBaseClass
        {

            private System.Nullable<int> islemKayitNoField;

            private bool basariDurumuField;

            private amortismanDetaySonucItem[] detaySonucListField;

            private string mesajField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public amortismanDetaySonucItem[] detaySonucList
            {
                get
                {
                    return this.detaySonucListField;
                }
                set
                {
                    this.detaySonucListField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class amortismanDetayListItem : entitiesBaseClass
        {

            private int amortismanIDField;

            private System.Nullable<decimal> ydobaTutariField;

            private System.Nullable<decimal> ydsTutariField;

            private System.Nullable<decimal> ydsbaTutariField;

            private System.Nullable<decimal> baTutariField;

            private System.Nullable<decimal> ydombTutariField;

            private System.Nullable<decimal> netDegerField;

            private decimal amortismanOraniField;

            private System.Nullable<decimal> yenidenDegerlemeOraniField;

            private System.Nullable<decimal> cyaTutariField;

            private decimal degerArtirimiField;

            private int yilField;

            private string hbysKayitNoField;

            /// <remarks/>
            public int amortismanID
            {
                get
                {
                    return this.amortismanIDField;
                }
                set
                {
                    this.amortismanIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> ydobaTutari
            {
                get
                {
                    return this.ydobaTutariField;
                }
                set
                {
                    this.ydobaTutariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> ydsTutari
            {
                get
                {
                    return this.ydsTutariField;
                }
                set
                {
                    this.ydsTutariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> ydsbaTutari
            {
                get
                {
                    return this.ydsbaTutariField;
                }
                set
                {
                    this.ydsbaTutariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> baTutari
            {
                get
                {
                    return this.baTutariField;
                }
                set
                {
                    this.baTutariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> ydombTutari
            {
                get
                {
                    return this.ydombTutariField;
                }
                set
                {
                    this.ydombTutariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> netDeger
            {
                get
                {
                    return this.netDegerField;
                }
                set
                {
                    this.netDegerField = value;
                }
            }

            /// <remarks/>
            public decimal amortismanOrani
            {
                get
                {
                    return this.amortismanOraniField;
                }
                set
                {
                    this.amortismanOraniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> yenidenDegerlemeOrani
            {
                get
                {
                    return this.yenidenDegerlemeOraniField;
                }
                set
                {
                    this.yenidenDegerlemeOraniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> cyaTutari
            {
                get
                {
                    return this.cyaTutariField;
                }
                set
                {
                    this.cyaTutariField = value;
                }
            }

            /// <remarks/>
            public decimal degerArtirimi
            {
                get
                {
                    return this.degerArtirimiField;
                }
                set
                {
                    this.degerArtirimiField = value;
                }
            }

            /// <remarks/>
            public int yil
            {
                get
                {
                    return this.yilField;
                }
                set
                {
                    this.yilField = value;
                }
            }

            /// <remarks/>
            public string hbysKayitNo
            {
                get
                {
                    return this.hbysKayitNoField;
                }
                set
                {
                    this.hbysKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class amortismanInsertItem : entitiesBaseClass
        {

            private int stokHareketIDField;

            private decimal degerArtirimiField;

            private int edinmeYiliField;

            private amortismanDetayListItem[] detayListField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            public decimal degerArtirimi
            {
                get
                {
                    return this.degerArtirimiField;
                }
                set
                {
                    this.degerArtirimiField = value;
                }
            }

            /// <remarks/>
            public int edinmeYili
            {
                get
                {
                    return this.edinmeYiliField;
                }
                set
                {
                    this.edinmeYiliField = value;
                }
            }

            /// <remarks/>
            public amortismanDetayListItem[] detayList
            {
                get
                {
                    return this.detayListField;
                }
                set
                {
                    this.detayListField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class sonKullanmaTarihiUpdateItemList : entitiesBaseClass
        {

            private System.DateTime sonKullanmaTarihiField;

            private int stokHareketIDField;

            /// <remarks/>
            public System.DateTime sonKullanmaTarihi
            {
                get
                {
                    return this.sonKullanmaTarihiField;
                }
                set
                {
                    this.sonKullanmaTarihiField = value;
                }
            }

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class sonKullanmaUpdateInsertItem : entitiesBaseClass
        {

            private sonKullanmaTarihiUpdateItemList[] listField;

            private int depoKayitNoField;

            /// <remarks/>
            public sonKullanmaTarihiUpdateItemList[] list
            {
                get
                {
                    return this.listField;
                }
                set
                {
                    this.listField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class malzemeBilgileriUpdateItem : entitiesBaseClass
        {

            private int stokHareketIDField;

            private string barkodField;

            private string malzemeAciklamaField;

            private int malzemeKayitIDField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string barkod
            {
                get
                {
                    return this.barkodField;
                }
                set
                {
                    this.barkodField = value;
                }
            }

            /// <remarks/>
            public string malzemeAciklama
            {
                get
                {
                    return this.malzemeAciklamaField;
                }
                set
                {
                    this.malzemeAciklamaField = value;
                }
            }

            /// <remarks/>
            public int malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class girisiOlmayanCikislarItem : entitiesBaseClass
        {

            private int cikisStokHareketIDField;

            private int girisStokHareketIDField;

            private string cikisTasinirKoduField;

            private decimal cikisFiyatiField;

            private decimal cikisMiktariField;

            private decimal cikisTutariField;

            private string demirbasNoField;

            private int malzemeKayitIDField;

            private string tasinirKoduField;

            private System.DateTime cikisTarihiField;

            private string cikisBelgeNoField;

            /// <remarks/>
            public int cikisStokHareketID
            {
                get
                {
                    return this.cikisStokHareketIDField;
                }
                set
                {
                    this.cikisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public int girisStokHareketID
            {
                get
                {
                    return this.girisStokHareketIDField;
                }
                set
                {
                    this.girisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string cikisTasinirKodu
            {
                get
                {
                    return this.cikisTasinirKoduField;
                }
                set
                {
                    this.cikisTasinirKoduField = value;
                }
            }

            /// <remarks/>
            public decimal cikisFiyati
            {
                get
                {
                    return this.cikisFiyatiField;
                }
                set
                {
                    this.cikisFiyatiField = value;
                }
            }

            /// <remarks/>
            public decimal cikisMiktari
            {
                get
                {
                    return this.cikisMiktariField;
                }
                set
                {
                    this.cikisMiktariField = value;
                }
            }

            /// <remarks/>
            public decimal cikisTutari
            {
                get
                {
                    return this.cikisTutariField;
                }
                set
                {
                    this.cikisTutariField = value;
                }
            }

            /// <remarks/>
            public string demirbasNo
            {
                get
                {
                    return this.demirbasNoField;
                }
                set
                {
                    this.demirbasNoField = value;
                }
            }

            /// <remarks/>
            public int malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public string tasinirKodu
            {
                get
                {
                    return this.tasinirKoduField;
                }
                set
                {
                    this.tasinirKoduField = value;
                }
            }

            /// <remarks/>
            public System.DateTime cikisTarihi
            {
                get
                {
                    return this.cikisTarihiField;
                }
                set
                {
                    this.cikisTarihiField = value;
                }
            }

            /// <remarks/>
            public string cikisBelgeNo
            {
                get
                {
                    return this.cikisBelgeNoField;
                }
                set
                {
                    this.cikisBelgeNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ilacJenerikAdiItem : entitiesBaseClass
        {

            private int jenerikIDField;

            private string jenerikAdiField;

            private string formField;

            /// <remarks/>
            public int jenerikID
            {
                get
                {
                    return this.jenerikIDField;
                }
                set
                {
                    this.jenerikIDField = value;
                }
            }

            /// <remarks/>
            public string jenerikAdi
            {
                get
                {
                    return this.jenerikAdiField;
                }
                set
                {
                    this.jenerikAdiField = value;
                }
            }

            /// <remarks/>
            public string form
            {
                get
                {
                    return this.formField;
                }
                set
                {
                    this.formField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ilacAtcItem : entitiesBaseClass
        {

            private string barkodField;

            private string atcAdiField;

            private string atcKoduField;

            private string atcTanimiField;

            /// <remarks/>
            public string barkod
            {
                get
                {
                    return this.barkodField;
                }
                set
                {
                    this.barkodField = value;
                }
            }

            /// <remarks/>
            public string atcAdi
            {
                get
                {
                    return this.atcAdiField;
                }
                set
                {
                    this.atcAdiField = value;
                }
            }

            /// <remarks/>
            public string atcKodu
            {
                get
                {
                    return this.atcKoduField;
                }
                set
                {
                    this.atcKoduField = value;
                }
            }

            /// <remarks/>
            public string atcTanimi
            {
                get
                {
                    return this.atcTanimiField;
                }
                set
                {
                    this.atcTanimiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ilacItem : entitiesBaseClass
        {

            private string barkodField;

            private string ilacAdiField;

            /// <remarks/>
            public string barkod
            {
                get
                {
                    return this.barkodField;
                }
                set
                {
                    this.barkodField = value;
                }
            }

            /// <remarks/>
            public string ilacAdi
            {
                get
                {
                    return this.ilacAdiField;
                }
                set
                {
                    this.ilacAdiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ilacSorgulamaSonuc : entitiesBaseClass
        {

            private ilacItem[] ilacListField;

            private ilacAtcItem[] atcListField;

            private ilacEtkenMaddeItem[] etkenMaddeListField;

            private ilacJenerikAdiItem[] jenerikListField;

            private string mesajField;

            /// <remarks/>
            public ilacItem[] ilacList
            {
                get
                {
                    return this.ilacListField;
                }
                set
                {
                    this.ilacListField = value;
                }
            }

            /// <remarks/>
            public ilacAtcItem[] atcList
            {
                get
                {
                    return this.atcListField;
                }
                set
                {
                    this.atcListField = value;
                }
            }

            /// <remarks/>
            public ilacEtkenMaddeItem[] etkenMaddeList
            {
                get
                {
                    return this.etkenMaddeListField;
                }
                set
                {
                    this.etkenMaddeListField = value;
                }
            }

            /// <remarks/>
            public ilacJenerikAdiItem[] jenerikList
            {
                get
                {
                    return this.jenerikListField;
                }
                set
                {
                    this.jenerikListField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ilacEtkenMaddeItem : entitiesBaseClass
        {

            private string barkodField;

            private string etkenMaddeField;

            private string miktarField;

            private string birimiField;

            /// <remarks/>
            public string barkod
            {
                get
                {
                    return this.barkodField;
                }
                set
                {
                    this.barkodField = value;
                }
            }

            /// <remarks/>
            public string etkenMadde
            {
                get
                {
                    return this.etkenMaddeField;
                }
                set
                {
                    this.etkenMaddeField = value;
                }
            }

            /// <remarks/>
            public string miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public string birimi
            {
                get
                {
                    return this.birimiField;
                }
                set
                {
                    this.birimiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class yonetimHesabiCetveliItem : entitiesBaseClass
        {

            private string tasinirKoduDuzey1Field;

            private string tasinirKoduDuzey2Field;

            private string tasinirAdiField;

            private string tasinirAdiDuzey1AdiField;

            private string harcamaKoduField;

            private decimal gecenYildanDevirEdenMiktarField;

            private decimal gecenYildanDevredenTutarField;

            private decimal yilIcindeGirenMiktarField;

            private decimal yilIcindeGirenTutarField;

            private decimal yilIcindeCikanMiktarField;

            private decimal yilIcindeCikanTutarField;

            private decimal gelecekYilaDevredenMiktarField;

            private decimal gelecekYilaDevredenTutarField;

            private string ambarlarArasiDevirDurumuField;

            /// <remarks/>
            public string tasinirKoduDuzey1
            {
                get
                {
                    return this.tasinirKoduDuzey1Field;
                }
                set
                {
                    this.tasinirKoduDuzey1Field = value;
                }
            }

            /// <remarks/>
            public string tasinirKoduDuzey2
            {
                get
                {
                    return this.tasinirKoduDuzey2Field;
                }
                set
                {
                    this.tasinirKoduDuzey2Field = value;
                }
            }

            /// <remarks/>
            public string tasinirAdi
            {
                get
                {
                    return this.tasinirAdiField;
                }
                set
                {
                    this.tasinirAdiField = value;
                }
            }

            /// <remarks/>
            public string tasinirAdiDuzey1Adi
            {
                get
                {
                    return this.tasinirAdiDuzey1AdiField;
                }
                set
                {
                    this.tasinirAdiDuzey1AdiField = value;
                }
            }

            /// <remarks/>
            public string harcamaKodu
            {
                get
                {
                    return this.harcamaKoduField;
                }
                set
                {
                    this.harcamaKoduField = value;
                }
            }

            /// <remarks/>
            public decimal gecenYildanDevirEdenMiktar
            {
                get
                {
                    return this.gecenYildanDevirEdenMiktarField;
                }
                set
                {
                    this.gecenYildanDevirEdenMiktarField = value;
                }
            }

            /// <remarks/>
            public decimal gecenYildanDevredenTutar
            {
                get
                {
                    return this.gecenYildanDevredenTutarField;
                }
                set
                {
                    this.gecenYildanDevredenTutarField = value;
                }
            }

            /// <remarks/>
            public decimal yilIcindeGirenMiktar
            {
                get
                {
                    return this.yilIcindeGirenMiktarField;
                }
                set
                {
                    this.yilIcindeGirenMiktarField = value;
                }
            }

            /// <remarks/>
            public decimal yilIcindeGirenTutar
            {
                get
                {
                    return this.yilIcindeGirenTutarField;
                }
                set
                {
                    this.yilIcindeGirenTutarField = value;
                }
            }

            /// <remarks/>
            public decimal yilIcindeCikanMiktar
            {
                get
                {
                    return this.yilIcindeCikanMiktarField;
                }
                set
                {
                    this.yilIcindeCikanMiktarField = value;
                }
            }

            /// <remarks/>
            public decimal yilIcindeCikanTutar
            {
                get
                {
                    return this.yilIcindeCikanTutarField;
                }
                set
                {
                    this.yilIcindeCikanTutarField = value;
                }
            }

            /// <remarks/>
            public decimal gelecekYilaDevredenMiktar
            {
                get
                {
                    return this.gelecekYilaDevredenMiktarField;
                }
                set
                {
                    this.gelecekYilaDevredenMiktarField = value;
                }
            }

            /// <remarks/>
            public decimal gelecekYilaDevredenTutar
            {
                get
                {
                    return this.gelecekYilaDevredenTutarField;
                }
                set
                {
                    this.gelecekYilaDevredenTutarField = value;
                }
            }

            /// <remarks/>
            public string ambarlarArasiDevirDurumu
            {
                get
                {
                    return this.ambarlarArasiDevirDurumuField;
                }
                set
                {
                    this.ambarlarArasiDevirDurumuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class yonetimHesabiKriter : entitiesBaseClass
        {

            private string butceTuruField;

            private int butceYiliField;

            private string tasinirKoduField;

            private int depoKayitNoField;

            /// <remarks/>
            public string butceTuru
            {
                get
                {
                    return this.butceTuruField;
                }
                set
                {
                    this.butceTuruField = value;
                }
            }

            /// <remarks/>
            public int butceYili
            {
                get
                {
                    return this.butceYiliField;
                }
                set
                {
                    this.butceYiliField = value;
                }
            }

            /// <remarks/>
            public string tasinirKodu
            {
                get
                {
                    return this.tasinirKoduField;
                }
                set
                {
                    this.tasinirKoduField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ayniyatMakbuzuUpdateItem : entitiesBaseClass
        {

            private int ayniyatMakbuzIDField;

            private System.Nullable<System.DateTime> ihaleTarihiField;

            private string ihaleKayitNoField;

            private EAlimYontemiID alimYontemiField;

            private EMalzemeGrupID malzemeGrubuField;

            /// <remarks/>
            public int ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> ihaleTarihi
            {
                get
                {
                    return this.ihaleTarihiField;
                }
                set
                {
                    this.ihaleTarihiField = value;
                }
            }

            /// <remarks/>
            public string ihaleKayitNo
            {
                get
                {
                    return this.ihaleKayitNoField;
                }
                set
                {
                    this.ihaleKayitNoField = value;
                }
            }

            /// <remarks/>
            public EAlimYontemiID alimYontemi
            {
                get
                {
                    return this.alimYontemiField;
                }
                set
                {
                    this.alimYontemiField = value;
                }
            }

            /// <remarks/>
            public EMalzemeGrupID malzemeGrubu
            {
                get
                {
                    return this.malzemeGrubuField;
                }
                set
                {
                    this.malzemeGrubuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EAlimYontemiID
        {

            /// <remarks/>
            acikIhale,

            /// <remarks/>
            madde21fPazarlik,

            /// <remarks/>
            madde22aDogrudanTemin,

            /// <remarks/>
            madde22bDogrudanTemin,

            /// <remarks/>
            madde22cDogrudanTemin,

            /// <remarks/>
            madde22dDogrudanTemin,

            /// <remarks/>
            madde22fDogrudanTemin,

            /// <remarks/>
            madde3eDMO,

            /// <remarks/>
            madde21bPazarlik,

            /// <remarks/>
            belliIstekliler,

            /// <remarks/>
            cerceveSozlesmeAcikIhale,

            /// <remarks/>
            test,

            /// <remarks/>
            madde3h,

            /// <remarks/>
            digerIsAvanslari,

            /// <remarks/>
            madde3cDunyaBankasindanAlinan,

            /// <remarks/>
            madde21aPazarlik,

            /// <remarks/>
            khk696IleAlimlar,

            /// <remarks/>
            dmoSaglikMarket,

            /// <remarks/>
            ushas,

            /// <remarks/>
            bos,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EMalzemeGrupID
        {

            /// <remarks/>
            ilac,

            /// <remarks/>
            tibbiSarf,

            /// <remarks/>
            tibbiCihaz,

            /// <remarks/>
            diger,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class stokHareketLogItem : entitiesBaseClass
        {

            private int stokHareketIDField;

            private string stokHareketTurIDField;

            private string islemTuruField;

            private string butceTuruIDField;

            private decimal miktarField;

            private decimal vergiliBirimFiyatField;

            private string olcuBirimIDField;

            private int belgeNoField;

            private System.Nullable<System.DateTime> belgeTarihiField;

            private string dayanakBelgeNoField;

            private System.Nullable<System.DateTime> dayanakBelgeTarihiField;

            private string malzemeDigerAciklamaField;

            private System.Nullable<int> depoKayitNoField;

            private System.Nullable<int> malzemeKayitIDField;

            private string cikisTCKimlikNoField;

            private System.Nullable<System.DateTime> uretimTarihiField;

            private System.Nullable<System.DateTime> sonKullanmaTarihiField;

            private System.Nullable<int> demirbasNoField;

            private System.Nullable<int> girisStokHareketIDField;

            private System.Nullable<int> cikisBirimDepoIDField;

            private System.Nullable<int> cikisBirimKayitNoField;

            private string malzemeKoduField;

            private string malzemeAdiField;

            private string malzemeTurIDField;

            private System.Nullable<int> islemKayitNoField;

            private System.Nullable<int> ayniyatMakbuzIDField;

            private System.DateTime iadeTarihiField;

            private System.Nullable<int> edinmeYiliField;

            private string urunBarkoduField;

            private string digerBirimAdiField;

            private string logTarihField;

            private string logKullaniciField;

            private string logIslemTuruField;

            private string logIpField;

            private string logMakinaField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string stokHareketTurID
            {
                get
                {
                    return this.stokHareketTurIDField;
                }
                set
                {
                    this.stokHareketTurIDField = value;
                }
            }

            /// <remarks/>
            public string islemTuru
            {
                get
                {
                    return this.islemTuruField;
                }
                set
                {
                    this.islemTuruField = value;
                }
            }

            /// <remarks/>
            public string butceTuruID
            {
                get
                {
                    return this.butceTuruIDField;
                }
                set
                {
                    this.butceTuruIDField = value;
                }
            }

            /// <remarks/>
            public decimal miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public decimal vergiliBirimFiyat
            {
                get
                {
                    return this.vergiliBirimFiyatField;
                }
                set
                {
                    this.vergiliBirimFiyatField = value;
                }
            }

            /// <remarks/>
            public string olcuBirimID
            {
                get
                {
                    return this.olcuBirimIDField;
                }
                set
                {
                    this.olcuBirimIDField = value;
                }
            }

            /// <remarks/>
            public int belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string dayanakBelgeNo
            {
                get
                {
                    return this.dayanakBelgeNoField;
                }
                set
                {
                    this.dayanakBelgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> dayanakBelgeTarihi
            {
                get
                {
                    return this.dayanakBelgeTarihiField;
                }
                set
                {
                    this.dayanakBelgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string malzemeDigerAciklama
            {
                get
                {
                    return this.malzemeDigerAciklamaField;
                }
                set
                {
                    this.malzemeDigerAciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public string cikisTCKimlikNo
            {
                get
                {
                    return this.cikisTCKimlikNoField;
                }
                set
                {
                    this.cikisTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> uretimTarihi
            {
                get
                {
                    return this.uretimTarihiField;
                }
                set
                {
                    this.uretimTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> sonKullanmaTarihi
            {
                get
                {
                    return this.sonKullanmaTarihiField;
                }
                set
                {
                    this.sonKullanmaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> demirbasNo
            {
                get
                {
                    return this.demirbasNoField;
                }
                set
                {
                    this.demirbasNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> girisStokHareketID
            {
                get
                {
                    return this.girisStokHareketIDField;
                }
                set
                {
                    this.girisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisBirimDepoID
            {
                get
                {
                    return this.cikisBirimDepoIDField;
                }
                set
                {
                    this.cikisBirimDepoIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisBirimKayitNo
            {
                get
                {
                    return this.cikisBirimKayitNoField;
                }
                set
                {
                    this.cikisBirimKayitNoField = value;
                }
            }

            /// <remarks/>
            public string malzemeKodu
            {
                get
                {
                    return this.malzemeKoduField;
                }
                set
                {
                    this.malzemeKoduField = value;
                }
            }

            /// <remarks/>
            public string malzemeAdi
            {
                get
                {
                    return this.malzemeAdiField;
                }
                set
                {
                    this.malzemeAdiField = value;
                }
            }

            /// <remarks/>
            public string malzemeTurID
            {
                get
                {
                    return this.malzemeTurIDField;
                }
                set
                {
                    this.malzemeTurIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }

            /// <remarks/>
            public System.DateTime iadeTarihi
            {
                get
                {
                    return this.iadeTarihiField;
                }
                set
                {
                    this.iadeTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> edinmeYili
            {
                get
                {
                    return this.edinmeYiliField;
                }
                set
                {
                    this.edinmeYiliField = value;
                }
            }

            /// <remarks/>
            public string urunBarkodu
            {
                get
                {
                    return this.urunBarkoduField;
                }
                set
                {
                    this.urunBarkoduField = value;
                }
            }

            /// <remarks/>
            public string digerBirimAdi
            {
                get
                {
                    return this.digerBirimAdiField;
                }
                set
                {
                    this.digerBirimAdiField = value;
                }
            }

            /// <remarks/>
            public string logTarih
            {
                get
                {
                    return this.logTarihField;
                }
                set
                {
                    this.logTarihField = value;
                }
            }

            /// <remarks/>
            public string logKullanici
            {
                get
                {
                    return this.logKullaniciField;
                }
                set
                {
                    this.logKullaniciField = value;
                }
            }

            /// <remarks/>
            public string logIslemTuru
            {
                get
                {
                    return this.logIslemTuruField;
                }
                set
                {
                    this.logIslemTuruField = value;
                }
            }

            /// <remarks/>
            public string logIp
            {
                get
                {
                    return this.logIpField;
                }
                set
                {
                    this.logIpField = value;
                }
            }

            /// <remarks/>
            public string logMakina
            {
                get
                {
                    return this.logMakinaField;
                }
                set
                {
                    this.logMakinaField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class stokHareketYilSonuItem : entitiesBaseClass
        {

            private int stokHareketIDField;

            private string stokHareketTurIDField;

            private string islemTuruField;

            private string butceTuruIDField;

            private decimal miktarField;

            private decimal vergiliBirimFiyatField;

            private string olcuBirimIDField;

            private int belgeNoField;

            private System.Nullable<System.DateTime> belgeTarihiField;

            private string dayanakBelgeNoField;

            private System.Nullable<System.DateTime> dayanakBelgeTarihiField;

            private string malzemeDigerAciklamaField;

            private System.Nullable<int> depoKayitNoField;

            private System.Nullable<int> malzemeKayitIDField;

            private string cikisTCKimlikNoField;

            private System.Nullable<System.DateTime> uretimTarihiField;

            private System.Nullable<System.DateTime> sonKullanmaTarihiField;

            private System.Nullable<int> demirbasNoField;

            private System.Nullable<int> girisStokHareketIDField;

            private System.Nullable<int> cikisBirimDepoIDField;

            private System.Nullable<int> cikisBirimKayitNoField;

            private string malzemeKoduField;

            private string malzemeAdiField;

            private string malzemeTurIDField;

            private System.Nullable<int> islemKayitNoField;

            private System.Nullable<int> ayniyatMakbuzIDField;

            private System.DateTime iadeTarihiField;

            private System.Nullable<int> edinmeYiliField;

            private string urunBarkoduField;

            private string digerBirimAdiField;

            private System.Nullable<decimal> cikisMiktariField;

            private System.Nullable<decimal> depodakiMiktarField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string stokHareketTurID
            {
                get
                {
                    return this.stokHareketTurIDField;
                }
                set
                {
                    this.stokHareketTurIDField = value;
                }
            }

            /// <remarks/>
            public string islemTuru
            {
                get
                {
                    return this.islemTuruField;
                }
                set
                {
                    this.islemTuruField = value;
                }
            }

            /// <remarks/>
            public string butceTuruID
            {
                get
                {
                    return this.butceTuruIDField;
                }
                set
                {
                    this.butceTuruIDField = value;
                }
            }

            /// <remarks/>
            public decimal miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public decimal vergiliBirimFiyat
            {
                get
                {
                    return this.vergiliBirimFiyatField;
                }
                set
                {
                    this.vergiliBirimFiyatField = value;
                }
            }

            /// <remarks/>
            public string olcuBirimID
            {
                get
                {
                    return this.olcuBirimIDField;
                }
                set
                {
                    this.olcuBirimIDField = value;
                }
            }

            /// <remarks/>
            public int belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string dayanakBelgeNo
            {
                get
                {
                    return this.dayanakBelgeNoField;
                }
                set
                {
                    this.dayanakBelgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> dayanakBelgeTarihi
            {
                get
                {
                    return this.dayanakBelgeTarihiField;
                }
                set
                {
                    this.dayanakBelgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string malzemeDigerAciklama
            {
                get
                {
                    return this.malzemeDigerAciklamaField;
                }
                set
                {
                    this.malzemeDigerAciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public string cikisTCKimlikNo
            {
                get
                {
                    return this.cikisTCKimlikNoField;
                }
                set
                {
                    this.cikisTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> uretimTarihi
            {
                get
                {
                    return this.uretimTarihiField;
                }
                set
                {
                    this.uretimTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> sonKullanmaTarihi
            {
                get
                {
                    return this.sonKullanmaTarihiField;
                }
                set
                {
                    this.sonKullanmaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> demirbasNo
            {
                get
                {
                    return this.demirbasNoField;
                }
                set
                {
                    this.demirbasNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> girisStokHareketID
            {
                get
                {
                    return this.girisStokHareketIDField;
                }
                set
                {
                    this.girisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisBirimDepoID
            {
                get
                {
                    return this.cikisBirimDepoIDField;
                }
                set
                {
                    this.cikisBirimDepoIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisBirimKayitNo
            {
                get
                {
                    return this.cikisBirimKayitNoField;
                }
                set
                {
                    this.cikisBirimKayitNoField = value;
                }
            }

            /// <remarks/>
            public string malzemeKodu
            {
                get
                {
                    return this.malzemeKoduField;
                }
                set
                {
                    this.malzemeKoduField = value;
                }
            }

            /// <remarks/>
            public string malzemeAdi
            {
                get
                {
                    return this.malzemeAdiField;
                }
                set
                {
                    this.malzemeAdiField = value;
                }
            }

            /// <remarks/>
            public string malzemeTurID
            {
                get
                {
                    return this.malzemeTurIDField;
                }
                set
                {
                    this.malzemeTurIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }

            /// <remarks/>
            public System.DateTime iadeTarihi
            {
                get
                {
                    return this.iadeTarihiField;
                }
                set
                {
                    this.iadeTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> edinmeYili
            {
                get
                {
                    return this.edinmeYiliField;
                }
                set
                {
                    this.edinmeYiliField = value;
                }
            }

            /// <remarks/>
            public string urunBarkodu
            {
                get
                {
                    return this.urunBarkoduField;
                }
                set
                {
                    this.urunBarkoduField = value;
                }
            }

            /// <remarks/>
            public string digerBirimAdi
            {
                get
                {
                    return this.digerBirimAdiField;
                }
                set
                {
                    this.digerBirimAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> cikisMiktari
            {
                get
                {
                    return this.cikisMiktariField;
                }
                set
                {
                    this.cikisMiktariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> depodakiMiktar
            {
                get
                {
                    return this.depodakiMiktarField;
                }
                set
                {
                    this.depodakiMiktarField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class yilSonuKriter : entitiesBaseClass
        {

            private int butceYiliField;

            private int depoKayitNoField;

            private string tasinirKoduField;

            private string butceTuruField;

            private string ilKoduField;

            private int[] malzemeKayitIdListesiField;

            /// <remarks/>
            public int butceYili
            {
                get
                {
                    return this.butceYiliField;
                }
                set
                {
                    this.butceYiliField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string tasinirKodu
            {
                get
                {
                    return this.tasinirKoduField;
                }
                set
                {
                    this.tasinirKoduField = value;
                }
            }

            /// <remarks/>
            public string butceTuru
            {
                get
                {
                    return this.butceTuruField;
                }
                set
                {
                    this.butceTuruField = value;
                }
            }

            /// <remarks/>
            public string ilKodu
            {
                get
                {
                    return this.ilKoduField;
                }
                set
                {
                    this.ilKoduField = value;
                }
            }

            /// <remarks/>
            public int[] malzemeKayitIdListesi
            {
                get
                {
                    return this.malzemeKayitIdListesiField;
                }
                set
                {
                    this.malzemeKayitIdListesiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class firmaBilgileriGetItem : entitiesBaseClass
        {

            private string unvanField;

            private string adres1Field;

            private string adres2Field;

            private string telefonField;

            private string faxField;

            private string emailField;

            private string vergiDairesiField;

            private string vergiNoField;

            private string ilceField;

            private string ilField;

            private int kodField;

            /// <remarks/>
            public string unvan
            {
                get
                {
                    return this.unvanField;
                }
                set
                {
                    this.unvanField = value;
                }
            }

            /// <remarks/>
            public string adres1
            {
                get
                {
                    return this.adres1Field;
                }
                set
                {
                    this.adres1Field = value;
                }
            }

            /// <remarks/>
            public string adres2
            {
                get
                {
                    return this.adres2Field;
                }
                set
                {
                    this.adres2Field = value;
                }
            }

            /// <remarks/>
            public string telefon
            {
                get
                {
                    return this.telefonField;
                }
                set
                {
                    this.telefonField = value;
                }
            }

            /// <remarks/>
            public string fax
            {
                get
                {
                    return this.faxField;
                }
                set
                {
                    this.faxField = value;
                }
            }

            /// <remarks/>
            public string email
            {
                get
                {
                    return this.emailField;
                }
                set
                {
                    this.emailField = value;
                }
            }

            /// <remarks/>
            public string vergiDairesi
            {
                get
                {
                    return this.vergiDairesiField;
                }
                set
                {
                    this.vergiDairesiField = value;
                }
            }

            /// <remarks/>
            public string vergiNo
            {
                get
                {
                    return this.vergiNoField;
                }
                set
                {
                    this.vergiNoField = value;
                }
            }

            /// <remarks/>
            public string ilce
            {
                get
                {
                    return this.ilceField;
                }
                set
                {
                    this.ilceField = value;
                }
            }

            /// <remarks/>
            public string il
            {
                get
                {
                    return this.ilField;
                }
                set
                {
                    this.ilField = value;
                }
            }

            /// <remarks/>
            public int kod
            {
                get
                {
                    return this.kodField;
                }
                set
                {
                    this.kodField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class firmaBilgileriGetVergiNoSonuc : entitiesBaseClass
        {

            private int firmakodField;

            private string unvanField;

            private string isAdresiField;

            private string ikametAdresiField;

            private string vergiDairesiAdiField;

            private string vergiNoField;

            /// <remarks/>
            public int firmakod
            {
                get
                {
                    return this.firmakodField;
                }
                set
                {
                    this.firmakodField = value;
                }
            }

            /// <remarks/>
            public string unvan
            {
                get
                {
                    return this.unvanField;
                }
                set
                {
                    this.unvanField = value;
                }
            }

            /// <remarks/>
            public string isAdresi
            {
                get
                {
                    return this.isAdresiField;
                }
                set
                {
                    this.isAdresiField = value;
                }
            }

            /// <remarks/>
            public string ikametAdresi
            {
                get
                {
                    return this.ikametAdresiField;
                }
                set
                {
                    this.ikametAdresiField = value;
                }
            }

            /// <remarks/>
            public string vergiDairesiAdi
            {
                get
                {
                    return this.vergiDairesiAdiField;
                }
                set
                {
                    this.vergiDairesiAdiField = value;
                }
            }

            /// <remarks/>
            public string vergiNo
            {
                get
                {
                    return this.vergiNoField;
                }
                set
                {
                    this.vergiNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class unvanTurItem : entitiesBaseClass
        {

            private string unvanTurIDField;

            private string unvanAdiField;

            /// <remarks/>
            public string unvanTurID
            {
                get
                {
                    return this.unvanTurIDField;
                }
                set
                {
                    this.unvanTurIDField = value;
                }
            }

            /// <remarks/>
            public string unvanAdi
            {
                get
                {
                    return this.unvanAdiField;
                }
                set
                {
                    this.unvanAdiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class mkysSonuc : entitiesBaseClass
        {

            private System.Nullable<int> islemKayitNoField;

            private bool basariDurumuField;

            private string mesajField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class stokHareketUpdateItem : entitiesBaseClass
        {

            private int stokHareketIDField;

            private System.Nullable<System.DateTime> uretimTarihiField;

            private System.Nullable<System.DateTime> sonKullanmaTarihiField;

            private System.Nullable<int> edinmeYiliField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> uretimTarihi
            {
                get
                {
                    return this.uretimTarihiField;
                }
                set
                {
                    this.uretimTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> sonKullanmaTarihi
            {
                get
                {
                    return this.sonKullanmaTarihiField;
                }
                set
                {
                    this.sonKullanmaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> edinmeYili
            {
                get
                {
                    return this.edinmeYiliField;
                }
                set
                {
                    this.edinmeYiliField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class depoYetkiKontrolSonuc : entitiesBaseClass
        {

            private bool yetkiVarField;

            private string mesajField;

            /// <remarks/>
            public bool yetkiVar
            {
                get
                {
                    return this.yetkiVarField;
                }
                set
                {
                    this.yetkiVarField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class depoYetkiKontrolItem : entitiesBaseClass
        {

            private int depoKayitNoField;

            private string mkysKullaniciAdiField;

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string mkysKullaniciAdi
            {
                get
                {
                    return this.mkysKullaniciAdiField;
                }
                set
                {
                    this.mkysKullaniciAdiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class aracModelItem : entitiesBaseClass
        {

            private string aracModelIDField;

            private string modelAdiField;

            /// <remarks/>
            public string aracModelID
            {
                get
                {
                    return this.aracModelIDField;
                }
                set
                {
                    this.aracModelIDField = value;
                }
            }

            /// <remarks/>
            public string modelAdi
            {
                get
                {
                    return this.modelAdiField;
                }
                set
                {
                    this.modelAdiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class stokSeviyesiInsertSonuc : entitiesBaseClass
        {

            private bool basariDurumuField;

            private int sonucField;

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public int sonuc
            {
                get
                {
                    return this.sonucField;
                }
                set
                {
                    this.sonucField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class stokSeviyesiInsertItem : entitiesBaseClass
        {

            private int depoKayitNoField;

            private int malzemeKayitIDField;

            private string barkodField;

            private EOlcuBirimID olcuField;

            private string yillikIhtiyacField;

            private string asgariMiktarField;

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public int malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public string barkod
            {
                get
                {
                    return this.barkodField;
                }
                set
                {
                    this.barkodField = value;
                }
            }

            /// <remarks/>
            public EOlcuBirimID olcu
            {
                get
                {
                    return this.olcuField;
                }
                set
                {
                    this.olcuField = value;
                }
            }

            /// <remarks/>
            public string yillikIhtiyac
            {
                get
                {
                    return this.yillikIhtiyacField;
                }
                set
                {
                    this.yillikIhtiyacField = value;
                }
            }

            /// <remarks/>
            public string asgariMiktar
            {
                get
                {
                    return this.asgariMiktarField;
                }
                set
                {
                    this.asgariMiktarField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EOlcuBirimID
        {

            /// <remarks/>
            adet,

            /// <remarks/>
            ampul,

            /// <remarks/>
            bag,

            /// <remarks/>
            blister,

            /// <remarks/>
            boy,

            /// <remarks/>
            bolum,

            /// <remarks/>
            bidon,

            /// <remarks/>
            cilt,

            /// <remarks/>
            desimetreKare,

            /// <remarks/>
            desimetreKup,

            /// <remarks/>
            doz,

            /// <remarks/>
            duzine,

            /// <remarks/>
            flakon,

            /// <remarks/>
            galon,

            /// <remarks/>
            gram,

            /// <remarks/>
            kapsul,

            /// <remarks/>
            kartus,

            /// <remarks/>
            kasa,

            /// <remarks/>
            kavanoz,

            /// <remarks/>
            koli,

            /// <remarks/>
            kutu,

            /// <remarks/>
            kilogram,

            /// <remarks/>
            kisi,

            /// <remarks/>
            litre,

            /// <remarks/>
            metre,

            /// <remarks/>
            metreKare,

            /// <remarks/>
            metreKup,

            /// <remarks/>
            metreTul,

            /// <remarks/>
            miliGram,

            /// <remarks/>
            miliLitre,

            /// <remarks/>
            paket,

            /// <remarks/>
            plaka,

            /// <remarks/>
            poset,

            /// <remarks/>
            rulo,

            /// <remarks/>
            santiMetre,

            /// <remarks/>
            santiMetreKare,

            /// <remarks/>
            ster,

            /// <remarks/>
            tabaka,

            /// <remarks/>
            tablet,

            /// <remarks/>
            takim,

            /// <remarks/>
            teneke,

            /// <remarks/>
            ton,

            /// <remarks/>
            top,

            /// <remarks/>
            torba,

            /// <remarks/>
            tup,

            /// <remarks/>
            cift,

            /// <remarks/>
            unite,

            /// <remarks/>
            sise,

            /// <remarks/>
            test,

            /// <remarks/>
            mci,

            /// <remarks/>
            kwh,

            /// <remarks/>
            set,

            /// <remarks/>
            mikgrogram,

            /// <remarks/>
            puan,

            /// <remarks/>
            kart,

            /// <remarks/>
            kova,

            /// <remarks/>
            draje,

            /// <remarks/>
            enjektor,

            /// <remarks/>
            makara,

            /// <remarks/>
            disk,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class cikisKontrolSonuc : entitiesBaseClass
        {

            private int cikisSayisiField;

            private string mesajField;

            /// <remarks/>
            public int cikisSayisi
            {
                get
                {
                    return this.cikisSayisiField;
                }
                set
                {
                    this.cikisSayisiField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class sifreDegistirSonuc : entitiesBaseClass
        {

            private bool basariDurumuField;

            private string mesajField;

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ihtiyacFazlasiItem : entitiesBaseClass
        {

            private System.Nullable<int> siraNoField;

            private string malzemeKoduField;

            private string malzemeAdiField;

            private string malzemeDigerAciklamaField;

            private string ilKoduField;

            private decimal adetiField;

            private decimal vergiliBirimFiyatField;

            private string birimAdiField;

            private string ilAdiField;

            private System.Nullable<System.DateTime> tarihField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> siraNo
            {
                get
                {
                    return this.siraNoField;
                }
                set
                {
                    this.siraNoField = value;
                }
            }

            /// <remarks/>
            public string malzemeKodu
            {
                get
                {
                    return this.malzemeKoduField;
                }
                set
                {
                    this.malzemeKoduField = value;
                }
            }

            /// <remarks/>
            public string malzemeAdi
            {
                get
                {
                    return this.malzemeAdiField;
                }
                set
                {
                    this.malzemeAdiField = value;
                }
            }

            /// <remarks/>
            public string malzemeDigerAciklama
            {
                get
                {
                    return this.malzemeDigerAciklamaField;
                }
                set
                {
                    this.malzemeDigerAciklamaField = value;
                }
            }

            /// <remarks/>
            public string ilKodu
            {
                get
                {
                    return this.ilKoduField;
                }
                set
                {
                    this.ilKoduField = value;
                }
            }

            /// <remarks/>
            public decimal adeti
            {
                get
                {
                    return this.adetiField;
                }
                set
                {
                    this.adetiField = value;
                }
            }

            /// <remarks/>
            public decimal vergiliBirimFiyat
            {
                get
                {
                    return this.vergiliBirimFiyatField;
                }
                set
                {
                    this.vergiliBirimFiyatField = value;
                }
            }

            /// <remarks/>
            public string birimAdi
            {
                get
                {
                    return this.birimAdiField;
                }
                set
                {
                    this.birimAdiField = value;
                }
            }

            /// <remarks/>
            public string ilAdi
            {
                get
                {
                    return this.ilAdiField;
                }
                set
                {
                    this.ilAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> tarih
            {
                get
                {
                    return this.tarihField;
                }
                set
                {
                    this.tarihField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ihtiyacFazlasiKriterItem : entitiesBaseClass
        {

            private string malzemeKoduField;

            private string malzemeAdiField;

            private string ilAdiField;

            private string birimAdiField;

            /// <remarks/>
            public string malzemeKodu
            {
                get
                {
                    return this.malzemeKoduField;
                }
                set
                {
                    this.malzemeKoduField = value;
                }
            }

            /// <remarks/>
            public string malzemeAdi
            {
                get
                {
                    return this.malzemeAdiField;
                }
                set
                {
                    this.malzemeAdiField = value;
                }
            }

            /// <remarks/>
            public string ilAdi
            {
                get
                {
                    return this.ilAdiField;
                }
                set
                {
                    this.ilAdiField = value;
                }
            }

            /// <remarks/>
            public string birimAdi
            {
                get
                {
                    return this.birimAdiField;
                }
                set
                {
                    this.birimAdiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class zimmetItem : entitiesBaseClass
        {

            private System.Nullable<int> belgeNoField;

            private System.Nullable<System.DateTime> belgeTarihiField;

            private string verilenKisiAdiField;

            private string verilenBirimAdiField;

            private string verilenYerAdiField;

            private int islemKayitNoField;

            private int personelSicilNoField;

            private string verilenKisiTCKimlikNoField;

            private int birimKayitNoField;

            private string hbysIDField;

            private string dayanakBelgeNoField;

            private System.Nullable<System.DateTime> dayanakBelgeTarihiField;

            private int depoKayitNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string verilenKisiAdi
            {
                get
                {
                    return this.verilenKisiAdiField;
                }
                set
                {
                    this.verilenKisiAdiField = value;
                }
            }

            /// <remarks/>
            public string verilenBirimAdi
            {
                get
                {
                    return this.verilenBirimAdiField;
                }
                set
                {
                    this.verilenBirimAdiField = value;
                }
            }

            /// <remarks/>
            public string verilenYerAdi
            {
                get
                {
                    return this.verilenYerAdiField;
                }
                set
                {
                    this.verilenYerAdiField = value;
                }
            }

            /// <remarks/>
            public int islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }

            /// <remarks/>
            public int personelSicilNo
            {
                get
                {
                    return this.personelSicilNoField;
                }
                set
                {
                    this.personelSicilNoField = value;
                }
            }

            /// <remarks/>
            public string verilenKisiTCKimlikNo
            {
                get
                {
                    return this.verilenKisiTCKimlikNoField;
                }
                set
                {
                    this.verilenKisiTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            public int birimKayitNo
            {
                get
                {
                    return this.birimKayitNoField;
                }
                set
                {
                    this.birimKayitNoField = value;
                }
            }

            /// <remarks/>
            public string hbysID
            {
                get
                {
                    return this.hbysIDField;
                }
                set
                {
                    this.hbysIDField = value;
                }
            }

            /// <remarks/>
            public string dayanakBelgeNo
            {
                get
                {
                    return this.dayanakBelgeNoField;
                }
                set
                {
                    this.dayanakBelgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> dayanakBelgeTarihi
            {
                get
                {
                    return this.dayanakBelgeTarihiField;
                }
                set
                {
                    this.dayanakBelgeTarihiField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class zimmettenAlSonuc : entitiesBaseClass
        {

            private bool basariDurumuField;

            private string mesajField;

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class zimmettenAlListItem : entitiesBaseClass
        {

            private int zimmetInsertHareketIDField;

            private string hbysMakbuzDetayKayitNoField;

            /// <remarks/>
            public int zimmetInsertHareketID
            {
                get
                {
                    return this.zimmetInsertHareketIDField;
                }
                set
                {
                    this.zimmetInsertHareketIDField = value;
                }
            }

            /// <remarks/>
            public string hbysMakbuzDetayKayitNo
            {
                get
                {
                    return this.hbysMakbuzDetayKayitNoField;
                }
                set
                {
                    this.hbysMakbuzDetayKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class zimmettenAlInsertItem : entitiesBaseClass
        {

            private System.DateTime zimmettenAlmaTarihiField;

            private string hbysIDField;

            private zimmettenAlListItem[] alinacakListeField;

            /// <remarks/>
            public System.DateTime zimmettenAlmaTarihi
            {
                get
                {
                    return this.zimmettenAlmaTarihiField;
                }
                set
                {
                    this.zimmettenAlmaTarihiField = value;
                }
            }

            /// <remarks/>
            public string hbysID
            {
                get
                {
                    return this.hbysIDField;
                }
                set
                {
                    this.hbysIDField = value;
                }
            }

            /// <remarks/>
            public zimmettenAlListItem[] alinacakListe
            {
                get
                {
                    return this.alinacakListeField;
                }
                set
                {
                    this.alinacakListeField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class sonucZimmetListItem : entitiesBaseClass
        {

            private int yeniStokHareketIDField;

            private string hbysKayitNoField;

            /// <remarks/>
            public int yeniStokHareketID
            {
                get
                {
                    return this.yeniStokHareketIDField;
                }
                set
                {
                    this.yeniStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string hbysKayitNo
            {
                get
                {
                    return this.hbysKayitNoField;
                }
                set
                {
                    this.hbysKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class zimmetInsertSonuc : entitiesBaseClass
        {

            private int islemKayitNoField;

            private bool basariDurumuField;

            private string mesajField;

            private sonucZimmetListItem[] sonucZimmetListField;

            /// <remarks/>
            public int islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }

            /// <remarks/>
            public sonucZimmetListItem[] sonucZimmetList
            {
                get
                {
                    return this.sonucZimmetListField;
                }
                set
                {
                    this.sonucZimmetListField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class zimmetListItem : entitiesBaseClass
        {

            private int girisStokHareketIDField;

            private string hbysKayitNoField;

            /// <remarks/>
            public int girisStokHareketID
            {
                get
                {
                    return this.girisStokHareketIDField;
                }
                set
                {
                    this.girisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string hbysKayitNo
            {
                get
                {
                    return this.hbysKayitNoField;
                }
                set
                {
                    this.hbysKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class zimmetInsertItem : entitiesBaseClass
        {

            private EZimmetTuru zimmetTuruField;

            private bool ortakAlanaYapilanZimmetField;

            private bool evdeBakimaYapilanZimmetField;

            private bool geciciTahisisYapilanZimmetField;

            private string zimmeteVerilenKisiTCKimlikNoField;

            private System.Nullable<int> verilenYerIDField;

            private int belgeNoField;

            private System.DateTime belgeTarihiField;

            private EButceTurID butceTuruField;

            private int depoKayitNoField;

            private string demirbasVerilenYerIDField;

            private zimmetListItem[] zimmetListesiField;

            private System.Nullable<int> islemKayitNoField;

            /// <remarks/>
            public EZimmetTuru zimmetTuru
            {
                get
                {
                    return this.zimmetTuruField;
                }
                set
                {
                    this.zimmetTuruField = value;
                }
            }

            /// <remarks/>
            public bool ortakAlanaYapilanZimmet
            {
                get
                {
                    return this.ortakAlanaYapilanZimmetField;
                }
                set
                {
                    this.ortakAlanaYapilanZimmetField = value;
                }
            }

            /// <remarks/>
            public bool evdeBakimaYapilanZimmet
            {
                get
                {
                    return this.evdeBakimaYapilanZimmetField;
                }
                set
                {
                    this.evdeBakimaYapilanZimmetField = value;
                }
            }

            /// <remarks/>
            public bool geciciTahisisYapilanZimmet
            {
                get
                {
                    return this.geciciTahisisYapilanZimmetField;
                }
                set
                {
                    this.geciciTahisisYapilanZimmetField = value;
                }
            }

            /// <remarks/>
            public string zimmeteVerilenKisiTCKimlikNo
            {
                get
                {
                    return this.zimmeteVerilenKisiTCKimlikNoField;
                }
                set
                {
                    this.zimmeteVerilenKisiTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> verilenYerID
            {
                get
                {
                    return this.verilenYerIDField;
                }
                set
                {
                    this.verilenYerIDField = value;
                }
            }

            /// <remarks/>
            public int belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            public System.DateTime belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            public EButceTurID butceTuru
            {
                get
                {
                    return this.butceTuruField;
                }
                set
                {
                    this.butceTuruField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string demirbasVerilenYerID
            {
                get
                {
                    return this.demirbasVerilenYerIDField;
                }
                set
                {
                    this.demirbasVerilenYerIDField = value;
                }
            }

            /// <remarks/>
            public zimmetListItem[] zimmetListesi
            {
                get
                {
                    return this.zimmetListesiField;
                }
                set
                {
                    this.zimmetListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EZimmetTuru
        {

            /// <remarks/>
            zimmet,

            /// <remarks/>
            ekZimmet,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class kitapInsertUpdateSonuc : entitiesBaseClass
        {

            private bool sonucField;

            private string mesajField;

            /// <remarks/>
            public bool sonuc
            {
                get
                {
                    return this.sonucField;
                }
                set
                {
                    this.sonucField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class kitapInsertUpdateItem : entitiesBaseClass
        {

            private int makbuzDetayKayitNoField;

            private string adiField;

            private string ciltMaddeField;

            private string dilField;

            private string konuField;

            private string yazarField;

            private string yayinYeriField;

            private System.Nullable<System.DateTime> yayinTarihiField;

            private string agirlikField;

            private string boyutField;

            private string satirSayisiField;

            private string yaprakSayisiField;

            private string sayfaSayisiField;

            private string ciltTuruField;

            private string digerTurField;

            private string bulunduguYerField;

            private string izBedeliField;

            /// <remarks/>
            public int makbuzDetayKayitNo
            {
                get
                {
                    return this.makbuzDetayKayitNoField;
                }
                set
                {
                    this.makbuzDetayKayitNoField = value;
                }
            }

            /// <remarks/>
            public string adi
            {
                get
                {
                    return this.adiField;
                }
                set
                {
                    this.adiField = value;
                }
            }

            /// <remarks/>
            public string ciltMadde
            {
                get
                {
                    return this.ciltMaddeField;
                }
                set
                {
                    this.ciltMaddeField = value;
                }
            }

            /// <remarks/>
            public string dil
            {
                get
                {
                    return this.dilField;
                }
                set
                {
                    this.dilField = value;
                }
            }

            /// <remarks/>
            public string konu
            {
                get
                {
                    return this.konuField;
                }
                set
                {
                    this.konuField = value;
                }
            }

            /// <remarks/>
            public string yazar
            {
                get
                {
                    return this.yazarField;
                }
                set
                {
                    this.yazarField = value;
                }
            }

            /// <remarks/>
            public string yayinYeri
            {
                get
                {
                    return this.yayinYeriField;
                }
                set
                {
                    this.yayinYeriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> yayinTarihi
            {
                get
                {
                    return this.yayinTarihiField;
                }
                set
                {
                    this.yayinTarihiField = value;
                }
            }

            /// <remarks/>
            public string agirlik
            {
                get
                {
                    return this.agirlikField;
                }
                set
                {
                    this.agirlikField = value;
                }
            }

            /// <remarks/>
            public string boyut
            {
                get
                {
                    return this.boyutField;
                }
                set
                {
                    this.boyutField = value;
                }
            }

            /// <remarks/>
            public string satirSayisi
            {
                get
                {
                    return this.satirSayisiField;
                }
                set
                {
                    this.satirSayisiField = value;
                }
            }

            /// <remarks/>
            public string yaprakSayisi
            {
                get
                {
                    return this.yaprakSayisiField;
                }
                set
                {
                    this.yaprakSayisiField = value;
                }
            }

            /// <remarks/>
            public string sayfaSayisi
            {
                get
                {
                    return this.sayfaSayisiField;
                }
                set
                {
                    this.sayfaSayisiField = value;
                }
            }

            /// <remarks/>
            public string ciltTuru
            {
                get
                {
                    return this.ciltTuruField;
                }
                set
                {
                    this.ciltTuruField = value;
                }
            }

            /// <remarks/>
            public string digerTur
            {
                get
                {
                    return this.digerTurField;
                }
                set
                {
                    this.digerTurField = value;
                }
            }

            /// <remarks/>
            public string bulunduguYer
            {
                get
                {
                    return this.bulunduguYerField;
                }
                set
                {
                    this.bulunduguYerField = value;
                }
            }

            /// <remarks/>
            public string izBedeli
            {
                get
                {
                    return this.izBedeliField;
                }
                set
                {
                    this.izBedeliField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class sonucKayittanDusmeListItem : entitiesBaseClass
        {

            private int yeniStokHareketIDField;

            private string hbysKayitNoField;

            /// <remarks/>
            public int yeniStokHareketID
            {
                get
                {
                    return this.yeniStokHareketIDField;
                }
                set
                {
                    this.yeniStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string hbysKayitNo
            {
                get
                {
                    return this.hbysKayitNoField;
                }
                set
                {
                    this.hbysKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class kayittanDusmeSonuc : entitiesBaseClass
        {

            private int islemKayitNoField;

            private bool basariDurumuField;

            private string mesajField;

            private sonucKayittanDusmeListItem[] sonucListField;

            /// <remarks/>
            public int islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }

            /// <remarks/>
            public sonucKayittanDusmeListItem[] sonucList
            {
                get
                {
                    return this.sonucListField;
                }
                set
                {
                    this.sonucListField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class kayittanDusmeInsertItem : entitiesBaseClass
        {

            private int belgeNoField;

            private System.DateTime belgeTarihiField;

            private EButceTurID butceTuruField;

            private int depoKayitNoField;

            private kayittanDusmeListItem[] dusecekListeField;

            /// <remarks/>
            public int belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            public System.DateTime belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            public EButceTurID butceTuru
            {
                get
                {
                    return this.butceTuruField;
                }
                set
                {
                    this.butceTuruField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public kayittanDusmeListItem[] dusecekListe
            {
                get
                {
                    return this.dusecekListeField;
                }
                set
                {
                    this.dusecekListeField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class demirbasDevirSonuc : entitiesBaseClass
        {

            private int yeniStokHareketIDField;

            private string mesajField;

            private bool basariDurumuField;

            /// <remarks/>
            public int yeniStokHareketID
            {
                get
                {
                    return this.yeniStokHareketIDField;
                }
                set
                {
                    this.yeniStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class demirbasDevirItem : entitiesBaseClass
        {

            private int devirEdecekStokHareketIDField;

            private System.DateTime devirTarihiField;

            /// <remarks/>
            public int devirEdecekStokHareketID
            {
                get
                {
                    return this.devirEdecekStokHareketIDField;
                }
                set
                {
                    this.devirEdecekStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public System.DateTime devirTarihi
            {
                get
                {
                    return this.devirTarihiField;
                }
                set
                {
                    this.devirTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class degerArtisiSonuc : entitiesBaseClass
        {

            private bool basariDurumuField;

            private string mesajField;

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class degerArtisiInsertItem : entitiesBaseClass
        {

            private int stokHareketIDField;

            private decimal artisMiktariToplamField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            public decimal artisMiktariToplam
            {
                get
                {
                    return this.artisMiktariToplamField;
                }
                set
                {
                    this.artisMiktariToplamField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class aracInsertSonuc : entitiesBaseClass
        {

            private bool sonucField;

            private string mesajField;

            /// <remarks/>
            public bool sonuc
            {
                get
                {
                    return this.sonucField;
                }
                set
                {
                    this.sonucField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class aracInsertItem : entitiesBaseClass
        {

            private int stokHareketIDField;

            private string markaIDField;

            private string modelIDField;

            private string aracTurIDField;

            private int modelYiliField;

            private string plakaField;

            private string saseNoField;

            private string motorNoField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string markaID
            {
                get
                {
                    return this.markaIDField;
                }
                set
                {
                    this.markaIDField = value;
                }
            }

            /// <remarks/>
            public string modelID
            {
                get
                {
                    return this.modelIDField;
                }
                set
                {
                    this.modelIDField = value;
                }
            }

            /// <remarks/>
            public string aracTurID
            {
                get
                {
                    return this.aracTurIDField;
                }
                set
                {
                    this.aracTurIDField = value;
                }
            }

            /// <remarks/>
            public int modelYili
            {
                get
                {
                    return this.modelYiliField;
                }
                set
                {
                    this.modelYiliField = value;
                }
            }

            /// <remarks/>
            public string plaka
            {
                get
                {
                    return this.plakaField;
                }
                set
                {
                    this.plakaField = value;
                }
            }

            /// <remarks/>
            public string saseNo
            {
                get
                {
                    return this.saseNoField;
                }
                set
                {
                    this.saseNoField = value;
                }
            }

            /// <remarks/>
            public string motorNo
            {
                get
                {
                    return this.motorNoField;
                }
                set
                {
                    this.motorNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class cikisFisDetayItem : entitiesBaseClass
        {

            private System.Nullable<int> cikisStokHareketIDField;

            private System.Nullable<System.DateTime> hareketTarihiField;

            private decimal miktarField;

            private decimal vergiliBirimFiyatField;

            private string malzemeAdiField;

            private string malzemeKoduField;

            private string malzemeTurIDField;

            private string olcuBirimIDField;

            private System.Nullable<int> malzemeKayitIDField;

            private string malzemeDigerAciklamaField;

            private System.Nullable<int> demirbasNoField;

            private System.Nullable<int> girisStokHareketIDField;

            private System.Nullable<System.DateTime> sonKullanimTarihiField;

            private string barkodField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisStokHareketID
            {
                get
                {
                    return this.cikisStokHareketIDField;
                }
                set
                {
                    this.cikisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> hareketTarihi
            {
                get
                {
                    return this.hareketTarihiField;
                }
                set
                {
                    this.hareketTarihiField = value;
                }
            }

            /// <remarks/>
            public decimal miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public decimal vergiliBirimFiyat
            {
                get
                {
                    return this.vergiliBirimFiyatField;
                }
                set
                {
                    this.vergiliBirimFiyatField = value;
                }
            }

            /// <remarks/>
            public string malzemeAdi
            {
                get
                {
                    return this.malzemeAdiField;
                }
                set
                {
                    this.malzemeAdiField = value;
                }
            }

            /// <remarks/>
            public string malzemeKodu
            {
                get
                {
                    return this.malzemeKoduField;
                }
                set
                {
                    this.malzemeKoduField = value;
                }
            }

            /// <remarks/>
            public string malzemeTurID
            {
                get
                {
                    return this.malzemeTurIDField;
                }
                set
                {
                    this.malzemeTurIDField = value;
                }
            }

            /// <remarks/>
            public string olcuBirimID
            {
                get
                {
                    return this.olcuBirimIDField;
                }
                set
                {
                    this.olcuBirimIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public string malzemeDigerAciklama
            {
                get
                {
                    return this.malzemeDigerAciklamaField;
                }
                set
                {
                    this.malzemeDigerAciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> demirbasNo
            {
                get
                {
                    return this.demirbasNoField;
                }
                set
                {
                    this.demirbasNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> girisStokHareketID
            {
                get
                {
                    return this.girisStokHareketIDField;
                }
                set
                {
                    this.girisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> sonKullanimTarihi
            {
                get
                {
                    return this.sonKullanimTarihiField;
                }
                set
                {
                    this.sonKullanimTarihiField = value;
                }
            }

            /// <remarks/>
            public string barkod
            {
                get
                {
                    return this.barkodField;
                }
                set
                {
                    this.barkodField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class girisMakbuzDetayItem : entitiesBaseClass
        {

            private System.Nullable<int> makbuzDetayIDField;

            private System.Nullable<int> stokHareketIDField;

            private System.Nullable<int> ayniyatMakbuzIDField;

            private System.Nullable<int> malzemeKayitIDField;

            private decimal miktarField;

            private string olcuBirimIDField;

            private decimal vergisizBirimFiyatField;

            private decimal indirimOraniField;

            private decimal indirimTutariField;

            private decimal kdvOraniField;

            private decimal vergiliBirimFiyatField;

            private string malzemeDigerAciklamaField;

            private string urunBarkoduField;

            private System.Nullable<System.DateTime> sonKullanmaTarihiField;

            private System.Nullable<decimal> vergili_birimFiyatField;

            private System.Nullable<decimal> devir_kdvField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> makbuzDetayID
            {
                get
                {
                    return this.makbuzDetayIDField;
                }
                set
                {
                    this.makbuzDetayIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public decimal miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public string olcuBirimID
            {
                get
                {
                    return this.olcuBirimIDField;
                }
                set
                {
                    this.olcuBirimIDField = value;
                }
            }

            /// <remarks/>
            public decimal vergisizBirimFiyat
            {
                get
                {
                    return this.vergisizBirimFiyatField;
                }
                set
                {
                    this.vergisizBirimFiyatField = value;
                }
            }

            /// <remarks/>
            public decimal indirimOrani
            {
                get
                {
                    return this.indirimOraniField;
                }
                set
                {
                    this.indirimOraniField = value;
                }
            }

            /// <remarks/>
            public decimal indirimTutari
            {
                get
                {
                    return this.indirimTutariField;
                }
                set
                {
                    this.indirimTutariField = value;
                }
            }

            /// <remarks/>
            public decimal kdvOrani
            {
                get
                {
                    return this.kdvOraniField;
                }
                set
                {
                    this.kdvOraniField = value;
                }
            }

            /// <remarks/>
            public decimal vergiliBirimFiyat
            {
                get
                {
                    return this.vergiliBirimFiyatField;
                }
                set
                {
                    this.vergiliBirimFiyatField = value;
                }
            }

            /// <remarks/>
            public string malzemeDigerAciklama
            {
                get
                {
                    return this.malzemeDigerAciklamaField;
                }
                set
                {
                    this.malzemeDigerAciklamaField = value;
                }
            }

            /// <remarks/>
            public string urunBarkodu
            {
                get
                {
                    return this.urunBarkoduField;
                }
                set
                {
                    this.urunBarkoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> sonKullanmaTarihi
            {
                get
                {
                    return this.sonKullanmaTarihiField;
                }
                set
                {
                    this.sonKullanmaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> vergili_birimFiyat
            {
                get
                {
                    return this.vergili_birimFiyatField;
                }
                set
                {
                    this.vergili_birimFiyatField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> devir_kdv
            {
                get
                {
                    return this.devir_kdvField;
                }
                set
                {
                    this.devir_kdvField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class cikisFisiItem : entitiesBaseClass
        {

            private string turuField;

            private System.Nullable<int> belgeNoField;

            private System.Nullable<System.DateTime> belgeTarihiField;

            private string dayanakNoField;

            private System.Nullable<System.DateTime> dayanakTarihField;

            private System.Nullable<System.DateTime> hareketTarihiField;

            private string butceTuruIDField;

            private string depoAdiField;

            private System.Nullable<int> depoKayitNoField;

            private System.Nullable<int> cikisDepoKayitNoField;

            private string stokHareketTurIDField;

            private string cikisTCKimlikNoField;

            private string verilenKisiAdiField;

            private System.Nullable<int> cikisBirimKayitNoField;

            private System.Nullable<int> islemKayitNoField;

            private string islemTuruField;

            private string cikisBirimAdiField;

            private string hbysIDField;

            /// <remarks/>
            public string turu
            {
                get
                {
                    return this.turuField;
                }
                set
                {
                    this.turuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string dayanakNo
            {
                get
                {
                    return this.dayanakNoField;
                }
                set
                {
                    this.dayanakNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> dayanakTarih
            {
                get
                {
                    return this.dayanakTarihField;
                }
                set
                {
                    this.dayanakTarihField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> hareketTarihi
            {
                get
                {
                    return this.hareketTarihiField;
                }
                set
                {
                    this.hareketTarihiField = value;
                }
            }

            /// <remarks/>
            public string butceTuruID
            {
                get
                {
                    return this.butceTuruIDField;
                }
                set
                {
                    this.butceTuruIDField = value;
                }
            }

            /// <remarks/>
            public string depoAdi
            {
                get
                {
                    return this.depoAdiField;
                }
                set
                {
                    this.depoAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisDepoKayitNo
            {
                get
                {
                    return this.cikisDepoKayitNoField;
                }
                set
                {
                    this.cikisDepoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string stokHareketTurID
            {
                get
                {
                    return this.stokHareketTurIDField;
                }
                set
                {
                    this.stokHareketTurIDField = value;
                }
            }

            /// <remarks/>
            public string cikisTCKimlikNo
            {
                get
                {
                    return this.cikisTCKimlikNoField;
                }
                set
                {
                    this.cikisTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            public string verilenKisiAdi
            {
                get
                {
                    return this.verilenKisiAdiField;
                }
                set
                {
                    this.verilenKisiAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisBirimKayitNo
            {
                get
                {
                    return this.cikisBirimKayitNoField;
                }
                set
                {
                    this.cikisBirimKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }

            /// <remarks/>
            public string islemTuru
            {
                get
                {
                    return this.islemTuruField;
                }
                set
                {
                    this.islemTuruField = value;
                }
            }

            /// <remarks/>
            public string cikisBirimAdi
            {
                get
                {
                    return this.cikisBirimAdiField;
                }
                set
                {
                    this.cikisBirimAdiField = value;
                }
            }

            /// <remarks/>
            public string hbysID
            {
                get
                {
                    return this.hbysIDField;
                }
                set
                {
                    this.hbysIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class cikisFisleriKriter : entitiesBaseClass
        {

            private int depoKayitNoField;

            private int butceYiliField;

            private string butceTuruIDField;

            private string islemTuruField;

            private string belgeNoField;

            private System.Nullable<System.DateTime> belgeTarihiField;

            private System.DateTime belgeTarihibaslaField;

            private System.DateTime belgeTarihibitisField;

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public int butceYili
            {
                get
                {
                    return this.butceYiliField;
                }
                set
                {
                    this.butceYiliField = value;
                }
            }

            /// <remarks/>
            public string butceTuruID
            {
                get
                {
                    return this.butceTuruIDField;
                }
                set
                {
                    this.butceTuruIDField = value;
                }
            }

            /// <remarks/>
            public string islemTuru
            {
                get
                {
                    return this.islemTuruField;
                }
                set
                {
                    this.islemTuruField = value;
                }
            }

            /// <remarks/>
            public string belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            public System.DateTime belgeTarihibasla
            {
                get
                {
                    return this.belgeTarihibaslaField;
                }
                set
                {
                    this.belgeTarihibaslaField = value;
                }
            }

            /// <remarks/>
            public System.DateTime belgeTarihibitis
            {
                get
                {
                    return this.belgeTarihibitisField;
                }
                set
                {
                    this.belgeTarihibitisField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class depoGirisMakbuzGetKriter : entitiesBaseClass
        {

            private int depoKayitNoField;

            private int butceYiliField;

            private string butceTuruIDField;

            private string belgeNoField;

            private System.Nullable<System.DateTime> belgeTarihiField;

            private System.Nullable<System.DateTime> fisKayitEdildigiTarihField;

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public int butceYili
            {
                get
                {
                    return this.butceYiliField;
                }
                set
                {
                    this.butceYiliField = value;
                }
            }

            /// <remarks/>
            public string butceTuruID
            {
                get
                {
                    return this.butceTuruIDField;
                }
                set
                {
                    this.butceTuruIDField = value;
                }
            }

            /// <remarks/>
            public string belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> fisKayitEdildigiTarih
            {
                get
                {
                    return this.fisKayitEdildigiTarihField;
                }
                set
                {
                    this.fisKayitEdildigiTarihField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class girisMakbuzItem : entitiesBaseClass
        {

            private System.Nullable<int> ayniyatMakbuzIDField;

            private System.Nullable<int> birimKayitIDGirenField;

            private int makbuzNoField;

            private System.DateTime makbuzTarihiField;

            private string ciltField;

            private string sayfaField;

            private string tedarikTurIDField;

            private string butceTurIDField;

            private string teslimEdenField;

            private string teslimAlanField;

            private System.Nullable<int> firmaVergiKayitNoField;

            private string dayanagiBelgeNoField;

            private System.Nullable<System.DateTime> dayanagiBelgeTarihiField;

            private string fisAciklamaField;

            private System.Nullable<int> depoKayitNoField;

            private string muayeneNoField;

            private System.Nullable<System.DateTime> muayaneTarihiField;

            private string alimYontemiIDField;

            private string firmaAdiField;

            private string malzemeGrupIDField;

            private System.Nullable<int> gonderenBirimKayitNoField;

            private string stokHareketTurIDField;

            private string ihaleNoField;

            private System.Nullable<System.DateTime> ihaleTarihiField;

            private string firmaVergiNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> birimKayitIDGiren
            {
                get
                {
                    return this.birimKayitIDGirenField;
                }
                set
                {
                    this.birimKayitIDGirenField = value;
                }
            }

            /// <remarks/>
            public int makbuzNo
            {
                get
                {
                    return this.makbuzNoField;
                }
                set
                {
                    this.makbuzNoField = value;
                }
            }

            /// <remarks/>
            public System.DateTime makbuzTarihi
            {
                get
                {
                    return this.makbuzTarihiField;
                }
                set
                {
                    this.makbuzTarihiField = value;
                }
            }

            /// <remarks/>
            public string cilt
            {
                get
                {
                    return this.ciltField;
                }
                set
                {
                    this.ciltField = value;
                }
            }

            /// <remarks/>
            public string sayfa
            {
                get
                {
                    return this.sayfaField;
                }
                set
                {
                    this.sayfaField = value;
                }
            }

            /// <remarks/>
            public string tedarikTurID
            {
                get
                {
                    return this.tedarikTurIDField;
                }
                set
                {
                    this.tedarikTurIDField = value;
                }
            }

            /// <remarks/>
            public string butceTurID
            {
                get
                {
                    return this.butceTurIDField;
                }
                set
                {
                    this.butceTurIDField = value;
                }
            }

            /// <remarks/>
            public string teslimEden
            {
                get
                {
                    return this.teslimEdenField;
                }
                set
                {
                    this.teslimEdenField = value;
                }
            }

            /// <remarks/>
            public string teslimAlan
            {
                get
                {
                    return this.teslimAlanField;
                }
                set
                {
                    this.teslimAlanField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> firmaVergiKayitNo
            {
                get
                {
                    return this.firmaVergiKayitNoField;
                }
                set
                {
                    this.firmaVergiKayitNoField = value;
                }
            }

            /// <remarks/>
            public string dayanagiBelgeNo
            {
                get
                {
                    return this.dayanagiBelgeNoField;
                }
                set
                {
                    this.dayanagiBelgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> dayanagiBelgeTarihi
            {
                get
                {
                    return this.dayanagiBelgeTarihiField;
                }
                set
                {
                    this.dayanagiBelgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string fisAciklama
            {
                get
                {
                    return this.fisAciklamaField;
                }
                set
                {
                    this.fisAciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string muayeneNo
            {
                get
                {
                    return this.muayeneNoField;
                }
                set
                {
                    this.muayeneNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> muayaneTarihi
            {
                get
                {
                    return this.muayaneTarihiField;
                }
                set
                {
                    this.muayaneTarihiField = value;
                }
            }

            /// <remarks/>
            public string alimYontemiID
            {
                get
                {
                    return this.alimYontemiIDField;
                }
                set
                {
                    this.alimYontemiIDField = value;
                }
            }

            /// <remarks/>
            public string firmaAdi
            {
                get
                {
                    return this.firmaAdiField;
                }
                set
                {
                    this.firmaAdiField = value;
                }
            }

            /// <remarks/>
            public string malzemeGrupID
            {
                get
                {
                    return this.malzemeGrupIDField;
                }
                set
                {
                    this.malzemeGrupIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> gonderenBirimKayitNo
            {
                get
                {
                    return this.gonderenBirimKayitNoField;
                }
                set
                {
                    this.gonderenBirimKayitNoField = value;
                }
            }

            /// <remarks/>
            public string stokHareketTurID
            {
                get
                {
                    return this.stokHareketTurIDField;
                }
                set
                {
                    this.stokHareketTurIDField = value;
                }
            }

            /// <remarks/>
            public string ihaleNo
            {
                get
                {
                    return this.ihaleNoField;
                }
                set
                {
                    this.ihaleNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> ihaleTarihi
            {
                get
                {
                    return this.ihaleTarihiField;
                }
                set
                {
                    this.ihaleTarihiField = value;
                }
            }

            /// <remarks/>
            public string firmaVergiNumarasi
            {
                get
                {
                    return this.firmaVergiNumarasiField;
                }
                set
                {
                    this.firmaVergiNumarasiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class kisiInsertSonuc : entitiesBaseClass
        {

            private bool basariDurumuField;

            private string mesajField;

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class kisiInsertItem : entitiesBaseClass
        {

            private string kisiAdiField;

            private string kisiSoyadiField;

            private string tcKimlikNoField;

            private string cinsiyetField;

            private System.DateTime dogumTarihiField;

            private string unvanKoduField;

            /// <remarks/>
            public string kisiAdi
            {
                get
                {
                    return this.kisiAdiField;
                }
                set
                {
                    this.kisiAdiField = value;
                }
            }

            /// <remarks/>
            public string kisiSoyadi
            {
                get
                {
                    return this.kisiSoyadiField;
                }
                set
                {
                    this.kisiSoyadiField = value;
                }
            }

            /// <remarks/>
            public string tcKimlikNo
            {
                get
                {
                    return this.tcKimlikNoField;
                }
                set
                {
                    this.tcKimlikNoField = value;
                }
            }

            /// <remarks/>
            public string cinsiyet
            {
                get
                {
                    return this.cinsiyetField;
                }
                set
                {
                    this.cinsiyetField = value;
                }
            }

            /// <remarks/>
            public System.DateTime dogumTarihi
            {
                get
                {
                    return this.dogumTarihiField;
                }
                set
                {
                    this.dogumTarihiField = value;
                }
            }

            /// <remarks/>
            public string unvanKodu
            {
                get
                {
                    return this.unvanKoduField;
                }
                set
                {
                    this.unvanKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class kisiKontrolSonuc : entitiesBaseClass
        {

            private bool varMiField;

            private string mesajField;

            /// <remarks/>
            public bool varMi
            {
                get
                {
                    return this.varMiField;
                }
                set
                {
                    this.varMiField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzKontrolSonuc : entitiesBaseClass
        {

            private bool varMiField;

            private string mesajField;

            /// <remarks/>
            public bool varMi
            {
                get
                {
                    return this.varMiField;
                }
                set
                {
                    this.varMiField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class stokHareketBirlikKriter : entitiesBaseClass
        {

            private string butceTuruIDField;

            private string stokHareketTurIDField;

            private string islemTuruField;

            private int birimKayitIDField;

            private int butceYiliField;

            private int depoKayitNoField;

            private string belgeNoField;

            private System.Nullable<System.DateTime> belgeTarihiField;

            private System.Nullable<int> girisStokHareketIDField;

            private System.Nullable<System.DateTime> tarihAraligiBaslangicField;

            private System.Nullable<System.DateTime> tarihAraligiBitisField;

            /// <remarks/>
            public string butceTuruID
            {
                get
                {
                    return this.butceTuruIDField;
                }
                set
                {
                    this.butceTuruIDField = value;
                }
            }

            /// <remarks/>
            public string stokHareketTurID
            {
                get
                {
                    return this.stokHareketTurIDField;
                }
                set
                {
                    this.stokHareketTurIDField = value;
                }
            }

            /// <remarks/>
            public string islemTuru
            {
                get
                {
                    return this.islemTuruField;
                }
                set
                {
                    this.islemTuruField = value;
                }
            }

            /// <remarks/>
            public int birimKayitID
            {
                get
                {
                    return this.birimKayitIDField;
                }
                set
                {
                    this.birimKayitIDField = value;
                }
            }

            /// <remarks/>
            public int butceYili
            {
                get
                {
                    return this.butceYiliField;
                }
                set
                {
                    this.butceYiliField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> girisStokHareketID
            {
                get
                {
                    return this.girisStokHareketIDField;
                }
                set
                {
                    this.girisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> tarihAraligiBaslangic
            {
                get
                {
                    return this.tarihAraligiBaslangicField;
                }
                set
                {
                    this.tarihAraligiBaslangicField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> tarihAraligiBitis
            {
                get
                {
                    return this.tarihAraligiBitisField;
                }
                set
                {
                    this.tarihAraligiBitisField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class stokHareketItem : entitiesBaseClass
        {

            private int stokHareketIDField;

            private System.Nullable<int> karsiStokHareketIDField;

            private string stokHareketTurIDField;

            private string islemTuruField;

            private string butceTuruIDField;

            private decimal miktarField;

            private decimal vergiliBirimFiyatField;

            private decimal vergisizBirimFiyatField;

            private string olcuBirimIDField;

            private int belgeNoField;

            private System.Nullable<System.DateTime> belgeTarihiField;

            private string dayanakBelgeNoField;

            private System.Nullable<System.DateTime> dayanakBelgeTarihiField;

            private string malzemeDigerAciklamaField;

            private System.Nullable<int> depoKayitNoField;

            private System.Nullable<int> malzemeKayitIDField;

            private string cikisTCKimlikNoField;

            private System.Nullable<System.DateTime> uretimTarihiField;

            private System.Nullable<System.DateTime> sonKullanmaTarihiField;

            private System.Nullable<int> demirbasNoField;

            private System.Nullable<int> girisStokHareketIDField;

            private System.Nullable<int> cikisBirimDepoIDField;

            private System.Nullable<int> cikisBirimKayitNoField;

            private string malzemeKoduField;

            private string malzemeAdiField;

            private string malzemeTurIDField;

            private System.Nullable<int> islemKayitNoField;

            private System.Nullable<int> ayniyatMakbuzIDField;

            private System.Nullable<System.DateTime> iadeTarihiField;

            private System.Nullable<int> edinmeYiliField;

            private string urunBarkoduField;

            private string digerBirimAdiField;

            private string hbysIDField;

            private string hbysDetayIDField;

            private System.Nullable<int> makbuzDetayIDField;

            private string sicilNoField;

            private System.Nullable<long> tibbiCihazIDField;

            private System.Nullable<long> tibbiCihazNoField;

            private System.Nullable<long> uzerineTuketimYapilanKunyeNoField;

            private string firmaTanimlayiciNoField;

            private string lotNoField;

            private string seriNoField;

            private System.Nullable<System.DateTime> ihaleTarihiField;

            private string ihaleNoField;

            private string sutKoduField;

            private string bayiNoField;

            private bool entegreIslemField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> karsiStokHareketID
            {
                get
                {
                    return this.karsiStokHareketIDField;
                }
                set
                {
                    this.karsiStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string stokHareketTurID
            {
                get
                {
                    return this.stokHareketTurIDField;
                }
                set
                {
                    this.stokHareketTurIDField = value;
                }
            }

            /// <remarks/>
            public string islemTuru
            {
                get
                {
                    return this.islemTuruField;
                }
                set
                {
                    this.islemTuruField = value;
                }
            }

            /// <remarks/>
            public string butceTuruID
            {
                get
                {
                    return this.butceTuruIDField;
                }
                set
                {
                    this.butceTuruIDField = value;
                }
            }

            /// <remarks/>
            public decimal miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public decimal vergiliBirimFiyat
            {
                get
                {
                    return this.vergiliBirimFiyatField;
                }
                set
                {
                    this.vergiliBirimFiyatField = value;
                }
            }

            /// <remarks/>
            public decimal vergisizBirimFiyat
            {
                get
                {
                    return this.vergisizBirimFiyatField;
                }
                set
                {
                    this.vergisizBirimFiyatField = value;
                }
            }

            /// <remarks/>
            public string olcuBirimID
            {
                get
                {
                    return this.olcuBirimIDField;
                }
                set
                {
                    this.olcuBirimIDField = value;
                }
            }

            /// <remarks/>
            public int belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string dayanakBelgeNo
            {
                get
                {
                    return this.dayanakBelgeNoField;
                }
                set
                {
                    this.dayanakBelgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> dayanakBelgeTarihi
            {
                get
                {
                    return this.dayanakBelgeTarihiField;
                }
                set
                {
                    this.dayanakBelgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string malzemeDigerAciklama
            {
                get
                {
                    return this.malzemeDigerAciklamaField;
                }
                set
                {
                    this.malzemeDigerAciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public string cikisTCKimlikNo
            {
                get
                {
                    return this.cikisTCKimlikNoField;
                }
                set
                {
                    this.cikisTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> uretimTarihi
            {
                get
                {
                    return this.uretimTarihiField;
                }
                set
                {
                    this.uretimTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> sonKullanmaTarihi
            {
                get
                {
                    return this.sonKullanmaTarihiField;
                }
                set
                {
                    this.sonKullanmaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> demirbasNo
            {
                get
                {
                    return this.demirbasNoField;
                }
                set
                {
                    this.demirbasNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> girisStokHareketID
            {
                get
                {
                    return this.girisStokHareketIDField;
                }
                set
                {
                    this.girisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisBirimDepoID
            {
                get
                {
                    return this.cikisBirimDepoIDField;
                }
                set
                {
                    this.cikisBirimDepoIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisBirimKayitNo
            {
                get
                {
                    return this.cikisBirimKayitNoField;
                }
                set
                {
                    this.cikisBirimKayitNoField = value;
                }
            }

            /// <remarks/>
            public string malzemeKodu
            {
                get
                {
                    return this.malzemeKoduField;
                }
                set
                {
                    this.malzemeKoduField = value;
                }
            }

            /// <remarks/>
            public string malzemeAdi
            {
                get
                {
                    return this.malzemeAdiField;
                }
                set
                {
                    this.malzemeAdiField = value;
                }
            }

            /// <remarks/>
            public string malzemeTurID
            {
                get
                {
                    return this.malzemeTurIDField;
                }
                set
                {
                    this.malzemeTurIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> iadeTarihi
            {
                get
                {
                    return this.iadeTarihiField;
                }
                set
                {
                    this.iadeTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> edinmeYili
            {
                get
                {
                    return this.edinmeYiliField;
                }
                set
                {
                    this.edinmeYiliField = value;
                }
            }

            /// <remarks/>
            public string urunBarkodu
            {
                get
                {
                    return this.urunBarkoduField;
                }
                set
                {
                    this.urunBarkoduField = value;
                }
            }

            /// <remarks/>
            public string digerBirimAdi
            {
                get
                {
                    return this.digerBirimAdiField;
                }
                set
                {
                    this.digerBirimAdiField = value;
                }
            }

            /// <remarks/>
            public string hbysID
            {
                get
                {
                    return this.hbysIDField;
                }
                set
                {
                    this.hbysIDField = value;
                }
            }

            /// <remarks/>
            public string hbysDetayID
            {
                get
                {
                    return this.hbysDetayIDField;
                }
                set
                {
                    this.hbysDetayIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> makbuzDetayID
            {
                get
                {
                    return this.makbuzDetayIDField;
                }
                set
                {
                    this.makbuzDetayIDField = value;
                }
            }

            /// <remarks/>
            public string sicilNo
            {
                get
                {
                    return this.sicilNoField;
                }
                set
                {
                    this.sicilNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> tibbiCihazID
            {
                get
                {
                    return this.tibbiCihazIDField;
                }
                set
                {
                    this.tibbiCihazIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> tibbiCihazNo
            {
                get
                {
                    return this.tibbiCihazNoField;
                }
                set
                {
                    this.tibbiCihazNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> uzerineTuketimYapilanKunyeNo
            {
                get
                {
                    return this.uzerineTuketimYapilanKunyeNoField;
                }
                set
                {
                    this.uzerineTuketimYapilanKunyeNoField = value;
                }
            }

            /// <remarks/>
            public string firmaTanimlayiciNo
            {
                get
                {
                    return this.firmaTanimlayiciNoField;
                }
                set
                {
                    this.firmaTanimlayiciNoField = value;
                }
            }

            /// <remarks/>
            public string lotNo
            {
                get
                {
                    return this.lotNoField;
                }
                set
                {
                    this.lotNoField = value;
                }
            }

            /// <remarks/>
            public string seriNo
            {
                get
                {
                    return this.seriNoField;
                }
                set
                {
                    this.seriNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> ihaleTarihi
            {
                get
                {
                    return this.ihaleTarihiField;
                }
                set
                {
                    this.ihaleTarihiField = value;
                }
            }

            /// <remarks/>
            public string ihaleNo
            {
                get
                {
                    return this.ihaleNoField;
                }
                set
                {
                    this.ihaleNoField = value;
                }
            }

            /// <remarks/>
            public string sutKodu
            {
                get
                {
                    return this.sutKoduField;
                }
                set
                {
                    this.sutKoduField = value;
                }
            }

            /// <remarks/>
            public string bayiNo
            {
                get
                {
                    return this.bayiNoField;
                }
                set
                {
                    this.bayiNoField = value;
                }
            }

            /// <remarks/>
            public bool entegreIslem
            {
                get
                {
                    return this.entegreIslemField;
                }
                set
                {
                    this.entegreIslemField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class stokHareketKriter : entitiesBaseClass
        {

            private string butceTuruIDField;

            private string stokHareketTurIDField;

            private string islemTuruField;

            private int butceYiliField;

            private int depoKayitNoField;

            private string belgeNoField;

            private System.Nullable<System.DateTime> belgeTarihiField;

            private System.Nullable<int> girisStokHareketIDField;

            private System.Nullable<System.DateTime> tarihAraligiBaslangicField;

            private System.Nullable<System.DateTime> tarihAraligiBitisField;

            /// <remarks/>
            public string butceTuruID
            {
                get
                {
                    return this.butceTuruIDField;
                }
                set
                {
                    this.butceTuruIDField = value;
                }
            }

            /// <remarks/>
            public string stokHareketTurID
            {
                get
                {
                    return this.stokHareketTurIDField;
                }
                set
                {
                    this.stokHareketTurIDField = value;
                }
            }

            /// <remarks/>
            public string islemTuru
            {
                get
                {
                    return this.islemTuruField;
                }
                set
                {
                    this.islemTuruField = value;
                }
            }

            /// <remarks/>
            public int butceYili
            {
                get
                {
                    return this.butceYiliField;
                }
                set
                {
                    this.butceYiliField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> girisStokHareketID
            {
                get
                {
                    return this.girisStokHareketIDField;
                }
                set
                {
                    this.girisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> tarihAraligiBaslangic
            {
                get
                {
                    return this.tarihAraligiBaslangicField;
                }
                set
                {
                    this.tarihAraligiBaslangicField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> tarihAraligiBitis
            {
                get
                {
                    return this.tarihAraligiBitisField;
                }
                set
                {
                    this.tarihAraligiBitisField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ihtiyacFazlasiIadeItem : entitiesBaseClass
        {

            private int ihtiyacFazlasiHareketIDField;

            private System.DateTime iadeTarihiField;

            /// <remarks/>
            public int ihtiyacFazlasiHareketID
            {
                get
                {
                    return this.ihtiyacFazlasiHareketIDField;
                }
                set
                {
                    this.ihtiyacFazlasiHareketIDField = value;
                }
            }

            /// <remarks/>
            public System.DateTime iadeTarihi
            {
                get
                {
                    return this.iadeTarihiField;
                }
                set
                {
                    this.iadeTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ihtiyacFazlasiSonuc : entitiesBaseClass
        {

            private System.Nullable<int> ihtiyacFazlasiHareketIDField;

            private bool basariDurumuField;

            private string mesajField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> ihtiyacFazlasiHareketID
            {
                get
                {
                    return this.ihtiyacFazlasiHareketIDField;
                }
                set
                {
                    this.ihtiyacFazlasiHareketIDField = value;
                }
            }

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ihtiyacFazlasiInsertItem : entitiesBaseClass
        {

            private EButceTurID butceTuruField;

            private int girisStokHareketIDField;

            private string aciklamaField;

            private decimal miktarField;

            private System.DateTime belgeTarihiField;

            private int depoKayitNoField;

            /// <remarks/>
            public EButceTurID butceTuru
            {
                get
                {
                    return this.butceTuruField;
                }
                set
                {
                    this.butceTuruField = value;
                }
            }

            /// <remarks/>
            public int girisStokHareketID
            {
                get
                {
                    return this.girisStokHareketIDField;
                }
                set
                {
                    this.girisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string aciklama
            {
                get
                {
                    return this.aciklamaField;
                }
                set
                {
                    this.aciklamaField = value;
                }
            }

            /// <remarks/>
            public decimal miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public System.DateTime belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class devirFisiItem : entitiesBaseClass
        {

            private int cikisStokHareketIDField;

            private System.Nullable<System.DateTime> hareketTarihiField;

            private decimal miktarField;

            private decimal vergiliBirimFiyatField;

            private int malzemeKayitIDField;

            private string malzemeAdiField;

            private string malzemeTurIDField;

            private string olcuBirimIDField;

            private string malzemeDigerAciklamaField;

            private string urunBarkoduField;

            private System.Nullable<System.DateTime> uretimTarihiField;

            private System.Nullable<System.DateTime> sonKullanmaTarihiField;

            private System.Nullable<int> edinmeYiliField;

            private System.Nullable<long> tibbiCihazIDField;

            private System.Nullable<long> tibbiCihazNoField;

            private string firmaTanimlayiciNoField;

            private string lotNoField;

            private string seriNoField;

            private System.Nullable<System.DateTime> ihaleTarihiField;

            private string ihaleNoField;

            private string sutKoduField;

            private string bayiNoField;

            /// <remarks/>
            public int cikisStokHareketID
            {
                get
                {
                    return this.cikisStokHareketIDField;
                }
                set
                {
                    this.cikisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> hareketTarihi
            {
                get
                {
                    return this.hareketTarihiField;
                }
                set
                {
                    this.hareketTarihiField = value;
                }
            }

            /// <remarks/>
            public decimal miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public decimal vergiliBirimFiyat
            {
                get
                {
                    return this.vergiliBirimFiyatField;
                }
                set
                {
                    this.vergiliBirimFiyatField = value;
                }
            }

            /// <remarks/>
            public int malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public string malzemeAdi
            {
                get
                {
                    return this.malzemeAdiField;
                }
                set
                {
                    this.malzemeAdiField = value;
                }
            }

            /// <remarks/>
            public string malzemeTurID
            {
                get
                {
                    return this.malzemeTurIDField;
                }
                set
                {
                    this.malzemeTurIDField = value;
                }
            }

            /// <remarks/>
            public string olcuBirimID
            {
                get
                {
                    return this.olcuBirimIDField;
                }
                set
                {
                    this.olcuBirimIDField = value;
                }
            }

            /// <remarks/>
            public string malzemeDigerAciklama
            {
                get
                {
                    return this.malzemeDigerAciklamaField;
                }
                set
                {
                    this.malzemeDigerAciklamaField = value;
                }
            }

            /// <remarks/>
            public string urunBarkodu
            {
                get
                {
                    return this.urunBarkoduField;
                }
                set
                {
                    this.urunBarkoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> uretimTarihi
            {
                get
                {
                    return this.uretimTarihiField;
                }
                set
                {
                    this.uretimTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> sonKullanmaTarihi
            {
                get
                {
                    return this.sonKullanmaTarihiField;
                }
                set
                {
                    this.sonKullanmaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> edinmeYili
            {
                get
                {
                    return this.edinmeYiliField;
                }
                set
                {
                    this.edinmeYiliField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> tibbiCihazID
            {
                get
                {
                    return this.tibbiCihazIDField;
                }
                set
                {
                    this.tibbiCihazIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> tibbiCihazNo
            {
                get
                {
                    return this.tibbiCihazNoField;
                }
                set
                {
                    this.tibbiCihazNoField = value;
                }
            }

            /// <remarks/>
            public string firmaTanimlayiciNo
            {
                get
                {
                    return this.firmaTanimlayiciNoField;
                }
                set
                {
                    this.firmaTanimlayiciNoField = value;
                }
            }

            /// <remarks/>
            public string lotNo
            {
                get
                {
                    return this.lotNoField;
                }
                set
                {
                    this.lotNoField = value;
                }
            }

            /// <remarks/>
            public string seriNo
            {
                get
                {
                    return this.seriNoField;
                }
                set
                {
                    this.seriNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> ihaleTarihi
            {
                get
                {
                    return this.ihaleTarihiField;
                }
                set
                {
                    this.ihaleTarihiField = value;
                }
            }

            /// <remarks/>
            public string ihaleNo
            {
                get
                {
                    return this.ihaleNoField;
                }
                set
                {
                    this.ihaleNoField = value;
                }
            }

            /// <remarks/>
            public string sutKodu
            {
                get
                {
                    return this.sutKoduField;
                }
                set
                {
                    this.sutKoduField = value;
                }
            }

            /// <remarks/>
            public string bayiNo
            {
                get
                {
                    return this.bayiNoField;
                }
                set
                {
                    this.bayiNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class malzemeSiniflandirmaItem : entitiesBaseClass
        {

            private int malzemeKayitIDField;

            private string malzemeKoduField;

            private string malzemeAdiField;

            private System.Nullable<System.DateTime> degisiklikTarihiField;

            private string tibbiSarfKlinikBransiField;

            private string tibbiSarfKullanimYeriField;

            private string tibbiSarfKullanimAmaciField;

            private string tibbiSarfMalzemeCinsiField;

            private string tibbiSarfSutKoduField;

            private string laboratuvarBransiField;

            private string laboratuvarCinsiField;

            private string laboratuvarSutKoduField;

            private string cerrahiAletBransiField;

            private string cerrahiAletCinsiField;

            private string cerrahiAletSutKoduField;

            private System.Nullable<int> biyomedikalCihazTurIdField;

            private string biyomedikalCihazTurField;

            private System.Nullable<int> biyomedikalCihazTanimIdField;

            private string biyomedikalCihazTanimField;

            private System.Nullable<int> biyomedikalSarfTurIdField;

            private string biyomedikalSarfTurField;

            private string biyomedikalSarfTanimField;

            private string biyomedikalSarfCinsField;

            private string biyomedikalSarfNitelikField;

            private string biyomedikalSarfSutKoduField;

            private string ilacBarkodField;

            private string ilacAdiField;

            private string ilacJenerikKoduField;

            private string ilacJenerikAdiField;

            private string ilacActKoduField;

            private string ilacAtcTanimiField;

            private string ilacAtc2DuzeyKoduField;

            private string ilacAtc2DuzeyTanimiField;

            private string ilacSogukZincirField;

            private string pasifField;

            private string barkodDogrulamaDurumuField;

            /// <remarks/>
            public int malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public string malzemeKodu
            {
                get
                {
                    return this.malzemeKoduField;
                }
                set
                {
                    this.malzemeKoduField = value;
                }
            }

            /// <remarks/>
            public string malzemeAdi
            {
                get
                {
                    return this.malzemeAdiField;
                }
                set
                {
                    this.malzemeAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> degisiklikTarihi
            {
                get
                {
                    return this.degisiklikTarihiField;
                }
                set
                {
                    this.degisiklikTarihiField = value;
                }
            }

            /// <remarks/>
            public string tibbiSarfKlinikBransi
            {
                get
                {
                    return this.tibbiSarfKlinikBransiField;
                }
                set
                {
                    this.tibbiSarfKlinikBransiField = value;
                }
            }

            /// <remarks/>
            public string tibbiSarfKullanimYeri
            {
                get
                {
                    return this.tibbiSarfKullanimYeriField;
                }
                set
                {
                    this.tibbiSarfKullanimYeriField = value;
                }
            }

            /// <remarks/>
            public string tibbiSarfKullanimAmaci
            {
                get
                {
                    return this.tibbiSarfKullanimAmaciField;
                }
                set
                {
                    this.tibbiSarfKullanimAmaciField = value;
                }
            }

            /// <remarks/>
            public string tibbiSarfMalzemeCinsi
            {
                get
                {
                    return this.tibbiSarfMalzemeCinsiField;
                }
                set
                {
                    this.tibbiSarfMalzemeCinsiField = value;
                }
            }

            /// <remarks/>
            public string tibbiSarfSutKodu
            {
                get
                {
                    return this.tibbiSarfSutKoduField;
                }
                set
                {
                    this.tibbiSarfSutKoduField = value;
                }
            }

            /// <remarks/>
            public string laboratuvarBransi
            {
                get
                {
                    return this.laboratuvarBransiField;
                }
                set
                {
                    this.laboratuvarBransiField = value;
                }
            }

            /// <remarks/>
            public string laboratuvarCinsi
            {
                get
                {
                    return this.laboratuvarCinsiField;
                }
                set
                {
                    this.laboratuvarCinsiField = value;
                }
            }

            /// <remarks/>
            public string laboratuvarSutKodu
            {
                get
                {
                    return this.laboratuvarSutKoduField;
                }
                set
                {
                    this.laboratuvarSutKoduField = value;
                }
            }

            /// <remarks/>
            public string cerrahiAletBransi
            {
                get
                {
                    return this.cerrahiAletBransiField;
                }
                set
                {
                    this.cerrahiAletBransiField = value;
                }
            }

            /// <remarks/>
            public string cerrahiAletCinsi
            {
                get
                {
                    return this.cerrahiAletCinsiField;
                }
                set
                {
                    this.cerrahiAletCinsiField = value;
                }
            }

            /// <remarks/>
            public string cerrahiAletSutKodu
            {
                get
                {
                    return this.cerrahiAletSutKoduField;
                }
                set
                {
                    this.cerrahiAletSutKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> biyomedikalCihazTurId
            {
                get
                {
                    return this.biyomedikalCihazTurIdField;
                }
                set
                {
                    this.biyomedikalCihazTurIdField = value;
                }
            }

            /// <remarks/>
            public string biyomedikalCihazTur
            {
                get
                {
                    return this.biyomedikalCihazTurField;
                }
                set
                {
                    this.biyomedikalCihazTurField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> biyomedikalCihazTanimId
            {
                get
                {
                    return this.biyomedikalCihazTanimIdField;
                }
                set
                {
                    this.biyomedikalCihazTanimIdField = value;
                }
            }

            /// <remarks/>
            public string biyomedikalCihazTanim
            {
                get
                {
                    return this.biyomedikalCihazTanimField;
                }
                set
                {
                    this.biyomedikalCihazTanimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> biyomedikalSarfTurId
            {
                get
                {
                    return this.biyomedikalSarfTurIdField;
                }
                set
                {
                    this.biyomedikalSarfTurIdField = value;
                }
            }

            /// <remarks/>
            public string biyomedikalSarfTur
            {
                get
                {
                    return this.biyomedikalSarfTurField;
                }
                set
                {
                    this.biyomedikalSarfTurField = value;
                }
            }

            /// <remarks/>
            public string biyomedikalSarfTanim
            {
                get
                {
                    return this.biyomedikalSarfTanimField;
                }
                set
                {
                    this.biyomedikalSarfTanimField = value;
                }
            }

            /// <remarks/>
            public string biyomedikalSarfCins
            {
                get
                {
                    return this.biyomedikalSarfCinsField;
                }
                set
                {
                    this.biyomedikalSarfCinsField = value;
                }
            }

            /// <remarks/>
            public string biyomedikalSarfNitelik
            {
                get
                {
                    return this.biyomedikalSarfNitelikField;
                }
                set
                {
                    this.biyomedikalSarfNitelikField = value;
                }
            }

            /// <remarks/>
            public string biyomedikalSarfSutKodu
            {
                get
                {
                    return this.biyomedikalSarfSutKoduField;
                }
                set
                {
                    this.biyomedikalSarfSutKoduField = value;
                }
            }

            /// <remarks/>
            public string ilacBarkod
            {
                get
                {
                    return this.ilacBarkodField;
                }
                set
                {
                    this.ilacBarkodField = value;
                }
            }

            /// <remarks/>
            public string ilacAdi
            {
                get
                {
                    return this.ilacAdiField;
                }
                set
                {
                    this.ilacAdiField = value;
                }
            }

            /// <remarks/>
            public string ilacJenerikKodu
            {
                get
                {
                    return this.ilacJenerikKoduField;
                }
                set
                {
                    this.ilacJenerikKoduField = value;
                }
            }

            /// <remarks/>
            public string ilacJenerikAdi
            {
                get
                {
                    return this.ilacJenerikAdiField;
                }
                set
                {
                    this.ilacJenerikAdiField = value;
                }
            }

            /// <remarks/>
            public string ilacActKodu
            {
                get
                {
                    return this.ilacActKoduField;
                }
                set
                {
                    this.ilacActKoduField = value;
                }
            }

            /// <remarks/>
            public string ilacAtcTanimi
            {
                get
                {
                    return this.ilacAtcTanimiField;
                }
                set
                {
                    this.ilacAtcTanimiField = value;
                }
            }

            /// <remarks/>
            public string ilacAtc2DuzeyKodu
            {
                get
                {
                    return this.ilacAtc2DuzeyKoduField;
                }
                set
                {
                    this.ilacAtc2DuzeyKoduField = value;
                }
            }

            /// <remarks/>
            public string ilacAtc2DuzeyTanimi
            {
                get
                {
                    return this.ilacAtc2DuzeyTanimiField;
                }
                set
                {
                    this.ilacAtc2DuzeyTanimiField = value;
                }
            }

            /// <remarks/>
            public string ilacSogukZincir
            {
                get
                {
                    return this.ilacSogukZincirField;
                }
                set
                {
                    this.ilacSogukZincirField = value;
                }
            }

            /// <remarks/>
            public string pasif
            {
                get
                {
                    return this.pasifField;
                }
                set
                {
                    this.pasifField = value;
                }
            }

            /// <remarks/>
            public string barkodDogrulamaDurumu
            {
                get
                {
                    return this.barkodDogrulamaDurumuField;
                }
                set
                {
                    this.barkodDogrulamaDurumuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class malzemeTibbiSarfItem : entitiesBaseClass
        {

            private int malzemeKayitIDField;

            private string malzemeKoduField;

            private string malzemeAdiField;

            private System.Nullable<System.DateTime> degisiklikTarihiField;

            private string olcuBirimIDField;

            private string malzemeTurIDField;

            private string eskiMalzemeKoduField;

            private string klinikbransiField;

            private string kullanimyeriField;

            private string kullanimamaciField;

            private string malzemecinsiField;

            private string sutKoduField;

            private bool aktifField;

            /// <remarks/>
            public int malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public string malzemeKodu
            {
                get
                {
                    return this.malzemeKoduField;
                }
                set
                {
                    this.malzemeKoduField = value;
                }
            }

            /// <remarks/>
            public string malzemeAdi
            {
                get
                {
                    return this.malzemeAdiField;
                }
                set
                {
                    this.malzemeAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> degisiklikTarihi
            {
                get
                {
                    return this.degisiklikTarihiField;
                }
                set
                {
                    this.degisiklikTarihiField = value;
                }
            }

            /// <remarks/>
            public string olcuBirimID
            {
                get
                {
                    return this.olcuBirimIDField;
                }
                set
                {
                    this.olcuBirimIDField = value;
                }
            }

            /// <remarks/>
            public string malzemeTurID
            {
                get
                {
                    return this.malzemeTurIDField;
                }
                set
                {
                    this.malzemeTurIDField = value;
                }
            }

            /// <remarks/>
            public string eskiMalzemeKodu
            {
                get
                {
                    return this.eskiMalzemeKoduField;
                }
                set
                {
                    this.eskiMalzemeKoduField = value;
                }
            }

            /// <remarks/>
            public string klinikbransi
            {
                get
                {
                    return this.klinikbransiField;
                }
                set
                {
                    this.klinikbransiField = value;
                }
            }

            /// <remarks/>
            public string kullanimyeri
            {
                get
                {
                    return this.kullanimyeriField;
                }
                set
                {
                    this.kullanimyeriField = value;
                }
            }

            /// <remarks/>
            public string kullanimamaci
            {
                get
                {
                    return this.kullanimamaciField;
                }
                set
                {
                    this.kullanimamaciField = value;
                }
            }

            /// <remarks/>
            public string malzemecinsi
            {
                get
                {
                    return this.malzemecinsiField;
                }
                set
                {
                    this.malzemecinsiField = value;
                }
            }

            /// <remarks/>
            public string sutKodu
            {
                get
                {
                    return this.sutKoduField;
                }
                set
                {
                    this.sutKoduField = value;
                }
            }

            /// <remarks/>
            public bool aktif
            {
                get
                {
                    return this.aktifField;
                }
                set
                {
                    this.aktifField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class malzemeItem : entitiesBaseClass
        {

            private int malzemeKayitIDField;

            private string malzemeKoduField;

            private string malzemeAdiField;

            private System.Nullable<System.DateTime> degisiklikTarihiField;

            private string olcuBirimIDField;

            private string malzemeTurIDField;

            private string eskiMalzemeKoduField;

            private bool aktifField;

            /// <remarks/>
            public int malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public string malzemeKodu
            {
                get
                {
                    return this.malzemeKoduField;
                }
                set
                {
                    this.malzemeKoduField = value;
                }
            }

            /// <remarks/>
            public string malzemeAdi
            {
                get
                {
                    return this.malzemeAdiField;
                }
                set
                {
                    this.malzemeAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> degisiklikTarihi
            {
                get
                {
                    return this.degisiklikTarihiField;
                }
                set
                {
                    this.degisiklikTarihiField = value;
                }
            }

            /// <remarks/>
            public string olcuBirimID
            {
                get
                {
                    return this.olcuBirimIDField;
                }
                set
                {
                    this.olcuBirimIDField = value;
                }
            }

            /// <remarks/>
            public string malzemeTurID
            {
                get
                {
                    return this.malzemeTurIDField;
                }
                set
                {
                    this.malzemeTurIDField = value;
                }
            }

            /// <remarks/>
            public string eskiMalzemeKodu
            {
                get
                {
                    return this.eskiMalzemeKoduField;
                }
                set
                {
                    this.eskiMalzemeKoduField = value;
                }
            }

            /// <remarks/>
            public bool aktif
            {
                get
                {
                    return this.aktifField;
                }
                set
                {
                    this.aktifField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class kurumlardanGelenDevirItem : entitiesBaseClass
        {

            private string turuField;

            private System.Nullable<int> cikisBelgeNoField;

            private System.Nullable<System.DateTime> cikisBelgeTarihiField;

            private string gonderenBirimAdiField;

            private string gonderenButceTuruAdiField;

            private string gonderenDepoAdiField;

            private string hareketTuruField;

            private System.Nullable<int> gonderenBirimIDField;

            private int birimDepoIDField;

            private System.Nullable<int> islemKayitNoField;

            private int devirGerceklestiMiField;

            /// <remarks/>
            public string turu
            {
                get
                {
                    return this.turuField;
                }
                set
                {
                    this.turuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisBelgeNo
            {
                get
                {
                    return this.cikisBelgeNoField;
                }
                set
                {
                    this.cikisBelgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> cikisBelgeTarihi
            {
                get
                {
                    return this.cikisBelgeTarihiField;
                }
                set
                {
                    this.cikisBelgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string gonderenBirimAdi
            {
                get
                {
                    return this.gonderenBirimAdiField;
                }
                set
                {
                    this.gonderenBirimAdiField = value;
                }
            }

            /// <remarks/>
            public string gonderenButceTuruAdi
            {
                get
                {
                    return this.gonderenButceTuruAdiField;
                }
                set
                {
                    this.gonderenButceTuruAdiField = value;
                }
            }

            /// <remarks/>
            public string gonderenDepoAdi
            {
                get
                {
                    return this.gonderenDepoAdiField;
                }
                set
                {
                    this.gonderenDepoAdiField = value;
                }
            }

            /// <remarks/>
            public string hareketTuru
            {
                get
                {
                    return this.hareketTuruField;
                }
                set
                {
                    this.hareketTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> gonderenBirimID
            {
                get
                {
                    return this.gonderenBirimIDField;
                }
                set
                {
                    this.gonderenBirimIDField = value;
                }
            }

            /// <remarks/>
            public int birimDepoID
            {
                get
                {
                    return this.birimDepoIDField;
                }
                set
                {
                    this.birimDepoIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }

            /// <remarks/>
            public int devirGerceklestiMi
            {
                get
                {
                    return this.devirGerceklestiMiField;
                }
                set
                {
                    this.devirGerceklestiMiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class kurumlardanGelenDevirKriter : entitiesBaseClass
        {

            private System.DateTime ilkTarihField;

            private System.DateTime sonTarihField;

            private bool ambarlarArasiDeviriDeGetirField;

            /// <remarks/>
            public System.DateTime ilkTarih
            {
                get
                {
                    return this.ilkTarihField;
                }
                set
                {
                    this.ilkTarihField = value;
                }
            }

            /// <remarks/>
            public System.DateTime sonTarih
            {
                get
                {
                    return this.sonTarihField;
                }
                set
                {
                    this.sonTarihField = value;
                }
            }

            /// <remarks/>
            public bool ambarlarArasiDeviriDeGetir
            {
                get
                {
                    return this.ambarlarArasiDeviriDeGetirField;
                }
                set
                {
                    this.ambarlarArasiDeviriDeGetirField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class birimUpdateItem : entitiesBaseClass
        {

            private int birimKayitNoField;

            private string birimKisaAdiField;

            /// <remarks/>
            public int birimKayitNo
            {
                get
                {
                    return this.birimKayitNoField;
                }
                set
                {
                    this.birimKayitNoField = value;
                }
            }

            /// <remarks/>
            public string birimKisaAdi
            {
                get
                {
                    return this.birimKisaAdiField;
                }
                set
                {
                    this.birimKisaAdiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class birimKayitIslemleriSonuc : entitiesBaseClass
        {

            private int birimKayitNoField;

            private string birimAdiField;

            private bool basariDurumuField;

            private string mesajField;

            /// <remarks/>
            public int birimKayitNo
            {
                get
                {
                    return this.birimKayitNoField;
                }
                set
                {
                    this.birimKayitNoField = value;
                }
            }

            /// <remarks/>
            public string birimAdi
            {
                get
                {
                    return this.birimAdiField;
                }
                set
                {
                    this.birimAdiField = value;
                }
            }

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class birimInsertItem : entitiesBaseClass
        {

            private string birimKisaAdiField;

            /// <remarks/>
            public string birimKisaAdi
            {
                get
                {
                    return this.birimKisaAdiField;
                }
                set
                {
                    this.birimKisaAdiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class stokHareketSilSonuc : entitiesBaseClass
        {

            private bool basariDurumuField;

            private string mesajField;

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzIptalSonuc : entitiesBaseClass
        {

            private bool basariDurumuField;

            private string mesajField;

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzSilmeSonuc : entitiesBaseClass
        {

            private bool basariDurumuField;

            private string mesajField;

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzDetayInsertGirisSonuc : entitiesBaseClass
        {

            private int ayniyatMakbuzIDField;

            private string mesajField;

            private sonucMakbuzDetayItem[] sonucMakbuzDetayListField;

            private sonucStokHareketItem[] sonucStokHareketListField;

            private bool basariDurumuField;

            /// <remarks/>
            public int ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }

            /// <remarks/>
            public sonucMakbuzDetayItem[] sonucMakbuzDetayList
            {
                get
                {
                    return this.sonucMakbuzDetayListField;
                }
                set
                {
                    this.sonucMakbuzDetayListField = value;
                }
            }

            /// <remarks/>
            public sonucStokHareketItem[] sonucStokHareketList
            {
                get
                {
                    return this.sonucStokHareketListField;
                }
                set
                {
                    this.sonucStokHareketListField = value;
                }
            }

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class sonucMakbuzDetayItem : entitiesBaseClass
        {

            private int makbuzDetayKayitNoField;

            private string hbysMakbuzDetayKayitNoField;

            private bool hataliSatirField;

            /// <remarks/>
            public int makbuzDetayKayitNo
            {
                get
                {
                    return this.makbuzDetayKayitNoField;
                }
                set
                {
                    this.makbuzDetayKayitNoField = value;
                }
            }

            /// <remarks/>
            public string hbysMakbuzDetayKayitNo
            {
                get
                {
                    return this.hbysMakbuzDetayKayitNoField;
                }
                set
                {
                    this.hbysMakbuzDetayKayitNoField = value;
                }
            }

            /// <remarks/>
            public bool hataliSatir
            {
                get
                {
                    return this.hataliSatirField;
                }
                set
                {
                    this.hataliSatirField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class sonucStokHareketItem : entitiesBaseClass
        {

            private int stokHareketIDField;

            private string hbysStokHareketIDField;

            private string hbysDemirbasNoField;

            private bool hataliSatirField;

            private int demirbasKayitIDField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string hbysStokHareketID
            {
                get
                {
                    return this.hbysStokHareketIDField;
                }
                set
                {
                    this.hbysStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string hbysDemirbasNo
            {
                get
                {
                    return this.hbysDemirbasNoField;
                }
                set
                {
                    this.hbysDemirbasNoField = value;
                }
            }

            /// <remarks/>
            public bool hataliSatir
            {
                get
                {
                    return this.hataliSatirField;
                }
                set
                {
                    this.hataliSatirField = value;
                }
            }

            /// <remarks/>
            public int demirbasKayitID
            {
                get
                {
                    return this.demirbasKayitIDField;
                }
                set
                {
                    this.demirbasKayitIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzDetayInsertGirisItem : entitiesBaseClass
        {

            private int ayniyatMakbuzIDField;

            private makbuzDetayGirisItem[] makbuzDetayListField;

            private demirbasGirisItem[] demirbasItemListField;

            /// <remarks/>
            public int ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }

            /// <remarks/>
            public makbuzDetayGirisItem[] makbuzDetayList
            {
                get
                {
                    return this.makbuzDetayListField;
                }
                set
                {
                    this.makbuzDetayListField = value;
                }
            }

            /// <remarks/>
            public demirbasGirisItem[] demirbasItemList
            {
                get
                {
                    return this.demirbasItemListField;
                }
                set
                {
                    this.demirbasItemListField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzDetayGirisItem : entitiesBaseClass
        {

            private int malzemeKayitIDField;

            private decimal miktarField;

            private EOlcuBirimID olcuBirimiIDField;

            private decimal vergisizBirimFiyatField;

            private decimal vergiliBirimFiyatField;

            private System.Nullable<decimal> indirimOraniField;

            private System.Nullable<decimal> indirimTutariField;

            private System.Nullable<decimal> kdvOraniField;

            private string malzemeDigerAciklamaField;

            private string urunBarkoduField;

            private string hbysMakbuzDetayKayitNoField;

            private System.Nullable<System.DateTime> sonKullanmaTarihiField;

            private System.Nullable<System.DateTime> uretimTarihiField;

            private System.Nullable<int> edinimYiliField;

            private System.Nullable<int> devirEdecekStokHareketIDField;

            private System.Nullable<decimal> devirOraniField;

            private System.Nullable<int> stokHareketDevirIDField;

            private System.Nullable<int> demirbasKayitIdField;

            private string zimmetAktarField;

            private string firmaTanimlayiciNoField;

            private string lotNoField;

            private string seriNoField;

            private System.Nullable<System.DateTime> ihaleTarihiField;

            private string ihaleNoField;

            private string sutKoduField;

            private string bayiNoField;

            /// <remarks/>
            public int malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public decimal miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public EOlcuBirimID olcuBirimiID
            {
                get
                {
                    return this.olcuBirimiIDField;
                }
                set
                {
                    this.olcuBirimiIDField = value;
                }
            }

            /// <remarks/>
            public decimal vergisizBirimFiyat
            {
                get
                {
                    return this.vergisizBirimFiyatField;
                }
                set
                {
                    this.vergisizBirimFiyatField = value;
                }
            }

            /// <remarks/>
            public decimal vergiliBirimFiyat
            {
                get
                {
                    return this.vergiliBirimFiyatField;
                }
                set
                {
                    this.vergiliBirimFiyatField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> indirimOrani
            {
                get
                {
                    return this.indirimOraniField;
                }
                set
                {
                    this.indirimOraniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> indirimTutari
            {
                get
                {
                    return this.indirimTutariField;
                }
                set
                {
                    this.indirimTutariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> kdvOrani
            {
                get
                {
                    return this.kdvOraniField;
                }
                set
                {
                    this.kdvOraniField = value;
                }
            }

            /// <remarks/>
            public string malzemeDigerAciklama
            {
                get
                {
                    return this.malzemeDigerAciklamaField;
                }
                set
                {
                    this.malzemeDigerAciklamaField = value;
                }
            }

            /// <remarks/>
            public string urunBarkodu
            {
                get
                {
                    return this.urunBarkoduField;
                }
                set
                {
                    this.urunBarkoduField = value;
                }
            }

            /// <remarks/>
            public string hbysMakbuzDetayKayitNo
            {
                get
                {
                    return this.hbysMakbuzDetayKayitNoField;
                }
                set
                {
                    this.hbysMakbuzDetayKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> sonKullanmaTarihi
            {
                get
                {
                    return this.sonKullanmaTarihiField;
                }
                set
                {
                    this.sonKullanmaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> uretimTarihi
            {
                get
                {
                    return this.uretimTarihiField;
                }
                set
                {
                    this.uretimTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> edinimYili
            {
                get
                {
                    return this.edinimYiliField;
                }
                set
                {
                    this.edinimYiliField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> devirEdecekStokHareketID
            {
                get
                {
                    return this.devirEdecekStokHareketIDField;
                }
                set
                {
                    this.devirEdecekStokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> devirOrani
            {
                get
                {
                    return this.devirOraniField;
                }
                set
                {
                    this.devirOraniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> stokHareketDevirID
            {
                get
                {
                    return this.stokHareketDevirIDField;
                }
                set
                {
                    this.stokHareketDevirIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> demirbasKayitId
            {
                get
                {
                    return this.demirbasKayitIdField;
                }
                set
                {
                    this.demirbasKayitIdField = value;
                }
            }

            /// <remarks/>
            public string zimmetAktar
            {
                get
                {
                    return this.zimmetAktarField;
                }
                set
                {
                    this.zimmetAktarField = value;
                }
            }

            /// <remarks/>
            public string firmaTanimlayiciNo
            {
                get
                {
                    return this.firmaTanimlayiciNoField;
                }
                set
                {
                    this.firmaTanimlayiciNoField = value;
                }
            }

            /// <remarks/>
            public string lotNo
            {
                get
                {
                    return this.lotNoField;
                }
                set
                {
                    this.lotNoField = value;
                }
            }

            /// <remarks/>
            public string seriNo
            {
                get
                {
                    return this.seriNoField;
                }
                set
                {
                    this.seriNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> ihaleTarihi
            {
                get
                {
                    return this.ihaleTarihiField;
                }
                set
                {
                    this.ihaleTarihiField = value;
                }
            }

            /// <remarks/>
            public string ihaleNo
            {
                get
                {
                    return this.ihaleNoField;
                }
                set
                {
                    this.ihaleNoField = value;
                }
            }

            /// <remarks/>
            public string sutKodu
            {
                get
                {
                    return this.sutKoduField;
                }
                set
                {
                    this.sutKoduField = value;
                }
            }

            /// <remarks/>
            public string bayiNo
            {
                get
                {
                    return this.bayiNoField;
                }
                set
                {
                    this.bayiNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class demirbasGirisItem : entitiesBaseClass
        {

            private string hbysMakbuzDetayKayitNoField;

            private string hbysDemirbasKayitNoField;

            private int demirbasNoField;

            private System.Nullable<int> demirbasKayitIdField;

            /// <remarks/>
            public string hbysMakbuzDetayKayitNo
            {
                get
                {
                    return this.hbysMakbuzDetayKayitNoField;
                }
                set
                {
                    this.hbysMakbuzDetayKayitNoField = value;
                }
            }

            /// <remarks/>
            public string hbysDemirbasKayitNo
            {
                get
                {
                    return this.hbysDemirbasKayitNoField;
                }
                set
                {
                    this.hbysDemirbasKayitNoField = value;
                }
            }

            /// <remarks/>
            public int demirbasNo
            {
                get
                {
                    return this.demirbasNoField;
                }
                set
                {
                    this.demirbasNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> demirbasKayitId
            {
                get
                {
                    return this.demirbasKayitIdField;
                }
                set
                {
                    this.demirbasKayitIdField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzInsertCikisSonuc : entitiesBaseClass
        {

            private int islemKayitNoField;

            private string mesajField;

            private sonucStokHareketItem[] sonucStokHareketListField;

            private bool basariDurumuField;

            /// <remarks/>
            public int islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }

            /// <remarks/>
            public sonucStokHareketItem[] sonucStokHareketList
            {
                get
                {
                    return this.sonucStokHareketListField;
                }
                set
                {
                    this.sonucStokHareketListField = value;
                }
            }

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class stokHareketCikisItem : entitiesBaseClass
        {

            private int girisStokHareketIDField;

            private decimal cikisMiktarField;

            private string hbysStokHareketIDField;

            private string cikisTibbiCihazKunyeNoField;

            private int cikisDemirbasNoField;

            private int cikisEdinmeYiliField;

            private string firmaTanimlayiciNoField;

            private string lotNoField;

            private string seriNoField;

            private System.Nullable<System.DateTime> ihaleTarihiField;

            private string ihaleNoField;

            private string sutKoduField;

            private string bayiNoField;

            /// <remarks/>
            public int girisStokHareketID
            {
                get
                {
                    return this.girisStokHareketIDField;
                }
                set
                {
                    this.girisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public decimal cikisMiktar
            {
                get
                {
                    return this.cikisMiktarField;
                }
                set
                {
                    this.cikisMiktarField = value;
                }
            }

            /// <remarks/>
            public string hbysStokHareketID
            {
                get
                {
                    return this.hbysStokHareketIDField;
                }
                set
                {
                    this.hbysStokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string cikisTibbiCihazKunyeNo
            {
                get
                {
                    return this.cikisTibbiCihazKunyeNoField;
                }
                set
                {
                    this.cikisTibbiCihazKunyeNoField = value;
                }
            }

            /// <remarks/>
            public int cikisDemirbasNo
            {
                get
                {
                    return this.cikisDemirbasNoField;
                }
                set
                {
                    this.cikisDemirbasNoField = value;
                }
            }

            /// <remarks/>
            public int cikisEdinmeYili
            {
                get
                {
                    return this.cikisEdinmeYiliField;
                }
                set
                {
                    this.cikisEdinmeYiliField = value;
                }
            }

            /// <remarks/>
            public string firmaTanimlayiciNo
            {
                get
                {
                    return this.firmaTanimlayiciNoField;
                }
                set
                {
                    this.firmaTanimlayiciNoField = value;
                }
            }

            /// <remarks/>
            public string lotNo
            {
                get
                {
                    return this.lotNoField;
                }
                set
                {
                    this.lotNoField = value;
                }
            }

            /// <remarks/>
            public string seriNo
            {
                get
                {
                    return this.seriNoField;
                }
                set
                {
                    this.seriNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> ihaleTarihi
            {
                get
                {
                    return this.ihaleTarihiField;
                }
                set
                {
                    this.ihaleTarihiField = value;
                }
            }

            /// <remarks/>
            public string ihaleNo
            {
                get
                {
                    return this.ihaleNoField;
                }
                set
                {
                    this.ihaleNoField = value;
                }
            }

            /// <remarks/>
            public string sutKodu
            {
                get
                {
                    return this.sutKoduField;
                }
                set
                {
                    this.sutKoduField = value;
                }
            }

            /// <remarks/>
            public string bayiNo
            {
                get
                {
                    return this.bayiNoField;
                }
                set
                {
                    this.bayiNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzInsertCikisItem : entitiesBaseClass
        {

            private ECikisIslemTuru islemTuruField;

            private EButceTurID butceTurIDField;

            private ECikisStokHareketTurID stokHareketTurIDField;

            private int makbuzNoField;

            private System.DateTime makbuzTarihiField;

            private string muayaneNoField;

            private System.Nullable<System.DateTime> muayeneTarihiField;

            private string dayanagiBelgeNoField;

            private System.Nullable<System.DateTime> dayanagiBelgeTarihiField;

            private int depoKayitNoField;

            private string teslimEdenField;

            private string fisAciklamaField;

            private string teslimAlanField;

            private System.Nullable<int> cikisYapilanDepoKayitNoField;

            private System.Nullable<int> cikisBirimKayitNoField;

            private string cikisYapilanKisiTCKimlikNoField;

            private string doktorTCKimlikNoField;

            private string digerBirimAdiField;

            private string hbysIDField;

            private stokHareketCikisItem[] cikisStokHareketListField;

            /// <remarks/>
            public ECikisIslemTuru islemTuru
            {
                get
                {
                    return this.islemTuruField;
                }
                set
                {
                    this.islemTuruField = value;
                }
            }

            /// <remarks/>
            public EButceTurID butceTurID
            {
                get
                {
                    return this.butceTurIDField;
                }
                set
                {
                    this.butceTurIDField = value;
                }
            }

            /// <remarks/>
            public ECikisStokHareketTurID stokHareketTurID
            {
                get
                {
                    return this.stokHareketTurIDField;
                }
                set
                {
                    this.stokHareketTurIDField = value;
                }
            }

            /// <remarks/>
            public int makbuzNo
            {
                get
                {
                    return this.makbuzNoField;
                }
                set
                {
                    this.makbuzNoField = value;
                }
            }

            /// <remarks/>
            public System.DateTime makbuzTarihi
            {
                get
                {
                    return this.makbuzTarihiField;
                }
                set
                {
                    this.makbuzTarihiField = value;
                }
            }

            /// <remarks/>
            public string muayaneNo
            {
                get
                {
                    return this.muayaneNoField;
                }
                set
                {
                    this.muayaneNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> muayeneTarihi
            {
                get
                {
                    return this.muayeneTarihiField;
                }
                set
                {
                    this.muayeneTarihiField = value;
                }
            }

            /// <remarks/>
            public string dayanagiBelgeNo
            {
                get
                {
                    return this.dayanagiBelgeNoField;
                }
                set
                {
                    this.dayanagiBelgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> dayanagiBelgeTarihi
            {
                get
                {
                    return this.dayanagiBelgeTarihiField;
                }
                set
                {
                    this.dayanagiBelgeTarihiField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string teslimEden
            {
                get
                {
                    return this.teslimEdenField;
                }
                set
                {
                    this.teslimEdenField = value;
                }
            }

            /// <remarks/>
            public string fisAciklama
            {
                get
                {
                    return this.fisAciklamaField;
                }
                set
                {
                    this.fisAciklamaField = value;
                }
            }

            /// <remarks/>
            public string teslimAlan
            {
                get
                {
                    return this.teslimAlanField;
                }
                set
                {
                    this.teslimAlanField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisYapilanDepoKayitNo
            {
                get
                {
                    return this.cikisYapilanDepoKayitNoField;
                }
                set
                {
                    this.cikisYapilanDepoKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisBirimKayitNo
            {
                get
                {
                    return this.cikisBirimKayitNoField;
                }
                set
                {
                    this.cikisBirimKayitNoField = value;
                }
            }

            /// <remarks/>
            public string cikisYapilanKisiTCKimlikNo
            {
                get
                {
                    return this.cikisYapilanKisiTCKimlikNoField;
                }
                set
                {
                    this.cikisYapilanKisiTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            public string doktorTCKimlikNo
            {
                get
                {
                    return this.doktorTCKimlikNoField;
                }
                set
                {
                    this.doktorTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            public string digerBirimAdi
            {
                get
                {
                    return this.digerBirimAdiField;
                }
                set
                {
                    this.digerBirimAdiField = value;
                }
            }

            /// <remarks/>
            public string hbysID
            {
                get
                {
                    return this.hbysIDField;
                }
                set
                {
                    this.hbysIDField = value;
                }
            }

            /// <remarks/>
            public stokHareketCikisItem[] cikisStokHareketList
            {
                get
                {
                    return this.cikisStokHareketListField;
                }
                set
                {
                    this.cikisStokHareketListField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum ECikisIslemTuru
        {

            /// <remarks/>
            cikis,

            /// <remarks/>
            halksagcikis,

            /// <remarks/>
            emanet,

            /// <remarks/>
            ihtiyacFazlasi,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum ECikisStokHareketTurID
        {

            /// <remarks/>
            ckAmbarlarArasiDevir,

            /// <remarks/>
            ckFireZayiat,

            /// <remarks/>
            ckDevirDigerBirimlereCikis,

            /// <remarks/>
            ckTuketim,

            /// <remarks/>
            ckDevirKurumDisiMalzemeCikis,

            /// <remarks/>
            ckTerkin,

            /// <remarks/>
            ckSatis,

            /// <remarks/>
            ckSayimNoksani,

            /// <remarks/>
            ckYabanciUlkelereBagis,

            /// <remarks/>
            ckKullanilmazHaleGelmeYokOlma,

            /// <remarks/>
            ckHurdayaAyirma,

            /// <remarks/>
            ckDonerSermayedenDevir,

            /// <remarks/>
            ckDuzeltme,

            /// <remarks/>
            ckTakas,

            /// <remarks/>
            ckDevirIhtiyacFazlasiDevir,

            /// <remarks/>
            ckDevirStokFazlasiDevir,

            /// <remarks/>
            ckSatinalmasiBaglananXXXXXXCikisi,

            /// <remarks/>
            ckXXXXXXBirlesmesindenDevir,

            /// <remarks/>
            ckBagliBirimlereCikis,

            /// <remarks/>
            ckTemelSagligaDevir,

            /// <remarks/>
            ckKullanimaVermeKisi,

            /// <remarks/>
            ckKullanimaVermeOrtakAlan,

            /// <remarks/>
            ckIhtiyacFazlasi,

            /// <remarks/>
            ckIhtiyacFazlasiIade,

            /// <remarks/>
            ckZimmettenIade,

            /// <remarks/>
            ckAfetDurumuCikisi,

            /// <remarks/>
            ckDevirUnvXXXXXXneIhtiyacFazlasiDevir,

            /// <remarks/>
            ckDevirUnvXXXXXXneStokFazlasiDevir,

            /// <remarks/>
            ck663KHKyaDevir,

            /// <remarks/>
            ckTuketimYatanHastaTedavisi,

            /// <remarks/>
            ckTuketimAyaktaTedaviAcilServis,

            /// <remarks/>
            ckTuketimGunuBirlikTedaviAcilServis,

            /// <remarks/>
            ckTuketimProtokolHizmeti,

            /// <remarks/>
            ckMiadUzatimiCikis,

            /// <remarks/>
            ckBagliSaglikTesislerineDevir,

            /// <remarks/>
            ckKamuOzelXXXXXXAantidotAntidoksinSatisi,

            /// <remarks/>
            skHalkSagligiBagliBirimlereCikis,

            /// <remarks/>
            ckTuketimEvdeSaglik,

            /// <remarks/>
            ckBirlikiciSaglikTesisineDevir,

            /// <remarks/>
            ckSaglikTesisindenGenelSekreterligeDevir,

            /// <remarks/>
            ckGarantiVeyaSigortaKapsamindaCikis,

            /// <remarks/>
            ckEmanetCikis,

            /// <remarks/>
            ckEmanetIade,

            /// <remarks/>
            ckPgdCikisi,

            /// <remarks/>
            ckDevirDigerKamuIdarelerineDevirCikisi,

            /// <remarks/>
            ckDevirKurumlarArasiDevirCikisi,

            /// <remarks/>
            ck669KHKDevirCikisi,

            /// <remarks/>
            ck667KHKIadeCikisi,

            /// <remarks/>
            ckTedarikPaylasim,

            /// <remarks/>
            ckDevirMilliSavunmaBakanligiMsbCikisi,

            /// <remarks/>
            ck694KHKDevirCikis,

            /// <remarks/>
            ckProjeKapsamindaCikis,

            /// <remarks/>
            ckKullanimaVermeEvdeBakim,

            /// <remarks/>
            ckMucbirDevirTedarikPaylasim,

            /// <remarks/>
            ckDevirSaglikMarketDevir,

            /// <remarks/>
            ckUniversiteGoturuBedelProtokoluDevirCikis,

            /// <remarks/>
            ckHibeBarisGucu,

            /// <remarks/>
            ckKullanimaVermeGeciciTahsis,

            /// <remarks/>
            ckDevirIcisleriBakanligiProtokolDevirCikis,

            /// <remarks/>
            ckSgkTarafindanTedarikEdilenUrun,

            /// <remarks/>
            ckDevirKaynakGelistirmeDevirGirisi,

            /// <remarks/>
            ckDevirKemoterapiIlacHazirlamaHizmeti,

            /// <remarks/>
            ckSgkAyaktanTedarik,

            /// <remarks/>
            ckSgkYatanTedarik,

            /// <remarks/>
            ckDevirSgkAyaktanDevir,

            /// <remarks/>
            ckDevirSgkYatanDevir,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzInsertGirisSonuc : entitiesBaseClass
        {

            private int ayniyatMakbuzIDField;

            private string mesajField;

            private sonucMakbuzDetayItem[] sonucMakbuzDetayListField;

            private sonucStokHareketItem[] sonucStokHareketListField;

            private bool basariDurumuField;

            /// <remarks/>
            public int ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }

            /// <remarks/>
            public sonucMakbuzDetayItem[] sonucMakbuzDetayList
            {
                get
                {
                    return this.sonucMakbuzDetayListField;
                }
                set
                {
                    this.sonucMakbuzDetayListField = value;
                }
            }

            /// <remarks/>
            public sonucStokHareketItem[] sonucStokHareketList
            {
                get
                {
                    return this.sonucStokHareketListField;
                }
                set
                {
                    this.sonucStokHareketListField = value;
                }
            }

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class makbuzInsertGirisItem : entitiesBaseClass
        {

            private EGirisIslemTuru islemTuruField;

            private EButceTurID butceTurIDField;

            private ETedarikTurID tedarikTurIDField;

            private EMalzemeGrupID malzemeGrupIDField;

            private EGirisStokHareketTurID stokHareketTurIDField;

            private int makbuzNoField;

            private System.DateTime makbuzTarihiField;

            private string muayeneNoField;

            private System.Nullable<System.DateTime> muayeneTarihiField;

            private string dayanagiBelgeNoField;

            private System.Nullable<System.DateTime> dayanagiBelgeTarihiField;

            private int depoKayitNoField;

            private string teslimEdenField;

            private string fisAciklamaField;

            private string teslimAlanField;

            private string geldigiYerField;

            private EAlimYontemiID alimYontemiIDField;

            private System.Nullable<int> gonderenBirimKayitNoField;

            private string hbysIDField;

            private System.Nullable<System.DateTime> ihaleTarihiField;

            private string ihaleKayitNoField;

            private string firmaVergiKayitNoField;

            private string genelButceHarcamaKoduField;

            private makbuzDetayGirisItem[] makbuzDetayListField;

            private demirbasGirisItem[] demirbasItemListField;

            /// <remarks/>
            public EGirisIslemTuru islemTuru
            {
                get
                {
                    return this.islemTuruField;
                }
                set
                {
                    this.islemTuruField = value;
                }
            }

            /// <remarks/>
            public EButceTurID butceTurID
            {
                get
                {
                    return this.butceTurIDField;
                }
                set
                {
                    this.butceTurIDField = value;
                }
            }

            /// <remarks/>
            public ETedarikTurID tedarikTurID
            {
                get
                {
                    return this.tedarikTurIDField;
                }
                set
                {
                    this.tedarikTurIDField = value;
                }
            }

            /// <remarks/>
            public EMalzemeGrupID malzemeGrupID
            {
                get
                {
                    return this.malzemeGrupIDField;
                }
                set
                {
                    this.malzemeGrupIDField = value;
                }
            }

            /// <remarks/>
            public EGirisStokHareketTurID stokHareketTurID
            {
                get
                {
                    return this.stokHareketTurIDField;
                }
                set
                {
                    this.stokHareketTurIDField = value;
                }
            }

            /// <remarks/>
            public int makbuzNo
            {
                get
                {
                    return this.makbuzNoField;
                }
                set
                {
                    this.makbuzNoField = value;
                }
            }

            /// <remarks/>
            public System.DateTime makbuzTarihi
            {
                get
                {
                    return this.makbuzTarihiField;
                }
                set
                {
                    this.makbuzTarihiField = value;
                }
            }

            /// <remarks/>
            public string muayeneNo
            {
                get
                {
                    return this.muayeneNoField;
                }
                set
                {
                    this.muayeneNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> muayeneTarihi
            {
                get
                {
                    return this.muayeneTarihiField;
                }
                set
                {
                    this.muayeneTarihiField = value;
                }
            }

            /// <remarks/>
            public string dayanagiBelgeNo
            {
                get
                {
                    return this.dayanagiBelgeNoField;
                }
                set
                {
                    this.dayanagiBelgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> dayanagiBelgeTarihi
            {
                get
                {
                    return this.dayanagiBelgeTarihiField;
                }
                set
                {
                    this.dayanagiBelgeTarihiField = value;
                }
            }

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string teslimEden
            {
                get
                {
                    return this.teslimEdenField;
                }
                set
                {
                    this.teslimEdenField = value;
                }
            }

            /// <remarks/>
            public string fisAciklama
            {
                get
                {
                    return this.fisAciklamaField;
                }
                set
                {
                    this.fisAciklamaField = value;
                }
            }

            /// <remarks/>
            public string teslimAlan
            {
                get
                {
                    return this.teslimAlanField;
                }
                set
                {
                    this.teslimAlanField = value;
                }
            }

            /// <remarks/>
            public string geldigiYer
            {
                get
                {
                    return this.geldigiYerField;
                }
                set
                {
                    this.geldigiYerField = value;
                }
            }

            /// <remarks/>
            public EAlimYontemiID alimYontemiID
            {
                get
                {
                    return this.alimYontemiIDField;
                }
                set
                {
                    this.alimYontemiIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> gonderenBirimKayitNo
            {
                get
                {
                    return this.gonderenBirimKayitNoField;
                }
                set
                {
                    this.gonderenBirimKayitNoField = value;
                }
            }

            /// <remarks/>
            public string hbysID
            {
                get
                {
                    return this.hbysIDField;
                }
                set
                {
                    this.hbysIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> ihaleTarihi
            {
                get
                {
                    return this.ihaleTarihiField;
                }
                set
                {
                    this.ihaleTarihiField = value;
                }
            }

            /// <remarks/>
            public string ihaleKayitNo
            {
                get
                {
                    return this.ihaleKayitNoField;
                }
                set
                {
                    this.ihaleKayitNoField = value;
                }
            }

            /// <remarks/>
            public string firmaVergiKayitNo
            {
                get
                {
                    return this.firmaVergiKayitNoField;
                }
                set
                {
                    this.firmaVergiKayitNoField = value;
                }
            }

            /// <remarks/>
            public string genelButceHarcamaKodu
            {
                get
                {
                    return this.genelButceHarcamaKoduField;
                }
                set
                {
                    this.genelButceHarcamaKoduField = value;
                }
            }

            /// <remarks/>
            public makbuzDetayGirisItem[] makbuzDetayList
            {
                get
                {
                    return this.makbuzDetayListField;
                }
                set
                {
                    this.makbuzDetayListField = value;
                }
            }

            /// <remarks/>
            public demirbasGirisItem[] demirbasItemList
            {
                get
                {
                    return this.demirbasItemListField;
                }
                set
                {
                    this.demirbasItemListField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EGirisIslemTuru
        {

            /// <remarks/>
            giris,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum ETedarikTurID
        {

            /// <remarks/>
            satinalma,

            /// <remarks/>
            takas,

            /// <remarks/>
            duzeltme,

            /// <remarks/>
            icImkanlarlaUretim,

            /// <remarks/>
            tasfiyeIdaresindenEdinilen,

            /// <remarks/>
            sayimFazlasi,

            /// <remarks/>
            iadeEdilen,

            /// <remarks/>
            devirAlinan,

            /// <remarks/>
            bagisVeYardim,

            /// <remarks/>
            temelSagliktanDevir,

            /// <remarks/>
            XXXXXXBirlesmesindenDevir,

            /// <remarks/>
            koordinatorXXXXXXdenDevir,

            /// <remarks/>
            stokFazlasiDevir,

            /// <remarks/>
            ihtiyacFazlasiDevir,

            /// <remarks/>
            ambarlarArasiDevir,

            /// <remarks/>
            acilisFiiliSayim,

            /// <remarks/>
            novartisHibe,

            /// <remarks/>
            ilOzelIdaresindenDevirAlinan,

            /// <remarks/>
            universiteXXXXXXndenIhtiyacFazlasiDevir,

            /// <remarks/>
            universiteXXXXXXndenStokFazlasiDevir,

            /// <remarks/>
            KHKdanDevirAlinan,

            /// <remarks/>
            MiadUzatimi,

            /// <remarks/>
            bagliBirliktenDevir,

            /// <remarks/>
            birlikSaglikTesisineDevir,

            /// <remarks/>
            bagliSaglikTsisisndenDevir,

            /// <remarks/>
            garantiSigortaKapsamindaGiris,

            /// <remarks/>
            XXXXXXAndidotAntidoksinGiris,

            /// <remarks/>
            devirKurumlarArasiDevir,

            /// <remarks/>
            devirDigerKamuIdarelerineDevirGiris,

            /// <remarks/>
            devir667KHKDevir,

            /// <remarks/>
            devir669KHKDevir,

            /// <remarks/>
            devirTedarikPaylasim,

            /// <remarks/>
            hudutSahillerindenDevir,

            /// <remarks/>
            hibeProje,

            /// <remarks/>
            kamuOzelIsBirligi6428SayiliKanun,

            /// <remarks/>
            devir694KHKDevir,

            /// <remarks/>
            hibeSihhatProje,

            /// <remarks/>
            devirMucbirDevirTedarikPaylasim,

            /// <remarks/>
            pgd,

            /// <remarks/>
            devirSaglikMarketDevir,

            /// <remarks/>
            devirGeciciTahsisDevir,

            /// <remarks/>
            hibeBarisGucu,

            /// <remarks/>
            sgkTarafindanTedarikEdilenUrun,

            /// <remarks/>
            devirKaynakGelistirme,

            /// <remarks/>
            devirKemoterapiIlacHazirlamaHizmeti,

            /// <remarks/>
            sgkAyaktanTedarik,

            /// <remarks/>
            sgkYatanTedarik,

            /// <remarks/>
            devirSgkAyaktanDevir,

            /// <remarks/>
            devirSgkYatanDevir,

            /// <remarks/>
            devir689KHKDevir,

            /// <remarks/>
            devirCovid19DevirAlinan,

            /// <remarks/>
            covid19Satinalma,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EGirisStokHareketTurID
        {

            /// <remarks/>
            grSatinAlinanMalzemeninGirisi,

            /// <remarks/>
            grBirimlerdenGelenMalzemeGirisi,

            /// <remarks/>
            grBirimlerdenIade,

            /// <remarks/>
            grSayimFazlasi,

            /// <remarks/>
            grYilSonuDevri,

            /// <remarks/>
            grIadeEdilen,

            /// <remarks/>
            grIcImkanlarlaUretilen,

            /// <remarks/>
            grTasfiyeIdaresindenEdinilen,

            /// <remarks/>
            grBagisHibe,

            /// <remarks/>
            grAmbarlarArasiDevir,

            /// <remarks/>
            grDuzetme,

            /// <remarks/>
            grTakas,

            /// <remarks/>
            grIhtiyacFazlasiGirisi,

            /// <remarks/>
            grStokFazlasiGirisi,

            /// <remarks/>
            grKoordinatorXXXXXXdenDevirAlinan,

            /// <remarks/>
            grXXXXXXBirlesmesindenDevir,

            /// <remarks/>
            grTemelSagliktanDevir,

            /// <remarks/>
            grHibeProje,

            /// <remarks/>
            grNovartisHibe,

            /// <remarks/>
            grilOzelIdaresindenDevir,

            /// <remarks/>
            grUnvXXXXXXndenStokFazlasiDevirGirisi,

            /// <remarks/>
            grUnvXXXXXXndenIhtiyacFazlasiDevirGirisi,

            /// <remarks/>
            gr663KHKdanDevirGirisi,

            /// <remarks/>
            grMiadUzatimiGiris,

            /// <remarks/>
            grBagliBirliktenDevirGirisi,

            /// <remarks/>
            grBirlikSaglikTesisineDevir,

            /// <remarks/>
            grSaglikTesisindenGenelSekreterligeDevir,

            /// <remarks/>
            grGarantiVeyaSigortaKApsamindaGiris,

            /// <remarks/>
            grSatinalinanKamuOZelXXXXXXAntidotAntidoksinCikis,

            /// <remarks/>
            grDevirKurumlarArasiDevirGirisi,

            /// <remarks/>
            grDevirDigerKamuIdarelerineDevirGiris,

            /// <remarks/>
            gr667KHKDevir,

            /// <remarks/>
            gr669KHKDevir,

            /// <remarks/>
            grHudutSahillerindenDevirGirisi,

            /// <remarks/>
            grTedarikPaylasim,

            /// <remarks/>
            grKamuOzelIsBirligi6428SayiliKanun,

            /// <remarks/>
            gr694KHKDevir,

            /// <remarks/>
            grHibeSihhatProje,

            /// <remarks/>
            grMucbirDevirTedarikPaylasim,

            /// <remarks/>
            grPgdGirisi,

            /// <remarks/>
            grDevirSaglikMarketDevir,

            /// <remarks/>
            grHibeBarisGucu,

            /// <remarks/>
            grSgkTarafindanTedarikEdilenUrun,

            /// <remarks/>
            grDevirKaynakGelistirmeDevirGirisi,

            /// <remarks/>
            grDevirKemoterapiIlacHazirlamaHizmeti,

            /// <remarks/>
            grSgkAyaktanTedarik,

            /// <remarks/>
            grSgkYatanTedarik,

            /// <remarks/>
            grDevirSgkAyaktanDevir,

            /// <remarks/>
            grDevirSgkYatanDevir,

            /// <remarks/>
            gr689KHKDevir,

            /// <remarks/>
            grDevirCovid19DevirAlinan,

            /// <remarks/>
            grCovid19SatinalmaGiris,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class depoUpdateItem : entitiesBaseClass
        {

            private int depoKayitNoField;

            private string depoTanimiField;

            private EEntegrasyonDurumu entegrasyonDurumuField;

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string depoTanimi
            {
                get
                {
                    return this.depoTanimiField;
                }
                set
                {
                    this.depoTanimiField = value;
                }
            }

            /// <remarks/>
            public EEntegrasyonDurumu entegrasyonDurumu
            {
                get
                {
                    return this.entegrasyonDurumuField;
                }
                set
                {
                    this.entegrasyonDurumuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EEntegrasyonDurumu
        {

            /// <remarks/>
            entegre,

            /// <remarks/>
            kapsamDisi,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class depoKayitIslemleriSonuc : entitiesBaseClass
        {

            private int depoKayitNoField;

            private string mesajField;

            private bool basariDurumuField;

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class depoInsertItem : entitiesBaseClass
        {

            private string depoKoduField;

            private string depoTanimiField;

            private string sorumluKisiTCKimlikNoField;

            private EEntegrasyonDurumu entegrasyonDurumuField;

            /// <remarks/>
            public string depoKodu
            {
                get
                {
                    return this.depoKoduField;
                }
                set
                {
                    this.depoKoduField = value;
                }
            }

            /// <remarks/>
            public string depoTanimi
            {
                get
                {
                    return this.depoTanimiField;
                }
                set
                {
                    this.depoTanimiField = value;
                }
            }

            /// <remarks/>
            public string sorumluKisiTCKimlikNo
            {
                get
                {
                    return this.sorumluKisiTCKimlikNoField;
                }
                set
                {
                    this.sorumluKisiTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            public EEntegrasyonDurumu entegrasyonDurumu
            {
                get
                {
                    return this.entegrasyonDurumuField;
                }
                set
                {
                    this.entegrasyonDurumuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class birimDepoItem : entitiesBaseClass
        {

            private int depoKayitNoField;

            private string depoKoduField;

            private string depoTanimiField;

            private string entegrasyonKapsamindaField;

            private System.Nullable<int> birimKayitNoField;

            private System.Nullable<EDepoNitelikID> depoNitelikField;

            /// <remarks/>
            public int depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            public string depoKodu
            {
                get
                {
                    return this.depoKoduField;
                }
                set
                {
                    this.depoKoduField = value;
                }
            }

            /// <remarks/>
            public string depoTanimi
            {
                get
                {
                    return this.depoTanimiField;
                }
                set
                {
                    this.depoTanimiField = value;
                }
            }

            /// <remarks/>
            public string entegrasyonKapsaminda
            {
                get
                {
                    return this.entegrasyonKapsamindaField;
                }
                set
                {
                    this.entegrasyonKapsamindaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> birimKayitNo
            {
                get
                {
                    return this.birimKayitNoField;
                }
                set
                {
                    this.birimKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<EDepoNitelikID> depoNitelik
            {
                get
                {
                    return this.depoNitelikField;
                }
                set
                {
                    this.depoNitelikField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EDepoNitelikID
        {

            /// <remarks/>
            Depo112,

            /// <remarks/>
            DepoHalkSagligi,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class birimItem : entitiesBaseClass
        {

            private System.Nullable<int> birimKayitNoField;

            private string birimAdiField;

            private string birimKoduField;

            private string birimKisaAdiField;

            private string turField;

            private string faaliyetDurumuField;

            private System.Nullable<int> bagliBirimIDField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> birimKayitNo
            {
                get
                {
                    return this.birimKayitNoField;
                }
                set
                {
                    this.birimKayitNoField = value;
                }
            }

            /// <remarks/>
            public string birimAdi
            {
                get
                {
                    return this.birimAdiField;
                }
                set
                {
                    this.birimAdiField = value;
                }
            }

            /// <remarks/>
            public string birimKodu
            {
                get
                {
                    return this.birimKoduField;
                }
                set
                {
                    this.birimKoduField = value;
                }
            }

            /// <remarks/>
            public string birimKisaAdi
            {
                get
                {
                    return this.birimKisaAdiField;
                }
                set
                {
                    this.birimKisaAdiField = value;
                }
            }

            /// <remarks/>
            public string tur
            {
                get
                {
                    return this.turField;
                }
                set
                {
                    this.turField = value;
                }
            }

            /// <remarks/>
            public string faaliyetDurumu
            {
                get
                {
                    return this.faaliyetDurumuField;
                }
                set
                {
                    this.faaliyetDurumuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> bagliBirimID
            {
                get
                {
                    return this.bagliBirimIDField;
                }
                set
                {
                    this.bagliBirimIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ntKodItem : entitiesBaseClass
        {

            private string kodAdiField;

            private string degeriField;

            private string aciklamaField;

            private System.Nullable<int> enumNoField;

            private bool aktifField;

            /// <remarks/>
            public string kodAdi
            {
                get
                {
                    return this.kodAdiField;
                }
                set
                {
                    this.kodAdiField = value;
                }
            }

            /// <remarks/>
            public string degeri
            {
                get
                {
                    return this.degeriField;
                }
                set
                {
                    this.degeriField = value;
                }
            }

            /// <remarks/>
            public string aciklama
            {
                get
                {
                    return this.aciklamaField;
                }
                set
                {
                    this.aciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> enumNo
            {
                get
                {
                    return this.enumNoField;
                }
                set
                {
                    this.enumNoField = value;
                }
            }

            /// <remarks/>
            public bool aktif
            {
                get
                {
                    return this.aktifField;
                }
                set
                {
                    this.aktifField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ihaleTarihiUpdateResult : entitiesBaseClass
        {

            private bool basaridurumuField;

            private string mesajField;

            private string ihaleNoField;

            private System.Nullable<System.DateTime> ihaleTarihiField;

            private int ayniyatMakbuzIDField;

            /// <remarks/>
            public bool basaridurumu
            {
                get
                {
                    return this.basaridurumuField;
                }
                set
                {
                    this.basaridurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }

            /// <remarks/>
            public string ihaleNo
            {
                get
                {
                    return this.ihaleNoField;
                }
                set
                {
                    this.ihaleNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> ihaleTarihi
            {
                get
                {
                    return this.ihaleTarihiField;
                }
                set
                {
                    this.ihaleTarihiField = value;
                }
            }

            /// <remarks/>
            public int ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ihaleTarihiUpdateInsertItem : entitiesBaseClass
        {

            private string ihaleNoField;

            private System.Nullable<System.DateTime> ihaleTarihiField;

            private int ayniyatMakbuzIDField;

            /// <remarks/>
            public string ihaleNo
            {
                get
                {
                    return this.ihaleNoField;
                }
                set
                {
                    this.ihaleNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> ihaleTarihi
            {
                get
                {
                    return this.ihaleTarihiField;
                }
                set
                {
                    this.ihaleTarihiField = value;
                }
            }

            /// <remarks/>
            public int ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class yetkiKontrolSonuc : entitiesBaseClass
        {

            private bool firmaLisansSonucField;

            private bool mkysLisansSonucField;

            private string mesajField;

            private bool basariliField;

            private int kullaniciBirimIDField;

            /// <remarks/>
            public bool firmaLisansSonuc
            {
                get
                {
                    return this.firmaLisansSonucField;
                }
                set
                {
                    this.firmaLisansSonucField = value;
                }
            }

            /// <remarks/>
            public bool mkysLisansSonuc
            {
                get
                {
                    return this.mkysLisansSonucField;
                }
                set
                {
                    this.mkysLisansSonucField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }

            /// <remarks/>
            public bool basarili
            {
                get
                {
                    return this.basariliField;
                }
                set
                {
                    this.basariliField = value;
                }
            }

            /// <remarks/>
            public int kullaniciBirimID
            {
                get
                {
                    return this.kullaniciBirimIDField;
                }
                set
                {
                    this.kullaniciBirimIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class devirGerceklestiriciSonuc : entitiesBaseClass
        {

            private bool basariDurumuField;

            private string mesajField;

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string mesaj
            {
                get
                {
                    return this.mesajField;
                }
                set
                {
                    this.mesajField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class devirGerceklestiYapItem : entitiesBaseClass
        {

            private int stokHareketIDField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class malzemeTeknikOzellikResult : entitiesBaseClass
        {

            private bool basariDurumuField;

            private string hataMesajiField;

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return this.basariDurumuField;
                }
                set
                {
                    this.basariDurumuField = value;
                }
            }

            /// <remarks/>
            public string hataMesaji
            {
                get
                {
                    return this.hataMesajiField;
                }
                set
                {
                    this.hataMesajiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class teknikOzellikInsertItem : entitiesBaseClass
        {

            private int stokHareketIDField;

            private string ubbBarkoduField;

            private string cihazinAdiField;

            private string markaIsmiField;

            private string modelNoField;

            private System.DateTime uretimTarihiField;

            private string seriNoField;

            private int garantiSuresiField;

            private System.Nullable<bool> bakimHizmetiAliniyormuField;

            private ECihazDurumID cihazinDurumuField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string ubbBarkodu
            {
                get
                {
                    return this.ubbBarkoduField;
                }
                set
                {
                    this.ubbBarkoduField = value;
                }
            }

            /// <remarks/>
            public string cihazinAdi
            {
                get
                {
                    return this.cihazinAdiField;
                }
                set
                {
                    this.cihazinAdiField = value;
                }
            }

            /// <remarks/>
            public string markaIsmi
            {
                get
                {
                    return this.markaIsmiField;
                }
                set
                {
                    this.markaIsmiField = value;
                }
            }

            /// <remarks/>
            public string modelNo
            {
                get
                {
                    return this.modelNoField;
                }
                set
                {
                    this.modelNoField = value;
                }
            }

            /// <remarks/>
            public System.DateTime uretimTarihi
            {
                get
                {
                    return this.uretimTarihiField;
                }
                set
                {
                    this.uretimTarihiField = value;
                }
            }

            /// <remarks/>
            public string seriNo
            {
                get
                {
                    return this.seriNoField;
                }
                set
                {
                    this.seriNoField = value;
                }
            }

            /// <remarks/>
            public int garantiSuresi
            {
                get
                {
                    return this.garantiSuresiField;
                }
                set
                {
                    this.garantiSuresiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<bool> bakimHizmetiAliniyormu
            {
                get
                {
                    return this.bakimHizmetiAliniyormuField;
                }
                set
                {
                    this.bakimHizmetiAliniyormuField = value;
                }
            }

            /// <remarks/>
            public ECihazDurumID cihazinDurumu
            {
                get
                {
                    return this.cihazinDurumuField;
                }
                set
                {
                    this.cihazinDurumuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum ECihazDurumID
        {

            /// <remarks/>
            Aktif,

            /// <remarks/>
            Pasif,

            /// <remarks/>
            Arizali,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class universiteXXXXXXleriSonucItem : entitiesBaseClass
        {

            private string adField;

            private int siraNoField;

            private int stdBRKoduField;

            private string turField;

            private string faaliyetDurumuField;

            private string hataKoduField;

            /// <remarks/>
            public string ad
            {
                get
                {
                    return this.adField;
                }
                set
                {
                    this.adField = value;
                }
            }

            /// <remarks/>
            public int siraNo
            {
                get
                {
                    return this.siraNoField;
                }
                set
                {
                    this.siraNoField = value;
                }
            }

            /// <remarks/>
            public int stdBRKodu
            {
                get
                {
                    return this.stdBRKoduField;
                }
                set
                {
                    this.stdBRKoduField = value;
                }
            }

            /// <remarks/>
            public string tur
            {
                get
                {
                    return this.turField;
                }
                set
                {
                    this.turField = value;
                }
            }

            /// <remarks/>
            public string faaliyetDurumu
            {
                get
                {
                    return this.faaliyetDurumuField;
                }
                set
                {
                    this.faaliyetDurumuField = value;
                }
            }

            /// <remarks/>
            public string hataKodu
            {
                get
                {
                    return this.hataKoduField;
                }
                set
                {
                    this.hataKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class yilSonuDevriSonucItem : entitiesBaseClass
        {

            private int malzeme_kayit_idField;

            private decimal miktarField;

            private decimal vergisiz_fiyatField;

            private decimal vergili_fiyatField;

            private decimal kdv_oraniField;

            private decimal indirim_oraniField;

            private string olcu_birimi_idField;

            private string malzeme_aciklamasiField;

            private string tasinir_koduField;

            private System.Nullable<System.DateTime> belge_tarihiField;

            private string belge_noField;

            private string hataKoduField;

            private int stokHareketIDField;

            private System.Nullable<System.DateTime> sonKullanmaTarihiField;

            private string butceTurIDField;

            private string barkodField;

            /// <remarks/>
            public int malzeme_kayit_id
            {
                get
                {
                    return this.malzeme_kayit_idField;
                }
                set
                {
                    this.malzeme_kayit_idField = value;
                }
            }

            /// <remarks/>
            public decimal miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public decimal vergisiz_fiyat
            {
                get
                {
                    return this.vergisiz_fiyatField;
                }
                set
                {
                    this.vergisiz_fiyatField = value;
                }
            }

            /// <remarks/>
            public decimal vergili_fiyat
            {
                get
                {
                    return this.vergili_fiyatField;
                }
                set
                {
                    this.vergili_fiyatField = value;
                }
            }

            /// <remarks/>
            public decimal kdv_orani
            {
                get
                {
                    return this.kdv_oraniField;
                }
                set
                {
                    this.kdv_oraniField = value;
                }
            }

            /// <remarks/>
            public decimal indirim_orani
            {
                get
                {
                    return this.indirim_oraniField;
                }
                set
                {
                    this.indirim_oraniField = value;
                }
            }

            /// <remarks/>
            public string olcu_birimi_id
            {
                get
                {
                    return this.olcu_birimi_idField;
                }
                set
                {
                    this.olcu_birimi_idField = value;
                }
            }

            /// <remarks/>
            public string malzeme_aciklamasi
            {
                get
                {
                    return this.malzeme_aciklamasiField;
                }
                set
                {
                    this.malzeme_aciklamasiField = value;
                }
            }

            /// <remarks/>
            public string tasinir_kodu
            {
                get
                {
                    return this.tasinir_koduField;
                }
                set
                {
                    this.tasinir_koduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belge_tarihi
            {
                get
                {
                    return this.belge_tarihiField;
                }
                set
                {
                    this.belge_tarihiField = value;
                }
            }

            /// <remarks/>
            public string belge_no
            {
                get
                {
                    return this.belge_noField;
                }
                set
                {
                    this.belge_noField = value;
                }
            }

            /// <remarks/>
            public string hataKodu
            {
                get
                {
                    return this.hataKoduField;
                }
                set
                {
                    this.hataKoduField = value;
                }
            }

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> sonKullanmaTarihi
            {
                get
                {
                    return this.sonKullanmaTarihiField;
                }
                set
                {
                    this.sonKullanmaTarihiField = value;
                }
            }

            /// <remarks/>
            public string butceTurID
            {
                get
                {
                    return this.butceTurIDField;
                }
                set
                {
                    this.butceTurIDField = value;
                }
            }

            /// <remarks/>
            public string barkod
            {
                get
                {
                    return this.barkodField;
                }
                set
                {
                    this.barkodField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class yilSonuDevriItem : entitiesBaseClass
        {

            private int birimDepoIDField;

            private int butceYiliField;

            /// <remarks/>
            public int birimDepoID
            {
                get
                {
                    return this.birimDepoIDField;
                }
                set
                {
                    this.birimDepoIDField = value;
                }
            }

            /// <remarks/>
            public int butceYili
            {
                get
                {
                    return this.butceYiliField;
                }
                set
                {
                    this.butceYiliField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class giriseAitCikislarResultItem : entitiesBaseClass
        {

            private int stokHareketIDField;

            private string stokHareketTurIDField;

            private string islemTuruField;

            private string butceTuruIDField;

            private decimal miktarField;

            private decimal vergiliBirimFiyatField;

            private string olcuBirimIDField;

            private int belgeNoField;

            private System.Nullable<System.DateTime> belgeTarihiField;

            private string dayanakBelgeNoField;

            private System.Nullable<System.DateTime> dayanakBelgeTarihiField;

            private string malzemeDigerAciklamaField;

            private System.Nullable<int> depoKayitNoField;

            private System.Nullable<int> malzemeKayitIDField;

            private string cikisTCKimlikNoField;

            private System.Nullable<System.DateTime> uretimTarihiField;

            private System.Nullable<System.DateTime> sonKullanmaTarihiField;

            private System.Nullable<int> demirbasNoField;

            private System.Nullable<int> girisStokHareketIDField;

            private System.Nullable<int> cikisBirimDepoIDField;

            private System.Nullable<int> cikisBirimKayitNoField;

            private string malzemeKoduField;

            private string malzemeAdiField;

            private string malzemeTurIDField;

            private System.Nullable<int> islemKayitNoField;

            private System.Nullable<int> ayniyatMakbuzIDField;

            private System.Nullable<System.DateTime> iadeTarihiField;

            private System.Nullable<int> edinmeYiliField;

            private string urunBarkoduField;

            private string digerBirimAdiField;

            private string hbysIDField;

            private string hbysDetayIDField;

            private string hataKoduField;

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            public string stokHareketTurID
            {
                get
                {
                    return this.stokHareketTurIDField;
                }
                set
                {
                    this.stokHareketTurIDField = value;
                }
            }

            /// <remarks/>
            public string islemTuru
            {
                get
                {
                    return this.islemTuruField;
                }
                set
                {
                    this.islemTuruField = value;
                }
            }

            /// <remarks/>
            public string butceTuruID
            {
                get
                {
                    return this.butceTuruIDField;
                }
                set
                {
                    this.butceTuruIDField = value;
                }
            }

            /// <remarks/>
            public decimal miktar
            {
                get
                {
                    return this.miktarField;
                }
                set
                {
                    this.miktarField = value;
                }
            }

            /// <remarks/>
            public decimal vergiliBirimFiyat
            {
                get
                {
                    return this.vergiliBirimFiyatField;
                }
                set
                {
                    this.vergiliBirimFiyatField = value;
                }
            }

            /// <remarks/>
            public string olcuBirimID
            {
                get
                {
                    return this.olcuBirimIDField;
                }
                set
                {
                    this.olcuBirimIDField = value;
                }
            }

            /// <remarks/>
            public int belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string dayanakBelgeNo
            {
                get
                {
                    return this.dayanakBelgeNoField;
                }
                set
                {
                    this.dayanakBelgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> dayanakBelgeTarihi
            {
                get
                {
                    return this.dayanakBelgeTarihiField;
                }
                set
                {
                    this.dayanakBelgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string malzemeDigerAciklama
            {
                get
                {
                    return this.malzemeDigerAciklamaField;
                }
                set
                {
                    this.malzemeDigerAciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> depoKayitNo
            {
                get
                {
                    return this.depoKayitNoField;
                }
                set
                {
                    this.depoKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> malzemeKayitID
            {
                get
                {
                    return this.malzemeKayitIDField;
                }
                set
                {
                    this.malzemeKayitIDField = value;
                }
            }

            /// <remarks/>
            public string cikisTCKimlikNo
            {
                get
                {
                    return this.cikisTCKimlikNoField;
                }
                set
                {
                    this.cikisTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> uretimTarihi
            {
                get
                {
                    return this.uretimTarihiField;
                }
                set
                {
                    this.uretimTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> sonKullanmaTarihi
            {
                get
                {
                    return this.sonKullanmaTarihiField;
                }
                set
                {
                    this.sonKullanmaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> demirbasNo
            {
                get
                {
                    return this.demirbasNoField;
                }
                set
                {
                    this.demirbasNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> girisStokHareketID
            {
                get
                {
                    return this.girisStokHareketIDField;
                }
                set
                {
                    this.girisStokHareketIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisBirimDepoID
            {
                get
                {
                    return this.cikisBirimDepoIDField;
                }
                set
                {
                    this.cikisBirimDepoIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> cikisBirimKayitNo
            {
                get
                {
                    return this.cikisBirimKayitNoField;
                }
                set
                {
                    this.cikisBirimKayitNoField = value;
                }
            }

            /// <remarks/>
            public string malzemeKodu
            {
                get
                {
                    return this.malzemeKoduField;
                }
                set
                {
                    this.malzemeKoduField = value;
                }
            }

            /// <remarks/>
            public string malzemeAdi
            {
                get
                {
                    return this.malzemeAdiField;
                }
                set
                {
                    this.malzemeAdiField = value;
                }
            }

            /// <remarks/>
            public string malzemeTurID
            {
                get
                {
                    return this.malzemeTurIDField;
                }
                set
                {
                    this.malzemeTurIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> islemKayitNo
            {
                get
                {
                    return this.islemKayitNoField;
                }
                set
                {
                    this.islemKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> iadeTarihi
            {
                get
                {
                    return this.iadeTarihiField;
                }
                set
                {
                    this.iadeTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> edinmeYili
            {
                get
                {
                    return this.edinmeYiliField;
                }
                set
                {
                    this.edinmeYiliField = value;
                }
            }

            /// <remarks/>
            public string urunBarkodu
            {
                get
                {
                    return this.urunBarkoduField;
                }
                set
                {
                    this.urunBarkoduField = value;
                }
            }

            /// <remarks/>
            public string digerBirimAdi
            {
                get
                {
                    return this.digerBirimAdiField;
                }
                set
                {
                    this.digerBirimAdiField = value;
                }
            }

            /// <remarks/>
            public string hbysID
            {
                get
                {
                    return this.hbysIDField;
                }
                set
                {
                    this.hbysIDField = value;
                }
            }

            /// <remarks/>
            public string hbysDetayID
            {
                get
                {
                    return this.hbysDetayIDField;
                }
                set
                {
                    this.hbysDetayIDField = value;
                }
            }

            /// <remarks/>
            public string hataKodu
            {
                get
                {
                    return this.hataKoduField;
                }
                set
                {
                    this.hataKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class malzemeZimmetBilgisiResult : entitiesBaseClass
        {

            private string islemTuruField;

            private string hareketTuruField;

            private System.Nullable<long> zimmeteVerilenKisiTCNoField;

            private string zimmeteVerilenKisiAdSoyadField;

            private System.Nullable<int> zimmeteVerildigiBirimField;

            private System.Nullable<System.DateTime> iadeTarihiField;

            private System.DateTime belgeTarihiField;

            private string belgeNoField;

            private string hataKoduField;

            /// <remarks/>
            public string islemTuru
            {
                get
                {
                    return this.islemTuruField;
                }
                set
                {
                    this.islemTuruField = value;
                }
            }

            /// <remarks/>
            public string hareketTuru
            {
                get
                {
                    return this.hareketTuruField;
                }
                set
                {
                    this.hareketTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> zimmeteVerilenKisiTCNo
            {
                get
                {
                    return this.zimmeteVerilenKisiTCNoField;
                }
                set
                {
                    this.zimmeteVerilenKisiTCNoField = value;
                }
            }

            /// <remarks/>
            public string zimmeteVerilenKisiAdSoyad
            {
                get
                {
                    return this.zimmeteVerilenKisiAdSoyadField;
                }
                set
                {
                    this.zimmeteVerilenKisiAdSoyadField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> zimmeteVerildigiBirim
            {
                get
                {
                    return this.zimmeteVerildigiBirimField;
                }
                set
                {
                    this.zimmeteVerildigiBirimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> iadeTarihi
            {
                get
                {
                    return this.iadeTarihiField;
                }
                set
                {
                    this.iadeTarihiField = value;
                }
            }

            /// <remarks/>
            public System.DateTime belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            public string hataKodu
            {
                get
                {
                    return this.hataKoduField;
                }
                set
                {
                    this.hataKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class demirbasGetDataResult : entitiesBaseClass
        {

            private string demirbasSicilNoField;

            private string tasinirKoduField;

            private string malzemeTuruField;

            private string islemTuruField;

            private string demirbasAdiField;

            private string hareketTuruField;

            private string hareketTurIDField;

            private int edinimYiliField;

            private int stokHareketIDField;

            private int ayniyatMakbuzIDField;

            private System.Nullable<int> belgeNoField;

            private System.Nullable<System.DateTime> belgeTarihiField;

            private string hataMesajiField;

            /// <remarks/>
            public string demirbasSicilNo
            {
                get
                {
                    return this.demirbasSicilNoField;
                }
                set
                {
                    this.demirbasSicilNoField = value;
                }
            }

            /// <remarks/>
            public string tasinirKodu
            {
                get
                {
                    return this.tasinirKoduField;
                }
                set
                {
                    this.tasinirKoduField = value;
                }
            }

            /// <remarks/>
            public string malzemeTuru
            {
                get
                {
                    return this.malzemeTuruField;
                }
                set
                {
                    this.malzemeTuruField = value;
                }
            }

            /// <remarks/>
            public string islemTuru
            {
                get
                {
                    return this.islemTuruField;
                }
                set
                {
                    this.islemTuruField = value;
                }
            }

            /// <remarks/>
            public string demirbasAdi
            {
                get
                {
                    return this.demirbasAdiField;
                }
                set
                {
                    this.demirbasAdiField = value;
                }
            }

            /// <remarks/>
            public string hareketTuru
            {
                get
                {
                    return this.hareketTuruField;
                }
                set
                {
                    this.hareketTuruField = value;
                }
            }

            /// <remarks/>
            public string hareketTurID
            {
                get
                {
                    return this.hareketTurIDField;
                }
                set
                {
                    this.hareketTurIDField = value;
                }
            }

            /// <remarks/>
            public int edinimYili
            {
                get
                {
                    return this.edinimYiliField;
                }
                set
                {
                    this.edinimYiliField = value;
                }
            }

            /// <remarks/>
            public int stokHareketID
            {
                get
                {
                    return this.stokHareketIDField;
                }
                set
                {
                    this.stokHareketIDField = value;
                }
            }

            /// <remarks/>
            public int ayniyatMakbuzID
            {
                get
                {
                    return this.ayniyatMakbuzIDField;
                }
                set
                {
                    this.ayniyatMakbuzIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> belgeNo
            {
                get
                {
                    return this.belgeNoField;
                }
                set
                {
                    this.belgeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> belgeTarihi
            {
                get
                {
                    return this.belgeTarihiField;
                }
                set
                {
                    this.belgeTarihiField = value;
                }
            }

            /// <remarks/>
            public string hataMesaji
            {
                get
                {
                    return this.hataMesajiField;
                }
                set
                {
                    this.hataMesajiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum EDepoTurId
        {

            /// <remarks/>
            medikalIlac,

            /// <remarks/>
            medikalSarf,

            /// <remarks/>
            medikalLaboratuvar,

            /// <remarks/>
            medikalCerrahiAletler,

            /// <remarks/>
            biyomedikalTuketim,

            /// <remarks/>
            biyomedikalDayanikliTasinir,

            /// <remarks/>
            ayniyatTuketim,

            /// <remarks/>
            ayniyatDayanikliTasinir,
        }


        #endregion Methods

    }











}