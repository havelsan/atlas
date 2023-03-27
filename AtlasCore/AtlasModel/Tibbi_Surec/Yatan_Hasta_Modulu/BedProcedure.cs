using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BedProcedure
    {
        public Guid ObjectId { get; set; }
        public Guid? BaseBedProcedureRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual BaseBedProcedure BaseBedProcedure { get; set; }
        #endregion Parent Relations
    }
}