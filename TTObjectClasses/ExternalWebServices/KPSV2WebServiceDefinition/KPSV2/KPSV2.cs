
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
    public  partial class KPSV2 : TTObject
    {
        public static partial class WebMethods
        {
                    
        }

        #region Methods


        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KpsServisSonucuOfBilesikKisiBilgisiZmZ26SC9 : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.BilesikKisiBilgisi SonucField;

            public KPSV2.Parametre HataBilgisi
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

            public KPSV2.BilesikKisiBilgisi Sonuc
            {
                get
                {
                    return SonucField;
                }
                set
                {
                    if ((object.ReferenceEquals(SonucField, value) != true))
                    {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class Parametre : object, System.ComponentModel.INotifyPropertyChanged
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
        public partial class BilesikKisiBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.MaviKartliKisiKutukleri MaviKartliKisiKutukleriField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TCVatandasiKisiKutukleri TCVatandasiKisiKutukleriField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.YabanciKisiKutukleri YabanciKisiKutukleriField;

            public KPSV2.Parametre HataBilgisi
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

            public KPSV2.MaviKartliKisiKutukleri MaviKartliKisiKutukleri
            {
                get
                {
                    return MaviKartliKisiKutukleriField;
                }
                set
                {
                    if ((object.ReferenceEquals(MaviKartliKisiKutukleriField, value) != true))
                    {
                        MaviKartliKisiKutukleriField = value;
                        RaisePropertyChanged("MaviKartliKisiKutukleri");
                    }
                }
            }

            public KPSV2.TCVatandasiKisiKutukleri TCVatandasiKisiKutukleri
            {
                get
                {
                    return TCVatandasiKisiKutukleriField;
                }
                set
                {
                    if ((object.ReferenceEquals(TCVatandasiKisiKutukleriField, value) != true))
                    {
                        TCVatandasiKisiKutukleriField = value;
                        RaisePropertyChanged("TCVatandasiKisiKutukleri");
                    }
                }
            }

            public KPSV2.YabanciKisiKutukleri YabanciKisiKutukleri
            {
                get
                {
                    return YabanciKisiKutukleriField;
                }
                set
                {
                    if ((object.ReferenceEquals(YabanciKisiKutukleriField, value) != true))
                    {
                        YabanciKisiKutukleriField = value;
                        RaisePropertyChanged("YabanciKisiKutukleri");
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
        public partial class KpsServisSonucuBilesikKisiBilgisi : KPSV2.KpsServisSonucuOfBilesikKisiBilgisiZmZ26SC9
        {
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class MaviKartliKisiKutukleri : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.KisiAdresBilgisi AdresBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.MaviKartKisiBilgisi KisiBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.MaviKartBilgisi MaviKartBilgisiField;

            public KPSV2.KisiAdresBilgisi AdresBilgisi
            {
                get
                {
                    return AdresBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(AdresBilgisiField, value) != true))
                    {
                        AdresBilgisiField = value;
                        RaisePropertyChanged("AdresBilgisi");
                    }
                }
            }

            public KPSV2.Parametre HataBilgisi
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

            public KPSV2.MaviKartKisiBilgisi KisiBilgisi
            {
                get
                {
                    return KisiBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(KisiBilgisiField, value) != true))
                    {
                        KisiBilgisiField = value;
                        RaisePropertyChanged("KisiBilgisi");
                    }
                }
            }

            public KPSV2.MaviKartBilgisi MaviKartBilgisi
            {
                get
                {
                    return MaviKartBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(MaviKartBilgisiField, value) != true))
                    {
                        MaviKartBilgisiField = value;
                        RaisePropertyChanged("MaviKartBilgisi");
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
        public partial class TCVatandasiKisiKutukleri : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.KisiAdresBilgisi AdresBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TCGeciciKimlikBilgisi GeciciKimlikBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TCKisiBilgisi KisiBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TCCuzdanBilgisi NufusCuzdaniBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TCKK TCKKBilgisiField;

            public KPSV2.KisiAdresBilgisi AdresBilgisi
            {
                get
                {
                    return AdresBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(AdresBilgisiField, value) != true))
                    {
                        AdresBilgisiField = value;
                        RaisePropertyChanged("AdresBilgisi");
                    }
                }
            }

            public KPSV2.TCGeciciKimlikBilgisi GeciciKimlikBilgisi
            {
                get
                {
                    return GeciciKimlikBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(GeciciKimlikBilgisiField, value) != true))
                    {
                        GeciciKimlikBilgisiField = value;
                        RaisePropertyChanged("GeciciKimlikBilgisi");
                    }
                }
            }

            public KPSV2.Parametre HataBilgisi
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

            public KPSV2.TCKisiBilgisi KisiBilgisi
            {
                get
                {
                    return KisiBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(KisiBilgisiField, value) != true))
                    {
                        KisiBilgisiField = value;
                        RaisePropertyChanged("KisiBilgisi");
                    }
                }
            }

            public KPSV2.TCCuzdanBilgisi NufusCuzdaniBilgisi
            {
                get
                {
                    return NufusCuzdaniBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(NufusCuzdaniBilgisiField, value) != true))
                    {
                        NufusCuzdaniBilgisiField = value;
                        RaisePropertyChanged("NufusCuzdaniBilgisi");
                    }
                }
            }

            public KPSV2.TCKK TCKKBilgisi
            {
                get
                {
                    return TCKKBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(TCKKBilgisiField, value) != true))
                    {
                        TCKKBilgisiField = value;
                        RaisePropertyChanged("TCKKBilgisi");
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
        public partial class YabanciKisiKutukleri : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.KisiAdresBilgisi AdresBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.YabanciKisiBilgisi KisiBilgisiField;

            public KPSV2.KisiAdresBilgisi AdresBilgisi
            {
                get
                {
                    return AdresBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(AdresBilgisiField, value) != true))
                    {
                        AdresBilgisiField = value;
                        RaisePropertyChanged("AdresBilgisi");
                    }
                }
            }

            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.YabanciKisiBilgisi KisiBilgisi
            {
                get
                {
                    return KisiBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(KisiBilgisiField, value) != true))
                    {
                        KisiBilgisiField = value;
                        RaisePropertyChanged("KisiBilgisi");
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
        public partial class KisiAdresBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AcikAdresField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> AdresNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre AdresTipField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.BeldeAdresi BeldeAdresiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi BeyanTarihiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BeyandaBulunanKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.IlIlceMerkezAdresi IlIlceMerkezAdresiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.KoyAdresi KoyAdresiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi TasinmaTarihiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi TescilTarihiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.YurtDisiAdresi YurtDisiAdresiField;

            
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

            
            public KPSV2.Parametre AdresTip
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

            
            public KPSV2.BeldeAdresi BeldeAdresi
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

            
            public KPSV2.TarihBilgisi BeyanTarihi
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

            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.IlIlceMerkezAdresi IlIlceMerkezAdresi
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

            
            public KPSV2.KoyAdresi KoyAdresi
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

            
            public KPSV2.TarihBilgisi TasinmaTarihi
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

            
            public KPSV2.TarihBilgisi TescilTarihi
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

            
            public KPSV2.YurtDisiAdresi YurtDisiAdresi
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
        public partial class MaviKartKisiBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> AnneTCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BabaTCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> DogumYerKodField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.DurumBilgisi DurumBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> EsTCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> GercekKisiKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KazanilanTCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TemelBilgisi TemelBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre UlkeField;
            
            public System.Nullable<long> AnneTCKimlikNo
            {
                get
                {
                    return AnneTCKimlikNoField;
                }
                set
                {
                    if ((AnneTCKimlikNoField.Equals(value) != true))
                    {
                        AnneTCKimlikNoField = value;
                        RaisePropertyChanged("AnneTCKimlikNo");
                    }
                }
            }

            
            public System.Nullable<long> BabaTCKimlikNo
            {
                get
                {
                    return BabaTCKimlikNoField;
                }
                set
                {
                    if ((BabaTCKimlikNoField.Equals(value) != true))
                    {
                        BabaTCKimlikNoField = value;
                        RaisePropertyChanged("BabaTCKimlikNo");
                    }
                }
            }

            
            public System.Nullable<int> DogumYerKod
            {
                get
                {
                    return DogumYerKodField;
                }
                set
                {
                    if ((DogumYerKodField.Equals(value) != true))
                    {
                        DogumYerKodField = value;
                        RaisePropertyChanged("DogumYerKod");
                    }
                }
            }

            
            public KPSV2.DurumBilgisi DurumBilgisi
            {
                get
                {
                    return DurumBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(DurumBilgisiField, value) != true))
                    {
                        DurumBilgisiField = value;
                        RaisePropertyChanged("DurumBilgisi");
                    }
                }
            }

            
            public System.Nullable<long> EsTCKimlikNo
            {
                get
                {
                    return EsTCKimlikNoField;
                }
                set
                {
                    if ((EsTCKimlikNoField.Equals(value) != true))
                    {
                        EsTCKimlikNoField = value;
                        RaisePropertyChanged("EsTCKimlikNo");
                    }
                }
            }

            
            public System.Nullable<long> GercekKisiKimlikNo
            {
                get
                {
                    return GercekKisiKimlikNoField;
                }
                set
                {
                    if ((GercekKisiKimlikNoField.Equals(value) != true))
                    {
                        GercekKisiKimlikNoField = value;
                        RaisePropertyChanged("GercekKisiKimlikNo");
                    }
                }
            }

            
            public KPSV2.Parametre HataBilgisi
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

            
            public System.Nullable<long> KazanilanTCKimlikNo
            {
                get
                {
                    return KazanilanTCKimlikNoField;
                }
                set
                {
                    if ((KazanilanTCKimlikNoField.Equals(value) != true))
                    {
                        KazanilanTCKimlikNoField = value;
                        RaisePropertyChanged("KazanilanTCKimlikNo");
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

            
            public KPSV2.TemelBilgisi TemelBilgisi
            {
                get
                {
                    return TemelBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(TemelBilgisiField, value) != true))
                    {
                        TemelBilgisiField = value;
                        RaisePropertyChanged("TemelBilgisi");
                    }
                }
            }

            
            public KPSV2.Parametre Ulke
            {
                get
                {
                    return UlkeField;
                }
                set
                {
                    if ((object.ReferenceEquals(UlkeField, value) != true))
                    {
                        UlkeField = value;
                        RaisePropertyChanged("Ulke");
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
        public partial class MaviKartBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnneAdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaAdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> BirimField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre CinsiyetField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi DogumTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumYerField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> DogumYerKodField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KartKayitNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre MedeniHalField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> NoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string OncekiSoyadField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SeriField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre UyrukField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre VerilisNedenField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi VerilmeTarihField;
            
            public string Ad
            {
                get
                {
                    return AdField;
                }
                set
                {
                    if ((object.ReferenceEquals(AdField, value) != true))
                    {
                        AdField = value;
                        RaisePropertyChanged("Ad");
                    }
                }
            }

            
            public string AnneAd
            {
                get
                {
                    return AnneAdField;
                }
                set
                {
                    if ((object.ReferenceEquals(AnneAdField, value) != true))
                    {
                        AnneAdField = value;
                        RaisePropertyChanged("AnneAd");
                    }
                }
            }

            
            public string BabaAd
            {
                get
                {
                    return BabaAdField;
                }
                set
                {
                    if ((object.ReferenceEquals(BabaAdField, value) != true))
                    {
                        BabaAdField = value;
                        RaisePropertyChanged("BabaAd");
                    }
                }
            }

            
            public System.Nullable<int> Birim
            {
                get
                {
                    return BirimField;
                }
                set
                {
                    if ((BirimField.Equals(value) != true))
                    {
                        BirimField = value;
                        RaisePropertyChanged("Birim");
                    }
                }
            }

            
            public KPSV2.Parametre Cinsiyet
            {
                get
                {
                    return CinsiyetField;
                }
                set
                {
                    if ((object.ReferenceEquals(CinsiyetField, value) != true))
                    {
                        CinsiyetField = value;
                        RaisePropertyChanged("Cinsiyet");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi DogumTarih
            {
                get
                {
                    return DogumTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(DogumTarihField, value) != true))
                    {
                        DogumTarihField = value;
                        RaisePropertyChanged("DogumTarih");
                    }
                }
            }

            
            public string DogumYer
            {
                get
                {
                    return DogumYerField;
                }
                set
                {
                    if ((object.ReferenceEquals(DogumYerField, value) != true))
                    {
                        DogumYerField = value;
                        RaisePropertyChanged("DogumYer");
                    }
                }
            }

            
            public System.Nullable<int> DogumYerKod
            {
                get
                {
                    return DogumYerKodField;
                }
                set
                {
                    if ((DogumYerKodField.Equals(value) != true))
                    {
                        DogumYerKodField = value;
                        RaisePropertyChanged("DogumYerKod");
                    }
                }
            }

            
            public KPSV2.Parametre HataBilgisi
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

            
            public System.Nullable<long> KartKayitNo
            {
                get
                {
                    return KartKayitNoField;
                }
                set
                {
                    if ((KartKayitNoField.Equals(value) != true))
                    {
                        KartKayitNoField = value;
                        RaisePropertyChanged("KartKayitNo");
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

            
            public KPSV2.Parametre MedeniHal
            {
                get
                {
                    return MedeniHalField;
                }
                set
                {
                    if ((object.ReferenceEquals(MedeniHalField, value) != true))
                    {
                        MedeniHalField = value;
                        RaisePropertyChanged("MedeniHal");
                    }
                }
            }

            
            public System.Nullable<int> No
            {
                get
                {
                    return NoField;
                }
                set
                {
                    if ((NoField.Equals(value) != true))
                    {
                        NoField = value;
                        RaisePropertyChanged("No");
                    }
                }
            }

            
            public string OncekiSoyad
            {
                get
                {
                    return OncekiSoyadField;
                }
                set
                {
                    if ((object.ReferenceEquals(OncekiSoyadField, value) != true))
                    {
                        OncekiSoyadField = value;
                        RaisePropertyChanged("OncekiSoyad");
                    }
                }
            }

            
            public string Seri
            {
                get
                {
                    return SeriField;
                }
                set
                {
                    if ((object.ReferenceEquals(SeriField, value) != true))
                    {
                        SeriField = value;
                        RaisePropertyChanged("Seri");
                    }
                }
            }

            
            public string Soyad
            {
                get
                {
                    return SoyadField;
                }
                set
                {
                    if ((object.ReferenceEquals(SoyadField, value) != true))
                    {
                        SoyadField = value;
                        RaisePropertyChanged("Soyad");
                    }
                }
            }

            
            public KPSV2.Parametre Uyruk
            {
                get
                {
                    return UyrukField;
                }
                set
                {
                    if ((object.ReferenceEquals(UyrukField, value) != true))
                    {
                        UyrukField = value;
                        RaisePropertyChanged("Uyruk");
                    }
                }
            }

            
            public KPSV2.Parametre VerilisNeden
            {
                get
                {
                    return VerilisNedenField;
                }
                set
                {
                    if ((object.ReferenceEquals(VerilisNedenField, value) != true))
                    {
                        VerilisNedenField = value;
                        RaisePropertyChanged("VerilisNeden");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi VerilmeTarih
            {
                get
                {
                    return VerilmeTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(VerilmeTarihField, value) != true))
                    {
                        VerilmeTarihField = value;
                        RaisePropertyChanged("VerilmeTarih");
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
        public partial class BeldeAdresi : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BagimsizBolumDurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BagimsizBolumTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaAdaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaBlokAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BinaDurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BinaKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> BinaNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BinaNumaratajTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaPaftaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaParselField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaSiteAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BinaYapiTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CsbmField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> CsbmKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DisKapiNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

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
            private KPSV2.Parametre YapiKullanimAmacField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YolAltiKatSayisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YolUstuKatSayisiField;
            
            public KPSV2.Parametre BagimsizBolumDurum
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

            
            public KPSV2.Parametre BagimsizBolumTipi
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

            
            public KPSV2.Parametre BinaDurum
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

            
            public KPSV2.Parametre BinaNumaratajTipi
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

            
            public KPSV2.Parametre BinaYapiTipi
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

            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.Parametre YapiKullanimAmac
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
        public partial class TarihBilgisi : object, System.ComponentModel.INotifyPropertyChanged
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
        public partial class IlIlceMerkezAdresi : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BagimsizBolumDurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BagimsizBolumTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaAdaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaBlokAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BinaDurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BinaKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> BinaNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BinaNumaratajTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaPaftaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaParselField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaSiteAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BinaYapiTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CsbmField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> CsbmKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DisKapiNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

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
            private KPSV2.Parametre YapiKullanimAmacField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YolAltiKatSayisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YolUstuKatSayisiField;
            
            public KPSV2.Parametre BagimsizBolumDurum
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

            
            public KPSV2.Parametre BagimsizBolumTipi
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

            
            public KPSV2.Parametre BinaDurum
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

            
            public KPSV2.Parametre BinaNumaratajTipi
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

            
            public KPSV2.Parametre BinaYapiTipi
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

            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.Parametre YapiKullanimAmac
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
        public partial class KoyAdresi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BagimsizBolumDurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BagimsizBolumTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaAdaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaBlokAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BinaDurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BinaKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> BinaNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BinaNumaratajTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaPaftaField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaParselField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaSiteAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BinaYapiTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CsbmField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> CsbmKoduField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DisKapiNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

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
            private KPSV2.Parametre YapiKullanimAmacField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YolAltiKatSayisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> YolUstuKatSayisiField;
            
            public KPSV2.Parametre BagimsizBolumDurum
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

            
            public KPSV2.Parametre BagimsizBolumTipi
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

            
            public KPSV2.Parametre BinaDurum
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

            
            public KPSV2.Parametre BinaNumaratajTipi
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

            
            public KPSV2.Parametre BinaYapiTipi
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

            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.Parametre YapiKullanimAmac
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
        public partial class YurtDisiAdresi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<System.DateTime> DisTemsDuzeltmeBeyanTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<System.DateTime> DisTemsDuzeltmeKararTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre DisTemsDuzeltmeNedenField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre DisTemsilcilikField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string YabanciAdresField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string YabanciSehirField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre YabanciUlkeField;
            
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

            
            public KPSV2.Parametre DisTemsDuzeltmeNeden
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

            
            public KPSV2.Parametre DisTemsilcilik
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

            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.Parametre YabanciUlke
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

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class DurumBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre DinField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre DurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre MedeniHalField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi OlumTarihField;
            
            public KPSV2.Parametre Din
            {
                get
                {
                    return DinField;
                }
                set
                {
                    if ((object.ReferenceEquals(DinField, value) != true))
                    {
                        DinField = value;
                        RaisePropertyChanged("Din");
                    }
                }
            }

            
            public KPSV2.Parametre Durum
            {
                get
                {
                    return DurumField;
                }
                set
                {
                    if ((object.ReferenceEquals(DurumField, value) != true))
                    {
                        DurumField = value;
                        RaisePropertyChanged("Durum");
                    }
                }
            }

            
            public KPSV2.Parametre MedeniHal
            {
                get
                {
                    return MedeniHalField;
                }
                set
                {
                    if ((object.ReferenceEquals(MedeniHalField, value) != true))
                    {
                        MedeniHalField = value;
                        RaisePropertyChanged("MedeniHal");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi OlumTarih
            {
                get
                {
                    return OlumTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(OlumTarihField, value) != true))
                    {
                        OlumTarihField = value;
                        RaisePropertyChanged("OlumTarih");
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
        public partial class TemelBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnneAdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaAdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre CinsiyetField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi DogumTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumYerField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadField;
            
            public string Ad
            {
                get
                {
                    return AdField;
                }
                set
                {
                    if ((object.ReferenceEquals(AdField, value) != true))
                    {
                        AdField = value;
                        RaisePropertyChanged("Ad");
                    }
                }
            }

            
            public string AnneAd
            {
                get
                {
                    return AnneAdField;
                }
                set
                {
                    if ((object.ReferenceEquals(AnneAdField, value) != true))
                    {
                        AnneAdField = value;
                        RaisePropertyChanged("AnneAd");
                    }
                }
            }

            
            public string BabaAd
            {
                get
                {
                    return BabaAdField;
                }
                set
                {
                    if ((object.ReferenceEquals(BabaAdField, value) != true))
                    {
                        BabaAdField = value;
                        RaisePropertyChanged("BabaAd");
                    }
                }
            }

            
            public KPSV2.Parametre Cinsiyet
            {
                get
                {
                    return CinsiyetField;
                }
                set
                {
                    if ((object.ReferenceEquals(CinsiyetField, value) != true))
                    {
                        CinsiyetField = value;
                        RaisePropertyChanged("Cinsiyet");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi DogumTarih
            {
                get
                {
                    return DogumTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(DogumTarihField, value) != true))
                    {
                        DogumTarihField = value;
                        RaisePropertyChanged("DogumTarih");
                    }
                }
            }

            
            public string DogumYer
            {
                get
                {
                    return DogumYerField;
                }
                set
                {
                    if ((object.ReferenceEquals(DogumYerField, value) != true))
                    {
                        DogumYerField = value;
                        RaisePropertyChanged("DogumYer");
                    }
                }
            }

            
            public string Soyad
            {
                get
                {
                    return SoyadField;
                }
                set
                {
                    if ((object.ReferenceEquals(SoyadField, value) != true))
                    {
                        SoyadField = value;
                        RaisePropertyChanged("Soyad");
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
        public partial class TCGeciciKimlikBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnneAdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaAdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BelgeNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre CinsiyetField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi DogumTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi DuzenlenmeTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre DuzenleyenIlceField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string OncekiSoyadField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi SonGecerlilikTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> TCKimlikNoField;
            
            public string Ad
            {
                get
                {
                    return AdField;
                }
                set
                {
                    if ((object.ReferenceEquals(AdField, value) != true))
                    {
                        AdField = value;
                        RaisePropertyChanged("Ad");
                    }
                }
            }

            
            public string AnneAd
            {
                get
                {
                    return AnneAdField;
                }
                set
                {
                    if ((object.ReferenceEquals(AnneAdField, value) != true))
                    {
                        AnneAdField = value;
                        RaisePropertyChanged("AnneAd");
                    }
                }
            }

            
            public string BabaAd
            {
                get
                {
                    return BabaAdField;
                }
                set
                {
                    if ((object.ReferenceEquals(BabaAdField, value) != true))
                    {
                        BabaAdField = value;
                        RaisePropertyChanged("BabaAd");
                    }
                }
            }

            
            public string BelgeNo
            {
                get
                {
                    return BelgeNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(BelgeNoField, value) != true))
                    {
                        BelgeNoField = value;
                        RaisePropertyChanged("BelgeNo");
                    }
                }
            }

            
            public KPSV2.Parametre Cinsiyet
            {
                get
                {
                    return CinsiyetField;
                }
                set
                {
                    if ((object.ReferenceEquals(CinsiyetField, value) != true))
                    {
                        CinsiyetField = value;
                        RaisePropertyChanged("Cinsiyet");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi DogumTarih
            {
                get
                {
                    return DogumTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(DogumTarihField, value) != true))
                    {
                        DogumTarihField = value;
                        RaisePropertyChanged("DogumTarih");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi DuzenlenmeTarih
            {
                get
                {
                    return DuzenlenmeTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(DuzenlenmeTarihField, value) != true))
                    {
                        DuzenlenmeTarihField = value;
                        RaisePropertyChanged("DuzenlenmeTarih");
                    }
                }
            }

            
            public KPSV2.Parametre DuzenleyenIlce
            {
                get
                {
                    return DuzenleyenIlceField;
                }
                set
                {
                    if ((object.ReferenceEquals(DuzenleyenIlceField, value) != true))
                    {
                        DuzenleyenIlceField = value;
                        RaisePropertyChanged("DuzenleyenIlce");
                    }
                }
            }

            
            public KPSV2.Parametre HataBilgisi
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

            
            public string OncekiSoyad
            {
                get
                {
                    return OncekiSoyadField;
                }
                set
                {
                    if ((object.ReferenceEquals(OncekiSoyadField, value) != true))
                    {
                        OncekiSoyadField = value;
                        RaisePropertyChanged("OncekiSoyad");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi SonGecerlilikTarih
            {
                get
                {
                    return SonGecerlilikTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(SonGecerlilikTarihField, value) != true))
                    {
                        SonGecerlilikTarihField = value;
                        RaisePropertyChanged("SonGecerlilikTarih");
                    }
                }
            }

            
            public string Soyad
            {
                get
                {
                    return SoyadField;
                }
                set
                {
                    if ((object.ReferenceEquals(SoyadField, value) != true))
                    {
                        SoyadField = value;
                        RaisePropertyChanged("Soyad");
                    }
                }
            }

            
            public System.Nullable<long> TCKimlikNo
            {
                get
                {
                    return TCKimlikNoField;
                }
                set
                {
                    if ((TCKimlikNoField.Equals(value) != true))
                    {
                        TCKimlikNoField = value;
                        RaisePropertyChanged("TCKimlikNo");
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
        public partial class TCKisiBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> AnneTCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BabaTCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> DogumYerKodField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.DurumBilgisi DurumBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> EsTCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.KayitYeriBilgisi KayitYeriBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> TCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TemelBilgisi TemelBilgisiField;
            
            public System.Nullable<long> AnneTCKimlikNo
            {
                get
                {
                    return AnneTCKimlikNoField;
                }
                set
                {
                    if ((AnneTCKimlikNoField.Equals(value) != true))
                    {
                        AnneTCKimlikNoField = value;
                        RaisePropertyChanged("AnneTCKimlikNo");
                    }
                }
            }

            
            public System.Nullable<long> BabaTCKimlikNo
            {
                get
                {
                    return BabaTCKimlikNoField;
                }
                set
                {
                    if ((BabaTCKimlikNoField.Equals(value) != true))
                    {
                        BabaTCKimlikNoField = value;
                        RaisePropertyChanged("BabaTCKimlikNo");
                    }
                }
            }

            
            public System.Nullable<int> DogumYerKod
            {
                get
                {
                    return DogumYerKodField;
                }
                set
                {
                    if ((DogumYerKodField.Equals(value) != true))
                    {
                        DogumYerKodField = value;
                        RaisePropertyChanged("DogumYerKod");
                    }
                }
            }

            
            public KPSV2.DurumBilgisi DurumBilgisi
            {
                get
                {
                    return DurumBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(DurumBilgisiField, value) != true))
                    {
                        DurumBilgisiField = value;
                        RaisePropertyChanged("DurumBilgisi");
                    }
                }
            }

            
            public System.Nullable<long> EsTCKimlikNo
            {
                get
                {
                    return EsTCKimlikNoField;
                }
                set
                {
                    if ((EsTCKimlikNoField.Equals(value) != true))
                    {
                        EsTCKimlikNoField = value;
                        RaisePropertyChanged("EsTCKimlikNo");
                    }
                }
            }

            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.KayitYeriBilgisi KayitYeriBilgisi
            {
                get
                {
                    return KayitYeriBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(KayitYeriBilgisiField, value) != true))
                    {
                        KayitYeriBilgisiField = value;
                        RaisePropertyChanged("KayitYeriBilgisi");
                    }
                }
            }

            
            public System.Nullable<long> TCKimlikNo
            {
                get
                {
                    return TCKimlikNoField;
                }
                set
                {
                    if ((TCKimlikNoField.Equals(value) != true))
                    {
                        TCKimlikNoField = value;
                        RaisePropertyChanged("TCKimlikNo");
                    }
                }
            }

            
            public KPSV2.TemelBilgisi TemelBilgisi
            {
                get
                {
                    return TemelBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(TemelBilgisiField, value) != true))
                    {
                        TemelBilgisiField = value;
                        RaisePropertyChanged("TemelBilgisi");
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
        public partial class TCCuzdanBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnaAdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaAdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> CuzdanKayitNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre CuzdanVerilmeNedenField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi DogumTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumYerField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> NoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SeriField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> TCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre VerildigiIlceField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi VerilmeTarihField;
            
            public string Ad
            {
                get
                {
                    return AdField;
                }
                set
                {
                    if ((object.ReferenceEquals(AdField, value) != true))
                    {
                        AdField = value;
                        RaisePropertyChanged("Ad");
                    }
                }
            }

            
            public string AnaAd
            {
                get
                {
                    return AnaAdField;
                }
                set
                {
                    if ((object.ReferenceEquals(AnaAdField, value) != true))
                    {
                        AnaAdField = value;
                        RaisePropertyChanged("AnaAd");
                    }
                }
            }

            
            public string BabaAd
            {
                get
                {
                    return BabaAdField;
                }
                set
                {
                    if ((object.ReferenceEquals(BabaAdField, value) != true))
                    {
                        BabaAdField = value;
                        RaisePropertyChanged("BabaAd");
                    }
                }
            }

            
            public System.Nullable<long> CuzdanKayitNo
            {
                get
                {
                    return CuzdanKayitNoField;
                }
                set
                {
                    if ((CuzdanKayitNoField.Equals(value) != true))
                    {
                        CuzdanKayitNoField = value;
                        RaisePropertyChanged("CuzdanKayitNo");
                    }
                }
            }

            
            public KPSV2.Parametre CuzdanVerilmeNeden
            {
                get
                {
                    return CuzdanVerilmeNedenField;
                }
                set
                {
                    if ((object.ReferenceEquals(CuzdanVerilmeNedenField, value) != true))
                    {
                        CuzdanVerilmeNedenField = value;
                        RaisePropertyChanged("CuzdanVerilmeNeden");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi DogumTarih
            {
                get
                {
                    return DogumTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(DogumTarihField, value) != true))
                    {
                        DogumTarihField = value;
                        RaisePropertyChanged("DogumTarih");
                    }
                }
            }

            
            public string DogumYer
            {
                get
                {
                    return DogumYerField;
                }
                set
                {
                    if ((object.ReferenceEquals(DogumYerField, value) != true))
                    {
                        DogumYerField = value;
                        RaisePropertyChanged("DogumYer");
                    }
                }
            }

            
            public KPSV2.Parametre HataBilgisi
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

            
            public System.Nullable<int> No
            {
                get
                {
                    return NoField;
                }
                set
                {
                    if ((NoField.Equals(value) != true))
                    {
                        NoField = value;
                        RaisePropertyChanged("No");
                    }
                }
            }

            
            public string Seri
            {
                get
                {
                    return SeriField;
                }
                set
                {
                    if ((object.ReferenceEquals(SeriField, value) != true))
                    {
                        SeriField = value;
                        RaisePropertyChanged("Seri");
                    }
                }
            }

            
            public string Soyad
            {
                get
                {
                    return SoyadField;
                }
                set
                {
                    if ((object.ReferenceEquals(SoyadField, value) != true))
                    {
                        SoyadField = value;
                        RaisePropertyChanged("Soyad");
                    }
                }
            }

            
            public System.Nullable<long> TCKimlikNo
            {
                get
                {
                    return TCKimlikNoField;
                }
                set
                {
                    if ((TCKimlikNoField.Equals(value) != true))
                    {
                        TCKimlikNoField = value;
                        RaisePropertyChanged("TCKimlikNo");
                    }
                }
            }

            
            public KPSV2.Parametre VerildigiIlce
            {
                get
                {
                    return VerildigiIlceField;
                }
                set
                {
                    if ((object.ReferenceEquals(VerildigiIlceField, value) != true))
                    {
                        VerildigiIlceField = value;
                        RaisePropertyChanged("VerildigiIlce");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi VerilmeTarih
            {
                get
                {
                    return VerilmeTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(VerilmeTarihField, value) != true))
                    {
                        VerilmeTarihField = value;
                        RaisePropertyChanged("VerilmeTarih");
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
        public partial class TCKK : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnneAdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaAdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BasvuruNedenField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre CinsiyetField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi DogumTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumYerField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KayitNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SeriNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi SonGecerlilikTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> TCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre TeslimEdenBirimField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi TeslimTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string VerenMakamField;
           
            public string Ad
            {
                get
                {
                    return AdField;
                }
                set
                {
                    if ((object.ReferenceEquals(AdField, value) != true))
                    {
                        AdField = value;
                        RaisePropertyChanged("Ad");
                    }
                }
            }

            
            public string AnneAd
            {
                get
                {
                    return AnneAdField;
                }
                set
                {
                    if ((object.ReferenceEquals(AnneAdField, value) != true))
                    {
                        AnneAdField = value;
                        RaisePropertyChanged("AnneAd");
                    }
                }
            }

            
            public string BabaAd
            {
                get
                {
                    return BabaAdField;
                }
                set
                {
                    if ((object.ReferenceEquals(BabaAdField, value) != true))
                    {
                        BabaAdField = value;
                        RaisePropertyChanged("BabaAd");
                    }
                }
            }

            
            public KPSV2.Parametre BasvuruNeden
            {
                get
                {
                    return BasvuruNedenField;
                }
                set
                {
                    if ((object.ReferenceEquals(BasvuruNedenField, value) != true))
                    {
                        BasvuruNedenField = value;
                        RaisePropertyChanged("BasvuruNeden");
                    }
                }
            }

            
            public KPSV2.Parametre Cinsiyet
            {
                get
                {
                    return CinsiyetField;
                }
                set
                {
                    if ((object.ReferenceEquals(CinsiyetField, value) != true))
                    {
                        CinsiyetField = value;
                        RaisePropertyChanged("Cinsiyet");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi DogumTarih
            {
                get
                {
                    return DogumTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(DogumTarihField, value) != true))
                    {
                        DogumTarihField = value;
                        RaisePropertyChanged("DogumTarih");
                    }
                }
            }

            
            public string DogumYer
            {
                get
                {
                    return DogumYerField;
                }
                set
                {
                    if ((object.ReferenceEquals(DogumYerField, value) != true))
                    {
                        DogumYerField = value;
                        RaisePropertyChanged("DogumYer");
                    }
                }
            }

            
            public KPSV2.Parametre HataBilgisi
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

            
            public System.Nullable<long> KayitNo
            {
                get
                {
                    return KayitNoField;
                }
                set
                {
                    if ((KayitNoField.Equals(value) != true))
                    {
                        KayitNoField = value;
                        RaisePropertyChanged("KayitNo");
                    }
                }
            }

            
            public string SeriNo
            {
                get
                {
                    return SeriNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(SeriNoField, value) != true))
                    {
                        SeriNoField = value;
                        RaisePropertyChanged("SeriNo");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi SonGecerlilikTarih
            {
                get
                {
                    return SonGecerlilikTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(SonGecerlilikTarihField, value) != true))
                    {
                        SonGecerlilikTarihField = value;
                        RaisePropertyChanged("SonGecerlilikTarih");
                    }
                }
            }

            
            public string Soyad
            {
                get
                {
                    return SoyadField;
                }
                set
                {
                    if ((object.ReferenceEquals(SoyadField, value) != true))
                    {
                        SoyadField = value;
                        RaisePropertyChanged("Soyad");
                    }
                }
            }

            
            public System.Nullable<long> TCKimlikNo
            {
                get
                {
                    return TCKimlikNoField;
                }
                set
                {
                    if ((TCKimlikNoField.Equals(value) != true))
                    {
                        TCKimlikNoField = value;
                        RaisePropertyChanged("TCKimlikNo");
                    }
                }
            }

            
            public KPSV2.Parametre TeslimEdenBirim
            {
                get
                {
                    return TeslimEdenBirimField;
                }
                set
                {
                    if ((object.ReferenceEquals(TeslimEdenBirimField, value) != true))
                    {
                        TeslimEdenBirimField = value;
                        RaisePropertyChanged("TeslimEdenBirim");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi TeslimTarih
            {
                get
                {
                    return TeslimTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(TeslimTarihField, value) != true))
                    {
                        TeslimTarihField = value;
                        RaisePropertyChanged("TeslimTarih");
                    }
                }
            }

            
            public string VerenMakam
            {
                get
                {
                    return VerenMakamField;
                }
                set
                {
                    if ((object.ReferenceEquals(VerenMakamField, value) != true))
                    {
                        VerenMakamField = value;
                        RaisePropertyChanged("VerenMakam");
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
        public partial class KayitYeriBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> AileSiraNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> BireySiraNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre CiltField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre IlField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre IlceField;
            
            public System.Nullable<int> AileSiraNo
            {
                get
                {
                    return AileSiraNoField;
                }
                set
                {
                    if ((AileSiraNoField.Equals(value) != true))
                    {
                        AileSiraNoField = value;
                        RaisePropertyChanged("AileSiraNo");
                    }
                }
            }

            
            public System.Nullable<int> BireySiraNo
            {
                get
                {
                    return BireySiraNoField;
                }
                set
                {
                    if ((BireySiraNoField.Equals(value) != true))
                    {
                        BireySiraNoField = value;
                        RaisePropertyChanged("BireySiraNo");
                    }
                }
            }

            
            public KPSV2.Parametre Cilt
            {
                get
                {
                    return CiltField;
                }
                set
                {
                    if ((object.ReferenceEquals(CiltField, value) != true))
                    {
                        CiltField = value;
                        RaisePropertyChanged("Cilt");
                    }
                }
            }

            
            public KPSV2.Parametre Il
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

            
            public KPSV2.Parametre Ilce
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
        public partial class YabanciKisiBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> AnneKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BabaKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre BitisTarihiBelirsizOlmaNedenField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi DogumTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> DogumYerKodField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> EsKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> GercekKisiKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<System.DateTime> IzinBaslangicTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<System.DateTime> IzinBitisTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre IzinDuzenlenenIlField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IzinNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre KaynakBirimField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KazanilanTCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi OlumTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TemelBilgisi TemelBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre UyrukField;
            
            public System.Nullable<long> AnneKimlikNo
            {
                get
                {
                    return AnneKimlikNoField;
                }
                set
                {
                    if ((AnneKimlikNoField.Equals(value) != true))
                    {
                        AnneKimlikNoField = value;
                        RaisePropertyChanged("AnneKimlikNo");
                    }
                }
            }

            
            public System.Nullable<long> BabaKimlikNo
            {
                get
                {
                    return BabaKimlikNoField;
                }
                set
                {
                    if ((BabaKimlikNoField.Equals(value) != true))
                    {
                        BabaKimlikNoField = value;
                        RaisePropertyChanged("BabaKimlikNo");
                    }
                }
            }

            
            public KPSV2.Parametre BitisTarihiBelirsizOlmaNeden
            {
                get
                {
                    return BitisTarihiBelirsizOlmaNedenField;
                }
                set
                {
                    if ((object.ReferenceEquals(BitisTarihiBelirsizOlmaNedenField, value) != true))
                    {
                        BitisTarihiBelirsizOlmaNedenField = value;
                        RaisePropertyChanged("BitisTarihiBelirsizOlmaNeden");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi DogumTarih
            {
                get
                {
                    return DogumTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(DogumTarihField, value) != true))
                    {
                        DogumTarihField = value;
                        RaisePropertyChanged("DogumTarih");
                    }
                }
            }

            
            public System.Nullable<int> DogumYerKod
            {
                get
                {
                    return DogumYerKodField;
                }
                set
                {
                    if ((DogumYerKodField.Equals(value) != true))
                    {
                        DogumYerKodField = value;
                        RaisePropertyChanged("DogumYerKod");
                    }
                }
            }

            
            public System.Nullable<long> EsKimlikNo
            {
                get
                {
                    return EsKimlikNoField;
                }
                set
                {
                    if ((EsKimlikNoField.Equals(value) != true))
                    {
                        EsKimlikNoField = value;
                        RaisePropertyChanged("EsKimlikNo");
                    }
                }
            }

            
            public System.Nullable<long> GercekKisiKimlikNo
            {
                get
                {
                    return GercekKisiKimlikNoField;
                }
                set
                {
                    if ((GercekKisiKimlikNoField.Equals(value) != true))
                    {
                        GercekKisiKimlikNoField = value;
                        RaisePropertyChanged("GercekKisiKimlikNo");
                    }
                }
            }

            
            public KPSV2.Parametre HataBilgisi
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

            
            public System.Nullable<System.DateTime> IzinBaslangicTarih
            {
                get
                {
                    return IzinBaslangicTarihField;
                }
                set
                {
                    if ((IzinBaslangicTarihField.Equals(value) != true))
                    {
                        IzinBaslangicTarihField = value;
                        RaisePropertyChanged("IzinBaslangicTarih");
                    }
                }
            }

            
            public System.Nullable<System.DateTime> IzinBitisTarih
            {
                get
                {
                    return IzinBitisTarihField;
                }
                set
                {
                    if ((IzinBitisTarihField.Equals(value) != true))
                    {
                        IzinBitisTarihField = value;
                        RaisePropertyChanged("IzinBitisTarih");
                    }
                }
            }

            
            public KPSV2.Parametre IzinDuzenlenenIl
            {
                get
                {
                    return IzinDuzenlenenIlField;
                }
                set
                {
                    if ((object.ReferenceEquals(IzinDuzenlenenIlField, value) != true))
                    {
                        IzinDuzenlenenIlField = value;
                        RaisePropertyChanged("IzinDuzenlenenIl");
                    }
                }
            }

            
            public string IzinNo
            {
                get
                {
                    return IzinNoField;
                }
                set
                {
                    if ((object.ReferenceEquals(IzinNoField, value) != true))
                    {
                        IzinNoField = value;
                        RaisePropertyChanged("IzinNo");
                    }
                }
            }

            
            public KPSV2.Parametre KaynakBirim
            {
                get
                {
                    return KaynakBirimField;
                }
                set
                {
                    if ((object.ReferenceEquals(KaynakBirimField, value) != true))
                    {
                        KaynakBirimField = value;
                        RaisePropertyChanged("KaynakBirim");
                    }
                }
            }

            
            public System.Nullable<long> KazanilanTCKimlikNo
            {
                get
                {
                    return KazanilanTCKimlikNoField;
                }
                set
                {
                    if ((KazanilanTCKimlikNoField.Equals(value) != true))
                    {
                        KazanilanTCKimlikNoField = value;
                        RaisePropertyChanged("KazanilanTCKimlikNo");
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

            
            public KPSV2.TarihBilgisi OlumTarih
            {
                get
                {
                    return OlumTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(OlumTarihField, value) != true))
                    {
                        OlumTarihField = value;
                        RaisePropertyChanged("OlumTarih");
                    }
                }
            }

            
            public KPSV2.TemelBilgisi TemelBilgisi
            {
                get
                {
                    return TemelBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(TemelBilgisiField, value) != true))
                    {
                        TemelBilgisiField = value;
                        RaisePropertyChanged("TemelBilgisi");
                    }
                }
            }

            
            public KPSV2.Parametre Uyruk
            {
                get
                {
                    return UyrukField;
                }
                set
                {
                    if ((object.ReferenceEquals(UyrukField, value) != true))
                    {
                        UyrukField = value;
                        RaisePropertyChanged("Uyruk");
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
        public partial class KisiSorgulaKisiBilgileriCO : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnneAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaAdiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.ECinsiyet CinsiyetField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.DateTime DogumTarihiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumYeriField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadiField;
            
            public string Adi
            {
                get
                {
                    return AdiField;
                }
                set
                {
                    if ((object.ReferenceEquals(AdiField, value) != true))
                    {
                        AdiField = value;
                        RaisePropertyChanged("Adi");
                    }
                }
            }

            
            public string AnneAdi
            {
                get
                {
                    return AnneAdiField;
                }
                set
                {
                    if ((object.ReferenceEquals(AnneAdiField, value) != true))
                    {
                        AnneAdiField = value;
                        RaisePropertyChanged("AnneAdi");
                    }
                }
            }

            
            public string BabaAdi
            {
                get
                {
                    return BabaAdiField;
                }
                set
                {
                    if ((object.ReferenceEquals(BabaAdiField, value) != true))
                    {
                        BabaAdiField = value;
                        RaisePropertyChanged("BabaAdi");
                    }
                }
            }

            
            public KPSV2.ECinsiyet Cinsiyet
            {
                get
                {
                    return CinsiyetField;
                }
                set
                {
                    if ((CinsiyetField.Equals(value) != true))
                    {
                        CinsiyetField = value;
                        RaisePropertyChanged("Cinsiyet");
                    }
                }
            }

            
            public System.DateTime DogumTarihi
            {
                get
                {
                    return DogumTarihiField;
                }
                set
                {
                    if ((DogumTarihiField.Equals(value) != true))
                    {
                        DogumTarihiField = value;
                        RaisePropertyChanged("DogumTarihi");
                    }
                }
            }

            
            public string DogumYeri
            {
                get
                {
                    return DogumYeriField;
                }
                set
                {
                    if ((object.ReferenceEquals(DogumYeriField, value) != true))
                    {
                        DogumYeriField = value;
                        RaisePropertyChanged("DogumYeri");
                    }
                }
            }

            
            public string Soyadi
            {
                get
                {
                    return SoyadiField;
                }
                set
                {
                    if ((object.ReferenceEquals(SoyadiField, value) != true))
                    {
                        SoyadiField = value;
                        RaisePropertyChanged("Soyadi");
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

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        public enum ECinsiyet : int
        {


            BILINMEYEN = 0,


            ERKEK = 1,


            KADIN = 2,
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KpsServisSonucuOfTCKisiBilgisiZmZ26SC9 : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TCKisiBilgisi SonucField;
            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.TCKisiBilgisi Sonuc
            {
                get
                {
                    return SonucField;
                }
                set
                {
                    if ((object.ReferenceEquals(SonucField, value) != true))
                    {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class KpsServisSonucuKisiTemelBilgisi : KPSV2.KpsServisSonucuOfTCKisiBilgisiZmZ26SC9
        {
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KpsServisSonucuOfKisiAdresBilgisiZmZ26SC9 : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.KisiAdresBilgisi SonucField;
            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.KisiAdresBilgisi Sonuc
            {
                get
                {
                    return SonucField;
                }
                set
                {
                    if ((object.ReferenceEquals(SonucField, value) != true))
                    {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class KpsServisSonucuKisiAdresBilgisi : KPSV2.KpsServisSonucuOfKisiAdresBilgisiZmZ26SC9
        {
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class AileBireyleriSorgulaKriter : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private long TCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.EAileSorguTipi TipField;
            
            public long TCKimlikNo
            {
                get
                {
                    return TCKimlikNoField;
                }
                set
                {
                    if ((TCKimlikNoField.Equals(value) != true))
                    {
                        TCKimlikNoField = value;
                        RaisePropertyChanged("TCKimlikNo");
                    }
                }
            }

            
            public KPSV2.EAileSorguTipi Tip
            {
                get
                {
                    return TipField;
                }
                set
                {
                    if ((TipField.Equals(value) != true))
                    {
                        TipField = value;
                        RaisePropertyChanged("Tip");
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

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        public enum EAileSorguTipi : int
        {
            Aile = 0,
            TumAile = 1,
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KpsServisSonucuOfAileBilgisiZmZ26SC9 : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.AileBilgisi SonucField;
            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.AileBilgisi Sonuc
            {
                get
                {
                    return SonucField;
                }
                set
                {
                    if ((object.ReferenceEquals(SonucField, value) != true))
                    {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class AileBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.KisiBilgisi[] AileKisiListesiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TCKisiBilgisi KisiBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> TCKimlikNoField;
            
            public KPSV2.KisiBilgisi[] AileKisiListesi
            {
                get
                {
                    return AileKisiListesiField;
                }
                set
                {
                    if ((object.ReferenceEquals(AileKisiListesiField, value) != true))
                    {
                        AileKisiListesiField = value;
                        RaisePropertyChanged("AileKisiListesi");
                    }
                }
            }

            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.TCKisiBilgisi KisiBilgisi
            {
                get
                {
                    return KisiBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(KisiBilgisiField, value) != true))
                    {
                        KisiBilgisiField = value;
                        RaisePropertyChanged("KisiBilgisi");
                    }
                }
            }

            
            public System.Nullable<long> TCKimlikNo
            {
                get
                {
                    return TCKimlikNoField;
                }
                set
                {
                    if ((TCKimlikNoField.Equals(value) != true))
                    {
                        TCKimlikNoField = value;
                        RaisePropertyChanged("TCKimlikNo");
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
        public partial class KpsServisSonucuAileBilgisi : KPSV2.KpsServisSonucuOfAileBilgisiZmZ26SC9
        {
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KisiBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.DurumBilgisi DurumBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.KayitYeriBilgisi KayitYeriBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> TCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TemelBilgisi TemelBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre YakinlikField;
            
            public KPSV2.DurumBilgisi DurumBilgisi
            {
                get
                {
                    return DurumBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(DurumBilgisiField, value) != true))
                    {
                        DurumBilgisiField = value;
                        RaisePropertyChanged("DurumBilgisi");
                    }
                }
            }

            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.KayitYeriBilgisi KayitYeriBilgisi
            {
                get
                {
                    return KayitYeriBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(KayitYeriBilgisiField, value) != true))
                    {
                        KayitYeriBilgisiField = value;
                        RaisePropertyChanged("KayitYeriBilgisi");
                    }
                }
            }

            
            public System.Nullable<long> TCKimlikNo
            {
                get
                {
                    return TCKimlikNoField;
                }
                set
                {
                    if ((TCKimlikNoField.Equals(value) != true))
                    {
                        TCKimlikNoField = value;
                        RaisePropertyChanged("TCKimlikNo");
                    }
                }
            }

            
            public KPSV2.TemelBilgisi TemelBilgisi
            {
                get
                {
                    return TemelBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(TemelBilgisiField, value) != true))
                    {
                        TemelBilgisiField = value;
                        RaisePropertyChanged("TemelBilgisi");
                    }
                }
            }

            
            public KPSV2.Parametre Yakinlik
            {
                get
                {
                    return YakinlikField;
                }
                set
                {
                    if ((object.ReferenceEquals(YakinlikField, value) != true))
                    {
                        YakinlikField = value;
                        RaisePropertyChanged("Yakinlik");
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
        public partial class KpsServisSonucuOfGenelNufusKayitOrnegiZmZ26SC9 : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.GenelNufusKayitOrnegi SonucField;
            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.GenelNufusKayitOrnegi Sonuc
            {
                get
                {
                    return SonucField;
                }
                set
                {
                    if ((object.ReferenceEquals(SonucField, value) != true))
                    {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class GenelNufusKayitOrnegi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.NkoMaviKart NkoMaviKartField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Nko NkoVatandasField;
            
            public KPSV2.NkoMaviKart NkoMaviKart
            {
                get
                {
                    return NkoMaviKartField;
                }
                set
                {
                    if ((object.ReferenceEquals(NkoMaviKartField, value) != true))
                    {
                        NkoMaviKartField = value;
                        RaisePropertyChanged("NkoMaviKart");
                    }
                }
            }

            
            public KPSV2.Nko NkoVatandas
            {
                get
                {
                    return NkoVatandasField;
                }
                set
                {
                    if ((object.ReferenceEquals(NkoVatandasField, value) != true))
                    {
                        NkoVatandasField = value;
                        RaisePropertyChanged("NkoVatandas");
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
        public partial class KpsServisSonucuGenelNufusKayitOrnegi : KPSV2.KpsServisSonucuOfGenelNufusKayitOrnegiZmZ26SC9
        {
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class NkoMaviKart : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.NkoMaviKartKisi[] KisilerField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre NkoTuruField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.NkoMaviKartOlay[] OlaylarField;
            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.NkoMaviKartKisi[] Kisiler
            {
                get
                {
                    return KisilerField;
                }
                set
                {
                    if ((object.ReferenceEquals(KisilerField, value) != true))
                    {
                        KisilerField = value;
                        RaisePropertyChanged("Kisiler");
                    }
                }
            }

            
            public KPSV2.Parametre NkoTuru
            {
                get
                {
                    return NkoTuruField;
                }
                set
                {
                    if ((object.ReferenceEquals(NkoTuruField, value) != true))
                    {
                        NkoTuruField = value;
                        RaisePropertyChanged("NkoTuru");
                    }
                }
            }

            
            public KPSV2.NkoMaviKartOlay[] Olaylar
            {
                get
                {
                    return OlaylarField;
                }
                set
                {
                    if ((object.ReferenceEquals(OlaylarField, value) != true))
                    {
                        OlaylarField = value;
                        RaisePropertyChanged("Olaylar");
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
        public partial class Nko : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.KisiBilgisi[] KisilerField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre NkoTuruField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.NkoOlay[] OlaylarField;
            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.KisiBilgisi[] Kisiler
            {
                get
                {
                    return KisilerField;
                }
                set
                {
                    if ((object.ReferenceEquals(KisilerField, value) != true))
                    {
                        KisilerField = value;
                        RaisePropertyChanged("Kisiler");
                    }
                }
            }

            
            public KPSV2.Parametre NkoTuru
            {
                get
                {
                    return NkoTuruField;
                }
                set
                {
                    if ((object.ReferenceEquals(NkoTuruField, value) != true))
                    {
                        NkoTuruField = value;
                        RaisePropertyChanged("NkoTuru");
                    }
                }
            }

            
            public KPSV2.NkoOlay[] Olaylar
            {
                get
                {
                    return OlaylarField;
                }
                set
                {
                    if ((object.ReferenceEquals(OlaylarField, value) != true))
                    {
                        OlaylarField = value;
                        RaisePropertyChanged("Olaylar");
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
        public partial class NkoMaviKartKisi : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> AnneKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BabaKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi BosanmaTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.NkoMaviKartKisiDurumBilgisi DurumBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> EsKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi EvlenmeTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TemelBilgisi TemelBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi TescilTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre UlkeField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre YakinlikKodField;

            public System.Nullable<long> AnneKimlikNo
            {
                get
                {
                    return AnneKimlikNoField;
                }
                set
                {
                    if ((AnneKimlikNoField.Equals(value) != true))
                    {
                        AnneKimlikNoField = value;
                        RaisePropertyChanged("AnneKimlikNo");
                    }
                }
            }

            
            public System.Nullable<long> BabaKimlikNo
            {
                get
                {
                    return BabaKimlikNoField;
                }
                set
                {
                    if ((BabaKimlikNoField.Equals(value) != true))
                    {
                        BabaKimlikNoField = value;
                        RaisePropertyChanged("BabaKimlikNo");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi BosanmaTarih
            {
                get
                {
                    return BosanmaTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(BosanmaTarihField, value) != true))
                    {
                        BosanmaTarihField = value;
                        RaisePropertyChanged("BosanmaTarih");
                    }
                }
            }

            
            public KPSV2.NkoMaviKartKisiDurumBilgisi DurumBilgisi
            {
                get
                {
                    return DurumBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(DurumBilgisiField, value) != true))
                    {
                        DurumBilgisiField = value;
                        RaisePropertyChanged("DurumBilgisi");
                    }
                }
            }

            
            public System.Nullable<long> EsKimlikNo
            {
                get
                {
                    return EsKimlikNoField;
                }
                set
                {
                    if ((EsKimlikNoField.Equals(value) != true))
                    {
                        EsKimlikNoField = value;
                        RaisePropertyChanged("EsKimlikNo");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi EvlenmeTarih
            {
                get
                {
                    return EvlenmeTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(EvlenmeTarihField, value) != true))
                    {
                        EvlenmeTarihField = value;
                        RaisePropertyChanged("EvlenmeTarih");
                    }
                }
            }

            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.TemelBilgisi TemelBilgisi
            {
                get
                {
                    return TemelBilgisiField;
                }
                set
                {
                    if ((object.ReferenceEquals(TemelBilgisiField, value) != true))
                    {
                        TemelBilgisiField = value;
                        RaisePropertyChanged("TemelBilgisi");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi TescilTarih
            {
                get
                {
                    return TescilTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(TescilTarihField, value) != true))
                    {
                        TescilTarihField = value;
                        RaisePropertyChanged("TescilTarih");
                    }
                }
            }

            
            public KPSV2.Parametre Ulke
            {
                get
                {
                    return UlkeField;
                }
                set
                {
                    if ((object.ReferenceEquals(UlkeField, value) != true))
                    {
                        UlkeField = value;
                        RaisePropertyChanged("Ulke");
                    }
                }
            }

            
            public KPSV2.Parametre YakinlikKod
            {
                get
                {
                    return YakinlikKodField;
                }
                set
                {
                    if ((object.ReferenceEquals(YakinlikKodField, value) != true))
                    {
                        YakinlikKodField = value;
                        RaisePropertyChanged("YakinlikKod");
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
        public partial class NkoMaviKartOlay : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DusunceField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> KisiKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi OlayTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre OlayTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadField;
            
            public string Ad
            {
                get
                {
                    return AdField;
                }
                set
                {
                    if ((object.ReferenceEquals(AdField, value) != true))
                    {
                        AdField = value;
                        RaisePropertyChanged("Ad");
                    }
                }
            }

            
            public string Dusunce
            {
                get
                {
                    return DusunceField;
                }
                set
                {
                    if ((object.ReferenceEquals(DusunceField, value) != true))
                    {
                        DusunceField = value;
                        RaisePropertyChanged("Dusunce");
                    }
                }
            }

            
            public KPSV2.Parametre HataBilgisi
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

            
            public System.Nullable<long> KisiKimlikNo
            {
                get
                {
                    return KisiKimlikNoField;
                }
                set
                {
                    if ((KisiKimlikNoField.Equals(value) != true))
                    {
                        KisiKimlikNoField = value;
                        RaisePropertyChanged("KisiKimlikNo");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi OlayTarih
            {
                get
                {
                    return OlayTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(OlayTarihField, value) != true))
                    {
                        OlayTarihField = value;
                        RaisePropertyChanged("OlayTarih");
                    }
                }
            }

            
            public KPSV2.Parametre OlayTipi
            {
                get
                {
                    return OlayTipiField;
                }
                set
                {
                    if ((object.ReferenceEquals(OlayTipiField, value) != true))
                    {
                        OlayTipiField = value;
                        RaisePropertyChanged("OlayTipi");
                    }
                }
            }

            
            public string Soyad
            {
                get
                {
                    return SoyadField;
                }
                set
                {
                    if ((object.ReferenceEquals(SoyadField, value) != true))
                    {
                        SoyadField = value;
                        RaisePropertyChanged("Soyad");
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
        public partial class NkoMaviKartKisiDurumBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre DurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre MedeniHalField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi OlumTarihField;
            
            public KPSV2.Parametre Durum
            {
                get
                {
                    return DurumField;
                }
                set
                {
                    if ((object.ReferenceEquals(DurumField, value) != true))
                    {
                        DurumField = value;
                        RaisePropertyChanged("Durum");
                    }
                }
            }

            
            public KPSV2.Parametre MedeniHal
            {
                get
                {
                    return MedeniHalField;
                }
                set
                {
                    if ((object.ReferenceEquals(MedeniHalField, value) != true))
                    {
                        MedeniHalField = value;
                        RaisePropertyChanged("MedeniHal");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi OlumTarih
            {
                get
                {
                    return OlumTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(OlumTarihField, value) != true))
                    {
                        OlumTarihField = value;
                        RaisePropertyChanged("OlumTarih");
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
        public partial class NkoOlay : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DusunceField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.KisiKayitYeriKodBilgisi KayitYeriField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> OlayKayitNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.TarihBilgisi OlayTarihField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre OlayTipiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadField;
            
            public string Ad
            {
                get
                {
                    return AdField;
                }
                set
                {
                    if ((object.ReferenceEquals(AdField, value) != true))
                    {
                        AdField = value;
                        RaisePropertyChanged("Ad");
                    }
                }
            }

            
            public string Dusunce
            {
                get
                {
                    return DusunceField;
                }
                set
                {
                    if ((object.ReferenceEquals(DusunceField, value) != true))
                    {
                        DusunceField = value;
                        RaisePropertyChanged("Dusunce");
                    }
                }
            }

            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.KisiKayitYeriKodBilgisi KayitYeri
            {
                get
                {
                    return KayitYeriField;
                }
                set
                {
                    if ((object.ReferenceEquals(KayitYeriField, value) != true))
                    {
                        KayitYeriField = value;
                        RaisePropertyChanged("KayitYeri");
                    }
                }
            }

            
            public System.Nullable<long> OlayKayitNo
            {
                get
                {
                    return OlayKayitNoField;
                }
                set
                {
                    if ((OlayKayitNoField.Equals(value) != true))
                    {
                        OlayKayitNoField = value;
                        RaisePropertyChanged("OlayKayitNo");
                    }
                }
            }

            
            public KPSV2.TarihBilgisi OlayTarih
            {
                get
                {
                    return OlayTarihField;
                }
                set
                {
                    if ((object.ReferenceEquals(OlayTarihField, value) != true))
                    {
                        OlayTarihField = value;
                        RaisePropertyChanged("OlayTarih");
                    }
                }
            }

            
            public KPSV2.Parametre OlayTipi
            {
                get
                {
                    return OlayTipiField;
                }
                set
                {
                    if ((object.ReferenceEquals(OlayTipiField, value) != true))
                    {
                        OlayTipiField = value;
                        RaisePropertyChanged("OlayTipi");
                    }
                }
            }

            
            public string Soyad
            {
                get
                {
                    return SoyadField;
                }
                set
                {
                    if ((object.ReferenceEquals(SoyadField, value) != true))
                    {
                        SoyadField = value;
                        RaisePropertyChanged("Soyad");
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
        public partial class KisiKayitYeriKodBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> AileSiraNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> BireySiraNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> CiltKodField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> IlceKodField;
            
            public System.Nullable<int> AileSiraNo
            {
                get
                {
                    return AileSiraNoField;
                }
                set
                {
                    if ((AileSiraNoField.Equals(value) != true))
                    {
                        AileSiraNoField = value;
                        RaisePropertyChanged("AileSiraNo");
                    }
                }
            }

            
            public System.Nullable<int> BireySiraNo
            {
                get
                {
                    return BireySiraNoField;
                }
                set
                {
                    if ((BireySiraNoField.Equals(value) != true))
                    {
                        BireySiraNoField = value;
                        RaisePropertyChanged("BireySiraNo");
                    }
                }
            }

            
            public System.Nullable<int> CiltKod
            {
                get
                {
                    return CiltKodField;
                }
                set
                {
                    if ((CiltKodField.Equals(value) != true))
                    {
                        CiltKodField = value;
                        RaisePropertyChanged("CiltKod");
                    }
                }
            }

            
            public System.Nullable<int> IlceKod
            {
                get
                {
                    return IlceKodField;
                }
                set
                {
                    if ((IlceKodField.Equals(value) != true))
                    {
                        IlceKodField = value;
                        RaisePropertyChanged("IlceKod");
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
        public partial class KpsServisSonucuOfArrayOfServiceZmZ26SC9 : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Service[] SonucField;
            
            public KPSV2.Parametre HataBilgisi
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

            
            public KPSV2.Service[] Sonuc
            {
                get
                {
                    return SonucField;
                }
                set
                {
                    if ((object.ReferenceEquals(SonucField, value) != true))
                    {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class KpsServisSonucuYetkiListesi : KPSV2.KpsServisSonucuOfArrayOfServiceZmZ26SC9
        {
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class Service : KPSV2.BaseEntity
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DescriptionField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private bool IsActiveField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<bool> IsAuthorizedField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private bool IsEditableField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Method[] MethodsField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string NameField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string NamespaceField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private int ServiceNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string ServiceTestUrlField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string ServiceUrlField;

            
            public string Description
            {
                get
                {
                    return DescriptionField;
                }
                set
                {
                    if ((object.ReferenceEquals(DescriptionField, value) != true))
                    {
                        DescriptionField = value;
                        RaisePropertyChanged("Description");
                    }
                }
            }

            
            public bool IsActive
            {
                get
                {
                    return IsActiveField;
                }
                set
                {
                    if ((IsActiveField.Equals(value) != true))
                    {
                        IsActiveField = value;
                        RaisePropertyChanged("IsActive");
                    }
                }
            }

            
            public System.Nullable<bool> IsAuthorized
            {
                get
                {
                    return IsAuthorizedField;
                }
                set
                {
                    if ((IsAuthorizedField.Equals(value) != true))
                    {
                        IsAuthorizedField = value;
                        RaisePropertyChanged("IsAuthorized");
                    }
                }
            }

            
            public bool IsEditable
            {
                get
                {
                    return IsEditableField;
                }
                set
                {
                    if ((IsEditableField.Equals(value) != true))
                    {
                        IsEditableField = value;
                        RaisePropertyChanged("IsEditable");
                    }
                }
            }

            
            public KPSV2.Method[] Methods
            {
                get
                {
                    return MethodsField;
                }
                set
                {
                    if ((object.ReferenceEquals(MethodsField, value) != true))
                    {
                        MethodsField = value;
                        RaisePropertyChanged("Methods");
                    }
                }
            }

            
            public string Name
            {
                get
                {
                    return NameField;
                }
                set
                {
                    if ((object.ReferenceEquals(NameField, value) != true))
                    {
                        NameField = value;
                        RaisePropertyChanged("Name");
                    }
                }
            }

            
            public string Namespace
            {
                get
                {
                    return NamespaceField;
                }
                set
                {
                    if ((object.ReferenceEquals(NamespaceField, value) != true))
                    {
                        NamespaceField = value;
                        RaisePropertyChanged("Namespace");
                    }
                }
            }

            
            public int ServiceNo
            {
                get
                {
                    return ServiceNoField;
                }
                set
                {
                    if ((ServiceNoField.Equals(value) != true))
                    {
                        ServiceNoField = value;
                        RaisePropertyChanged("ServiceNo");
                    }
                }
            }

            
            public string ServiceTestUrl
            {
                get
                {
                    return ServiceTestUrlField;
                }
                set
                {
                    if ((object.ReferenceEquals(ServiceTestUrlField, value) != true))
                    {
                        ServiceTestUrlField = value;
                        RaisePropertyChanged("ServiceTestUrl");
                    }
                }
            }

            
            public string ServiceUrl
            {
                get
                {
                    return ServiceUrlField;
                }
                set
                {
                    if ((object.ReferenceEquals(ServiceUrlField, value) != true))
                    {
                        ServiceUrlField = value;
                        RaisePropertyChanged("ServiceUrl");
                    }
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class BaseEntity : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private int CreatedByField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.DateTime CreatedOnField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> ModifiedByField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<System.DateTime> ModifiedOnField;
            
            public int CreatedBy
            {
                get
                {
                    return CreatedByField;
                }
                set
                {
                    if ((CreatedByField.Equals(value) != true))
                    {
                        CreatedByField = value;
                        RaisePropertyChanged("CreatedBy");
                    }
                }
            }

            
            public System.DateTime CreatedOn
            {
                get
                {
                    return CreatedOnField;
                }
                set
                {
                    if ((CreatedOnField.Equals(value) != true))
                    {
                        CreatedOnField = value;
                        RaisePropertyChanged("CreatedOn");
                    }
                }
            }

            
            public string Id
            {
                get
                {
                    return IdField;
                }
                set
                {
                    if ((object.ReferenceEquals(IdField, value) != true))
                    {
                        IdField = value;
                        RaisePropertyChanged("Id");
                    }
                }
            }

            
            public System.Nullable<int> ModifiedBy
            {
                get
                {
                    return ModifiedByField;
                }
                set
                {
                    if ((ModifiedByField.Equals(value) != true))
                    {
                        ModifiedByField = value;
                        RaisePropertyChanged("ModifiedBy");
                    }
                }
            }

            
            public System.Nullable<System.DateTime> ModifiedOn
            {
                get
                {
                    return ModifiedOnField;
                }
                set
                {
                    if ((ModifiedOnField.Equals(value) != true))
                    {
                        ModifiedOnField = value;
                        RaisePropertyChanged("ModifiedOn");
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
        public partial class Method : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Property[] ArgumansField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DescriptionField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<bool> IsAuthorizedField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private bool IsEditableField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string NameField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Property[] ReturnPropertiesField;
            
            public KPSV2.Property[] Argumans
            {
                get
                {
                    return ArgumansField;
                }
                set
                {
                    if ((object.ReferenceEquals(ArgumansField, value) != true))
                    {
                        ArgumansField = value;
                        RaisePropertyChanged("Argumans");
                    }
                }
            }

            
            public string Description
            {
                get
                {
                    return DescriptionField;
                }
                set
                {
                    if ((object.ReferenceEquals(DescriptionField, value) != true))
                    {
                        DescriptionField = value;
                        RaisePropertyChanged("Description");
                    }
                }
            }

            
            public System.Nullable<bool> IsAuthorized
            {
                get
                {
                    return IsAuthorizedField;
                }
                set
                {
                    if ((IsAuthorizedField.Equals(value) != true))
                    {
                        IsAuthorizedField = value;
                        RaisePropertyChanged("IsAuthorized");
                    }
                }
            }

            
            public bool IsEditable
            {
                get
                {
                    return IsEditableField;
                }
                set
                {
                    if ((IsEditableField.Equals(value) != true))
                    {
                        IsEditableField = value;
                        RaisePropertyChanged("IsEditable");
                    }
                }
            }

            
            public string Name
            {
                get
                {
                    return NameField;
                }
                set
                {
                    if ((object.ReferenceEquals(NameField, value) != true))
                    {
                        NameField = value;
                        RaisePropertyChanged("Name");
                    }
                }
            }

            
            public KPSV2.Property[] ReturnProperties
            {
                get
                {
                    return ReturnPropertiesField;
                }
                set
                {
                    if ((object.ReferenceEquals(ReturnPropertiesField, value) != true))
                    {
                        ReturnPropertiesField = value;
                        RaisePropertyChanged("ReturnProperties");
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
        public partial class Property : object, System.ComponentModel.INotifyPropertyChanged
        {
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<bool> IsAuthorizedField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private bool IsEditableField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string NameField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KPSV2.Property[] SubPropertiesField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string TypeField;

            public System.Nullable<bool> IsAuthorized
            {
                get
                {
                    return IsAuthorizedField;
                }
                set
                {
                    if ((IsAuthorizedField.Equals(value) != true))
                    {
                        IsAuthorizedField = value;
                        RaisePropertyChanged("IsAuthorized");
                    }
                }
            }

            public bool IsEditable
            {
                get
                {
                    return IsEditableField;
                }
                set
                {
                    if ((IsEditableField.Equals(value) != true))
                    {
                        IsEditableField = value;
                        RaisePropertyChanged("IsEditable");
                    }
                }
            }

            
            public string Name
            {
                get
                {
                    return NameField;
                }
                set
                {
                    if ((object.ReferenceEquals(NameField, value) != true))
                    {
                        NameField = value;
                        RaisePropertyChanged("Name");
                    }
                }
            }

            
            public KPSV2.Property[] SubProperties
            {
                get
                {
                    return SubPropertiesField;
                }
                set
                {
                    if ((object.ReferenceEquals(SubPropertiesField, value) != true))
                    {
                        SubPropertiesField = value;
                        RaisePropertyChanged("SubProperties");
                    }
                }
            }

            public string Type
            {
                get
                {
                    return TypeField;
                }
                set
                {
                    if ((object.ReferenceEquals(TypeField, value) != true))
                    {
                        TypeField = value;
                        RaisePropertyChanged("Type");
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