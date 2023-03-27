using System;

namespace Core.Models
{
    public class PatientInfoDto
    {
        public Guid ObjectID { get; set; }
        public long UniqueIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Age { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
    }
}
