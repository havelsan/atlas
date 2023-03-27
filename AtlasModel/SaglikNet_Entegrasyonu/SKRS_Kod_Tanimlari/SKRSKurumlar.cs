using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSKurumlar
    {
        public Guid ObjectId { get; set; }
        public string ADI { get; set; }
        public int? KODU { get; set; }
        public int? ILKODU { get; set; }
        public int? ILCEKODU { get; set; }
        public string KURUMTIPI { get; set; }
        public int? KURUMTURKODU { get; set; }
        public int? BASAMAKSEVIYESI { get; set; }
        public DateTime? OLUSTURULMATARIHI { get; set; }
        public DateTime? GUNCELLENMETARIHI { get; set; }
        public string TELETIPONEK { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}