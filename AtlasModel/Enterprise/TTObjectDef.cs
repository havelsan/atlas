using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTObjectDef
    {
        public string ObjectDefId { get; set; }
        public bool GenerateDefaultConstructor { get; set; }
        public Guid? PermissionDefId { get; set; }
        public string PreInsert { get; set; }
        public string PostInsert { get; set; }
        public string PreUpdate { get; set; }
        public string PostUpdate { get; set; }
        public string PreDelete { get; set; }
        public string PostDelete { get; set; }
        public string ObjectTableName { get; set; }
        public short IsCentral { get; set; }
        public int CacheDuration { get; set; }
        public TTAuditEnabledEnum AuditEnabled { get; set; }
    }
}