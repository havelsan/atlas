using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DynamicFormRevision
    {
        public Guid ObjectId { get; set; }
        public string Comment { get; set; }
        public int? RevisionNumber { get; set; }
        public bool? IsMain { get; set; }
        public Guid? JsonTemplate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? DynamicFormIdRef { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual DynamicForm DynamicFormId { get; set; }
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}