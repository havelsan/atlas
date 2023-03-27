using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ProcedureMaterialAdding
    {
        public Guid ObjectId { get; set; }
        public DateTime? PStartDate { get; set; }
        public DateTime? PEndDate { get; set; }
        public Guid? ProcedureDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        #endregion Parent Relations
    }
}