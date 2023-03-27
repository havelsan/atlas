using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OrthesisProsthesis_ReturnDescriptionsGrid
    {
        public Guid ObjectId { get; set; }
        public Guid? OrthesisProsthesisRequestRef { get; set; }

        #region Base Object Navigation Property
        public virtual ReturnDescriptionsGrid ReturnDescriptionsGrid { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual OrthesisProsthesisRequest OrthesisProsthesisRequest { get; set; }
        #endregion Parent Relations
    }
}