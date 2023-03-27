using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTFormDef
    {
        public string FormDefId { get; set; }
        public Guid ObjectDefId { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string Caption { get; set; }
        public string PreScript { get; set; }
        public string PostScript { get; set; }
        public string BaseFormDefId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public FormTypeEnum FormType { get; set; }
        public string Methods { get; set; }
        public string DifferenceXml { get; set; }
        public Guid? PermissionDefId { get; set; }
        public string ModuleDefId { get; set; }
        public string CheckOutId { get; set; }
        public short CheckOutStatus { get; set; }
        public string FormNo { get; set; }
        public string HelpNamespace { get; set; }
        public string Description { get; set; }
        public string ClientSidePreScript { get; set; }
        public string ClientSidePostScript { get; set; }
        public string DeMethods { get; set; }
    }
}