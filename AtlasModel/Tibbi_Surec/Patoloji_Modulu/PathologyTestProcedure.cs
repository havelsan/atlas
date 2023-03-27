using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PathologyTestProcedure
    {
        public Guid ObjectId { get; set; }
        public bool? IsResultSeen { get; set; }
        public string Description { get; set; }
        public Guid? PathologyMaterialRef { get; set; }
        public Guid? PathologyRequestRef { get; set; }
        public Guid? TestCategoryRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual PathologyMaterial PathologyMaterial { get; set; }
        public virtual PathologyRequest PathologyRequest { get; set; }
        #endregion Parent Relations
    }
}