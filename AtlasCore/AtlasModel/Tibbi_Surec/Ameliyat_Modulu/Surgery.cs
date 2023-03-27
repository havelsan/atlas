using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Surgery
    {
        public Guid ObjectId { get; set; }
        public double? SurgeryAnesthesiaPoint { get; set; }
        public DateTime? SurgeryEndTime { get; set; }
        public long? ProtocolNo { get; set; }
        public string ReturnToDoctorReason { get; set; }
        public Guid? DescriptionToPreOp { get; set; }
        public string PreOpDescriptions { get; set; }
        public Guid? SurgeryReport { get; set; }
        public long? SurgeryReportNo { get; set; }
        public DateTime? SurgeryStartTime { get; set; }
        public string NotesToAnesthesia { get; set; }
        public DateTime? PlannedSurgeryDate { get; set; }
        public double? SurgeryTotalPoint { get; set; }
        public DateTime? SurgeryReportDate { get; set; }
        public bool? IsPatientApprovalFormGiven { get; set; }
        public bool? SurgeryTemplate { get; set; }
        public string MedulaAciklamasi { get; set; }
        public bool? IsNeedAnesthesia { get; set; }
        public bool? IsComplicationSurgery { get; set; }
        public string ComplicationDescription { get; set; }
        public string PlannedSurgeryDescription { get; set; }
        public SurgeryShiftEnum? SurgeryShift { get; set; }
        public SurgeryStatusEnum? SurgeryStatus { get; set; }
        public bool? IsDelayedSurgery { get; set; }
        public DateTime? SurgeryStatusDefinitionTime { get; set; }
        public SurgeryPointGroupEnum? SurgeryPointGroup { get; set; }
        public Guid? AnesthesiaAndReanimationRef { get; set; }
        public Guid? SurgeryRoomRef { get; set; }
        public Guid? SurgeryDeskRef { get; set; }
        public Guid? SurgeryExtensionRef { get; set; }
        public Guid? SurgeryRobsonRef { get; set; }
        public Guid? SurgeryResultRef { get; set; }
        public Guid? SurgeryStatusDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual AnesthesiaAndReanimation AnesthesiaAndReanimation { get; set; }
        public virtual ResSurgeryRoom SurgeryRoom { get; set; }
        public virtual ResSurgeryDesk SurgeryDesk { get; set; }
        public virtual SurgeryExtension SurgeryExtension { get; set; }
        public virtual SurgeryRobsonDefinition SurgeryRobson { get; set; }
        #endregion Parent Relations
    }
}