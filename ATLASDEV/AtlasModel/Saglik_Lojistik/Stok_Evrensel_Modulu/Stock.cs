using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Stock
    {
        public Guid ObjectId { get; set; }
        public decimal? TotalOutPrice { get; set; }
        public decimal? MinimumLevel { get; set; }
        public decimal? TotalInPrice { get; set; }
        public decimal? TotalOut { get; set; }
        public decimal? Consigned { get; set; }
        public decimal? Inheld { get; set; }
        public decimal? TotalIn { get; set; }
        public decimal? SafetyLevel { get; set; }
        public bool? Expendable { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? MaximumLevel { get; set; }
        public decimal? CriticalLevel { get; set; }
        public int? Row { get; set; }
        public int? Shelf { get; set; }
        public Guid? StoreRef { get; set; }
        public Guid? MaterialRef { get; set; }

        #region Parent Relations
        public virtual Store Store { get; set; }
        public virtual Material Material { get; set; }
        #endregion Parent Relations
    }
}