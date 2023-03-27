using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DentalCommitment
    {
        public Guid ObjectId { get; set; }
        public string CommitmentNo { get; set; }
        public string CommitmentProtocolNo { get; set; }
        public string CommitmentResultCode { get; set; }
        public string CommitmentResultMessage { get; set; }
        public DateTime? SendDate { get; set; }
        public string PostCode { get; set; }
        public string StreetName { get; set; }
        public string OuterDoorNo { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string CommitmentTakenByName { get; set; }
        public string CommitmentTakenBySurname { get; set; }
        public string InnerDoorNo { get; set; }
        public Guid? CityRef { get; set; }
        public Guid? TownRef { get; set; }
    }
}