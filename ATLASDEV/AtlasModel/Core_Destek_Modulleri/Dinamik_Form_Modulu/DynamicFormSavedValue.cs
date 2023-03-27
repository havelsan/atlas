using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicFormSavedValue
    {
        public Guid ObjectId { get; set; }
        public string Value { get; set; }
        public Guid? RelatedObjectID { get; set; }
        public Guid? FormFieldIDRef { get; set; }
        public Guid? DynamicFormIDRef { get; set; }
        public Guid? DynamicFormRevisionIDRef { get; set; }
        public Guid? DynamicFormSubmissionRef { get; set; }
        public Guid? DynamicFormRevisionFieldIDRef { get; set; }

        #region Parent Relations
        public virtual FormField FormFieldID { get; set; }
        public virtual DynamicForm DynamicFormID { get; set; }
        public virtual DynamicFormRevision DynamicFormRevisionID { get; set; }
        public virtual DynamicFormSubmission DynamicFormSubmission { get; set; }
        public virtual DynamicFormRevisionField DynamicFormRevisionFieldID { get; set; }
        #endregion Parent Relations
    }
}