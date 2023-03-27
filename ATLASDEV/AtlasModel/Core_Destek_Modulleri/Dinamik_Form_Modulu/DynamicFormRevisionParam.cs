using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicFormRevisionParam
    {
        public Guid ObjectId { get; set; }
        public Guid? DynamicFormRevisionRef { get; set; }
        public Guid? FormParamRef { get; set; }

        #region Parent Relations
        public virtual DynamicFormRevision DynamicFormRevision { get; set; }
        public virtual FormParam FormParam { get; set; }
        #endregion Parent Relations
    }
}