using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalInfoContiniousDrugs
    {
        public Guid ObjectId { get; set; }
        public Guid? DrugRef { get; set; }
        public Guid? MedicalInformationRef { get; set; }

        #region Parent Relations
        public virtual DrugDefinition Drug { get; set; }
        public virtual MedicalInformation MedicalInformation { get; set; }
        #endregion Parent Relations
    }
}