
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
    /// Tasinir Mal WEB SERVİS Entegrasyon Nesnesi
    /// </summary>
    public  partial class XXXXXXTasinirMal : TTObject
    {
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class TalepBildirimInfoWS
        {

            private ETalepTur talepTurIdField;

            private string talepNedeniField;

            private string aciklamaField;

            private System.DateTime talepTarihiField;

            private int mkysDepoKayitNoField;

            private System.Nullable<int> talepEdenBirimMkysKayitNoField;

            private string talepEdenBirimAdiField;

            private long talepKullaniciTCField;

            private System.DateTime karsilanmaTarihiField;

            private int acilField;

            private int hastabasiField;

            private long hastaTCField;

            private string hastaAdSoyadField;

            private string hastaProtokolNoField;

            private System.DateTime ameliyatTarihiField;

            private TalepBildirimDetayInfoWS[] talepMalzemeListesiField;

            /// <remarks/>
            public ETalepTur TalepTurId
            {
                get
                {
                    return talepTurIdField;
                }
                set
                {
                    talepTurIdField = value;
                }
            }

            /// <remarks/>
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
            public int MkysDepoKayitNo
            {
                get
                {
                    return mkysDepoKayitNoField;
                }
                set
                {
                    mkysDepoKayitNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> TalepEdenBirimMkysKayitNo
            {
                get
                {
                    return talepEdenBirimMkysKayitNoField;
                }
                set
                {
                    talepEdenBirimMkysKayitNoField = value;
                }
            }

            /// <remarks/>
            public string TalepEdenBirimAdi
            {
                get
                {
                    return talepEdenBirimAdiField;
                }
                set
                {
                    talepEdenBirimAdiField = value;
                }
            }

            /// <remarks/>
            public long TalepKullaniciTC
            {
                get
                {
                    return talepKullaniciTCField;
                }
                set
                {
                    talepKullaniciTCField = value;
                }
            }

            /// <remarks/>
            public System.DateTime KarsilanmaTarihi
            {
                get
                {
                    return karsilanmaTarihiField;
                }
                set
                {
                    karsilanmaTarihiField = value;
                }
            }

            /// <remarks/>
            public int Acil
            {
                get
                {
                    return acilField;
                }
                set
                {
                    acilField = value;
                }
            }

            /// <remarks/>
            public int Hastabasi
            {
                get
                {
                    return hastabasiField;
                }
                set
                {
                    hastabasiField = value;
                }
            }

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
            public string HastaAdSoyad
            {
                get
                {
                    return hastaAdSoyadField;
                }
                set
                {
                    hastaAdSoyadField = value;
                }
            }

            /// <remarks/>
            public string HastaProtokolNo
            {
                get
                {
                    return hastaProtokolNoField;
                }
                set
                {
                    hastaProtokolNoField = value;
                }
            }

            /// <remarks/>
            public System.DateTime AmeliyatTarihi
            {
                get
                {
                    return ameliyatTarihiField;
                }
                set
                {
                    ameliyatTarihiField = value;
                }
            }

            /// <remarks/>
            public TalepBildirimDetayInfoWS[] TalepMalzemeListesi
            {
                get
                {
                    return talepMalzemeListesiField;
                }
                set
                {
                    talepMalzemeListesiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public enum ETalepTur
        {

            /// <remarks/>
            none,

            /// <remarks/>
            ilac,

            /// <remarks/>
            sarfMalzeme,

            /// <remarks/>
            demirbas,

            /// <remarks/>
            hizmet,

            /// <remarks/>
            diger,

            /// <remarks/>
            yapimOnarim,

            /// <remarks/>
            cihazOnarim,

            /// <remarks/>
            tibbiCihazOnarim,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class TalepBildirimDetayInfoWS
        {

            private int malzemeKayitIdField;

            private System.Nullable<int> redimoStokkartIdField;

            private string sutKoduField;

            private string aciklamaField;

            private double talepMiktarField;

            private string mkysOlcuBirimKoduField;

            /// <remarks/>
            public int MalzemeKayitId
            {
                get
                {
                    return malzemeKayitIdField;
                }
                set
                {
                    malzemeKayitIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> RedimoStokkartId
            {
                get
                {
                    return redimoStokkartIdField;
                }
                set
                {
                    redimoStokkartIdField = value;
                }
            }

            /// <remarks/>
            public string SutKodu
            {
                get
                {
                    return sutKoduField;
                }
                set
                {
                    sutKoduField = value;
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
            public double TalepMiktar
            {
                get
                {
                    return talepMiktarField;
                }
                set
                {
                    talepMiktarField = value;
                }
            }

            /// <remarks/>
            public string MkysOlcuBirimKodu
            {
                get
                {
                    return mkysOlcuBirimKoduField;
                }
                set
                {
                    mkysOlcuBirimKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class HbysStokListesiObje
        {

            private eDepoTip eDepoTipField;

            private string depoIdField;

            private string depoAdField;

            private string barkodField;

            private int mkysMalzemeIdField;

            private string sonKullanimTarihField;

            private string aciklamaField;

            private decimal depoMiktarField;

            private decimal depoTutarField;

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
            public string DepoId
            {
                get
                {
                    return depoIdField;
                }
                set
                {
                    depoIdField = value;
                }
            }

            /// <remarks/>
            public string DepoAd
            {
                get
                {
                    return depoAdField;
                }
                set
                {
                    depoAdField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class HbysStokGonderimObje
        {

            private string ehipEntegreKeyField;

            private HbysStokListesiObje[] stokListesiField;

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
            public HbysStokListesiObje[] stokListesi
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class VenStokIhtiyacTur
        {

            private int stokIhtiyacTurIdField;

            private string stokIhtiyacTurAdiField;

            /// <remarks/>
            public int StokIhtiyacTurId
            {
                get
                {
                    return stokIhtiyacTurIdField;
                }
                set
                {
                    stokIhtiyacTurIdField = value;
                }
            }

            /// <remarks/>
            public string StokIhtiyacTurAdi
            {
                get
                {
                    return stokIhtiyacTurAdiField;
                }
                set
                {
                    stokIhtiyacTurAdiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class VenStokTur
        {

            private int stokTurIdField;

            private string stokTurAdiField;

            /// <remarks/>
            public int StokTurId
            {
                get
                {
                    return stokTurIdField;
                }
                set
                {
                    stokTurIdField = value;
                }
            }

            /// <remarks/>
            public string StokTurAdi
            {
                get
                {
                    return stokTurAdiField;
                }
                set
                {
                    stokTurAdiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class VenStokBirimTur
        {

            private int stokBirimTurIdField;

            private string stokBirimTurAdiField;

            private string mkysBirimKoduField;

            /// <remarks/>
            public int StokBirimTurId
            {
                get
                {
                    return stokBirimTurIdField;
                }
                set
                {
                    stokBirimTurIdField = value;
                }
            }

            /// <remarks/>
            public string StokBirimTurAdi
            {
                get
                {
                    return stokBirimTurAdiField;
                }
                set
                {
                    stokBirimTurAdiField = value;
                }
            }

            /// <remarks/>
            public string MkysBirimKodu
            {
                get
                {
                    return mkysBirimKoduField;
                }
                set
                {
                    mkysBirimKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class WsResult
        {

            private string errorField;

            /// <remarks/>
            public string Error
            {
                get
                {
                    return errorField;
                }
                set
                {
                    errorField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class VenAdvancedStokInfo
        {

            private int redimoStokkartIdField;

            private int malzemeKayitIdField;

            private int stokIhtiyacTurIdField;

            private string depoTurIdField;

            private string depoTurAdiField;

            private int kdvOranField;

            private string malzemeAciklamaField;

            private string stokAdiField;

            private string malzemeKoduField;

            private int stokTurIdField;

            private string stokTurAdiField;

            private string barkodField;

            private string ilacJenerikKoduField;

            private string ilacJenerikAdiField;

            private string sutKoduField;

            private int stokbirimturIdField;

            private string stokbirimturAdiField;

            private string aktifField;

            /// <remarks/>
            public int RedimoStokkartId
            {
                get
                {
                    return redimoStokkartIdField;
                }
                set
                {
                    redimoStokkartIdField = value;
                }
            }

            /// <remarks/>
            public int MalzemeKayitId
            {
                get
                {
                    return malzemeKayitIdField;
                }
                set
                {
                    malzemeKayitIdField = value;
                }
            }

            /// <remarks/>
            public int StokIhtiyacTurId
            {
                get
                {
                    return stokIhtiyacTurIdField;
                }
                set
                {
                    stokIhtiyacTurIdField = value;
                }
            }

            /// <remarks/>
            public string DepoTurId
            {
                get
                {
                    return depoTurIdField;
                }
                set
                {
                    depoTurIdField = value;
                }
            }

            /// <remarks/>
            public string DepoTurAdi
            {
                get
                {
                    return depoTurAdiField;
                }
                set
                {
                    depoTurAdiField = value;
                }
            }

            /// <remarks/>
            public int KdvOran
            {
                get
                {
                    return kdvOranField;
                }
                set
                {
                    kdvOranField = value;
                }
            }

            /// <remarks/>
            public string MalzemeAciklama
            {
                get
                {
                    return malzemeAciklamaField;
                }
                set
                {
                    malzemeAciklamaField = value;
                }
            }

            /// <remarks/>
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
            public string MalzemeKodu
            {
                get
                {
                    return malzemeKoduField;
                }
                set
                {
                    malzemeKoduField = value;
                }
            }

            /// <remarks/>
            public int StokTurId
            {
                get
                {
                    return stokTurIdField;
                }
                set
                {
                    stokTurIdField = value;
                }
            }

            /// <remarks/>
            public string StokTurAdi
            {
                get
                {
                    return stokTurAdiField;
                }
                set
                {
                    stokTurAdiField = value;
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
            public string IlacJenerikKodu
            {
                get
                {
                    return ilacJenerikKoduField;
                }
                set
                {
                    ilacJenerikKoduField = value;
                }
            }

            /// <remarks/>
            public string IlacJenerikAdi
            {
                get
                {
                    return ilacJenerikAdiField;
                }
                set
                {
                    ilacJenerikAdiField = value;
                }
            }

            /// <remarks/>
            public string SutKodu
            {
                get
                {
                    return sutKoduField;
                }
                set
                {
                    sutKoduField = value;
                }
            }

            /// <remarks/>
            public int StokbirimturId
            {
                get
                {
                    return stokbirimturIdField;
                }
                set
                {
                    stokbirimturIdField = value;
                }
            }

            /// <remarks/>
            public string StokbirimturAdi
            {
                get
                {
                    return stokbirimturAdiField;
                }
                set
                {
                    stokbirimturAdiField = value;
                }
            }

            /// <remarks/>
            public string Aktif
            {
                get
                {
                    return aktifField;
                }
                set
                {
                    aktifField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class VenStokInfo
        {

            private int malzemeKayitIdField;

            private int redimoStokkartIdField;

            private string malzemeKoduField;

            private string stokAdiField;

            private string olcuBirimiField;

            private string sutKoduField;

            private string depoTipiField;

            private string aktifField;

            /// <remarks/>
            public int MalzemeKayitId
            {
                get
                {
                    return malzemeKayitIdField;
                }
                set
                {
                    malzemeKayitIdField = value;
                }
            }

            /// <remarks/>
            public int RedimoStokkartId
            {
                get
                {
                    return redimoStokkartIdField;
                }
                set
                {
                    redimoStokkartIdField = value;
                }
            }

            /// <remarks/>
            public string MalzemeKodu
            {
                get
                {
                    return malzemeKoduField;
                }
                set
                {
                    malzemeKoduField = value;
                }
            }

            /// <remarks/>
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
            public string OlcuBirimi
            {
                get
                {
                    return olcuBirimiField;
                }
                set
                {
                    olcuBirimiField = value;
                }
            }

            /// <remarks/>
            public string SutKodu
            {
                get
                {
                    return sutKoduField;
                }
                set
                {
                    sutKoduField = value;
                }
            }

            /// <remarks/>
            public string DepoTipi
            {
                get
                {
                    return depoTipiField;
                }
                set
                {
                    depoTipiField = value;
                }
            }

            /// <remarks/>
            public string Aktif
            {
                get
                {
                    return aktifField;
                }
                set
                {
                    aktifField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class VenStokAramaKriterInfo
        {

            private System.Nullable<int> redimoStokkartIdField;

            private System.Nullable<int> stokIhtiyacTurIdField;

            private string malzemeKoduField;

            private string stokAdiField;

            private string sutKoduField;

            private string depoTipiField;

            private string aktifField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> RedimoStokkartId
            {
                get
                {
                    return redimoStokkartIdField;
                }
                set
                {
                    redimoStokkartIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> StokIhtiyacTurId
            {
                get
                {
                    return stokIhtiyacTurIdField;
                }
                set
                {
                    stokIhtiyacTurIdField = value;
                }
            }

            /// <remarks/>
            public string MalzemeKodu
            {
                get
                {
                    return malzemeKoduField;
                }
                set
                {
                    malzemeKoduField = value;
                }
            }

            /// <remarks/>
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
            public string SutKodu
            {
                get
                {
                    return sutKoduField;
                }
                set
                {
                    sutKoduField = value;
                }
            }

            /// <remarks/>
            public string DepoTipi
            {
                get
                {
                    return depoTipiField;
                }
                set
                {
                    depoTipiField = value;
                }
            }

            /// <remarks/>
            public string Aktif
            {
                get
                {
                    return aktifField;
                }
                set
                {
                    aktifField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class MuayeneKabulCevapInfoWS
        {

            private string mkysDepoKoduField;

            private int satMuayeneKabulIdField;

            private string irsaliyeNoField;

            private string tifNoField;

            private System.DateTime tifTarihiField;

            /// <remarks/>
            public string MkysDepoKodu
            {
                get
                {
                    return mkysDepoKoduField;
                }
                set
                {
                    mkysDepoKoduField = value;
                }
            }

            /// <remarks/>
            public int SatMuayeneKabulId
            {
                get
                {
                    return satMuayeneKabulIdField;
                }
                set
                {
                    satMuayeneKabulIdField = value;
                }
            }

            /// <remarks/>
            public string IrsaliyeNo
            {
                get
                {
                    return irsaliyeNoField;
                }
                set
                {
                    irsaliyeNoField = value;
                }
            }

            /// <remarks/>
            public string TifNo
            {
                get
                {
                    return tifNoField;
                }
                set
                {
                    tifNoField = value;
                }
            }

            /// <remarks/>
            public System.DateTime TifTarihi
            {
                get
                {
                    return tifTarihiField;
                }
                set
                {
                    tifTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class MuayeneKabulKalemInfoWS
        {

            private int satMuayeneKabulIdField;

            private int malzemeKayitIdField;

            private int redimoStokkartIdField;

            private string barkodField;

            private string stokKoduField;

            private string lotNoField;

            private string malzemeAdiField;

            private string malzemeAciklamaField;

            private string olcuBirimiField;

            private double miktarField;

            private double alisFiyatiField;

            private double indirimTutarField;

            private int indirimOraniField;

            private int stokbirimturIdField;

            private string stokTuruField;

            private int kdvOranField;

            private double tutarField;

            private double kdvTutarField;

            private System.DateTime sonKullanmaTarihiField;

            /// <remarks/>
            public int SatMuayeneKabulId
            {
                get
                {
                    return satMuayeneKabulIdField;
                }
                set
                {
                    satMuayeneKabulIdField = value;
                }
            }

            /// <remarks/>
            public int MalzemeKayitId
            {
                get
                {
                    return malzemeKayitIdField;
                }
                set
                {
                    malzemeKayitIdField = value;
                }
            }

            /// <remarks/>
            public int RedimoStokkartId
            {
                get
                {
                    return redimoStokkartIdField;
                }
                set
                {
                    redimoStokkartIdField = value;
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
            public string LotNo
            {
                get
                {
                    return lotNoField;
                }
                set
                {
                    lotNoField = value;
                }
            }

            /// <remarks/>
            public string MalzemeAdi
            {
                get
                {
                    return malzemeAdiField;
                }
                set
                {
                    malzemeAdiField = value;
                }
            }

            /// <remarks/>
            public string MalzemeAciklama
            {
                get
                {
                    return malzemeAciklamaField;
                }
                set
                {
                    malzemeAciklamaField = value;
                }
            }

            /// <remarks/>
            public string OlcuBirimi
            {
                get
                {
                    return olcuBirimiField;
                }
                set
                {
                    olcuBirimiField = value;
                }
            }

            /// <remarks/>
            public double Miktar
            {
                get
                {
                    return miktarField;
                }
                set
                {
                    miktarField = value;
                }
            }

            /// <remarks/>
            public double AlisFiyati
            {
                get
                {
                    return alisFiyatiField;
                }
                set
                {
                    alisFiyatiField = value;
                }
            }

            /// <remarks/>
            public double IndirimTutar
            {
                get
                {
                    return indirimTutarField;
                }
                set
                {
                    indirimTutarField = value;
                }
            }

            /// <remarks/>
            public int IndirimOrani
            {
                get
                {
                    return indirimOraniField;
                }
                set
                {
                    indirimOraniField = value;
                }
            }

            /// <remarks/>
            public int StokbirimturId
            {
                get
                {
                    return stokbirimturIdField;
                }
                set
                {
                    stokbirimturIdField = value;
                }
            }

            /// <remarks/>
            public string StokTuru
            {
                get
                {
                    return stokTuruField;
                }
                set
                {
                    stokTuruField = value;
                }
            }

            /// <remarks/>
            public int KdvOran
            {
                get
                {
                    return kdvOranField;
                }
                set
                {
                    kdvOranField = value;
                }
            }

            /// <remarks/>
            public double Tutar
            {
                get
                {
                    return tutarField;
                }
                set
                {
                    tutarField = value;
                }
            }

            /// <remarks/>
            public double KdvTutar
            {
                get
                {
                    return kdvTutarField;
                }
                set
                {
                    kdvTutarField = value;
                }
            }

            /// <remarks/>
            public System.DateTime SonKullanmaTarihi
            {
                get
                {
                    return sonKullanmaTarihiField;
                }
                set
                {
                    sonKullanmaTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class MuayeneKabulInfoWS
        {

            private int satMuayeneKabulIdField;

            private string butceTurIdField;

            private string tedarikTurIdField;

            private string stokHareketTurIdField;

            private string alimYontemIdField;

            private string mkysDepoKoduField;

            private int talepNoField;

            private int muayeneNoField;

            private int carikartIdField;

            private System.DateTime muayeneTarihiField;

            private string firmaVergiNoField;

            private long kontrolYetkiliTCField;

            private long teslimatCalTCField;

            private System.DateTime teslimTarihiField;

            private string teslimEdenField;

            private string teslimAlanField;

            private string kabulKomisyonSayiField;

            private string makamOnayNoField;

            private System.DateTime makamOnayTarihiField;

            private string iKNField;

            private System.DateTime ihaleTarihiField;

            private string firmaAdiField;

            private string irsaliyeNoField;

            private System.DateTime irsaliyeTarihiField;

            private string depoTurIdField;

            private double faturaTutarField;

            private double kdvTutarField;

            private double indirimTutarField;

            private double genelToplamField;

            private string hastaTCField;

            private string hastaAdSoyadField;

            private MuayeneKabulKalemInfoWS[] muayeneKalemleriField;

            /// <remarks/>
            public int SatMuayeneKabulId
            {
                get
                {
                    return satMuayeneKabulIdField;
                }
                set
                {
                    satMuayeneKabulIdField = value;
                }
            }

            /// <remarks/>
            public string ButceTurId
            {
                get
                {
                    return butceTurIdField;
                }
                set
                {
                    butceTurIdField = value;
                }
            }

            /// <remarks/>
            public string TedarikTurId
            {
                get
                {
                    return tedarikTurIdField;
                }
                set
                {
                    tedarikTurIdField = value;
                }
            }

            /// <remarks/>
            public string StokHareketTurId
            {
                get
                {
                    return stokHareketTurIdField;
                }
                set
                {
                    stokHareketTurIdField = value;
                }
            }

            /// <remarks/>
            public string AlimYontemId
            {
                get
                {
                    return alimYontemIdField;
                }
                set
                {
                    alimYontemIdField = value;
                }
            }

            /// <remarks/>
            public string MkysDepoKodu
            {
                get
                {
                    return mkysDepoKoduField;
                }
                set
                {
                    mkysDepoKoduField = value;
                }
            }

            /// <remarks/>
            public int TalepNo
            {
                get
                {
                    return talepNoField;
                }
                set
                {
                    talepNoField = value;
                }
            }

            /// <remarks/>
            public int MuayeneNo
            {
                get
                {
                    return muayeneNoField;
                }
                set
                {
                    muayeneNoField = value;
                }
            }

            /// <remarks/>
            public int CarikartId
            {
                get
                {
                    return carikartIdField;
                }
                set
                {
                    carikartIdField = value;
                }
            }

            /// <remarks/>
            public System.DateTime MuayeneTarihi
            {
                get
                {
                    return muayeneTarihiField;
                }
                set
                {
                    muayeneTarihiField = value;
                }
            }

            /// <remarks/>
            public string FirmaVergiNo
            {
                get
                {
                    return firmaVergiNoField;
                }
                set
                {
                    firmaVergiNoField = value;
                }
            }

            /// <remarks/>
            public long KontrolYetkiliTC
            {
                get
                {
                    return kontrolYetkiliTCField;
                }
                set
                {
                    kontrolYetkiliTCField = value;
                }
            }

            /// <remarks/>
            public long TeslimatCalTC
            {
                get
                {
                    return teslimatCalTCField;
                }
                set
                {
                    teslimatCalTCField = value;
                }
            }

            /// <remarks/>
            public System.DateTime TeslimTarihi
            {
                get
                {
                    return teslimTarihiField;
                }
                set
                {
                    teslimTarihiField = value;
                }
            }

            /// <remarks/>
            public string TeslimEden
            {
                get
                {
                    return teslimEdenField;
                }
                set
                {
                    teslimEdenField = value;
                }
            }

            /// <remarks/>
            public string TeslimAlan
            {
                get
                {
                    return teslimAlanField;
                }
                set
                {
                    teslimAlanField = value;
                }
            }

            /// <remarks/>
            public string KabulKomisyonSayi
            {
                get
                {
                    return kabulKomisyonSayiField;
                }
                set
                {
                    kabulKomisyonSayiField = value;
                }
            }

            /// <remarks/>
            public string MakamOnayNo
            {
                get
                {
                    return makamOnayNoField;
                }
                set
                {
                    makamOnayNoField = value;
                }
            }

            /// <remarks/>
            public System.DateTime MakamOnayTarihi
            {
                get
                {
                    return makamOnayTarihiField;
                }
                set
                {
                    makamOnayTarihiField = value;
                }
            }

            /// <remarks/>
            public string IKN
            {
                get
                {
                    return iKNField;
                }
                set
                {
                    iKNField = value;
                }
            }

            /// <remarks/>
            public System.DateTime IhaleTarihi
            {
                get
                {
                    return ihaleTarihiField;
                }
                set
                {
                    ihaleTarihiField = value;
                }
            }

            /// <remarks/>
            public string FirmaAdi
            {
                get
                {
                    return firmaAdiField;
                }
                set
                {
                    firmaAdiField = value;
                }
            }

            /// <remarks/>
            public string IrsaliyeNo
            {
                get
                {
                    return irsaliyeNoField;
                }
                set
                {
                    irsaliyeNoField = value;
                }
            }

            /// <remarks/>
            public System.DateTime IrsaliyeTarihi
            {
                get
                {
                    return irsaliyeTarihiField;
                }
                set
                {
                    irsaliyeTarihiField = value;
                }
            }

            /// <remarks/>
            public string DepoTurId
            {
                get
                {
                    return depoTurIdField;
                }
                set
                {
                    depoTurIdField = value;
                }
            }

            /// <remarks/>
            public double FaturaTutar
            {
                get
                {
                    return faturaTutarField;
                }
                set
                {
                    faturaTutarField = value;
                }
            }

            /// <remarks/>
            public double KdvTutar
            {
                get
                {
                    return kdvTutarField;
                }
                set
                {
                    kdvTutarField = value;
                }
            }

            /// <remarks/>
            public double IndirimTutar
            {
                get
                {
                    return indirimTutarField;
                }
                set
                {
                    indirimTutarField = value;
                }
            }

            /// <remarks/>
            public double GenelToplam
            {
                get
                {
                    return genelToplamField;
                }
                set
                {
                    genelToplamField = value;
                }
            }

            /// <remarks/>
            public string HastaTC
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
            public string HastaAdSoyad
            {
                get
                {
                    return hastaAdSoyadField;
                }
                set
                {
                    hastaAdSoyadField = value;
                }
            }

            /// <remarks/>
            public MuayeneKabulKalemInfoWS[] MuayeneKalemleri
            {
                get
                {
                    return muayeneKalemleriField;
                }
                set
                {
                    muayeneKalemleriField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class MuayeneAramaKriterInfoWS
        {

            private string mkysDepoKoduField;

            private int satMuayeneKabulIdField;

            private int muayeneNoField;

            private System.Nullable<int> talepNoField;

            private string firmaAdiField;

            private string irsaliyeNoField;

            private System.Nullable<System.DateTime> muayeneTarihiStartField;

            private System.Nullable<System.DateTime> muayeneTarihiEndField;

            private System.Nullable<System.DateTime> teslimatTarihiStartField;

            private System.Nullable<System.DateTime> teslimatTarihiEndField;

            /// <remarks/>
            public string MkysDepoKodu
            {
                get
                {
                    return mkysDepoKoduField;
                }
                set
                {
                    mkysDepoKoduField = value;
                }
            }

            /// <remarks/>
            public int SatMuayeneKabulId
            {
                get
                {
                    return satMuayeneKabulIdField;
                }
                set
                {
                    satMuayeneKabulIdField = value;
                }
            }

            /// <remarks/>
            public int MuayeneNo
            {
                get
                {
                    return muayeneNoField;
                }
                set
                {
                    muayeneNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> TalepNo
            {
                get
                {
                    return talepNoField;
                }
                set
                {
                    talepNoField = value;
                }
            }

            /// <remarks/>
            public string FirmaAdi
            {
                get
                {
                    return firmaAdiField;
                }
                set
                {
                    firmaAdiField = value;
                }
            }

            /// <remarks/>
            public string IrsaliyeNo
            {
                get
                {
                    return irsaliyeNoField;
                }
                set
                {
                    irsaliyeNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> MuayeneTarihiStart
            {
                get
                {
                    return muayeneTarihiStartField;
                }
                set
                {
                    muayeneTarihiStartField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> MuayeneTarihiEnd
            {
                get
                {
                    return muayeneTarihiEndField;
                }
                set
                {
                    muayeneTarihiEndField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> TeslimatTarihiStart
            {
                get
                {
                    return teslimatTarihiStartField;
                }
                set
                {
                    teslimatTarihiStartField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> TeslimatTarihiEnd
            {
                get
                {
                    return teslimatTarihiEndField;
                }
                set
                {
                    teslimatTarihiEndField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
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

            private string epostaToStrField;

            private string epostaFromStrField;

            private string konuBaslikStrField;

            private string mailIcerikStrField;

            private string epostaFromSifreField;

            private string hbysTabloAdiField;

            private int tabloPkIdField;

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

            /// <remarks/>
            public string epostaToStr
            {
                get
                {
                    return epostaToStrField;
                }
                set
                {
                    epostaToStrField = value;
                }
            }

            /// <remarks/>
            public string epostaFromStr
            {
                get
                {
                    return epostaFromStrField;
                }
                set
                {
                    epostaFromStrField = value;
                }
            }

            /// <remarks/>
            public string konuBaslikStr
            {
                get
                {
                    return konuBaslikStrField;
                }
                set
                {
                    konuBaslikStrField = value;
                }
            }

            /// <remarks/>
            public string mailIcerikStr
            {
                get
                {
                    return mailIcerikStrField;
                }
                set
                {
                    mailIcerikStrField = value;
                }
            }

            /// <remarks/>
            public string epostaFromSifre
            {
                get
                {
                    return epostaFromSifreField;
                }
                set
                {
                    epostaFromSifreField = value;
                }
            }

            /// <remarks/>
            public string hbysTabloAdi
            {
                get
                {
                    return hbysTabloAdiField;
                }
                set
                {
                    hbysTabloAdiField = value;
                }
            }

            /// <remarks/>
            public int tabloPkId
            {
                get
                {
                    return tabloPkIdField;
                }
                set
                {
                    tabloPkIdField = value;
                }
            }
        }

    }
}