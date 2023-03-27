//$4774BF4D
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class DrugReturnActionServiceController
    {
        partial void PostScript_DrugReturnActionNewForm(DrugReturnActionNewFormViewModel viewModel, DrugReturnAction drugReturnAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (string.IsNullOrEmpty(drugReturnAction.DrugReturnReason))
            {
                throw new TTException(TTUtils.CultureService.GetText("M25997", "İade nedeni olmadan işlemi ilerletemessiniz."));
            }
        }
       
    }
}

namespace Core.Models
{

    public partial class DrugReturnActionNewFormViewModel
    {
        //DrugReturnAction Classına taşındı
        //public static GetReturnDetails GetReturnableDrugsOnPatient(Guid episodeObjectID)
        //{
        //    TTObjectContext objectContext = new TTObjectContext(true);
        //    GetReturnDetails output = new GetReturnDetails();

        //    List<GetReturnableDetails_Output> getReturnableDetails = new List<GetReturnableDetails_Output>();
        //    List<GetReturnableDetails_Output> getReviewDetails = new List<GetReturnableDetails_Output>();

        //    IList allDrugOrderTransaction = DrugOrderTransaction.GetReturnableDrugOrderTrx(objectContext, episodeObjectID);
        //    Dictionary<Guid, ReturnableDrugsOnPatient> returnList = new Dictionary<Guid, ReturnableDrugsOnPatient>(); // iade edilebilir ilaçların bulundugu liste, bu liste dolu ise hasta üzerinde doz bulunuyor anlamına gelir.

        //    foreach (DrugOrderTransaction.GetReturnableDrugOrderTrx_Class drugOrderTransaction in allDrugOrderTransaction)
        //    {

        //        var drugDeliveryActionDetailList = objectContext.QueryObjects("DRUGDELIVERYACTIONDETAIL", " DRUGORDERTRANSACTION ='" + drugOrderTransaction.ObjectID.ToString() + "'");
        //        if (drugDeliveryActionDetailList.Count == 0)
        //        {
        //            var drugReturnActionDetailList = objectContext.QueryObjects("DRUGRETURNACTIONDETAIL", " DRUGORDERTRANSACTION ='" + drugOrderTransaction.ObjectID.ToString() + "' AND DRUGRETURNACTION.CURRENTSTATEDEFID <> 'a3b9f936-e351-4bfd-831c-ef9e8975b0f2' ORDER BY DRUGRETURNACTION.ACTIONDATE DESC ");
        //            if (drugReturnActionDetailList.Count > 0)
        //            {
        //                foreach (DrugReturnActionDetail returnDetail in drugReturnActionDetailList)
        //                {
        //                    if (returnDetail.CurrentStateDefID != DrugReturnAction.States.Cancelled)
        //                    {
        //                        if (returnDetail.DrugReturnAction.CurrentStateDefID == DrugReturnAction.States.Approval)
        //                        {
        //                            CreateReturnableObjectAndAddToReturnDrugList(objectContext, returnList, drugOrderTransaction, returnDetail.SendAmount.Value);
        //                        }else if(returnDetail.DrugReturnAction.CurrentStateDefID == DrugReturnAction.States.Completed)
        //                        {
        //                            CreateReturnableObjectAndAddToReturnDrugList(objectContext, returnList, drugOrderTransaction, 0);
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                CreateReturnableObjectAndAddToReturnDrugList(objectContext, returnList, drugOrderTransaction, 0);
        //            }
        //        }
        //    }

        //    output.IsThereAnyReturnableDrugs = returnList.Count > 0;
        //    foreach (KeyValuePair<Guid, ReturnableDrugsOnPatient> outobject in returnList)
        //    {
        //        ReturnableDrugsOnPatient returnableDrugsOnPatient = outobject.Value;
        //        if (returnableDrugsOnPatient.Amount > 0)
        //        {
        //            DrugOrderTransaction trx = (DrugOrderTransaction)objectContext.GetObject(returnableDrugsOnPatient.drugOrderTransaction, "DRUGORDERTRANSACTION");
        //            List<StockTransaction> returnableStockTransaction = trx.KScheduleMaterial.StockTransactions.Select(string.Empty).Where(t => t.StockCollectedTrxs.Count == 0).ToList();

        //            GetReturnableDetails_Output drugDeliveryActionDetail = new GetReturnableDetails_Output();
        //            drugDeliveryActionDetail.Amount = returnableDrugsOnPatient.Amount;
        //            drugDeliveryActionDetail.ReturnAmount = returnableDrugsOnPatient.ReturnAmount;
        //            drugDeliveryActionDetail.drugName = returnableDrugsOnPatient.drugName;
        //            drugDeliveryActionDetail.drugOrderTransaction = trx;
        //            drugDeliveryActionDetail.transactionDate = (DateTime)trx.KScheduleMaterial.StockAction.TransactionDate;

