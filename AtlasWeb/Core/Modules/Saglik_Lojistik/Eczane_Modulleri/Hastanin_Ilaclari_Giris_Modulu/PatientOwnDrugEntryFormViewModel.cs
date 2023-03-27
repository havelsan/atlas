//$8AD59F6B
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class PatientOwnDrugEntryServiceController
    {
        partial void PostScript_PatientOwnDrugEntryForm(PatientOwnDrugEntryFormViewModel viewModel, PatientOwnDrugEntry patientOwnDrugEntry, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (patientOwnDrugEntry.PatientOwnDrugEntryDetails.Count == 0  && patientOwnDrugEntry.PatientLastUseDrugs.Count == 0)
            {
                throw new TTException(TTUtils.CultureService.GetText("M26063", "İlaç girmeden işleme devam edemessiniz"));
            }
                
            
            foreach (PatientOwnDrugEntryDetail det in patientOwnDrugEntry.PatientOwnDrugEntryDetails)
            {
                if(det.ExpirationDate == null)
                    throw new TTException(TTUtils.CultureService.GetText("M26917", "son kullanma tarihi olmadan işleme devam edemessiniz"));
                if (DateTime.Now > det.ExpirationDate)
                    throw new TTException(TTUtils.CultureService.GetText("M26916", "son kullanma tarihi geçmiş tarihi kontrol ediniz"));
                det.BarcodeAmount = det.Amount;
            }

            foreach(PatientLastUseDrug lastUseDrug in patientOwnDrugEntry.PatientLastUseDrugs)
            {
                if (lastUseDrug.Amount == null)
                    throw new TTException("Son kullanılan ilaçların mevcudu boş olamaz");
            }
        }
    }
}

namespace Core.Models
{
    public partial class PatientOwnDrugEntryFormViewModel
    {
    }
}
