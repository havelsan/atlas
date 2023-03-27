using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using System.Collections;
using TTStorageManager.Security;
using TTUtils;
using TTDefinitionManagement;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    //[Export]
    //[PartCreationPolicy(CreationPolicy.NonShared)]
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class EpisodeActionWorkListServiceController : Controller
    {
        //SortedList<string, TTObjectDef> _filteredObjectDefList;
        //SortedList<Guid, SortedList<string, TTObjectStateDef>> _filteredObjectStateDefList;
        //protected WorkListDefinition _workListDefinition;
        //public WorkListDefinition workListDefinition
        //{
        //    get
        //    {
        //        //if (_workListDefinition == null)
        //        setWorkListDefinition();
        //        return _workListDefinition;
        //    }
        //}

        public class QueryInputDVO
        {
            public string txtPatient
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

            public int? ID
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

            public List<EpisodeActionWorkListItem> WorkListItems
            {
                get;
                set;
            }

            public List<EpisodeActionWorkListStateItem> WorkListStateItems
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

            public string activeResUserObjectID
            {
                get;
                set;
            }
            public ResSection userSelectedOutPatientResource
            {
                get;
                set;
            }
            public ResSection userSelectedInPatientResource
            {
                get;
                set;
            }
            public ResSection userSelectedSecMasterResource
            {
                get;
                set;
            }

            public List<string> SelectedStateTypes
            {
                get;
                set;
            }
            public List<string> SelectedStateTypesEM
            {
                get;
                set;
            }
            public string SEProtocolNo
            {
                get;
                set;
            }

            public List<EquipmentItem> RadiologyEquipmentItems
            {
                get;
                set;
            }

            public List<EquipmentItem> SelectedRadiologyEquipmentItems
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

        public class MenuOutputDVO
        {
            public List<EpisodeActionWorkListItem> WorkListSearchItem
            {
                get;
                set;
            }

            public List<EpisodeActionWorkListStateItem> WorkListSearchStateItem
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

            public List<EpisodeActionWorkListItem> EAWorkListSearchItem
            {
                get;
                set;
            }

            public List<EpisodeActionWorkListStateItem> EAWorkListSearchStateItem
            {
                get;
                set;
            }

            public List<EpisodeActionWorkListItem> SPFWorkListSearchItem
            {
                get;
                set;
            }

            public List<EpisodeActionWorkListStateItem> SPFWorkListSearchStateItem
            {
                get;
                set;
            }
            public int WorkListMaxDayToSearch
            {
                get;
                set;
            }
        }

        public class StateOutputDVO
        {
            public List<EpisodeActionWorkListStateItem> WorkListSearchStateItem
            {
                get;
                set;
            }
        }

        public class LCDNotificationOutputDVO
        {
            public List<LCDNotificationDefinition> LCDNotificationList
            {
                get;
                set;
            }
            public string isNewLcd { get; set; }
        }

        public class UserResourceOutputDVO
        {
            public List<UserResourceItem> WorkListSearchUserResourceItem
            {
                get;
                set;
            }
            public List<UserResourceItem> SelectedWorkListSearchUserResourceItem
            {
                get;
                set;
            }
        }
        protected virtual WorkListDefinition getWorkListDefinition(string worklistDefID)
        {
            //TODO BB, worklistdef i şimdilik böyle çektim. Değişecek
            if (string.IsNullOrEmpty(worklistDefID))
                worklistDefID = "e0444b60-fa7f-40bc-ba42-8f06556aee7c";
            TTObjectContext objectContext = new TTObjectContext(true);
            WorkListDefinition _workListDefinition = (WorkListDefinition)objectContext.GetObject(new Guid(worklistDefID), "WorkListDefinition");
            return _workListDefinition;
        }

        protected static string GenerateExpression(QueryInputDVO queryInputDVO, WorkListDefinition workListDefinition, out List<EpisodeActionWorkListStateItem> selectedStateDefs)
        {
            selectedStateDefs = new List<EpisodeActionWorkListStateItem>();
            List<EpisodeActionWorkListStateItem> _selectedStateDefs = new List<EpisodeActionWorkListStateItem>();
            if (queryInputDVO.SelectedWorkListStateItems != null && queryInputDVO.SelectedWorkListStateItems.Count > 0)
                _selectedStateDefs = queryInputDVO.SelectedWorkListStateItems;
            else if (queryInputDVO.WorkListStateItems != null && queryInputDVO.WorkListStateItems.Count > 0)
            {
                if (queryInputDVO.SelectedStateTypesEM.Count > 0)
                {
                    foreach (string stateType in queryInputDVO.SelectedStateTypesEM)
                    {
                        foreach (EpisodeActionWorkListStateItem stateItem in queryInputDVO.WorkListStateItems)
                        {
                            if (stateItem.StateStatus.Equals(stateType))
                                _selectedStateDefs.Add(stateItem);
                        }
                    }

                }
                else
                    _selectedStateDefs = queryInputDVO.WorkListStateItems;
            }
            else
                return "";

            var expression = new System.Text.StringBuilder(" AND (");

            expression.Append(workListDefinition.GenerateExpression());

            Dictionary<Guid, List<TTObjectStateDef>> states = new Dictionary<Guid, List<TTObjectStateDef>>();
            for (int i = 0; i < _selectedStateDefs.Count; i++)
            {
                TTObjectStateDef stateDef = TTObjectDefManager.Instance.AllTTObjectStateDefs[new Guid(_selectedStateDefs[i].StateDefID)];

                if (queryInputDVO.SelectedStateTypesEM.Count == 0 || queryInputDVO.SelectedStateTypesEM.Contains<string>(stateDef.Status.ToString().ToUpper()))
                {
                    Guid? permDefID = ((ITTSecurableObject)stateDef.ObjectDef).GetSecurityAuthority().PermissionDefID;
                    if (permDefID.HasValue)
                    {
                        List<TTObjectStateDef> list;
                        if (states.TryGetValue(permDefID.Value, out list) == false)
                        {
                            list = new List<TTObjectStateDef>();
                            states.Add(permDefID.Value, list);
                        }
                        list.Add(stateDef);
                        EpisodeActionWorkListStateItem stateItem = new EpisodeActionWorkListStateItem();
                        stateItem.StateDefID = stateDef.StateDefID.ToString();
                        stateItem.StateDefName = stateDef.Name;
                        stateItem.StateStatus = stateDef.Status.ToString().ToUpperInvariant();
                        selectedStateDefs.Add(stateItem);
                    }
                }
            }

            if (states.Values.Count == 0)
                return "";

            var sAnd = "";
            foreach (var list in states.Values)
            {
                var autho = ((ITTSecurableObject)list[0].ObjectDef).GetSecurityAuthority();
                expression.Append(sAnd);
                autho.GetWorklistNQLFilter(expression, list);
                sAnd = " OR ";
            }

            expression.Append(")");

            return expression.ToString();
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public EpisodeActionWorkListFormViewModel Query(QueryInputDVO inputdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                int workListMaxItemCount = Common.WorklistMaxItemCount();
                if (inputdvo.userSelectedOutPatientResource != null)
                    Common.CurrentResource.SelectedOutPatientResource = inputdvo.userSelectedOutPatientResource;
                if (inputdvo.userSelectedInPatientResource != null)
                    Common.CurrentResource.SelectedInPatientResource = inputdvo.userSelectedInPatientResource;
                if (inputdvo.userSelectedSecMasterResource != null)
                    Common.CurrentResource.SelectedSecMasterResource = inputdvo.userSelectedSecMasterResource;

                EpisodeActionWorkListFormViewModel model = new EpisodeActionWorkListFormViewModel();
                
                model.maxWorklistItemCount = 0;
                if (inputdvo.StartDate.HasValue == false)
                    inputdvo.StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                else
                    inputdvo.StartDate = Convert.ToDateTime(inputdvo.StartDate.Value.ToShortDateString() + " " + "00:00:00");
                if (inputdvo.EndDate.HasValue == false)
                    inputdvo.EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                else
                    inputdvo.EndDate = Convert.ToDateTime(inputdvo.EndDate.Value.ToShortDateString() + " " + "23:59:59");
                inputdvo.MinDate = Convert.ToDateTime("01.01.1800 00:00:00");
                WorkListDefinition workListDefinition = getWorkListDefinition("e0444b60-fa7f-40bc-ba42-8f06556aee7c");
                Common.QueueItems queueItems = null;
                if (Common.CurrentResource.SelectedQueue != null)
                {
                    ExaminationQueueDefinition qDef = objectContext.GetObject<ExaminationQueueDefinition>(Common.CurrentResource.SelectedQueue.ObjectID);
                    if (qDef.ResSection != null)
                    {
                        if (qDef.ResSection.ExaminationQueueDefinitions.Where(q => q.IsActive == true).ToList().Count == 1)
                            queueItems = Common.GetSortedQueue(Common.CurrentResource.SelectedQueue.ObjectID, false);
                    }
                }
                Appointment appointment = null;

                if (workListDefinition.LastSpecialPanel == null)
                {
                    IList pDefs = SpecialPanelDefinition.GetByUserAndWorkListDef(objectContext, inputdvo.activeResUserObjectID, workListDefinition.ObjectID.ToString()); //inMemory_Context olmalı
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

                List<EpisodeActionWorkListItemModel> EpisodeActionList = new List<EpisodeActionWorkListItemModel>();
                string filterExpression = string.Empty;

                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    filterExpression += " AND THIS:SUBEPISODE:PATIENTSTATUS IN (" + inputdvo.PatientStatus + ")";
                if (!String.IsNullOrEmpty(inputdvo.txtPatient))
                {
                    filterExpression += " AND THIS:EPISODE:PATIENT:OBJECTID = '" + inputdvo.txtPatient + "'";
                }

                if (!String.IsNullOrEmpty(inputdvo.SEProtocolNo))
                {
                    if (inputdvo.SEProtocolNo.Contains("-"))
                        filterExpression += " AND THIS:SUBEPISODE:PROTOCOLNO = '" + inputdvo.SEProtocolNo.Trim() + "'";
                    else
                    {
                        filterExpression += " AND THIS:SUBEPISODE:PROTOCOLNO LIKE '" + inputdvo.SEProtocolNo.Trim() + "%'";
                        //inputdvo.SEProtocolNo.Substring(0, inputdvo.SEProtocolNo.IndexOf("-")).Trim()
                    }
                }
                string filterExpressionForEA = " ";
                if (inputdvo.SelectedWorkListItems != null && inputdvo.SelectedWorkListItems.Count > 0)
                {
                    List<Guid> objectDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListItem wli in inputdvo.SelectedWorkListItems)
                    {
                        TTObjectDef objDef = TTObjectDefManager.Instance.ObjectDefs[new Guid(wli.ObjectDefID)];
                        if (objDef.IsOfType("EpisodeAction"))
                            objectDefIDs.Add(new Guid(wli.ObjectDefID));
                    }
                    if (objectDefIDs.Count > 0)
                    {
                        inputdvo.WorkListStateItems = FilterStatesWithObjectDef(inputdvo.SelectedWorkListItems, "e0444b60-fa7f-40bc-ba42-8f06556aee7c");

                        filterExpressionForEA = Common.CreateFilterExpressionOfGuidList(filterExpressionForEA, "OBJECTDEFID", objectDefIDs);
                    }
                }
                else
                {
                    MenuOutputDVO menuOutputDVO = GetEpisodeActionMenuDefinition();
                    inputdvo.WorkListItems = menuOutputDVO.EAWorkListSearchItem;
                    inputdvo.WorkListStateItems = menuOutputDVO.EAWorkListSearchStateItem;
                    List<Guid> objectDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListItem wli in inputdvo.WorkListItems)
                    {
                        objectDefIDs.Add(new Guid(wli.ObjectDefID));
                    }
                    if (objectDefIDs.Count > 0)
                        filterExpressionForEA = Common.CreateFilterExpressionOfGuidList(filterExpressionForEA, "OBJECTDEFID", objectDefIDs);
                }

                List<EpisodeActionWorkListStateItem> selectedStateDefs = new List<EpisodeActionWorkListStateItem>();
                filterExpressionForEA += GenerateExpression(inputdvo, workListDefinition, out selectedStateDefs);
                if (inputdvo.SelectedWorkListStateItems == null || inputdvo.SelectedWorkListStateItems.Count == 0)
                {
                    inputdvo.WorkListStateItems = selectedStateDefs;
                }

                if (inputdvo.SelectedUserResourceItems != null && inputdvo.SelectedUserResourceItems.Count > 0)
                {
                    List<ResSection> selectedWorkListResources = new List<ResSection>();
                    foreach (UserResourceItem userResourceItem in inputdvo.SelectedUserResourceItems)
                    {
                        ResSection resource = objectContext.GetObject<ResSection>(new Guid(userResourceItem.ResourceID));
                        selectedWorkListResources.Add(resource);
                    }
                    Common.CurrentResource.SelectedWorkListResources = selectedWorkListResources;
                }
                else
                    Common.CurrentResource.SelectedWorkListResources = new List<ResSection>();
                int counter = 0;
                if (!String.IsNullOrWhiteSpace(filterExpressionForEA))
                {
                    IBindingList doctorsWorkList = EpisodeAction.GetByEpisodeActionWorklistDateReport(inputdvo.StartDate.Value, inputdvo.EndDate.Value, inputdvo.MinDate.Value, filterExpression + filterExpressionForEA);
                    foreach (EpisodeAction.GetByEpisodeActionWorklistDateReport_Class ea in doctorsWorkList)
                    {
                        EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject(ea.ObjectID.Value, "EPISODEACTION");

                        if (episodeAction is IWorkListEpisodeAction && !(episodeAction is IWorkListRadiology))
                        {
                            if (TTUser.CurrentUser.HasRight(episodeAction.CurrentStateDef.FormDef, episodeAction, workListDefinition.RightDefID.Value))// || (filteredWorkList && TTUser.CurrentUser.HasRight(episodeAction.CurrentStateDef.FormDef, episodeAction, (int)TTSecurityAuthority.RightsEnum.ReadForm)))
                            {
                                if (counter > workListMaxItemCount)
                                {
                                    model.maxWorklistItemCount += counter;
                                    break;
                                }
                                EpisodeActionWorkListItemModel episodeActionWorkListItemModel = new EpisodeActionWorkListItemModel();
                                episodeActionWorkListItemModel.ObjectID = episodeAction.ObjectID.ToString();
                                episodeActionWorkListItemModel.ObjectDefName = episodeAction.ObjectDef.Name;
                                //episodeActionWorkListItemModel.PatientNameSurname = episodeAction.Episode.Patient.PatientIDandFullName;
                                episodeActionWorkListItemModel.PatientIdentityNumber = episodeAction.Episode.Patient.RefNo;
                                episodeActionWorkListItemModel.PatientNameSurname = episodeAction.Episode.Patient.FullName;
                                if (queueItems != null && queueItems.patient != null && queueItems.patient.ToList().Exists(x => x.patientObjectID.Equals(episodeAction.Episode.Patient.ObjectID)))
                                    episodeActionWorkListItemModel.QueueNumberToSort = queueItems.patient.ToList().Where(x => x.patientObjectID.Equals(episodeAction.Episode.Patient.ObjectID)).FirstOrDefault().Index;
                                else
                                    episodeActionWorkListItemModel.QueueNumberToSort = 5000;

                                if (episodeAction is PatientExamination)
                                {
                                    PatientExamination patientExamination = (PatientExamination)episodeAction;
                                    if (patientExamination.EmergencyIntervention != null)
                                    {
                                        if ((patientExamination.EmergencyIntervention).Triage == null)
                                        {
                                            episodeActionWorkListItemModel.TriageCode = "";
                                        }
                                        else
                                            episodeActionWorkListItemModel.TriageCode = (patientExamination.EmergencyIntervention).Triage == null ? "" : (patientExamination.EmergencyIntervention).Triage.KODU;
                                    }
                                    else
                                        episodeActionWorkListItemModel.TriageCode = "";

                                    //if (patientExamination.EmergencyIntervention != null)
                                    //{
                                    //    if ((patientExamination.EmergencyIntervention).Triage == null)
                                    //    {
                                    //        if (patientExamination.PatientAdmission != null && patientExamination.PatientAdmission.Triage != null)
                                    //        {
                                    //            episodeActionWorkListItemModel.TriageCode = patientExamination.PatientAdmission.Triage.KODU;
                                    //        }
                                    //    }
                                    //    else
                                    //        episodeActionWorkListItemModel.TriageCode = (patientExamination.EmergencyIntervention).Triage == null ? "" : (patientExamination.EmergencyIntervention).Triage.KODU;
                                    //}
                                }
                                else
                                    episodeActionWorkListItemModel.TriageCode = "";

                                episodeActionWorkListItemModel.PatientCallStatus = getPatientCallStatus(episodeAction);
                                
                                //episodeActionWorkListItemModel.ID = (int)episodeAction.ID.Value;
                                if (episodeAction.SubEpisode != null)
                                {
                                    if (episodeAction.SubEpisode.PatientAdmission != null)
                                    {
                                        if (episodeAction.RequestDate.HasValue)
                                            episodeActionWorkListItemModel.RequestDateStr = (DateTime)episodeAction.RequestDate.Value;
                                        appointment = null;
                                        if ((episodeAction is PatientExamination || episodeAction is DentalExamination) && episodeAction.SubEpisode.PatientAdmission.AdmissionAppointment != null && episodeAction.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments.Count > 0)
                                        {
                                            foreach (Appointment app in episodeAction.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments)
                                            {
                                                if (app.MasterResource.ObjectID.Equals(episodeAction.MasterResource.ObjectID) && episodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue == false)
                                                {
                                                    appointment = app;
                                                    break;
                                                }
                                            }
                                        }
                                        else if(episodeAction is Consultation)
                                        {
                                            Consultation consultation = episodeAction as Consultation;
                                            foreach (Appointment app in consultation.Appointments)
                                            {
                                                if (app.MasterResource.ObjectID.Equals(consultation.MasterResource.ObjectID) && consultation.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue == false)
                                                {
                                                    appointment = app;
                                                    break;
                                                }
                                            }
                                        }

                                        if (appointment != null)
                                        {
                                            episodeActionWorkListItemModel.AdmissionQueueNumber = appointment.StartTime.Value.ToShortTimeString();
                                        }
                                        else
                                        {
                                            if (episodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                                            {
                                                if (episodeAction.WorkListDate.HasValue)
                                                    episodeActionWorkListItemModel.RequestDateStr = (DateTime)episodeAction.WorkListDate.Value;
                                            }
                                            episodeActionWorkListItemModel.AdmissionQueueNumber = Common.GetFormattedAdmissionQueueNumber(episodeAction, episodeAction.SubEpisode.PatientAdmission, true, appointment == null);

                                        }
                                        //else if (episodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                                        //{
                                        //    if (episodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value < 10)
                                        //        episodeActionWorkListItemModel.AdmissionQueueNumber = "S-00" + episodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                                        //    else if (episodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value < 100)
                                        //        episodeActionWorkListItemModel.AdmissionQueueNumber = "S-0" + episodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                                        //    else
                                        //        episodeActionWorkListItemModel.AdmissionQueueNumber = "S-" + episodeAction.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();


                                        //    if (episodeAction.WorkListDate.HasValue)
                                        //        episodeActionWorkListItemModel.RequestDateStr = (DateTime)episodeAction.WorkListDate.Value;
                                        //}
                                        //else if (episodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.HasValue)
                                        //{
                                        //    if (episodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value < 10)
                                        //        episodeActionWorkListItemModel.AdmissionQueueNumber = "00" + episodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                                        //    else if (episodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value < 100)
                                        //        episodeActionWorkListItemModel.AdmissionQueueNumber = "0" + episodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                                        //    else
                                        //        episodeActionWorkListItemModel.AdmissionQueueNumber = episodeAction.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                                        //}

                                        if (episodeAction.MasterResource != null)
                                            episodeActionWorkListItemModel.AdmissionResourceName = episodeAction.MasterResource.Name;
                                        if (episodeAction.ProcedureDoctor != null)
                                            episodeActionWorkListItemModel.AdmissionDoctorName = episodeAction.ProcedureDoctor.Name;
                                        else if (episodeAction.SubEpisode.StarterEpisodeAction != null && episodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor != null)
                                            episodeActionWorkListItemModel.AdmissionDoctorName = episodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor.Name;
                                        if (episodeAction.SubEpisode.StarterEpisodeAction != null && episodeAction.SubEpisode.StarterEpisodeAction is InPatientTreatmentClinicApplication)
                                        {
                                            if (((InPatientTreatmentClinicApplication)episodeAction.SubEpisode.StarterEpisodeAction).ResponsibleNurse != null)
                                                episodeActionWorkListItemModel.ResponsibleNurseName = ((InPatientTreatmentClinicApplication)episodeAction.SubEpisode.StarterEpisodeAction).ResponsibleNurse.Name;
                                        }
                                        if (episodeAction.SubEpisode.ProtocolNo != null)
                                            episodeActionWorkListItemModel.ID = episodeAction.SubEpisode.ProtocolNo.ToString();
                                        
                                        //TODO: PriorityStatusDefinition a ayırt edici bir flag(enum) koymak lazım.Şimdilik isimden bakıldı :( BB
                                        if (episodeAction.SubEpisode.PatientAdmission.PriorityStatus != null)
                                        {
                                            if (episodeAction.SubEpisode.PatientAdmission.PriorityStatus.Code == "H")//Hamileler
                                                episodeActionWorkListItemModel.isPregnant = true;
                                            if (episodeAction.SubEpisode.PatientAdmission.PriorityStatus.Code == "Y")//65 Yaş Üstü Yaşlılar
                                                episodeActionWorkListItemModel.isOld = true;
                                            if (episodeAction.SubEpisode.PatientAdmission.PriorityStatus.Code == "G")//Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler
                                                episodeActionWorkListItemModel.isVetera = true;
                                            if (episodeAction.SubEpisode.PatientAdmission.PriorityStatus.Code == "A")//Acil Vakalar
                                                episodeActionWorkListItemModel.isEmergency = true;
                                            if (episodeAction.SubEpisode.PatientAdmission.PriorityStatus.Code == "E")//Engelliler
                                                episodeActionWorkListItemModel.isDisabled = true;
                                            if (episodeAction.SubEpisode.PatientAdmission.PriorityStatus.Code == "C")//7 Yaşından Küçük Çocuklar
                                                episodeActionWorkListItemModel.isYoung = true;
                                        }
                                    }

                                    if (episodeAction is Consultation)
                                    {
                                        Consultation cons = (Consultation)episodeAction;
                                        if (cons.Emergency.HasValue && cons.Emergency.Value == true)
                                            episodeActionWorkListItemModel.isEmergency = true;
                                    }
                                    else if (episodeAction is InPatientTreatmentClinicApplication)
                                    {
                                        InPatientTreatmentClinicApplication inPatientTreatmentClinicApp = (InPatientTreatmentClinicApplication)episodeAction;
                                        if (inPatientTreatmentClinicApp.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Acception)
                                        {
                                            if (inPatientTreatmentClinicApp.BaseInpatientAdmission.Emergency.HasValue && inPatientTreatmentClinicApp.BaseInpatientAdmission.Emergency.Value == true)
                                                episodeActionWorkListItemModel.isEmergency = true;
                                        }
                                    }

                                    if (episodeAction.Episode.Patient.ActivePregnancy != null || (episodeAction.Episode.Patient.MedicalInformation != null && episodeAction.Episode.Patient.MedicalInformation.Pregnancy.HasValue && episodeAction.Episode.Patient.MedicalInformation.Pregnancy.Value == true))
                                        episodeActionWorkListItemModel.isPregnant = true;
                                    if (episodeAction.Episode.Patient.Age.HasValue && episodeAction.Episode.Patient.Age.Value > 65)
                                        episodeActionWorkListItemModel.isOld = true;
                                    if (episodeAction.Episode.Patient.Age.HasValue && episodeAction.Episode.Patient.Age.Value < 7)
                                        episodeActionWorkListItemModel.isYoung = true;
                                    if (episodeAction.Episode.Patient.hasMedicalInformation())
                                        episodeActionWorkListItemModel.hasMedicalInformation = true;
                                    episodeActionWorkListItemModel.EpisodeObjectID = episodeAction.Episode.ObjectID;
                                }

                                if (episodeAction is PatientExamination)
                                {
                                    if (((PatientExamination)episodeAction).PatientExaminationType.HasValue)
                                    {
                                        episodeActionWorkListItemModel.EpisodeActionName = Common.GetDisplayTextOfDataTypeEnum(((PatientExamination)episodeAction).PatientExaminationType.Value);
                                        if (((PatientExamination)episodeAction).PatientExaminationType.Value == PatientExaminationEnum.Emergency)
                                            episodeActionWorkListItemModel.isEmergency = true;
                                    }
                                    else
                                    {
                                        foreach (ResourceSpecialityGrid resourceSpecialityGrid in episodeAction.MasterResource.ResourceSpecialities)
                                        {
                                            if (resourceSpecialityGrid.Speciality != null && resourceSpecialityGrid.Speciality.SpecialityBasedObjectType == SpecialityBasedObjectEnum.EmergencySpecialityObject)
                                            {
                                                episodeActionWorkListItemModel.EpisodeActionName = Common.GetDisplayTextOfDataTypeEnum(SpecialityBasedObjectEnum.EmergencySpecialityObject);
                                                episodeActionWorkListItemModel.isEmergency = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (episodeAction is DentalExamination)
                                {
                                    if (((DentalExamination)episodeAction).IsConsultation == true)
                                        episodeActionWorkListItemModel.EpisodeActionName = TTUtils.CultureService.GetText("M25499", "Diş Konsültasyonu");
                                }

                                if(episodeAction is NuclearMedicine)
                                {
                                    if (((NuclearMedicine)episodeAction).Emergency != null)
                                    {
                                        if (((NuclearMedicine)episodeAction).Emergency == true)
                                            episodeActionWorkListItemModel.isEmergency = true;
                                    }
                                }


                                if (String.IsNullOrEmpty(episodeActionWorkListItemModel.EpisodeActionName))
                                    episodeActionWorkListItemModel.EpisodeActionName = episodeAction.ObjectDef.DisplayText;
                                episodeActionWorkListItemModel.TransactionDate = (DateTime)episodeAction.WorkListDate.Value.Date;
                                episodeActionWorkListItemModel.StateName = episodeAction.CurrentStateDef.DisplayText;
                                episodeActionWorkListItemModel.CurrentStateDefID = episodeAction.CurrentStateDefID.HasValue ? episodeAction.CurrentStateDefID.Value.ToString() : "";
                                episodeActionWorkListItemModel.ReasonOfCancel = episodeAction.ReasonOfCancel;
                                // Yatan Hasta için 
                                if (episodeAction.Episode.PatientStatus == PatientStatusEnum.Inpatient)
                                {
                                    foreach (var inpatientAdmission in episodeAction.Episode.InpatientAdmissions)
                                    {
                                        if (inpatientAdmission.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        {
                                            episodeActionWorkListItemModel.HasTightContactIsolation = (Boolean)(inpatientAdmission.HasTightContactIsolation == null ? false : inpatientAdmission.HasTightContactIsolation);
                                            episodeActionWorkListItemModel.HasFallingRisk = (Boolean)(inpatientAdmission.HasFallingRisk == null ? false : inpatientAdmission.HasFallingRisk);
                                            episodeActionWorkListItemModel.HasDropletIsolation = (Boolean)(inpatientAdmission.HasDropletIsolation == null ? false : inpatientAdmission.HasDropletIsolation);
                                            episodeActionWorkListItemModel.HasAirborneContactIsolation = (Boolean)(inpatientAdmission.HasAirborneContactIsolation == null ? false : inpatientAdmission.HasAirborneContactIsolation);
                                            episodeActionWorkListItemModel.HasContactIsolation = (Boolean)(inpatientAdmission.HasContactIsolation == null ? false : inpatientAdmission.HasContactIsolation);
                                        }
                                    }
                                }



                                // RowColor set etme
                                string morRenk = "rgb(211, 133, 243)"; // açık Mor // "rgb(185, 90, 224)"; koyu mor
                                if (episodeAction is TreatmentDischarge && (episodeAction.CurrentStateDefID == TreatmentDischarge.States.PreDischarge || episodeAction.CurrentStateDefID == TreatmentDischarge.States.Discharged))
                                    episodeActionWorkListItemModel.RowColor = morRenk;
                                else if (episodeAction is InPatientTreatmentClinicApplication && (episodeAction.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Discharged || episodeAction.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Transferred))
                                    episodeActionWorkListItemModel.RowColor = morRenk;
                                else if (episodeAction is InPatientPhysicianApplication && (episodeAction.CurrentStateDefID == InPatientPhysicianApplication.States.PreDischarged || episodeAction.CurrentStateDefID == InPatientPhysicianApplication.States.Discharged))
                                    episodeActionWorkListItemModel.RowColor = morRenk;
                                else if (episodeAction is NursingApplication && (episodeAction.CurrentStateDefID == NursingApplication.States.PreDischarged || episodeAction.CurrentStateDefID == NursingApplication.States.Discharged))
                                    episodeActionWorkListItemModel.RowColor = morRenk;
                                
                                if (episodeAction.Episode.Patient.IsPatientAllergic())
                                    episodeActionWorkListItemModel.RowColor = Common.kirmiziRenk;
                                EpisodeActionList.Add(episodeActionWorkListItemModel);
                                counter++;

                                if(episodeAction is Manipulation)
                                {
                                    if(((Manipulation)episodeAction).ManipulationProcedures.Where(manipulation => manipulation.Emergency == true).FirstOrDefault() != null)
                                    {
                                        episodeActionWorkListItemModel.isEmergencyManipulationRequest = true;
                                    }
                                }
                            }
                        }
                    }
                }

                string filterExpressionForSPF = " ";
                if (inputdvo.SelectedWorkListItems != null && inputdvo.SelectedWorkListItems.Count > 0)
                {
                    List<Guid> objectDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListItem wli in inputdvo.SelectedWorkListItems)
                    {
                        TTObjectDef objDef = TTObjectDefManager.Instance.ObjectDefs[new Guid(wli.ObjectDefID)];
                        if (objDef.IsOfType("SubactionProcedureFlowable"))
                            objectDefIDs.Add(new Guid(wli.ObjectDefID));
                    }
                    if (objectDefIDs.Count > 0)
                    {
                        inputdvo.WorkListStateItems = FilterStatesWithObjectDef(inputdvo.SelectedWorkListItems, "e0444b60-fa7f-40bc-ba42-8f06556aee7c");
                        filterExpressionForSPF = Common.CreateFilterExpressionOfGuidList(filterExpressionForSPF, "OBJECTDEFID", objectDefIDs);
                    }
                }
                else
                {
                    MenuOutputDVO menuOutputDVO = GetEpisodeActionMenuDefinition();
                    inputdvo.WorkListItems = menuOutputDVO.SPFWorkListSearchItem;
                    inputdvo.WorkListStateItems = menuOutputDVO.SPFWorkListSearchStateItem;
                    List<Guid> objectDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListItem wli in inputdvo.WorkListItems)
                    {
                        objectDefIDs.Add(new Guid(wli.ObjectDefID));
                    }
                    if (objectDefIDs.Count > 0)
                        filterExpressionForSPF = Common.CreateFilterExpressionOfGuidList(filterExpressionForSPF, "OBJECTDEFID", objectDefIDs);
                }

                List<EpisodeActionWorkListStateItem> selectedStateDefsSPF = new List<EpisodeActionWorkListStateItem>();
                filterExpressionForSPF += GenerateExpression(inputdvo, workListDefinition, out selectedStateDefsSPF);
                if (inputdvo.SelectedWorkListStateItems == null || inputdvo.SelectedWorkListStateItems.Count == 0)
                {
                    inputdvo.WorkListStateItems = selectedStateDefsSPF;
                }
                counter = 0;
                if (!String.IsNullOrWhiteSpace(filterExpressionForSPF))
                {
                    IBindingList doctorsWorkListSPF = SubactionProcedureFlowable.GetBySPFWorklistDateReport(inputdvo.StartDate.Value, inputdvo.EndDate.Value, inputdvo.MinDate.Value, filterExpression + filterExpressionForSPF);
                    foreach (SubactionProcedureFlowable.GetBySPFWorklistDateReport_Class spf in doctorsWorkListSPF)
                    {
                        SubactionProcedureFlowable subactionProcedureFlowable = (SubactionProcedureFlowable)objectContext.GetObject(spf.ObjectID.Value, "SUBACTIONPROCEDUREFLOWABLE");
                        if (subactionProcedureFlowable is IWorkListEpisodeAction && !(subactionProcedureFlowable is IWorkListRadiology))
                        {
                            if (TTUser.CurrentUser.HasRight(subactionProcedureFlowable.CurrentStateDef.FormDef, subactionProcedureFlowable, workListDefinition.RightDefID.Value))// || (filteredWorkList && TTUser.CurrentUser.HasRight(subactionProcedureFlowable.CurrentStateDef.FormDef, subactionProcedureFlowable, (int)TTSecurityAuthority.RightsEnum.ReadForm)))
                            {
                                if (counter > workListMaxItemCount)
                                {
                                    model.maxWorklistItemCount += counter;
                                    break;
                                }
                                EpisodeActionWorkListItemModel episodeActionWorkListItemModel = new EpisodeActionWorkListItemModel();
                                episodeActionWorkListItemModel.ObjectID = subactionProcedureFlowable.ObjectID.ToString();
                                episodeActionWorkListItemModel.ObjectDefName = subactionProcedureFlowable.ObjectDef.Name;
                                //episodeActionWorkListItemModel.PatientNameSurname = episodeAction.Episode.Patient.PatientIDandFullName;
                                episodeActionWorkListItemModel.PatientNameSurname = subactionProcedureFlowable.Episode.Patient.FullName;
                                episodeActionWorkListItemModel.PatientIdentityNumber = subactionProcedureFlowable.Episode.Patient.RefNo;
                                //episodeActionWorkListItemModel.ID = (int)episodeAction.ID.Value;
                                if (subactionProcedureFlowable.SubEpisode != null)
                                {
                                    if (subactionProcedureFlowable.CreationDate.HasValue)
                                        episodeActionWorkListItemModel.RequestDateStr = (DateTime)subactionProcedureFlowable.CreationDate.Value;//.ToString("dd.MM.yyyy HH:mm");
                                    if (subactionProcedureFlowable.SubEpisode.PatientAdmission != null)
                                    {

                                        appointment = null;
                                        if (subactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionAppointment != null && subactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments.Count > 0)
                                        {
                                            foreach (Appointment app in subactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments)
                                            {
                                                if (app.MasterResource.ObjectID.Equals(subactionProcedureFlowable.MasterResource.ObjectID) && subactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue == false)
                                                {
                                                    appointment = app;
                                                    break;
                                                }
                                            }
                                        }

                                        if (appointment != null)
                                        {
                                            episodeActionWorkListItemModel.AdmissionQueueNumber = appointment.StartTime.Value.ToShortTimeString();
                                                                             }
                                        else
                                        {
                                            if (subactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                                            {
                                                if (subactionProcedureFlowable.WorkListDate.HasValue)
                                                    episodeActionWorkListItemModel.RequestDateStr = (DateTime)subactionProcedureFlowable.WorkListDate.Value;
                                            }
                                            episodeActionWorkListItemModel.AdmissionQueueNumber = Common.GetFormattedAdmissionQueueNumber(null, subactionProcedureFlowable.SubEpisode.PatientAdmission, true, appointment == null);

                                        }
                                        //else if (subactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.HasValue)
                                        //{
                                        //    if (subactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value < 10)
                                        //        episodeActionWorkListItemModel.AdmissionQueueNumber = "S-00" + subactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                                        //    else if (subactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value < 100)
                                        //        episodeActionWorkListItemModel.AdmissionQueueNumber = "S-0" + subactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();
                                        //    else
                                        //        episodeActionWorkListItemModel.AdmissionQueueNumber = "S-" + subactionProcedureFlowable.SubEpisode.PatientAdmission.ResultQueueNumber.Value.Value.ToString();

                                        //    if (subactionProcedureFlowable.WorkListDate.HasValue)
                                        //        episodeActionWorkListItemModel.RequestDateStr = (DateTime)subactionProcedureFlowable.WorkListDate.Value;//.ToString("dd.MM.yyyy HH:mm");
                                        //}
                                        //else if (subactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.HasValue)
                                        //{
                                        //    if (subactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value < 10)
                                        //        episodeActionWorkListItemModel.AdmissionQueueNumber = "00" + subactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                                        //    else if (subactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value < 100)
                                        //        episodeActionWorkListItemModel.AdmissionQueueNumber = "0" + subactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();
                                        //    else
                                        //        episodeActionWorkListItemModel.AdmissionQueueNumber = subactionProcedureFlowable.SubEpisode.PatientAdmission.AdmissionQueueNumber.Value.Value.ToString();

                                        //}

                                        if (subactionProcedureFlowable.MasterResource != null)
                                            episodeActionWorkListItemModel.AdmissionResourceName = subactionProcedureFlowable.MasterResource.Name;
                                        if (subactionProcedureFlowable.ProcedureDoctor != null)
                                            episodeActionWorkListItemModel.AdmissionDoctorName = subactionProcedureFlowable.ProcedureDoctor.Name;
                                        else if(subactionProcedureFlowable.SubEpisode.StarterEpisodeAction != null && subactionProcedureFlowable.SubEpisode.StarterEpisodeAction.ProcedureDoctor != null)
                                            episodeActionWorkListItemModel.AdmissionDoctorName = subactionProcedureFlowable.SubEpisode.StarterEpisodeAction.ProcedureDoctor.Name;
                                        if (subactionProcedureFlowable.SubEpisode.StarterEpisodeAction != null && subactionProcedureFlowable.SubEpisode.StarterEpisodeAction is InPatientTreatmentClinicApplication)
                                        {
                                            if (((InPatientTreatmentClinicApplication)subactionProcedureFlowable.SubEpisode.StarterEpisodeAction).ResponsibleNurse != null)
                                                episodeActionWorkListItemModel.ResponsibleNurseName = ((InPatientTreatmentClinicApplication)subactionProcedureFlowable.SubEpisode.StarterEpisodeAction).ResponsibleNurse.Name;
                                        }
                                        if (subactionProcedureFlowable.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo != null)
                                            episodeActionWorkListItemModel.ID = subactionProcedureFlowable.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo.ToString();
                                        

                                        if (subactionProcedureFlowable.SubEpisode.PatientAdmission.PriorityStatus != null)
                                        {
                                            if (subactionProcedureFlowable.SubEpisode.PatientAdmission.PriorityStatus.Code == "H")//Hamileler
                                                episodeActionWorkListItemModel.isPregnant = true;
                                            if (subactionProcedureFlowable.SubEpisode.PatientAdmission.PriorityStatus.Code == "Y")//65 Yaş Üstü Yaşlılar
                                                episodeActionWorkListItemModel.isOld = true;
                                            if (subactionProcedureFlowable.SubEpisode.PatientAdmission.PriorityStatus.Code == "G")//Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler
                                                episodeActionWorkListItemModel.isVetera = true;
                                            if (subactionProcedureFlowable.SubEpisode.PatientAdmission.PriorityStatus.Code == "A")//Acil Vakalar
                                                episodeActionWorkListItemModel.isEmergency = true;
                                            if (subactionProcedureFlowable.SubEpisode.PatientAdmission.PriorityStatus.Code == "E")//Engelliler
                                                episodeActionWorkListItemModel.isDisabled = true;
                                            if (subactionProcedureFlowable.SubEpisode.PatientAdmission.PriorityStatus.Code == "C")//7 Yaşından Küçük Çocuklar
                                                episodeActionWorkListItemModel.isYoung = true;
                                           
                                        }
                                    }

                                    if (subactionProcedureFlowable.Episode.Patient.ActivePregnancy != null || (subactionProcedureFlowable.Episode.Patient.MedicalInformation != null && subactionProcedureFlowable.Episode.Patient.MedicalInformation.Pregnancy.HasValue && subactionProcedureFlowable.Episode.Patient.MedicalInformation.Pregnancy.Value == true))
                                        episodeActionWorkListItemModel.isPregnant = true;
                                    if (subactionProcedureFlowable.Episode.Patient.Age.HasValue && subactionProcedureFlowable.Episode.Patient.Age.Value > 65)
                                        episodeActionWorkListItemModel.isOld = true;
                                    if (subactionProcedureFlowable.Episode.Patient.Age.HasValue && subactionProcedureFlowable.Episode.Patient.Age.Value < 7)
                                        episodeActionWorkListItemModel.isYoung = true;
                                    if (subactionProcedureFlowable.Episode.Patient.hasMedicalInformation())
                                        episodeActionWorkListItemModel.hasMedicalInformation = true;
                                    episodeActionWorkListItemModel.EpisodeObjectID = subactionProcedureFlowable.Episode.ObjectID;
                                }

                                episodeActionWorkListItemModel.EpisodeActionName = subactionProcedureFlowable.ObjectDef.DisplayText;
                                episodeActionWorkListItemModel.TransactionDate = (DateTime)subactionProcedureFlowable.WorkListDate.Value.Date;
                                if (subactionProcedureFlowable.CurrentStateDef != null)
                                    episodeActionWorkListItemModel.StateName = subactionProcedureFlowable.CurrentStateDef.DisplayText;
                                if (subactionProcedureFlowable.Episode.Patient.IsPatientAllergic())
                                    episodeActionWorkListItemModel.RowColor = Common.kirmiziRenk;

                                episodeActionWorkListItemModel.CurrentStateDefID = subactionProcedureFlowable.CurrentStateDefID.HasValue ? subactionProcedureFlowable.CurrentStateDefID.Value.ToString() : "";
                                episodeActionWorkListItemModel.ReasonOfCancel = subactionProcedureFlowable.ReasonOfCancel;
                                EpisodeActionList.Add(episodeActionWorkListItemModel);
                                counter++;
                            }
                        }
                    }
                }
                //EpisodeActionList.OrderBy(e => e.AdmissionQueueNumber).ToList();

                model.EpisodeActionList = EpisodeActionList.OrderBy(e => e.QueueNumberToSort).ThenBy(e => Convert.ToDateTime(e.TransactionDate)).ToList();
                model.txtPatient = inputdvo.txtPatient;
                model.StartDate = (DateTime)inputdvo.StartDate;
                model.EndDate = (DateTime)inputdvo.EndDate;
                if (inputdvo.ID > 0)
                    model.ID = (int)inputdvo.ID;
                if (inputdvo.WorkListCount > 0)
                    model.WorkListCount = (int)inputdvo.WorkListCount;
                //TODO: Kullanıcı özelliklerinden gelmeli.
                model.StateType = inputdvo.StateType;
                model.SelectedStateTypes = inputdvo.SelectedStateTypes;
                model.SelectedStateTypesEM = inputdvo.SelectedStateTypesEM;
                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    model.PatientStatus = inputdvo.PatientStatus;
                //model.workListItems = FilterStatesWithObjectDef();
                //objectContext.FullPartialllyLoadedObjects(); // Gerekli değil ve yavaşlatıyor ..
                return model;
            }
        }

        //public class EpisodeActionListComparer : IComparer<EpisodeActionWorkListItemModel>
        //{
        //    #region IComparer<LotoItem> Members
        //    public int Compare(EpisodeActionWorkListItemModel x, EpisodeActionWorkListItemModel y)
        //    {
        //    }
        //    #endregion
        //}

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public UserResourceOutputDVO GetUserResources(bool? FromRadiology = null)
        {
            UserResourceOutputDVO userResourceDVO = new UserResourceOutputDVO();
            List<UserResourceItem> userResourceList = new List<UserResourceItem>();
            List<UserResourceItem> selectedUserResourceList = new List<UserResourceItem>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                foreach (UserResource userResource in Common.CurrentResource.UserResources)
                {
                    if (userResource.Resource == null || userResource.Resource.IsActive != true)
                        continue;
                    if (!userResourceList.Exists(u => u.ResourceID.Equals(userResource.Resource.ObjectID.ToString())))
                    {
                        if (FromRadiology.HasValue && FromRadiology.Value)
                        {
                            foreach(ResourceSpecialityGrid speciality in userResource.Resource.ResourceSpecialities)
                            {
                                if (speciality.Speciality.SKRSKlinik != null && (speciality.Speciality.SKRSKlinik.KODU == "104" || speciality.Speciality.SKRSKlinik.KODU == "130" || speciality.Speciality.SKRSKlinik.KODU == "178"))
                                {
                                    UserResourceItem userResourceItem = new UserResourceItem();
                                    userResourceItem.ResourceID = userResource.Resource.ObjectID.ToString();
                                    userResourceItem.ResourceName = userResource.Resource.Name;
                                    userResourceList.Add(userResourceItem);
                                }
                            }
                        }
                        else
                        {
                            UserResourceItem userResourceItem = new UserResourceItem();
                            userResourceItem.ResourceID = userResource.Resource.ObjectID.ToString();
                            userResourceItem.ResourceName = userResource.Resource.Name;
                            userResourceList.Add(userResourceItem);
                        }
                    }
                }

                if (Common.CurrentResource.SelectedInPatientResource != null)
                {
                    UserResourceItem sUserResourceItem = new UserResourceItem();
                    sUserResourceItem.ResourceID = Common.CurrentResource.SelectedInPatientResource.ObjectID.ToString();
                    sUserResourceItem.ResourceName = Common.CurrentResource.SelectedInPatientResource.Name;
                    selectedUserResourceList.Add(sUserResourceItem);
                }

                userResourceDVO.WorkListSearchUserResourceItem = userResourceList.OrderBy(x => x.ResourceName).ToList();
                userResourceDVO.SelectedWorkListSearchUserResourceItem = selectedUserResourceList;
                objectContext.FullPartialllyLoadedObjects();
                return userResourceDVO;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public MenuOutputDVO GetEpisodeActionMenuDefinition()
        {
            MenuOutputDVO menu = new MenuOutputDVO();
            List<MenuDefinition> menuList = new List<MenuDefinition>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                menu = FilterObjectDefWithPermission();
                objectContext.FullPartialllyLoadedObjects();
                return menu;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public StateOutputDVO GetEpisodeActionStateDefinition(List<EpisodeActionWorkListItem> selectedEpisodeActionWorkListItems,string worklistDefID)
        {
            StateOutputDVO state = new StateOutputDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                state.WorkListSearchStateItem = FilterStatesWithObjectDef(selectedEpisodeActionWorkListItems, worklistDefID);
                objectContext.FullPartialllyLoadedObjects();
                return state;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LCDNotificationOutputDVO GetLCDNotificationDefinition()
        {
            LCDNotificationOutputDVO lcdNotificationOutputDVO = new LCDNotificationOutputDVO();
            lcdNotificationOutputDVO.LCDNotificationList = new List<LCDNotificationDefinition>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                BindingList<LCDNotificationDefinition> notificationDefinitions = objectContext.QueryObjects<LCDNotificationDefinition>("ISACTIVE = 1", "NOTIFICATION");
                foreach (var notificationDef in notificationDefinitions)
                {
                    //var notification = viewModel.LCDNotificationList.Where(t => t.ObjectID == notificationDef.ObjectID).FirstOrDefault();
                    //if (notification == null)
                    lcdNotificationOutputDVO.LCDNotificationList.Add(notificationDef);
                }
                lcdNotificationOutputDVO.isNewLcd = TTObjectClasses.SystemParameter.GetParameterValue("ISNEWLCD", "FALSE");
                objectContext.FullPartialllyLoadedObjects();
                return lcdNotificationOutputDVO;
            }
        }

        
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DynamicComponentInfoDVO GetDynamicComponentInfo([FromQuery] string ObjectId)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                TTObject obj = objectContext.GetObject(new Guid(ObjectId), typeof(EpisodeAction));
                var subFolders = GetParentFolders(obj.ObjectDef.ModuleDef);
                var folderPath = string.Join("/", subFolders.Reverse());
                var moduleName = obj.ObjectDef.ModuleDef.Name.GetTsModuleName();
                var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
                dynamicComponentInfo.ComponentName = obj.CurrentStateDef.FormDef.CodeName;
                dynamicComponentInfo.ModuleName = moduleName;
                dynamicComponentInfo.ModulePath = modulePath;
                dynamicComponentInfo.objectID = ObjectId;
                objectContext.FullPartialllyLoadedObjects();
                return dynamicComponentInfo;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DynamicComponentInfoDVO GetNewObjectDynamicComponentInfo([FromQuery] string ObjectDefName)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            var objectDefList = TTObjectDefManager.Instance.ObjectDefs;
            var objectDef = objectDefList.Values.Where(d => d.Name.ToUpperInvariant() == ObjectDefName).FirstOrDefault();
            if (objectDef == null)
                return dynamicComponentInfo;
            var subFolders = GetParentFolders(objectDef.ModuleDef);
            var folderPath = string.Join("/", subFolders.Reverse());
            var moduleName = objectDef.ModuleDef.Name.GetTsModuleName();
            var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
            string componentName = string.Empty;
            foreach (TTObjectStateDef state in objectDef.StateDefs)
            {
                if (state.IsEntry)
                {
                    componentName = state.FormDef.CodeName;
                    break;
                }
            }

            dynamicComponentInfo.ComponentName = componentName;
            dynamicComponentInfo.ModuleName = moduleName;
            dynamicComponentInfo.ModulePath = modulePath;
            dynamicComponentInfo.objectID = string.Empty;
            return dynamicComponentInfo;
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

        public static bool HasRightMenuDefinition(MenuDefinition menuDefinition)
        {
            // TTObjectContext objectContext = new TTObjectContext(true);
            if (menuDefinition.ObjectDefinitionName != null)
            {
                TTObjectStateDef entryState = EntryStateForMenuDefinition(menuDefinition);
                if (entryState == null)
                    return false;
                if (entryState.FormDef == null)
                    return false;
                return TTStorageManager.Security.TTUser.CurrentUser.HasRight(entryState.FormDef, null, (int)TTStorageManager.Security.TTSecurityAuthority.RightsEnum.UpdateForm);
            }
            else if (menuDefinition.UnboundFormName != null)
            {
                string unboundFormDefName = menuDefinition.UnboundFormName.ToUpperInvariant();
                if (TTObjectDefManager.Instance.UnboundFormDefs.ContainsKey(unboundFormDefName))
                {
                    return TTStorageManager.Security.TTUser.CurrentUser.HasRight(TTObjectDefManager.Instance.UnboundFormDefs[unboundFormDefName], null, (int)TTStorageManager.Security.TTSecurityAuthority.RightsEnum.UpdateForm);
                }
            }
            else
            {
                foreach (MenuDefinition md in menuDefinition.ChildMenus)
                {
                    if (HasRightMenuDefinition(md)) //Bir tanesi bile true olsa true döner
                        return true;
                }
            }

            return false;
        }

        public static TTObjectStateDef EntryStateForMenuDefinition(MenuDefinition menuDefinition)
        {
            if (menuDefinition.ObjectDefinitionName != null)
            {
                string objectDefName = menuDefinition.ObjectDefinitionName.ToUpperInvariant();
                if (TTObjectDefManager.Instance.ObjectDefs.ContainsKey(objectDefName) == true)
                {
                    TTObjectDef objDef = TTObjectDefManager.Instance.ObjectDefs[objectDefName];
                    if (menuDefinition.EntryState != null)
                    {
                        if (Globals.IsGuid(menuDefinition.EntryState))
                        {
                            Guid mdGuid = new Guid(menuDefinition.EntryState.ToString());
                            if (objDef.StateDefs.ContainsKey(mdGuid))
                                return objDef.StateDefs[mdGuid];
                        }
                    }

                    foreach (TTObjectStateDef StateDef in objDef.StateDefs)
                    {
                        if (StateDef.IsEntry == true)
                            return StateDef;
                    }
                }
            }

            return null;
        }

        private MenuOutputDVO FilterObjectDefWithPermission()
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            SortedList<string, TTObjectDef> _filteredObjectDefList = new SortedList<string, TTObjectDef>();
            MenuOutputDVO menuOutputDVO = new MenuOutputDVO();
            //TODO BB, worklistdef i şimdilik böyle çektim. Değişecek
            //WorkListDefinition _workListDefinition = (WorkListDefinition)objectContext.GetObject(new Guid("e0444b60-fa7f-40bc-ba42-8f06556aee7c"), "WorkListDefinition");
            //setWorkListDefinition();
            WorkListDefinition workListDefinition = getWorkListDefinition("e0444b60-fa7f-40bc-ba42-8f06556aee7c");
            foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values)
            {
                if (objDef.IsAbstract == false && objDef.AllImplementedInterfaceDefs.ContainsKey(workListDefinition.InterfaceDefName))
                {
                    if (TTUser.CurrentUser.IsSuperUser && _filteredObjectDefList.ContainsKey(objDef.ApplicationName) == false)
                        _filteredObjectDefList.Add(objDef.ApplicationName, objDef);
                    if (!TTUser.CurrentUser.IsSuperUser)
                    {
                        foreach (TTObjectStateDef stateDef in objDef.StateDefs)
                        {
                            ITTSecurableObject securableFormDef = stateDef.FormDef;
                            if (securableFormDef != null)
                            {
                                bool hasWorkList = false;
                                TTPermissionCollection subSecurityPermissionsCollection;
                                if (securableFormDef.SubSecurityPermissions.TryGetValue(stateDef.StateDefID, out subSecurityPermissionsCollection))
                                {
                                    foreach (TTPermission permission in subSecurityPermissionsCollection.Values)
                                    {
                                        if (permission.RightDef.RightDefID == workListDefinition.RightDefID.Value)
                                        {
                                            if (permission.ParameterValues.ContainsValue(true) && TTUser.CurrentUser.HasRole(permission.Role.RoleID))
                                            {
                                                hasWorkList = true;
                                                break;
                                            }
                                        }
                                    }

                                    if (hasWorkList)
                                    {
                                        if (_filteredObjectDefList.ContainsKey(objDef.ApplicationName) == false)
                                            _filteredObjectDefList.Add(objDef.ApplicationName, objDef);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            List<EpisodeActionWorkListItem> workListItems = new List<EpisodeActionWorkListItem>();
            List<EpisodeActionWorkListItem> EAWorkListItems = new List<EpisodeActionWorkListItem>();
            List<EpisodeActionWorkListItem> SPFWorkListItems = new List<EpisodeActionWorkListItem>();
            foreach (var l in _filteredObjectDefList)
            {
                EpisodeActionWorkListItem w = new Models.EpisodeActionWorkListItem();
                w.ObjectDefName = l.Value.ApplicationName;
                w.ObjectDefID = l.Value.ID.ToString();
                workListItems.Add(w);
                if (l.Value.IsOfType("EpisodeAction"))
                    EAWorkListItems.Add(w);
                else if (l.Value.IsOfType("SubactionProcedureFlowable"))
                    SPFWorkListItems.Add(w);
            }
            menuOutputDVO.WorkListSearchItem = workListItems;
            menuOutputDVO.EAWorkListSearchItem = EAWorkListItems;
            menuOutputDVO.SPFWorkListSearchItem = SPFWorkListItems;

            List<EpisodeActionWorkListStateItem> workListStateItems = new List<EpisodeActionWorkListStateItem>();
            List<EpisodeActionWorkListStateItem> EAWorkListStateItems = new List<EpisodeActionWorkListStateItem>();
            List<EpisodeActionWorkListStateItem> SPFWorkListStateItems = new List<EpisodeActionWorkListStateItem>();
            workListStateItems = FilterStatesWithObjectDef(workListItems, "e0444b60-fa7f-40bc-ba42-8f06556aee7c");
            EAWorkListStateItems = FilterStatesWithObjectDef(EAWorkListItems, "e0444b60-fa7f-40bc-ba42-8f06556aee7c");
            SPFWorkListStateItems = FilterStatesWithObjectDef(SPFWorkListItems, "e0444b60-fa7f-40bc-ba42-8f06556aee7c");
            menuOutputDVO.WorkListSearchStateItem = workListStateItems;
            menuOutputDVO.EAWorkListSearchStateItem = EAWorkListStateItems;
            menuOutputDVO.SPFWorkListSearchStateItem = SPFWorkListStateItems;
            menuOutputDVO.StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
            menuOutputDVO.EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
            menuOutputDVO.WorkListMaxDayToSearch = Common.WorklistDayLimit();
            return menuOutputDVO;
        }

        private List<EpisodeActionWorkListStateItem> FilterStatesWithObjectDef(List<EpisodeActionWorkListItem> selectedEpisodeActionWorkListItems, string worklistDefID)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            SortedList<Guid, SortedList<string, TTObjectStateDef>> _filteredObjectStateDefList = new SortedList<Guid, SortedList<string, TTObjectStateDef>>();
            WorkListDefinition workListDefinition = getWorkListDefinition(worklistDefID);
            List<EpisodeActionWorkListStateItem> workListStateItems = new List<EpisodeActionWorkListStateItem>();
            //if (selectedEpisodeActionWorkListItems != null && selectedEpisodeActionWorkListItems.Count == 1)
            if (selectedEpisodeActionWorkListItems != null)
            {
                foreach (EpisodeActionWorkListItem _episodeActionWorkListItem in selectedEpisodeActionWorkListItems)
                {
                    Guid objDefID = new Guid(_episodeActionWorkListItem.ObjectDefID);
                    TTObjectDef objDef = TTObjectDefManager.Instance.ObjectDefs[objDefID];
                    TTDefCollection<TTObjectStateDef> stateDefList = objDef.StateDefs;
                    foreach (TTObjectStateDef _stateDef in stateDefList)
                    {
                        ITTSecurableObject securableFormDef = _stateDef.FormDef;
                        if (securableFormDef != null)
                        {
                            if (TTUser.CurrentUser.IsSuperUser)
                            {
                                SortedList<string, TTObjectStateDef> _stateDefList;
                                if (_filteredObjectStateDefList.TryGetValue(objDefID, out _stateDefList) == false)
                                {
                                    _stateDefList = new SortedList<string, TTObjectStateDef>();
                                    _filteredObjectStateDefList.Add(objDefID, _stateDefList);
                                }

                                if (_stateDefList.ContainsKey(_stateDef.DisplayText) == false)
                                    _stateDefList.Add(_stateDef.DisplayText, _stateDef);
                            }
                            else
                            {
                                bool hasWorkList = false;
                                TTPermissionCollection subSecurityPermissionsCollection;
                                if (securableFormDef.SubSecurityPermissions.TryGetValue(_stateDef.StateDefID, out subSecurityPermissionsCollection))
                                {
                                    foreach (TTPermission permission in subSecurityPermissionsCollection.Values)
                                    {
                                        if (permission.RightDef.RightDefID == workListDefinition.RightDefID.Value)
                                        {
                                            if (permission.ParameterValues.ContainsValue(true) && TTUser.CurrentUser.HasRole(permission.Role.RoleID))
                                            {
                                                hasWorkList = true;
                                                break;
                                            }
                                        }
                                    }

                                    if (hasWorkList)
                                    {
                                        SortedList<string, TTObjectStateDef> _stateDefList;
                                        if (_filteredObjectStateDefList.TryGetValue(objDef.ID, out _stateDefList) == false)
                                        {
                                            _stateDefList = new SortedList<string, TTObjectStateDef>();
                                            _filteredObjectStateDefList.Add(objDef.ID, _stateDefList);
                                        }

                                        if (_stateDefList.ContainsKey(_stateDef.DisplayText) == false)
                                            _stateDefList.Add(_stateDef.DisplayText, _stateDef);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (var stItem in _filteredObjectStateDefList)
                {
                    foreach (var state in stItem.Value)
                    {
                        EpisodeActionWorkListStateItem ws = new Models.EpisodeActionWorkListStateItem();
                        ws.StateDefName = state.Value.ObjectDef.DisplayText + " - " + state.Value.DisplayText;
                        ws.StateDefID = state.Value.StateDefID.ToString();
                        ws.StateStatus = state.Value.Status.ToString().ToUpperInvariant();
                        workListStateItems.Add(ws);
                    }
                }
            }

            return workListStateItems;
        }

        private string getPatientCallStatus(EpisodeAction episodeAction)
        {
            ExaminationQueueItem queueItem = episodeAction.GetActiveQueueItem(false);
            if (queueItem != null)
            {
                int callCount = 1;
                if (queueItem.CallCount.HasValue)
                    callCount = queueItem.CallCount.Value;
                if (queueItem.Priority == -1)
                {
                    if (Common.RecTime().Subtract(queueItem.CallTime.Value).TotalMinutes < Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("ACILDETEKRARSIRAYAALMASURESI", "15")))
                        return "HASTA ÇAĞIRILDI - ÇAĞIRILMA SAYISI : " + callCount.ToString();
                    else
                        return "HASTA DAHA ÖNCE " + callCount.ToString() + " KEZ ÇAĞIRILDI";
                }
                else
                {
                    if (callCount > 0)
                        return "HASTA DAHA ÖNCE " + callCount.ToString() + " KEZ ÇAĞIRILDI";
                }
            }
            return String.Empty;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public SpecialPanelOutputDVO GetSpecialPanelDefinition([FromQuery] string activeResUserObjectID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                SpecialPanelOutputDVO specialPanelDVO = new SpecialPanelOutputDVO();
                specialPanelDVO.SpecialPanelList = new List<SpecialPanelListItem>();
                //List<SpecialPanelDefinition> specialPanelList = new List<SpecialPanelDefinition>();
                ResUser activeResUser = objectContext.GetObject<ResUser>(new Guid(activeResUserObjectID));
                WorkListDefinition workListDefinition = getWorkListDefinition("e0444b60-fa7f-40bc-ba42-8f06556aee7c");
                WorkListDefinition __workListDefinition = objectContext.GetObject<WorkListDefinition>(workListDefinition.ObjectID);
                IList pDefs = SpecialPanelDefinition.GetByUserAndWorkListDef(objectContext, activeResUserObjectID, __workListDefinition.ObjectID.ToString());
                if (pDefs.Count == 0)
                {
                    SpecialPanelDefinition newDef = new SpecialPanelDefinition(objectContext);
                    newDef.Caption = "<Tümü>";
                    newDef.Name = "@DEFAULT@";
                    //newDef.User = activeResUser;
                    //SpecialPanelRoleMatch specialPanelRoleMatch = new SpecialPanelRoleMatch(objectContext);
                    //specialPanelRoleMatch.RoleID = Guid.Empty;//Everyone
                    //specialPanelRoleMatch.SpecialPanelDefinition = newDef;
                    __workListDefinition.SpecialPanelDefinitions.Add(newDef);
                    __workListDefinition.LastSpecialPanel = newDef;
                    SpecialPanelListItem specialPanelListItem = createNewSpecialPanelListItem(newDef);
                    specialPanelDVO.SpecialPanelList.Add(specialPanelListItem);
                    specialPanelDVO.LastSelectedSpecialPanel = specialPanelListItem;
                    //specialPanelList.Add(newDef);
                    objectContext.Save();
                    //RefreshInternalObjects();
                }

                foreach (SpecialPanelDefinition pDef in pDefs)
                {
                    if (pDef.User == null)
                    {
                        bool addPanel = true;
                        foreach (SpecialPanelCriteriaValue cv in pDef.CriteriaValues)
                        {
                            if (!addPanel)
                                break;
                            if (cv.Value != null)
                            {
                                if (cv.Name == "STATES")
                                {
                                    List<string> values = cv.Value.Split(',').ToList<string>();
                                    values.ForEach(ID =>
                                    {
                                        TTObjectStateDef stateDef = TTObjectDefManager.Instance.AllTTObjectStateDefs[new Guid(ID)];
                                        if (TTUser.CurrentUser.HasRight(stateDef.FormDef, null, pDef.WorkListDefinition.RightDefID.Value, stateDef) != true)
                                        {
                                            addPanel = false;
                                        }
                                    });
                                }
                            }
                        }
                        if (addPanel)
                        {
                            SpecialPanelListItem specialPanelListItem = createNewSpecialPanelListItem(pDef);
                            specialPanelDVO.SpecialPanelList.Add(specialPanelListItem);
                        }
                        //if (pDef.SpecialPanelRoles != null && pDef.SpecialPanelRoles.Count > 0)
                        //{
                        //    //bool addPanel = false;
                        //    foreach (SpecialPanelRoleMatch role in pDef.SpecialPanelRoles)
                        //    {
                        //        if(TTUser.CurrentUser.HasRole(role.RoleID.Value))
                        //        {
                        //            addPanel = true;
                        //            break;
                        //        }
                        //    }
                        //    if(addPanel)
                        //    {
                        //        SpecialPanelListItem specialPanelListItem = createNewSpecialPanelListItem(pDef);
                        //        specialPanelDVO.SpecialPanelList.Add(specialPanelListItem);
                        //    }
                        //}
                    }
                    else if (pDef.User.ObjectID.Equals(new Guid(activeResUserObjectID)))
                    {
                        SpecialPanelListItem specialPanelListItem = createNewSpecialPanelListItem(pDef);
                        specialPanelDVO.SpecialPanelList.Add(specialPanelListItem);
                        //specialPanelList.Add(pDef);
                    }
                }

                if (__workListDefinition.LastSpecialPanel != null)
                {
                    if (__workListDefinition.LastSpecialPanel.User == null)
                    {
                        bool addPanel = true;
                        foreach (SpecialPanelCriteriaValue cv in __workListDefinition.LastSpecialPanel.CriteriaValues)
                        {
                            if (!addPanel)
                                break;
                            if (cv.Value != null)
                            {
                                if (cv.Name == "STATES")
                                {
                                    List<string> values = cv.Value.Split(',').ToList<string>();
                                    values.ForEach(ID =>
                                    {
                                        TTObjectStateDef stateDef = TTObjectDefManager.Instance.AllTTObjectStateDefs[new Guid(ID)];
                                        if (TTUser.CurrentUser.HasRight(stateDef.FormDef, null, __workListDefinition.LastSpecialPanel.WorkListDefinition.RightDefID.Value, stateDef) != true)
                                        {
                                            addPanel = false;
                                        }
                                    });
                                }
                            }
                        }
                        if (addPanel)
                        {
                            SpecialPanelListItem lastSpecialPanelListItem = createNewSpecialPanelListItem(__workListDefinition.LastSpecialPanel);
                            specialPanelDVO.LastSelectedSpecialPanel = lastSpecialPanelListItem;
                        }

                        //if (__workListDefinition.LastSpecialPanel.SpecialPanelRoles != null && __workListDefinition.LastSpecialPanel.SpecialPanelRoles.Count > 0)
                        //{
                        //    bool addPanel = false;
                        //    foreach (SpecialPanelRoleMatch role in __workListDefinition.LastSpecialPanel.SpecialPanelRoles)
                        //    {
                        //        if (TTUser.CurrentUser.HasRole(role.RoleID.Value))
                        //        {
                        //            addPanel = true;
                        //            break;
                        //        }
                        //    }
                        //    if (addPanel)
                        //    {
                        //        SpecialPanelListItem lastSpecialPanelListItem = createNewSpecialPanelListItem(__workListDefinition.LastSpecialPanel);
                        //        specialPanelDVO.LastSelectedSpecialPanel = lastSpecialPanelListItem;
                        //    }
                        //}
                    }
                    else if (__workListDefinition.LastSpecialPanel.User.ObjectID.Equals(new Guid(activeResUserObjectID)))
                    {
                        SpecialPanelListItem lastSpecialPanelListItem = createNewSpecialPanelListItem(__workListDefinition.LastSpecialPanel);
                        specialPanelDVO.LastSelectedSpecialPanel = lastSpecialPanelListItem;
                    }

                }
                else
                    specialPanelDVO.LastSelectedSpecialPanel = specialPanelDVO.SpecialPanelList[0];

                objectContext.FullPartialllyLoadedObjects();
                specialPanelDVO.SpecialPanelList.OrderBy(x => x.Name);
                return specialPanelDVO;
            }
        }

        protected virtual SpecialPanelListItem createNewSpecialPanelListItem(SpecialPanelDefinition pDef)
        {
            SpecialPanelListItem specialPanelListItem = new SpecialPanelListItem();
            specialPanelListItem.Name = pDef.Name;
            specialPanelListItem.Caption = pDef.Caption;
            specialPanelListItem.ObjectID = pDef.ObjectID.ToString();
            if (pDef.User != null)
                specialPanelListItem.User = pDef.User.ToString();
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

        private SpecialPanelCriteriaValue GetSPCriteriaValue(string name, WorkListDefinition __workListDefinition)
        {
            SpecialPanelCriteriaValue retVal = null;
            foreach (SpecialPanelCriteriaValue pCriteria in __workListDefinition.LastSpecialPanel.CriteriaValues)
            {
                if (pCriteria.Name == name)
                {
                    retVal = pCriteria;
                    break;
                }
            }

            return retVal;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public SpecialPanelInputDVO SaveSpecialPanel(SpecialPanelInputDVO inputdvo)
        {
            try
            {
                bool isCreatedOrUpdated = false;
                TTObjectContext objectContext = new TTObjectContext(false);
                WorkListDefinition workListDefinition = getWorkListDefinition("e0444b60-fa7f-40bc-ba42-8f06556aee7c");
                WorkListDefinition __workListDefinition = objectContext.GetObject<WorkListDefinition>(workListDefinition.ObjectID);
                ResUser activeResUser = objectContext.GetObject<ResUser>(new Guid(inputdvo.activeResUserObjectID));
                if (inputdvo.LastSelectedSpecialPanel == null || inputdvo.LastSelectedSpecialPanel.Name == "@DEFAULT@" || String.IsNullOrEmpty(inputdvo.LastSelectedSpecialPanel.User))
                {
                    if (inputdvo.LastSelectedSpecialPanel == null || inputdvo.SpecialPanelListItemCaption != inputdvo.LastSelectedSpecialPanel.Caption)
                    {
                        SpecialPanelDefinition newDef = new SpecialPanelDefinition(objectContext);
                        newDef.Name = Globals.MakeVariableName(inputdvo.SpecialPanelListItemCaption).ToUpperInvariant();
                        newDef.Caption = inputdvo.SpecialPanelListItemCaption;
                        newDef.User = activeResUser;
                        __workListDefinition.LastSpecialPanel = newDef;
                        newDef.WorkListDefinition = __workListDefinition;
                        //workListDefinition.SpecialPanelDefinitions.Add(newDef);
                        SpecialPanelListItem newSpecialPanelListItem = createNewSpecialPanelListItem(newDef);
                        inputdvo.SpecialPanelListItems.Add(newSpecialPanelListItem);
                        inputdvo.LastSelectedSpecialPanel = newSpecialPanelListItem;
                        isCreatedOrUpdated = true;
                    }
                }
                else
                {
                    SpecialPanelDefinition pDef = (SpecialPanelDefinition)objectContext.GetObject(new Guid(inputdvo.LastSelectedSpecialPanel.ObjectID), typeof(SpecialPanelDefinition));
                    //if (pDef.Name != "@DEFAULT@")
                    if (pDef.User != null)
                    {
                        pDef.Name = Globals.MakeVariableName(inputdvo.SpecialPanelListItemCaption).ToUpperInvariant();
                        pDef.Caption = inputdvo.SpecialPanelListItemCaption;
                        __workListDefinition.LastSpecialPanel = pDef;
                        isCreatedOrUpdated = true;
                    }
                }

                if (isCreatedOrUpdated)
                {
                    this.SaveSpecialCriteria(objectContext, inputdvo.SelectedWorkListItems, inputdvo.SelectedWorkListStateItems, __workListDefinition);
                    objectContext.Save();
                    objectContext.FullPartialllyLoadedObjects();
                    inputdvo.SpecialPanelListItems.OrderBy(x => x.Name);
                }

                return inputdvo;
            }
            catch
            {
                return null;
                //InfoBox.Show(MainHospitalForm.MainHospitalFormInstance, ex);
            }
        }

        private void SaveSpecialCriteria(TTObjectContext objectContext, List<EpisodeActionWorkListItem> SelectedWorkListItems, List<EpisodeActionWorkListStateItem> SelectedWorkListStateItems, WorkListDefinition __workListDefinition)
        {
            string sObjects = "";
            int nCounter = 0;
            foreach (EpisodeActionWorkListItem episodeActionWorkListItem in SelectedWorkListItems)
            {
                sObjects += episodeActionWorkListItem.ObjectDefID.ToString();
                if ((nCounter + 1) < SelectedWorkListItems.Count)
                    sObjects += ",";
                nCounter++;
            }

            SpecialPanelCriteriaValue crValObj = this.GetSPCriteriaValue("OBJECTDEFINITIONS", __workListDefinition);
            if (crValObj == null)
            {
                SpecialPanelCriteriaValue newCrVal = new SpecialPanelCriteriaValue(objectContext);
                newCrVal.Value = sObjects;
                newCrVal.Name = "OBJECTDEFINITIONS";
                newCrVal.SpecialPanel = __workListDefinition.LastSpecialPanel;
            }
            else
            {
                crValObj.Value = sObjects;
            }

            string sStates = "";
            nCounter = 0;
            foreach (EpisodeActionWorkListStateItem episodeActionWorkListStateItem in SelectedWorkListStateItems)
            {
                sStates += episodeActionWorkListStateItem.StateDefID.ToString();
                if ((nCounter + 1) < SelectedWorkListStateItems.Count)
                    sStates += ",";
                nCounter++;
            }

            SpecialPanelCriteriaValue crValState = this.GetSPCriteriaValue("STATES", __workListDefinition);
            if (crValState == null)
            {
                SpecialPanelCriteriaValue newCrVal = new SpecialPanelCriteriaValue(objectContext);
                newCrVal.Value = sStates;
                newCrVal.Name = "STATES";
                newCrVal.SpecialPanel = __workListDefinition.LastSpecialPanel;
            }
            else
            {
                crValState.Value = sStates;
            }
        }

        /// <summary>
        /// Özel panelin silinmesini sağlar.
        /// </summary>
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public SpecialPanelInputDVO DeleteSpecialPanel(SpecialPanelInputDVO inputdvo)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            WorkListDefinition workListDefinition = getWorkListDefinition("e0444b60-fa7f-40bc-ba42-8f06556aee7c");
            WorkListDefinition __workListDefinition = objectContext.GetObject<WorkListDefinition>(workListDefinition.ObjectID);
            SpecialPanelInputDVO outputdvo = inputdvo;
            try
            {
                if (outputdvo.LastSelectedSpecialPanel != null && outputdvo.LastSelectedSpecialPanel.Name != "@DEFAULT@" && !String.IsNullOrEmpty(outputdvo.LastSelectedSpecialPanel.User))
                {
                    IList pCrValues = CriteriaValue.GetCriteriaValuesBySpecialPanel(objectContext, outputdvo.LastSelectedSpecialPanel.ObjectID.ToString());
                    IList pSpCrValues = SpecialPanelCriteriaValue.GetSPCriteriaValueByParent(objectContext, outputdvo.LastSelectedSpecialPanel.ObjectID.ToString());
                    ITTObject pDef = (ITTObject)objectContext.GetObject(new Guid(outputdvo.LastSelectedSpecialPanel.ObjectID), typeof(SpecialPanelDefinition));
                    pDef.Delete();
                    __workListDefinition.LastSpecialPanel = null;
                    List<SpecialPanelListItem> sList = new List<SpecialPanelListItem>();
                    sList = outputdvo.SpecialPanelListItems;
                    sList.Remove(outputdvo.LastSelectedSpecialPanel);
                    outputdvo.SpecialPanelListItems = sList;
                    //outputdvo.SpecialPanelListItems.Remove(outputdvo.LastSelectedSpecialPanel);
                    foreach (SpecialPanelListItem specialPanelListItem in outputdvo.SpecialPanelListItems)
                    {
                        if (specialPanelListItem.Name == "@DEFAULT@")
                        {
                            outputdvo.LastSelectedSpecialPanel = specialPanelListItem;
                            outputdvo.SpecialPanelListItemCaption = specialPanelListItem.Caption;
                            break;
                        }
                    }

                    foreach (ITTObject pCrValue in pCrValues)
                        pCrValue.Delete();
                    foreach (ITTObject pCrValue in pSpCrValues)
                        pCrValue.Delete();
                    objectContext.Save();
                }

                outputdvo.SpecialPanelListItems.OrderBy(x => x.Name);
                return outputdvo;
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ActiveInfoDVO GetActiveInfoDVO([FromQuery] string ObjectId, [FromQuery] string ObjectDefName)
        {
            ActiveInfoDVO activeInfoDVO = new ActiveInfoDVO();
            if (String.IsNullOrEmpty(ObjectId))
            {
                activeInfoDVO.EpisodeActionObjectID = Guid.Empty;
                activeInfoDVO.EpisodeObjectID = Guid.Empty;
                activeInfoDVO.PatientObjectID = Guid.Empty;
            }
            else
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    TTObject action = objectContext.GetObject(new Guid(ObjectId), ObjectDefName);
                    if (action is EpisodeAction)
                    {
                        EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject(new Guid(ObjectId), typeof(EpisodeAction));
                        activeInfoDVO.EpisodeActionObjectID = episodeAction.ObjectID;
                        activeInfoDVO.EpisodeObjectID = episodeAction.Episode.ObjectID;
                        activeInfoDVO.PatientObjectID = episodeAction.Episode.Patient.ObjectID;
                    }

                    if (action is SubactionProcedureFlowable)
                    {
                        SubactionProcedureFlowable subactionProcedureFlowable = (SubactionProcedureFlowable)objectContext.GetObject(new Guid(ObjectId), typeof(SubactionProcedureFlowable));
                        activeInfoDVO.EpisodeActionObjectID = subactionProcedureFlowable.ObjectID;
                        activeInfoDVO.EpisodeObjectID = subactionProcedureFlowable.Episode.ObjectID;
                        activeInfoDVO.PatientObjectID = subactionProcedureFlowable.Episode.Patient.ObjectID;
                    }

                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return activeInfoDVO;
        }
    }
}