//$CCC5761C
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Core.Security;
using Newtonsoft.Json;

namespace Core.Controllers
{
    public partial class ChemotherapyRadiotherapyServiceController
    {
        partial void PreScript_ChemotherapyRadiotherapyForm(ChemotherapyRadiotherapyFormViewModel viewModel, ChemotherapyRadiotherapy chemotherapyRadiotherapy, TTObjectContext objectContext)
        {
            MedicalOncology oncologyObject = null;

            if (chemotherapyRadiotherapy.MasterAction != null)
            {
                if (chemotherapyRadiotherapy.MasterAction is PhysicianApplication)
                {
                    oncologyObject = ((PhysicianApplication)chemotherapyRadiotherapy.MasterAction).SpecialityBasedObject.Where(t => t is MedicalOncology).FirstOrDefault() as MedicalOncology;
                    if (oncologyObject == null)
                    {
                        oncologyObject = ((PhysicianApplication)chemotherapyRadiotherapy.CreatedAction).SpecialityBasedObject.Where(t => t is MedicalOncology).FirstOrDefault() as MedicalOncology;

                    }
                }
            }
            var resourceList = new List<Guid>();
            if (chemotherapyRadiotherapy.CreatedAction != null)
            {
                resourceList.Add(((EpisodeAction)chemotherapyRadiotherapy.CreatedAction).MasterResource.ObjectID);
            }
            else if (chemotherapyRadiotherapy.MasterAction != null)
            {
                resourceList.Add(((EpisodeAction)chemotherapyRadiotherapy.MasterAction).MasterResource.ObjectID);
            }

            viewModel.ProcedureRequestFormResourceIDs = resourceList.ToArray();
            if (oncologyObject != null)
            {
                viewModel.patientHeight = oncologyObject.Height;
                viewModel.patientWeight = oncologyObject.Weight;

            }

            BindingList<DiagnosisGrid> diagnosisGrid = new BindingList<DiagnosisGrid>();

            diagnosisGrid = DiagnosisGrid.GetDiagnoseCancerForOncology(objectContext, oncologyObject.PhysicianApplication.SubEpisode.ObjectID);

            if (diagnosisGrid.Count == 0)
            {
                viewModel.diagnoseDate = null;
            }
            else
            {
                DateTime? time = Common.RecTime();
                foreach (DiagnosisGrid diagnosis in diagnosisGrid)
                {
                    if (diagnosis.DiagnoseDate < time)
                    {
                        time = diagnosis.DiagnoseDate;
                    }
                }
                viewModel.diagnoseDate = time;
            }



            foreach (UserResource resource in Common.CurrentResource.UserResources)
            {
                if (resource.Resource.EnabledType == ResourceEnableType.BothInpatientAndOutPatient || resource.Resource.EnabledType == ResourceEnableType.InPatient || resource.Resource.EnabledType == ResourceEnableType.OutPatient || resource.Resource.EnabledType == ResourceEnableType.Secmaster)
                    if (resource.Resource.Store != null)
                    {
                        if (resource.Resource.Store.IsActive == true)
                        {
                            var store = objectContext.GetObject<Store>(resource.Resource.Store.ObjectID);
                            if (viewModel.storeList.Contains(store) == false)
                                viewModel.storeList.Add(store);
                        }
                    }
            }
            var protocolList = chemotherapyRadiotherapy.ChemoRadioCureProtocol.Where(t => t.CurrentStateDefID != ChemoRadioCureProtocol.States.Cancelled).ToList();
            foreach (var cureProtocol in protocolList)
            {
                foreach (var cureProtocolDetail in cureProtocol.ChemoRadioCureProtocolDet.Where(u => u.CurrentStateDefID != ChemoRadioCureProtocolDet.States.Cancelled).ToList())
                {
                    ChemoRadioOrderDetailItem chemoRadioOrderDetailItem = new ChemoRadioOrderDetailItem();
                    chemoRadioOrderDetailItem.ObjectID = cureProtocolDetail.ObjectID;
                    chemoRadioOrderDetailItem.OrderObject = cureProtocol;
                    chemoRadioOrderDetailItem.AppliedDate = cureProtocolDetail.PerformedDate;
                    chemoRadioOrderDetailItem.ApplyType = cureProtocol.ChemotherapyApplyMethod.Name + " - " + cureProtocol.ChemotherapyApplySubMethod.Name;
                    chemoRadioOrderDetailItem.isRadiotherapy = false;
                    if (cureProtocol.IsRadiotherapyCure == true)
                    {
                        chemoRadioOrderDetailItem.Cure = cureProtocol.RadiotherapyXRayTypeDef.Name;
                        chemoRadioOrderDetailItem.isRadiotherapy = true;
                    }
                    else
                    {
                        chemoRadioOrderDetailItem.Cure = cureProtocol.Material != null ? cureProtocol.Material.Name : null;
                        chemoRadioOrderDetailItem.EtkenMadde = cureProtocol.EtkinMadde != null ? cureProtocol.EtkinMadde.etkinMaddeAdi : null;
                        chemoRadioOrderDetailItem.CureSolvent = cureProtocol.Solvent.Name;
                        chemoRadioOrderDetailItem.DrugDose = cureProtocol.DrugDose;
                        chemoRadioOrderDetailItem.SolventDose = cureProtocol.SolventDose;
                        if (cureProtocolDetail.DrugMaterial != null)
                            chemoRadioOrderDetailItem.Store = cureProtocolDetail.DrugMaterial.Store != null ? cureProtocolDetail.DrugMaterial.Store.Name : null;

                    }
                    chemoRadioOrderDetailItem.isAborted = cureProtocolDetail.CurrentStateDefID == ChemoRadioCureProtocolDet.States.Aborted ? true : false;
                    chemoRadioOrderDetailItem.isNew = cureProtocolDetail.CurrentStateDefID == ChemoRadioCureProtocolDet.States.Cure ? true : false;
                    chemoRadioOrderDetailItem.isCompleted = cureProtocolDetail.CurrentStateDefID == ChemoRadioCureProtocolDet.States.Completed ? true : false;
                    chemoRadioOrderDetailItem.Description = cureProtocolDetail.Note;
                    chemoRadioOrderDetailItem.currentState = chemoRadioOrderDetailItem.isNew ? "Uygulama" : chemoRadioOrderDetailItem.isCompleted ? "Tamamlandý" : "Durduruldu";
                    chemoRadioOrderDetailItem.canUndo = cureProtocolDetail.GetStateHistory().Where(t => t.PrevState != null).ToList().Count > 0 ? cureProtocolDetail.CurrentStateDef.IsEntry == true ? false : true : false;
                    var list = cureProtocolDetail.GetStateHistory();
                    viewModel.cureDetails.Add(chemoRadioOrderDetailItem);
                }
            }
            viewModel.TreatmentMaterialGridList = viewModel.TreatmentMaterialGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            objectContext.FullPartialllyLoadedObjects();


            viewModel.storeList = viewModel.storeList.OrderBy(t => t.Name).ToList();
            viewModel.lastSelectedCureProtocol = new ChemoRadioCureProtocol(objectContext);
            viewModel.lastSelectedCureProtocol.ChemotherapyRadiotherapy = chemotherapyRadiotherapy;
            viewModel.lastSelectedCureProtocol.Episode = chemotherapyRadiotherapy.Episode;
            viewModel.lastSelectedCureProtocol.SubEpisode = chemotherapyRadiotherapy.SubEpisode;
            viewModel.lastSelectedCureProtocol.MasterAction = chemotherapyRadiotherapy;
            viewModel.lastSelectedCureProtocol.IsRadiotherapyCure = false;

            var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, viewModel.lastSelectedCureProtocol.ObjectDef.ID, "ChemoRadioCureProtocolTemplate").ToList();
            viewModel.userTemplateList = new List<UserTemplateModel>();
            foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList)
            {
                UserTemplateModel templateModel = new UserTemplateModel();
                templateModel.ObjectID = item.ObjectID;
                templateModel.TAObjectID = item.TAObjectID;
                templateModel.TAObjectDefID = item.TAObjectDefID;
                templateModel.Description = item.Description;
                viewModel.userTemplateList.Add(templateModel);
            }
            //viewModel.lastSelectedCureProtocol.ChemotherapyApplyMethod

