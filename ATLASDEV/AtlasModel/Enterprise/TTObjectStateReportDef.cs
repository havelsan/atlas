using System;

namespace AtlasModel.Enterprise
{
    public partial class TTObjectStateReportDef
    {
        public string StateDefId { get; set; }
        public string ReportDefId { get; set; }
        public int DuplicateCount { get; set; }
        public short AskUser { get; set; }
        public short IsDisplay { get; set; }
        public short CheckOutStatus { get; set; }
    }
}