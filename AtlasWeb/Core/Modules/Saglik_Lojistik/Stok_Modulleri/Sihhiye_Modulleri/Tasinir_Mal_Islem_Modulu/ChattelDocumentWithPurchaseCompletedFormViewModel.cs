//$D4B31376
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class ChattelDocumentWithPurchaseServiceController
    {
        //partial void PostScript_ChattelDocumentWithPurchaseCompletedForm(ChattelDocumentWithPurchaseCompletedFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        //{
        //    if (chattelDocumentWithPurchase.CurrentStateDefID == ChattelDocumentWithPurchase.States.Cancelled)
        //    {
        //        foreach (var detail in chattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase)
        //        {
        //            // Alma bildirimi yapıldıysa iptaili için eklendi
        //            if (!string.IsNullOrEmpty(detail.ReceiveNotificationID))
        //            {
        //                detail.DeliveryNotifictionID = StockAction.UTSMakeDeliveryNotification(detail.Material.Barcode, detail.LotNo, detail.SerialNo, long.Parse(chattelDocumentWithPurchase.Supplier.SupplierNumber), chattelDocumentWithPurchase.Waybill, int.Parse(detail.Amount.ToString()));
        //            }
        //        }
        //    }
        //} 

        partial void AfterContextSaveScript_ChattelDocumentWithPurchaseCompletedForm(ChattelDocumentWithPurchaseCompletedFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string sonucMesaji = "";
            if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
            {
                if (chattelDocumentWithPurchase.CurrentStateDefID == ChattelDocumentInputWithAccountancy.States.Cancelled)
                {
                    if (chattelDocumentWithPurchase.MKYS_AyniyatMakbuzID != null)
                    {
                        sonucMesaji = chattelDocumentWithPurchase.SendDeleteMessageToMkys(false, chattelDocumentWithPurchase.MKYS_AyniyatMakbuzID.Value, Common.CurrentResource.MkysPassword);
                        TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                    }

                }
            }
            sonucMesaji = "";
            if (chattelDocumentWithPurchase.CurrentStateDefID == ChattelDocumentWithPurchase.States.Cancelled)
            {
                foreach (var detail in chattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase)
                {
                    // Alma bildirimi yapıldıysa iptaili için eklendi
                    foreach (StockTransaction stockTransaction in detail.StockTransactions.Select(string.Empty))
                    {
                        if (string.IsNullOrEmpty(stockTransaction.ReceiveNotificationID) == false)
                        {
                            detail.DeliveryNotifictionID = StockAction.UTSMakeDeliveryNotification(stockTransaction);
                            sonucMesaji += detail.DeliveryNotifictionID;
                        }
                    }
                }
                objectContext.Save();
                TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji + " Üts verme bildirimleri yapıldı");
            }

            if(chattelDocumentWithPurchase.CurrentStateDefID == ChattelDocumentWithPurchase.States.FixDocument)
            {
                List<StockTransaction> deletedTrx = new List<StockTransaction>();
                foreach (ChattelDocumentDetailWithPurchase purchaseDetail in chattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase)
                {
                    purchaseDetail.Status = StockActionDetailStatusEnum.New;
                    foreach (StockTransaction trx in purchaseDetail.StockTransactions.Select(string.Empty))
                        deletedTrx.Add(trx);
                }

                foreach (StockTransaction trx in deletedTrx)
                    ((ITTObject)trx).Delete();

                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public partial class ChattelDocumentWithPurchaseCompletedFormViewModel
    {
    }
}