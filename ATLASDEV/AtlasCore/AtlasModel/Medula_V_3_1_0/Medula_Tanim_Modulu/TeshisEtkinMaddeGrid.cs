using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class TeshisEtkinMaddeGrid
    {
        public Guid ObjectId { get; set; }
        public Guid? TeshisRef { get; set; }
        public Guid? EtkinMaddeRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual EtkinMadde EtkinMadde { get; set; }
        #endregion Parent Relations
    }
}