
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
    public  partial class DrugServis : TTObject
    {
        public static partial class WebMethods
        {
                    
        }

        #region Methods

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class AuditRow
        {

            private string idField;

            private string ipField;

            private string mACField;

            private string changeSetField;

            private string key1Field;

            private string key2Field;

            private System.DateTime dateField;

            private string iUDField;

            private string objectNameField;

            /// <remarks/>
            public string Id
            {
                get
                {
                    return idField;
                }
                set
                {
                    idField = value;
                }
            }

            /// <remarks/>
            public string IP
            {
                get
                {
                    return ipField;
                }
                set
                {
                    ipField = value;
                }
            }

            /// <remarks/>
            public string MAC
            {
                get
                {
                    return mACField;
                }
                set
                {
                    mACField = value;
                }
            }

            /// <remarks/>
            public string ChangeSet
            {
                get
                {
                    return changeSetField;
                }
                set
                {
                    changeSetField = value;
                }
            }

            /// <remarks/>
            public string Key1
            {
                get
                {
                    return key1Field;
                }
                set
                {
                    key1Field = value;
                }
            }

            /// <remarks/>
            public string Key2
            {
                get
                {
                    return key2Field;
                }
                set
                {
                    key2Field = value;
                }
            }

            /// <remarks/>
            public System.DateTime Date
            {
                get
                {
                    return dateField;
                }
                set
                {
                    dateField = value;
                }
            }

            /// <remarks/>
            public string IUD
            {
                get
                {
                    return iUDField;
                }
                set
                {
                    iUDField = value;
                }
            }

            /// <remarks/>
            public string ObjectName
            {
                get
                {
                    return objectNameField;
                }
                set
                {
                    objectNameField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class EntityKeyMember
        {

            private string keyField;

            private object valueField;

            /// <remarks/>
            public string Key
            {
                get
                {
                    return keyField;
                }
                set
                {
                    keyField = value;
                }
            }

            /// <remarks/>
            public object Value
            {
                get
                {
                    return valueField;
                }
                set
                {
                    valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class EntityKey
        {

            private string entitySetNameField;

            private string entityContainerNameField;

            private EntityKeyMember[] entityKeyValuesField;

            /// <remarks/>
            public string EntitySetName
            {
                get
                {
                    return entitySetNameField;
                }
                set
                {
                    entitySetNameField = value;
                }
            }

            /// <remarks/>
            public string EntityContainerName
            {
                get
                {
                    return entityContainerNameField;
                }
                set
                {
                    entityContainerNameField = value;
                }
            }

            /// <remarks/>
            public EntityKeyMember[] EntityKeyValues
            {
                get
                {
                    return entityKeyValuesField;
                }
                set
                {
                    entityKeyValuesField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(EntityObject))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(Urun_Fiyat))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(UygulamaKodlari))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(Urun_EtkenMadde))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(Urun_Bilgisi))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(Urun_Atc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(Listeler))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(FarmasotikSekil))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(Etken_Madde))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ATC))]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public abstract partial class StructuralObject
        {
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(Urun_Fiyat))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(UygulamaKodlari))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(Urun_EtkenMadde))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(Urun_Bilgisi))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(Urun_Atc))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(Listeler))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(FarmasotikSekil))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(Etken_Madde))]
        [System.Xml.Serialization.XmlIncludeAttribute(typeof(ATC))]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public abstract partial class EntityObject : StructuralObject
        {

            private EntityKey entityKeyField;

            /// <remarks/>
            public EntityKey EntityKey
            {
                get
                {
                    return entityKeyField;
                }
                set
                {
                    entityKeyField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class Urun_Fiyat : EntityObject
        {

            private long idField;

            private string barkodField;

            private System.DateTime baslangic_TrhField;

            private System.DateTime bitis_TrhField;

            private System.Nullable<decimal> fiyatField;

            private decimal fiyat_Tur_IDField;

            private string fiyat_TurField;

            private decimal para_Birim_IDField;

            private string para_BirimField;

            private System.Nullable<System.DateTime> anlasmaTarihiField;

            /// <remarks/>
            public long Id
            {
                get
                {
                    return idField;
                }
                set
                {
                    idField = value;
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
            public System.DateTime Baslangic_Trh
            {
                get
                {
                    return baslangic_TrhField;
                }
                set
                {
                    baslangic_TrhField = value;
                }
            }

            /// <remarks/>
            public System.DateTime Bitis_Trh
            {
                get
                {
                    return bitis_TrhField;
                }
                set
                {
                    bitis_TrhField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> Fiyat
            {
                get
                {
                    return fiyatField;
                }
                set
                {
                    fiyatField = value;
                }
            }

            /// <remarks/>
            public decimal Fiyat_Tur_ID
            {
                get
                {
                    return fiyat_Tur_IDField;
                }
                set
                {
                    fiyat_Tur_IDField = value;
                }
            }

            /// <remarks/>
            public string Fiyat_Tur
            {
                get
                {
                    return fiyat_TurField;
                }
                set
                {
                    fiyat_TurField = value;
                }
            }

            /// <remarks/>
            public decimal Para_Birim_ID
            {
                get
                {
                    return para_Birim_IDField;
                }
                set
                {
                    para_Birim_IDField = value;
                }
            }

            /// <remarks/>
            public string Para_Birim
            {
                get
                {
                    return para_BirimField;
                }
                set
                {
                    para_BirimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<System.DateTime> AnlasmaTarihi
            {
                get
                {
                    return anlasmaTarihiField;
                }
                set
                {
                    anlasmaTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class UygulamaKodlari : EntityObject
        {

            private string uygulamaKodlari1Field;

            private string uygulamaKodlari_TrField;

            private int uygulama_IDField;

            /// <remarks/>
            public string UygulamaKodlari1
            {
                get
                {
                    return uygulamaKodlari1Field;
                }
                set
                {
                    uygulamaKodlari1Field = value;
                }
            }

            /// <remarks/>
            public string UygulamaKodlari_Tr
            {
                get
                {
                    return uygulamaKodlari_TrField;
                }
                set
                {
                    uygulamaKodlari_TrField = value;
                }
            }

            /// <remarks/>
            public int Uygulama_ID
            {
                get
                {
                    return uygulama_IDField;
                }
                set
                {
                    uygulama_IDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class Urun_EtkenMadde : EntityObject
        {

            private long idField;

            private System.Nullable<long> urun_Bilgisi_IDField;

            private string urunAdiField;

            private string barkodField;

            private System.Nullable<long> etken_Madde_IDField;

            private string etken_Madde_AdiField;

            private System.Nullable<decimal> urun_Madde_MiktariField;

            private string urun_Madde_Miktari_BirimiField;

            private System.Nullable<long> urun_Madde_Miktari_Birimi_IDField;

            private string urun_Madde_Max_DozField;

            private string urun_Madde_DurumField;

            private System.Nullable<long> etken_Madde_Unit_IDField;

            /// <remarks/>
            public long Id
            {
                get
                {
                    return idField;
                }
                set
                {
                    idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> Urun_Bilgisi_ID
            {
                get
                {
                    return urun_Bilgisi_IDField;
                }
                set
                {
                    urun_Bilgisi_IDField = value;
                }
            }

            /// <remarks/>
            public string UrunAdi
            {
                get
                {
                    return urunAdiField;
                }
                set
                {
                    urunAdiField = value;
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
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> Etken_Madde_ID
            {
                get
                {
                    return etken_Madde_IDField;
                }
                set
                {
                    etken_Madde_IDField = value;
                }
            }

            /// <remarks/>
            public string Etken_Madde_Adi
            {
                get
                {
                    return etken_Madde_AdiField;
                }
                set
                {
                    etken_Madde_AdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> Urun_Madde_Miktari
            {
                get
                {
                    return urun_Madde_MiktariField;
                }
                set
                {
                    urun_Madde_MiktariField = value;
                }
            }

            /// <remarks/>
            public string Urun_Madde_Miktari_Birimi
            {
                get
                {
                    return urun_Madde_Miktari_BirimiField;
                }
                set
                {
                    urun_Madde_Miktari_BirimiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> Urun_Madde_Miktari_Birimi_ID
            {
                get
                {
                    return urun_Madde_Miktari_Birimi_IDField;
                }
                set
                {
                    urun_Madde_Miktari_Birimi_IDField = value;
                }
            }

            /// <remarks/>
            public string Urun_Madde_Max_Doz
            {
                get
                {
                    return urun_Madde_Max_DozField;
                }
                set
                {
                    urun_Madde_Max_DozField = value;
                }
            }

            /// <remarks/>
            public string Urun_Madde_Durum
            {
                get
                {
                    return urun_Madde_DurumField;
                }
                set
                {
                    urun_Madde_DurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<long> Etken_Madde_Unit_ID
            {
                get
                {
                    return etken_Madde_Unit_IDField;
                }
                set
                {
                    etken_Madde_Unit_IDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class Urun_Bilgisi : EntityObject
        {

            private long urun_Bilgisi_IDField;

            private string barkodField;

            private string urunAdiField;

            private System.Nullable<int> durumuField;

            private System.Nullable<decimal> recete_TurField;

            private System.Nullable<decimal> miktar_AmbalajField;

            private string birim_AmbalajField;

            private System.Nullable<decimal> urun_Birim_SayisiField;

            private string urun_Birim_BirimiField;

            private string uygulama_Yolu_AdiField;

            private string uygulama_Yolu_KoduField;

            private string uygulama_Sekli_KoduField;

            private string uygulama_Sekli_AdiField;

            private string hesaplama_TurField;

            private string urun_TipiField;

            private string esdeger_KoduField;

            private string urun_FirmaField;

            private string hesaplama_Tur_DegerField;

            private System.Nullable<decimal> hesaplama_Tur_IDField;

            /// <remarks/>
            public long Urun_Bilgisi_ID
            {
                get
                {
                    return urun_Bilgisi_IDField;
                }
                set
                {
                    urun_Bilgisi_IDField = value;
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
            public string UrunAdi
            {
                get
                {
                    return urunAdiField;
                }
                set
                {
                    urunAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<int> Durumu
            {
                get
                {
                    return durumuField;
                }
                set
                {
                    durumuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> Recete_Tur
            {
                get
                {
                    return recete_TurField;
                }
                set
                {
                    recete_TurField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> Miktar_Ambalaj
            {
                get
                {
                    return miktar_AmbalajField;
                }
                set
                {
                    miktar_AmbalajField = value;
                }
            }

            /// <remarks/>
            public string Birim_Ambalaj
            {
                get
                {
                    return birim_AmbalajField;
                }
                set
                {
                    birim_AmbalajField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> Urun_Birim_Sayisi
            {
                get
                {
                    return urun_Birim_SayisiField;
                }
                set
                {
                    urun_Birim_SayisiField = value;
                }
            }

            /// <remarks/>
            public string Urun_Birim_Birimi
            {
                get
                {
                    return urun_Birim_BirimiField;
                }
                set
                {
                    urun_Birim_BirimiField = value;
                }
            }

            /// <remarks/>
            public string Uygulama_Yolu_Adi
            {
                get
                {
                    return uygulama_Yolu_AdiField;
                }
                set
                {
                    uygulama_Yolu_AdiField = value;
                }
            }

            /// <remarks/>
            public string Uygulama_Yolu_Kodu
            {
                get
                {
                    return uygulama_Yolu_KoduField;
                }
                set
                {
                    uygulama_Yolu_KoduField = value;
                }
            }

            /// <remarks/>
            public string Uygulama_Sekli_Kodu
            {
                get
                {
                    return uygulama_Sekli_KoduField;
                }
                set
                {
                    uygulama_Sekli_KoduField = value;
                }
            }

            /// <remarks/>
            public string Uygulama_Sekli_Adi
            {
                get
                {
                    return uygulama_Sekli_AdiField;
                }
                set
                {
                    uygulama_Sekli_AdiField = value;
                }
            }

            /// <remarks/>
            public string Hesaplama_Tur
            {
                get
                {
                    return hesaplama_TurField;
                }
                set
                {
                    hesaplama_TurField = value;
                }
            }

            /// <remarks/>
            public string Urun_Tipi
            {
                get
                {
                    return urun_TipiField;
                }
                set
                {
                    urun_TipiField = value;
                }
            }

            /// <remarks/>
            public string Esdeger_Kodu
            {
                get
                {
                    return esdeger_KoduField;
                }
                set
                {
                    esdeger_KoduField = value;
                }
            }

            /// <remarks/>
            public string Urun_Firma
            {
                get
                {
                    return urun_FirmaField;
                }
                set
                {
                    urun_FirmaField = value;
                }
            }

            /// <remarks/>
            public string Hesaplama_Tur_Deger
            {
                get
                {
                    return hesaplama_Tur_DegerField;
                }
                set
                {
                    hesaplama_Tur_DegerField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.Nullable<decimal> Hesaplama_Tur_ID
            {
                get
                {
                    return hesaplama_Tur_IDField;
                }
                set
                {
                    hesaplama_Tur_IDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class Urun_Atc : EntityObject
        {

            private decimal atcIdField;

            private decimal urunIdField;

            /// <remarks/>
            public decimal AtcId
            {
                get
                {
                    return atcIdField;
                }
                set
                {
                    atcIdField = value;
                }
            }

            /// <remarks/>
            public decimal UrunId
            {
                get
                {
                    return urunIdField;
                }
                set
                {
                    urunIdField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class Listeler : EntityObject
        {

            private long idField;

            private string adField;

            private string tipField;

            private string aktifField;

            private string degerField;

            /// <remarks/>
            public long Id
            {
                get
                {
                    return idField;
                }
                set
                {
                    idField = value;
                }
            }

            /// <remarks/>
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
            public string Tip
            {
                get
                {
                    return tipField;
                }
                set
                {
                    tipField = value;
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

            /// <remarks/>
            public string Deger
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class FarmasotikSekil : EntityObject
        {

            private string farmasotikGrupKoduField;

            private string farmasotikSekilKoduField;

            private string farmasotikSekilAdiField;

            private int farmasotik_IDField;

            /// <remarks/>
            public string FarmasotikGrupKodu
            {
                get
                {
                    return farmasotikGrupKoduField;
                }
                set
                {
                    farmasotikGrupKoduField = value;
                }
            }

            /// <remarks/>
            public string FarmasotikSekilKodu
            {
                get
                {
                    return farmasotikSekilKoduField;
                }
                set
                {
                    farmasotikSekilKoduField = value;
                }
            }

            /// <remarks/>
            public string FarmasotikSekilAdi
            {
                get
                {
                    return farmasotikSekilAdiField;
                }
                set
                {
                    farmasotikSekilAdiField = value;
                }
            }

            /// <remarks/>
            public int Farmasotik_ID
            {
                get
                {
                    return farmasotik_IDField;
                }
                set
                {
                    farmasotik_IDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class Etken_Madde : EntityObject
        {

            private int etken_Madde_IDField;

            private string etken_Madde_AdiField;

            /// <remarks/>
            public int Etken_Madde_ID
            {
                get
                {
                    return etken_Madde_IDField;
                }
                set
                {
                    etken_Madde_IDField = value;
                }
            }

            /// <remarks/>
            public string Etken_Madde_Adi
            {
                get
                {
                    return etken_Madde_AdiField;
                }
                set
                {
                    etken_Madde_AdiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ATC : EntityObject
        {

            private int atc_IDField;

            private string atcKodu_ParentField;

            private string atcKoduField;

            private string atcAdiField;

            /// <remarks/>
            public int Atc_ID
            {
                get
                {
                    return atc_IDField;
                }
                set
                {
                    atc_IDField = value;
                }
            }

            /// <remarks/>
            public string AtcKodu_Parent
            {
                get
                {
                    return atcKodu_ParentField;
                }
                set
                {
                    atcKodu_ParentField = value;
                }
            }

            /// <remarks/>
            public string AtcKodu
            {
                get
                {
                    return atcKoduField;
                }
                set
                {
                    atcKoduField = value;
                }
            }

            /// <remarks/>
            public string AtcAdi
            {
                get
                {
                    return atcAdiField;
                }
                set
                {
                    atcAdiField = value;
                }
            }
        }

        #endregion Methods

    }
}