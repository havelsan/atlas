using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class KScheduleMaterial
    {
        public Guid ObjectId { get; set; }
        public double? StoreInheld { get; set; }
        public string Description { get; set; }
        public double? RequestAmount { get; set; }
        public string PatientName { get; set; }
        public string QuarantinaNO { get; set; }
        public string PatientID { get; set; }
        public bool? IsImmediate { get; set; }
        public double? BarcodeVerifyCounter { get; set; }
        public DateTime? DrugOrderStartDate { get; set; }
        public int? TimesInADay { get; set; }
        public string UsageNote { get; set; }
        public Guid? DrugOrderObjectID { get; set; }
        public Guid? KScheduleCollectedOrderRef { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetailOut StockActionDetailOut { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual KScheduleCollectedOrder KScheduleCollectedOrder { get; set; }
        #endregion Parent Relations
    }
}