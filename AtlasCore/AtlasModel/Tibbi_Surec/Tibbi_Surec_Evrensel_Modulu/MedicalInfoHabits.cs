using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalInfoHabits
    {
        public Guid ObjectId { get; set; }
        public bool? Cigarette { get; set; }
        public bool? Alcohol { get; set; }
        public bool? Tea { get; set; }
        public bool? Coffee { get; set; }
        public bool? Other { get; set; }
        public string Description { get; set; }
        public bool? Drug { get; set; }
        public Guid? CigaretteUsageFrequencyRef { get; set; }
        public Guid? AlcoholUsageFrequencyRef { get; set; }
    }
}