using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingCare
    {
        public Guid ObjectId { get; set; }
        public int? Amount { get; set; }
        public Guid? Note { get; set; }
        public NursingCareResultEnum? NursingResult { get; set; }
        public Guid? NursingProblemRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}