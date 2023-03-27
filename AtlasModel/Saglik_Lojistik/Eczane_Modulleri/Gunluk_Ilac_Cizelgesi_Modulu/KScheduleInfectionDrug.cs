using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class KScheduleInfectionDrug
    {
        public Guid ObjectId { get; set; }
        public double? BarcodeVerifyCounter { get; set; }
        public double? DrugAmount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsApproved { get; set; }
        public StockActionDetailStatusEnum? StockActionStatus { get; set; }
        public Guid? DrugOrderObjectID { get; set; }
        public Guid? MaterialRef { get; set; }
        public Guid? KScheduleRef { get; set; }

        #region Parent Relations
        public virtual Material Material { get; set; }
        public virtual KSchedule KSchedule { get; set; }
        #endregion Parent Relations
    }
}