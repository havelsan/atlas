using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ServiceLogInfo
    {
        public Guid ObjectId { get; set; }
        public Guid? LOGID { get; set; }
        public string StatusCode { get; set; }
        public string RequestPath { get; set; }
        public DateTime? CallDate { get; set; }
        public string WorkstationIp { get; set; }
        public string Description { get; set; }
        public Guid? UserID { get; set; }
    }
}