
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Prism")] 

    /// <summary>
    /// PRISM Skorlama
    /// </summary>
    public  partial class Prism : BaseMultipleDataEntry
    {
        public class PrismList : TTObjectCollection<Prism> { }
                    
        public class ChildPrismCollection : TTObject.TTChildObjectCollection<Prism>
        {
            public ChildPrismCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPrismCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sistolik Kan Basıncı (mmHg)
    /// </summary>
        public PrismSystolicEnum? SystolicPressure
        {
            get { return (PrismSystolicEnum?)(int?)this["SYSTOLICPRESSURE"]; }
            set { this["SYSTOLICPRESSURE"] = value; }
        }

    /// <summary>
    /// Diastolik Kan Basıncı (mmHg)
    /// </summary>
        public PrismDiastolicEnum? DiastolicPressure
        {
            get { return (PrismDiastolicEnum?)(int?)this["DIASTOLICPRESSURE"]; }
            set { this["DIASTOLICPRESSURE"] = value; }
        }

    /// <summary>
    /// Kalp Hızı (beats/ min)
    /// </summary>
        public PrismHeartRateEnum? HeartRate
        {
            get { return (PrismHeartRateEnum?)(int?)this["HEARTRATE"]; }
            set { this["HEARTRATE"] = value; }
        }

    /// <summary>
    /// Solunum Sayısı (breaths/ min)
    /// </summary>
        public PrismRespirationRateEnum? RespirationRate
        {
            get { return (PrismRespirationRateEnum?)(int?)this["RESPIRATIONRATE"]; }
            set { this["RESPIRATIONRATE"] = value; }
        }

    /// <summary>
    /// Pa O2 / FI O2 (mmHg)
    /// </summary>
        public PrismPaO2FIO2Enum? PaO2FIO2
        {
            get { return (PrismPaO2FIO2Enum?)(int?)this["PAO2FIO2"]; }
            set { this["PAO2FIO2"] = value; }
        }

    /// <summary>
    /// Pa CO2 (mmHg)
    /// </summary>
        public PrismPaCO2Enum? PaCO2
        {
            get { return (PrismPaCO2Enum?)(int?)this["PACO2"]; }
            set { this["PACO2"] = value; }
        }

    /// <summary>
    /// PT / PTT
    /// </summary>
        public PrismPTTEnum? PTT
        {
            get { return (PrismPTTEnum?)(int?)this["PTT"]; }
            set { this["PTT"] = value; }
        }

    /// <summary>
    /// Total Bilirubin
    /// </summary>
        public PrismBilirubinEnum? Bilirubin
        {
            get { return (PrismBilirubinEnum?)(int?)this["BILIRUBIN"]; }
            set { this["BILIRUBIN"] = value; }
        }

    /// <summary>
    /// Kalsiyum
    /// </summary>
        public PrismCalciumEnum? Calcium
        {
            get { return (PrismCalciumEnum?)(int?)this["CALCIUM"]; }
            set { this["CALCIUM"] = value; }
        }

    /// <summary>
    /// Potasyum (mEq/L)
    /// </summary>
        public PrismPotassiumEnum? Potassium
        {
            get { return (PrismPotassiumEnum?)(int?)this["POTASSIUM"]; }
            set { this["POTASSIUM"] = value; }
        }

    /// <summary>
    /// Glukoz
    /// </summary>
        public PrismGlucoseEnum? Glucose
        {
            get { return (PrismGlucoseEnum?)(int?)this["GLUCOSE"]; }
            set { this["GLUCOSE"] = value; }
        }

    /// <summary>
    /// HCO3- (mEq/L)
    /// </summary>
        public PrismHCO3Enum? HCO3
        {
            get { return (PrismHCO3Enum?)(int?)this["HCO3"]; }
            set { this["HCO3"] = value; }
        }

    /// <summary>
    /// Pupil Reaksiyonu
    /// </summary>
        public PrismPupilEnum? Pupil
        {
            get { return (PrismPupilEnum?)(int?)this["PUPIL"]; }
            set { this["PUPIL"] = value; }
        }

    /// <summary>
    /// Toplam Skor
    /// </summary>
        public int? TotalScore
        {
            get { return (int?)this["TOTALSCORE"]; }
            set { this["TOTALSCORE"] = value; }
        }

    /// <summary>
    /// Beklenen Ölüm Oranı
    /// </summary>
        public double? MortalityRate
        {
            get { return (double?)this["MORTALITYRATE"]; }
            set { this["MORTALITYRATE"] = value; }
        }

        public PhysicianApplication PhysicianApplication
        {
            get 
            {   
                if (EpisodeAction is PhysicianApplication)
                    return (PhysicianApplication)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected Prism(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Prism(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Prism(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Prism(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Prism(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRISM", dataRow) { }
        protected Prism(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRISM", dataRow, isImported) { }
        public Prism(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Prism(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Prism() : base() { }

    }
}