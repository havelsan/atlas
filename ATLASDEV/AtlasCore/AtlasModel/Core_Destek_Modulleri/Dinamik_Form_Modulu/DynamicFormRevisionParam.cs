using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicFormRevisionParam
    {
        public Guid ObjectId { get; set; }
        public string ParamKey { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsFilter { get; set; }
        public Guid? DynamicFormRevisionRef { get; set; }

        #region Parent Relations
        public virtual DynamicFormRevision DynamicFormRevision { get; set; }
        #endregion Parent Relations
    }
}