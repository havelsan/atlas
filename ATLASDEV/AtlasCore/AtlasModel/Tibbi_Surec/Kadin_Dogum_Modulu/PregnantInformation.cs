using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PregnantInformation
    {
        public Guid ObjectId { get; set; }
        public int? PregnancyNumber { get; set; }
        public int? LiveBirthsNumber { get; set; }
        public int? StillbirthNumber { get; set; }
        public int? NewbornsNumber { get; set; }
        public int? Parity { get; set; }
        public int? Abortions { get; set; }
        public int? DC { get; set; }
        public int? UIEX { get; set; }
    }
}