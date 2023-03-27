using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResourceSpecialityGrid
    {
        public Guid ObjectId { get; set; }
        public bool? MainSpeciality { get; set; }
        public Guid? ResourceRef { get; set; }
        public Guid? SpecialityRef { get; set; }

        #region Parent Relations
        public virtual Resource Resource { get; set; }
        #endregion Parent Relations
    }
}