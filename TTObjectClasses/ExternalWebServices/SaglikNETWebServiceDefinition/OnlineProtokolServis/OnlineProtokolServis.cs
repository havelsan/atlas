
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
    public  partial class OnlineProtokolServis : TTObject
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class kullanici {
        
        private string kullaniciAdiField;
        
        private string kullaniciSifreField;
        
        private string erisimKoduField;
        
        /// <remarks/>
        public string kullaniciAdi {
            get {
                return kullaniciAdiField;
            }
            set {
                kullaniciAdiField = value;
            }
        }
        
        /// <remarks/>
        public string kullaniciSifre {
            get {
                return kullaniciSifreField;
            }
            set {
                kullaniciSifreField = value;
            }
        }
        
        /// <remarks/>
        public string erisimKodu {
            get {
                return erisimKoduField;
            }
            set {
                erisimKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class protokolNoListObjesi {
        
        private string protokolNumarasiField;
        
        private string protokolTipiField;
        
        private int uSVSPaketIDField;
        
        private string islemTarihiField;
        
        private string mHRSField;
        
        private string kayitTarihiField;
        
        private string otomasyonKayitIDField;
        
        private string hekimTCKField;
        
        private string vatandasTCKField;
        
        private int hastaTipiField;
        
        /// <remarks/>
        public string protokolNumarasi {
            get {
                return protokolNumarasiField;
            }
            set {
                protokolNumarasiField = value;
            }
        }
        
        /// <remarks/>
        public string protokolTipi {
            get {
                return protokolTipiField;
            }
            set {
                protokolTipiField = value;
            }
        }
        
        /// <remarks/>
        public int USVSPaketID {
            get {
                return uSVSPaketIDField;
            }
            set {
                uSVSPaketIDField = value;
            }
        }
        
        /// <remarks/>
        public string islemTarihi {
            get {
                return islemTarihiField;
            }
            set {
                islemTarihiField = value;
            }
        }
        
        /// <remarks/>
        public string MHRS {
            get {
                return mHRSField;
            }
            set {
                mHRSField = value;
            }
        }
        
        /// <remarks/>
        public string kayitTarihi {
            get {
                return kayitTarihiField;
            }
            set {
                kayitTarihiField = value;
            }
        }
        
        /// <remarks/>
        public string otomasyonKayitID {
            get {
                return otomasyonKayitIDField;
            }
            set {
                otomasyonKayitIDField = value;
            }
        }
        
        /// <remarks/>
        public string hekimTCK {
            get {
                return hekimTCKField;
            }
            set {
                hekimTCKField = value;
            }
        }
        
        /// <remarks/>
        public string vatandasTCK {
            get {
                return vatandasTCKField;
            }
            set {
                vatandasTCKField = value;
            }
        }
        
        /// <remarks/>
        public int hastaTipi {
            get {
                return hastaTipiField;
            }
            set {
                hastaTipiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class protokolListesiCevap {
        
        private cevap cvpField;
        
        private protokolNoListObjesi[] protokolListesiObjesiField;
        
        /// <remarks/>
        public cevap cvp {
            get {
                return cvpField;
            }
            set {
                cvpField = value;
            }
        }
        
        /// <remarks/>
        public protokolNoListObjesi[] protokolListesiObjesi {
            get {
                return protokolListesiObjesiField;
            }
            set {
                protokolListesiObjesiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class cevap {
        
        private int cevapKoduField;
        
        private string cevapAciklamaField;
        
        private string protokolNoField;
        
        private string[] hatalarField;
        
        /// <remarks/>
        public int cevapKodu {
            get {
                return cevapKoduField;
            }
            set {
                cevapKoduField = value;
            }
        }
        
        /// <remarks/>
        public string cevapAciklama {
            get {
                return cevapAciklamaField;
            }
            set {
                cevapAciklamaField = value;
            }
        }
        
        /// <remarks/>
        public string protokolNo {
            get {
                return protokolNoField;
            }
            set {
                protokolNoField = value;
            }
        }
        
        /// <remarks/>
        public string[] hatalar {
            get {
                return hatalarField;
            }
            set {
                hatalarField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class protokol {
        
        private string vatandasTCKField;
        
        private string islemTarihiField;
        
        private string kurumKoduField;
        
        private string mHRSField;
        
        private int uSVSPaketIdField;
        
        private string bagliProtokolNoField;
        
        private int klinikKoduField;
        
        private int protokolTipiField;
        
        private string otomasyonKayitIdField;
        
        private string hekimTCKField;
        
        private int hastaTipiField;
        
        /// <remarks/>
        public string vatandasTCK {
            get {
                return vatandasTCKField;
            }
            set {
                vatandasTCKField = value;
            }
        }
        
        /// <remarks/>
        public string islemTarihi {
            get {
                return islemTarihiField;
            }
            set {
                islemTarihiField = value;
            }
        }
        
        /// <remarks/>
        public string kurumKodu {
            get {
                return kurumKoduField;
            }
            set {
                kurumKoduField = value;
            }
        }
        
        /// <remarks/>
        public string MHRS {
            get {
                return mHRSField;
            }
            set {
                mHRSField = value;
            }
        }
        
        /// <remarks/>
        public int USVSPaketId {
            get {
                return uSVSPaketIdField;
            }
            set {
                uSVSPaketIdField = value;
            }
        }
        
        /// <remarks/>
        public string bagliProtokolNo {
            get {
                return bagliProtokolNoField;
            }
            set {
                bagliProtokolNoField = value;
            }
        }
        
        /// <remarks/>
        public int klinikKodu {
            get {
                return klinikKoduField;
            }
            set {
                klinikKoduField = value;
            }
        }
        
        /// <remarks/>
        public int protokolTipi {
            get {
                return protokolTipiField;
            }
            set {
                protokolTipiField = value;
            }
        }
        
        /// <remarks/>
        public string otomasyonKayitId {
            get {
                return otomasyonKayitIdField;
            }
            set {
                otomasyonKayitIdField = value;
            }
        }
        
        /// <remarks/>
        public string hekimTCK {
            get {
                return hekimTCKField;
            }
            set {
                hekimTCKField = value;
            }
        }
        
        /// <remarks/>
        public int hastaTipi {
            get {
                return hastaTipiField;
            }
            set {
                hastaTipiField = value;
            }
        }
    }
        
#endregion Methods

    }
}