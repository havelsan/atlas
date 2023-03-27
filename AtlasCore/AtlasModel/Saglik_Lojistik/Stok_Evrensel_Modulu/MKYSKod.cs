using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MKYSKod
    {
        public Guid ObjectId { get; set; }
        public string KodAdi { get; set; }
        public string Degeri { get; set; }
        public string Aciklama { get; set; }
        public int? EnumNo { get; set; }
        public bool? Aktif { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}