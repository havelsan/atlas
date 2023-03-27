using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugOrderIntroduction
    {
        public Guid ObjectId { get; set; }
        public bool? IsBarcode { get; set; }
        public string ERecetePassword { get; set; }
        public bool? IsRepeated { get; set; }
        public string DrugDescription { get; set; }
        public bool? IsInheldDrug { get; set; }
        public FrequencyEnum? Frequency { get; set; }
        public double? RoutineDay { get; set; }
        public double? RoutineDose { get; set; }
        public double? Dose { get; set; }
        public double? Volume { get; set; }
        public string Unit { get; set; }
        public bool? UseRoutineValue { get; set; }
        public double? OrderDose { get; set; }
        public double? OrderFrequency { get; set; }
        public double? OrderDay { get; set; }
        public string DrugName { get; set; }
        public Guid? DrugObjectID { get; set; }
        public double? MaxDose { get; set; }
        public double? MaxDoseDay { get; set; }
        public bool? PatientOwnDrug { get; set; }
        public bool? AutoSearch { get; set; }
        public bool? CheckFavoriteDrug { get; set; }
        public DateTime? PlannedStartTime { get; set; }
        public bool? IsConsultaitonOrder { get; set; }
        public DescriptionTypeEnum? DrugDescriptionType { get; set; }
        public bool? IsTemplate { get; set; }
        public string TemplateDescription { get; set; }
        public bool? IsImmediate { get; set; }
        public DrugOrderTypeEnum? DrugOrderType { get; set; }
        public PeriodUnitTypeEnum? PeriodUnitType { get; set; }
        public double? PackageAmount { get; set; }
        public bool? CaseOfNeed { get; set; }
        public Guid? ActiveInPatientPhysicianAppRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual InPatientPhysicianApplication ActiveInPatientPhysicianApp { get; set; }
        #endregion Parent Relations
    }
}