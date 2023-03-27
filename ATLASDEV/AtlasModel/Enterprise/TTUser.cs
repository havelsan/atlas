using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTUser
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Guid? TTObjectId { get; set; }
        public Guid? TTObjectDefId { get; set; }
        public UserStatusEnum Status { get; set; }
        public DateTime? PwdExpireDate { get; set; }
        public DateTime PwdDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastLogonDate { get; set; }
        public string Note { get; set; }
        public DateTime? LoginStartTime { get; set; }
        public DateTime? LoginEndTime { get; set; }
    }
}