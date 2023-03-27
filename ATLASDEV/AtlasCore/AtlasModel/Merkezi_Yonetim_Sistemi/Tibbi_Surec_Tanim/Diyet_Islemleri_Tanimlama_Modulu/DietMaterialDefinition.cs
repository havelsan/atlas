using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DietMaterialDefinition
    {
        public Guid ObjectId { get; set; }
        public string MaterialName { get; set; }
        public string Vitamins { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}