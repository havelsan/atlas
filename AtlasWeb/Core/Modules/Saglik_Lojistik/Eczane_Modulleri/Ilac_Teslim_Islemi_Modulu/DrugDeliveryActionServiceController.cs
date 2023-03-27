//$85E1E85B
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class DrugDeliveryActionServiceController : Controller
    {
        public class GetDetails_Input
        {
            public Guid episodeID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<GetDetails_Output> GetDetails(GetDetails_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<GetDetails_Output> output = new List<GetDetails_Output>();
                BindingList<DrugOrderTransaction.GetReturnableDrugOrderTrx_Class> allDrugOrderTransaction = DrugOrderTransaction.GetReturnableDrugOrderTrx(input.episodeID);

                foreach (DrugOrderTransaction.GetReturnableDrugOrderTrx_Class drugOrderTransaction in allDrugOrderTransaction)
                {

                    var drugReturnActionDetailList = objectContext.QueryObjects("DRUGRETURNACTIONDETAIL", " DRUGORDERTRANSACTION ='" + drugOrderTransaction.ObjectID.ToString() + "' AND DRUGRETURNACTION.CURRENTSTATEDEFID <> 'a3b9f936-e351-4bfd-831c-ef9e8975b0f2' ");
                    if (drugReturnActionDetailList.Count > 0)
                    {
                        bool controlAmount = true;
                        foreach (DrugReturnActionDetail det in drugReturnActionDetailList)
                        {
                            if (det.DrugReturnAction.CurrentStateDefID == DrugReturnAction.States.Completed || det.DrugReturnAction.CurrentStateDefID == DrugReturnAction.States.Approval )
                            {
                                if (det.Amount <= det.SendAmount)
                                {
                                    controlAmount = false;
                                }
                            }
                        }
                        if (controlAmount == false)
                            continue;
                    }
                    var drugDeliveryActionDetailList = objectContext.QueryObjects("DRUGDELIVERYACTIONDETAIL", " DRUGORDERTRANSACTION ='" + drugOrderTransaction.ObjectID.ToString() + "'");
                    if (drugDeliveryActionDetailList.Count > 0)
                    {
                        continue;
                    }

                    DrugOrderTransaction trx = (DrugOrderTransaction)objectContext.GetObject((Guid)drugOrderTransaction.ObjectID, "DRUGORDERTRANSACTION");
                    DrugOrder order = (DrugOrder)objectContext.GetObject((Guid)drugOrderTransaction.Drugorder, "DRUGORDER");
                    DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject((Guid)drugOrderTransaction.Drugdefinition, "DRUGDEFINITION");
                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                    if (drugType)
                    {
                        if (DrugOrderTransaction.GetRestDose(order) > 0)
                        {
                            GetDetails_Output drugDeliveryActionDetail = new GetDetails_Output();
                            drugDeliveryActionDetail.Amount = Convert.ToDouble(drugOrderTransaction.Restamount); // DrugOrderTransaction.GetRestDose(order); her serferinde girip sayýyý arttýrýyor.
                            drugDeliveryActionDetail.drugName = drugDefinition.Name;
                            drugDeliveryActionDetail.drugOrderTransaction = trx;
                            drugDeliveryActionDetail.DrugOrderDetails = new List<DrugOrderDetail>();

                            foreach (DrugOrderDetail drugOrderDetail in order.DrugOrderDetails)
                            {
                                if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply || drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ExPharmacySupply)
                                {
                                    drugDeliveryActionDetail.DrugOrderDetails.Add(drugOrderDetail);
                                }
                            }
                            output.Add(drugDeliveryActionDetail);
                        }
                    }
                    else
                    {
                        double resVolume = DrugOrderTransaction.GetRestDose(order);
                        double resAmount = 0;
                        if (resVolume > 0)
                        {
                            resAmount = Math.Truncate(resVolume / (double)drugDefinition.Volume);
                            if (resAmount > 0)
                            {
                                GetDetails_Output drugDeliveryActionDetail = new GetDetails_Output();
                                drugDeliveryActionDetail.Amount = resAmount;
                                drugDeliveryActionDetail.drugName = drugDefinition.Name;
                                drugDeliveryActionDetail.drugOrderTransaction = trx;
                                drugDeliveryActionDetail.DrugOrderDetails = new List<DrugOrderDetail>();

                                foreach (DrugOrderDetail drugOrderDetail in order.DrugOrderDetails)
                                {
                                    if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply || drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ExPharmacySupply)
                                    {
                                        drugDeliveryActionDetail.DrugOrderDetails.Add(drugOrderDetail);
                                    }
                                }
                                output.Add(drugDeliveryActionDetail);
                            }
                        }
                    }

                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class GetDetails_Output
        {
            public string drugName
            {
                get;
                set;
            }
            public double Amount
            {
                get;
                set;
            }

            public DrugOrderTransaction drugOrderTransaction
            {
                get;
                set;
            }
            public List<DrugOrderDetail> DrugOrderDetails
            {
                get;
                set;
            }
        }
    }
}