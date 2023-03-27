using System;
using System.Collections.Generic;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using static TTObjectClasses.InPatientTreatmentClinicApplication;

namespace Core.Modules.Tibbi_Surec.Danisma_Modulu.SearchingModel
{
    public class InPatientSearchingModel
    {
        public Patient Patient
        {
            get;
            set;
        }

        public string UniqueRefNo
        {
            get;
            set;
        }

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

        public DateTime? ActionDate
        {
            get;
            set;
        }

        public string InPatientDecisionDoctor
        {
            get;
            set;
        }

        public string InPatientDoctor
        {
            get;
            set;
        }

        public string Clinic
        {
            get;
            set;
        }

        public string PhysicalStateClinic
        {
            get;
            set;
        }

        public string Department
        {
            get;
            set;
        }

        public string ServiceFloor
        {
            get;
            set;
        }

        public string Room
        {
            get;
            set;
        }

        public string RoomPhone
        {
            get;
            set;
        }

        public string Bed
        {
            get;
            set;
        }

        public string BedPhone
        {
            get;
            set;
        }

        public string NurseTablePhone
        {
            get;
            set;
        }

        public string DischargeOrInPatientState
        {
            get;
            set;
        }

        public bool IsIntensiveCare
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public InPatientSearchingModel()
        {
        }

        public InPatientSearchingModel(GetInPatientInfoByPatients_Class inPatientInfo, Patient patient)
        {
            try
            {
                Patient = patient;
                UniqueRefNo = inPatientInfo.Tcno.ToString();
                Name = inPatientInfo.Hastaadi;
                Surname = inPatientInfo.Hastasoyadi;
                MotherName = inPatientInfo.Anneadi;
                FatherName = inPatientInfo.Babaadi;
                ActionDate = inPatientInfo.Klinikyatistarihi;
                InPatientDecisionDoctor = inPatientInfo.Istegiyapandoktoradi;
                InPatientDoctor = inPatientInfo.Sorumludoktoradi;
                Clinic = inPatientInfo.Tedaviklinikadi;
                PhysicalStateClinic = inPatientInfo.Yattigiklinikadi;
                Department = inPatientInfo.Brans.ToString();
                Department = inPatientInfo.Bransadi;
                ServiceFloor = inPatientInfo.Yattigiklinikkati;
                Room = inPatientInfo.Odaadi;
                Bed = inPatientInfo.Yatakadi;
                if (inPatientInfo.Yogunbakim != null)
                    IsIntensiveCare = (bool)inPatientInfo.Yogunbakim;
                else
                    IsIntensiveCare = false;

                if (patient.PatientAddress != null)
                {
                    Address = patient.PatientAddress.HomeAddress;
                    PhoneNumber = patient.PatientAddress.MobilePhone;
                }
            }
            catch (Exception e)
            {
                UniqueRefNo = e.Message;
            }
        }
    }
}