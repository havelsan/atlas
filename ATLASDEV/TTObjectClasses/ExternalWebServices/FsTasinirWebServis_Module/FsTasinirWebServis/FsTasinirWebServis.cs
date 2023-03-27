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
    public partial class FsTasinirWebServis : TTObject
    {
        public static partial class WebMethods
        {

        }

        #region Methods


        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class MuayeneFaturaAramaKriterInfoWS
        {

            private int muayeneNoField;

            private string depoTurIdField;

            private string firmaAdiField;

            private string irsaliyeNoField;

            private string faturaNoField;

            private System.Nullable<System.DateTime> muayeneTarihiStartField;

            private System.Nullable<System.DateTime> muayeneTarihiEndField;

            private System.Nullable<System.DateTime> faturaTarihiStartField;

            private System.Nullable<System.DateTime> faturaTarihiEndField;

            private System.Nullable<System.DateTime> irsaliyeTarihiStartField;

            private System.Nullable<System.DateTime> irsaliyeTarihiEndField;

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
            public string FaturaNo
            {
                get
                {
                    return faturaNoField;
                }
                set
                {
                    faturaNoField = value;
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
            public System.Nullable<System.DateTime> FaturaTarihiStart
            {
                get
                {
                    return faturaTarihiStartField;
                }
                set
                {
                    faturaTarihiStartField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> FaturaTarihiEnd
            {
                get
                {
                    return faturaTarihiEndField;
                }
                set
                {
                    faturaTarihiEndField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> IrsaliyeTarihiStart
            {
                get
                {
                    return irsaliyeTarihiStartField;
                }
                set
                {
                    irsaliyeTarihiStartField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> IrsaliyeTarihiEnd
            {
                get
                {
                    return irsaliyeTarihiEndField;
                }
                set
                {
                    irsaliyeTarihiEndField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class IslemNoTarihInfo
        {

            private int siparisIdField;

            private string noField;

            private System.Nullable<System.DateTime> tarihField;

            /// <remarks/>
            public int SiparisId
            {
                get
                {
                    return siparisIdField;
                }
                set
                {
                    siparisIdField = value;
                }
            }

            /// <remarks/>
            public string No
            {
                get
                {
                    return noField;
                }
                set
                {
                    noField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> Tarih
            {
                get
                {
                    return tarihField;
                }
                set
                {
                    tarihField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class TalepTedarikAkisSureInfo
        {

            private int talepIdField;

            private System.Nullable<System.DateTime> talepTarihiField;

            private System.Nullable<System.DateTime> talepBirimOnayTarihiField;

            private System.Nullable<System.DateTime> talepBaskanlikOnayTarihiField;

            private System.Nullable<System.DateTime> satinalmaOncesiDegerlendirmeyeGondermeTarihiField;

            private System.Nullable<System.DateTime> satinalmayaSevkTarihiField;

            private int uygulamaIdField;

            private int dosyaIdField;

            private string dosyaEkapKayitNoField;

            private string isinAdiField;

            private System.Nullable<System.DateTime> satinalmayaBaslamaTarihiField;

            private System.Nullable<System.DateTime> dosyaTamamlanmaTarihiField;

            private IslemNoTarihInfo[] siparisListField;

            private IslemNoTarihInfo[] irsaliyeListField;

            private IslemNoTarihInfo[] muayeneListField;

            private IslemNoTarihInfo[] faturaListField;

            /// <remarks/>
            public int TalepId
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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> TalepTarihi
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
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> TalepBirimOnayTarihi
            {
                get
                {
                    return talepBirimOnayTarihiField;
                }
                set
                {
                    talepBirimOnayTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> TalepBaskanlikOnayTarihi
            {
                get
                {
                    return talepBaskanlikOnayTarihiField;
                }
                set
                {
                    talepBaskanlikOnayTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> SatinalmaOncesiDegerlendirmeyeGondermeTarihi
            {
                get
                {
                    return satinalmaOncesiDegerlendirmeyeGondermeTarihiField;
                }
                set
                {
                    satinalmaOncesiDegerlendirmeyeGondermeTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> SatinalmayaSevkTarihi
            {
                get
                {
                    return satinalmayaSevkTarihiField;
                }
                set
                {
                    satinalmayaSevkTarihiField = value;
                }
            }

            /// <remarks/>
            public int UygulamaId
            {
                get
                {
                    return uygulamaIdField;
                }
                set
                {
                    uygulamaIdField = value;
                }
            }

            /// <remarks/>
            public int DosyaId
            {
                get
                {
                    return dosyaIdField;
                }
                set
                {
                    dosyaIdField = value;
                }
            }

            /// <remarks/>
            public string DosyaEkapKayitNo
            {
                get
                {
                    return dosyaEkapKayitNoField;
                }
                set
                {
                    dosyaEkapKayitNoField = value;
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
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> SatinalmayaBaslamaTarihi
            {
                get
                {
                    return satinalmayaBaslamaTarihiField;
                }
                set
                {
                    satinalmayaBaslamaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> DosyaTamamlanmaTarihi
            {
                get
                {
                    return dosyaTamamlanmaTarihiField;
                }
                set
                {
                    dosyaTamamlanmaTarihiField = value;
                }
            }

            /// <remarks/>
            public IslemNoTarihInfo[] SiparisList
            {
                get
                {
                    return siparisListField;
                }
                set
                {
                    siparisListField = value;
                }
            }

            /// <remarks/>
            public IslemNoTarihInfo[] IrsaliyeList
            {
                get
                {
                    return irsaliyeListField;
                }
                set
                {
                    irsaliyeListField = value;
                }
            }

            /// <remarks/>
            public IslemNoTarihInfo[] MuayeneList
            {
                get
                {
                    return muayeneListField;
                }
                set
                {
                    muayeneListField = value;
                }
            }

            /// <remarks/>
            public IslemNoTarihInfo[] FaturaList
            {
                get
                {
                    return faturaListField;
                }
                set
                {
                    faturaListField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class HBYSDepoDurumInfo
        {

            private int mkysBirimIdField;

            private int hbysDepoIdField;

            private int malzemeKayitIdField;

            private string malzemeAciklamaField;

            private string olcuBirimiField;

            private decimal stokMiktariField;

            /// <remarks/>
            public int MkysBirimId
            {
                get
                {
                    return mkysBirimIdField;
                }
                set
                {
                    mkysBirimIdField = value;
                }
            }

            /// <remarks/>
            public int HbysDepoId
            {
                get
                {
                    return hbysDepoIdField;
                }
                set
                {
                    hbysDepoIdField = value;
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
            public decimal StokMiktari
            {
                get
                {
                    return stokMiktariField;
                }
                set
                {
                    stokMiktariField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class HbysDepoInfo
        {

            private int hbysDepoIdField;

            private int hbysDepoTuruField;

            private string depoAdiField;

            private int aktifField;

            private int mkysBirimIdField;

            /// <remarks/>
            public int HbysDepoId
            {
                get
                {
                    return hbysDepoIdField;
                }
                set
                {
                    hbysDepoIdField = value;
                }
            }

            /// <remarks/>
            public int HbysDepoTuru
            {
                get
                {
                    return hbysDepoTuruField;
                }
                set
                {
                    hbysDepoTuruField = value;
                }
            }

            /// <remarks/>
            public string DepoAdi
            {
                get
                {
                    return depoAdiField;
                }
                set
                {
                    depoAdiField = value;
                }
            }

            /// <remarks/>
            public int Aktif
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

            /// <remarks/>
            public int MkysBirimId
            {
                get
                {
                    return mkysBirimIdField;
                }
                set
                {
                    mkysBirimIdField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class KayitSonuc
        {

            private bool basariDurumuField;

            private System.Nullable<System.DateTime> dateValueField;

            private decimal degerField;

            private int islemKayitNoField;

            private string mesajField;

            private string stringValueField;

            private object resultObjField;

            /// <remarks/>
            public bool basariDurumu
            {
                get
                {
                    return basariDurumuField;
                }
                set
                {
                    basariDurumuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> dateValue
            {
                get
                {
                    return dateValueField;
                }
                set
                {
                    dateValueField = value;
                }
            }

            /// <remarks/>
            public decimal deger
            {
                get
                {
                    return degerField;
                }
                set
                {
                    degerField = value;
                }
            }

            /// <remarks/>
            public int islemKayitNo
            {
                get
                {
                    return islemKayitNoField;
                }
                set
                {
                    islemKayitNoField = value;
                }
            }

            /// <remarks/>
            public string mesaj
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
            public string stringValue
            {
                get
                {
                    return stringValueField;
                }
                set
                {
                    stringValueField = value;
                }
            }

            /// <remarks/>
            public object ResultObj
            {
                get
                {
                    return resultObjField;
                }
                set
                {
                    resultObjField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class MuayeneKomisyonUyeInfoWS
        {

            private int muayeneIdField;

            private int siraNoField;

            private int komisyonGorevIdField;

            private string uyeTcKimlikNoField;

            private string uyeAdSoyadField;

            private string uyeImzaUnvanField;

            /// <remarks/>
            public int MuayeneId
            {
                get
                {
                    return muayeneIdField;
                }
                set
                {
                    muayeneIdField = value;
                }
            }

            /// <remarks/>
            public int SiraNo
            {
                get
                {
                    return siraNoField;
                }
                set
                {
                    siraNoField = value;
                }
            }

            /// <remarks/>
            public int KomisyonGorevId
            {
                get
                {
                    return komisyonGorevIdField;
                }
                set
                {
                    komisyonGorevIdField = value;
                }
            }

            /// <remarks/>
            public string UyeTcKimlikNo
            {
                get
                {
                    return uyeTcKimlikNoField;
                }
                set
                {
                    uyeTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            public string UyeAdSoyad
            {
                get
                {
                    return uyeAdSoyadField;
                }
                set
                {
                    uyeAdSoyadField = value;
                }
            }

            /// <remarks/>
            public string UyeImzaUnvan
            {
                get
                {
                    return uyeImzaUnvanField;
                }
                set
                {
                    uyeImzaUnvanField = value;
                }
            }
        }



        /// <remarks/>
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(EntityBaseClass))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(MalzemeStokEslesmeInfoWS))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(TopluAlimTalepInfoWS))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(MuayeneFaturaKalemInfoWS))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(MuayeneFaturaInfoWS))]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class tafSQLServerInfoBaseClass
        {
        }



        /// <remarks/>
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(MalzemeStokEslesmeInfoWS))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(TopluAlimTalepInfoWS))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(MuayeneFaturaKalemInfoWS))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(MuayeneFaturaInfoWS))]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class EntityBaseClass : tafSQLServerInfoBaseClass
        {
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class MalzemeStokEslesmeInfoWS : EntityBaseClass
        {

            private int birimIdField;

            private string depoTurIdField;

            private int mkysMalzemeIdField;

            private string mkysMalzmeKoduField;

            private string malzemeAdiField;

            private string malzemeAciklamaField;

            /// <remarks/>
            public int BirimId
            {
                get
                {
                    return birimIdField;
                }
                set
                {
                    birimIdField = value;
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
            public string MkysMalzmeKodu
            {
                get
                {
                    return mkysMalzmeKoduField;
                }
                set
                {
                    mkysMalzmeKoduField = value;
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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class TopluAlimTalepInfoWS : EntityBaseClass
        {

            private int ihaleIdField;

            private int malzemeIdField;

            private int siraNoField;

            private string mkysKoduField;

            private string malzemeAdiField;

            private string malzemeAciklamaField;

            private string olcuBirimiField;

            private decimal talepMiktariField;

            private decimal onayMiktariField;

            private System.DateTime talepTarihiField;

            /// <remarks/>
            public int IhaleId
            {
                get
                {
                    return ihaleIdField;
                }
                set
                {
                    ihaleIdField = value;
                }
            }

            /// <remarks/>
            public int MalzemeId
            {
                get
                {
                    return malzemeIdField;
                }
                set
                {
                    malzemeIdField = value;
                }
            }

            /// <remarks/>
            public int SiraNo
            {
                get
                {
                    return siraNoField;
                }
                set
                {
                    siraNoField = value;
                }
            }

            /// <remarks/>
            public string MkysKodu
            {
                get
                {
                    return mkysKoduField;
                }
                set
                {
                    mkysKoduField = value;
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
            public decimal TalepMiktari
            {
                get
                {
                    return talepMiktariField;
                }
                set
                {
                    talepMiktariField = value;
                }
            }

            /// <remarks/>
            public decimal OnayMiktari
            {
                get
                {
                    return onayMiktariField;
                }
                set
                {
                    onayMiktariField = value;
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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class MuayeneFaturaKalemInfoWS : EntityBaseClass
        {

            private int muayeneIdField;

            private int malzemeKayitIdField;

            private int malzemeIdField;

            private int siraNoField;

            private string barkodField;

            private string malzemeKoduField;

            private string malzemeAdiField;

            private string malzemeAciklamaField;

            private string olcuBirimiField;

            private decimal miktarField;

            private decimal alisFiyatiField;

            private decimal fiyatFarkiField;

            private int indirimOraniField;

            private int kdvOraniField;

            private string malzemeTuruField;

            private string mkysOlcuBirimiIdField;

            private decimal tutarField;

            private decimal kdvTutarField;

            private decimal kdvliTutarField;

            private decimal netTutarField;

            private System.DateTime sonKullanmaTarihiField;

            private string gmdnField;

            private string firmaTanimlayiciNoField;

            private string kunyeNoField;

            private string donorNoField;

            private int uygulamaIdField;

            private int faturaIdField;

            /// <remarks/>
            public int MuayeneId
            {
                get
                {
                    return muayeneIdField;
                }
                set
                {
                    muayeneIdField = value;
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
            public int MalzemeId
            {
                get
                {
                    return malzemeIdField;
                }
                set
                {
                    malzemeIdField = value;
                }
            }

            /// <remarks/>
            public int SiraNo
            {
                get
                {
                    return siraNoField;
                }
                set
                {
                    siraNoField = value;
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
            public decimal Miktar
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
            public decimal AlisFiyati
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
            public decimal FiyatFarki
            {
                get
                {
                    return fiyatFarkiField;
                }
                set
                {
                    fiyatFarkiField = value;
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
            public int KdvOrani
            {
                get
                {
                    return kdvOraniField;
                }
                set
                {
                    kdvOraniField = value;
                }
            }

            /// <remarks/>
            public string MalzemeTuru
            {
                get
                {
                    return malzemeTuruField;
                }
                set
                {
                    malzemeTuruField = value;
                }
            }

            /// <remarks/>
            public string MkysOlcuBirimiId
            {
                get
                {
                    return mkysOlcuBirimiIdField;
                }
                set
                {
                    mkysOlcuBirimiIdField = value;
                }
            }

            /// <remarks/>
            public decimal Tutar
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
            public decimal KdvTutar
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
            public decimal KdvliTutar
            {
                get
                {
                    return kdvliTutarField;
                }
                set
                {
                    kdvliTutarField = value;
                }
            }

            /// <remarks/>
            public decimal NetTutar
            {
                get
                {
                    return netTutarField;
                }
                set
                {
                    netTutarField = value;
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

            /// <remarks/>
            public string Gmdn
            {
                get
                {
                    return gmdnField;
                }
                set
                {
                    gmdnField = value;
                }
            }

            /// <remarks/>
            public string FirmaTanimlayiciNo
            {
                get
                {
                    return firmaTanimlayiciNoField;
                }
                set
                {
                    firmaTanimlayiciNoField = value;
                }
            }

            /// <remarks/>
            public string KunyeNo
            {
                get
                {
                    return kunyeNoField;
                }
                set
                {
                    kunyeNoField = value;
                }
            }

            /// <remarks/>
            public string DonorNo
            {
                get
                {
                    return donorNoField;
                }
                set
                {
                    donorNoField = value;
                }
            }

            /// <remarks/>
            public int UygulamaId
            {
                get
                {
                    return uygulamaIdField;
                }
                set
                {
                    uygulamaIdField = value;
                }
            }

            /// <remarks/>
            public int FaturaId
            {
                get
                {
                    return faturaIdField;
                }
                set
                {
                    faturaIdField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class MuayeneFaturaInfoWS : EntityBaseClass
        {

            private int uygulamaIdField;

            private int dosyaIdField;

            private int muayeneIdField;

            private int faturaIdField;

            private string butceTurIdField;

            private string tedarikTurIdField;

            private string stokHareketTurIdField;

            private string alimYontemIdField;

            private string mkysDepoKoduField;

            private int muayeneNoField;

            private System.DateTime muayeneTarihiField;

            private string firmaVergiNoField;

            private long kontrolYetkiliTCField;

            private System.DateTime teslimTarihiField;

            private string teslimEdenField;

            private string teslimAlanField;

            private string kabulKomisyonSayiField;

            private string makamOnayNoField;

            private System.DateTime makamOnayTarihiField;

            private string ihaleKayitNoField;

            private System.DateTime ihaleTarihiField;

            private string firmaAdiField;

            private string irsaliyeNoField;

            private System.DateTime irsaliyeTarihiField;

            private string faturaNoField;

            private System.Nullable<System.DateTime> kararOnayTarihiField;

            private System.Nullable<System.DateTime> talepSatinalmaUlasmaTarihiField;

            private System.Nullable<System.DateTime> sozlesmeImzaTarihiField;

            private string faturaDurumAciklamaField;

            private System.DateTime faturaTarihiField;

            private string talepIdStrField;

            private MuayeneFaturaKalemInfoWS[] muayeneFaturaKalemListField;

            private MuayeneKomisyonUyeInfoWS[] muayeneKomisyonUyeListField;

            /// <remarks/>
            public int UygulamaId
            {
                get
                {
                    return uygulamaIdField;
                }
                set
                {
                    uygulamaIdField = value;
                }
            }

            /// <remarks/>
            public int DosyaId
            {
                get
                {
                    return dosyaIdField;
                }
                set
                {
                    dosyaIdField = value;
                }
            }

            /// <remarks/>
            public int MuayeneId
            {
                get
                {
                    return muayeneIdField;
                }
                set
                {
                    muayeneIdField = value;
                }
            }

            /// <remarks/>
            public int FaturaId
            {
                get
                {
                    return faturaIdField;
                }
                set
                {
                    faturaIdField = value;
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
            public string IhaleKayitNo
            {
                get
                {
                    return ihaleKayitNoField;
                }
                set
                {
                    ihaleKayitNoField = value;
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
            public string FaturaNo
            {
                get
                {
                    return faturaNoField;
                }
                set
                {
                    faturaNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> KararOnayTarihi
            {
                get
                {
                    return kararOnayTarihiField;
                }
                set
                {
                    kararOnayTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> TalepSatinalmaUlasmaTarihi
            {
                get
                {
                    return talepSatinalmaUlasmaTarihiField;
                }
                set
                {
                    talepSatinalmaUlasmaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> SozlesmeImzaTarihi
            {
                get
                {
                    return sozlesmeImzaTarihiField;
                }
                set
                {
                    sozlesmeImzaTarihiField = value;
                }
            }

            /// <remarks/>
            public string FaturaDurumAciklama
            {
                get
                {
                    return faturaDurumAciklamaField;
                }
                set
                {
                    faturaDurumAciklamaField = value;
                }
            }

            /// <remarks/>
            public System.DateTime FaturaTarihi
            {
                get
                {
                    return faturaTarihiField;
                }
                set
                {
                    faturaTarihiField = value;
                }
            }

            /// <remarks/>
            public string TalepIdStr
            {
                get
                {
                    return talepIdStrField;
                }
                set
                {
                    talepIdStrField = value;
                }
            }

            /// <remarks/>
            public MuayeneFaturaKalemInfoWS[] MuayeneFaturaKalemList
            {
                get
                {
                    return muayeneFaturaKalemListField;
                }
                set
                {
                    muayeneFaturaKalemListField = value;
                }
            }

            /// <remarks/>
            public MuayeneKomisyonUyeInfoWS[] MuayeneKomisyonUyeList
            {
                get
                {
                    return muayeneKomisyonUyeListField;
                }
                set
                {
                    muayeneKomisyonUyeListField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class MuayeneFaturaGetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal MuayeneFaturaGetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public MuayeneFaturaInfoWS[] Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((MuayeneFaturaInfoWS[])(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class MuayeneFaturaTifKaydetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal MuayeneFaturaTifKaydetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public KayitSonuc Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((KayitSonuc)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class HBYSDepoEkleGuncelleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal HBYSDepoEkleGuncelleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public KayitSonuc Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((KayitSonuc)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class HBYSDepoDurumEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal HBYSDepoDurumEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public KayitSonuc Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((KayitSonuc)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class FaturaKilitDurumKaydetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal FaturaKilitDurumKaydetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public KayitSonuc Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((KayitSonuc)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class FaturaKilitKontrolCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal FaturaKilitKontrolCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public KayitSonuc Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((KayitSonuc)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class TalepTedarikAkisGetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal TalepTedarikAkisGetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public TalepTedarikAkisSureInfo Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((TalepTedarikAkisSureInfo)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class TopluAlimTalepListGetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal TopluAlimTalepListGetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public TopluAlimTalepInfoWS[] Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((TopluAlimTalepInfoWS[])(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class MalzemeStokEslesmeGetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal MalzemeStokEslesmeGetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public MalzemeStokEslesmeInfoWS[] Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((MalzemeStokEslesmeInfoWS[])(results[0]));
                }
            }
        }


        #endregion Methods
    }
}