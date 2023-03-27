//$42B5065E
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class InpatientAdmissionDepositMaterialServiceController
    {
        partial void PreScript_InpatientAdmissinDepositMaterialForm(InpatientAdmissinDepositMaterialFormViewModel viewModel, InpatientAdmissionDepositMaterial inpatientAdmissionDepositMaterial, TTObjectContext objectContext)
        {
            if (inpatientAdmissionDepositMaterial.Episode == null)
            {
                Guid? selectedEpisodeObjectID = viewModel.GetSelectedEpisodeID();
                if (selectedEpisodeObjectID.HasValue)
                {
                    Episode episode = objectContext.GetObject<Episode>(selectedEpisodeObjectID.Value);
                    inpatientAdmissionDepositMaterial.Episode = episode;
                }
            }

            if (inpatientAdmissionDepositMaterial.ProcessDate == null)
                inpatientAdmissionDepositMaterial.ProcessDate = Common.RecTime();
            if (inpatientAdmissionDepositMaterial.ProcessUser == null)
                inpatientAdmissionDepositMaterial.ProcessUser = Common.CurrentResource;
            ContextToViewModel(viewModel, objectContext);
        }

        partial void PostScript_InpatientAdmissinDepositMaterialForm(InpatientAdmissinDepositMaterialFormViewModel viewModel, InpatientAdmissionDepositMaterial inpatientAdmissionDepositMaterial, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
        }
    }
}

namespace Core.Models
{
    public partial class InpatientAdmissinDepositMaterialFormViewModel
    {
    }
}