
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
    public  abstract  partial class TakipFormuIslemleri : TTObject
    {
        
                    
        public static partial class WebMethods
        {
                    
        }
                    
#region Methods
        /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class takipFormuKaydetGirisDVO {
        
        private diabetTakipFormuKayitDVO diabetTakipFormuField;
        
        private int saglikTesisKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public diabetTakipFormuKayitDVO diabetTakipFormu {
            get {
                return diabetTakipFormuField;
            }
            set {
                diabetTakipFormuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int saglikTesisKodu {
            get {
                return saglikTesisKoduField;
            }
            set {
                saglikTesisKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class diabetTakipFormuKayitDVO {
        
        private string tcKimlikNoField;
        
        private string adField;
        
        private string soyadField;
        
        private string cinsiyetField;
        
        private string cepTelField;
        
        private string taniKoduField;
        
        private string taniTarihiField;
        
        private string vizitTarihiField;
        
        private string glukoMetreField;
        
        private string antiGADField;
        
        private string mikroalbuminuriField;
        
        private string periferikSensoryalField;
        
        private string koronerArterHField;
        
        private string serebrovaskulerHField;
        
        private string ayakMuayenesiField;
        
        private string insulinPompasiField;
        
        private string insulinPompasiDegTarihiField;
        
        private string protokolNoField;
        
        private System.Nullable<int> saglikTesisKoduField;
        
        private System.Nullable<int> ikametTuruField;
        
        private takipFormuDoktorBilgisiDVO[] doktorBilgileriField;
        
        private takipFormuDiabetEgitimiDVO diabetEgitimiField;
        
        private System.Nullable<int> tibbiBeslenmeTedavisiField;
        
        private System.Nullable<int> egzersizField;
        
        private takipFormuHastalikDVO[] hastaliklarField;
        
        private System.Nullable<int> basvuruNedeniField;
        
        private takipFormuAliskanlikDVO[] aliskanliklarField;
        
        private System.Nullable<int> kanSekeriTakipSayisiField;
        
        private takipFormuKullanilanIlaclarDVO[] kullanilanIlaclarField;
        
        private System.Nullable<int> sistolikKanBasinciField;
        
        private System.Nullable<int> diyastolikKanBasinciField;
        
        private System.Nullable<double> boyField;
        
        private System.Nullable<double> kiloField;
        
        private System.Nullable<double> vkiField;
        
        private System.Nullable<double> apgField;
        
        private System.Nullable<double> tpgField;
        
        private System.Nullable<double> hbA1cField;
        
        private System.Nullable<double> kreatininField;
        
        private System.Nullable<double> trigliseridField;
        
        private System.Nullable<double> ldlKolField;
        
        private System.Nullable<double> hdlKolField;
        
        private System.Nullable<double> altField;
        
        private System.Nullable<int> ekgField;
        
        private System.Nullable<int> gozMuayenesiField;
        
        private System.Nullable<int> akutKomplikasyonField;
        
        private System.Nullable<int> yatisGunField;
        
        private string insulinPompasiVerTarihiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tcKimlikNo {
            get {
                return tcKimlikNoField;
            }
            set {
                tcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ad {
            get {
                return adField;
            }
            set {
                adField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string soyad {
            get {
                return soyadField;
            }
            set {
                soyadField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cinsiyet {
            get {
                return cinsiyetField;
            }
            set {
                cinsiyetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cepTel {
            get {
                return cepTelField;
            }
            set {
                cepTelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string taniKodu {
            get {
                return taniKoduField;
            }
            set {
                taniKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string taniTarihi {
            get {
                return taniTarihiField;
            }
            set {
                taniTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string vizitTarihi {
            get {
                return vizitTarihiField;
            }
            set {
                vizitTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string glukoMetre {
            get {
                return glukoMetreField;
            }
            set {
                glukoMetreField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string antiGAD {
            get {
                return antiGADField;
            }
            set {
                antiGADField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string mikroalbuminuri {
            get {
                return mikroalbuminuriField;
            }
            set {
                mikroalbuminuriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string periferikSensoryal {
            get {
                return periferikSensoryalField;
            }
            set {
                periferikSensoryalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string koronerArterH {
            get {
                return koronerArterHField;
            }
            set {
                koronerArterHField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string serebrovaskulerH {
            get {
                return serebrovaskulerHField;
            }
            set {
                serebrovaskulerHField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ayakMuayenesi {
            get {
                return ayakMuayenesiField;
            }
            set {
                ayakMuayenesiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string insulinPompasi {
            get {
                return insulinPompasiField;
            }
            set {
                insulinPompasiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string insulinPompasiDegTarihi {
            get {
                return insulinPompasiDegTarihiField;
            }
            set {
                insulinPompasiDegTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string protokolNo {
            get {
                return protokolNoField;
            }
            set {
                protokolNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> saglikTesisKodu {
            get {
                return saglikTesisKoduField;
            }
            set {
                saglikTesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> ikametTuru {
            get {
                return ikametTuruField;
            }
            set {
                ikametTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("doktorBilgileri", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public takipFormuDoktorBilgisiDVO[] doktorBilgileri {
            get {
                return doktorBilgileriField;
            }
            set {
                doktorBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public takipFormuDiabetEgitimiDVO diabetEgitimi {
            get {
                return diabetEgitimiField;
            }
            set {
                diabetEgitimiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> tibbiBeslenmeTedavisi {
            get {
                return tibbiBeslenmeTedavisiField;
            }
            set {
                tibbiBeslenmeTedavisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> egzersiz {
            get {
                return egzersizField;
            }
            set {
                egzersizField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("hastaliklar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public takipFormuHastalikDVO[] hastaliklar {
            get {
                return hastaliklarField;
            }
            set {
                hastaliklarField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> basvuruNedeni {
            get {
                return basvuruNedeniField;
            }
            set {
                basvuruNedeniField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("aliskanliklar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public takipFormuAliskanlikDVO[] aliskanliklar {
            get {
                return aliskanliklarField;
            }
            set {
                aliskanliklarField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> kanSekeriTakipSayisi {
            get {
                return kanSekeriTakipSayisiField;
            }
            set {
                kanSekeriTakipSayisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("kullanilanIlaclar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public takipFormuKullanilanIlaclarDVO[] kullanilanIlaclar {
            get {
                return kullanilanIlaclarField;
            }
            set {
                kullanilanIlaclarField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> sistolikKanBasinci {
            get {
                return sistolikKanBasinciField;
            }
            set {
                sistolikKanBasinciField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> diyastolikKanBasinci {
            get {
                return diyastolikKanBasinciField;
            }
            set {
                diyastolikKanBasinciField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<double> boy {
            get {
                return boyField;
            }
            set {
                boyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<double> kilo {
            get {
                return kiloField;
            }
            set {
                kiloField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<double> vki {
            get {
                return vkiField;
            }
            set {
                vkiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<double> apg {
            get {
                return apgField;
            }
            set {
                apgField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<double> tpg {
            get {
                return tpgField;
            }
            set {
                tpgField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<double> hbA1c {
            get {
                return hbA1cField;
            }
            set {
                hbA1cField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<double> kreatinin {
            get {
                return kreatininField;
            }
            set {
                kreatininField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<double> trigliserid {
            get {
                return trigliseridField;
            }
            set {
                trigliseridField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<double> ldlKol {
            get {
                return ldlKolField;
            }
            set {
                ldlKolField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<double> hdlKol {
            get {
                return hdlKolField;
            }
            set {
                hdlKolField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<double> alt {
            get {
                return altField;
            }
            set {
                altField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> ekg {
            get {
                return ekgField;
            }
            set {
                ekgField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> gozMuayenesi {
            get {
                return gozMuayenesiField;
            }
            set {
                gozMuayenesiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> akutKomplikasyon {
            get {
                return akutKomplikasyonField;
            }
            set {
                akutKomplikasyonField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> yatisGun {
            get {
                return yatisGunField;
            }
            set {
                yatisGunField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string insulinPompasiVerTarihi {
            get {
                return insulinPompasiVerTarihiField;
            }
            set {
                insulinPompasiVerTarihiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class takipFormuDoktorBilgisiDVO {
        
        private string drTescilNoField;
        
        private string drBransKoduField;
        
        private string dmEgitimiAlmisMiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string drTescilNo {
            get {
                return drTescilNoField;
            }
            set {
                drTescilNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string drBransKodu {
            get {
                return drBransKoduField;
            }
            set {
                drBransKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string dmEgitimiAlmisMi {
            get {
                return dmEgitimiAlmisMiField;
            }
            set {
                dmEgitimiAlmisMiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class takipFormuOkuCevapDVO {
        
        private diabetTakipFormuDVO[] diabetTakipFormlariField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("diabetTakipFormlari", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public diabetTakipFormuDVO[] diabetTakipFormlari {
            get {
                return diabetTakipFormlariField;
            }
            set {
                diabetTakipFormlariField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sonucKodu {
            get {
                return sonucKoduField;
            }
            set {
                sonucKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sonucMesaji {
            get {
                return sonucMesajiField;
            }
            set {
                sonucMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class diabetTakipFormuDVO {
        
        private string takipFormuNoField;
        
        private string tcKimlikNoField;
        
        private string adField;
        
        private string soyadField;
        
        private string cinsiyetField;
        
        private string cepTelField;
        
        private string taniKoduField;
        
        private string taniTarihiField;
        
        private string vizitTarihiField;
        
        private string glukoMetreField;
        
        private string antiGADField;
        
        private string mikroalbuminuriField;
        
        private string periferikSensoryalField;
        
        private string koronerArterHField;
        
        private string serebrovaskulerHField;
        
        private string ayakMuayenesiField;
        
        private string insulinPompasiField;
        
        private string insulinPompasiDegTarihiField;
        
        private string protokolNoField;
        
        private int saglikTesisKoduField;
        
        private int ikametTuruField;
        
        private takipFormuDoktorBilgisiDVO[] doktorBilgileriField;
        
        private takipFormuDiabetEgitimiDVO diabetEgitimiField;
        
        private int tibbiBeslenmeTedavisiField;
        
        private int egzersizField;
        
        private takipFormuHastalikDVO[] hastaliklarField;
        
        private int basvuruNedeniField;
        
        private takipFormuAliskanlikDVO[] aliskanliklarField;
        
        private int kanSekeriTakipSayisiField;
        
        private takipFormuKullanilanIlaclarDVO[] kullanilanIlaclarField;
        
        private int sistolikKanBasinciField;
        
        private int diyastolikKanBasinciField;
        
        private double boyField;
        
        private double kiloField;
        
        private double vkiField;
        
        private double apgField;
        
        private double tpgField;
        
        private double hbA1cField;
        
        private double kreatininField;
        
        private double trigliseridField;
        
        private double ldlKolField;
        
        private double hdlKolField;
        
        private double altField;
        
        private int ekgField;
        
        private int gozMuayenesiField;
        
        private int akutKomplikasyonField;
        
        private int yatisGunField;
        
        private string insulinPompasiVerTarihiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string takipFormuNo {
            get {
                return takipFormuNoField;
            }
            set {
                takipFormuNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tcKimlikNo {
            get {
                return tcKimlikNoField;
            }
            set {
                tcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ad {
            get {
                return adField;
            }
            set {
                adField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string soyad {
            get {
                return soyadField;
            }
            set {
                soyadField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cinsiyet {
            get {
                return cinsiyetField;
            }
            set {
                cinsiyetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cepTel {
            get {
                return cepTelField;
            }
            set {
                cepTelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string taniKodu {
            get {
                return taniKoduField;
            }
            set {
                taniKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string taniTarihi {
            get {
                return taniTarihiField;
            }
            set {
                taniTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string vizitTarihi {
            get {
                return vizitTarihiField;
            }
            set {
                vizitTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string glukoMetre {
            get {
                return glukoMetreField;
            }
            set {
                glukoMetreField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string antiGAD {
            get {
                return antiGADField;
            }
            set {
                antiGADField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string mikroalbuminuri {
            get {
                return mikroalbuminuriField;
            }
            set {
                mikroalbuminuriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string periferikSensoryal {
            get {
                return periferikSensoryalField;
            }
            set {
                periferikSensoryalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string koronerArterH {
            get {
                return koronerArterHField;
            }
            set {
                koronerArterHField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string serebrovaskulerH {
            get {
                return serebrovaskulerHField;
            }
            set {
                serebrovaskulerHField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ayakMuayenesi {
            get {
                return ayakMuayenesiField;
            }
            set {
                ayakMuayenesiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string insulinPompasi {
            get {
                return insulinPompasiField;
            }
            set {
                insulinPompasiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string insulinPompasiDegTarihi {
            get {
                return insulinPompasiDegTarihiField;
            }
            set {
                insulinPompasiDegTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string protokolNo {
            get {
                return protokolNoField;
            }
            set {
                protokolNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int saglikTesisKodu {
            get {
                return saglikTesisKoduField;
            }
            set {
                saglikTesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int ikametTuru {
            get {
                return ikametTuruField;
            }
            set {
                ikametTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("doktorBilgileri", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public takipFormuDoktorBilgisiDVO[] doktorBilgileri {
            get {
                return doktorBilgileriField;
            }
            set {
                doktorBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public takipFormuDiabetEgitimiDVO diabetEgitimi {
            get {
                return diabetEgitimiField;
            }
            set {
                diabetEgitimiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tibbiBeslenmeTedavisi {
            get {
                return tibbiBeslenmeTedavisiField;
            }
            set {
                tibbiBeslenmeTedavisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int egzersiz {
            get {
                return egzersizField;
            }
            set {
                egzersizField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("hastaliklar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public takipFormuHastalikDVO[] hastaliklar {
            get {
                return hastaliklarField;
            }
            set {
                hastaliklarField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int basvuruNedeni {
            get {
                return basvuruNedeniField;
            }
            set {
                basvuruNedeniField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("aliskanliklar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public takipFormuAliskanlikDVO[] aliskanliklar {
            get {
                return aliskanliklarField;
            }
            set {
                aliskanliklarField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int kanSekeriTakipSayisi {
            get {
                return kanSekeriTakipSayisiField;
            }
            set {
                kanSekeriTakipSayisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("kullanilanIlaclar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public takipFormuKullanilanIlaclarDVO[] kullanilanIlaclar {
            get {
                return kullanilanIlaclarField;
            }
            set {
                kullanilanIlaclarField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int sistolikKanBasinci {
            get {
                return sistolikKanBasinciField;
            }
            set {
                sistolikKanBasinciField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int diyastolikKanBasinci {
            get {
                return diyastolikKanBasinciField;
            }
            set {
                diyastolikKanBasinciField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double boy {
            get {
                return boyField;
            }
            set {
                boyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double kilo {
            get {
                return kiloField;
            }
            set {
                kiloField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double vki {
            get {
                return vkiField;
            }
            set {
                vkiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double apg {
            get {
                return apgField;
            }
            set {
                apgField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double tpg {
            get {
                return tpgField;
            }
            set {
                tpgField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double hbA1c {
            get {
                return hbA1cField;
            }
            set {
                hbA1cField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double kreatinin {
            get {
                return kreatininField;
            }
            set {
                kreatininField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double trigliserid {
            get {
                return trigliseridField;
            }
            set {
                trigliseridField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double ldlKol {
            get {
                return ldlKolField;
            }
            set {
                ldlKolField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double hdlKol {
            get {
                return hdlKolField;
            }
            set {
                hdlKolField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double alt {
            get {
                return altField;
            }
            set {
                altField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int ekg {
            get {
                return ekgField;
            }
            set {
                ekgField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int gozMuayenesi {
            get {
                return gozMuayenesiField;
            }
            set {
                gozMuayenesiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int akutKomplikasyon {
            get {
                return akutKomplikasyonField;
            }
            set {
                akutKomplikasyonField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int yatisGun {
            get {
                return yatisGunField;
            }
            set {
                yatisGunField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string insulinPompasiVerTarihi {
            get {
                return insulinPompasiVerTarihiField;
            }
            set {
                insulinPompasiVerTarihiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class takipFormuDiabetEgitimiDVO {
        
        private System.Nullable<int> bireyselEgitimSayisiField;
        
        private System.Nullable<int> grupEgitimiSayisiField;
        
        private string dmEgitimiAlmisMiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> bireyselEgitimSayisi {
            get {
                return bireyselEgitimSayisiField;
            }
            set {
                bireyselEgitimSayisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> grupEgitimiSayisi {
            get {
                return grupEgitimiSayisiField;
            }
            set {
                grupEgitimiSayisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string dmEgitimiAlmisMi {
            get {
                return dmEgitimiAlmisMiField;
            }
            set {
                dmEgitimiAlmisMiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class takipFormuHastalikDVO {
        
        private string digerHastalikTaniKoduField;
        
        private System.Nullable<int> hastalikKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string digerHastalikTaniKodu {
            get {
                return digerHastalikTaniKoduField;
            }
            set {
                digerHastalikTaniKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> hastalikKodu {
            get {
                return hastalikKoduField;
            }
            set {
                hastalikKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class takipFormuAliskanlikDVO {
        
        private System.Nullable<int> aliskanlikField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> aliskanlik {
            get {
                return aliskanlikField;
            }
            set {
                aliskanlikField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class takipFormuKullanilanIlaclarDVO {
        
        private string barkodField;
        
        private string gunlukDozField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string barkod {
            get {
                return barkodField;
            }
            set {
                barkodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string gunlukDoz {
            get {
                return gunlukDozField;
            }
            set {
                gunlukDozField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class takipFormuOkuGirisDVO {
        
        private int saglikTesisKoduField;
        
        private string tcKimlikNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int saglikTesisKodu {
            get {
                return saglikTesisKoduField;
            }
            set {
                saglikTesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tcKimlikNo {
            get {
                return tcKimlikNoField;
            }
            set {
                tcKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class takipFormuSilCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sonucKodu {
            get {
                return sonucKoduField;
            }
            set {
                sonucKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sonucMesaji {
            get {
                return sonucMesajiField;
            }
            set {
                sonucMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class takipFormuSilGirisDVO {
        
        private string takipFormuNoField;
        
        private int saglikTesisKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string takipFormuNo {
            get {
                return takipFormuNoField;
            }
            set {
                takipFormuNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int saglikTesisKodu {
            get {
                return saglikTesisKoduField;
            }
            set {
                saglikTesisKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class takipFormuKaydetCevapDVO {
        
        private diabetTakipFormuDVO diabetTakipFormuField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public diabetTakipFormuDVO diabetTakipFormu {
            get {
                return diabetTakipFormuField;
            }
            set {
                diabetTakipFormuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sonucKodu {
            get {
                return sonucKoduField;
            }
            set {
                sonucKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sonucMesaji {
            get {
                return sonucMesajiField;
            }
            set {
                sonucMesajiField = value;
            }
        }
    }
        
#endregion Methods

    }
}