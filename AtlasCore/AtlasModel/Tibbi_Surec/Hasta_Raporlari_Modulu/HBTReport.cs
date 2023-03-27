using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class HBTReport
    {
        public Guid ObjectId { get; set; }
        public int? NumberOfSessions { get; set; }
        public int? TreatmenDuration { get; set; }
    }
}