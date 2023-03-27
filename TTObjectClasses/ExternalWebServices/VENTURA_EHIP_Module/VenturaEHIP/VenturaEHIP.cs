
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
    /// EHİP WEB SERVİS Entegrasyon Nesnesi
    /// </summary>
    public partial class XXXXXXEHIP : TTObject
    {
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class IslemSonuc
        {

            private int etkilenenAdetField;

            private bool islemBasariliField;

            private string mesajField;

            private int kayitIDField;

            /// <remarks/>
            public int EtkilenenAdet
            {
                get
                {
                    return etkilenenAdetField;
                }
                set
                {
                    etkilenenAdetField = value;
                }
            }

            /// <remarks/>
            public bool IslemBasarili
            {
                get
                {
                    return islemBasariliField;
                }
                set
                {
                    islemBasariliField = value;
                }
            }

            /// <remarks/>
            public string Mesaj
            {
                get
                {
                    return mesajField;
                }
                set
                {
                    mesajField = value;
                }
            }

            /// <remarks/>
            public int KayitID
            {
                get
                {
                    return kayitIDField;
                }
                set
                {
                    kayitIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class StokListesiDepoDetayli
        {

            private eDepoTip eDepoTipField;

            private string mkysDepoBirimKayitNoField;

            private string barkodField;

            private int mkysMalzemeIdField;

            private string sonKullanimTarihField;

            private string aciklamaField;

            private decimal depoMiktarField;

            private decimal depoTutarField;

            private string aktarimSonucKodField;

            private string aktarimSonucAciklamaField;

            /// <remarks/>
            public eDepoTip eDepoTip
            {
                get
                {
                    return eDepoTipField;
                }
                set
                {
                    eDepoTipField = value;
                }
            }

            /// <remarks/>
            public string MkysDepoBirimKayitNo
            {
                get
                {
                    return mkysDepoBirimKayitNoField;
                }
                set
                {
                    mkysDepoBirimKayitNoField = value;
                }
            }

            /// <remarks/>
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
            public int MkysMalzemeId
            {
                get
                {
                    return mkysMalzemeIdField;
                }
                set
                {
                    mkysMalzemeIdField = value;
                }
            }

            /// <remarks/>
            public string SonKullanimTarih
            {
                get
                {
                    return sonKullanimTarihField;
                }
                set
                {
                    sonKullanimTarihField = value;
                }
            }

            /// <remarks/>
            public string Aciklama
            {
                get
                {
                    return aciklamaField;
                }
                set
                {
                    aciklamaField = value;
                }
            }

            /// <remarks/>
            public decimal DepoMiktar
            {
                get
                {
                    return depoMiktarField;
                }
                set
                {
                    depoMiktarField = value;
                }
            }

            /// <remarks/>
            public decimal DepoTutar
            {
                get
                {
                    return depoTutarField;
                }
                set
                {
                    depoTutarField = value;
                }
            }

            /// <remarks/>
            public string AktarimSonucKod
            {
                get
                {
                    return aktarimSonucKodField;
                }
                set
                {
                    aktarimSonucKodField = value;
                }
            }

            /// <remarks/>
            public string AktarimSonucAciklama
            {
                get
                {
                    return aktarimSonucAciklamaField;
                }
                set
                {
                    aktarimSonucAciklamaField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum eDepoTip
        {

            /// <remarks/>
            AnaDepo,

            /// <remarks/>
            AraDepo,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class StokGonderimDepoDetayliObje
        {

            private string ehipEntegreKeyField;

            private StokListesiDepoDetayli[] stokListesiField;

            /// <remarks/>
            public string EhipEntegreKey
            {
                get
                {
                    return ehipEntegreKeyField;
                }
                set
                {
                    ehipEntegreKeyField = value;
                }
            }

            /// <remarks/>
            public StokListesiDepoDetayli[] stokListesi
            {
                get
                {
                    return stokListesiField;
                }
                set
                {
                    stokListesiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class StokListesi
        {

            private string barkodField;

            private int mkysMalzemeIdField;

            private string sonKullanimTarihField;

            private string aciklamaField;

            private decimal anaDepoMiktarField;

            private decimal anaDepoTutarField;

            private decimal araDepoMiktarField;

            private decimal araDepoTutarField;

            private string aktarimSonucKodField;

            private string aktarimSonucAciklamaField;

            /// <remarks/>
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
            public int MkysMalzemeId
            {
                get
                {
                    return mkysMalzemeIdField;
                }
                set
                {
                    mkysMalzemeIdField = value;
                }
            }

            /// <remarks/>
            public string SonKullanimTarih
            {
                get
                {
                    return sonKullanimTarihField;
                }
                set
                {
                    sonKullanimTarihField = value;
                }
            }

            /// <remarks/>
            public string Aciklama
            {
                get
                {
                    return aciklamaField;
                }
                set
                {
                    aciklamaField = value;
                }
            }

            /// <remarks/>
            public decimal AnaDepoMiktar
            {
                get
                {
                    return anaDepoMiktarField;
                }
                set
                {
                    anaDepoMiktarField = value;
                }
            }

            /// <remarks/>
            public decimal AnaDepoTutar
            {
                get
                {
                    return anaDepoTutarField;
                }
                set
                {
                    anaDepoTutarField = value;
                }
            }

            /// <remarks/>
            public decimal AraDepoMiktar
            {
                get
                {
                    return araDepoMiktarField;
                }
                set
                {
                    araDepoMiktarField = value;
                }
            }

            /// <remarks/>
            public decimal AraDepoTutar
            {
                get
                {
                    return araDepoTutarField;
                }
                set
                {
                    araDepoTutarField = value;
                }
            }

            /// <remarks/>
            public string AktarimSonucKod
            {
                get
                {
                    return aktarimSonucKodField;
                }
                set
                {
                    aktarimSonucKodField = value;
                }
            }

            /// <remarks/>
            public string AktarimSonucAciklama
            {
                get
                {
                    return aktarimSonucAciklamaField;
                }
                set
                {
                    aktarimSonucAciklamaField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class StokGonderimObje
        {

            private string ehipEntegreKeyField;

            private StokListesi[] stokListesiField;

            /// <remarks/>
            public string EhipEntegreKey
            {
                get
                {
                    return ehipEntegreKeyField;
                }
                set
                {
                    ehipEntegreKeyField = value;
                }
            }

            /// <remarks/>
            public StokListesi[] stokListesi
            {
                get
                {
                    return stokListesiField;
                }
                set
                {
                    stokListesiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class KisiIhaleKomisyonInfo
        {

            private long tcKimlikNoField;

            private string adSoyadField;

            private string unvaniField;

            private string komisyondakiGoreviField;

            private string iknField;

            private string isinAdiField;

            private System.DateTime ihaleTarihSaatField;

            private string ihaleYeriField;

            private string asilYedekField;

            /// <remarks/>
            public long TcKimlikNo
            {
                get
                {
                    return tcKimlikNoField;
                }
                set
                {
                    tcKimlikNoField = value;
                }
            }

            /// <remarks/>
            public string AdSoyad
            {
                get
                {
                    return adSoyadField;
                }
                set
                {
                    adSoyadField = value;
                }
            }

            /// <remarks/>
            public string Unvani
            {
                get
                {
                    return unvaniField;
                }
                set
                {
                    unvaniField = value;
                }
            }

            /// <remarks/>
            public string KomisyondakiGorevi
            {
                get
                {
                    return komisyondakiGoreviField;
                }
                set
                {
                    komisyondakiGoreviField = value;
                }
            }

            /// <remarks/>
            public string Ikn
            {
                get
                {
                    return iknField;
                }
                set
                {
                    iknField = value;
                }
            }

            /// <remarks/>
            public string IsinAdi
            {
                get
                {
                    return isinAdiField;
                }
                set
                {
                    isinAdiField = value;
                }
            }

            /// <remarks/>
            public System.DateTime IhaleTarihSaat
            {
                get
                {
                    return ihaleTarihSaatField;
                }
                set
                {
                    ihaleTarihSaatField = value;
                }
            }

            /// <remarks/>
            public string IhaleYeri
            {
                get
                {
                    return ihaleYeriField;
                }
                set
                {
                    ihaleYeriField = value;
                }
            }

            /// <remarks/>
            public string AsilYedek
            {
                get
                {
                    return asilYedekField;
                }
                set
                {
                    asilYedekField = value;
                }
            }
        }

    }
}