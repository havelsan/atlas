
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
    /// <summary>
    /// E- Sevk İşlemleri
    /// </summary>
    public  abstract  partial class SevkIslemleri : TTObject
    {
        
                    
        public static partial class WebMethods
        {
                    
        }
                    
#region Methods
        /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class sevkListeDVO {
        
        private long tcKimlikNoField;
        
        private int saglikTesisKoduField;
        
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class sevkKayitIptalDVO {
        
        private string sevkTakipNoField;
        
        private int saglikTesisKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkTakipNo {
            get {
                return sevkTakipNoField;
            }
            set {
                sevkTakipNoField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class sevkIptalCevapDVO {
        
        private string sevkTakipNoField;
        
        private long esevkNoField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkTakipNo {
            get {
                return sevkTakipNoField;
            }
            set {
                sevkTakipNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long esevkNo {
            get {
                return esevkNoField;
            }
            set {
                esevkNoField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class sevkBildirimIptalDVO {
        
        private string sevkTakipNoField;
        
        private int saglikTesisKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkTakipNo {
            get {
                return sevkTakipNoField;
            }
            set {
                sevkTakipNoField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class sevkTedaviDVO {
        
        private string tedaviTuruField;
        
        private string baslangicTarihiField;
        
        private string bitisTarihiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tedaviTuru {
            get {
                return tedaviTuruField;
            }
            set {
                tedaviTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string baslangicTarihi {
            get {
                return baslangicTarihiField;
            }
            set {
                baslangicTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string bitisTarihi {
            get {
                return bitisTarihiField;
            }
            set {
                bitisTarihiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class sevkKayitDVO {
        
        private string kabulTakipNoField;
        
        private System.Nullable<int> donusVasitasiField;
        
        private string refakatciField;
        
        private int saglikTesisKoduField;
        
        private string ayrilisTarihiField;
        
        private System.Nullable<long> raporIdField;
        
        private sevkTaniDVO[] tedaviTaniField;
        
        private sevkDoktorDVO[] tedaviEdenDoktorField;
        
        private sevkTedaviDVO[] sevkTedaviField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string kabulTakipNo {
            get {
                return kabulTakipNoField;
            }
            set {
                kabulTakipNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> donusVasitasi {
            get {
                return donusVasitasiField;
            }
            set {
                donusVasitasiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string refakatci {
            get {
                return refakatciField;
            }
            set {
                refakatciField = value;
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
        public string ayrilisTarihi {
            get {
                return ayrilisTarihiField;
            }
            set {
                ayrilisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<long> raporId {
            get {
                return raporIdField;
            }
            set {
                raporIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("tedaviTani", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public sevkTaniDVO[] tedaviTani {
            get {
                return tedaviTaniField;
            }
            set {
                tedaviTaniField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("tedaviEdenDoktor", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public sevkDoktorDVO[] tedaviEdenDoktor {
            get {
                return tedaviEdenDoktorField;
            }
            set {
                tedaviEdenDoktorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sevkTedavi", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public sevkTedaviDVO[] sevkTedavi {
            get {
                return sevkTedaviField;
            }
            set {
                sevkTedaviField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class sevkTaniDVO {
        
        private string sevkTaniKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkTaniKodu {
            get {
                return sevkTaniKoduField;
            }
            set {
                sevkTaniKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class sevkDoktorDVO {
        
        private string doktorTescilNoField;
        
        private string doktorTipiField;
        
        private string bransKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string doktorTescilNo {
            get {
                return doktorTescilNoField;
            }
            set {
                doktorTescilNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string doktorTipi {
            get {
                return doktorTipiField;
            }
            set {
                doktorTipiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string bransKodu {
            get {
                return bransKoduField;
            }
            set {
                bransKoduField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class sevkCevapDVO {
        
        private string sevkTakipNoField;
        
        private long esevkNoField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkTakipNo {
            get {
                return sevkTakipNoField;
            }
            set {
                sevkTakipNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long esevkNo {
            get {
                return esevkNoField;
            }
            set {
                esevkNoField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class sevkBildirimDVO {
        
        private string sevkTakipNoField;
        
        private string protokolNoField;
        
        private int sevkEdilenIlField;
        
        private string sevkEdilenBransField;
        
        private int sevkVasitasiField;
        
        private int sevkNedeniField;
        
        private string sevkNedeniAciklamaField;
        
        private int tedaviTipiField;
        
        private string refakakciGerekcesiField;
        
        private string refakatciField;
        
        private sevkTaniDVO[] sevkTaniField;
        
        private sevkDoktorDVO[] sevkEdenDoktorField;
        
        private int saglikTesisKoduField;
        
        private long raporIdField;
        
        private int sevkEdilenTesisField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkTakipNo {
            get {
                return sevkTakipNoField;
            }
            set {
                sevkTakipNoField = value;
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
        public int sevkEdilenIl {
            get {
                return sevkEdilenIlField;
            }
            set {
                sevkEdilenIlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkEdilenBrans {
            get {
                return sevkEdilenBransField;
            }
            set {
                sevkEdilenBransField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int sevkVasitasi {
            get {
                return sevkVasitasiField;
            }
            set {
                sevkVasitasiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int sevkNedeni {
            get {
                return sevkNedeniField;
            }
            set {
                sevkNedeniField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkNedeniAciklama {
            get {
                return sevkNedeniAciklamaField;
            }
            set {
                sevkNedeniAciklamaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tedaviTipi {
            get {
                return tedaviTipiField;
            }
            set {
                tedaviTipiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string refakakciGerekcesi {
            get {
                return refakakciGerekcesiField;
            }
            set {
                refakakciGerekcesiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string refakatci {
            get {
                return refakatciField;
            }
            set {
                refakatciField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sevkTani", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public sevkTaniDVO[] sevkTani {
            get {
                return sevkTaniField;
            }
            set {
                sevkTaniField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sevkEdenDoktor", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public sevkDoktorDVO[] sevkEdenDoktor {
            get {
                return sevkEdenDoktorField;
            }
            set {
                sevkEdenDoktorField = value;
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
        public long raporId {
            get {
                return raporIdField;
            }
            set {
                raporIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int sevkEdilenTesis {
            get {
                return sevkEdilenTesisField;
            }
            set {
                sevkEdilenTesisField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class mutatDisiIptalCevapDVO {
        
        private long raporIDField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long raporID {
            get {
                return raporIDField;
            }
            set {
                raporIDField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class mutatDisiRaporIptalDVO {
        
        private int raporIDField;
        
        private int saglikTesisKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int raporID {
            get {
                return raporIDField;
            }
            set {
                raporIDField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class mutatDisiRaporCevapDVO {
        
        private long raporIdField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long raporId {
            get {
                return raporIdField;
            }
            set {
                raporIdField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class mutatDisiRaporDVO {
        
        private long haksahibiTCNOField;
        
        private string raporNoField;
        
        private string protokolNoField;
        
        private int sevkVasitasiField;
        
        private string raporTarihiField;
        
        private string baslangicTarihiField;
        
        private string bitisTarihiField;
        
        private string refakatciGerekcesiField;
        
        private string mutatDisiGerekcesiField;
        
        private sevkTaniDVO[] sevkTaniField;
        
        private sevkDoktorDVO[] sevkEdenDoktorField;
        
        private int saglikTesisKoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long haksahibiTCNO {
            get {
                return haksahibiTCNOField;
            }
            set {
                haksahibiTCNOField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string raporNo {
            get {
                return raporNoField;
            }
            set {
                raporNoField = value;
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
        public int sevkVasitasi {
            get {
                return sevkVasitasiField;
            }
            set {
                sevkVasitasiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string raporTarihi {
            get {
                return raporTarihiField;
            }
            set {
                raporTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string baslangicTarihi {
            get {
                return baslangicTarihiField;
            }
            set {
                baslangicTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string bitisTarihi {
            get {
                return bitisTarihiField;
            }
            set {
                bitisTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string refakatciGerekcesi {
            get {
                return refakatciGerekcesiField;
            }
            set {
                refakatciGerekcesiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string mutatDisiGerekcesi {
            get {
                return mutatDisiGerekcesiField;
            }
            set {
                mutatDisiGerekcesiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sevkTani", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public sevkTaniDVO[] sevkTani {
            get {
                return sevkTaniField;
            }
            set {
                sevkTaniField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sevkEdenDoktor", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public sevkDoktorDVO[] sevkEdenDoktor {
            get {
                return sevkEdenDoktorField;
            }
            set {
                sevkEdenDoktorField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class sevkDVO {
        
        private long sevkIdField;
        
        private long tcKimlikNoField;
        
        private int sevkEdenTesisField;
        
        private string sevkTakipNoField;
        
        private string protokolNoField;
        
        private int sevkEdilenIlField;
        
        private string sevkTarihiField;
        
        private string sevkEdilenBransField;
        
        private int sevkVasitasiField;
        
        private int sevkNedeniField;
        
        private string sevkNedeniAciklamaField;
        
        private int tedaviTipiField;
        
        private int kabulEdenTesisField;
        
        private string kabulEdenTakipField;
        
        private string sevkEdenBransField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long sevkId {
            get {
                return sevkIdField;
            }
            set {
                sevkIdField = value;
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
        public int sevkEdenTesis {
            get {
                return sevkEdenTesisField;
            }
            set {
                sevkEdenTesisField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkTakipNo {
            get {
                return sevkTakipNoField;
            }
            set {
                sevkTakipNoField = value;
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
        public int sevkEdilenIl {
            get {
                return sevkEdilenIlField;
            }
            set {
                sevkEdilenIlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkTarihi {
            get {
                return sevkTarihiField;
            }
            set {
                sevkTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkEdilenBrans {
            get {
                return sevkEdilenBransField;
            }
            set {
                sevkEdilenBransField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int sevkVasitasi {
            get {
                return sevkVasitasiField;
            }
            set {
                sevkVasitasiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int sevkNedeni {
            get {
                return sevkNedeniField;
            }
            set {
                sevkNedeniField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkNedeniAciklama {
            get {
                return sevkNedeniAciklamaField;
            }
            set {
                sevkNedeniAciklamaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int tedaviTipi {
            get {
                return tedaviTipiField;
            }
            set {
                tedaviTipiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int kabulEdenTesis {
            get {
                return kabulEdenTesisField;
            }
            set {
                kabulEdenTesisField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string kabulEdenTakip {
            get {
                return kabulEdenTakipField;
            }
            set {
                kabulEdenTakipField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sevkEdenBrans {
            get {
                return sevkEdenBransField;
            }
            set {
                sevkEdenBransField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
    public partial class sevkListeCevapDVO {
        
        private sevkDVO[] sevkListesiField;
        
        private string sonucKoduField;
        
        private string sonucMesajiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sevkListesi", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public sevkDVO[] sevkListesi {
            get {
                return sevkListesiField;
            }
            set {
                sevkListesiField = value;
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