using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InvoiceInclusionNQL
    {
        public Guid ObjectId { get; set; }
        public string NQL { get; set; }
        public int? OrderNo { get; set; }
        public ProcedureMaterialEnum? ProcedureMaterialType { get; set; }
        public string Name { get; set; }
    }
}