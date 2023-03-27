//$455FA256
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ChattelDocumentWithPurchaseServiceController : Controller
    {
        public class GetWaybillForInputDocumentTS_Input
        {
            public TTObjectClasses.StockAction stockAction
            {
                get;
                set;
            }
        }

        public class GetWaybillForInputDetailDocument_Output
        {
            public TTObjectClasses.ChattelDocumentWithPurchase chattelDocumentWithPurchase
            {
                get;
                set;
            }

            public List<TTObjectClasses.ChattelDocumentDetailWithPurchase> chattelDocumentDetailWithPurchase
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Tasinir_Mal_Islemi_Satin_Alma_Yoluyla_Tamam)]
        public string SendMuayeneKabulCevapToXXXXXXTS(ChattelDocumentWithPurchase input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = ChattelDocumentWithPurchase.SendMuayeneKabulCevapToXXXXXXTS((ChattelDocumentWithPurchase)input);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Tasinir_Mal_Islemi_Satin_Alma_Yoluyla_Kayit)]
        public GetWaybillForInputDetailDocument_Output GetWaybillForInputDocumentTS(GetWaybillForInputDocumentTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.stockAction != null)
                    input.stockAction = (TTObjectClasses.StockAction)objectContext.AddObject(input.stockAction);
                var ret = ChattelDocumentWithPurchase.GetWaybillForInputDocumentTS((ChattelDocumentWithPurchase)input.stockAction);
                GetWaybillForInputDetailDocument_Output getWaybillForInputDetailDocument_Output = new Controllers.ChattelDocumentWithPurchaseServiceController.GetWaybillForInputDetailDocument_Output();
                getWaybillForInputDetailDocument_Output.chattelDocumentWithPurchase = ret;
                getWaybillForInputDetailDocument_Output.chattelDocumentDetailWithPurchase = new List<ChattelDocumentDetailWithPurchase>();
                foreach (ChattelDocumentDetailWithPurchase purchaseDetail in ret.ChattelDocumentDetailsWithPurchase)
                    getWaybillForInputDetailDocument_Output.chattelDocumentDetailWithPurchase.Add(purchaseDetail);
                objectContext.FullPartialllyLoadedObjects();
                return getWaybillForInputDetailDocument_Output;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Tasinir_Mal_Islemi_Satin_Alma_Yoluyla_Kayit)]
        public GetWaybillForInputDetailDocument_Output GetWaybillForInputDocumentTSFastsoft(GetWaybillForInputDocumentTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.stockAction != null)
                    input.stockAction = (TTObjectClasses.StockAction)objectContext.AddObject(input.stockAction);
                var ret = ChattelDocumentWithPurchase.GetWaybillForInputDocumentTSFastsoft((ChattelDocumentWithPurchase)input.stockAction);
                GetWaybillForInputDetailDocument_Output getWaybillForInputDetailDocument_Output = new Controllers.ChattelDocumentWithPurchaseServiceController.GetWaybillForInputDetailDocument_Output();
                getWaybillForInputDetailDocument_Output.chattelDocumentWithPurchase = ret;
                getWaybillForInputDetailDocument_Output.chattelDocumentDetailWithPurchase = new List<ChattelDocumentDetailWithPurchase>();
                foreach (ChattelDocumentDetailWithPurchase purchaseDetail in ret.ChattelDocumentDetailsWithPurchase)
                    getWaybillForInputDetailDocument_Output.chattelDocumentDetailWithPurchase.Add(purchaseDetail);
                objectContext.FullPartialllyLoadedObjects();
                return getWaybillForInputDetailDocument_Output;
            }
        }


        public class InputForReGeneration
        {
            public string ActionID
            {
                get;
                set;
            }
        }

        public class OutputForReGeneration
        {
            public string OutputMessage
            {
                get;
                set;
            }
            public bool IsTheActionGenerated
            {
                get;
                set;
            }
        }

        public class OutputForRePhysicianApplication
        {
            public string OutputMessage
            {
                get;
                set;
            }

        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public OutputForRePhysicianApplication ReInPatientPhysicianApplicationChattelDocumentWithPurchase(InputForReGeneration input)
        {
            OutputForRePhysicianApplication outputObject = new OutputForRePhysicianApplication();
            try
            {
                TTObjectContext context = new TTObjectContext(false);
                ChattelDocumentWithPurchase currentAction = (ChattelDocumentWithPurchase)context.GetObject(new Guid(input.ActionID), typeof(ChattelDocumentWithPurchase));
                if (currentAction != null && currentAction.CurrentStateDefID == ChattelDocumentWithPurchase.States.Completed)
                {
                    bool outTransaction = false;
                    foreach (ChattelDocumentDetailWithPurchase chattelDocumentDetail in currentAction.ChattelDocumentDetailsWithPurchase)
                    {

                        foreach (StockTransaction stockTransaction in chattelDocumentDetail.StockTransactions.Select(string.Empty))
                        {
                            foreach (StockTransactionDetail stockTransactionDetail in stockTransaction.StockTransactionDetails)
                            {
                                if (stockTransactionDetail.OutStockTransaction.CurrentStateDefID == StockTransaction.States.Completed)
                                {
                                    outTransaction = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (outTransaction)
                        outputObject.OutputMessage = "Girişi yapılmış malzemenin haraketi bulunduğu için buradan işlem devam ettirilemez.";

                    if (String.IsNullOrEmpty(outputObject.OutputMessage) == true)
                    {
                        foreach (ChattelDocumentDetailWithPurchase detail in currentAction.ChattelDocumentDetailsWithPurchase)
                        {
                            BaseTreatmentMaterial baseTreatmentMaterial = new BaseTreatmentMaterial(context);
                            baseTreatmentMaterial.Material = detail.Material;
                            baseTreatmentMaterial.Amount = detail.Amount;
                            baseTreatmentMaterial.ActionDate = currentAction.WaybillDate.Value;
                            baseTreatmentMaterial.Patient = currentAction.InPatientPhysicianApplication.SubEpisode.Episode.Patient;
                            baseTreatmentMaterial.Store = currentAction.Store;
                            if (currentAction.InPatientPhysicianApplication.SubEpisode.ClosingDate < Common.RecTime())
                                baseTreatmentMaterial.PricingDate = currentAction.InPatientPhysicianApplication.SubEpisode.ClosingDate;
                            currentAction.InPatientPhysicianApplication.TreatmentMaterials.Add(baseTreatmentMaterial);
                        }
                        outputObject.OutputMessage = "Hastaya Sarf işlemi başarılı tamamlanmıştır!";
                    }
                }
                context.Save();
                context.Dispose();

                return outputObject;
            }
            catch (Exception ex)
            {
                outputObject.OutputMessage = ex.Message.ToString();
                return outputObject;
            }
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public OutputForReGeneration ReGenerateMyChattelDocumentWithPurchase(InputForReGeneration input)
        {

            OutputForReGeneration outputObject = new OutputForReGeneration();
            try
            {
                BindingList<StockAction.GetClonedStockAction_Class> otherClonedActions = StockAction.GetClonedStockAction(new Guid(input.ActionID));
                if (otherClonedActions.Count > 0)
                {
                    outputObject.IsTheActionGenerated = false;
                    outputObject.OutputMessage = " Bu işlem daha önce " + otherClonedActions[0].StockActionID.ToString() + " işlem numarası olarak kopyanalmış bir daha kopyalamak istiyorsanız bu işlemi iptal etmeniz gerekmektedir.";
                    return outputObject;
                }
                else
                {
                    TTObjectContext context = new TTObjectContext(false);
                    ChattelDocumentWithPurchase currentAction = (ChattelDocumentWithPurchase)context.GetObject(new Guid(input.ActionID), typeof(ChattelDocumentWithPurchase));

                    if (currentAction != null && currentAction.CurrentStateDefID == ChattelDocumentWithPurchase.States.Cancelled)
                    {

                        ChattelDocumentWithPurchase newAction = (ChattelDocumentWithPurchase)currentAction.Clone();
                        newAction.CurrentStateDefID = ChattelDocumentWithPurchase.States.New;
                        newAction.Description = currentAction.Description + " (İptal edilmiş " + currentAction.StockActionID.ToString() + " numaralı işlem üzerinden tekrar oluşturulmuştur!)";
                        newAction.ClonedObjectID = currentAction.ObjectID;

                        TTSequence.allowSetSequenceValue = true;
                        newAction.StockActionID.SetSequenceValue(0);
                        newAction.StockActionID.GetNextValue();

                        foreach (ChattelDocumentDetailWithPurchase item in currentAction.ChattelDocumentDetailsWithPurchase)
                        {
                            ChattelDocumentDetailWithPurchase detail = (ChattelDocumentDetailWithPurchase)item.Clone();
                            detail.StockAction = newAction;
                            detail.Status = StockActionDetailStatusEnum.New;
                        }

                        context.Save();

                        outputObject.IsTheActionGenerated = true;
                        outputObject.OutputMessage = newAction.StockActionID.ToString() + " numaralı işlem başarıyla oluşturulmuştur! İş listesinden kontrol ediniz!";
                    }
                    else
                    {
                        outputObject.IsTheActionGenerated = false;
                        outputObject.OutputMessage = TTUtils.CultureService.GetText("M26181", "İşlem kopyası oluşturma başarısız!");
                    }

                    return outputObject;
                }
            }
            catch (Exception ex)
            {
                outputObject.IsTheActionGenerated = false;
                outputObject.OutputMessage = ex.ToString();
                return outputObject;
            }

        }
    }
}