using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class FavoriteDrug
    {
        public Guid ObjectId { get; set; }
        public int? Count { get; set; }
        public Guid? DrugDefinitionRef { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual DrugDefinition DrugDefinition { get; set; }
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}