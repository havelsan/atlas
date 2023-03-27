using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseTemplate
    {
        public Guid ObjectId { get; set; }
        public Guid? Content { get; set; }
        public string MenuCaption { get; set; }
        public string Description { get; set; }
        public bool? Enabled { get; set; }
        public Guid? TemplateGroupRef { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual TemplateGroup TemplateGroup { get; set; }
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}