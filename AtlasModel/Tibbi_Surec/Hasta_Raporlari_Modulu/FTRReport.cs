using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class FTRReport
    {
        public Guid ObjectId { get; set; }
        public MedulaRaporOzelDurumEnum? SpacialCase { get; set; }
        public bool? IsTrafficAccident { get; set; }
    }
}