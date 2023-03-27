using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseDrugOrder
    {
        public Guid ObjectId { get; set; }
        public FrequencyEnum? Frequency { get; set; }
        public DateTime? PlannedStartTime { get; set; }
        public double? DoseAmount { get; set; }
        public string UsageNote { get; set; }
        public int? Day { get; set; }
        public Guid? SecondaryMasterResourceRef { get; set; }
        public Guid? FromResourceRef { get; set; }
        public Guid? ProcedureDoctorRef { get; set; }
        public Guid? MasterResourceRef { get; set; }
        public Guid? ProcedureSpecialityRef { get; set; }
        public Guid? HospitalTimeScheduleRef { get; set; }

        #region Base Object Navigation Property
        public virtual SubActionMaterial SubActionMaterial { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResSection SecondaryMasterResource { get; set; }
        public virtual ResSection FromResource { get; set; }
        public virtual ResUser ProcedureDoctor { get; set; }
        public virtual ResSection MasterResource { get; set; }
        #endregion Parent Relations
    }
}