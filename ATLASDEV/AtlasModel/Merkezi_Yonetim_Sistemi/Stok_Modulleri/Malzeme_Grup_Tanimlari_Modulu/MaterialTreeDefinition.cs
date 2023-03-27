using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MaterialTreeDefinition
    {
        public Guid ObjectId { get; set; }
        public bool? IsGroup { get; set; }
        public string Name { get; set; }
        public string Name_Shadow { get; set; }
        public string GroupCode { get; set; }
        public Guid? ParentMaterialTreeRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual MaterialTreeDefinition ParentMaterialTree { get; set; }
        #endregion Parent Relations
    }
}