using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class TakeOffDatetime
    {
        public Guid ObjectId { get; set; }
        public DateTime? TakeOffDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? IsAllDayOff { get; set; }
        public bool? IsStart { get; set; }
    }
}