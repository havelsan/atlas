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
        public Guid? WoundStageRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual WoundStageDef WoundStage { get; set; }
        #endregion Parent Relations
    }
}