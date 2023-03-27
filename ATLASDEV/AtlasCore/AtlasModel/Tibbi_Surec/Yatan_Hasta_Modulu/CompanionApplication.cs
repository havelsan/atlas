using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class CompanionApplication
    {
        public Guid ObjectId { get; set; }
        public string CompanionAddress { get; set; }
        public int? StayingDateCount { get; set; }
        public string CompanionName { get; set; }
        public DateTime? CompanionBirthDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string MedicalReasonForCompanion { get; set; }
        public string PassportNo { get; set; }
        public RelationshipType? Relationship { get; set; }
        public long? UniqueRefNo { get; set; }
        public Guid? InpatientAdmissionRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual InpatientAdmission InpatientAdmission { get; set; }
        #endregion Parent Relations
    }
}