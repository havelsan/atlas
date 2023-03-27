using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedulaErrorCodeDefinition
    {
        public Guid ObjectId { get; set; }
        public string Code { get; set; }
        public bool? Controlled { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string UserNote { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}