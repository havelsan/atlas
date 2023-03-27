using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PackageProcedureDefinition
    {
        public Guid ObjectId { get; set; }
        public bool? HolidaysIncluded { get; set; }
        public PackageProcedureTypeEnum? Type { get; set; }

        #region Base Object Navigation Property
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}