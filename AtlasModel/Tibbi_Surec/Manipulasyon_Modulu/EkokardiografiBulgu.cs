using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EkokardiografiBulgu
    {
        public Guid ObjectId { get; set; }
        public EkokardiografiEnum? EkokardiografiTest { get; set; }
        public string EkokardiografiTestBulgu { get; set; }
        public Guid? EkokardiografiFormObjectRef { get; set; }

        #region Parent Relations
        public virtual EkokardiografiFormObject EkokardiografiFormObject { get; set; }
        #endregion Parent Relations
    }
}