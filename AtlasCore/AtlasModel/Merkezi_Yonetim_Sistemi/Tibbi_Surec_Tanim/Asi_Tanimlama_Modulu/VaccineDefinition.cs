using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class VaccineDefinition
    {
        public Guid ObjectId { get; set; }
        public PeriodCriterionEnum? PeriodCriterion { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? AutoAdd { get; set; }
        public VaccinationAgeTypeEnum? AutoAddAgeType { get; set; }
        public int? MaxPeriodRange { get; set; }
        public PeriodUnitTypeEnum? MaxPeriodRangeUnit { get; set; }
        public Guid? SKRSAsiKoduRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual SKRSAsiKodu SKRSAsiKodu { get; set; }
        #endregion Parent Relations
    }
}