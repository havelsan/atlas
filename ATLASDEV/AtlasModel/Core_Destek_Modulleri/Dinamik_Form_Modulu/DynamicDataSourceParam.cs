using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicDataSourceParam
    {
        public Guid ObjectId { get; set; }
        public string ParamKey { get; set; }
        public Guid? DynamicDataSourceRef { get; set; }

        #region Parent Relations
        public virtual DynamicDataSource DynamicDataSource { get; set; }
        #endregion Parent Relations
    }
}