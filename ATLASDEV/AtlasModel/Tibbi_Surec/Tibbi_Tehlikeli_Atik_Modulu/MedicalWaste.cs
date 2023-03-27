using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalWaste
    {
        public Guid ObjectId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public double? Amount { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}