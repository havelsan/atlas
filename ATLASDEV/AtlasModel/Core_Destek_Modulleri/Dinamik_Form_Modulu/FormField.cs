using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class FormField
    {
        public Guid ObjectId { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public Guid? DynamicFormIDRef { get; set; }

        #region Parent Relations
        public virtual DynamicForm DynamicFormID { get; set; }
        #endregion Parent Relations
    }
}