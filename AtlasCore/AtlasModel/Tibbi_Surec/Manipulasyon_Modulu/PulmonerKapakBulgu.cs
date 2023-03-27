using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PulmonerKapakBulgu
    {
        public Guid ObjectId { get; set; }
        public PulmonerKapakEnum? PulmonerKapakTest { get; set; }
        public string PulmonerKapakTestBulgu { get; set; }
        public Guid? EkokardiografiFormObjectRef { get; set; }

        #region Parent Relations
        public virtual EkokardiografiFormObject EkokardiografiFormObject { get; set; }
        #endregion Parent Relations
    }
}