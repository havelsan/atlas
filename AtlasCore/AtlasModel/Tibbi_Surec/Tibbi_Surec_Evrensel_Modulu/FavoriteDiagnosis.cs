using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class FavoriteDiagnosis
    {
        public Guid ObjectId { get; set; }
        public int? Order { get; set; }
        public Guid? DiagnoseRef { get; set; }
        public Guid? UserRef { get; set; }

        #region Parent Relations
        public virtual DiagnosisDefinition Diagnose { get; set; }
        public virtual ResUser User { get; set; }
        #endregion Parent Relations
    }
}