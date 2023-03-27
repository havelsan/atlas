using System;

namespace AtlasModel.Enterprise
{
    public partial class TTFormFieldDef
    {
        public Guid FieldDefId { get; set; }
        public Guid FormDefId { get; set; }
        public Guid? ParentFieldDefId { get; set; }
        public int OrderNo { get; set; }
        public string Name { get; set; }
        public string ControlClass { get; set; }
        public string DataMember { get; set; }
        public string ControlProperties { get; set; }
        public short CheckOutStatus { get; set; }
    }
}