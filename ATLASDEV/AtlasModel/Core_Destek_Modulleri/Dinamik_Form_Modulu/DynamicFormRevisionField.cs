using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicFormRevisionField
    {
        public Guid ObjectId { get; set; }
        public Guid? FormFieldIDRef { get; set; }
        public Guid? DynamicFormRevisionIDRef { get; set; }

        #region Parent Relations
        public virtual FormField FormFieldID { get; set; }
        public virtual DynamicFormRevision DynamicFormRevisionID { get; set; }
        #endregion Parent Relations
    }
}