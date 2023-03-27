//$FB54B33A
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
        partial void AfterContextSaveScript_MainStoreStockTransferStoreAppropvalForm(MainStoreStockTransferStoreAppropvalFormViewModel viewModel, MainStoreStockTransfer mainStoreStockTransfer, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string sonucMesaji = string.Empty;
            if (viewModel._MainStoreStockTransfer.CurrentStateDefID != null)
            {
                if (viewModel._MainStoreStockTransfer.CurrentStateDefID == MainStoreStockTransfer.States.Completed)
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                    {

                        if (viewModel._MainStoreStockTransfer.OutMkysControl == null || viewModel._MainStoreStockTransfer.OutMkysControl == false)
                        {
                            sonucMesaji = mainStoreStockTransfer.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                            if (viewModel._MainStoreStockTransfer.InMkysControl == null || viewModel._MainStoreStockTransfer.InMkysControl == false)
                            {
                                sonucMesaji += mainStoreStockTransfer.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                            }
                        }
                        else if (viewModel._MainStoreStockTransfer.InMkysControl == null || viewModel._MainStoreStockTransfer.InMkysControl == false)
                        {
                            sonucMesaji = mainStoreStockTransfer.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                        }

                        TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                    }
                }

            }
        }
    }
}

namespace Core.Models
{
    public partial class MainStoreStockTransferStoreAppropvalFormViewModel
    {
    }
}