using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MenuDefinition
    {
        public Guid ObjectId { get; set; }
        public string ObjectDefinitionName { get; set; }
        public int? OrderNo { get; set; }
        public string EntryState { get; set; }
        public MenuTypeEnum? MenuGroup { get; set; }
        public string Caption_Shadow { get; set; }
        public string Caption { get; set; }
        public string UnboundFormName { get; set; }
        public long? MenuDefinitionNo { get; set; }
        public bool? IsDisabled { get; set; }
        public string IconPath { get; set; }
        public Guid? ParentMenuRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual MenuDefinition ParentMenu { get; set; }
        #endregion Parent Relations
    }
}