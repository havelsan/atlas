using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;
using static TTObjectClasses.InPatientTreatmentClinicApplication;
using Core.Modules.Tibbi_Surec.Danisma_Modulu.SearchingModel;
using System.ComponentModel;
using Core.Models;
using TTInstanceManagement;
using System.Collections;

namespace Core.Models
{
    public class HospitalInformationPatientSearchFormViewModel
    {
        public string ObjectID
        {
            get;
            set;
        }

        public string ObjectDefName
        {
            get;
            set;
        }

        public string UnicRefNo
        {
            get;
            set;
        }

        public string PassportNo
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public string AdmissionNumber
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

        public string BirthCity
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

        public bool isOutPatient
        {
            get;
            set;
        }

        public SKRSCinsiyet Sex
        {
            get;
            set;
        }
        public List<ResourceModel> InpatientResources { get; set; }
        public List<ResourceModel> OutpatientResources{ get; set; }
        public List<ResourceModel> ResourceListOutPatient { get; set; }
        public List<ResourceModel> ResourceListInPatient { get; set; }


    }

    public class ResourceModel
    {
        public string Name { get; set; }
        public Guid? ID { get; set; }
    }


}