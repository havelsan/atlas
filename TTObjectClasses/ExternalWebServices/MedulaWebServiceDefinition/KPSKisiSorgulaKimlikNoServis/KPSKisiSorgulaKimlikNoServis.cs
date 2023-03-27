
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
    public  partial class KPSKisiSorgulaKimlikNoServis : TTObject
    {
        public static partial class WebMethods
        {
                    
        }
                    
#region Methods
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KisiSorgulaTCKimlikNoSorguKriteri : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> TCKimlikNoField;

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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KisiBilgisiSonucu : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KisiBilgisi[] SorguSonucuField;

            public Parametre HataBilgisi
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

            public KisiBilgisi[] SorguSonucu
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KisiBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> AnneTCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> BabaTCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> DogumYerKodField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KisiDurumBilgisi DurumBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> EsTCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Parametre HataBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KisiKayitYeriBilgisi KayitYeriBilgisiField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> TCKimlikNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KisiTemelBilgisi TemelBilgisiField;

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

            public KisiDurumBilgisi DurumBilgisi
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

            public Parametre HataBilgisi
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

            public KisiKayitYeriBilgisi KayitYeriBilgisi
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

            public KisiTemelBilgisi TemelBilgisi
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KisiDurumBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Parametre DinField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Parametre DurumField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Parametre MedeniHalField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private TarihBilgisi OlumTarihField;

            public Parametre Din
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

            public Parametre Durum
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

            public Parametre MedeniHal
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

            public TarihBilgisi OlumTarih
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KisiKayitYeriBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> AileSiraNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<int> BireySiraNoField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Parametre CiltField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Parametre IlField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Parametre IlceField;

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

            public Parametre Cilt
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

            public Parametre Il
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

            public Parametre Ilce
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KisiTemelBilgisi : object, System.ComponentModel.INotifyPropertyChanged
        {


            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnneAdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaAdField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Parametre CinsiyetField;

            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private TarihBilgisi DogumTarihField;

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

            public Parametre Cinsiyet
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

            public TarihBilgisi DogumTarih
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
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
        
#endregion Methods

    }
}