//$699BB451
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ChattelDocumentInputWithAccountancyServiceController
    {
        partial void AfterContextSaveScript_ChattelDocumentInputWithAccountancyApproveForm(ChattelDocumentInputWithAccountancyApproveFormViewModel viewModel, ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            try
            {
                if (viewModel._ChattelDocumentInputWithAccountancy.CurrentStateDefID == ChattelDocumentInputWithAccountancy.States.Completed)
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                    {
                        var sonucMesaji = chattelDocumentInputWithAccountancy.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                        TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                    }

                    if (chattelDocumentInputWithAccountancy.InPatientPhysicianApplication != null)
                    {
                        foreach (ChattelDocumentInputDetailWithAccountancy detail in chattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy)
                        {
                            BaseTreatmentMaterial baseTreatmentMaterial = new BaseTreatmentMaterial(objectContext);
                            baseTreatmentMaterial.Material = detail.Material;
                            baseTreatmentMaterial.Amount = detail.Amount;
                            baseTreatmentMaterial.Patient = detail.Patient;
                            baseTreatmentMaterial.Store = chattelDocumentInputWithAccountancy.Store;
                            chattelDocumentInputWithAccountancy.InPatientPhysicianApplication.TreatmentMaterials.Add(baseTreatmentMaterial);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

namespace Core.Models
{
    public partial class ChattelDocumentInputWithAccountancyApproveFormViewModel
    {
    }
}