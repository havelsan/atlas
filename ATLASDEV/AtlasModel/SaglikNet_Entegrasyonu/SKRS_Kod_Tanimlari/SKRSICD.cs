using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSICD
    {
        public Guid ObjectId { get; set; }
        public string ADI { get; set; }
        public string KODU { get; set; }
        public string USTKODU { get; set; }
        public string USTIDNO { get; set; }
        public int? SEVIYE { get; set; }
        public int? ANNEOLUMU { get; set; }
        public int? BILDIRIMIZORUNLU { get; set; }
        public int? OLUMNEDENI { get; set; }
        public DateTime? OLUSTURULMATARIHI { get; set; }
        public string GUNCELLENMETARIHI { get; set; }
        public bool? YUKSEKRISKLIGEBELIK { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}