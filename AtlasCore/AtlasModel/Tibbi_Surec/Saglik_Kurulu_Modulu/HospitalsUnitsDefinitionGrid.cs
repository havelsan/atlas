using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class HospitalsUnitsDefinitionGrid
    {
        public Guid ObjectId { get; set; }
        public SexEnum? Sex { get; set; }
        public string TemplateDescription { get; set; }
        public int? MaxOld { get; set; }
        public int? MinOld { get; set; }
        public Guid? TemplateRef { get; set; }
        public Guid? ReasonForExaminationDefRef { get; set; }
        public Guid? PolicklinicRef { get; set; }
        public Guid? ProcedureDoctorRef { get; set; }
        public Guid? EpisodeActionTemplateRef { get; set; }
        public Guid? SpecialityRef { get; set; }

        #region Parent Relations
        public virtual ReasonForExaminationDefinition ReasonForExaminationDef { get; set; }
        public virtual ResPoliclinic Policklinic { get; set; }
        public virtual ResUser ProcedureDoctor { get; set; }
        #endregion Parent Relations
    }
}