using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OutPatientDrugOrder
    {
        public Guid ObjectId { get; set; }
        public string SPTSProvisionDetail { get; set; }
        public bool? SPTSProvisionResult { get; set; }
        public bool? Report { get; set; }
        public double? RequiredAmount { get; set; }
        public double? PackageAmount { get; set; }
        public double? UnitPrice { get; set; }
        public double? Price { get; set; }
        public double? StoreInheld { get; set; }
        public double? ReceivedPrice { get; set; }
        public bool? TenDaily { get; set; }
        public PeriodUnitTypeEnum? PeriodUnitType { get; set; }
        public OutPatientDrugSupplyEnum? DrugSupply { get; set; }
        public double? TreatmentTime { get; set; }
        public Guid? OutPatientPrescriptionRef { get; set; }
        public Guid? PhysicianDrugRef { get; set; }

        #region Base Object Navigation Property
        public virtual DrugOrder DrugOrder { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual OutPatientPrescription OutPatientPrescription { get; set; }
        public virtual DrugDefinition PhysicianDrug { get; set; }
        #endregion Parent Relations
    }
}