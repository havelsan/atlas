using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BudgetDef
    {
        public Guid ObjectId { get; set; }
        public string Definition { get; set; }
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public string Code4 { get; set; }
        public BudgetType? BudgetItemType { get; set; }
    }
}