using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ManagerPrescriptionCounts
    {
        public Guid ObjectId { get; set; }
        public int? ePrescriptionCount { get; set; }
        public int? PaperPrescriptionCount { get; set; }
        public string TotalPrescriptionCounts { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PrescriptionCountRate { get; set; }
        public bool? Cancelled { get; set; }
        public int? EmergencyPrescriptionCount { get; set; }
        public int? PoliclinicPrescriptionCount { get; set; }
        public Guid? AddedUserRef { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual ResUser AddedUser { get; set; }
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}