using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Modules.Tibbi_Surec.Hasta_Demografik_Bilgileri
{
    public class PatientDemographicsViewModel
    {
        public bool IsPrivacyPatient { get; set; }//Gizli hasta
        public int ShowType
        {
            get;
            set;
        } //Hastanın  1-> Ayaktan Hasta  2-> Yatan Hasta Yatış Modülleri, 3-> Yatan Hasta Diğer Modüller

        public string name
        {
            get;
            set;
        }

        public string surname
        {
            get;
            set;
        }

        public string fatherName
        {
            get;
            set;
        }

        public string age
        {
            get;
            set;
        }

        public string BirthDate
        {
            get;
            set;
        }

        public string importantPatientInfo
        {
            get;
            set;
        }

        public string refNo
        {
            get;
            set;
        }

        public string payerName
        {
            get;
            set;
        }

        public string policlinicName
        {
            get;
            set;
        }

        public string admissionDate
        {
            get;
            set;
        }

        public string formattedRequestDate
        {
            get;
            set;
        }

        public string admissionType
        {
            get;
            set;
        }
        public string provisionNo
        {
            get;
            set;
        }
        public string archiveNo
        {
            get;
            set;
        }


        public string hospitalProtocolNo
        {
            get;
            set;
        }

        public string profilPhotoPath
        {
            get;
            set;
        }

        public string gender
        {
            get;
            set;
        }

        public string admissionDoctor
        {
            get;
            set;
        }

        public string patientGuidID
        {
            get;
            set;
        }

        public string medicalInformationGuidID
        {
            get;
            set;
        }

        public bool hasMedicalInformation
        {
            get;
            set;
        }

        public bool isPregnant
        {
            get;
            set;
        }
        public string pregnancyWeekInfo { get; set; } //Gebelik takvimine göre verilecek uyarı cümlesi

        public bool isHighRiskPregnant = false;

        public bool Pandemic { get; set; }

        public string inpatientClinicDate
        {
            get;
            set;
        }

        public string responsibleNurse
        {
            get;
            set;
        }

        public string InpatientClinicDischargeDate
        {
            get;
            set;
        }

        public string InpatientDay
        {
            get;
            set;
        }

        public string InpatientType
        {
            get;
            set;
        }
        public bool IsInpatientTypeDischarge//Taburcu
        {
            get;
            set;
        }

        public string ClinicProtocolNo
        {
            get;
            set;
        }

        public string RoomGroup
        {
            get;
            set;
        }

        public string Room
        {
            get;
            set;
        }

        public string Bed
        {
            get;
            set;
        }

        public string SubEpisodeProtocolNo
        {
            get;
            set;
        }
        public string PoliclinicProtocolNo
        {
            get;
            set;
        }

        public string ExaminationProcessAndEndDate
        {
            get;
            set;
        }

        public string PatientClassGroup
        {
            get;
            set;
        }
        public string ApplicationReason
        {
            get;
            set;
        }
        public string MedulaSigortaTuru { get; set; }
        public string PatientType { get; set; }//Ayaktan,yatan

        public bool IsPatientAllergic { get; set; }//Hastanın önemli tıbbi bilgilerinde alerji bilgisi var mı?

        public bool HasAirborneContactIsolation { get; set; }
        public bool HasContactIsolation { get; set; }
        public bool HasDropletIsolation { get; set; }
        public bool HasTightContactIsolation { get; set; }
        public bool HasFallingRisk { get; set; }
        public string bloodGroup { get; set; }

        public string ArchiveNo { get; set; }
    }

    public class PatientDetailsViewModel
    {
        public bool IsPrivacyPatient { get; set; }//Gizli hasta
        public string PatientIdentifier
        {
            get;
            set;
        }
        public string PatientName
        {
            get;
            set;
        }
        public string PatientSurname
        {
            get;
            set;
        }
        public string MotherName
        {
            get;
            set;
        }
        public string FatherName
        {
            get;
            set;
        }
        public string RelativeFullName
        {
            get;
            set;
        }
        public string RelativeMobilePhone
        {
            get;
            set;
        }
        public string BirthPlace
        {
            get;
            set;
        }
        public string BirthDate
        {
            get;
            set;
        }
        public string Sex
        {
            get;
            set;
        }
        public string Nationality
        {
            get;
            set;
        }
        public string MobilePhone
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
    }

    public class DynamicComponentInfoDVO
    {
        public string ComponentName
        {
            get;
            set;
        }

        public string ModuleName
        {
            get;
            set;
        }

        public string ModulePath
        {
            get;
            set;
        }

        public string objectID
        {
            get;
            set;
        }

        public Guid episodeObjectID
        {
            get;
            set;
        }

        public Guid patientObjectID
        {
            get;
            set;
        }
    }

    public class AllergyTypesDetails
    {
        public string foodAllergies
        {
            get;
            set;
        }

        public string drugAllergies
        {
            get;
            set;
        }

    }
}