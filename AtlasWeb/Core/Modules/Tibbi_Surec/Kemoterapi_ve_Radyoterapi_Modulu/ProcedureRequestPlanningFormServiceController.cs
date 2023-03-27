//$B7C4A3D8
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class ProcedureRequestPlanningFormServiceController : Controller
    {
        [HttpGet]
        public ProcedureRequestPlanningFormViewModel getViewModel(Guid episodeActionId, Guid? templateId = null)
        {
            ProcedureRequestPlanningFormViewModel viewModel = new ProcedureRequestPlanningFormViewModel();

            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                Guid UnitResource = Guid.Empty;
                viewModel.PlannedProcedureRequest = new PlannedProcedureRequest(objectContext);
                if (templateId != null)
                {
                    UserTemplate templateObject = objectContext.GetObject<UserTemplate>((Guid)templateId);
                    PlannedProcedureRequest templateRequest = objectContext.GetObject<PlannedProcedureRequest>((Guid)templateObject.TAObjectID);
                    List<ProcedureRequestFormDetailDefinition> defList = new List<ProcedureRequestFormDetailDefinition>();
                    foreach (var req in templateRequest.ProcedureForPlannedRequest)
                    {
                        defList.Add(req.ProcedureDetailDefinition);
                    }
                    viewModel.FormDetailDefinitions = defList.ToArray();
                }
                viewModel.PlannedProcedureRequest.IsOnCureCount = true;
                viewModel.PlannedProcedureRequest.IsOnTreatmentComplete = false;

                viewModel.PlannedProcedureRequest.PlannedBy = Common.CurrentResource;
                viewModel.PlannedUser = Common.CurrentResource;
                viewModel.PlannedProcedureRequest.ForPlannedEpisodeAction = objectContext.GetObject<EpisodeAction>(episodeActionId);
                if (viewModel.PlannedProcedureRequest.ForPlannedEpisodeAction is ChemotherapyRadiotherapy)
                {
                    if (((ChemotherapyRadiotherapy)viewModel.PlannedProcedureRequest.ForPlannedEpisodeAction).CreatedAction != null)
                        UnitResource = ((EpisodeAction)((ChemotherapyRadiotherapy)viewModel.PlannedProcedureRequest.ForPlannedEpisodeAction).CreatedAction).MasterResource.ObjectID;
                    else
                        UnitResource = ((EpisodeAction)((ChemotherapyRadiotherapy)viewModel.PlannedProcedureRequest.ForPlannedEpisodeAction).MasterAction).MasterResource.ObjectID;
                }
                else
                {
                    UnitResource = viewModel.PlannedProcedureRequest.ForPlannedEpisodeAction.MasterResource.ObjectID;
                }
                var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, viewModel.PlannedProcedureRequest.ObjectDef.ID, "PlannedProcedureRequestTemplate").ToList();
                viewModel.userTemplateList = new List<UserTemplateModel>();
                foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList.Where(t => t.TAObjectID.ToString() != viewModel.PlannedProcedureRequest.ObjectID.ToString()))
                {
                    UserTemplateModel templateModel = new UserTemplateModel();
                    templateModel.ObjectID = item.ObjectID;
                    templateModel.TAObjectID = item.TAObjectID;
                    templateModel.TAObjectDefID = item.TAObjectDefID;
                    templateModel.Description = item.Description;
                    viewModel.userTemplateList.Add(templateModel);
                }
                List<Guid> ResourceList = new List<Guid>();
                ResourceList.Add(UnitResource);
                viewModel.FormUnitList = GetProcedureSelectionFormItems(objectContext, ResourceList);
                var OldPlannedRequestList = PlannedProcedureRequest.GetPlannedProcedureRequests(objectContext, "WHERE FORPLANNEDEPISODEACTION='" + episodeActionId + "'");
                foreach (PlannedProcedureRequest oldPlannedProcedureRequest in OldPlannedRequestList)
                {
                    OldPlannedRequest request = new OldPlannedRequest();
                    request.ObjectId = oldPlannedProcedureRequest.ObjectID;
                    request.IsApplied = oldPlannedProcedureRequest.PlanApplyDate == null ? "Uygulanmadý" : "Uygulandý";
                    request.PlannedBy = oldPlannedProcedureRequest.PlannedBy.Name;
                    request.PlannedDate = oldPlannedProcedureRequest.CreationDate.Value;
                    request.WhenWillApply = oldPlannedProcedureRequest.IsOnCureCount == true ? oldPlannedProcedureRequest.WhichCure.Value + ". Kür" : "Tedavi Tamamlandýðýnda";
                    request.HasTemplate = userTemplateList.Where(t => t.TAObjectID == oldPlannedProcedureRequest.ObjectID).FirstOrDefault() != null ? true : false;
                    request.FormDetailDefinitionList = new List<ProcedureRequestFormDetailDefinition>();
                    foreach (ProcedureForPlannedRequest procedure in oldPlannedProcedureRequest.ProcedureForPlannedRequest)
                    {
                        request.FormDetailDefinitionList.Add(procedure.ProcedureDetailDefinition);
                    }
                    viewModel.OldPlannedRequests.Add(request);
                }
                var ProcedureDefinitionList = new List<ProcedureDefinition>();
                foreach (var formUnit in viewModel.FormUnitList)
                {
                    foreach (var formCategory in formUnit.FormCategories)
                    {
                        foreach (var categoryItem in formCategory.FormDetailDefinitionList)
                        {
                            ProcedureDefinitionList.Add(categoryItem.ProcedureDefinition);
                        }
                    }
                }
                viewModel.ProcedureDefinitions = ProcedureDefinitionList.ToArray();
                objectContext.FullPartialllyLoadedObjects();
                //viewModel.FormDetailDefinitions = objectContext.QueryObjects<ProcedureRequestFormDetailDefinition>().ToList();
            }
            return viewModel;
        }

        [HttpGet]
        public ProcedureRequestPlanningFormViewModel CreateProcedurePlanningRequest(ProcedureRequestPlanningFormViewModel viewModel)
        {
            ProcedureRequestPlanningFormViewModel returnModel = new ProcedureRequestPlanningFormViewModel();

            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                var plannedProcedureRequest = objectContext.AddObject(viewModel.PlannedProcedureRequest);
                viewModel.PlannedUser = Common.CurrentResource;
                var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, viewModel.PlannedProcedureRequest.ObjectDef.ID, "PlannedProcedureRequestTemplate").ToList();
                viewModel.userTemplateList = new List<UserTemplateModel>();
                foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList.Where(t => t.TAObjectID.ToString() != viewModel.PlannedProcedureRequest.ObjectID.ToString()))
                {
                    UserTemplateModel templateModel = new UserTemplateModel();
                    templateModel.ObjectID = item.ObjectID;
                    templateModel.TAObjectID = item.TAObjectID;
                    templateModel.TAObjectDefID = item.TAObjectDefID;
                    templateModel.Description = item.Description;
                    viewModel.userTemplateList.Add(templateModel);
                }
                List<Guid> ResourceList = new List<Guid>();
                ResourceList.Add(viewModel.PlannedProcedureRequest.ForPlannedEpisodeAction.MasterResource.ObjectID);
                viewModel.FormUnitList = GetProcedureSelectionFormItems(objectContext, ResourceList);
                var ProcedureDefinitionList = new List<ProcedureDefinition>();
                foreach (var formUnit in viewModel.FormUnitList)
                {
                    foreach (var formCategory in formUnit.FormCategories)
                    {
                        foreach (var categoryItem in formCategory.FormDetailDefinitionList)
                        {
                            ProcedureDefinitionList.Add(categoryItem.ProcedureDefinition);
                        }
                    }
                }
                viewModel.ProcedureDefinitions = ProcedureDefinitionList.ToArray();
                objectContext.FullPartialllyLoadedObjects();
                //viewModel.FormDetailDefinitions = objectContext.QueryObjects<ProcedureRequestFormDetailDefinition>().ToList();
            }
            return viewModel;
        }

        [HttpPost]
        public bool savePlanningForm(ProcedureRequestPlanningFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.FormDetailDefinitions.ToList());
                objectContext.AddToRawObjectList(viewModel.PlannedProcedureRequest);
                objectContext.ProcessRawObjects(false);
                var PlannedProcedureRequest = (PlannedProcedureRequest)objectContext.GetLoadedObject(viewModel.PlannedProcedureRequest.ObjectID);
                PlannedProcedureRequest.CreationDate = Common.RecTime();
                foreach (var plannedProcedure in viewModel.FormDetailDefinitions)
                {
                    var procedure = (ProcedureRequestFormDetailDefinition)objectContext.GetLoadedObject(plannedProcedure.ObjectID);
                    if (procedure != null)
                    {
                        ProcedureForPlannedRequest procedureForPlannedRequest = new ProcedureForPlannedRequest(objectContext);
                        procedureForPlannedRequest.ProcedureDetailDefinition = procedure;
                        procedureForPlannedRequest.PlannedProcedureRequest = PlannedProcedureRequest;
                    }
                }
                objectContext.Save();
            }
            return true;
        }

        [HttpPost]
        public List<UserTemplateModel> SavePlannedProcedureRequestUserTemplate(UserTemplateModel userTemplate)
        {
            List<UserTemplateModel> userTemplatesList = new List<UserTemplateModel>();

            using (var objectContext = new TTObjectContext(false))
            {
                if (userTemplate.ObjectID != null)
                {
                    UserTemplate oldUserTemplate = objectContext.GetObject<UserTemplate>((Guid)userTemplate.ObjectID);
                    oldUserTemplate.FiliterData = "DELETED-PlannedProcedureRequestTemplate";
                }
                else
                {
                    UserTemplate newUserTemplate = new UserTemplate(objectContext);
                    newUserTemplate.TAObjectDefID = userTemplate.TAObjectDefID;
                    newUserTemplate.TAObjectID = userTemplate.TAObjectID;
                    newUserTemplate.FiliterData = "PlannedProcedureRequestTemplate";
                    newUserTemplate.ResUser = Common.CurrentResource;
                    newUserTemplate.Description = userTemplate.Description;
                }

                objectContext.Save();
                var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, (Guid)userTemplate.TAObjectDefID, "PlannedProcedureRequestTemplate").ToList();
                foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList)
                {
                    UserTemplateModel templateModel = new UserTemplateModel();
                    templateModel.ObjectID = item.ObjectID;
                    templateModel.TAObjectID = item.TAObjectID;
                    templateModel.TAObjectDefID = item.TAObjectDefID;
                    templateModel.Description = item.Description;
                    userTemplatesList.Add(templateModel);
                }
            }
            return userTemplatesList;
        }


        public List<ProcedureFormUnit> GetProcedureSelectionFormItems(TTObjectContext objContext, List<Guid> resourceIDList)
        {
            //var ttProcedureRequestFormDefinitionList = TTObjectClasses.ProcedureRequestFormDefinition.GetForms(objContext, "");
            BindingList<RequestUnitOfProcedureForm> ttRequestUnitOfProcedureFormList = TTObjectClasses.RequestUnitOfProcedureForm.GetFormsByResourceIDs(objContext, resourceIDList);
            List<ProcedureFormUnit> unitList = new List<ProcedureFormUnit>();

            foreach (RequestUnitOfProcedureForm ttRequestUnitOfProcedureForm in ttRequestUnitOfProcedureFormList)
            {
                var procedureRequestFormDefinition = new ProcedureFormUnit();
                procedureRequestFormDefinition.ObjectID = ttRequestUnitOfProcedureForm.ProcedureRequestFormDef.ObjectID;
                procedureRequestFormDefinition.UnitName = ttRequestUnitOfProcedureForm.ProcedureRequestFormDef.Name;
                foreach (var ttProcedureRequestFormCategory in ttRequestUnitOfProcedureForm.ProcedureRequestFormDef.FormCategory.ToList().OrderBy(dr => dr.OrderNo))
                {
                    var procedureRequestFormCategory = new ProcedureFormCategory();
                    procedureRequestFormCategory.ObjectID = ttProcedureRequestFormCategory.ObjectID;
                    procedureRequestFormCategory.CategoryName = ttProcedureRequestFormCategory.CategoryName;


                    var categoryDetailsList = ttProcedureRequestFormCategory.FormDetail.ToList().OrderBy(dr => dr.OrderNo).ToList();
                    bool addGridFormDetails = false;
                    foreach (var categoryFormDetail in categoryDetailsList)
                    {
                        addGridFormDetails = true;
                        //Aktif olmayan  tetkiklerin istem paneline hic yuklenmemesi saglandi.
                        if (categoryFormDetail.ProcedureDefinition.IsActive != null && (bool)categoryFormDetail.ProcedureDefinition.IsActive == true)
                        {
                            if (categoryFormDetail.ProcedureDefinition is LaboratoryTestDefinition)
                            {
                                if (((LaboratoryTestDefinition)categoryFormDetail.ProcedureDefinition).IsSubTest != null && ((LaboratoryTestDefinition)categoryFormDetail.ProcedureDefinition).IsSubTest == true)
                                    addGridFormDetails = false;
                            }
                            if (addGridFormDetails)
                            {
                                if (categoryFormDetail.ProcedureDefinition is LaboratoryTestDefinition)
                                {
                                    if (((LaboratoryTestDefinition)categoryFormDetail.ProcedureDefinition).BoundedTests.Count > 0)
                                    {
                                        List<ProcedureRequestFormDetailDefinition> boundedList = new List<ProcedureRequestFormDetailDefinition>();
                                        foreach (LaboratoryGridBoundedTestDefinition boundedTestDef in ((LaboratoryTestDefinition)categoryFormDetail.ProcedureDefinition).BoundedTests)
                                        {
                                            //Bounded testin formdetail ini bulup collectiona ekle
                                            ProcedureDefinition boundedProcedureDefinition = (ProcedureDefinition)boundedTestDef.LaboratoryTest;
                                            BindingList<ProcedureRequestFormDetailDefinition> procedureRequestFormDetailList = ProcedureRequestFormDetailDefinition.GetProcedureRequestFormDetailByProcedureDefinition(objContext, boundedProcedureDefinition.ObjectID);

                                            foreach (ProcedureRequestFormDetailDefinition reqFormDetDef in procedureRequestFormDetailList)
                                            {
                                                if (reqFormDetDef.ProcedureRequestCategory.ProcedureRequestForm.ObjectID.ToString() == categoryFormDetail.ProcedureRequestCategory.ProcedureRequestForm.ObjectID.ToString())
                                                {
                                                    boundedList.Add(reqFormDetDef);
                                                }
                                            }
                                        }
                                        if (boundedList.Count > 0)
                                        {
                                            categoryFormDetail.ProcedureDefinition.Name += " (Baðlý Testler: ";
                                            foreach (var item in boundedList)
                                            {
                                                if (item.ProcedureDefinition.Name.Contains("Baðlý Testler:"))
                                                {
                                                    categoryFormDetail.ProcedureDefinition.Name += item.ProcedureDefinition.Code + "-" + item.ProcedureDefinition.Name.Substring(0, item.ProcedureDefinition.Name.IndexOf(" (Baðlý Testler:")) + ", ";
                                                }
                                                else
                                                {
                                                    categoryFormDetail.ProcedureDefinition.Name += item.ProcedureDefinition.Code + "-" + item.ProcedureDefinition.Name + ", ";
                                                }

                                            }
                                            categoryFormDetail.ProcedureDefinition.Name = categoryFormDetail.ProcedureDefinition.Name.Remove(categoryFormDetail.ProcedureDefinition.Name.LastIndexOf(",")) + ")";
                                        }
                                    }
                                }
                                if (procedureRequestFormCategory.FormDetailDefinitionList == null)
                                    procedureRequestFormCategory.FormDetailDefinitionList = new List<ProcedureRequestFormDetailDefinition>();
                                procedureRequestFormCategory.FormDetailDefinitionList.Add(categoryFormDetail);
                            }

                        }
                    }
                    if (procedureRequestFormDefinition.FormCategories == null)
                        procedureRequestFormDefinition.FormCategories = new List<ProcedureFormCategory>();
                    procedureRequestFormDefinition.FormCategories.Add(procedureRequestFormCategory);
                }
                unitList.Add(procedureRequestFormDefinition);
            }
            return unitList;
        }
    }
}

