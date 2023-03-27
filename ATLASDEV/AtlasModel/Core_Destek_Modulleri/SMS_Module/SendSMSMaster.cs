using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SendSMSMaster
    {
        public Guid ObjectId { get; set; }
        public string MessageText { get; set; }
        public bool? IsPatientSMS { get; set; }
        public bool? Cancelled { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}