using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PathologyJarTypeDef
    {
        public Guid ObjectId { get; set; }
        public string JarType { get; set; }
        public string Name_Shadow { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}