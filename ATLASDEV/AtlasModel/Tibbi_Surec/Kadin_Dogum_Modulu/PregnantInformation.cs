using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PregnantInformation
    {
        public Guid ObjectId { get; set; }
        public int? PregnancyNumber { get; set; }
        public int? Parity { get; set; }
        public int? Abortions { get; set; }
        public int? DC { get; set; }
        public int? UIEX { get; set; }
        public int? NumberOfLivingChildren { get; set; }
    }
}