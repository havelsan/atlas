using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingWoundedAssesment
    {
        public Guid ObjectId { get; set; }
        public double? Width { get; set; }
        public WoundTypeEnum? WoundedType { get; set; }
        public DateTime? OperationDate { get; set; }
        public double? Height { get; set; }
        public double? Depth { get; set; }
        public PressureWoundTimeEnum? NursingWoundTime { get; set; }
        public int? Amount { get; set; }
        public Guid? WoundStageRef { get; set; }
        public Guid? WoundLocalizationRef { get; set; }
        public Guid? WoundSideRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual WoundStageDef WoundStage { get; set; }
        public virtual WoundLocalizationDef WoundLocalization { get; set; }
        public virtual WoundSideInfo WoundSide { get; set; }
        #endregion Parent Relations
    }
}