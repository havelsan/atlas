using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicFormSavedParam
    {
        public Guid ObjectId { get; set; }
        public string Value { get; set; }
        public Guid? DynamicFormRevisionParamRef { get; set; }
        public Guid? DynamicFormSubmissionRef { get; set; }

        #region Parent Relations
        public virtual DynamicFormRevisionParam DynamicFormRevisionParam { get; set; }
        public virtual DynamicFormSubmission DynamicFormSubmission { get; set; }
        #endregion Parent Relations
    }
}