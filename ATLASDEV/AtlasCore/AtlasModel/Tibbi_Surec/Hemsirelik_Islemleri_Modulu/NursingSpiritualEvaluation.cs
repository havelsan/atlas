using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingSpiritualEvaluation
    {
        public Guid ObjectId { get; set; }
        public bool? Normal { get; set; }
        public bool? Furious { get; set; }
        public bool? Sad { get; set; }
        public bool? Nervous { get; set; }
        public bool? Indifferent { get; set; }
        public bool? Other { get; set; }
        public string Explanation { get; set; }

        #region Base Object Navigation Property
        public virtual BaseNursingDataEntry BaseNursingDataEntry { get; set; }
        #endregion Base Object Navigation Property
    }
}