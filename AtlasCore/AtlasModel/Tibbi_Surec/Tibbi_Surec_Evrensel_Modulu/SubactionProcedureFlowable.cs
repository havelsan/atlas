using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SubactionProcedureFlowable
    {
        public Guid ObjectId { get; set; }
        public Guid? ReasonOfReject { get; set; }
        public Guid? MasterResourceRef { get; set; }
        public Guid? OrderObjectRef { get; set; }
        public Guid? SecondaryMasterResourceRef { get; set; }
        public Guid? FromResourceRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResSection MasterResource { get; set; }
        public virtual PlannedAction OrderObject { get; set; }
        public virtual ResSection SecondaryMasterResource { get; set; }
        public virtual ResSection FromResource { get; set; }
        #endregion Parent Relations
    }
}