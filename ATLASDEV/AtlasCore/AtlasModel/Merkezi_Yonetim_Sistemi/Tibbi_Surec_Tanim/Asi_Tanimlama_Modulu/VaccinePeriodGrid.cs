using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class VaccinePeriodGrid
    {
        public Guid ObjectId { get; set; }
        public string PeriodDescription { get; set; }
        public int? Period { get; set; }
        public PeriodUnitTypeEnum? PeriodType { get; set; }
        public int? PeriodNumber { get; set; }
        public Guid? VaccineDefinitionRef { get; set; }

        #region Parent Relations
        public virtual VaccineDefinition VaccineDefinition { get; set; }
        #endregion Parent Relations
    }
}