            viewModel._EpisodeActionID = chemotherapyRadiotherapy.ObjectID;
            viewModel._EpisodeID = chemotherapyRadiotherapy.SubEpisode.Episode.ObjectID;
            viewModel._PatientID = chemotherapyRadiotherapy.SubEpisode.Episode.Patient.ObjectID;
            if (chemotherapyRadiotherapy.Episode.Patient.BirthDate.HasValue)
            {
                viewModel.patientAge = Common.RecTime().Year - ((DateTime)chemotherapyRadiotherapy.Episode.Patient.BirthDate).Year;
            }
            else
            {
                viewModel.patientAge = 0;
            }
            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();
            if (viewModel.OutgoingTransitions != null)
            {
                foreach (var trans in viewModel.OutgoingTransitions)
                {
                    if (!(trans.ToStateDefID == ChemotherapyRadiotherapy.States.Cancelled || trans.ToStateDefID == ChemotherapyRadiotherapy.States.Completed))
                        removedOutgoingTransitions.Add(trans);

                }
                foreach (var removedtrans in removedOutgoingTransitions)
                {
                    viewModel.OutgoingTransitions.Remove(removedtrans);
                }
            }

            viewModel.PlannedProcedureRequests = GetMyPlannedRequests(chemotherapyRadiotherapy, objectContext).ToArray();
            List<ProcedureForPlannedRequest> details = new List<ProcedureForPlannedRequest>();
            foreach (var item in viewModel.PlannedProcedureRequests)
            {
                foreach (var seconditem in item.ProcedureForPlannedRequest)
                {
                    details.Add(seconditem);
                    var a = seconditem.ProcedureDetailDefinition;
                }
            }
            viewModel.ProcedureForPlannedRequests = details.ToArray();
            viewModel.ProcedureRequestFormDetailDefinitions = objectContext.LocalQuery<ProcedureRequestFormDetailDefinition>().ToArray();
            viewModel.EpisodeObject = chemotherapyRadiotherapy.Episode;
            viewModel.PatientObject = chemotherapyRadiotherapy.Episode.Patient;
            viewModel.PatientSexObject = chemotherapyRadiotherapy.Episode.Patient.Sex;


        }


        partial void PostScript_ChemotherapyRadiotherapyForm(ChemotherapyRadiotherapyFormViewModel viewModel, ChemotherapyRadiotherapy chemotherapyRadiotherapy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            MedicalOncology oncologyObject = null;

            if (chemotherapyRadiotherapy.MasterAction != null)
            {
                if (chemotherapyRadiotherapy.MasterAction is PhysicianApplication)
                {
                    oncologyObject = ((PhysicianApplication)chemotherapyRadiotherapy.MasterAction).SpecialityBasedObject.Where(t => t is MedicalOncology).FirstOrDefault() as MedicalOncology;
                }
            }

            if (oncologyObject != null)
            {
                if (viewModel.patientHeight != oncologyObject.Height)
                {
                    oncologyObject.Height = viewModel.patientHeight;
                    chemotherapyRadiotherapy.Episode.Patient.Heigth = viewModel.patientHeight;
                }
                if (viewModel.patientWeight != oncologyObject.Weight)
                {
                    oncologyObject.Weight = viewModel.patientWeight;
                    chemotherapyRadiotherapy.Episode.Patient.Weight = viewModel.patientWeight;
                }
            }

            if (transDef != null && transDef.ToStateDefID == ChemotherapyRadiotherapy.States.Completed)
            {
                var orderList = chemotherapyRadiotherapy.ChemoRadioCureProtocol.Where(t => t.CurrentStateDefID == ChemoRadioCureProtocol.States.New).ToList();
                var date = Common.RecTime().ToString("dd.MM.yyyy HH:mm");
                foreach (var chemoRadioOrder in orderList)
                {
                    var detailList = chemoRadioOrder.ChemoRadioCureProtocolDet.Where(x => x.CurrentStateDefID == ChemoRadioCureProtocolDet.States.Cure).ToList();
                    foreach (var orderDetail in detailList)
                    {
                        orderDetail.CurrentStateDefID = ChemoRadioCureProtocolDet.States.Aborted;
                        orderDetail.Note += "    " + date + " Tarihinde Tedavi sonlandýrýlýnca durdurulmuþtur.";
                    }
                    chemoRadioOrder.CurrentStateDefID = ChemoRadioCureProtocol.States.Aborted;
                    chemoRadioOrder.CureDescription += "    " + date + " Tarihinde Tedavi sonlandýrýlýnca durdurulmuþtur.";
                }
            }
        }

        partial void AfterContextSaveScript_ChemotherapyRadiotherapyForm(ChemotherapyRadiotherapyFormViewModel viewModel, ChemotherapyRadiotherapy chemotherapyRadiotherapy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null && transDef.ToStateDefID == ChemotherapyRadiotherapy.States.Completed)
            {

                List<string> doctorlist = new List<string>();
                string messageText = "Sayýn " + chemotherapyRadiotherapy.ProcedureByUser.Name + ", " + chemotherapyRadiotherapy.SubEpisode.ProtocolNo + " kabul numaralý; " + chemotherapyRadiotherapy.Episode.Patient.Name + " " + chemotherapyRadiotherapy.Episode.Patient.Surname + " isimli hastanýn Kemoterapi/Radyoterapi tedavisi tamamlanmýþtýr.";
                doctorlist.Add(chemotherapyRadiotherapy.ProcedureByUser.ObjectID.ToString());

                if (doctorlist.Count > 0)
                {
                    TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
                    atlasNotification.users = doctorlist;
                    atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
                    atlasNotification.contentType = TTUtils.AtlasContentType.Action;

                    atlasNotification.content = messageText;
                    var actionData = new { objectDefName = chemotherapyRadiotherapy.ObjectDef.Name, objectID = chemotherapyRadiotherapy.ObjectID, episodeObjectID = chemotherapyRadiotherapy.Episode.ObjectID, patientObjectID = chemotherapyRadiotherapy.Episode.Patient.ObjectID, formDefId = chemotherapyRadiotherapy.CurrentStateDef.FormDefID, inputparam = "" };
                    //ActionData actionData = new ActionData(this.ObjectDef.Name, this.ObjectID, this.CurrentStateDef.FormDefID, "");
                    atlasNotification.actionData = actionData;
                    string notificationStr = JsonConvert.SerializeObject(atlasNotification);

                    TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);

                    var sendChemoRadioSmsParmeter = TTObjectClasses.SystemParameter.GetParameterValue("KEMORADYOTERAPISMSBILGI", "FALSE");
                    if (sendChemoRadioSmsParmeter == "TRUE")
                    {
                        try
                        {
                            UserMessage um = new UserMessage();
                            List<ResUser> users = new List<ResUser> { chemotherapyRadiotherapy.ProcedureByUser };
                            um.SendSMSPerson(users, messageText, SMSTypeEnum.ChemotherapyRadiotherapy);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Sms Gönderilirken Oluþan Hata: " + e.ToString());
                        }
                    }


                }
            }
        }


        public List<PlannedProcedureRequest> GetMyPlannedRequests(ChemotherapyRadiotherapy chemotherapyRadiotherapy, TTObjectContext objectContext)
        {
            List<PlannedProcedureRequest> plannedProcedureRequests = new List<PlannedProcedureRequest>();
            string filterExpression = String.Empty;
            if (chemotherapyRadiotherapy.CurrentStateDefID == ChemotherapyRadiotherapy.States.Completed)
            {
                plannedProcedureRequests = PlannedProcedureRequest.GetPlannedRequestsOnCureComplete(objectContext, chemotherapyRadiotherapy.ObjectID).ToList();
            }
            else if (chemotherapyRadiotherapy.CurrentStateDefID == ChemotherapyRadiotherapy.States.NurseApproved)
            {
                int cureCount = 0;
                foreach (ChemoRadioCureProtocol cureProtocol in chemotherapyRadiotherapy.ChemoRadioCureProtocol)
                {
                    var completedCureDetCount = cureProtocol.ChemoRadioCureProtocolDet.Where(t => t.CurrentStateDefID == ChemoRadioCureProtocolDet.States.Completed).Count();
                    cureCount += completedCureDetCount;
                }
                plannedProcedureRequests = PlannedProcedureRequest.GetPlannedRequestsOnCureCount(objectContext, chemotherapyRadiotherapy.ObjectID).Where(y => y.WhichCure == cureCount).ToList();

            }

            return plannedProcedureRequests;
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Kemoterapi_Radyoterapi_Order_Verme)]
        public bool AddOrUpdateChemoRadioOrder(AddOrUpdateChemoRadioOrder input)
        {
            try
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    if (input.chemoRadioCureProtocol != null && input.procedureObject != null)
                    {
                        ChemoRadioCureProtocol cureProtocol = (ChemoRadioCureProtocol)objectContext.AddObject(input.chemoRadioCureProtocol);
                        ProcedureDefinition procedureObject = (ProcedureDefinition)objectContext.AddObject(input.procedureObject);
                        Store store = null;
                        if (input.store != null)
                            store = (Store)objectContext.AddObject(input.store);
                        //objectContext.AddToRawObjectList(input.chemoRadioCureProtocol);
                        //objectContext.AddToRawObjectList(input.store);
                        if (cureProtocol.CurrentStateDefID == null)
                            cureProtocol.CurrentStateDefID = ChemoRadioCureProtocol.States.New;
                        cureProtocol.Amount = 1;
                        cureProtocol.MasterResource = cureProtocol.ChemotherapyRadiotherapy.MasterResource;
                        cureProtocol.Episode = cureProtocol.ChemotherapyRadiotherapy.Episode;
                        cureProtocol.SubEpisode = cureProtocol.ChemotherapyRadiotherapy.SubEpisode;
                        for (int i = 0; i < input.chemoRadioCureProtocol.CureCount; i++)
                        {
                            ChemoRadioCureProtocolDet chemoRadioCureProtocolDetail = new ChemoRadioCureProtocolDet(objectContext);

                            chemoRadioCureProtocolDetail.ChemoRadioCureProtocol = cureProtocol;
                            chemoRadioCureProtocolDetail.CurrentStateDefID = ChemoRadioCureProtocolDet.States.Cure;
                            chemoRadioCureProtocolDetail.ProcedureObject = procedureObject;
                            chemoRadioCureProtocolDetail.EpisodeAction = cureProtocol.ChemotherapyRadiotherapy;
                            chemoRadioCureProtocolDetail.SubEpisode = cureProtocol.ChemotherapyRadiotherapy.SubEpisode;
                            chemoRadioCureProtocolDetail.Episode = cureProtocol.ChemotherapyRadiotherapy.Episode;
                            chemoRadioCureProtocolDetail.MasterResource = cureProtocol.ChemotherapyRadiotherapy.MasterResource;
                            chemoRadioCureProtocolDetail.ProcedureDoctor = cureProtocol.ChemotherapyRadiotherapy.ProcedureDoctor;


                        }
                        if (cureProtocol.ChemotherapyRadiotherapy.CurrentStateDefID != ChemotherapyRadiotherapy.States.NurseApproved)
                            cureProtocol.ChemotherapyRadiotherapy.CurrentStateDefID = ChemotherapyRadiotherapy.States.DoctorPlanned;
                        objectContext.Save();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Kemoterapi_Radyoterapi_Tedavi_Protokolu_Uygulama)]
        public bool UpdateChemoRadioOrderDetail(UpdateChemoRadioOrderDetail input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ChemoRadioCureProtocolDet cureProtocolDet = objectContext.GetObject<ChemoRadioCureProtocolDet>(input.ObjectID);
                ChemoRadioCureProtocol cureProtocol = cureProtocolDet.ChemoRadioCureProtocol;
                ChemotherapyRadiotherapy chemoRadio = cureProtocol.ChemotherapyRadiotherapy;
                Store store = null;
                if (input.store != null)
                    store = (Store)objectContext.AddObject(input.store);
                if (cureProtocolDet != null)
                {
                    if (input.isAborted == true)
                    {
                        cureProtocolDet.CurrentStateDefID = ChemoRadioCureProtocolDet.States.Aborted;
                        if (input.description != null)
                            cureProtocolDet.Note = input.description;
                    }
                    else if (input.isCancelled == true)
                    {
                        cureProtocolDet.CurrentStateDefID = ChemoRadioCureProtocolDet.States.Cancelled;

                        var cancelledDetailCount = cureProtocol.ChemoRadioCureProtocolDet.Where(t => t.CurrentStateDefID == ChemoRadioCureProtocolDet.States.Cancelled).ToList().Count;
                        if (cancelledDetailCount == cureProtocol.CureCount)
                        {
                            cureProtocol.CurrentStateDefID = ChemoRadioCureProtocol.States.Cancelled;
                        }
                        if (input.description != null)
                            cureProtocolDet.Note = input.description;
                    }
                    else if (input.isCompleted == true)
                    {
                        if (cureProtocol.IsRadiotherapyCure != true)
                        {
                            if (cureProtocolDet.DrugMaterial == null && cureProtocol.Material != null)
                            {
                                BaseTreatmentMaterial drugTreatmentMaterial = new BaseTreatmentMaterial(objectContext);
                                drugTreatmentMaterial.Amount = 1;
                                drugTreatmentMaterial.Material = cureProtocol.Material;
                                drugTreatmentMaterial.Store = store;
                                drugTreatmentMaterial.ActionDate = Common.RecTime();
                                drugTreatmentMaterial.Eligible = true;
                                drugTreatmentMaterial.EpisodeAction = cureProtocol.ChemotherapyRadiotherapy;
                                drugTreatmentMaterial.SubEpisode = cureProtocol.ChemotherapyRadiotherapy.SubEpisode;
                                drugTreatmentMaterial.Episode = cureProtocol.ChemotherapyRadiotherapy.Episode;
                                cureProtocolDet.DrugMaterial = drugTreatmentMaterial;
                            }

                            if (cureProtocolDet.SolutionMaterial == null && cureProtocol.Solvent != null)
                            {
                                BaseTreatmentMaterial solventTreatmentMaterial = new BaseTreatmentMaterial(objectContext);
                                solventTreatmentMaterial.Amount = 1;
                                solventTreatmentMaterial.Material = cureProtocol.Solvent;
                                solventTreatmentMaterial.Store = store;
                                solventTreatmentMaterial.ActionDate = Common.RecTime();
                                solventTreatmentMaterial.Eligible = true;
                                solventTreatmentMaterial.EpisodeAction = cureProtocol.ChemotherapyRadiotherapy;
                                solventTreatmentMaterial.SubEpisode = cureProtocol.ChemotherapyRadiotherapy.SubEpisode;
                                solventTreatmentMaterial.Episode = cureProtocol.ChemotherapyRadiotherapy.Episode;
                                cureProtocolDet.SolutionMaterial = solventTreatmentMaterial;
                            }

                            if (cureProtocolDet.DrugMaterial != null)
                            {
                                cureProtocolDet.DrugMaterial.StockOutOperation();
                            }
                            if (cureProtocolDet.SolutionMaterial != null)
                            {
                                cureProtocolDet.SolutionMaterial.StockOutOperation();
                            }
                            objectContext.Save();
                        }
                        chemoRadio.CurrentStateDefID = ChemotherapyRadiotherapy.States.NurseApproved;

                        cureProtocolDet.CurrentStateDefID = ChemoRadioCureProtocolDet.States.Completed;
                        cureProtocolDet.PerformedDate = Common.RecTime();
                        cureProtocolDet.ProcedureByUser = Common.CurrentResource;
                        var completedDetailCount = cureProtocol.ChemoRadioCureProtocolDet.Where(t => t.CurrentStateDefID != ChemoRadioCureProtocolDet.States.Cure).ToList().Count;
                        if (completedDetailCount == cureProtocol.CureCount)
                        {
                            cureProtocol.CurrentStateDefID = ChemoRadioCureProtocol.States.Completed;
                        }

                        if (input.description != null)
                            cureProtocolDet.Note = input.description;
                    }
                    else if (input.isUndo == true)
                    {
                        if (input.description != null)
                            ((ITTObject)cureProtocolDet).UndoLastTransition(input.description);
                        else
                            ((ITTObject)cureProtocolDet).UndoLastTransition();
                    }


                    objectContext.Save();
                }
            }

            return true;
        }



        [HttpPost]
        public List<UserTemplateModel> SaveProtocolUserTemplate(UserTemplateModel userTemplate)
        {
            List<UserTemplateModel> userTemplatesList = new List<UserTemplateModel>();

            using (var objectContext = new TTObjectContext(false))
            {
                if (userTemplate.ObjectID != null)
                {
                    UserTemplate oldUserTemplate = objectContext.GetObject<UserTemplate>((Guid)userTemplate.ObjectID);
                    oldUserTemplate.FiliterData = "DELETED-ChemoRadioCureProtocolTemplate";
                }
                else
                {
                    UserTemplate newUserTemplate = new UserTemplate(objectContext);
                    newUserTemplate.TAObjectDefID = userTemplate.TAObjectDefID;
                    newUserTemplate.TAObjectID = userTemplate.TAObjectID;
                    newUserTemplate.FiliterData = "ChemoRadioCureProtocolTemplate";
                    newUserTemplate.ResUser = Common.CurrentResource;
                    newUserTemplate.Description = userTemplate.Description;
                }

                objectContext.Save();
                var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, (Guid)userTemplate.TAObjectDefID, "ChemoRadioCureProtocolTemplate").ToList();
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

        [HttpGet]
        public GetTemplateCureProtocolItem GetProtocolItemByTemplate(Guid templateId)
        {
            GetTemplateCureProtocolItem cureProtocolItem = new GetTemplateCureProtocolItem();

            using (var objectContext = new TTObjectContext(false))
            {
                if (templateId != null)
                {
                    UserTemplate userTemplate = objectContext.GetObject<UserTemplate>(templateId);
                    if (userTemplate != null)
                    {
                        var cureProtocol = objectContext.GetObject<ChemoRadioCureProtocol>((Guid)userTemplate.TAObjectID, false);
                        if (cureProtocol != null)
                        {
                            cureProtocolItem.cureProtocol = cureProtocol;
                            if (cureProtocol.IsRadiotherapyCure == null)
                                cureProtocol.IsRadiotherapyCure = false;
                            if (cureProtocol.ChemotherapyApplyMethod != null)
                                cureProtocolItem.ApplyMethod = cureProtocol.ChemotherapyApplyMethod;
                            if (cureProtocol.ChemotherapyApplySubMethod != null)
                                cureProtocolItem.ApplySubMethod = cureProtocol.ChemotherapyApplySubMethod;
                            if (cureProtocol.Material != null)
                                cureProtocolItem.Material = cureProtocol.Material;
                            if (cureProtocol.Solvent != null)
                                cureProtocolItem.Solvent = cureProtocol.Solvent;
                            if (cureProtocol.EtkinMadde != null)
                                cureProtocolItem.EtkinMadde = cureProtocol.EtkinMadde;
                            if (cureProtocol.RadiotherapyXRayTypeDef != null)
                                cureProtocolItem.RadiotherapyXRayTypeDef = cureProtocol.RadiotherapyXRayTypeDef;
                            objectContext.FullPartialllyLoadedObjects();

                            return cureProtocolItem;
                        }
                    }
                }
            }
            return cureProtocolItem;
        }
    }
}

