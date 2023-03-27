using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResWard
    {
        public Guid ObjectId { get; set; }
        public int? PercentageOfEmptyBedFor112 { get; set; }
        public string Floor { get; set; }
        public bool? IsIntensiveCare { get; set; }
        public BedProcedureTypeEnum? BedProcedureType { get; set; }
        public Guid? HospitalRef { get; set; }
        public Guid? Res112ClinicDefRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property
    }
}