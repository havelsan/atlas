using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ReturnDescriptionsGrid
    {
        public Guid ObjectId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
    }
}