using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class GuardFormationDefinition
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
    }
}