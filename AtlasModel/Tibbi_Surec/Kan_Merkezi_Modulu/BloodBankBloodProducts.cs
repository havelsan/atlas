using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BloodBankBloodProducts
    {
        public Guid ObjectId { get; set; }
        public string ISBTUnitNumber { get; set; }
        public bool? Used { get; set; }
        public string ProductNumber { get; set; }
        public DateTime? ProductDate { get; set; }
        public bool? IsFilter { get; set; }
        public bool? Returned { get; set; }
        public string Notes { get; set; }
        public bool? IsIsinlama { get; set; }
        public string BloodProductExternalID { get; set; }
        public Guid? OzelDurumRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubactionProcedureFlowable SubactionProcedureFlowable { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual OzelDurum OzelDurum { get; set; }
        #endregion Parent Relations
    }
}