using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class WorkListDefinition
    {
        public Guid ObjectId { get; set; }
        public string InterfaceDefName { get; set; }
        public Guid? WorkListIcon { get; set; }
        public int? RightDefID { get; set; }
        public string RoleID { get; set; }
        public string FormName { get; set; }
        public string Caption { get; set; }
        public bool? NoRightCheck { get; set; }
        public string ReportDefName { get; set; }
        public Guid? LastSpecialPanelRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual SpecialPanelDefinition LastSpecialPanel { get; set; }
        #endregion Parent Relations
    }
}