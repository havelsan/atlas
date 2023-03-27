using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DialysisReport
    {
        public Guid ObjectId { get; set; }
        public int? NumberOfSessions { get; set; }
        public DiyalizSeansGunEnum? DialysisSessionsDay { get; set; }
        public bool? IsCompanion { get; set; }
        public Guid? TedaviRaporiIslemKodlariRef { get; set; }
    }
}