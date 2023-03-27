using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InvoiceBlockingDefinition
    {
        public Guid ObjectId { get; set; }
        public Guid? StateDefId { get; set; }
        public string ObjectName { get; set; }
        public EAorSPEnum? Type { get; set; }
        public string StateName { get; set; }
        public bool? InvoiceBlock { get; set; }
        public bool? CashOfficeBlock { get; set; }
    }
}