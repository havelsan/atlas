using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections;
using TTStorageManager.Security;
using TTUtils;
using TTDefinitionManagement;
using TTInstanceManagement;
using System.Net.Http;
using System.ComponentModel;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Modules.Tibbi_Surec.Laboratuar_Is_Listesi
{
    public partial class LaboratoryWorkListServiceController : Controller
    {
        //SortedList<string, TTObjectDef> _filteredObjectDefList;
        //SortedList<Guid, SortedList<string, TTObjectStateDef>> _filteredObjectStateDefList;
        public static WorkListDefinition workListDefinition;
        public class QueryInputDVO
        {
            public static void SetInitialValues(ref QueryInputDVO queryInputDVO, DateTime serverTime)
            {
                if (queryInputDVO.StartDate.HasValue == false)
                    queryInputDVO.StartDate = serverTime.BeginOfDate();
                else
                    queryInputDVO.StartDate = Convert.ToDateTime(queryInputDVO.StartDate).BeginOfDate();

                if (queryInputDVO.EndDate.HasValue == false)
                    queryInputDVO.EndDate = serverTime.EndOfDate();
                else
                    queryInputDVO.EndDate = Convert.ToDateTime(queryInputDVO.EndDate).EndOfDate();

                queryInputDVO.MinDate = DateTimeExtensions.MinValue1900();// Convert.ToDateTime("01.01.1900 00:00:00");
            }

            public string txtPatient
            {
                get;
                set;
            }

            public string txtSEProtocolNo
            {
                get;
                set;
            }

            public DateTime? StartDate
            {
                get;
                set;
            }

            public DateTime? EndDate
            {
                get;
                set;
            }

            public DateTime? MinDate
            {
                get;
                set;
            }

            public string StateType
            {
                get;
                set;
            }

            public string PatientStatus
            {
                get;
                set;
            }

            public string ID
            {
                get;
                set;
            }

            public int? WorkListCount
            {
                get;
                set;
            }

            public List<EpisodeActionWorkListItem> SelectedWorkListItems
            {
                get;
                set;
            }

            public List<EpisodeActionWorkListStateItem> SelectedWorkListStateItems
            {
                get;
                set;
            }

            public List<UserResourceItem> UserResourceItems
            {
                get;
                set;
            }

            public List<UserResourceItem> SelectedUserResourceItems
            {
                get;
                set;
            }

            public string SelectedQueueObjectID
            {
                get;
                set;
            }
        }

        public class QueryInputDVOByEpisode
        {
            public string PatientObjectID
            {
                get;
                set;
            }
            public string EpisodeID
            {
                get;
                set;
            }

            public DateTime? StartDate
            {
                get;
                set;
            }

            public DateTime? EndDate
            {
                get;
                set;
            }

            public string PatientStatus
            {
                get;
                set;
            }

            public List<EpisodeActionWorkListStateItem> SelectedWorkListStateItems
            {
                get;
                set;
            }

            public string LabRequestObjectID
            {
                get;
                set;
            }
        }

        private void setWorkListDefinition()
        {
            //TODO BB, worklistdef i şimdilik böyle çektim. Değişecek
            //Laboratuvar İş Listesi cekildi 
            if (workListDefinition == null)
            {
                TTObjectContext objectContext = new TTObjectContext(true);
                workListDefinition = (WorkListDefinition)objectContext.GetObject(new Guid("869bc4de-8200-4428-865d-f3cd4b809c0d"), "WorkListDefinition");
            }
        }

        private SpecialPanelListItem createNewSpecialPanelListItem(SpecialPanelDefinition pDef)
        {
            SpecialPanelListItem specialPanelListItem = new SpecialPanelListItem();
            specialPanelListItem.Name = pDef.Name;
            specialPanelListItem.Caption = pDef.Caption;
            specialPanelListItem.ObjectID = pDef.ObjectID.ToString();
            specialPanelListItem.SpecialPanelCriteriaValues = new List<SpecialPanelCriteriaVal>();
            if (pDef.CriteriaValues != null)
            {
                foreach (SpecialPanelCriteriaValue pCriteria in pDef.CriteriaValues)
                {
                    SpecialPanelCriteriaVal cVal = new SpecialPanelCriteriaVal();
                    cVal.Name = pCriteria.Name;
                    cVal.ObjectID = pCriteria.ObjectID.ToString();
                    cVal.Value = pCriteria.Value;
                    specialPanelListItem.SpecialPanelCriteriaValues.Add(cVal);
                }
            }

            return specialPanelListItem;
        }

        internal static IEnumerable<string> GetParentFolders(TTModuleDef moduleDef)
        {
            yield return TTUtils.Globals.GetModuleName(moduleDef.Name);
            Guid? folderDefId = moduleDef.FolderDefID;
            while (folderDefId != null)
            {
                TTFolderDef folderDef = null;
                if (TTObjectDefManager.Instance.FolderDefs.ContainsKey(folderDefId))
                {
                    folderDef = TTObjectDefManager.Instance.FolderDefs[folderDefId];
                    yield return TTUtils.Globals.GetModuleName(folderDef.CodeName);
                    folderDefId = folderDef.ParentFolderDefID;
                }

                if (!folderDefId.HasValue)
                    yield break;
            }
        }

        [HttpGet]
        public DynamicComponentInfoDVO GetDynamicComponentPatientInfo([FromQuery] string ObjectId)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                TTObject obj = objectContext.GetObject(new Guid(ObjectId), typeof(LaboratoryProcedure));
                var subFolders = GetParentFolders(obj.ObjectDef.ModuleDef);
                var folderPath = "Tibbi_Surec/Hasta_Demografik_Bilgileri"; //string.Join("/", subFolders.Reverse());
                var moduleName = "PatientDemographicsModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();
                var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
                dynamicComponentInfo.ComponentName = "PatientDemographicsForm"; // obj.CurrentStateDef.FormDef.CodeName;
                dynamicComponentInfo.ModuleName = moduleName;
                dynamicComponentInfo.ModulePath = modulePath;
                dynamicComponentInfo.objectID = ObjectId;
                objectContext.FullPartialllyLoadedObjects();
                return dynamicComponentInfo;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Laboratuvar_Numune_Alma_Islem_Geri_Alma, TTRoleNames.Laboratuvar_Numune_Kabul_Islem_Geri_Alma)]
        public void UndoLastTransitionLabProcedureByObjectId(string ObjectId)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            var subactionProcedureFlowable = objectContext.GetObject(new Guid(ObjectId), typeof(SubactionProcedureFlowable)) as SubactionProcedureFlowable;
            ((ITTObject)subactionProcedureFlowable).UndoLastTransition();
            objectContext.Save();

        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Laboratuvar_Istek_Kabul_Iptal, TTRoleNames.Laboratuvar_Numune_Alma_Iptal, TTRoleNames.Laboratuvar_Numune_Kabul_Iptal)]
        public void CancelLabProcedureByObjectId(string ObjectId)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            var subactionProcedureFlowable = objectContext.GetObject(new Guid(ObjectId), typeof(SubactionProcedureFlowable)) as SubactionProcedureFlowable;
            ((ITTObject)subactionProcedureFlowable).Cancel();
            objectContext.Save();
        }

        public class TubeInformation
        {
            public string SpecimenID
            {
                get;
                set;
            }

            public string ContainerID
            {
                get;
                set;
            }

            public string SpecialHandlingCode
            {
                get;
                set;
            }

            public string OtherEnvFactor
            {
                get;
                set;
            }

            public string FromResourceName
            {
                get;
                set;
            }
            public string RequestAcceptionDate
            {
                get;
                set;
            }
        }

        public class ProcedureInformation
        {
            public string PlacerOrderNumber
            {
                get;
                set;
            } //HBYS ObjectID

            public string PlacerGroupNumber
            {
                get;
                set;
            } //BarcodeID
        }

        public class ProcedureInfoInputDVO
        {
            public string EpisodeID
            {
                get;
                set;
            }

            public string SpecimenID
            {
                get;
                set;
            }

            public List<string> LabProcedures
            {
                get;
                set;
            }
            public string LabRequestObjectID
            {
                get;
                set;
            }
        }

        public class ProcedureInfoOutputDVO
        {
            public string SpecimenID
            {
                get;
                set;
            }

            public List<TubeInformation> TubeInformations
            {
                get;
                set;
            }

            public List<ProcedureInformation> LabProcedures
            {
                get;
                set;
            }
        }

        public class ProcedureResultInfoInputDVO
        {
            public List<ProcedureResultInfo> LabProceduresResultInfo
            {
                get;
                set;
            }
        }

        public class ProcedureResultInfo
        {
            public string LaboratoryProcedureObjectID
            {
                get;
                set;
            }

            public DateTime ResultDate
            {
                get;
                set;
            }

            public string Result
            {
                get;
                set;
            }

            public string Unit
            {
                get;
                set;
            }

            public string Reference
            {
                get;
                set;
            }

            public List<ProcedureResultInfo> SubProceduresResultInfo
            {
                get;
                set;
            }
        }

        [HttpPost]
        public LaboratoryWorkListFormViewModel QueryLaboratorySampleAcceptList(QueryInputDVO inputdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                DateTime serverTime = Common.RecTime();
                QueryInputDVO.SetInitialValues(ref inputdvo, serverTime);

                LaboratoryWorkListFormViewModel model = new LaboratoryWorkListFormViewModel();

                setWorkListDefinition();
                if (workListDefinition.LastSpecialPanel == null)
                {
                    IList pDefs = SpecialPanelDefinition.GetByUserAndWorkListDef(objectContext, Common.CurrentResource.ObjectID.ToString(), workListDefinition.ObjectID.ToString()); //inMemory_Context olmalı
                    foreach (SpecialPanelDefinition pDef in pDefs)
                    {
                        if (pDef.Name == "@DEFAULT@")
                        {
                            TTObjectContext objectContextEditable = new TTObjectContext(false);
                            WorkListDefinition workListDefinitionEditable = (WorkListDefinition)objectContextEditable.GetObject(workListDefinition.ObjectID, typeof(WorkListDefinition));
                            workListDefinitionEditable.LastSpecialPanel = pDef;
                            SpecialPanelListItem lastSpecialPanelListItem = createNewSpecialPanelListItem(pDef);
                            model.LastSelectedSpecialPanel = lastSpecialPanelListItem;
                            objectContextEditable.Save();
                            break;
                        }
                    }
                }

                string filterExpression = string.Empty;
                if (string.IsNullOrEmpty(inputdvo.StateType) == false)
                    filterExpression += " AND CURRENTSTATE IS " + inputdvo.StateType;
                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    filterExpression += " AND THIS:SUBEPISODE:PATIENTSTATUS IN (" + inputdvo.PatientStatus + ")";

                /*
                if (!String.IsNullOrEmpty(inputdvo.txtPatient))
                {
                    //PatientSearch componenti kullanıldığı için değiştirildi.
                    filterExpression += " AND THIS:EPISODE:PATIENT:OBJECTID = '" + inputdvo.txtPatient + "'";
                }

                if (!String.IsNullOrEmpty(inputdvo.txtSEProtocolNo))
                {
                    filterExpression += " AND THIS:SUBEPISODE:PROTOCOLNO = '" + inputdvo.txtSEProtocolNo + "'";
                }
                */

                if (inputdvo.SelectedWorkListItems != null && inputdvo.SelectedWorkListItems.Count > 0)
                {
                    List<Guid> objectDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListItem wli in inputdvo.SelectedWorkListItems)
                    {
                        objectDefIDs.Add(new Guid(wli.ObjectDefID));
                    }

                    filterExpression += Common.CreateFilterExpressionOfGuidList(filterExpression, "OBJECTDEFID", objectDefIDs);
                }

                List<string> selectedLabStates = new List<string>();
                if (inputdvo.SelectedWorkListStateItems != null && inputdvo.SelectedWorkListStateItems.Count > 0)
                {
                    List<Guid> stateDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListStateItem wlsi in inputdvo.SelectedWorkListStateItems)
                    {
                        stateDefIDs.Add(new Guid(wlsi.StateDefID));
                        selectedLabStates.Add(wlsi.StateDefID);
                    }

                    filterExpression += Common.CreateFilterExpressionOfGuidList(filterExpression, "CURRENTSTATEDEFID", stateDefIDs);
                }

                //Ayaktan Hasta ise isteyen klinik secimi olmayacak tum polk.ler listeye gelecek
                //Yatan hasta ise isteyen klinik alanında ResClinic tipindeki resource icin listeleme yapilacak
                if (inputdvo.PatientStatus != "0,3")
                {
                    List<Guid> selectedResourceList = new List<Guid>();
                    if (inputdvo.SelectedUserResourceItems != null && inputdvo.SelectedUserResourceItems.Count > 0)
                    {
                        List<ResSection> selectedWorkListResources = new List<ResSection>();
                        foreach (UserResourceItem userResourceItem in inputdvo.SelectedUserResourceItems)
                        {
                            ResSection resource = objectContext.GetObject<ResSection>(new Guid(userResourceItem.ResourceID));
                            if (resource is ResClinic)
                                selectedResourceList.Add(new Guid(userResourceItem.ResourceID));
                        }
                        Common.CurrentResource.SelectedWorkListResources = selectedWorkListResources;
                    }
                    else
                        Common.CurrentResource.SelectedWorkListResources = new List<ResSection>();

                    if (selectedResourceList != null && selectedResourceList.Count > 0)
                        filterExpression += Common.CreateFilterExpressionOfGuidList(filterExpression, "FROMRESOURCE", selectedResourceList);
                }


                model.LaboratoryProcedureMasterList = new List<LaboratoryWorkListItemMasterModel>();

                if (!String.IsNullOrEmpty(inputdvo.txtPatient))
                {
                    //PatientSearch componenti kullanıldığı için değiştirildi.
                    filterExpression += " AND THIS:EPISODE:PATIENT:OBJECTID = '" + inputdvo.txtPatient + "'";
                }

                if (!String.IsNullOrEmpty(inputdvo.txtSEProtocolNo))
                {
                    filterExpression += " AND THIS:SUBEPISODE:PROTOCOLNO = '" + inputdvo.txtSEProtocolNo + "'";
                }


                //Numune Alma check işaretli ise Ayaktan ve Yatan hasta için farklı listelemeler yapılacak.
                if (inputdvo.SelectedWorkListStateItems.Count > 0 && inputdvo.SelectedWorkListStateItems[0].StateDefID == LaboratoryProcedure.States.SampleTaking.ToString() && inputdvo.PatientStatus == "0,3")
                {
                    //Kullanıcının bağlı olduğu kuyruk tanımındaki hastalar gelecek.
                    if (!string.IsNullOrEmpty(inputdvo.SelectedQueueObjectID))
                    {
                        TTObjectClasses.Common.QueueItems ret = new TTObjectClasses.Common.QueueItems();
                        ret = Common.GetSortedQueue(new Guid(inputdvo.SelectedQueueObjectID), false);
                        List<Guid> episodeIDList = new List<Guid>();

                        foreach (Common.QueuePatient patient in ret.patient)
                        {
                            if (patient.ObjectID != Guid.Empty)
                            {
                                EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject(patient.ObjectID, "EPISODEACTION");
                                LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = this.CreateLaboratoryWorkListItemMasterModel(episodeAction.Episode, objectContext, (DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, filterExpression);

                                // Hasta Cagir methodunda kuyruktan kaldirabilmesi icin kuyruga atılmıs olan EpisodeActionID, is listesindeki LaboratoryWorkListItemMasterModel in LabRequestObjectID sine set ediliyor. 
                                laboratoryWorkListItemMasterModel.LabRequestObjectID = episodeAction.ObjectID.ToString();
                                model.LaboratoryProcedureMasterList.Add(laboratoryWorkListItemMasterModel);
                                episodeIDList.Add(episodeAction.Episode.ObjectID);
                            }
                        }

                        //Monıtorde hıc hasta yoksa normal ıs lıstesı gıbı Numune Alma durumundakı hastalar gelecek
                        if (episodeIDList.Count == 0)
                        {
                            IBindingList laboratoryMasterWorkList = LaboratoryProcedure.GetLabProcedureByWorklistDate(inputdvo.StartDate.Value, inputdvo.EndDate.Value, filterExpression);
                            foreach (LaboratoryProcedure.GetLabProcedureByWorklistDate_Class lpm in laboratoryMasterWorkList)
                            {
                                Episode episode = (Episode)objectContext.GetObject((Guid)lpm.Episode, "EPISODE");
                                LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = this.CreateLaboratoryWorkListItemMasterModel(episode, objectContext, (DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, filterExpression);
                                model.LaboratoryProcedureMasterList.Add(laboratoryWorkListItemMasterModel);
                            }
                        }
                        //Monıtorde olan hastalar bır daha lısteye eklenmemelı
                        else
                        {
                            IBindingList laboratoryMasterWorkList = LaboratoryProcedure.GetLabProcedureByWorklistDate(inputdvo.StartDate.Value, inputdvo.EndDate.Value, filterExpression);
                            Boolean isExists;
                            foreach (LaboratoryProcedure.GetLabProcedureByWorklistDate_Class lpm in laboratoryMasterWorkList)
                            {
                                isExists = false;
                                foreach (Guid eID in episodeIDList)
                                {
                                    if (eID.ToString() == lpm.Episode.ToString())
                                    {
                                        isExists = true;
                                        break;
                                    }
                                }
                                if (!isExists)
                                {
                                    Episode episode = (Episode)objectContext.GetObject((Guid)lpm.Episode, "EPISODE");
                                    LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = this.CreateLaboratoryWorkListItemMasterModel(episode, objectContext, (DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, filterExpression);
                                    model.LaboratoryProcedureMasterList.Add(laboratoryWorkListItemMasterModel);
                                }
                            }
                        }
                    }
                }
                else
                {
                    IBindingList laboratoryMasterWorkList = LaboratoryProcedure.GetLabProcedureByWorklistDate(inputdvo.StartDate.Value, inputdvo.EndDate.Value, filterExpression);
                    foreach (LaboratoryProcedure.GetLabProcedureByWorklistDate_Class lpm in laboratoryMasterWorkList)
                    {
                        Episode episode = (Episode)objectContext.GetObject((Guid)lpm.Episode, "EPISODE");
                        LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = this.CreateLaboratoryWorkListItemMasterModel(episode, objectContext, (DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, filterExpression);
                        model.LaboratoryProcedureMasterList.Add(laboratoryWorkListItemMasterModel);
                    }

                }


                model.txtPatient = inputdvo.txtPatient;
                model.StartDate = (DateTime)inputdvo.StartDate;
                model.EndDate = (DateTime)inputdvo.EndDate;
                model.ID = inputdvo.ID;
                if (inputdvo.WorkListCount > 0)
                    model.WorkListCount = (int)inputdvo.WorkListCount;
                //TODO: Kullanıcı özelliklerinden gelmeli.
                model.StateType = inputdvo.StateType;
                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    model.PatientStatus = inputdvo.PatientStatus;
                //model.workListItems = FilterStatesWithObjectDef();
                objectContext.FullPartialllyLoadedObjects();
                return model;

            }
        }



        [HttpPost]
        public LaboratoryWorkListFormViewModel QueryLaboratorySampleAcceptListGroupByPatient(QueryInputDVO inputdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                DateTime serverTime = Common.RecTime();
                QueryInputDVO.SetInitialValues(ref inputdvo, serverTime);

                LaboratoryWorkListFormViewModel model = new LaboratoryWorkListFormViewModel();

                setWorkListDefinition();
                if (workListDefinition.LastSpecialPanel == null)
                {
                    IList pDefs = SpecialPanelDefinition.GetByUserAndWorkListDef(objectContext, Common.CurrentResource.ObjectID.ToString(), workListDefinition.ObjectID.ToString()); //inMemory_Context olmalı
                    foreach (SpecialPanelDefinition pDef in pDefs)
                    {
                        if (pDef.Name == "@DEFAULT@")
                        {
                            TTObjectContext objectContextEditable = new TTObjectContext(false);
                            WorkListDefinition workListDefinitionEditable = (WorkListDefinition)objectContextEditable.GetObject(workListDefinition.ObjectID, typeof(WorkListDefinition));
                            workListDefinitionEditable.LastSpecialPanel = pDef;
                            SpecialPanelListItem lastSpecialPanelListItem = createNewSpecialPanelListItem(pDef);
                            model.LastSelectedSpecialPanel = lastSpecialPanelListItem;
                            objectContextEditable.Save();
                            break;
                        }
                    }
                }

                string filterExpression = string.Empty;
                if (string.IsNullOrEmpty(inputdvo.StateType) == false)
                    filterExpression += " AND CURRENTSTATE IS " + inputdvo.StateType;

                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    filterExpression += " AND THIS:SUBEPISODE:PATIENTSTATUS IN (" + inputdvo.PatientStatus + ")";

                if (!String.IsNullOrEmpty(inputdvo.txtPatient))
                {
                    //PatientSearch componenti kullanıldığı için değiştirildi.
                    filterExpression += " AND THIS:EPISODE:PATIENT:OBJECTID = '" + inputdvo.txtPatient + "'";
                }

                if (!String.IsNullOrEmpty(inputdvo.txtSEProtocolNo))
                {
                    filterExpression += " AND THIS:SUBEPISODE:PROTOCOLNO = '" + inputdvo.txtSEProtocolNo + "'";
                }


                if (inputdvo.SelectedWorkListItems != null && inputdvo.SelectedWorkListItems.Count > 0)
                {
                    List<Guid> objectDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListItem wli in inputdvo.SelectedWorkListItems)
                    {
                        objectDefIDs.Add(new Guid(wli.ObjectDefID));
                    }

                    filterExpression += Common.CreateFilterExpressionOfGuidList(filterExpression, "OBJECTDEFID", objectDefIDs);
                }

                List<string> selectedLabStates = new List<string>();
                if (inputdvo.SelectedWorkListStateItems != null && inputdvo.SelectedWorkListStateItems.Count > 0)
                {
                    List<Guid> stateDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListStateItem wlsi in inputdvo.SelectedWorkListStateItems)
                    {
                        stateDefIDs.Add(new Guid(wlsi.StateDefID));
                        selectedLabStates.Add(wlsi.StateDefID);
                    }

                    filterExpression += Common.CreateFilterExpressionOfGuidList(filterExpression, "CURRENTSTATEDEFID", stateDefIDs);
                }

                //Ayaktan Hasta ise isteyen klinik secimi olmayacak tum polk.ler listeye gelecek
                //Yatan hasta ise isteyen klinik alanında ResClinic tipindeki resource icin listeleme yapilacak
                if (inputdvo.PatientStatus != "0,3")
                {
                    List<Guid> selectedResourceList = new List<Guid>();
                    if (inputdvo.SelectedUserResourceItems != null && inputdvo.SelectedUserResourceItems.Count > 0)
                    {
                        List<ResSection> selectedWorkListResources = new List<ResSection>();
                        foreach (UserResourceItem userResourceItem in inputdvo.SelectedUserResourceItems)
                        {
                            ResSection resource = objectContext.GetObject<ResSection>(new Guid(userResourceItem.ResourceID));
                            if (resource is ResClinic)
                                selectedResourceList.Add(new Guid(userResourceItem.ResourceID));
                        }
                        Common.CurrentResource.SelectedWorkListResources = selectedWorkListResources;
                    }
                    else
                        Common.CurrentResource.SelectedWorkListResources = new List<ResSection>();

                    if (selectedResourceList != null && selectedResourceList.Count > 0)
                        filterExpression += Common.CreateFilterExpressionOfGuidList(filterExpression, "FROMRESOURCE", selectedResourceList);
                }

                model.LaboratoryProcedureMasterList = new List<LaboratoryWorkListItemMasterModel>();
                if (inputdvo.SelectedWorkListStateItems.Count > 0 && inputdvo.SelectedWorkListStateItems[0].StateDefID == LaboratoryProcedure.States.SampleTaking.ToString() && inputdvo.PatientStatus == "0,3")
                {

                    if (!string.IsNullOrEmpty(inputdvo.SelectedQueueObjectID))
                    {
                        TTObjectClasses.Common.QueueItems ret = new TTObjectClasses.Common.QueueItems();
                        ret = Common.GetSortedQueue(new Guid(inputdvo.SelectedQueueObjectID), false);
                        List<Guid> patientIDList = new List<Guid>();

                        foreach (Common.QueuePatient patient in ret.patient)
                        {
                            if (patient.ObjectID != Guid.Empty)
                            {
                                EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject(patient.ObjectID, "EPISODEACTION");
                                LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = this.CreateLaboratoryWorkListItemMasterModelByPatient(episodeAction.Episode.Patient, inputdvo.PatientStatus, objectContext, (DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, filterExpression);

                                // Hasta Cagir methodunda kuyruktan kaldirabilmesi icin kuyruga atılmıs olan EpisodeActionID, is listesindeki LaboratoryWorkListItemMasterModel in LabRequestObjectID sine set ediliyor. 

                                //TODO: PatientGroup
                                laboratoryWorkListItemMasterModel.LabRequestObjectID = episodeAction.ObjectID.ToString();
                                model.LaboratoryProcedureMasterList.Add(laboratoryWorkListItemMasterModel);
                                patientIDList.Add(episodeAction.Episode.Patient.ObjectID);
                            }
                        }

                        //Monıtorde hıc hasta yoksa normal ıs lıstesı gıbı Numune Alma durumundakı hastalar gelecek
                        if (patientIDList.Count == 0)
                        {
                            IBindingList laboratoryMasterWorkList = LaboratoryProcedure.GetLabProcedureByPatientByWorklistDate(inputdvo.StartDate.Value, inputdvo.EndDate.Value, filterExpression);
                            foreach (LaboratoryProcedure.GetLabProcedureByPatientByWorklistDate_Class lpm in laboratoryMasterWorkList)
                            {
                                Patient patient = (Patient)objectContext.GetObject((Guid)lpm.Patient, "PATIENT");
                                LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = this.CreateLaboratoryWorkListItemMasterModelByPatient(patient, inputdvo.PatientStatus, objectContext, (DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, filterExpression);
                                model.LaboratoryProcedureMasterList.Add(laboratoryWorkListItemMasterModel);
                            }
                        }
                        //Monıtorde olan hastalar bır daha lısteye eklenmemelı
                        else
                        {
                            IBindingList laboratoryMasterWorkList = LaboratoryProcedure.GetLabProcedureByPatientByWorklistDate(inputdvo.StartDate.Value, inputdvo.EndDate.Value, filterExpression);
                            Boolean isExists;
                            foreach (LaboratoryProcedure.GetLabProcedureByPatientByWorklistDate_Class lpm in laboratoryMasterWorkList)
                            {
                                isExists = false;
                                foreach (Guid pID in patientIDList)
                                {
                                    if (pID.ToString() == lpm.Patient.ToString())
                                    {
                                        isExists = true;
                                        break;
                                    }
                                }
                                if (!isExists)
                                {
                                    Patient patient = (Patient)objectContext.GetObject((Guid)lpm.Patient, "PATIENT");
                                    LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = this.CreateLaboratoryWorkListItemMasterModelByPatient(patient, inputdvo.PatientStatus, objectContext, (DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, filterExpression);
                                    model.LaboratoryProcedureMasterList.Add(laboratoryWorkListItemMasterModel);
                                }
                            }
                        }
                    }
                    else
                    { //Kullanıcının kuyruk tanımı ile eşleşmesi yoksa tüm listeyi getirecek.
                        IBindingList laboratoryMasterWorkList = LaboratoryProcedure.GetLabProcedureByPatientByWorklistDate(inputdvo.StartDate.Value, inputdvo.EndDate.Value, filterExpression);
                        foreach (LaboratoryProcedure.GetLabProcedureByPatientByWorklistDate_Class lpm in laboratoryMasterWorkList)
                        {
                            Patient patient = (Patient)objectContext.GetObject((Guid)lpm.Patient, "PATIENT");
                            LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = this.CreateLaboratoryWorkListItemMasterModelByPatient(patient, inputdvo.PatientStatus, objectContext, (DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, filterExpression);
                            model.LaboratoryProcedureMasterList.Add(laboratoryWorkListItemMasterModel);
                        }
                    }
                }
                else
                {
                    IBindingList laboratoryMasterWorkList = LaboratoryProcedure.GetLabProcedureByPatientByWorklistDate(inputdvo.StartDate.Value, inputdvo.EndDate.Value, filterExpression);
                    foreach (LaboratoryProcedure.GetLabProcedureByPatientByWorklistDate_Class lpm in laboratoryMasterWorkList)
                    {
                        Patient patient = (Patient)objectContext.GetObject((Guid)lpm.Patient, "PATIENT");
                        LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = this.CreateLaboratoryWorkListItemMasterModelByPatient(patient, inputdvo.PatientStatus, objectContext, (DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, filterExpression);
                        model.LaboratoryProcedureMasterList.Add(laboratoryWorkListItemMasterModel);
                    }
                }

                model.txtPatient = inputdvo.txtPatient;
                model.StartDate = (DateTime)inputdvo.StartDate;
                model.EndDate = (DateTime)inputdvo.EndDate;
                model.ID = inputdvo.ID;
                if (inputdvo.WorkListCount > 0)
                    model.WorkListCount = (int)inputdvo.WorkListCount;
                //TODO: Kullanıcı özelliklerinden gelmeli.
                model.StateType = inputdvo.StateType;
                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    model.PatientStatus = inputdvo.PatientStatus;
                //model.workListItems = FilterStatesWithObjectDef();
                objectContext.FullPartialllyLoadedObjects();
                return model;

            }
        }


        public LaboratoryWorkListItemMasterModel CreateLaboratoryWorkListItemMasterModel(Episode e, TTObjectContext objectContext, DateTime startDate, DateTime endDate, string filterExpression)
        {

            LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel();
            laboratoryWorkListItemMasterModel.EpisodeID = e.ObjectID.ToString();
            laboratoryWorkListItemMasterModel.PatientTCNo = e.Patient.UniqueRefNo.ToString();
            laboratoryWorkListItemMasterModel.PatientNameSurname = e.Patient.FullName;
            laboratoryWorkListItemMasterModel.PatientID = e.Patient.ID.ToString();
            laboratoryWorkListItemMasterModel.PatientBirthDate = Convert.ToDateTime(e.Patient.BirthDate).ToString("dd.MM.yyyy");

            //Asagidaki kod Barcode etiketi bilgileri icin
            //yatan hasta ise yatis bilgileri dolacak
            if (e.PatientStatus != PatientStatusEnum.Outpatient)
            {
                laboratoryWorkListItemMasterModel.PatientStatus = "Y";
                laboratoryWorkListItemMasterModel.PatientBirthCity = e.Patient.BirthPlace;
                if (e.GetMyPatientGroupDefinition() != null)
                    laboratoryWorkListItemMasterModel.PatientGroup = e.GetMyPatientGroupDefinition().ToString();
                laboratoryWorkListItemMasterModel.PatientSex = e.Patient.Sex.ADI;

                laboratoryWorkListItemMasterModel.PatientDoctor = "";
                var lastIpa = e.GetLastInpatientAdmission();
                if (lastIpa != null)
                {
                    laboratoryWorkListItemMasterModel.InPatientDate = Convert.ToDateTime(lastIpa.HospitalInPatientDate).ToString("dd.MM.yyyy");
                    if (lastIpa.HospitalDischargeDate != null)
                        laboratoryWorkListItemMasterModel.DischargeDate = Convert.ToDateTime(lastIpa.HospitalDischargeDate).ToString("dd.MM.yyyy");
                    laboratoryWorkListItemMasterModel.DefNo = lastIpa.QuarantineProtocolNo.ToString();  //TODO:kontrol edilecek
                }

                laboratoryWorkListItemMasterModel.ArsivNo = ""; //TODO:kontrol edilecek

            }
            else
                laboratoryWorkListItemMasterModel.PatientStatus = "A";


            // laboratoryWorkListItemMasterModel.SelectedLaboratoryStateItems = selectedLabStates;


            PatientAdmission patientAdm = null;
            Boolean isPatientAdmSet = false;
            List<LaboratoryWorkListItemDetailModel> LaboratoryProcedureList = new List<LaboratoryWorkListItemDetailModel>();
            List<LaboratoryProcedure> laboratoryWorkList = LaboratoryProcedure.GetLaboratoryProcedureByEpisodeByWorkListDateNQL(objectContext, startDate, endDate, e.ObjectID, filterExpression).ToList();

            bool emergentTestFound = false;
            foreach (LaboratoryProcedure laboratoryTest in laboratoryWorkList)
            {

                if (laboratoryTest.SubEpisode != null && laboratoryTest.SubEpisode.PatientAdmission != null && laboratoryTest.SubEpisode.PatientAdmission.FirstSubEpisode != null)
                {
                    if (laboratoryTest.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo != null)
                    {
                        laboratoryWorkListItemMasterModel.ID = laboratoryTest.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo;
                    }
                }
                if (laboratoryWorkListItemMasterModel.FromResourceName == null)
                    laboratoryWorkListItemMasterModel.FromResourceName = laboratoryTest.EpisodeAction.FromResource.Name;

                if (laboratoryWorkListItemMasterModel.LabRequestObjectID == null)
                    laboratoryWorkListItemMasterModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();

                if (laboratoryTest.SubEpisode != null && isPatientAdmSet == false)
                {
                    patientAdm = laboratoryTest.SubEpisode.PatientAdmission;
                    isPatientAdmSet = true;
                }

                if (patientAdm != null)
                {
                    if (patientAdm.PriorityStatus != null)
                    {
                        if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25767", "Hamileler"))
                            laboratoryWorkListItemMasterModel.isPregnant = true;
                        if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25090", "65 Yaş Üstü Yaşlılar"))
                            laboratoryWorkListItemMasterModel.isOld = true;
                        if (patientAdm.PriorityStatus.Name == "Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler")
                            laboratoryWorkListItemMasterModel.isVetera = true;
                        if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25097", "Acil Vakalar"))
                            laboratoryWorkListItemMasterModel.isEmergency = true;
                        if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25590", "Engelliler"))
                            laboratoryWorkListItemMasterModel.isDisabled = true;
                        if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25091", "7 Yaşından Küçük Çocuklar"))
                            laboratoryWorkListItemMasterModel.isYoung = true;
                    }
                }

                if (e.Patient.ActivePregnancy != null || (e.Patient.MedicalInformation != null && e.Patient.MedicalInformation.Pregnancy.HasValue && e.Patient.MedicalInformation.Pregnancy.Value == true))
                    laboratoryWorkListItemMasterModel.isPregnant = true;
                if (e.Patient.Age.HasValue && e.Patient.Age.Value > 65)
                    laboratoryWorkListItemMasterModel.isOld = true;
                if (e.Patient.Age.HasValue && e.Patient.Age.Value < 7)
                    laboratoryWorkListItemMasterModel.isYoung = true;
                if (e.Patient.hasMedicalInformation())
                    laboratoryWorkListItemMasterModel.hasMedicalInformation = true;
                if (emergentTestFound == false)
                {
                    if (laboratoryTest.Emergency == true)
                        emergentTestFound = true;
                }

            }
            if (emergentTestFound == true)
                laboratoryWorkListItemMasterModel.isEmergency = true;

            return laboratoryWorkListItemMasterModel;



        }


        public LaboratoryWorkListItemMasterModel CreateLaboratoryWorkListItemMasterModelByPatient(Patient p, string patientStatus, TTObjectContext objectContext, DateTime startDate, DateTime endDate, string filterExpression)
        {

            LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel();

            laboratoryWorkListItemMasterModel.PatientObjectID = p.ObjectID.ToString();
            laboratoryWorkListItemMasterModel.PatientTCNo = p.UniqueRefNo.ToString();
            laboratoryWorkListItemMasterModel.PatientNameSurname = p.FullName;
            laboratoryWorkListItemMasterModel.PatientID = p.ID.ToString();
            laboratoryWorkListItemMasterModel.PatientBirthDate = Convert.ToDateTime(p.BirthDate).ToString("dd.MM.yyyy");
            laboratoryWorkListItemMasterModel.PatientBirthCity = p.BirthPlace;
            laboratoryWorkListItemMasterModel.PatientSex = p.Sex.ADI;




            PatientAdmission patientAdm = null;
            Boolean isPatientAdmSet = false;
            List<LaboratoryWorkListItemDetailModel> LaboratoryProcedureList = new List<LaboratoryWorkListItemDetailModel>();
            List<LaboratoryProcedure> laboratoryWorkList = LaboratoryProcedure.GetLaboratoryProcedureByPatientByWorkListDateNQL(objectContext, startDate, endDate, p.ObjectID.ToString(), filterExpression).ToList();

            bool emergentTestFound = false;
            Episode myFirstEpisode = null;

            foreach (LaboratoryProcedure laboratoryTest in laboratoryWorkList)
            {


                //if (laboratoryTest.SubEpisode != null && laboratoryTest.SubEpisode.PatientAdmission != null && laboratoryTest.SubEpisode.PatientAdmission.FirstSubEpisode != null)
                //{
                //    if (laboratoryTest.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo != null)
                //    {
                //        laboratoryWorkListItemMasterModel.ID = laboratoryTest.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo;
                //    }
                //}
                laboratoryWorkListItemMasterModel.ID = p.ID.ToString();

                if (myFirstEpisode == null)
                {
                    myFirstEpisode = laboratoryTest.SubEpisode.Episode;
                    laboratoryWorkListItemMasterModel.EpisodeID = myFirstEpisode.ObjectID.ToString();
                }

                if (laboratoryWorkListItemMasterModel.FromResourceName == null)
                    laboratoryWorkListItemMasterModel.FromResourceName = laboratoryTest.EpisodeAction.FromResource.Name;

                if (laboratoryWorkListItemMasterModel.LabRequestObjectID == null)
                    laboratoryWorkListItemMasterModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();

                if (laboratoryTest.SubEpisode != null && isPatientAdmSet == false)
                {
                    patientAdm = laboratoryTest.SubEpisode.PatientAdmission;
                    isPatientAdmSet = true;
                }

                if (patientAdm != null)
                {
                    if (patientAdm.PriorityStatus != null)
                    {
                        if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25767", "Hamileler"))
                            laboratoryWorkListItemMasterModel.isPregnant = true;
                        if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25090", "65 Yaş Üstü Yaşlılar"))
                            laboratoryWorkListItemMasterModel.isOld = true;
                        if (patientAdm.PriorityStatus.Name == "Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler")
                            laboratoryWorkListItemMasterModel.isVetera = true;
                        if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25097", "Acil Vakalar"))
                            laboratoryWorkListItemMasterModel.isEmergency = true;
                        if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25590", "Engelliler"))
                            laboratoryWorkListItemMasterModel.isDisabled = true;
                        if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25091", "7 Yaşından Küçük Çocuklar"))
                            laboratoryWorkListItemMasterModel.isYoung = true;
                    }
                }

                if (p.ActivePregnancy != null || (p.MedicalInformation != null && p.MedicalInformation.Pregnancy.HasValue && p.MedicalInformation.Pregnancy.Value == true))
                    laboratoryWorkListItemMasterModel.isPregnant = true;
                if (p.Age.HasValue && p.Age.Value > 65)
                    laboratoryWorkListItemMasterModel.isOld = true;
                if (p.Age.HasValue && p.Age.Value < 7)
                    laboratoryWorkListItemMasterModel.isYoung = true;
                if (p.hasMedicalInformation())
                    laboratoryWorkListItemMasterModel.hasMedicalInformation = true;
                if (emergentTestFound == false)
                {
                    if (laboratoryTest.Emergency == true)
                        emergentTestFound = true;
                }

            }
            if (emergentTestFound == true)
                laboratoryWorkListItemMasterModel.isEmergency = true;


            //Asagidaki kod Barcode etiketi bilgileri icin
            //yatan hasta ise yatis bilgileri dolacak

            if (patientStatus == "0,3") //ayaktan ve günübirlik ise
                laboratoryWorkListItemMasterModel.PatientStatus = "A";
            else
            {
                laboratoryWorkListItemMasterModel.PatientStatus = "Y";
                InpatientAdmission lastInpatientAdm = null;

                foreach (Episode myEpisode in p.Episodes.OrderByDescending(dr => dr.OpeningDate))
                {
                    foreach (InpatientAdmission inpatientAdmission in myEpisode.InpatientAdmissions.OrderByDescending(dr => dr.HospitalInPatientDate))
                    {
                        if (inpatientAdmission.IsCancelled != true)
                        {
                            lastInpatientAdm = inpatientAdmission;
                            break;
                        }
                    }
                    if (lastInpatientAdm != null)
                        break;
                }

                if (lastInpatientAdm != null)
                {
                    laboratoryWorkListItemMasterModel.InPatientDate = Convert.ToDateTime(lastInpatientAdm.HospitalInPatientDate).ToString("dd.MM.yyyy");
                    if (lastInpatientAdm.HospitalDischargeDate != null)
                        laboratoryWorkListItemMasterModel.DischargeDate = Convert.ToDateTime(lastInpatientAdm.HospitalDischargeDate).ToString("dd.MM.yyyy");
                    laboratoryWorkListItemMasterModel.DefNo = lastInpatientAdm.QuarantineProtocolNo.ToString();  //TODO:kontrol edilecek
                }
            }
            return laboratoryWorkListItemMasterModel;
        }


        [HttpPost]
        public LaboratoryWorkListItemMasterModel QueryLaboratoryDetailItemByEpisode(QueryInputDVOByEpisode inputdvo)
        {

            LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel();
            List<LaboratoryWorkListItemDetailModel> laboratoryWorkListItemDetailModelList = new List<LaboratoryWorkListItemDetailModel>();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                PatientAdmission patientAdm = null;
                Boolean isPatientAdmSet = false;
                if (inputdvo.StartDate.HasValue == false)
                    inputdvo.StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                if (inputdvo.EndDate.HasValue == false)
                    inputdvo.EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                string filterExpression = string.Empty;
                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    filterExpression += " AND THIS:SUBEPISODE:PATIENTSTATUS IN (" + inputdvo.PatientStatus + ")";
                List<string> selectedLabStates = new List<string>();
                if (inputdvo.SelectedWorkListStateItems != null && inputdvo.SelectedWorkListStateItems.Count > 0)
                {
                    List<Guid> stateDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListStateItem wlsi in inputdvo.SelectedWorkListStateItems)
                    {
                        stateDefIDs.Add(new Guid(wlsi.StateDefID));
                        selectedLabStates.Add(wlsi.StateDefID);
                    }

                    filterExpression += Common.CreateFilterExpressionOfGuidList(filterExpression, "CURRENTSTATEDEFID", stateDefIDs);
                }

                Episode e = (Episode)objectContext.GetObject(new Guid(inputdvo.EpisodeID), "EPISODE");
                laboratoryWorkListItemMasterModel.EpisodeID = e.ObjectID.ToString();
                laboratoryWorkListItemMasterModel.LabRequestObjectID = inputdvo.LabRequestObjectID;
                laboratoryWorkListItemMasterModel.PatientTCNo = e.Patient.UniqueRefNo.ToString();
                laboratoryWorkListItemMasterModel.PatientNameSurname = e.Patient.FullName;
                laboratoryWorkListItemMasterModel.PatientID = e.Patient.ID.ToString();
                laboratoryWorkListItemMasterModel.PatientBirthDate = Convert.ToDateTime(e.Patient.BirthDate).ToString("dd.MM.yyyy");


                //Asagidaki kod Barcode etiketi bilgileri icin
                //yatan hasta ise yatis bilgileri dolacak
                if (e.PatientStatus != PatientStatusEnum.Outpatient)
                {
                    laboratoryWorkListItemMasterModel.PatientStatus = "Y";
                    laboratoryWorkListItemMasterModel.PatientBirthCity = e.Patient.BirthPlace;
                    if (e.GetMyPatientGroupDefinition() != null)
                        laboratoryWorkListItemMasterModel.PatientGroup = e.GetMyPatientGroupDefinition().ToString();
                    laboratoryWorkListItemMasterModel.PatientSex = e.Patient.Sex.ADI;

                    laboratoryWorkListItemMasterModel.PatientDoctor = "";

                    var lastIpa = e.GetLastInpatientAdmission();
                    if (lastIpa != null)
                    {
                        laboratoryWorkListItemMasterModel.InPatientDate = Convert.ToDateTime(lastIpa.HospitalInPatientDate).ToString("dd.MM.yyyy");
                        if (lastIpa.HospitalDischargeDate != null)
                            laboratoryWorkListItemMasterModel.DischargeDate = Convert.ToDateTime(lastIpa.HospitalDischargeDate).ToString("dd.MM.yyyy");
                        laboratoryWorkListItemMasterModel.DefNo = lastIpa.QuarantineProtocolNo.ToString();  //TODO:kontrol edilecek
                    }

                    laboratoryWorkListItemMasterModel.ArsivNo = ""; //TODO:kontrol edilecek

                }
                else
                    laboratoryWorkListItemMasterModel.PatientStatus = "A";




                laboratoryWorkListItemMasterModel.SelectedLaboratoryStateItems = selectedLabStates;
                //herbır masteritem ıcın lab procedureler dondurulecek
                List<LaboratoryWorkListItemDetailModel> LaboratoryProcedureList = new List<LaboratoryWorkListItemDetailModel>();
                List<Laboratuar_Is_Listesi.TubeInformation> TubeInformationList = new List<Laboratuar_Is_Listesi.TubeInformation>();
                Dictionary<string, Laboratuar_Is_Listesi.TubeInformation> LabProceduresTubeInfoList = new Dictionary<string, Laboratuar_Is_Listesi.TubeInformation>();
                List<LaboratoryProcedure> laboratoryWorkList = LaboratoryProcedure.GetLaboratoryProcedureByEpisodeNQL(objectContext, new Guid(inputdvo.EpisodeID), filterExpression).ToList();

                //TODO: WorkList Right kontrolu yapılıyor
                bool hasWorkListRight = false;
                List<LaboratoryProcedure> laboratoryWorkListObjects = new List<LaboratoryProcedure>();
                if (laboratoryWorkList.Count > 0)
                {

                    foreach (LaboratoryProcedure labProcedureObject in laboratoryWorkList)
                    {
                        //LaboratoryProcedure labProcedureObject = (LaboratoryProcedure)objectContext.GetObject((Guid)ttObject.ObjectID, "LABORATORYPROCEDURE");

                        if (TTUser.CurrentUser.HasRight(labProcedureObject.CurrentStateDef.FormDef, labProcedureObject, workListDefinition.RightDefID.Value, labProcedureObject.CurrentStateDef))
                        {
                            hasWorkListRight = true;
                            laboratoryWorkListObjects.Add(labProcedureObject);
                        }
                    }
                }
                //WorkList Right

                if (hasWorkListRight)
                {
                    //foreach (LaboratoryProcedure.GetLaboratoryProcedureByEpisode_Class lp in laboratoryWorkList)
                    foreach (LaboratoryProcedure laboratoryTest in laboratoryWorkListObjects)
                    {
                        //LaboratoryProcedure laboratoryTest = (LaboratoryProcedure)objectContext.GetObject(lp.ObjectID.Value, "LABORATORYPROCEDURE");
                        LaboratoryWorkListItemDetailModel laboratoryWorkListItemDetailModel = new LaboratoryWorkListItemDetailModel();
                        laboratoryWorkListItemDetailModel.ObjectID = laboratoryTest.ObjectID;
                        laboratoryWorkListItemDetailModel.ObjectDefName = laboratoryTest.ObjectDef.Name;
                        laboratoryWorkListItemDetailModel.PatientNameSurname = laboratoryTest.Episode.Patient.FullName;


                        laboratoryWorkListItemDetailModel.FromResourceName = laboratoryTest.EpisodeAction.FromResource.Name;
                        if (laboratoryWorkListItemMasterModel.FromResourceName == null)
                            laboratoryWorkListItemMasterModel.FromResourceName = laboratoryTest.EpisodeAction.FromResource.Name;

                        laboratoryWorkListItemDetailModel.LaboratoryTestName = laboratoryTest.ProcedureObject.Name.ToString();
                        laboratoryWorkListItemDetailModel.WorkListDate = (DateTime)laboratoryTest.WorkListDate.Value;
                        laboratoryWorkListItemDetailModel.RequestDate = Convert.ToDateTime(laboratoryTest.RequestDate).ToString("dd-MM-yyyy HH:mm");
                        laboratoryWorkListItemDetailModel.RequestedByUser = laboratoryTest.Laboratory.RequestDoctor.Name;
                        laboratoryWorkListItemDetailModel.StateName = laboratoryTest.CurrentStateDef.DisplayText;
                        laboratoryWorkListItemDetailModel.StateDefID = laboratoryTest.CurrentStateDefID.ToString();
                        if (laboratoryTest.Emergency == true)
                            laboratoryWorkListItemDetailModel.isLabTestEmergency = true;
                        laboratoryWorkListItemDetailModel.TestCode = laboratoryTest.ProcedureObject.Code;
                        //laboratoryWorkListItemDetailModel.TestLoincCode = laboratoryTest.ProcedureObject.SKRSLoincKodu?.LOINCNUMARASI;
                        laboratoryWorkListItemDetailModel.TestLoincCode = ((LaboratoryTestDefinition)laboratoryTest.ProcedureObject).FreeLOINCCode;
                        laboratoryWorkListItemDetailModel.BarcodeID = laboratoryTest.BarcodeId.ToString();
                        laboratoryWorkListItemDetailModel.SpecimenID = laboratoryTest.SpecimenId.ToString();
                        laboratoryWorkListItemDetailModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();
                        if (laboratoryWorkListItemMasterModel.LabRequestObjectID == null)
                            laboratoryWorkListItemMasterModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();

                        //Dis Istem oldugu bilgisi set ediliyor
                        Resource masterResource = (Resource)laboratoryTest.EpisodeAction.MasterResource;
                        laboratoryWorkListItemDetailModel.isExternalProcedureRequest = false;
                        if (masterResource is ResObservationUnit)
                        {
                            if (((ResObservationUnit)masterResource).IsExternalObservationUnit == true)
                                laboratoryWorkListItemDetailModel.isExternalProcedureRequest = true;
                        }
                        laboratoryWorkListItemDetailModel.EpisodeActionObjectId = laboratoryTest.EpisodeAction.ObjectID;


                        //Tetkik kategori bilgisi set ediliyor. Tetkik'in katolog tanımında karşılığı bulunmaması durumunu karşılamak için öncelikle Diğer olarak set ediliyor.
                        laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = TTUtils.CultureService.GetText("M12780", "Diğer");
                        bool categoryNameOK = false;
                        if (laboratoryTest.ProcedureObject.FormDetail != null)
                        {
                            //Tetkik Sık Kullanılanlar Kategorisinde ise o grup altında çıkması istenmiyor. ResUser ile eşlenmiş ProcedureRequestForm un kategori isminin çıkmaması için aşağıdaki kod yazıldı.
                            for (int i = 0; i < laboratoryTest.ProcedureObject.FormDetail.Count; i++)
                            {
                                ProcedureRequestFormDefinition procedureReqForm = laboratoryTest.ProcedureObject.FormDetail[i].ProcedureRequestCategory?.ProcedureRequestForm;
                                if (procedureReqForm != null)
                                {
                                    foreach (RequestUnitOfProcedureForm requestFormResource in procedureReqForm.RequestUnitsOfProcedureForm)
                                    {
                                        if (!(requestFormResource.Resource is ResUser))
                                        {
                                            laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = laboratoryTest.ProcedureObject.FormDetail[i].ProcedureRequestCategory?.CategoryName;
                                            categoryNameOK = true;
                                            break;
                                        }
                                    }
                                    if (categoryNameOK == true)
                                        break;
                                }
                            }
                        }


                        //Tetkigin bilgilendirme formu ve aciklamasi varda o yuklenecek
                        LaboratoryTestDefinition laboratoryTestDefinition;
                        laboratoryTestDefinition = (LaboratoryTestDefinition)laboratoryTest.ProcedureObject;

                        if (laboratoryTestDefinition.RequiresBinaryScanForm == true || laboratoryTestDefinition.RequiresTripleTestForm == true || laboratoryTestDefinition.RequiresUreaBreathTestReport == true || laboratoryTestDefinition.TestDescription != null)
                        {
                            string procedureInst = "";
                            string instReportName = "";
                            if (laboratoryTestDefinition.RequiresBinaryScanForm == true)
                            {
                                procedureInst = procedureInst + TTUtils.CultureService.GetText("M26037", "İkili Tarama Formu Gerektirir\n");
                                instReportName = instReportName + "LaboratoryBinaryScanInfoReport" + "|";
                            }

                            if (laboratoryTestDefinition.RequiresTripleTestForm == true)
                            {
                                procedureInst = procedureInst + TTUtils.CultureService.GetText("M27161", "Üçlü Test Formu Gerektirir\n");
                                instReportName = instReportName + "LaboratoryTripleTestInfoReport" + "|";
                            }

                            if (laboratoryTestDefinition.RequiresUreaBreathTestReport == true)
                            {
                                procedureInst = procedureInst + TTUtils.CultureService.GetText("M27164", "Üre Nefes Testi Hasta Talimat Raporunu Gerektirir\n");
                                instReportName = instReportName + "UreaBreathTestPatientInstructionReport" + "|";
                            }

                            if (laboratoryTestDefinition.TestDescription != null)
                            {
                                procedureInst = procedureInst + laboratoryTestDefinition.TestDescription;
                                instReportName = instReportName + "LaboratoryTestPatientInstructionReport" + "|";
                            }

                            laboratoryWorkListItemDetailModel.hasProcedureInstruction = true;
                            laboratoryWorkListItemDetailModel.ProcedureInstructions = procedureInst;
                            laboratoryWorkListItemDetailModel.ProcedureInstructionReportName = instReportName;
                        }
                        //

                        laboratoryWorkListItemDetailModelList.Add(laboratoryWorkListItemDetailModel);
                        if (laboratoryTest.TubeInformation != null)
                        {
                            Laboratuar_Is_Listesi.TubeInformation tubeInfo = new Laboratuar_Is_Listesi.TubeInformation();
                            string containerID = laboratoryTest.TubeInformation.ContainerID.ToString();
                            if (LabProceduresTubeInfoList.TryGetValue(containerID, out tubeInfo) == false)
                            {
                                if (tubeInfo == null)
                                    tubeInfo = new Laboratuar_Is_Listesi.TubeInformation();
                                tubeInfo.FromResourceName = laboratoryTest.TubeInformation.FromResourceName;
                                tubeInfo.SpecimenID = laboratoryTest.TubeInformation.SpecimenID.ToString();
                                tubeInfo.ContainerID = laboratoryTest.TubeInformation.ContainerID.ToString();
                                tubeInfo.SpecialHandlingCode = laboratoryTest.TubeInformation.Description;
                                tubeInfo.OtherEnvFactor = laboratoryTest.TubeInformation.BarcodeType;
                                if (laboratoryTest.TubeInformation.RequestAcceptionDate != null)
                                    tubeInfo.RequestAcceptionDate = Convert.ToDateTime(laboratoryTest.TubeInformation.RequestAcceptionDate).ToString("dd-MM-yyyy HH:mm");
                                LabProceduresTubeInfoList.Add(containerID, tubeInfo);
                            }
                        }
                        if (laboratoryTest.SubEpisode != null && isPatientAdmSet == false)
                        {
                            patientAdm = laboratoryTest.SubEpisode.PatientAdmission;
                            isPatientAdmSet = true;
                        }
                    }

                    foreach (KeyValuePair<string, Laboratuar_Is_Listesi.TubeInformation> tubeInfo in LabProceduresTubeInfoList)
                    {
                        TubeInformationList.Add(tubeInfo.Value);
                    }

                    laboratoryWorkListItemMasterModel.LaboratoryProcedureList = laboratoryWorkListItemDetailModelList;
                    laboratoryWorkListItemMasterModel.TubeInformationList = TubeInformationList;


                    //TODO: PriorityStatusDefinition a ayırt edici bir flag(enum) koymak lazım.Şimdilik isimden bakıldı :( BB
                    if (patientAdm != null)
                    {
                        if (patientAdm.PriorityStatus != null)
                        {
                            if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25767", "Hamileler"))
                                laboratoryWorkListItemMasterModel.isPregnant = true;
                            if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25090", "65 Yaş Üstü Yaşlılar"))
                                laboratoryWorkListItemMasterModel.isOld = true;
                            if (patientAdm.PriorityStatus.Name == "Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler")
                                laboratoryWorkListItemMasterModel.isVetera = true;
                            if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25097", "Acil Vakalar"))
                                laboratoryWorkListItemMasterModel.isEmergency = true;
                            if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25590", "Engelliler"))
                                laboratoryWorkListItemMasterModel.isDisabled = true;
                            if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25091", "7 Yaşından Küçük Çocuklar"))
                                laboratoryWorkListItemMasterModel.isYoung = true;
                        }
                    }
                    if (e.Patient.ActivePregnancy != null || (e.Patient.MedicalInformation != null && e.Patient.MedicalInformation.Pregnancy.HasValue && e.Patient.MedicalInformation.Pregnancy.Value == true))
                        laboratoryWorkListItemMasterModel.isPregnant = true;
                    if (e.Patient.Age.HasValue && e.Patient.Age.Value > 65)
                        laboratoryWorkListItemMasterModel.isOld = true;
                    if (e.Patient.Age.HasValue && e.Patient.Age.Value < 7)
                        laboratoryWorkListItemMasterModel.isYoung = true;
                    if (e.Patient.hasMedicalInformation())
                        laboratoryWorkListItemMasterModel.hasMedicalInformation = true;

                    return laboratoryWorkListItemMasterModel;
                }
                else
                    return null;
            }
        }


        [HttpPost]
        public LaboratoryWorkListItemMasterModel QueryLaboratoryDetailItemByPatient(QueryInputDVOByEpisode inputdvo)
        {

            LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel();
            List<LaboratoryWorkListItemDetailModel> laboratoryWorkListItemDetailModelList = new List<LaboratoryWorkListItemDetailModel>();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                PatientAdmission patientAdm = null;
                Boolean isPatientAdmSet = false;
                string filterExpression = string.Empty;

                //if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                //    filterExpression += " AND THIS:EPISODE:PATIENTSTATUS IN (" + inputdvo.PatientStatus + ")";

                List<string> selectedLabStates = new List<string>();
                if (inputdvo.SelectedWorkListStateItems != null && inputdvo.SelectedWorkListStateItems.Count > 0)
                {
                    List<Guid> stateDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListStateItem wlsi in inputdvo.SelectedWorkListStateItems)
                    {
                        stateDefIDs.Add(new Guid(wlsi.StateDefID));
                        selectedLabStates.Add(wlsi.StateDefID);
                    }

                    filterExpression += " AND " + Common.CreateFilterExpressionOfGuidList(filterExpression, "CURRENTSTATEDEFID", stateDefIDs);
                }

                Patient p = (Patient)objectContext.GetObject(new Guid(inputdvo.PatientObjectID), "PATIENT");
                laboratoryWorkListItemMasterModel.PatientObjectID = p.ObjectID.ToString();
                laboratoryWorkListItemMasterModel.LabRequestObjectID = inputdvo.LabRequestObjectID;
                laboratoryWorkListItemMasterModel.PatientTCNo = p.UniqueRefNo.ToString();
                laboratoryWorkListItemMasterModel.PatientNameSurname = p.FullName;
                laboratoryWorkListItemMasterModel.PatientID = p.ID.ToString();
                laboratoryWorkListItemMasterModel.PatientBirthDate = Convert.ToDateTime(p.BirthDate).ToString("dd.MM.yyyy");
                laboratoryWorkListItemMasterModel.PatientBirthCity = p.BirthPlace;
                laboratoryWorkListItemMasterModel.PatientSex = p.Sex.ADI;


                //Asagidaki kod Barcode etiketi bilgileri icin
                //yatan hasta ise yatis bilgileri dolacak


                if (inputdvo.PatientStatus == "0,3") //ayaktan ve günübirlik ise
                    laboratoryWorkListItemMasterModel.PatientStatus = "A";
                else
                {
                    laboratoryWorkListItemMasterModel.PatientStatus = "Y";
                    InpatientAdmission lastInpatientAdm = null;

                    foreach (Episode myEpisode in p.Episodes.OrderByDescending(dr => dr.OpeningDate))
                    {
                        foreach (InpatientAdmission inpatientAdmission in myEpisode.InpatientAdmissions.OrderByDescending(dr => dr.HospitalInPatientDate))
                        {
                            if (inpatientAdmission.IsCancelled != true)
                            {
                                lastInpatientAdm = inpatientAdmission;
                                break;
                            }
                        }
                        if (lastInpatientAdm != null)
                            break;
                    }

                    if (lastInpatientAdm != null)
                    {
                        laboratoryWorkListItemMasterModel.InPatientDate = Convert.ToDateTime(lastInpatientAdm.HospitalInPatientDate).ToString("dd.MM.yyyy");
                        if (lastInpatientAdm.HospitalDischargeDate != null)
                            laboratoryWorkListItemMasterModel.DischargeDate = Convert.ToDateTime(lastInpatientAdm.HospitalDischargeDate).ToString("dd.MM.yyyy");
                        laboratoryWorkListItemMasterModel.DefNo = lastInpatientAdm.QuarantineProtocolNo.ToString();  //TODO:kontrol edilecek
                    }

                }


                laboratoryWorkListItemMasterModel.SelectedLaboratoryStateItems = selectedLabStates;
                //herbır masteritem ıcın lab procedureler dondurulecek
                List<LaboratoryWorkListItemDetailModel> LaboratoryProcedureList = new List<LaboratoryWorkListItemDetailModel>();
                List<Laboratuar_Is_Listesi.TubeInformation> TubeInformationList = new List<Laboratuar_Is_Listesi.TubeInformation>();
                Dictionary<string, Laboratuar_Is_Listesi.TubeInformation> LabProceduresTubeInfoList = new Dictionary<string, Laboratuar_Is_Listesi.TubeInformation>();
                List<LaboratoryProcedure> laboratoryWorkList = LaboratoryProcedure.GetLaboratoryProcedureByPatientNQL(objectContext, inputdvo.PatientObjectID, (DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, filterExpression).ToList();

                //TODO: WorkList Right kontrolu yapılıyor
                bool hasWorkListRight = false;
                List<LaboratoryProcedure> laboratoryWorkListObjects = new List<LaboratoryProcedure>();
                if (laboratoryWorkList.Count > 0)
                {

                    foreach (LaboratoryProcedure labProcedureObject in laboratoryWorkList)
                    {
                        //LaboratoryProcedure labProcedureObject = (LaboratoryProcedure)objectContext.GetObject((Guid)ttObject.ObjectID, "LABORATORYPROCEDURE");

                        if (TTUser.CurrentUser.HasRight(labProcedureObject.CurrentStateDef.FormDef, labProcedureObject, workListDefinition.RightDefID.Value, labProcedureObject.CurrentStateDef))
                        {
                            hasWorkListRight = true;
                            laboratoryWorkListObjects.Add(labProcedureObject);
                        }
                    }
                }
                //WorkList Right

                Episode myFirstEpisode = null;
                if (hasWorkListRight)
                {
                    //foreach (LaboratoryProcedure.GetLaboratoryProcedureByEpisode_Class lp in laboratoryWorkList)
                    foreach (LaboratoryProcedure laboratoryTest in laboratoryWorkListObjects)
                    {
                        //LaboratoryProcedure laboratoryTest = (LaboratoryProcedure)objectContext.GetObject(lp.ObjectID.Value, "LABORATORYPROCEDURE");
                        LaboratoryWorkListItemDetailModel laboratoryWorkListItemDetailModel = new LaboratoryWorkListItemDetailModel();
                        laboratoryWorkListItemDetailModel.ObjectID = laboratoryTest.ObjectID;
                        laboratoryWorkListItemDetailModel.ObjectDefName = laboratoryTest.ObjectDef.Name;
                        laboratoryWorkListItemDetailModel.PatientNameSurname = laboratoryTest.Episode.Patient.FullName;

                        if (myFirstEpisode == null)
                        {
                            myFirstEpisode = laboratoryTest.SubEpisode.Episode;
                            laboratoryWorkListItemMasterModel.EpisodeID = myFirstEpisode.ObjectID.ToString();
                        }

                        laboratoryWorkListItemDetailModel.FromResourceName = laboratoryTest.EpisodeAction.FromResource.Name;
                        if (laboratoryWorkListItemMasterModel.FromResourceName == null)
                            laboratoryWorkListItemMasterModel.FromResourceName = laboratoryTest.EpisodeAction.FromResource.Name;

                        laboratoryWorkListItemDetailModel.LaboratoryTestName = laboratoryTest.ProcedureObject.Name.ToString();
                        laboratoryWorkListItemDetailModel.WorkListDate = (DateTime)laboratoryTest.WorkListDate.Value;
                        laboratoryWorkListItemDetailModel.RequestDate = Convert.ToDateTime(laboratoryTest.RequestDate).ToString("dd-MM-yyyy HH:mm");
                        laboratoryWorkListItemDetailModel.RequestedByUser = laboratoryTest.Laboratory.RequestDoctor.Name;
                        laboratoryWorkListItemDetailModel.StateName = laboratoryTest.CurrentStateDef.DisplayText;
                        laboratoryWorkListItemDetailModel.StateDefID = laboratoryTest.CurrentStateDefID.ToString();
                        if (laboratoryTest.Emergency == true)
                            laboratoryWorkListItemDetailModel.isLabTestEmergency = true;
                        laboratoryWorkListItemDetailModel.TestCode = laboratoryTest.ProcedureObject.Code;
                        //laboratoryWorkListItemDetailModel.TestLoincCode = laboratoryTest.ProcedureObject.SKRSLoincKodu?.LOINCNUMARASI;
                        laboratoryWorkListItemDetailModel.TestLoincCode = ((LaboratoryTestDefinition)laboratoryTest.ProcedureObject).FreeLOINCCode;
                        laboratoryWorkListItemDetailModel.BarcodeID = laboratoryTest.BarcodeId.ToString();
                        laboratoryWorkListItemDetailModel.SpecimenID = laboratoryTest.SpecimenId.ToString();
                        laboratoryWorkListItemDetailModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();
                        if (laboratoryWorkListItemMasterModel.LabRequestObjectID == null)
                            laboratoryWorkListItemMasterModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();

                        //Dis Istem oldugu bilgisi set ediliyor
                        Resource masterResource = (Resource)laboratoryTest.EpisodeAction.MasterResource;
                        laboratoryWorkListItemDetailModel.isExternalProcedureRequest = false;
                        if (masterResource is ResObservationUnit)
                        {
                            if (((ResObservationUnit)masterResource).IsExternalObservationUnit == true)
                                laboratoryWorkListItemDetailModel.isExternalProcedureRequest = true;
                        }
                        laboratoryWorkListItemDetailModel.EpisodeActionObjectId = laboratoryTest.EpisodeAction.ObjectID;


                        //Tetkik kategori bilgisi set ediliyor. Tetkik'in katolog tanımında karşılığı bulunmaması durumunu karşılamak için öncelikle Diğer olarak set ediliyor.
                        laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = TTUtils.CultureService.GetText("M12780", "Diğer");
                        bool categoryNameOK = false;
                        if (laboratoryTest.ProcedureObject.FormDetail != null)
                        {
                            //Tetkik Sık Kullanılanlar Kategorisinde ise o grup altında çıkması istenmiyor. ResUser ile eşlenmiş ProcedureRequestForm un kategori isminin çıkmaması için aşağıdaki kod yazıldı.
                            for (int i = 0; i < laboratoryTest.ProcedureObject.FormDetail.Count; i++)
                            {
                                ProcedureRequestFormDefinition procedureReqForm = laboratoryTest.ProcedureObject.FormDetail[i].ProcedureRequestCategory?.ProcedureRequestForm;
                                if (procedureReqForm != null)
                                {
                                    foreach (RequestUnitOfProcedureForm requestFormResource in procedureReqForm.RequestUnitsOfProcedureForm)
                                    {
                                        if (!(requestFormResource.Resource is ResUser))
                                        {
                                            laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = laboratoryTest.ProcedureObject.FormDetail[i].ProcedureRequestCategory?.CategoryName;
                                            categoryNameOK = true;
                                            break;
                                        }
                                    }
                                    if (categoryNameOK == true)
                                        break;
                                }
                            }
                        }


                        //Tetkigin bilgilendirme formu ve aciklamasi varda o yuklenecek
                        LaboratoryTestDefinition laboratoryTestDefinition;
                        laboratoryTestDefinition = (LaboratoryTestDefinition)laboratoryTest.ProcedureObject;

                        if (laboratoryTestDefinition.RequiresBinaryScanForm == true || laboratoryTestDefinition.RequiresTripleTestForm == true || laboratoryTestDefinition.RequiresUreaBreathTestReport == true || laboratoryTestDefinition.TestDescription != null)
                        {
                            string procedureInst = "";
                            string instReportName = "";
                            if (laboratoryTestDefinition.RequiresBinaryScanForm == true)
                            {
                                procedureInst = procedureInst + TTUtils.CultureService.GetText("M26037", "İkili Tarama Formu Gerektirir\n");
                                instReportName = instReportName + "LaboratoryBinaryScanInfoReport" + "|";
                            }

                            if (laboratoryTestDefinition.RequiresTripleTestForm == true)
                            {
                                procedureInst = procedureInst + TTUtils.CultureService.GetText("M27161", "Üçlü Test Formu Gerektirir\n");
                                instReportName = instReportName + "LaboratoryTripleTestInfoReport" + "|";
                            }

                            if (laboratoryTestDefinition.RequiresUreaBreathTestReport == true)
                            {
                                procedureInst = procedureInst + TTUtils.CultureService.GetText("M27164", "Üre Nefes Testi Hasta Talimat Raporunu Gerektirir\n");
                                instReportName = instReportName + "UreaBreathTestPatientInstructionReport" + "|";
                            }

                            if (laboratoryTestDefinition.TestDescription != null)
                            {
                                procedureInst = procedureInst + laboratoryTestDefinition.TestDescription;
                                instReportName = instReportName + "LaboratoryTestPatientInstructionReport" + "|";
                            }

                            laboratoryWorkListItemDetailModel.hasProcedureInstruction = true;
                            laboratoryWorkListItemDetailModel.ProcedureInstructions = procedureInst;
                            laboratoryWorkListItemDetailModel.ProcedureInstructionReportName = instReportName;
                        }
                        //

                        laboratoryWorkListItemDetailModelList.Add(laboratoryWorkListItemDetailModel);
                        if (laboratoryTest.TubeInformation != null)
                        {
                            Laboratuar_Is_Listesi.TubeInformation tubeInfo = new Laboratuar_Is_Listesi.TubeInformation();
                            string containerID = laboratoryTest.TubeInformation.ContainerID.ToString();
                            if (LabProceduresTubeInfoList.TryGetValue(containerID, out tubeInfo) == false)
                            {
                                if (tubeInfo == null)
                                    tubeInfo = new Laboratuar_Is_Listesi.TubeInformation();
                                tubeInfo.FromResourceName = laboratoryTest.TubeInformation.FromResourceName;
                                tubeInfo.SpecimenID = laboratoryTest.TubeInformation.SpecimenID.ToString();
                                tubeInfo.ContainerID = laboratoryTest.TubeInformation.ContainerID.ToString();
                                tubeInfo.SpecialHandlingCode = laboratoryTest.TubeInformation.Description;
                                tubeInfo.OtherEnvFactor = laboratoryTest.TubeInformation.BarcodeType;
                                if (laboratoryTest.TubeInformation.RequestAcceptionDate != null)
                                    tubeInfo.RequestAcceptionDate = Convert.ToDateTime(laboratoryTest.TubeInformation.RequestAcceptionDate).ToString("dd-MM-yyyy HH:mm");
                                LabProceduresTubeInfoList.Add(containerID, tubeInfo);
                            }
                        }
                        if (laboratoryTest.SubEpisode != null && isPatientAdmSet == false)
                        {
                            patientAdm = laboratoryTest.SubEpisode.PatientAdmission;
                            isPatientAdmSet = true;
                        }
                    }

                    foreach (KeyValuePair<string, Laboratuar_Is_Listesi.TubeInformation> tubeInfo in LabProceduresTubeInfoList)
                    {
                        TubeInformationList.Add(tubeInfo.Value);
                    }

                    laboratoryWorkListItemMasterModel.LaboratoryProcedureList = laboratoryWorkListItemDetailModelList;
                    laboratoryWorkListItemMasterModel.TubeInformationList = TubeInformationList;


                    //TODO: PriorityStatusDefinition a ayırt edici bir flag(enum) koymak lazım.Şimdilik isimden bakıldı :( BB
                    if (patientAdm != null)
                    {
                        if (patientAdm.PriorityStatus != null)
                        {
                            if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25767", "Hamileler"))
                                laboratoryWorkListItemMasterModel.isPregnant = true;
                            if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25090", "65 Yaş Üstü Yaşlılar"))
                                laboratoryWorkListItemMasterModel.isOld = true;
                            if (patientAdm.PriorityStatus.Name == "Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler")
                                laboratoryWorkListItemMasterModel.isVetera = true;
                            if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25097", "Acil Vakalar"))
                                laboratoryWorkListItemMasterModel.isEmergency = true;
                            if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25590", "Engelliler"))
                                laboratoryWorkListItemMasterModel.isDisabled = true;
                            if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25091", "7 Yaşından Küçük Çocuklar"))
                                laboratoryWorkListItemMasterModel.isYoung = true;
                        }
                    }
                    if (p.ActivePregnancy != null || (p.MedicalInformation != null && p.MedicalInformation.Pregnancy.HasValue && p.MedicalInformation.Pregnancy.Value == true))
                        laboratoryWorkListItemMasterModel.isPregnant = true;
                    if (p.Age.HasValue && p.Age.Value > 65)
                        laboratoryWorkListItemMasterModel.isOld = true;
                    if (p.Age.HasValue && p.Age.Value < 7)
                        laboratoryWorkListItemMasterModel.isYoung = true;
                    if (p.hasMedicalInformation())
                        laboratoryWorkListItemMasterModel.hasMedicalInformation = true;

                    return laboratoryWorkListItemMasterModel;
                }
                else
                    return null;
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Laboratuvar_Is_Listesi_Genel_Listeleme)]
        public LaboratoryWorkListFormViewModel QueryLaboratoryWorkList(QueryInputDVO inputdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                LaboratoryWorkListFormViewModel model = new LaboratoryWorkListFormViewModel();
                if (inputdvo.StartDate.HasValue == false)
                    inputdvo.StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                if (inputdvo.EndDate.HasValue == false)
                    inputdvo.EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                inputdvo.MinDate = Convert.ToDateTime("01.01.1900 00:00:00");
                setWorkListDefinition();
                if (workListDefinition.LastSpecialPanel == null)
                {
                    IList pDefs = SpecialPanelDefinition.GetByUserAndWorkListDef(objectContext, Common.CurrentResource.ObjectID.ToString(), workListDefinition.ObjectID.ToString()); //inMemory_Context olmalı
                    foreach (SpecialPanelDefinition pDef in pDefs)
                    {
                        if (pDef.Name == "@DEFAULT@")
                        {
                            TTObjectContext objectContextEditable = new TTObjectContext(false);
                            WorkListDefinition workListDefinitionEditable = (WorkListDefinition)objectContextEditable.GetObject(workListDefinition.ObjectID, typeof(WorkListDefinition));
                            workListDefinitionEditable.LastSpecialPanel = pDef;
                            SpecialPanelListItem lastSpecialPanelListItem = createNewSpecialPanelListItem(pDef);
                            model.LastSelectedSpecialPanel = lastSpecialPanelListItem;
                            objectContextEditable.Save();
                            break;
                        }
                    }
                }

                string filterExpression = string.Empty;
                if (string.IsNullOrEmpty(inputdvo.StateType) == false)
                    filterExpression += " AND CURRENTSTATE IS " + inputdvo.StateType;
                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    filterExpression += " AND THIS:EPISODE:PATIENTSTATUS IN (" + inputdvo.PatientStatus + ")";
                if (!String.IsNullOrEmpty(inputdvo.txtPatient))
                {
                    //PatientSearch componenti kullanıldığı için değiştirildi.
                    filterExpression += " AND THIS:EPISODE:PATIENT:OBJECTID = '" + inputdvo.txtPatient + "'";
                }

                if (inputdvo.SelectedWorkListItems != null && inputdvo.SelectedWorkListItems.Count > 0)
                {
                    List<Guid> objectDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListItem wli in inputdvo.SelectedWorkListItems)
                    {
                        objectDefIDs.Add(new Guid(wli.ObjectDefID));
                    }

                    filterExpression += Common.CreateFilterExpressionOfGuidList(filterExpression, "OBJECTDEFID", objectDefIDs);
                }

                if (inputdvo.SelectedWorkListStateItems != null && inputdvo.SelectedWorkListStateItems.Count > 0)
                {
                    List<Guid> stateDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListStateItem wlsi in inputdvo.SelectedWorkListStateItems)
                    {
                        stateDefIDs.Add(new Guid(wlsi.StateDefID));
                    }

                    filterExpression += Common.CreateFilterExpressionOfGuidList(filterExpression, "CURRENTSTATEDEFID", stateDefIDs);
                }

                //IBindingList doctorsWorkList = EpisodeAction.GetByEpisodeActionWorklistDateReport(inputdvo.StartDate.Value, inputdvo.EndDate.Value, inputdvo.MinDate.Value, filterExpression);
                //TODO: LaboratoryProcedure objesı olan episodeları sorgula.

    

                if (!String.IsNullOrEmpty(inputdvo.txtSEProtocolNo)) //Kabul no ile arandıysa diğer kriterleri kontrol etmemeli
                {
                    if(inputdvo.txtSEProtocolNo.Contains("-"))
                    {
                        filterExpression = " AND THIS:SUBEPISODE:PROTOCOLNO = '" + inputdvo.txtSEProtocolNo.Trim() + "'";
                    }
                    else
                    {
                        filterExpression = " AND THIS:SUBEPISODE:PROTOCOLNO LIKE '" + inputdvo.txtSEProtocolNo.Trim() + "%'";
                    }
           
                  


                    

                }

                model.LaboratoryProcedureMasterList = new List<LaboratoryWorkListItemMasterModel>();
                IBindingList laboratoryMasterWorkList = LaboratoryProcedure.GetLabProcedureByWorklistDate(inputdvo.StartDate.Value, inputdvo.EndDate.Value, filterExpression);
                foreach (LaboratoryProcedure.GetLabProcedureByWorklistDate_Class lpm in laboratoryMasterWorkList)
                {
                    LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel();
                    Episode e = (Episode)objectContext.GetObject(lpm.Episode.Value, "EPISODE");
                    Patient p = e.Patient;
                    laboratoryWorkListItemMasterModel.EpisodeID = e.ObjectID.ToString();
                    laboratoryWorkListItemMasterModel.PatientTCNo = p.UniqueRefNo.ToString();
                    laboratoryWorkListItemMasterModel.PatientNameSurname = p.FullName;
                    laboratoryWorkListItemMasterModel.PatientID = p.ID.ToString();
                    laboratoryWorkListItemMasterModel.PatientBirthDate = Convert.ToDateTime(p.BirthDate).ToString("dd.MM.yyyy");
                    //lpm.ek


                    //Asagidaki kod Barcode etiketi bilgileri icin
                    //yatan hasta ise yatis bilgileri dolacak
                    if (e.PatientStatus != PatientStatusEnum.Outpatient)
                    {
                        laboratoryWorkListItemMasterModel.PatientStatus = "Y";
                        laboratoryWorkListItemMasterModel.PatientBirthCity =p.BirthPlace;
                        if (e.GetMyPatientGroupDefinition() != null)
                            laboratoryWorkListItemMasterModel.PatientGroup = e.GetMyPatientGroupDefinition().ToString();
                        laboratoryWorkListItemMasterModel.PatientSex = p.Sex.ADI;

                        laboratoryWorkListItemMasterModel.PatientDoctor = "";

                        var lastIpa = e.GetLastInpatientAdmission();
                        if (lastIpa != null)
                        {
                            laboratoryWorkListItemMasterModel.InPatientDate = Convert.ToDateTime(lastIpa.HospitalInPatientDate).ToString("dd.MM.yyyy");
                            if (lastIpa.HospitalDischargeDate != null)
                                laboratoryWorkListItemMasterModel.DischargeDate = Convert.ToDateTime(lastIpa.HospitalDischargeDate).ToString("dd.MM.yyyy");
                            laboratoryWorkListItemMasterModel.DefNo = lastIpa.QuarantineProtocolNo.ToString();  //TODO:kontrol edilecek
                        }

                        laboratoryWorkListItemMasterModel.ArsivNo = ""; //TODO:kontrol edilecek

                    }
                    else
                        laboratoryWorkListItemMasterModel.PatientStatus = "A";


                    //Episode altındaki test bilgilerinden ulaşılacak veriler için testler dönülüyor.
                    //List<LaboratoryWorkListItemDetailModel> LaboratoryProcedureList = new List<LaboratoryWorkListItemDetailModel>();
                    //List<LaboratoryProcedure> laboratoryWorkList = LaboratoryProcedure.GetLaboratoryProcedureByEpisodeByWorkListDateNQL(objectContext, inputdvo.StartDate.Value, inputdvo.EndDate.Value, lpm.Episode.Value, filterExpression).ToList();
                    //EpisodeAction ea = null;

                    //foreach (LaboratoryProcedure laboratoryTest in laboratoryWorkList)
                    //{
                    //    if (laboratoryTest.EpisodeAction != null)
                    //    {
                    //        ea = laboratoryTest.EpisodeAction;
                    //        break;
                    //    }
                    //}
                    ////laboratoryWorkListItemMasterModel.ID = patientAdm.FirstSubEpisode?.ProtocolNo;
                    //laboratoryWorkListItemMasterModel.FromResourceName = ea.FromResource?.Name;
                    //laboratoryWorkListItemMasterModel.LabRequestObjectID = ea.ObjectID.ToString();

                    //üstteki sorgu vt gidişi azalmtak buna çevrildi
                    List<LaboratoryProcedure.GetLaboratoryProcedureByEpisodeByWorkListDate_Class> laboratoryWorkList = LaboratoryProcedure.GetLaboratoryProcedureByEpisodeByWorkListDate(lpm.Episode.Value, inputdvo.StartDate.Value, inputdvo.EndDate.Value, filterExpression).ToList();
                    if (laboratoryWorkList != null && laboratoryWorkList.Count > 0)
                    {
                        laboratoryWorkListItemMasterModel.FromResourceName = laboratoryWorkList[0].Fromresource;
                        laboratoryWorkListItemMasterModel.LabRequestObjectID = laboratoryWorkList[0].Actionid.ToString();
                    }

                    model.LaboratoryProcedureMasterList.Add(laboratoryWorkListItemMasterModel);
                }

                model.txtPatient = inputdvo.txtPatient;
                model.StartDate = (DateTime)inputdvo.StartDate;
                model.EndDate = (DateTime)inputdvo.EndDate;
                model.ID = inputdvo.ID;
                if (inputdvo.WorkListCount > 0)
                    model.WorkListCount = (int)inputdvo.WorkListCount;
                model.StateType = inputdvo.StateType;
                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    model.PatientStatus = inputdvo.PatientStatus;
                objectContext.FullPartialllyLoadedObjects();
                return model;
            }
        }


        [HttpPost]
        public LaboratoryWorkListItemMasterModel QueryLaboratoryDetailItemByEpisodeForMainLabWorkList(QueryInputDVOByEpisode inputdvo)
        {

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel();

                if (inputdvo.StartDate.HasValue == false)
                    inputdvo.StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                if (inputdvo.EndDate.HasValue == false)
                    inputdvo.EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                string filterExpression = string.Empty;
                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    filterExpression += " AND THIS:EPISODE:PATIENTSTATUS IN (" + inputdvo.PatientStatus + ")";
                List<string> selectedLabStates = new List<string>();
                if (inputdvo.SelectedWorkListStateItems != null && inputdvo.SelectedWorkListStateItems.Count > 0)
                {
                    List<Guid> stateDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListStateItem wlsi in inputdvo.SelectedWorkListStateItems)
                    {
                        stateDefIDs.Add(new Guid(wlsi.StateDefID));
                        selectedLabStates.Add(wlsi.StateDefID);
                    }

                    filterExpression += Common.CreateFilterExpressionOfGuidList(filterExpression, "CURRENTSTATEDEFID", stateDefIDs);
                }

                Episode e = (Episode)objectContext.GetObject(new Guid(inputdvo.EpisodeID), "EPISODE");
                laboratoryWorkListItemMasterModel.EpisodeID = e.ObjectID.ToString();
                laboratoryWorkListItemMasterModel.LabRequestObjectID = inputdvo.LabRequestObjectID;
                laboratoryWorkListItemMasterModel.PatientTCNo = e.Patient.UniqueRefNo.ToString();
                laboratoryWorkListItemMasterModel.PatientNameSurname = e.Patient.FullName;
                laboratoryWorkListItemMasterModel.PatientID = e.Patient.ID.ToString();
                laboratoryWorkListItemMasterModel.PatientBirthDate = Convert.ToDateTime(e.Patient.BirthDate).ToString("dd.MM.yyyy");


                //Asagidaki kod Barcode etiketi bilgileri icin
                //yatan hasta ise yatis bilgileri dolacak
                if (e.PatientStatus != PatientStatusEnum.Outpatient)
                {
                    laboratoryWorkListItemMasterModel.PatientStatus = "Y";
                    laboratoryWorkListItemMasterModel.PatientBirthCity = e.Patient.BirthPlace;
                    if (e.GetMyPatientGroupDefinition() != null)
                        laboratoryWorkListItemMasterModel.PatientGroup = e.GetMyPatientGroupDefinition().ToString();
                    laboratoryWorkListItemMasterModel.PatientSex = e.Patient.Sex.ADI;

                    laboratoryWorkListItemMasterModel.PatientDoctor = "";

                    var lastIpa = e.GetLastInpatientAdmission();
                    if (lastIpa != null)
                    {
                        laboratoryWorkListItemMasterModel.InPatientDate = Convert.ToDateTime(lastIpa.HospitalInPatientDate).ToString("dd.MM.yyyy");
                        if (lastIpa.HospitalDischargeDate != null)
                            laboratoryWorkListItemMasterModel.DischargeDate = Convert.ToDateTime(lastIpa.HospitalDischargeDate).ToString("dd.MM.yyyy");
                        laboratoryWorkListItemMasterModel.DefNo = lastIpa.QuarantineProtocolNo.ToString();  //TODO:kontrol edilecek
                    }

                    laboratoryWorkListItemMasterModel.ArsivNo = ""; //TODO:kontrol edilecek

                }
                else
                    laboratoryWorkListItemMasterModel.PatientStatus = "A";




                laboratoryWorkListItemMasterModel.SelectedLaboratoryStateItems = selectedLabStates;



                //herbır masteritem ıcın lab procedureler dondurulecek
                List<LaboratoryWorkListItemDetailModel> LaboratoryProcedureList = new List<LaboratoryWorkListItemDetailModel>();
                List<Laboratuar_Is_Listesi.TubeInformation> TubeInformationList = new List<Laboratuar_Is_Listesi.TubeInformation>();
                Dictionary<string, Laboratuar_Is_Listesi.TubeInformation> LabProceduresTubeInfoList = new Dictionary<string, Laboratuar_Is_Listesi.TubeInformation>();
                List<LaboratoryProcedure> laboratoryWorkList = LaboratoryProcedure.GetLaboratoryProcedureByEpisodeByWorkListDateNQL(objectContext, inputdvo.StartDate.Value, inputdvo.EndDate.Value, new Guid(inputdvo.EpisodeID), filterExpression).ToList();

                foreach (LaboratoryProcedure laboratoryTest in laboratoryWorkList)
                {
                    LaboratoryWorkListItemDetailModel laboratoryWorkListItemDetailModel = new LaboratoryWorkListItemDetailModel();
                    laboratoryWorkListItemDetailModel.ObjectID = laboratoryTest.ObjectID;
                    laboratoryWorkListItemDetailModel.ObjectDefName = laboratoryTest.ObjectDef.Name;
                    laboratoryWorkListItemDetailModel.PatientNameSurname = laboratoryTest.Episode.Patient.FullName;
                    laboratoryWorkListItemDetailModel.FromResourceName = laboratoryTest.EpisodeAction.FromResource.Name;
                    laboratoryWorkListItemDetailModel.LaboratoryTestName = laboratoryTest.ProcedureObject.Name.ToString();
                    laboratoryWorkListItemDetailModel.WorkListDate = (DateTime)laboratoryTest.WorkListDate.Value;
                    laboratoryWorkListItemDetailModel.RequestDate = Convert.ToDateTime(laboratoryTest.RequestDate).ToString("dd-MM-yyyy HH:mm");
                    laboratoryWorkListItemDetailModel.RequestedByUser = laboratoryTest.Laboratory.RequestDoctor.Name;
                    laboratoryWorkListItemDetailModel.StateName = laboratoryTest.CurrentStateDef.DisplayText;
                    laboratoryWorkListItemDetailModel.StateDefID = laboratoryTest.CurrentStateDefID.ToString();
                    if (laboratoryTest.Emergency == true)
                        laboratoryWorkListItemDetailModel.isLabTestEmergency = true;
                    laboratoryWorkListItemDetailModel.TestCode = laboratoryTest.ProcedureObject.Code;
                    laboratoryWorkListItemDetailModel.TestLoincCode = ((LaboratoryTestDefinition)laboratoryTest.ProcedureObject).FreeLOINCCode;
                    laboratoryWorkListItemDetailModel.BarcodeID = laboratoryTest.BarcodeId.ToString();
                    laboratoryWorkListItemDetailModel.SpecimenID = laboratoryTest.SpecimenId.ToString();
                    if (laboratoryTest.ResultDate != null)
                        laboratoryWorkListItemDetailModel.ResultDate = Convert.ToDateTime(laboratoryTest.ResultDate).ToString("dd-MM-yyyy HH:mm");
                    else
                        laboratoryWorkListItemDetailModel.ResultDate = "";
                    if (laboratoryTest.SampleDate != null)
                        laboratoryWorkListItemDetailModel.SampleDate = Convert.ToDateTime(laboratoryTest.SampleDate).ToString("dd-MM-yyyy HH:mm");
                    else
                        laboratoryWorkListItemDetailModel.SampleDate = "";
                    if (laboratoryTest.ApproveDate != null)
                        laboratoryWorkListItemDetailModel.ApproveDate = Convert.ToDateTime(laboratoryTest.ApproveDate).ToString("dd-MM-yyyy HH:mm");
                    else
                        laboratoryWorkListItemDetailModel.ApproveDate = "";
                    if (laboratoryTest.BarcodePrintDate != null)
                        laboratoryWorkListItemDetailModel.BarcodePrintDate = Convert.ToDateTime(laboratoryTest.BarcodePrintDate).ToString("dd-MM-yyyy HH:mm");
                    else
                        laboratoryWorkListItemDetailModel.BarcodePrintDate = "";
                    laboratoryWorkListItemDetailModel.Result = laboratoryTest.Result;
                    laboratoryWorkListItemDetailModel.Unit = laboratoryTest.Unit;
                    laboratoryWorkListItemDetailModel.Reference = laboratoryTest.Reference;
                    //Panel test ise laboratorysubprocedure objelerı de doldurulacak
                    if (((LaboratoryTestDefinition)laboratoryTest.ProcedureObject).IsPanel == true)
                    {
                        List<LaboratoryWorkListSubItemDetailModel> LaboratorySubProcedureList = new List<LaboratoryWorkListSubItemDetailModel>();
                        laboratoryWorkListItemDetailModel.isPanelTest = (Boolean)((LaboratoryTestDefinition)laboratoryTest.ProcedureObject).IsPanel;
                        foreach (LaboratorySubProcedure labsubProc in laboratoryTest.ChildSubActionProcedure)
                        {
                            LaboratoryWorkListSubItemDetailModel laboratoryWorkListSubItemDetailModel = new LaboratoryWorkListSubItemDetailModel();
                            laboratoryWorkListSubItemDetailModel.ObjectID = labsubProc.ObjectID;
                            laboratoryWorkListSubItemDetailModel.MasterSubactionProcedureID = laboratoryTest.ObjectID;
                            laboratoryWorkListSubItemDetailModel.TestCode = labsubProc.ProcedureObject.Code;
                            laboratoryWorkListSubItemDetailModel.LaboratoryTestName = labsubProc.ProcedureObject.Name;
                            laboratoryWorkListSubItemDetailModel.BarcodeID = laboratoryTest.BarcodeId.ToString();
                            laboratoryWorkListSubItemDetailModel.SpecimenID = laboratoryTest.SpecimenId.ToString();
                            laboratoryWorkListSubItemDetailModel.Result = labsubProc.Result;
                            laboratoryWorkListSubItemDetailModel.Unit = labsubProc.Unit;
                            laboratoryWorkListSubItemDetailModel.Reference = labsubProc.Reference;
                            LaboratorySubProcedureList.Add(laboratoryWorkListSubItemDetailModel);
                        }

                        laboratoryWorkListItemDetailModel.LaboratorySubProcedureList = LaboratorySubProcedureList;
                    }

                    laboratoryWorkListItemDetailModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();
                    if (laboratoryWorkListItemMasterModel.LabRequestObjectID == null)
                        laboratoryWorkListItemMasterModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();


                    //Dis Istem oldugu bilgisi set ediliyor
                    Resource masterResource = (Resource)laboratoryTest.EpisodeAction.MasterResource;
                    laboratoryWorkListItemDetailModel.isExternalProcedureRequest = false;
                    if (masterResource is ResObservationUnit)
                    {
                        if (((ResObservationUnit)masterResource).IsExternalObservationUnit == true)
                            laboratoryWorkListItemDetailModel.isExternalProcedureRequest = true;
                    }
                    laboratoryWorkListItemDetailModel.EpisodeActionObjectId = laboratoryTest.EpisodeAction.ObjectID;


                    //Tetkik kategori bilgisi set ediliyor. Tetkik'in katolog tanımında karşılığı bulunmaması durumunu karşılamak için öncelikle Diğer olarak set ediliyor.
                    laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = TTUtils.CultureService.GetText("M12780", "Diğer");
                    bool categoryNameOK = false;
                    if (laboratoryTest.ProcedureObject.FormDetail != null)
                    {
                        //Tetkik Sık Kullanılanlar Kategorisinde ise o grup altında çıkması istenmiyor. ResUser ile eşlenmiş ProcedureRequestForm un kategori isminin çıkmaması için aşağıdaki kod yazıldı.
                        for (int i = 0; i < laboratoryTest.ProcedureObject.FormDetail.Count; i++)
                        {
                            ProcedureRequestFormDefinition procedureReqForm = laboratoryTest.ProcedureObject.FormDetail[i].ProcedureRequestCategory?.ProcedureRequestForm;
                            if (procedureReqForm != null)
                            {
                                foreach (RequestUnitOfProcedureForm requestFormResource in procedureReqForm.RequestUnitsOfProcedureForm)
                                {
                                    if (!(requestFormResource.Resource is ResUser))
                                    {
                                        laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = laboratoryTest.ProcedureObject.FormDetail[i].ProcedureRequestCategory?.CategoryName;
                                        categoryNameOK = true;
                                        break;
                                    }
                                }
                                if (categoryNameOK == true)
                                    break;
                            }
                        }
                    }

                    string microscopicExaminationStr = "Mikroskopik inceleme";
                    if (laboratoryTest.ProcedureObject.ProcedureTree.ObjectID.ToString() == "66022707-6322-4ece-b725-99ba1dcf0e56" && laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName != null && laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName.ToUpper() == microscopicExaminationStr.ToUpper())
                    {
                        laboratoryWorkListItemDetailModel.isMicroscopicExamination = true;
                        laboratoryWorkListItemDetailModel.ResultDescription = laboratoryTest.ResultDescription;
                    }

                        LaboratoryProcedureList.Add(laboratoryWorkListItemDetailModel);

                    if (laboratoryTest.TubeInformation != null)
                    {
                        Laboratuar_Is_Listesi.TubeInformation tubeInfo = new Laboratuar_Is_Listesi.TubeInformation();
                        string containerID = laboratoryTest.TubeInformation.ContainerID.ToString();
                        if (LabProceduresTubeInfoList.TryGetValue(containerID, out tubeInfo) == false)
                        {
                            if (tubeInfo == null)
                                tubeInfo = new Laboratuar_Is_Listesi.TubeInformation();
                            tubeInfo.FromResourceName = laboratoryTest.TubeInformation.FromResourceName;
                            tubeInfo.SpecimenID = laboratoryTest.TubeInformation.SpecimenID.ToString();
                            tubeInfo.ContainerID = laboratoryTest.TubeInformation.ContainerID.ToString();
                            tubeInfo.SpecialHandlingCode = laboratoryTest.TubeInformation.Description;
                            tubeInfo.OtherEnvFactor = laboratoryTest.TubeInformation.BarcodeType;
                            LabProceduresTubeInfoList.Add(containerID, tubeInfo);
                        }
                    }

                }

                laboratoryWorkListItemMasterModel.LaboratoryProcedureList = LaboratoryProcedureList;


                foreach (KeyValuePair<string, Laboratuar_Is_Listesi.TubeInformation> tubeInfo in LabProceduresTubeInfoList)
                {
                    TubeInformationList.Add(tubeInfo.Value);
                }
                laboratoryWorkListItemMasterModel.TubeInformationList = TubeInformationList;
                

                return laboratoryWorkListItemMasterModel;
            }
        }

        public void AcceptProceduresWithBarcode(List<LaboratoryProcedure> laboratoryRequests,TTObjectContext objectContext)
        {

            ProcedureInfoInputDVO procedureInfoInputDVO = new ProcedureInfoInputDVO();

            foreach (var procedure in laboratoryRequests)
            {
                if (procedureInfoInputDVO.LabRequestObjectID == null)
                    procedureInfoInputDVO.LabRequestObjectID = procedure.Laboratory.ObjectID.ToString();
                if (procedure.CurrentStateDefID == LaboratoryProcedure.States.SampleTaking)
                {
                    if (procedureInfoInputDVO.LabProcedures == null)
                        procedureInfoInputDVO.LabProcedures = new List<string>();
                    procedureInfoInputDVO.LabProcedures.Add(procedure.ObjectID.ToString());
                }
            }

            if (procedureInfoInputDVO.LabRequestObjectID != null && procedureInfoInputDVO.LabProcedures != null && procedureInfoInputDVO.LabProcedures.Count > 0)
                SampleTakingToSampleLaboratoryAccept(procedureInfoInputDVO,objectContext);

        }

        [HttpGet]
        public SampleAcceptBarcodeModel GetSampleAcceptBarcodeFormViewModel(string BarcodeId)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                SampleAcceptBarcodeModel laboratoryWorkListItemMasterModel = new SampleAcceptBarcodeModel();
                laboratoryWorkListItemMasterModel.LastReadedBarcode = BarcodeId;
                //herbır masteritem ıcın lab procedureler dondurulecek
                List<LaboratoryWorkListItemDetailModel> LaboratoryProcedureList = new List<LaboratoryWorkListItemDetailModel>();
                List<LaboratoryProcedure.GetLabProcedureByBarcodeId_Class> laboratoryProcedureList = LaboratoryProcedure.GetLabProcedureByBarcodeId(Convert.ToInt64(BarcodeId)).ToList();
                List<LaboratoryProcedure> laboratoryProcedures = new List<LaboratoryProcedure>();

                foreach (var labProc in laboratoryProcedureList)
                {
                    laboratoryProcedures.Add(objectContext.GetObject<LaboratoryProcedure>((Guid)labProc.ObjectID));
                }
                if (laboratoryProcedures.Where(t => t.CurrentStateDefID == LaboratoryProcedure.States.SampleTaking).ToList().Count > 0)
                    laboratoryWorkListItemMasterModel.IsTransitionMade = true;
                AcceptProceduresWithBarcode(laboratoryProcedures,objectContext);

                foreach (LaboratoryProcedure laboratoryTest in laboratoryProcedures)
                {
                    LaboratoryWorkListItemDetailModel laboratoryWorkListItemDetailModel = new LaboratoryWorkListItemDetailModel();
                    laboratoryWorkListItemDetailModel.ObjectID = laboratoryTest.ObjectID;
                    laboratoryWorkListItemDetailModel.ObjectDefName = laboratoryTest.ObjectDef.Name;
                    laboratoryWorkListItemDetailModel.PatientNameSurname = laboratoryTest.Episode.Patient.FullName;
                    laboratoryWorkListItemDetailModel.FromResourceName = laboratoryTest.EpisodeAction.FromResource.Name;
                    laboratoryWorkListItemDetailModel.LaboratoryTestName = laboratoryTest.ProcedureObject.Name.ToString();
                    laboratoryWorkListItemDetailModel.WorkListDate = (DateTime)laboratoryTest.WorkListDate.Value;
                    laboratoryWorkListItemDetailModel.RequestDate = Convert.ToDateTime(laboratoryTest.RequestDate).ToString("dd-MM-yyyy HH:mm");
                    laboratoryWorkListItemDetailModel.RequestedByUser = laboratoryTest.Laboratory.RequestDoctor.Name;
                    laboratoryWorkListItemDetailModel.SampleUser = laboratoryTest.SampleUser != null?laboratoryTest.SampleUser.Name : "";
                    laboratoryWorkListItemDetailModel.StateName = laboratoryTest.CurrentStateDef.DisplayText;
                    laboratoryWorkListItemDetailModel.StateDefID = laboratoryTest.CurrentStateDefID.ToString();
                    if (laboratoryTest.Emergency == true)
                        laboratoryWorkListItemDetailModel.isLabTestEmergency = true;
                    laboratoryWorkListItemDetailModel.TestCode = laboratoryTest.ProcedureObject.Code;
                    laboratoryWorkListItemDetailModel.TestLoincCode = ((LaboratoryTestDefinition)laboratoryTest.ProcedureObject).FreeLOINCCode;
                    laboratoryWorkListItemDetailModel.BarcodeID = laboratoryTest.BarcodeId.ToString();
                    laboratoryWorkListItemDetailModel.SpecimenID = laboratoryTest.SpecimenId.ToString();
                    if (laboratoryTest.ResultDate != null)
                        laboratoryWorkListItemDetailModel.ResultDate = Convert.ToDateTime(laboratoryTest.ResultDate).ToString("dd-MM-yyyy HH:mm");
                    else
                        laboratoryWorkListItemDetailModel.ResultDate = "";
                    if (laboratoryTest.SampleDate != null)
                        laboratoryWorkListItemDetailModel.SampleDate = Convert.ToDateTime(laboratoryTest.SampleDate).ToString("dd-MM-yyyy HH:mm:ss");
                    else
                        laboratoryWorkListItemDetailModel.SampleDate = "";
                    if (laboratoryTest.ApproveDate != null)
                        laboratoryWorkListItemDetailModel.ApproveDate = Convert.ToDateTime(laboratoryTest.ApproveDate).ToString("dd-MM-yyyy HH:mm");
                    else
                        laboratoryWorkListItemDetailModel.ApproveDate = "";
                    if (laboratoryTest.BarcodePrintDate != null)
                        laboratoryWorkListItemDetailModel.BarcodePrintDate = Convert.ToDateTime(laboratoryTest.BarcodePrintDate).ToString("dd-MM-yyyy HH:mm");
                    else
                        laboratoryWorkListItemDetailModel.BarcodePrintDate = "";
                    laboratoryWorkListItemDetailModel.Result = laboratoryTest.Result;
                    laboratoryWorkListItemDetailModel.Unit = laboratoryTest.Unit;
                    laboratoryWorkListItemDetailModel.Reference = laboratoryTest.Reference;
                    //Panel test ise laboratorysubprocedure objelerı de doldurulacak
                    if (((LaboratoryTestDefinition)laboratoryTest.ProcedureObject).IsPanel == true)
                    {
                        List<LaboratoryWorkListSubItemDetailModel> LaboratorySubProcedureList = new List<LaboratoryWorkListSubItemDetailModel>();
                        laboratoryWorkListItemDetailModel.isPanelTest = (Boolean)((LaboratoryTestDefinition)laboratoryTest.ProcedureObject).IsPanel;
                        foreach (LaboratorySubProcedure labsubProc in laboratoryTest.ChildSubActionProcedure)
                        {
                            LaboratoryWorkListSubItemDetailModel laboratoryWorkListSubItemDetailModel = new LaboratoryWorkListSubItemDetailModel();
                            laboratoryWorkListSubItemDetailModel.ObjectID = labsubProc.ObjectID;
                            laboratoryWorkListSubItemDetailModel.MasterSubactionProcedureID = laboratoryTest.ObjectID;
                            laboratoryWorkListSubItemDetailModel.TestCode = labsubProc.ProcedureObject.Code;
                            laboratoryWorkListSubItemDetailModel.LaboratoryTestName = labsubProc.ProcedureObject.Name;
                            laboratoryWorkListSubItemDetailModel.BarcodeID = laboratoryTest.BarcodeId.ToString();
                            laboratoryWorkListSubItemDetailModel.SpecimenID = laboratoryTest.SpecimenId.ToString();
                            laboratoryWorkListSubItemDetailModel.Result = labsubProc.Result;
                            laboratoryWorkListSubItemDetailModel.Unit = labsubProc.Unit;
                            laboratoryWorkListSubItemDetailModel.Reference = labsubProc.Reference;
                            LaboratorySubProcedureList.Add(laboratoryWorkListSubItemDetailModel);
                        }

                        laboratoryWorkListItemDetailModel.LaboratorySubProcedureList = LaboratorySubProcedureList;
                    }

                    laboratoryWorkListItemDetailModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();
                    if (laboratoryWorkListItemMasterModel.LabRequestObjectID == null)
                        laboratoryWorkListItemMasterModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();


                    //Dis Istem oldugu bilgisi set ediliyor
                    Resource masterResource = (Resource)laboratoryTest.EpisodeAction.MasterResource;
                    laboratoryWorkListItemDetailModel.isExternalProcedureRequest = false;
                    if (masterResource is ResObservationUnit)
                    {
                        if (((ResObservationUnit)masterResource).IsExternalObservationUnit == true)
                            laboratoryWorkListItemDetailModel.isExternalProcedureRequest = true;
                    }
                    laboratoryWorkListItemDetailModel.EpisodeActionObjectId = laboratoryTest.EpisodeAction.ObjectID;


                    //Tetkik kategori bilgisi set ediliyor. Tetkik'in katolog tanımında karşılığı bulunmaması durumunu karşılamak için öncelikle Diğer olarak set ediliyor.
                    laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = TTUtils.CultureService.GetText("M12780", "Diğer");
                    bool categoryNameOK = false;
                    if (laboratoryTest.ProcedureObject.FormDetail != null)
                    {
                        //Tetkik Sık Kullanılanlar Kategorisinde ise o grup altında çıkması istenmiyor. ResUser ile eşlenmiş ProcedureRequestForm un kategori isminin çıkmaması için aşağıdaki kod yazıldı.
                        for (int i = 0; i < laboratoryTest.ProcedureObject.FormDetail.Count; i++)
                        {
                            ProcedureRequestFormDefinition procedureReqForm = laboratoryTest.ProcedureObject.FormDetail[i].ProcedureRequestCategory?.ProcedureRequestForm;
                            if (procedureReqForm != null)
                            {
                                foreach (RequestUnitOfProcedureForm requestFormResource in procedureReqForm.RequestUnitsOfProcedureForm)
                                {
                                    if (!(requestFormResource.Resource is ResUser))
                                    {
                                        laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = laboratoryTest.ProcedureObject.FormDetail[i].ProcedureRequestCategory?.CategoryName;
                                        categoryNameOK = true;
                                        break;
                                    }
                                }
                                if (categoryNameOK == true)
                                    break;
                            }
                        }
                    }


                    LaboratoryProcedureList.Add(laboratoryWorkListItemDetailModel);

                }

                laboratoryWorkListItemMasterModel.LaboratoryProcedureList = LaboratoryProcedureList;


                return laboratoryWorkListItemMasterModel;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Laboratuvar_Is_Listesi_Genel_Listeleme)]
        public LaboratoryWorkListFormViewModel QueryLaboratoryWorkListByResultBarcode(string specimenID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                LaboratoryWorkListFormViewModel model = new LaboratoryWorkListFormViewModel();
                PatientAdmission patientAdm = null;
                Boolean isPatientAdmSet;
                model.LaboratoryProcedureMasterList = new List<LaboratoryWorkListItemMasterModel>();

                LaboratoryWorkListItemMasterModel laboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel();
                int i = 0;
                //herbır masteritem ıcın lab procedureler dondurulecek
                List<LaboratoryWorkListItemDetailModel> LaboratoryProcedureList = new List<LaboratoryWorkListItemDetailModel>();
                List<Laboratuar_Is_Listesi.TubeInformation> TubeInformationList = new List<Laboratuar_Is_Listesi.TubeInformation>();
                Dictionary<string, Laboratuar_Is_Listesi.TubeInformation> LabProceduresTubeInfoList = new Dictionary<string, Laboratuar_Is_Listesi.TubeInformation>();

                List<LaboratoryProcedure> laboratoryWorkList = LaboratoryProcedure.GetLaboratoryProcedureBySpecimenIdForWorkList(objectContext, specimenID).ToList();
                foreach (LaboratoryProcedure laboratoryTest in laboratoryWorkList)
                {
                    if (i == 0)
                    {
                        isPatientAdmSet = false;
                        Episode e = (Episode)objectContext.GetObject(laboratoryTest.SubEpisode.Episode.ObjectID, "EPISODE");
                        model.txtPatient = e.Patient.ObjectID.ToString();


                        if (e.PatientStatus == PatientStatusEnum.Outpatient)
                            model.PatientStatus = "0";
                        else if (e.PatientStatus == PatientStatusEnum.Inpatient)
                            model.PatientStatus = "1";
                        else if (e.PatientStatus == PatientStatusEnum.PreDischarge || e.PatientStatus == PatientStatusEnum.Discharge)
                            model.PatientStatus = "2";

                        laboratoryWorkListItemMasterModel.EpisodeID = e.ObjectID.ToString();
                        laboratoryWorkListItemMasterModel.PatientTCNo = e.Patient.UniqueRefNo.ToString();
                        laboratoryWorkListItemMasterModel.PatientNameSurname = e.Patient.FullName;
                        laboratoryWorkListItemMasterModel.PatientID = e.Patient.ID.ToString();
                        laboratoryWorkListItemMasterModel.PatientBirthDate = Convert.ToDateTime(e.Patient.BirthDate).ToString("dd.MM.yyyy");

                        //Asagidaki kod Barcode etiketi bilgileri icin
                        //yatan hasta ise yatis bilgileri dolacak
                        if (e.PatientStatus != PatientStatusEnum.Outpatient)
                        {
                            laboratoryWorkListItemMasterModel.PatientStatus = "Y";
                            laboratoryWorkListItemMasterModel.PatientBirthCity = e.Patient.BirthPlace;
                            if (e.GetMyPatientGroupDefinition() != null)
                                laboratoryWorkListItemMasterModel.PatientGroup = e.GetMyPatientGroupDefinition().ToString();
                            laboratoryWorkListItemMasterModel.PatientSex = e.Patient.Sex.ADI;

                            laboratoryWorkListItemMasterModel.PatientDoctor = "";
                            if (laboratoryTest.SubEpisode.InpatientAdmission != null)
                            {
                                laboratoryWorkListItemMasterModel.InPatientDate = Convert.ToDateTime(laboratoryTest.SubEpisode.InpatientAdmission.HospitalInPatientDate).ToString("dd.MM.yyyy");
                                if (laboratoryTest.SubEpisode.InpatientAdmission.HospitalDischargeDate != null)
                                    laboratoryWorkListItemMasterModel.DischargeDate = Convert.ToDateTime(laboratoryTest.SubEpisode.InpatientAdmission.HospitalDischargeDate).ToString("dd.MM.yyyy");
                                laboratoryWorkListItemMasterModel.DefNo = laboratoryTest.SubEpisode.InpatientAdmission.QuarantineProtocolNo.ToString();  //TODO:kontrol edilecek
                            }
                            laboratoryWorkListItemMasterModel.ArsivNo = ""; //TODO:kontrol edilecek

                        }
                        else
                            laboratoryWorkListItemMasterModel.PatientStatus = "A";

                        if (laboratoryWorkListItemMasterModel.LabRequestObjectID == null)
                            laboratoryWorkListItemMasterModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();

                        if (laboratoryTest.SubEpisode != null && isPatientAdmSet == false)
                        {
                            patientAdm = laboratoryTest.SubEpisode.PatientAdmission;
                            isPatientAdmSet = true;
                        }

                        if (patientAdm != null)
                        {
                            if (patientAdm.PriorityStatus != null)
                            {
                                if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25767", "Hamileler"))
                                    laboratoryWorkListItemMasterModel.isPregnant = true;
                                if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25090", "65 Yaş Üstü Yaşlılar"))
                                    laboratoryWorkListItemMasterModel.isOld = true;
                                if (patientAdm.PriorityStatus.Name == "Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler")
                                    laboratoryWorkListItemMasterModel.isVetera = true;
                                if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25097", "Acil Vakalar"))
                                    laboratoryWorkListItemMasterModel.isEmergency = true;
                                if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25590", "Engelliler"))
                                    laboratoryWorkListItemMasterModel.isDisabled = true;
                                if (patientAdm.PriorityStatus.Name == TTUtils.CultureService.GetText("M25091", "7 Yaşından Küçük Çocuklar"))
                                    laboratoryWorkListItemMasterModel.isYoung = true;
                            }
                        }
                        if (e.Patient.ActivePregnancy != null || (e.Patient.MedicalInformation != null && e.Patient.MedicalInformation.Pregnancy.HasValue && e.Patient.MedicalInformation.Pregnancy.Value == true))
                            laboratoryWorkListItemMasterModel.isPregnant = true;
                        if (e.Patient.Age.HasValue && e.Patient.Age.Value > 65)
                            laboratoryWorkListItemMasterModel.isOld = true;
                        if (e.Patient.Age.HasValue && e.Patient.Age.Value < 7)
                            laboratoryWorkListItemMasterModel.isYoung = true;
                        if (e.Patient.hasMedicalInformation())
                            laboratoryWorkListItemMasterModel.hasMedicalInformation = true;

                    }

                    LaboratoryWorkListItemDetailModel laboratoryWorkListItemDetailModel = new LaboratoryWorkListItemDetailModel();
                    laboratoryWorkListItemDetailModel.ObjectID = laboratoryTest.ObjectID;
                    laboratoryWorkListItemDetailModel.ObjectDefName = laboratoryTest.ObjectDef.Name;
                    laboratoryWorkListItemDetailModel.PatientNameSurname = laboratoryTest.Episode.Patient.FullName;
                    if (laboratoryTest.SubEpisode != null && laboratoryTest.SubEpisode.PatientAdmission != null && laboratoryTest.SubEpisode.PatientAdmission.FirstSubEpisode != null)
                    {
                        if (laboratoryTest.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo != null)
                        {
                            laboratoryWorkListItemMasterModel.ID = laboratoryTest.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo;
                        }


                    }

                    laboratoryWorkListItemDetailModel.FromResourceName = laboratoryTest.EpisodeAction.FromResource.Name;
                    if (laboratoryWorkListItemMasterModel.FromResourceName == null)
                        laboratoryWorkListItemMasterModel.FromResourceName = laboratoryTest.EpisodeAction.FromResource.Name;
                    laboratoryWorkListItemDetailModel.LaboratoryTestName = laboratoryTest.ProcedureObject.Name.ToString();
                    laboratoryWorkListItemDetailModel.WorkListDate = (DateTime)laboratoryTest.WorkListDate.Value;
                    laboratoryWorkListItemDetailModel.RequestDate = Convert.ToDateTime(laboratoryTest.RequestDate).ToString("dd-MM-yyyy HH:mm");
                    laboratoryWorkListItemDetailModel.RequestedByUser = laboratoryTest.Laboratory.RequestDoctor.Name;
                    laboratoryWorkListItemDetailModel.StateName = laboratoryTest.CurrentStateDef.DisplayText;
                    laboratoryWorkListItemDetailModel.StateDefID = laboratoryTest.CurrentStateDefID.ToString();
                    if (laboratoryTest.Emergency == true)
                        laboratoryWorkListItemDetailModel.isLabTestEmergency = true;
                    laboratoryWorkListItemDetailModel.TestCode = laboratoryTest.ProcedureObject.Code;
                    laboratoryWorkListItemDetailModel.TestLoincCode = ((LaboratoryTestDefinition)laboratoryTest.ProcedureObject).FreeLOINCCode;
                    laboratoryWorkListItemDetailModel.BarcodeID = laboratoryTest.BarcodeId.ToString();
                    laboratoryWorkListItemDetailModel.SpecimenID = laboratoryTest.SpecimenId.ToString();
                    if (laboratoryTest.ResultDate != null)
                        laboratoryWorkListItemDetailModel.ResultDate = Convert.ToDateTime(laboratoryTest.ResultDate).ToString("dd-MM-yyyy HH:mm");
                    else
                        laboratoryWorkListItemDetailModel.ResultDate = "";
                    if (laboratoryTest.SampleDate != null)
                        laboratoryWorkListItemDetailModel.SampleDate = Convert.ToDateTime(laboratoryTest.SampleDate).ToString("dd-MM-yyyy HH:mm");
                    else
                        laboratoryWorkListItemDetailModel.SampleDate = "";
                    if (laboratoryTest.ApproveDate != null)
                        laboratoryWorkListItemDetailModel.ApproveDate = Convert.ToDateTime(laboratoryTest.ApproveDate).ToString("dd-MM-yyyy HH:mm");
                    else
                        laboratoryWorkListItemDetailModel.ApproveDate = "";
                    if (laboratoryTest.BarcodePrintDate != null)
                        laboratoryWorkListItemDetailModel.BarcodePrintDate = Convert.ToDateTime(laboratoryTest.BarcodePrintDate).ToString("dd-MM-yyyy HH:mm");
                    else
                        laboratoryWorkListItemDetailModel.BarcodePrintDate = "";
                    laboratoryWorkListItemDetailModel.Result = laboratoryTest.Result;
                    laboratoryWorkListItemDetailModel.Unit = laboratoryTest.Unit;
                    laboratoryWorkListItemDetailModel.Reference = laboratoryTest.Reference;
                    //Panel test ise laboratorysubprocedure objelerı de doldurulacak
                    if (((LaboratoryTestDefinition)laboratoryTest.ProcedureObject).IsPanel == true)
                    {
                        List<LaboratoryWorkListSubItemDetailModel> LaboratorySubProcedureList = new List<LaboratoryWorkListSubItemDetailModel>();
                        laboratoryWorkListItemDetailModel.isPanelTest = (Boolean)((LaboratoryTestDefinition)laboratoryTest.ProcedureObject).IsPanel;
                        foreach (LaboratorySubProcedure labsubProc in laboratoryTest.ChildSubActionProcedure)
                        {
                            LaboratoryWorkListSubItemDetailModel laboratoryWorkListSubItemDetailModel = new LaboratoryWorkListSubItemDetailModel();
                            laboratoryWorkListSubItemDetailModel.ObjectID = labsubProc.ObjectID;
                            laboratoryWorkListSubItemDetailModel.MasterSubactionProcedureID = laboratoryTest.ObjectID;
                            laboratoryWorkListSubItemDetailModel.TestCode = labsubProc.ProcedureObject.Code;
                            laboratoryWorkListSubItemDetailModel.LaboratoryTestName = labsubProc.ProcedureObject.Name;
                            laboratoryWorkListSubItemDetailModel.BarcodeID = laboratoryTest.BarcodeId.ToString();
                            laboratoryWorkListSubItemDetailModel.SpecimenID = laboratoryTest.SpecimenId.ToString();
                            laboratoryWorkListSubItemDetailModel.Result = labsubProc.Result;
                            laboratoryWorkListSubItemDetailModel.Unit = labsubProc.Unit;
                            laboratoryWorkListSubItemDetailModel.Reference = labsubProc.Reference;
                            LaboratorySubProcedureList.Add(laboratoryWorkListSubItemDetailModel);
                        }

                        laboratoryWorkListItemDetailModel.LaboratorySubProcedureList = LaboratorySubProcedureList;
                    }

                    laboratoryWorkListItemDetailModel.LabRequestObjectID = laboratoryTest.Laboratory.ObjectID.ToString();

                    //Dis Istem oldugu bilgisi set ediliyor
                    Resource masterResource = (Resource)laboratoryTest.EpisodeAction.MasterResource;
                    laboratoryWorkListItemDetailModel.isExternalProcedureRequest = false;
                    if (masterResource is ResObservationUnit)
                    {
                        if (((ResObservationUnit)masterResource).IsExternalObservationUnit == true)
                            laboratoryWorkListItemDetailModel.isExternalProcedureRequest = true;
                    }
                    laboratoryWorkListItemDetailModel.EpisodeActionObjectId = laboratoryTest.EpisodeAction.ObjectID;

                    ////Tetkik kategori bilgisi set ediliyor.
                    //laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = TTUtils.CultureService.GetText("M12780", "Diğer");
                    //if (laboratoryTest.ProcedureObject.FormDetail != null)
                    //{
                    //    if (laboratoryTest.ProcedureObject.FormDetail.Count > 0)
                    //        laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = laboratoryTest.ProcedureObject.FormDetail[0].ProcedureRequestCategory?.CategoryName;
                    //}

                    //Tetkik kategori bilgisi set ediliyor. Tetkik'in katolog tanımında karşılığı bulunmaması durumunu karşılamak için öncelikle Diğer olarak set ediliyor.
                    laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = TTUtils.CultureService.GetText("M12780", "Diğer");
                    bool categoryNameOK = false;
                    if (laboratoryTest.ProcedureObject.FormDetail != null)
                    {
                        //Tetkik Sık Kullanılanlar Kategorisinde ise o grup altında çıkması istenmiyor. ResUser ile eşlenmiş ProcedureRequestForm un kategori isminin çıkmaması için aşağıdaki kod yazıldı.
                        for (int j = 0; j < laboratoryTest.ProcedureObject.FormDetail.Count; j++)
                        {
                            ProcedureRequestFormDefinition procedureReqForm = laboratoryTest.ProcedureObject.FormDetail[j].ProcedureRequestCategory?.ProcedureRequestForm;
                            if (procedureReqForm != null)
                            {
                                foreach (RequestUnitOfProcedureForm requestFormResource in procedureReqForm.RequestUnitsOfProcedureForm)
                                {
                                    if (!(requestFormResource.Resource is ResUser))
                                    {
                                        laboratoryWorkListItemDetailModel.ProcedureRequestFormCategoryName = laboratoryTest.ProcedureObject.FormDetail[j].ProcedureRequestCategory?.CategoryName;
                                        categoryNameOK = true;
                                        break;
                                    }
                                }
                                if (categoryNameOK == true)
                                    break;
                            }
                        }
                    }


                    LaboratoryProcedureList.Add(laboratoryWorkListItemDetailModel);
                    if (laboratoryTest.TubeInformation != null)
                    {
                        Laboratuar_Is_Listesi.TubeInformation tubeInfo = new Laboratuar_Is_Listesi.TubeInformation();
                        string containerID = laboratoryTest.TubeInformation.ContainerID.ToString();
                        if (LabProceduresTubeInfoList.TryGetValue(containerID, out tubeInfo) == false)
                        {
                            if (tubeInfo == null)
                                tubeInfo = new Laboratuar_Is_Listesi.TubeInformation();
                            tubeInfo.FromResourceName = laboratoryTest.TubeInformation.FromResourceName;
                            tubeInfo.SpecimenID = laboratoryTest.TubeInformation.SpecimenID.ToString();
                            tubeInfo.ContainerID = laboratoryTest.TubeInformation.ContainerID.ToString();
                            tubeInfo.SpecialHandlingCode = laboratoryTest.TubeInformation.Description;
                            tubeInfo.OtherEnvFactor = laboratoryTest.TubeInformation.BarcodeType;
                            LabProceduresTubeInfoList.Add(containerID, tubeInfo);
                        }
                    }

                    i++;

                }
                laboratoryWorkListItemMasterModel.LaboratoryProcedureList = LaboratoryProcedureList;

                foreach (KeyValuePair<string, Laboratuar_Is_Listesi.TubeInformation> tubeInfo in LabProceduresTubeInfoList)
                {
                    TubeInformationList.Add(tubeInfo.Value);
                }
                laboratoryWorkListItemMasterModel.TubeInformationList = TubeInformationList;

                model.LaboratoryProcedureMasterList.Add(laboratoryWorkListItemMasterModel);
                objectContext.FullPartialllyLoadedObjects();
                return model;
            }


        }

        public ExaminationQueueItem CreateExaminationQueueItem(LaboratoryRequest laboratoryRequest, ExaminationQueueDefinition appQueueDef, bool isEmergency, ResUser currentUser)
        {

            ExaminationQueueItem examinationQueueItem = null;

            if (TTObjectClasses.SystemParameter.GetParameterValue("CloseExaminationQueueItem", "FALSE") != "TRUE")
            {
                if (laboratoryRequest.MasterResource != null && laboratoryRequest.MasterResource is ResObservationUnit)
                {
                    if (laboratoryRequest.Episode.Patient.HasActiveQueueItemInQueue(appQueueDef, currentUser) == null)
                    {
                        examinationQueueItem = new ExaminationQueueItem(laboratoryRequest.ObjectContext);
                        examinationQueueItem.EpisodeAction = laboratoryRequest;
                        examinationQueueItem.Appointment = null;
                        examinationQueueItem.CurrentStateDefID = TTObjectClasses.ExaminationQueueItem.States.New;
                        examinationQueueItem.Patient = laboratoryRequest.Episode.Patient;

                        if (laboratoryRequest.LaboratoryProcedures != null && laboratoryRequest.LaboratoryProcedures.Count > 0 && laboratoryRequest.LaboratoryProcedures[0] != null)
                        {
                            examinationQueueItem.Priority = (laboratoryRequest.LaboratoryProcedures[0].SubEpisode.PatientAdmission.PriorityStatus == null) ? 5000 : laboratoryRequest.LaboratoryProcedures[0].SubEpisode.PatientAdmission.PriorityStatus.Order;
                            examinationQueueItem.PriorityReason = (laboratoryRequest.LaboratoryProcedures[0].SubEpisode.PatientAdmission.PriorityStatus == null) ? "" : laboratoryRequest.LaboratoryProcedures[0].SubEpisode.PatientAdmission.PriorityStatus.Name;
                        }
                        examinationQueueItem.QueueDate = Common.RecTime().Date;
                        examinationQueueItem.CallTime = Common.RecTime();
                        examinationQueueItem.ExaminationQueueDefinition = appQueueDef;
                        examinationQueueItem.DivertedTime = Common.RecTime();
                        examinationQueueItem.Doctor = currentUser;
                        examinationQueueItem.CallCount = 0;
                    }
                }
            }

            return examinationQueueItem;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Laboratuvar_Istek_Kabul)]
        public List<ProcedureInfoOutputDVO> SampleAcceptToSampleTaking(ProcedureInfoInputDVO inputDVO)
        {
            //LIS entegrasyonuna gitmeden once Ucretli Hastalar icin borc kontrolu yapiliyor.
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                foreach (string labProcObjectID in inputDVO.LabProcedures)
                {
                    LaboratoryProcedure labProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(labProcObjectID), "LABORATORYPROCEDURE");
                    if (labProcedure != null)
                    {
                        if (labProcedure.Paid() == false)
                            throw new TTException(SystemMessage.GetMessage(141));
                    }
                }
            }

            //Istek Kabul asamasindan Numune Alma asamasina geciliyor.
            //LIS a tetkik kaydetme yapiliyor, cevapta donen Barcode, specimen ve tup bilgileri HBYS de saklaniyor.
            if (TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXENTEGRATION", "FALSE") == "TRUE")
            {

                List<ProcedureInfoOutputDVO> responseList = new List<ProcedureInfoOutputDVO>();

                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    Dictionary<ResSection, List<LaboratoryProcedure>> LabProceduresByFromResList = new Dictionary<ResSection, List<LaboratoryProcedure>>();
                    Dictionary<Guid, LaboratoryRequest> LaboratoryRequestActionList = new Dictionary<Guid, LaboratoryRequest>();

                    foreach (string labProcObjectID in inputDVO.LabProcedures)
                    {
                        LaboratoryProcedure labProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(labProcObjectID), "LABORATORYPROCEDURE");
                        if (labProcedure != null)
                        {
                            List<LaboratoryProcedure> lpList = new List<LaboratoryProcedure>();
                            LaboratoryRequest labRequest = null;

                            //Distinct laboratoryrequestepisodeaction lar toplanıyor
                            if (LaboratoryRequestActionList.TryGetValue(labProcedure.Laboratory.ObjectID, out labRequest) == false)
                            {
                                if (labRequest == null)
                                {
                                    labRequest = labProcedure.Laboratory;
                                    LaboratoryRequestActionList.Add(labRequest.ObjectID, labRequest);
                                }
                            }


                            if (LabProceduresByFromResList.TryGetValue(labProcedure.Laboratory.FromResource, out lpList) == false)
                            {
                                if (lpList == null)
                                    lpList = new List<LaboratoryProcedure>();
                                lpList.Add(labProcedure);
                                LabProceduresByFromResList.Add(labProcedure.Laboratory.FromResource, lpList);
                            }
                            else
                            {
                                lpList.Add(labProcedure);
                            }
                        }
                    }

                    if (LabProceduresByFromResList.Count > 0)
                    {
                        responseList = SendToLabLIS(new Guid(inputDVO.EpisodeID), LabProceduresByFromResList);
                    }

                    foreach (ProcedureInfoOutputDVO resultInfo in responseList)
                    {
                        foreach (ProcedureInformation labProcedureInfo in resultInfo.LabProcedures)
                        {
                            foreach (string lpObjectID in inputDVO.LabProcedures)
                            {
                                if (lpObjectID == labProcedureInfo.PlacerOrderNumber)
                                {
                                    LaboratoryProcedure laboratoryProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(lpObjectID), "LABORATORYPROCEDURE");
                                    laboratoryProcedure.SpecimenId = Convert.ToInt32(resultInfo.SpecimenID);
                                    laboratoryProcedure.BarcodeId = Convert.ToInt64(labProcedureInfo.PlacerGroupNumber);
                                    //Numune Kabul Tarihi bu asamada set edilmeyecek. Sonuc bilgisi guncellenirken set edilecek.
                                    //laboratoryProcedure.SampleAcceptionDate = (DateTime)DateTime.Now;
                                    //laboratoryProcedure.AcceptUser = Common.CurrentResource;
                                    laboratoryProcedure.CurrentStateDefID = LaboratoryProcedure.States.SampleTaking;
                                    foreach (TubeInformation tubeInfo in resultInfo.TubeInformations)
                                    {
                                        if (tubeInfo.ContainerID == labProcedureInfo.PlacerGroupNumber)
                                        {
                                            //IBindingList laboratoryProcTubeInfoList = LaboratoryProcedureTubeInfo.GetLabProcedureTubeByContainerID(objectContext, Convert.ToInt64(labProcedureInfo.PlacerGroupNumber));
                                            IBindingList laboratoryProcTubeInfoList = objectContext.LocalQuery<LaboratoryProcedureTubeInfo>("CONTAINERID = " + Convert.ToInt64(labProcedureInfo.PlacerGroupNumber));

                                            if (laboratoryProcTubeInfoList.Count == 0)
                                            {
                                                LaboratoryProcedureTubeInfo laboratoryProcTubeInfo = new LaboratoryProcedureTubeInfo(objectContext);
                                                laboratoryProcTubeInfo.ContainerID = Convert.ToInt64(tubeInfo.ContainerID);
                                                laboratoryProcTubeInfo.Description = tubeInfo.SpecialHandlingCode;
                                                laboratoryProcTubeInfo.BarcodeType = tubeInfo.OtherEnvFactor;
                                                laboratoryProcTubeInfo.SpecimenID = Convert.ToInt64(tubeInfo.SpecimenID);
                                                laboratoryProcTubeInfo.FromResourceName = tubeInfo.FromResourceName;
                                                laboratoryProcTubeInfo.RequestAcceptionDate = Convert.ToDateTime(tubeInfo.RequestAcceptionDate);
                                                laboratoryProcedure.TubeInformation = laboratoryProcTubeInfo;
                                            }
                                            else
                                                laboratoryProcedure.TubeInformation = (LaboratoryProcedureTubeInfo)laboratoryProcTubeInfoList[0];
                                            break;
                                        }
                                    }

                                    laboratoryProcedure.Update();
                                }
                            }
                        }
                    }


                    if (TTObjectClasses.SystemParameter.GetParameterValue("LABORATORYLCDOPEN", "FALSE") == "TRUE")
                    {
                        //NUMUNE ALMA LCD ye ekleme
                        if (responseList.Count > 0)
                        {
                            foreach (KeyValuePair<Guid, LaboratoryRequest> labReq in LaboratoryRequestActionList)
                            {
                                if (labReq.Value != null)
                                {
                                    //Ayaktan hasta icin yapılan istemler monitore  dusecek.
                                    if (labReq.Value.FromResource is ResPoliclinic)
                                    {
                                        string resource = "";
                                        //Mikrobiyoloji Laboratuvari icin ayri kuyruk tanimi yapilamadigi icin resource bilgisi her zaman LABSAMPLEREQUESTQUEURESOURCE Biyokimya Lab. olarak yonlendirildi. 
                                        //Resource bilgisi systemparametresinden alinacak sekilde degisiklik yapildi.
                                        resource = TTObjectClasses.SystemParameter.GetParameterValue("LABSAMPLEREQUESTQUEURESOURCE", "4e6fa78f-868f-4f94-8c0c-0f7fdd63f6be");

                                        IList<ExaminationQueueDefinition> myQueue = ExaminationQueueDefinition.GetQueueByResource(objectContext, resource);
                                        if (myQueue.Count > 0)
                                        {
                                            this.CreateExaminationQueueItem(labReq.Value, myQueue[0], false, Common.CurrentResource);
                                            break;
                                        }

                                    }
                                }
                            }
                        }
                        //NUMUNE ALMA LCD
                    }


                    objectContext.Save();
                    return responseList;
                }
            }
            else
                return null;
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Laboratuvar_Istek_Kabul)]
        public List<ProcedureInfoOutputDVO> SampleAcceptToSampleTakingGroupByPatient(ProcedureInfoInputDVO inputDVO)
        {
            //LIS entegrasyonuna gitmeden once Ucretli Hastalar icin borc kontrolu yapiliyor.
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                foreach (string labProcObjectID in inputDVO.LabProcedures)
                {
                    LaboratoryProcedure labProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(labProcObjectID), "LABORATORYPROCEDURE");
                    if (labProcedure != null)
                    {
                        if (labProcedure.Paid() == false)
                            throw new TTException(SystemMessage.GetMessage(141));
                    }
                }
            }

            //Istek Kabul asamasindan Numune Alma asamasina geciliyor.
            //LIS a tetkik kaydetme yapiliyor, cevapta donen Barcode, specimen ve tup bilgileri HBYS de saklaniyor.
            if (TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXENTEGRATION", "FALSE") == "TRUE")
            {

                List<ProcedureInfoOutputDVO> responseList = new List<ProcedureInfoOutputDVO>();

                using (TTObjectContext objectContext = new TTObjectContext(false))
                {

                    Dictionary<Guid, LaboratoryRequest> LaboratoryRequestActionList = new Dictionary<Guid, LaboratoryRequest>();
                    Dictionary<ResSection, List<LaboratoryProcedure>> LabProceduresByFromResList = new Dictionary<ResSection, List<LaboratoryProcedure>>();
                    ResSection fromResource = null;
                    List<LaboratoryProcedure> lpList = new List<LaboratoryProcedure>();

                    foreach (string labProcObjectID in inputDVO.LabProcedures)
                    {
                        LaboratoryProcedure labProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(labProcObjectID), "LABORATORYPROCEDURE");
                        if (labProcedure != null)
                        {
                            LaboratoryRequest labRequest = labProcedure.Laboratory;
                            LaboratoryRequestActionList.Add(labRequest.ObjectID, labRequest);

                            fromResource = labProcedure.Laboratory.FromResource;
                            break;
                        }
                    }

                    //Listedeki ilk istenmiş olan tetkiğin LaboratoryRequestAction ı ve FromResource bilgisi alınıyor.

                    foreach (string labProcObjectID in inputDVO.LabProcedures)
                    {
                        LaboratoryProcedure labProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(labProcObjectID), "LABORATORYPROCEDURE");
                        if (labProcedure != null)
                            lpList.Add(labProcedure);
                    }
                    LabProceduresByFromResList.Add(fromResource, lpList);


                    if (LabProceduresByFromResList.Count > 0)
                    {
                        responseList = SendToLabLIS(new Guid(inputDVO.EpisodeID), LabProceduresByFromResList);
                    }

                    foreach (ProcedureInfoOutputDVO resultInfo in responseList)
                    {
                        foreach (ProcedureInformation labProcedureInfo in resultInfo.LabProcedures)
                        {
                            foreach (string lpObjectID in inputDVO.LabProcedures)
                            {
                                if (lpObjectID == labProcedureInfo.PlacerOrderNumber)
                                {
                                    LaboratoryProcedure laboratoryProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(lpObjectID), "LABORATORYPROCEDURE");
                                    laboratoryProcedure.SpecimenId = Convert.ToInt32(resultInfo.SpecimenID);
                                    laboratoryProcedure.BarcodeId = Convert.ToInt64(labProcedureInfo.PlacerGroupNumber);
                                    //Numune Kabul Tarihi bu asamada set edilmeyecek. Sonuc bilgisi guncellenirken set edilecek.
                                    //laboratoryProcedure.SampleAcceptionDate = (DateTime)DateTime.Now;
                                    //laboratoryProcedure.AcceptUser = Common.CurrentResource;
                                    laboratoryProcedure.CurrentStateDefID = LaboratoryProcedure.States.SampleTaking;
                                    foreach (TubeInformation tubeInfo in resultInfo.TubeInformations)
                                    {
                                        if (tubeInfo.ContainerID == labProcedureInfo.PlacerGroupNumber)
                                        {
                                            //IBindingList laboratoryProcTubeInfoList = LaboratoryProcedureTubeInfo.GetLabProcedureTubeByContainerID(objectContext, Convert.ToInt64(labProcedureInfo.PlacerGroupNumber));
                                            IBindingList laboratoryProcTubeInfoList = objectContext.LocalQuery<LaboratoryProcedureTubeInfo>("CONTAINERID = " + Convert.ToInt64(labProcedureInfo.PlacerGroupNumber));

                                            if (laboratoryProcTubeInfoList.Count == 0)
                                            {
                                                LaboratoryProcedureTubeInfo laboratoryProcTubeInfo = new LaboratoryProcedureTubeInfo(objectContext);
                                                laboratoryProcTubeInfo.ContainerID = Convert.ToInt64(tubeInfo.ContainerID);
                                                laboratoryProcTubeInfo.Description = tubeInfo.SpecialHandlingCode;
                                                laboratoryProcTubeInfo.BarcodeType = tubeInfo.OtherEnvFactor;
                                                laboratoryProcTubeInfo.SpecimenID = Convert.ToInt64(tubeInfo.SpecimenID);
                                                laboratoryProcTubeInfo.FromResourceName = tubeInfo.FromResourceName;
                                                laboratoryProcTubeInfo.RequestAcceptionDate = Convert.ToDateTime(tubeInfo.RequestAcceptionDate);
                                                laboratoryProcedure.TubeInformation = laboratoryProcTubeInfo;
                                            }
                                            else
                                                laboratoryProcedure.TubeInformation = (LaboratoryProcedureTubeInfo)laboratoryProcTubeInfoList[0];
                                            break;
                                        }
                                    }

                                    laboratoryProcedure.Update();
                                }
                            }
                        }
                    }


                    if (TTObjectClasses.SystemParameter.GetParameterValue("LABORATORYLCDOPEN", "FALSE") == "TRUE")
                    {
                        //NUMUNE ALMA LCD ye ekleme
                        if (responseList.Count > 0)
                        {
                            foreach (KeyValuePair<Guid, LaboratoryRequest> labReq in LaboratoryRequestActionList)
                            {
                                if (labReq.Value != null)
                                {
                                    //Ayaktan hasta icin yapılan istemler monitore  dusecek.
                                    if (labReq.Value.FromResource is ResPoliclinic)
                                    {
                                        string resource = "";
                                        //Mikrobiyoloji Laboratuvari icin ayri kuyruk tanimi yapilamadigi icin resource bilgisi her zaman LABSAMPLEREQUESTQUEURESOURCE Biyokimya Lab. olarak yonlendirildi. 
                                        //Resource bilgisi systemparametresinden alinacak sekilde degisiklik yapildi.
                                        resource = TTObjectClasses.SystemParameter.GetParameterValue("LABSAMPLEREQUESTQUEURESOURCE", "4e6fa78f-868f-4f94-8c0c-0f7fdd63f6be");

                                        IList<ExaminationQueueDefinition> myQueue = ExaminationQueueDefinition.GetQueueByResource(objectContext, resource);
                                        if (myQueue.Count > 0)
                                        {
                                            this.CreateExaminationQueueItem(labReq.Value, myQueue[0], false, Common.CurrentResource);
                                            break;
                                        }

                                    }
                                }
                            }
                        }
                        //NUMUNE ALMA LCD
                    }


                    objectContext.Save();
                    return responseList;
                }
            }
            else
                return null;
        }



        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Laboratuvar_Numune_Alma)]
        public void SampleTakingToSampleLaboratoryAccept(ProcedureInfoInputDVO inputDVO, TTObjectContext objectContext = null)
        {
            //Numune Alma asamasindan Laboratuvarda asamasina geciliyor.
            //LIS a Kan Alma zamani bilgisi gonderiliyor, HBYS de Numune Alinma Tarihi bilgisi saklaniyor. 
            if (TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXENTEGRATION", "FALSE") == "TRUE")
            {
                List<string> LaboratoryRequestList = new List<string>();
                bool isContextCreated = false;
                if (objectContext == null)
                {
                    objectContext = new TTObjectContext(false);
                    isContextCreated = true;
                }
                foreach (string labProcObjectID in inputDVO.LabProcedures)
                {
                    LaboratoryProcedure labProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(labProcObjectID), "LABORATORYPROCEDURE");
                    if (labProcedure != null)
                    {
                        //SampleAcceptToSampleTaking asamasina kontrol konuldugu icin asagidaki kod kapatildi.
                        //if (labProcedure.Paid() == false)
                        //    throw new TTException(SystemMessage.GetMessage(141));

                        labProcedure.SampleDate = (DateTime)DateTime.Now; //Numune Alınma Tarihi
                        labProcedure.SampleUser = Common.CurrentResource;
                        labProcedure.CurrentStateDefID = LaboratoryProcedure.States.SampleLaboratoryAccept;
                        if (!LaboratoryRequestList.Contains(labProcedure.Laboratory.ObjectID.ToString()))
                            LaboratoryRequestList.Add(labProcedure.Laboratory.ObjectID.ToString());
                        UpdateSampleDateForLaboratoryProcedure(labProcedure.SpecimenId.ToString(), labProcedure.BarcodeId.ToString(), (DateTime)labProcedure.SampleDate);
                    }
                }


                if (TTObjectClasses.SystemParameter.GetParameterValue("LABORATORYLCDOPEN", "FALSE") == "TRUE")
                {
                    if (LaboratoryRequestList.Count > 0)
                    {
                        foreach (string labReqObjectId in LaboratoryRequestList)
                        {
                            List<ExaminationQueueItem> queueItem = ExaminationQueueItem.GetByEpisodeAction(objectContext, new Guid(labReqObjectId)).ToList();
                            if (queueItem.Count > 0)
                            {
                                if (queueItem[0].CurrentStateDefID != ExaminationQueueItem.States.Completed)
                                {
                                    queueItem[0].CurrentStateDefID = ExaminationQueueItem.States.Completed;
                                }
                            }
                        }

                    }
                }
                objectContext.Save();
                if (isContextCreated)
                    objectContext.Dispose();
            }
        }

        [HttpPost]
        public void ProcedureToComplete(ProcedureResultInfoInputDVO inputDVO)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                foreach (ProcedureResultInfo labProcResult in inputDVO.LabProceduresResultInfo)
                {
                    LaboratoryProcedure labProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(labProcResult.LaboratoryProcedureObjectID), "LABORATORYPROCEDURE");
                    if (labProcedure != null)
                    {
                        labProcedure.ResultDate = (DateTime)labProcResult.ResultDate;
                        labProcedure.Result = labProcResult.Result;
                        labProcedure.Unit = labProcResult.Unit;
                        labProcedure.Reference = labProcResult.Reference;
                        labProcedure.CurrentStateDefID = LaboratoryProcedure.States.Completed;
                        //TODO: LIS a sonuc gonderılecek mı?
                        //UpdateSampleDateForLaboratoryProcedure(labProcedure.SpecimenId.ToString(), labProcedure.BarcodeId.ToString(), (DateTime)labProcedure.SampleDate);
                    }
                }

                objectContext.Save();
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Laboratuvar_Istek_Iptal)]
        public void SampleAcceptToCancelled(ProcedureInfoInputDVO inputDVO)
        {
            //Istek Kabul asamasindan Iptal asamasina geciliyor.
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                foreach (string labProcObjectID in inputDVO.LabProcedures)
                {
                    LaboratoryProcedure labProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(labProcObjectID), "LABORATORYPROCEDURE");
                    if (labProcedure != null)
                    {
                        labProcedure.CurrentStateDefID = LaboratoryProcedure.States.Cancelled;
                    }
                }

                objectContext.Save();
            }
        }

        public List<ProcedureInfoOutputDVO> SendToLabLIS(Guid episodeID, Dictionary<ResSection, List<LaboratoryProcedure>> LabProceduresByFromResList)
        {
            List<ProcedureInfoOutputDVO> responseList = new List<ProcedureInfoOutputDVO>();
            foreach (KeyValuePair<ResSection, List<LaboratoryProcedure>> labProcedureByFromRes in LabProceduresByFromResList)
            {
                try
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    XXXXXXIHEWS.ORL34 orl34 = new XXXXXXIHEWS.ORL34();
                    XXXXXXIHEWS.OML33 oml33 = new XXXXXXIHEWS.OML33();
                    XXXXXXIHEWS.MSH msh = new XXXXXXIHEWS.MSH();
                    XXXXXXIHEWS.Patient patient = new XXXXXXIHEWS.Patient();
                    XXXXXXIHEWS.PID pid = new XXXXXXIHEWS.PID();
                    XXXXXXIHEWS.PV1 pv1 = new XXXXXXIHEWS.PV1();
                    List<XXXXXXIHEWS.DG1> dgList = new List<XXXXXXIHEWS.DG1>();
                    List<XXXXXXIHEWS.Order> orderList = new List<XXXXXXIHEWS.Order>();
                    List<XXXXXXIHEWS.OML33Specimen> oml33SpecimenList = new List<XXXXXXIHEWS.OML33Specimen>();
                    List<XXXXXXIHEWS.OBX> obxList = new List<XXXXXXIHEWS.OBX>();
                    Episode e = (Episode)objectContext.GetObject(episodeID, "EPISODE");
                    //MSH, mesaj basligi segmenti
                    msh.EncodingCharacters = @"^~\&";
                    msh.SendingApplication = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXSENDINGAPPLICATION", "ATLASHBYS_ATLAS");  //"HBYS_TEST";
                    msh.SendingFacility = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXSENDINGFACILITY", "ATLAS_FTR");  //"HBYS_TEST_HOSPITAL";
                    msh.DateTimeOfMessage = DateTime.Now.ToString("yyyyMMddHHmmss");
                    msh.ReceivingApplication = "XXXXXX";
                    msh.ReceivingFacility = "XXXXXX_Kurumu";
                    msh.MessageType = "OML^O33^OML_O33";
                    Random random = new Random();
                    msh.MessageControlID = random.Next(9999, 19999).ToString();
                    //Patient.PID  hasta bilgileri segmenti     
                    pid.PatientID = e.Patient.UniqueRefNo.ToString(); //"10000000000";

                    //Eski sistemden aktarılan hastalar için eski sistemdeki Patient.ID gönderilecek (Patient.VemHastaKodu)
                    if (!string.IsNullOrEmpty(e.Patient.VemHastaKodu))
                        pid.PatientIdentifierList = e.Patient.VemHastaKodu.ToString() + "^^^" + "ATLAS_ATLASDEV^PI";
                    else
                        pid.PatientIdentifierList = e.Patient.ID.ToString() + "^^^" + "ATLAS_ATLASDEV^PI";


                    pid.PatientName = e.Patient.Surname + "^" + e.Patient.Name; //"DENEME^DENEME";
                    if (e.Patient.Mother != null)
                        pid.MothersMaidenName = e.Patient.FatherName + "^" + e.Patient.MotherName + "^" + e.Patient.Mother.UniqueRefNo; //"BABA^ANNE^10000000000";
                    else
                        pid.MothersMaidenName = e.Patient.FatherName + "^" + e.Patient.MotherName; //"BABA^ANNE^10000000000";
                    if (e.Patient.Sex != null)
                    {
                        if (e.Patient.Sex.ADI == "KADIN")
                            pid.Sex = "F";
                        else if (e.Patient.Sex.ADI == "ERKEK")
                            pid.Sex = "M";
                        else
                            pid.Sex = "O";
                    }
                    else
                        pid.Sex = "U";
                    pid.DateTimeofBirth = Convert.ToDateTime(e.Patient.BirthDate).ToString("yyyyMMddHHmmss"); //"19791102000000";
                    if (e.Patient.PatientAddress != null)
                    {
                        pid.PhoneNumberHome = e.Patient.PatientAddress.HomePhone; //"05555555555";
                        pid.PhoneNumberBusiness = e.Patient.PatientAddress.BusinessPhone; //"05555555555";
                        pid.PatientAddress = e.Patient.PatientAddress.HomeAddress; //"Bilinmiyor";
                    }
                    pid.PatientAccountNumber = e.ID.ToString(); //msh.MessageControlID;
                    if (e.Patient.Heigth != null)
                        pid.Strain = e.Patient.Heigth.ToString();

                    //Patient.PV1, gelis bilgileri segmenti             
                    pv1.PatientClass = "O";
                    pv1.VisitNumber = e.ID.ToString(); //msh.MessageControlID;
                    if (labProcedureByFromRes.Key is ResPoliclinic)
                        pv1.HospitalService = labProcedureByFromRes.Key.Qref + "^" + labProcedureByFromRes.Key.Name + "^P"; //"SRV01^DENEME_SERVIS^S";
                    if (labProcedureByFromRes.Key is ResClinic)
                        pv1.HospitalService = labProcedureByFromRes.Key.Qref + "^" + labProcedureByFromRes.Key.Name + "^S"; //"SRV01^DENEME_SERVIS^S";
                    //Patient segmenti
                    patient.Pid = pid;
                    patient.Pv1 = pv1;
                    foreach (DiagnosisGrid dg in e.Diagnosis)
                    {
                        XXXXXXIHEWS.DG1 dg1 = new XXXXXXIHEWS.DG1();
                        dg1.DiagnosisCode = dg.Diagnose.Code; //"J02.9";
                        dg1.DiagnosisDescription = dg.Diagnose.Name; //"Akut farenjit, tanımlanmamış";
                        dgList.Add(dg1);
                    }

                    foreach (LaboratoryProcedure labProc in labProcedureByFromRes.Value)
                    {
                        //Order.OBR, tetkik bilgisi segmenti
                        string skrsLoincKodu = "";
                        XXXXXXIHEWS.OBR obr = new XXXXXXIHEWS.OBR();
                        obr.PlacerOrderNumber = labProc.ObjectID.ToString();

                        //DIS laboratuvar tetkiki ise obr.PlacerField1  alanina 2 degeri gonderiliyor, ic tetkik ise 1 gonderiliyor
                        obr.Placerfield1 = "1";
                        if (labProc.MasterResource is ResObservationUnit)
                            if (((ResObservationUnit)labProc.MasterResource).IsExternalObservationUnit == true)
                                obr.Placerfield1 = "2";

                        if (((LaboratoryTestDefinition)labProc.ProcedureObject).FreeLOINCCode == null || ((LaboratoryTestDefinition)labProc.ProcedureObject).FreeLOINCCode == "")
                            throw new Exception("Serbest Loinc Kodu (LIS Enteg. Kod) bulunamadı:" + labProc.ProcedureObject.Code + "-" + labProc.ProcedureObject.Name);
                        else
                        {
                            //if (labProc.ProcedureObject.SKRSLoincKodu.LOINCNUMARASI == null || labProc.ProcedureObject.SKRSLoincKodu.LOINCNUMARASI == "")
                            //    throw new Exception("SKRSLoinc Numarası boş olan tetkik bulundu: " + labProc.ProcedureObject.Code + "-" + labProc.ProcedureObject.Name);
                            //else
                            skrsLoincKodu = ((LaboratoryTestDefinition)labProc.ProcedureObject).FreeLOINCCode;
                        }

                        obr.UniversalServiceID = skrsLoincKodu;
                        obr.OrderingProvider = labProc.Laboratory.RequestDoctor.DiplomaNo + "^" + labProc.Laboratory.RequestDoctor.Person.Surname + "^" + labProc.Laboratory.RequestDoctor.Person.Name + "^" + labProc.Laboratory.RequestDoctor.EmploymentRecordID + "^" + labProc.Laboratory.RequestDoctor.Person.UniqueRefNo + "^" + labProc.Laboratory.RequestDoctor.PhoneNumber; // "N-DOK165^KARAYEĞEN^AYTUĞ^^10000000000^";
                        obr.Dg1 = dgList.ToArray();
                        //Order.ORC, istem bilgisi segmenti
                        XXXXXXIHEWS.ORC orc = new XXXXXXIHEWS.ORC();
                        orc.OrderControl = "NW";
                        orc.PlacerOrderNumber = obr.PlacerOrderNumber;
                        orc.DateTimeofTransaction = ((DateTime)labProc.RequestDate).ToString("yyyyMMddHHmmss");
                        if (((LaboratoryTestDefinition)labProc.ProcedureObject).IsPanel == true)
                        {
                            orc.ParentUniServiceID = skrsLoincKodu;
                        }

                        //Order segmenti
                        XXXXXXIHEWS.Order order = new XXXXXXIHEWS.Order();
                        order.Orc = orc;
                        order.Obr = obr;
                        order.Obx = obxList.ToArray();
                        orderList.Add(order);
                    }

                    //Specimen.SPM, ornek bilgileri segmenti 
                    XXXXXXIHEWS.SPM spm = new XXXXXXIHEWS.SPM();
                    spm.SpecimenType = "SER";
                    spm.SpecimenDesc = "Aciklama";
                    //Specimen segmenti
                    XXXXXXIHEWS.Specimen specimen = new XXXXXXIHEWS.Specimen();
                    specimen.Spm = spm;
                    XXXXXXIHEWS.OML33Specimen oml33Specimen = new XXXXXXIHEWS.OML33Specimen();
                    oml33Specimen.Specimen = specimen;
                    oml33Specimen.Order = orderList.ToArray();
                    oml33SpecimenList.Add(oml33Specimen);
                    oml33.Msh = msh;
                    oml33.Patient = patient;
                    oml33.OML33SpecimenArr = oml33SpecimenList.ToArray();
                    orl34 = XXXXXXIHEWS.WebMethods.OML33ToORL34Sync(Sites.SiteLocalHost, oml33);
                    ProcedureInfoOutputDVO outputDVO = new ProcedureInfoOutputDVO();
                    if (orl34.Msa.AcknowledgmentCode == "AA") //basarılı kaydedıldı.
                    {
                        outputDVO.SpecimenID = orl34.OML33Specimen[0].Specimen.Spm.SpecimenID;
                        outputDVO.TubeInformations = new List<TubeInformation>();
                        outputDVO.LabProcedures = new List<ProcedureInformation>();
                        foreach (XXXXXXIHEWS.SAC tubeInfo in orl34.OML33Specimen[0].Specimen.Sac)
                        {
                            TubeInformation tubeInformation = new TubeInformation();
                            tubeInformation.FromResourceName = labProcedureByFromRes.Key.Qref + "|" + labProcedureByFromRes.Key.Name;
                            tubeInformation.ContainerID = tubeInfo.ContainerID;
                            tubeInformation.OtherEnvFactor = tubeInfo.OtherEnvFactor;
                            //string[] tubeDescriptionArr;
                            //string tubeDescription = "";
                            //tubeDescriptionArr = tubeInfo.SpecialHandlingCode.Split('&');
                            //foreach (string str in tubeDescriptionArr)
                            //{
                            //    tubeDescription = tubeDescription + str + '\n';
                            //}

                            //tubeInformation.SpecialHandlingCode = tubeDescription; //tubeInfo.SpecialHandlingCode;
                            tubeInformation.SpecialHandlingCode = tubeInfo.SpecialHandlingCode;
                            tubeInformation.SpecimenID = orl34.OML33Specimen[0].Specimen.Spm.SpecimenID;
                            tubeInformation.RequestAcceptionDate = Convert.ToDateTime(DateTime.Now).ToString("dd-MM-yyyy HH:mm");
                            outputDVO.TubeInformations.Add(tubeInformation);
                        }

                        foreach (XXXXXXIHEWS.Order procInfo in orl34.OML33Specimen[0].Order)
                        {
                            ProcedureInformation orderInfo = new ProcedureInformation();
                            orderInfo.PlacerOrderNumber = procInfo.Orc.PlacerOrderNumber;
                            orderInfo.PlacerGroupNumber = procInfo.Orc.PlacerGroupNumber;
                            outputDVO.LabProcedures.Add(orderInfo);
                        }

                        responseList.Add(outputDVO);
                    }
                    else
                    {
                        throw new Exception("XXXXXX sisteminden gelen bir hata oluştu: " + orl34.Err.ApplicationErrorCode.ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("XXXXXX sistemine gönderimde hata oluştu! " + ex.Message.ToString(), ex);
                }
            }

            return responseList;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Laboratuvar_Barkod_Bas)]
        public void UpdateBarcodeDateForSpecimen(List<TubeInformation> TubeInformationList)
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXENTEGRATION", "FALSE") == "TRUE")
            {
                foreach (TubeInformation tubeInfo in TubeInformationList)
                {
                    try
                    {
                        int response = XXXXXXIHEWS.WebMethods.OrnekIslemTarihBildirSync(Sites.SiteLocalHost, Convert.ToInt32(tubeInfo.SpecimenID), tubeInfo.ContainerID, 10, DateTime.Now.ToString("yyyyMMddHHmmss"), Common.CurrentUser.FullName);
                        if (response == 0)
                        {
                            throw new Exception("XXXXXX sistemine gönderimde hata oluştu! ");
                        }
                        else
                        {
                            SetBarcodeDateFromBarcodeID(tubeInfo.ContainerID);//ALIS'de barkod bilgisi gönderildi ve barkod basma tarihi bize eklendi
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("XXXXXX sistemine gönderimde hata oluştu! ", ex);
                    }
                }
            }
        }

        private void SetBarcodeDateFromBarcodeID(string containerID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    List<LaboratoryProcedure> labProcedureList = LaboratoryProcedure.GetLabProcedureByBarcodeId_OQ(objectContext, containerID).ToList();
                    foreach (LaboratoryProcedure labProc in labProcedureList)
                    {
                        if (labProc.CurrentStateDefID == LaboratoryProcedure.States.SampleTaking && labProc.BarcodePrintDate == null)
                            labProc.BarcodePrintDate = DateTime.Now;
                    }
                    objectContext.Save();
                }
                catch (Exception)
                {
                    //do nothing
                }

            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Laboratuvar_Barkod_Bas)]
        public void UpdateSampleDateAsBarcodeDate(string specimenID)
        {


            if (TTObjectClasses.SystemParameter.GetParameterValue("SETSAMPLEDATEASBARCODEDATE", "TRUE") == "TRUE")
            {
                try
                {
                    using (TTObjectContext objectContext = new TTObjectContext(false))
                    {
                        List<LaboratoryProcedure> labProcedureList = LaboratoryProcedure.GetLaboratoryProcedureBySpecimenIdForWorkList(objectContext, specimenID).ToList();
                        foreach (LaboratoryProcedure labProc in labProcedureList)
                        {
                            if (labProc.CurrentStateDefID == LaboratoryProcedure.States.SampleTaking && labProc.SampleDate == null)
                                labProc.SampleDate = DateTime.Now;
                        }
                        objectContext.Save();
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Numune Alma zamanı güncellemede hata oluştu! ", ex);
                }
            }
            
        }


            public void UpdateSampleDateForLaboratoryProcedure(string specimenID, string barcodeNo, DateTime sampleAcceptDate)
        {
            try
            {
                int response = XXXXXXIHEWS.WebMethods.OrnekIslemTarihBildirSync(Sites.SiteLocalHost, Convert.ToInt32(specimenID), barcodeNo, 4, sampleAcceptDate.ToString("yyyyMMddHHmmss"), Common.CurrentUser.FullName);
                if (response == 0)
                {
                    throw new Exception("XXXXXX sistemine gönderimde hata oluştu! ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("XXXXXX sistemine gönderimde hata oluştu! ", ex);
            }
        }

        [HttpGet]
        public List<LaboratoryWorkListSubItemDetailModel> GetPanelSubTestsInfo(string LaboratoryProcedureObjectID)
        {
            List<LaboratoryWorkListSubItemDetailModel> panelTestList = new List<LaboratoryWorkListSubItemDetailModel>();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                LaboratoryProcedure labProc = new LaboratoryProcedure();
                //
                labProc = (LaboratoryProcedure)objectContext.GetObject(new Guid(LaboratoryProcedureObjectID), "LABORATORYPROCEDURE");
                foreach (LaboratorySubProcedure labSubProc in labProc.LaboratorySubProcedures)
                {
                    LaboratoryWorkListSubItemDetailModel laboratoryWorkListSubItemDetailModel = new LaboratoryWorkListSubItemDetailModel();
                    laboratoryWorkListSubItemDetailModel.ObjectID = labSubProc.ObjectID;
                    laboratoryWorkListSubItemDetailModel.MasterSubactionProcedureID = labProc.ObjectID;
                    laboratoryWorkListSubItemDetailModel.TestCode = labSubProc.ProcedureObject.Code;
                    laboratoryWorkListSubItemDetailModel.LaboratoryTestName = labSubProc.ProcedureObject.Name;
                    laboratoryWorkListSubItemDetailModel.BarcodeID = labProc.BarcodeId.ToString();
                    laboratoryWorkListSubItemDetailModel.SpecimenID = labProc.SpecimenId.ToString();
                    laboratoryWorkListSubItemDetailModel.Result = labSubProc.Result;
                    laboratoryWorkListSubItemDetailModel.Unit = labSubProc.Unit;
                    laboratoryWorkListSubItemDetailModel.Reference = labSubProc.Reference;
                    laboratoryWorkListSubItemDetailModel.ResultDescription = labSubProc.ResultDescription;
                    
                    laboratoryWorkListSubItemDetailModel.IsOutOfReference = false; //Alt tetkiğin numerik bir sonucu varsa ve referansları numerik ise kontrol edilip set edilecek. Renklendirme için kullanılıyor.
                    if (labSubProc.Reference != null && labSubProc.Reference != String.Empty)
                    {
                        string reference = labSubProc.Reference.Trim(' ');//Boşluklar çıkarıldı
                        string[] referenceList = reference.Split('-');
                      
                        if (referenceList.Length == 2)
                        {

                            decimal result;

                            bool isResultNumaric = decimal.TryParse(labSubProc.Result, out result);

                            if (isResultNumaric)
                            {
                                decimal refLow, refHigh;
                                decimal ref1, ref2;
                                bool isRef1Numaric = decimal.TryParse(referenceList[0], out ref1);
                                bool isRef2Numaric = decimal.TryParse(referenceList[1], out ref2);
                                
                                if (isRef1Numaric && isRef2Numaric)
                                {
                                    if (ref1 <= ref2)
                                    {
                                        refLow = ref1;
                                        refHigh = ref2;
                                    }
                                    else
                                    {
                                        refLow = ref2;
                                        refHigh = ref1;
                                    }

                                    if (result < refLow || result > refHigh)
                                        laboratoryWorkListSubItemDetailModel.IsOutOfReference = true;
                                  
                                   
                                }


                            }

                        } 

                    }
                    if (labProc.ResultDate != null)
                        laboratoryWorkListSubItemDetailModel.ResultDate = labProc.ResultDate.Value;
                    panelTestList.Add(laboratoryWorkListSubItemDetailModel);
                }
            }

            return panelTestList;
        }

        [HttpPost]
        public void SavePanelTestResult(List<LaboratoryWorkListSubItemDetailModel> inputDVO)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                foreach (LaboratoryWorkListSubItemDetailModel subItem in inputDVO)
                {
                    LaboratorySubProcedure labSubProc = new LaboratorySubProcedure();
                    labSubProc = (LaboratorySubProcedure)objectContext.GetObject(subItem.ObjectID, "LABORATORYSUBPROCEDURE");
                    labSubProc.Result = subItem.Result;
                    labSubProc.Unit = subItem.Unit;
                    labSubProc.Reference = subItem.Reference;
                }

                objectContext.Save();
            }
        }

        [HttpPost]
        public void AskLabResultFromLIS(ProcedureInfoInputDVO inputDVO)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                Boolean result = false;
                List<LaboratoryProcedure> labProcList = new List<LaboratoryProcedure>();
                foreach (string labProcObjectID in inputDVO.LabProcedures)
                {
                    LaboratoryProcedure labProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(labProcObjectID), "LABORATORYPROCEDURE");
                    if (labProcedure != null)
                    {
                        labProcList.Add(labProcedure);
                    }
                }

                result = LaboratoryRequest.GetLabResultFromLIS(inputDVO.SpecimenID, labProcList);
            }
        }

        [HttpGet]
        public void GetReadyResultsFromLIS()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                LaboratoryRequest.GetReadySpecimensFromLIS();
            }
        }

        //[HttpPost]
        //public void AskResultsFromLISBySpecimenID(ProcedureInfoInputDVO inputDVO)
        //{
        //    using (TTObjectContext objectContext = new TTObjectContext(false))
        //    {
        //        LaboratoryRequest.AskResultsFromLIS();
        //    }
        //}


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Laboratuvar_Tetkik_Bilgi_Guncelleme)]
        public void ReadTestDefinitionInfoFromLIS()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                LaboratoryTestDefinition.GetLaboratoryTestDefinitionFromLIS();
            }
        }

        public void SaveTestResult(List<LaboratoryWorkListItemDetailModel> inputDVO)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                foreach (LaboratoryWorkListItemDetailModel labItem in inputDVO)
                {
                    LaboratoryProcedure labProc = new LaboratoryProcedure();
                    labProc = (LaboratoryProcedure)objectContext.GetObject(labItem.ObjectID, "LABORATORYPROCEDURE");
                    //labProc.ResultDate = labItem.ResultDate;
                    labProc.Result = labItem.Result;
                    labProc.Unit = labItem.Unit;
                    labProc.Reference = labItem.Reference;
                }

                objectContext.Save();
            }
        }

        [HttpGet]
        public List<ProcedureTreeObject> GetLabProcedureTreeList()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<ProcedureTreeObject> procedureTreeList = new List<ProcedureTreeObject>();

                BindingList<ProcedureTreeDefinition.GetProcedureTreeDefinitions_Class> treeList = ProcedureTreeDefinition.GetProcedureTreeDefinitions("");
                foreach (ProcedureTreeDefinition.GetProcedureTreeDefinitions_Class procedureTree in treeList)
                {
                    ProcedureTreeObject p = new ProcedureTreeObject();
                    p.Name = procedureTree.ExternalCode + " " + procedureTree.Description;
                    p.ObjectID = procedureTree.ObjectID.ToString();
                    procedureTreeList.Add(p);
                }
                return procedureTreeList;
            }
        }
    }

    public class LaboratoryWorkListFormViewModel
    {
        public string txtPatient
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }

        public string ID
        {
            get;
            set;
        }

        public Int32 EpisodeID
        {
            get;
            set;
        }

        public Int32 WorkListCount
        {
            get;
            set;
        }

        public string StateType
        {
            get;
            set;
        }

        public string PatientStatus
        {
            get;
            set;
        }

        //public List<LaboratoryWorkListItemDetailModel> LaboratoryList { get; set; }
        public List<TTObjectClasses.MenuDefinition> MenuList
        {
            get;
            set;
        }

        public List<LaboratoryWorkListItem> WorkListItems
        {
            get;
            set;
        }

        public List<LaboratoryWorkListItem> SelectedWorkListItems
        {
            get;
            set;
        }

        public List<LaboratoryWorkListStateItem> SelectedWorkListStateItems
        {
            get;
            set;
        }

        public List<SpecialPanelListItem> SpecialPanelListItems
        {
            get;
            set;
        }

        public SpecialPanelListItem LastSelectedSpecialPanel
        {
            get;
            set;
        }

        public List<LaboratoryWorkListItemMasterModel> LaboratoryProcedureMasterList
        {
            get;
            set;
        }
    }

    public class LaboratoryWorkListItemMasterModel
    {
        public string EpisodeID
        {
            get;
            set;
        }

        public string PatientNameSurname
        {
            get;
            set;
        }

        public string ID
        {
            get;
            set;
        }

        public string FromResourceName
        {
            get;
            set;
        }

        public string LabRequestObjectID
        {
            get;
            set;
        }

        public List<LaboratoryWorkListItemDetailModel> LaboratoryProcedureList
        {
            get;
            set;
        }

        public List<TubeInformation> TubeInformationList
        {
            get;
            set;
        }

        public List<string> SelectedLaboratoryStateItems
        {
            get;
            set;
        }

        public bool isPregnant
        {
            get;
            set;
        }

        public bool isEmergency
        {
            get;
            set;
        }

        public bool isYoung
        {
            get;
            set;
        }

        public bool isOld
        {
            get;
            set;
        }

        public bool isVetera
        {
            get;
            set;
        }

        public bool isDisabled
        {
            get;
            set;
        }

        public bool hasMedicalInformation
        {
            get;
            set;
        }
        //Barcode etiketi icin gerekli bilgiler

        public string PatientObjectID
        {
            get;
            set;
        }
        public string PatientID
        {
            get;
            set;
        }


        public string PatientTCNo
        {
            get;
            set;
        }

        public string PatientBirthDate
        {
            get;
            set;
        }

        public string PatientBirthCity
        {
            get;
            set;
        }

        public string PatientStatus
        {
            get;
            set;
        }

        public string InPatientDate
        {
            get;
            set;
        }

        public string DischargeDate
        {
            get;
            set;
        }

        public string PatientDoctor
        {
            get;
            set;
        }

        public string PatientGroup
        {
            get;
            set;
        }

        public string PatientSex
        {
            get;
            set;
        }

        public string DefNo
        {
            get;
            set;
        }
        public string ArsivNo
        {
            get;
            set;
        }
    }

    public class LaboratoryWorkListItemDetailModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string ObjectDefName
        {
            get;
            set;
        }

        public string PatientNameSurname
        {
            get;
            set;
        }

        public string EpisodeActionName
        {
            get;
            set;
        }

        public string TestCode
        {
            get;
            set;
        }

        public string TestLoincCode
        {
            get;
            set;
        }

        public string LaboratoryTestName
        {
            get;
            set;
        }

        public string BarcodeID
        {
            get;
            set;
        }

        public string SpecimenID
        {
            get;
            set;
        }

        public string FromResourceName
        {
            get;
            set;
        }

        public DateTime WorkListDate
        {
            get;
            set;
        }

        public string RequestDate
        {
            get;
            set;
        }

        public string RequestedByUser
        {
            get;
            set;
        }

        public string StateName
        {
            get;
            set;
        }

        public string StateDefID
        {
            get;
            set;
        }


        public bool isLabTestEmergency
        {
            get;
            set;
        }

        public bool isSelected
        {
            get;
            set;
        }

        public string LabRequestObjectID
        {
            get;
            set;
        }

        public TubeInformation TubeInfo
        {
            get;
            set;
        }

        public string ResultDate
        {
            get;
            set;
        }

        public string SampleDate
        {
            get;
            set;
        }

        public string ApproveDate
        {
            get;
            set;
        }

        public string BarcodePrintDate
        {
            get;
            set;
        }

        public string Result
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }

        public string Reference
        {
            get;
            set;
        }

        public bool isPanelTest
        {
            get;
            set;
        }

        public List<LaboratoryWorkListSubItemDetailModel> LaboratorySubProcedureList
        {
            get;
            set;
        }

        public bool isExternalProcedureRequest
        {
            get;
            set;
        }

        public Guid EpisodeActionObjectId
        {
            get;
            set;
        }
        public string ProcedureRequestFormCategoryName
        {
            get;
            set;
        }

        public bool hasProcedureInstruction
        {
            get;
            set;
        }
        public string ProcedureInstructions
        {
            get;
            set;
        }
        public string ProcedureInstructionReportName
        {
            get;
            set;
        }
        public string SampleUser
        {
            get;
            set;
        }
        public string ResultDescription
        {
            get;
            set;
        }
        public bool isMicroscopicExamination
        {
            get;
            set;
        }
    }

    public class LaboratoryWorkListSubItemDetailModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public Guid MasterSubactionProcedureID
        {
            get;
            set;
        }

        public string TestCode
        {
            get;
            set;
        }

        public string TestLoincCode
        {
            get;
            set;
        }

        public string LaboratoryTestName
        {
            get;
            set;
        }

        public string BarcodeID
        {
            get;
            set;
        }

        public string SpecimenID
        {
            get;
            set;
        }

        public DateTime ResultDate
        {
            get;
            set;
        }

        public string Result
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }

        public string Reference
        {
            get;
            set;
        }
        public bool IsOutOfReference
        {
            get;
            set;
        }

        public string ResultDescription
        {
            get;
            set;
        }

    }

    public class TubeInformation
    {
        public string SpecimenID
        {
            get;
            set;
        }

        public string ContainerID
        {
            get;
            set;
        }

        public string SpecialHandlingCode
        {
            get;
            set;
        }

        public string OtherEnvFactor
        {
            get;
            set;
        }

        public string FromResourceName
        {
            get;
            set;
        }
        public string RequestAcceptionDate
        {
            get;
            set;
        }
    }

    public class LaboratoryWorkListItem
    {
        public string ObjectDefName
        {
            get;
            set;
        }

        public string ObjectDefID
        {
            get;
            set;
        }
    }

    public class LaboratoryWorkListStateItem
    {
        public string StateDefName
        {
            get;
            set;
        }

        public string StateDefID
        {
            get;
            set;
        }
    }

    public class SpecialPanelListItem
    {
        public string Name;
        public string Caption;
        public string ObjectID;
        public List<SpecialPanelCriteriaVal> SpecialPanelCriteriaValues;
    }

    public class SpecialPanelCriteriaVal
    {
        public string Name;
        public string ObjectID;
        public string Value;
    }

    public class SpecialPanelOutputDVO
    {
        public List<SpecialPanelListItem> SpecialPanelList;
        public SpecialPanelListItem LastSelectedSpecialPanel;
    }

    public class SpecialPanelInputDVO
    {
        public List<LaboratoryWorkListItem> SelectedWorkListItems
        {
            get;
            set;
        }

        public List<LaboratoryWorkListStateItem> SelectedWorkListStateItems
        {
            get;
            set;
        }

        public List<SpecialPanelListItem> SpecialPanelListItems
        {
            get;
            set;
        }

        public SpecialPanelListItem LastSelectedSpecialPanel
        {
            get;
            set;
        }

        public bool isNew
        {
            get;
            set;
        }

        public string SpecialPanelListItemCaption
        {
            get;
            set;
        }
        public string activeResUserObjectID
        {
            get;
            set;
        }
    }


    public class SampleAcceptBarcodeModel
    {
        public List<LaboratoryWorkListItemDetailModel> LaboratoryProcedureList = new List<LaboratoryWorkListItemDetailModel>();
        public string LabRequestObjectID { get; set; }
        public string LastReadedBarcode { get; set; }
        public bool IsTransitionMade { get; set; }
    }

    public class ProcedureTreeObject
    {
        public string ObjectID { get; set; }
        public string Name { get; set; }
    }
}