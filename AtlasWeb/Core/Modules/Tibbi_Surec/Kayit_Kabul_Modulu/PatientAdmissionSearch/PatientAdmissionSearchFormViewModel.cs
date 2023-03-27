using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

namespace Core.Models
{
    public class PatientAdmissionSearchFormViewModel
    {
        public string SearchText
        {
            get;
            set;
        }

        public PatientSearchResultModel PatientSearchResult
        {
            get;
            set;
        }

        public PatientInfoListsModel PatientInfoLists
        {
            get;
            set;
        }

        //public PatientAdmissionInfoDet SelectedAdmission { get; set; }
        public PatientInfoDet SelectedPatient
        {
            get;
            set;
        }

        public PatientAdmissionSearchFormViewModel()
        {
            this.PatientSearchResult = new PatientSearchResultModel();
            this.PatientInfoLists = new PatientInfoListsModel();
            //this.SelectedAdmission = new PatientAdmissionInfoDet();
            this.SelectedPatient = new PatientInfoDet();
        }
    }

    public class PatientInfoListsModel : BasePatientInfoListsModel
    {
        public List<PatientAdmissionInfoDet> PatientAdmissionList
        {
            get;
            set;
        }

        //public Patient PatientInfo { get; set; }
        //public Appointment AppointmentInfo { get; set; }
        public string AdmissionSpecOrResOfCurrentDayEpisodes
        {
            get;
            set;
        }

        public bool hasGizliHastaKabulRoleID
        {
            get;
            set;
        }

        // public PatientAdmission PatientAdmissionInfo { get; set; }
        public PatientInfoListsModel()
        {
            this.PatientList = new List<PatientInfoDet>();
            this.PatientAdmissionList = new List<PatientAdmissionInfoDet>();
            this.hasGizliHastaKabulRoleID = false;
        //this.PatientInfo = new Patient();
        //this.AppointmentInfo = new Appointment();
        //this.PatientAdmissionInfo = new PatientAdmission();
        }
    }

    public class PatientSearchResultModel : BasePatientSearchResultModel
    {
        public PatientAdmission PatientAdmissionInfo
        {
            get;
            set;
        }
    }

    public class PatientAdmissionInfoDet
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string ActionDate
        {
            get;
            set;
        }

        public string Info
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