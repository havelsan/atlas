using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ScheduleAppointmentType
    {
        public Guid ObjectId { get; set; }
        public AppointmentTypeEnum? AppointmentType { get; set; }
        public Guid? ScheduleRef { get; set; }

        #region Parent Relations
        public virtual Schedule Schedule { get; set; }
        #endregion Parent Relations
    }
}