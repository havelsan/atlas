using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSMalnutrisyonDegerlendirmeBilgisi
    {
        public Guid ObjectId { get; set; }
        public string KODTIPIADI { get; set; }
        public string ADI { get; set; }
        public string KODU { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}