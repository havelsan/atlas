using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses.DTOs
{
    public class MaterialPropertyRequestDTO
    {
        public List<Guid> MaterialIds { get; set; }
        public DateTime? Date { get; set; }
        public Guid? Store { get; set; }
        public Guid? DestinationStore { get; set; }
    }
}
