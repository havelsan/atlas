using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SubactionProcedureSMSInfo
    {
        public Guid ObjectId { get; set; }
        public Guid? ChiefUserID { get; set; }
        public bool? CompletedFlag { get; set; }
        public Guid? DoctorUserID { get; set; }
        public DateTime? ProcedureDate { get; set; }
        public string InternalObjectDefNAme { get; set; }
        public bool? IsActiveFlag { get; set; }
        public Guid? ResponsibleUserID { get; set; }
        public int? SMSNumberForChief { get; set; }
        public int? SMSNumberForDoctor { get; set; }
        public int? SMSNumberForResponsible { get; set; }
        public Guid? SubActionProcedureRef { get; set; }

        #region Parent Relations
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Parent Relations
    }
}