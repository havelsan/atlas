//$73E04CFD
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
using TTConnectionManager;
using TTDataDictionary;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DistributionDocumentServiceController : Controller
    {
        public class GetDistributionDocumentCensusReportQuery_Input
        {
            public string TERMID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DistributionDocument.GetDistributionDocumentCensusReportQuery_Class> GetDistributionDocumentCensusReportQuery(GetDistributionDocumentCensusReportQuery_Input input)
        {
            var ret = DistributionDocument.GetDistributionDocumentCensusReportQuery(input.TERMID);
            return ret;
        }

        public class CensusReportNQL_DistributionDocument_Input
        {
            public string TERMID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DistributionDocument.CensusReportNQL_DistributionDocument_Class> CensusReportNQL_DistributionDocument(CensusReportNQL_DistributionDocument_Input input)
        {
            var ret = DistributionDocument.CensusReportNQL_DistributionDocument(input.TERMID);
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
        public OutputForReGeneration ReGenerateMyDistributionDocument(InputForReGeneration input)
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
                    DistributionDocument currentAction = (DistributionDocument)context.GetObject(new Guid(input.ActionID), typeof(DistributionDocument));

                    if (currentAction != null && currentAction.CurrentStateDefID == DistributionDocument.States.Cancelled)
                    {

                        DistributionDocument newAction = (DistributionDocument)currentAction.Clone();

                        newAction.CurrentStateDefID = DistributionDocument.States.New;
                        newAction.Description += " (İptal edilmiş " + currentAction.StockActionID.ToString() + " numaralı işlem üzerinden tekrar oluşturulmuştur!)";
                        newAction.ClonedObjectID = currentAction.ObjectID;

                        TTSequence.allowSetSequenceValue = true;
                        newAction.StockActionID.SetSequenceValue(0);

                        newAction.StockActionID.GetNextValue();

                        foreach (DistributionDocumentMaterial item in currentAction.DistributionDocumentMaterials)
                        {
                            DistributionDocumentMaterial detail = (DistributionDocumentMaterial)item.Clone();
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


        public class GetStockMaxLvlControl_Input
        {
            public Guid materialObjectID { get; set; }
            public Guid storeObjectId { get; set; }
            public int amount { get; set; }
        }

        [HttpPost]
        public string GetStockMaxLvlControl(GetStockMaxLvlControl_Input input)
        {
            string returnValue = string.Empty;
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            Material material = (Material)readOnlyContext.GetObject(input.materialObjectID, typeof(Material));
            BindingList<Stock> stocks = material.Stocks.Select("STORE =" + ConnectionManager.GuidToString(input.storeObjectId));
            if (stocks.Count > 0)
            {
                Stock stock = stocks[0];

                Currency totalInheld = (Currency)stock.Inheld + input.amount;
                Currency maxRequest = stock.MaximumLevel.Value - (Currency)stock.Inheld;
                if (totalInheld > stock.MaximumLevel)
                {

                    returnValue = " Maximum seviye geçiliyor.Depo Mevcudu :" + stock.Inheld.ToString() + " - Maxsimum Seviye : " + stock.MaximumLevel.ToString() 
                        + "İstenilebilecek Maximum Miktar = " + maxRequest.ToString();
                }

            }

            return returnValue;
        }
    }
}