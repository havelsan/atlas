using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResponseOfENabizWOSYS
    {
        public Guid ObjectId { get; set; }
        public string PackageCode { get; set; }
        public SendToENabizEnum? Status { get; set; }
        public DateTime? SendDate { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}