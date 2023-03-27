using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DevredilenKurum
    {
        public Guid ObjectId { get; set; }
        public string devredilenKurumAdi_Shadow { get; set; }
        public string devredilenKurumAdi { get; set; }
        public string devredilenKurumKodu { get; set; }

        #region Base Object Navigation Property
        public virtual BaseMedulaDefinition BaseMedulaDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}