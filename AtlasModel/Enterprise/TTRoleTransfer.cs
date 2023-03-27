using System;

namespace AtlasModel.Enterprise
{
    public partial class TTRoleTransfer
    {
        public Guid TransferId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public byte Cancelled { get; set; }
    }
}