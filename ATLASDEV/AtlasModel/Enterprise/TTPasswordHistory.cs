using System;

namespace AtlasModel.Enterprise
{
    public partial class TTPasswordHistory
    {
        public Guid UserId { get; set; }
        public DateTime ChangeDate { get; set; }
        public string Password { get; set; }
    }
}