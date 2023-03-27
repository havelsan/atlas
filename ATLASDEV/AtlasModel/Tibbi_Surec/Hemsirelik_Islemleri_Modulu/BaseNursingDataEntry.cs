using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseNursingDataEntry
    {
        public Guid ObjectId { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public DateTime? EntryDate { get; set; }
        public Guid? ApplicationUserRef { get; set; }
        public Guid? NursingApplicationRef { get; set; }

        #region Parent Relations
        public virtual ResUser ApplicationUser { get; set; }
        public virtual NursingApplication NursingApplication { get; set; }
        #endregion Parent Relations
    }
}