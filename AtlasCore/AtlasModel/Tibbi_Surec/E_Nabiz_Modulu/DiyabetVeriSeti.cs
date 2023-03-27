using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DiyabetVeriSeti
    {
        public Guid ObjectId { get; set; }
        public DateTime? IlkTaniTarihi { get; set; }
        public int? Boy { get; set; }
        public double? Kilo { get; set; }
        public Guid? SKRSDiyabetEgitimiRef { get; set; }

        #region Base Object Navigation Property
        public virtual ENabiz ENabiz { get; set; }
        #endregion Base Object Navigation Property
    }
}