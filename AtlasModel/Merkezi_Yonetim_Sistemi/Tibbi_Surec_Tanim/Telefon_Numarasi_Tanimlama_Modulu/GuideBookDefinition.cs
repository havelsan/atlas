using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class GuideBookDefinition
    {
        public Guid ObjectId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
    }
}