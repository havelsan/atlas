using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSICDMSVSIliskisi
    {
        public Guid ObjectId { get; set; }
        public string ICDKODU { get; set; }
        public int? MSVSKODU { get; set; }
        public string MSVSADI { get; set; }
        public string CINSIYETKODU { get; set; }
        public string CINSIYETADI { get; set; }
        public DateTime? GUNCELLENMETARIHI { get; set; }
        public DateTime? OLUSTURULMATARIHI { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}