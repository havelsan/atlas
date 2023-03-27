using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EStatusNotRepCommitteeObj
    {
        public Guid ObjectId { get; set; }
        public EDurumBildirirKurulAppStatus? ApplicationCouncilSituation { get; set; }
        public EDurumBildirirKurulAppType? ApplicationType { get; set; }
        public string PatientApplicationID { get; set; }
    }
}