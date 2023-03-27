
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
    /// Medula Adres Bilgileri WebService Classı
    /// </summary>
    public  partial class KPSKimlikNoSorgulaAdresServis : TTObject
    {
        public static partial class WebMethods
        {
                    
        }
                    
#region Methods
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KimlikNoileAdresSorguKriteri : object , System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KimlikNoField;

            public System.Nullable<long> KimlikNo
            {
                get
                {
                    return KimlikNoField;
                }
                set
                {
                    if ((KimlikNoField.Equals(value) != true))
                    {
                        KimlikNoField = value;
                        RaisePropertyChanged("KimlikNo");
                    }
                }
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChanged(string propertyName)
            {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if ((propertyChanged != null))
                {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KimlikNoileKisiAdresBilgileriSonucu : object , System.ComponentModel.INotifyPropertyChanged
        {

            

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KimlikNoileKisiAdresBilgileri[] SorguSonucuField;

            
            public  Parametre HataBilgisi
            {
                get
                {
                    return HataBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(HataBilgisiField, value) != true))
                    {
                        HataBilgisiField = value;
                        RaisePropertyChanged("HataBilgisi");
                    }
                }
            }

             
            public  KimlikNoileKisiAdresBilgileri[] SorguSonucu
            {
                get
                {
                    return SorguSonucuField;
                }
                set
                {
                    if ((object.ReferenceEquals(SorguSonucuField, value) != true))
                    {
                        SorguSonucuField = value;
                        RaisePropertyChanged("SorguSonucu");
                    }
                }
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChanged(string propertyName)
            {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if ((propertyChanged != null))
                {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class Parametre : object , System.ComponentModel.INotifyPropertyChanged
        {

            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AciklamaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> KodField;

            public string Aciklama
            {
                get
                {
                    return AciklamaField;
                }
                set
                {
                    if ((object.ReferenceEquals(AciklamaField, value) != true))
                    {
                        AciklamaField = value;
                        RaisePropertyChanged("Aciklama");
                    }
                }
            }

             
            public System.Nullable<int> Kod
            {
                get
                {
                    return KodField;
                }
                set
                {
                    if ((KodField.Equals(value) != true))
                    {
                        KodField = value;
                        RaisePropertyChanged("Kod");
                    }
                }
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChanged(string propertyName)
            {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if ((propertyChanged != null))
                {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KimlikNoileKisiAdresBilgileri : object , System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  KimlikNoileKisiAdresBilgisi[] DigerAdresBilgileriField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  KimlikNoileKisiAdresBilgisi YerlesimYeriAdresiField;

            public  KimlikNoileKisiAdresBilgisi[] DigerAdresBilgileri
            {
                get
                {
                    return DigerAdresBilgileriField;
                }
                set
                {
                    if ((object.ReferenceEquals(DigerAdresBilgileriField, value) != true))
                    {
                        DigerAdresBilgileriField = value;
                        RaisePropertyChanged("DigerAdresBilgileri");
                    }
                }
            }

             
            public  Parametre HataBilgisi
            {
                get
                {
                    return HataBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(HataBilgisiField, value) != true))
                    {
                        HataBilgisiField = value;
                        RaisePropertyChanged("HataBilgisi");
                    }
                }
            }

             
            public System.Nullable<long> KimlikNo
            {
                get
                {
                    return KimlikNoField;
                }
                set
                {
                    if ((KimlikNoField.Equals(value) != true))
                    {
                        KimlikNoField = value;
                        RaisePropertyChanged("KimlikNo");
                    }
                }
            }

             
            public  KimlikNoileKisiAdresBilgisi YerlesimYeriAdresi
            {
                get
                {
                    return YerlesimYeriAdresiField;
                }
                set
                {
                    if ((object.ReferenceEquals(YerlesimYeriAdresiField, value) != true))
                    {
                        YerlesimYeriAdresiField = value;
                        RaisePropertyChanged("YerlesimYeriAdresi");
                    }
                }
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChanged(string propertyName)
            {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if ((propertyChanged != null))
                {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KimlikNoileKisiAdresBilgisi : object , System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AcikAdresField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> AdresNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre AdresTipField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  KimlikNoileBeldeAdresi BeldeAdresiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  TarihBilgisi BeyanTarihiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BeyandaBulunanKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  KimlikNoileIlIlceMerkezi IlIlceMerkezAdresiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  KimlikNoileKoyAdresi KoyAdresiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  TarihBilgisi TasinmaTarihiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  TarihBilgisi TescilTarihiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  KimlikNoileYurtDisiAdresi YurtDisiAdresiField;

            public string AcikAdres
            {
                get
                {
                    return AcikAdresField;
                }
                set
                {
                    if ((object.ReferenceEquals(AcikAdresField, value) != true))
                    {
                        AcikAdresField = value;
                        RaisePropertyChanged("AcikAdres");
                    }
                }
            }

             
            public System.Nullable<long> AdresNo
            {
                get
                {
                    return AdresNoField;
                }
                set
                {
                    if ((AdresNoField.Equals(value) != true))
                    {
                        AdresNoField = value;
                        RaisePropertyChanged("AdresNo");
                    }
                }
            }

             
            public  Parametre AdresTip
            {
                get
                {
                    return AdresTipField;
                }
                set
                {
                    if ((object.ReferenceEquals(AdresTipField, value) != true))
                    {
                        AdresTipField = value;
                        RaisePropertyChanged("AdresTip");
                    }
                }
            }

             
            public  KimlikNoileBeldeAdresi BeldeAdresi
            {
                get
                {
                    return BeldeAdresiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BeldeAdresiField, value) != true))
                    {
                        BeldeAdresiField = value;
                        RaisePropertyChanged("BeldeAdresi");
                    }
                }
            }

             
            public  TarihBilgisi BeyanTarihi
            {
                get
                {
                    return BeyanTarihiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BeyanTarihiField, value) != true))
                    {
                        BeyanTarihiField = value;
                        RaisePropertyChanged("BeyanTarihi");
                    }
                }
            }

             
            public System.Nullable<long> BeyandaBulunanKimlikNo
            {
                get
                {
                    return BeyandaBulunanKimlikNoField;
                }
                set
                {
                    if ((BeyandaBulunanKimlikNoField.Equals(value) != true))
                    {
                        BeyandaBulunanKimlikNoField = value;
                        RaisePropertyChanged("BeyandaBulunanKimlikNo");
                    }
                }
            }

             
            public  Parametre HataBilgisi
            {
                get
                {
                    return HataBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(HataBilgisiField, value) != true))
                    {
                        HataBilgisiField = value;
                        RaisePropertyChanged("HataBilgisi");
                    }
                }
            }

             
            public  KimlikNoileIlIlceMerkezi IlIlceMerkezAdresi
            {
                get
                {
                    return IlIlceMerkezAdresiField;
                }
                set
                {
                    if ((object.ReferenceEquals(IlIlceMerkezAdresiField, value) != true))
                    {
                        IlIlceMerkezAdresiField = value;
                        RaisePropertyChanged("IlIlceMerkezAdresi");
                    }
                }
            }

             
            public  KimlikNoileKoyAdresi KoyAdresi
            {
                get
                {
                    return KoyAdresiField;
                }
                set
                {
                    if ((object.ReferenceEquals(KoyAdresiField, value) != true))
                    {
                        KoyAdresiField = value;
                        RaisePropertyChanged("KoyAdresi");
                    }
                }
            }

             
            public  TarihBilgisi TasinmaTarihi
            {
                get
                {
                    return TasinmaTarihiField;
                }
                set
                {
                    if ((object.ReferenceEquals(TasinmaTarihiField, value) != true))
                    {
                        TasinmaTarihiField = value;
                        RaisePropertyChanged("TasinmaTarihi");
                    }
                }
            }

             
            public  TarihBilgisi TescilTarihi
            {
                get
                {
                    return TescilTarihiField;
                }
                set
                {
                    if ((object.ReferenceEquals(TescilTarihiField, value) != true))
                    {
                        TescilTarihiField = value;
                        RaisePropertyChanged("TescilTarihi");
                    }
                }
            }

             
            public  KimlikNoileYurtDisiAdresi YurtDisiAdresi
            {
                get
                {
                    return YurtDisiAdresiField;
                }
                set
                {
                    if ((object.ReferenceEquals(YurtDisiAdresiField, value) != true))
                    {
                        YurtDisiAdresiField = value;
                        RaisePropertyChanged("YurtDisiAdresi");
                    }
                }
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChanged(string propertyName)
            {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if ((propertyChanged != null))
                {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KimlikNoileBeldeAdresi : object , System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BagimsizBolumDurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BagimsizBolumTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaAdaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaBlokAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BinaDurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BinaKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> BinaNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BinaNumaratajTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaPaftaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaParselField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaSiteAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BinaYapiTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CsbmField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> CsbmKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DisKapiNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IcKapiNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> IlKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlceField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> IlceKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KatNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KoyField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KoyKayitNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KoyKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string MahalleField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> MahalleKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string TapuBagimsizBolumNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre YapiKullanimAmacField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YolAltiKatSayisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YolUstuKatSayisiField;

            public  Parametre BagimsizBolumDurum
            {
                get
                {
                    return BagimsizBolumDurumField;
                }
                set
                {
                    if ((object.ReferenceEquals(BagimsizBolumDurumField, value) != true))
                    {
                        BagimsizBolumDurumField = value;
                        RaisePropertyChanged("BagimsizBolumDurum");
                    }
                }
            }

             
            public  Parametre BagimsizBolumTipi
            {
                get
                {
                    return BagimsizBolumTipiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BagimsizBolumTipiField, value) != true))
                    {
                        BagimsizBolumTipiField = value;
                        RaisePropertyChanged("BagimsizBolumTipi");
                    }
                }
            }

             
            public string BinaAda
            {
                get
                {
                    return BinaAdaField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaAdaField, value) != true))
                    {
                        BinaAdaField = value;
                        RaisePropertyChanged("BinaAda");
                    }
                }
            }

             
            public string BinaBlokAdi
            {
                get
                {
                    return BinaBlokAdiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaBlokAdiField, value) != true))
                    {
                        BinaBlokAdiField = value;
                        RaisePropertyChanged("BinaBlokAdi");
                    }
                }
            }

             
            public  Parametre BinaDurum
            {
                get
                {
                    return BinaDurumField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaDurumField, value) != true))
                    {
                        BinaDurumField = value;
                        RaisePropertyChanged("BinaDurum");
                    }
                }
            }

             
            public System.Nullable<long> BinaKodu
            {
                get
                {
                    return BinaKoduField;
                }
                set
                {
                    if ((BinaKoduField.Equals(value) != true))
                    {
                        BinaKoduField = value;
                        RaisePropertyChanged("BinaKodu");
                    }
                }
            }

             
            public System.Nullable<int> BinaNo
            {
                get
                {
                    return BinaNoField;
                }
                set
                {
                    if ((BinaNoField.Equals(value) != true))
                    {
                        BinaNoField = value;
                        RaisePropertyChanged("BinaNo");
                    }
                }
            }

             
            public  Parametre BinaNumaratajTipi
            {
                get
                {
                    return BinaNumaratajTipiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaNumaratajTipiField, value) != true))
                    {
                        BinaNumaratajTipiField = value;
                        RaisePropertyChanged("BinaNumaratajTipi");
                    }
                }
            }

             
            public string BinaPafta
            {
                get
                {
                    return BinaPaftaField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaPaftaField, value) != true))
                    {
                        BinaPaftaField = value;
                        RaisePropertyChanged("BinaPafta");
                    }
                }
            }

             
            public string BinaParsel
            {
                get
                {
                    return BinaParselField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaParselField, value) != true))
                    {
                        BinaParselField = value;
                        RaisePropertyChanged("BinaParsel");
                    }
                }
            }

             
            public string BinaSiteAdi
            {
                get
                {
                    return BinaSiteAdiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaSiteAdiField, value) != true))
                    {
                        BinaSiteAdiField = value;
                        RaisePropertyChanged("BinaSiteAdi");
                    }
                }
            }

             
            public  Parametre BinaYapiTipi
            {
                get
                {
                    return BinaYapiTipiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaYapiTipiField, value) != true))
                    {
                        BinaYapiTipiField = value;
                        RaisePropertyChanged("BinaYapiTipi");
                    }
                }
            }

             
            public string Csbm
            {
                get
                {
                    return CsbmField;
                }
                set
                {
                    if ((object.ReferenceEquals(CsbmField, value) != true))
                    {
                        CsbmField = value;
                        RaisePropertyChanged("Csbm");
                    }
                }
            }

             
            public System.Nullable<int> CsbmKodu
            {
                get
                {
                    return CsbmKoduField;
                }
                set
                {
                    if ((CsbmKoduField.Equals(value) != true))
                    {
                        CsbmKoduField = value;
                        RaisePropertyChanged("CsbmKodu");
                    }
                }
            }

             
            public string DisKapiNo
            {
                get
                {
                    return DisKapiNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(DisKapiNoField, value) != true))
                    {
                        DisKapiNoField = value;
                        RaisePropertyChanged("DisKapiNo");
                    }
                }
            }

             
            public  Parametre HataBilgisi
            {
                get
                {
                    return HataBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(HataBilgisiField, value) != true))
                    {
                        HataBilgisiField = value;
                        RaisePropertyChanged("HataBilgisi");
                    }
                }
            }

             
            public string IcKapiNo
            {
                get
                {
                    return IcKapiNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(IcKapiNoField, value) != true))
                    {
                        IcKapiNoField = value;
                        RaisePropertyChanged("IcKapiNo");
                    }
                }
            }

             
            public string Il
            {
                get
                {
                    return IlField;
                }
                set
                {
                    if ((object.ReferenceEquals(IlField, value) != true))
                    {
                        IlField = value;
                        RaisePropertyChanged("Il");
                    }
                }
            }

             
            public System.Nullable<int> IlKodu
            {
                get
                {
                    return IlKoduField;
                }
                set
                {
                    if ((IlKoduField.Equals(value) != true))
                    {
                        IlKoduField = value;
                        RaisePropertyChanged("IlKodu");
                    }
                }
            }

             
            public string Ilce
            {
                get
                {
                    return IlceField;
                }
                set
                {
                    if ((object.ReferenceEquals(IlceField, value) != true))
                    {
                        IlceField = value;
                        RaisePropertyChanged("Ilce");
                    }
                }
            }

             
            public System.Nullable<int> IlceKodu
            {
                get
                {
                    return IlceKoduField;
                }
                set
                {
                    if ((IlceKoduField.Equals(value) != true))
                    {
                        IlceKoduField = value;
                        RaisePropertyChanged("IlceKodu");
                    }
                }
            }

             
            public string KatNo
            {
                get
                {
                    return KatNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(KatNoField, value) != true))
                    {
                        KatNoField = value;
                        RaisePropertyChanged("KatNo");
                    }
                }
            }

             
            public string Koy
            {
                get
                {
                    return KoyField;
                }
                set
                {
                    if ((object.ReferenceEquals(KoyField, value) != true))
                    {
                        KoyField = value;
                        RaisePropertyChanged("Koy");
                    }
                }
            }

             
            public System.Nullable<long> KoyKayitNo
            {
                get
                {
                    return KoyKayitNoField;
                }
                set
                {
                    if ((KoyKayitNoField.Equals(value) != true))
                    {
                        KoyKayitNoField = value;
                        RaisePropertyChanged("KoyKayitNo");
                    }
                }
            }

             
            public System.Nullable<long> KoyKodu
            {
                get
                {
                    return KoyKoduField;
                }
                set
                {
                    if ((KoyKoduField.Equals(value) != true))
                    {
                        KoyKoduField = value;
                        RaisePropertyChanged("KoyKodu");
                    }
                }
            }

             
            public string Mahalle
            {
                get
                {
                    return MahalleField;
                }
                set
                {
                    if ((object.ReferenceEquals(MahalleField, value) != true))
                    {
                        MahalleField = value;
                        RaisePropertyChanged("Mahalle");
                    }
                }
            }

             
            public System.Nullable<int> MahalleKodu
            {
                get
                {
                    return MahalleKoduField;
                }
                set
                {
                    if ((MahalleKoduField.Equals(value) != true))
                    {
                        MahalleKoduField = value;
                        RaisePropertyChanged("MahalleKodu");
                    }
                }
            }

             
            public string TapuBagimsizBolumNo
            {
                get
                {
                    return TapuBagimsizBolumNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(TapuBagimsizBolumNoField, value) != true))
                    {
                        TapuBagimsizBolumNoField = value;
                        RaisePropertyChanged("TapuBagimsizBolumNo");
                    }
                }
            }

             
            public  Parametre YapiKullanimAmac
            {
                get
                {
                    return YapiKullanimAmacField;
                }
                set
                {
                    if ((object.ReferenceEquals(YapiKullanimAmacField, value) != true))
                    {
                        YapiKullanimAmacField = value;
                        RaisePropertyChanged("YapiKullanimAmac");
                    }
                }
            }

             
            public System.Nullable<int> YolAltiKatSayisi
            {
                get
                {
                    return YolAltiKatSayisiField;
                }
                set
                {
                    if ((YolAltiKatSayisiField.Equals(value) != true))
                    {
                        YolAltiKatSayisiField = value;
                        RaisePropertyChanged("YolAltiKatSayisi");
                    }
                }
            }

             
            public System.Nullable<int> YolUstuKatSayisi
            {
                get
                {
                    return YolUstuKatSayisiField;
                }
                set
                {
                    if ((YolUstuKatSayisiField.Equals(value) != true))
                    {
                        YolUstuKatSayisiField = value;
                        RaisePropertyChanged("YolUstuKatSayisi");
                    }
                }
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChanged(string propertyName)
            {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if ((propertyChanged != null))
                {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class TarihBilgisi : object , System.ComponentModel.INotifyPropertyChanged
        {


            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> AyField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> GunField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YilField;

            
            public System.Nullable<int> Ay
            {
                get
                {
                    return AyField;
                }
                set
                {
                    if ((AyField.Equals(value) != true))
                    {
                        AyField = value;
                        RaisePropertyChanged("Ay");
                    }
                }
            }

             
            public System.Nullable<int> Gun
            {
                get
                {
                    return GunField;
                }
                set
                {
                    if ((GunField.Equals(value) != true))
                    {
                        GunField = value;
                        RaisePropertyChanged("Gun");
                    }
                }
            }

             
            public System.Nullable<int> Yil
            {
                get
                {
                    return YilField;
                }
                set
                {
                    if ((YilField.Equals(value) != true))
                    {
                        YilField = value;
                        RaisePropertyChanged("Yil");
                    }
                }
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChanged(string propertyName)
            {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if ((propertyChanged != null))
                {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KimlikNoileIlIlceMerkezi : object , System.ComponentModel.INotifyPropertyChanged
        {

        
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BagimsizBolumDurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BagimsizBolumTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaAdaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaBlokAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BinaDurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BinaKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> BinaNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BinaNumaratajTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaPaftaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaParselField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaSiteAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BinaYapiTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CsbmField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> CsbmKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DisKapiNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IcKapiNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> IlKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlceField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> IlceKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KatNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string MahalleField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> MahalleKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string TapuBagimsizBolumNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre YapiKullanimAmacField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YolAltiKatSayisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YolUstuKatSayisiField;

            public  Parametre BagimsizBolumDurum
            {
                get
                {
                    return BagimsizBolumDurumField;
                }
                set
                {
                    if ((object.ReferenceEquals(BagimsizBolumDurumField, value) != true))
                    {
                        BagimsizBolumDurumField = value;
                        RaisePropertyChanged("BagimsizBolumDurum");
                    }
                }
            }

             
            public  Parametre BagimsizBolumTipi
            {
                get
                {
                    return BagimsizBolumTipiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BagimsizBolumTipiField, value) != true))
                    {
                        BagimsizBolumTipiField = value;
                        RaisePropertyChanged("BagimsizBolumTipi");
                    }
                }
            }

             
            public string BinaAda
            {
                get
                {
                    return BinaAdaField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaAdaField, value) != true))
                    {
                        BinaAdaField = value;
                        RaisePropertyChanged("BinaAda");
                    }
                }
            }

             
            public string BinaBlokAdi
            {
                get
                {
                    return BinaBlokAdiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaBlokAdiField, value) != true))
                    {
                        BinaBlokAdiField = value;
                        RaisePropertyChanged("BinaBlokAdi");
                    }
                }
            }

             
            public  Parametre BinaDurum
            {
                get
                {
                    return BinaDurumField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaDurumField, value) != true))
                    {
                        BinaDurumField = value;
                        RaisePropertyChanged("BinaDurum");
                    }
                }
            }

             
            public System.Nullable<long> BinaKodu
            {
                get
                {
                    return BinaKoduField;
                }
                set
                {
                    if ((BinaKoduField.Equals(value) != true))
                    {
                        BinaKoduField = value;
                        RaisePropertyChanged("BinaKodu");
                    }
                }
            }

             
            public System.Nullable<int> BinaNo
            {
                get
                {
                    return BinaNoField;
                }
                set
                {
                    if ((BinaNoField.Equals(value) != true))
                    {
                        BinaNoField = value;
                        RaisePropertyChanged("BinaNo");
                    }
                }
            }

             
            public  Parametre BinaNumaratajTipi
            {
                get
                {
                    return BinaNumaratajTipiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaNumaratajTipiField, value) != true))
                    {
                        BinaNumaratajTipiField = value;
                        RaisePropertyChanged("BinaNumaratajTipi");
                    }
                }
            }

             
            public string BinaPafta
            {
                get
                {
                    return BinaPaftaField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaPaftaField, value) != true))
                    {
                        BinaPaftaField = value;
                        RaisePropertyChanged("BinaPafta");
                    }
                }
            }

             
            public string BinaParsel
            {
                get
                {
                    return BinaParselField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaParselField, value) != true))
                    {
                        BinaParselField = value;
                        RaisePropertyChanged("BinaParsel");
                    }
                }
            }

             
            public string BinaSiteAdi
            {
                get
                {
                    return BinaSiteAdiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaSiteAdiField, value) != true))
                    {
                        BinaSiteAdiField = value;
                        RaisePropertyChanged("BinaSiteAdi");
                    }
                }
            }

             
            public  Parametre BinaYapiTipi
            {
                get
                {
                    return BinaYapiTipiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaYapiTipiField, value) != true))
                    {
                        BinaYapiTipiField = value;
                        RaisePropertyChanged("BinaYapiTipi");
                    }
                }
            }

             
            public string Csbm
            {
                get
                {
                    return CsbmField;
                }
                set
                {
                    if ((object.ReferenceEquals(CsbmField, value) != true))
                    {
                        CsbmField = value;
                        RaisePropertyChanged("Csbm");
                    }
                }
            }

             
            public System.Nullable<int> CsbmKodu
            {
                get
                {
                    return CsbmKoduField;
                }
                set
                {
                    if ((CsbmKoduField.Equals(value) != true))
                    {
                        CsbmKoduField = value;
                        RaisePropertyChanged("CsbmKodu");
                    }
                }
            }

             
            public string DisKapiNo
            {
                get
                {
                    return DisKapiNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(DisKapiNoField, value) != true))
                    {
                        DisKapiNoField = value;
                        RaisePropertyChanged("DisKapiNo");
                    }
                }
            }

             
            public  Parametre HataBilgisi
            {
                get
                {
                    return HataBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(HataBilgisiField, value) != true))
                    {
                        HataBilgisiField = value;
                        RaisePropertyChanged("HataBilgisi");
                    }
                }
            }

             
            public string IcKapiNo
            {
                get
                {
                    return IcKapiNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(IcKapiNoField, value) != true))
                    {
                        IcKapiNoField = value;
                        RaisePropertyChanged("IcKapiNo");
                    }
                }
            }

             
            public string Il
            {
                get
                {
                    return IlField;
                }
                set
                {
                    if ((object.ReferenceEquals(IlField, value) != true))
                    {
                        IlField = value;
                        RaisePropertyChanged("Il");
                    }
                }
            }

             
            public System.Nullable<int> IlKodu
            {
                get
                {
                    return IlKoduField;
                }
                set
                {
                    if ((IlKoduField.Equals(value) != true))
                    {
                        IlKoduField = value;
                        RaisePropertyChanged("IlKodu");
                    }
                }
            }

             
            public string Ilce
            {
                get
                {
                    return IlceField;
                }
                set
                {
                    if ((object.ReferenceEquals(IlceField, value) != true))
                    {
                        IlceField = value;
                        RaisePropertyChanged("Ilce");
                    }
                }
            }

             
            public System.Nullable<int> IlceKodu
            {
                get
                {
                    return IlceKoduField;
                }
                set
                {
                    if ((IlceKoduField.Equals(value) != true))
                    {
                        IlceKoduField = value;
                        RaisePropertyChanged("IlceKodu");
                    }
                }
            }

             
            public string KatNo
            {
                get
                {
                    return KatNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(KatNoField, value) != true))
                    {
                        KatNoField = value;
                        RaisePropertyChanged("KatNo");
                    }
                }
            }

             
            public string Mahalle
            {
                get
                {
                    return MahalleField;
                }
                set
                {
                    if ((object.ReferenceEquals(MahalleField, value) != true))
                    {
                        MahalleField = value;
                        RaisePropertyChanged("Mahalle");
                    }
                }
            }

             
            public System.Nullable<int> MahalleKodu
            {
                get
                {
                    return MahalleKoduField;
                }
                set
                {
                    if ((MahalleKoduField.Equals(value) != true))
                    {
                        MahalleKoduField = value;
                        RaisePropertyChanged("MahalleKodu");
                    }
                }
            }

             
            public string TapuBagimsizBolumNo
            {
                get
                {
                    return TapuBagimsizBolumNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(TapuBagimsizBolumNoField, value) != true))
                    {
                        TapuBagimsizBolumNoField = value;
                        RaisePropertyChanged("TapuBagimsizBolumNo");
                    }
                }
            }

             
            public  Parametre YapiKullanimAmac
            {
                get
                {
                    return YapiKullanimAmacField;
                }
                set
                {
                    if ((object.ReferenceEquals(YapiKullanimAmacField, value) != true))
                    {
                        YapiKullanimAmacField = value;
                        RaisePropertyChanged("YapiKullanimAmac");
                    }
                }
            }

             
            public System.Nullable<int> YolAltiKatSayisi
            {
                get
                {
                    return YolAltiKatSayisiField;
                }
                set
                {
                    if ((YolAltiKatSayisiField.Equals(value) != true))
                    {
                        YolAltiKatSayisiField = value;
                        RaisePropertyChanged("YolAltiKatSayisi");
                    }
                }
            }

             
            public System.Nullable<int> YolUstuKatSayisi
            {
                get
                {
                    return YolUstuKatSayisiField;
                }
                set
                {
                    if ((YolUstuKatSayisiField.Equals(value) != true))
                    {
                        YolUstuKatSayisiField = value;
                        RaisePropertyChanged("YolUstuKatSayisi");
                    }
                }
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChanged(string propertyName)
            {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if ((propertyChanged != null))
                {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KimlikNoileKoyAdresi : object , System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BagimsizBolumDurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BagimsizBolumTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaAdaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaBlokAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BinaDurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BinaKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> BinaNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BinaNumaratajTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaPaftaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaParselField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaSiteAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre BinaYapiTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CsbmField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> CsbmKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DisKapiNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IcKapiNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> IlKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlceField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> IlceKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KatNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KoyField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KoyKayitNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KoyKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string MahalleField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> MahalleKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string TapuBagimsizBolumNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre YapiKullanimAmacField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YolAltiKatSayisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YolUstuKatSayisiField;

            
            public  Parametre BagimsizBolumDurum
            {
                get
                {
                    return BagimsizBolumDurumField;
                }
                set
                {
                    if ((object.ReferenceEquals(BagimsizBolumDurumField, value) != true))
                    {
                        BagimsizBolumDurumField = value;
                        RaisePropertyChanged("BagimsizBolumDurum");
                    }
                }
            }

             
            public  Parametre BagimsizBolumTipi
            {
                get
                {
                    return BagimsizBolumTipiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BagimsizBolumTipiField, value) != true))
                    {
                        BagimsizBolumTipiField = value;
                        RaisePropertyChanged("BagimsizBolumTipi");
                    }
                }
            }

             
            public string BinaAda
            {
                get
                {
                    return BinaAdaField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaAdaField, value) != true))
                    {
                        BinaAdaField = value;
                        RaisePropertyChanged("BinaAda");
                    }
                }
            }

             
            public string BinaBlokAdi
            {
                get
                {
                    return BinaBlokAdiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaBlokAdiField, value) != true))
                    {
                        BinaBlokAdiField = value;
                        RaisePropertyChanged("BinaBlokAdi");
                    }
                }
            }

             
            public  Parametre BinaDurum
            {
                get
                {
                    return BinaDurumField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaDurumField, value) != true))
                    {
                        BinaDurumField = value;
                        RaisePropertyChanged("BinaDurum");
                    }
                }
            }

             
            public System.Nullable<long> BinaKodu
            {
                get
                {
                    return BinaKoduField;
                }
                set
                {
                    if ((BinaKoduField.Equals(value) != true))
                    {
                        BinaKoduField = value;
                        RaisePropertyChanged("BinaKodu");
                    }
                }
            }

             
            public System.Nullable<int> BinaNo
            {
                get
                {
                    return BinaNoField;
                }
                set
                {
                    if ((BinaNoField.Equals(value) != true))
                    {
                        BinaNoField = value;
                        RaisePropertyChanged("BinaNo");
                    }
                }
            }

             
            public  Parametre BinaNumaratajTipi
            {
                get
                {
                    return BinaNumaratajTipiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaNumaratajTipiField, value) != true))
                    {
                        BinaNumaratajTipiField = value;
                        RaisePropertyChanged("BinaNumaratajTipi");
                    }
                }
            }

             
            public string BinaPafta
            {
                get
                {
                    return BinaPaftaField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaPaftaField, value) != true))
                    {
                        BinaPaftaField = value;
                        RaisePropertyChanged("BinaPafta");
                    }
                }
            }

             
            public string BinaParsel
            {
                get
                {
                    return BinaParselField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaParselField, value) != true))
                    {
                        BinaParselField = value;
                        RaisePropertyChanged("BinaParsel");
                    }
                }
            }

             
            public string BinaSiteAdi
            {
                get
                {
                    return BinaSiteAdiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaSiteAdiField, value) != true))
                    {
                        BinaSiteAdiField = value;
                        RaisePropertyChanged("BinaSiteAdi");
                    }
                }
            }

             
            public  Parametre BinaYapiTipi
            {
                get
                {
                    return BinaYapiTipiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BinaYapiTipiField, value) != true))
                    {
                        BinaYapiTipiField = value;
                        RaisePropertyChanged("BinaYapiTipi");
                    }
                }
            }

             
            public string Csbm
            {
                get
                {
                    return CsbmField;
                }
                set
                {
                    if ((object.ReferenceEquals(CsbmField, value) != true))
                    {
                        CsbmField = value;
                        RaisePropertyChanged("Csbm");
                    }
                }
            }

             
            public System.Nullable<int> CsbmKodu
            {
                get
                {
                    return CsbmKoduField;
                }
                set
                {
                    if ((CsbmKoduField.Equals(value) != true))
                    {
                        CsbmKoduField = value;
                        RaisePropertyChanged("CsbmKodu");
                    }
                }
            }

             
            public string DisKapiNo
            {
                get
                {
                    return DisKapiNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(DisKapiNoField, value) != true))
                    {
                        DisKapiNoField = value;
                        RaisePropertyChanged("DisKapiNo");
                    }
                }
            }

             
            public  Parametre HataBilgisi
            {
                get
                {
                    return HataBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(HataBilgisiField, value) != true))
                    {
                        HataBilgisiField = value;
                        RaisePropertyChanged("HataBilgisi");
                    }
                }
            }

             
            public string IcKapiNo
            {
                get
                {
                    return IcKapiNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(IcKapiNoField, value) != true))
                    {
                        IcKapiNoField = value;
                        RaisePropertyChanged("IcKapiNo");
                    }
                }
            }

             
            public string Il
            {
                get
                {
                    return IlField;
                }
                set
                {
                    if ((object.ReferenceEquals(IlField, value) != true))
                    {
                        IlField = value;
                        RaisePropertyChanged("Il");
                    }
                }
            }

             
            public System.Nullable<int> IlKodu
            {
                get
                {
                    return IlKoduField;
                }
                set
                {
                    if ((IlKoduField.Equals(value) != true))
                    {
                        IlKoduField = value;
                        RaisePropertyChanged("IlKodu");
                    }
                }
            }

             
            public string Ilce
            {
                get
                {
                    return IlceField;
                }
                set
                {
                    if ((object.ReferenceEquals(IlceField, value) != true))
                    {
                        IlceField = value;
                        RaisePropertyChanged("Ilce");
                    }
                }
            }

             
            public System.Nullable<int> IlceKodu
            {
                get
                {
                    return IlceKoduField;
                }
                set
                {
                    if ((IlceKoduField.Equals(value) != true))
                    {
                        IlceKoduField = value;
                        RaisePropertyChanged("IlceKodu");
                    }
                }
            }

             
            public string KatNo
            {
                get
                {
                    return KatNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(KatNoField, value) != true))
                    {
                        KatNoField = value;
                        RaisePropertyChanged("KatNo");
                    }
                }
            }

             
            public string Koy
            {
                get
                {
                    return KoyField;
                }
                set
                {
                    if ((object.ReferenceEquals(KoyField, value) != true))
                    {
                        KoyField = value;
                        RaisePropertyChanged("Koy");
                    }
                }
            }

             
            public System.Nullable<long> KoyKayitNo
            {
                get
                {
                    return KoyKayitNoField;
                }
                set
                {
                    if ((KoyKayitNoField.Equals(value) != true))
                    {
                        KoyKayitNoField = value;
                        RaisePropertyChanged("KoyKayitNo");
                    }
                }
            }

             
            public System.Nullable<long> KoyKodu
            {
                get
                {
                    return KoyKoduField;
                }
                set
                {
                    if ((KoyKoduField.Equals(value) != true))
                    {
                        KoyKoduField = value;
                        RaisePropertyChanged("KoyKodu");
                    }
                }
            }

             
            public string Mahalle
            {
                get
                {
                    return MahalleField;
                }
                set
                {
                    if ((object.ReferenceEquals(MahalleField, value) != true))
                    {
                        MahalleField = value;
                        RaisePropertyChanged("Mahalle");
                    }
                }
            }

             
            public System.Nullable<int> MahalleKodu
            {
                get
                {
                    return MahalleKoduField;
                }
                set
                {
                    if ((MahalleKoduField.Equals(value) != true))
                    {
                        MahalleKoduField = value;
                        RaisePropertyChanged("MahalleKodu");
                    }
                }
            }

             
            public string TapuBagimsizBolumNo
            {
                get
                {
                    return TapuBagimsizBolumNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(TapuBagimsizBolumNoField, value) != true))
                    {
                        TapuBagimsizBolumNoField = value;
                        RaisePropertyChanged("TapuBagimsizBolumNo");
                    }
                }
            }

             
            public  Parametre YapiKullanimAmac
            {
                get
                {
                    return YapiKullanimAmacField;
                }
                set
                {
                    if ((object.ReferenceEquals(YapiKullanimAmacField, value) != true))
                    {
                        YapiKullanimAmacField = value;
                        RaisePropertyChanged("YapiKullanimAmac");
                    }
                }
            }

             
            public System.Nullable<int> YolAltiKatSayisi
            {
                get
                {
                    return YolAltiKatSayisiField;
                }
                set
                {
                    if ((YolAltiKatSayisiField.Equals(value) != true))
                    {
                        YolAltiKatSayisiField = value;
                        RaisePropertyChanged("YolAltiKatSayisi");
                    }
                }
            }

             
            public System.Nullable<int> YolUstuKatSayisi
            {
                get
                {
                    return YolUstuKatSayisiField;
                }
                set
                {
                    if ((YolUstuKatSayisiField.Equals(value) != true))
                    {
                        YolUstuKatSayisiField = value;
                        RaisePropertyChanged("YolUstuKatSayisi");
                    }
                }
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChanged(string propertyName)
            {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if ((propertyChanged != null))
                {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KimlikNoileYurtDisiAdresi : object , System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<System.DateTime> DisTemsDuzeltmeBeyanTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<System.DateTime> DisTemsDuzeltmeKararTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre DisTemsDuzeltmeNedenField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre DisTemsilcilikField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string YabanciAdresField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string YabanciSehirField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private  Parametre YabanciUlkeField;

            public System.Nullable<System.DateTime> DisTemsDuzeltmeBeyanTarih
            {
                get
                {
                    return DisTemsDuzeltmeBeyanTarihField;
                }
                set
                {
                    if ((DisTemsDuzeltmeBeyanTarihField.Equals(value) != true))
                    {
                        DisTemsDuzeltmeBeyanTarihField = value;
                        RaisePropertyChanged("DisTemsDuzeltmeBeyanTarih");
                    }
                }
            }

             
            public System.Nullable<System.DateTime> DisTemsDuzeltmeKararTarih
            {
                get
                {
                    return DisTemsDuzeltmeKararTarihField;
                }
                set
                {
                    if ((DisTemsDuzeltmeKararTarihField.Equals(value) != true))
                    {
                        DisTemsDuzeltmeKararTarihField = value;
                        RaisePropertyChanged("DisTemsDuzeltmeKararTarih");
                    }
                }
            }

             
            public  Parametre DisTemsDuzeltmeNeden
            {
                get
                {
                    return DisTemsDuzeltmeNedenField;
                }
                set
                {
                    if ((object.ReferenceEquals(DisTemsDuzeltmeNedenField, value) != true))
                    {
                        DisTemsDuzeltmeNedenField = value;
                        RaisePropertyChanged("DisTemsDuzeltmeNeden");
                    }
                }
            }

             
            public  Parametre DisTemsilcilik
            {
                get
                {
                    return DisTemsilcilikField;
                }
                set
                {
                    if ((object.ReferenceEquals(DisTemsilcilikField, value) != true))
                    {
                        DisTemsilcilikField = value;
                        RaisePropertyChanged("DisTemsilcilik");
                    }
                }
            }

             
            public  Parametre HataBilgisi
            {
                get
                {
                    return HataBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(HataBilgisiField, value) != true))
                    {
                        HataBilgisiField = value;
                        RaisePropertyChanged("HataBilgisi");
                    }
                }
            }

             
            public string YabanciAdres
            {
                get
                {
                    return YabanciAdresField;
                }
                set
                {
                    if ((object.ReferenceEquals(YabanciAdresField, value) != true))
                    {
                        YabanciAdresField = value;
                        RaisePropertyChanged("YabanciAdres");
                    }
                }
            }

             
            public string YabanciSehir
            {
                get
                {
                    return YabanciSehirField;
                }
                set
                {
                    if ((object.ReferenceEquals(YabanciSehirField, value) != true))
                    {
                        YabanciSehirField = value;
                        RaisePropertyChanged("YabanciSehir");
                    }
                }
            }

             
            public  Parametre YabanciUlke
            {
                get
                {
                    return YabanciUlkeField;
                }
                set
                {
                    if ((object.ReferenceEquals(YabanciUlkeField, value) != true))
                    {
                        YabanciUlkeField = value;
                        RaisePropertyChanged("YabanciUlke");
                    }
                }
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChanged(string propertyName)
            {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if ((propertyChanged != null))
                {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }
        
#endregion Methods

    }
}