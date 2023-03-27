using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SubActionMaterial
    {
        public Guid ObjectId { get; set; }
        public bool? Eligible { get; set; }
        public double? Amount { get; set; }
        public DateTime? ActionDate { get; set; }
        public DateTime? PricingDate { get; set; }
        public bool? Active { get; set; }
        public long? ID { get; set; }
        public bool? AccTrxsMultipliedByAmount { get; set; }
        public bool? AccountOperationDone { get; set; }
        public bool? PatientPay { get; set; }
        public string DonorID { get; set; }
        public int? UseAmount { get; set; }
        public string UBBCode { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool? IsOldAction { get; set; }
        public string MedulaReportNo { get; set; }
        public Guid? StoreRef { get; set; }
        public Guid? EpisodeRef { get; set; }
        public Guid? MasterPackgSubActionProcedureRef { get; set; }
        public Guid? StockActionDetailRef { get; set; }
        public Guid? MedulaHastaKabulRef { get; set; }
        public Guid? MaterialRef { get; set; }
        public Guid? SubEpisodeRef { get; set; }
        public Guid? RequestedByUserRef { get; set; }

        #region Parent Relations
        public virtual Store Store { get; set; }
        public virtual Episode Episode { get; set; }
        public virtual SubActionProcedure MasterPackgSubActionProcedure { get; set; }
        public virtual StockActionDetail StockActionDetail { get; set; }
        public virtual Material Material { get; set; }
        public virtual SubEpisode SubEpisode { get; set; }
        public virtual ResUser RequestedByUser { get; set; }
        #endregion Parent Relations
    }
}