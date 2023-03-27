using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalResarchDoctor
    {
        public Guid ObjectId { get; set; }
        public Guid? MedicalResarchRef { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual MedicalResarch MedicalResarch { get; set; }
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}