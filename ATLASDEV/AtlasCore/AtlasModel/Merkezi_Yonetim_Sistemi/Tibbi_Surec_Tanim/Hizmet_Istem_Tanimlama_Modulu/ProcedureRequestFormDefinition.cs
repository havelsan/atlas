using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ProcedureRequestFormDefinition
    {
        public Guid ObjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? OrderNo { get; set; }
        public Guid? ObservationUnitRef { get; set; }

        #region Parent Relations
        public virtual ResObservationUnit ObservationUnit { get; set; }
        #endregion Parent Relations
    }
}