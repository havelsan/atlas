using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DiyabetKompBilgisi
    {
        public Guid ObjectId { get; set; }
        public Guid? DiyabetVeriSetiRef { get; set; }
        public Guid? SKRSDiyabetKomplikasyonlariRef { get; set; }

        #region Parent Relations
        public virtual DiyabetVeriSeti DiyabetVeriSeti { get; set; }
        #endregion Parent Relations
    }
}