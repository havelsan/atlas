using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicForm
    {
        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool? IsEnable { get; set; }
        public string ClassName { get; set; }
        public string CheckClassName { get; set; }
    }
}