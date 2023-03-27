using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSRadyolojikTetkikIstemPeriyoduListesi
    {
        public Guid ObjectId { get; set; }
        public string ADI { get; set; }
        public string SUTKODU { get; set; }
        public int? ISTEMSURESI { get; set; }
        public string ACIKLAMA { get; set; }
        public DateTime? OLUSTURULMATARIHI { get; set; }
        public DateTime? GUNCELLENMETARIHI { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}