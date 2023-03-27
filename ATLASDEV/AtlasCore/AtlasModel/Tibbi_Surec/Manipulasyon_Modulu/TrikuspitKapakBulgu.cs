using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class TrikuspitKapakBulgu
    {
        public Guid ObjectId { get; set; }
        public TrikuspitKapakEnum? TrikuspitKapakTest { get; set; }
        public string TrikuspitKapakTestBulgu { get; set; }
        public Guid? EkokardiografiFormObjectRef { get; set; }

        #region Parent Relations
        public virtual EkokardiografiFormObject EkokardiografiFormObject { get; set; }
        #endregion Parent Relations
    }
}