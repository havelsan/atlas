//$F54FF559
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
        partial void AfterContextSaveScript_CensusFixedCompletedForm(CensusFixedCompletedFormViewModel viewModel, CensusFixed censusFixed, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string sonucMesaji = "";
            if (censusFixed.CurrentStateDefID == CensusFixed.States.Cancelled)
            {
                if (censusFixed.InMkysControl != null || censusFixed.InMkysControl != false)
                {
                    if (censusFixed.MKYS_AyniyatMakbuzIDGiris != null)
                    {
                        sonucMesaji = censusFixed.SendDeleteMessageToMkys(false, censusFixed.MKYS_AyniyatMakbuzIDGiris.Value, Common.CurrentResource.MkysPassword);
                        if (censusFixed.OutMkysControl != null || censusFixed.OutMkysControl != false)
                        {
                            sonucMesaji += censusFixed.SendDeleteMessageToMkys(true, censusFixed.MKYS_AyniyatMakbuzID.Value,Common.CurrentResource.MkysPassword);
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
    public partial class CensusFixedCompletedFormViewModel
    {
    }
}