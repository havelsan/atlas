using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTListPropertyDef
    {
        public Guid ListPropertyDefId { get; set; }
        public Guid ListDefId { get; set; }
        public string MemberName { get; set; }
        public string Caption { get; set; }
        public ListPropertyDefAccessEnum AccessType { get; set; }
        public byte CriteriaOrder { get; set; }
        public int ControlWidth { get; set; }
        public Guid? FormFieldDefId { get; set; }
        public short CheckOutStatus { get; set; }
    }
}