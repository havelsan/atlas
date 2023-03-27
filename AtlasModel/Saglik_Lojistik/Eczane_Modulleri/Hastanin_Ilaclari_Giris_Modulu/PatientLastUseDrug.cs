using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientLastUseDrug
    {
        public Guid ObjectId { get; set; }
        public double? Amount { get; set; }
        public Guid? MaterialRef { get; set; }

        #region Parent Relations
        public virtual Material Material { get; set; }
        #endregion Parent Relations
    }
}