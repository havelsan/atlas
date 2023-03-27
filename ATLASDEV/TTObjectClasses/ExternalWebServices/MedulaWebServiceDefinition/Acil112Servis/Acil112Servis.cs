
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
    public  partial class Acil112Servis : TTObject
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class VakaBilgileri {
        
        private int protokolNoField;
        
        private string hastaAdiSoyadiField;
        
        private string vakaSenesiField;
        
        private string kimlikNoField;
        
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
        public string hastaAdiSoyadi {
            get {
                return hastaAdiSoyadiField;
            }
            set {
                hastaAdiSoyadiField = value;
            }
        }
        
        /// <remarks/>
        public string vakaSenesi {
            get {
                return vakaSenesiField;
            }
            set {
                vakaSenesiField = value;
            }
        }
        
        /// <remarks/>
        public string kimlikNo {
            get {
                return kimlikNoField;
            }
            set {
                kimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class BolumBilgileri {
        
        private string bolumAdiField;
        
        private int toplamYatakField;
        
        private int bosYatakField;
        
        private int toplamVentilField;
        
        private int bosVentilField;
        
        private int toplamKuvezField;
        
        private int bosKuvezField;
        
        /// <remarks/>
        public string BolumAdi {
            get {
                return bolumAdiField;
            }
            set {
                bolumAdiField = value;
            }
        }
        
        /// <remarks/>
        public int ToplamYatak {
            get {
                return toplamYatakField;
            }
            set {
                toplamYatakField = value;
            }
        }
        
        /// <remarks/>
        public int BosYatak {
            get {
                return bosYatakField;
            }
            set {
                bosYatakField = value;
            }
        }
        
        /// <remarks/>
        public int ToplamVentil {
            get {
                return toplamVentilField;
            }
            set {
                toplamVentilField = value;
            }
        }
        
        /// <remarks/>
        public int BosVentil {
            get {
                return bosVentilField;
            }
            set {
                bosVentilField = value;
            }
        }
        
        /// <remarks/>
        public int ToplamKuvez {
            get {
                return toplamKuvezField;
            }
            set {
                toplamKuvezField = value;
            }
        }
        
        /// <remarks/>
        public int BosKuvez {
            get {
                return bosKuvezField;
            }
            set {
                bosKuvezField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HastaBilgileri {
        
        private string adiSoyadiField;
        
        private string tCKimlikNoField;
        
        private int yasField;
        
        private string cinsiyetField;
        
        private string hastaGirisZamaniField;
        
        private bool yatarakTedaviField;
        
        private string ilField;
        
        private string ilceField;
        
        private string mahalleField;
        
        /// <remarks/>
        public string AdiSoyadi {
            get {
                return adiSoyadiField;
            }
            set {
                adiSoyadiField = value;
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
        public int Yas {
            get {
                return yasField;
            }
            set {
                yasField = value;
            }
        }
        
        /// <remarks/>
        public string Cinsiyet {
            get {
                return cinsiyetField;
            }
            set {
                cinsiyetField = value;
            }
        }
        
        /// <remarks/>
        public string HastaGirisZamani {
            get {
                return hastaGirisZamaniField;
            }
            set {
                hastaGirisZamaniField = value;
            }
        }
        
        /// <remarks/>
        public bool YatarakTedavi {
            get {
                return yatarakTedaviField;
            }
            set {
                yatarakTedaviField = value;
            }
        }
        
        /// <remarks/>
        public string Il {
            get {
                return ilField;
            }
            set {
                ilField = value;
            }
        }
        
        /// <remarks/>
        public string Ilce {
            get {
                return ilceField;
            }
            set {
                ilceField = value;
            }
        }
        
        /// <remarks/>
        public string Mahalle {
            get {
                return mahalleField;
            }
            set {
                mahalleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class BolumBilgisi {
        
        private BolumKodlari bolumKodField;
        
        private int toplamYatakField;
        
        private int bosYatakField;
        
        private int toplamVentilField;
        
        private int bosVentilField;
        
        private int toplamKuvezField;
        
        private int bosKuvezField;
        
        /// <remarks/>
        public BolumKodlari BolumKod {
            get {
                return bolumKodField;
            }
            set {
                bolumKodField = value;
            }
        }
        
        /// <remarks/>
        public int ToplamYatak {
            get {
                return toplamYatakField;
            }
            set {
                toplamYatakField = value;
            }
        }
        
        /// <remarks/>
        public int BosYatak {
            get {
                return bosYatakField;
            }
            set {
                bosYatakField = value;
            }
        }
        
        /// <remarks/>
        public int ToplamVentil {
            get {
                return toplamVentilField;
            }
            set {
                toplamVentilField = value;
            }
        }
        
        /// <remarks/>
        public int BosVentil {
            get {
                return bosVentilField;
            }
            set {
                bosVentilField = value;
            }
        }
        
        /// <remarks/>
        public int ToplamKuvez {
            get {
                return toplamKuvezField;
            }
            set {
                toplamKuvezField = value;
            }
        }
        
        /// <remarks/>
        public int BosKuvez {
            get {
                return bosKuvezField;
            }
            set {
                bosKuvezField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum BolumKodlari {
        
        /// <remarks/>
        AcilEriskin,
        
        /// <remarks/>
        AcilCocuk,
        
        /// <remarks/>
        YogunBakimKoroner,
        
        /// <remarks/>
        YogunBakimKalpDamar,
        
        /// <remarks/>
        YogunBakimAnestezi_Reanimasyon,
        
        /// <remarks/>
        YogunBakimNoroloji,
        
        /// <remarks/>
        YogunBakimBeyinCerrahisi,
        
        /// <remarks/>
        YogunBakimGenelCerrahi,
        
        /// <remarks/>
        YogunBakimDahiliye,
        
        /// <remarks/>
        YogunBakimGogusHastaliklari,
        
        /// <remarks/>
        YogunBakimKadinDogum,
        
        /// <remarks/>
        YogunBakimPediatri,
        
        /// <remarks/>
        YogunBakimYenidogan,
        
        /// <remarks/>
        YogunBakimYanik,
        
        /// <remarks/>
        ServisPediatri,
        
        /// <remarks/>
        ServisDahiliye,
        
        /// <remarks/>
        ServisKalpDamar,
        
        /// <remarks/>
        ServisKadinDogum,
        
        /// <remarks/>
        ServisGenelCerrahi,
        
        /// <remarks/>
        ServisOrtopedi,
        
        /// <remarks/>
        ServisKalpDamarCerrahisi,
        
        /// <remarks/>
        ServisBeyinCerrahisi,
        
        /// <remarks/>
        ServisYenidogan,
        
        /// <remarks/>
        ServisDializ,
        
        /// <remarks/>
        ServisDiger,
        
        /// <remarks/>
        Ameliyathane,
        
        /// <remarks/>
        Morg,
        
        /// <remarks/>
        YogunBakimCocukCerrahi,
        
        /// <remarks/>
        ServisCocukCerrahi,
        
        /// <remarks/>
        ServisCocukKardiyolojisi,
        
        /// <remarks/>
        ServisCocukHematolojiOnkoloji,
        
        /// <remarks/>
        ServisCocukKKB,
        
        /// <remarks/>
        ServisCocukGastroloji,
        
        /// <remarks/>
        ServisCocukPsikoloji,
        
        /// <remarks/>
        ServisCocukNoroloji,
        
        /// <remarks/>
        ServisCocukHastaliklari,
        
        /// <remarks/>
        ServisKardiyoloji,
        
        /// <remarks/>
        YogunBakimDiger,
        
        /// <remarks/>
        ServisEnfeksiyon,
        
        /// <remarks/>
        YogunBakimEnfeksiyon,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class NobetciPersonelBilgileri {
        
        private string gorevField;
        
        private string bransField;
        
        private string bolumField;
        
        private string personelSicilNoField;
        
        private string nobetTarihiBaslangicField;
        
        private string nobetTarihiBitisField;
        
        private string personelAdiField;
        
        private string personelSoyadiField;
        
        private string telefonField;
        
        private bool icapField;
        
        /// <remarks/>
        public string gorev {
            get {
                return gorevField;
            }
            set {
                gorevField = value;
            }
        }
        
        /// <remarks/>
        public string brans {
            get {
                return bransField;
            }
            set {
                bransField = value;
            }
        }
        
        /// <remarks/>
        public string bolum {
            get {
                return bolumField;
            }
            set {
                bolumField = value;
            }
        }
        
        /// <remarks/>
        public string personelSicilNo {
            get {
                return personelSicilNoField;
            }
            set {
                personelSicilNoField = value;
            }
        }
        
        /// <remarks/>
        public string nobetTarihiBaslangic {
            get {
                return nobetTarihiBaslangicField;
            }
            set {
                nobetTarihiBaslangicField = value;
            }
        }
        
        /// <remarks/>
        public string nobetTarihiBitis {
            get {
                return nobetTarihiBitisField;
            }
            set {
                nobetTarihiBitisField = value;
            }
        }
        
        /// <remarks/>
        public string personelAdi {
            get {
                return personelAdiField;
            }
            set {
                personelAdiField = value;
            }
        }
        
        /// <remarks/>
        public string personelSoyadi {
            get {
                return personelSoyadiField;
            }
            set {
                personelSoyadiField = value;
            }
        }
        
        /// <remarks/>
        public string telefon {
            get {
                return telefonField;
            }
            set {
                telefonField = value;
            }
        }
        
        /// <remarks/>
        public bool icap {
            get {
                return icapField;
            }
            set {
                icapField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class PersonelBilgileri {
        
        private string gorevField;
        
        private string bransField;
        
        private string bolumField;
        
        private string personelSicilNoField;
        
        private string nobetTarihiBaslangicField;
        
        private string nobetTarihiBitisField;
        
        private string personelAdiField;
        
        private string personelSoyadiField;
        
        private string telefonField;
        
        /// <remarks/>
        public string gorev {
            get {
                return gorevField;
            }
            set {
                gorevField = value;
            }
        }
        
        /// <remarks/>
        public string brans {
            get {
                return bransField;
            }
            set {
                bransField = value;
            }
        }
        
        /// <remarks/>
        public string bolum {
            get {
                return bolumField;
            }
            set {
                bolumField = value;
            }
        }
        
        /// <remarks/>
        public string personelSicilNo {
            get {
                return personelSicilNoField;
            }
            set {
                personelSicilNoField = value;
            }
        }
        
        /// <remarks/>
        public string nobetTarihiBaslangic {
            get {
                return nobetTarihiBaslangicField;
            }
            set {
                nobetTarihiBaslangicField = value;
            }
        }
        
        /// <remarks/>
        public string nobetTarihiBitis {
            get {
                return nobetTarihiBitisField;
            }
            set {
                nobetTarihiBitisField = value;
            }
        }
        
        /// <remarks/>
        public string personelAdi {
            get {
                return personelAdiField;
            }
            set {
                personelAdiField = value;
            }
        }
        
        /// <remarks/>
        public string personelSoyadi {
            get {
                return personelSoyadiField;
            }
            set {
                personelSoyadiField = value;
            }
        }
        
        /// <remarks/>
        public string telefon {
            get {
                return telefonField;
            }
            set {
                telefonField = value;
            }
        }
    }
        
#endregion Methods

    }
}