using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class FTRReportDetailGrid
    {
        public Guid ObjectId { get; set; }
        public int? NumberOfSessions { get; set; }
        public Guid? FTRReportRef { get; set; }
        public Guid? TedaviRaporiIslemKodlariRef { get; set; }
        public Guid? TedaviTuruRef { get; set; }
        public Guid? FTRVucutBolgesiRef { get; set; }

        #region Parent Relations
        public virtual FTRReport FTRReport { get; set; }
        #endregion Parent Relations
    }
}