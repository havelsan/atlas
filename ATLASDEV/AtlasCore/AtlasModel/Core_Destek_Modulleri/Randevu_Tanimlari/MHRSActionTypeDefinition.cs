using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MHRSActionTypeDefinition
    {
        public Guid ObjectId { get; set; }
        public bool? IsDocumentRequired { get; set; }
        public bool? IsIstisnaType { get; set; }
        public string ActionName { get; set; }
        public string ActionCode { get; set; }
        public bool? OpenMHRS { get; set; }
        public bool? Mustesna { get; set; }
        public int? Day { get; set; }
        public bool? IsWorkingHour { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}