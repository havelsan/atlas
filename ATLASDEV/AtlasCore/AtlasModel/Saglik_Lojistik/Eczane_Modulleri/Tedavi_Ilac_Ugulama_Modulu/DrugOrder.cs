using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugOrder
    {
        public Guid ObjectId { get; set; }
        public string SelectedMaterial { get; set; }
        public string BarcodeLevel { get; set; }
        public string Type { get; set; }
        public bool? PatientOwnDrug { get; set; }
        public string Description { get; set; }
        public DescriptionTypeEnum? DescriptionType { get; set; }
        public DrugUsageTypeEnum? DrugUsageType { get; set; }
        public bool? IsImmediate { get; set; }
        public DrugOrderTypeEnum? DrugOrderType { get; set; }
        public bool? CaseOfNeed { get; set; }
        public Guid? ParentDrugOrder { get; set; }
        public bool? OutOfTreatment { get; set; }
        public string EHUCancelReason { get; set; }
        public bool? IsUpgraded { get; set; }
        public Guid? OldHospitalTimeScheduleID { get; set; }
        public Guid? NursingApplicationRef { get; set; }
        public Guid? InPatientPhysicianApplicationRef { get; set; }
        public Guid? MaterialBarcodeLevelRef { get; set; }
        public Guid? MagistralPreparationActionRef { get; set; }
        public Guid? PhysicianOrderedDrugRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseDrugOrder BaseDrugOrder { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual NursingApplication NursingApplication { get; set; }
        public virtual InPatientPhysicianApplication InPatientPhysicianApplication { get; set; }
        public virtual Material PhysicianOrderedDrug { get; set; }
        #endregion Parent Relations
    }
}