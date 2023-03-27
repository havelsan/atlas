using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class RadiologyTestTypeDefinition
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public long? Id { get; set; }
        public string Name_Shadow { get; set; }
        public int? EstimatedAppointmentTime { get; set; }
        public int? EstimatedCompletionTime { get; set; }
    }
}