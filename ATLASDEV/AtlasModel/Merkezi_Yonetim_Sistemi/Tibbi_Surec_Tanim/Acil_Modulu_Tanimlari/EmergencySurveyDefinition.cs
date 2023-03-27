using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EmergencySurveyDefinition
    {
        public Guid ObjectId { get; set; }
        public EmergencySurveyEnum? ActivityGroup { get; set; }
        public string Name { get; set; }
        public string Name_Shadow { get; set; }
    }
}