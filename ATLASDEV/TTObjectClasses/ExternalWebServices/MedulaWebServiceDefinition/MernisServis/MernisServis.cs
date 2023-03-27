
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
    public  partial class MernisServis : TTObject
    {
        
                    
#region Methods
        [System.SerializableAttribute()]
        public class SorguPaket
        {
            private bool tcNoSpecified;
            private long tcNo;
           
           
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public bool TcNoSpecified {
                get {
                    return tcNoSpecified;
                }
                set {
                    tcNoSpecified = value;
                }
            }
            
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long TcNo {
                get {
                    return tcNo;
                }
                set {
                    tcNo = value;
                }
            }
        }
        
        public class TCKimlikPaket
        {
            private string ad;
            private long tCKimlikNo;
            private string soyad;
            private int dogumYili;
            
            public TCKimlikPaket() {        }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string Ad {
                get {
                    return ad;
                }
                set {
                    ad = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long TCKimlikNo {
                get {
                    return tCKimlikNo;
                }
                set {
                    tCKimlikNo = value;
                }
            }
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int DogumYili {
                get {
                    return dogumYili;
                }
                set {
                    dogumYili = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string Soyad {
                get {
                    return soyad;
                }
                set {
                    soyad = value;
                }
            }
        }
        
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KPSServisSonucuArrayOfIl {
        
        private string hataField;
        
        private Il[] sonucField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Hata {
            get {
                return hataField;
            }
            set {
                hataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        public Il[] Sonuc {
            get {
                return sonucField;
            }
            set {
                sonucField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class Il {
        
        private string adField;
        
        private string kodField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Ad {
            get {
                return adField;
            }
            set {
                adField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Kod {
            get {
                return kodField;
            }
            set {
                kodField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KPSServisSonucuAdresTipi {
        
        private string hataField;
        
        private AdresTipi sonucField;
        
        private bool sonucFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Hata {
            get {
                return hataField;
            }
            set {
                hataField = value;
            }
        }
        
        /// <remarks/>
        public AdresTipi Sonuc {
            get {
                return sonucField;
            }
            set {
                sonucField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SonucSpecified {
            get {
                return sonucFieldSpecified;
            }
            set {
                sonucFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public enum AdresTipi {
        
        /// <remarks/>
        Tanimsiz,
        
        /// <remarks/>
        Koy,
        
        /// <remarks/>
        Belde,
        
        /// <remarks/>
        IlceMerkezi,
        
        /// <remarks/>
        YurtDisi,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KisiAdresBilgisi {
        
        private System.Nullable<long> adresNoField;
        
        private bool adresNoFieldSpecified;
        
        private AdresTipi adresTipiField;
        
        private bool adresTipiFieldSpecified;
        
        private string binaAdaField;
        
        private string binaBlokAdiField;
        
        private string binaKoduField;
        
        private string binaNoField;
        
        private string binaPaftaField;
        
        private string binaParselField;
        
        private string binaSiteAdiField;
        
        private string bucakField;
        
        private string bucakKoduField;
        
        private string csbmField;
        
        private string csbmKoduField;
        
        private string disKapiNoField;
        
        private string disTemsDuzeltmeBeyanTarihField;
        
        private string disTemsDuzeltmeKararTarihField;
        
        private string disTemsDuzeltmeNedenField;
        
        private string disTemsilcilikField;
        
        private string hataField;
        
        private string hataBilgisiField;
        
        private string icKapiNoField;
        
        private string ilField;
        
        private string ilKoduField;
        
        private string ilceField;
        
        private string ilceKoduField;
        
        private string koyField;
        
        private string koyKayitNoField;
        
        private string koyKoduField;
        
        private string mahalleField;
        
        private string mahalleKoduField;
        
        private string yabanciAdresField;
        
        private string yabanciSehirField;
        
        private string yabanciUlkeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<long> AdresNo {
            get {
                return adresNoField;
            }
            set {
                adresNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AdresNoSpecified {
            get {
                return adresNoFieldSpecified;
            }
            set {
                adresNoFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public AdresTipi AdresTipi {
            get {
                return adresTipiField;
            }
            set {
                adresTipiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AdresTipiSpecified {
            get {
                return adresTipiFieldSpecified;
            }
            set {
                adresTipiFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BinaAda {
            get {
                return binaAdaField;
            }
            set {
                binaAdaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BinaBlokAdi {
            get {
                return binaBlokAdiField;
            }
            set {
                binaBlokAdiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BinaKodu {
            get {
                return binaKoduField;
            }
            set {
                binaKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BinaNo {
            get {
                return binaNoField;
            }
            set {
                binaNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BinaPafta {
            get {
                return binaPaftaField;
            }
            set {
                binaPaftaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BinaParsel {
            get {
                return binaParselField;
            }
            set {
                binaParselField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BinaSiteAdi {
            get {
                return binaSiteAdiField;
            }
            set {
                binaSiteAdiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Bucak {
            get {
                return bucakField;
            }
            set {
                bucakField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BucakKodu {
            get {
                return bucakKoduField;
            }
            set {
                bucakKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Csbm {
            get {
                return csbmField;
            }
            set {
                csbmField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CsbmKodu {
            get {
                return csbmKoduField;
            }
            set {
                csbmKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DisKapiNo {
            get {
                return disKapiNoField;
            }
            set {
                disKapiNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DisTemsDuzeltmeBeyanTarih {
            get {
                return disTemsDuzeltmeBeyanTarihField;
            }
            set {
                disTemsDuzeltmeBeyanTarihField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DisTemsDuzeltmeKararTarih {
            get {
                return disTemsDuzeltmeKararTarihField;
            }
            set {
                disTemsDuzeltmeKararTarihField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DisTemsDuzeltmeNeden {
            get {
                return disTemsDuzeltmeNedenField;
            }
            set {
                disTemsDuzeltmeNedenField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DisTemsilcilik {
            get {
                return disTemsilcilikField;
            }
            set {
                disTemsilcilikField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Hata {
            get {
                return hataField;
            }
            set {
                hataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string HataBilgisi {
            get {
                return hataBilgisiField;
            }
            set {
                hataBilgisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IcKapiNo {
            get {
                return icKapiNoField;
            }
            set {
                icKapiNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Il {
            get {
                return ilField;
            }
            set {
                ilField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IlKodu {
            get {
                return ilKoduField;
            }
            set {
                ilKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Ilce {
            get {
                return ilceField;
            }
            set {
                ilceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IlceKodu {
            get {
                return ilceKoduField;
            }
            set {
                ilceKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Koy {
            get {
                return koyField;
            }
            set {
                koyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string KoyKayitNo {
            get {
                return koyKayitNoField;
            }
            set {
                koyKayitNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string KoyKodu {
            get {
                return koyKoduField;
            }
            set {
                koyKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Mahalle {
            get {
                return mahalleField;
            }
            set {
                mahalleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string MahalleKodu {
            get {
                return mahalleKoduField;
            }
            set {
                mahalleKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string YabanciAdres {
            get {
                return yabanciAdresField;
            }
            set {
                yabanciAdresField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string YabanciSehir {
            get {
                return yabanciSehirField;
            }
            set {
                yabanciSehirField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string YabanciUlke {
            get {
                return yabanciUlkeField;
            }
            set {
                yabanciUlkeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KPSServisSonucuKisiAdresBilgisi {
        
        private string hataField;
        
        private KisiAdresBilgisi sonucField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Hata {
            get {
                return hataField;
            }
            set {
                hataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public KisiAdresBilgisi Sonuc {
            get {
                return sonucField;
            }
            set {
                sonucField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KayitYeriKodBilgisi {
        
        private string aileSiraNoField;
        
        private string bireySiraNoField;
        
        private string ciltField;
        
        private string ilceField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string AileSiraNo {
            get {
                return aileSiraNoField;
            }
            set {
                aileSiraNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BireySiraNo {
            get {
                return bireySiraNoField;
            }
            set {
                bireySiraNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Cilt {
            get {
                return ciltField;
            }
            set {
                ciltField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Ilce {
            get {
                return ilceField;
            }
            set {
                ilceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class NufusKayitOrnegiOlay {
        
        private string adField;
        
        private string dusunceField;
        
        private string hataBilgisiField;
        
        private KayitYeriKodBilgisi kayitYeriField;
        
        private string olayTarihField;
        
        private string olayTipiField;
        
        private string soyadField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Ad {
            get {
                return adField;
            }
            set {
                adField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Dusunce {
            get {
                return dusunceField;
            }
            set {
                dusunceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string HataBilgisi {
            get {
                return hataBilgisiField;
            }
            set {
                hataBilgisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public KayitYeriKodBilgisi KayitYeri {
            get {
                return kayitYeriField;
            }
            set {
                kayitYeriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string OlayTarih {
            get {
                return olayTarihField;
            }
            set {
                olayTarihField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string OlayTipi {
            get {
                return olayTipiField;
            }
            set {
                olayTipiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Soyad {
            get {
                return soyadField;
            }
            set {
                soyadField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class NufusKayitOrnegi {
        
        private KisiTemelBilgisi[] kisilerField;
        
        private NufusKayitOrnegiOlay[] olaylarField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        public KisiTemelBilgisi[] Kisiler {
            get {
                return kisilerField;
            }
            set {
                kisilerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        public NufusKayitOrnegiOlay[] Olaylar {
            get {
                return olaylarField;
            }
            set {
                olaylarField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(KisiCuzdanBilgisi))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KisiTemelBilgisi {
        
        private string adField;
        
        private string aileSiraNoField;
        
        private string anaAdField;
        
        private string babaAdField;
        
        private string bireySiraNoField;
        
        private string ciltAdField;
        
        private string ciltKodField;
        
        private string cinsiyetField;
        
        private string dinField;
        
        private string dogumTarihiField;
        
        private string dogumYerField;
        
        private string durumField;
        
        private string hataField;
        
        private string ilAdField;
        
        private string ilKodField;
        
        private string ilceAdField;
        
        private string ilceKodField;
        
        private string medeniHalField;
        
        private NufusKayitOrnegiOlayTarihBilgisi olayTarihBilgileriField;
        
        private string olumTarihField;
        
        private string soyadField;
        
        private string tCKimlikNoField;
        
        private string yakinlikField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Ad {
            get {
                return adField;
            }
            set {
                adField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string AileSiraNo {
            get {
                return aileSiraNoField;
            }
            set {
                aileSiraNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string AnaAd {
            get {
                return anaAdField;
            }
            set {
                anaAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BabaAd {
            get {
                return babaAdField;
            }
            set {
                babaAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BireySiraNo {
            get {
                return bireySiraNoField;
            }
            set {
                bireySiraNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CiltAd {
            get {
                return ciltAdField;
            }
            set {
                ciltAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CiltKod {
            get {
                return ciltKodField;
            }
            set {
                ciltKodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Cinsiyet {
            get {
                return cinsiyetField;
            }
            set {
                cinsiyetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Din {
            get {
                return dinField;
            }
            set {
                dinField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DogumTarihi {
            get {
                return dogumTarihiField;
            }
            set {
                dogumTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DogumYer {
            get {
                return dogumYerField;
            }
            set {
                dogumYerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Durum {
            get {
                return durumField;
            }
            set {
                durumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Hata {
            get {
                return hataField;
            }
            set {
                hataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IlAd {
            get {
                return ilAdField;
            }
            set {
                ilAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IlKod {
            get {
                return ilKodField;
            }
            set {
                ilKodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IlceAd {
            get {
                return ilceAdField;
            }
            set {
                ilceAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IlceKod {
            get {
                return ilceKodField;
            }
            set {
                ilceKodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string MedeniHal {
            get {
                return medeniHalField;
            }
            set {
                medeniHalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public NufusKayitOrnegiOlayTarihBilgisi OlayTarihBilgileri {
            get {
                return olayTarihBilgileriField;
            }
            set {
                olayTarihBilgileriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string OlumTarih {
            get {
                return olumTarihField;
            }
            set {
                olumTarihField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Soyad {
            get {
                return soyadField;
            }
            set {
                soyadField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string TCKimlikNo {
            get {
                return tCKimlikNoField;
            }
            set {
                tCKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Yakinlik {
            get {
                return yakinlikField;
            }
            set {
                yakinlikField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class NufusKayitOrnegiOlayTarihBilgisi {
        
        private string bosanmaTarihiField;
        
        private string evlenmeTarihiField;
        
        private string hataBilgisiField;
        
        private string tescilTarihiField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BosanmaTarihi {
            get {
                return bosanmaTarihiField;
            }
            set {
                bosanmaTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string EvlenmeTarihi {
            get {
                return evlenmeTarihiField;
            }
            set {
                evlenmeTarihiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string HataBilgisi {
            get {
                return hataBilgisiField;
            }
            set {
                hataBilgisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string TescilTarihi {
            get {
                return tescilTarihiField;
            }
            set {
                tescilTarihiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KisiCuzdanBilgisi : KisiTemelBilgisi {
        
        private string cuzdanNoField;
        
        private string cuzdanSeriField;
        
        private string verildigiIlceAdField;
        
        private string verildigiIlceKodField;
        
        private string verilmeNedenField;
        
        private string verilmeTarihField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CuzdanNo {
            get {
                return cuzdanNoField;
            }
            set {
                cuzdanNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CuzdanSeri {
            get {
                return cuzdanSeriField;
            }
            set {
                cuzdanSeriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string VerildigiIlceAd {
            get {
                return verildigiIlceAdField;
            }
            set {
                verildigiIlceAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string VerildigiIlceKod {
            get {
                return verildigiIlceKodField;
            }
            set {
                verildigiIlceKodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string VerilmeNeden {
            get {
                return verilmeNedenField;
            }
            set {
                verilmeNedenField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string VerilmeTarih {
            get {
                return verilmeTarihField;
            }
            set {
                verilmeTarihField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KPSServisSonucuNufusKayitOrnegi {
        
        private string hataField;
        
        private NufusKayitOrnegi sonucField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Hata {
            get {
                return hataField;
            }
            set {
                hataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public NufusKayitOrnegi Sonuc {
            get {
                return sonucField;
            }
            set {
                sonucField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class YabanciKisiBilgisi {
        
        private string adField;
        
        private string anneAdField;
        
        private string anneEgmSahisIdField;
        
        private string anneKimlikNoField;
        
        private string babaAdField;
        
        private string babaEgmSahisIdField;
        
        private string babaKimlikNoField;
        
        private string cinsiyetField;
        
        private string dogumTarihField;
        
        private string dogumYerField;
        
        private string dogumYilField;
        
        private string durumField;
        
        private string egmSahisIdField;
        
        private string esEgmSahisIdField;
        
        private string esKimlikNoField;
        
        private string hataField;
        
        private string hataBilgisiField;
        
        private string ikametAdresField;
        
        private string ikametAdresIlField;
        
        private string ikametAdresIlKodField;
        
        private string ikametAdresIlceField;
        
        private string ikametDuzenleIlField;
        
        private string ikametSureField;
        
        private string ikametTezkereNoField;
        
        private string izinBaslangicTarihField;
        
        private string kimlikNoField;
        
        private string medeniHalField;
        
        private string soyadField;
        
        private string ulkeField;
        
        private string ulkeKodField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Ad {
            get {
                return adField;
            }
            set {
                adField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string AnneAd {
            get {
                return anneAdField;
            }
            set {
                anneAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string AnneEgmSahisId {
            get {
                return anneEgmSahisIdField;
            }
            set {
                anneEgmSahisIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string AnneKimlikNo {
            get {
                return anneKimlikNoField;
            }
            set {
                anneKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BabaAd {
            get {
                return babaAdField;
            }
            set {
                babaAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BabaEgmSahisId {
            get {
                return babaEgmSahisIdField;
            }
            set {
                babaEgmSahisIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string BabaKimlikNo {
            get {
                return babaKimlikNoField;
            }
            set {
                babaKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Cinsiyet {
            get {
                return cinsiyetField;
            }
            set {
                cinsiyetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DogumTarih {
            get {
                return dogumTarihField;
            }
            set {
                dogumTarihField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DogumYer {
            get {
                return dogumYerField;
            }
            set {
                dogumYerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DogumYil {
            get {
                return dogumYilField;
            }
            set {
                dogumYilField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Durum {
            get {
                return durumField;
            }
            set {
                durumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string EgmSahisId {
            get {
                return egmSahisIdField;
            }
            set {
                egmSahisIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string EsEgmSahisId {
            get {
                return esEgmSahisIdField;
            }
            set {
                esEgmSahisIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string EsKimlikNo {
            get {
                return esKimlikNoField;
            }
            set {
                esKimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Hata {
            get {
                return hataField;
            }
            set {
                hataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string HataBilgisi {
            get {
                return hataBilgisiField;
            }
            set {
                hataBilgisiField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IkametAdres {
            get {
                return ikametAdresField;
            }
            set {
                ikametAdresField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IkametAdresIl {
            get {
                return ikametAdresIlField;
            }
            set {
                ikametAdresIlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IkametAdresIlKod {
            get {
                return ikametAdresIlKodField;
            }
            set {
                ikametAdresIlKodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IkametAdresIlce {
            get {
                return ikametAdresIlceField;
            }
            set {
                ikametAdresIlceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IkametDuzenleIl {
            get {
                return ikametDuzenleIlField;
            }
            set {
                ikametDuzenleIlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IkametSure {
            get {
                return ikametSureField;
            }
            set {
                ikametSureField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IkametTezkereNo {
            get {
                return ikametTezkereNoField;
            }
            set {
                ikametTezkereNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IzinBaslangicTarih {
            get {
                return izinBaslangicTarihField;
            }
            set {
                izinBaslangicTarihField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string KimlikNo {
            get {
                return kimlikNoField;
            }
            set {
                kimlikNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string MedeniHal {
            get {
                return medeniHalField;
            }
            set {
                medeniHalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Soyad {
            get {
                return soyadField;
            }
            set {
                soyadField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Ulke {
            get {
                return ulkeField;
            }
            set {
                ulkeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string UlkeKod {
            get {
                return ulkeKodField;
            }
            set {
                ulkeKodField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KPSServisSonucuYabanciKisiBilgisi {
        
        private string hataField;
        
        private YabanciKisiBilgisi sonucField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Hata {
            get {
                return hataField;
            }
            set {
                hataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public YabanciKisiBilgisi Sonuc {
            get {
                return sonucField;
            }
            set {
                sonucField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KPSServisSonucuKisiCuzdanBilgisi {
        
        private string hataField;
        
        private KisiCuzdanBilgisi sonucField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Hata {
            get {
                return hataField;
            }
            set {
                hataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public KisiCuzdanBilgisi Sonuc {
            get {
                return sonucField;
            }
            set {
                sonucField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KPSServisSonucuArrayOfKisiTemelBilgisi {
        
        private string hataField;
        
        private KisiTemelBilgisi[] sonucField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Hata {
            get {
                return hataField;
            }
            set {
                hataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        public KisiTemelBilgisi[] Sonuc {
            get {
                return sonucField;
            }
            set {
                sonucField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KPSServisSonucuKisiTemelBilgisi {
        
        private string hataField;
        
        private KisiTemelBilgisi sonucField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Hata {
            get {
                return hataField;
            }
            set {
                hataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public KisiTemelBilgisi Sonuc {
            get {
                return sonucField;
            }
            set {
                sonucField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class Ilce {
        
        private string adField;
        
        private string ilKodField;
        
        private string kodField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Ad {
            get {
                return adField;
            }
            set {
                adField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IlKod {
            get {
                return ilKodField;
            }
            set {
                ilKodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Kod {
            get {
                return kodField;
            }
            set {
                kodField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xxxxxx.com/KPS/2011")]
    public partial class KPSServisSonucuArrayOfIlce {
        
        private string hataField;
        
        private Ilce[] sonucField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Hata {
            get {
                return hataField;
            }
            set {
                hataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        public Ilce[] Sonuc {
            get {
                return sonucField;
            }
            set {
                sonucField = value;
            }
        }
    }
        
#endregion Methods

    }
}