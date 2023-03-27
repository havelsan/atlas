using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalOncology
    {
        public Guid ObjectId { get; set; }
        public Guid? PreTreatmentStaging { get; set; }
        public Guid? InterimEvaluation { get; set; }
        public Guid? FirstLineTreatment { get; set; }
        public Guid? SecondLineTreatment { get; set; }
        public Guid? Story { get; set; }
        public Guid? Pathology { get; set; }
        public Guid? Description { get; set; }
        public string PS { get; set; }
        public string TA { get; set; }
        public string NB { get; set; }
        public string M2 { get; set; }

        #region Base Object Navigation Property
        public virtual SpecialityBasedObject SpecialityBasedObject { get; set; }
        #endregion Base Object Navigation Property
    }
}