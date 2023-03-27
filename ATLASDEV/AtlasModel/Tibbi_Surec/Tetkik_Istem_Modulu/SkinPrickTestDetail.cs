using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SkinPrickTestDetail
    {
        public Guid ObjectId { get; set; }
        public bool? Negative { get; set; }
        public bool? Positive { get; set; }
        public string Description { get; set; }
        public Guid? SkinPrickTestResultRef { get; set; }
        public Guid? BaseAdditionalApplicationRef { get; set; }

        #region Parent Relations
        public virtual SkinPrickTestResult SkinPrickTestResult { get; set; }
        public virtual BaseAdditionalApplication BaseAdditionalApplication { get; set; }
        #endregion Parent Relations
    }
}