
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiabetesMellitusPursuit")] 

    /// <summary>
    /// Diyabet Takip
    /// </summary>
    public  partial class DiabetesMellitusPursuit : TTObject
    {
        public class DiabetesMellitusPursuitList : TTObjectCollection<DiabetesMellitusPursuit> { }
                    
        public class ChildDiabetesMellitusPursuitCollection : TTObject.TTChildObjectCollection<DiabetesMellitusPursuit>
        {
            public ChildDiabetesMellitusPursuitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiabetesMellitusPursuitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// TPG
    /// </summary>
        public double? tpg
        {
            get { return (double?)this["TPG"]; }
            set { this["TPG"] = value; }
        }

    /// <summary>
    /// HbA1c 
    /// </summary>
        public double? hbA1c
        {
            get { return (double?)this["HBA1C"]; }
            set { this["HBA1C"] = value; }
        }

    /// <summary>
    /// Kreatinin
    /// </summary>
        public double? kreatinin
        {
            get { return (double?)this["KREATININ"]; }
            set { this["KREATININ"] = value; }
        }

    /// <summary>
    /// Trigliserid 
    /// </summary>
        public double? trigliserid
        {
            get { return (double?)this["TRIGLISERID"]; }
            set { this["TRIGLISERID"] = value; }
        }

    /// <summary>
    /// LDL-Kol 
    /// </summary>
        public double? ldlKol
        {
            get { return (double?)this["LDLKOL"]; }
            set { this["LDLKOL"] = value; }
        }

    /// <summary>
    /// HDL-Kol
    /// </summary>
        public double? hdlKol
        {
            get { return (double?)this["HDLKOL"]; }
            set { this["HDLKOL"] = value; }
        }

    /// <summary>
    /// ALT
    /// </summary>
        public double? alt
        {
            get { return (double?)this["ALT"]; }
            set { this["ALT"] = value; }
        }

    /// <summary>
    /// AntiGAD 
    /// </summary>
        public AntiGADEnum? antiGAD
        {
            get { return (AntiGADEnum?)(int?)this["ANTIGAD"]; }
            set { this["ANTIGAD"] = value; }
        }

    /// <summary>
    /// EKG
    /// </summary>
        public EkgEnum? ekg
        {
            get { return (EkgEnum?)(int?)this["EKG"]; }
            set { this["EKG"] = value; }
        }

    /// <summary>
    /// Mikroalbuminüri
    /// </summary>
        public VarYokEnum? mikroalbuminuri
        {
            get { return (VarYokEnum?)(int?)this["MIKROALBUMINURI"]; }
            set { this["MIKROALBUMINURI"] = value; }
        }

    /// <summary>
    /// Göz Muayenesi
    /// </summary>
        public GozMuayenesiEnum? gozMuayenesi
        {
            get { return (GozMuayenesiEnum?)(int?)this["GOZMUAYENESI"]; }
            set { this["GOZMUAYENESI"] = value; }
        }

    /// <summary>
    /// Periferik Sensoryal Nöropati 
    /// </summary>
        public VarYokEnum? periferikSensoryal
        {
            get { return (VarYokEnum?)(int?)this["PERIFERIKSENSORYAL"]; }
            set { this["PERIFERIKSENSORYAL"] = value; }
        }

    /// <summary>
    /// Koroner Arter H 
    /// </summary>
        public VarYokEnum? koronerArterH
        {
            get { return (VarYokEnum?)(int?)this["KORONERARTERH"]; }
            set { this["KORONERARTERH"] = value; }
        }

    /// <summary>
    /// Serebrovasküler H
    /// </summary>
        public VarYokEnum? serebrovaskulerH
        {
            get { return (VarYokEnum?)(int?)this["SEREBROVASKULERH"]; }
            set { this["SEREBROVASKULERH"] = value; }
        }

    /// <summary>
    /// Ayak Muayenesi
    /// </summary>
        public AyakMuayenesiEnum? ayakMuayenesi
        {
            get { return (AyakMuayenesiEnum?)(int?)this["AYAKMUAYENESI"]; }
            set { this["AYAKMUAYENESI"] = value; }
        }

    /// <summary>
    /// Akut komplikasyonu
    /// </summary>
        public AkutKomplikasyonEnum? akutKomplikasyon
        {
            get { return (AkutKomplikasyonEnum?)(int?)this["AKUTKOMPLIKASYON"]; }
            set { this["AKUTKOMPLIKASYON"] = value; }
        }

    /// <summary>
    /// TC Kimlik Numarası 
    /// </summary>
        public string tCKimlikNo
        {
            get { return (string)this["TCKIMLIKNO"]; }
            set { this["TCKIMLIKNO"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string ad
        {
            get { return (string)this["AD"]; }
            set { this["AD"] = value; }
        }

    /// <summary>
    /// Soyad
    /// </summary>
        public string soyad
        {
            get { return (string)this["SOYAD"]; }
            set { this["SOYAD"] = value; }
        }

    /// <summary>
    /// Cep Telefonu
    /// </summary>
        public string cepTel
        {
            get { return (string)this["CEPTEL"]; }
            set { this["CEPTEL"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public string protokolNo
        {
            get { return (string)this["PROTOKOLNO"]; }
            set { this["PROTOKOLNO"] = value; }
        }

    /// <summary>
    /// Vizit Tarihi
    /// </summary>
        public DateTime? vizitTarihi
        {
            get { return (DateTime?)this["VIZITTARIHI"]; }
            set { this["VIZITTARIHI"] = value; }
        }

    /// <summary>
    /// Hastanın cinsiyeti
    /// </summary>
        public string cinsiyet
        {
            get { return (string)this["CINSIYET"]; }
            set { this["CINSIYET"] = value; }
        }

    /// <summary>
    /// Tanı Tarihi
    /// </summary>
        public DateTime? taniTarihi
        {
            get { return (DateTime?)this["TANITARIHI"]; }
            set { this["TANITARIHI"] = value; }
        }

    /// <summary>
    /// İkamet Türü
    /// </summary>
        public ikametTuruEnum? ikametTuru
        {
            get { return (ikametTuruEnum?)(int?)this["IKAMETTURU"]; }
            set { this["IKAMETTURU"] = value; }
        }

    /// <summary>
    /// Tıbbı Beslenme Tedavisi 
    /// </summary>
        public TibbiBeslenmeTedavisiEnum? tibbiBeslenmeTedavisi
        {
            get { return (TibbiBeslenmeTedavisiEnum?)(int?)this["TIBBIBESLENMETEDAVISI"]; }
            set { this["TIBBIBESLENMETEDAVISI"] = value; }
        }

    /// <summary>
    /// Egzersiz
    /// </summary>
        public EgzersizEnum? egzersiz
        {
            get { return (EgzersizEnum?)(int?)this["EGZERSIZ"]; }
            set { this["EGZERSIZ"] = value; }
        }

    /// <summary>
    /// Başvuru Nedeni
    /// </summary>
        public BasvuruNedeniEnum? basvuruNedeni
        {
            get { return (BasvuruNedeniEnum?)(int?)this["BASVURUNEDENI"]; }
            set { this["BASVURUNEDENI"] = value; }
        }

    /// <summary>
    /// Gluko Metre
    /// </summary>
        public VarYokEnum? glukoMetre
        {
            get { return (VarYokEnum?)(int?)this["GLUKOMETRE"]; }
            set { this["GLUKOMETRE"] = value; }
        }

    /// <summary>
    /// Kan şekeri takip sayısı
    /// </summary>
        public int? kanSekeriTakipSayisi
        {
            get { return (int?)this["KANSEKERITAKIPSAYISI"]; }
            set { this["KANSEKERITAKIPSAYISI"] = value; }
        }

    /// <summary>
    /// Sistolik Kan Basıncı 
    /// </summary>
        public int? sistolikKanBasinci
        {
            get { return (int?)this["SISTOLIKKANBASINCI"]; }
            set { this["SISTOLIKKANBASINCI"] = value; }
        }

    /// <summary>
    ///  Diyastolik Kan Basıncı 
    /// </summary>
        public int? diyastolikKanBasinci
        {
            get { return (int?)this["DIYASTOLIKKANBASINCI"]; }
            set { this["DIYASTOLIKKANBASINCI"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public double? boy
        {
            get { return (double?)this["BOY"]; }
            set { this["BOY"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public double? kilo
        {
            get { return (double?)this["KILO"]; }
            set { this["KILO"] = value; }
        }

    /// <summary>
    /// VKİ
    /// </summary>
        public double? vki
        {
            get { return (double?)this["VKI"]; }
            set { this["VKI"] = value; }
        }

    /// <summary>
    /// APG
    /// </summary>
        public double? apg
        {
            get { return (double?)this["APG"]; }
            set { this["APG"] = value; }
        }

    /// <summary>
    /// İnsülin Pompası
    /// </summary>
        public VarYokEnum? insulinPompasi
        {
            get { return (VarYokEnum?)(int?)this["INSULINPOMPASI"]; }
            set { this["INSULINPOMPASI"] = value; }
        }

    /// <summary>
    /// Hasta Yatış Gün 
    /// </summary>
        public int? yatisGun
        {
            get { return (int?)this["YATISGUN"]; }
            set { this["YATISGUN"] = value; }
        }

    /// <summary>
    /// İnsülin Pompası Veriliş Tarihi
    /// </summary>
        public DateTime? insulinPompasiVerTarihi
        {
            get { return (DateTime?)this["INSULINPOMPASIVERTARIHI"]; }
            set { this["INSULINPOMPASIVERTARIHI"] = value; }
        }

    /// <summary>
    /// İnsülin Pompası Değiştirme tarihi
    /// </summary>
        public DateTime? insulinPompasiDegTarihi
        {
            get { return (DateTime?)this["INSULINPOMPASIDEGTARIHI"]; }
            set { this["INSULINPOMPASIDEGTARIHI"] = value; }
        }

    /// <summary>
    /// Takip Formu No
    /// </summary>
        public string takipFormuNo
        {
            get { return (string)this["TAKIPFORMUNO"]; }
            set { this["TAKIPFORMUNO"] = value; }
        }

        public DiagnosisDefinition HastaTanisi
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("HASTATANISI"); }
            set { this["HASTATANISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiabetesMellitusPursuitTemplate DiabetesMellitusPursuitTmplt
        {
            get { return (DiabetesMellitusPursuitTemplate)((ITTObject)this).GetParent("DIABETESMELLITUSPURSUITTMPLT"); }
            set { this["DIABETESMELLITUSPURSUITTMPLT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDiabetesMellitusPursuitDoctorCollection()
        {
            _DiabetesMellitusPursuitDoctor = new DiabetesMellitusPursuitDoctor.ChildDiabetesMellitusPursuitDoctorCollection(this, new Guid("199ce644-270c-48ab-891d-efa5a63b19f9"));
            ((ITTChildObjectCollection)_DiabetesMellitusPursuitDoctor).GetChildren();
        }

        protected DiabetesMellitusPursuitDoctor.ChildDiabetesMellitusPursuitDoctorCollection _DiabetesMellitusPursuitDoctor = null;
        public DiabetesMellitusPursuitDoctor.ChildDiabetesMellitusPursuitDoctorCollection DiabetesMellitusPursuitDoctor
        {
            get
            {
                if (_DiabetesMellitusPursuitDoctor == null)
                    CreateDiabetesMellitusPursuitDoctorCollection();
                return _DiabetesMellitusPursuitDoctor;
            }
        }

        virtual protected void CreateDiabetesMellitusPursuitHabitCollection()
        {
            _DiabetesMellitusPursuitHabit = new DiabetesMellitusPursuitHabit.ChildDiabetesMellitusPursuitHabitCollection(this, new Guid("6b63de29-2e30-430a-8a0b-98430ceed2b4"));
            ((ITTChildObjectCollection)_DiabetesMellitusPursuitHabit).GetChildren();
        }

        protected DiabetesMellitusPursuitHabit.ChildDiabetesMellitusPursuitHabitCollection _DiabetesMellitusPursuitHabit = null;
        public DiabetesMellitusPursuitHabit.ChildDiabetesMellitusPursuitHabitCollection DiabetesMellitusPursuitHabit
        {
            get
            {
                if (_DiabetesMellitusPursuitHabit == null)
                    CreateDiabetesMellitusPursuitHabitCollection();
                return _DiabetesMellitusPursuitHabit;
            }
        }

        virtual protected void CreateDiabetesMellitusPursuitInstructionCollection()
        {
            _DiabetesMellitusPursuitInstruction = new DiabetesMellitusPursuitInstruction.ChildDiabetesMellitusPursuitInstructionCollection(this, new Guid("686a4831-0504-40fe-9064-2f0ca33db0da"));
            ((ITTChildObjectCollection)_DiabetesMellitusPursuitInstruction).GetChildren();
        }

        protected DiabetesMellitusPursuitInstruction.ChildDiabetesMellitusPursuitInstructionCollection _DiabetesMellitusPursuitInstruction = null;
        public DiabetesMellitusPursuitInstruction.ChildDiabetesMellitusPursuitInstructionCollection DiabetesMellitusPursuitInstruction
        {
            get
            {
                if (_DiabetesMellitusPursuitInstruction == null)
                    CreateDiabetesMellitusPursuitInstructionCollection();
                return _DiabetesMellitusPursuitInstruction;
            }
        }

        virtual protected void CreateDiabetesMellitusPursuitDiseaseCollection()
        {
            _DiabetesMellitusPursuitDisease = new DiabetesMellitusPursuitDisease.ChildDiabetesMellitusPursuitDiseaseCollection(this, new Guid("c7309ed3-087b-4b6c-85e7-6e7a77ecb448"));
            ((ITTChildObjectCollection)_DiabetesMellitusPursuitDisease).GetChildren();
        }

        protected DiabetesMellitusPursuitDisease.ChildDiabetesMellitusPursuitDiseaseCollection _DiabetesMellitusPursuitDisease = null;
        public DiabetesMellitusPursuitDisease.ChildDiabetesMellitusPursuitDiseaseCollection DiabetesMellitusPursuitDisease
        {
            get
            {
                if (_DiabetesMellitusPursuitDisease == null)
                    CreateDiabetesMellitusPursuitDiseaseCollection();
                return _DiabetesMellitusPursuitDisease;
            }
        }

        virtual protected void CreateDiyabetTakipCollection()
        {
            _DiyabetTakip = new DiyabetTakip.ChildDiyabetTakipCollection(this, new Guid("5b1f0e8b-66ec-4603-a265-7f4a77aecbee"));
            ((ITTChildObjectCollection)_DiyabetTakip).GetChildren();
        }

        protected DiyabetTakip.ChildDiyabetTakipCollection _DiyabetTakip = null;
        public DiyabetTakip.ChildDiyabetTakipCollection DiyabetTakip
        {
            get
            {
                if (_DiyabetTakip == null)
                    CreateDiyabetTakipCollection();
                return _DiyabetTakip;
            }
        }

        virtual protected void CreateDiabetesMellitusPursuitUsedDrugCollection()
        {
            _DiabetesMellitusPursuitUsedDrug = new DiabetesMellitusPursuitUsedDrug.ChildDiabetesMellitusPursuitUsedDrugCollection(this, new Guid("8d394a61-4c0e-4961-88d2-1fb6b5cd06a8"));
            ((ITTChildObjectCollection)_DiabetesMellitusPursuitUsedDrug).GetChildren();
        }

        protected DiabetesMellitusPursuitUsedDrug.ChildDiabetesMellitusPursuitUsedDrugCollection _DiabetesMellitusPursuitUsedDrug = null;
        public DiabetesMellitusPursuitUsedDrug.ChildDiabetesMellitusPursuitUsedDrugCollection DiabetesMellitusPursuitUsedDrug
        {
            get
            {
                if (_DiabetesMellitusPursuitUsedDrug == null)
                    CreateDiabetesMellitusPursuitUsedDrugCollection();
                return _DiabetesMellitusPursuitUsedDrug;
            }
        }

        protected DiabetesMellitusPursuit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiabetesMellitusPursuit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiabetesMellitusPursuit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiabetesMellitusPursuit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiabetesMellitusPursuit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIABETESMELLITUSPURSUIT", dataRow) { }
        protected DiabetesMellitusPursuit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIABETESMELLITUSPURSUIT", dataRow, isImported) { }
        public DiabetesMellitusPursuit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiabetesMellitusPursuit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiabetesMellitusPursuit() : base() { }

    }
}