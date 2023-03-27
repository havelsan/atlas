using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class UserMessage
    {
        public Guid ObjectId { get; set; }
        public Guid? MessageBody { get; set; }
        public DateTime? MessageDate { get; set; }
        public bool? IsSystemMessage { get; set; }
        public MessageStatusEnum? ReceiverStatus { get; set; }
        public string Subject { get; set; }
        public bool? IsPanicMessage { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool? OpenForm { get; set; }
        public bool? IsSplashMessage { get; set; }
        public bool? MessageFeedback { get; set; }
        public Guid? UserMessageID { get; set; }
        public Guid? ReportDefID { get; set; }
        public MessageStatusEnum? SenderStatus { get; set; }
        public Guid? SenderRef { get; set; }
        public Guid? ToUserRef { get; set; }
        public Guid? PatientRef { get; set; }
        public Guid? UserMessageGroupRef { get; set; }
        public Guid? BaseActionRef { get; set; }
        public Guid? SubActionRef { get; set; }

        #region Parent Relations
        public virtual ResUser Sender { get; set; }
        public virtual ResUser ToUser { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual BaseAction BaseAction { get; set; }
        public virtual SubActionProcedure SubAction { get; set; }
        #endregion Parent Relations
    }
}