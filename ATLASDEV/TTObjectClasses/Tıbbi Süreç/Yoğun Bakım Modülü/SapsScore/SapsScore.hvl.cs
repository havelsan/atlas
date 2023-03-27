
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SapsScore")] 

    public  partial class SapsScore : BaseMultipleDataEntry
    {
        public class SapsScoreList : TTObjectCollection<SapsScore> { }
                    
        public class ChildSapsScoreCollection : TTObject.TTChildObjectCollection<SapsScore>
        {
            public ChildSapsScoreCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSapsScoreCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<SapsScore> GetDescOrderedSapScoreByEpisodeAction(TTObjectContext objectContext, string EPISODEACTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAPSSCORE"].QueryDefs["GetDescOrderedSapScoreByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return ((ITTQuery)objectContext).QueryObjects<SapsScore>(queryDef, paramList);
        }

        public SapsBilirubinEnum? Bilirubin
        {
            get { return (SapsBilirubinEnum?)(int?)this["BILIRUBIN"]; }
            set { this["BILIRUBIN"] = value; }
        }

        public SapsBodyTemperatureEnum? BodyTemperature
        {
            get { return (SapsBodyTemperatureEnum?)(int?)this["BODYTEMPERATURE"]; }
            set { this["BODYTEMPERATURE"] = value; }
        }

        public SapsChronicIllnessEnum? ChronicIllness
        {
            get { return (SapsChronicIllnessEnum?)(int?)this["CHRONICILLNESS"]; }
            set { this["CHRONICILLNESS"] = value; }
        }

        public SapsClinicCategoryEnum? ClinicCategory
        {
            get { return (SapsClinicCategoryEnum?)(int?)this["CLINICCATEGORY"]; }
            set { this["CLINICCATEGORY"] = value; }
        }

        public SapsDurationOfStayBeforeIntensiveCare? DurationOfStayBeforeIC
        {
            get { return (SapsDurationOfStayBeforeIntensiveCare?)(int?)this["DURATIONOFSTAYBEFOREIC"]; }
            set { this["DURATIONOFSTAYBEFOREIC"] = value; }
        }

        public SapsGlasgowEnum? Glasgow
        {
            get { return (SapsGlasgowEnum?)(int?)this["GLASGOW"]; }
            set { this["GLASGOW"] = value; }
        }

        public SapsHCO3Enum? HCO3
        {
            get { return (SapsHCO3Enum?)(int?)this["HCO3"]; }
            set { this["HCO3"] = value; }
        }

        public SapsHeartRateEnum? HeartRate
        {
            get { return (SapsHeartRateEnum?)(int?)this["HEARTRATE"]; }
            set { this["HEARTRATE"] = value; }
        }

        public SapsInpatientResourceBeforeIntensiveCare? InpatientResourceBeforeIC
        {
            get { return (SapsInpatientResourceBeforeIntensiveCare?)(int?)this["INPATIENTRESOURCEBEFOREIC"]; }
            set { this["INPATIENTRESOURCEBEFOREIC"] = value; }
        }

        public SapsInpatientTypeEnum? InpatientType
        {
            get { return (SapsInpatientTypeEnum?)(int?)this["INPATIENTTYPE"]; }
            set { this["INPATIENTTYPE"] = value; }
        }

        public SapsPaO2_FIO2Enum? PaO2_FIO2
        {
            get { return (SapsPaO2_FIO2Enum?)(int?)this["PAO2_FIO2"]; }
            set { this["PAO2_FIO2"] = value; }
        }

        public SapsPotassiumEnum? Potassium
        {
            get { return (SapsPotassiumEnum?)(int?)this["POTASSIUM"]; }
            set { this["POTASSIUM"] = value; }
        }

        public SapsSerumUreEnum? SerumUre
        {
            get { return (SapsSerumUreEnum?)(int?)this["SERUMURE"]; }
            set { this["SERUMURE"] = value; }
        }

        public SapsSistolikEnum? SistolikBloodPressure
        {
            get { return (SapsSistolikEnum?)(int?)this["SISTOLIKBLOODPRESSURE"]; }
            set { this["SISTOLIKBLOODPRESSURE"] = value; }
        }

        public SapsSodiumEnum? Sodium
        {
            get { return (SapsSodiumEnum?)(int?)this["SODIUM"]; }
            set { this["SODIUM"] = value; }
        }

        public SapsUrineEnum? Urine
        {
            get { return (SapsUrineEnum?)(int?)this["URINE"]; }
            set { this["URINE"] = value; }
        }

        public SapsWBC? WBC
        {
            get { return (SapsWBC?)(int?)this["WBC"]; }
            set { this["WBC"] = value; }
        }

        public YesNoEnum? Poising
        {
            get { return (YesNoEnum?)(int?)this["POISING"]; }
            set { this["POISING"] = value; }
        }

        public int? SapsIIPoint
        {
            get { return (int?)this["SAPSIIPOINT"]; }
            set { this["SAPSIIPOINT"] = value; }
        }

        public double? SapsIIPointDetail
        {
            get { return (double?)this["SAPSIIPOINTDETAIL"]; }
            set { this["SAPSIIPOINTDETAIL"] = value; }
        }

        public double? WaitingMortalite
        {
            get { return (double?)this["WAITINGMORTALITE"]; }
            set { this["WAITINGMORTALITE"] = value; }
        }

        public int? PatientAge
        {
            get { return (int?)this["PATIENTAGE"]; }
            set { this["PATIENTAGE"] = value; }
        }

        public SexEnum? PatientSex
        {
            get { return (SexEnum?)(int?)this["PATIENTSEX"]; }
            set { this["PATIENTSEX"] = value; }
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

        protected SapsScore(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SapsScore(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SapsScore(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SapsScore(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SapsScore(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SAPSSCORE", dataRow) { }
        protected SapsScore(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SAPSSCORE", dataRow, isImported) { }
        public SapsScore(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SapsScore(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SapsScore() : base() { }

    }
}