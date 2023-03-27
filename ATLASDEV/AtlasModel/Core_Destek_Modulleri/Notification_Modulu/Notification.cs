using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Notification
    {
        public Guid ObjectId { get; set; }
        public string ActionData { get; set; }
        public string Content { get; set; }
        public int? ContentType { get; set; }
        public DateTime? CreateTime { get; set; }
        public string HeaderDefinition { get; set; }
        public int? SourceType { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}