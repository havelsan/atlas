using System;

namespace AtlasModel.Enterprise
{
    public partial class TTRoleMember
    {
        public string RoleId { get; set; }
        public string MemberId { get; set; }
        public short CheckOutStatus { get; set; }
        public short TransferType { get; set; }
    }
}