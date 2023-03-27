using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ParticipationFreeDrgGrid
    {
        public Guid ObjectId { get; set; }
        public string DrugName { get; set; }
        public PeriodUnitTypeEnum? PeriodUnitType { get; set; }
        public int? Day { get; set; }
        public FrequencyEnum? Frequency { get; set; }
        public double? MedulaDose { get; set; }
        public UsageDoseUnitTypeEnum? UsageDoseUnitType { get; set; }
        public string Dose { get; set; }
        public int? Count { get; set; }
        public string MedulaDoseInteger { get; set; }
        public double? MedulaUsageDose2 { get; set; }
        public Guid? ParticipatnFreeDrugReportRef { get; set; }
        public Guid? EtkinMaddeRef { get; set; }

        #region Parent Relations
        public virtual ParticipatnFreeDrugReport ParticipatnFreeDrugReport { get; set; }
        public virtual EtkinMadde EtkinMadde { get; set; }
        #endregion Parent Relations
    }
}