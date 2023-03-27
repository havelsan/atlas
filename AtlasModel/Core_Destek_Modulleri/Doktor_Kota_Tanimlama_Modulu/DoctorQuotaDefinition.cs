using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DoctorQuotaDefinition
    {
        public Guid ObjectId { get; set; }
        public DateTime? WorkDate { get; set; }
        public string Quota { get; set; }
        public bool? Active { get; set; }
        public bool? AutomaticReception { get; set; }
        public Guid? PoliclinicRef { get; set; }
        public Guid? ProcedureDoctorRef { get; set; }

        #region Parent Relations
        public virtual ResPoliclinic Policlinic { get; set; }
        public virtual ResUser ProcedureDoctor { get; set; }
        #endregion Parent Relations
    }
}