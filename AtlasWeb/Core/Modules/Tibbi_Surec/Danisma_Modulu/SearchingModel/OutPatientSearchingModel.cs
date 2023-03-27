using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

namespace Core.Modules.Tibbi_Surec.Danisma_Modulu.SearchingModel
{
    public class OutPatientSearchingModel
    {
        public string AdmissionID
        {
            get;
            set;
        }

        public string AdmissionObjectID
        {
            get;
            set;
        }

        public string AdmissionObjectDefID
        {
            get;
            set;
        }

        public Patient Patient
        {
            get;
            set;
        }

        public DateTime? ActionDate
        {
            get;
            set;
        }

        public string Doctor
        {
            get;
            set;
        }

        public string Policlinic
        {
            get;
            set;
        }

        public string Department
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
        public OutPatientSearchingModel()
        {
        }

        public OutPatientSearchingModel(PatientAdmission patientAdmission)
        {
            try
            {
                this.Patient = patientAdmission.Episode.Patient;
                if (patientAdmission.ActionDate != null)
                    ActionDate = patientAdmission.ActionDate;
                if (patientAdmission.Department != null)
                    Department = patientAdmission.Department.Name;
                if (patientAdmission.Policlinic != null)
                    Policlinic = patientAdmission.Policlinic.Name;
                if (patientAdmission.ProcedureDoctor != null)
                    Doctor = patientAdmission.ProcedureDoctor.Name;
                if (patientAdmission.PA_Address != null)
                {
                    Address = patientAdmission.PA_Address.HomeAddress;
                    PhoneNumber = patientAdmission.PA_Address.MobilePhone;
                }
            }
            catch
            {
            }
        }
    }
}