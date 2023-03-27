//$85DB23B8
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
    public partial class DrugReturnActionServiceController
    {
        partial void PostScript_DrugReturnActionApprovalForm(DrugReturnActionApprovalFormViewModel viewModel, DrugReturnAction drugReturnAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //foreach (DrugReturnActionDetail detail in drugReturnAction.DrugReturnActionDetails)
            //{
            //    if (detail.Amount == 0 && detail.Amount > detail.SendAmount)
            //    {
            //        throw new TTException("Miktarlar 0 ve Gönderilen Miktardan Büyük Olamaz.");
            //    }
            //}

            //if (string.IsNullOrEmpty(drugReturnAction.DrugReturnReason))
            //{
            //    throw new TTException("İade nedeni olmadan işlemi ilerletemessiniz.");
            //}
        }
        partial void AfterContextSaveScript_DrugReturnActionApprovalForm(DrugReturnActionApprovalFormViewModel viewModel, DrugReturnAction drugReturnAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //TTObjectContext contextNew = new TTObjectContext(false);
            //drugReturnAction.createStockIn(drugReturnAction, contextNew);
            //contextNew.Save();

        }
    }
}

namespace Core.Models
{
    public partial class DrugReturnActionApprovalFormViewModel
    {
    }
}