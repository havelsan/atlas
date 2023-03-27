using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DefinitionConcept
    {
        public Guid ObjectId { get; set; }
        public string Concept_Shadow { get; set; }
        public string Concept { get; set; }
        public Guid? TerminologyManagerDefRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual TerminologyManagerDef TerminologyManagerDefDefinitionConcepts { get; set; }
        #endregion Parent Relations
    }
}