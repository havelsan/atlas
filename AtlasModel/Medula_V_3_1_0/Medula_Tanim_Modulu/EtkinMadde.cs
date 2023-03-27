using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EtkinMadde
    {
        public Guid ObjectId { get; set; }
        public string etkinMaddeLatinceAdi { get; set; }
        public string adetMiktar { get; set; }
        public string etkinMaddeAdi { get; set; }
        public string etkinMaddeAdi_Shadow { get; set; }
        public string etkinMaddeKodu { get; set; }
        public string form { get; set; }
        public string icerikMiktari { get; set; }
        public bool? hastaGvnlikveIzlemFrmGerek { get; set; }
        public DateTime? baslangicTarihi { get; set; }
        public DateTime? bitisTarihi { get; set; }
        public string SUTList { get; set; }

        #region Base Object Navigation Property
        public virtual BaseMedulaDefinition BaseMedulaDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}