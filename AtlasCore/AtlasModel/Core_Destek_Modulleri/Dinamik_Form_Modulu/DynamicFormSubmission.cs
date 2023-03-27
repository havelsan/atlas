using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicFormSubmission
    {
        public Guid ObjectId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsEnable { get; set; }
        public Guid? DynamicFormRevisionRef { get; set; }
        public Guid? CreatedByRef { get; set; }

        #region Parent Relations
        public virtual DynamicFormRevision DynamicFormRevision { get; set; }
        public virtual ResUser CreatedBy { get; set; }
        #endregion Parent Relations
    }
}