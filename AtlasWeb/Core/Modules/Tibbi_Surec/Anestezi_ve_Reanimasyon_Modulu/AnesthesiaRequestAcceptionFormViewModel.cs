//$E67F0831
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class AnesthesiaAndReanimationServiceController
    {
        partial void PreScript_AnesthesiaRequestAcceptionForm(AnesthesiaRequestAcceptionFormViewModel viewModel, AnesthesiaAndReanimation anesthesiaAndReanimation, TTObjectContext objectContext)
        {
            anesthesiaAndReanimation.SetProcedureDoctorAsCurrentResource();
            viewModel.isSurgeryDelay = false;
            if (anesthesiaAndReanimation.CurrentStateDefID == AnesthesiaAndReanimation.States.RequestAcception)
            {
                if (anesthesiaAndReanimation.MainSurgery != null)
                {
                    if (anesthesiaAndReanimation.IsSurgeryDelay())
                    {
                        viewModel.isSurgeryDelay = true;
                    }
                }
            }
            //ContextToViewModel den sonra çağırılmalı //TANI için
            viewModel.GridDiagnosisGridList = anesthesiaAndReanimation.DiagnosisGrid_PreScript();
            
        }

        partial void PostScript_AnesthesiaRequestAcceptionForm(AnesthesiaRequestAcceptionFormViewModel viewModel, AnesthesiaAndReanimation anesthesiaAndReanimation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDef.StateDefID == AnesthesiaAndReanimation.States.ReturnedToDoctor)
                {
                    if (anesthesiaAndReanimation.ReasonOfReject == null || string.IsNullOrEmpty(Common.GetTextOfRTFString(anesthesiaAndReanimation.ReasonOfReject.ToString())))
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M25998", "İade Sebebi girilmeden doktora iade edilemez"));
                    }
                }
            }
            //TANI için
            anesthesiaAndReanimation.DiagnosisGrid_PostScript(viewModel.GridDiagnosisGridList);
        }
    }
}

namespace Core.Models
{
    public partial class AnesthesiaRequestAcceptionFormViewModel
    {
        public Boolean isSurgeryDelay;
    }
}