namespace Core.Models
{
    public class ProcedureRequestPlanningFormViewModel
    {
        public PlannedProcedureRequest PlannedProcedureRequest { get; set; }
        public ResUser PlannedUser { get; set; }
        public List<UserTemplateModel> userTemplateList { get; set; }
        public ProcedureRequestFormDetailDefinition[] FormDetailDefinitions = new ProcedureRequestFormDetailDefinition[0];
        public ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public List<ProcedureFormUnit> FormUnitList { get; set; }
        public List<OldPlannedRequest> OldPlannedRequests = new List<OldPlannedRequest>();
    }

    public class ProcedureFormUnit
    {
        public Guid ObjectID { get; set; }
        public string UnitName { get; set; }
        public List<ProcedureFormCategory> FormCategories { get; set; }
    }

    public class ProcedureFormCategory
    {
        public Guid ObjectID { get; set; }
        public string CategoryName { get; set; }
        public List<ProcedureRequestFormDetailDefinition> FormDetailDefinitionList { get; set; }
    }

    public class OldPlannedRequest
    {
        public Guid ObjectId { get; set; }
        public string PlannedBy { get; set; }
        public DateTime PlannedDate { get; set; }
        public string WhenWillApply { get; set; }
        public string IsApplied { get; set; }
        public List<ProcedureRequestFormDetailDefinition> FormDetailDefinitionList { get; set; }
        public bool HasTemplate { get; set; }
    }
}