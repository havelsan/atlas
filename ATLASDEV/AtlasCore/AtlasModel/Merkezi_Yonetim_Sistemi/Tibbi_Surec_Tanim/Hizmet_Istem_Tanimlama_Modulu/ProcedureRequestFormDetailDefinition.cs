using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ProcedureRequestFormDetailDefinition
    {
        public Guid ObjectId { get; set; }
        public int? OrderNo { get; set; }
        public Guid? ObservationUnitRef { get; set; }
        public Guid? ProcedureDefinitionRef { get; set; }
        public Guid? ProcedureRequestCategoryRef { get; set; }
        public Guid? PatientAdmissionResSectionRef { get; set; }

        #region Parent Relations
        public virtual ResObservationUnit ObservationUnit { get; set; }
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        public virtual ProcedureRequestCategoryDefinition ProcedureRequestCategory { get; set; }
        public virtual ResSection PatientAdmissionResSection { get; set; }
        #endregion Parent Relations
    }
}