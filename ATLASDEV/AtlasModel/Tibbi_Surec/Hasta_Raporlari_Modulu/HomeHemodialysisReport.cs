using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class HomeHemodialysisReport
    {
        public Guid ObjectId { get; set; }
        public int? NumberOfSessions { get; set; }
        public int? TreatmenDuration { get; set; }
        public DiyalizSeansGunEnum? DialysisSessionsDay { get; set; }
        public Guid? TedaviRaporiIslemKodlariRef { get; set; }
    }
}