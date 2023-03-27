using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SendSMSDetail
    {
        public Guid ObjectId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? SendSMSMasterRef { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? PatientRef { get; set; }

        #region Parent Relations
        public virtual SendSMSMaster SendSMSMaster { get; set; }
        public virtual ResUser ResUser { get; set; }
        public virtual Patient Patient { get; set; }
        #endregion Parent Relations
    }
}