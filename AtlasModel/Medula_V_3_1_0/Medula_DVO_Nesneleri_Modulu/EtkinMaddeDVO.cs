using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EtkinMaddeDVO
    {
        public Guid ObjectId { get; set; }
        public string adetMiktar { get; set; }
        public string etkinMaddeAdi { get; set; }
        public string etkinMaddeKodu { get; set; }
        public string form { get; set; }
        public string icerikMiktari { get; set; }
        public Guid? EtkinMaddeOkuCevapDVORef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseMedulaObject BaseMedulaObject { get; set; }
        #endregion Base Object Navigation Property
    }
}