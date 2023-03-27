using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalInfoDisabledGroup
    {
        public Guid ObjectId { get; set; }
        public bool? Orthopedic { get; set; }
        public bool? Vision { get; set; }
        public bool? Hearing { get; set; }
        public bool? SpeechAndLanguage { get; set; }
        public bool? Mental { get; set; }
        public bool? PsychicAndEmotional { get; set; }
        public bool? Chronic { get; set; }
        public bool? Unclassified { get; set; }
        public bool? Nonexistence { get; set; }
    }
}