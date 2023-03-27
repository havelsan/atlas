using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DentalProsthesisRequestSuggestedProsthesis
    {
        public Guid ObjectId { get; set; }
        public string Definition { get; set; }
        public bool? Emergency { get; set; }
        public DentalPositionEnum? DentalPosition { get; set; }
        public ToothNumberEnum? ToothNumber { get; set; }
        public DisDurumEnum? CurrentState { get; set; }
        public string Color { get; set; }
        public string ExternalLab { get; set; }
        public DateTime? ActionDate { get; set; }
        public string TechnicianNote { get; set; }
        public Guid? DepartmentRef { get; set; }
        public Guid? SuggestedProsthesisProcedureRef { get; set; }
        public Guid? DentalProthesisRequestRef { get; set; }
        public Guid? TechnicianRef { get; set; }

        #region Parent Relations
        public virtual ResSection Department { get; set; }
        #endregion Parent Relations
    }
}