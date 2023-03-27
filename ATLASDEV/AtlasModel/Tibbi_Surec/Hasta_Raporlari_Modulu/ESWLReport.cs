using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ESWLReport
    {
        public Guid ObjectId { get; set; }
        public int? NumberOfStone { get; set; }
        public int? NumberOfSessions { get; set; }
        public Guid? TedaviRaporiIslemKodlariRef { get; set; }
    }
}