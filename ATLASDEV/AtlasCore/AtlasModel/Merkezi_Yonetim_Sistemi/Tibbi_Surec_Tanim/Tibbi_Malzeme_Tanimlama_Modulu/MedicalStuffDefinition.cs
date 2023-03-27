using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalStuffDefinition
    {
        public Guid ObjectId { get; set; }
        public string Code { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Name { get; set; }
        public Guid? MedicalStuffGroupRef { get; set; }
    }
}