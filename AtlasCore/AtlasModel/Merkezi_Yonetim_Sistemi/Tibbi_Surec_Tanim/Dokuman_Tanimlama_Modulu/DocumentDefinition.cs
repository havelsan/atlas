using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DocumentDefinition
    {
        public Guid ObjectId { get; set; }
        public int? OrderNo { get; set; }
        public string Name { get; set; }
        public bool? IsGroup { get; set; }
        public bool? IsMainGroup { get; set; }
        public Guid? File { get; set; }
        public string FileExtension { get; set; }
        public Guid? ParentDocumentDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual DocumentDefinition ParentDocumentDefinition { get; set; }
        #endregion Parent Relations
    }
}