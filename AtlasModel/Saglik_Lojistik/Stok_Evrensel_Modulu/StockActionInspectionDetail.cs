using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class StockActionInspectionDetail
    {
        public Guid ObjectId { get; set; }
        public string ShortMilitaryClass { get; set; }
        public string ShortRank { get; set; }
        public string EmploymentRecordID { get; set; }
        public string NameString { get; set; }
        public InspectionUserTypeEnum? InspectionUserType { get; set; }
        public Guid? InspectionUserRef { get; set; }
        public Guid? StockActionInspectionRef { get; set; }

        #region Parent Relations
        public virtual ResUser InspectionUser { get; set; }
        public virtual StockActionInspection StockActionInspection { get; set; }
        #endregion Parent Relations
    }
}