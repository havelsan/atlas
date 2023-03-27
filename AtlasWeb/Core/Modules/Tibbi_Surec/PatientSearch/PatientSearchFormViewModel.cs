using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

namespace Core.Models
{
    public class PatientSearchFormViewModel
    {
        public string SearchText
        {
            get;
            set;
        }

        public BasePatientSearchResultModel PatientSearchResult
        {
            get;
            set;
        }

        public BasePatientInfoListsModel PatientInfoLists
        {
            get;
            set;
        }

        public PatientInfoDet SelectedPatient
        {
            get;
            set;
        }

        public PatientSearchFormViewModel()
        {
            this.PatientSearchResult = new BasePatientSearchResultModel();
            this.PatientInfoLists = new BasePatientInfoListsModel();
            //this.SelectedAdmission = new PatientAdmissionInfoDet();
            this.SelectedPatient = new PatientInfoDet();
        }
    }

    public class BasePatientInfoListsModel
    {
        public List<PatientInfoDet> PatientList
        {
            get;
            set;
        }

        //public Patient PatientInfo { get; set; }
        //public Appointment AppointmentInfo { get; set; }
        // public PatientAdmission PatientAdmissionInfo { get; set; }
        public BasePatientInfoListsModel()
        {
            this.PatientList = new List<PatientInfoDet>();
        //this.PatientInfo = new Patient();
        //this.AppointmentInfo = new Appointment();
        //this.PatientAdmissionInfo = new PatientAdmission();
        }
    }

    public class BasePatientSearchResultModel
    {
        public Patient PatientInfo
        {
            get;
            set;
        }

        public Appointment AppointmentInfo
        {
            get;
            set;
        }

        public string PatientIDandFullName
        {
            get;
            set;
        }

        public string PatientRefNo
        {
            get;
            set;
        }

        public string PatientPhoneNumber
        {
            get;
            set;
        }
    }

    public class PatientInfoDet
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string NameSurname
        {
            get;
            set;
        }

        public string Info
        {
            get;
            set;
        }

        public string FullInfo
        {
            get;
            set;
        }

        public string FatherName
        {
            get;
            set;
        }

        public string Dob
        {
            get;
            set;
        }

        public string CityOfBirth
        {
            get;
            set;
        }

        public bool? Privacy
        {
            get;
            set;
        }
    }
//public class AppointmentInfo
//{
//    public Guid ObjectID { get; set; }
//}
}