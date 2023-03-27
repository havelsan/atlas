
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ApacheScore")] 

    public  partial class ApacheScore : BaseMultipleDataEntry
    {
        public class ApacheScoreList : TTObjectCollection<ApacheScore> { }
                    
        public class ChildApacheScoreCollection : TTObject.TTChildObjectCollection<ApacheScore>
        {
            public ChildApacheScoreCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildApacheScoreCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ApacheScore> GetDescOrderedApacheScoreByEpisodeAction(TTObjectContext objectContext, string EPISODEACTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APACHESCORE"].QueryDefs["GetDescOrderedApacheScoreByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return ((ITTQuery)objectContext).QueryObjects<ApacheScore>(queryDef, paramList);
        }

    /// <summary>
    /// Vücut Isısı
    /// </summary>
        public ApacheBodyTemperatureEnum? BodyTemperature
        {
            get { return (ApacheBodyTemperatureEnum?)(int?)this["BODYTEMPERATURE"]; }
            set { this["BODYTEMPERATURE"] = value; }
        }

    /// <summary>
    /// Ortalama Kan Basıncı
    /// </summary>
        public ApacheMeanBloodPressureEnum? MeanBloodPressure
        {
            get { return (ApacheMeanBloodPressureEnum?)(int?)this["MEANBLOODPRESSURE"]; }
            set { this["MEANBLOODPRESSURE"] = value; }
        }

    /// <summary>
    /// Kalp Hızı
    /// </summary>
        public ApacheHeartRateEnum? HeartRate
        {
            get { return (ApacheHeartRateEnum?)(int?)this["HEARTRATE"]; }
            set { this["HEARTRATE"] = value; }
        }

    /// <summary>
    /// Solunum Hızı
    /// </summary>
        public ApacheBreathRateEnum? BreathRate
        {
            get { return (ApacheBreathRateEnum?)(int?)this["BREATHRATE"]; }
            set { this["BREATHRATE"] = value; }
        }

    /// <summary>
    /// FIO2 >= 0,5 ise (A-a) O2
    /// </summary>
        public ApacheFIO2OverEnum? FIO2Over
        {
            get { return (ApacheFIO2OverEnum?)(int?)this["FIO2OVER"]; }
            set { this["FIO2OVER"] = value; }
        }

    /// <summary>
    /// FIO2 < 0,5 ise PaO2
    /// </summary>
        public ApacheFIO2UnderEnum? FIO2Under
        {
            get { return (ApacheFIO2UnderEnum?)(int?)this["FIO2UNDER"]; }
            set { this["FIO2UNDER"] = value; }
        }

    /// <summary>
    /// AKG yok ise
    /// </summary>
        public ApacheNoAKGEnum? NoAKG
        {
            get { return (ApacheNoAKGEnum?)(int?)this["NOAKG"]; }
            set { this["NOAKG"] = value; }
        }

    /// <summary>
    /// Arterial pH
    /// </summary>
        public ApacheArterialpHEnum? ArterialpH
        {
            get { return (ApacheArterialpHEnum?)(int?)this["ARTERIALPH"]; }
            set { this["ARTERIALPH"] = value; }
        }

    /// <summary>
    /// Serum Sodyum (mmol/L)
    /// </summary>
        public ApacheSerumSodiumEnum? SerumSodium
        {
            get { return (ApacheSerumSodiumEnum?)(int?)this["SERUMSODIUM"]; }
            set { this["SERUMSODIUM"] = value; }
        }

    /// <summary>
    /// Beklenen Ölüm Oranı
    /// </summary>
        public double? ExpectedMortalityRate
        {
            get { return (double?)this["EXPECTEDMORTALITYRATE"]; }
            set { this["EXPECTEDMORTALITYRATE"] = value; }
        }

    /// <summary>
    /// Serum Potasyum (mmol/L)
    /// </summary>
        public ApacheSerumPotassiumEnum? SerumPotassium
        {
            get { return (ApacheSerumPotassiumEnum?)(int?)this["SERUMPOTASSIUM"]; }
            set { this["SERUMPOTASSIUM"] = value; }
        }

    /// <summary>
    /// Serum Kreatin Akut Böbrek Yetmezliği Var
    /// </summary>
        public ApacheSerumCreatinineEnum? SerumCreatinineYesFailure
        {
            get { return (ApacheSerumCreatinineEnum?)(int?)this["SERUMCREATININEYESFAILURE"]; }
            set { this["SERUMCREATININEYESFAILURE"] = value; }
        }

    /// <summary>
    /// Ht
    /// </summary>
        public ApacheHtEnum? Ht
        {
            get { return (ApacheHtEnum?)(int?)this["HT"]; }
            set { this["HT"] = value; }
        }

    /// <summary>
    /// W.B.C (x103/ mm3 )
    /// </summary>
        public ApacheWBCEnum? WBC
        {
            get { return (ApacheWBCEnum?)(int?)this["WBC"]; }
            set { this["WBC"] = value; }
        }

    /// <summary>
    /// Glasgow Koma Skore
    /// </summary>
        public ApacheGlasgowComaScaleEnum? GlasgowComaScale
        {
            get { return (ApacheGlasgowComaScaleEnum?)(int?)this["GLASGOWCOMASCALE"]; }
            set { this["GLASGOWCOMASCALE"] = value; }
        }

    /// <summary>
    /// Yaş
    /// </summary>
        public ApacheAgeEnum? Age
        {
            get { return (ApacheAgeEnum?)(int?)this["AGE"]; }
            set { this["AGE"] = value; }
        }

    /// <summary>
    /// Kronik Organ Yetmezilği
    /// </summary>
        public ApacheChronicOrganFailureEnum? ChronicOrganFailure
        {
            get { return (ApacheChronicOrganFailureEnum?)(int?)this["CHRONICORGANFAILURE"]; }
            set { this["CHRONICORGANFAILURE"] = value; }
        }

    /// <summary>
    /// Apache II Toplam
    /// </summary>
        public int? ApacheIITotal
        {
            get { return (int?)this["APACHEIITOTAL"]; }
            set { this["APACHEIITOTAL"] = value; }
        }

    /// <summary>
    /// Serum Kreatin Akut Böbrek Yetmezliği Yok
    /// </summary>
        public ApacheSerumCreatinineEnum? SerumCreatinineNoFailure
        {
            get { return (ApacheSerumCreatinineEnum?)(int?)this["SERUMCREATININENOFAILURE"]; }
            set { this["SERUMCREATININENOFAILURE"] = value; }
        }

    /// <summary>
    /// FIO2
    /// </summary>
        public int? FIO2
        {
            get { return (int?)this["FIO2"]; }
            set { this["FIO2"] = value; }
        }

    /// <summary>
    /// PaCO2
    /// </summary>
        public int? PaCO2
        {
            get { return (int?)this["PACO2"]; }
            set { this["PACO2"] = value; }
        }

    /// <summary>
    /// PaO2
    /// </summary>
        public int? PaO2
        {
            get { return (int?)this["PAO2"]; }
            set { this["PAO2"] = value; }
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

        protected ApacheScore(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ApacheScore(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ApacheScore(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ApacheScore(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ApacheScore(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "APACHESCORE", dataRow) { }
        protected ApacheScore(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "APACHESCORE", dataRow, isImported) { }
        public ApacheScore(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ApacheScore(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ApacheScore() : base() { }

    }
}