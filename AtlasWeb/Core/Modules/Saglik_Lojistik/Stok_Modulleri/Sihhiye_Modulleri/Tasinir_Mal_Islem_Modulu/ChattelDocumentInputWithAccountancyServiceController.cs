//$31A57F44
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
    public partial class ChattelDocumentInputWithAccountancyServiceController : Controller
    {
        public class InputDetailsWithAccountancyRQ_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

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
            public TTObjectClasses.ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy
            {
                get;
                set;
            }

            public List<TTObjectClasses.ChattelDocumentInputDetailWithAccountancy> chattelDocumentInputDetailWithAccountancy
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ChattelDocumentInputWithAccountancy.InputDetailsWithAccountancyRQ_Class> InputDetailsWithAccountancyRQ(InputDetailsWithAccountancyRQ_Input input)
        {
            var ret = ChattelDocumentInputWithAccountancy.InputDetailsWithAccountancyRQ(input.TTOBJECTID);
            return ret;
        }

        public class GetSameBaseNumberNQL_Input
        {
            public Guid TERMID
            {
                get;
                set;
            }

            public string BASENUMBER
            {
                get;
                set;
            }

            public Guid ACCOUNTANCY
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Tasinir_Mal_Islemi_Giris_Kayit)]
        public BindingList<ChattelDocumentInputWithAccountancy> GetSameBaseNumberNQL(GetSameBaseNumberNQL_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ChattelDocumentInputWithAccountancy.GetSameBaseNumberNQL(objectContext, input.TERMID, input.BASENUMBER, input.ACCOUNTANCY);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Tasinir_Mal_Islemi_Giris_Kayit)]
        public GetWaybillForInputDetailDocument_Output GetWaybillForInputDocumentTS(GetWaybillForInputDocumentTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.stockAction != null)
                    input.stockAction = (TTObjectClasses.StockAction)objectContext.AddObject(input.stockAction);
                var ret = ChattelDocumentInputWithAccountancy.GetWaybillForInputDocumentTS((ChattelDocumentInputWithAccountancy)input.stockAction);
                GetWaybillForInputDetailDocument_Output getWaybillForInputDetailDocument_Output = new Controllers.ChattelDocumentInputWithAccountancyServiceController.GetWaybillForInputDetailDocument_Output();
                getWaybillForInputDetailDocument_Output.chattelDocumentInputWithAccountancy = ret;
                getWaybillForInputDetailDocument_Output.chattelDocumentInputDetailWithAccountancy = new List<ChattelDocumentInputDetailWithAccountancy>();
                foreach (ChattelDocumentInputDetailWithAccountancy detail in ret.ChattelDocumentInputDetailsWithAccountancy)
                    getWaybillForInputDetailDocument_Output.chattelDocumentInputDetailWithAccountancy.Add(detail);
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

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public OutputForReGeneration ReGenerateMyChattelDocumentInputWithAccountancy(InputForReGeneration input)
        {
            
            OutputForReGeneration outputObject = new OutputForReGeneration();
            try
            {
                BindingList< StockAction.GetClonedStockAction_Class> otherClonedActions =  StockAction.GetClonedStockAction(new Guid(input.ActionID));
                if (otherClonedActions.Count > 0)
                {
                    outputObject.IsTheActionGenerated = false;
                    outputObject.OutputMessage = " Bu işlem daha önce " + otherClonedActions[0].StockActionID.ToString() + " işlem olarak kopyanalmış bir daha kopyalamak istiyorsanız bu işlemi iptal etmeniz gerekmektedir.";
                    return outputObject;
                }
                else
                {
                    TTObjectContext context = new TTObjectContext(false);
                    ChattelDocumentInputWithAccountancy currentAction = (ChattelDocumentInputWithAccountancy)context.GetObject(new Guid(input.ActionID), typeof(ChattelDocumentInputWithAccountancy));

                    if (currentAction != null && currentAction.CurrentStateDefID == ChattelDocumentInputWithAccountancy.States.Cancelled)
                    {

                        ChattelDocumentInputWithAccountancy newAction = (ChattelDocumentInputWithAccountancy)currentAction.Clone();

                        newAction.CurrentStateDefID = ChattelDocumentInputWithAccountancy.States.New;
                        newAction.Description = currentAction.Description + " (İptal edilmiş " + currentAction.StockActionID.ToString() + " numaralı işlem üzerinden tekrar oluşturulmuştur!)";
                        newAction.ClonedObjectID = currentAction.ObjectID;

                        TTSequence.allowSetSequenceValue = true;
                        newAction.StockActionID.SetSequenceValue(0);
                        newAction.StockActionID.GetNextValue();

                        foreach (ChattelDocumentInputDetailWithAccountancy item in currentAction.ChattelDocumentInputDetailsWithAccountancy)
                        {
                            ChattelDocumentInputDetailWithAccountancy detail = (ChattelDocumentInputDetailWithAccountancy)item.Clone();
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