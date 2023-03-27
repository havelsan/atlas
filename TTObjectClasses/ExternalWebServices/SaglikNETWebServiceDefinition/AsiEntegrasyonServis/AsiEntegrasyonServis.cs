
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
    public  partial class AsiEntegrasyonServis : TTObject
    {
        public static partial class WebMethods
        {
                    
        }

        #region Methods

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Stok.EntegrasyonServisi.Model.Model.Reque" +
            "st")]
        public partial class AsiKullanilabilirlikSorgusuGirdi
        {

            private KullaniciBilgisi kullaniciBilgisiField;

            private AsiSorguBilgisi sorguBilgisiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public KullaniciBilgisi KullaniciBilgisi
            {
                get
                {
                    return kullaniciBilgisiField;
                }
                set
                {
                    kullaniciBilgisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public AsiSorguBilgisi SorguBilgisi
            {
                get
                {
                    return sorguBilgisiField;
                }
                set
                {
                    sorguBilgisiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "ats.saglik.gov.tr/KullaniciBilgisi")]
        public partial class KullaniciBilgisi
        {

            private string kullaniciAdiField;

            private string parolaField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string KullaniciAdi
            {
                get
                {
                    return kullaniciAdiField;
                }
                set
                {
                    kullaniciAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string Parola
            {
                get
                {
                    return parolaField;
                }
                set
                {
                    parolaField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Stok.EntegrasyonServisi.Model.Model.Respo" +
            "nse")]
        public partial class TuketimSorgusuCikti
        {

            private string bilgiField;

            private string sorguNoField;

            private bool varMiField;

            private bool varMiFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string Bilgi
            {
                get
                {
                    return bilgiField;
                }
                set
                {
                    bilgiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string SorguNo
            {
                get
                {
                    return sorguNoField;
                }
                set
                {
                    sorguNoField = value;
                }
            }

            /// <remarks/>
            public bool VarMi
            {
                get
                {
                    return varMiField;
                }
                set
                {
                    varMiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool VarMiSpecified
            {
                get
                {
                    return varMiFieldSpecified;
                }
                set
                {
                    varMiFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Stok.EntegrasyonServisi.Model.Model.Reque" +
            "st")]
        public partial class TuketimSorgusuGirdi
        {

            private KullaniciBilgisi kullaniciBilgisiField;

            private string barkodField;

            private string seriNoField;

            private string partiNoField;

            private string tCKNField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public KullaniciBilgisi KullaniciBilgisi
            {
                get
                {
                    return kullaniciBilgisiField;
                }
                set
                {
                    kullaniciBilgisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string Barkod
            {
                get
                {
                    return barkodField;
                }
                set
                {
                    barkodField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string SeriNo
            {
                get
                {
                    return seriNoField;
                }
                set
                {
                    seriNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string PartiNo
            {
                get
                {
                    return partiNoField;
                }
                set
                {
                    partiNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string TCKN
            {
                get
                {
                    return tCKNField;
                }
                set
                {
                    tCKNField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Stok.EntegrasyonServisi.Model.Model.Respo" +
            "nse")]
        public partial class UygulamaSorgusuCikti
        {

            private string bilgiField;

            private bool varMiField;

            private bool varMiFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string Bilgi
            {
                get
                {
                    return bilgiField;
                }
                set
                {
                    bilgiField = value;
                }
            }

            /// <remarks/>
            public bool VarMi
            {
                get
                {
                    return varMiField;
                }
                set
                {
                    varMiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool VarMiSpecified
            {
                get
                {
                    return varMiFieldSpecified;
                }
                set
                {
                    varMiFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(AsiUygulamaCikti))]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Stok.EntegrasyonServisi.Model.Model.Respo" +
            "nse")]
        public partial class ResponseBase
        {

            private string bilgiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string Bilgi
            {
                get
                {
                    return bilgiField;
                }
                set
                {
                    bilgiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Stok.EntegrasyonServisi.Model.Model.Respo" +
            "nse")]
        public partial class AsiUygulamaCikti : ResponseBase
        {

            private string sorguNumarasiField;

            private EUygulamaDurum uygulamaDurumField;

            private bool uygulamaDurumFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string SorguNumarasi
            {
                get
                {
                    return sorguNumarasiField;
                }
                set
                {
                    sorguNumarasiField = value;
                }
            }

            /// <remarks/>
            public EUygulamaDurum UygulamaDurum
            {
                get
                {
                    return uygulamaDurumField;
                }
                set
                {
                    uygulamaDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool UygulamaDurumSpecified
            {
                get
                {
                    return uygulamaDurumFieldSpecified;
                }
                set
                {
                    uygulamaDurumFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Stok.EntegrasyonServisi.Model.Enum")]
        public enum EUygulamaDurum
        {

            /// <remarks/>
            Basarili,

            /// <remarks/>
            Basarisiz,

            /// <remarks/>
            YetkiYok,

            /// <remarks/>
            StokYok,

            /// <remarks/>
            KullaniciadiParolaHatali,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "ats.saglik.gov.tr/UygulamaSorguBilgisi")]
        public partial class AsiUygulamaBilgisi
        {

            private string onlineProtokolNoField;

            private string sorguNumarasiField;

            private System.DateTime uygulamaZamaniField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string OnlineProtokolNo
            {
                get
                {
                    return onlineProtokolNoField;
                }
                set
                {
                    onlineProtokolNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string SorguNumarasi
            {
                get
                {
                    return sorguNumarasiField;
                }
                set
                {
                    sorguNumarasiField = value;
                }
            }

            /// <remarks/>
            public System.DateTime UygulamaZamani
            {
                get
                {
                    return uygulamaZamaniField;
                }
                set
                {
                    uygulamaZamaniField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Stok.EntegrasyonServisi.Model.Model.Reque" +
            "st")]
        public partial class AsiUygulamaParametre
        {

            private KullaniciBilgisi kullaniciBilgisiField;

            private AsiUygulamaBilgisi uygulamaSorguBilgisiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public KullaniciBilgisi KullaniciBilgisi
            {
                get
                {
                    return kullaniciBilgisiField;
                }
                set
                {
                    kullaniciBilgisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public AsiUygulamaBilgisi UygulamaSorguBilgisi
            {
                get
                {
                    return uygulamaSorguBilgisiField;
                }
                set
                {
                    uygulamaSorguBilgisiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Stok.EntegrasyonServisi.Model.Model.Respo" +
            "nse")]
        public partial class AsiKullanilabilirlikSorgusuCikti
        {

            private string bilgiField;

            private EKullanilabilirlikDurumu sorguKullanilabilirlikDurumuField;

            private bool sorguKullanilabilirlikDurumuFieldSpecified;

            private string sorguNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string Bilgi
            {
                get
                {
                    return bilgiField;
                }
                set
                {
                    bilgiField = value;
                }
            }

            /// <remarks/>
            public EKullanilabilirlikDurumu SorguKullanilabilirlikDurumu
            {
                get
                {
                    return sorguKullanilabilirlikDurumuField;
                }
                set
                {
                    sorguKullanilabilirlikDurumuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool SorguKullanilabilirlikDurumuSpecified
            {
                get
                {
                    return sorguKullanilabilirlikDurumuFieldSpecified;
                }
                set
                {
                    sorguKullanilabilirlikDurumuFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string SorguNumarasi
            {
                get
                {
                    return sorguNumarasiField;
                }
                set
                {
                    sorguNumarasiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Stok.Common.Enums")]
        public enum EKullanilabilirlikDurumu
        {

            /// <remarks/>
            Kullanilabilir,

            /// <remarks/>
            Kullanilamaz,

            /// <remarks/>
            YetkiYok,

            /// <remarks/>
            StokYok,

            /// <remarks/>
            KullaniciadiParolaHatali,

            /// <remarks/>
            TasimaBirimiUrunDegil,

            /// <remarks/>
            SogukZincirMaruziyet,

            /// <remarks/>
            TasimaDurumunda,

            /// <remarks/>
            GeziciHizmetTuketimyok,

            /// <remarks/>
            GeziciHizmette,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "ats.saglik.gov.tr/SorguBilgisi")]
        public partial class AsiSorguBilgisi
        {

            private string asiKoduField;

            private System.Nullable<EAsininSaglandigiKaynakTipi> asininSaglandigiKaynakField;

            private bool asininSaglandigiKaynakFieldSpecified;

            private System.DateTime dogumTarihiField;

            private int dozBilgisiField;

            private System.Nullable<bool> geziciHizmetMiField;

            private string hekimKimlikNoField;

            private string kirilimBilgisiField;

            private string onlineProtokolNoField;

            private System.Nullable<System.DateTime> sonKullanmaTarihiField;

            private string stokBarkodField;

            private string stokPartiNoField;

            private string stokSeriNoField;

            private string uygulanacakKisiIdField;

            private EKisiTipi uygulanacakKisiTipiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string AsiKodu
            {
                get
                {
                    return asiKoduField;
                }
                set
                {
                    asiKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<EAsininSaglandigiKaynakTipi> AsininSaglandigiKaynak
            {
                get
                {
                    return asininSaglandigiKaynakField;
                }
                set
                {
                    asininSaglandigiKaynakField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool AsininSaglandigiKaynakSpecified
            {
                get
                {
                    return asininSaglandigiKaynakFieldSpecified;
                }
                set
                {
                    asininSaglandigiKaynakFieldSpecified = value;
                }
            }

            /// <remarks/>
            public System.DateTime DogumTarihi
            {
                get
                {
                    return dogumTarihiField;
                }
                set
                {
                    dogumTarihiField = value;
                }
            }

            /// <remarks/>
            public int DozBilgisi
            {
                get
                {
                    return dozBilgisiField;
                }
                set
                {
                    dozBilgisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<bool> GeziciHizmetMi
            {
                get
                {
                    return geziciHizmetMiField;
                }
                set
                {
                    geziciHizmetMiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string HekimKimlikNo
            {
                get
                {
                    return hekimKimlikNoField;
                }
                set
                {
                    hekimKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string KirilimBilgisi
            {
                get
                {
                    return kirilimBilgisiField;
                }
                set
                {
                    kirilimBilgisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string OnlineProtokolNo
            {
                get
                {
                    return onlineProtokolNoField;
                }
                set
                {
                    onlineProtokolNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> SonKullanmaTarihi
            {
                get
                {
                    return sonKullanmaTarihiField;
                }
                set
                {
                    sonKullanmaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokBarkod
            {
                get
                {
                    return stokBarkodField;
                }
                set
                {
                    stokBarkodField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokPartiNo
            {
                get
                {
                    return stokPartiNoField;
                }
                set
                {
                    stokPartiNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokSeriNo
            {
                get
                {
                    return stokSeriNoField;
                }
                set
                {
                    stokSeriNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string UygulanacakKisiId
            {
                get
                {
                    return uygulanacakKisiIdField;
                }
                set
                {
                    uygulanacakKisiIdField = value;
                }
            }

            /// <remarks/>
            public EKisiTipi UygulanacakKisiTipi
            {
                get
                {
                    return uygulanacakKisiTipiField;
                }
                set
                {
                    uygulanacakKisiTipiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Stok.Common.Enums")]
        public enum EAsininSaglandigiKaynakTipi
        {

            /// <remarks/>
            ReceteIleVerilen,

            /// <remarks/>
            UcretsizVerilenler,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Stok.Common.Enums")]
        public enum EKisiTipi
        {

            /// <remarks/>
            Vatandas,

            /// <remarks/>
            Yabanci,

            /// <remarks/>
            Vatansiz,

            /// <remarks/>
            YeniDogan,
        }


        #endregion Methods

    }
}