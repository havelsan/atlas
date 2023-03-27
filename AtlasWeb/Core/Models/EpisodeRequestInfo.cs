using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class EpisodeRequestInfo
    {
        public Guid EpisodeID { get; set; }
        public IEnumerable<EpisodeRequestDetailInfo> RequestDetails { get; set; }
    }

    public class EpisodeRequestDetailInfo
    {
        public Guid DetailID { get; set; }
        public DateTime RequestDate { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureName { get; set; }
        public long Quantity { get; set; }
        public Guid RequestDoctor { get; set; }
    }
}
