
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
    public  abstract  partial class TaahhutIslemleri : TTObject
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
    public partial class taahhutKayitDVO {
        
        private string takipNoField;
        
        private taahhutDVO taahhutField;
        
        private taahhutDisDVO[] taahhutDissField;
        
        private int saglikTesisKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string takipNo {
            get {
                return takipNoField;
            }
            set {
                takipNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public taahhutDVO taahhut {
            get {
                return taahhutField;
            }
            set {
                taahhutField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("taahhutDiss", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public taahhutDisDVO[] taahhutDiss {
            get {
                return taahhutDissField;
            }
            set {
                taahhutDissField = value;
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
    public partial class taahhutDVO {
        
        private string hastaTCKimlikNoField;
        
        private int adressIlPlakaField;
        
        private string adressIlceField;
        
        private string adressPostaKoduField;
        
        private string adressCaddeSokakField;
        
        private string adressDisKapiNoField;
        
        private string adressIcKapiNoField;
        
        private string adressTelefonField;
        
        private string adressEpostaField;
        
        private string taahhutAlanAdField;
        
        private string taahhutAlanSoyadField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string hastaTCKimlikNo {
            get {
                return hastaTCKimlikNoField;
            }
            set {
                hastaTCKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int adressIlPlaka {
            get {
                return adressIlPlakaField;
            }
            set {
                adressIlPlakaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string adressIlce {
            get {
                return adressIlceField;
            }
            set {
                adressIlceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string adressPostaKodu {
            get {
                return adressPostaKoduField;
            }
            set {
                adressPostaKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string adressCaddeSokak {
            get {
                return adressCaddeSokakField;
            }
            set {
                adressCaddeSokakField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string adressDisKapiNo {
            get {
                return adressDisKapiNoField;
            }
            set {
                adressDisKapiNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string adressIcKapiNo {
            get {
                return adressIcKapiNoField;
            }
            set {
                adressIcKapiNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string adressTelefon {
            get {
                return adressTelefonField;
            }
            set {
                adressTelefonField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string adressEposta {
            get {
                return adressEpostaField;
            }
            set {
                adressEpostaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string taahhutAlanAd {
            get {
                return taahhutAlanAdField;
            }
            set {
                taahhutAlanAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string taahhutAlanSoyad {
            get {
                return taahhutAlanSoyadField;
            }
            set {
                taahhutAlanSoyadField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class taahhutKisiCevapDVO {
        
        private System.Nullable<int>[] taahhutNoField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("taahhutNo", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int>[] taahhutNo {
            get {
                return taahhutNoField;
            }
            set {
                taahhutNoField = value;
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
    public partial class taahhutKisiOkuDVO {
        
        private int saglikTesisKoduField;
        
        private long tcKimlikNoField;
        
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
        public long tcKimlikNo {
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
    public partial class taahhutOkuDVO {
        
        private int taahhutNoField;
        
        private int saglikTesisKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int taahhutNo {
            get {
                return taahhutNoField;
            }
            set {
                taahhutNoField = value;
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
    public partial class taahhutCevapDVO {
        
        private int taahhutNoField;
        
        private byte[] taahhutCiktiField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int taahhutNo {
            get {
                return taahhutNoField;
            }
            set {
                taahhutNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] taahhutCikti {
            get {
                return taahhutCiktiField;
            }
            set {
                taahhutCiktiField = value;
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
    public partial class taahhutDisDVO {
        
        private string sutKoduField;
        
        private int disNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sutKodu {
            get {
                return sutKoduField;
            }
            set {
                sutKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int disNo {
            get {
                return disNoField;
            }
            set {
                disNoField = value;
            }
        }
    }
        
#endregion Methods

    }
}