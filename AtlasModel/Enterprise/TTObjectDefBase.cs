using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTObjectDefBase
    {
        public string ObjectDefId { get; set; }
        public string Name { get; set; }
        public Guid? BaseObjectDefId { get; set; }
        public bool IsAbstract { get; set; }
        public TTObjectSubTypeEnum SubType { get; set; }
        public string Methods { get; set; }
        public Guid ModuleDefId { get; set; }
        public string CheckOutId { get; set; }
        public CheckOutStatusEnum CheckOutStatus { get; set; }
        public string DisplayText { get; set; }
        public string HelpNamespace { get; set; }
        public string Description { get; set; }
        public string ObjectDefName { get; set; }
    }
}