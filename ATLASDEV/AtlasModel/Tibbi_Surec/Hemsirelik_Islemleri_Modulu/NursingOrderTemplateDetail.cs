using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NursingOrderTemplateDetail
    {
        public Guid ObjectId { get; set; }
        public int? AmountForPeriod { get; set; }
        public FrequencyEnum? Frequency { get; set; }
        public int? RecurrenceDayAmount { get; set; }
        public Guid? NursingOrderObjectRef { get; set; }
        public Guid? NursingOrderTemplateRef { get; set; }

        #region Parent Relations
        public virtual ProcedureDefinition NursingOrderObject { get; set; }
        #endregion Parent Relations
    }
}