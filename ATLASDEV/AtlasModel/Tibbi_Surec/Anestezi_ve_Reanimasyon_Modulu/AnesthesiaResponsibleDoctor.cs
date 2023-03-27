using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AnesthesiaResponsibleDoctor
    {
        public Guid ObjectId { get; set; }
        public Guid? ResponsibleDoctorRef { get; set; }
        public Guid? AnesthesiaAndReanimationRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResponsibleDoctor { get; set; }
        public virtual AnesthesiaAndReanimation AnesthesiaAndReanimation { get; set; }
        #endregion Parent Relations
    }
}