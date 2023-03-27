
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
    public  partial class KPSYbKisiSorgulaYbKimlikNoServis : TTObject
    {
        public static partial class WebMethods
        {
                    
        }
                    
#region Methods
        [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.SerializableAttribute()]
    public partial class YbKisiSorgulaYbKimlikNoSorguKriteri : object,  System.ComponentModel.INotifyPropertyChanged {
        
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> KimlikNoField;
        
        

        public System.Nullable<long> KimlikNo {
            get {
                return KimlikNoField;
            }
            set {
                if ((KimlikNoField.Equals(value) != true)) {
                    KimlikNoField = value;
                    RaisePropertyChanged("KimlikNo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.SerializableAttribute()]
    public partial class YbKimlikNoIleYbKisiBilgisiSonucu : object,  System.ComponentModel.INotifyPropertyChanged {
        
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Parametre HataBilgisiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private YbKimlikNoIleYbKisiBilgisi[] SorguSonucuField;
        
        
     public Parametre HataBilgisi {
            get {
                return HataBilgisiField;
            }
            set {
                if ((object.ReferenceEquals(HataBilgisiField, value) != true)) {
                    HataBilgisiField = value;
                    RaisePropertyChanged("HataBilgisi");
                }
            }
        }
        
            public YbKimlikNoIleYbKisiBilgisi[] SorguSonucu {
            get {
                return SorguSonucuField;
            }
            set {
                if ((object.ReferenceEquals(SorguSonucuField, value) != true)) {
                    SorguSonucuField = value;
                    RaisePropertyChanged("SorguSonucu");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.SerializableAttribute()]
    public partial class Parametre : object,  System.ComponentModel.INotifyPropertyChanged {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AciklamaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> KodField;
        
  
        public string Aciklama {
            get {
                return AciklamaField;
            }
            set {
                if ((object.ReferenceEquals(AciklamaField, value) != true)) {
                    AciklamaField = value;
                    RaisePropertyChanged("Aciklama");
                }
            }
        }
        
        public System.Nullable<int> Kod {
            get {
                return KodField;
            }
            set {
                if ((KodField.Equals(value) != true)) {
                    KodField = value;
                    RaisePropertyChanged("Kod");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.SerializableAttribute()]
    public partial class YbKimlikNoIleYbKisiBilgisi : object,  System.ComponentModel.INotifyPropertyChanged {
        
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AnneAdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> AnneKimlikNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BabaAdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> BabaKimlikNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Parametre BitisTarihiBelirsizOlmaNedenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Parametre CinsiyetField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TarihBilgisi DogumTarihField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DogumYerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> DogumYerKodField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Parametre DurumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> EsKimlikNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Parametre HataBilgisiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> IzinBaslangicTarihField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> IzinBitisTarihField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Parametre IzinDuzenlenenIlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IzinNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Parametre KaynakBirimField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> KazanilanTCKimlikNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> KimlikNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Parametre MedeniHalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TarihBilgisi OlumTarihField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SoyadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Parametre UyrukField;
        
        
       
        public string Ad {
            get {
                return AdField;
            }
            set {
                if ((object.ReferenceEquals(AdField, value) != true)) {
                    AdField = value;
                    RaisePropertyChanged("Ad");
                }
            }
        }
        
       
        public string AnneAd {
            get {
                return AnneAdField;
            }
            set {
                if ((object.ReferenceEquals(AnneAdField, value) != true)) {
                    AnneAdField = value;
                    RaisePropertyChanged("AnneAd");
                }
            }
        }
        
 
        public System.Nullable<long> AnneKimlikNo {
            get {
                return AnneKimlikNoField;
            }
            set {
                if ((AnneKimlikNoField.Equals(value) != true)) {
                    AnneKimlikNoField = value;
                    RaisePropertyChanged("AnneKimlikNo");
                }
            }
        }
        
       
        public string BabaAd {
            get {
                return BabaAdField;
            }
            set {
                if ((object.ReferenceEquals(BabaAdField, value) != true)) {
                    BabaAdField = value;
                    RaisePropertyChanged("BabaAd");
                }
            }
        }
        
    
        public System.Nullable<long> BabaKimlikNo {
            get {
                return BabaKimlikNoField;
            }
            set {
                if ((BabaKimlikNoField.Equals(value) != true)) {
                    BabaKimlikNoField = value;
                    RaisePropertyChanged("BabaKimlikNo");
                }
            }
        }
        
       
        public Parametre BitisTarihiBelirsizOlmaNeden {
            get {
                return BitisTarihiBelirsizOlmaNedenField;
            }
            set {
                if ((object.ReferenceEquals(BitisTarihiBelirsizOlmaNedenField, value) != true)) {
                    BitisTarihiBelirsizOlmaNedenField = value;
                    RaisePropertyChanged("BitisTarihiBelirsizOlmaNeden");
                }
            }
        }
        
       
        public Parametre Cinsiyet {
            get {
                return CinsiyetField;
            }
            set {
                if ((object.ReferenceEquals(CinsiyetField, value) != true)) {
                    CinsiyetField = value;
                    RaisePropertyChanged("Cinsiyet");
                }
            }
        }
        
       
        public TarihBilgisi DogumTarih {
            get {
                return DogumTarihField;
            }
            set {
                if ((object.ReferenceEquals(DogumTarihField, value) != true)) {
                    DogumTarihField = value;
                    RaisePropertyChanged("DogumTarih");
                }
            }
        }
        
       
        public string DogumYer {
            get {
                return DogumYerField;
            }
            set {
                if ((object.ReferenceEquals(DogumYerField, value) != true)) {
                    DogumYerField = value;
                    RaisePropertyChanged("DogumYer");
                }
            }
        }
        
       
        public System.Nullable<int> DogumYerKod {
            get {
                return DogumYerKodField;
            }
            set {
                if ((DogumYerKodField.Equals(value) != true)) {
                    DogumYerKodField = value;
                    RaisePropertyChanged("DogumYerKod");
                }
            }
        }
        
       
        public Parametre Durum {
            get {
                return DurumField;
            }
            set {
                if ((object.ReferenceEquals(DurumField, value) != true)) {
                    DurumField = value;
                    RaisePropertyChanged("Durum");
                }
            }
        }
        
       
        public System.Nullable<long> EsKimlikNo {
            get {
                return EsKimlikNoField;
            }
            set {
                if ((EsKimlikNoField.Equals(value) != true)) {
                    EsKimlikNoField = value;
                    RaisePropertyChanged("EsKimlikNo");
                }
            }
        }
        
       
        public Parametre HataBilgisi {
            get {
                return HataBilgisiField;
            }
            set {
                if ((object.ReferenceEquals(HataBilgisiField, value) != true)) {
                    HataBilgisiField = value;
                    RaisePropertyChanged("HataBilgisi");
                }
            }
        }
        
       
        public System.Nullable<System.DateTime> IzinBaslangicTarih {
            get {
                return IzinBaslangicTarihField;
            }
            set {
                if ((IzinBaslangicTarihField.Equals(value) != true)) {
                    IzinBaslangicTarihField = value;
                    RaisePropertyChanged("IzinBaslangicTarih");
                }
            }
        }
        
       
        public System.Nullable<System.DateTime> IzinBitisTarih {
            get {
                return IzinBitisTarihField;
            }
            set {
                if ((IzinBitisTarihField.Equals(value) != true)) {
                    IzinBitisTarihField = value;
                    RaisePropertyChanged("IzinBitisTarih");
                }
            }
        }
        
       
        public Parametre IzinDuzenlenenIl {
            get {
                return IzinDuzenlenenIlField;
            }
            set {
                if ((object.ReferenceEquals(IzinDuzenlenenIlField, value) != true)) {
                    IzinDuzenlenenIlField = value;
                    RaisePropertyChanged("IzinDuzenlenenIl");
                }
            }
        }
        
       
        public string IzinNo {
            get {
                return IzinNoField;
            }
            set {
                if ((object.ReferenceEquals(IzinNoField, value) != true)) {
                    IzinNoField = value;
                    RaisePropertyChanged("IzinNo");
                }
            }
        }
        
       
        public Parametre KaynakBirim {
            get {
                return KaynakBirimField;
            }
            set {
                if ((object.ReferenceEquals(KaynakBirimField, value) != true)) {
                    KaynakBirimField = value;
                    RaisePropertyChanged("KaynakBirim");
                }
            }
        }
        
       
        public System.Nullable<long> KazanilanTCKimlikNo {
            get {
                return KazanilanTCKimlikNoField;
            }
            set {
                if ((KazanilanTCKimlikNoField.Equals(value) != true)) {
                    KazanilanTCKimlikNoField = value;
                    RaisePropertyChanged("KazanilanTCKimlikNo");
                }
            }
        }
        
       
        public System.Nullable<long> KimlikNo {
            get {
                return KimlikNoField;
            }
            set {
                if ((KimlikNoField.Equals(value) != true)) {
                    KimlikNoField = value;
                    RaisePropertyChanged("KimlikNo");
                }
            }
        }
        
       
        public Parametre MedeniHal {
            get {
                return MedeniHalField;
            }
            set {
                if ((object.ReferenceEquals(MedeniHalField, value) != true)) {
                    MedeniHalField = value;
                    RaisePropertyChanged("MedeniHal");
                }
            }
        }
        
       
        public TarihBilgisi OlumTarih {
            get {
                return OlumTarihField;
            }
            set {
                if ((object.ReferenceEquals(OlumTarihField, value) != true)) {
                    OlumTarihField = value;
                    RaisePropertyChanged("OlumTarih");
                }
            }
        }
        
       
        public string Soyad {
            get {
                return SoyadField;
            }
            set {
                if ((object.ReferenceEquals(SoyadField, value) != true)) {
                    SoyadField = value;
                    RaisePropertyChanged("Soyad");
                }
            }
        }
        
       
        public Parametre Uyruk {
            get {
                return UyrukField;
            }
            set {
                if ((object.ReferenceEquals(UyrukField, value) != true)) {
                    UyrukField = value;
                    RaisePropertyChanged("Uyruk");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.SerializableAttribute()]
    public partial class TarihBilgisi : object,  System.ComponentModel.INotifyPropertyChanged {
        
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> AyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> GunField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> YilField;
        
        
       
        public System.Nullable<int> Ay {
            get {
                return AyField;
            }
            set {
                if ((AyField.Equals(value) != true)) {
                    AyField = value;
                    RaisePropertyChanged("Ay");
                }
            }
        }
        
       
        public System.Nullable<int> Gun {
            get {
                return GunField;
            }
            set {
                if ((GunField.Equals(value) != true)) {
                    GunField = value;
                    RaisePropertyChanged("Gun");
                }
            }
        }
        
       
        public System.Nullable<int> Yil {
            get {
                return YilField;
            }
            set {
                if ((YilField.Equals(value) != true)) {
                    YilField = value;
                    RaisePropertyChanged("Yil");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface YbKisiSorgulaYbKimlikNoServis {
        
        YbKimlikNoIleYbKisiBilgisiSonucu ListeleCoklu(YbKisiSorgulaYbKimlikNoSorguKriteri[] kriterListesi);
        
        System.IAsyncResult BeginListeleCoklu(YbKisiSorgulaYbKimlikNoSorguKriteri[] kriterListesi, System.AsyncCallback callback, object asyncState);
        
        YbKimlikNoIleYbKisiBilgisiSonucu EndListeleCoklu(System.IAsyncResult result);
    }
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ListeleCokluCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ListeleCokluCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public YbKimlikNoIleYbKisiBilgisiSonucu Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((YbKimlikNoIleYbKisiBilgisiSonucu)(results[0]));
            }
        }
    }
   
        
#endregion Methods

    }
}