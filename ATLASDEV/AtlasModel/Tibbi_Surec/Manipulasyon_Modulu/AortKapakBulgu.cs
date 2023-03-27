using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AortKapakBulgu
    {
        public Guid ObjectId { get; set; }
        public AortKapakEnum? AortKapakTest { get; set; }
        public string AortKapakTestBulgu { get; set; }
        public Guid? EkokardiografiFormObjectRef { get; set; }

        #region Parent Relations
        public virtual EkokardiografiFormObject EkokardiografiFormObject { get; set; }
        #endregion Parent Relations
    }
}