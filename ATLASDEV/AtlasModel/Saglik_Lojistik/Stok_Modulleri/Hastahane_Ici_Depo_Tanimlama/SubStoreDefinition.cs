using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SubStoreDefinition
    {
        public Guid ObjectId { get; set; }
        public int? DependantUnitID { get; set; }
        public int? UnitRegistryNo { get; set; }
        public string UnitCode { get; set; }
        public MKYS_ECikisStokHareketTurEnum? MKYS_CikisHareketTuru { get; set; }
        public Guid? StoreResponsibleRef { get; set; }
        public Guid? SubStoreMKYSRef { get; set; }

        #region Base Object Navigation Property
        public virtual Store Store { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser StoreResponsible { get; set; }
        public virtual MKYS_ServisDepo SubStoreMKYS { get; set; }
        #endregion Parent Relations
    }
}