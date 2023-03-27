//$8D1B005E
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class MainStoreStockTransferServiceController
    {
        partial void AfterContextSaveScript_MainStoreStockTransferCompletedForm(MainStoreStockTransferCompletedFormViewModel viewModel, MainStoreStockTransfer mainStoreStockTransfer, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string sonucMesaji = "";
            if (viewModel._MainStoreStockTransfer.CurrentStateDefID == MainStoreStockTransfer.States.Cancelled)
            {
                if (mainStoreStockTransfer.InMkysControl != null || mainStoreStockTransfer.InMkysControl != false)
                {
                    if (mainStoreStockTransfer.MKYS_AyniyatMakbuzIDGiris != null)
                    {
                        sonucMesaji = mainStoreStockTransfer.SendDeleteMessageToMkys(false, mainStoreStockTransfer.MKYS_AyniyatMakbuzIDGiris.Value, Common.CurrentResource.MkysPassword);
                        if (mainStoreStockTransfer.OutMkysControl != null || mainStoreStockTransfer.OutMkysControl != false)
                        {
                            sonucMesaji += mainStoreStockTransfer.SendDeleteMessageToMkys(true, mainStoreStockTransfer.MKYS_AyniyatMakbuzID.Value,Common.CurrentResource.MkysPassword);
                        }
                    }
                }

                TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
            }
        }
    }
}

namespace Core.Models
{
    public partial class MainStoreStockTransferCompletedFormViewModel
    {
    }
}