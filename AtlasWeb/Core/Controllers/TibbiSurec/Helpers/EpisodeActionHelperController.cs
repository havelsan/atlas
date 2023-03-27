using Infrastructure.Filters;
using Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers.TibbiSurec
{
    [HvlResult]
    [Route("api/[controller]/[action]")]
    public class EpisodeActionHelperController : Controller
    {
        [HttpGet]
        [Route("{objectDefID}/{episodeID}/{currentStateDefID}")]
        public DefaultEpisodeActionViewModel GetNewEpisodeAction(Guid objectDefID, Guid episodeID, Guid currentStateDefID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var defaultEpisodeActionViewModel = new DefaultEpisodeActionViewModel();
                var ttObject = objectContext.CreateObject(objectDefID);
                SetDefaultPropertiesByEpisode(ttObject, episodeID);
                if (ttObject is EpisodeAction)
                {
                    EpisodeAction episodeAction = (EpisodeAction)ttObject;
                    episodeAction.CurrentStateDefID = currentStateDefID;
                    episodeAction.CheckRulesForNewEpisodeAction();
                    defaultEpisodeActionViewModel._EpisodeAction = episodeAction;
                    defaultEpisodeActionViewModel._Episode = episodeAction.Episode;
                    defaultEpisodeActionViewModel._MasterResource = episodeAction.MasterResource;
                    defaultEpisodeActionViewModel._FromResource = episodeAction.FromResource;
                    defaultEpisodeActionViewModel._SecondaryMasterResource = episodeAction.SecondaryMasterResource;
                    defaultEpisodeActionViewModel._ProcedureSpeciality = episodeAction.ProcedureSpeciality;
                    defaultEpisodeActionViewModel._ProcedureDoctor = episodeAction.ProcedureDoctor;
                    defaultEpisodeActionViewModel._SubEpisode = episodeAction.SubEpisode;
                    defaultEpisodeActionViewModel._MasterAction = episodeAction.MasterAction;
                }
                else
                {
                    throw new TTUtils.TTException(objectDefID + " ObjectDefID EpisodeAction olmadığı için işlem başlatrılamaz");
                }

                objectContext.FullPartialllyLoadedObjects();
                return defaultEpisodeActionViewModel;
            }
        }

        [HttpGet]
        [Route("{objectDefID}/{episodeID}/{currentStateDefID}")]
        public DefaultEpisodeActionViewModel GetNewSubactionProcedureFlowable(Guid objectDefID, Guid episodeID, Guid currentStateDefID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var defaultEpisodeActionViewModel = new DefaultEpisodeActionViewModel();
                var ttObject = objectContext.CreateObject(objectDefID);
                SetDefaultPropertiesByEpisode(ttObject, episodeID);
                if (ttObject is SubactionProcedureFlowable)
                {
                    SubactionProcedureFlowable subactionProcedureFlowable = (SubactionProcedureFlowable)ttObject;
                    subactionProcedureFlowable.CurrentStateDefID = currentStateDefID;
                    subactionProcedureFlowable.CheckRulesForNewEpisodeAction();
                    defaultEpisodeActionViewModel._SubactionProcedureFlowable = subactionProcedureFlowable;
                    defaultEpisodeActionViewModel._Episode = subactionProcedureFlowable.Episode;
                    defaultEpisodeActionViewModel._MasterResource = subactionProcedureFlowable.MasterResource;
                    defaultEpisodeActionViewModel._FromResource = subactionProcedureFlowable.FromResource;
                    defaultEpisodeActionViewModel._SecondaryMasterResource = subactionProcedureFlowable.SecondaryMasterResource;
                    defaultEpisodeActionViewModel._ProcedureSpeciality = subactionProcedureFlowable.ProcedureSpeciality;
                    defaultEpisodeActionViewModel._ProcedureDoctor = subactionProcedureFlowable.ProcedureDoctor;
                    defaultEpisodeActionViewModel._SubEpisode = subactionProcedureFlowable.SubEpisode;
                }
                else
                {
                    throw new TTUtils.TTException(objectDefID + " ObjectDefID SubactionProcedureFlowable olmadığı için işlem başlatrılamaz");
                }

                objectContext.FullPartialllyLoadedObjects();
                return defaultEpisodeActionViewModel;
            }
        }

        [HttpPost]
        [Route("{objectDefID}/{currentStateDefID}/{masterEpisodeAction}")]
        public DefaultEpisodeActionViewModel GetNewEpisodeActionByMasterEpisodeAction(Guid objectDefID, Guid currentStateDefID, EpisodeAction masterEpisodeAction)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var defaultEpisodeActionViewModel = new DefaultEpisodeActionViewModel();
                var importedMasterEpisodeAction = (EpisodeAction)objectContext.AddObject(masterEpisodeAction);
                var ttObject = objectContext.CreateObject(objectDefID);
                SetDefaultPropertiesByMasterEpisodeAction(ttObject, importedMasterEpisodeAction);
                if (ttObject is EpisodeAction)
                {
                    EpisodeAction episodeAction = (EpisodeAction)ttObject;
                    episodeAction.CurrentStateDefID = currentStateDefID;
                    episodeAction.CheckRulesForNewEpisodeAction();
                    defaultEpisodeActionViewModel._EpisodeAction = episodeAction;
                    defaultEpisodeActionViewModel._Episode = episodeAction.Episode;
                    defaultEpisodeActionViewModel._MasterResource = episodeAction.MasterResource;
                    defaultEpisodeActionViewModel._FromResource = episodeAction.FromResource;
                    defaultEpisodeActionViewModel._SecondaryMasterResource = episodeAction.SecondaryMasterResource;
                    defaultEpisodeActionViewModel._ProcedureSpeciality = episodeAction.ProcedureSpeciality;
                    defaultEpisodeActionViewModel._ProcedureDoctor = episodeAction.ProcedureDoctor;
                    defaultEpisodeActionViewModel._SubEpisode = episodeAction.SubEpisode;
                    defaultEpisodeActionViewModel._MasterAction = episodeAction.MasterAction;
                }
                else
                {
                    throw new TTUtils.TTException(objectDefID + " ObjectDefID EpisodeAction olmadığı için işlem başlatrılamaz");
                }

                objectContext.FullPartialllyLoadedObjects();
                return defaultEpisodeActionViewModel;
            }
        }

        public void SetDefaultPropertiesByEpisode(TTObject ttObject, Guid episodeID)
        {
            if (ttObject is EpisodeAction || ttObject is SubactionProcedureFlowable)
            {
                Episode episode = ttObject.ObjectContext.GetObject(episodeID, typeof (Episode)) as Episode;
                if (episode != null)
                {
                    if (ttObject is EpisodeAction)
                        ((EpisodeAction)ttObject).Episode = episode;
                    if (ttObject is SubactionProcedureFlowable)
                        ((SubactionProcedureFlowable)ttObject).Episode = episode;
                }
            }
        }

        public void SetDefaultPropertiesByMasterEpisodeAction(TTObject ttObject, EpisodeAction masterEpisodeAction)
        {
            if (ttObject is EpisodeAction || ttObject is SubactionProcedureFlowable)
            {
                if (ttObject is EpisodeAction)
                {
                    // Sırası önemli
                    ((EpisodeAction)ttObject).SetMyPropertiesByMasterAction(masterEpisodeAction);
                    ((EpisodeAction)ttObject).FromResource = masterEpisodeAction.MasterResource;
                    ((EpisodeAction)ttObject).MasterAction = masterEpisodeAction;
                    ((EpisodeAction)ttObject).Episode = masterEpisodeAction.Episode;
                }

                if (ttObject is SubactionProcedureFlowable)
                {
                    // Sırası önemli
                    ((SubactionProcedureFlowable)ttObject).SetMyPropertiesByMasterAction(masterEpisodeAction);
                    ((SubactionProcedureFlowable)ttObject).FromResource = masterEpisodeAction.MasterResource;
                    ((SubactionProcedureFlowable)ttObject).Episode = masterEpisodeAction.Episode;
                }
            }
        }
    }
}

namespace Core.Models
{
    public class DefaultEpisodeActionViewModel
    {
        public TTObjectClasses.EpisodeAction _EpisodeAction
        {
            get;
            set;
        }

        public TTObjectClasses.SubactionProcedureFlowable _SubactionProcedureFlowable
        {
            get;
            set;
        }

        public Episode _Episode
        {
            get;
            set;
        }

        public ResSection _MasterResource
        {
            get;
            set;
        }

        public ResSection _FromResource
        {
            get;
            set;
        }

        public ResSection _SecondaryMasterResource
        {
            get;
            set;
        }

        public SpecialityDefinition _ProcedureSpeciality
        {
            get;
            set;
        }

        public ResUser _ProcedureDoctor
        {
            get;
            set;
        }

        public SubEpisode _SubEpisode
        {
            get;
            set;
        }

        public BaseAction _MasterAction
        {
            get;
            set;
        }
    }
}