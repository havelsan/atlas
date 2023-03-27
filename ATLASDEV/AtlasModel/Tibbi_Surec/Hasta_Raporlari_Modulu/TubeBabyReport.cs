using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class TubeBabyReport
    {
        public Guid ObjectId { get; set; }
        public TupBebekRaporTuruEnum? TubeBabyReportType { get; set; }
        public Guid? TedaviRaporiIslemKodlariRef { get; set; }
    }
}