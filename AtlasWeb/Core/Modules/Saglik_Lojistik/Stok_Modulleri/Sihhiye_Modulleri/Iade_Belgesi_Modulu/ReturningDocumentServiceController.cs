//$F86D691A
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
    public partial class ReturningDocumentServiceController : Controller
    {
        public class GetReturningDocumentCensusReportQuery_Input
        {
            public string TERMID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ReturningDocument.GetReturningDocumentCensusReportQuery_Class> GetReturningDocumentCensusReportQuery(GetReturningDocumentCensusReportQuery_Input input)
        {
            var ret = ReturningDocument.GetReturningDocumentCensusReportQuery(input.TERMID);
            return ret;
        }

        public class CensusReportNQL_ReturningDocument_Input
        {
            public string TERMID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ReturningDocument.CensusReportNQL_ReturningDocument_Class> CensusReportNQL_ReturningDocument(CensusReportNQL_ReturningDocument_Input input)
        {
            var ret = ReturningDocument.CensusReportNQL_ReturningDocument(input.TERMID);
            return ret;
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
        public OutputForReGeneration ReGenerateMyReturningDocument(InputForReGeneration input)
        {

            OutputForReGeneration outputObject = new OutputForReGeneration();
            try
            {
                BindingList<StockAction.GetClonedStockAction_Class> otherClonedActions = StockAction.GetClonedStockAction(new Guid(input.ActionID));
                if (otherClonedActions.Count > 0)
                {
                    outputObject.IsTheActionGenerated = false;
                    outputObject.OutputMessage = " Bu işlem daha önce " + otherClonedActions[0].StockActionID.ToString() + " işlem olarak kopyanalmış bir daha kopyalamak istiyorsanız bu işlemi iptal etmeniz gerekmektedir.";
                    return outputObject;
                }
                else
                {
                    TTObjectContext context = new TTObjectContext(false);
                    ReturningDocument currentAction = (ReturningDocument)context.GetObject(new Guid(input.ActionID), typeof(ReturningDocument));

                    if (currentAction != null && currentAction.CurrentStateDefID == ReturningDocument.States.Cancelled)
                    {

                        ReturningDocument newAction = (ReturningDocument)currentAction.Clone();
                        newAction.CurrentStateDefID = ReturningDocument.States.New;
                        newAction.Description = currentAction.Description + " (İptal edilmiş " + currentAction.StockActionID.ToString() + " numaralı işlem üzerinden tekrar oluşturulmuştur!)";
                        newAction.ClonedObjectID = currentAction.ObjectID;

                        TTSequence.allowSetSequenceValue = true;
                        newAction.StockActionID.SetSequenceValue(0);
                        newAction.StockActionID.GetNextValue();

                        foreach (ReturningDocumentMaterial item in currentAction.ReturningDocumentMaterials)
                        {
                            ReturningDocumentMaterial detail = (ReturningDocumentMaterial)item.Clone();
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