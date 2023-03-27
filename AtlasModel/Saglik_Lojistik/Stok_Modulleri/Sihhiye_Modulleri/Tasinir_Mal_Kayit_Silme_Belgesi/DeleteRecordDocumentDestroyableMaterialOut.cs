using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DeleteRecordDocumentDestroyableMaterialOut
    {
        public Guid ObjectId { get; set; }

        #region Base Object Navigation Property
        public virtual BaseDeleteRecordDocumentDetail BaseDeleteRecordDocumentDetail { get; set; }
        #endregion Base Object Navigation Property
    }
}