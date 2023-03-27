//$EDC07D21
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ConsultationServiceController
    {
        partial void PreScript_OldConsultationsForm(OldConsultationsFormViewModel viewModel, Consultation consultation, TTObjectContext objectContext)
        {
            if (consultation != null)
            {
                if (consultation.ProcessEndDate != null)
                {
                    viewModel.ProcessEndDate = consultation.ProcessEndDate;
                }

                if (consultation.RequesterResource != null)
                {
                    viewModel.RequesterResource = isNullOrEmpty(consultation.RequesterResource.Name);
                }

                if (consultation.RequesterDoctor != null)
                {
                    viewModel.RequesterDoctor = isNullOrEmpty(consultation.RequesterDoctor.Name);
                }

                if (consultation.MasterResource != null)
                {
                    viewModel.MasterResource = isNullOrEmpty(consultation.MasterResource.Name);
                }

                if (consultation.ProcedureSpeciality != null)
                {
                    viewModel.ProcedureSpeciality = isNullOrEmpty(consultation.ProcedureSpeciality.Name);
                }

                if (consultation.ProcedureDoctor != null)
                {
                    viewModel.ProcedureDoctor = isNullOrEmpty(consultation.ProcedureDoctor.Name);
                }

                if (consultation.RequestDescription != null)
                {
                    viewModel.RequestDescription = isNullOrEmpty(consultation.RequestDescription.ToString());
                }

                if (consultation.ConsultationResultAndOffers != null)
                {
                    viewModel.ConsultationResultAndOffers = isNullOrEmpty(consultation.ConsultationResultAndOffers.ToString());
                }

                if (consultation.PatientAdmission != null)
                {
                    viewModel.AdmissionNumber = isNullOrEmpty(consultation.PatientAdmission.FirstSubEpisode.ProtocolNo.ToString());
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
    public partial class OldConsultationsFormViewModel
    {
        public DateTime? ProcessEndDate
        {
            get;
            set;
        } //Kons. Bitiş Tarihi

        public string AdmissionNumber
        {
            get;
            set;
        } //Kabul Numarası

        public string RequesterResource
        {
            get;
            set;
        } //İstek Yapan Birim

        public string RequesterDoctor
        {
            get;
            set;
        } //İstek Yapan 

        public string MasterResource
        {
            get;
            set;
        } //Kons. Yapıldığı Birim

        public string ProcedureSpeciality
        {
            get;
            set;
        } //Kons. Yapıldığı Uzmanlık

        public string ProcedureDoctor
        {
            get;
            set;
        } //Kons. Yapan

        public string RequestDescription
        {
            get;
            set;
        } //İstek Açıklaması

        public string ConsultationResultAndOffers
        {
            get;
            set;
        } //Konsultasyon
    }
}