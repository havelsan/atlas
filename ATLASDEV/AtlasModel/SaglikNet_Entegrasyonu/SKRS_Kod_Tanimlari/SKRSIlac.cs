using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSIlac
    {
        public Guid ObjectId { get; set; }
        public string ADI { get; set; }
        public string BARKODU { get; set; }
        public int? FIYAT { get; set; }
        public int? GERIODEME { get; set; }
        public int? RECETETURU { get; set; }
        public string FIRMAADI { get; set; }
        public DateTime? OLUSTURULMATARIHI { get; set; }
        public DateTime? GUNCELLENMETARIHI { get; set; }
        public string ATCKODU { get; set; }
        public string ATCADI { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}