using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTObjectClasses;

namespace Core.Models
{
    public class UserResourceSelectionModel
    {
        public List<Resource> OutPatientResourceList { get; set; }
        public List<Resource> InPatientResourceList { get; set; }
        public List<Resource> SecMasterResourceList { get; set; }
        public List<ExaminationQueueDefinition> QueueList { get; set; }
        public ResSection SelectedOutPatientResource { get; set; }
        public ResSection SelectedInPatientResource { get; set; }
        public ResSection SelectedSecMasterResource { get; set; }
        public ExaminationQueueDefinition SelectedQueue { get; set; }
    }
}
