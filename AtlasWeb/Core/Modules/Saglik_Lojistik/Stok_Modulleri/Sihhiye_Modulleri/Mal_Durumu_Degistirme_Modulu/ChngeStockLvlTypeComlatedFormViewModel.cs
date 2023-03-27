//$2AFB696B
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
    /*partial void AfterContextSaveScript(ChangeStockLevelTypeFormViewModel viewModel, ChangeStockLevelType changeStockLevelType)
{
 if (changeStockLevelType.CurrentStateDefID == ChangeStockLevelType.States.Completed)
                {
                    var sonucMesaji = changeStockLevelType.SendMKYSForOutputDocument();
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                   
                }

                if (changeStockLevelType.CurrentStateDefID == ChangeStockLevelType.States.Cancel)
                {
                    var sonucMesaji = changeStockLevelType.SendDeleteMessageToMkys(true, changeStockLevelType.MKYS_AyniyatMakbuzID.Value);
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);

                }
}*/
    }
}

namespace Core.Models
{
    public partial class ChngeStockLvlTypeComlatedFormViewModel
    {
    }
}