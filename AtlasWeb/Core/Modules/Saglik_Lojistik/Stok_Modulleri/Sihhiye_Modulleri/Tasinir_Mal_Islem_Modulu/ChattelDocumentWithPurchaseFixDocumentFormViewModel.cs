//$1F5ECB56
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
    public partial class ChattelDocumentWithPurchaseServiceController
    {
        partial void AfterContextSaveScript_ChattelDocumentWithPurchaseFixDocumentForm(ChattelDocumentWithPurchaseFixDocumentFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (chattelDocumentWithPurchase.InPatientPhysicianApplication != null)
            {
                foreach (ChattelDocumentDetailWithPurchase detail in chattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase)
                {
                    BaseTreatmentMaterial baseTreatmentMaterial = new BaseTreatmentMaterial(objectContext);
                    baseTreatmentMaterial.Material = detail.Material;
                    baseTreatmentMaterial.Amount = detail.Amount;
                    baseTreatmentMaterial.Patient = detail.Patient;
                    baseTreatmentMaterial.Store = chattelDocumentWithPurchase.Store;
                    baseTreatmentMaterial.ActionDate = chattelDocumentWithPurchase.WaybillDate.Value;
                    if (chattelDocumentWithPurchase.InPatientPhysicianApplication.SubEpisode.ClosingDate < Common.RecTime())
                        baseTreatmentMaterial.PricingDate = chattelDocumentWithPurchase.InPatientPhysicianApplication.SubEpisode.ClosingDate;
                    chattelDocumentWithPurchase.InPatientPhysicianApplication.TreatmentMaterials.Add(baseTreatmentMaterial);
                }
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public partial class ChattelDocumentWithPurchaseFixDocumentFormViewModel: BaseViewModel
    {
    }
}
