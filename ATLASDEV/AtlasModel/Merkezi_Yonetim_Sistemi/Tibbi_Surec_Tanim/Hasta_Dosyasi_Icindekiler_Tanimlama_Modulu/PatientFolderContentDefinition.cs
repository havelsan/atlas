using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientFolderContentDefinition
    {
        public Guid ObjectId { get; set; }
        public string FileName { get; set; }
        public bool? Active { get; set; }
    }
}