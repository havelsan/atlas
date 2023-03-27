using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTQueryDef
    {
        public Guid QueryDefId { get; set; }
        public Guid ObjectDefId { get; set; }
        public string Name { get; set; }
        public string Nql { get; set; }
        public QueryDefSubTypeEnum SubType { get; set; }
        public Guid ModuleDefId { get; set; }
        public string CheckOutId { get; set; }
        public short CheckOutStatus { get; set; }
        public string Methods { get; set; }
        public string Description { get; set; }
    }
}