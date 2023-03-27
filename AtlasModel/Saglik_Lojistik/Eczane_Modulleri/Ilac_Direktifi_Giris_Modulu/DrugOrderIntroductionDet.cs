using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugOrderIntroductionDet
    {
        public Guid ObjectId { get; set; }
        public int? Day { get; set; }
        public double? DoseAmount { get; set; }
        public FrequencyEnum? Frequency { get; set; }
        public string UsageNote { get; set; }
        public bool? PatientOwnDrug { get; set; }
        public DrugOrderTypeEnum? DrugOrderType { get; set; }
        public string DrugDescription { get; set; }
        public DescriptionTypeEnum? DrugDescriptionType { get; set; }
        public DrugUsageTypeEnum? DrugUsageType { get; set; }
        public bool? IsImmediate { get; set; }
        public bool? NextDayOrder { get; set; }
        public PeriodUnitTypeEnum? PeriodUnitType { get; set; }
        public double? PackageAmount { get; set; }
        public bool? CaseOfNeed { get; set; }
        public Guid? DrugOrderRef { get; set; }
        public Guid? MaterialRef { get; set; }
        public Guid? DrugOrderIntroductionRef { get; set; }

        #region Parent Relations
        public virtual DrugOrder DrugOrder { get; set; }
        public virtual Material Material { get; set; }
        public virtual DrugOrderIntroduction DrugOrderIntroduction { get; set; }
        #endregion Parent Relations
    }
}