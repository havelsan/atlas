using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DentalCommitmentProsthesis
    {
        public Guid ObjectId { get; set; }
        public string ToothNo { get; set; }
        public Guid? DentalProsthesisDefinitionRef { get; set; }
        public Guid? DentalCommitmentRef { get; set; }

        #region Parent Relations
        public virtual DentalCommitment DentalCommitment { get; set; }
        #endregion Parent Relations
    }
}