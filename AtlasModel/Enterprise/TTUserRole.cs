using System;

namespace AtlasModel.Enterprise
{
    public partial class TTUserRole
    {
        public Guid? UserId { get; set; }
        public string RoleId { get; set; }
        public short TransferType { get; set; }
        public Guid? TransferId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}