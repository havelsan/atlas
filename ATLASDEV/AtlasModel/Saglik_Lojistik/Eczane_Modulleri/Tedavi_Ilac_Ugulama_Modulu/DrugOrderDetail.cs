using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugOrderDetail
    {
        public Guid ObjectId { get; set; }
        public double? PackageQuantity { get; set; }
        public DateTime? OrderPlannedDate { get; set; }
        public bool? DrugDone { get; set; }
        public string Stage { get; set; }
        public string Note { get; set; }
        public int? DetailNo { get; set; }
        public string CRCCode { get; set; }
        public Guid? NursingApplicationRef { get; set; }
        public Guid? KScheduleCollectedOrderRef { get; set; }
        public Guid? DrugOrderRef { get; set; }
        public Guid? DrugDeliveryActionDetailRef { get; set; }
        public Guid? DrugReturnActionDetailRef { get; set; }
        public Guid? KScheduleUnListMaterialRef { get; set; }
        public Guid? KSchedulePatienOwnDrugRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseDrugOrder BaseDrugOrder { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual NursingApplication NursingApplication { get; set; }
        public virtual KScheduleCollectedOrder KScheduleCollectedOrder { get; set; }
        public virtual DrugOrder DrugOrder { get; set; }
        public virtual DrugDeliveryActionDetail DrugDeliveryActionDetail { get; set; }
        public virtual DrugReturnActionDetail DrugReturnActionDetail { get; set; }
        public virtual KScheduleUnListMaterial KScheduleUnListMaterial { get; set; }
        public virtual KSchedulePatienOwnDrug KSchedulePatienOwnDrug { get; set; }
        #endregion Parent Relations
    }
}