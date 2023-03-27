using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MalzemeGetData
    {
        public Guid ObjectId { get; set; }
        public int? malzemeKayitID { get; set; }
        public string malzemeKodu { get; set; }
        public string malzemeAdi { get; set; }
        public DateTime? degisiklikTarihi { get; set; }
        public string olcuBirimiID { get; set; }
        public string malzemeTurID { get; set; }
        public string eskiMalzemeKodu { get; set; }
        public bool? aktif { get; set; }
        public DateTime? gunlemeTarihi { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}