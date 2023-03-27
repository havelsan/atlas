using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class TaburcuKodu
    {
        public Guid ObjectId { get; set; }
        public string taburcuKodu { get; set; }
        public string taburcuKoduAdi { get; set; }

        #region Base Object Navigation Property
        public virtual BaseMedulaDefinition BaseMedulaDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}