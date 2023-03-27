using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OutpatientPresDetail
    {
        public Guid ObjectId { get; set; }
        public Guid? DrugOrderIntroductionRef { get; set; }
        public Guid? OutPatientPrescriptionRef { get; set; }

        #region Parent Relations
        public virtual DrugOrderIntroduction DrugOrderIntroduction { get; set; }
        public virtual OutPatientPrescription OutPatientPrescription { get; set; }
        #endregion Parent Relations
    }
}