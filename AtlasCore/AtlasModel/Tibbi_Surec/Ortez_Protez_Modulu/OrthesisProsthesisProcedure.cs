using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OrthesisProsthesisProcedure
    {
        public Guid ObjectId { get; set; }
        public bool? IsPrintReport { get; set; }
        public bool? IsRequestReport { get; set; }
        public SideEnum? Side { get; set; }
        public string DrAnesteziTescilNo { get; set; }
        public string RaporTakipNo { get; set; }
        public OrthesisPayRatio? PayRatio { get; set; }
        public decimal? Price { get; set; }
        public Guid? AyniFarkliKesiRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? TechnicianRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseOrthesisProsthesisProcedure BaseOrthesisProsthesisProcedure { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual ResUser ResUser { get; set; }
        public virtual ResUser Technician { get; set; }
        #endregion Parent Relations
    }
}