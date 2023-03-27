//$77C889E5
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class HemodialysisOrderServiceController
    {
        partial void PreScript_HemodialysisOrderForm(HemodialysisOrderFormViewModel viewModel, HemodialysisOrder hemodialysisOrder, TTObjectContext objectContext)
        {
            Guid? activeEpisodeObjectID = viewModel.GetSelectedEpisodeActionID();
            if (activeEpisodeObjectID.HasValue && hemodialysisOrder.IsOldAction != true)
            {
                EpisodeAction activeEpisodeAction = objectContext.GetObject<EpisodeAction>(activeEpisodeObjectID.Value);

                hemodialysisOrder.SetMandatoryEpisodeActionProperties(activeEpisodeAction, activeEpisodeAction.MasterResource, true);

                hemodialysisOrder.MasterAction = activeEpisodeAction;//?????????????????
                hemodialysisOrder.CurrentStateDefID = HemodialysisOrder.States.Request;
                if (activeEpisodeAction.SubEpisode.StarterEpisodeAction != null && activeEpisodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor != null)
                    hemodialysisOrder.ProcedureDoctor = activeEpisodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor;
                else if (activeEpisodeAction.ProcedureDoctor != null)
                    hemodialysisOrder.ProcedureDoctor = activeEpisodeAction.ProcedureDoctor;
            }

            List<ResEquipment> resEquipmentList = new List<ResEquipment>();
            var equipmentList = ResEquipment.GetHemodialysisResEquipment(objectContext);
            foreach (var equipment in equipmentList)
            {
                ResEquipment resEquipment = objectContext.GetObject(equipment.ObjectID.Value, equipment.ObjectDefID.Value) as ResEquipment;
                resEquipmentList.Add(resEquipment);
            }
            viewModel.ResEquipments = resEquipmentList.ToArray();
            ContextToViewModel(viewModel, objectContext);
        }

        partial void PostScript_HemodialysisOrderForm(HemodialysisOrderFormViewModel viewModel, HemodialysisOrder hemodialysisOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (hemodialysisOrder.HemodialysisRequest != null && hemodialysisOrder.IsOldAction != true)
            {
                EpisodeAction activeEpisodeAction = hemodialysisOrder.HemodialysisRequest;

                hemodialysisOrder.SetMandatoryEpisodeActionProperties(activeEpisodeAction, activeEpisodeAction.MasterResource, true);

                hemodialysisOrder.MasterAction = activeEpisodeAction;//?????????????????
                if (hemodialysisOrder.CurrentStateDefID == null)
                {
                    hemodialysisOrder.CurrentStateDefID = HemodialysisOrder.States.Request;
                }

                if (activeEpisodeAction.SubEpisode.StarterEpisodeAction != null && activeEpisodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor != null)
                    hemodialysisOrder.ProcedureDoctor = activeEpisodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor;
                else if (activeEpisodeAction.ProcedureDoctor != null)
                    hemodialysisOrder.ProcedureDoctor = activeEpisodeAction.ProcedureDoctor;
            }

            if (hemodialysisOrder.SessionCount != null)
            {
                hemodialysisOrder.Amount = hemodialysisOrder.SessionCount;
            }
            else
            {
                hemodialysisOrder.Amount = 0;
            }

            if (hemodialysisOrder.PackageProcedure != null)
            {
                hemodialysisOrder.ProcedureObject = hemodialysisOrder.PackageProcedure;
            }

            //hemodialysisOrder.CurrentStateDefID = HemodialysisOrder.States.Plan;
        }

        partial void AfterContextSaveScript_HemodialysisOrderForm(HemodialysisOrderFormViewModel viewModel, HemodialysisOrder hemodialysisOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            hemodialysisOrder.CurrentStateDefID = HemodialysisOrder.States.Plan;
            objectContext.Save();
        }
    }
}

namespace Core.Models
{
    public partial class HemodialysisOrderFormViewModel : BaseViewModel
    {
    }
}