namespace Core.Models
{
    public partial class ChemotherapyRadiotherapyFormViewModel : BaseViewModel
    {
        public DateTime? diagnoseDate { get; set; }
        public double? patientHeight { get; set; }
        public double? patientWeight { get; set; }
        public ChemoRadioCureProtocol lastSelectedCureProtocol { get; set; }
        public Store selectedStore { get; set; }
        public List<Store> storeList = new List<Store>();
        public List<ChemoRadioOrderDetailItem> cureDetails = new List<ChemoRadioOrderDetailItem>();
        public ProcedureDefinition chemoRadioProcedure { get; set; }
        public List<UserTemplateModel> userTemplateList { get; set; }
        public ChemoRadiotherapyMaterial[] TreatmentMaterialGridList { get; set; }
        public Material[] Materials { get; set; }
        public StockCard[] StockCards { get; set; }
        public DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }

        public Guid _EpisodeActionID;
        public Guid _EpisodeID;
        public Guid _PatientID;
        public int patientAge;
        public PlannedProcedureRequest[] PlannedProcedureRequests { get; set; }
        public ProcedureForPlannedRequest[] ProcedureForPlannedRequests { get; set; }
        public ProcedureRequestFormDetailDefinition[] ProcedureRequestFormDetailDefinitions { get; set; }
        public Guid[] ProcedureRequestFormResourceIDs { get; set; }
        public Episode EpisodeObject { get; set; }
        public Patient PatientObject { get; set; }
        public SKRSCinsiyet PatientSexObject { get; set; }

    }

    public class ChemoRadioOrderDetailItem
    {
        public Guid ObjectID { get; set; }
        public ChemoRadioCureProtocol OrderObject { get; set; }
        public DateTime? AppliedDate { get; set; }
        public string EtkenMadde { get; set; }
        public string Cure { get; set; }
        public string CureSolvent { get; set; }
        public int? DrugDose { get; set; }
        public int? SolventDose { get; set; }
        public string ApplyType { get; set; }
        public string Store { get; set; }
        public string Description { get; set; }
        public string currentState { get; set; }
        public bool isCompleted { get; set; }
        public bool isAborted { get; set; }
        public bool isNew { get; set; }
        public bool isRadiotherapy { get; set; }
        public bool canUndo { get; set; }
    }

    public class AddOrUpdateChemoRadioOrder
    {
        public ChemoRadioCureProtocol chemoRadioCureProtocol { get; set; }
        public Store store { get; set; }
        public ProcedureDefinition procedureObject { get; set; }
    }

    public class UpdateChemoRadioOrderDetail
    {
        public Guid ObjectID { get; set; }
        public bool isCancelled { get; set; }
        public bool isAborted { get; set; }
        public bool isCompleted { get; set; }
        public bool isUndo { get; set; }
        public Store store { get; set; }
        public string description { get; set; }
    }

    public class GetTemplateCureProtocolItem
    {
        public ChemoRadioCureProtocol cureProtocol { get; set; }
        public Material Material { get; set; }
        public Material Solvent { get; set; }
        public EtkinMadde EtkinMadde { get; set; }
        public ChemotherapyApplyMethod ApplyMethod { get; set; }
        public ChemotherapyApplySubMethod ApplySubMethod { get; set; }
        public RadiotherapyXRayTypeDef RadiotherapyXRayTypeDef { get; set; }
    }
}
