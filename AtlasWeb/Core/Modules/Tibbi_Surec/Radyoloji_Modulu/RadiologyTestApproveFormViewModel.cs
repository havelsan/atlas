//$5C83FE5B
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class RadiologyTestServiceController
    {
        partial void PostScript_RadiologyTestApproveForm(RadiologyTestApproveFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDefID == RadiologyTest.States.Reported)
                {
                    if (radiologyTest.Report == null)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M26755", "Rapor yazılmadan süreç 'Raporlandı' aşamasına alınamaz!"));
                    }
                }
            }
        }
        partial void PreScript_RadiologyTestApproveForm(RadiologyTestApproveFormViewModel viewModel, RadiologyTest radiologyTest, TTObjectContext objectContext)
        {
            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalışmamalı
            viewModel.MaterialsGridList = viewModel.MaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
        }
    }
}

namespace Core.Models
{
    public partial class RadiologyTestApproveFormViewModel
    {
    }
}