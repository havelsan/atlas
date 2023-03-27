
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
    public  partial class RaporIslemleri : TTObject
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
        public partial class raporGirisDVO {
            
            private int saglikTesisKoduField;
            
            private ilacRaporDVO ilacRaporField;
            
            private tedaviRaporDVO tedaviRaporField;
            
            private isgoremezlikRaporDVO isgoremezlikRaporField;
            
            private maluliyetRaporDVO maluliyetRaporField;
            
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
            public ilacRaporDVO ilacRapor {
                get {
                    return ilacRaporField;
                }
                set {
                    ilacRaporField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public tedaviRaporDVO tedaviRapor {
                get {
                    return tedaviRaporField;
                }
                set {
                    tedaviRaporField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public isgoremezlikRaporDVO isgoremezlikRapor {
                get {
                    return isgoremezlikRaporField;
                }
                set {
                    isgoremezlikRaporField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public maluliyetRaporDVO maluliyetRapor {
                get {
                    return maluliyetRaporField;
                }
                set {
                    maluliyetRaporField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class ilacRaporDVO {
            
            private raporDVO raporDVOField;
            
            private string takipFormuNoField;
            
            private raporEtkinMaddeDVO[] raporEtkinMaddelerField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public raporDVO raporDVO {
                get {
                    return raporDVOField;
                }
                set {
                    raporDVOField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string takipFormuNo {
                get {
                    return takipFormuNoField;
                }
                set {
                    takipFormuNoField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("raporEtkinMaddeler", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public raporEtkinMaddeDVO[] raporEtkinMaddeler {
                get {
                    return raporEtkinMaddelerField;
                }
                set {
                    raporEtkinMaddelerField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class raporDVO {
            
            private raporBilgisiDVO raporBilgisiField;
            
            private string turuField;
            
            private string baslangicTarihiField;
            
            private string bitisTarihiField;
            
            private string duzenlemeTuruField;
            
            private hakSahibiBilgisiDVO hakSahibiField;
            
            private string protokolNoField;
            
            private string protokolTarihiField;
            
            private string durumField;
            
            private string aciklamaField;
            
            private doktorBilgisiDVO[] doktorlarField;
            
            private taniBilgisiDVO[] tanilarField;
            
            private teshisBilgisiDVO[] teshislerField;
            
            private ilacTeshisBilgiDVO[] ilacTeshislerField;
            
            private string takipNoField;
            
            private string klinikTaniField;
            
            private System.Nullable<int> ozelDurumField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public raporBilgisiDVO raporBilgisi {
                get {
                    return raporBilgisiField;
                }
                set {
                    raporBilgisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string turu {
                get {
                    return turuField;
                }
                set {
                    turuField = value;
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
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string duzenlemeTuru {
                get {
                    return duzenlemeTuruField;
                }
                set {
                    duzenlemeTuruField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public hakSahibiBilgisiDVO hakSahibi {
                get {
                    return hakSahibiField;
                }
                set {
                    hakSahibiField = value;
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
            public string protokolTarihi {
                get {
                    return protokolTarihiField;
                }
                set {
                    protokolTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string durum {
                get {
                    return durumField;
                }
                set {
                    durumField = value;
                }
            }
            
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
            [System.Xml.Serialization.XmlElementAttribute("doktorlar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public doktorBilgisiDVO[] doktorlar {
                get {
                    return doktorlarField;
                }
                set {
                    doktorlarField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("tanilar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public taniBilgisiDVO[] tanilar {
                get {
                    return tanilarField;
                }
                set {
                    tanilarField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("teshisler", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public teshisBilgisiDVO[] teshisler {
                get {
                    return teshislerField;
                }
                set {
                    teshislerField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ilacTeshisler", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public ilacTeshisBilgiDVO[] ilacTeshisler {
                get {
                    return ilacTeshislerField;
                }
                set {
                    ilacTeshislerField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string takipNo {
                get {
                    return takipNoField;
                }
                set {
                    takipNoField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string klinikTani {
                get {
                    return klinikTaniField;
                }
                set {
                    klinikTaniField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> ozelDurum {
                get {
                    return ozelDurumField;
                }
                set {
                    ozelDurumField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class raporBilgisiDVO {
            
            private int raporTesisKoduField;
            
            private string tarihField;
            
            private string noField;
            
            private string raporTakipNoField;
            
            private System.Nullable<int> raporSiraNoField;
            
            private int aVakaTKazaField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int raporTesisKodu {
                get {
                    return raporTesisKoduField;
                }
                set {
                    raporTesisKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tarih {
                get {
                    return tarihField;
                }
                set {
                    tarihField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string no {
                get {
                    return noField;
                }
                set {
                    noField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo {
                get {
                    return raporTakipNoField;
                }
                set {
                    raporTakipNoField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> raporSiraNo {
                get {
                    return raporSiraNoField;
                }
                set {
                    raporSiraNoField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int aVakaTKaza {
                get {
                    return aVakaTKazaField;
                }
                set {
                    aVakaTKazaField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class ilacRaporDuzeltDVO {
            
            private string raporNoField;
            
            private string raporTarihiField;
            
            private int saglikTesisKoduField;
            
            private string raporTuruField;
            
            private string duzeltmeTarihiField;
            
            private string duzeltmeBilgisiField;
            
            private string drTescilNoField;
            
            private raporEtkinMaddeDVO[] raporEtkinMaddelerField;
            
            private taniBilgisiDVO[] tanilarField;
            
            private ilacTeshisBilgiDVO[] ilacTeshislerField;
            
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
            public string raporTuru {
                get {
                    return raporTuruField;
                }
                set {
                    raporTuruField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string duzeltmeTarihi {
                get {
                    return duzeltmeTarihiField;
                }
                set {
                    duzeltmeTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string duzeltmeBilgisi {
                get {
                    return duzeltmeBilgisiField;
                }
                set {
                    duzeltmeBilgisiField = value;
                }
            }
            
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
            [System.Xml.Serialization.XmlElementAttribute("raporEtkinMaddeler", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public raporEtkinMaddeDVO[] raporEtkinMaddeler {
                get {
                    return raporEtkinMaddelerField;
                }
                set {
                    raporEtkinMaddelerField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("tanilar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public taniBilgisiDVO[] tanilar {
                get {
                    return tanilarField;
                }
                set {
                    tanilarField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ilacTeshisler", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public ilacTeshisBilgiDVO[] ilacTeshisler {
                get {
                    return ilacTeshislerField;
                }
                set {
                    ilacTeshislerField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class raporEtkinMaddeDVO {
            
            private string etkinMaddeKoduField;
            
            private System.Nullable<int> kullanimDoz1Field;
            
            private System.Nullable<int> kullanimDoz2Field;
            
            private string kullanimDozBirimField;
            
            private System.Nullable<int> kullanimPeriyotField;
            
            private string kullanimPeriyotBirimField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string etkinMaddeKodu {
                get {
                    return etkinMaddeKoduField;
                }
                set {
                    etkinMaddeKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> kullanimDoz1 {
                get {
                    return kullanimDoz1Field;
                }
                set {
                    kullanimDoz1Field = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> kullanimDoz2 {
                get {
                    return kullanimDoz2Field;
                }
                set {
                    kullanimDoz2Field = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string kullanimDozBirim {
                get {
                    return kullanimDozBirimField;
                }
                set {
                    kullanimDozBirimField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> kullanimPeriyot {
                get {
                    return kullanimPeriyotField;
                }
                set {
                    kullanimPeriyotField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string kullanimPeriyotBirim {
                get {
                    return kullanimPeriyotBirimField;
                }
                set {
                    kullanimPeriyotBirimField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class taniBilgisiDVO {
            
            private string taniKoduField;
            
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class ilacTeshisBilgiDVO {
            
            private int teshisKoduField;
            
            private string baslangicTarihiField;
            
            private string bitisTarihiField;
            
            private taniBilgisiDVO[] iCD10KoduField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int teshisKodu {
                get {
                    return teshisKoduField;
                }
                set {
                    teshisKoduField = value;
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
            [System.Xml.Serialization.XmlElementAttribute("ICD10Kodu", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public taniBilgisiDVO[] ICD10Kodu {
                get {
                    return iCD10KoduField;
                }
                set {
                    iCD10KoduField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class raporCevapTCKimlikNodanDVO {
            
            private raporCevapDVO[] raporlarField;
            
            private int sonucKoduField;
            
            private string sonucAciklamasiField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("raporlar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public raporCevapDVO[] raporlar {
                get {
                    return raporlarField;
                }
                set {
                    raporlarField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int sonucKodu {
                get {
                    return sonucKoduField;
                }
                set {
                    sonucKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucAciklamasi {
                get {
                    return sonucAciklamasiField;
                }
                set {
                    sonucAciklamasiField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class raporCevapDVO {
            
            private long raporTakipNoField;
            
            private int sonucKoduField;
            
            private string sonucAciklamasiField;
            
            private isgoremezlikRaporDVO isgoremezlikRaporField;
            
            private isgoremezlikRaporEkDVO[] isgoremezlikRaporEkleriField;
            
            private dogumOncesiCalisabilirRaporDVO dogumOncesiCalisabilirRaporField;
            
            private dogumRaporDVO dogumRaporField;
            
            private analikIsgoremezlikRaporDVO analikRaporField;
            
            private protezRaporDVO protezRaporField;
            
            private ilacRaporDVO ilacRaporField;
            
            private tedaviRaporDVO tedaviRaporField;
            
            private maluliyetRaporDVO maluliyetRaporField;
            
            private string raporTuruField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long raporTakipNo {
                get {
                    return raporTakipNoField;
                }
                set {
                    raporTakipNoField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int sonucKodu {
                get {
                    return sonucKoduField;
                }
                set {
                    sonucKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucAciklamasi {
                get {
                    return sonucAciklamasiField;
                }
                set {
                    sonucAciklamasiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public isgoremezlikRaporDVO isgoremezlikRapor {
                get {
                    return isgoremezlikRaporField;
                }
                set {
                    isgoremezlikRaporField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("isgoremezlikRaporEkleri", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public isgoremezlikRaporEkDVO[] isgoremezlikRaporEkleri {
                get {
                    return isgoremezlikRaporEkleriField;
                }
                set {
                    isgoremezlikRaporEkleriField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public dogumOncesiCalisabilirRaporDVO dogumOncesiCalisabilirRapor {
                get {
                    return dogumOncesiCalisabilirRaporField;
                }
                set {
                    dogumOncesiCalisabilirRaporField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public dogumRaporDVO dogumRapor {
                get {
                    return dogumRaporField;
                }
                set {
                    dogumRaporField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public analikIsgoremezlikRaporDVO analikRapor {
                get {
                    return analikRaporField;
                }
                set {
                    analikRaporField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public protezRaporDVO protezRapor {
                get {
                    return protezRaporField;
                }
                set {
                    protezRaporField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public ilacRaporDVO ilacRapor {
                get {
                    return ilacRaporField;
                }
                set {
                    ilacRaporField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public tedaviRaporDVO tedaviRapor {
                get {
                    return tedaviRaporField;
                }
                set {
                    tedaviRaporField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public maluliyetRaporDVO maluliyetRapor {
                get {
                    return maluliyetRaporField;
                }
                set {
                    maluliyetRaporField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTuru {
                get {
                    return raporTuruField;
                }
                set {
                    raporTuruField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class isgoremezlikRaporDVO {
            
            private raporDVO raporDVOField;
            
            private int isGoremezlikRaporTuruField;
            
            private int bransKoduField;
            
            private string teshisField;
            
            private string olumField;
            
            private string klinikBulguField;
            
            private string ronLabBilgiField;
            
            private string kararField;
            
            private isKazasiRaporDVO isKazasiRaporuField;
            
            private meslekHastaligiRaporDVO meslekHastaligiRaporuField;
            
            private analikRaporDVO analikRaporuField;
            
            private emzirmeRaporDVO emzirmeRaporuField;
            
            private hastalikRaporDVO hastalikRaporuField;
            
            private int devammiField;
            
            private string yatisDevamField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public raporDVO raporDVO {
                get {
                    return raporDVOField;
                }
                set {
                    raporDVOField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int isGoremezlikRaporTuru {
                get {
                    return isGoremezlikRaporTuruField;
                }
                set {
                    isGoremezlikRaporTuruField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int bransKodu {
                get {
                    return bransKoduField;
                }
                set {
                    bransKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string teshis {
                get {
                    return teshisField;
                }
                set {
                    teshisField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string olum {
                get {
                    return olumField;
                }
                set {
                    olumField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string klinikBulgu {
                get {
                    return klinikBulguField;
                }
                set {
                    klinikBulguField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string ronLabBilgi {
                get {
                    return ronLabBilgiField;
                }
                set {
                    ronLabBilgiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string karar {
                get {
                    return kararField;
                }
                set {
                    kararField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public isKazasiRaporDVO isKazasiRaporu {
                get {
                    return isKazasiRaporuField;
                }
                set {
                    isKazasiRaporuField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public meslekHastaligiRaporDVO meslekHastaligiRaporu {
                get {
                    return meslekHastaligiRaporuField;
                }
                set {
                    meslekHastaligiRaporuField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public analikRaporDVO analikRaporu {
                get {
                    return analikRaporuField;
                }
                set {
                    analikRaporuField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public emzirmeRaporDVO emzirmeRaporu {
                get {
                    return emzirmeRaporuField;
                }
                set {
                    emzirmeRaporuField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public hastalikRaporDVO hastalikRaporu {
                get {
                    return hastalikRaporuField;
                }
                set {
                    hastalikRaporuField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int devammi {
                get {
                    return devammiField;
                }
                set {
                    devammiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string yatisDevam {
                get {
                    return yatisDevamField;
                }
                set {
                    yatisDevamField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class isKazasiRaporDVO {
            
            private string baslangicTarihiField;
            
            private string bitisTarihiField;
            
            private string raporDurumuField;
            
            private string isKontTarihiField;
            
            private string XXXXXXYatisTarihiField;
            
            private string XXXXXXCikisTarihiField;
            
            private string nuksField;
            
            private string yaraninTuruField;
            
            private string yaraninYeriField;
            
            private string taburcuTarihiField;
            
            private System.Nullable<int> taburcuKoduField;
            
            private string isKazasiTarihiField;
            
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
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string raporDurumu {
                get {
                    return raporDurumuField;
                }
                set {
                    raporDurumuField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string isKontTarihi {
                get {
                    return isKontTarihiField;
                }
                set {
                    isKontTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string XXXXXXYatisTarihi {
                get {
                    return XXXXXXYatisTarihiField;
                }
                set {
                    XXXXXXYatisTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string XXXXXXCikisTarihi {
                get {
                    return XXXXXXCikisTarihiField;
                }
                set {
                    XXXXXXCikisTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string nuks {
                get {
                    return nuksField;
                }
                set {
                    nuksField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string yaraninTuru {
                get {
                    return yaraninTuruField;
                }
                set {
                    yaraninTuruField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string yaraninYeri {
                get {
                    return yaraninYeriField;
                }
                set {
                    yaraninYeriField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string taburcuTarihi {
                get {
                    return taburcuTarihiField;
                }
                set {
                    taburcuTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> taburcuKodu {
                get {
                    return taburcuKoduField;
                }
                set {
                    taburcuKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string isKazasiTarihi {
                get {
                    return isKazasiTarihiField;
                }
                set {
                    isKazasiTarihiField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class meslekHastaligiRaporDVO {
            
            private string baslangicTarihiField;
            
            private string bitisTarihiField;
            
            private string raporDurumuField;
            
            private string isKontTarihiField;
            
            private string XXXXXXYatisTarihiField;
            
            private string XXXXXXCikisTarihiField;
            
            private string nuksField;
            
            private string yaraninTuruField;
            
            private string yaraninYeriField;
            
            private string taburcuTarihiField;
            
            private System.Nullable<int> taburcuKoduField;
            
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
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string raporDurumu {
                get {
                    return raporDurumuField;
                }
                set {
                    raporDurumuField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string isKontTarihi {
                get {
                    return isKontTarihiField;
                }
                set {
                    isKontTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string XXXXXXYatisTarihi {
                get {
                    return XXXXXXYatisTarihiField;
                }
                set {
                    XXXXXXYatisTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string XXXXXXCikisTarihi {
                get {
                    return XXXXXXCikisTarihiField;
                }
                set {
                    XXXXXXCikisTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string nuks {
                get {
                    return nuksField;
                }
                set {
                    nuksField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string yaraninTuru {
                get {
                    return yaraninTuruField;
                }
                set {
                    yaraninTuruField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string yaraninYeri {
                get {
                    return yaraninYeriField;
                }
                set {
                    yaraninYeriField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string taburcuTarihi {
                get {
                    return taburcuTarihiField;
                }
                set {
                    taburcuTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> taburcuKodu {
                get {
                    return taburcuKoduField;
                }
                set {
                    taburcuKoduField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class analikRaporDVO {
            
            private string baslangicTarihiField;
            
            private string bitisTarihiField;
            
            private string raporDurumuField;
            
            private string isKontTarihiField;
            
            private string XXXXXXYatisTarihiField;
            
            private string XXXXXXCikisTarihiField;
            
            private string bebekDogumTarihiField;
            
            private System.Nullable<int> canliCocukSayisiField;
            
            private System.Nullable<int> doganCocukSayisiField;
            
            private string norSezForField;
            
            private string taburcuTarihiField;
            
            private System.Nullable<int> taburcuKoduField;
            
            private System.Nullable<int> gebelikTipiField;
            
            private System.Nullable<int> gebelikHaftasi1Field;
            
            private System.Nullable<int> gebelikHaftasi2Field;
            
            private System.Nullable<int> bebekDogumHaftasiField;
            
            private System.Nullable<int> aktarmaHaftasiField;
            
            private System.Nullable<int> analikRaporTipiField;
            
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
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string raporDurumu {
                get {
                    return raporDurumuField;
                }
                set {
                    raporDurumuField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string isKontTarihi {
                get {
                    return isKontTarihiField;
                }
                set {
                    isKontTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string XXXXXXYatisTarihi {
                get {
                    return XXXXXXYatisTarihiField;
                }
                set {
                    XXXXXXYatisTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string XXXXXXCikisTarihi {
                get {
                    return XXXXXXCikisTarihiField;
                }
                set {
                    XXXXXXCikisTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string bebekDogumTarihi {
                get {
                    return bebekDogumTarihiField;
                }
                set {
                    bebekDogumTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> canliCocukSayisi {
                get {
                    return canliCocukSayisiField;
                }
                set {
                    canliCocukSayisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> doganCocukSayisi {
                get {
                    return doganCocukSayisiField;
                }
                set {
                    doganCocukSayisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string norSezFor {
                get {
                    return norSezForField;
                }
                set {
                    norSezForField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string taburcuTarihi {
                get {
                    return taburcuTarihiField;
                }
                set {
                    taburcuTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> taburcuKodu {
                get {
                    return taburcuKoduField;
                }
                set {
                    taburcuKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> gebelikTipi {
                get {
                    return gebelikTipiField;
                }
                set {
                    gebelikTipiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> gebelikHaftasi1 {
                get {
                    return gebelikHaftasi1Field;
                }
                set {
                    gebelikHaftasi1Field = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> gebelikHaftasi2 {
                get {
                    return gebelikHaftasi2Field;
                }
                set {
                    gebelikHaftasi2Field = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> bebekDogumHaftasi {
                get {
                    return bebekDogumHaftasiField;
                }
                set {
                    bebekDogumHaftasiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> aktarmaHaftasi {
                get {
                    return aktarmaHaftasiField;
                }
                set {
                    aktarmaHaftasiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> analikRaporTipi {
                get {
                    return analikRaporTipiField;
                }
                set {
                    analikRaporTipiField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class emzirmeRaporDVO {
            
            private string bebekDogumTarihiField;
            
            private System.Nullable<int> canliCocukSayisiField;
            
            private System.Nullable<int> doganCocukSayisiField;
            
            private string anneTcKimlikNoField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string bebekDogumTarihi {
                get {
                    return bebekDogumTarihiField;
                }
                set {
                    bebekDogumTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> canliCocukSayisi {
                get {
                    return canliCocukSayisiField;
                }
                set {
                    canliCocukSayisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> doganCocukSayisi {
                get {
                    return doganCocukSayisiField;
                }
                set {
                    doganCocukSayisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string anneTcKimlikNo {
                get {
                    return anneTcKimlikNoField;
                }
                set {
                    anneTcKimlikNoField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class hastalikRaporDVO {
            
            private string baslangicTarihiField;
            
            private string bitisTarihiField;
            
            private string raporDurumuField;
            
            private string isKontTarihiField;
            
            private string XXXXXXYatisTarihiField;
            
            private string XXXXXXCikisTarihiField;
            
            private string taburcuTarihiField;
            
            private System.Nullable<int> taburcuKoduField;
            
            private string nuksField;
            
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
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string raporDurumu {
                get {
                    return raporDurumuField;
                }
                set {
                    raporDurumuField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string isKontTarihi {
                get {
                    return isKontTarihiField;
                }
                set {
                    isKontTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string XXXXXXYatisTarihi {
                get {
                    return XXXXXXYatisTarihiField;
                }
                set {
                    XXXXXXYatisTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string XXXXXXCikisTarihi {
                get {
                    return XXXXXXCikisTarihiField;
                }
                set {
                    XXXXXXCikisTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string taburcuTarihi {
                get {
                    return taburcuTarihiField;
                }
                set {
                    taburcuTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public System.Nullable<int> taburcuKodu {
                get {
                    return taburcuKoduField;
                }
                set {
                    taburcuKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string nuks {
                get {
                    return nuksField;
                }
                set {
                    nuksField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class isgoremezlikRaporEkDVO {
            
            private int kullaniciTesisKoduField;
            
            private raporBilgisiDVO raporBilgisiDVOField;
            
            private string kontrolMuField;
            
            private string kontrolTarihiField;
            
            private string hastaYatisVarMiField;
            
            private hastaYatisBilgisiDVO[] yatislarField;
            
            private string bitisTarihiField;
            
            private string duzenlemeTuruField;
            
            private string protokolNoField;
            
            private string protokolTarihiField;
            
            private string durumField;
            
            private string aciklamaField;
            
            private doktorBilgisiDVO[] doktorlarField;
            
            private taniBilgisiDVO[] tanilarField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int kullaniciTesisKodu {
                get {
                    return kullaniciTesisKoduField;
                }
                set {
                    kullaniciTesisKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public raporBilgisiDVO raporBilgisiDVO {
                get {
                    return raporBilgisiDVOField;
                }
                set {
                    raporBilgisiDVOField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kontrolMu {
                get {
                    return kontrolMuField;
                }
                set {
                    kontrolMuField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kontrolTarihi {
                get {
                    return kontrolTarihiField;
                }
                set {
                    kontrolTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hastaYatisVarMi {
                get {
                    return hastaYatisVarMiField;
                }
                set {
                    hastaYatisVarMiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("yatislar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public hastaYatisBilgisiDVO[] yatislar {
                get {
                    return yatislarField;
                }
                set {
                    yatislarField = value;
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
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string duzenlemeTuru {
                get {
                    return duzenlemeTuruField;
                }
                set {
                    duzenlemeTuruField = value;
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
            public string protokolTarihi {
                get {
                    return protokolTarihiField;
                }
                set {
                    protokolTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string durum {
                get {
                    return durumField;
                }
                set {
                    durumField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string aciklama {
                get {
                    return aciklamaField;
                }
                set {
                    aciklamaField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("doktorlar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public doktorBilgisiDVO[] doktorlar {
                get {
                    return doktorlarField;
                }
                set {
                    doktorlarField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("tanilar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public taniBilgisiDVO[] tanilar {
                get {
                    return tanilarField;
                }
                set {
                    tanilarField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class hastaYatisBilgisiDVO {
            
            private string yatisTarihiField;
            
            private string cikisTarihiField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string yatisTarihi {
                get {
                    return yatisTarihiField;
                }
                set {
                    yatisTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string cikisTarihi {
                get {
                    return cikisTarihiField;
                }
                set {
                    cikisTarihiField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class doktorBilgisiDVO {
            
            private string drTescilNoField;
            
            private string drAdiField;
            
            private string drSoyadiField;
            
            private string drBransKoduField;
            
            private string tipiField;
            
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
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string drAdi {
                get {
                    return drAdiField;
                }
                set {
                    drAdiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string drSoyadi {
                get {
                    return drSoyadiField;
                }
                set {
                    drSoyadiField = value;
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
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tipi {
                get {
                    return tipiField;
                }
                set {
                    tipiField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class dogumOncesiCalisabilirRaporDVO {
            
            private raporDVO raporDVOField;
            
            private string bebekDogumTarihiField;
            
            private string dogumIzniBaslangicTarihiField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public raporDVO raporDVO {
                get {
                    return raporDVOField;
                }
                set {
                    raporDVOField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string bebekDogumTarihi {
                get {
                    return bebekDogumTarihiField;
                }
                set {
                    bebekDogumTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string dogumIzniBaslangicTarihi {
                get {
                    return dogumIzniBaslangicTarihiField;
                }
                set {
                    dogumIzniBaslangicTarihiField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class dogumRaporDVO {
            
            private raporDVO raporDVOField;
            
            private string bebekDogumTarihiField;
            
            private int cocukSayisiField;
            
            private int canliCocukSayisiField;
            
            private string dogumTipiField;
            
            private string epizyotemiField;
            
            private string anesteziTipiField;
            
            private cocukBilgisiDVO[] cocuklarField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public raporDVO raporDVO {
                get {
                    return raporDVOField;
                }
                set {
                    raporDVOField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string bebekDogumTarihi {
                get {
                    return bebekDogumTarihiField;
                }
                set {
                    bebekDogumTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int cocukSayisi {
                get {
                    return cocukSayisiField;
                }
                set {
                    cocukSayisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int canliCocukSayisi {
                get {
                    return canliCocukSayisiField;
                }
                set {
                    canliCocukSayisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string dogumTipi {
                get {
                    return dogumTipiField;
                }
                set {
                    dogumTipiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string epizyotemi {
                get {
                    return epizyotemiField;
                }
                set {
                    epizyotemiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string anesteziTipi {
                get {
                    return anesteziTipiField;
                }
                set {
                    anesteziTipiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cocuklar", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public cocukBilgisiDVO[] cocuklar {
                get {
                    return cocuklarField;
                }
                set {
                    cocuklarField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class cocukBilgisiDVO {
            
            private string cinsiyetField;
            
            private string kiloField;
            
            private string dogumSaatiField;
            
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
            public string kilo {
                get {
                    return kiloField;
                }
                set {
                    kiloField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string dogumSaati {
                get {
                    return dogumSaatiField;
                }
                set {
                    dogumSaatiField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class analikIsgoremezlikRaporDVO {
            
            private raporDVO raporDVOField;
            
            private string bebekDogumTarihiField;
            
            private int cocukSayisiField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public raporDVO raporDVO {
                get {
                    return raporDVOField;
                }
                set {
                    raporDVOField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string bebekDogumTarihi {
                get {
                    return bebekDogumTarihiField;
                }
                set {
                    bebekDogumTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int cocukSayisi {
                get {
                    return cocukSayisiField;
                }
                set {
                    cocukSayisiField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class protezRaporDVO {
            
            private raporDVO raporDVOField;
            
            private malzemeBilgisiDVO[] malzemelerField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public raporDVO raporDVO {
                get {
                    return raporDVOField;
                }
                set {
                    raporDVOField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("malzemeler", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public malzemeBilgisiDVO[] malzemeler {
                get {
                    return malzemelerField;
                }
                set {
                    malzemelerField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class malzemeBilgisiDVO {
            
            private string malzemeKoduField;
            
            private string malzemeAdiField;
            
            private string malzemeTuruField;
            
            private int adetField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string malzemeKodu {
                get {
                    return malzemeKoduField;
                }
                set {
                    malzemeKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string malzemeAdi {
                get {
                    return malzemeAdiField;
                }
                set {
                    malzemeAdiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string malzemeTuru {
                get {
                    return malzemeTuruField;
                }
                set {
                    malzemeTuruField = value;
                }
            }
            
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
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class tedaviRaporDVO {
            
            private raporDVO raporDVOField;
            
            private tedaviIslemBilgisiDVO[] islemlerField;
            
            private int tedaviRaporTuruField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public raporDVO raporDVO {
                get {
                    return raporDVOField;
                }
                set {
                    raporDVOField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("islemler", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public tedaviIslemBilgisiDVO[] islemler {
                get {
                    return islemlerField;
                }
                set {
                    islemlerField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tedaviRaporTuru {
                get {
                    return tedaviRaporTuruField;
                }
                set {
                    tedaviRaporTuruField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class tedaviIslemBilgisiDVO {
            
            private diyalizRaporBilgisiDVO diyalizRaporBilgisiField;
            
            private hotRaporBilgisiDVO hotRaporBilgisiField;
            
            private eswtRaporBilgisiDVO eswtRaporBilgisiField;
            
            private tupBebekRaporBilgisiDVO tupBebekRaporBilgisiField;
            
            private ftrRaporBilgisiDVO ftrRaporBilgisiField;
            
            private eswlRaporBilgisiDVO eswlRaporBilgisiField;
            
            private evHemodiyaliziRaporBilgisiDVO evHemodiyaliziRaporBilgisiField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public diyalizRaporBilgisiDVO diyalizRaporBilgisi {
                get {
                    return diyalizRaporBilgisiField;
                }
                set {
                    diyalizRaporBilgisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public hotRaporBilgisiDVO hotRaporBilgisi {
                get {
                    return hotRaporBilgisiField;
                }
                set {
                    hotRaporBilgisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public eswtRaporBilgisiDVO eswtRaporBilgisi {
                get {
                    return eswtRaporBilgisiField;
                }
                set {
                    eswtRaporBilgisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public tupBebekRaporBilgisiDVO tupBebekRaporBilgisi {
                get {
                    return tupBebekRaporBilgisiField;
                }
                set {
                    tupBebekRaporBilgisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public ftrRaporBilgisiDVO ftrRaporBilgisi {
                get {
                    return ftrRaporBilgisiField;
                }
                set {
                    ftrRaporBilgisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public eswlRaporBilgisiDVO eswlRaporBilgisi {
                get {
                    return eswlRaporBilgisiField;
                }
                set {
                    eswlRaporBilgisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public evHemodiyaliziRaporBilgisiDVO evHemodiyaliziRaporBilgisi {
                get {
                    return evHemodiyaliziRaporBilgisiField;
                }
                set {
                    evHemodiyaliziRaporBilgisiField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class diyalizRaporBilgisiDVO {
            
            private string butKoduField;
            
            private int seansSayiField;
            
            private int seansGunField;
            
            private string refakatVarMiField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string butKodu {
                get {
                    return butKoduField;
                }
                set {
                    butKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int seansSayi {
                get {
                    return seansSayiField;
                }
                set {
                    seansSayiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int seansGun {
                get {
                    return seansGunField;
                }
                set {
                    seansGunField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string refakatVarMi {
                get {
                    return refakatVarMiField;
                }
                set {
                    refakatVarMiField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class hotRaporBilgisiDVO {
            
            private int tedaviSuresiField;
            
            private int seansSayiField;
            
            private int seansGunField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tedaviSuresi {
                get {
                    return tedaviSuresiField;
                }
                set {
                    tedaviSuresiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int seansSayi {
                get {
                    return seansSayiField;
                }
                set {
                    seansSayiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int seansGun {
                get {
                    return seansGunField;
                }
                set {
                    seansGunField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class eswtRaporBilgisiDVO {
            
            private string butKoduField;
            
            private int eswtVucutBolgesiKoduField;
            
            private int seansSayiField;
            
            private int seansGunField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string butKodu {
                get {
                    return butKoduField;
                }
                set {
                    butKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int eswtVucutBolgesiKodu {
                get {
                    return eswtVucutBolgesiKoduField;
                }
                set {
                    eswtVucutBolgesiKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int seansSayi {
                get {
                    return seansSayiField;
                }
                set {
                    seansSayiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int seansGun {
                get {
                    return seansGunField;
                }
                set {
                    seansGunField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class tupBebekRaporBilgisiDVO {
            
            private string butKoduField;
            
            private int tupBebekRaporTuruField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string butKodu {
                get {
                    return butKoduField;
                }
                set {
                    butKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tupBebekRaporTuru {
                get {
                    return tupBebekRaporTuruField;
                }
                set {
                    tupBebekRaporTuruField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class ftrRaporBilgisiDVO {
            
            private string butKoduField;
            
            private int seansSayiField;
            
            private int seansGunField;
            
            private int ftrVucutBolgesiKoduField;
            
            private string tedaviTuruField;
            
            private string robotikRehabilitasyonField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string butKodu {
                get {
                    return butKoduField;
                }
                set {
                    butKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int seansSayi {
                get {
                    return seansSayiField;
                }
                set {
                    seansSayiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int seansGun {
                get {
                    return seansGunField;
                }
                set {
                    seansGunField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int ftrVucutBolgesiKodu {
                get {
                    return ftrVucutBolgesiKoduField;
                }
                set {
                    ftrVucutBolgesiKoduField = value;
                }
            }
            
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
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string robotikRehabilitasyon {
                get {
                    return robotikRehabilitasyonField;
                }
                set {
                    robotikRehabilitasyonField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class eswlRaporBilgisiDVO {
            
            private string butKoduField;
            
            private int eswlRaporuTasSayisiField;
            
            private int eswlRaporuSeansSayisiField;
            
            private int bobrekBilgisiField;
            
            private eswlTasBilgisiDVO[] eswlRaporuTasBilgileriField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string butKodu {
                get {
                    return butKoduField;
                }
                set {
                    butKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int eswlRaporuTasSayisi {
                get {
                    return eswlRaporuTasSayisiField;
                }
                set {
                    eswlRaporuTasSayisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int eswlRaporuSeansSayisi {
                get {
                    return eswlRaporuSeansSayisiField;
                }
                set {
                    eswlRaporuSeansSayisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int bobrekBilgisi {
                get {
                    return bobrekBilgisiField;
                }
                set {
                    bobrekBilgisiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("eswlRaporuTasBilgileri", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eswlTasBilgisiDVO[] eswlRaporuTasBilgileri {
                get {
                    return eswlRaporuTasBilgileriField;
                }
                set {
                    eswlRaporuTasBilgileriField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class eswlTasBilgisiDVO {
            
            private string tasBoyutuField;
            
            private int tasLokalizasyonKoduField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tasBoyutu {
                get {
                    return tasBoyutuField;
                }
                set {
                    tasBoyutuField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tasLokalizasyonKodu {
                get {
                    return tasLokalizasyonKoduField;
                }
                set {
                    tasLokalizasyonKoduField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class evHemodiyaliziRaporBilgisiDVO {
            
            private string butKoduField;
            
            private int seansSayiField;
            
            private int seansGunField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string butKodu {
                get {
                    return butKoduField;
                }
                set {
                    butKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int seansSayi {
                get {
                    return seansSayiField;
                }
                set {
                    seansSayiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int seansGun {
                get {
                    return seansGunField;
                }
                set {
                    seansGunField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class maluliyetRaporDVO {
            
            private raporDVO raporDVOField;
            
            private string aciklamaField;
            
            private string laboratuvarBulgulariField;
            
            private string goruntulemeYontemleriField;
            
            private string teshisField;
            
            private string kararField;
            
            private bransGorusBilgisiDVO[] bransGorusleriField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public raporDVO raporDVO {
                get {
                    return raporDVOField;
                }
                set {
                    raporDVOField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
            public string laboratuvarBulgulari {
                get {
                    return laboratuvarBulgulariField;
                }
                set {
                    laboratuvarBulgulariField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string goruntulemeYontemleri {
                get {
                    return goruntulemeYontemleriField;
                }
                set {
                    goruntulemeYontemleriField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string teshis {
                get {
                    return teshisField;
                }
                set {
                    teshisField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string karar {
                get {
                    return kararField;
                }
                set {
                    kararField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("bransGorusleri", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public bransGorusBilgisiDVO[] bransGorusleri {
                get {
                    return bransGorusleriField;
                }
                set {
                    bransGorusleriField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class bransGorusBilgisiDVO {
            
            private string bransKoduField;
            
            private string aciklamaField;
            
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
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string aciklama {
                get {
                    return aciklamaField;
                }
                set {
                    aciklamaField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class raporOkuTCKimlikNodanDVO {
            
            private string tckimlikNoField;
            
            private string raporTuruField;
            
            private int saglikTesisKoduField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tckimlikNo {
                get {
                    return tckimlikNoField;
                }
                set {
                    tckimlikNoField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTuru {
                get {
                    return raporTuruField;
                }
                set {
                    raporTuruField = value;
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
        public partial class raporOkuRaporTakipNodanDVO {
            
            private string raporTakipNoField;
            
            private string raporSiraNoField;
            
            private int saglikTesisKoduField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo {
                get {
                    return raporTakipNoField;
                }
                set {
                    raporTakipNoField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporSiraNo {
                get {
                    return raporSiraNoField;
                }
                set {
                    raporSiraNoField = value;
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
        public partial class raporOkuDVO {
            
            private int raporTesisKoduField;
            
            private string tarihField;
            
            private string noField;
            
            private string turuField;
            
            private string raporSiraNoField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int raporTesisKodu {
                get {
                    return raporTesisKoduField;
                }
                set {
                    raporTesisKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tarih {
                get {
                    return tarihField;
                }
                set {
                    tarihField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string no {
                get {
                    return noField;
                }
                set {
                    noField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string turu {
                get {
                    return turuField;
                }
                set {
                    turuField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporSiraNo {
                get {
                    return raporSiraNoField;
                }
                set {
                    raporSiraNoField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class raporSorguDVO {
            
            private int saglikTesisKoduField;
            
            private raporOkuDVO raporBilgisiField;
            
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
            public raporOkuDVO raporBilgisi {
                get {
                    return raporBilgisiField;
                }
                set {
                    raporBilgisiField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class teshisBilgisiDVO {
            
            private int teshisKoduField;
            
            private string baslangicTarihiField;
            
            private string bitisTarihiField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int teshisKodu {
                get {
                    return teshisKoduField;
                }
                set {
                    teshisKoduField = value;
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
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com")]
        public partial class hakSahibiBilgisiDVO {
            
            private string tckimlikNoField;
            
            private string karneNoField;
            
            private string sosyalGuvenlikNoField;
            
            private string yakinlikKoduField;
            
            private string sigortaliTuruField;
            
            private string devredilenKurumField;
            
            private string provizyonTipiField;
            
            private string provizyonTarihiField;
            
            private string adiField;
            
            private string soyadiField;
            
            private string adresField;
            
            private string telefonField;
            
            private string bagliBulunanBirimField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string tckimlikNo {
                get {
                    return tckimlikNoField;
                }
                set {
                    tckimlikNoField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string karneNo {
                get {
                    return karneNoField;
                }
                set {
                    karneNoField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string sosyalGuvenlikNo {
                get {
                    return sosyalGuvenlikNoField;
                }
                set {
                    sosyalGuvenlikNoField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string yakinlikKodu {
                get {
                    return yakinlikKoduField;
                }
                set {
                    yakinlikKoduField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string sigortaliTuru {
                get {
                    return sigortaliTuruField;
                }
                set {
                    sigortaliTuruField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string devredilenKurum {
                get {
                    return devredilenKurumField;
                }
                set {
                    devredilenKurumField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string provizyonTipi {
                get {
                    return provizyonTipiField;
                }
                set {
                    provizyonTipiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string provizyonTarihi {
                get {
                    return provizyonTarihiField;
                }
                set {
                    provizyonTarihiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string adi {
                get {
                    return adiField;
                }
                set {
                    adiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string soyadi {
                get {
                    return soyadiField;
                }
                set {
                    soyadiField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string adres {
                get {
                    return adresField;
                }
                set {
                    adresField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string telefon {
                get {
                    return telefonField;
                }
                set {
                    telefonField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
            public string bagliBulunanBirim {
                get {
                    return bagliBulunanBirimField;
                }
                set {
                    bagliBulunanBirimField = value;
                }
            }
        }
        
#endregion Methods

    }
}