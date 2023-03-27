using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class NotificationUser
    {
        public Guid ObjectId { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? ReadTime { get; set; }
        public Guid? NotificationRef { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual Notification Notification { get; set; }
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}