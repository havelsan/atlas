//$DCFA882E
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using TTDataDictionary;

namespace Core.Controllers
{
    public partial class ChattelDocumentOutputWithAccountancyServiceController
    {
        partial void AfterContextSaveScript_ChattelDocumentOutputWithAccountancyNewForm(ChattelDocumentOutputWithAccountancyNewFormViewModel viewModel, ChattelDocumentOutputWithAccountancy chattelDocumentOutputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
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
                    // Alma bildirimi yapýldýysa iptaili için eklendi
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
                TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji + " Üts verme bildirimleri yapýldý");

        }
    }
}

namespace Core.Models
{
    public partial class ChattelDocumentOutputWithAccountancyNewFormViewModel
    {
        public OuttableLotDTO[] OuttableLotList { get; set; }
        public QRCodeReadDTO[] QRCodeReadList { get; set; }
    }

    public class OuttableLotDTO
    {
        public Currency Amount { get; set; }
        public Currency RestAmount { get; set; }
        public string BudgetTypeName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string LotNo { get; set; }
        public string SerialNo { get; set; }
        public Guid TrxObjectID { get; set; }
        public Int16 StockActionDetailOrderNo { get; set; }
    }

    public class QRCodeReadDTO
    {
        public string Barcode { get; set; }
        public string LotNo { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SerialNo { get; set; }
        public Currency Amount { get; set; }
        public Guid MaterialObjectID { get; set; }
    }
}