using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class UserBasedGridColumnOption
    {
        public Guid ObjectId { get; set; }
        public string GridName { get; set; }
        public string ColumnList { get; set; }
        public string PageName { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}