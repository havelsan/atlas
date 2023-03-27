using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class KronikHastaliklarVeriSeti
    {
        public Guid ObjectId { get; set; }
        public DateTime? IlkTaniTarihi { get; set; }
        public DateTime? PaketeAitIslemZamani { get; set; }
        public Guid? SKRSSpirometriRef { get; set; }

        #region Base Object Navigation Property
        public virtual ENabiz ENabiz { get; set; }
        #endregion Base Object Navigation Property
    }
}