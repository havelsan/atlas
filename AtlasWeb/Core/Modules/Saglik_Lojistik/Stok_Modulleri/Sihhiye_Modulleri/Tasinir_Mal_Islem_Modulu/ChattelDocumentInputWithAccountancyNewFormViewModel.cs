//$BA78D070
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using TTDataDictionary;

namespace Core.Controllers
{
    public partial class ChattelDocumentInputWithAccountancyServiceController
    {
        partial void PostScript_ChattelDocumentInputWithAccountancyNewForm(ChattelDocumentInputWithAccountancyNewFormViewModel viewModel, ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy, TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {

        }

        partial void AfterContextSaveScript_ChattelDocumentInputWithAccountancyNewForm(ChattelDocumentInputWithAccountancyNewFormViewModel viewModel, ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
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
                            DateTime now = Common.RecTime();
                            DateTime actionDate = chattelDocumentInputWithAccountancy.WaybillDate.Value.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
                            baseTreatmentMaterial.ActionDate = actionDate;
                            if (chattelDocumentInputWithAccountancy.InPatientPhysicianApplication.SubEpisode.ClosingDate < now)
                                baseTreatmentMaterial.PricingDate = chattelDocumentInputWithAccountancy.InPatientPhysicianApplication.SubEpisode.ClosingDate;
                            chattelDocumentInputWithAccountancy.InPatientPhysicianApplication.TreatmentMaterials.Add(baseTreatmentMaterial);
                        }
                    }
                    objectContext.Save();


                    if (chattelDocumentInputWithAccountancy.IsPTSAction == true)
                        chattelDocumentInputWithAccountancy.SendITSReceiptNotification();
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
    public partial class ChattelDocumentInputWithAccountancyNewFormViewModel
    {
        public List<ChattelDocumentInputWithAccountancyGridViewModel> chattelDocumentInputWithAccountancyGridViewModel = new List<ChattelDocumentInputWithAccountancyGridViewModel>();
    }

    public class ChattelDocumentInputWithAccountancyGridViewModel
    {
        public Material Material;
        public Guid MaterialObjectID;
        public string MaterialName;
        public string Barcode;
        public string UnitType;
        public int Amount;
        public double NotDiscountedUnitPrice;
        public long KDV;
        public double DiscountRate;
        public double CalculatedUnitPriceOfMaterial;
        public double TotalPriceNotDiscount;
        public double TotalDiscountAmount;
        public double TotalPrice;
        public string LotNo;
        public DateTime ExpirationDate;
        public string StockLevelType;
        public Guid StockLevelTypeObjectID;
        public int RetrievalYear;
        public DateTime ProductionDate;
    }


}