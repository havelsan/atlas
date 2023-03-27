using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ApacheScore
    {
        public Guid ObjectId { get; set; }
        public ApacheBodyTemperatureEnum? BodyTemperature { get; set; }
        public ApacheMeanBloodPressureEnum? MeanBloodPressure { get; set; }
        public ApacheHeartRateEnum? HeartRate { get; set; }
        public ApacheBreathRateEnum? BreathRate { get; set; }
        public ApacheFIO2OverEnum? FIO2Over { get; set; }
        public ApacheFIO2UnderEnum? FIO2Under { get; set; }
        public ApacheNoAKGEnum? NoAKG { get; set; }
        public ApacheArterialpHEnum? ArterialpH { get; set; }
        public ApacheSerumSodiumEnum? SerumSodium { get; set; }
        public double? ExpectedMortalityRate { get; set; }
        public ApacheSerumPotassiumEnum? SerumPotassium { get; set; }
        public ApacheSerumCreatinineEnum? SerumCreatinineYesFailure { get; set; }
        public ApacheHtEnum? Ht { get; set; }
        public ApacheWBCEnum? WBC { get; set; }
        public ApacheGlasgowComaScaleEnum? GlasgowComaScale { get; set; }
        public ApacheAgeEnum? Age { get; set; }
        public ApacheChronicOrganFailureEnum? ChronicOrganFailure { get; set; }
        public int? ApacheIITotal { get; set; }
        public ApacheSerumCreatinineEnum? SerumCreatinineNoFailure { get; set; }
        public int? FIO2 { get; set; }
        public int? PaCO2 { get; set; }
        public int? PaO2 { get; set; }

        #region Base Object Navigation Property
        public virtual BaseMultipleDataEntry BaseMultipleDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}