        //            if (returnableStockTransaction.Count > 0)
        //            {
        //                getReturnableDetails.Add(drugDeliveryActionDetail);
        //            }
        //            else
        //            {
        //                getReviewDetails.Add(drugDeliveryActionDetail);
        //            }
        //        }
        //        else if (returnableDrugsOnPatient.Amount < 0)
        //        {

        //        }
        //    }

        //    output.getReturnableDetails = getReturnableDetails;
        //    output.getReviewDetails = getReviewDetails;
        //    return output;
        //}

        //private static void CreateReturnableObjectAndAddToReturnDrugList(TTObjectContext objectContext, Dictionary<Guid, ReturnableDrugsOnPatient> returnList, DrugOrderTransaction.GetReturnableDrugOrderTrx_Class drugOrderTransaction, double returnAbleAmount)
        //{

        //    double resAmount = 0;
        //    DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject((Guid)drugOrderTransaction.Drugdefinition, "DRUGDEFINITION");
        //    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
        //    ReturnableDrugsOnPatient returnableDrugsOnPatient = null;
        //    bool insertBefore = returnList.TryGetValue(drugOrderTransaction.ObjectID.Value, out returnableDrugsOnPatient);


        //    if (drugType) // Tablet , Hap gibi sayıca iade ediilebilir ilaçlar
        //    {
        //        if (insertBefore == false) // aynı ilacın eczaneye birden fazla iade durumu kontrolu
        //        {
        //            returnableDrugsOnPatient = new ReturnableDrugsOnPatient();
        //            resAmount = Convert.ToDouble(drugOrderTransaction.Restamount) - returnAbleAmount;
        //        }
        //        else
        //        {
        //            resAmount = returnableDrugsOnPatient.Amount - returnAbleAmount;
        //        }
        //    }
        //    else
        //    {
        //        if (insertBefore == false) // aynı ilacın eczaneye birden fazla iade durumu kontrolu
        //        {
        //            returnableDrugsOnPatient = new ReturnableDrugsOnPatient();
        //            //Şurup, Krem gibi açılınca eczaneye iadesi olmayan ilaçlar.
        //            double resVolume = Convert.ToDouble(drugOrderTransaction.Restamount) - returnAbleAmount;
        //            resAmount = Math.Truncate(resVolume / (double)drugDefinition.Volume);
        //        }
        //        else
        //        {
        //            double resVolume = returnableDrugsOnPatient.Amount - returnAbleAmount;
        //            resAmount = Math.Truncate(resVolume / (double)drugDefinition.Volume);
        //        }

        //    }


        //    returnableDrugsOnPatient.Amount = resAmount;
        //    returnableDrugsOnPatient.ReturnAmount = resAmount;
        //    returnableDrugsOnPatient.drugName = drugDefinition.Name;
        //    returnableDrugsOnPatient.drugOrderTransaction = drugOrderTransaction.ObjectID.Value;
        //    if (insertBefore == false)
        //        returnList.Add(drugOrderTransaction.ObjectID.Value, returnableDrugsOnPatient);


        //}
    }

    //public class GetReturnDetails
    //{
    //    public GetReturnDetails()
    //    {
    //        this.IsThereAnyReturnableDrugs = false;
    //    }

    //    public List<GetReturnableDetails_Output> getReturnableDetails { get; set; }
    //    public List<GetReturnableDetails_Output> getReviewDetails { get; set; }

    //    public bool IsThereAnyReturnableDrugs { get; set; }// iade edilebilir ilaçların bulundugu boolean, true ise hasta üzerinde doz bulunuyor anlamına gelir.
    //}

    //public class GetReturnableDetails_Output
    //{
    //    public DateTime transactionDate
    //    {
    //        get;
    //        set;
    //    }

    //    public string drugName
    //    {
    //        get;
    //        set;
    //    }
    //    public double Amount
    //    {
    //        get;
    //        set;
    //    }
    //    public double ReturnAmount
    //    {
    //        get;
    //        set;
    //    }
    //    public Guid MaterialObjectID
    //    {
    //        get;
    //        set;
    //    }
    //    public DrugOrderTransaction drugOrderTransaction
    //    {
    //        get;
    //        set;
    //    }
    //}
    //public class GetReturnableDetails_Input
    //{
    //    public Guid episodeID
    //    {
    //        get;
    //        set;
    //    }
    //}
    //public class ReturnableDrugsOnPatient
    //{
    //    public string drugName
    //    {
    //        get;
    //        set;
    //    }
    //    public double Amount
    //    {
    //        get;
    //        set;
    //    }
    //    public double ReturnAmount
    //    {
    //        get;
    //        set;
    //    }

    //    public Guid drugOrderTransaction
    //    {
    //        get;
    //        set;
    //    }

    //    public bool drugType { get; set; }
    //}

}