//$1671D3E5
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class FileCreationAndAnalysisServiceController : Controller
    {
        [HttpGet]
        public FormFCAAArchiveViewModel FormFCAAArchive(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return FormFCAAArchiveLoadInternal(input);
        }

        [HttpPost]
        public FormFCAAArchiveViewModel FormFCAAArchiveLoad(FormLoadInput input)
        {
            return FormFCAAArchiveLoadInternal(input);
        }

        private FormFCAAArchiveViewModel FormFCAAArchiveLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("cda7c522-5d20-40c5-b679-09f8bf0269a5");
            var objectDefID = Guid.Parse("859f21d0-66ae-4751-aa3c-98dd64e850b8");
            var viewModel = new FormFCAAArchiveViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._FileCreationAndAnalysis = objectContext.GetObject(id.Value, objectDefID) as FileCreationAndAnalysis;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._FileCreationAndAnalysis, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._FileCreationAndAnalysis, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._FileCreationAndAnalysis);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._FileCreationAndAnalysis);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_FormFCAAArchive(viewModel, viewModel._FileCreationAndAnalysis, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._FileCreationAndAnalysis = new FileCreationAndAnalysis(objectContext);
                    var entryStateID = Guid.Parse("2a894dd3-31e2-4730-b7f1-35333067a156");
                    viewModel._FileCreationAndAnalysis.CurrentStateDefID = entryStateID;
                    viewModel.PatientEpisodeDetailsGridList = new TTObjectClasses.Episode[] { };
                    //viewModel.FolderContentsGridList = new TTObjectClasses.EpisodeFolderContent[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._FileCreationAndAnalysis, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._FileCreationAndAnalysis, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._FileCreationAndAnalysis);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._FileCreationAndAnalysis);
                    PreScript_FormFCAAArchive(viewModel, viewModel._FileCreationAndAnalysis, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel FormFCAAArchive(FormFCAAArchiveViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("cda7c522-5d20-40c5-b679-09f8bf0269a5");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.Episodes);
                objectContext.AddToRawObjectList(viewModel.Patients);
                objectContext.AddToRawObjectList(viewModel.PatientFolders);
                objectContext.AddToRawObjectList(viewModel.ResBuildings);
                //objectContext.AddToRawObjectList(viewModel.EpisodeFolders);
                //objectContext.AddToRawObjectList(viewModel.PatientFolderContentDefinitions);
                //objectContext.AddToRawObjectList(viewModel.PatientEpisodeDetailsGridList);
                //objectContext.AddToRawObjectList(viewModel.FolderContentsGridList);
                var entryStateID = Guid.Parse("2a894dd3-31e2-4730-b7f1-35333067a156");
                objectContext.AddToRawObjectList(viewModel._FileCreationAndAnalysis, entryStateID);
                objectContext.ProcessRawObjects(false);
                var fileCreationAndAnalysis = (FileCreationAndAnalysis)objectContext.GetLoadedObject(viewModel._FileCreationAndAnalysis.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(fileCreationAndAnalysis, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._FileCreationAndAnalysis, formDefID);
                var episodeImported = fileCreationAndAnalysis.Episode;
                if (episodeImported != null)
                {
                    var patientImported = episodeImported.Patient;
                    if (patientImported != null)
                    {
                        if (viewModel.PatientEpisodeDetailsGridList != null)
                        {
                            foreach (var item in viewModel.PatientEpisodeDetailsGridList)
                            {
                                var episodesImported = (Episode)objectContext.GetLoadedObject(item.ObjectID);
                                if (((ITTObject)episodesImported).IsDeleted)
                                    continue;
                                episodesImported.Patient = patientImported;
                            }
                        }
                    }
                    //var episodeFolderImported = episodeImported.EpisodeFolder;
                    //if (episodeFolderImported != null)
                    //{
                    //    if (viewModel.FolderContentsGridList != null)
                    //    {
                    //        foreach (var item in viewModel.FolderContentsGridList)
                    //        {
                    //            var folderContentsImported = (EpisodeFolderContent)objectContext.GetLoadedObject(item.ObjectID);
                    //            if (((ITTObject)folderContentsImported).IsDeleted)
                    //                continue;
                    //            folderContentsImported.EpisodeFolder = episodeFolderImported;
                    //        }
                    //    }
                    //}
                }

                var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(fileCreationAndAnalysis);
                PostScript_FormFCAAArchive(viewModel, fileCreationAndAnalysis, transDef, objectContext);
                objectContext.AdvanceStateForNewObjects();
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(fileCreationAndAnalysis);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(fileCreationAndAnalysis);
                AfterContextSaveScript_FormFCAAArchive(viewModel, fileCreationAndAnalysis, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();
            }

            return retViewModel;
        }

        partial void PreScript_FormFCAAArchive(FormFCAAArchiveViewModel viewModel, FileCreationAndAnalysis fileCreationAndAnalysis, TTObjectContext objectContext);
        partial void PostScript_FormFCAAArchive(FormFCAAArchiveViewModel viewModel, FileCreationAndAnalysis fileCreationAndAnalysis, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_FormFCAAArchive(FormFCAAArchiveViewModel viewModel, FileCreationAndAnalysis fileCreationAndAnalysis, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(FormFCAAArchiveViewModel viewModel, TTObjectContext objectContext)
        {
            var episode = viewModel._FileCreationAndAnalysis.Episode;
            if (episode != null)
            {
                var patient = episode.Patient;
                if (patient != null)
                {
                    viewModel.PatientEpisodeDetailsGridList = patient.Episodes.OfType<Episode>().ToArray();
                }
                //var episodeFolder = episode.EpisodeFolder;
                //if (episodeFolder != null)
                //{
                //    viewModel.FolderContentsGridList = episodeFolder.FolderContents.OfType<EpisodeFolderContent>().ToArray();
                //}
            }

            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            viewModel.PatientFolders = objectContext.LocalQuery<PatientFolder>().ToArray();
            viewModel.ResBuildings = objectContext.LocalQuery<ResBuilding>().ToArray();
            viewModel.ResArchiveRooms = objectContext.LocalQuery<ResArchiveRoom>().ToArray();
            viewModel.ResCabinet = objectContext.LocalQuery<ResCabinet>().ToArray();
            viewModel.ResShelves = objectContext.LocalQuery<ResShelf>().ToArray();

            if (ResBuilding.GetBuildingList("").ToArray().Length == 1)
            {
                viewModel.ResBuildings = new ResBuilding[1];
                var a = ResBuilding.GetBuildingList("").ToArray();
                viewModel.ResBuildings[0] = objectContext.GetObject<ResBuilding>(a[0].ObjectID.Value);
            }

            //viewModel.EpisodeFolders = objectContext.LocalQuery<EpisodeFolder>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BuildinglistDefinition", viewModel.ResBuildings);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CabinetListDefinition", viewModel.ResCabinet);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ArchiveRoomListDef", viewModel.ResArchiveRooms);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ShelfListDefinition", viewModel.ResShelves);

            //viewModel.PatientFolderContentDefinitions = objectContext.LocalQuery<PatientFolderContentDefinition>().ToArray();
            //ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PatientFolderContentListDefinition", viewModel.PatientFolderContentDefinitions);
        }
    }
}


namespace Core.Models
{
    public partial class FormFCAAArchiveViewModel : BaseViewModel
    {
        public TTObjectClasses.FileCreationAndAnalysis _FileCreationAndAnalysis { get; set; }
        public TTObjectClasses.Episode[] PatientEpisodeDetailsGridList { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.PatientFolder[] PatientFolders { get; set; }
        public TTObjectClasses.ResBuilding[] ResBuildings { get; set; }
        public TTObjectClasses.ResArchiveRoom[] ResArchiveRooms { get; set; }
        public TTObjectClasses.ResCabinet[] ResCabinet { get; set; }
        public TTObjectClasses.ResShelf[] ResShelves { get; set; }


    }
}
