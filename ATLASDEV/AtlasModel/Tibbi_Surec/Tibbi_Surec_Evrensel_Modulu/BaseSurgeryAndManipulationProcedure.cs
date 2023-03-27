using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseSurgeryAndManipulationProcedure
    {
        public Guid ObjectId { get; set; }
        public double? SutPoint { get; set; }
        public Guid? AnesteziDoktorRef { get; set; }
        public Guid? AyniFarkliKesiRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? ProcedureDoctor2Ref { get; set; }
        public Guid? EuroScoreOfProcedureRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser AnesteziDoktor { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual ResUser ProcedureDoctor2 { get; set; }
        #endregion Parent Relations
    }
}