using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PlannedAction
    {
        public Guid ObjectId { get; set; }
        public Guid? DoctorReturnDescription { get; set; }
        public Guid? AbortRequestDescription { get; set; }
        public double? Amount { get; set; }
        public Guid? ProcedureObjectRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ProcedureDefinition ProcedureObject { get; set; }
        #endregion Parent Relations
    }
}