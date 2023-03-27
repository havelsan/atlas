
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
    public  partial class KPSServis : TTObject
    {
        public static partial class WebMethods
        {
                    
        }
                    
#region Methods
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        
        [System.SerializableAttribute()]
        public partial class KPSServisSonucuArrayOfIl : object, System.ComponentModel.INotifyPropertyChanged {
            
           
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Il[] SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            public Il[] Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((object.ReferenceEquals(SonucField, value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class Il : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KodField;
            
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
            
            public string Kod {
                get {
                    return KodField;
                }
                set {
                    if ((object.ReferenceEquals(KodField, value) != true)) {
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
        public partial class KPSServisSonucuArrayOfIlce : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Ilce[] SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            public Ilce[] Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((object.ReferenceEquals(SonucField, value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class Ilce : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlKodField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KodField;
            
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
            
            public string IlKod {
                get {
                    return IlKodField;
                }
                set {
                    if ((object.ReferenceEquals(IlKodField, value) != true)) {
                        IlKodField = value;
                        RaisePropertyChanged("IlKod");
                    }
                }
            }
            
            public string Kod {
                get {
                    return KodField;
                }
                set {
                    if ((object.ReferenceEquals(KodField, value) != true)) {
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
        public partial class KPSServisSonucuKisiTemelBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KisiTemelBilgisi SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            public KisiTemelBilgisi Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((object.ReferenceEquals(SonucField, value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class KisiTemelBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AileSiraNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnaAdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaAdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BireySiraNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CiltAdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CiltKodField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CinsiyetField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DinField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumTarihiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumYerField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DurumField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlAdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlKodField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlceAdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlceKodField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string MedeniHalField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private NufusKayitOrnegiOlayTarihBilgisi OlayTarihBilgileriField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string OlumTarihField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string TCKimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string YakinlikField;
            
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
            
            public string AileSiraNo {
                get {
                    return AileSiraNoField;
                }
                set {
                    if ((object.ReferenceEquals(AileSiraNoField, value) != true)) {
                        AileSiraNoField = value;
                        RaisePropertyChanged("AileSiraNo");
                    }
                }
            }
            
            public string AnaAd {
                get {
                    return AnaAdField;
                }
                set {
                    if ((object.ReferenceEquals(AnaAdField, value) != true)) {
                        AnaAdField = value;
                        RaisePropertyChanged("AnaAd");
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
            
            public string BireySiraNo {
                get {
                    return BireySiraNoField;
                }
                set {
                    if ((object.ReferenceEquals(BireySiraNoField, value) != true)) {
                        BireySiraNoField = value;
                        RaisePropertyChanged("BireySiraNo");
                    }
                }
            }
            
            public string CiltAd {
                get {
                    return CiltAdField;
                }
                set {
                    if ((object.ReferenceEquals(CiltAdField, value) != true)) {
                        CiltAdField = value;
                        RaisePropertyChanged("CiltAd");
                    }
                }
            }
            
            public string CiltKod {
                get {
                    return CiltKodField;
                }
                set {
                    if ((object.ReferenceEquals(CiltKodField, value) != true)) {
                        CiltKodField = value;
                        RaisePropertyChanged("CiltKod");
                    }
                }
            }
            
            public string Cinsiyet {
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
            
            public string Din {
                get {
                    return DinField;
                }
                set {
                    if ((object.ReferenceEquals(DinField, value) != true)) {
                        DinField = value;
                        RaisePropertyChanged("Din");
                    }
                }
            }
            
            public string DogumTarihi {
                get {
                    return DogumTarihiField;
                }
                set {
                    if ((object.ReferenceEquals(DogumTarihiField, value) != true)) {
                        DogumTarihiField = value;
                        RaisePropertyChanged("DogumTarihi");
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
            
            public string Durum {
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
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            public string IlAd {
                get {
                    return IlAdField;
                }
                set {
                    if ((object.ReferenceEquals(IlAdField, value) != true)) {
                        IlAdField = value;
                        RaisePropertyChanged("IlAd");
                    }
                }
            }
            
            public string IlKod {
                get {
                    return IlKodField;
                }
                set {
                    if ((object.ReferenceEquals(IlKodField, value) != true)) {
                        IlKodField = value;
                        RaisePropertyChanged("IlKod");
                    }
                }
            }
            
            
            public string IlceAd {
                get {
                    return IlceAdField;
                }
                set {
                    if ((object.ReferenceEquals(IlceAdField, value) != true)) {
                        IlceAdField = value;
                        RaisePropertyChanged("IlceAd");
                    }
                }
            }
            
            
            public string IlceKod {
                get {
                    return IlceKodField;
                }
                set {
                    if ((object.ReferenceEquals(IlceKodField, value) != true)) {
                        IlceKodField = value;
                        RaisePropertyChanged("IlceKod");
                    }
                }
            }
            
            
            public string MedeniHal {
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
            
            
            public NufusKayitOrnegiOlayTarihBilgisi OlayTarihBilgileri {
                get {
                    return OlayTarihBilgileriField;
                }
                set {
                    if ((object.ReferenceEquals(OlayTarihBilgileriField, value) != true)) {
                        OlayTarihBilgileriField = value;
                        RaisePropertyChanged("OlayTarihBilgileri");
                    }
                }
            }
            
            
            public string OlumTarih {
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
            
            
            public string TCKimlikNo {
                get {
                    return TCKimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(TCKimlikNoField, value) != true)) {
                        TCKimlikNoField = value;
                        RaisePropertyChanged("TCKimlikNo");
                    }
                }
            }
            
            
            public string Yakinlik {
                get {
                    return YakinlikField;
                }
                set {
                    if ((object.ReferenceEquals(YakinlikField, value) != true)) {
                        YakinlikField = value;
                        RaisePropertyChanged("Yakinlik");
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
        public partial class NufusKayitOrnegiOlayTarihBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BosanmaTarihiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string EvlenmeTarihiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataBilgisiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string TescilTarihiField;
            
            public string BosanmaTarihi {
                get {
                    return BosanmaTarihiField;
                }
                set {
                    if ((object.ReferenceEquals(BosanmaTarihiField, value) != true)) {
                        BosanmaTarihiField = value;
                        RaisePropertyChanged("BosanmaTarihi");
                    }
                }
            }
            
            
            public string EvlenmeTarihi {
                get {
                    return EvlenmeTarihiField;
                }
                set {
                    if ((object.ReferenceEquals(EvlenmeTarihiField, value) != true)) {
                        EvlenmeTarihiField = value;
                        RaisePropertyChanged("EvlenmeTarihi");
                    }
                }
            }
            
            
            public string HataBilgisi {
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
            
            
            public string TescilTarihi {
                get {
                    return TescilTarihiField;
                }
                set {
                    if ((object.ReferenceEquals(TescilTarihiField, value) != true)) {
                        TescilTarihiField = value;
                        RaisePropertyChanged("TescilTarihi");
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
        public partial class KisiCuzdanBilgisi : KisiTemelBilgisi {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CuzdanNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CuzdanSeriField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string VerildigiIlceAdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string VerildigiIlceKodField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string VerilmeNedenField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string VerilmeTarihField;
            
            
            public string CuzdanNo {
                get {
                    return CuzdanNoField;
                }
                set {
                    if ((object.ReferenceEquals(CuzdanNoField, value) != true)) {
                        CuzdanNoField = value;
                        RaisePropertyChanged("CuzdanNo");
                    }
                }
            }
            
            
            public string CuzdanSeri {
                get {
                    return CuzdanSeriField;
                }
                set {
                    if ((object.ReferenceEquals(CuzdanSeriField, value) != true)) {
                        CuzdanSeriField = value;
                        RaisePropertyChanged("CuzdanSeri");
                    }
                }
            }
            
            
            public string VerildigiIlceAd {
                get {
                    return VerildigiIlceAdField;
                }
                set {
                    if ((object.ReferenceEquals(VerildigiIlceAdField, value) != true)) {
                        VerildigiIlceAdField = value;
                        RaisePropertyChanged("VerildigiIlceAd");
                    }
                }
            }
            
            
            public string VerildigiIlceKod {
                get {
                    return VerildigiIlceKodField;
                }
                set {
                    if ((object.ReferenceEquals(VerildigiIlceKodField, value) != true)) {
                        VerildigiIlceKodField = value;
                        RaisePropertyChanged("VerildigiIlceKod");
                    }
                }
            }
            
            
            public string VerilmeNeden {
                get {
                    return VerilmeNedenField;
                }
                set {
                    if ((object.ReferenceEquals(VerilmeNedenField, value) != true)) {
                        VerilmeNedenField = value;
                        RaisePropertyChanged("VerilmeNeden");
                    }
                }
            }
            
            
            public string VerilmeTarih {
                get {
                    return VerilmeTarihField;
                }
                set {
                    if ((object.ReferenceEquals(VerilmeTarihField, value) != true)) {
                        VerilmeTarihField = value;
                        RaisePropertyChanged("VerilmeTarih");
                    }
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KPSServisSonucuArrayOfKisiTemelBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KisiTemelBilgisi[] SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public KisiTemelBilgisi[] Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((object.ReferenceEquals(SonucField, value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class KPSServisSonucuKisiCuzdanBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KisiCuzdanBilgisi SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public KisiCuzdanBilgisi Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((object.ReferenceEquals(SonucField, value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class KPSServisSonucuYabanciKisiBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private YabanciKisiBilgisi SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public YabanciKisiBilgisi Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((object.ReferenceEquals(SonucField, value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class YabanciKisiBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnneAdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnneEgmSahisIdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnneKimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaAdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaEgmSahisIdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaKimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CinsiyetField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumTarihField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumYerField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumYilField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DurumField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string EgmSahisIdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string EsEgmSahisIdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string EsKimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataBilgisiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IkametAdresField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IkametAdresIlField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IkametAdresIlKodField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IkametAdresIlceField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IkametDuzenleIlField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IkametSureField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IkametTezkereNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IzinBaslangicTarihField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KazanilanTCKimlikNOField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string MedeniHalField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string OlumTarihiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string UlkeField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string UlkeKodField;
            
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
            
            
            public string AnneEgmSahisId {
                get {
                    return AnneEgmSahisIdField;
                }
                set {
                    if ((object.ReferenceEquals(AnneEgmSahisIdField, value) != true)) {
                        AnneEgmSahisIdField = value;
                        RaisePropertyChanged("AnneEgmSahisId");
                    }
                }
            }
            
            
            public string AnneKimlikNo {
                get {
                    return AnneKimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(AnneKimlikNoField, value) != true)) {
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
            
            
            public string BabaEgmSahisId {
                get {
                    return BabaEgmSahisIdField;
                }
                set {
                    if ((object.ReferenceEquals(BabaEgmSahisIdField, value) != true)) {
                        BabaEgmSahisIdField = value;
                        RaisePropertyChanged("BabaEgmSahisId");
                    }
                }
            }
            
            
            public string BabaKimlikNo {
                get {
                    return BabaKimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(BabaKimlikNoField, value) != true)) {
                        BabaKimlikNoField = value;
                        RaisePropertyChanged("BabaKimlikNo");
                    }
                }
            }
            
            
            public string Cinsiyet {
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
            
            
            public string DogumTarih {
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
            
            
            public string DogumYil {
                get {
                    return DogumYilField;
                }
                set {
                    if ((object.ReferenceEquals(DogumYilField, value) != true)) {
                        DogumYilField = value;
                        RaisePropertyChanged("DogumYil");
                    }
                }
            }
            
            
            public string Durum {
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
            
            
            public string EgmSahisId {
                get {
                    return EgmSahisIdField;
                }
                set {
                    if ((object.ReferenceEquals(EgmSahisIdField, value) != true)) {
                        EgmSahisIdField = value;
                        RaisePropertyChanged("EgmSahisId");
                    }
                }
            }
            
            
            public string EsEgmSahisId {
                get {
                    return EsEgmSahisIdField;
                }
                set {
                    if ((object.ReferenceEquals(EsEgmSahisIdField, value) != true)) {
                        EsEgmSahisIdField = value;
                        RaisePropertyChanged("EsEgmSahisId");
                    }
                }
            }
            
            
            public string EsKimlikNo {
                get {
                    return EsKimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(EsKimlikNoField, value) != true)) {
                        EsKimlikNoField = value;
                        RaisePropertyChanged("EsKimlikNo");
                    }
                }
            }
            
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public string HataBilgisi {
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
            
            
            public string IkametAdres {
                get {
                    return IkametAdresField;
                }
                set {
                    if ((object.ReferenceEquals(IkametAdresField, value) != true)) {
                        IkametAdresField = value;
                        RaisePropertyChanged("IkametAdres");
                    }
                }
            }
            
            
            public string IkametAdresIl {
                get {
                    return IkametAdresIlField;
                }
                set {
                    if ((object.ReferenceEquals(IkametAdresIlField, value) != true)) {
                        IkametAdresIlField = value;
                        RaisePropertyChanged("IkametAdresIl");
                    }
                }
            }
            
            
            public string IkametAdresIlKod {
                get {
                    return IkametAdresIlKodField;
                }
                set {
                    if ((object.ReferenceEquals(IkametAdresIlKodField, value) != true)) {
                        IkametAdresIlKodField = value;
                        RaisePropertyChanged("IkametAdresIlKod");
                    }
                }
            }
            
            
            public string IkametAdresIlce {
                get {
                    return IkametAdresIlceField;
                }
                set {
                    if ((object.ReferenceEquals(IkametAdresIlceField, value) != true)) {
                        IkametAdresIlceField = value;
                        RaisePropertyChanged("IkametAdresIlce");
                    }
                }
            }
            
            
            public string IkametDuzenleIl {
                get {
                    return IkametDuzenleIlField;
                }
                set {
                    if ((object.ReferenceEquals(IkametDuzenleIlField, value) != true)) {
                        IkametDuzenleIlField = value;
                        RaisePropertyChanged("IkametDuzenleIl");
                    }
                }
            }
            
            
            public string IkametSure {
                get {
                    return IkametSureField;
                }
                set {
                    if ((object.ReferenceEquals(IkametSureField, value) != true)) {
                        IkametSureField = value;
                        RaisePropertyChanged("IkametSure");
                    }
                }
            }
            
            
            public string IkametTezkereNo {
                get {
                    return IkametTezkereNoField;
                }
                set {
                    if ((object.ReferenceEquals(IkametTezkereNoField, value) != true)) {
                        IkametTezkereNoField = value;
                        RaisePropertyChanged("IkametTezkereNo");
                    }
                }
            }
            
            
            public string IzinBaslangicTarih {
                get {
                    return IzinBaslangicTarihField;
                }
                set {
                    if ((object.ReferenceEquals(IzinBaslangicTarihField, value) != true)) {
                        IzinBaslangicTarihField = value;
                        RaisePropertyChanged("IzinBaslangicTarih");
                    }
                }
            }
            
            
            public string KazanilanTCKimlikNO {
                get {
                    return KazanilanTCKimlikNOField;
                }
                set {
                    if ((object.ReferenceEquals(KazanilanTCKimlikNOField, value) != true)) {
                        KazanilanTCKimlikNOField = value;
                        RaisePropertyChanged("KazanilanTCKimlikNO");
                    }
                }
            }
            
            
            public string KimlikNo {
                get {
                    return KimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(KimlikNoField, value) != true)) {
                        KimlikNoField = value;
                        RaisePropertyChanged("KimlikNo");
                    }
                }
            }
            
            
            public string MedeniHal {
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
            
            
            public string OlumTarihi {
                get {
                    return OlumTarihiField;
                }
                set {
                    if ((object.ReferenceEquals(OlumTarihiField, value) != true)) {
                        OlumTarihiField = value;
                        RaisePropertyChanged("OlumTarihi");
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
            
            
            public string Ulke {
                get {
                    return UlkeField;
                }
                set {
                    if ((object.ReferenceEquals(UlkeField, value) != true)) {
                        UlkeField = value;
                        RaisePropertyChanged("Ulke");
                    }
                }
            }
            
            
            public string UlkeKod {
                get {
                    return UlkeKodField;
                }
                set {
                    if ((object.ReferenceEquals(UlkeKodField, value) != true)) {
                        UlkeKodField = value;
                        RaisePropertyChanged("UlkeKod");
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
        public partial class KPSServisSonucuNufusKayitOrnegi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private NufusKayitOrnegi SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public NufusKayitOrnegi Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((object.ReferenceEquals(SonucField, value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class NufusKayitOrnegi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KisiTemelBilgisi[] KisilerField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private NufusKayitOrnegiOlay[] OlaylarField;
            
            public KisiTemelBilgisi[] Kisiler {
                get {
                    return KisilerField;
                }
                set {
                    if ((object.ReferenceEquals(KisilerField, value) != true)) {
                        KisilerField = value;
                        RaisePropertyChanged("Kisiler");
                    }
                }
            }
            
            
            public NufusKayitOrnegiOlay[] Olaylar {
                get {
                    return OlaylarField;
                }
                set {
                    if ((object.ReferenceEquals(OlaylarField, value) != true)) {
                        OlaylarField = value;
                        RaisePropertyChanged("Olaylar");
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
        public partial class NufusKayitOrnegiOlay : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DusunceField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataBilgisiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KayitYeriKodBilgisi KayitYeriField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string OlayTarihField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string OlayTipiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadField;
            
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
            
            
            public string Dusunce {
                get {
                    return DusunceField;
                }
                set {
                    if ((object.ReferenceEquals(DusunceField, value) != true)) {
                        DusunceField = value;
                        RaisePropertyChanged("Dusunce");
                    }
                }
            }
            
            
            public string HataBilgisi {
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
            
            
            public KayitYeriKodBilgisi KayitYeri {
                get {
                    return KayitYeriField;
                }
                set {
                    if ((object.ReferenceEquals(KayitYeriField, value) != true)) {
                        KayitYeriField = value;
                        RaisePropertyChanged("KayitYeri");
                    }
                }
            }
            
            
            public string OlayTarih {
                get {
                    return OlayTarihField;
                }
                set {
                    if ((object.ReferenceEquals(OlayTarihField, value) != true)) {
                        OlayTarihField = value;
                        RaisePropertyChanged("OlayTarih");
                    }
                }
            }
            
            
            public string OlayTipi {
                get {
                    return OlayTipiField;
                }
                set {
                    if ((object.ReferenceEquals(OlayTipiField, value) != true)) {
                        OlayTipiField = value;
                        RaisePropertyChanged("OlayTipi");
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
        public partial class KayitYeriKodBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AileSiraNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BireySiraNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CiltField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlceField;
            
            public string AileSiraNo {
                get {
                    return AileSiraNoField;
                }
                set {
                    if ((object.ReferenceEquals(AileSiraNoField, value) != true)) {
                        AileSiraNoField = value;
                        RaisePropertyChanged("AileSiraNo");
                    }
                }
            }
            
            
            public string BireySiraNo {
                get {
                    return BireySiraNoField;
                }
                set {
                    if ((object.ReferenceEquals(BireySiraNoField, value) != true)) {
                        BireySiraNoField = value;
                        RaisePropertyChanged("BireySiraNo");
                    }
                }
            }
            
            
            public string Cilt {
                get {
                    return CiltField;
                }
                set {
                    if ((object.ReferenceEquals(CiltField, value) != true)) {
                        CiltField = value;
                        RaisePropertyChanged("Cilt");
                    }
                }
            }
            
            
            public string Ilce {
                get {
                    return IlceField;
                }
                set {
                    if ((object.ReferenceEquals(IlceField, value) != true)) {
                        IlceField = value;
                        RaisePropertyChanged("Ilce");
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
        public partial class KPSServisSonucuKisiAdresBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KisiAdresBilgisi SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public KisiAdresBilgisi Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((object.ReferenceEquals(SonucField, value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class KisiAdresBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> AdresNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private AdresTipi AdresTipiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BeyanTarihiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BeyandaBulunanKimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaAdaField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaBlokAdiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaKoduField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaPaftaField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaParselField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BinaSiteAdiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BucakField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BucakKoduField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CsbmField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CsbmKoduField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DisKapiNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DisTemsDuzeltmeBeyanTarihField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DisTemsDuzeltmeKararTarihField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DisTemsDuzeltmeNedenField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DisTemsilcilikField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataBilgisiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IcKapiNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlKoduField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlceField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string IlceKoduField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KoyField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KoyKayitNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KoyKoduField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string MahalleField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string MahalleKoduField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string TasinmaTarihiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string TescilTarihiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string YabanciAdresField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string YabanciSehirField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string YabanciUlkeField;
            
            public System.Nullable<long> AdresNo {
                get {
                    return AdresNoField;
                }
                set {
                    if ((AdresNoField.Equals(value) != true)) {
                        AdresNoField = value;
                        RaisePropertyChanged("AdresNo");
                    }
                }
            }
            
            
            public AdresTipi AdresTipi {
                get {
                    return AdresTipiField;
                }
                set {
                    if ((AdresTipiField.Equals(value) != true)) {
                        AdresTipiField = value;
                        RaisePropertyChanged("AdresTipi");
                    }
                }
            }
            
            
            public string BeyanTarihi {
                get {
                    return BeyanTarihiField;
                }
                set {
                    if ((object.ReferenceEquals(BeyanTarihiField, value) != true)) {
                        BeyanTarihiField = value;
                        RaisePropertyChanged("BeyanTarihi");
                    }
                }
            }
            
            
            public string BeyandaBulunanKimlikNo {
                get {
                    return BeyandaBulunanKimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(BeyandaBulunanKimlikNoField, value) != true)) {
                        BeyandaBulunanKimlikNoField = value;
                        RaisePropertyChanged("BeyandaBulunanKimlikNo");
                    }
                }
            }
            
            
            public string BinaAda {
                get {
                    return BinaAdaField;
                }
                set {
                    if ((object.ReferenceEquals(BinaAdaField, value) != true)) {
                        BinaAdaField = value;
                        RaisePropertyChanged("BinaAda");
                    }
                }
            }
            
            
            public string BinaBlokAdi {
                get {
                    return BinaBlokAdiField;
                }
                set {
                    if ((object.ReferenceEquals(BinaBlokAdiField, value) != true)) {
                        BinaBlokAdiField = value;
                        RaisePropertyChanged("BinaBlokAdi");
                    }
                }
            }
            
            
            public string BinaKodu {
                get {
                    return BinaKoduField;
                }
                set {
                    if ((object.ReferenceEquals(BinaKoduField, value) != true)) {
                        BinaKoduField = value;
                        RaisePropertyChanged("BinaKodu");
                    }
                }
            }
            
            
            public string BinaNo {
                get {
                    return BinaNoField;
                }
                set {
                    if ((object.ReferenceEquals(BinaNoField, value) != true)) {
                        BinaNoField = value;
                        RaisePropertyChanged("BinaNo");
                    }
                }
            }
            
            
            public string BinaPafta {
                get {
                    return BinaPaftaField;
                }
                set {
                    if ((object.ReferenceEquals(BinaPaftaField, value) != true)) {
                        BinaPaftaField = value;
                        RaisePropertyChanged("BinaPafta");
                    }
                }
            }
            
            
            public string BinaParsel {
                get {
                    return BinaParselField;
                }
                set {
                    if ((object.ReferenceEquals(BinaParselField, value) != true)) {
                        BinaParselField = value;
                        RaisePropertyChanged("BinaParsel");
                    }
                }
            }
            
            
            public string BinaSiteAdi {
                get {
                    return BinaSiteAdiField;
                }
                set {
                    if ((object.ReferenceEquals(BinaSiteAdiField, value) != true)) {
                        BinaSiteAdiField = value;
                        RaisePropertyChanged("BinaSiteAdi");
                    }
                }
            }
            
            
            public string Bucak {
                get {
                    return BucakField;
                }
                set {
                    if ((object.ReferenceEquals(BucakField, value) != true)) {
                        BucakField = value;
                        RaisePropertyChanged("Bucak");
                    }
                }
            }
            
            
            public string BucakKodu {
                get {
                    return BucakKoduField;
                }
                set {
                    if ((object.ReferenceEquals(BucakKoduField, value) != true)) {
                        BucakKoduField = value;
                        RaisePropertyChanged("BucakKodu");
                    }
                }
            }
            
            
            public string Csbm {
                get {
                    return CsbmField;
                }
                set {
                    if ((object.ReferenceEquals(CsbmField, value) != true)) {
                        CsbmField = value;
                        RaisePropertyChanged("Csbm");
                    }
                }
            }
            
            
            public string CsbmKodu {
                get {
                    return CsbmKoduField;
                }
                set {
                    if ((object.ReferenceEquals(CsbmKoduField, value) != true)) {
                        CsbmKoduField = value;
                        RaisePropertyChanged("CsbmKodu");
                    }
                }
            }
            
            
            public string DisKapiNo {
                get {
                    return DisKapiNoField;
                }
                set {
                    if ((object.ReferenceEquals(DisKapiNoField, value) != true)) {
                        DisKapiNoField = value;
                        RaisePropertyChanged("DisKapiNo");
                    }
                }
            }
            
            
            public string DisTemsDuzeltmeBeyanTarih {
                get {
                    return DisTemsDuzeltmeBeyanTarihField;
                }
                set {
                    if ((object.ReferenceEquals(DisTemsDuzeltmeBeyanTarihField, value) != true)) {
                        DisTemsDuzeltmeBeyanTarihField = value;
                        RaisePropertyChanged("DisTemsDuzeltmeBeyanTarih");
                    }
                }
            }
            
            
            public string DisTemsDuzeltmeKararTarih {
                get {
                    return DisTemsDuzeltmeKararTarihField;
                }
                set {
                    if ((object.ReferenceEquals(DisTemsDuzeltmeKararTarihField, value) != true)) {
                        DisTemsDuzeltmeKararTarihField = value;
                        RaisePropertyChanged("DisTemsDuzeltmeKararTarih");
                    }
                }
            }
            
            
            public string DisTemsDuzeltmeNeden {
                get {
                    return DisTemsDuzeltmeNedenField;
                }
                set {
                    if ((object.ReferenceEquals(DisTemsDuzeltmeNedenField, value) != true)) {
                        DisTemsDuzeltmeNedenField = value;
                        RaisePropertyChanged("DisTemsDuzeltmeNeden");
                    }
                }
            }
            
            
            public string DisTemsilcilik {
                get {
                    return DisTemsilcilikField;
                }
                set {
                    if ((object.ReferenceEquals(DisTemsilcilikField, value) != true)) {
                        DisTemsilcilikField = value;
                        RaisePropertyChanged("DisTemsilcilik");
                    }
                }
            }
            
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public string HataBilgisi {
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
            
            
            public string IcKapiNo {
                get {
                    return IcKapiNoField;
                }
                set {
                    if ((object.ReferenceEquals(IcKapiNoField, value) != true)) {
                        IcKapiNoField = value;
                        RaisePropertyChanged("IcKapiNo");
                    }
                }
            }
            
            
            public string Il {
                get {
                    return IlField;
                }
                set {
                    if ((object.ReferenceEquals(IlField, value) != true)) {
                        IlField = value;
                        RaisePropertyChanged("Il");
                    }
                }
            }
            
            
            public string IlKodu {
                get {
                    return IlKoduField;
                }
                set {
                    if ((object.ReferenceEquals(IlKoduField, value) != true)) {
                        IlKoduField = value;
                        RaisePropertyChanged("IlKodu");
                    }
                }
            }
            
            
            public string Ilce {
                get {
                    return IlceField;
                }
                set {
                    if ((object.ReferenceEquals(IlceField, value) != true)) {
                        IlceField = value;
                        RaisePropertyChanged("Ilce");
                    }
                }
            }
            
            
            public string IlceKodu {
                get {
                    return IlceKoduField;
                }
                set {
                    if ((object.ReferenceEquals(IlceKoduField, value) != true)) {
                        IlceKoduField = value;
                        RaisePropertyChanged("IlceKodu");
                    }
                }
            }
            
            
            public string Koy {
                get {
                    return KoyField;
                }
                set {
                    if ((object.ReferenceEquals(KoyField, value) != true)) {
                        KoyField = value;
                        RaisePropertyChanged("Koy");
                    }
                }
            }
            
            
            public string KoyKayitNo {
                get {
                    return KoyKayitNoField;
                }
                set {
                    if ((object.ReferenceEquals(KoyKayitNoField, value) != true)) {
                        KoyKayitNoField = value;
                        RaisePropertyChanged("KoyKayitNo");
                    }
                }
            }
            
            
            public string KoyKodu {
                get {
                    return KoyKoduField;
                }
                set {
                    if ((object.ReferenceEquals(KoyKoduField, value) != true)) {
                        KoyKoduField = value;
                        RaisePropertyChanged("KoyKodu");
                    }
                }
            }
            
            
            public string Mahalle {
                get {
                    return MahalleField;
                }
                set {
                    if ((object.ReferenceEquals(MahalleField, value) != true)) {
                        MahalleField = value;
                        RaisePropertyChanged("Mahalle");
                    }
                }
            }
            
            
            public string MahalleKodu {
                get {
                    return MahalleKoduField;
                }
                set {
                    if ((object.ReferenceEquals(MahalleKoduField, value) != true)) {
                        MahalleKoduField = value;
                        RaisePropertyChanged("MahalleKodu");
                    }
                }
            }
            
            
            public string TasinmaTarihi {
                get {
                    return TasinmaTarihiField;
                }
                set {
                    if ((object.ReferenceEquals(TasinmaTarihiField, value) != true)) {
                        TasinmaTarihiField = value;
                        RaisePropertyChanged("TasinmaTarihi");
                    }
                }
            }
            
            
            public string TescilTarihi {
                get {
                    return TescilTarihiField;
                }
                set {
                    if ((object.ReferenceEquals(TescilTarihiField, value) != true)) {
                        TescilTarihiField = value;
                        RaisePropertyChanged("TescilTarihi");
                    }
                }
            }
            
            
            public string YabanciAdres {
                get {
                    return YabanciAdresField;
                }
                set {
                    if ((object.ReferenceEquals(YabanciAdresField, value) != true)) {
                        YabanciAdresField = value;
                        RaisePropertyChanged("YabanciAdres");
                    }
                }
            }
            
            
            public string YabanciSehir {
                get {
                    return YabanciSehirField;
                }
                set {
                    if ((object.ReferenceEquals(YabanciSehirField, value) != true)) {
                        YabanciSehirField = value;
                        RaisePropertyChanged("YabanciSehir");
                    }
                }
            }
            
            
            public string YabanciUlke {
                get {
                    return YabanciUlkeField;
                }
                set {
                    if ((object.ReferenceEquals(YabanciUlkeField, value) != true)) {
                        YabanciUlkeField = value;
                        RaisePropertyChanged("YabanciUlke");
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
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        public enum AdresTipi : int {
            
            Tanimsiz = -1,
            
            Koy = 3,
            
            Belde = 2,
            
            IlceMerkezi = 1,
            
            YurtDisi = 4,
        }
        
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.SerializableAttribute()]
        public partial class KPSServisSonucuAdresTipi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private AdresTipi SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public AdresTipi Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((SonucField.Equals(value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class KPSServisSonucuMaviKartKisiBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private MaviKartKisiBilgisi SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public MaviKartKisiBilgisi Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((object.ReferenceEquals(SonucField, value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class MaviKartKisiBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnneTCKimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaTCKimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumYerKodField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DurumField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string EsTCKimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KazanilanTCKimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string MedeniHalField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string OlumTarihField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private MaviKartKisiTemelBilgisi TemelBilgisiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string UlkeField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string UlkeKodField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string YakinlikField;
            
            public string AnneTCKimlikNo {
                get {
                    return AnneTCKimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(AnneTCKimlikNoField, value) != true)) {
                        AnneTCKimlikNoField = value;
                        RaisePropertyChanged("AnneTCKimlikNo");
                    }
                }
            }
            
            
            public string BabaTCKimlikNo {
                get {
                    return BabaTCKimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(BabaTCKimlikNoField, value) != true)) {
                        BabaTCKimlikNoField = value;
                        RaisePropertyChanged("BabaTCKimlikNo");
                    }
                }
            }
            
            
            public string DogumYerKod {
                get {
                    return DogumYerKodField;
                }
                set {
                    if ((object.ReferenceEquals(DogumYerKodField, value) != true)) {
                        DogumYerKodField = value;
                        RaisePropertyChanged("DogumYerKod");
                    }
                }
            }
            
            
            public string Durum {
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
            
            
            public string EsTCKimlikNo {
                get {
                    return EsTCKimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(EsTCKimlikNoField, value) != true)) {
                        EsTCKimlikNoField = value;
                        RaisePropertyChanged("EsTCKimlikNo");
                    }
                }
            }
            
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public string KazanilanTCKimlikNo {
                get {
                    return KazanilanTCKimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(KazanilanTCKimlikNoField, value) != true)) {
                        KazanilanTCKimlikNoField = value;
                        RaisePropertyChanged("KazanilanTCKimlikNo");
                    }
                }
            }
            
            
            public string KimlikNo {
                get {
                    return KimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(KimlikNoField, value) != true)) {
                        KimlikNoField = value;
                        RaisePropertyChanged("KimlikNo");
                    }
                }
            }
            
            
            public string MedeniHal {
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
            
            
            public string OlumTarih {
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
            
            
            public MaviKartKisiTemelBilgisi TemelBilgisi {
                get {
                    return TemelBilgisiField;
                }
                set {
                    if ((object.ReferenceEquals(TemelBilgisiField, value) != true)) {
                        TemelBilgisiField = value;
                        RaisePropertyChanged("TemelBilgisi");
                    }
                }
            }
            
            
            public string Ulke {
                get {
                    return UlkeField;
                }
                set {
                    if ((object.ReferenceEquals(UlkeField, value) != true)) {
                        UlkeField = value;
                        RaisePropertyChanged("Ulke");
                    }
                }
            }
            
            
            public string UlkeKod {
                get {
                    return UlkeKodField;
                }
                set {
                    if ((object.ReferenceEquals(UlkeKodField, value) != true)) {
                        UlkeKodField = value;
                        RaisePropertyChanged("UlkeKod");
                    }
                }
            }
            
            
            public string Yakinlik {
                get {
                    return YakinlikField;
                }
                set {
                    if ((object.ReferenceEquals(YakinlikField, value) != true)) {
                        YakinlikField = value;
                        RaisePropertyChanged("Yakinlik");
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
        public partial class MaviKartKisiTemelBilgisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnneAdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaAdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string CinsiyetField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumTarihField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DogumYerField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadField;
            
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
            
            
            public string Cinsiyet {
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
            
            
            public string DogumTarih {
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
        public partial class KPSServisSonucuMaviKartDegisimListesi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private MaviKartDegisimListesi SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public MaviKartDegisimListesi Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((object.ReferenceEquals(SonucField, value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class MaviKartDegisimListesi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private long[] KimlikNoListesiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private System.Nullable<long> SonrakiSayfaField;
            
            public long[] KimlikNoListesi {
                get {
                    return KimlikNoListesiField;
                }
                set {
                    if ((object.ReferenceEquals(KimlikNoListesiField, value) != true)) {
                        KimlikNoListesiField = value;
                        RaisePropertyChanged("KimlikNoListesi");
                    }
                }
            }
            
            
            public System.Nullable<long> SonrakiSayfa {
                get {
                    return SonrakiSayfaField;
                }
                set {
                    if ((SonrakiSayfaField.Equals(value) != true)) {
                        SonrakiSayfaField = value;
                        RaisePropertyChanged("SonrakiSayfa");
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
        public partial class KPSServisSonucuKimlikNoSonuc : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KimlikNoSonuc SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public KimlikNoSonuc Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((object.ReferenceEquals(SonucField, value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class KimlikNoSonuc : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private KisiTemelBilgisi KisiBilgisiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private MaviKartKisiBilgisi MaviKartKisiBilgisiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private YabanciKisiBilgisi YabanciKisiBilgisiField;
            
            public KisiTemelBilgisi KisiBilgisi {
                get {
                    return KisiBilgisiField;
                }
                set {
                    if ((object.ReferenceEquals(KisiBilgisiField, value) != true)) {
                        KisiBilgisiField = value;
                        RaisePropertyChanged("KisiBilgisi");
                    }
                }
            }
            
            
            public MaviKartKisiBilgisi MaviKartKisiBilgisi {
                get {
                    return MaviKartKisiBilgisiField;
                }
                set {
                    if ((object.ReferenceEquals(MaviKartKisiBilgisiField, value) != true)) {
                        MaviKartKisiBilgisiField = value;
                        RaisePropertyChanged("MaviKartKisiBilgisi");
                    }
                }
            }
            
            
            public YabanciKisiBilgisi YabanciKisiBilgisi {
                get {
                    return YabanciKisiBilgisiField;
                }
                set {
                    if ((object.ReferenceEquals(YabanciKisiBilgisiField, value) != true)) {
                        YabanciKisiBilgisiField = value;
                        RaisePropertyChanged("YabanciKisiBilgisi");
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
        public partial class KPSServisSonucuNkoSonuc : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private NkoSonuc SonucField;
            
            public string Hata {
                get {
                    return HataField;
                }
                set {
                    if ((object.ReferenceEquals(HataField, value) != true)) {
                        HataField = value;
                        RaisePropertyChanged("Hata");
                    }
                }
            }
            
            
            public NkoSonuc Sonuc {
                get {
                    return SonucField;
                }
                set {
                    if ((object.ReferenceEquals(SonucField, value) != true)) {
                        SonucField = value;
                        RaisePropertyChanged("Sonuc");
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
        public partial class NkoSonuc : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private MaviKartNko MaviKartNkoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private NufusKayitOrnegi NkoField;
            
            public MaviKartNko MaviKartNko {
                get {
                    return MaviKartNkoField;
                }
                set {
                    if ((object.ReferenceEquals(MaviKartNkoField, value) != true)) {
                        MaviKartNkoField = value;
                        RaisePropertyChanged("MaviKartNko");
                    }
                }
            }
            
            
            public NufusKayitOrnegi Nko {
                get {
                    return NkoField;
                }
                set {
                    if ((object.ReferenceEquals(NkoField, value) != true)) {
                        NkoField = value;
                        RaisePropertyChanged("Nko");
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
        public partial class MaviKartNko : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private MaviKartNkoKisi[] KisilerField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private MaviKartNkoOlay[] OlaylarField;
            
            public MaviKartNkoKisi[] Kisiler {
                get {
                    return KisilerField;
                }
                set {
                    if ((object.ReferenceEquals(KisilerField, value) != true)) {
                        KisilerField = value;
                        RaisePropertyChanged("Kisiler");
                    }
                }
            }
            
            
            public MaviKartNkoOlay[] Olaylar {
                get {
                    return OlaylarField;
                }
                set {
                    if ((object.ReferenceEquals(OlaylarField, value) != true)) {
                        OlaylarField = value;
                        RaisePropertyChanged("Olaylar");
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
        public partial class MaviKartNkoKisi : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AnneKimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BabaKimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string BosanmaTarihField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DurumField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string EsKimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string EvlenmeTarihField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private MaviKartKisiTemelBilgisi TemelBilgisiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string TescilTarihField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string UlkeField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string YakinlikField;
            
            public string AnneKimlikNo {
                get {
                    return AnneKimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(AnneKimlikNoField, value) != true)) {
                        AnneKimlikNoField = value;
                        RaisePropertyChanged("AnneKimlikNo");
                    }
                }
            }
            
            
            public string BabaKimlikNo {
                get {
                    return BabaKimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(BabaKimlikNoField, value) != true)) {
                        BabaKimlikNoField = value;
                        RaisePropertyChanged("BabaKimlikNo");
                    }
                }
            }
            
            
            public string BosanmaTarih {
                get {
                    return BosanmaTarihField;
                }
                set {
                    if ((object.ReferenceEquals(BosanmaTarihField, value) != true)) {
                        BosanmaTarihField = value;
                        RaisePropertyChanged("BosanmaTarih");
                    }
                }
            }
            
            
            public string Durum {
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
            
            
            public string EsKimlikNo {
                get {
                    return EsKimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(EsKimlikNoField, value) != true)) {
                        EsKimlikNoField = value;
                        RaisePropertyChanged("EsKimlikNo");
                    }
                }
            }
            
            
            public string EvlenmeTarih {
                get {
                    return EvlenmeTarihField;
                }
                set {
                    if ((object.ReferenceEquals(EvlenmeTarihField, value) != true)) {
                        EvlenmeTarihField = value;
                        RaisePropertyChanged("EvlenmeTarih");
                    }
                }
            }
            
            
            public string KimlikNo {
                get {
                    return KimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(KimlikNoField, value) != true)) {
                        KimlikNoField = value;
                        RaisePropertyChanged("KimlikNo");
                    }
                }
            }
            
            
            public MaviKartKisiTemelBilgisi TemelBilgisi {
                get {
                    return TemelBilgisiField;
                }
                set {
                    if ((object.ReferenceEquals(TemelBilgisiField, value) != true)) {
                        TemelBilgisiField = value;
                        RaisePropertyChanged("TemelBilgisi");
                    }
                }
            }
            
            
            public string TescilTarih {
                get {
                    return TescilTarihField;
                }
                set {
                    if ((object.ReferenceEquals(TescilTarihField, value) != true)) {
                        TescilTarihField = value;
                        RaisePropertyChanged("TescilTarih");
                    }
                }
            }
            
            
            public string Ulke {
                get {
                    return UlkeField;
                }
                set {
                    if ((object.ReferenceEquals(UlkeField, value) != true)) {
                        UlkeField = value;
                        RaisePropertyChanged("Ulke");
                    }
                }
            }
            
            
            public string Yakinlik {
                get {
                    return YakinlikField;
                }
                set {
                    if ((object.ReferenceEquals(YakinlikField, value) != true)) {
                        YakinlikField = value;
                        RaisePropertyChanged("Yakinlik");
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
        public partial class MaviKartNkoOlay : object, System.ComponentModel.INotifyPropertyChanged {
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string AdField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string DusunceField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string HataBilgisiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string KimlikNoField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string OlayTarihField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string OlayTipiField;
            
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private string SoyadField;
            
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
            
            
            public string Dusunce {
                get {
                    return DusunceField;
                }
                set {
                    if ((object.ReferenceEquals(DusunceField, value) != true)) {
                        DusunceField = value;
                        RaisePropertyChanged("Dusunce");
                    }
                }
            }
            
            
            public string HataBilgisi {
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
            
            
            public string KimlikNo {
                get {
                    return KimlikNoField;
                }
                set {
                    if ((object.ReferenceEquals(KimlikNoField, value) != true)) {
                        KimlikNoField = value;
                        RaisePropertyChanged("KimlikNo");
                    }
                }
            }
            
            
            public string OlayTarih {
                get {
                    return OlayTarihField;
                }
                set {
                    if ((object.ReferenceEquals(OlayTarihField, value) != true)) {
                        OlayTarihField = value;
                        RaisePropertyChanged("OlayTarih");
                    }
                }
            }
            
            
            public string OlayTipi {
                get {
                    return OlayTipiField;
                }
                set {
                    if ((object.ReferenceEquals(OlayTipiField, value) != true)) {
                        OlayTipiField = value;
                        RaisePropertyChanged("OlayTipi");
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
            
            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
            
            protected void RaisePropertyChanged(string propertyName) {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if ((propertyChanged != null)) {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }
        
#endregion Methods

    }
}