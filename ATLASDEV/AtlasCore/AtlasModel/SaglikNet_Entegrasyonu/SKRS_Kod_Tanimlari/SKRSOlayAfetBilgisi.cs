using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSOlayAfetBilgisi
    {
        public Guid ObjectId { get; set; }
        public int? OLAYNO { get; set; }
        public string OLAYISMI { get; set; }
        public int? OLAYILKODU { get; set; }
        public string LOKASYON { get; set; }
        public string TARIHSAAT { get; set; }
        public string OLAYTIPI { get; set; }
        public int? BAGLIOLAYNO { get; set; }
        public string BILGINOTU { get; set; }
        public string ETKILENENILLER { get; set; }
        public DateTime? KAPATILMATARIHI { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}