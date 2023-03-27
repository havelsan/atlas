using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugSpecifications
    {
        public Guid ObjectId { get; set; }
        public DrugSpecificationEnum? DrugSpecification { get; set; }
        public Guid? DrugDefinitionRef { get; set; }

        #region Parent Relations
        public virtual DrugDefinition DrugDefinition { get; set; }
        #endregion Parent Relations
    }
}