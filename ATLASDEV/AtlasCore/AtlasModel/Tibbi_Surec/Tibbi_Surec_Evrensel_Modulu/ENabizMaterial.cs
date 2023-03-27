using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ENabizMaterial
    {
        public Guid ObjectId { get; set; }
        public DateTime? RequestDate { get; set; }
        public double? PatientPrice { get; set; }
        public double? PayerPrice { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public Guid? SubActionMaterialRef { get; set; }
        public Guid? AccountTransactionRef { get; set; }

        #region Parent Relations
        public virtual SubActionMaterial SubActionMaterial { get; set; }
        public virtual AccountTransaction AccountTransaction { get; set; }
        #endregion Parent Relations
    }
}