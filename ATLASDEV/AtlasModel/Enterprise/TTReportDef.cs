using System;

namespace AtlasModel.Enterprise
{
    public partial class TTReportDef
    {
        public Guid ReportDefId { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string ReportXml { get; set; }
        public Guid ModuleDefId { get; set; }
        public string Methods { get; set; }
        public string CheckOutId { get; set; }
        public short CheckOutStatus { get; set; }
        public Guid? PermissionDefId { get; set; }
        public string ReportNo { get; set; }
        public object ExcelTemplate { get; set; }
        public string Description { get; set; }
    }
}