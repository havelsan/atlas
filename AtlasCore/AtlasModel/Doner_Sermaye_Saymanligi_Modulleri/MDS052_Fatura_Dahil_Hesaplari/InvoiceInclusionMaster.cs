using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InvoiceInclusionMaster
    {
        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public DateTime? FirstDate { get; set; }
        public DateTime? LastDate { get; set; }
        public string Description { get; set; }
    }
}