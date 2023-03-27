using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InpatientPresDetail
    {
        public Guid ObjectId { get; set; }
        public Guid? DrugOrderIntroductionRef { get; set; }
        public Guid? InpatientPrescriptionRef { get; set; }

        #region Parent Relations
        public virtual DrugOrderIntroduction DrugOrderIntroduction { get; set; }
        public virtual InpatientPrescription InpatientPrescription { get; set; }
        #endregion Parent Relations
    }
}