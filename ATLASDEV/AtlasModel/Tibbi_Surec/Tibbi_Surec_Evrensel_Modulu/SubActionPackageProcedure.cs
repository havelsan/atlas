using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SubActionPackageProcedure
    {
        public Guid ObjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Aciklama { get; set; }
        public string RaporTakipNo { get; set; }
        public string Birim { get; set; }
        public string Sonuc { get; set; }
        public int? RefakatciGunSayisi { get; set; }
        public MedulaEuroScoreEnum? MedulaEuroScore { get; set; }
        public Guid? BransRef { get; set; }
        public Guid? DoktorRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? AnesteziDoktorRef { get; set; }
        public Guid? AyniFarkliKesiRef { get; set; }
        public Guid? SagSolRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser Doktor { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual ResUser AnesteziDoktor { get; set; }
        #endregion Parent Relations
    }
}