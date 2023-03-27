using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DPRuleMaster
    {
        public Guid ObjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? GILDefinitionRef { get; set; }
    }
}