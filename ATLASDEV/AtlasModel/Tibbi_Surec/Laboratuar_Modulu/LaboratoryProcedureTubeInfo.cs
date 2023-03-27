using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class LaboratoryProcedureTubeInfo
    {
        public Guid ObjectId { get; set; }
        public DateTime? RequestAcceptionDate { get; set; }
        public string BarcodeType { get; set; }
        public long? SpecimenID { get; set; }
        public long? ContainerID { get; set; }
        public string Description { get; set; }
        public string FromResourceName { get; set; }
    }
}