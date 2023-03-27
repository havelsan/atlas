//$07F3D108
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class DiagnosisGridServiceController : Controller
    {

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public vmNewDiagnosisGrid GetNewDiagnosisGrid([FromQuery] Boolean isEpisodeBaseDentalEpisodeAction, [FromQuery] string episodeActionId)
        {
            vmNewDiagnosisGrid _vmNewDiagnosisGrid = new vmNewDiagnosisGrid();
            using (var objectContext = new TTObjectContext(false))
            {
                DiagnosisGrid newDiagnosisGrid = new DiagnosisGrid(objectContext);
                if (isEpisodeBaseDentalEpisodeAction == true) // dişin tanı gridi farklı
                    newDiagnosisGrid = new BaseDentalEpisodeActionDiagnosisGrid(objectContext);
                //if (!string.IsNullOrEmpty(diagnoseObjectid)) Clientta atılıyor
                //    newDiagnosisGrid.Diagnose = (DiagnosisDefinition)objectContext.GetObject(new Guid(diagnoseObjectid),"DiagnosisDefinition");
                //newDiagnosisGrid.DiagnosisType = DiagnosisTypeEnum.Seconder;
                //newDiagnosisGrid.IsMainDiagnose = false;
                var episodeActionList = EpisodeAction.GetEpisodeActionByID(objectContext, episodeActionId);
                if (episodeActionList.Count > 0)
                {
                    EpisodeActionWithDiagnosis episodeAction = episodeActionList[0] as EpisodeActionWithDiagnosis;
                    if (episodeAction != null)
                    {
                        newDiagnosisGrid.EpisodeAction = episodeAction;
                        newDiagnosisGrid.EntryActionType = episodeAction.ActionType;

                        if (episodeAction.ProcedureDoctor != null)
                        {
                            newDiagnosisGrid.ResponsibleDoctor = episodeAction.ProcedureDoctor;
                            _vmNewDiagnosisGrid.ResponsibleDoctor = episodeAction.ProcedureDoctor;
                        }
                        if (episodeAction.Episode != null)
                        {
                            newDiagnosisGrid.Episode = episodeAction.Episode;
                        }

                        _vmNewDiagnosisGrid.StarterAction = Common.GetDisplayTextOfDataTypeEnum(episodeAction.ActionType);
                    }
                }
                _vmNewDiagnosisGrid.DiagnosisGrid = newDiagnosisGrid;
            }
            return _vmNewDiagnosisGrid;
        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<vmDiagnosisGridReadOnly> GetDiagnosisGridReadOnlyForm([FromQuery] string episodeActionOrSubEpisodeObjectID)
        {
            List<vmDiagnosisGridReadOnly> vmDiagnosisGridReadOnlyFormList = new List<vmDiagnosisGridReadOnly>();
            using (var objectContext = new TTObjectContext(true))
            {
                SubEpisode subEpisode = null;
                var episodeActionList = EpisodeAction.GetEpisodeActionByID(objectContext, episodeActionOrSubEpisodeObjectID);
                if (episodeActionList.Count > 0)
                {
                    subEpisode = episodeActionList[0].SubEpisode;
                }
                else
                {
                    subEpisode = objectContext.GetObject(new Guid(episodeActionOrSubEpisodeObjectID), typeof(SubEpisode)) as SubEpisode;
                }

                if (subEpisode != null)
                {
                    var diagnosisGridList = DiagnosisGrid.GetBySubEpisode(objectContext, subEpisode.ObjectID.ToString());
                    foreach (var diagnose in diagnosisGridList)
                    {
                        var viewModelDianosisGrid = new vmDiagnosisGridReadOnly();
                        if (diagnose.Diagnose != null)
                            viewModelDianosisGrid.Diagnosis = diagnose.Diagnose.Code + ' ' + diagnose.Diagnose.Name;
                        if (diagnose.DiagnosisType != null)
                            viewModelDianosisGrid.DiagnosisType = (DiagnosisTypeEnum)diagnose.DiagnosisType;
                        if (diagnose.IsMainDiagnose != null)
                            viewModelDianosisGrid.IsMainDiagnose = (bool)diagnose.IsMainDiagnose;
                        if (diagnose.ResponsibleDoctor != null)
                            viewModelDianosisGrid.ResponsibleDoctor = diagnose.ResponsibleDoctor.Name;
                        if (diagnose.EntryActionType != null)
                            viewModelDianosisGrid.EntryActionType = Common.GetDisplayTextOfDataTypeEnum(diagnose.EntryActionType);
                        vmDiagnosisGridReadOnlyFormList.Add(viewModelDianosisGrid);
                    }
                }
            }
            return vmDiagnosisGridReadOnlyFormList;
        }
        // daha sonra silinebilir 
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public vmDiagnosisGridFormDefinitionsParameter GetReadOnlyDiagnosisByEpisodeActionId([FromQuery] string episodeActionOrSubEpisodeObjectID) // ReadOnly olarak Açılırsa
        {
            var viewModelDianosisGrid = new vmDiagnosisGridFormDefinitionsParameter();
            using (var objectContext = new TTObjectContext(true))
            {
                SubEpisode subepisode = null;
                var episodeActionList = EpisodeAction.GetEpisodeActionByID(objectContext, episodeActionOrSubEpisodeObjectID);
                if (episodeActionList.Count > 0)
                {
                    subepisode = episodeActionList[0].SubEpisode;
                }
                else
                {
                    subepisode = objectContext.GetObject(new Guid(episodeActionOrSubEpisodeObjectID), typeof(SubEpisode)) as SubEpisode;
                }

                if (subepisode != null)
                {
                    viewModelDianosisGrid.GridDiagnosisGridList = DiagnosisGrid.GetBySubEpisode(objectContext, subepisode.ObjectID.ToString()).ToArray();
                    List<DiagnosisDefinition> diagnosisDefList = new List<DiagnosisDefinition>();
                    foreach (var gridDiagnosisGrid in viewModelDianosisGrid.GridDiagnosisGridList)
                    {
                        if (!diagnosisDefList.Contains(gridDiagnosisGrid.Diagnose))
                            diagnosisDefList.Add(gridDiagnosisGrid.Diagnose);
                    }

                    viewModelDianosisGrid.DiagnosisDefinitions = diagnosisDefList.ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModelDianosisGrid;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DiagnosisGridFormViewModel DiagnosisGridFormDefinitions(vmDiagnosisGridFormDefinitionsParameter _vmDiagnosisGridFormDefinitionsParameter)
        {
            var viewModel = new DiagnosisGridFormViewModel();
            if (_vmDiagnosisGridFormDefinitionsParameter != null && _vmDiagnosisGridFormDefinitionsParameter.GridDiagnosisGridList != null)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    List<DiagnosisDefinition> diagnosisDefList = new List<DiagnosisDefinition>();
                    List<ResUser> resuserDefList = new List<ResUser>();
                    foreach (var gridDiagnosisGrid in _vmDiagnosisGridFormDefinitionsParameter.GridDiagnosisGridList)
                    {
                        var importedDiagnosis = (DiagnosisGrid)objectContext.AddObject(gridDiagnosisGrid);
                        if (importedDiagnosis.Diagnose != null)
                        {
                            if (!diagnosisDefList.Contains(importedDiagnosis.Diagnose))
                                diagnosisDefList.Add(importedDiagnosis.Diagnose);
                        }

                        if (importedDiagnosis.ResponsibleDoctor != null)
                        {
                            if (!resuserDefList.Contains(importedDiagnosis.ResponsibleDoctor))
                                resuserDefList.Add(importedDiagnosis.ResponsibleDoctor);
                        }
                        //if (importedDiagnosis.ResponsibleUser != null)
                        //{
                        //    if (!resuserDefList.Contains(importedDiagnosis.ResponsibleUser))
                        //        resuserDefList.Add(importedDiagnosis.ResponsibleUser);
                        //}
                    }

                    viewModel.DiagnosisDefinitions = diagnosisDefList.ToArray();
                    viewModel.ResUsers = resuserDefList.ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DiagnosisGridFormViewModel DiagnosisGridFormFilterExpression()
        {
            var viewModel = new DiagnosisGridFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.DiagnosisListFilterExpression = GetDiagnosisListFilter(objectContext);
            }

            return viewModel;
        }


        //// DiagnosisSelectionForm için
        public BindingList<FavoriteDiagnosis> CurrenUserFavoriteDiagnosis(TTObjectContext objectContext, bool showMainDiagnose) // GridFavoriteDiagnosis
        {
            if (showMainDiagnose == false)
                return FavoriteDiagnosis.GetFavoriteDiagnosis(objectContext, Common.CurrentResource.ObjectID.ToString(), " AND THIS.DIAGNOSE.ISLEAF=1");
            return FavoriteDiagnosis.GetFavoriteDiagnosis(objectContext, Common.CurrentResource.ObjectID.ToString());
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DiagnosisGridFormViewModel DiagnosisQuickSelectionData([FromQuery] string episodeObjectId, [FromQuery] string procedureSpecialityObjectId)
        {
            var viewModel = new DiagnosisGridFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                Dictionary<Guid, DiagnosisDefinition> diagnosisDefList = new Dictionary<Guid, DiagnosisDefinition>();
                var episode = objectContext.GetObject(new Guid(episodeObjectId), typeof(Episode)) as Episode;
                if (episode != null)
                {
                    bool anaTaniGoster = TTObjectClasses.SystemParameter.GetParameterValue("ANATANIGOSTER", "FALSE") == "FALSE" ? false : true;

                    var favoriteDiagnosis = this.CurrenUserFavoriteDiagnosis(objectContext, anaTaniGoster);
                    viewModel.FavoriteDiagnosisList = favoriteDiagnosis.ToArray();
                    int dayPeriod = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("LIMITDAYOFTOP10DIAGNOSISOFUSER", "30"));
                    string filter = anaTaniGoster == false ? "AND THIS.DIAGNOSE.ISLEAF=1 " : string.Empty;
                    var Top10DiagnosisDefinitionOfUser = DiagnosisGrid.GetTop10DiagnosisDefinitionOfUser(Common.CurrentResource.ObjectID.ToString(), Common.RecTime().AddDays(-1 * dayPeriod),filter);
                    viewModel.Top10DiagnosisDefinitionOfUserList = Top10DiagnosisDefinitionOfUser.ToArray();
                    filter = filter != string.Empty ? " AND THIS:DIAGNOSE.ISLEAF=1 " : string.Empty;
                    var Last10DiagnosisOfPatient = DiagnosisGrid.GetLast10DiagnosisOfPatient(episode.Patient.ObjectID.ToString(), procedureSpecialityObjectId, filter);
                    viewModel.Last10DiagnosisOfPatientList = Last10DiagnosisOfPatient.ToArray();
                    List<vmEpisodeDiagnosisGrid> EpisodeDiagnosisGridList = new List<vmEpisodeDiagnosisGrid>();
                    foreach (var favoriteDiagnose in favoriteDiagnosis)
                    {
                        if (favoriteDiagnose.Diagnose != null)
                        {
                            if (!diagnosisDefList.ContainsKey(favoriteDiagnose.Diagnose.ObjectID))
                                diagnosisDefList.Add(favoriteDiagnose.Diagnose.ObjectID, favoriteDiagnose.Diagnose);
                        }
                    }

                    foreach (var Top10DiagnoseDefinitionOfUser in Top10DiagnosisDefinitionOfUser)
                    {
                        if (Top10DiagnoseDefinitionOfUser.Diagnoseobjectid != null)
                        {
                            if (!diagnosisDefList.ContainsKey((Guid)Top10DiagnoseDefinitionOfUser.Diagnoseobjectid))
                            {
                                var Top10Diagnose = objectContext.GetObject((Guid)Top10DiagnoseDefinitionOfUser.Diagnoseobjectid, "DiagnosisDefinition") as DiagnosisDefinition;
                                diagnosisDefList.Add(Top10Diagnose.ObjectID, Top10Diagnose);
                            }
                        }
                    }

                    foreach (var Last10DiagnoseOfPatient in Last10DiagnosisOfPatient)
                    {
                        if (Last10DiagnoseOfPatient.Diagnoseobjectid != null)
                        {
                            if (!diagnosisDefList.ContainsKey((Guid)Last10DiagnoseOfPatient.Diagnoseobjectid))
                            {
                                var Last10Diagnose = objectContext.GetObject((Guid)Last10DiagnoseOfPatient.Diagnoseobjectid, "DiagnosisDefinition") as DiagnosisDefinition;
                                diagnosisDefList.Add(Last10Diagnose.ObjectID, Last10Diagnose);
                            }
                        }
                    }
                    foreach (var episodeDiagnosisGrid in episode.Diagnosis)
                    {
                        bool checkEpisodeDiagnosisAdding = false;
                        vmEpisodeDiagnosisGrid _vmEpisodeDiagnosisGrid = new vmEpisodeDiagnosisGrid();
                        _vmEpisodeDiagnosisGrid.DiagnosisGrid = episodeDiagnosisGrid;
                        if (episodeDiagnosisGrid.Diagnose != null)
                        {
                            if (anaTaniGoster == false)
                            {
                                if (episodeDiagnosisGrid.Diagnose.IsLeaf == true)
                                {
                                    _vmEpisodeDiagnosisGrid.DiagnoseObjectID = episodeDiagnosisGrid.Diagnose.ObjectID.ToString();
                                    _vmEpisodeDiagnosisGrid.DiagnoseName = episodeDiagnosisGrid.Diagnose.Code.ToString() + "-" + episodeDiagnosisGrid.Diagnose.Name.ToString();
                                    if (!diagnosisDefList.ContainsKey((Guid)episodeDiagnosisGrid.Diagnose.ObjectID))
                                    {
                                        diagnosisDefList.Add(episodeDiagnosisGrid.Diagnose.ObjectID, episodeDiagnosisGrid.Diagnose);
                                    }
                                    checkEpisodeDiagnosisAdding = true;
                                }
                            }
                            else
                            {
                                _vmEpisodeDiagnosisGrid.DiagnoseObjectID = episodeDiagnosisGrid.Diagnose.ObjectID.ToString();
                                _vmEpisodeDiagnosisGrid.DiagnoseName = episodeDiagnosisGrid.Diagnose.Code.ToString() + "-" + episodeDiagnosisGrid.Diagnose.Name.ToString();
                                if (!diagnosisDefList.ContainsKey((Guid)episodeDiagnosisGrid.Diagnose.ObjectID))
                                {
                                    diagnosisDefList.Add(episodeDiagnosisGrid.Diagnose.ObjectID, episodeDiagnosisGrid.Diagnose);
                                }
                                checkEpisodeDiagnosisAdding = true;
                            }

                        }
                        if(checkEpisodeDiagnosisAdding == true)
                            EpisodeDiagnosisGridList.Add(_vmEpisodeDiagnosisGrid);
                    }
                    viewModel.EpisodeDiagnosisGridList = EpisodeDiagnosisGridList.ToArray();
                    viewModel.DiagnosisDefinitions = diagnosisDefList.Values.ToArray();
                    objectContext.FullPartialllyLoadedObjects();// BaseDentalDiagnosisGrid serilase olamıyordu o yüzden eklend
                }
            }
            return viewModel;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void SaveFavoriteDiagnose([FromQuery] Guid diagnoseDefinitionObjectId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var currentUserFavoriteDiagnosis = this.CurrenUserFavoriteDiagnosis(objectContext, true);
                if (currentUserFavoriteDiagnosis.FirstOrDefault(dr => dr.Diagnose.ObjectID == diagnoseDefinitionObjectId) == null)
                {
                    FavoriteDiagnosis favoriteDiagnosis = new FavoriteDiagnosis(objectContext);
                    var favoriteDiagnosisDef = objectContext.GetObject(diagnoseDefinitionObjectId, "DiagnosisDefinition") as DiagnosisDefinition;
                    if (favoriteDiagnosisDef != null)
                    {
                        favoriteDiagnosis.Diagnose = favoriteDiagnosisDef;
                        favoriteDiagnosis.User = Common.CurrentResource;
                        favoriteDiagnosis.Order = currentUserFavoriteDiagnosis.Count();
                    }

                    objectContext.Save();
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void RemoveFavoriteDiagnose([FromQuery] Guid diagnoseDefinitionObjectId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var favoriteDiagnosisListToRemove = FavoriteDiagnosis.GetFavoriteDiagnosisByUserAndDiagnose(objectContext, Common.CurrentResource.ObjectID.ToString(), diagnoseDefinitionObjectId.ToString());
                foreach (var favoriteDiagnosisToRemove in favoriteDiagnosisListToRemove)
                {
                    ((ITTObject)favoriteDiagnosisToRemove).Delete();
                }

                objectContext.Save();
            }
        }

        //[HttpGet]
        //[AtlasRequiredRoles(TTRoleNames.Everyone)]
        //public ENabizDataSets[] CheckENabiz([FromQuery] Guid DiagnoseObjectID)
        //{
        //    List<ENabizDataSets> nabizList = new List<ENabizDataSets>();
        //    bool isENabizActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("ISNABIZACTIVE", "TRUE"));
        //    if (isENabizActive)
        //    {
        //        using (var objectContext = new TTObjectContext(false))
        //        {
        //            var selectedDiagnosis = objectContext.GetObject(DiagnoseObjectID, "DiagnosisDefinition") as DiagnosisDefinition;
        //            if (selectedDiagnosis != null)
        //            {
        //                BindingList<SKRSICDMSVSIliskisi> msvsList = SKRSICDMSVSIliskisi.GetSkrsICDMSVSIliskisiByICDKODU(objectContext, selectedDiagnosis.Code);
        //                for (int i = 0; i < msvsList.Count; i++)
        //                {
        //                    BindingList<ENabizDataSetDefinition> nList = ENabizDataSetDefinition.GetENabizDataSetDefinitionByMSVSCode(objectContext, Convert.ToInt32(msvsList[i].MSVSKODU));
        //                    for (int j = 0; j < nList.Count; j++)
        //                    {
        //                        ENabizDataSets dataset = new ENabizDataSets();
        //                        dataset.PackageID = Convert.ToInt32(nList[j].PackageID);
        //                        dataset.PackageName = nList[j].PackageName.ToString();
        //                        dataset.DiagnosisObjectID = DiagnoseObjectID;
        //                        nabizList.Add(dataset);
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return nabizList.ToArray();
        //}

        public ENabizDataSets[] CheckENabiz(TTObjectContext objectContext, DiagnosisDefinition diagnosisDefinition)
        {
            if (diagnosisDefinition != null)
            {
                List<ENabizDataSets> nabizList = new List<ENabizDataSets>();
                bool isENabizActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("ISNABIZACTIVE", "TRUE"));
                if (isENabizActive)
                {

                    BindingList<SKRSICDMSVSIliskisi> msvsList = SKRSICDMSVSIliskisi.GetSkrsICDMSVSIliskisiByICDKODU(objectContext, diagnosisDefinition.Code);
                    for (int i = 0; i < msvsList.Count; i++)
                    {
                        BindingList<ENabizDataSetDefinition> nList = ENabizDataSetDefinition.GetENabizDataSetDefinitionByMSVSCode(objectContext, Convert.ToInt32(msvsList[i].MSVSKODU));
                        for (int j = 0; j < nList.Count; j++)
                        {
                            ENabizDataSets dataset = new ENabizDataSets();
                            dataset.PackageID = Convert.ToInt32(nList[j].PackageID);
                            dataset.PackageName = nList[j].PackageName.ToString();
                            dataset.DiagnosisObjectID = diagnosisDefinition.ObjectID;
                            nabizList.Add(dataset);
                        }
                    }
                }

                return nabizList.ToArray();
            }
            return null;
        }



        private DiagnosisActionSuggestionViewModel CreateDiagnosisActionSuggestionViewModel(TTObjectContext objectContext, ProcedureDefinition procedureDefinition, Guid diagnosisDefinitionObjectID, List<Guid> resourceIDList)
        {
            DiagnosisActionSuggestionViewModel diagnosisActionSuggestionViewModel = new DiagnosisActionSuggestionViewModel();
            diagnosisActionSuggestionViewModel.DiagnosisObjectId = diagnosisDefinitionObjectID;
            diagnosisActionSuggestionViewModel.ChoosedByUser = false;
            // şimdilik kullanılmıyo
            //if (diagnosisActionSuggestion.ActionType != null)
            //    diagnosisActionSuggestionViewModel.ActionType = (ActionTypeEnum)diagnosisActionSuggestion.ActionType;
            diagnosisActionSuggestionViewModel.ProcedureName = procedureDefinition.Code + "-" + procedureDefinition.Name;
            diagnosisActionSuggestionViewModel.ProcedureObjectId = procedureDefinition.ObjectID;

            diagnosisActionSuggestionViewModel.IsAdditionalApplication = false;
            if (procedureDefinition is SurgeryDefinition)
            {
                var surgeryDefinition = (SurgeryDefinition)procedureDefinition;
                if (surgeryDefinition.SurgeryProcedureType == SurgeyProcedureTypeEnum.OnlyAdditionalApplication || surgeryDefinition.SurgeryProcedureType == SurgeyProcedureTypeEnum.ManipulationAdditionalApplication)
                    diagnosisActionSuggestionViewModel.IsAdditionalApplication = true;
            }
            if (!diagnosisActionSuggestionViewModel.IsAdditionalApplication)
            {
                var procedureRequestFormDetailList = ProcedureRequestFormDetailDefinition.GetFormDetailByProcedureDefAndResources(objectContext, procedureDefinition.ObjectID, resourceIDList);
                foreach (var procedureRequestFormDetail in procedureRequestFormDetailList)
                {
                    diagnosisActionSuggestionViewModel.ProcedureRequestFormDetailObjectId = procedureRequestFormDetail.ObjectID;
                    break;
                }
            }
            //Default değer
            diagnosisActionSuggestionViewModel.CreateProcedure = true;
            return diagnosisActionSuggestionViewModel;
        }

        public DiagnosisActionSuggestionViewModel[] GetDiagnosisActionSuggestion(TTObjectContext objectContext, DiagnosisDefinition diagnosisDefinition, Guid? RequestUnitResourceId)
        {
            if (diagnosisDefinition != null)
            {
                List<DiagnosisActionSuggestionViewModel> diagnosisActionSuggestionViewModelList = new List<DiagnosisActionSuggestionViewModel>();
                List<Guid> resourceIDList = new List<Guid>();
                if (RequestUnitResourceId != null)
                    resourceIDList.Add((Guid)RequestUnitResourceId); // istek yapılan birim
                resourceIDList.Add(Common.CurrentResource.ObjectID);// istek yapılan kişi
                foreach (DiagnosisActionSuggestion diagnosisActionSuggestion in diagnosisDefinition.DiagnosisActionSuggestions.Select("ISACTIVE = 1"))
                {
                    //DiagnosisActionSuggestionViewModel diagnosisActionSuggestionViewModel = new DiagnosisActionSuggestionViewModel();
                    //diagnosisActionSuggestionViewModel.DiagnosisObjectId = diagnosisDefinition.ObjectID;
                    //diagnosisActionSuggestionViewModel.ChoosedByUser = false;
                    //// şimdilik kullanılmıyo
                    ////if (diagnosisActionSuggestion.ActionType != null)
                    ////    diagnosisActionSuggestionViewModel.ActionType = (ActionTypeEnum)diagnosisActionSuggestion.ActionType;
                    //diagnosisActionSuggestionViewModel.ProcedureName = diagnosisActionSuggestion.ProcedureDefinition.Code + "-" + diagnosisActionSuggestion.ProcedureDefinition.Name;
                    //diagnosisActionSuggestionViewModel.ProcedureObjectId = diagnosisActionSuggestion.ProcedureDefinition.ObjectID;

                    //diagnosisActionSuggestionViewModel.IsAdditionalApplication = false;
                    //if(diagnosisActionSuggestion.ProcedureDefinition is SurgeryDefinition)
                    //{
                    //    var surgeryDefinition = (SurgeryDefinition)diagnosisActionSuggestion.ProcedureDefinition;
                    //    if (surgeryDefinition.SurgeryProcedureType == SurgeyProcedureTypeEnum.OnlyAdditionalApplication || surgeryDefinition.SurgeryProcedureType == SurgeyProcedureTypeEnum.ManipulationAdditionalApplication)
                    //        diagnosisActionSuggestionViewModel.IsAdditionalApplication = true;
                    //}
                    //if (!diagnosisActionSuggestionViewModel.IsAdditionalApplication)
                    //{
                    //    var procedureRequestFormDetailList = ProcedureRequestFormDetailDefinition.GetFormDetailByProcedureDefAndResources(objectContext, diagnosisActionSuggestion.ProcedureDefinition.ObjectID, resourceIDList);
                    //    foreach (var procedureRequestFormDetail in procedureRequestFormDetailList)
                    //    {
                    //        diagnosisActionSuggestionViewModel.ProcedureRequestFormDetailObjectId = procedureRequestFormDetail.ObjectID;
                    //        break;
                    //    }
                    //}
                    ////Default değer
                    //diagnosisActionSuggestionViewModel.CreateProcedure = true;

                    DiagnosisActionSuggestionViewModel diagnosisActionSuggestionViewModel = this.CreateDiagnosisActionSuggestionViewModel(objectContext, diagnosisActionSuggestion.ProcedureDefinition, diagnosisDefinition.ObjectID, resourceIDList);
                    diagnosisActionSuggestionViewModelList.Add(diagnosisActionSuggestionViewModel);
                }
                return diagnosisActionSuggestionViewModelList.ToArray();
            }
            return null;
        }


        public PhysicianSuggestionDefViewModel[] GetPhysicianSuggestionDef(TTObjectContext objectContext, DiagnosisDefinition diagnosisDefinition, Guid? RequestUnitResourceId)
        {
            if (diagnosisDefinition != null)
            {
                List<PhysicianSuggestionDefViewModel> physicianSuggestionDefViewModelList = new List<PhysicianSuggestionDefViewModel>();
                List<Guid> resourceIDList = new List<Guid>();
                if (RequestUnitResourceId != null)
                    resourceIDList.Add((Guid)RequestUnitResourceId); // istek yapılan birim
                resourceIDList.Add(Common.CurrentResource.ObjectID);// istek yapılan kişi

                foreach (PhysicianSuggestionDef physicianSuggestionDefWithDiagnose in diagnosisDefinition.PhysicianSuggestionDefs.Select("ISACTIVE = 1"))
                {

                    var physicianSuggestionDefGroupList = PhysicianSuggestionDef.GetByGroupName(objectContext, physicianSuggestionDefWithDiagnose.GrupName);

                    foreach (var physicianSuggestionDef in physicianSuggestionDefGroupList)
                    {
                        PhysicianSuggestionDefViewModel physicianSuggestionDefViewModel = new PhysicianSuggestionDefViewModel();

                        if (physicianSuggestionDef.DiagnosisDefinition != null)
                            physicianSuggestionDefViewModel.DiagnosisObjectId = physicianSuggestionDef.DiagnosisDefinition.ObjectID;
                        physicianSuggestionDefViewModel.GrupName = physicianSuggestionDef.GrupName.Trim();
                        physicianSuggestionDefViewModel.PhysicianSuggestionDefObjectId = physicianSuggestionDef.ObjectID;
                        if (physicianSuggestionDef.ParentPhysicianSuggestionDef != null)
                            physicianSuggestionDefViewModel.ParentPhysicianSuggestionDefObjectId = physicianSuggestionDef.ParentPhysicianSuggestionDef.ObjectID;
                        physicianSuggestionDefViewModel.ReturnValueOfParent = physicianSuggestionDef.ReturnValueOfParent;
                        physicianSuggestionDefViewModel.Message = physicianSuggestionDef.Message;
                        physicianSuggestionDefViewModel.ButtonCaptions = physicianSuggestionDef.ButtonCaptions;
                        physicianSuggestionDefViewModel.ReturnValues = physicianSuggestionDef.ReturnValues;

                        if (physicianSuggestionDef.ProcedureDefinition != null)
                        {
                            DiagnosisActionSuggestionViewModel diagnosisActionSuggestionViewModel = this.CreateDiagnosisActionSuggestionViewModel(objectContext, physicianSuggestionDef.ProcedureDefinition, diagnosisDefinition.ObjectID, resourceIDList);
                            physicianSuggestionDefViewModel.diagnosisActionSuggestionViewModel = diagnosisActionSuggestionViewModel;
                        }
                        physicianSuggestionDefViewModelList.Add(physicianSuggestionDefViewModel);
                    }
                }
                return physicianSuggestionDefViewModelList.ToArray();
            }
            return null;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DiagnoseObjectSelectionViewModel GetDiagnoseObjectSelectionViewModel([FromQuery] Guid DiagnoseObjectID, [FromQuery] bool CheckENabiz, [FromQuery] bool SuggestProcedureByDiagnosis, [FromQuery] Guid? RequestUnitResourceId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var selectedDiagnosis = objectContext.GetObject(DiagnoseObjectID, "DiagnosisDefinition") as DiagnosisDefinition;
                if (selectedDiagnosis != null)
                {
                    DiagnoseObjectSelectionViewModel diagnoseObjectSelectionViewModel = new DiagnoseObjectSelectionViewModel();
                    if (CheckENabiz)
                        diagnoseObjectSelectionViewModel.ENabizDataSets = this.CheckENabiz(objectContext, selectedDiagnosis);
                    if (SuggestProcedureByDiagnosis)
                    {
                        diagnoseObjectSelectionViewModel.DiagnosisActionSuggestions = this.GetDiagnosisActionSuggestion(objectContext, selectedDiagnosis, RequestUnitResourceId);
                        diagnoseObjectSelectionViewModel.PhysicianSuggestionDefs = GetPhysicianSuggestionDef(objectContext, selectedDiagnosis, RequestUnitResourceId);
                    }
                    return diagnoseObjectSelectionViewModel;
                }
            }
            return null;
        }


        public class OLAP_GetLastDiagnosis_Input
        {
            public string EID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeActionWithDiagnosis.OLAP_GetLastDiagnosis_Class> OLAP_GetLastDiagnosis(OLAP_GetLastDiagnosis_Input input)
        {
            var ret = EpisodeActionWithDiagnosis.OLAP_GetLastDiagnosis(input.EID);
            return ret;
        }

        public class OLAP_GetEpisodeDiagnosis_Input
        {
            public string EID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<EpisodeActionWithDiagnosis.OLAP_GetEpisodeDiagnosis_Class> OLAP_GetEpisodeDiagnosis(OLAP_GetEpisodeDiagnosis_Input input)
        {
            var ret = EpisodeActionWithDiagnosis.OLAP_GetEpisodeDiagnosis(input.EID);
            return ret;
        }

        private string GetDiagnosisListFilter(TTObjectContext objectContext)
        {
            string filterString = "";
            UserOption uo = Common.CurrentResource.GetUserOption(UserOptionType.ICDFilter);
            if (uo != null && uo.Value != null && uo.Value.ToString() == "OPEN")
            {
                System.Collections.Generic.List<SpecialityDefinition> specialityList = new System.Collections.Generic.List<SpecialityDefinition>();
                string parentGroupIDs = "";
                foreach (UserResource uRes in Common.CurrentResource.UserResources)
                {
                    foreach (ResourceSpecialityGrid specGrid in uRes.Resource.ResourceSpecialities)
                    {
                        if (specialityList.Contains(specGrid.Speciality) == false)
                            specialityList.Add(specGrid.Speciality);
                    }
                }

                foreach (SpecialityDefinition speciality in specialityList)
                {
                    BindingList<DiagnoseSpecialityMatching> matchingList = DiagnoseSpecialityMatching.GetBySpeciality(objectContext, speciality.ObjectID.ToString());
                    foreach (DiagnoseSpecialityMatching dsm in matchingList)
                    {
                        foreach (DiagnosisGridForMatching dgm in dsm.Diagnosis)
                        {
                            parentGroupIDs += "'" + dgm.DiagnosisDefinition.ObjectID + "',";
                        }
                    }
                }

                if (parentGroupIDs != "")
                {
                    filterString = " (OBJECTID IN (" + parentGroupIDs.Substring(0, parentGroupIDs.Length - 1) + "))";
                    //filterString += " OR PARENTGROUP IN (" + parentGroupIDs.Substring(0,parentGroupIDs.Length-1) + "))";
                }
                else
                    filterString = " 1=0";
            }

            return filterString;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DiagnosisDefinition> GetHighRiskyPregnantDefiniton()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DiagnosisDefinition> highRiskyDefList = DiagnosisDefinition.GetDiagnosisDefinitions(objectContext," WHERE HighRiskPregnancy = 1").ToList();
                return highRiskyDefList;
            }
        }
    }
}