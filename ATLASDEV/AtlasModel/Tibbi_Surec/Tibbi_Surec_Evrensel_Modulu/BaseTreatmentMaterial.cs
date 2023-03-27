using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseTreatmentMaterial
    {
        public Guid ObjectId { get; set; }
        public string Note { get; set; }
        public int? Kdv { get; set; }
        public string MalzemeBrans { get; set; }
        public DateTime? MalzemeSatinAlisTarihi { get; set; }
        public double? KodsuzMalzemeFiyati { get; set; }
        public double? UnitPrice { get; set; }
        public string DealerNo { get; set; }
        public Guid? SubactionProcedureFlowableRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? MalzemeTuruRef { get; set; }
        public Guid? EpisodeActionRef { get; set; }
        public Guid? SetMaterialRef { get; set; }
        public Guid? PatientRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionMaterial SubActionMaterial { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual SubactionProcedureFlowable SubactionProcedureFlowable { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual EpisodeAction EpisodeAction { get; set; }
        public virtual Patient Patient { get; set; }
        #endregion Parent Relations
    }
}