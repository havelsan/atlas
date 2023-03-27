using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MKYS_ServisDepo
    {
        public Guid ObjectId { get; set; }
        public int? bagliBirimID { get; set; }
        public string birimAdi { get; set; }
        public int? birimKayitNo { get; set; }
        public string birimKisaAdi { get; set; }
        public string birimKodu { get; set; }
        public string faaliyetDurumu { get; set; }
        public string tur { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}