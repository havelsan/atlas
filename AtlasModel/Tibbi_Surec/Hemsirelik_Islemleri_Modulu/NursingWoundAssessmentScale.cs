using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingWoundAssessmentScale
    {
        public Guid ObjectId { get; set; }
        public DateTime? NursingAppDoneDate { get; set; }
        public DateTime? ActionDate { get; set; }
        public int? TotalRisk { get; set; }
        public BodyTypeEnum? BodyType { get; set; }
        public ContinenceEnum? Continence { get; set; }
        public MobilityEnum? Mobility { get; set; }
        public NeurologicalDisordersEnum? NeurologicalDisorders { get; set; }
        public bool? SkinHealthy { get; set; }
        public bool? SkinThin { get; set; }
        public bool? SkinDry { get; set; }
        public bool? SkinDropsy { get; set; }
        public bool? SkinColdAndMoist { get; set; }
        public bool? SkinDiscolored { get; set; }
        public bool? SkinIntegrityBroken { get; set; }
        public bool? MedicineUsage { get; set; }
        public bool? AppetiteAverage { get; set; }
        public bool? AppetiteOnlyLiquid { get; set; }
        public bool? AppetitePoor { get; set; }
        public bool? AppetiteNg { get; set; }
        public bool? AppetiteAnorexia { get; set; }
        public bool? DMTerminalCachexia { get; set; }
        public bool? DMHeartFailure { get; set; }
        public bool? DMPeripheralVascularDisease { get; set; }
        public bool? DMAnemia { get; set; }
        public bool? DMCigaretteUsage { get; set; }
        public bool? SurgeryOrthopedic { get; set; }
        public bool? SurgeryLongerThan2Hours { get; set; }
        public PressureWoundTimeEnum? NursingWoundTime { get; set; }
        public GradeDistributionEnum? GradeDistribution { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}