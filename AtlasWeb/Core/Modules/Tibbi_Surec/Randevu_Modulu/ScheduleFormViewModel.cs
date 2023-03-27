//$1586A49D
using System;
using System.Collections.Generic;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using TTStorageManager.Security;
using System.Collections;
using TTDataDictionary;
using System.Globalization;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Core.Controllers
{
    public partial class ScheduleServiceController
    {
        protected void ApplySecurity()
        {
            if (!TTUser.CurrentUser.HasRole(TTRoleNames.Randevu_Planlama))
                throw new TTException(SystemMessage.GetMessageV2(343, TTUtils.CultureService.GetText("M26731", "Randevu Planlama için yetkiniz yok.")));
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public ScheduleFormViewModel ScheduleForm(Guid? id)
        {
            var formDefID = Guid.Parse("d576b966-29e4-4916-9fa3-ee4adfec5efa");
            var objectDefID = Guid.Parse("a93d5b7a-2372-454e-84b5-e4b43aa1f006");
            var viewModel = new ScheduleFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                if (id.HasValue && id.Value != Guid.Empty)
                {
                    viewModel._Schedule = objectContext.GetObject(id.Value, objectDefID) as Schedule;
                    viewModel.ReadOnly = true; //TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Schedule, formDefID);
                    //viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Schedule, formDefID);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Schedule);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Schedule);
                    PreScript_ScheduleForm(viewModel, viewModel._Schedule, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
                else
                {
                    viewModel._Schedule = new Schedule(objectContext);
                    viewModel.ReadOnly = true; // TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Schedule, formDefID);
                    //viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Schedule, formDefID);
                    viewModel.AppointmentDefinitionList = new System.Collections.Generic.List<AppointmentDefinition>();
                    viewModel.AppointmentCarrierList = new System.Collections.Generic.List<AppointmentCarrier>();
                    viewModel.AppointmentTypeList = new System.Collections.Generic.List<AppointmentTypeListDVO>();
                    viewModel.MasterResourceList = new System.Collections.Generic.List<Resource>();
                    viewModel.SubResourceList = new System.Collections.Generic.List<Resource>();
                    viewModel.SelectedMasterResourceList = new System.Collections.Generic.List<Guid>();
                    viewModel.SelectedSubResourceList = new System.Collections.Generic.List<Guid>();
                    viewModel.MHRSActionList = new System.Collections.Generic.List<MHRSActionTypeDefinition>();
                    viewModel.ScheduleAppointmentTypes = new System.Collections.Generic.List<ScheduleAppointmentType>();
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Schedule);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Schedule);
                    PreScript_ScheduleForm(viewModel, viewModel._Schedule, objectContext);
                }
            }

            return viewModel;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public void ScheduleForm(ScheduleFormViewModel viewModel)
        {
            var formDefID = Guid.Parse("d576b966-29e4-4916-9fa3-ee4adfec5efa");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel._Schedule);
                objectContext.AddToRawObjectList(viewModel.AppointmentDefinitionList);
                objectContext.AddToRawObjectList(viewModel.AppointmentCarrierList);
                objectContext.AddToRawObjectList(viewModel.MasterResourceList);
                objectContext.AddToRawObjectList(viewModel.SubResourceList);
                objectContext.AddToRawObjectList(viewModel.MHRSActionList);
                objectContext.AddToRawObjectList(viewModel.AppointmentCarrier);
                objectContext.AddToRawObjectList(viewModel._Schedule.AppointmentDefinition);
                objectContext.AddToRawObjectList(viewModel._Schedule.MasterResource);
                objectContext.AddToRawObjectList(viewModel._Schedule.Resource);
                objectContext.AddToRawObjectList(viewModel._Schedule.MasterSchedule);
                objectContext.AddToRawObjectList(viewModel._Schedule.MHRSActionTypeDefinition);
                objectContext.AddToRawObjectList(viewModel._Schedule.ScheduleJobRules);
                objectContext.ProcessRawObjects();
                var schedule = (Schedule)objectContext.GetLoadedObject(viewModel._Schedule.ObjectID);
                //TTDefinitionManagement.TTFormDef.CheckFormSecurity(schedule, formDefID, true);
                //TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Schedule, formDefID);
                PostScript_ScheduleForm(viewModel, schedule, schedule.TransDef, objectContext);
                objectContext.Save();
                AfterContextSaveScript_ScheduleForm(viewModel, schedule, schedule.TransDef, objectContext);
            }
        }

        partial void PreScript_ScheduleForm(ScheduleFormViewModel viewModel, Schedule schedule, TTObjectContext objectContext);
        partial void PostScript_ScheduleForm(ScheduleFormViewModel viewModel, Schedule schedule, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ScheduleForm(ScheduleFormViewModel viewModel, Schedule schedule, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(ScheduleFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.AppointmentDefinitionList = objectContext.LocalQuery<AppointmentDefinition>().ToList();
            viewModel.AppointmentCarrierList = objectContext.LocalQuery<AppointmentCarrier>().ToList();
            viewModel.MasterResourceList = objectContext.LocalQuery<Resource>().ToList();
            viewModel.SubResourceList = objectContext.LocalQuery<Resource>().ToList();
            viewModel.MHRSActionList = objectContext.LocalQuery<MHRSActionTypeDefinition>().ToList();
        }

        private bool CheckScheduleRight(AppointmentDefinition appDef, int rightDefID, Resource masterResource)
        {
            TTObjectContext disposableContext = new TTObjectContext(false);
            if (!String.IsNullOrEmpty(appDef.FormDefID))
            {
                Appointment app = new Appointment(disposableContext);
                app.MasterResource = masterResource != null ? masterResource : null;
                TTFormDef frmDef = TTObjectDefManager.Instance.ObjectDefs["Appointment"].FormDefs[new Guid(appDef.FormDefID)];
                if (Common.CurrentUser.HasRight(frmDef, app, rightDefID) == false)
                {
                    disposableContext.Dispose();
                    return false;
                }
            }

            disposableContext.Dispose();
            return true;
        }

        void SetDefaultValues(ScheduleFormViewModel viewModel)
        {
            DateTime currentDate = new DateTime(TTObjectDefManager.ServerTime.Date.Year, TTObjectDefManager.ServerTime.Date.Month, TTObjectDefManager.ServerTime.Date.Day, 0, 0, 0);
            //viewModel._Schedule.ScheduleDate = currentDate;
            viewModel.recurrenceStartDate = currentDate;
            viewModel.recurrenceEndDate = currentDate;
            viewModel._Schedule.StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 8, 0, 0);
            viewModel._Schedule.EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 9, 0, 0);
            viewModel._Schedule.ScheduleDate = viewModel._Schedule.StartTime;
            viewModel._Schedule.SentToMHRS = false;
            viewModel._Schedule.ScheduleType = ScheduleTypeEnum.Timely;
            viewModel._Schedule.CetvelTipiValue = CetvelTipiEnum.Hekim;
            viewModel.cetvelTipi = CetvelTipiEnum.Hekim;
            viewModel._Schedule.Duration = 0;
            viewModel.txtDurationDisabled = false;
            viewModel.txtCountLimitDisabled = true;
            viewModel.MHRSActionFilter = "ISWORKINGHOUR = 1";
            viewModel.showScheduleJobRuleGrid = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("MHRSISKURALIEKLEME", "FALSE"));
            viewModel.newMHRSParameter = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE"));
        }

        public int GetWeekNumber(DateTime currentDate)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        public DayOfWeek GetDayOfWeek(DateTime currentDate)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            DayOfWeek dayOfWeek = ciCurr.Calendar.GetDayOfWeek(currentDate);
            return dayOfWeek;
        }

        public DateTime GetFirstDateOfWeek(DateTime currentDate)
        {
            DayOfWeek currentDayOfWeek = GetDayOfWeek(currentDate);
            int dayNum = Convert.ToInt16(currentDayOfWeek);
            if (dayNum == 0)
                dayNum = 7;
            return currentDate.AddDays(-(dayNum - 1));
        }

        public DateTime GetFirstDateOfMonth(DateTime currentDate)
        {
            return new DateTime(currentDate.Year, currentDate.Month, 1);
        }

        public DateTime GetLastDateOfMonth(DateTime currentDate)
        {
            return GetFirstDateOfMonth(currentDate).AddMonths(1).AddDays(-1);
        }
        private void FillScheduleFormComboValues(ScheduleFormViewModel viewModel)
        {
            FillAppointmentDefinitions(viewModel);
            FillAppointmentCarriers(viewModel);
            FillScheduleAppointmentTypes(viewModel);
            FillSubResources(viewModel);
            FillMasterResources(viewModel);
            FillMHRSActions(viewModel);
        }

        private void FillMHRSActions(ScheduleFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                IList MHRSActionList = objectContext.QueryObjects("MHRSACTIONTYPEDEFINITION", viewModel.MHRSActionFilter, "ACTIONNAME");
                foreach (MHRSActionTypeDefinition actionType in MHRSActionList)
                {
                    viewModel.MHRSActionList.Add(actionType);
                }

                if (viewModel.MHRSActionList.Count > 0)
                {
                    viewModel._Schedule.MHRSActionTypeDefinition = viewModel.MHRSActionList.FirstOrDefault(x => (x.ActionCode == "1" || x.ActionCode == "200"));
                    if (viewModel._Schedule.MHRSActionTypeDefinition == null)
                        viewModel._Schedule.MHRSActionTypeDefinition = viewModel.MHRSActionList[0];
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public MHRSActionDVO FillMHRSActionCombo(MHRSActionInputDVO mhrsActionInputDVO)
        {
            MHRSActionDVO mhrsActionDVO = new MHRSActionDVO();
            mhrsActionDVO.MHRSActionList = new List<MHRSActionTypeDefinition>();
            mhrsActionDVO.defaultMHRSAction = new MHRSActionTypeDefinition();
            using (TTObjectContext context = new TTObjectContext(true))
            {
                IList MHRSActionList = context.QueryObjects("MHRSACTIONTYPEDEFINITION", mhrsActionInputDVO.MHRSActionFilter, "ACTIONNAME");
                foreach (MHRSActionTypeDefinition actionType in MHRSActionList)
                {
                    mhrsActionDVO.MHRSActionList.Add(actionType);
                }

                if (mhrsActionDVO.MHRSActionList.Count > 0)
                {
                    mhrsActionDVO.defaultMHRSAction = mhrsActionDVO.MHRSActionList.FirstOrDefault(x => x.ActionCode == "1" || x.ActionCode == "200");
                    if (mhrsActionDVO.defaultMHRSAction == null)
                        mhrsActionDVO.defaultMHRSAction = mhrsActionDVO.MHRSActionList[0];
                }
                context.FullPartialllyLoadedObjects();
                return mhrsActionDVO;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public bool IsSentToMHRS(Resource resource)
        {
            bool SentToMHRSVisible = true;
            if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE")
            {
                SentToMHRSVisible = true;
            }
            else
                SentToMHRSVisible = false;
            return SentToMHRSVisible;
        }

        private void FillSubResources(ScheduleFormViewModel viewModel)
        {
            SubResourceInputDVO subResourceInputDVO = new SubResourceInputDVO();
            subResourceInputDVO.isKioskAppointment = false;
            if (viewModel._Schedule.AppointmentDefinition == null)
                return;
            subResourceInputDVO.appointmentCarrierObjectID = viewModel.AppointmentCarrier.ObjectID.ToString();
            subResourceInputDVO.appointmentDefObjectID = viewModel._Schedule.AppointmentDefinition.ObjectID.ToString();
            if (viewModel._Schedule.MasterResource != null)
                subResourceInputDVO.defaultMasterResourceObjectID = viewModel._Schedule.MasterResource.ObjectID.ToString();
            subResourceInputDVO.subResourceType = viewModel.AppointmentCarrier.SubResource;
            subResourceInputDVO.relationParentName = viewModel.AppointmentCarrier.RelationParentName;
            SubResourceDVO subResourceDVO = FillSubResourceCombo(subResourceInputDVO);
            viewModel._Schedule.Resource = subResourceDVO.defaultSubResource;
            if (IsSentToMHRS(viewModel._Schedule.Resource))
            {
                viewModel.SentToMHRSVisible = true;
                if (viewModel._Schedule.Resource != null && viewModel._Schedule.Resource.GetType() == typeof(ResUser))
                {
                    if (((ResUser)viewModel._Schedule.Resource).SentToMHRS.HasValue)
                        viewModel._Schedule.SentToMHRS = ((ResUser)viewModel._Schedule.Resource).SentToMHRS.Value;
                    else
                        viewModel._Schedule.SentToMHRS = false;
                }
            }
            else
                viewModel.SentToMHRSVisible = false;
            viewModel.SubResourceList = subResourceDVO.SubResourceList;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public SubResourceDVO FillSubResourceCombo(SubResourceInputDVO subResourceInputDVO)
        {
            bool isUserTypeAllowed;
            SubResourceDVO subResourceDVO = new SubResourceDVO();
            subResourceDVO.defaultSubResource = null;
            subResourceDVO.SubResourceList = new List<Resource>();
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            AppointmentDefinition appDef = readOnlyContext.GetObject<AppointmentDefinition>(new Guid(subResourceInputDVO.appointmentDefObjectID));
            AppointmentCarrier appCarrier = readOnlyContext.GetObject<AppointmentCarrier>(new Guid(subResourceInputDVO.appointmentCarrierObjectID));
            ResSection masterResource = null;
            if (!String.IsNullOrEmpty(subResourceInputDVO.defaultMasterResourceObjectID))
                masterResource = readOnlyContext.GetObject<ResSection>(new Guid(subResourceInputDVO.defaultMasterResourceObjectID));
            bool isExists = false;
            IList subResList;
            if (appDef.GiveToMaster == true && masterResource != null)
            {
                isExists = subResourceDVO.SubResourceList.Exists(o => o.ObjectID.ToString() == masterResource.ObjectID.ToString());
                if (!isExists)
                {
                    //TODO buraya bak
                    masterResource.ResourceColor = CommonServiceController.GetRandomSpecificColor(0);
                    subResourceDVO.SubResourceList.Add(masterResource);
                }
            }
            else
            {
                int i = 0;
                if (!String.IsNullOrEmpty(subResourceInputDVO.relationParentName))
                {
                    //if (masterResource != null)
                    //    subResList = readOnlyContext.QueryObjects(subResourceInputDVO.subResourceType, subResourceInputDVO.relationParentName + " = '" + masterResource.ObjectID.ToString() + "' AND ISACTIVE = 1 ORDER BY NAME DESC");
                    //else
                    subResList = readOnlyContext.QueryObjects(subResourceInputDVO.subResourceType, " ISACTIVE = 1 ORDER BY NAME ASC");
                    foreach (ResSection section in subResList)
                    {
                        isExists = subResourceDVO.SubResourceList.Exists(o => o.ObjectID.ToString() == section.ObjectID.ToString());
                        if (!isExists)
                        {
                            section.ResourceColor = CommonServiceController.GetRandomSpecificColor(i);
                            subResourceDVO.SubResourceList.Add(section);
                            i++;
                        }
                    }
                }
                else
                {
                    if (subResourceInputDVO.subResourceType.ToUpperInvariant() == "RESUSER")
                    {
                        if (masterResource == null)
                        {
                            subResList = readOnlyContext.QueryObjects(subResourceInputDVO.subResourceType, " ISACTIVE = 1 ORDER BY NAME ASC");
                            foreach (ResUser user in subResList)
                            {
                                isUserTypeAllowed = false;
                                foreach (AppointmentCarrierUserTypes appCarrierUserType in appCarrier.AppointmentCarrierUserTypes)
                                {
                                    {
                                        if (appCarrierUserType.UserType == user.UserType)
                                        {
                                            isUserTypeAllowed = true;
                                            break;
                                        }
                                    }
                                }

                                if (isUserTypeAllowed || appCarrier.AppointmentCarrierUserTypes.Count == 0)
                                {
                                    Resource resUser = (Resource)user;
                                    isExists = subResourceDVO.SubResourceList.Exists(o => o.ObjectID.ToString() == resUser.ObjectID.ToString());
                                    if (!isExists)
                                    {
                                        resUser.ResourceColor = CommonServiceController.GetRandomSpecificColor(i);
                                        subResourceDVO.SubResourceList.Add(resUser);
                                        i++;
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (UserResource userResource in masterResource.ResourceUsers)
                            {
                                if (userResource.User != null && userResource.User.IsActive == true)
                                {
                                    isUserTypeAllowed = false;
                                    foreach (AppointmentCarrierUserTypes appCarrierUserType in appCarrier.AppointmentCarrierUserTypes)
                                    {
                                        {
                                            if (appCarrierUserType.UserType == userResource.User.UserType)
                                            {
                                                isUserTypeAllowed = true;
                                                break;
                                            }
                                        }
                                    }

                                    if (isUserTypeAllowed || appCarrier.AppointmentCarrierUserTypes.Count == 0)
                                    {
                                        Resource resUser = (Resource)userResource.User;
                                        isExists = subResourceDVO.SubResourceList.Exists(o => o.ObjectID.ToString() == resUser.ObjectID.ToString());
                                        if (!isExists)
                                        {
                                            resUser.ResourceColor = CommonServiceController.GetRandomSpecificColor(i);
                                            subResourceDVO.SubResourceList.Add(resUser);
                                            i++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (subResourceDVO.SubResourceList.Count > 0)
            {
                subResourceDVO.defaultSubResource = subResourceDVO.SubResourceList[0];
                if (subResourceDVO.defaultSubResource.GetType() == typeof(ResUser))
                {
                    ResUser currentUser = Common.CurrentResource;
                    foreach (ResUser userItem in subResourceDVO.SubResourceList)
                    {
                        if (currentUser.ObjectID == userItem.ObjectID)
                        {
                            subResourceDVO.defaultSubResource = userItem;
                        }
                    }
                }
            }

            readOnlyContext.FullPartialllyLoadedObjects();
            return subResourceDVO;
        }

        private void FillMasterResources(ScheduleFormViewModel viewModel)
        {
            MasterResourceInputDVO masterResourceInputDVO = new MasterResourceInputDVO();
            if (viewModel._Schedule.AppointmentDefinition == null)
                return;
            masterResourceInputDVO.appointmentCarrierObjectID = viewModel.AppointmentCarrier.ObjectID.ToString();
            masterResourceInputDVO.appointmentDefObjectID = viewModel._Schedule.AppointmentDefinition.ObjectID.ToString();
            masterResourceInputDVO.masterResourceFilter = viewModel.AppointmentCarrier.MasterResourceFilter;
            masterResourceInputDVO.masterResourceType = viewModel.AppointmentCarrier.MasterResource;
            masterResourceInputDVO.relationParentName = viewModel.AppointmentCarrier.RelationParentName;
            masterResourceInputDVO.subResourceType = viewModel.AppointmentCarrier.SubResource;
            if (viewModel._Schedule.Resource != null)
                masterResourceInputDVO.defaultSubResourceObjectID = viewModel._Schedule.Resource.ObjectID.ToString();
            masterResourceInputDVO.isKioskAppointment = false;
            MasterResourceDVO masterResourceDVO = FillMasterResourceCombo(masterResourceInputDVO);
            viewModel._Schedule.MasterResource = masterResourceDVO.defaultMasterResource;
            viewModel.MasterResourceList = masterResourceDVO.MasterResourceList;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public MasterResourceDVO FillMasterResourceCombo(MasterResourceInputDVO masterResourceInputDVO)
        {
            MasterResourceDVO masterResourceDVO = new MasterResourceDVO();
            masterResourceDVO.defaultMasterResource = null; // new ResSection();
            masterResourceDVO.MasterResourceList = new List<Resource>();
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            AppointmentDefinition appDef = readOnlyContext.GetObject<AppointmentDefinition>(new Guid(masterResourceInputDVO.appointmentDefObjectID));
            AppointmentCarrier appCarrier = readOnlyContext.GetObject<AppointmentCarrier>(new Guid(masterResourceInputDVO.appointmentCarrierObjectID));
            Resource subResource = readOnlyContext.GetObject<Resource>(new Guid(masterResourceInputDVO.defaultSubResourceObjectID));
            bool addMasterResource = true;
            IBindingList masterResourceList;
            TTObjectDef masterResourceObjectDef = readOnlyContext.ObjectDefManager.ObjectDefs[masterResourceInputDVO.masterResourceType.ToUpperInvariant()];
            if (!String.IsNullOrEmpty(masterResourceInputDVO.masterResourceFilter))
                masterResourceInputDVO.masterResourceFilter += " AND ";

            if (!String.IsNullOrEmpty(masterResourceInputDVO.relationParentName))
            {
                //TTObjectRelationDef relDef = masterResourceObjectDef.ChildRelationDefs.Values.ToArray().FirstOrDefault(x => x.ParentName == masterResourceInputDVO.relationParentName && x.ChildObjectDef.ID.Equals(subResource.ObjectDef.ID));
                //if (relDef == null)
                TTObjectRelationDef relDef = subResource.ObjectDef.AllParentRelationDefs.Values.ToArray().FirstOrDefault(x => x.ParentName == masterResourceInputDVO.relationParentName);
                if (relDef != null)
                    masterResourceInputDVO.masterResourceFilter += relDef.ChildrenName + "(OBJECTID = '" + subResource.ObjectID.ToString() + "').EXISTS AND ISACTIVE = 1";

                masterResourceList = readOnlyContext.QueryObjects(masterResourceObjectDef, masterResourceInputDVO.masterResourceFilter, " NAME ASC");
            }
            else
            {
                masterResourceInputDVO.masterResourceFilter += "ResourceUsers(USER = '" + subResource.ObjectID.ToString() + "').EXISTS AND ISACTIVE = 1";
                masterResourceList = readOnlyContext.QueryObjects(masterResourceObjectDef, masterResourceInputDVO.masterResourceFilter, " NAME ASC");
            }
            int i = 0;
            foreach (ResSection section in masterResourceList)
            {
                if (section.ObjectDef.ID == masterResourceObjectDef.ID)
                {
                    addMasterResource = true;
                    if (CheckScheduleRight(appDef, Common.AppointmentAddRightDefID, section) == false && CheckScheduleRight(appDef, Common.AppointmentPrintRightDefID, section) == false) // Add ve print yetkisi yoksa eklenmemeli.
                        addMasterResource = false;
                    if (addMasterResource == true)
                    {
                        section.ResourceColor = CommonServiceController.GetRandomSpecificColor(i);
                        masterResourceDVO.MasterResourceList.Add(section);
                        i++;
                    }
                }
            }

            if (masterResourceDVO.MasterResourceList.Count > 0)
            {
                foreach (ResSection res in masterResourceDVO.MasterResourceList)
                {
                    foreach (ResSection selectedRes in Common.CurrentResource.SelectedResources)
                    {
                        if (selectedRes.ObjectID == res.ObjectID)
                        {
                            masterResourceDVO.defaultMasterResource = res;
                            break;
                        }
                    }
                }

                if (masterResourceDVO.defaultMasterResource == null)
                    masterResourceDVO.defaultMasterResource = masterResourceDVO.MasterResourceList[0];
            }

            readOnlyContext.FullPartialllyLoadedObjects();
            return masterResourceDVO;
        }

        private void FillScheduleAppointmentTypes(ScheduleFormViewModel viewModel)
        {
            using (TTObjectContext context = new TTObjectContext(true))
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes["AppointmentTypeEnum"];
                if (dataType.IsEnum == false)
                    throw new TTCallAdminException();
                viewModel.AppointmentTypeList = new List<AppointmentTypeListDVO>();
                viewModel.SelectedAppointmentTypeList = new List<AppointmentTypeListDVO>();
                AppointmentCarrier carrier = viewModel.AppointmentCarrier;
                if (carrier == null)
                    return;
                foreach (AppointmentType appType in carrier.AppointmentTypes)
                {
                    AppointmentTypeListDVO appointmentTypeListDVO = new AppointmentTypeListDVO();
                    appointmentTypeListDVO.AppointmentType = appType;
                    appointmentTypeListDVO.AppointmentTypeEnumValue = appType.Type;
                    appointmentTypeListDVO.AppointmentTypeDisplayText = (appType.Type.HasValue ? TTObjectClasses.Common.GetEnumValueDefOfEnumValue(appType.Type).DisplayText : null);
                    appointmentTypeListDVO.id = Convert.ToInt32(appointmentTypeListDVO.AppointmentTypeEnumValue.GetValueOrDefault());
                    appointmentTypeListDVO.text = appointmentTypeListDVO.AppointmentTypeDisplayText;
                    viewModel.AppointmentTypeList.Add(appointmentTypeListDVO);
                    viewModel.SelectedAppointmentTypeList.Add(appointmentTypeListDVO);
                }

                context.FullPartialllyLoadedObjects();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public AppointmentTypeDVO FillScheduleAppointmentTypeList(string appointmentCarrierObjectID)
        {
            AppointmentTypeDVO appointmentTypeDVO = new AppointmentTypeDVO();
            appointmentTypeDVO.AppointmentTypeList = new List<AppointmentTypeListDVO>();
            appointmentTypeDVO.defaultAppType = new AppointmentTypeListDVO();
            using (TTObjectContext context = new TTObjectContext(true))
            {
                AppointmentCarrier appCarrier = context.GetObject<AppointmentCarrier>(new Guid(appointmentCarrierObjectID));
                foreach (AppointmentType appType in appCarrier.AppointmentTypes)
                {
                    AppointmentTypeListDVO appointmentTypeListDVO = new AppointmentTypeListDVO();
                    appointmentTypeListDVO.AppointmentType = appType;
                    appointmentTypeListDVO.AppointmentTypeEnumValue = appType.Type;
                    appointmentTypeListDVO.AppointmentTypeDisplayText = (appType.Type.HasValue ? TTObjectClasses.Common.GetEnumValueDefOfEnumValue(appType.Type).DisplayText : null);
                    appointmentTypeListDVO.id = Convert.ToInt32(appointmentTypeListDVO.AppointmentTypeEnumValue.GetValueOrDefault());
                    appointmentTypeListDVO.text = appointmentTypeListDVO.AppointmentTypeDisplayText;
                    appointmentTypeDVO.AppointmentTypeList.Add(appointmentTypeListDVO);
                }

                context.FullPartialllyLoadedObjects();
            }

            if (appointmentTypeDVO.AppointmentTypeList.Count > 0)
            {
                appointmentTypeDVO.defaultAppType = appointmentTypeDVO.AppointmentTypeList[0];
            }

            return appointmentTypeDVO;
        }

        private void FillAppointmentCarriers(ScheduleFormViewModel viewModel)
        {
            using (TTObjectContext context = new TTObjectContext(true))
            {
                AppointmentDefinition definition = viewModel._Schedule.AppointmentDefinition;
                if (definition == null)
                    return;
                foreach (AppointmentCarrier carrier in definition.AppointmentCarriers)
                {
                    if (carrier.IsDefault == true)
                        viewModel.AppointmentCarrier = carrier;
                    viewModel.AppointmentCarrierList.Add(carrier);
                }

                if (viewModel.AppointmentCarrier == null && viewModel.AppointmentCarrierList.Count > 0)
                    viewModel.AppointmentCarrier = viewModel.AppointmentCarrierList[0];
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public AppointmentCarrierDVO FillAppointmentCarrierCombo(string appointmentDefObjectID)
        {
            AppointmentCarrierDVO appointmentCarrierDVO = new AppointmentCarrierDVO();
            appointmentCarrierDVO.AppointmentCarrierList = new List<AppointmentCarrier>();
            appointmentCarrierDVO.defaultCarrier = new AppointmentCarrier();
            using (TTObjectContext context = new TTObjectContext(true))
            {
                AppointmentDefinition definition = context.GetObject<AppointmentDefinition>(new Guid(appointmentDefObjectID));
                foreach (AppointmentCarrier carrier in definition.AppointmentCarriers)
                {
                    if (carrier.IsDefault == true)
                        appointmentCarrierDVO.defaultCarrier = carrier;
                    appointmentCarrierDVO.AppointmentCarrierList.Add(carrier);
                }

                context.FullPartialllyLoadedObjects();
                return appointmentCarrierDVO;
            }
        }

        private void FillAppointmentDefinitions(ScheduleFormViewModel viewModel)
        {
            bool addDefinition;
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                IList defList = AppointmentDefinition.GetAllAppointmentDefinitions(objectContext);
                foreach (AppointmentDefinition appDef in defList)
                {
                    addDefinition = true;
                    if (CheckScheduleRight(appDef, Common.AppointmentAddRightDefID, null) == false) //Add yetkisi yoksa definition eklenmiyor.
                        addDefinition = false;
                    if (addDefinition == true)
                        viewModel.AppointmentDefinitionList.Add(appDef);
                }

                if (viewModel.AppointmentDefinitionList.Count > 0)
                {
                    UserOption uo = Common.CurrentResource.GetUserOption(UserOptionType.DefaultAppointmentDefinition);
                    if (uo != null)
                    {
                        if (String.IsNullOrEmpty(uo.Value) == false)
                        {
                            TTObject ad = objectContext.GetObject(new Guid(uo.Value.ToString()), "AppointmentDefinition");
                            if (ad != null)
                            {
                                viewModel._Schedule.AppointmentDefinition = (AppointmentDefinition)ad;
                            }
                        }
                    }

                    if (viewModel._Schedule.AppointmentDefinition == null || (viewModel._Schedule.AppointmentDefinition != null && string.IsNullOrEmpty(viewModel._Schedule.AppointmentDefinition.AppDefNameDisplayText.ToString())))
                    {
                        bool isPatientExamination = false;
                        foreach (AppointmentDefinition appDefItem in viewModel.AppointmentDefinitionList)
                        {
                            if (appDefItem != null && appDefItem.AppointmentDefinitionName == AppointmentDefinitionEnum.PatientExamination)
                                isPatientExamination = true;
                        }

                        if (isPatientExamination == true)
                        {
                            IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(objectContext, AppointmentDefinitionEnum.PatientExamination);
                            if (appDefList.Count > 0)
                                viewModel._Schedule.AppointmentDefinition = (AppointmentDefinition)appDefList[0];
                        }
                        else
                        {
                            viewModel._Schedule.AppointmentDefinition = viewModel.AppointmentDefinitionList[0];
                        }
                    }
                }
            }
        }

        GivenSchedules _givenSchedules;
        GivenSchedules givenSchedules
        {
            get
            {
                return _givenSchedules;
            }

            set
            {
                _givenSchedules = value;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public GivenSchedules GetSchedules(ScheduleInputDVO scheduleInputDVO)
        {
            givenSchedules = new GivenSchedules();
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            if (scheduleInputDVO.currentView == "day")
            {
                startDate = scheduleInputDVO.ScheduleDate.Date;
                endDate = startDate.AddDays(1).AddMinutes(-1);
            }
            else if (scheduleInputDVO.currentView == "month")
            {
                startDate = GetFirstDateOfMonth(scheduleInputDVO.ScheduleDate.Date);
                endDate = GetLastDateOfMonth(startDate);
            }
            else
            {
                startDate = GetFirstDateOfWeek(scheduleInputDVO.ScheduleDate.Date);
                endDate = startDate.AddDays(7);
            }

            givenSchedules.givenSchedules = new List<GivenSchedule>();
            givenSchedules.MasterResources = new List<GivenResource>();
            givenSchedules.SubResources = new List<GivenResource>();
            try
            {
                foreach (Guid ownerResource in scheduleInputDVO.SelectedOwnerResources)
                {
                    //foreach (Guid ownerMasterResource in scheduleInputDVO.SelectedMasterOwnerResources)
                    //{
                    using (TTObjectContext context = new TTObjectContext(true))
                    {
                        Resource appResource = context.GetObject<Resource>(ownerResource);
                        //Resource appMasterResource = context.GetObject<Resource>(ownerMasterResource);
                        //bool isExistsMasRes = givenSchedules.MasterResources.Exists(o => o.id.ToString() == appMasterResource.ObjectID.ToString());
                        //if (!isExistsMasRes)
                        //{
                        //    GivenResource givenMasterResource = new GivenResource();
                        //    givenMasterResource.id = appMasterResource.ObjectID;
                        //    givenMasterResource.text = appMasterResource.Name;
                        //    ResourceAndColorDVO appMasterResourceFromList = scheduleInputDVO.AllResourcesAndColors.FirstOrDefault(o => o.resourceObjectID.ToString() == appMasterResource.ObjectID.ToString());
                        //    if (appMasterResourceFromList != null)
                        //        givenMasterResource.color = appMasterResourceFromList.resourceColor;
                        //    givenSchedules.MasterResources.Add(givenMasterResource);
                        //}

                        bool isExistsRes = givenSchedules.SubResources.Exists(o => o.id.ToString() == appResource.ObjectID.ToString());
                        if (!isExistsRes)
                        {
                            GivenResource givenSubResource = new GivenResource();
                            givenSubResource.id = appResource.ObjectID;
                            givenSubResource.text = appResource.Name;
                            ResourceAndColorDVO appResourceFromList = scheduleInputDVO.AllResourcesAndColors.FirstOrDefault(o => o.resourceObjectID.ToString() == appResource.ObjectID.ToString());
                            if (appResourceFromList != null)
                                givenSubResource.color = appResourceFromList.resourceColor;
                            givenSchedules.SubResources.Add(givenSubResource);
                        }

                        IBindingList schedules = Schedule.GetByScheduleDateAndResource(context, Convert.ToDateTime(startDate.Date), Convert.ToDateTime(endDate.Date), ownerResource.ToString());
                        foreach (Schedule oSchedule in schedules)
                        {
                            //if (ownerMasterResource.Equals(oSchedule.MasterResource.ObjectID))
                            //{
                            string subjectStr = String.Empty;
                            if (oSchedule.IsWorkHour == false)
                            {
                                subjectStr = " ÇALIŞILMAYAN SAAT\r\n";
                            }
                            else
                            {
                                if (oSchedule.CountLimit > 0)
                                    subjectStr = "\r\nPlanlama Tipi : Sıralı\r\nSayı : " + oSchedule.CountLimit.ToString() + " adet\r\n";
                                else if (oSchedule.Duration > 0)
                                    subjectStr = "\r\nPlanlama Tipi : Saatli\r\nSüre : " + oSchedule.Duration.ToString() + " dk.\r\n";
                                subjectStr += "Randevu Türleri : ";
                                foreach (ScheduleAppointmentType sat in oSchedule.ScheduleAppointmentTypes)
                                {
                                    subjectStr += Common.GetEnumValueDefOfEnumValue(sat.AppointmentType).DisplayText + ";";
                                }

                                subjectStr += "\r\n";
                            }

                            DateTime startDateTime = (DateTime)oSchedule.StartTime;
                            DateTime endDateTime = (DateTime)oSchedule.EndTime;
                            GivenSchedule givenSch = new GivenSchedule();
                            givenSch.startDate = startDateTime;
                            givenSch.endDate = endDateTime;
                            givenSch.objectID = oSchedule.ObjectID.ToString();
                            givenSch.ownerObjectID = ownerResource;
                            givenSch.ownerObject = oSchedule.Resource;
                            if (oSchedule.MasterResource != null)
                                givenSch.masterOwnerObjectID = oSchedule.MasterResource.ObjectID;
                            givenSch.objectDefID = oSchedule.ObjectDef.ID.ToString();
                            givenSch.objectDefName = oSchedule.ObjectDef.Name;
                            ResourceAndColorDVO appResourceFromList = scheduleInputDVO.AllResourcesAndColors.FirstOrDefault(o => o.resourceObjectID.ToString() == oSchedule.Resource.ObjectID.ToString());
                            if (appResourceFromList != null)
                                givenSch.color = appResourceFromList.resourceColor;
                            givenSch.notes = oSchedule.Notes;
                            if (oSchedule.MasterResource != null && oSchedule.IsWorkHour == true)
                                givenSch.text = oSchedule.MasterResource.Name + "\r\n" + oSchedule.Resource.Name + "\r\nSaat : " + givenSch.startDate.ToShortTimeString() + " - " + givenSch.endDate.ToShortTimeString() + subjectStr + "Not : " + oSchedule.Notes;
                            else
                                givenSch.text = oSchedule.Resource.Name + "\r\nSaat : " + givenSch.startDate.ToShortTimeString() + " - " + givenSch.endDate.ToShortTimeString() + subjectStr + "Not : " + oSchedule.Notes;
                            string mhrs = null;
                            if (oSchedule.MHRSKesinCetvelID != null)
                            {
                                givenSch.text += "\r\n";
                                mhrs = string.Format("--{0}--", "MHRS Taslak Kesinleştirildi.");
                            }
                            else if (oSchedule.MHRSKesinCetvelID == null && oSchedule.MHRSTaslakCetvelID != null && oSchedule.SentToMHRS == true)
                            {
                                givenSch.text += "\r\n";
                                mhrs = string.Format("--{0}--", "MHRS Taslak Kesinleştirilmedi.");
                            }

                            givenSch.text += mhrs;
                            if (oSchedule.MHRSActionTypeDefinition != null && oSchedule.MHRSActionTypeDefinition.ActionName != null && (oSchedule.MHRSKesinCetvelID != null || oSchedule.MHRSTaslakCetvelID != null))
                            {
                                givenSch.text += "\r\n";
                                if (oSchedule.MHRSScheduleType != MHRSScheduleTypeEnum.WaitingApproval)
                                    givenSch.text += string.Format("--{0}--", oSchedule.MHRSActionTypeDefinition.ActionName);
                                else
                                    givenSch.text += string.Format("--{0}--", "MHRS İstisna İptali");
                            }

                            givenSch.MHRSKesinCetvelID = oSchedule.MHRSKesinCetvelID;

                            if (oSchedule.ScheduleType == ScheduleTypeEnum.NonWorkingHour)
                            {
                                givenSch.color = "#e06b6b";
                            }
                            else if (oSchedule.MHRSScheduleType == MHRSScheduleTypeEnum.WaitingApproval)
                            {
                                givenSch.color = "#a5a4a4";
                            }
                            else if (oSchedule.SentToMHRS == true && oSchedule.MHRSKesinCetvelID != null)
                            {
                                givenSch.color = "#B5E196";
                            }
                            givenSchedules.givenSchedules.Add(givenSch);
                            // }

                            context.FullPartialllyLoadedObjects();
                        }
                    }
                    //}
                }

                return givenSchedules;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool isOverlap(TTObjectContext context, Resource resource, DateTime schDate, DateTime schStartTime, DateTime schEndTime)
        {
            string injectionStr = "WHERE RESOURCE = '" + resource.ObjectID + "' AND SCHEDULEDATE = TODATE('" + schDate.ToString("yyyy-MM-dd HH:mm:ss") + "') AND ((STARTTIME >= TODATE('" + schStartTime.ToString("yyyy-MM-dd HH:mm:ss") + "') AND STARTTIME < TODATE('" + schEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')) OR (ENDTIME > TODATE('" + schStartTime.ToString("yyyy-MM-dd HH:mm:ss") + "') AND ENDTIME <= TODATE('" + schEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')) OR (STARTTIME <= TODATE('" + schStartTime.ToString("yyyy-MM-dd HH:mm:ss") + "') AND ENDTIME >= TODATE('" + schEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')))";
            IList schList = Schedule.GetByInjection(context, injectionStr);
            return (schList.Count > 0);
        }

        private bool isOverlapAppointment(TTObjectContext context, Resource resource, DateTime schDate, DateTime schStartTime, DateTime schEndTime)
        {
            string injectionStr = "WHERE CURRENTSTATE IS NOT STATES.CANCELLED AND RESOURCE = '" + resource.ObjectID + "' AND APPDATE = TODATE('" + schDate.ToString("yyyy-MM-dd HH:mm:ss") + "') AND ((STARTTIME >= TODATE('" + schStartTime.ToString("yyyy-MM-dd HH:mm:ss") + "') AND STARTTIME < TODATE('" + schEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')) OR (ENDTIME > TODATE('" + schStartTime.ToString("yyyy-MM-dd HH:mm:ss") + "') AND ENDTIME <= TODATE('" + schEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')) OR (STARTTIME <= TODATE('" + schStartTime.ToString("yyyy-MM-dd HH:mm:ss") + "') AND ENDTIME >= TODATE('" + schEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')))";
            IList appList = Appointment.GetByInjection(context, injectionStr);
            return (appList.Count > 0);
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public void SaveSchedule(ScheduleToSaveDVO scheduleToSaveDVO)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            try
            {
                Schedule scheduleToSave = objectContext.AddObject(scheduleToSaveDVO.scheduleToSave) as Schedule;
                scheduleToSaveDVO.scheduleToSave = scheduleToSave;
                TimeSpan selectedTimeInterval = scheduleToSave.EndTime.Value.Subtract(scheduleToSave.StartTime.Value);
                TimeSpan appointmentDuration = TimeSpan.Zero;
                DateTime newOccurrenceStartTime = scheduleToSave.StartTime.Value;
                DateTime newOccurrenceEndTime = scheduleToSave.EndTime.Value;
                Schedule newSchedule = (Schedule)scheduleToSave.Clone();
                DateTime schDate = newSchedule.ScheduleDate.Value;
                newSchedule.ScheduleDate = new DateTime(schDate.Year, schDate.Month, schDate.Day, 0, 0, 0);
                newSchedule.IsWorkHour = (scheduleToSave.ScheduleType.Value != ScheduleTypeEnum.NonWorkingHour);
                TTObjectContext readOnlyObjectContext = new TTObjectContext(true);
                if (isOverlap(readOnlyObjectContext, newSchedule.Resource, newSchedule.ScheduleDate.Value, newOccurrenceStartTime, newOccurrenceEndTime) == true)
                {
                    if (newSchedule.AppointmentDefinition.ScheduleOverlapAllowed != true)
                        throw new Exception(SystemMessage.GetMessageV2(335, TTUtils.CultureService.GetText("M25714", "Girdiğiniz çalışma saati, var olanlarla çakışıyor.")));
                }

                if (isOverlapAppointment(readOnlyObjectContext, newSchedule.Resource, newSchedule.ScheduleDate.Value, newOccurrenceStartTime, newOccurrenceEndTime) == true && scheduleToSave.ScheduleType.Value == ScheduleTypeEnum.NonWorkingHour)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25713", "Girdiğiniz çalışılmayan saat aralığına randevu verilmiş."));
                }

                newSchedule.StartTime = newOccurrenceStartTime;
                newSchedule.EndTime = newOccurrenceEndTime;
                ((IEditableObject)scheduleToSave).CancelEdit();
                if (newSchedule.IsWorkHour.Value)
                {
                    foreach (AppointmentTypeListDVO appType in scheduleToSaveDVO.SelectedAppointmentTypeList)
                    {
                        ScheduleAppointmentType scheduleAppointmentType = new ScheduleAppointmentType(objectContext);
                        scheduleAppointmentType.AppointmentType = (AppointmentTypeEnum)appType.AppointmentTypeEnumValue.Value;
                        scheduleAppointmentType.Schedule = newSchedule;
                    }
                }

                foreach (ScheduleJobRule _scheduleJobRule in scheduleToSaveDVO.ScheduleJobRules)
                {
                    ScheduleJobRule scheduleJobRule = new ScheduleJobRule(objectContext);
                    scheduleJobRule.RuleType = _scheduleJobRule.RuleType;
                    scheduleJobRule.RuleValue = _scheduleJobRule.RuleValue;
                    scheduleJobRule.TimeCriteria = _scheduleJobRule.TimeCriteria;
                    scheduleJobRule.Schedule = newSchedule;
                }

                newOccurrenceStartTime = newOccurrenceEndTime;
                objectContext.Save();

                if (((Schedule)newSchedule).SentToMHRS.Value)
                {
                    string MHRSAciklama = null;
                    MHRSAciklama += newSchedule.StartTime.ToString();
                    MHRSAciklama += " - ";
                    MHRSAciklama += newSchedule.EndTime.ToString();
                    MHRSAciklama += " Randuvu planı MHRS'ye başarıyla bildirildi." + "\n\r";
                    TTUtils.InfoMessageService.Instance.ShowMessage(MHRSAciklama);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private int Weekday(DateTime dateTime)
        {
            return dateTime.DayOfWeek.GetHashCode() + 1;
        }

        private DayOfWeek WeekdayEnum(DateTime dateTime)
        {
            return dateTime.DayOfWeek;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public void CopyRecurrence(ScheduleToCopyDVO scheduleToCopyDVO)
        {
            DateTime schDate = scheduleToCopyDVO.ScheduleDate;
            scheduleToCopyDVO.ScheduleDate = new DateTime(schDate.Year, schDate.Month, schDate.Day, 0, 0, 0);
            DateTime sDate = scheduleToCopyDVO.ScheduleDate.AddDays(-1 * Weekday(scheduleToCopyDVO.ScheduleDate) + 2);
            DateTime eDate = sDate.AddDays(6);
            bool anySchedule = false;
            bool includeWeekend = scheduleToCopyDVO.includeWeekend;
            bool weeklyPlan = scheduleToCopyDVO.weeklyPlan;
            int interval = 0;
            Dictionary<string, IList<Schedule>> schedules = new Dictionary<string, IList<Schedule>>();
            IList<Schedule> schList;
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                interval = (eDate.Date - sDate.Date).Days;
                for (int j = 0; j <= interval; j++)
                {
                    schList = Schedule.GetByScheduleDateAndResource(objectContext, sDate.AddDays(j), sDate.AddDays(j), scheduleToCopyDVO.currentSubResourceObjectID.ToString());
                    anySchedule = anySchedule || (schList.Count > 0);
                    schedules.Add("K-" + Weekday(sDate.AddDays(j)).ToString(), schList);
                }

                if (anySchedule == false)
                {
                    throw new TTException(SystemMessage.GetMessageV2(338, TTUtils.CultureService.GetText("M26826", "Seçilen tarihin bulunduğu haftada, hiç planlama bulunamadı.")));
                }
                else
                {
                    if (weeklyPlan == false)
                    {
                        if (schedules["K-" + Weekday(scheduleToCopyDVO.ScheduleDate).ToString()].Count <= 0)
                        {
                            throw new Exception(SystemMessage.GetMessageV2(339, TTUtils.CultureService.GetText("M26827", "Seçilen tarihte hiç planlama bulunamadı.")));
                        }
                    }
                }

                DateTime startDate = new DateTime(scheduleToCopyDVO.RecurrenceStartDate.Year, scheduleToCopyDVO.RecurrenceStartDate.Month, scheduleToCopyDVO.RecurrenceStartDate.Day, 0, 0, 0);
                DateTime endDate = new DateTime(scheduleToCopyDVO.RecurrenceEndDate.Year, scheduleToCopyDVO.RecurrenceEndDate.Month, scheduleToCopyDVO.RecurrenceEndDate.Day, 0, 0, 0);
                DateTime tempDate;
                interval = (endDate.Date - startDate.Date).Days;
                string MHRSAciklama = null;
                for (int i = 0; i <= interval; i++)
                {
                    tempDate = startDate.AddDays(i);
                    if (weeklyPlan == true)
                        schList = schedules["K-" + Weekday(tempDate).ToString()];
                    else
                        schList = schedules["K-" + Weekday(scheduleToCopyDVO.ScheduleDate).ToString()];
                    if (schList.Count > 0)
                    {
                        //IList sList = Schedule.GetByScheduleDateAndResource(objectContext, tempDate, tempDate, scheduleToCopyDVO.currentSubResourceObjectID.ToString());
                        //if (sList.Count <= 0)
                        //{

                        foreach (Schedule sch in schList)
                        {
                            DateTime tempStartTime = tempDate.AddHours(sch.StartTime.Value.Hour).AddMinutes(sch.StartTime.Value.Minute).AddSeconds(sch.StartTime.Value.Second);
                            DateTime tempEndTime = tempDate.AddHours(sch.EndTime.Value.Hour).AddMinutes(sch.EndTime.Value.Minute).AddSeconds(sch.EndTime.Value.Second);
                            if (isOverlap(objectContext, sch.Resource, tempDate, tempStartTime, tempEndTime) == true)
                                continue;
                            if (includeWeekend || (!includeWeekend && WeekdayEnum(tempDate) != DayOfWeek.Sunday && WeekdayEnum(tempDate) != DayOfWeek.Saturday))
                            {
                                Schedule newSchedule = (Schedule)sch.Clone();
                                newSchedule.ScheduleDate = tempDate;
                                int dayDiff = (newSchedule.ScheduleDate.Value.Date - sch.ScheduleDate.Value.Date).Days;
                                newSchedule.StartTime = sch.StartTime.Value.AddDays(dayDiff);
                                newSchedule.EndTime = sch.EndTime.Value.AddDays(dayDiff);
                                foreach (ScheduleAppointmentType sat in sch.ScheduleAppointmentTypes)
                                {
                                    ScheduleAppointmentType scheduleAppointmentType = (ScheduleAppointmentType)sat.Clone();
                                    scheduleAppointmentType.Schedule = newSchedule;
                                }

                                newSchedule.MasterSchedule = (Schedule)sch;
                                newSchedule.MHRSKesinCetvelID = null;
                                newSchedule.MHRSTaslakCetvelID = null;
                                if (!((Schedule)sch).SentToMHRS.Value)
                                {
                                    newSchedule.SentToMHRS = false;
                                    newSchedule.MHRSActionTypeDefinition = null;
                                }
                                else
                                {
                                    newSchedule.SentToMHRS = true;
                                    newSchedule.MHRSActionTypeDefinition = ((Schedule)sch).MHRSActionTypeDefinition;
                                }

                                newSchedule.ObjectContext.Save();
                                if (((Schedule)sch).SentToMHRS.Value)
                                {
                                    MHRSAciklama += newSchedule.StartTime.ToString();
                                    MHRSAciklama += " - ";
                                    MHRSAciklama += newSchedule.EndTime.ToString();
                                    MHRSAciklama += " Randuvu planı MHRS'ye başarıyla bildirildi." + "\n\r";
                                }
                            }

                        }

                        //}
                    }
                }
                if (MHRSAciklama != null)
                    TTUtils.InfoMessageService.Instance.ShowMessage(MHRSAciklama);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public string DeleteRecurrence(ScheduleRecurrenceToDeleteDVO scheduleRecurrenceToDeleteDVO)
        {
            ArrayList deletedObjects = new ArrayList();
            TTObjectContext deleteContext = new TTObjectContext(false);
            TTObjectContext deleteContextReadOnly = new TTObjectContext(true);
            bool deleteSch = true;
            string informationMessage = String.Empty;

            bool NewMHRSActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE"));

            try
            {
                DateTime startDate = new DateTime(scheduleRecurrenceToDeleteDVO.RecurrenceStartDate.Year, scheduleRecurrenceToDeleteDVO.RecurrenceStartDate.Month, scheduleRecurrenceToDeleteDVO.RecurrenceStartDate.Day, 0, 0, 0);
                DateTime endDate = new DateTime(scheduleRecurrenceToDeleteDVO.RecurrenceEndDate.Year, scheduleRecurrenceToDeleteDVO.RecurrenceEndDate.Month, scheduleRecurrenceToDeleteDVO.RecurrenceEndDate.Day, 0, 0, 0);
                IBindingList schedules = Schedule.GetByScheduleDateAndResource(deleteContextReadOnly, startDate, endDate, scheduleRecurrenceToDeleteDVO.currentSubResourceObjectID.ToString());
                foreach (Schedule sch in schedules)
                {
                    deleteSch = true;
                    BindingList<Appointment.GetAppointmentBySchedule_Class> appointmentsWithSch = Appointment.GetAppointmentBySchedule(deleteContext, sch.ObjectID);
                    if (appointmentsWithSch.Count > 0)
                    {
                        foreach (Appointment.GetAppointmentBySchedule_Class appSch_Class in appointmentsWithSch)
                        {
                            Appointment app = (Appointment)deleteContext.GetObject(appSch_Class.ObjectID.Value, typeof(Appointment));
                            if (app.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                            {
                                deleteSch = false;
                                if (informationMessage.Length > 0)
                                    informationMessage += " , ";
                                informationMessage += "'" + app.ObjectID.ToString() + "'";
                            }
                        }
                    }

                    if (deleteSch)
                    {
                        Schedule delSch = (Schedule)deleteContext.GetObject(sch.ObjectID, sch.ObjectDef);
                        if (delSch.MHRSKesinCetvelID != null && NewMHRSActive)
                            throw new Exception("Silmek istediğiniz planlar arasında kesinleşmiş planlar bulunduğu için toplu sil işlemi yapamazsınız");

                        if (!scheduleRecurrenceToDeleteDVO.SentToMHRS && (delSch.MHRSKesinCetvelID != null || delSch.MHRSTaslakCetvelID != null))
                            throw new TTException(TTUtils.CultureService.GetText("M26887", "Silinmek istenen planlama MHRS'de kayıtlı, MHRS'ye bildir işaretlenmeli !"));
                        ITTObject o = (ITTObject)delSch;
                        deletedObjects.Add(o);
                    }
                }

                foreach (ITTObject o in deletedObjects)
                {
                    o.Delete();
                }

                deleteContext.Save();
                if (informationMessage.Length > 0)
                    return ("Silinmek istenen bazı planlamalar, iptal edilmiş randevular tarafından kullanılıyor. Planlamalar silinemedi. AppObjectIDs : " + informationMessage);
                else
                    return (TTUtils.CultureService.GetText("M27115", "Toplu planlama İptal işlemi başarılı tamamlandı"));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                deleteContext.Dispose();
                deleteContextReadOnly.Dispose();
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public bool DeleteSelectedSchedules(CalismaPlaniGuncelleDVO calismaPlaniGuncelle)
        {
            GivenSchedule givenSchedule = calismaPlaniGuncelle.givenSchedule;
            ScheduleToSaveDVO scheduleToSaveDVO = calismaPlaniGuncelle.scheduleToSaveDVO;

            bool NewMHRSActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE"));

            bool isRemovable = true;
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                //TODO Burada birden fazla seçilmiş schedule içinde dönebilmeli
                //foreach (Infragistics.Win.UltraWinSchedule.Appointment app in ultraCalendarInfo.Appointments.All)
                //{
                Schedule schForDelete = objectContext.GetObject<Schedule>(new Guid(givenSchedule.objectID));
                BindingList<Appointment.GetAppointmentBySchedule_Class> appointmentsWithSch = Appointment.GetAppointmentBySchedule(objectContext, schForDelete.ObjectID);
                if (appointmentsWithSch.Count > 0)
                {
                    foreach (Appointment.GetAppointmentBySchedule_Class appSch_Class in appointmentsWithSch)
                    {
                        Appointment appSch = (Appointment)objectContext.GetObject(appSch_Class.ObjectID.Value, typeof(Appointment));
                        if (appSch.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                        {
                            throw new TTException(TTUtils.CultureService.GetText("M26888", "Silinmek istenen planlama, iptal edilmiş bir randevu tarafından kullanılıyor. Planlamayı silemezsiniz. AppObjectID : '") + appSch.ObjectID.ToString() + "'");
                        }
                    }
                }

                //TODO SentToMHRS nin başlangıç değerini set ettim mi acaba?
                bool sentToMHRS = false;
                if (schForDelete.SentToMHRS.HasValue)
                    sentToMHRS = schForDelete.SentToMHRS.Value;
                if (!sentToMHRS && (schForDelete.MHRSKesinCetvelID != null || schForDelete.MHRSTaslakCetvelID != null))
                    throw new TTException(TTUtils.CultureService.GetText("M26887", "Silinmek istenen planlama MHRS'de kayıtlı, MHRS'ye bildir işaretlenmeli !"));
                if (sentToMHRS && schForDelete.MHRSKesinCetvelID != null && schForDelete.MHRSScheduleType != MHRSScheduleTypeEnum.WaitingApproval)
                {
                    int istisnasuresi = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MHRSISTISNASURESI", "0"));
                    if (Convert.ToDateTime(schForDelete.StartTime).AddHours(-istisnasuresi) <= DateTime.Now)
                    {
                        if (schForDelete.MHRSActionTypeDefinition != null && schForDelete.MHRSActionTypeDefinition.OpenMHRS == true)
                        {
                            //TODO Necmiye
                            //InfoBox.Show("Silinmek istenen planlamaya " + istisnasuresi + " saatten az kaldığı için plan silinemez! İstisna bildirmek için bilgilerinizi giriniz");
                            if (appointmentsWithSch.Count > 0)
                                isRemovable = false;
                            //MHRSExceptionalForm mHRSExceptionalForm = MHRSExceptionalForm.MHRSExceptionalFormInstance;
                            //DialogResult result = mHRSExceptionalForm.ShowDialog(this, delSch, objectContext);
                        }
                    }
                }

                if (schForDelete.MHRSScheduleType == MHRSScheduleTypeEnum.WaitingApproval)
                {
                    if (appointmentsWithSch.Count > 0)
                        isRemovable = false;
                }
                if (isRemovable)
                {
                    if (NewMHRSActive && sentToMHRS && schForDelete.MHRSKesinCetvelID != null)//yeni mhrs ise kesinleşmiş cetveli silme update et
                    {
                        MHRSCalismaPlaniGuncelle(calismaPlaniGuncelle, schForDelete, objectContext);
                    }
                    else
                    {
                        ((ITTObject)schForDelete).Delete();
                    }
                }
                objectContext.Save();
                objectContext.Dispose();
                return isRemovable;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void MHRSCalismaPlaniGuncelle(CalismaPlaniGuncelleDVO calismaPlaniGuncelle, Schedule schForDelete, TTObjectContext objectContext)
        {
            PlanGuncelleRoot_Input planGuncelleRoot = new PlanGuncelleRoot_Input();

            planGuncelleRoot.eklenecekCetvelTalepList = new List<EklenecekCetvelTalep>();
            int? muayeneYeriId = null;

            //TTObjectContext objectContext = new TTObjectContext(false);
            using (var objContext = new TTObjectContext(false))
            {
                Schedule scheduleToSave = objContext.AddObject(calismaPlaniGuncelle.scheduleToSaveDVO.scheduleToSave) as Schedule;
                calismaPlaniGuncelle.scheduleToSaveDVO.scheduleToSave = scheduleToSave;

                //schForDelete.MHRSActionTypeDefinition = scheduleToSave.MHRSActionTypeDefinition;
                schForDelete.ScheduleDate = new DateTime(scheduleToSave.ScheduleDate.Value.Year, scheduleToSave.ScheduleDate.Value.Month, scheduleToSave.ScheduleDate.Value.Day, 0, 0, 0);
                //schForDelete.IsWorkHour = (scheduleToSave.ScheduleType.Value != ScheduleTypeEnum.NonWorkingHour);

                if (isOverlap(objContext, scheduleToSave.Resource, scheduleToSave.ScheduleDate.Value, scheduleToSave.StartTime.Value, scheduleToSave.EndTime.Value) == true)
                {
                    if (scheduleToSave.AppointmentDefinition.ScheduleOverlapAllowed != true)
                        throw new Exception(SystemMessage.GetMessageV2(335, TTUtils.CultureService.GetText("M25714", "Girdiğiniz çalışma saati, var olanlarla çakışıyor.")));
                }

                if (isOverlapAppointment(objContext, scheduleToSave.Resource, scheduleToSave.ScheduleDate.Value, scheduleToSave.StartTime.Value, scheduleToSave.EndTime.Value) == true && scheduleToSave.ScheduleType.Value == ScheduleTypeEnum.NonWorkingHour)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25713", "Girdiğiniz çalışılmayan saat aralığına randevu verilmiş."));
                }

                schForDelete.IsWorkHour = scheduleToSave.IsWorkHour;
                schForDelete.StartTime = scheduleToSave.StartTime;
                schForDelete.EndTime = scheduleToSave.EndTime;
                schForDelete.MHRSActionTypeDefinition = scheduleToSave.MHRSActionTypeDefinition;
                schForDelete.ErrorOfMHRSApprove = null;
                schForDelete.Duration = scheduleToSave.Duration;
                schForDelete.ScheduleType = scheduleToSave.ScheduleType;

                objectContext.Update();

                string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

                EklenecekCetvelTalep eklenecekCetvelTalep = new EklenecekCetvelTalep();
                eklenecekCetvelTalep.eklenecekCetvelAksiyonId = Convert.ToInt32(schForDelete.MHRSActionTypeDefinition.ActionCode);
                eklenecekCetvelTalep.eklenecekCetvelBaslangicZamani = scheduleToSave.StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                eklenecekCetvelTalep.eklenecekCetvelBitisZamani = scheduleToSave.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                eklenecekCetvelTalep.eklenecekCetvelKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                eklenecekCetvelTalep.eklenecekCetvelRandevusuresi = scheduleToSave.Duration != null ? Convert.ToInt32(scheduleToSave.Duration) : 0;

                if (scheduleToSave.MHRSActionTypeDefinition != null && scheduleToSave.MHRSActionTypeDefinition.OpenMHRS == false)
                {
                    if (scheduleToSave.MasterResource is ResPoliclinic)
                    {
                        //mHRS_TASLAK.klinikKodu = ((ResPoliclinic)MasterResource).MHRSCode != null ? Convert.ToInt32(((ResPoliclinic)MasterResource).MHRSCode) : 0;
                        if (scheduleToSave.CetvelTipiValue == CetvelTipiEnum.Bolum)
                            muayeneYeriId = eklenecekCetvelTalep.eklenecekCetvelMuayeneYeriId.HasValue ? eklenecekCetvelTalep.eklenecekCetvelMuayeneYeriId : -1;
                        else
                            eklenecekCetvelTalep.eklenecekCetvelMuayeneYeriId = null;

                    }

                    eklenecekCetvelTalep.eklenecekCetvelSlotHastaSayisi = 0;
                    eklenecekCetvelTalep.enKucukYas = null;
                    eklenecekCetvelTalep.enBuyukYas = null;

                }
                else
                {
                    eklenecekCetvelTalep.enBuyukYasTipi = "Y";
                    eklenecekCetvelTalep.enKucukYasTipi = "Y";
                    eklenecekCetvelTalep.enKucukYas = 1;
                    eklenecekCetvelTalep.enBuyukYas = 120;
                    eklenecekCetvelTalep.eklenecekCetvelSlotHastaSayisi = 1;

                    if (scheduleToSave.MasterResource is ResPoliclinic)
                    {
                        //mHRS_TASLAK.klinikKodu = ((ResPoliclinic)MasterResource).MHRSCode != null ? Convert.ToInt32(((ResPoliclinic)MasterResource).MHRSCode) : 0;
                        //hekimKlinikBilgileri.KlinikAdi = ((ResPoliclinic)MasterResource).Name;
                        eklenecekCetvelTalep.eklenecekCetvelMuayeneYeriId = ((ResPoliclinic)scheduleToSave.MasterResource).MHRSAltKlinikKodu != null ? Convert.ToInt32(((ResPoliclinic)scheduleToSave.MasterResource).MHRSAltKlinikKodu) : 0;
                        muayeneYeriId = eklenecekCetvelTalep.eklenecekCetvelMuayeneYeriId.HasValue ? eklenecekCetvelTalep.eklenecekCetvelMuayeneYeriId : -1;
                    }


                }

                planGuncelleRoot.eklenecekCetvelTalepList.Add(eklenecekCetvelTalep);
                planGuncelleRoot.semtDahilMi = true;

                planGuncelleRoot.silinecekCetvelIdList = new List<Int64>();
                planGuncelleRoot.silinecekCetvelIdList.Add(schForDelete.MHRSKesinCetvelID.Value);

                DateTime startDate = GetFirstDateOfWeek(scheduleToSave.ScheduleDate.Value);
                DateTime endDate = startDate.AddDays(6);

                planGuncelleRoot.sorgulananBaslangicZamani = startDate.ToString("yyyy-MM-dd HH:mm:ss");
                planGuncelleRoot.sorgulananBitisZamani = endDate.ToString("yyyy-MM-dd HH:mm:ss");
                if (scheduleToSave.CetvelTipiValue == CetvelTipiEnum.Bolum)
                {
                    planGuncelleRoot.sorgulananCetvelTipi = 2;
                    planGuncelleRoot.sorgulananHekimTCKimlikNo = null;
                }
                else
                {
                    planGuncelleRoot.sorgulananCetvelTipi = 1;
                    planGuncelleRoot.sorgulananHekimTCKimlikNo = Convert.ToInt64(((ResUser)scheduleToSave.Resource).UniqueNo);
                }
                
                planGuncelleRoot.sorgulananKlinikKodu = ((ResPoliclinic)scheduleToSave.MasterResource).MHRSCode != null ? Convert.ToInt32(((ResPoliclinic)scheduleToSave.MasterResource).MHRSCode) : 0;
                planGuncelleRoot.sorgulananMuayeneYeriId = muayeneYeriId;
                planGuncelleRoot.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);
                planGuncelleRoot.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);


                string serializedObj = JsonConvert.SerializeObject(planGuncelleRoot, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });


                string accessToken = scheduleToSave.LoginForMHRS();

                Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/cetvel/calisma-plani-guncelle");

                var client = new RestClient(uri);

                RestRequest request = new RestRequest();
                request.Method = Method.POST;
                request.Parameters.Clear();

                string bearerToken = "Bearer " + accessToken;
                request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                request.AddHeader("Accept", "application/json");
                request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);


                //IRestResponse response = client.Execute(request);
                IRestResponse response = scheduleToSave.PostCallForMHRS(client, request);

                if (response != null && response.ResponseStatus == ResponseStatus.Completed && response.IsSuccessful == false)
                {
                    var errorMessage = response.Content;
                    var errorObject = JsonConvert.DeserializeObject(response.Content) as JObject;
                    string detailedError = "";

                    if (errorObject != null)
                    {
                        var error = errorObject.Value<JArray>("errors");

                        foreach (Newtonsoft.Json.Linq.JObject item in error)
                        {
                            detailedError += item.ToString();
                        }
                        //var detailedError = errorObject.Value<string>("message");
                        //errorMessage = error.ToString();
                    }
                    throw new TTException(detailedError);
                }

                if (response.IsSuccessful)
                {
                    var perfResult = JsonConvert.DeserializeObject<PlanGuncelleRoot_Output>(response.Content);

                    EklenecekCetvelTalep eklenecekCetvelTalep_temp = planGuncelleRoot.eklenecekCetvelTalepList[0];
                    List<Datum> changedSchedule = perfResult.data.Where(x => x.aksiyonId == eklenecekCetvelTalep_temp.eklenecekCetvelAksiyonId && (x.baslangicZamani == eklenecekCetvelTalep_temp.eklenecekCetvelBaslangicZamani)
                                     && x.bitisZamani == eklenecekCetvelTalep_temp.eklenecekCetvelBitisZamani).ToList();

                    if (changedSchedule != null && changedSchedule.Count > 0)
                    {
                        schForDelete.MHRSKesinCetvelID = changedSchedule[0].cetvelId;

                    }
                    //schForDelete.MHRSKesinCetvelID = perfResult.Count > 0 ? perfResult[0] : 0;

                    //objectContext.Save();
                }


            }




        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public void IsRemovableSchedule(GivenSchedule givenSchedule)
        {
            bool isRemovable = true;
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                //TODO Burada birden fazla seçilmiş schedule içinde dönebilmeli
                //foreach (Infragistics.Win.UltraWinSchedule.Appointment app in ultraCalendarInfo.Appointments.All)
                //{
                Schedule schForDelete = objectContext.GetObject<Schedule>(new Guid(givenSchedule.objectID));
                BindingList<Appointment.GetAppointmentBySchedule_Class> appointmentsWithSch = Appointment.GetAppointmentBySchedule(objectContext, schForDelete.ObjectID);
                if (appointmentsWithSch.Count > 0)
                {
                    foreach (Appointment.GetAppointmentBySchedule_Class appSch_Class in appointmentsWithSch)
                    {
                        Appointment appSch = (Appointment)objectContext.GetObject(appSch_Class.ObjectID.Value, typeof(Appointment));
                        if (appSch.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                        {
                            throw new TTException(TTUtils.CultureService.GetText("M26888", "Silinmek istenen planlama, iptal edilmiş bir randevu tarafından kullanılıyor. Planlamayı silemezsiniz. AppObjectID : '") + appSch.ObjectID.ToString() + "'");
                        }
                    }
                }

                //TODO SentToMHRS nin başlangıç değerini set ettim mi acaba?
                bool sentToMHRS = false;
                if (schForDelete.SentToMHRS.HasValue)
                    sentToMHRS = schForDelete.SentToMHRS.Value;
                if (!sentToMHRS && (schForDelete.MHRSKesinCetvelID != null || schForDelete.MHRSTaslakCetvelID != null))
                    throw new TTException(TTUtils.CultureService.GetText("M26887", "Silinmek istenen planlama MHRS'de kayıtlı, MHRS'ye bildir işaretlenmeli !"));
                if (!sentToMHRS && schForDelete.MHRSKesinCetvelID != null && schForDelete.MHRSScheduleType != MHRSScheduleTypeEnum.WaitingApproval)
                {
                    int istisnasuresi = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MHRSISTISNASURESI", "0"));
                    if (Convert.ToDateTime(schForDelete.StartTime).AddHours(-istisnasuresi) <= DateTime.Now)
                    {
                        if (schForDelete.MHRSActionTypeDefinition != null && schForDelete.MHRSActionTypeDefinition.OpenMHRS == true)
                        {
                            //TODO Necmiye
                            //InfoBox.Show("Silinmek istenen planlamaya " + istisnasuresi + " saatten az kaldığı için plan silinemez! İstisna bildirmek için bilgilerinizi giriniz");
                            isRemovable = false;
                            //MHRSExceptionalForm mHRSExceptionalForm = MHRSExceptionalForm.MHRSExceptionalFormInstance;
                            //DialogResult result = mHRSExceptionalForm.ShowDialog(this, delSch, objectContext);
                        }
                    }
                }

                if (schForDelete.MHRSScheduleType == MHRSScheduleTypeEnum.WaitingApproval)
                    isRemovable = false;
                if (isRemovable)
                    ((ITTObject)schForDelete).Delete();
                objectContext.Save();
                objectContext.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Planlama)]
        public bool ConfirmScheduleFromMHRS(ScheduleToConfirmDVO scheduleToConfirmDVO)
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("NEWMHRSPARAMETER", "FALSE").ToUpper() == "FALSE")
            {
                //int firstSepartor = currentDate.IndexOf('/');
                //int secondSepartor = currentDate.LastIndexOf('/');
                //int daySeperator = secondSepartor - firstSepartor;
                //string dd = currentDate.Substring(firstSepartor + 1, daySeperator - 1) + "." + currentDate.Substring(0, firstSepartor) + "." + currentDate.Substring(secondSepartor + 1, 4);

                DateTime date = Convert.ToDateTime(scheduleToConfirmDVO.ScheduleDate);

                var currentCulture = CultureInfo.CurrentCulture;
                int currentWeekNo = currentCulture.Calendar.GetWeekOfYear(DateTime.Now, currentCulture.DateTimeFormat.CalendarWeekRule, currentCulture.DateTimeFormat.FirstDayOfWeek);
                int scheduleWeekNo = currentCulture.Calendar.GetWeekOfYear(date, currentCulture.DateTimeFormat.CalendarWeekRule, currentCulture.DateTimeFormat.FirstDayOfWeek);

                //DateTime startDate = currentWeekNo == scheduleWeekNo ? DateTime.Now.AddDays(1) : GetFirstDateOfWeek(date);
                DateTime startDate = GetFirstDateOfWeek(date);
                DateTime endDate = startDate.AddDays(6);
                Guid masterResource = new Guid(scheduleToConfirmDVO.MasterResourceID);
                Guid resource = new Guid(scheduleToConfirmDVO.ResourceID);
                try
                {
                    using (TTObjectContext objectContext = new TTObjectContext(false))
                    {
                        ResPoliclinic mResource = (ResPoliclinic)objectContext.GetObject(masterResource, typeof(ResPoliclinic));
                        // Resource doctor = (Resource)objectContext.GetObject(resource, typeof(Resource));
                        BindingList<Schedule> MHRSList = Schedule.GetScheduleByResourceAndDateForMHRSTask(objectContext, endDate.Date, startDate.Date, resource.ToString());
                        if (MHRSList == null || MHRSList.Count == 0)
                            throw new TTException("Kesinleştirmek istediğiniz haftada MHRS planı bulunamadı !");
                        Schedule schedule = MHRSList[0];

                        MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                        MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                        MHRSServis.HekimBilgileriType hekimBilgileri = new MHRSServis.HekimBilgileriType();
                        MHRSServis.KurumTaslakCetvelKesinlestirmeTalepType kurumTaslakCetvelKesinlestirme = new MHRSServis.KurumTaslakCetvelKesinlestirmeTalepType();
                        MHRSServis.TarihBilgileriType kesinlestirmeTarihBilgileri = new MHRSServis.TarihBilgileriType();
                        MHRSServis.KurumTaslakCetvelKesinlestirmeCevapType kurumTaslakCetvelKesinlestirmeCevap = new MHRSServis.KurumTaslakCetvelKesinlestirmeCevapType();

                        yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX"));
                        yetkilendirmeGirisBilgileri.KullaniciSifre = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
                        yetkilendirmeGirisBilgileri.KulaniciTuru = 2; // bu değişecek manuel verildi

                        if (schedule.Resource != null && schedule.Resource is ResUser)
                        {
                            hekimBilgileri.Ad = schedule.Resource.Name;
                            hekimBilgileri.Soyad = ((ResUser)schedule.Resource).Person.Surname;
                            hekimBilgileri.HekimKodu = ((ResUser)schedule.Resource).UniqueNo;

                            kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(((ResUser)schedule.Resource).UniqueNo);
                        }

                        kurumBilgileri.KurumKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX"));
                        kurumBilgileri.KurumKoduSpecified = true;
                        kurumBilgileri.GonderenBirim = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");

                        kurumTaslakCetvelKesinlestirme.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                        kurumTaslakCetvelKesinlestirme.HekimBilgileri = hekimBilgileri;
                        kurumTaslakCetvelKesinlestirme.KurumBilgileri = kurumBilgileri;

                        if (startDate <= Common.RecTime())
                            kesinlestirmeTarihBilgileri.BaslangicTarihi = Common.RecTime().AddDays(1).ToShortDateString();
                        else
                            kesinlestirmeTarihBilgileri.BaslangicTarihi = startDate.ToShortDateString();
                        kesinlestirmeTarihBilgileri.BitisTarihi = endDate.ToShortDateString(); //endDate; bu tarih de gelebilir
                        kurumTaslakCetvelKesinlestirme.TarihBilgileri = kesinlestirmeTarihBilgileri;
                        if (mResource != null)
                        {
                            if (mResource.MHRSCode != null)
                            {
                                kurumTaslakCetvelKesinlestirme.KlinikKoduSpecified = true;
                                kurumTaslakCetvelKesinlestirme.KlinikKodu = Convert.ToInt32(mResource.MHRSCode);
                            }
                        }

                        kurumTaslakCetvelKesinlestirmeCevap = MHRSServis.WebMethods.KurumTaslakCetvelKesinlestirmeSync(Sites.SiteLocalHost, kurumTaslakCetvelKesinlestirme);

                        if (kurumTaslakCetvelKesinlestirmeCevap != null && kurumTaslakCetvelKesinlestirmeCevap.TemelCevapBilgileri != null)
                        {
                            if (kurumTaslakCetvelKesinlestirmeCevap.TemelCevapBilgileri.ServisBasarisi == true && kurumTaslakCetvelKesinlestirmeCevap.taslakKesinMap != null && kurumTaslakCetvelKesinlestirmeCevap.taslakKesinMap.Length > 0)
                            {
                                foreach (MHRSServis.taslakKesinMapType taslakKesinMap in kurumTaslakCetvelKesinlestirmeCevap.taslakKesinMap)
                                {
                                    BindingList<Schedule> ScheduleMHRSByTaslakId = Schedule.GrtScheduleByMHRSTaslakID(objectContext, taslakKesinMap.TaslakCetvelId);
                                    if (ScheduleMHRSByTaslakId.Count > 0)
                                    {
                                        Schedule sch = (Schedule)objectContext.GetObject(ScheduleMHRSByTaslakId[0].ObjectID, typeof(Schedule));
                                        sch.MHRSKesinCetvelID = taslakKesinMap.KesinCetvelId;
                                        sch.MHRSTaslakCetvelID = null;
                                        sch.ErrorOfMHRSApprove = null;
                                        objectContext.Save();
                                    }
                                }
                                return true;
                            }
                            else if (kurumTaslakCetvelKesinlestirmeCevap.TemelCevapBilgileri.ServisBasarisi == false)
                            {
                                foreach (Schedule scheduleItem in MHRSList)
                                {
                                    if (scheduleItem.MasterResource is ResPoliclinic && mResource.MHRSCode == ((ResPoliclinic)scheduleItem.MasterResource).MHRSCode)
                                        scheduleItem.ErrorOfMHRSApprove = kurumTaslakCetvelKesinlestirmeCevap.TemelCevapBilgileri.Aciklama;
                                }
                                objectContext.Save();
                                throw new TTException("MHRS Bildirim Hatası : " + kurumTaslakCetvelKesinlestirmeCevap.TemelCevapBilgileri.Aciklama);
                            }
                        }
                    }
                    return false;

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                return MhrsCetvelKesinlestirme_V2(scheduleToConfirmDVO);
            }
        }
        public bool MhrsCetvelKesinlestirme_V2(ScheduleToConfirmDVO scheduleToConfirmDVO)
        {
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSBASEURL = TTObjectClasses.SystemParameter.GetParameterValue("MHRSBASEURL", "test.mhrs.gov.tr");

            DateTime date = Convert.ToDateTime(scheduleToConfirmDVO.ScheduleDate);
            DateTime startDate;
            DateTime currentWeekEndDate = GetFirstDateOfWeek(Common.RecTime()).AddDays(6).Date;
            if (date.Date <= currentWeekEndDate)//mevcut hafta için kesinleştirme yapılıyorsa bir sonraki günden başlanır.
            {
                startDate = date.AddDays(1);
            }
            else//mevcut haftadan ileri bir tarih için kesinleştirme yapılıyorsa ilk pazartesi gününden başlanır.
            {
                startDate = GetFirstDateOfWeek(date);
            }

            DateTime endDate = GetFirstDateOfWeek(date).AddDays(6);
            Guid masterResource = new Guid(scheduleToConfirmDVO.MasterResourceID);
            Guid resource = new Guid(scheduleToConfirmDVO.ResourceID);

            try
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    ResPoliclinic mResource = (ResPoliclinic)objectContext.GetObject(masterResource, typeof(ResPoliclinic));
                    // Resource doctor = (Resource)objectContext.GetObject(resource, typeof(Resource));
                    BindingList<Schedule> MHRSList = Schedule.GetScheduleByResourceAndDateForMHRSTask(objectContext, endDate.AddDays(1).Date, startDate.Date, resource.ToString());
                    if (MHRSList == null || MHRSList.Count == 0)
                    {
                        throw new TTException("Kesinleştirmek istediğiniz haftada MHRS planı bulunamadı !");
                    }
                    Schedule schedule = MHRSList[0];

                    MhrsCetvelKesinlestirmeInput input = new MhrsCetvelKesinlestirmeInput();
                    input.baslangicTarihi = startDate.ToString("yyyy-MM-dd");
                    input.bitisTarihi = endDate.ToString("yyyy-MM-dd");
                    if (schedule.CetvelTipiValue == CetvelTipiEnum.Bolum)
                    {
                        input.cetvelTipi = 2;
                        input.hekimTcKimlikNo = null;
                    }
                    else
                    {
                        input.cetvelTipi = 1;

                        if (schedule.Resource != null && schedule.Resource is ResUser)
                        {
                            input.hekimTcKimlikNo = Convert.ToInt64(((ResUser)schedule.Resource).UniqueNo);
                        }
                    }

                    if (mResource != null)
                    {
                        input.klinikKodu = mResource.MHRSCode != null ? Convert.ToInt32(mResource.MHRSCode) : 0;
                        input.muayeneYeriId = -1;// Çalışılan ve çalışılmayan tüm cetvellerin kesinleştirilmesi için -1 gönderiyoruz. mResource.MHRSAltKlinikKodu != null ? Convert.ToInt32(mResource.MHRSAltKlinikKodu) : 0;
                    }
                    input.semtDahilMi = false;
                    input.islemYapilanKurumKodu = Convert.ToInt32(MHRSKurumKodu);
                    input.islemYapanTcKimlikNo = Convert.ToInt64(Common.CurrentResource.UniqueNo);


                    string serializedObj = JsonConvert.SerializeObject(input);
                    string accessToken = schedule.LoginForMHRS();

                    Uri uri = new Uri("https://" + MHRSBASEURL + "/api/rs/hbys/cetvel/kesinlestir");

                    var client = new RestClient(uri);

                    var request = new RestSharp.RestRequest();
                    request.Method = Method.POST;
                    request.Parameters.Clear();

                    string bearerToken = "Bearer " + accessToken;
                    request.AddParameter("Authorization", bearerToken, ParameterType.HttpHeader);
                    request.AddHeader("Accept", "application/json");
                    request.AddParameter("application/json", serializedObj, ParameterType.RequestBody);

                    //IRestResponse response = client.Execute(request);
                    IRestResponse response = schedule.PostCallForMHRS(client, request);
                    if (response != null && response.ResponseStatus == ResponseStatus.Completed && response.IsSuccessful == false)
                    {
                        var errorMessage = response.Content;
                        var errorObject = JsonConvert.DeserializeObject(response.Content) as JObject;
                        string detailedError = "";

                        if (errorObject != null)
                        {
                            var error = errorObject.Value<JArray>("errors");

                            foreach (Newtonsoft.Json.Linq.JObject item in error)
                            {
                                detailedError += " Kodu: " + item["kodu"] + "  Mesaj: " + item["mesaj"];
                            }

                        }
                        throw new TTException(detailedError);

                    }

                    if (response.IsSuccessful)
                    {
                        var result = JsonConvert.DeserializeObject<MhrsCetvelKesinlestirmeResponse>(response.Content);

                        foreach (var item in result.data)
                        {
                            BindingList<Schedule> ScheduleMHRSByTaslakId = Schedule.GrtScheduleByMHRSTaslakID(objectContext, item.cetvelId);
                            if (ScheduleMHRSByTaslakId.Count > 0)
                            {
                                Schedule scheduleKesinlesmis = (Schedule)objectContext.GetObject(ScheduleMHRSByTaslakId[0].ObjectID, typeof(Schedule));
                                scheduleKesinlesmis.MHRSTaslakCetvelID = null;
                                scheduleKesinlesmis.MHRSKesinCetvelID = item.cetvelId;
                                scheduleKesinlesmis.ErrorOfMHRSApprove = null;
                                objectContext.Save();
                            }
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        void ShowScheduleForm(ScheduleFormViewModel viewModel)
        {
            try
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    FillScheduleFormComboValues(viewModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        partial void PreScript_ScheduleForm(ScheduleFormViewModel viewModel, Schedule schedule, TTObjectContext objectContext)
        {
            viewModel.istisnasuresi = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MHRSISTISNASURESI", "0"));
            ApplySecurity();
            viewModel.ReadOnly = false;
            SetDefaultValues(viewModel);
            ShowScheduleForm(viewModel);
        }
    }
}

namespace Core.Models
{
    public partial class ScheduleFormViewModel
    {
        public int istisnasuresi
        {
            get;
            set;
        }

        public bool txtDurationDisabled
        {
            get;
            set;
        }

        public bool txtCountLimitDisabled
        {
            get;
            set;
        }

        public bool SentToMHRSVisible
        {
            get;
            set;
        }

        public string MHRSActionFilter
        {
            get;
            set;
        }

        public DateTime SchDate
        {
            get;
            set;
        }

        public Int32 timePeriod
        {
            get;
            set;
        }

        public Int32 Number
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public bool weeklyPlan
        {
            get;
            set;
        }

        public bool weekendIncluded
        {
            get;
            set;
        }

        public DateTime recurrenceStartDate
        {
            get;
            set;
        }

        public DateTime recurrenceEndDate
        {
            get;
            set;
        }

        public string RepeatNote
        {
            get;
            set;
        }

        public AppointmentCarrier AppointmentCarrier
        {
            get;
            set;
        }

        public List<MHRSActionTypeDefinition> MHRSActionList
        {
            get;
            set;
        }

        public List<ScheduleAppointmentType> ScheduleAppointmentTypes
        {
            get;
            set;
        }

        public List<AppointmentDefinition> AppointmentDefinitionList
        {
            get;
            set;
        }

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get;
            set;
        }

        public List<AppointmentTypeListDVO> AppointmentTypeList
        {
            get;
            set;
        }

        public List<AppointmentTypeListDVO> SelectedAppointmentTypeList
        {
            get;
            set;
        }

        public List<Resource> MasterResourceList
        {
            get;
            set;
        }

        public List<Resource> SubResourceList
        {
            get;
            set;
        }

        public List<Guid> SelectedMasterResourceList
        {
            get;
            set;
        }

        public List<Guid> SelectedSubResourceList
        {
            get;
            set;
        }

        public AppointmentTypeEnum? AppointmentTypeEnum
        {
            get;
            set;
        }

        public AppointmentTypeListDVO AppointmentType
        {
            get;
            set;
        }

        public GivenSchedule selectedSchedule
        {
            get;
            set;
        }

        public GivenSchedule _myOldSchedule
        {
            get;
            set;
        }

        public List<ResourceAndColorDVO> AllResourcesAndColors
        {
            get;
            set;
        }

        public ScheduleToUpdateDVO scheduleToUpdateDVO
        {
            get;
            set;
        }

        public bool appCarrierDisabled
        {
            get;
            set;
        }

        public bool appDefDisabled
        {
            get;
            set;
        }

        public bool appMasterResourceDisabled
        {
            get;
            set;
        }

        public bool showScheduleJobRuleGrid
        {
            get;
            set;
        }

        public bool newMHRSParameter
        {
            get;
            set;
        }

        public CetvelTipiEnum cetvelTipi
        {
            get;
            set;
        }
    }

    public class ScheduleInputDVO
    {
        public Resource res
        {
            get;
            set;
        }

        public Guid ownerObjectID
        {
            get;
            set;
        }

        public Guid masterOwnerObjectID
        {
            get;
            set;
        }

        public List<Guid> SelectedOwnerResources
        {
            get;
            set;
        }

        public List<Guid> SelectedMasterOwnerResources
        {
            get;
            set;
        }

        public List<ResourceAndColorDVO> AllResourcesAndColors
        {
            get;
            set;
        }

        public DateTime ScheduleDate
        {
            get;
            set;
        }

        public DateTime StartTime
        {
            get;
            set;
        }

        public DateTime EndTime
        {
            get;
            set;
        }

        public Int32 timePeriod
        {
            get;
            set;
        }

        public Int32 Number
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public bool weeklyPlan
        {
            get;
            set;
        }

        public bool weekendIncluded
        {
            get;
            set;
        }

        public DateTime recurrenceStartDate
        {
            get;
            set;
        }

        public DateTime recurrenceEndDate
        {
            get;
            set;
        }

        public string RepeatNote
        {
            get;
            set;
        }

        public AppointmentTypeEnum? scheduleType
        {
            get;
            set;
        }

        public string currentView
        {
            get; set;
        }
    }

    public class ScheduleToSaveDVO
    {
        public Schedule scheduleToSave
        {
            get;
            set;
        }

        public List<GivenSchedule> selectedCalendarItems
        {
            get;
            set;
        }

        public GivenSchedule _myOldSchedule
        {
            get;
            set;
        }

        public Schedule _retSchedule
        {
            get;
            set;
        }

        public List<AppointmentCarrier> _carrierList
        {
            get;
            set;
        }

        public List<AppointmentTypeListDVO> SelectedAppointmentTypeList
        {
            get;
            set;
        }

        public List<ScheduleJobRule> ScheduleJobRules
        {
            get;
            set;
        }
    }

    public class CalismaPlaniGuncelleDVO
    {
        public ScheduleToSaveDVO scheduleToSaveDVO { get; set; }
        public GivenSchedule givenSchedule { get; set; }

    }

    public class ScheduleToCopyDVO
    {
        public DateTime ScheduleDate
        {
            get;
            set;
        }

        public DateTime RecurrenceStartDate
        {
            get;
            set;
        }

        public DateTime RecurrenceEndDate
        {
            get;
            set;
        }

        public bool includeWeekend
        {
            get;
            set;
        }

        public bool weeklyPlan
        {
            get;
            set;
        }

        public Guid currentSubResourceObjectID
        {
            get;
            set;
        }

        public bool SentToMHRS
        {
            get;
            set;
        }
    }

    public class ScheduleRecurrenceToDeleteDVO
    {
        public DateTime RecurrenceStartDate
        {
            get;
            set;
        }

        public DateTime RecurrenceEndDate
        {
            get;
            set;
        }

        public Guid currentSubResourceObjectID
        {
            get;
            set;
        }

        public bool SentToMHRS
        {
            get;
            set;
        }
    }

    public class ScheduleToUpdateDVO
    {
        public bool appCarrierDisabled
        {
            get;
            set;
        }

        public bool appDefDisabled
        {
            get;
            set;
        }

        public bool appMasterResourceDisabled
        {
            get;
            set;
        }
    }

    public class GivenSchedules
    {
        public List<GivenSchedule> givenSchedules
        {
            get;
            set;
        }

        public List<GivenResource> SubResources
        {
            get;
            set;
        }

        public List<GivenResource> MasterResources
        {
            get;
            set;
        }
    }

    public class GivenSchedule
    {
        public string text
        {
            get;
            set;
        }

        public string objectID
        {
            get;
            set;
        }

        public Guid ownerObjectID
        {
            get;
            set;
        }

        public Resource ownerObject
        {
            get;
            set;
        }

        public Guid masterOwnerObjectID
        {
            get;
            set;
        }

        public string objectDefID
        {
            get;
            set;
        }

        public string objectDefName
        {
            get;
            set;
        }

        public DateTime startDate
        {
            get;
            set;
        }

        public DateTime endDate
        {
            get;
            set;
        }

        public string recurrenceRule
        {
            get;
            set;
        }

        public string color
        {
            get;
            set;
        }

        public string notes
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }

        public long? MHRSKesinCetvelID { get; set; }
    }

    public class ScheduleToConfirmDVO
    {

        public DateTime ScheduleDate
        {
            get; set;
        }
        public string ResourceID
        {
            get;
            set;
        }
        public string MasterResourceID
        {
            get;
            set;
        }
    }

    #region MHRS_V2
    public class EklenecekCetvelTalep
    {
        public string cinsiyet { get; set; }
        public int eklenecekCetvelAksiyonId { get; set; }
        public string eklenecekCetvelBaslangicZamani { get; set; }
        public string eklenecekCetvelBitisZamani { get; set; }
        public int eklenecekCetvelKurumKodu { get; set; }
        public int? eklenecekCetvelMuayeneYeriId { get; set; }
        public int eklenecekCetvelRandevusuresi { get; set; }
        public int eklenecekCetvelSlotHastaSayisi { get; set; }
        public int? enBuyukYas { get; set; }
        public string enBuyukYasTipi { get; set; }
        public int? enKucukYas { get; set; }
        public string enKucukYasTipi { get; set; }
        public List<int> ikOzelDurumList { get; set; }
    }

    public class PlanGuncelleRoot_Input
    {
        public List<EklenecekCetvelTalep> eklenecekCetvelTalepList { get; set; }
        public bool semtDahilMi { get; set; }
        public List<Int64> silinecekCetvelIdList { get; set; }
        public string sorgulananBaslangicZamani { get; set; }
        public string sorgulananBitisZamani { get; set; }
        public int sorgulananCetvelTipi { get; set; }
        public Int64? sorgulananHekimTCKimlikNo { get; set; }
        public int sorgulananKlinikKodu { get; set; }
        public int? sorgulananMuayeneYeriId { get; set; }
        public int islemYapilanKurumKodu { get; set; }
        public Int64 islemYapanTcKimlikNo { get; set; }
    }

    public class Info
    {
        public string kodu { get; set; }
        public string mesaj { get; set; }
    }

    public class IkOzelDurum
    {
        public int? val { get; set; }
        public string valText { get; set; }
    }


    public class Datum
    {
        public int aksiyonId { get; set; }
        public string baslangicZamani { get; set; }
        public string bitisZamani { get; set; }
        public CetvelDurumu cetvelDurumu { get; set; }
        public Int64 cetvelId { get; set; }
        public CetvelTipi cetvelTipi { get; set; }
        public Cinsiyet cinsiyet { get; set; }
        public int? enBuyukYas { get; set; }
        public string enBuyukYasTipi { get; set; }
        public int? enKucukYas { get; set; }
        public string enKucukYasTipi { get; set; }
        public Int64? hekimTcKimlikNo { get; set; }
        public List<IkOzelDurum> ikOzelDurum { get; set; }

        public int klinikKodu { get; set; }
        public int kurumKodu { get; set; }
        public int? muayeneYeriId { get; set; }
        public int randevuSuresi { get; set; }
        public int slotHastaSayisi { get; set; }

    }

    public class PlanGuncelleRoot_Output
    {
        public string lang { get; set; }
        public bool success { get; set; }
        public List<Info> infos { get; set; }
        public List<object> warnings { get; set; }
        public List<object> errors { get; set; }
        public List<Datum> data { get; set; }
    }
    #endregion
    public class MhrsCetvelKesinlestirmeInput
    {
        public string baslangicTarihi { get; set; }
        public string bitisTarihi { get; set; }
        public int cetvelTipi { get; set; }
        public Int64? hekimTcKimlikNo { get; set; }
        public int klinikKodu { get; set; }
        public int? muayeneYeriId { get; set; }
        public bool semtDahilMi { get; set; }
        public int islemYapilanKurumKodu { get; set; }
        public Int64 islemYapanTcKimlikNo { get; set; }
    }

    public class MhrsCetvelKesinlestirmeResponse
    {
        public string lang { get; set; }
        public bool success { get; set; }
        public List<Info> infos { get; set; }
        public List<object> warnings { get; set; }
        public List<object> errors { get; set; }
        public List<MhrsCetvelKesinlestirmeData> data { get; set; }
    }
    public class MhrsCetvelKesinlestirmeData
    {
        public Int64 cetvelId { get; set; }
        public Cetveldurumu cetvelDurumu { get; set; }
        public Cetveltipi cetvelTipi { get; set; }
        public int aksiyonId { get; set; }
        public DateTime baslangicZamani { get; set; }
        public DateTime bitisZamani { get; set; }
        public int klinikKodu { get; set; }
        public int kurumKodu { get; set; }
        public int muayeneYeriId { get; set; }
        public Int64? hekimTcKimlikNo { get; set; }
        public int randevuSuresi { get; set; }
        public int slotHastaSayisi { get; set; }
        public Cinsiyet cinsiyet { get; set; }
        public int? enBuyukYas { get; set; }
        public string enBuyukYasTipi { get; set; }
        public int? enKucukYas { get; set; }
        public string enKucukYasTipi { get; set; }
        public Ikozeldurum[] ikOzelDurum { get; set; }
    }

    public class Cetveldurumu
    {
        public int val { get; set; }
        public string valText { get; set; }
    }

    public class Cetveltipi
    {
        public int val { get; set; }
        public string valText { get; set; }
    }

    public class Cinsiyet
    {
        public string val { get; set; }
        public string valText { get; set; }
    }

    public class Ikozeldurum
    {
        public int val { get; set; }
        public string valText { get; set; }
    }

}