using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PMAddingProcedure
    {
        public Guid ObjectId { get; set; }
        public decimal? PayerPrice { get; set; }
        public decimal? PatientPrice { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Base Object Navigation Property
    }
}