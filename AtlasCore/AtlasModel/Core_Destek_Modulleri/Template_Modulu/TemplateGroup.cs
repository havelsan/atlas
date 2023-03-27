using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class TemplateGroup
    {
        public Guid ObjectId { get; set; }
        public string OldGroupName { get; set; }
        public string GroupName { get; set; }
        public string GroupName_Shadow { get; set; }
    }
}