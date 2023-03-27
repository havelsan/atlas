
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
    public  partial class HSBSServis : TTObject
    {
        #region Methods
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class USER
        {

            private string adField;

            private int ilField;

            private bool ilFieldSpecified;

            private int ilceField;

            private bool ilceFieldSpecified;

            private int kurumIdField;

            private bool kurumIdFieldSpecified;

            private string sifreField;

            private string soyAdField;

            private long userTCField;

            private bool userTCFieldSpecified;

            private string uygulamaKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string Ad
            {
                get
                {
                    return adField;
                }
                set
                {
                    adField = value;
                }
            }

            /// <remarks/>
            public int Il
            {
                get
                {
                    return ilField;
                }
                set
                {
                    ilField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool IlSpecified
            {
                get
                {
                    return ilFieldSpecified;
                }
                set
                {
                    ilFieldSpecified = value;
                }
            }

            /// <remarks/>
            public int Ilce
            {
                get
                {
                    return ilceField;
                }
                set
                {
                    ilceField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool IlceSpecified
            {
                get
                {
                    return ilceFieldSpecified;
                }
                set
                {
                    ilceFieldSpecified = value;
                }
            }

            /// <remarks/>
            public int KurumId
            {
                get
                {
                    return kurumIdField;
                }
                set
                {
                    kurumIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool KurumIdSpecified
            {
                get
                {
                    return kurumIdFieldSpecified;
                }
                set
                {
                    kurumIdFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string Sifre
            {
                get
                {
                    return sifreField;
                }
                set
                {
                    sifreField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string SoyAd
            {
                get
                {
                    return soyAdField;
                }
                set
                {
                    soyAdField = value;
                }
            }

            /// <remarks/>
            public long UserTC
            {
                get
                {
                    return userTCField;
                }
                set
                {
                    userTCField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool UserTCSpecified
            {
                get
                {
                    return userTCFieldSpecified;
                }
                set
                {
                    userTCFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string UygulamaKodu
            {
                get
                {
                    return uygulamaKoduField;
                }
                set
                {
                    uygulamaKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class Riskli_Gebe_Surec_Durum
        {

            private ISLEMSONUC islemSonucuField;

            private int surec_DurumField;

            private bool surec_DurumFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }

            /// <remarks/>
            public int surec_Durum
            {
                get
                {
                    return surec_DurumField;
                }
                set
                {
                    surec_DurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool surec_DurumSpecified
            {
                get
                {
                    return surec_DurumFieldSpecified;
                }
                set
                {
                    surec_DurumFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class ISLEMSONUC
        {

            private bool basariliField;

            private bool basariliFieldSpecified;

            private string hataField;

            private int hatakoduField;

            private bool hatakoduFieldSpecified;

            /// <remarks/>
            public bool Basarili
            {
                get
                {
                    return basariliField;
                }
                set
                {
                    basariliField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool BasariliSpecified
            {
                get
                {
                    return basariliFieldSpecified;
                }
                set
                {
                    basariliFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string Hata
            {
                get
                {
                    return hataField;
                }
                set
                {
                    hataField = value;
                }
            }

            /// <remarks/>
            public int Hatakodu
            {
                get
                {
                    return hatakoduField;
                }
                set
                {
                    hatakoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool HatakoduSpecified
            {
                get
                {
                    return hatakoduFieldSpecified;
                }
                set
                {
                    hatakoduFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class ASM_AHB_STOK_CIKIS
        {

            private long hastaKimlikNoField;

            private bool hastaKimlikNoFieldSpecified;

            private int stokCikisMiktariField;

            private bool stokCikisMiktariFieldSpecified;

            private enStokCikisTuru stokCikisTuruField;

            private bool stokCikisTuruFieldSpecified;

            private string stokCikisiAciklamaField;

            private System.DateTime stokCikisiTarihiField;

            private bool stokCikisiTarihiFieldSpecified;

            private string stokCikisiYapanKurumAdField;

            private int stokCikisiYapanKurumIdField;

            private bool stokCikisiYapanKurumIdFieldSpecified;

            private STOK_KART stokKartiField;

            /// <remarks/>
            public long HastaKimlikNo
            {
                get
                {
                    return hastaKimlikNoField;
                }
                set
                {
                    hastaKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool HastaKimlikNoSpecified
            {
                get
                {
                    return hastaKimlikNoFieldSpecified;
                }
                set
                {
                    hastaKimlikNoFieldSpecified = value;
                }
            }

            /// <remarks/>
            public int StokCikisMiktari
            {
                get
                {
                    return stokCikisMiktariField;
                }
                set
                {
                    stokCikisMiktariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisMiktariSpecified
            {
                get
                {
                    return stokCikisMiktariFieldSpecified;
                }
                set
                {
                    stokCikisMiktariFieldSpecified = value;
                }
            }

            /// <remarks/>
            public enStokCikisTuru StokCikisTuru
            {
                get
                {
                    return stokCikisTuruField;
                }
                set
                {
                    stokCikisTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisTuruSpecified
            {
                get
                {
                    return stokCikisTuruFieldSpecified;
                }
                set
                {
                    stokCikisTuruFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokCikisiAciklama
            {
                get
                {
                    return stokCikisiAciklamaField;
                }
                set
                {
                    stokCikisiAciklamaField = value;
                }
            }

            /// <remarks/>
            public System.DateTime StokCikisiTarihi
            {
                get
                {
                    return stokCikisiTarihiField;
                }
                set
                {
                    stokCikisiTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisiTarihiSpecified
            {
                get
                {
                    return stokCikisiTarihiFieldSpecified;
                }
                set
                {
                    stokCikisiTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokCikisiYapanKurumAd
            {
                get
                {
                    return stokCikisiYapanKurumAdField;
                }
                set
                {
                    stokCikisiYapanKurumAdField = value;
                }
            }

            /// <remarks/>
            public int StokCikisiYapanKurumId
            {
                get
                {
                    return stokCikisiYapanKurumIdField;
                }
                set
                {
                    stokCikisiYapanKurumIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisiYapanKurumIdSpecified
            {
                get
                {
                    return stokCikisiYapanKurumIdFieldSpecified;
                }
                set
                {
                    stokCikisiYapanKurumIdFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public STOK_KART StokKarti
            {
                get
                {
                    return stokKartiField;
                }
                set
                {
                    stokKartiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public enum enStokCikisTuru
        {

            /// <remarks/>
            Normal,

            /// <remarks/>
            Zayi,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class STOK_KART
        {

            private int ahbKritikStokSeviyesiField;

            private bool ahbKritikStokSeviyesiFieldSpecified;

            private int asmMininmumStokSeviyesiField;

            private bool asmMininmumStokSeviyesiFieldSpecified;

            private string stokAdiField;

            private STOK_GRUP stokGrupField;

            private string stokKoduField;

            private string stokMKYSKoduField;

            /// <remarks/>
            public int AhbKritikStokSeviyesi
            {
                get
                {
                    return ahbKritikStokSeviyesiField;
                }
                set
                {
                    ahbKritikStokSeviyesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool AhbKritikStokSeviyesiSpecified
            {
                get
                {
                    return ahbKritikStokSeviyesiFieldSpecified;
                }
                set
                {
                    ahbKritikStokSeviyesiFieldSpecified = value;
                }
            }

            /// <remarks/>
            public int AsmMininmumStokSeviyesi
            {
                get
                {
                    return asmMininmumStokSeviyesiField;
                }
                set
                {
                    asmMininmumStokSeviyesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool AsmMininmumStokSeviyesiSpecified
            {
                get
                {
                    return asmMininmumStokSeviyesiFieldSpecified;
                }
                set
                {
                    asmMininmumStokSeviyesiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokAdi
            {
                get
                {
                    return stokAdiField;
                }
                set
                {
                    stokAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public STOK_GRUP StokGrup
            {
                get
                {
                    return stokGrupField;
                }
                set
                {
                    stokGrupField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokKodu
            {
                get
                {
                    return stokKoduField;
                }
                set
                {
                    stokKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokMKYSKodu
            {
                get
                {
                    return stokMKYSKoduField;
                }
                set
                {
                    stokMKYSKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class STOK_GRUP
        {

            private string stokGrupAdiField;

            private string stokGrupKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokGrupAdi
            {
                get
                {
                    return stokGrupAdiField;
                }
                set
                {
                    stokGrupAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokGrupKodu
            {
                get
                {
                    return stokGrupKoduField;
                }
                set
                {
                    stokGrupKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class STOK_CIKIS_LISTESI
        {

            private ASM_AHB_STOK_CIKIS[] cikisYapilanStokField;

            private ISLEMSONUC islemSonucuField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
            public ASM_AHB_STOK_CIKIS[] CikisYapilanStok
            {
                get
                {
                    return cikisYapilanStokField;
                }
                set
                {
                    cikisYapilanStokField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class STOK_BILGISI
        {

            private int asmCkysKoduField;

            private bool asmCkysKoduFieldSpecified;

            private long hastaKimlikNoField;

            private bool hastaKimlikNoFieldSpecified;

            private int stokCikisMiktariField;

            private bool stokCikisMiktariFieldSpecified;

            private enStokCikisTuru stokCikisTuruField;

            private bool stokCikisTuruFieldSpecified;

            private string stokCikisiAciklamaField;

            private System.DateTime stokCikisiTarihiField;

            private bool stokCikisiTarihiFieldSpecified;

            private string stokKoduField;

            /// <remarks/>
            public int AsmCkysKodu
            {
                get
                {
                    return asmCkysKoduField;
                }
                set
                {
                    asmCkysKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool AsmCkysKoduSpecified
            {
                get
                {
                    return asmCkysKoduFieldSpecified;
                }
                set
                {
                    asmCkysKoduFieldSpecified = value;
                }
            }

            /// <remarks/>
            public long HastaKimlikNo
            {
                get
                {
                    return hastaKimlikNoField;
                }
                set
                {
                    hastaKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool HastaKimlikNoSpecified
            {
                get
                {
                    return hastaKimlikNoFieldSpecified;
                }
                set
                {
                    hastaKimlikNoFieldSpecified = value;
                }
            }

            /// <remarks/>
            public int StokCikisMiktari
            {
                get
                {
                    return stokCikisMiktariField;
                }
                set
                {
                    stokCikisMiktariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisMiktariSpecified
            {
                get
                {
                    return stokCikisMiktariFieldSpecified;
                }
                set
                {
                    stokCikisMiktariFieldSpecified = value;
                }
            }

            /// <remarks/>
            public enStokCikisTuru StokCikisTuru
            {
                get
                {
                    return stokCikisTuruField;
                }
                set
                {
                    stokCikisTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisTuruSpecified
            {
                get
                {
                    return stokCikisTuruFieldSpecified;
                }
                set
                {
                    stokCikisTuruFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokCikisiAciklama
            {
                get
                {
                    return stokCikisiAciklamaField;
                }
                set
                {
                    stokCikisiAciklamaField = value;
                }
            }

            /// <remarks/>
            public System.DateTime StokCikisiTarihi
            {
                get
                {
                    return stokCikisiTarihiField;
                }
                set
                {
                    stokCikisiTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisiTarihiSpecified
            {
                get
                {
                    return stokCikisiTarihiFieldSpecified;
                }
                set
                {
                    stokCikisiTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokKodu
            {
                get
                {
                    return stokKoduField;
                }
                set
                {
                    stokKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class ASM_STOK_GIRIS
        {

            private int stokCikisMiktariField;

            private bool stokCikisMiktariFieldSpecified;

            private string stokCikisiAciklamaField;

            private System.DateTime stokCikisiTarihiField;

            private bool stokCikisiTarihiFieldSpecified;

            private string stokCikisiYapanKurumAdField;

            private int stokCikisiYapanKurumIdField;

            private bool stokCikisiYapanKurumIdFieldSpecified;

            private STOK_KART stokKartiField;

            /// <remarks/>
            public int StokCikisMiktari
            {
                get
                {
                    return stokCikisMiktariField;
                }
                set
                {
                    stokCikisMiktariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisMiktariSpecified
            {
                get
                {
                    return stokCikisMiktariFieldSpecified;
                }
                set
                {
                    stokCikisMiktariFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokCikisiAciklama
            {
                get
                {
                    return stokCikisiAciklamaField;
                }
                set
                {
                    stokCikisiAciklamaField = value;
                }
            }

            /// <remarks/>
            public System.DateTime StokCikisiTarihi
            {
                get
                {
                    return stokCikisiTarihiField;
                }
                set
                {
                    stokCikisiTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisiTarihiSpecified
            {
                get
                {
                    return stokCikisiTarihiFieldSpecified;
                }
                set
                {
                    stokCikisiTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokCikisiYapanKurumAd
            {
                get
                {
                    return stokCikisiYapanKurumAdField;
                }
                set
                {
                    stokCikisiYapanKurumAdField = value;
                }
            }

            /// <remarks/>
            public int StokCikisiYapanKurumId
            {
                get
                {
                    return stokCikisiYapanKurumIdField;
                }
                set
                {
                    stokCikisiYapanKurumIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisiYapanKurumIdSpecified
            {
                get
                {
                    return stokCikisiYapanKurumIdFieldSpecified;
                }
                set
                {
                    stokCikisiYapanKurumIdFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public STOK_KART StokKarti
            {
                get
                {
                    return stokKartiField;
                }
                set
                {
                    stokKartiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class ASM_STOK_GIRIS_LISTESI
        {

            private ASM_STOK_GIRIS[] asmStokGirisListField;

            private ISLEMSONUC islemSonucuField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
            public ASM_STOK_GIRIS[] AsmStokGirisList
            {
                get
                {
                    return asmStokGirisListField;
                }
                set
                {
                    asmStokGirisListField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class AHB_STOK_GIRIS
        {

            private int stokCikisMiktariField;

            private bool stokCikisMiktariFieldSpecified;

            private string stokCikisiAciklamaField;

            private System.DateTime stokCikisiTarihiField;

            private bool stokCikisiTarihiFieldSpecified;

            private string stokCikisiYapanKurumAdField;

            private int stokCikisiYapanKurumIdField;

            private bool stokCikisiYapanKurumIdFieldSpecified;

            private STOK_KART stokKartiField;

            /// <remarks/>
            public int StokCikisMiktari
            {
                get
                {
                    return stokCikisMiktariField;
                }
                set
                {
                    stokCikisMiktariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisMiktariSpecified
            {
                get
                {
                    return stokCikisMiktariFieldSpecified;
                }
                set
                {
                    stokCikisMiktariFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokCikisiAciklama
            {
                get
                {
                    return stokCikisiAciklamaField;
                }
                set
                {
                    stokCikisiAciklamaField = value;
                }
            }

            /// <remarks/>
            public System.DateTime StokCikisiTarihi
            {
                get
                {
                    return stokCikisiTarihiField;
                }
                set
                {
                    stokCikisiTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisiTarihiSpecified
            {
                get
                {
                    return stokCikisiTarihiFieldSpecified;
                }
                set
                {
                    stokCikisiTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string StokCikisiYapanKurumAd
            {
                get
                {
                    return stokCikisiYapanKurumAdField;
                }
                set
                {
                    stokCikisiYapanKurumAdField = value;
                }
            }

            /// <remarks/>
            public int StokCikisiYapanKurumId
            {
                get
                {
                    return stokCikisiYapanKurumIdField;
                }
                set
                {
                    stokCikisiYapanKurumIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool StokCikisiYapanKurumIdSpecified
            {
                get
                {
                    return stokCikisiYapanKurumIdFieldSpecified;
                }
                set
                {
                    stokCikisiYapanKurumIdFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public STOK_KART StokKarti
            {
                get
                {
                    return stokKartiField;
                }
                set
                {
                    stokKartiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class AHB_STOK_GIRIS_LISTESI
        {

            private AHB_STOK_GIRIS[] ahbStokGirisListField;

            private ISLEMSONUC islemSonucuField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
            public AHB_STOK_GIRIS[] AhbStokGirisList
            {
                get
                {
                    return ahbStokGirisListField;
                }
                set
                {
                    ahbStokGirisListField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class STOK_KART_LISTESI
        {

            private ISLEMSONUC islemSonucuField;

            private STOK_KART[] stokKartlariListField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
            public STOK_KART[] StokKartlariList
            {
                get
                {
                    return stokKartlariListField;
                }
                set
                {
                    stokKartlariListField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class STOK_GRUP_LISTESI
        {

            private ISLEMSONUC islemSonucuField;

            private STOK_GRUP[] stokGruplariListField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
            public STOK_GRUP[] StokGruplariList
            {
                get
                {
                    return stokGruplariListField;
                }
                set
                {
                    stokGruplariListField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class SONUC_MISAFIRANNE_TALEPKAYDET
        {

            private ISLEMSONUC islemSonucuField;

            private string talepIdField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }

            /// <remarks/>
            public string TalepId
            {
                get
                {
                    return talepIdField;
                }
                set
                {
                    talepIdField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class MISAFIRANNE_TALEP_BILGISI
        {

            private string hastaOnayDurumuField;

            private long hasta_TCKimlikNoField;

            private bool hasta_TCKimlikNoFieldSpecified;

            private string redNedeniField;

            private System.DateTime sonAdetTarihiField;

            private bool sonAdetTarihiFieldSpecified;

            private string talepNedeniField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string HastaOnayDurumu
            {
                get
                {
                    return hastaOnayDurumuField;
                }
                set
                {
                    hastaOnayDurumuField = value;
                }
            }

            /// <remarks/>
            public long Hasta_TCKimlikNo
            {
                get
                {
                    return hasta_TCKimlikNoField;
                }
                set
                {
                    hasta_TCKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool Hasta_TCKimlikNoSpecified
            {
                get
                {
                    return hasta_TCKimlikNoFieldSpecified;
                }
                set
                {
                    hasta_TCKimlikNoFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string RedNedeni
            {
                get
                {
                    return redNedeniField;
                }
                set
                {
                    redNedeniField = value;
                }
            }

            /// <remarks/>
            public System.DateTime SonAdetTarihi
            {
                get
                {
                    return sonAdetTarihiField;
                }
                set
                {
                    sonAdetTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool SonAdetTarihiSpecified
            {
                get
                {
                    return sonAdetTarihiFieldSpecified;
                }
                set
                {
                    sonAdetTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string TalepNedeni
            {
                get
                {
                    return talepNedeniField;
                }
                set
                {
                    talepNedeniField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class MISAFIR_ANNE_SUREC_DETAY
        {

            private string gercekDogumKurumuField;

            private System.DateTime gercekDogumTarihiField;

            private bool gercekDogumTarihiFieldSpecified;

            private string planlananDogumKurumuField;

            private System.DateTime planlananDogumTarihiField;

            private bool planlananDogumTarihiFieldSpecified;

            private System.DateTime sonAdetTarihiField;

            private bool sonAdetTarihiFieldSpecified;

            private string surecDurumuField;

            private string surecKapanmaNedeniField;

            private string talepEdenKurumField;

            private string talepNedeniField;

            private System.DateTime talepTarihiField;

            private bool talepTarihiFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string GercekDogumKurumu
            {
                get
                {
                    return gercekDogumKurumuField;
                }
                set
                {
                    gercekDogumKurumuField = value;
                }
            }

            /// <remarks/>
            public System.DateTime GercekDogumTarihi
            {
                get
                {
                    return gercekDogumTarihiField;
                }
                set
                {
                    gercekDogumTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool GercekDogumTarihiSpecified
            {
                get
                {
                    return gercekDogumTarihiFieldSpecified;
                }
                set
                {
                    gercekDogumTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string PlanlananDogumKurumu
            {
                get
                {
                    return planlananDogumKurumuField;
                }
                set
                {
                    planlananDogumKurumuField = value;
                }
            }

            /// <remarks/>
            public System.DateTime PlanlananDogumTarihi
            {
                get
                {
                    return planlananDogumTarihiField;
                }
                set
                {
                    planlananDogumTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool PlanlananDogumTarihiSpecified
            {
                get
                {
                    return planlananDogumTarihiFieldSpecified;
                }
                set
                {
                    planlananDogumTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            public System.DateTime SonAdetTarihi
            {
                get
                {
                    return sonAdetTarihiField;
                }
                set
                {
                    sonAdetTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool SonAdetTarihiSpecified
            {
                get
                {
                    return sonAdetTarihiFieldSpecified;
                }
                set
                {
                    sonAdetTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string SurecDurumu
            {
                get
                {
                    return surecDurumuField;
                }
                set
                {
                    surecDurumuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string SurecKapanmaNedeni
            {
                get
                {
                    return surecKapanmaNedeniField;
                }
                set
                {
                    surecKapanmaNedeniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string TalepEdenKurum
            {
                get
                {
                    return talepEdenKurumField;
                }
                set
                {
                    talepEdenKurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string TalepNedeni
            {
                get
                {
                    return talepNedeniField;
                }
                set
                {
                    talepNedeniField = value;
                }
            }

            /// <remarks/>
            public System.DateTime TalepTarihi
            {
                get
                {
                    return talepTarihiField;
                }
                set
                {
                    talepTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool TalepTarihiSpecified
            {
                get
                {
                    return talepTarihiFieldSpecified;
                }
                set
                {
                    talepTarihiFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class MISAFIR_ANNE_SUREC_BILGISI
        {

            private bool acikSurecVarMiField;

            private bool acikSurecVarMiFieldSpecified;

            private ISLEMSONUC islemSonucuField;

            private MISAFIR_ANNE_SUREC_DETAY misafirAnneSurecDetayField;

            /// <remarks/>
            public bool AcikSurecVarMi
            {
                get
                {
                    return acikSurecVarMiField;
                }
                set
                {
                    acikSurecVarMiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool AcikSurecVarMiSpecified
            {
                get
                {
                    return acikSurecVarMiFieldSpecified;
                }
                set
                {
                    acikSurecVarMiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public MISAFIR_ANNE_SUREC_DETAY MisafirAnneSurecDetay
            {
                get
                {
                    return misafirAnneSurecDetayField;
                }
                set
                {
                    misafirAnneSurecDetayField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class OLASI_MISAFIR_ANNE_BILGILERI
        {

            private string adField;

            private System.DateTime sonAdetTarihiField;

            private bool sonAdetTarihiFieldSpecified;

            private string soyadField;

            private long tcKimlikField;

            private bool tcKimlikFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string Ad
            {
                get
                {
                    return adField;
                }
                set
                {
                    adField = value;
                }
            }

            /// <remarks/>
            public System.DateTime SonAdetTarihi
            {
                get
                {
                    return sonAdetTarihiField;
                }
                set
                {
                    sonAdetTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool SonAdetTarihiSpecified
            {
                get
                {
                    return sonAdetTarihiFieldSpecified;
                }
                set
                {
                    sonAdetTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string Soyad
            {
                get
                {
                    return soyadField;
                }
                set
                {
                    soyadField = value;
                }
            }

            /// <remarks/>
            public long TcKimlik
            {
                get
                {
                    return tcKimlikField;
                }
                set
                {
                    tcKimlikField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool TcKimlikSpecified
            {
                get
                {
                    return tcKimlikFieldSpecified;
                }
                set
                {
                    tcKimlikFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class OLASI_MISAFIR_ANNE_LISTESI
        {

            private ISLEMSONUC islemSonucuField;

            private OLASI_MISAFIR_ANNE_BILGILERI[] misafirAnneField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
            public OLASI_MISAFIR_ANNE_BILGILERI[] MisafirAnne
            {
                get
                {
                    return misafirAnneField;
                }
                set
                {
                    misafirAnneField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class HACI_UMRE_ADAYI
        {

            private long tcField;

            private bool tcFieldSpecified;

            /// <remarks/>
            public long TC
            {
                get
                {
                    return tcField;
                }
                set
                {
                    tcField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool TCSpecified
            {
                get
                {
                    return tcFieldSpecified;
                }
                set
                {
                    tcFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class KANSER_MAMOGRAFI_KAYIT_BILGILERI
        {

            private long hastaTCField;

            private bool hastaTCFieldSpecified;

            private System.DateTime istekTarihiField;

            private bool istekTarihiFieldSpecified;

            private string istekYapanKurumAdField;

            private int istekYapanKurumIdField;

            private bool istekYapanKurumIdFieldSpecified;

            private string mamografiSonucuAciklamaField;

            private string mamografiSonucuAdField;

            private int mamografiSonucuKodField;

            private bool mamografiSonucuKodFieldSpecified;

            private System.DateTime sonuclanmaTarihiField;

            private bool sonuclanmaTarihiFieldSpecified;

            /// <remarks/>
            public long HastaTC
            {
                get
                {
                    return hastaTCField;
                }
                set
                {
                    hastaTCField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool HastaTCSpecified
            {
                get
                {
                    return hastaTCFieldSpecified;
                }
                set
                {
                    hastaTCFieldSpecified = value;
                }
            }

            /// <remarks/>
            public System.DateTime IstekTarihi
            {
                get
                {
                    return istekTarihiField;
                }
                set
                {
                    istekTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool IstekTarihiSpecified
            {
                get
                {
                    return istekTarihiFieldSpecified;
                }
                set
                {
                    istekTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string IstekYapanKurumAd
            {
                get
                {
                    return istekYapanKurumAdField;
                }
                set
                {
                    istekYapanKurumAdField = value;
                }
            }

            /// <remarks/>
            public int IstekYapanKurumId
            {
                get
                {
                    return istekYapanKurumIdField;
                }
                set
                {
                    istekYapanKurumIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool IstekYapanKurumIdSpecified
            {
                get
                {
                    return istekYapanKurumIdFieldSpecified;
                }
                set
                {
                    istekYapanKurumIdFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string MamografiSonucuAciklama
            {
                get
                {
                    return mamografiSonucuAciklamaField;
                }
                set
                {
                    mamografiSonucuAciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string MamografiSonucuAd
            {
                get
                {
                    return mamografiSonucuAdField;
                }
                set
                {
                    mamografiSonucuAdField = value;
                }
            }

            /// <remarks/>
            public int MamografiSonucuKod
            {
                get
                {
                    return mamografiSonucuKodField;
                }
                set
                {
                    mamografiSonucuKodField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool MamografiSonucuKodSpecified
            {
                get
                {
                    return mamografiSonucuKodFieldSpecified;
                }
                set
                {
                    mamografiSonucuKodFieldSpecified = value;
                }
            }

            /// <remarks/>
            public System.DateTime SonuclanmaTarihi
            {
                get
                {
                    return sonuclanmaTarihiField;
                }
                set
                {
                    sonuclanmaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool SonuclanmaTarihiSpecified
            {
                get
                {
                    return sonuclanmaTarihiFieldSpecified;
                }
                set
                {
                    sonuclanmaTarihiFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class KANSER_MAMOGRAFI_ISTEK_BILGILERI
        {

            private long hastaTCField;

            private bool hastaTCFieldSpecified;

            private System.DateTime istekTarihiField;

            private bool istekTarihiFieldSpecified;

            private string istekYapanKurumAdField;

            private int istekYapanKurumIdField;

            private bool istekYapanKurumIdFieldSpecified;

            /// <remarks/>
            public long HastaTC
            {
                get
                {
                    return hastaTCField;
                }
                set
                {
                    hastaTCField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool HastaTCSpecified
            {
                get
                {
                    return hastaTCFieldSpecified;
                }
                set
                {
                    hastaTCFieldSpecified = value;
                }
            }

            /// <remarks/>
            public System.DateTime IstekTarihi
            {
                get
                {
                    return istekTarihiField;
                }
                set
                {
                    istekTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool IstekTarihiSpecified
            {
                get
                {
                    return istekTarihiFieldSpecified;
                }
                set
                {
                    istekTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string IstekYapanKurumAd
            {
                get
                {
                    return istekYapanKurumAdField;
                }
                set
                {
                    istekYapanKurumAdField = value;
                }
            }

            /// <remarks/>
            public int IstekYapanKurumId
            {
                get
                {
                    return istekYapanKurumIdField;
                }
                set
                {
                    istekYapanKurumIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool IstekYapanKurumIdSpecified
            {
                get
                {
                    return istekYapanKurumIdFieldSpecified;
                }
                set
                {
                    istekYapanKurumIdFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class KANSER_MAMOGRAFI_ISTEK_LISTESI
        {

            private ISLEMSONUC islemSonucuField;

            private KANSER_MAMOGRAFI_ISTEK_BILGILERI[] istekBilgileriField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
            public KANSER_MAMOGRAFI_ISTEK_BILGILERI[] IstekBilgileri
            {
                get
                {
                    return istekBilgileriField;
                }
                set
                {
                    istekBilgileriField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class KANSER_HEDEFLISTE_BILGILERI
        {

            private long hastaTCField;

            private bool hastaTCFieldSpecified;

            private enKanserTaramaTuru kanserTuruField;

            private bool kanserTuruFieldSpecified;

            /// <remarks/>
            public long HastaTC
            {
                get
                {
                    return hastaTCField;
                }
                set
                {
                    hastaTCField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool HastaTCSpecified
            {
                get
                {
                    return hastaTCFieldSpecified;
                }
                set
                {
                    hastaTCFieldSpecified = value;
                }
            }

            /// <remarks/>
            public enKanserTaramaTuru KanserTuru
            {
                get
                {
                    return kanserTuruField;
                }
                set
                {
                    kanserTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool KanserTuruSpecified
            {
                get
                {
                    return kanserTuruFieldSpecified;
                }
                set
                {
                    kanserTuruFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public enum enKanserTaramaTuru
        {

            /// <remarks/>
            MemeCA,

            /// <remarks/>
            KolerektalCA,

            /// <remarks/>
            ServiksCA,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class KANSER_HEDEFLISTE
        {

            private KANSER_HEDEFLISTE_BILGILERI[] hedefListeField;

            private ISLEMSONUC islemSonucuField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
            public KANSER_HEDEFLISTE_BILGILERI[] HedefListe
            {
                get
                {
                    return hedefListeField;
                }
                set
                {
                    hedefListeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class HIZMET_EMIRLERI
        {

            private EVDESAGLIK_HASTABILGI_HIZMETEMRIKURUM[] hizmetEmriBilgileriField;

            private ISLEMSONUC islemSonucuField;

            private USER userField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
            public EVDESAGLIK_HASTABILGI_HIZMETEMRIKURUM[] HizmetEmriBilgileri
            {
                get
                {
                    return hizmetEmriBilgileriField;
                }
                set
                {
                    hizmetEmriBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public USER User
            {
                get
                {
                    return userField;
                }
                set
                {
                    userField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class EVDESAGLIK_HASTABILGI_HIZMETEMRIKURUM : EVDESAGLIK_HASTABILGILERI
        {

            private string hizmetEmriAtayanKurumAdField;

            private int hizmetEmriAtayanKurumKodField;

            private bool hizmetEmriAtayanKurumKodFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string HizmetEmriAtayanKurumAd
            {
                get
                {
                    return hizmetEmriAtayanKurumAdField;
                }
                set
                {
                    hizmetEmriAtayanKurumAdField = value;
                }
            }

            /// <remarks/>
            public int HizmetEmriAtayanKurumKod
            {
                get
                {
                    return hizmetEmriAtayanKurumKodField;
                }
                set
                {
                    hizmetEmriAtayanKurumKodField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool HizmetEmriAtayanKurumKodSpecified
            {
                get
                {
                    return hizmetEmriAtayanKurumKodFieldSpecified;
                }
                set
                {
                    hizmetEmriAtayanKurumKodFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(EVDESAGLIK_HASTABILGI_HIZMETEMRIKURUM))]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class EVDESAGLIK_HASTABILGILERI
        {

            private int basvuruIdField;

            private bool basvuruIdFieldSpecified;

            private string hastaAdField;

            private string hastaAdresField;

            private string hastaSoyAdField;

            private long hastaTcField;

            private bool hastaTcFieldSpecified;

            private System.DateTime hizmetEmriTarihiField;

            private bool hizmetEmriTarihiFieldSpecified;

            /// <remarks/>
            public int BasvuruId
            {
                get
                {
                    return basvuruIdField;
                }
                set
                {
                    basvuruIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool BasvuruIdSpecified
            {
                get
                {
                    return basvuruIdFieldSpecified;
                }
                set
                {
                    basvuruIdFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string HastaAd
            {
                get
                {
                    return hastaAdField;
                }
                set
                {
                    hastaAdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string HastaAdres
            {
                get
                {
                    return hastaAdresField;
                }
                set
                {
                    hastaAdresField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string HastaSoyAd
            {
                get
                {
                    return hastaSoyAdField;
                }
                set
                {
                    hastaSoyAdField = value;
                }
            }

            /// <remarks/>
            public long HastaTc
            {
                get
                {
                    return hastaTcField;
                }
                set
                {
                    hastaTcField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool HastaTcSpecified
            {
                get
                {
                    return hastaTcFieldSpecified;
                }
                set
                {
                    hastaTcFieldSpecified = value;
                }
            }

            /// <remarks/>
            public System.DateTime HizmetEmriTarihi
            {
                get
                {
                    return hizmetEmriTarihiField;
                }
                set
                {
                    hizmetEmriTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool HizmetEmriTarihiSpecified
            {
                get
                {
                    return hizmetEmriTarihiFieldSpecified;
                }
                set
                {
                    hizmetEmriTarihiFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class SONUC_EVDESAGLIK_ISLEMLER
        {

            private long basvuru_IdField;

            private bool basvuru_IdFieldSpecified;

            private EVDESAGLIK_HASTABILGILERI[] hastaBilgileriField;

            private ISLEMSONUC islemSonucuField;

            /// <remarks/>
            public long Basvuru_Id
            {
                get
                {
                    return basvuru_IdField;
                }
                set
                {
                    basvuru_IdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool Basvuru_IdSpecified
            {
                get
                {
                    return basvuru_IdFieldSpecified;
                }
                set
                {
                    basvuru_IdFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
            public EVDESAGLIK_HASTABILGILERI[] HastaBilgileri
            {
                get
                {
                    return hastaBilgileriField;
                }
                set
                {
                    hastaBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public ISLEMSONUC IslemSonucu
            {
                get
                {
                    return islemSonucuField;
                }
                set
                {
                    islemSonucuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public partial class EVDESAGLIK_BASVURUSU
        {

            private string alinanNotlarField;

            private string basvuranAciklamasiField;

            private string basvuranAdField;

            private string basvuranSoyadField;

            private long basvuranTCField;

            private bool basvuranTCFieldSpecified;

            private long basvuranTelefonField;

            private bool basvuranTelefonFieldSpecified;

            private EVDESAGLIK_HASTABILGILERI hastaBilgileriField;

            private USER userField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string AlinanNotlar
            {
                get
                {
                    return alinanNotlarField;
                }
                set
                {
                    alinanNotlarField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string BasvuranAciklamasi
            {
                get
                {
                    return basvuranAciklamasiField;
                }
                set
                {
                    basvuranAciklamasiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string BasvuranAd
            {
                get
                {
                    return basvuranAdField;
                }
                set
                {
                    basvuranAdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string BasvuranSoyad
            {
                get
                {
                    return basvuranSoyadField;
                }
                set
                {
                    basvuranSoyadField = value;
                }
            }

            /// <remarks/>
            public long BasvuranTC
            {
                get
                {
                    return basvuranTCField;
                }
                set
                {
                    basvuranTCField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool BasvuranTCSpecified
            {
                get
                {
                    return basvuranTCFieldSpecified;
                }
                set
                {
                    basvuranTCFieldSpecified = value;
                }
            }

            /// <remarks/>
            public long BasvuranTelefon
            {
                get
                {
                    return basvuranTelefonField;
                }
                set
                {
                    basvuranTelefonField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool BasvuranTelefonSpecified
            {
                get
                {
                    return basvuranTelefonFieldSpecified;
                }
                set
                {
                    basvuranTelefonFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public EVDESAGLIK_HASTABILGILERI HastaBilgileri
            {
                get
                {
                    return hastaBilgileriField;
                }
                set
                {
                    hastaBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public USER User
            {
                get
                {
                    return userField;
                }
                set
                {
                    userField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/WCF_HSBS_SERVICE")]
        public enum enStokCikisYapanKurumTur
        {

            /// <remarks/>
            AHB,

            /// <remarks/>
            ASM,
        }
        #endregion Methods
    }
}