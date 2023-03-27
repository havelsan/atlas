using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingPupilSymptoms
    {
        public Guid ObjectId { get; set; }
        public PupilPropertiesEnum? LeftPupil { get; set; }
        public PupilWidenessEnum? RightPupilWideness { get; set; }
        public PupilPropertiesEnum? RightPupil { get; set; }
        public DateTime? ActionDate { get; set; }
        public PositiveNegativeEnum? LeftGleamRef { get; set; }
        public PositiveNegativeEnum? RightGleamRef { get; set; }
        public PupilWidenessEnum? LeftPupilWideness { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}