using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class InvoiceTerm
    {
        public Guid ObjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Name { get; set; }
        public int? DocumentNo { get; set; }
        public bool? Approved { get; set; }
        public DateTime? ApproveDate { get; set; }
        public Guid? LastStateUserRef { get; set; }
        public Guid? ApproveUserRef { get; set; }

        #region Parent Relations
        public virtual ResUser LastStateUser { get; set; }
        public virtual ResUser ApproveUser { get; set; }
        #endregion Parent Relations
    }
}