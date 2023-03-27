using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSTibbiIslemPuanBilgisi
    {
        public Guid ObjectId { get; set; }
        public string ADI { get; set; }
        public int? KODU { get; set; }
        public string ACIKLAMA { get; set; }
        public int? ISLEMPUANI { get; set; }
        public string AMELIYATGRUPLARI { get; set; }
        public DateTime? OLUSTURULMATARIHI { get; set; }
        public DateTime? GUNCELLENMETARIHI { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}