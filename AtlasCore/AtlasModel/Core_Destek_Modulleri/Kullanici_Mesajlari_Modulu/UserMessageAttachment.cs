using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class UserMessageAttachment
    {
        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public Guid? Attachment { get; set; }
    }
}