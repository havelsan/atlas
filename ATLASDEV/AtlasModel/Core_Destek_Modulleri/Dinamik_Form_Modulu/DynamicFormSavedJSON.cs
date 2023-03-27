using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicFormSavedJSON
    {
        public Guid ObjectId { get; set; }
        public Guid? Value { get; set; }
        public Guid? DynamicFormIDRef { get; set; }
        public Guid? DynamicFormRevisionIDRef { get; set; }
        public Guid? DynamicFormSubmissionRef { get; set; }

        #region Parent Relations
        public virtual DynamicForm DynamicFormID { get; set; }
        public virtual DynamicFormRevision DynamicFormRevisionID { get; set; }
        public virtual DynamicFormSubmission DynamicFormSubmission { get; set; }
        #endregion Parent Relations
    }
}