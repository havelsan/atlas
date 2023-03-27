//$EC403D5B
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ExtendExpirationDateServiceController
    {
        partial void AfterContextSaveScript_ExtendExpDateCompletedForm(ExtendExpDateCompletedFormViewModel viewModel, ExtendExpirationDate extendExpirationDate, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string sonucMesaji = "";
            //TODO ilayda
            //if (extendExpirationDate.CurrentStateDefID == ExtendExpirationDate.States.Completed)
            //{
            //    if (extendExpirationDate.InMkysControl != null || extendExpirationDate.InMkysControl != false)
            //    {
            //        sonucMesaji = extendExpirationDate.SendDeleteMessageToMkys(false, extendExpirationDate.MKYS_AyniyatMakbuzIDGiris.Value, Common.CurrentResource.MkysPassword);
            //        if (extendExpirationDate.OutMkysControl != null || extendExpirationDate.OutMkysControl != false)
            //        {
            //            sonucMesaji += extendExpirationDate.SendDeleteMessageToMkys(true, extendExpirationDate.MKYS_AyniyatMakbuzID.Value,Common.CurrentResource.MkysPassword);
            //        }
            //    }

            //    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
            //}
        }
    }
}

namespace Core.Models
{
    public partial class ExtendExpDateCompletedFormViewModel
    {
    }
}