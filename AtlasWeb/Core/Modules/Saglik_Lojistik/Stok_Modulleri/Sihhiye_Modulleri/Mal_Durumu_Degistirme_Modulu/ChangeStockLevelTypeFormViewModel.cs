//$0C6FCBFE
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ChangeStockLevelTypeServiceController
    {
        partial void AfterContextSaveScript_ChangeStockLevelTypeForm(ChangeStockLevelTypeFormViewModel viewModel, ChangeStockLevelType changeStockLevelType, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (changeStockLevelType.CurrentStateDefID == ChangeStockLevelType.States.Completed)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                {
                    var sonucMesaji = changeStockLevelType.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class ChangeStockLevelTypeFormViewModel
    {
    }
}