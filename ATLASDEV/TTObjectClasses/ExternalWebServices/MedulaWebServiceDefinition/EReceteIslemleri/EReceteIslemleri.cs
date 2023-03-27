
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
    public  abstract  partial class EReceteIslemleri : TTObject
    {
        
                    
        public static partial class WebMethods
        {
                    
        }
                    
#region Methods
        /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteSorguIstekDVO {
        
        private int tesisKoduField;
        
        private string ereceteNoField;
        
        private long doktorTcKimlikNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ereceteNo {
            get {
                return ereceteNoField;
            }
            set {
                ereceteNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteIlacAciklamaEkleCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteIlacAciklamaEkleIstekDVO {
        
        private byte[] imzaliEreceteIlacAciklamaField;
        
        private string tesisKoduField;
        
        private string doktorTcKimlikNoField;
        
        private string surumNumarasiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] imzaliEreceteIlacAciklama {
            get {
                return imzaliEreceteIlacAciklamaField;
            }
            set {
                imzaliEreceteIlacAciklamaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string surumNumarasi {
            get {
                return surumNumarasiField;
            }
            set {
                surumNumarasiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteIlacAciklamaEkleCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteIlacAciklamaEkleIstekDVO {
        
        private string ereceteNoField;
        
        private long barkodField;
        
        private int tesisKoduField;
        
        private long doktorTcKimlikNoField;
        
        private ereceteIlacAciklamaDVO ereceteIlacAciklamaDVOField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ereceteNo {
            get {
                return ereceteNoField;
            }
            set {
                ereceteNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long barkod {
            get {
                return barkodField;
            }
            set {
                barkodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ereceteIlacAciklamaDVO ereceteIlacAciklamaDVO {
            get {
                return ereceteIlacAciklamaDVOField;
            }
            set {
                ereceteIlacAciklamaDVOField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteIlacAciklamaDVO {
        
        private string aciklamaField;
        
        private int aciklamaTuruField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int aciklamaTuru {
            get {
                return aciklamaTuruField;
            }
            set {
                aciklamaTuruField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteAciklamaEkleCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteAciklamaEkleIstekDVO {
        
        private byte[] imzaliEreceteAciklamaField;
        
        private string tesisKoduField;
        
        private string doktorTcKimlikNoField;
        
        private string surumNumarasiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] imzaliEreceteAciklama {
            get {
                return imzaliEreceteAciklamaField;
            }
            set {
                imzaliEreceteAciklamaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string surumNumarasi {
            get {
                return surumNumarasiField;
            }
            set {
                surumNumarasiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteAciklamaEkleCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteAciklamaEkleIstekDVO {
        
        private string ereceteNoField;
        
        private int tesisKoduField;
        
        private long doktorTcKimlikNoField;
        
        private ereceteAciklamaDVO ereceteAciklamaDVOField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ereceteNo {
            get {
                return ereceteNoField;
            }
            set {
                ereceteNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ereceteAciklamaDVO ereceteAciklamaDVO {
            get {
                return ereceteAciklamaDVOField;
            }
            set {
                ereceteAciklamaDVOField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteAciklamaDVO {
        
        private string aciklamaField;
        
        private int aciklamaTuruField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string aciklama {
            get {
                return aciklamaField;
            }
            set {
                aciklamaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int aciklamaTuru {
            get {
                return aciklamaTuruField;
            }
            set {
                aciklamaTuruField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteTaniEkleCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteTaniEkleIstekDVO {
        
        private byte[] imzaliEreceteTaniField;
        
        private string tesisKoduField;
        
        private string doktorTcKimlikNoField;
        
        private string surumNumarasiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] imzaliEreceteTani {
            get {
                return imzaliEreceteTaniField;
            }
            set {
                imzaliEreceteTaniField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string surumNumarasi {
            get {
                return surumNumarasiField;
            }
            set {
                surumNumarasiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteTaniEkleCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteTaniEkleIstekDVO {
        
        private string ereceteNoField;
        
        private int tesisKoduField;
        
        private long doktorTcKimlikNoField;
        
        private ereceteTaniDVO ereceteTaniDVOField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ereceteNo {
            get {
                return ereceteNoField;
            }
            set {
                ereceteNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ereceteTaniDVO ereceteTaniDVO {
            get {
                return ereceteTaniDVOField;
            }
            set {
                ereceteTaniDVOField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteTaniDVO {
        
        private string taniAdiField;
        
        private string taniKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string taniAdi {
            get {
                return taniAdiField;
            }
            set {
                taniAdiField = value;
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteOnayIptalCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteOnayIptalIstekDVO {
        
        private byte[] imzaliEreceteOnayIptalField;
        
        private string tesisKoduField;
        
        private string doktorTcKimlikNoField;
        
        private string surumNumarasiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] imzaliEreceteOnayIptal {
            get {
                return imzaliEreceteOnayIptalField;
            }
            set {
                imzaliEreceteOnayIptalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string surumNumarasi {
            get {
                return surumNumarasiField;
            }
            set {
                surumNumarasiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteOnayIptalCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteOnayIptalIstekDVO {
        
        private string ereceteNoField;
        
        private int tesisKoduField;
        
        private long doktorTcKimlikNoField;
        
        private string receteOnayTuruField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ereceteNo {
            get {
                return ereceteNoField;
            }
            set {
                ereceteNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string receteOnayTuru {
            get {
                return receteOnayTuruField;
            }
            set {
                receteOnayTuruField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteOnayCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteOnayIstekDVO {
        
        private byte[] imzaliEreceteOnayField;
        
        private string tesisKoduField;
        
        private string doktorTcKimlikNoField;
        
        private string surumNumarasiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] imzaliEreceteOnay {
            get {
                return imzaliEreceteOnayField;
            }
            set {
                imzaliEreceteOnayField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string surumNumarasi {
            get {
                return surumNumarasiField;
            }
            set {
                surumNumarasiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteOnayCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteOnayIstekDVO {
        
        private string ereceteNoField;
        
        private int tesisKoduField;
        
        private long doktorTcKimlikNoField;
        
        private string receteOnayTuruField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ereceteNo {
            get {
                return ereceteNoField;
            }
            set {
                ereceteNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string receteOnayTuru {
            get {
                return receteOnayTuruField;
            }
            set {
                receteOnayTuruField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteYatanHastaOnayiIptalCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteYatanHastaOnayiIptalIstekDVO {
        
        private string ereceteNoField;
        
        private int tesisKoduField;
        
        private long doktorTcKimlikNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ereceteNo {
            get {
                return ereceteNoField;
            }
            set {
                ereceteNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteYatanHastaOnayiCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteYatanHastaOnayiIstekDVO {
        
        private string ereceteNoField;
        
        private int tesisKoduField;
        
        private long doktorTcKimlikNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ereceteNo {
            get {
                return ereceteNoField;
            }
            set {
                ereceteNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteEhuOnayiIptalCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteEhuOnayiIptalIstekDVO {
        
        private string ereceteNoField;
        
        private int tesisKoduField;
        
        private long doktorTcKimlikNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ereceteNo {
            get {
                return ereceteNoField;
            }
            set {
                ereceteNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteEhuOnayiCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteEhuOnayiIstekDVO {
        
        private string ereceteNoField;
        
        private int tesisKoduField;
        
        private long doktorTcKimlikNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ereceteNo {
            get {
                return ereceteNoField;
            }
            set {
                ereceteNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteSilCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteSilIstekDVO {
        
        private byte[] imzaliEreceteSilField;
        
        private string tesisKoduField;
        
        private string doktorTcKimlikNoField;
        
        private string surumNumarasiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] imzaliEreceteSil {
            get {
                return imzaliEreceteSilField;
            }
            set {
                imzaliEreceteSilField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string surumNumarasi {
            get {
                return surumNumarasiField;
            }
            set {
                surumNumarasiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteSilCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteSilIstekDVO {
        
        private int tesisKoduField;
        
        private string ereceteNoField;
        
        private long doktorTcKimlikNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ereceteNo {
            get {
                return ereceteNoField;
            }
            set {
                ereceteNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteGirisCevapDVO {
        
        private ereceteDVO ereceteDVOField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ereceteDVO ereceteDVO {
            get {
                return ereceteDVOField;
            }
            set {
                ereceteDVOField = value;
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteDVO {
        
        private string protokolNoField;
        
        private int provizyonTipiField;
        
        private int receteAltTuruField;
        
        private string receteTarihiField;
        
        private System.Nullable<int> receteTuruField;
        
        private string takipNoField;
        
        private long tcKimlikNoField;
        
        private int tesisKoduField;
        
        private string seriNoField;
        
        private int doktorBransKoduField;
        
        private int doktorSertifikaKoduField;
        
        private kisiDVO kisiDVOField;
        
        private string ereceteNoField;
        
        private ereceteIlacDVO[] ereceteIlacListesiField;
        
        private ereceteTaniDVO[] ereceteTaniListesiField;
        
        private ereceteAciklamaDVO[] ereceteAciklamaListesiField;
        
        private string doktorAdiField;
        
        private string doktorSoyadiField;
        
        private long doktorTcKimlikNoField;
        
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
        public int provizyonTipi {
            get {
                return provizyonTipiField;
            }
            set {
                provizyonTipiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int receteAltTuru {
            get {
                return receteAltTuruField;
            }
            set {
                receteAltTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string receteTarihi {
            get {
                return receteTarihiField;
            }
            set {
                receteTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> receteTuru {
            get {
                return receteTuruField;
            }
            set {
                receteTuruField = value;
            }
        }
        
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
        public long tcKimlikNo {
            get {
                return tcKimlikNoField;
            }
            set {
                tcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string seriNo {
            get {
                return seriNoField;
            }
            set {
                seriNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int doktorBransKodu {
            get {
                return doktorBransKoduField;
            }
            set {
                doktorBransKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int doktorSertifikaKodu {
            get {
                return doktorSertifikaKoduField;
            }
            set {
                doktorSertifikaKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public kisiDVO kisiDVO {
            get {
                return kisiDVOField;
            }
            set {
                kisiDVOField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string ereceteNo {
            get {
                return ereceteNoField;
            }
            set {
                ereceteNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ereceteIlacListesi", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ereceteIlacDVO[] ereceteIlacListesi {
            get {
                return ereceteIlacListesiField;
            }
            set {
                ereceteIlacListesiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ereceteTaniListesi", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ereceteTaniDVO[] ereceteTaniListesi {
            get {
                return ereceteTaniListesiField;
            }
            set {
                ereceteTaniListesiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ereceteAciklamaListesi", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public ereceteAciklamaDVO[] ereceteAciklamaListesi {
            get {
                return ereceteAciklamaListesiField;
            }
            set {
                ereceteAciklamaListesiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string doktorAdi {
            get {
                return doktorAdiField;
            }
            set {
                doktorAdiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string doktorSoyadi {
            get {
                return doktorSoyadiField;
            }
            set {
                doktorSoyadiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class kisiDVO {
        
        private string adiField;
        
        private string cinsiyetiField;
        
        private string dogumTarihiField;
        
        private string soyadiField;
        
        private long tcKimlikNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string adi {
            get {
                return adiField;
            }
            set {
                adiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cinsiyeti {
            get {
                return cinsiyetiField;
            }
            set {
                cinsiyetiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string dogumTarihi {
            get {
                return dogumTarihiField;
            }
            set {
                dogumTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string soyadi {
            get {
                return soyadiField;
            }
            set {
                soyadiField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteIlacDVO {
        
        private int adetField;
        
        private long barkodField;
        
        private string ilacAdiField;
        
        private int kullanimDoz1Field;
        
        private int kullanimPeriyotBirimiField;
        
        private System.Nullable<int> kullanimSekliField;
        
        private ereceteIlacAciklamaDVO[] ereceteIlacAciklamaListesiField;
        
        private double kullanimDoz2Field;
        
        private int kullanimPeriyotField;
        
        private string geriOdemeKapsamindaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int adet {
            get {
                return adetField;
            }
            set {
                adetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long barkod {
            get {
                return barkodField;
            }
            set {
                barkodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string ilacAdi {
            get {
                return ilacAdiField;
            }
            set {
                ilacAdiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int kullanimDoz1 {
            get {
                return kullanimDoz1Field;
            }
            set {
                kullanimDoz1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int kullanimPeriyotBirimi {
            get {
                return kullanimPeriyotBirimiField;
            }
            set {
                kullanimPeriyotBirimiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> kullanimSekli {
            get {
                return kullanimSekliField;
            }
            set {
                kullanimSekliField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ereceteIlacAciklamaListesi", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public ereceteIlacAciklamaDVO[] ereceteIlacAciklamaListesi {
            get {
                return ereceteIlacAciklamaListesiField;
            }
            set {
                ereceteIlacAciklamaListesiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double kullanimDoz2 {
            get {
                return kullanimDoz2Field;
            }
            set {
                kullanimDoz2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int kullanimPeriyot {
            get {
                return kullanimPeriyotField;
            }
            set {
                kullanimPeriyotField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string geriOdemeKapsaminda {
            get {
                return geriOdemeKapsamindaField;
            }
            set {
                geriOdemeKapsamindaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteGirisIstekDVO {
        
        private byte[] imzaliEreceteField;
        
        private int tesisKoduField;
        
        private int surumNumarasiField;
        
        private long doktorTcKimlikNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] imzaliErecete {
            get {
                return imzaliEreceteField;
            }
            set {
                imzaliEreceteField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int surumNumarasi {
            get {
                return surumNumarasiField;
            }
            set {
                surumNumarasiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteGirisCevapDVO {
        
        private ereceteDVO ereceteDVOField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ereceteDVO ereceteDVO {
            get {
                return ereceteDVOField;
            }
            set {
                ereceteDVOField = value;
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteGirisIstekDVO {
        
        private ereceteDVO ereceteDVOField;
        
        private int tesisKoduField;
        
        private long doktorTcKimlikNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ereceteDVO ereceteDVO {
            get {
                return ereceteDVOField;
            }
            set {
                ereceteDVOField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteListeSorguCevapDVO {
        
        private ereceteDVO[] ereceteListesiField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ereceteListesi", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public ereceteDVO[] ereceteListesi {
            get {
                return ereceteListesiField;
            }
            set {
                ereceteListesiField = value;
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteListeSorguIstekDVO {
        
        private byte[] imzaliEreceteListeSorgulaField;
        
        private string tesisKoduField;
        
        private string doktorTcKimlikNoField;
        
        private string surumNumarasiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] imzaliEreceteListeSorgula {
            get {
                return imzaliEreceteListeSorgulaField;
            }
            set {
                imzaliEreceteListeSorgulaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string surumNumarasi {
            get {
                return surumNumarasiField;
            }
            set {
                surumNumarasiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteListeSorguCevapDVO {
        
        private ereceteDVO[] ereceteListesiField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ereceteListesi", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public ereceteDVO[] ereceteListesi {
            get {
                return ereceteListesiField;
            }
            set {
                ereceteListesiField = value;
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteListeSorguIstekDVO {
        
        private int tesisKoduField;
        
        private long doktorTcKimlikNoField;
        
        private long hastaTcKimlikNoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long hastaTcKimlikNo {
            get {
                return hastaTcKimlikNoField;
            }
            set {
                hastaTcKimlikNoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteSorguCevapDVO {
        
        private ereceteDVO ereceteDVOField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ereceteDVO ereceteDVO {
            get {
                return ereceteDVOField;
            }
            set {
                ereceteDVOField = value;
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class imzaliEreceteSorguIstekDVO {
        
        private byte[] imzaliEreceteSorgulaField;
        
        private string tesisKoduField;
        
        private string doktorTcKimlikNoField;
        
        private string surumNumarasiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] imzaliEreceteSorgula {
            get {
                return imzaliEreceteSorgulaField;
            }
            set {
                imzaliEreceteSorgulaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tesisKodu {
            get {
                return tesisKoduField;
            }
            set {
                tesisKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string doktorTcKimlikNo {
            get {
                return doktorTcKimlikNoField;
            }
            set {
                doktorTcKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string surumNumarasi {
            get {
                return surumNumarasiField;
            }
            set {
                surumNumarasiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class ereceteSorguCevapDVO {
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        private string uyariMesajiField;
        
        private ereceteDVO ereceteDVOField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uyariMesaji {
            get {
                return uyariMesajiField;
            }
            set {
                uyariMesajiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ereceteDVO ereceteDVO {
            get {
                return ereceteDVOField;
            }
            set {
                ereceteDVOField = value;
            }
        }
    }
        
#endregion Methods

    }
}