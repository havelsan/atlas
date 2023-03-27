using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSOkulCagiGenclikIzlemTakvimi
    {
        public Guid ObjectId { get; set; }
        public string ADI { get; set; }
        public int? KODU { get; set; }
        public int? ILKUYGULANMATARIHI { get; set; }
        public int? SONUYGULANMATARIHI { get; set; }
        public int? PERFDAHILMI { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}