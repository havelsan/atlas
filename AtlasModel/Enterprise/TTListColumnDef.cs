using System;

namespace AtlasModel.Enterprise
{
    public partial class TTListColumnDef
    {
        public Guid ListColumnDefId { get; set; }
        public Guid ListDefId { get; set; }
        public string MemberName { get; set; }
        public string Caption { get; set; }
        public byte ColumnOrder { get; set; }
        public int ColumnWidth { get; set; }
        public short CheckOutStatus { get; set; }
    }
}