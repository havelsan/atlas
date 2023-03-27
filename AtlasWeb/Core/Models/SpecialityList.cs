using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public class SpecialityDto
    {
        public Guid ObjectID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }


    public class SpecialityList
    {
        public IEnumerable<SpecialityDto> Specialities { get; set; }
        public int TotalCount { get; set; }

        public SpecialityList()
        {

        }

        public SpecialityList(IEnumerable<SpecialityDto> specialities)
        {
            this.Specialities = specialities;
            this.TotalCount = specialities.Count();
        }
    }
}
