using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseAdditionalInfo
    {
        public Guid ObjectId { get; set; }
        public string Code { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}