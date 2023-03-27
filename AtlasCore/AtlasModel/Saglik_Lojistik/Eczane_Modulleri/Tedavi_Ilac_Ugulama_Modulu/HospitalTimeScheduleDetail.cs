using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class HospitalTimeScheduleDetail
    {
        public Guid ObjectId { get; set; }
        public DateTime? Time { get; set; }
        public int? TimeNumber { get; set; }
        public Guid? HospitalTimeScheduleRef { get; set; }
    }
}