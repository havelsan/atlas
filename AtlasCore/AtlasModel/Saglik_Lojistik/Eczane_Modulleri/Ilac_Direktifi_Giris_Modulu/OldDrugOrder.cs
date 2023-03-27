using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OldDrugOrder
    {
        public Guid ObjectId { get; set; }
        public Guid? DrugOrderRef { get; set; }
        public Guid? DrugOrderIntroductionRef { get; set; }

        #region Parent Relations
        public virtual DrugOrder DrugOrder { get; set; }
        public virtual DrugOrderIntroduction DrugOrderIntroduction { get; set; }
        #endregion Parent Relations
    }
}