using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class LinenLocation
    {
        public Guid ObjectId { get; set; }
        public string IntegrationCode { get; set; }
        public string Location { get; set; }
        public string MahalNo { get; set; }
    }
}