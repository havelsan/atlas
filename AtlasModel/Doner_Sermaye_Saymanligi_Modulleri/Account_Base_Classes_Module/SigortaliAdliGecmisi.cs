using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SigortaliAdliGecmisi
    {
        public Guid ObjectId { get; set; }
        public string tckNo { get; set; }
        public string provTipi { get; set; }
        public string provTarihi { get; set; }
        public Guid? PatientRef { get; set; }

        #region Parent Relations
        public virtual Patient Patient { get; set; }
        #endregion Parent Relations
    }
}