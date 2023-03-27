using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DentalProcedure
    {
        public Guid ObjectId { get; set; }
        public string ExternalID { get; set; }
        public ToothNumberEnum? ToothNumber { get; set; }
        public bool? AccountRecordable { get; set; }
        public decimal? PatientPrice { get; set; }
        public bool? Anomali { get; set; }
        public int? DisTaahhutNo { get; set; }
        public DentalPositionEnum? DentalPosition { get; set; }
        public Guid? AnesteziDoktorRef { get; set; }
        public Guid? AyniFarkliKesiRef { get; set; }
        public Guid? OzelDurumRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubactionProcedureWithDiagnosis SubactionProcedureWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser AnesteziDoktor { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        #endregion Parent Relations
    }
}