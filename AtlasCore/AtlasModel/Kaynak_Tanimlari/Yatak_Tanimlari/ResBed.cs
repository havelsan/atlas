using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResBed
    {
        public Guid ObjectId { get; set; }
        public string BedCodeForMedula { get; set; }
        public bool? IsVentilator { get; set; }
        public int? OrderNo { get; set; }
        public BedProcedureTypeEnum? BedProcedureType { get; set; }
        public Guid? BedProcedureRef { get; set; }
        public Guid? UsedByBedProcedureRef { get; set; }
        public Guid? RoomRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual BaseBedProcedure UsedByBedProcedure { get; set; }
        public virtual ResRoom Room { get; set; }
        #endregion Parent Relations
    }
}