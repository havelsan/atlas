using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicDataSource
    {
        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public string ApiConfig { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}