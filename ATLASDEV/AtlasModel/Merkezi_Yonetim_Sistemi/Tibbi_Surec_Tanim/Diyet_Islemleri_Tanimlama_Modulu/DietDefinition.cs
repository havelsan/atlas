using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DietDefinition
    {
        public Guid ObjectId { get; set; }
        public bool? Breakfast { get; set; }
        public bool? Lunch { get; set; }
        public bool? Dinner { get; set; }
        public bool? Snack2 { get; set; }
        public bool? NightBreakfast { get; set; }
        public bool? Snack1 { get; set; }
        public bool? Snack3 { get; set; }
        public OutPatientInPatientBothEnum? PatientType { get; set; }

        #region Base Object Navigation Property
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}