//$52CC448F
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class CensusFixedServiceController
    {
        partial void AfterContextSaveScript_CensusFixedApprovalForm(CensusFixedApprovalFormViewModel viewModel, CensusFixed censusFixed, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel._CensusFixed.CurrentStateDefID != null)
            {
                if (viewModel._CensusFixed.CurrentStateDefID == MainStoreStockTransfer.States.Completed)
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                    {
                        if (viewModel._CensusFixed.OutMkysControl == null || viewModel._CensusFixed.OutMkysControl == false)
                        {
                            string sonucMesaji = censusFixed.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                            if (viewModel._CensusFixed.InMkysControl == null || viewModel._CensusFixed.InMkysControl == false)
                            {
                                sonucMesaji += censusFixed.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                            }

                            TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                        }
                    }
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class CensusFixedApprovalFormViewModel
    {
    }
}