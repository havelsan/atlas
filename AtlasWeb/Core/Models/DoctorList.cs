using System;
using System.Linq;
using System.Collections.Generic;

namespace Core.Models
{
    public class DoctorDto
    {
        public Guid ObjectID { get; set; }
        public long ID { get; set; }
        public string Name { get; set; }
    }


    public class DoctorList
    {
        public IEnumerable<DoctorDto> Doctors { get; set; }
        public int TotalCount { get; set; }

        public DoctorList()
        {

        }

        public DoctorList(IEnumerable<DoctorDto> doctors)
        {
            this.Doctors = doctors;
            this.TotalCount = doctors.Count();
        }
    }

}
