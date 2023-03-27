//$865F36A5
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.ComponentModel;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class ManipulationRequestServiceController
    {
        partial void PreScript_ManipulationRequestForm(ManipulationRequestFormViewModel viewModel, ManipulationRequest manipulationRequest, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionObjectID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                viewModel._ManipulationRequest.MasterAction = episodeAction;
                viewModel._ManipulationRequest.Episode = episodeAction.Episode;

                if (Common.CurrentResource.TakesPerformanceScore == true)
                {
                    viewModel._ManipulationRequest.ProcedureDoctor = Common.CurrentResource;
                }
                else
                {
                    viewModel._ManipulationRequest.ProcedureDoctor = episodeAction.ProcedureDoctor;
                }
            }

            //manipulationRequest.CurrentStateDefID = ManipulationRequest.States.Request;
           
            //BindingList<ResSection> resources = ResSection.GetResSections(objectContext, ""); 

            
            //viewModel.ProcedureDepartments = resources.ToArray();

            ContextToViewModel(viewModel, objectContext);
        }

        partial void PostScript_ManipulationRequestForm(ManipulationRequestFormViewModel viewModel, ManipulationRequest manipulationRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            objectContext.Update();
            for (int i = 0; i < manipulationRequest.ManipulationProcedures.Count; i++)
            {
                manipulationRequest.ManipulationProcedures[i].Amount = 1;
            }

            manipulationRequest.CurrentStateDefID = ManipulationRequest.States.Completed;
            

        }

        partial void AfterContextSaveScript_ManipulationRequestForm(ManipulationRequestFormViewModel viewModel, ManipulationRequest manipulationRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            foreach (ManipulationProcedure mp in manipulationRequest.ManipulationProcedures)
            {
                SurgeryDefinition manipulationProcedureDef = (SurgeryDefinition)(mp.ProcedureObject);
                if (manipulationProcedureDef.ManipulationStartState != null)
                {
                   
                    if (mp.Manipulation.CurrentStateDefID == Manipulation.States.RequestAcception)
                    {
                        if (manipulationProcedureDef.ManipulationStartState == ManipulationStartStateEnum.DoctorProcedure)
                            mp.Manipulation.CurrentStateDefID = Manipulation.States.DoctorProcedure;
                        else if (manipulationProcedureDef.ManipulationStartState == ManipulationStartStateEnum.TechnicianProcedure)
                            mp.Manipulation.CurrentStateDefID = Manipulation.States.TechnicianProcedure;
                        else if (manipulationProcedureDef.ManipulationStartState == ManipulationStartStateEnum.NursingProcedure)
                            mp.Manipulation.CurrentStateDefID = Manipulation.States.NursingProcedure;
                    }
                }
            }

            objectContext.Save();
        }

    }
}

namespace Core.Models
{
    public partial class ManipulationRequestFormViewModel
    {
        public object _selectedManipulationProcedureObject
        {
            get;
            set;
        }

        //public TTObjectClasses.ResSection[] ProcedureDepartments { get; set; }
    }
}