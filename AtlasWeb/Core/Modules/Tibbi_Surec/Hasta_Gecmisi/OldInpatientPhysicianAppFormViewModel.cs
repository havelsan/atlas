//$470D06D1
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class InPatientPhysicianApplicationServiceController
    {
        partial void PreScript_OldInpatientPhysicianAppForm(OldInpatientPhysicianAppFormViewModel viewModel, InPatientPhysicianApplication inPatientPhysicianApplication, TTObjectContext objectContext)
        {
            if (inPatientPhysicianApplication != null)
            {
                viewModel.AdmissionNumber = isNullOrEmpty(inPatientPhysicianApplication.ProtocolNo.ToString());
                if (inPatientPhysicianApplication.InPatientTreatmentClinicApp != null)
                {
                    if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate != null)
                    {
                        viewModel.InpatientDate = inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate;
                    }

                    if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate != null)
                    {
                        viewModel.DischargeDate = inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate;
                    }

                    if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ProcedureDoctor != null)
                    {
                        viewModel.ResponsibleDoctor = isNullOrEmpty(inPatientPhysicianApplication.InPatientTreatmentClinicApp.ProcedureDoctor.Name);
                    }

                    if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission != null)
                    {
                        if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.PhysicalStateClinic != null)
                        {
                            viewModel.Clinic = isNullOrEmpty(inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.PhysicalStateClinic.Name);
                        }

                        viewModel.InpatientReason = isNullOrEmpty(inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.ReasonForInpatientAdmission);
                    }
                }

                foreach (var item in inPatientPhysicianApplication.Diagnosis)
                {
                    viewModel.Diagnosis += item.DiagnosisDefinition + " ";
                }

                if (inPatientPhysicianApplication.Complaint != null)
                {
                    viewModel.Complaint = inPatientPhysicianApplication.Complaint.ToString();
                }

                if (inPatientPhysicianApplication.PhysicalExamination != null)
                {
                    viewModel.PhysicalExamination = inPatientPhysicianApplication.PhysicalExamination.ToString();
                }

                if (inPatientPhysicianApplication.PatientHistory != null)
                {
                    viewModel.PatientHistory = inPatientPhysicianApplication.PatientHistory.ToString();
                }

                StringBuilder drugOrderString = new StringBuilder();
                foreach (var drugOrder in inPatientPhysicianApplication.DrugOrders)
                {
                    drugOrderString.Append(drugOrder.Material.Name);
                    drugOrderString.Append(" ");
                    drugOrderString.Append(drugOrder.Frequency);
                    drugOrderString.Append(" ");
                    drugOrderString.Append(drugOrder.Frequency);
                    drugOrderString.Append(" ");
                    drugOrderString.Append(drugOrder.UsageNote);
                    drugOrderString.Append(", ");
                    drugOrderString.AppendLine();
                }

                viewModel.DrugOrders = drugOrderString.ToString();
                StringBuilder prescriptionString = new StringBuilder();
                foreach (var prescription in inPatientPhysicianApplication.SubEpisode.OutPatientPrescriptions)
                {
                    foreach (var drugOrder in prescription.OutPatientDrugOrders)
                    {
                        prescriptionString.Append(drugOrder.PhysicianDrug.Name);
                        prescriptionString.Append(" ");
                        prescriptionString.Append(drugOrder.Frequency);
                        prescriptionString.Append(" ");
                        prescriptionString.Append(drugOrder.Frequency);
                        prescriptionString.Append(" ");
                        prescriptionString.Append(drugOrder.DrugUsageType.Value);
                        prescriptionString.Append(", ");
                        prescriptionString.AppendLine();
                    }
                }

                viewModel.Prescription = prescriptionString.ToString();
                //viewModel.Vitals=inPatientPhysicianApplication.
                StringBuilder progressesString = new StringBuilder();
                foreach (var item in inPatientPhysicianApplication.SubEpisode.InPatientPhysicianProgresses)
                {
                    inPatientPhysicianProgresses physicianProgresses = new inPatientPhysicianProgresses{Date = item.ProgressDate.Value.ToString("yyyy/MM/dd HH:mm"), Doktor = item.ProcedureDoctor.Name, Note = item.Description.ToString(), Qref = item.ProcedureDoctor.Qref};
                    progressesString.Append("(");
                    progressesString.Append(physicianProgresses.Qref);
                    progressesString.Append(" ");
                    progressesString.Append(physicianProgresses.Doktor);
                    progressesString.Append(") ");
                    progressesString.Append(physicianProgresses.Date);
                    progressesString.Append("  ");
                    progressesString.Append(physicianProgresses.Note);
                    progressesString.Append(@"<hr/>");
                    progressesString.AppendLine();
                }

                viewModel.PhysicianProgresses = progressesString.ToString();
                BindingList<BaseNursingDataEntry> baseNursingDataEntry = BaseNursingDataEntry.GetByInPatientPhysicianApplication(objectContext, inPatientPhysicianApplication.ObjectID);
                var result = baseNursingDataEntry.GroupBy(p => p.ObjectDef);
                viewModel.NursingApplication = new List<NursingApp>();
                foreach (var item in result)
                {
                    StringBuilder nursingString = new StringBuilder();
                    var results = baseNursingDataEntry.Where(c => c.ObjectDef == item.Key);
                    var title = "";
                    foreach (var items in results)
                    {
                        nursingString.Append(items.ApplicationDate.Value.ToString("yyyy/MM/dd HH:mm"));
                        progressesString.Append(" ");
                        nursingString.Append(@"<p>");
                        nursingString.Append(items.GetApplicationSummary());
                        nursingString.Append(@"<p/>");
                        nursingString.Append(@"<hr/>");
                        nursingString.AppendLine();
                        title = items.ObjectDef.ApplicationName;
                    }

                    NursingApp nursingApp = new NursingApp{Title = title, Data = nursingString.ToString()};
                    viewModel.NursingApplication.Add(nursingApp);
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
    public partial class OldInpatientPhysicianAppFormViewModel
    {
        public string AdmissionNumber
        {
            get;
            set;
        } //Kabul Numarası

        public DateTime? InpatientDate
        {
            get;
            set;
        } //Yatış Tarihi

        public DateTime? DischargeDate
        {
            get;
            set;
        } //Taburcu Tarihi

        public string Clinic
        {
            get;
            set;
        } //Yatılan Servis

        public string ResponsibleDoctor
        {
            get;
            set;
        } //Sorumlu Doktor

        public string InpatientReason
        {
            get;
            set;
        } //Yatış Sebebi??????????????

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

        public string DrugOrders
        {
            get;
            set;
        } //İlaç Direktifleri

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

        public string PhysicianProgresses
        {
            get;
            set;
        } //Klinik İzlem Notları

        public List<NursingApp> NursingApplication
        {
            get;
            set;
        } //Hemşirelik değerlendirmeleri
    }

    public class inPatientPhysicianProgresses
    {
        public string Qref
        {
            get;
            set;
        } //Ünvan

        public string Doktor
        {
            get;
            set;
        } //İşlemi Yapan Doktor

        public string Date
        {
            get;
            set;
        } //Tarih

        public string Note
        {
            get;
            set;
        } //İşlem Tanımı
    }

    public class NursingApp
    {
        public string Title
        {
            get;
            set;
        }

        public string Data
        {
            get;
            set;
        }
    }
}