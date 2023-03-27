using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSSUT
    {
        public Guid ObjectId { get; set; }
        public string ADI { get; set; }
        public string KODU { get; set; }
        public string FIYAT { get; set; }
        public int? IDUSTNO { get; set; }
        public string TIP { get; set; }
        public int? PUAN { get; set; }
        public DateTime? OLUSTURULMATARIHI { get; set; }
        public DateTime? GUNCELLENMETARIHI { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}