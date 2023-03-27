//$0CC8788C
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Text;

namespace Core.Controllers
{
    public partial class PatientExaminationServiceController
    {
        partial void PreScript_OldExaminationForm(OldExaminationFormViewModel viewModel, PatientExamination patientExamination, TTObjectContext objectContext)
        {
            if (patientExamination != null)
            {
                if (patientExamination.PatientAdmission != null)
                {
                    if (patientExamination.PatientAdmission.ActionDate != null)
                    {
                        viewModel.AdmissionDate = patientExamination.PatientAdmission.ActionDate;
                    }

                    if (patientExamination.PatientAdmission.Policlinic != null)
                    {
                        viewModel.AdmissionClinic = isNullOrEmpty(patientExamination.PatientAdmission.Policlinic.Name);
                    }
                    if (patientExamination.PatientAdmission.FirstSubEpisode != null && patientExamination.PatientAdmission.FirstSubEpisode.ProtocolNo != null)
                    {
                        viewModel.AdmissionNumber = isNullOrEmpty(patientExamination.PatientAdmission.FirstSubEpisode.ProtocolNo.ToString());
                    }
                }

                if (patientExamination.ProcedureDoctor != null)
                {
                    viewModel.ProcedureDoctor = isNullOrEmpty(patientExamination.ProcedureDoctor.Name);
                }

                foreach (var item in patientExamination.Diagnosis)
                {
                    viewModel.Diagnosis += item.DiagnosisDefinition + " ";
                }

                if (patientExamination.Complaint != null)
                {
                    viewModel.Complaint = patientExamination.Complaint.ToString();
                }

                if (patientExamination.PatientStory != null)
                {
                    viewModel.PatientStory = patientExamination.PatientStory.ToString();
                }

                if (patientExamination.PhysicalExamination != null)
                {
                    viewModel.PhysicalExamination = patientExamination.PhysicalExamination.ToString();
                }

                if (patientExamination.PatientHistory != null)
                {
                    viewModel.PatientHistory = patientExamination.PatientHistory.ToString();
                }

                if (patientExamination.PatientFamilyHistory != null)
                {
                    viewModel.PatientFamilyHistory = patientExamination.PatientFamilyHistory.ToString();
                }

                StringBuilder _prescription = new StringBuilder();
                foreach (var prescription in patientExamination.SubEpisode.OutPatientPrescriptions)
                {
                    foreach (var drugOrder in prescription.OutPatientDrugOrders)
                    {
                        _prescription.Append("<p>");
                        _prescription.Append(drugOrder.Material.Name);
                        _prescription.Append(" ");
                        _prescription.Append(drugOrder.Frequency);
                        _prescription.Append(" ");
                        _prescription.Append(drugOrder.DoseAmount);
                        _prescription.Append(" ");
                        _prescription.Append(drugOrder.DrugUsageType.Value);
                        _prescription.Append("</p>");
                    }
                }

                viewModel.Prescription = _prescription.ToString();

                if (patientExamination.TreatmentResult != null)
                {
                    viewModel.TreatmentResult = isNullOrEmpty(patientExamination.TreatmentResult.ADI);
                }

                if (patientExamination.ProcessDate != null)
                {
                    viewModel.ProcessStartDate = patientExamination.ProcessDate;
                }

                if (patientExamination.ProcessEndDate != null)
                {
                    viewModel.ProcessEndDate = patientExamination.ProcessEndDate;
                }
            }
        }

        private string isNullOrEmpty(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "";
            }
            else
            {
                return input;
            }
        }
    }
}

namespace Core.Models
{
    public partial class OldExaminationFormViewModel
    {
        public DateTime? AdmissionDate
        {
            get;
            set;
        } //Kabul Tarihi

        public string AdmissionClinic
        {
            get;
            set;
        } //Kabul Alınan Birim

        public string ProcedureDoctor
        {
            get;
            set;
        } //Kabul Alınan Doktor

        public string AdmissionNumber
        {
            get;
            set;
        } //Kabul Numarası

        public string Diagnosis
        {
            get;
            set;
        } //Tanı

        public string Complaint
        {
            get;
            set;
        } //Anamnez

        public string PatientStory
        {
            get;
            set;
        }

        public string PhysicalExamination
        {
            get;
            set;
        }

        public string PatientHistory
        {
            get;
            set;
        }

        public string PatientFamilyHistory
        {
            get;
            set;
        }

        public string Prescription
        {
            get;
            set;
        } //Reçete

        public string Vitals
        {
            get;
            set;
        } //Hayati Bulgular

        public string TreatmentResult
        {
            get;
            set;
        } //Tedavi Sonucu

        public DateTime? ProcessStartDate
        {
            get;
            set;
        } //Muayene Başlangıç Tarihi

        public DateTime? ProcessEndDate
        {
            get;
            set;
        } //Muayene Bitiş Tarihi
    }
}