using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AppointmentWithoutResource
    {
        public Guid ObjectId { get; set; }
        public DateTime? AppDateTime { get; set; }
        public Guid? ActionRef { get; set; }
        public Guid? SubActionProcedureRef { get; set; }

        #region Parent Relations
        public virtual BaseAction Action { get; set; }
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Parent Relations
    }
}