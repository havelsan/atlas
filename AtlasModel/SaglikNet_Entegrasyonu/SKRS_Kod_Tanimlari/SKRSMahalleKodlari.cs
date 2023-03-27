using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSMahalleKodlari
    {
        public Guid ObjectId { get; set; }
        public int? KOYKODU { get; set; }
        public string ADI { get; set; }
        public int? KODU { get; set; }
        public int? TANITIMKODU { get; set; }
        public int? TIPI { get; set; }
        public int? YETKILIIDAREKODU { get; set; }
        public DateTime? OLUSTURULMATARIHI { get; set; }
        public DateTime? GUNCELLENMETARIHI { get; set; }
        public Guid? SKRSKoyKodlariRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}