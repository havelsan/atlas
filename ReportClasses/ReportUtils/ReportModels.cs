using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ReportClasses.Controllers.ReportModels
{
    [Serializable]
    public class MedicineDto
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
    [Serializable]
    public class HospitalDto
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    [Serializable]
    public class MedicineReportParameters
    {
        [DataMember]
        public ProductSearchParameters ProductSearchParameters { get; set; }
        [DataMember]
        public HospitalSearchParameters HospitalSearchParameters { get; set; }
    }
    [Serializable]
    public class ProductSearchParameters
    {
        [DataMember]
        public string StartDate { get; set; }
        [DataMember]
        public string EndDate { get; set; }
    }
    [Serializable]
    public class HospitalSearchParameters
    {
        [DataMember]
        public int HospitalID { get; set; }
    }
    [Serializable]
    public class MedicineReportData
    {
        [DataMember]
        public List<MedicineDto> Medicines { get; set; }
        [DataMember]
        public List<HospitalDto> Hospitals { get; set; }

        [DataMember]
        public Patient Patient { get; set; }

        [DataMember]
        public List<Patient> Doctors { get; set; }
    }

    [Serializable]
    public class Patient
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
    }

    
}
