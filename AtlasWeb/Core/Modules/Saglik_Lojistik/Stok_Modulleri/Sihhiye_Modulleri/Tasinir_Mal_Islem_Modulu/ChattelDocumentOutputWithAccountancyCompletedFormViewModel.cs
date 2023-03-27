//$142D7451
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
        partial void AfterContextSaveScript_ChattelDocumentOutputWithAccountancyCompletedForm(ChattelDocumentOutputWithAccountancyCompletedFormViewModel viewModel, ChattelDocumentOutputWithAccountancy chattelDocumentOutputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (chattelDocumentOutputWithAccountancy.CurrentStateDefID == ChattelDocumentInputWithAccountancy.States.Cancelled)
            {
                if (chattelDocumentOutputWithAccountancy.MKYS_AyniyatMakbuzID != null)
                {
                    var sonucMesaji = chattelDocumentOutputWithAccountancy.SendDeleteMessageToMkys(true, chattelDocumentOutputWithAccountancy.MKYS_AyniyatMakbuzID.Value,Common.CurrentResource.MkysPassword);
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class ChattelDocumentOutputWithAccountancyCompletedFormViewModel
    {
    }
}