using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MitralKapakBulgu
    {
        public Guid ObjectId { get; set; }
        public MitralKapakEnum? MitralKapakTest { get; set; }
        public string MitralKapakTestBulgu { get; set; }
        public Guid? EkokardiografiFormObjectRef { get; set; }

        #region Parent Relations
        public virtual EkokardiografiFormObject EkokardiografiFormObject { get; set; }
        #endregion Parent Relations
    }
}