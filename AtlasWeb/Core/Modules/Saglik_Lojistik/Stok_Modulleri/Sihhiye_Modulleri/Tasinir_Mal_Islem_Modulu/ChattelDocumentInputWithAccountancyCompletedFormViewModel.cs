//$0495D14F
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
    public partial class ChattelDocumentInputWithAccountancyServiceController
    {
        partial void AfterContextSaveScript_ChattelDocumentInputWithAccountancyCompletedForm(ChattelDocumentInputWithAccountancyCompletedFormViewModel viewModel, ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (chattelDocumentInputWithAccountancy.CurrentStateDefID == ChattelDocumentInputWithAccountancy.States.Cancelled)
            {
                if (chattelDocumentInputWithAccountancy.MKYS_AyniyatMakbuzID != null)
                {
                    var sonucMesaji = chattelDocumentInputWithAccountancy.SendDeleteMessageToMkys(false, chattelDocumentInputWithAccountancy.MKYS_AyniyatMakbuzID.Value, Common.CurrentResource.MkysPassword);
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                }
            }

            if (chattelDocumentInputWithAccountancy.CurrentStateDefID == ChattelDocumentInputWithAccountancy.States.FixDocument)
            {
                List<StockTransaction> deletedTrx = new List<StockTransaction>();
                foreach (ChattelDocumentInputDetailWithAccountancy purchaseDetail in chattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy)
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
    public partial class ChattelDocumentInputWithAccountancyCompletedFormViewModel
    {
    }
}