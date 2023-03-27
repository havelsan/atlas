using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalStuff
    {
        public Guid ObjectId { get; set; }
        public string StuffDescription { get; set; }
        public int? StuffAmount { get; set; }
        public string PeriodUnit { get; set; }
        public PeriodUnitTypeEnum? PeriodUnitType { get; set; }
        public int? OdyometryTestId { get; set; }
        public Guid? MedicalStuffPlaceOfUsageRef { get; set; }
        public Guid? MedicalStuffDefRef { get; set; }
        public Guid? MedicalStuffGroupRef { get; set; }
        public Guid? MedicalStuffReportRef { get; set; }
        public Guid? MedicalStuffPrescriptionRef { get; set; }
        public Guid? MedicalStuffUsageTypeRef { get; set; }

        #region Parent Relations
        public virtual MedicalStuffDefinition MedicalStuffDef { get; set; }
        public virtual MedicalStuffReport MedicalStuffReport { get; set; }
        #endregion Parent Relations
    }
}