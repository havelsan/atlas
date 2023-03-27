using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSICDOYERLESIMYERI
    {
        public Guid ObjectId { get; set; }
        public int? SKRSKODU { get; set; }
        public string TOPOGRAFIKODU { get; set; }
        public string KODTANIMI { get; set; }
        public string KODACIKLAMA { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSKRSDefinition BaseSKRSDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}