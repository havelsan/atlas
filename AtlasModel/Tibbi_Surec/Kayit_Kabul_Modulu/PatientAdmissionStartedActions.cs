using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientAdmissionStartedActions
    {
        public Guid ObjectId { get; set; }
        public ActionTypeEnum? DefaultActionType { get; set; }
        public AdmissionStatusEnum? AdmissionStatus { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}