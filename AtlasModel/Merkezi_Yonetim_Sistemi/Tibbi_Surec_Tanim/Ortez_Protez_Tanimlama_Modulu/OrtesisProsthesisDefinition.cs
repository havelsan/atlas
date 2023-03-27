using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OrtesisProsthesisDefinition
    {
        public Guid ObjectId { get; set; }
        public OrthesisProsthesisHCType? HealthCommitteeType { get; set; }
        public bool? SideSelect { get; set; }
        public string Warranty { get; set; }
        public int? DefaultAmount { get; set; }

        #region Base Object Navigation Property
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}