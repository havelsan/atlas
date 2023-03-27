using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SurgeryResponsibleDoctor
    {
        public Guid ObjectId { get; set; }
        public string RankingNumber { get; set; }
        public Guid? ResponsibleDoctorRef { get; set; }
        public Guid? SurgeryProcedureRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResponsibleDoctor { get; set; }
        public virtual SurgeryProcedure SurgeryProcedure { get; set; }
        #endregion Parent Relations
    }
}