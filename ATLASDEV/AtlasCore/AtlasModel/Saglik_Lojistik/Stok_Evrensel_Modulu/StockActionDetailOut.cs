using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockActionDetailOut
    {
        public Guid ObjectId { get; set; }
        public bool? IsZeroUnitPrice { get; set; }
        public bool? ReadQRCode { get; set; }
        public long? VatRate { get; set; }
        public string TagNo { get; set; }
        public Guid? StockReservationRef { get; set; }

        #region Base Object Navigation Property
        public virtual StockActionDetail StockActionDetail { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual StockReservation StockReservation { get; set; }
        #endregion Parent Relations
    }
}