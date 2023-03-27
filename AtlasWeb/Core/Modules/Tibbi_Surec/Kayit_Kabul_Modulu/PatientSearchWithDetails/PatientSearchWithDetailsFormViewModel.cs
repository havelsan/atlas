using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using System.Collections;

namespace Core.Models
{
    public class PatientSearchWithDetailsFormViewModel
    {
        public string Name
        {
            get;
            set;
        }

        public string Surname
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

        public SKRSILKodlari CityOfBirth;
        public string DoctorName
        {
            get;
            set;
        }

        public string policlinicName
        {
            get;
            set;
        }

        public string UniqueRefNo
        {
            get;
            set;
        }

        public string Age
        {
            get;
            set;
        }

        public string AdmissionPoliclinic
        {
            get;
            set;
        }

        public string Payer
        {
            get;
            set;
        }

        public string AdmissionType
        {
            get;
            set;
        }
        public string BirthPlace
        {
            get;
            set;
        }        

        public DateTime BirthDate
        {
            get;
            set;
        }

        public DateTime AdmissionDateFirst
        {
            get;
            set;
        }

        public DateTime AdmissionDateSecond
        {
            get;
            set;
        }

        public DateTime AdmissionTimeFirst
        {
            get;
            set;
        }

        public DateTime AdmissionTimeSecond
        {
            get;
            set;
        }

        public string DispatchNumber
        {
            get;
            set;
        }

        public string DistrictPoliclinicName
        {
            get;
            set;
        }

        public string PatientInServiceName
        {
            get;
            set;
        }

        public string PasaportNo { get; set; }

        public PatientSearchWithDetailsFormViewModel()
        {
        }
      
    }
}