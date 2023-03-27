using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSTELETIPKurumOnEkBilgileri
    {
        public Guid ObjectId { get; set; }
        public int? KURUMKODU { get; set; }
        public string KURUMADI { get; set; }
        public string TELETIPONEK { get; set; }
        public DateTime? GUNCELLENMETARIHI { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}