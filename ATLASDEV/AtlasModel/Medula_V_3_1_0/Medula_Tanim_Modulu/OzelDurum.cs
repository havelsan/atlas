using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OzelDurum
    {
        public Guid ObjectId { get; set; }
        public string ozelDurumAdi { get; set; }
        public string ozelDurumAdi_Shadow { get; set; }
        public string ozelDurumKodu { get; set; }

        #region Base Object Navigation Property
        public virtual BaseMedulaDefinition BaseMedulaDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}