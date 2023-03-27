
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
    public  partial class OrtodontiIslemleri : TTObject
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
    public partial class ortodontiFormuKaydetGirisDVO {
        
        private int saglikTesisKoduField;
        
        private string provizyonNoField;
        
        private string sutKoduField;
        
        private string formNoField;
        
        private string islemTarihiField;
        
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
        public string provizyonNo {
            get {
                return provizyonNoField;
            }
            set {
                provizyonNoField = value;
            }
        }
        
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
        public string formNo {
            get {
                return formNoField;
            }
            set {
                formNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string islemTarihi {
            get {
                return islemTarihiField;
            }
            set {
                islemTarihiField = value;
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
    public partial class ortodontiFormuOkuCevapDVO {
        
        private long formNoField;
        
        private string islemTuruField;
        
        private int tesis_kodu_1Field;
        
        private int tesis_kodu_2Field;
        
        private int tesis_kodu_3Field;
        
        private string islem_tarihi_1Field;
        
        private string islem_tarihi_2Field;
        
        private string islem_tarihi_3Field;
        
        private string provizyonNo1Field;
        
        private string provizyonNo2Field;
        
        private string provizyonNo3Field;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long formNo {
            get {
                return formNoField;
            }
            set {
                formNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string islemTuru {
            get {
                return islemTuruField;
            }
            set {
                islemTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesis_kodu_1 {
            get {
                return tesis_kodu_1Field;
            }
            set {
                tesis_kodu_1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesis_kodu_2 {
            get {
                return tesis_kodu_2Field;
            }
            set {
                tesis_kodu_2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesis_kodu_3 {
            get {
                return tesis_kodu_3Field;
            }
            set {
                tesis_kodu_3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string islem_tarihi_1 {
            get {
                return islem_tarihi_1Field;
            }
            set {
                islem_tarihi_1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string islem_tarihi_2 {
            get {
                return islem_tarihi_2Field;
            }
            set {
                islem_tarihi_2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string islem_tarihi_3 {
            get {
                return islem_tarihi_3Field;
            }
            set {
                islem_tarihi_3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string provizyonNo1 {
            get {
                return provizyonNo1Field;
            }
            set {
                provizyonNo1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string provizyonNo2 {
            get {
                return provizyonNo2Field;
            }
            set {
                provizyonNo2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string provizyonNo3 {
            get {
                return provizyonNo3Field;
            }
            set {
                provizyonNo3Field = value;
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
    public partial class ortodontiFormuOkuGirisDVO {
        
        private int saglikTesisKoduField;
        
        private string formNoField;
        
        private string tcKimlikNoField;
        
        private string sutKoduField;
        
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
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string formNo {
            get {
                return formNoField;
            }
            set {
                formNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string tcKimlikNo {
            get {
                return tcKimlikNoField;
            }
            set {
                tcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string sutKodu {
            get {
                return sutKoduField;
            }
            set {
                sutKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.7905")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ortodontiFormuIptalCevapDVO {
        
        private long formNoField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long formNo {
            get {
                return formNoField;
            }
            set {
                formNoField = value;
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
    public partial class ortodontiFormuIptalGirisDVO {
        
        private int saglikTesisKoduField;
        
        private string sutKoduField;
        
        private string formNoField;
        
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
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string sutKodu {
            get {
                return sutKoduField;
            }
            set {
                sutKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string formNo {
            get {
                return formNoField;
            }
            set {
                formNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
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
    public partial class ortodontiFormuKaydetCevapDVO {
        
        private long formNoField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long formNo {
            get {
                return formNoField;
            }
            set {
                formNoField = value;
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