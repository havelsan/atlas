//$6BC2F10D
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ChattelDocumentOutputWithAccountancyServiceController
    {
        partial void AfterContextSaveScript_ChattelDocumentOutputWithAccountancyApproveForm(ChattelDocumentOutputWithAccountancyApproveFormViewModel viewModel, ChattelDocumentOutputWithAccountancy chattelDocumentOutputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string sonucMesaji = "";
            try
            {
                if (viewModel._ChattelDocumentOutputWithAccountancy.CurrentStateDefID == ChattelDocumentOutputWithAccountancy.States.Completed)
                {


                    if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                    {
                        sonucMesaji = chattelDocumentOutputWithAccountancy.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                        TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            sonucMesaji = "";
            foreach (var detail in chattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.Select(string.Empty))
            {
                foreach (var transaction in detail.StockTransactions)
                {
                    // Alma bildirimi yapıldıysa iptaili için eklendi
                    if (string.IsNullOrEmpty(transaction.ReceiveNotificationID) == false)
                    {
                        try
                        {
                            transaction.DeliveryNotifictionID = StockAction.UTSMakeDeliveryNotification(transaction);
                            sonucMesaji += transaction.DeliveryNotifictionID;
                            objectContext.Save();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            if (String.IsNullOrEmpty(sonucMesaji) == false)
                TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji + " Üts verme bildirimleri yapıldı");


        }
    }
}

namespace Core.Models
{
    public partial class ChattelDocumentOutputWithAccountancyApproveFormViewModel
    {
    }
}