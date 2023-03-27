using System;

namespace AtlasModel.Enterprise
{
    public partial class TTListDef
    {
        public Guid ListDefId { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public Guid ObjectDefId { get; set; }
        public string ValuePropertyName { get; set; }
        public string TreeViewParentPath { get; set; }
        public bool AllowSelectionFromTree { get; set; }
        public bool AllowOnlyLeafSelection { get; set; }
        public bool AutoSearchOnTreeSelect { get; set; }
        public bool AutoFillList { get; set; }
        public string FilterExpression { get; set; }
        public string DefaultFilterExpression { get; set; }
        public string DisplayExpression { get; set; }
        public int FormWidth { get; set; }
        public int FormHeight { get; set; }
        public Guid? FormDefId { get; set; }
        public Guid ModuleDefId { get; set; }
        public Guid? QueryDefId { get; set; }
        public string Methods { get; set; }
        public string CheckOutId { get; set; }
        public short CheckOutStatus { get; set; }
        public string Description { get; set; }
    }
}