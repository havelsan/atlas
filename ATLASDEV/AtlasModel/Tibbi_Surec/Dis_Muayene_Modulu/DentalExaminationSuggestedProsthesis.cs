using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DentalExaminationSuggestedProsthesis
    {
        public Guid ObjectId { get; set; }
        public Guid? DentalExaminationRef { get; set; }
        public Guid? DentalLaboratoryProcedureRef { get; set; }

        #region Base Object Navigation Property
        public virtual DentalProsthesisRequestSuggestedProsthesis DentalProsthesisRequestSuggestedProsthesis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual DentalExamination DentalExamination { get; set; }
        #endregion Parent Relations
    }
}