//$6E404C94
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using System.ComponentModel;
using TTStorageManager.Security;
using System.Collections;
using TTConnectionManager;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    public partial class AppointmentServiceController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public AppointmentFormViewModel AppointmentForm(Guid? id)
        {
            var formDefID = Guid.Parse("f9278a52-a69b-45c3-89e7-e8b3fb5f08f9");
            var objectDefID = Guid.Parse("6a432849-b460-4c0e-9a27-7101ff8305b5");
            var viewModel = new AppointmentFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                if (id.HasValue && id.Value != Guid.Empty)
                {
                    viewModel._Appointment = objectContext.GetObject(id.Value, objectDefID) as Appointment;
                    viewModel.ReadOnly = true;// TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Appointment, formDefID);
                    //viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Appointment, formDefID);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                }
                else
                {
                    viewModel._Appointment = new Appointment(objectContext);
                    viewModel._Appointment.AppointmentID.GetNextValue();
                    if (viewModel._Appointment.IsNumarator == null)
                        viewModel._Appointment.IsNumarator = false;
                    viewModel.AppointmentDefinitionList = new System.Collections.Generic.List<AppointmentDefinition>();
                    viewModel.AppointmentCarrierList = new System.Collections.Generic.List<AppointmentCarrier>();
                    viewModel.ObjectAppointmentCarrierList = new System.Collections.Generic.List<AppointmentCarrier>();
                    viewModel.AppointmentTypeList = new System.Collections.Generic.List<AppointmentTypeListDVO>();
                    viewModel.MasterResourceList = new System.Collections.Generic.List<Resource>();
                    viewModel.SubResourceList = new System.Collections.Generic.List<Resource>();
                    viewModel.SelectedMasterResourceList = new System.Collections.Generic.List<Guid>();
                    viewModel.SelectedSubResourceList = new System.Collections.Generic.List<Guid>();
                    //viewModel.SelectedAppointmentDef = null;// new AppointmentDefinition();
                    //viewModel.SelectedAppointmentCarrier = null;//new AppointmentCarrier();
                    viewModel.ReadOnly = true;// TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Appointment, formDefID);
                    //viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Appointment, formDefID);
                }

                PreScript_AppointmentForm(viewModel, viewModel._Appointment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }

            return viewModel;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public AppointmentFormViewModel StateAppointmentForm(AppointmentFormViewModel id)
        {
            var formDefID = Guid.Parse("f9278a52-a69b-45c3-89e7-e8b3fb5f08f9");
            var objectDefID = Guid.Parse("6a432849-b460-4c0e-9a27-7101ff8305b5");
            var viewModel = new AppointmentFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                if (id != null)
                {
                    viewModel._Appointment = new Appointment(objectContext);
                    viewModel._Appointment.AppointmentID.GetNextValue();
                    if (viewModel._Appointment.IsNumarator == null)
                        viewModel._Appointment.IsNumarator = false;
                    viewModel.AppointmentDefinitionList = new System.Collections.Generic.List<AppointmentDefinition>();
                    viewModel.AppointmentCarrierList = new System.Collections.Generic.List<AppointmentCarrier>();
                    viewModel.ObjectAppointmentCarrierList = new System.Collections.Generic.List<AppointmentCarrier>();
                    viewModel.AppointmentTypeList = new System.Collections.Generic.List<AppointmentTypeListDVO>();
                    viewModel.MasterResourceList = new System.Collections.Generic.List<Resource>();
                    viewModel.SubResourceList = new System.Collections.Generic.List<Resource>();
                    viewModel.SelectedMasterResourceList = new System.Collections.Generic.List<Guid>();
                    viewModel.SelectedSubResourceList = new System.Collections.Generic.List<Guid>();
                    viewModel.CurrentObject = id.CurrentObject;
                    viewModel.StarterObject = id.StarterObject;
                    viewModel.CurrentObjectTransDefID = id.CurrentObjectTransDefID;
                    viewModel.ReadOnly = true;// TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Appointment, formDefID);
                    //viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Appointment, formDefID);
                }

                PreScript_AppointmentForm(viewModel, viewModel._Appointment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }

            return viewModel;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public void AppointmentForm(AppointmentFormViewModel viewModel)
        {
            var formDefID = Guid.Parse("f9278a52-a69b-45c3-89e7-e8b3fb5f08f9");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.AppointmentDefinitionList);
                objectContext.AddToRawObjectList(viewModel.AppointmentCarrierList);
                objectContext.AddToRawObjectList(viewModel.MasterResourceList);
                objectContext.AddToRawObjectList(viewModel.SubResourceList);
                //objectContext.AddToRawObjectList(viewModel.SelectedMasterResourceList);
                //objectContext.AddToRawObjectList(viewModel.SelectedSubResourceList);
                objectContext.AddToRawObjectList(viewModel._Appointment);
                objectContext.AddToRawObjectList(viewModel._Appointment.AppointmentCarrier);
                objectContext.AddToRawObjectList(viewModel._Appointment.AppointmentDefinition);
                objectContext.AddToRawObjectList(viewModel._Appointment.EpisodeAction);
                objectContext.AddToRawObjectList(viewModel._Appointment.ExaminationQueueHistory);
                objectContext.AddToRawObjectList(viewModel._Appointment.GivenBy);
                objectContext.AddToRawObjectList(viewModel._Appointment.MasterAppointments);
                objectContext.AddToRawObjectList(viewModel._Appointment.MasterResource);
                objectContext.AddToRawObjectList(viewModel._Appointment.Patient);
                objectContext.AddToRawObjectList(viewModel._Appointment.Resource);
                objectContext.AddToRawObjectList(viewModel._Appointment.Schedule);
                objectContext.AddToRawObjectList(viewModel._Appointment.SubActionProcedure);
                objectContext.ProcessRawObjects();
                var appointment = (Appointment)objectContext.GetLoadedObject(viewModel._Appointment.ObjectID);
                //TTDefinitionManagement.TTFormDef.CheckFormSecurity(appointment, formDefID, true);
                //TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Appointment, formDefID);
                PostScript_AppointmentForm(viewModel, appointment, appointment.TransDef, objectContext);
                objectContext.Save();
                AfterContextSaveScript_AppointmentForm(viewModel, appointment, appointment.TransDef, objectContext);
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Guncelleme)]
        public AppointmentFormViewModel AppointmentListForm(Guid? id)
        {
            var formDefID = Guid.Parse("f9278a52-a69b-45c3-89e7-e8b3fb5f08f9");
            var objectDefID = Guid.Parse("6a432849-b460-4c0e-9a27-7101ff8305b5");
            var viewModel = new AppointmentFormViewModel();
            viewModel.isAppointmentListForm = true;
            using (var objectContext = new TTObjectContext(false))
            {
                if (id.HasValue && id.Value != Guid.Empty)
                {
                    viewModel._Appointment = objectContext.GetObject(id.Value, objectDefID) as Appointment;
                    viewModel.ReadOnly = true;// TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Appointment, formDefID);
                    //viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Appointment, formDefID);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                }
                else
                {
                    viewModel._Appointment = new Appointment(objectContext);
                    //viewModel._Appointment.AppointmentID.GetNextValue();
                    if (viewModel._Appointment.IsNumarator == null)
                        viewModel._Appointment.IsNumarator = false;
                    viewModel.AppointmentDefinitionList = new System.Collections.Generic.List<AppointmentDefinition>();
                    viewModel.AppointmentCarrierList = new System.Collections.Generic.List<AppointmentCarrier>();
                    viewModel.ObjectAppointmentCarrierList = new System.Collections.Generic.List<AppointmentCarrier>();
                    viewModel.AppointmentTypeList = new System.Collections.Generic.List<AppointmentTypeListDVO>();
                    viewModel.MasterResourceList = new System.Collections.Generic.List<Resource>();
                    viewModel.SubResourceList = new System.Collections.Generic.List<Resource>();
                    viewModel.SelectedMasterResourceList = new System.Collections.Generic.List<Guid>();
                    viewModel.SelectedSubResourceList = new System.Collections.Generic.List<Guid>();
                    viewModel.AppointmentStateItems = new System.Collections.Generic.List<AppointmentStateItem>();
                    viewModel.SelectedAppointmentStateItems = new System.Collections.Generic.List<AppointmentStateItem>();
                    //viewModel.SelectedAppointmentDef = null;// new AppointmentDefinition();
                    //viewModel.SelectedAppointmentCarrier = null;//new AppointmentCarrier();
                    viewModel.ReadOnly = true;// TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Appointment, formDefID);
                    //viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Appointment, formDefID);
                }

                PreScript_AppointmentListForm(viewModel, viewModel._Appointment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }

            return viewModel;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Guncelleme)]
        public void AppointmentListForm(AppointmentFormViewModel viewModel)
        {
            var formDefID = Guid.Parse("f9278a52-a69b-45c3-89e7-e8b3fb5f08f9");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.AppointmentDefinitionList);
                objectContext.AddToRawObjectList(viewModel.AppointmentCarrierList);
                objectContext.AddToRawObjectList(viewModel.MasterResourceList);
                objectContext.AddToRawObjectList(viewModel.SubResourceList);
                //objectContext.AddToRawObjectList(viewModel.SelectedMasterResourceList);
                //objectContext.AddToRawObjectList(viewModel.SelectedSubResourceList);
                objectContext.AddToRawObjectList(viewModel._Appointment);
                objectContext.AddToRawObjectList(viewModel._Appointment.AppointmentCarrier);
                objectContext.AddToRawObjectList(viewModel._Appointment.AppointmentDefinition);
                objectContext.AddToRawObjectList(viewModel._Appointment.EpisodeAction);
                objectContext.AddToRawObjectList(viewModel._Appointment.ExaminationQueueHistory);
                objectContext.AddToRawObjectList(viewModel._Appointment.GivenBy);
                objectContext.AddToRawObjectList(viewModel._Appointment.MasterAppointments);
                objectContext.AddToRawObjectList(viewModel._Appointment.MasterResource);
                objectContext.AddToRawObjectList(viewModel._Appointment.Patient);
                objectContext.AddToRawObjectList(viewModel._Appointment.Resource);
                objectContext.AddToRawObjectList(viewModel._Appointment.Schedule);
                objectContext.AddToRawObjectList(viewModel._Appointment.SubActionProcedure);

                objectContext.ProcessRawObjects();
                var appointment = (Appointment)objectContext.GetLoadedObject(viewModel._Appointment.ObjectID);
                //TTDefinitionManagement.TTFormDef.CheckFormSecurity(appointment, formDefID, true);
                //TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Appointment, formDefID);
                PostScript_AppointmentListForm(viewModel, appointment, appointment.TransDef, objectContext);
                objectContext.Save();
                AfterContextSaveScript_AppointmentListForm(viewModel, appointment, appointment.TransDef, objectContext);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Guncelleme)]
        public AppointmentListInputDVO FillAppointmentsList(AppointmentListInputDVO appointmentListInputModel)
        {
            TTObjectContext _editableObjectcontext = new TTObjectContext(true);
            DateTime startDate = appointmentListInputModel.appListStartDate;
            DateTime endDate = appointmentListInputModel.appListEndDate;

            CreateInjectionSQL(appointmentListInputModel);

            IList appointments = Appointment.GetByAppDate(_editableObjectcontext, startDate, endDate, appointmentListInputModel.injectionSQL);
            appointmentListInputModel.appointmentListItems = new List<GivenAppointment>();
            foreach (Appointment appointment in appointments)
            {
                GivenAppointment appointmentListItem = createAppointmentListItem(appointment);
                appointmentListInputModel.appointmentListItems.Add(appointmentListItem);
            }
            _editableObjectcontext.FullPartialllyLoadedObjects();
            return appointmentListInputModel;
        }

        private void CreateInjectionSQL(AppointmentListInputDVO appointmentListInputModel)
        {
            string injectionSQL = String.Empty;
            AppointmentDefinition appDef = (AppointmentDefinition)appointmentListInputModel.appListAppointmentDefinition;
            Resource masRes = (Resource)appointmentListInputModel.appListMasterResource;
            //Resource subRes = null;
            //if (appointmentListInputModel.appListResource != null)
            //{
            //    if (appointmentListInputModel.appListResource is ResUser)
            //        subRes = (ResUser)appointmentListInputModel.appListResource;
            //    else
            //        subRes = (Resource)appointmentListInputModel.appListResource;
            //}
            List<Guid> selectedOwnerResources = appointmentListInputModel.SelectedOwnerResources;
            DateTime startDateTime = appointmentListInputModel.appListStartDate;
            DateTime endDateTime = appointmentListInputModel.appListEndDate;
            string _criteria = "";

            _criteria += "Tarih : " + startDateTime.ToShortDateString() + " - " + endDateTime.ToShortDateString() + " ";
            //if (appointmentListInputModel.filterAppListByAppDef == true)
            if (appDef != null)
            {
                injectionSQL += " AND APPOINTMENTDEFINITION = " + ConnectionManager.GuidToString(appDef.ObjectID) + "";
                _criteria += "Kategori : " + appDef.AppointmentDefinitionNameDisplayText + " ";
            }

            if (appointmentListInputModel.currentPatient != null)
            {
                injectionSQL += " AND PATIENT = " + ConnectionManager.GuidToString(appointmentListInputModel.currentPatient.ObjectID) + "";
                _criteria += "Hasta : " + appointmentListInputModel.currentPatient.FullName + " ";
            }

            if (appDef.GiveToMaster == true)
            {
                if (masRes != null)
                {
                    injectionSQL += " AND MASTERRESOURCE IS NULL AND \"RESOURCE\" = " + ConnectionManager.GuidToString(masRes.ObjectID) + "";
                    _criteria += appointmentListInputModel.MasterResourceCaption + " : " + masRes.Name + " ";
                }
                else
                {
                    injectionSQL += " AND MASTERRESOURCE IS NULL AND \"RESOURCE\" IN (" + ConnectionManager.GuidToString(Guid.Empty);
                    foreach (Resource item in appointmentListInputModel.MasterResourceList)
                    {
                        if (item != null)
                        {
                            ResSection section = (ResSection)item;
                            injectionSQL += "," + ConnectionManager.GuidToString(section.ObjectID);
                        }
                    }
                    injectionSQL += ") ";
                    _criteria += appointmentListInputModel.MasterResourceCaption + " : <TÜMÜ> ";
                }
            }
            else
            {
                if (masRes != null)
                {
                    injectionSQL += " AND MASTERRESOURCE = " + ConnectionManager.GuidToString(masRes.ObjectID) + "";
                    _criteria += appointmentListInputModel.MasterResourceCaption + " : " + masRes.Name + " ";

                    if (appointmentListInputModel.SelectedOwnerResources != null && appointmentListInputModel.SelectedOwnerResources.Count > 0)
                    {
                        injectionSQL += " AND \"RESOURCE\" IN (" + ConnectionManager.GuidToString(Guid.Empty);
                        _criteria += appointmentListInputModel.SubResourceCaption + " : ";
                        foreach (Guid subRes in appointmentListInputModel.SelectedOwnerResources)
                        {
                            injectionSQL += "," + ConnectionManager.GuidToString(subRes);
                            TTObjectContext objectContext = new TTObjectContext(true);
                            Resource subResource = objectContext.GetObject<Resource>(subRes);
                            _criteria += subResource.Name + ", ";
                        }
                        injectionSQL += ") ";
                    }
                    else
                        _criteria += appointmentListInputModel.SubResourceCaption + " : <TÜMÜ> ";
                    //if (subRes != null)
                    //{
                    //    injectionSQL += " AND \"RESOURCE\" = " + ConnectionManager.GuidToString(subRes.ObjectID) + "";
                    //    _criteria += appointmentListInputModel.SubResourceCaption + " " + subRes.Name + " ";
                    //}
                    //else
                    //    _criteria += appointmentListInputModel.SubResourceCaption + " <TÜMÜ> ";
                }
                else
                {
                    injectionSQL += " AND MASTERRESOURCE IN (" + ConnectionManager.GuidToString(Guid.Empty);
                    foreach (Resource item in appointmentListInputModel.MasterResourceList)
                    {
                        if (item != null)
                        {
                            ResSection section = (ResSection)item;
                            injectionSQL += "," + ConnectionManager.GuidToString(section.ObjectID);
                        }
                    }
                    injectionSQL += ") ";
                    _criteria += appointmentListInputModel.MasterResourceCaption + " : <TÜMÜ> ";
                    _criteria += appointmentListInputModel.SubResourceCaption + " : <TÜMÜ> ";
                }
            }

            if (appointmentListInputModel.appListAppointmentType != null)
            {
                injectionSQL += " AND APPOINTMENTTYPE = " + ((AppointmentTypeEnum)appointmentListInputModel.appListAppointmentType.AppointmentTypeEnumValue).GetHashCode() + "";
                _criteria += "Randevu Türü : " + (appointmentListInputModel.appListAppointmentType.AppointmentTypeDisplayText).ToString() + " ";
            }
            else
                _criteria += "Randevu Türü : <TÜMÜ> ";

            if (appointmentListInputModel.SelectedAppointmentStateItems != null && appointmentListInputModel.SelectedAppointmentStateItems.Count > 0)
            {
                injectionSQL += " AND CURRENTSTATEDEFID IN (" + ConnectionManager.GuidToString(Guid.Empty);
                _criteria += "Durum : ";
                foreach (AppointmentStateItem appState in appointmentListInputModel.SelectedAppointmentStateItems)
                {
                    injectionSQL += "," + ConnectionManager.GuidToString(new Guid(appState.StateDefID));
                    _criteria += appState.StateDefName + " , ";
                }
                injectionSQL += ") ";
            }
            else
                _criteria += "Durum : <TÜMÜ> ";

            //injectionSQL += " AND ISNUMARATOR = 0 ORDER BY APPDATE,STARTTIME";
            injectionSQL += " ORDER BY APPDATE,STARTTIME";
            appointmentListInputModel.injectionSQL = injectionSQL;
            appointmentListInputModel.criteria = _criteria;
        }

        private GivenAppointment createAppointmentListItem(Appointment app)
        {
            GivenAppointment appointmentListItem = new GivenAppointment();

            string appDate = app.AppDate.HasValue ? app.AppDate.Value.ToShortDateString() : "";
            string strTime = (app.StartTime.HasValue && app.EndTime.HasValue) ? app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() : "";

            appointmentListItem.startDate = (DateTime)app.StartTime;
            appointmentListItem.endDate = (DateTime)app.EndTime;

            string procedureObjectName = string.Empty;
            if (app.SubActionProcedure != null && app.SubActionProcedure.ProcedureObject != null)
                procedureObjectName = "İşlem:" + app.SubActionProcedure.ProcedureObject.Name + " ";

            if (app.Patient != null)
            {
                appointmentListItem.text = procedureObjectName + "Hasta : " + app.Patient.PatientIDandFullName + " " + app.Notes;
                appointmentListItem.patient = app.Patient;
                appointmentListItem.txtPatient = app.Patient.PatientIDandFullName;

                //if (app.Patient.UniqueRefNo.HasValue)
                //    appointmentListItem.TCKNo = app.Patient.UniqueRefNo.Value;
                //if (app.Patient.PatientAddress != null)
                //    appointmentListItem.PhoneNumber = app.Patient.PatientAddress.MobilePhone;

                if (app.Patient.Privacy.HasValue && app.Patient.Privacy.Value == true)
                {
                    if (app.Patient.PrivacyUniqueRefNo.HasValue)
                        appointmentListItem.TCKNo = app.Patient.PrivacyUniqueRefNo.Value;

                    appointmentListItem.PhoneNumber = app.Patient.PrivacyMobilePhone;
                }
                else
                {
                    if (app.Patient.UniqueRefNo.HasValue)
                        appointmentListItem.TCKNo = app.Patient.UniqueRefNo.Value;
                    if (app.Patient.PatientAddress != null)
                        appointmentListItem.PhoneNumber = app.Patient.PatientAddress.MobilePhone;
                }

                appointmentListItem.osPhoneType = PhoneTypeEnum.GSM;
            }
            else
            {
                if (app.Action != null && app.Action is AdmissionAppointment)
                {
                    AdmissionAppointment admissionApp = (AdmissionAppointment)app.Action;
                    appointmentListItem.text = procedureObjectName + "Hasta : " + admissionApp.PatientNameSurname + " " + app.Notes;
                    appointmentListItem.patient = null;
                    appointmentListItem.txtPatient = (admissionApp.PatientUniqueRefNo.HasValue ? admissionApp.PatientUniqueRefNo.Value.ToString() + " " : String.Empty) + admissionApp.PatientNameSurname;
                    appointmentListItem.TCKNo = admissionApp.PatientUniqueRefNo;
                    appointmentListItem.PhoneNumber = admissionApp.PatientPhone;
                    appointmentListItem.osPhoneType = admissionApp.PhoneType;
                }
            }

            appointmentListItem.masterOwnerObjectID = app.MasterResource.ObjectID;
            appointmentListItem.appointmentTypeEnum = app.AppointmentType;

            if (app.CurrentStateDefID == Appointment.States.Completed)
            {
                appointmentListItem.text = "KABUL ALINDI!" + "  " + appointmentListItem.text;
                appointmentListItem.color = "#f5f5f5";
                appointmentListItem.enabled = false;
                appointmentListItem.rowButtonType = 3;//hiç buton çıkmayacak
                appointmentListItem.rowColor = "#007ab7";
            }
            else if (app.CurrentStateDefID == Appointment.States.Cancelled)
            {
                appointmentListItem.color = "#f5f5f5";
                appointmentListItem.enabled = false;
                appointmentListItem.rowButtonType = 3;//hiç buton çıkmayacak
                appointmentListItem.rowColor = "#d9534f";
            }
            else
            {
                appointmentListItem.enabled = true;
                appointmentListItem.rowButtonType = 1;//her iki buton da çıkacak
            }
            //AppOrSchType appOrSchType = new AppOrSchType();
            //appOrSchType.text = "";
            //appOrSchType.id = app.ObjectDef.ID.ToString();
            //givenAppointmentsAndSchedules.AppOrSchTypes.Add(appOrSchType);
            //appointmentListItem.appOrSchTypeID = appOrSchType.id;


            //appointmentListItem.appointment = app;
            appointmentListItem.objectID = app.ObjectID.ToString();
            appointmentListItem.ownerObject = app.Resource;
            appointmentListItem.ownerObjectID = app.Resource != null ? app.Resource.ObjectID : Guid.Empty;
            appointmentListItem.objectDefName = app.ObjectDef.Name;
            appointmentListItem.objectDefID = app.ObjectDef.ID.ToString();
            appointmentListItem.strAppDate = appDate;
            appointmentListItem.strAppTime = strTime;
            appointmentListItem.appCategory = app.AppointmentDefinition != null ? app.AppointmentDefinition.AppDefNameDisplayText : "";
            appointmentListItem.notes = app.Notes;
            appointmentListItem.appStatus = app.CurrentStateDef != null ? app.CurrentStateDef.DisplayText : "";
            if (app.BreakAppointment == true)
                appointmentListItem.strAppTime = TTUtils.CultureService.GetText("M26776", "Saatsiz randevu");

            if (app.AppointmentType != null)
                appointmentListItem.strType = (Common.GetEnumValueDefOfEnumValue((Enum)app.AppointmentType)).DisplayText;

            if (app.AppointmentDefinition.GiveToMaster == true)
                appointmentListItem.appResources = app.Resource.Name;
            else
                appointmentListItem.appResources = app.Resource.Name + " - " + app.MasterResource.Name;

            return appointmentListItem;
        }

        void ContextToViewModel(AppointmentFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.AppointmentDefinitionList = objectContext.LocalQuery<AppointmentDefinition>().ToList();
            viewModel.AppointmentCarrierList = objectContext.LocalQuery<AppointmentCarrier>().ToList();
            viewModel.MasterResourceList = objectContext.LocalQuery<Resource>().ToList();
            viewModel.SubResourceList = objectContext.LocalQuery<Resource>().ToList();
            //viewModel.SelectedMasterResourceList = objectContext.LocalQuery<Guid>().ToList();
            //viewModel.SelectedSubResourceList = objectContext.LocalQuery<Guid>().ToList();
        }

        void ApplySecurity()
        {
            if (!TTUser.CurrentUser.HasRole(TTRoleNames.Randevu_Verme))
                throw new TTException(SystemMessage.GetMessageV2(246, TTUtils.CultureService.GetText("M26735", "Randevu vermek için yetkiniz yok.")));
        }

        void ApplySecurityForSearch()
        {
            if (!TTUser.CurrentUser.HasRole(TTRoleNames.Randevu_Guncelleme))
                throw new TTException(SystemMessage.GetMessageV2(246, TTUtils.CultureService.GetText("M26721", "Randevu aramak için yetkiniz yok.")));
        }

        void SetDefaultDateTimeValues(AppointmentFormViewModel viewModel)
        {
            DateTime currentDate = new DateTime(TTObjectDefManager.ServerTime.Date.Year, TTObjectDefManager.ServerTime.Date.Month, TTObjectDefManager.ServerTime.Date.Day, 0, 0, 0);
            viewModel._Appointment.StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 8, 0, 0);
            viewModel._Appointment.EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 9, 0, 0);
            viewModel._Appointment.AppDate = viewModel._Appointment.StartTime;
        }

        void SetDefaultDateTimeValuesForSearch(AppointmentFormViewModel viewModel)
        {
            DateTime currentDate = new DateTime(TTObjectDefManager.ServerTime.Date.Year, TTObjectDefManager.ServerTime.Date.Month, TTObjectDefManager.ServerTime.Date.Day, 0, 0, 0);
            viewModel.appListStartDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 0, 0, 0);
            viewModel.appListEndDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59);
        }

        private void ShowAppointmentForm(AppointmentFormViewModel viewModel)
        {
            List<TTObject> objectList;
            EpisodeAction ea = null;
            SubactionProcedureFlowable spf = null;
            PatientAdmission pa = null;
            SpecialityBasedObject specialityBasedObject = null;
            Patient patient = null;
            TTObjectContext context = new TTObjectContext(false);
            TTObjectStateTransitionDef currentObjectTransDef = null;
            if (viewModel.CurrentObject != null)
            {

                if (viewModel.CurrentObject is EpisodeAction)
                {
                    ea = context.GetObject<EpisodeAction>(viewModel.CurrentObject.ObjectID);
                    viewModel.CurrentObject = ea;
                    patient = ea.Episode.Patient;
                    if (viewModel.CurrentObjectTransDefID != null)
                        currentObjectTransDef = ea.ObjectDef.AllTransitionDefs.Values.FirstOrDefault(t => t.StateTransitionDefID.ToString() == viewModel.CurrentObjectTransDefID.ToString());
                    viewModel._Appointment.EpisodeAction = ea;
                    viewModel.ProcedureDoctor = ea.ProcedureDoctor;
                }
                else if (viewModel.CurrentObject is SubactionProcedureFlowable)
                {
                    spf = context.GetObject<SubactionProcedureFlowable>(viewModel.CurrentObject.ObjectID);
                    viewModel.CurrentObject = spf;
                    patient = spf.Episode.Patient;
                    if (viewModel.CurrentObjectTransDefID != null)
                        currentObjectTransDef = spf.ObjectDef.AllTransitionDefs.Values.FirstOrDefault(t => t.StateTransitionDefID.ToString() == viewModel.CurrentObjectTransDefID.ToString());
                    viewModel._Appointment.SubActionProcedure = spf;
                    viewModel.ProcedureDoctor = spf.ProcedureDoctor;
                    viewModel._Appointment.MasterResource = spf.GetDefaultAppointmentMasterResource();
                    viewModel._Appointment.Resource = spf.GetDefaultAppointmentResource();
                }

                viewModel.currentPatient = patient;
                viewModel.currentPatient.MobilePhone = patient.PatientAddress != null ? patient.PatientAddress.MobilePhone : patient.MobilePhone;
                viewModel._Appointment.Patient = patient;
                viewModel.txtPatient = patient.PatientIDandFullName;
                if (currentObjectTransDef != null)
                {
                    if (Common.IsAttributeExists(typeof(AppointmentDefinitionAttribute), viewModel.CurrentObject))
                    {
                        if (currentObjectTransDef.Attributes.ContainsKey("AppointmentDefinitionAttribute"))
                        {

                            IAppointmentDef def = (IAppointmentDef)viewModel.CurrentObject;
                            viewModel._appointmentDef = def;
                            viewModel.AppointmentCarrierList = def.GetAppointmentCarrierList();
                            viewModel.AppointmentDef = def;
                            ShowStepAppointment(viewModel);
                        }
                    }

                    if (Common.IsAttributeExists(typeof(PlanPlannedActionAttribute), viewModel.CurrentObject))
                    {
                        if (currentObjectTransDef.Attributes.ContainsKey("PlanPlannedActionAttribute"))
                        {
                            IPlanPlannedAction def = (IPlanPlannedAction)viewModel.CurrentObject;
                            viewModel._plannedAppointmentDef = def;
                            viewModel.AppointmentCarrierList = def.GetAppointmentCarrierList();
                            viewModel.AppointmentDef = def;
                            IList<PlannedAction> plannedActions = def.GetMySiblingObjectListForAppointment();
                            objectList = new List<TTObject>();
                            foreach (PlannedAction plannedAction in plannedActions)
                            {
                                objectList.Add(plannedAction);
                            }

                            viewModel.objectsList = objectList;
                            ShowStepAppointment(viewModel);
                        }
                    }

                    if (Common.IsAttributeExists(typeof(SplitBySubActionProcedureAppointmentAttribute), viewModel.CurrentObject))
                    {
                        if (currentObjectTransDef.Attributes.ContainsKey("SplitBySubActionProcedureAppointmentAttribute"))
                        {
                            ISplitBySubActionProcedureAppointment def = (ISplitBySubActionProcedureAppointment)viewModel.CurrentObject;
                            viewModel._splitBySubActionProcedureAppointmentDef = def;
                            viewModel.AppointmentCarrierList = def.GetAppointmentCarrierList();
                            viewModel.AppointmentDef = def;
                            IList<SubActionProcedure> subActionProcedures = def.GetMySiblingObjectListForAppointment();
                            objectList = new List<TTObject>();
                            foreach (SubActionProcedure subActionProcedure in subActionProcedures)
                            {
                                objectList.Add(subActionProcedure);
                            }

                            viewModel.objectsList = objectList;
                            ShowStepAppointment(viewModel);
                        }
                    }
                }
            }
            else if (viewModel.StarterObject != null)
            {

                if (viewModel.StarterObject is EpisodeAction)
                {
                    ea = context.GetObject<EpisodeAction>(viewModel.StarterObject.ObjectID);
                    viewModel.StarterObject = ea;
                    patient = ea.Episode.Patient;
                    if (viewModel.CurrentObjectTransDefID != null)
                        currentObjectTransDef = ea.ObjectDef.AllTransitionDefs.Values.FirstOrDefault(t => t.StateTransitionDefID.ToString() == viewModel.CurrentObjectTransDefID.ToString());
                    viewModel._Appointment.EpisodeAction = ea;
                    viewModel.ProcedureDoctor = ea.ProcedureDoctor;
                }
                else if (viewModel.StarterObject is SubactionProcedureFlowable)
                {
                    spf = context.GetObject<SubactionProcedureFlowable>(viewModel.StarterObject.ObjectID);
                    viewModel.StarterObject = spf;
                    patient = spf.Episode.Patient;
                    if (viewModel.CurrentObjectTransDefID != null)
                        currentObjectTransDef = spf.ObjectDef.AllTransitionDefs.Values.FirstOrDefault(t => t.StateTransitionDefID.ToString() == viewModel.CurrentObjectTransDefID.ToString());
                    viewModel._Appointment.SubActionProcedure = spf;
                    viewModel.ProcedureDoctor = spf.ProcedureDoctor;
                }
                else if (viewModel.StarterObject is PatientAdmission)
                {
                    IBindingList paList = context.QueryObjects<PatientAdmission>("OBJECTID = '" + viewModel.StarterObject.ObjectID.ToString() + "'");
                    if (paList.Count > 0)
                    {
                        pa = (PatientAdmission)paList[0];//context.GetObject<PatientAdmission>(viewModel.StarterObject.ObjectID);
                        viewModel.StarterObject = pa;
                        patient = pa.Episode.Patient;
                        viewModel.ProcedureDoctor = pa.ProcedureDoctor;
                    }
                }
                else if (viewModel.StarterObject is SpecialityBasedObject)
                {
                    IBindingList specialityBaseObjectList = context.QueryObjects<SpecialityBasedObject>("OBJECTID = '" + viewModel.StarterObject.ObjectID.ToString() + "'");
                    if (specialityBaseObjectList.Count > 0)
                    {
                        specialityBasedObject = (SpecialityBasedObject)specialityBaseObjectList[0];//context.GetObject<PatientAdmission>(viewModel.StarterObject.ObjectID);
                        viewModel.StarterObject = specialityBasedObject;
                        patient = specialityBasedObject.PhysicianApplication.Episode.Patient;
                        viewModel._Appointment.EpisodeAction = specialityBasedObject.PhysicianApplication;
                        viewModel.ProcedureDoctor = specialityBasedObject.PhysicianApplication.ProcedureDoctor;
                    }
                }

                viewModel.currentPatient = patient;
                viewModel.currentPatient.MobilePhone = patient.PatientAddress != null ? patient.PatientAddress.MobilePhone : patient.MobilePhone;
                viewModel._Appointment.Patient = patient;
                if (patient != null)
                    viewModel.txtPatient = patient.PatientIDandFullName;
                if (Common.IsAttributeExists(typeof(AppointmentDefinitionAttribute), viewModel.StarterObject))
                {
                    IAppointmentDef starterObjectDef = (IAppointmentDef)viewModel.StarterObject;
                    List<AppointmentCarrier> objectAppointmentCarrierList = starterObjectDef.GetAppointmentCarrierList();
                    viewModel.ObjectAppointmentCarrierList = objectAppointmentCarrierList;
                    ShowAdmissionAppointment(viewModel);
                }
                else if (pa != null)
                {
                    List<AppointmentCarrier> objectAppointmentCarrierList = pa.AppointmentCarrierList;
                    viewModel.ObjectAppointmentCarrierList = objectAppointmentCarrierList;
                    ShowAdmissionAppointment(viewModel);
                }
                else if (specialityBasedObject != null)
                {
                    if (specialityBasedObject is WomanSpecialityObject)
                    {
                        List<AppointmentCarrier> objectAppointmentCarrierList = specialityBasedObject.MaternityAppointmentCarrierList;
                        viewModel.ObjectAppointmentCarrierList = objectAppointmentCarrierList;
                        ShowAdmissionAppointment(viewModel);
                    }
                }
                else
                    ShowAdmissionAppointment(viewModel);
            }
            else
                ShowAdmissionAppointment(viewModel);
        }

        void ShowAdmissionAppointment(AppointmentFormViewModel viewModel)
        {
            try
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    AdmissionAppointment admissionAppointment = (AdmissionAppointment)objectContext.CreateObject("AdmissionAppointment");
                    admissionAppointment.CurrentStateDefID = AdmissionAppointment.States.New;
                    IAdmissionAppointmentDef def = (IAdmissionAppointmentDef)admissionAppointment;
                    viewModel.AppointmentCarrierList = def.GetAppointmentCarrierList();
                    //model.TempAppointments = new List<ExtendedAppointmentInfo>();
                    viewModel.AppointmentDef = def;
                    viewModel.objectsVisible = false;
                    viewModel.lblPlannedActionsVisible = false;
                    viewModel.chkGroupPlanVisible = false;
                    viewModel.CurrentObject = (AdmissionAppointment)def;
                    FillAppointmentFormComboValues(viewModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        void ShowAppointmentListForm(AppointmentFormViewModel viewModel)
        {
            try
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    //AdmissionAppointment admissionAppointment = (AdmissionAppointment)objectContext.CreateObject("AdmissionAppointment");
                    //admissionAppointment.CurrentStateDefID = AdmissionAppointment.States.New;
                    //IAdmissionAppointmentDef def = (IAdmissionAppointmentDef)admissionAppointment;
                    //viewModel.AppointmentCarrierList = def.GetAppointmentCarrierList();
                    ////model.TempAppointments = new List<ExtendedAppointmentInfo>();
                    //viewModel.AppointmentDef = def;
                    viewModel.objectsVisible = false;
                    viewModel.lblPlannedActionsVisible = false;
                    viewModel.chkGroupPlanVisible = false;
                    viewModel.CurrentObject = null;
                    FillAppointmentFormComboValues(viewModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        void ShowStepAppointment(AppointmentFormViewModel viewModel)
        {
            try
            {
                if (viewModel._splitBySubActionProcedureAppointmentDef != null)
                {
                    //_tempAppointments = new List<ExtendedAppointmentInfo>();
                    viewModel.AppointmentDef = viewModel._splitBySubActionProcedureAppointmentDef;
                    viewModel.objectsVisible = true;
                    viewModel.lblPlannedActionsVisible = true;
                    viewModel.chkGroupPlanVisible = true;
                    FillObjectListCombo(viewModel, (TTObject)viewModel._splitBySubActionProcedureAppointmentDef, viewModel.objectsList);
                    FillAppointmentFormComboValues(viewModel);
                    viewModel.recurrenceVisible = false;
                }
                else if (viewModel._plannedAppointmentDef != null)
                {
                    //_tempAppointments = new List<ExtendedAppointmentInfo>();
                    viewModel.AppointmentDef = viewModel._plannedAppointmentDef;
                    viewModel.objectsVisible = true;
                    viewModel.lblPlannedActionsVisible = true;
                    viewModel.chkGroupPlanVisible = true;
                    FillObjectListCombo(viewModel, (TTObject)viewModel._plannedAppointmentDef, viewModel.objectsList);
                    FillAppointmentFormComboValues(viewModel);
                }
                else if (viewModel._appointmentDef != null)
                {
                    viewModel.AppointmentDef = viewModel._appointmentDef;
                    viewModel.objectsVisible = false;
                    viewModel.lblPlannedActionsVisible = false;
                    viewModel.chkGroupPlanVisible = false;
                    FillAppointmentFormComboValues(viewModel);
                    viewModel.recurrenceVisible = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        void FillObjectListCombo(AppointmentFormViewModel viewModel, TTObject masterObject, List<TTObject> siblingObjectList)
        {
            List<TTObject> siblingObjectList2 = new List<TTObject>();
            //viewModel.objectsList.Clear();
            viewModel.CurrentObject = masterObject;
            if (viewModel.CurrentObject is IPlanPlannedAction)
            {
                IPlanPlannedAction currentPlannedAction = (IPlanPlannedAction)viewModel.CurrentObject;
                //viewModel.objectsList.Add(viewModel.CurrentObject);
                siblingObjectList2.Add(viewModel.CurrentObject);
                foreach (TTObject siblingObject in siblingObjectList)
                {
                    if (siblingObject is IPlanPlannedAction)
                    {
                        IPlanPlannedAction currentSiblingAction = (IPlanPlannedAction)siblingObject;
                        siblingObjectList2.Add(siblingObject);
                        //viewModel.objectsList.Add(siblingObject);
                    }
                }
            }

            if (viewModel.CurrentObject is ISplitBySubActionProcedureAppointment)
            {
                ISplitBySubActionProcedureAppointment currentSubActionProcedure = (ISplitBySubActionProcedureAppointment)viewModel.CurrentObject;
                foreach (TTObject siblingObject in siblingObjectList)
                {
                    if (siblingObject is ISplitBySubActionProcedureAppointment)
                    {
                        ISplitBySubActionProcedureAppointment currentSiblingAction = (ISplitBySubActionProcedureAppointment)siblingObject;
                        siblingObjectList2.Add(siblingObject);
                        //viewModel.objectsList.Add(siblingObject);
                    }
                }
            }

            viewModel.objectsList.Clear();
            foreach (var item in siblingObjectList2)
            {
                viewModel.objectsList.Add(item);
            }

        }

        private void FillAppointmentFormComboValues(AppointmentFormViewModel viewModel)
        {
            FillAppointmentDefinitions(viewModel);
            FillAppointmentCarriers(viewModel);
            FillAppointmentTypes(viewModel);
            FillMasterResources(viewModel);
            FillSubResources(viewModel);
        }

        private void FillSubResources(AppointmentFormViewModel viewModel)
        {
            SubResourceInputDVO subResourceInputDVO = new SubResourceInputDVO();
            subResourceInputDVO.isKioskAppointment = false;
            if (viewModel._Appointment.AppointmentDefinition == null)
                return;
            subResourceInputDVO.appointmentCarrierObjectID = viewModel._Appointment.AppointmentCarrier.ObjectID.ToString();
            subResourceInputDVO.appointmentDefObjectID = viewModel._Appointment.AppointmentDefinition.ObjectID.ToString();
            if (viewModel._Appointment.MasterResource != null)
                subResourceInputDVO.defaultMasterResourceObjectID = viewModel._Appointment.MasterResource.ObjectID.ToString();
            subResourceInputDVO.subResourceType = viewModel._Appointment.AppointmentCarrier.SubResource;
            subResourceInputDVO.relationParentName = viewModel._Appointment.AppointmentCarrier.RelationParentName;
            subResourceInputDVO.isAppointmentListForm = viewModel.isAppointmentListForm;
            if (viewModel.ProcedureDoctor != null && viewModel.ProcedureDoctor.ObjectDef.Name.Equals(subResourceInputDVO.subResourceType.ToUpper()))
                subResourceInputDVO.defaultSubResourceObjectID = viewModel.ProcedureDoctor.ObjectID.ToString();
            SubResourceDVO subResourceDVO = FillSubResourceCombo(subResourceInputDVO);
            if (viewModel.ProcedureDoctor != null && viewModel.ProcedureDoctor.ObjectDef.Name.Equals(subResourceInputDVO.subResourceType.ToUpper()))
                subResourceDVO.defaultSubResource = viewModel.ProcedureDoctor;
            if (!viewModel.isAppointmentListForm && viewModel._Appointment.Resource == null)
            {
                viewModel._Appointment.Resource = subResourceDVO.defaultSubResource;
                if (viewModel.ObjectAppointmentCarrierList != null && viewModel.ObjectAppointmentCarrierList.Count > 0)
                {
                    Resource defaultResource = viewModel.ObjectAppointmentCarrierList[0].DefaultResource;
                    if (defaultResource != null)
                        viewModel._Appointment.Resource = defaultResource;
                }
            }
            viewModel.SubResourceList = subResourceDVO.SubResourceList;
        }

        private void FillMasterResources(AppointmentFormViewModel viewModel)
        {
            MasterResourceInputDVO masterResourceInputDVO = new MasterResourceInputDVO();
            if (viewModel._Appointment.AppointmentDefinition == null)
                return;
            masterResourceInputDVO.appointmentCarrierObjectID = viewModel._Appointment.AppointmentCarrier.ObjectID.ToString();
            masterResourceInputDVO.appointmentDefObjectID = viewModel._Appointment.AppointmentDefinition.ObjectID.ToString();
            masterResourceInputDVO.masterResourceFilter = viewModel._Appointment.AppointmentCarrier.MasterResourceFilter;
            masterResourceInputDVO.masterResourceType = viewModel._Appointment.AppointmentCarrier.MasterResource;
            if (viewModel.CurrentObject != null)
                masterResourceInputDVO.currentObjectIsPlannedAction = (viewModel.CurrentObject is IPlanPlannedAction ? true : false);
            else
                masterResourceInputDVO.currentObjectIsPlannedAction = false;
            if (masterResourceInputDVO.currentObjectIsPlannedAction)
                masterResourceInputDVO.currentPlannedActionMasterResourceID = ((IPlanPlannedAction)viewModel.CurrentObject).GetMyPlannedAction().MasterResource.ObjectID.ToString();
            masterResourceInputDVO.isAppointmentListForm = viewModel.isAppointmentListForm;
            masterResourceInputDVO.isKioskAppointment = false;
            MasterResourceDVO masterResourceDVO = FillMasterResourceCombo(masterResourceInputDVO);
            if (!viewModel.isAppointmentListForm && viewModel._Appointment.MasterResource == null)
            {
                viewModel._Appointment.MasterResource = masterResourceDVO.defaultMasterResource;
                if (viewModel.ObjectAppointmentCarrierList != null && viewModel.ObjectAppointmentCarrierList.Count > 0)
                {
                    Resource defaultMasterResource = viewModel.ObjectAppointmentCarrierList[0].DefaultMasterResource;
                    if (defaultMasterResource != null)
                        viewModel._Appointment.MasterResource = defaultMasterResource;
                }
            }
            viewModel.MasterResourceList = masterResourceDVO.MasterResourceList;
        }

        private void FillAppointmentDefinitions(AppointmentFormViewModel viewModel)
        {
            bool addDefinition;
            if (viewModel.AppointmentCarrierList.Count > 0)
            {
                viewModel.isAdmissionAppointment = false;
                AppointmentDefinition firstAppDef = viewModel.AppointmentCarrierList[0].AppointmentDefinition;
                if (firstAppDef != null)
                {
                    viewModel.AppointmentDefinitionList.Add(firstAppDef);
                    viewModel._Appointment.AppointmentDefinition = firstAppDef;
                    if (viewModel.isAppointmentListForm)
                        viewModel.AppointmentDefinitionToList = firstAppDef;
                }
            }
            else
            {
                viewModel.isAdmissionAppointment = true;
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    //Sadece kafa randevusu için
                    //viewModel.isAdmissionAppointment = true;
                    //IList defList = AppointmentDefinition.GetAdmissionAppointmentDefinitions(objectContext);
                    IList defList = AppointmentDefinition.GetAllAppointmentDefinitions(objectContext);
                    foreach (AppointmentDefinition appDef in defList)
                    {
                        addDefinition = true;
                        if (CheckAppointmentRight(appDef, Common.AppointmentCreateRightDefID, null) == false)
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
                                    viewModel._Appointment.AppointmentDefinition = (AppointmentDefinition)ad;
                                    if (viewModel.isAppointmentListForm)
                                        viewModel.AppointmentDefinitionToList = (AppointmentDefinition)ad;
                                }
                            }
                        }
                    }

                    if (viewModel.AppointmentDefinitionList.Count > 0)
                    {
                        if (viewModel._Appointment.AppointmentDefinition == null || (viewModel._Appointment.AppointmentDefinition != null && string.IsNullOrEmpty(viewModel._Appointment.AppointmentDefinition.AppDefNameDisplayText.ToString())))
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
                                {
                                    viewModel._Appointment.AppointmentDefinition = (AppointmentDefinition)appDefList[0];
                                    if (viewModel.isAppointmentListForm)
                                        viewModel.AppointmentDefinitionToList = (AppointmentDefinition)appDefList[0];
                                }
                            }
                            else
                            {
                                viewModel._Appointment.AppointmentDefinition = viewModel.AppointmentDefinitionList[0];
                                if (viewModel.isAppointmentListForm)
                                    viewModel.AppointmentDefinitionToList = viewModel.AppointmentDefinitionList[0];
                            }
                        }
                    }

                    if (viewModel.ObjectAppointmentCarrierList != null && viewModel.ObjectAppointmentCarrierList.Count > 0)
                    {
                        AppointmentDefinition defaultAppDef = viewModel.ObjectAppointmentCarrierList[0].DefaultAppointmentDefinition;
                        if (defaultAppDef != null)
                        {
                            viewModel._Appointment.AppointmentDefinition = defaultAppDef;
                            if (viewModel.isAppointmentListForm)
                                viewModel.AppointmentDefinitionToList = defaultAppDef;
                        }
                    }
                }
            }
        }

        private bool CheckAppointmentRight(AppointmentDefinition appDef, int rightDefID, Resource masterResource)
        {
            if (!String.IsNullOrEmpty(appDef.FormDefID))
            {
                TTFormDef frmDef = TTObjectDefManager.Instance.ObjectDefs["Appointment"].FormDefs[new Guid(appDef.FormDefID)];
                if (Common.CurrentUser.HasRight(frmDef, masterResource, rightDefID) == false)
                    return false;
            }

            return true;
        }

        private void FillAppointmentCarriers(AppointmentFormViewModel viewModel)
        {
            using (TTObjectContext context = new TTObjectContext(true))
            {
                AppointmentDefinition definition = viewModel._Appointment.AppointmentDefinition;
                if (definition == null)
                    return;
                if (viewModel.AppointmentCarrierList.Count == 0)
                {
                    if (viewModel.ObjectAppointmentCarrierList.Count > 0)
                    {
                        foreach (AppointmentCarrier carrier in viewModel.ObjectAppointmentCarrierList)
                        {
                            //if (carrier.IsDefault == true && viewModel.isAppointmentListForm != true)
                            if (carrier.IsDefault == true)
                            {
                                viewModel._Appointment.AppointmentCarrier = carrier;
                                if (viewModel.isAppointmentListForm)
                                    viewModel.AppointmentCarrierToList = carrier;
                            }
                            viewModel.AppointmentCarrierList.Add(carrier);
                        }
                    }
                    else
                    {
                        foreach (AppointmentCarrier carrier in definition.AppointmentCarriers)
                        {
                            //if (carrier.IsDefault == true && viewModel.isAppointmentListForm != true)
                            if (carrier.IsDefault == true)
                            {
                                viewModel._Appointment.AppointmentCarrier = carrier;
                                if (viewModel.isAppointmentListForm)
                                    viewModel.AppointmentCarrierToList = carrier;
                            }
                            viewModel.AppointmentCarrierList.Add(carrier);
                        }
                    }
                }

                if (viewModel._Appointment.AppointmentCarrier == null && viewModel.AppointmentCarrierList.Count > 0)
                {
                    viewModel._Appointment.AppointmentCarrier = viewModel.AppointmentCarrierList[0];
                    if (viewModel.isAppointmentListForm)
                        viewModel.AppointmentCarrierToList = viewModel.AppointmentCarrierList[0];
                    viewModel._Appointment.AppointmentCarrier.AppointmentCount = viewModel.AppointmentCarrierList[0].AppointmentCount;
                    viewModel._Appointment.AppointmentCarrier.AppointmentDuration = viewModel.AppointmentCarrierList[0].AppointmentDuration;
                    viewModel._Appointment.AppointmentCarrier.AppointmentType = viewModel.AppointmentCarrierList[0].AppointmentType;
                    viewModel._Appointment.AppointmentCarrier.MasterResourceFilter = viewModel.AppointmentCarrierList[0].MasterResourceFilter;
                }
            }
        }

        private void FillAppointmentTypes(AppointmentFormViewModel viewModel)
        {
            using (TTObjectContext context = new TTObjectContext(true))
            {
                AppointmentCarrier carrier = viewModel._Appointment.AppointmentCarrier;
                if (carrier == null)
                    return;
                foreach (AppointmentType appType in carrier.AppointmentTypes)
                {
                    AppointmentTypeListDVO appointmentTypeListDVO = new AppointmentTypeListDVO();
                    appointmentTypeListDVO.AppointmentType = appType;
                    appointmentTypeListDVO.AppointmentTypeEnumValue = appType.Type;
                    appointmentTypeListDVO.AppointmentTypeDisplayText = (appType.Type.HasValue ? TTObjectClasses.Common.GetEnumValueDefOfEnumValue(appType.Type).DisplayText : null);
                    viewModel.AppointmentTypeList.Add(appointmentTypeListDVO);
                }

                if (viewModel._Appointment.AppointmentType == null && viewModel.AppointmentTypeList.Count > 0)
                {
                    viewModel.AppointmentType = viewModel.AppointmentTypeList[0];
                }

                //if (viewModel.CurrentObjectAppointmentCarrierList != null && viewModel.CurrentObjectAppointmentCarrierList.Count > 0)
                //{
                //    AppointmentType defaultAppType = viewModel.CurrentObjectAppointmentCarrierList[0].DefaultAppointmentType;
                //    if (defaultAppType != null)
                //        viewModel.AppointmentType = defaultAppType;
                //}

            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public AppointmentCarrierDVO FillAppointmentCarrierCombo(string appointmentDefObjectID, bool isAppointmentListForm)
        {
            using (TTObjectContext context = new TTObjectContext(true))
            {
                AppointmentCarrierDVO appointmentCarrierDVO = new AppointmentCarrierDVO();
                appointmentCarrierDVO.AppointmentCarrierList = new List<AppointmentCarrier>();
                appointmentCarrierDVO.defaultCarrier = new AppointmentCarrier(context);
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

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public AppointmentTypeDVO FillAppointmentTypeCombo(string appointmentCarrierObjectID, bool isAppointmentListForm)
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
                    appointmentTypeDVO.AppointmentTypeList.Add(appointmentTypeListDVO);
                }

                context.FullPartialllyLoadedObjects();
            }

            if (appointmentTypeDVO.AppointmentTypeList.Count > 0 && isAppointmentListForm != true)
            {
                appointmentTypeDVO.defaultAppType = appointmentTypeDVO.AppointmentTypeList[0];
            }

            return appointmentTypeDVO;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public MasterResourceDVO FillMasterResourceCombo(MasterResourceInputDVO masterResourceInputDVO)
        {
            MasterResourceDVO masterResourceDVO = new MasterResourceDVO();
            masterResourceDVO.defaultMasterResource = null; // new ResSection();
            masterResourceDVO.MasterResourceList = new List<Resource>();
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            AppointmentDefinition appDef = readOnlyContext.GetObject<AppointmentDefinition>(new Guid(masterResourceInputDVO.appointmentDefObjectID));
            AppointmentCarrier appCarrier = readOnlyContext.GetObject<AppointmentCarrier>(new Guid(masterResourceInputDVO.appointmentCarrierObjectID));
            bool addMasterResource = true;
            if (String.IsNullOrEmpty(masterResourceInputDVO.masterResourceFilter))
                masterResourceInputDVO.masterResourceFilter += " ISACTIVE = 1";
            else
                masterResourceInputDVO.masterResourceFilter += " AND ISACTIVE = 1";

            //Kioskta uzmanlık dalına göre seçmek istendiğinde dolu gelecek
            if (!String.IsNullOrEmpty(masterResourceInputDVO.defaultSpecialityObjectID))
            {
                masterResourceInputDVO.masterResourceFilter += " AND ResourceSpecialities(SPECIALITY = '" + masterResourceInputDVO.defaultSpecialityObjectID + "').EXISTS ";
            }

            IList masterResourceList = readOnlyContext.QueryObjects(masterResourceInputDVO.masterResourceType, masterResourceInputDVO.masterResourceFilter, "NAME ASC");
            int i = 0;
            masterResourceDVO.SpecialityList = new List<SpecialityDefinition>();
            foreach (ResSection section in masterResourceList)
            {
                addMasterResource = true;
                if (CheckAppointmentRight(appDef, Common.AppointmentCreateRightDefID, section) == false && CheckAppointmentRight(appDef, Common.AppointmentPrintRightDefID, section) == false) // Create = 2003 ; Print = 2004
                    addMasterResource = false;

                //Sadece 1 hafta içinde boş slotu olan kaynakların poliklinikleri ve uzmanlık dalları gelsin diye kiosk için eklendi.
                
                if (masterResourceInputDVO.isKioskAppointment)
                {
                    bool hasAvailableResource = false;
                    foreach (UserResource userResource in section.ResourceUsers)
                    {
                        foreach (AppointmentCarrierUserTypes userTypes in appCarrier.AppointmentCarrierUserTypes)
                        {
                            if (userResource.User.UserType == userTypes.UserType)
                            {
                                hasAvailableResource = this.IsResourceAvailableToAppointment(userResource.User, masterResourceInputDVO.isKioskAppointment,section.ObjectID);
                                if (hasAvailableResource)
                                    break;
                            }
                        }
                        if (hasAvailableResource)
                            break;
                    }
                    if (!hasAvailableResource)
                        addMasterResource = false;
                }
                

                if (addMasterResource == true)
                {
                    section.ResourceColor = CommonServiceController.GetRandomSpecificColor(i);
                    masterResourceDVO.MasterResourceList.Add(section);
                    i++;
                    if (masterResourceInputDVO.isKioskAppointment)
                    {

                        foreach (ResourceSpecialityGrid rsp in section.ResourceSpecialities)
                        {
                            if (masterResourceDVO.SpecialityList.Exists(x => x.ObjectID.Equals(rsp.Speciality.ObjectID)) == false)
                                masterResourceDVO.SpecialityList.Add(rsp.Speciality);
                        }
                    }
                }
            }

            if (masterResourceDVO.MasterResourceList.Count > 0)
            {
                //if (masterResourceInputDVO.currentObject is IPlanPlannedAction)
                if (masterResourceInputDVO.currentObjectIsPlannedAction)
                {
                    ResSection currenObjMasterResource = readOnlyContext.GetObject<ResSection>(new Guid(masterResourceInputDVO.currentPlannedActionMasterResourceID)); //((IPlanPlannedAction)masterResourceInputDVO.currentObject).MyPlannedAction.MasterResource as ResSection;
                    foreach (ResSection section in masterResourceDVO.MasterResourceList)
                    {
                        if (section.ObjectID.Equals(currenObjMasterResource.ObjectID) && masterResourceInputDVO.isAppointmentListForm != true)
                        {
                            masterResourceDVO.defaultMasterResource = section;
                            break;
                        }
                    }
                    if (masterResourceDVO.defaultMasterResource == null || (masterResourceDVO.defaultMasterResource != null && string.IsNullOrEmpty(masterResourceDVO.defaultMasterResource.Name.ToString())))
                    {
                        if (masterResourceDVO.MasterResourceList.Count > 0 && masterResourceInputDVO.isAppointmentListForm != true)
                            masterResourceDVO.defaultMasterResource = masterResourceDVO.MasterResourceList[0];
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(masterResourceInputDVO.defaultMasterResourceObjectID))
                    {
                        ResSection defaultMasterResource = readOnlyContext.GetObject<ResSection>(new Guid(masterResourceInputDVO.defaultMasterResourceObjectID));
                        if (defaultMasterResource != null)
                            masterResourceDVO.defaultMasterResource = defaultMasterResource;
                    }
                    else
                    {
                        foreach (ResSection section in masterResourceDVO.MasterResourceList)
                        {
                            foreach (ResSection sec in Common.CurrentResource.SelectedResources)
                            {
                                if (section.ObjectID == sec.ObjectID && masterResourceInputDVO.isAppointmentListForm != true)
                                {
                                    masterResourceDVO.defaultMasterResource = section;
                                    break;
                                }
                            }
                        }
                    }
                    if (masterResourceDVO.defaultMasterResource == null || (masterResourceDVO.defaultMasterResource != null && string.IsNullOrEmpty(masterResourceDVO.defaultMasterResource.Name.ToString())))
                    {
                        if (masterResourceDVO.MasterResourceList.Count > 0 && masterResourceInputDVO.isAppointmentListForm != true)
                            masterResourceDVO.defaultMasterResource = masterResourceDVO.MasterResourceList[0];
                    }
                }
            }

            readOnlyContext.FullPartialllyLoadedObjects();
            return masterResourceDVO;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public SubResourceDVO FillSubResourceCombo(SubResourceInputDVO subResourceInputDVO)
        {
            bool isUserTypeAllowed;
            SubResourceDVO subResourceDVO = new SubResourceDVO();
            subResourceDVO.defaultSubResource = null;
            //if (subResourceInputDVO.subResourceType.ToUpperInvariant() == "RESUSER")
            //    subResourceDVO.defaultSubResource = new ResUser();
            //else
            //    subResourceDVO.defaultSubResource = new ResSection();
            subResourceDVO.SubResourceList = new List<Resource>();
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            AppointmentDefinition appDef = readOnlyContext.GetObject<AppointmentDefinition>(new Guid(subResourceInputDVO.appointmentDefObjectID));
            AppointmentCarrier appCarrier = readOnlyContext.GetObject<AppointmentCarrier>(new Guid(subResourceInputDVO.appointmentCarrierObjectID));
            if (String.IsNullOrEmpty(subResourceInputDVO.defaultMasterResourceObjectID) == false)
            {
                ResSection masterResource = readOnlyContext.GetObject<ResSection>(new Guid(subResourceInputDVO.defaultMasterResourceObjectID));
                bool isExists = false;
                if (appDef.GiveToMaster == true)
                {
                    isExists = subResourceDVO.SubResourceList.Exists(o => o.ObjectID.ToString() == masterResource.ObjectID.ToString());
                    if (!isExists)
                    {
                        //TODO buraya bak
                        if (this.IsResourceAvailableToAppointment(masterResource, subResourceInputDVO.isKioskAppointment, masterResource.ObjectID))
                        {
                            masterResource.ResourceColor = CommonServiceController.GetRandomSpecificColor(0);
                            subResourceDVO.SubResourceList.Add(masterResource);
                        }
                    }
                }
                else
                {
                    int i = 0;
                    if (!String.IsNullOrEmpty(subResourceInputDVO.relationParentName))
                    {
                        IList subResList = readOnlyContext.QueryObjects(subResourceInputDVO.subResourceType, subResourceInputDVO.relationParentName + " = '" + masterResource.ObjectID.ToString() + "' AND ISACTIVE = 1 ORDER BY NAME ASC");
                        foreach (ResSection section in subResList)
                        {
                            isExists = subResourceDVO.SubResourceList.Exists(o => o.ObjectID.ToString() == section.ObjectID.ToString());
                            if (!isExists)
                            {
                                if (this.IsResourceAvailableToAppointment(section, subResourceInputDVO.isKioskAppointment,masterResource.ObjectID))
                                {
                                    section.ResourceColor = CommonServiceController.GetRandomSpecificColor(i);
                                    subResourceDVO.SubResourceList.Add(section);
                                    i++;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (subResourceInputDVO.subResourceType.ToUpperInvariant() == "RESUSER")
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
                                            if (this.IsResourceAvailableToAppointment(resUser, subResourceInputDVO.isKioskAppointment,masterResource.ObjectID))
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
            }
            else
            {
                //Bu kısım Kiosk için eklendi. Poliklinik seçmeden doktor seçilmek istendiği için.
                IList subResList = readOnlyContext.QueryObjects(subResourceInputDVO.subResourceType, " ISACTIVE = 1 ORDER BY NAME ASC");
                foreach (ResUser resUser in subResList)
                {
                    foreach (AppointmentCarrierUserTypes appCarrierUserType in appCarrier.AppointmentCarrierUserTypes)
                    {
                        if (appCarrierUserType.UserType == resUser.UserType)
                        {
                            bool isExists = subResourceDVO.SubResourceList.Exists(o => o.ObjectID.ToString() == resUser.ObjectID.ToString());
                            if (!isExists)
                            {
                                if (this.IsResourceAvailableToAppointment(resUser, subResourceInputDVO.isKioskAppointment,null))
                                {
                                    subResourceDVO.SubResourceList.Add(resUser);
                                }
                            }
                        }
                    }
                }
            }
            if (subResourceDVO.SubResourceList.Count > 0 && subResourceInputDVO.isAppointmentListForm != true)
            {
                if (!String.IsNullOrEmpty(subResourceInputDVO.defaultSubResourceObjectID))
                {
                    Resource subResource = readOnlyContext.GetObject<Resource>(new Guid(subResourceInputDVO.defaultSubResourceObjectID));
                    subResourceDVO.defaultSubResource = subResource;
                }
                else
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
                                break;
                            }
                        }
                    }
                }
            }

            readOnlyContext.FullPartialllyLoadedObjects();
            return subResourceDVO;
        }

        //Sadece 1 hafta içinde boş slotu olan kaynaklar, poliklinikler ve uzmanlık dallar gelsin diye kiosk için eklendi.
        internal bool IsResourceAvailableToAppointment(Resource resource, bool isKiosk, Guid? masterOwnerObjectID)
        {
            if (!isKiosk)
                return true;
            AppointmentInputDVO appointmentInputDVO = new AppointmentInputDVO();
            appointmentInputDVO.AppDate = Common.RecTime();
            appointmentInputDVO.SelectedOwnerResources = new List<Guid>();
            appointmentInputDVO.SelectedOwnerResources.Add(resource.ObjectID);
            if (masterOwnerObjectID != null)
                appointmentInputDVO.masterOwnerObjectID = masterOwnerObjectID.Value;
            appointmentInputDVO.currentView = TTObjectClasses.SystemParameter.GetParameterValue("KIOSKDEFAULTAPPVIEW","month");
            GivenAppointmentsAndSchedules givenAppointmentsAndSchedules = this.GetEmptyWorkingSchedules(appointmentInputDVO);
            if (givenAppointmentsAndSchedules.GivenAppointments == null || givenAppointmentsAndSchedules.GivenAppointments.Count == 0)
                return false;
            return true;
        }

        /// <summary>
        /// Verilen tarihin yılın kaçıncı haftasında olduğunu döndürür.
        /// </summary>
        /// <param name = "currentDate"></param>
        /// <returns></returns>
        public int GetWeekNumber(DateTime currentDate)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        /// <summary>
        /// Verilen tarihin haftanın hangi günü olduğunu DayOfWeek türünde döndürür.
        /// </summary>
        /// <param name = "currentDate"></param>
        /// <returns></returns>
        public DayOfWeek GetDayOfWeek(DateTime currentDate)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            DayOfWeek dayOfWeek = ciCurr.Calendar.GetDayOfWeek(currentDate);
            return dayOfWeek;
        }

        /// <summary>
        /// Verilen tarihin bulunduğu haftanın ilk gününün tarihini döndürür.
        /// </summary>
        /// <param name = "currentDate"></param>
        /// <returns></returns>
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

        GivenAppointmentsAndSchedules _givenAppointmentsAndSchedules;
        GivenAppointmentsAndSchedules givenAppointmentsAndSchedules
        {
            get
            {
                return _givenAppointmentsAndSchedules;
            }

            set
            {
                _givenAppointmentsAndSchedules = value;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public GivenAppointmentsAndSchedules GetAppointmentsAndSchedules(AppointmentInputDVO appointmentInputDVO)
        {
            givenAppointmentsAndSchedules = new GivenAppointmentsAndSchedules();
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            if (appointmentInputDVO.currentView == "day")
            {
                startDate = appointmentInputDVO.AppDate.Date;
                endDate = startDate.AddDays(1).AddMinutes(-1);
            }
            else if (appointmentInputDVO.currentView == "month")
            {
                startDate = GetFirstDateOfMonth(appointmentInputDVO.AppDate.Date);
                endDate = GetLastDateOfMonth(startDate);
            }
            else
            {
                startDate = GetFirstDateOfWeek(appointmentInputDVO.AppDate.Date);
                endDate = startDate.AddDays(7);
            }
            givenAppointmentsAndSchedules.GivenAppointments = new List<GivenAppointment>();
            givenAppointmentsAndSchedules.MasterResources = new List<GivenResource>();
            givenAppointmentsAndSchedules.SubResources = new List<GivenResource>();
            givenAppointmentsAndSchedules.AppOrSchTypes = new List<AppOrSchType>();
            try
            {
                foreach (Guid ownerResource in appointmentInputDVO.SelectedOwnerResources)
                {
                    using (TTObjectContext context = new TTObjectContext(true))
                    {
                        Resource appResource = context.GetObject<Resource>(ownerResource);
                        Resource appMasterResource = context.GetObject<Resource>(appointmentInputDVO.masterOwnerObjectID);
                        if (!appointmentInputDVO.showAppointmentsOfPatient)
                        {
                            bool isExistsMasRes = givenAppointmentsAndSchedules.MasterResources.Exists(o => o.id.ToString() == appMasterResource.ObjectID.ToString());
                            if (!isExistsMasRes)
                            {
                                GivenResource givenMasterResource = new GivenResource();
                                givenMasterResource.id = appMasterResource.ObjectID;
                                givenMasterResource.text = appMasterResource.Name;
                                ResourceAndColorDVO appMasterResourceFromList = appointmentInputDVO.AllResourcesAndColors.FirstOrDefault(o => o.resourceObjectID.ToString() == appMasterResource.ObjectID.ToString());
                                if (appMasterResourceFromList != null)
                                    givenMasterResource.color = appMasterResourceFromList.resourceColor;
                                givenAppointmentsAndSchedules.MasterResources.Add(givenMasterResource);
                            }
                        }

                        string injectionStr = "";
                        //injectionStr = " AND MASTERRESOURCE = '" + appointmentInputDVO.ownerObjectID.ToString() + "' ";
                        injectionStr += " AND CURRENTSTATEDEFID <> '" + Appointment.States.Cancelled + "' ORDER BY STARTTIME";
                        IBindingList apps = Appointment.GetByAppDateAndResource(context, Convert.ToDateTime(startDate.Date), Convert.ToDateTime(endDate.Date), ownerResource.ToString(), injectionStr);
                        //IBindingList apps = Appointment.GetByAppDate(context, Convert.ToDateTime(startDate.Date), Convert.ToDateTime(endDate.Date), injectionStr);
                        foreach (Appointment app in apps)
                        {
                            DateTime startDateTime = (DateTime)app.StartTime;
                            DateTime endDateTime = (DateTime)app.EndTime;
                            GivenAppointment givenApp = new GivenAppointment();
                            givenApp.startDate = startDateTime;
                            givenApp.endDate = endDateTime;
                            givenApp.objectID = app.ObjectID.ToString();
                            givenApp.ownerObjectID = ownerResource;
                            givenApp.ownerObject = app.Resource;

                            string procedureObjectName = string.Empty;
                            if (app.SubActionProcedure != null && app.SubActionProcedure.ProcedureObject != null)
                                procedureObjectName = "İşlem:" + app.SubActionProcedure.ProcedureObject.Name + " ";


                            if (app.Patient != null)
                            {
                                givenApp.text = procedureObjectName + "Hasta : " + app.Patient.PatientIDandFullName + " " + app.Notes;
                                givenApp.patient = app.Patient;
                                givenApp.txtPatient = app.Patient.PatientIDandFullName;

                                if (app.Patient.Privacy.HasValue && app.Patient.Privacy.Value == true)
                                {
                                    if (app.Patient.PrivacyUniqueRefNo.HasValue)
                                        givenApp.TCKNo = app.Patient.PrivacyUniqueRefNo.Value;

                                    givenApp.PhoneNumber = app.Patient.PrivacyMobilePhone;
                                }
                                else
                                {
                                    if (app.Patient.UniqueRefNo.HasValue)
                                        givenApp.TCKNo = app.Patient.UniqueRefNo.Value;
                                    if (app.Patient.PatientAddress != null)
                                        givenApp.PhoneNumber = app.Patient.PatientAddress.MobilePhone;
                                }

                                givenApp.osPhoneType = PhoneTypeEnum.GSM;
                            }
                            else
                            {
                                if (app.Action != null && app.Action is AdmissionAppointment)
                                {
                                    AdmissionAppointment admissionApp = (AdmissionAppointment)app.Action;
                                    givenApp.text = procedureObjectName + "Hasta : " + admissionApp.PatientNameSurname + " " + app.Notes;
                                    givenApp.patient = null;
                                    givenApp.txtPatient = (admissionApp.PatientUniqueRefNo.HasValue ? admissionApp.PatientUniqueRefNo.Value.ToString() + " " : String.Empty) + admissionApp.PatientNameSurname;
                                    givenApp.TCKNo = admissionApp.PatientUniqueRefNo;
                                    givenApp.PhoneNumber = admissionApp.PatientPhone;
                                    givenApp.osPhoneType = admissionApp.PhoneType;
                                }
                            }

                            givenApp.masterOwnerObjectID = app.MasterResource.ObjectID;
                            givenApp.objectDefID = app.ObjectDef.ID.ToString();
                            givenApp.objectDefName = app.ObjectDef.Name;
                            if (app.CurrentStateDefID == Appointment.States.Completed)
                            {
                                givenApp.text = "KABUL ALINDI!" + "  " + givenApp.text;
                                givenApp.color = "#f5f5f5";
                                givenApp.enabled = false;
                            }
                            else
                            {
                                ResourceAndColorDVO appResourceFromList = appointmentInputDVO.AllResourcesAndColors.FirstOrDefault(o => o.resourceObjectID.ToString() == app.Resource.ObjectID.ToString());
                                if (appResourceFromList != null)
                                    givenApp.color = appResourceFromList.resourceColor;
                                givenApp.enabled = true;
                            }
                            AppOrSchType appOrSchType = new AppOrSchType();
                            appOrSchType.text = "";
                            appOrSchType.id = app.ObjectDef.ID.ToString();
                            givenAppointmentsAndSchedules.AppOrSchTypes.Add(appOrSchType);
                            givenApp.appOrSchTypeID = appOrSchType.id;
                            givenApp.notes += app.Notes;
                            givenApp.appCategory = app.AppointmentDefinition != null ? app.AppointmentDefinition.AppDefNameDisplayText : "";
                            givenApp.strAppDate = app.AppDate.HasValue ? app.AppDate.Value.ToShortDateString() : "";
                            givenApp.strAppTime = (app.StartTime.HasValue && app.EndTime.HasValue) ? app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() : "";
                            givenApp.appResources = app.Resource != null ? app.Resource.Name : "";
                            givenApp.appStatus = app.CurrentStateDef != null ? app.CurrentStateDef.DisplayText : "";
                            givenApp.strType = "DOLU";
                            //givenApp.rowColor = "#f5f5f5";
                            givenApp.rowButtonType = 1;//Güncelle butonu çıkacak.

                            givenAppointmentsAndSchedules.GivenAppointments.Add(givenApp);
                            if (appointmentInputDVO.showAppointmentsOfPatient)
                            {
                                bool isExistsMasRes = givenAppointmentsAndSchedules.MasterResources.Exists(o => o.id.ToString() == app.MasterResource.ObjectID.ToString());
                                if (!isExistsMasRes)
                                {
                                    GivenResource givenMasterResource = new GivenResource();
                                    givenMasterResource.id = app.MasterResource.ObjectID;
                                    givenMasterResource.text = app.MasterResource.Name;
                                    ResourceAndColorDVO appMasterResourceFromList = appointmentInputDVO.AllResourcesAndColors.FirstOrDefault(o => o.resourceObjectID.ToString() == app.MasterResource.ObjectID.ToString());
                                    if (appMasterResourceFromList != null)
                                        givenMasterResource.color = appMasterResourceFromList.resourceColor;
                                    givenAppointmentsAndSchedules.MasterResources.Add(givenMasterResource);
                                }
                            }
                        }

                        bool isExistsRes = givenAppointmentsAndSchedules.SubResources.Exists(o => o.id.ToString() == appResource.ObjectID.ToString());
                        if (!isExistsRes)
                        {
                            GivenResource givenSubResource = new GivenResource();
                            givenSubResource.id = appResource.ObjectID;
                            givenSubResource.text = appResource.Name;
                            ResourceAndColorDVO appResourceFromList = appointmentInputDVO.AllResourcesAndColors.FirstOrDefault(o => o.resourceObjectID.ToString() == appResource.ObjectID.ToString());
                            if (appResourceFromList != null)
                                givenSubResource.color = appResourceFromList.resourceColor;
                            givenAppointmentsAndSchedules.SubResources.Add(givenSubResource);
                        }

                        IBindingList schedules = Schedule.GetByScheduleDateAndResource(context, startDate.Date, endDate.Date, ownerResource.ToString());
                        foreach (Schedule sch in schedules)
                        {
                            if (sch.ScheduleType == ScheduleTypeEnum.NonWorkingHour)
                            {
                                List<GivenAppointment> givenSchedules = FillSchedulesToCalendar(sch, apps);
                                givenAppointmentsAndSchedules.GivenAppointments.AddRange(givenSchedules);
                            }
                            else
                            {
                                //foreach (ScheduleAppointmentType schAppType in sch.ScheduleAppointmentTypes)
                                //{
                                //    if (appointmentInputDVO.appointmentType.HasValue)
                                //        if (schAppType.AppointmentType.Value == appointmentInputDVO.appointmentType.Value)
                                //        {
                                List<GivenAppointment> givenSchedules = FillSchedulesToCalendar(sch, apps);
                                givenAppointmentsAndSchedules.GivenAppointments.AddRange(givenSchedules);
                                //        }
                                //}
                            }
                        }

                        context.FullPartialllyLoadedObjects();
                    }
                    //TODO : tempapp ne işe yarıyor araştır
                    //if (_tempAppointments != null)
                    //{
                    //    for (int i = 0; i < _tempAppointments.Count; i++)
                    //    {
                    //        _tempAppointments[i].Appointment.Owner = _tempAppointments[i].Owner; //Cloned
                    //        this.ultraCalendarInfo.Appointments.Add(_tempAppointments[i].Appointment);
                    //    }
                    //}
                }

                return givenAppointmentsAndSchedules;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public GivenAppointmentsAndSchedules GetEmptyWorkingSchedules(AppointmentInputDVO appointmentInputDVO)
        {
            givenAppointmentsAndSchedules = new GivenAppointmentsAndSchedules();
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            startDate = appointmentInputDVO.AppDate.Date;
            if (appointmentInputDVO.currentView == "day")
            {
                
                endDate = startDate.AddDays(1).AddMinutes(-1);
            }
            else if (appointmentInputDVO.currentView == "month")
            {
                //startDate = GetFirstDateOfMonth(appointmentInputDVO.AppDate.Date);
                endDate = startDate.AddDays(30);// GetLastDateOfMonth(startDate);
            }
            else
            {
                //startDate = GetFirstDateOfWeek(appointmentInputDVO.AppDate.Date);
                endDate = startDate.AddDays(7);
            }
            givenAppointmentsAndSchedules.GivenAppointments = new List<GivenAppointment>();
            givenAppointmentsAndSchedules.MasterResources = new List<GivenResource>();
            givenAppointmentsAndSchedules.SubResources = new List<GivenResource>();
            givenAppointmentsAndSchedules.AppOrSchTypes = new List<AppOrSchType>();
            try
            {
                foreach (Guid ownerResource in appointmentInputDVO.SelectedOwnerResources)
                {
                    using (TTObjectContext context = new TTObjectContext(true))
                    {
                        Resource appResource = context.GetObject<Resource>(ownerResource);

                        string injectionStr = "";
                        injectionStr += " AND CURRENTSTATEDEFID <> '" + Appointment.States.Cancelled + "' ORDER BY STARTTIME";
                        IBindingList apps = Appointment.GetByAppDateAndResource(context, Convert.ToDateTime(startDate.Date), Convert.ToDateTime(endDate.Date), ownerResource.ToString(), injectionStr);
                        IBindingList schedules = Schedule.GetByScheduleDateAndResource(context, startDate.Date, endDate.Date, ownerResource.ToString());
                        foreach (Schedule sch in schedules)
                        {
                            if (sch.ScheduleType != ScheduleTypeEnum.NonWorkingHour)
                            {
                                List<GivenAppointment> givenSchedules = FillSchedulesToCalendar(sch, apps);
                                foreach (GivenAppointment givenSchedule in givenSchedules)
                                {
                                    if (givenSchedule.startDate > Common.RecTime())
                                    {
                                        bool addToArray = true;
                                        if (appointmentInputDVO.masterOwnerObjectID.Equals(Guid.Empty) == false && appointmentInputDVO.masterOwnerObjectID.Equals(givenSchedule.masterOwnerObjectID) == false)
                                            addToArray = false;
                                        if(addToArray)
                                            givenAppointmentsAndSchedules.GivenAppointments.Add(givenSchedule);
                                    }
                                }
                            }
                        }

                        context.FullPartialllyLoadedObjects();
                    }
                }

                if (givenAppointmentsAndSchedules.GivenAppointments != null && givenAppointmentsAndSchedules.GivenAppointments.Count > 0)
                    givenAppointmentsAndSchedules.GivenAppointments = givenAppointmentsAndSchedules.GivenAppointments.OrderBy(p => p.startDate).ToList(); 

                return givenAppointmentsAndSchedules;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private List<GivenAppointment> FillSchedulesToCalendar(Schedule sch, IBindingList apps)
        {
            List<GivenAppointment> givenSchedules = new List<GivenAppointment>();
            DateTime gapStart = (DateTime)sch.StartTime;
            DateTime gapEnd = (DateTime)sch.EndTime;
            string schMasResName = String.Empty;
            if (sch.MasterResource != null)
                schMasResName = sch.MasterResource.Name;
            if (sch.IsWorkHour == false)
            {
                string strDef = "ÇALIŞILMAYAN SAAT";
                string strType = String.Empty;
                foreach (ScheduleAppointmentType schAppType in sch.ScheduleAppointmentTypes)
                    strType += TTObjectClasses.Common.GetEnumValueDefOfEnumValue(schAppType.AppointmentType).DisplayText + ";";
                GivenAppointment scheduleAppointment = new GivenAppointment();
                scheduleAppointment.text = strDef; // +strSubject;
                scheduleAppointment.startDate = gapStart;
                scheduleAppointment.endDate = gapEnd;
                scheduleAppointment.objectID = sch.ObjectID.ToString();
                //TODO : ?
                //scheduleAppointment.Locked = true;
                scheduleAppointment.objectDefID = sch.ObjectDef.ID.ToString();
                scheduleAppointment.objectDefName = sch.ObjectDef.Name;
                AppOrSchType appOrSchType = new AppOrSchType();
                appOrSchType.text = "";
                appOrSchType.id = "NONWORKHOUR" + sch.Resource.ObjectID.ToString();
                givenAppointmentsAndSchedules.AppOrSchTypes.Add(appOrSchType);
                scheduleAppointment.appOrSchTypeID = appOrSchType.id;
                scheduleAppointment.color = "#e06b6b";
                scheduleAppointment.masterOwnerObjectID = sch.MasterResource.ObjectID;
                scheduleAppointment.ownerObjectID = sch.Resource.ObjectID;
                scheduleAppointment.ownerObject = sch.Resource;

                scheduleAppointment.appCategory = sch.AppointmentDefinition != null ? sch.AppointmentDefinition.AppDefNameDisplayText : "";
                scheduleAppointment.strAppDate = sch.ScheduleDate.HasValue ? sch.ScheduleDate.Value.ToShortDateString() : "";
                scheduleAppointment.strAppTime = (sch.StartTime.HasValue && sch.EndTime.HasValue) ? sch.StartTime.Value.ToShortTimeString() + " - " + sch.EndTime.Value.ToShortTimeString() : "";
                scheduleAppointment.appResources = sch.Resource != null ? sch.Resource.Name : "";
                scheduleAppointment.appStatus = sch.CurrentStateDef != null ? sch.CurrentStateDef.DisplayText : "";
                scheduleAppointment.strType = strDef;
                scheduleAppointment.rowColor = "#d9534f";
                scheduleAppointment.rowButtonType = 3;//hiç buton çıkmayacak.
                //TODO:?
                //scheduleAppointment.recurrenceRule = sch.RecurrenceID
                givenSchedules.Add(scheduleAppointment);
            }

            if (sch.Duration > 0)
            {
                foreach (Appointment app in apps)
                {
                    if (((app.StartTime >= sch.StartTime && app.StartTime <= sch.EndTime) || (app.EndTime >= sch.StartTime && app.EndTime <= sch.EndTime) || (app.StartTime <= sch.EndTime && app.EndTime >= sch.EndTime)) && app.BreakAppointment == false)
                    {
                        if (gapStart > app.StartTime)
                            gapStart = (DateTime)app.EndTime;
                        if (gapStart > app.EndTime)
                            gapStart = (DateTime)app.EndTime;
                        if (gapEnd > app.StartTime)
                            gapEnd = (DateTime)app.StartTime;
                        while (sch.Duration <= gapEnd.Subtract(gapStart).TotalMinutes)
                        {
                            DateTime startTime = gapStart;
                            string strTime = gapStart.ToShortTimeString() + " - ";
                            gapStart = gapStart.AddMinutes(Convert.ToDouble(sch.Duration));
                            strTime += gapStart.ToShortTimeString();
                            string strType = String.Empty;
                            foreach (ScheduleAppointmentType schAppType in sch.ScheduleAppointmentTypes)
                                strType += TTObjectClasses.Common.GetEnumValueDefOfEnumValue(schAppType.AppointmentType).DisplayText + ";";
                            GivenAppointment scheduleAppointment = new GivenAppointment();
                            scheduleAppointment.startDate = startTime;
                            scheduleAppointment.endDate = gapStart;
                            scheduleAppointment.text = schMasResName + "\r\n\r\n" + sch.Resource.Name + "\r\n\r\n" + strType; // +strSubject;
                            scheduleAppointment.objectID = sch.ObjectID.ToString();
                            scheduleAppointment.objectDefName = sch.ObjectDef.Name;
                            //TODO
                            //scheduleAppointment.Locked = true;
                            scheduleAppointment.objectDefID = sch.ObjectDef.ID.ToString();
                            AppOrSchType appOrSchType = new AppOrSchType();
                            appOrSchType.text = "";
                            appOrSchType.id = "WITHWORKHOUR" + sch.Resource.ObjectID.ToString();
                            givenAppointmentsAndSchedules.AppOrSchTypes.Add(appOrSchType);
                            scheduleAppointment.appOrSchTypeID = appOrSchType.id;
                            scheduleAppointment.color = "#5ba1d0";
                            scheduleAppointment.masterOwnerObjectID = sch.MasterResource.ObjectID;
                            scheduleAppointment.ownerObjectID = sch.Resource.ObjectID;
                            scheduleAppointment.ownerObject = sch.Resource;

                            scheduleAppointment.appCategory = sch.AppointmentDefinition != null ? sch.AppointmentDefinition.AppDefNameDisplayText : "";
                            scheduleAppointment.strAppDate = sch.ScheduleDate.HasValue ? sch.ScheduleDate.Value.ToShortDateString() : "";
                            scheduleAppointment.strAppTime = strTime;
                            scheduleAppointment.appResources = sch.Resource != null ? sch.Resource.Name : "";
                            scheduleAppointment.appStatus = sch.CurrentStateDef != null ? sch.CurrentStateDef.DisplayText : "";
                            scheduleAppointment.strType = "SAATLİ";
                            scheduleAppointment.rowColor = "#007ab7";
                            scheduleAppointment.rowButtonType = 2;//randevu ver butonu çıkacak
                            givenSchedules.Add(scheduleAppointment);
                        }

                        gapStart = (DateTime)app.EndTime;
                        gapEnd = (DateTime)sch.EndTime;
                    }
                }

                while (sch.Duration <= gapEnd.Subtract(gapStart).TotalMinutes)
                {
                    DateTime startTime = gapStart;
                    string strTime = gapStart.ToShortTimeString() + " - ";
                    gapStart = gapStart.AddMinutes(Convert.ToDouble(sch.Duration));
                    strTime += gapStart.ToShortTimeString();
                    string strType = String.Empty;
                    foreach (ScheduleAppointmentType schAppType in sch.ScheduleAppointmentTypes)
                        strType += TTObjectClasses.Common.GetEnumValueDefOfEnumValue(schAppType.AppointmentType).DisplayText + ";";
                    GivenAppointment scheduleAppointment = new GivenAppointment();
                    scheduleAppointment.startDate = startTime;
                    scheduleAppointment.endDate = gapStart;
                    scheduleAppointment.text = schMasResName + "\r\n\r\n" + sch.Resource.Name + "\r\n\r\n" + strType; // +strSubject;
                    scheduleAppointment.objectID = sch.ObjectID.ToString();
                    scheduleAppointment.objectDefName = sch.ObjectDef.Name;
                    //TODO
                    //scheduleAppointment.Locked = true;
                    scheduleAppointment.objectDefID = sch.ObjectDef.ID.ToString();
                    AppOrSchType appOrSchType = new AppOrSchType();
                    appOrSchType.text = "";
                    appOrSchType.id = "WITHWORKHOUR" + sch.Resource.ObjectID.ToString();
                    givenAppointmentsAndSchedules.AppOrSchTypes.Add(appOrSchType);
                    scheduleAppointment.appOrSchTypeID = appOrSchType.id;
                    scheduleAppointment.color = "#5ba1d0";
                    scheduleAppointment.masterOwnerObjectID = sch.MasterResource.ObjectID;
                    scheduleAppointment.ownerObjectID = sch.Resource.ObjectID;
                    scheduleAppointment.ownerObject = sch.Resource;

                    scheduleAppointment.appCategory = sch.AppointmentDefinition != null ? sch.AppointmentDefinition.AppDefNameDisplayText : "";
                    scheduleAppointment.strAppDate = sch.ScheduleDate.HasValue ? sch.ScheduleDate.Value.ToShortDateString() : "";
                    scheduleAppointment.strAppTime = strTime;
                    scheduleAppointment.appResources = sch.Resource != null ? sch.Resource.Name : "";
                    scheduleAppointment.appStatus = sch.CurrentStateDef != null ? sch.CurrentStateDef.DisplayText : "";
                    scheduleAppointment.strType = "SAATLİ";
                    scheduleAppointment.rowColor = "#007ab7";
                    scheduleAppointment.rowButtonType = 2;//randevu ver butonu çıkacak
                    givenSchedules.Add(scheduleAppointment);
                }
            }
            else
            {
                int cnt = 0;
                foreach (Appointment app in apps)
                    if (app.BreakAppointment == false)
                        if (app.Schedule != null && app.Schedule.ObjectID == sch.ObjectID)
                            cnt += 1;
                        else if (app.StartTime >= sch.StartTime && app.EndTime <= sch.EndTime)
                            cnt += 1;
                for (int i = cnt + 1; i < (sch.CountLimit + 1); i++)
                {
                    string strDef = string.Empty;
                    if (i <= 9)
                        strDef = "SIRALI:" + i.ToString().Insert(0, "0");
                    else
                        strDef = "SIRALI:" + i.ToString();
                    string strType = String.Empty;
                    foreach (ScheduleAppointmentType schAppType in sch.ScheduleAppointmentTypes)
                        strType += TTObjectClasses.Common.GetEnumValueDefOfEnumValue(schAppType.AppointmentType).DisplayText + ";";
                    //infWinSchedule.Appointment scheduleAppointment = new infWinSchedule.Appointment(gapStart, gapEnd);
                    GivenAppointment scheduleAppointment = new GivenAppointment();
                    scheduleAppointment.startDate = GetStartTimeForOrderedAppointment(sch, i - 1); //gapStart;
                    scheduleAppointment.endDate = GetEndTimeForOrderedAppointment(sch, i - 1); //gapEnd;
                    scheduleAppointment.text = schMasResName + "\r\n\r\n" + sch.Resource.Name + "\r\n\r\n" + strDef; // +strSubject;
                    scheduleAppointment.objectID = sch.ObjectID.ToString();
                    scheduleAppointment.objectDefName = sch.ObjectDef.Name;
                    //TODO
                    //scheduleAppointment.Locked = true;
                    scheduleAppointment.objectDefID = sch.ObjectDef.ID.ToString();
                    AppOrSchType appOrSchType = new AppOrSchType();
                    appOrSchType.text = "";
                    appOrSchType.id = "WITHQUEUE" + sch.Resource.ObjectID.ToString();
                    givenAppointmentsAndSchedules.AppOrSchTypes.Add(appOrSchType);
                    scheduleAppointment.appOrSchTypeID = appOrSchType.id;
                    scheduleAppointment.color = "#5ba1d0";
                    scheduleAppointment.masterOwnerObjectID = sch.MasterResource.ObjectID;
                    scheduleAppointment.ownerObjectID = sch.Resource.ObjectID;
                    scheduleAppointment.ownerObject = sch.Resource;

                    scheduleAppointment.appCategory = sch.AppointmentDefinition != null ? sch.AppointmentDefinition.AppDefNameDisplayText : "";
                    scheduleAppointment.strAppDate = sch.ScheduleDate.HasValue ? sch.ScheduleDate.Value.ToShortDateString() : "";
                    scheduleAppointment.strAppTime = scheduleAppointment.startDate.ToShortTimeString() + " - " + scheduleAppointment.endDate.ToShortTimeString();
                    scheduleAppointment.appResources = sch.Resource != null ? sch.Resource.Name : "";
                    scheduleAppointment.appStatus = sch.CurrentStateDef != null ? sch.CurrentStateDef.DisplayText : "";
                    scheduleAppointment.strType = strDef;
                    scheduleAppointment.rowColor = "#007ab7";
                    scheduleAppointment.rowButtonType = 2;//randevu ver butonu çıkacak
                    givenSchedules.Add(scheduleAppointment);
                }
            }

            return givenSchedules;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public void SaveAppointment(AppointmentToSaveDVO appointmentToSaveDVO)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            Schedule selectedAppointmentSchedule = null;
            try
            {
                IAppointmentDef appObject;
                Appointment newAppointment = null;
                Appointment _myOldAppointment = null;
                if (appointmentToSaveDVO._myOldAppointment != null)
                    _myOldAppointment = objectContext.GetObject<Appointment>(new Guid(appointmentToSaveDVO._myOldAppointment.objectID));
                //this._currentObject = (TTObject)_appointmentDef;
                TTObjectContext appointmentToSaveContext = new TTObjectContext(false);
                Appointment appointmentToSave = null;
                if (appointmentToSaveDVO.appointmentToSave.ObjectContext == null)
                    appointmentToSave = appointmentToSaveContext.AddObject(appointmentToSaveDVO.appointmentToSave) as Appointment;
                else
                {
                    appointmentToSave = new Appointment(appointmentToSaveContext);//appointmentToSaveContext.AddObject(appointmentToSaveDVO.appointmentToSave) as Appointment;
                    appointmentToSave = appointmentToSaveDVO.appointmentToSave;
                }
                if (appointmentToSaveDVO.TCKNo != 0)
                {
                    checkTCKNo(appointmentToSaveDVO.TCKNo);
                }

                DateTime appDate = appointmentToSave.AppDate.Value;
                appointmentToSave.AppDate = new DateTime(appDate.Year, appDate.Month, appDate.Day, 0, 0, 0);
                TTObject currentObject = null;
                if (appointmentToSaveDVO.CurrentObject == null)
                {
                    TTObject ttObject = null;
                    if (appointmentToSave.Action != null)
                        ttObject = (TTObject)appointmentToSave.Action;
                    if (appointmentToSave.SubActionProcedure != null)
                    {
                        if (Common.IsAttributeExists(typeof(PlanPlannedActionAttribute), appointmentToSave.SubActionProcedure.EpisodeAction))
                            ttObject = (TTObject)appointmentToSave.SubActionProcedure.EpisodeAction;
                        else
                            ttObject = (TTObject)appointmentToSave.SubActionProcedure;
                    }

                    appointmentToSaveDVO.CurrentObject = ttObject;
                }
                if (appointmentToSaveDVO.CurrentObject != null)
                {
                    if (appointmentToSaveDVO.CurrentObject is AdmissionAppointment)
                    {
                        AdmissionAppointment admissionAppointment = new AdmissionAppointment(appointmentToSaveContext);
                        admissionAppointment = (AdmissionAppointment)appointmentToSaveDVO.CurrentObject;
                        currentObject = admissionAppointment;
                    }
                    else
                    {
                        if (appointmentToSaveDVO.CurrentObject.ObjectContext == null)
                            currentObject = appointmentToSaveContext.AddObject(appointmentToSaveDVO.CurrentObject);
                        else
                            currentObject = (TTObject)appointmentToSaveDVO.CurrentObject;
                         //   currentObject = appointmentToSaveContext.GetObject<TTObject>(appointmentToSaveDVO.CurrentObject.ObjectID,false);
                    }

                   
                }
                appointmentToSaveDVO.appointmentToSave = appointmentToSave;
                //if (lwAppointments.SelectedItems.Count > 0)
                if (appointmentToSaveDVO.selectedCalendarItems != null && appointmentToSaveDVO.selectedCalendarItems.Count > 0)
                {
                    GivenAppointment item = (GivenAppointment)appointmentToSaveDVO.selectedCalendarItems[0];
                    selectedAppointmentSchedule = objectContext.GetObject<Schedule>(new Guid(item.objectID)); //((Appointment)item.Tag).Schedule;
                }
                else if (appointmentToSaveDVO.appointmentToSave.Schedule != null)
                    selectedAppointmentSchedule = appointmentToSaveDVO.appointmentToSave.Schedule;

                bool checkOverlap = true;
                /*
                if (selectedAppointmentSchedule == null)
                    checkOverlap = true;
                else if (selectedAppointmentSchedule != null && selectedAppointmentSchedule.ScheduleType != null && selectedAppointmentSchedule.ScheduleType.Value == ScheduleTypeEnum.Timely)
                    checkOverlap = true;
                */
                //TODO burada _currentAppDefinition ı tekrar get yapmak gerekebilir.
                AppointmentDefinition _currentAppDefinition = appointmentToSave.AppointmentDefinition;
                if (checkOverlap)
                {
                    if (appointmentToSave.AppointmentDefinition.OverlapAllowed == false)
                    {
                        if (IsOverlapPatient(_currentAppDefinition, appointmentToSave, _myOldAppointment, currentObject))
                        {
                            throw new Exception(SystemMessage.GetMessageV2(284, TTUtils.CultureService.GetText("M25829", "Hastanın bu zaman diliminde başka randevusu var.")));
                        }

                        if (!appointmentToSaveDVO.isBreak && IsOverlapResource(appointmentToSave, _myOldAppointment, currentObject))
                        {
                            throw new Exception(SystemMessage.GetMessageV2(274, TTUtils.CultureService.GetText("M25348", "Bu zaman dilimine, daha önce verilmiş başka bir randevu var.")));
                            //RefreshAppointmentsInListView();
                        }
                    }
                }

                if (IsOverlapNonWorkHour(objectContext, appointmentToSave, _myOldAppointment, currentObject))
                {
                    string[] parameters = new string[] { appointmentToSave.Resource.Name };
                    throw new Exception(SystemMessage.GetMessageV3(285, parameters));
                }

                if (currentObject is AdmissionAppointment)
                {
                    CreateAdmissionAppointment(newAppointment, objectContext, selectedAppointmentSchedule, appointmentToSaveDVO.isBreak, appointmentToSaveDVO);
                }
                else
                {
                    //SubActionProcedure sap = null;
                    if (Common.IsAttributeExists(typeof(ChangeAppointmentTypeAttribute), currentObject) && IsAppointmentDateExceededEpisodeClosingDate(currentObject, appointmentToSave.StartTime.Value))
                    {
                        Episode episode = null;
                        if (currentObject is EpisodeAction)
                        {
                            EpisodeAction ea = (EpisodeAction)currentObject;
                            episode = ea.Episode;
                        }
                        else if (currentObject is SubActionProcedure)
                        {
                            SubActionProcedure sa = (SubActionProcedure)currentObject;
                            episode = sa.Episode;
                        }

                        if (episode != null && episode.PatientStatus == PatientStatusEnum.Outpatient)
                        {
                            //if (ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "İşleme devam etmek istiyor musunuz?", "Verilen randevu tarihi vaka kapanış tarihinin ilerisindedir. Bu durumda Kabul Randevusu oluşturulacaktır. İşleme devam etmek istiyor musunuz?") == "E")
                            //{
                            CreateAdmissionAppointment(newAppointment, objectContext, selectedAppointmentSchedule, appointmentToSaveDVO.isBreak, appointmentToSaveDVO);
                            //}
                        }
                    }
                    else
                    {
                        appObject = (IAppointmentDef)currentObject;
                        if (appointmentToSaveDVO._myOldAppointment == null)
                        {
                            foreach (Appointment newApp in appObject.GetMyNewAppointments())
                            {
                                if (newApp.AppointmentCarrier.ObjectID.Equals(appointmentToSave.AppointmentCarrier.ObjectID))
                                {
                                    throw new Exception(TTUtils.CultureService.GetText("M25334", "Bu randevu türünde daha önce verilmiş randevu var. Randevu türünü değiştiriniz."));
                                }
                            }
                        }

                        newAppointment = appointmentToSave;
                        if (_currentAppDefinition.GiveToMaster == true)
                            newAppointment.MasterResource = null;
                        newAppointment.Schedule = selectedAppointmentSchedule;
                        newAppointment.BreakAppointment = appointmentToSaveDVO.isBreak;
                        if (selectedAppointmentSchedule != null && !(selectedAppointmentSchedule.Duration > 0))
                        {
                            newAppointment.StartTime = GetStartTimeForOrderedAppointment(selectedAppointmentSchedule, nextAvailableAppointmentOrder(selectedAppointmentSchedule));
                            newAppointment.EndTime = GetEndTimeForOrderedAppointment(selectedAppointmentSchedule, nextAvailableAppointmentOrder(selectedAppointmentSchedule));
                        }

                        newAppointment.CurrentStateDefID = Appointment.States.New;
                        newAppointment.AppointmentDefinition = _currentAppDefinition;
                        newAppointment.GivenBy = Common.CurrentResource;
                        if (appObject is BaseAction)
                        {
                            newAppointment.Action = (BaseAction)appObject;
                            if (appObject is EpisodeAction)
                                newAppointment.EpisodeAction = (EpisodeAction)appObject;
                        }
                        else if (appObject is SubActionProcedure)
                            newAppointment.SubActionProcedure = (SubActionProcedure)appObject;
                        if (appointmentToSaveDVO._myOldAppointment == null)
                        {
                            appObject.ObjectContext.Save();
                        }
                        else
                        {
                            appointmentToSaveDVO._retAppointment = newAppointment;
                            UpdateAppointment(appointmentToSaveDVO);
                        }
                        //TODO
                        //if (appointmentToSaveDVO._carrierList.Count > 1 && appObject.MyNewAppointments.Count < appointmentToSaveDVO._carrierList.Count)
                        //{
                        //    bool isExistsInAppointments = false;
                        //    foreach (AppointmentCarrier appCarrier in appointmentToSaveDVO._carrierList)
                        //    {
                        //        foreach (Appointment app in appObject.MyNewAppointments)
                        //        {
                        //            if (app.AppointmentCarrier.ObjectID.Equals(appCarrier.ObjectID) == true)
                        //                isExistsInAppointments = true;
                        //        }
                        //        if (!isExistsInAppointments)
                        //        {
                        //            if (ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Uyarı", "Randevu Türü '" + appCarrier.CarrierName + "' için randevu vermediniz. Bu randevu türü için randevu vermek ister misiniz?") == "T")
                        //            {
                        //                cboCarrier.Value = appCarrier;
                        //                return;
                        //            }
                        //        }
                        //    }
                        //}
                    }
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public void SaveAppointmentForKiosk(AppointmentToSaveForKioskDVO appointmentToSaveForKioskDVO)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            Schedule selectedAppointmentSchedule = null;
            Patient patient = null;
            AppointmentToSaveDVO appointmentToSaveDVO = new AppointmentToSaveDVO();
            try
            {
                if (!String.IsNullOrEmpty(appointmentToSaveForKioskDVO.selectedCalendarItemObjectID))
                {
                    selectedAppointmentSchedule = objectContext.GetObject<Schedule>(new Guid(appointmentToSaveForKioskDVO.selectedCalendarItemObjectID)); //((Appointment)item.Tag).Schedule;
                }
                else
                    throw new Exception("Planlama bulunamadı");

                Appointment appointmentToSave = new Appointment(objectContext);
                if (appointmentToSaveForKioskDVO.TCKNo != 0)
                {
                    checkTCKNo(appointmentToSaveForKioskDVO.TCKNo);
                }

                IList patientSearchList = Patient.Search(Convert.ToString(appointmentToSaveForKioskDVO.TCKNo))?.FoundList;
                if (patientSearchList != null && patientSearchList.Count > 0)
                {
                    patient = (Patient)patientSearchList[0];
                }
                if(patient == null)
                {
                    try
                    {
                        PatientServiceController patientServiceController = new PatientServiceController();
                        NewPatientFormViewModel newPatientFormViewModel = patientServiceController.GenerateNewPatient(appointmentToSaveForKioskDVO.TCKNo);
                        patient = newPatientFormViewModel._Patient;
                    }
                    catch(Exception ex)
                    {
                        //Hata alırsa birşey yapmasın.
                    }
                }

                DateTime appDate = selectedAppointmentSchedule.ScheduleDate.Value;
                DateTime appStartTime = appointmentToSaveForKioskDVO.startDate;
                DateTime appEndTime = appointmentToSaveForKioskDVO.endDate;

                appointmentToSave.AppDate = new DateTime(appDate.Year, appDate.Month, appDate.Day, 0, 0, 0);
                appointmentToSave.StartTime = new DateTime(appStartTime.Year, appStartTime.Month, appStartTime.Day, appStartTime.Hour, appStartTime.Minute, appStartTime.Second);
                appointmentToSave.EndTime = new DateTime(appEndTime.Year, appEndTime.Month, appEndTime.Day, appEndTime.Hour, appEndTime.Minute, appEndTime.Second);
                appointmentToSave.AppointmentDefinition = selectedAppointmentSchedule.AppointmentDefinition;
                if (selectedAppointmentSchedule.AppointmentDefinition.AppointmentCarriers != null && selectedAppointmentSchedule.AppointmentDefinition.AppointmentCarriers.Count > 0)
                {
                    appointmentToSave.AppointmentCarrier = selectedAppointmentSchedule.AppointmentDefinition.AppointmentCarriers.FirstOrDefault(p => p.IsDefault == true);
                    if (appointmentToSave.AppointmentCarrier == null)
                        appointmentToSave.AppointmentCarrier = selectedAppointmentSchedule.AppointmentDefinition.AppointmentCarriers[0];
                }
                appointmentToSave.MasterResource = selectedAppointmentSchedule.MasterResource;
                appointmentToSave.Resource = selectedAppointmentSchedule.Resource;
                appointmentToSave.Schedule = selectedAppointmentSchedule;
                appointmentToSave.AppointmentType = AppointmentTypeEnum.Examination;
                appointmentToSave.Notes = "Kiosk Randevusu";
                AdmissionAppointment admissionAppointment = (AdmissionAppointment)objectContext.CreateObject("AdmissionAppointment");
                admissionAppointment.CurrentStateDefID = AdmissionAppointment.States.New;
                IAdmissionAppointmentDef def = (IAdmissionAppointmentDef)admissionAppointment;
                appointmentToSaveDVO._carrierList = def.GetAppointmentCarrierList();
                if (appointmentToSaveDVO._carrierList != null && appointmentToSaveDVO._carrierList.Count > 0)
                    appointmentToSave.AppointmentCarrier = appointmentToSaveDVO._carrierList[0];
                appointmentToSaveDVO.AppointmentDef = def;

                if (patient != null)
                {
                    appointmentToSave.Patient = patient;
                    admissionAppointment.SelectedPatient = patient;
                    appointmentToSaveDVO.txtPatient = patient.FullName;
                }
                else
                {
                    admissionAppointment.PatientUniqueRefNo = appointmentToSaveForKioskDVO.TCKNo;
                    admissionAppointment.PatientPhone = appointmentToSaveForKioskDVO.PhoneNumber;
                    admissionAppointment.PhoneType = appointmentToSaveForKioskDVO.osPhoneType;
                    appointmentToSaveDVO.txtPatient = "KIOSK RANDEVUSU";
                }

                appointmentToSaveDVO.CurrentObject = (TTObject)admissionAppointment;
                appointmentToSave.Action = admissionAppointment;


                appointmentToSaveDVO.appointmentToSave = appointmentToSave;

                appointmentToSaveDVO.isBreak = false;
                appointmentToSaveDVO.osPhoneType = appointmentToSaveForKioskDVO.osPhoneType;
                appointmentToSaveDVO.PhoneNumber = appointmentToSaveForKioskDVO.PhoneNumber;
                appointmentToSaveDVO.selectedCalendarItems = null;
                appointmentToSaveDVO.TCKNo = appointmentToSaveForKioskDVO.TCKNo;
                appointmentToSaveDVO._myOldAppointment = null;
                appointmentToSaveDVO._retAppointment = null;
                // objectContext.Dispose();
                SaveAppointment(appointmentToSaveDVO);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public void CheckAppointmentForCancel(AppointmentForUpdateDeleteApproveDVO appForCancelDVO)
        {
            TTObjectContext context = new TTObjectContext(false);
            Appointment appForCancel = context.GetObject<Appointment>(new Guid(appForCancelDVO.appointmentObjectID));
            if (CheckAppointmentRight(appForCancel.AppointmentDefinition, Common.AppointmentCancelRightDefID, (Resource)appForCancel.MasterResource) == false) //İptal
            {
                throw new TTException(SystemMessage.GetMessageV2(290, TTUtils.CultureService.GetText("M26726", "Randevu iptali için yetkiniz yok.")));
            }

            if (appForCancel.CurrentStateDefID == Appointment.States.Cancelled)
            {
                throw new TTException(SystemMessage.GetMessageV2(291, TTUtils.CultureService.GetText("M26736", "Randevu zaten iptal edilmiş.")));
            }

            if (appForCancel.SubActionProcedure == null && appForCancel.Action == null)
            {
                CancelAppointment(appForCancel);
                return;
            }
            else
            {
                if (appForCancel.Action != null)
                {
                    if (appForCancel.Action is AdmissionAppointment)
                    {
                        CancelAppointment(appForCancel);
                        return;
                    }
                }

                throw new TTException(SystemMessage.GetMessageV2(293, TTUtils.CultureService.GetText("M25335", "Bu randevuyu buradan iptal edemezsiniz, iptal için bilgi işleme başvurunuz.")));
            }
        }

        private void CancelAppointment(Appointment app)
        {
            try
            {
                TTObjectContext context = new TTObjectContext(false);
                Appointment appCancel = (Appointment)context.GetObject(app.ObjectID, "Appointment");
                if (appCancel.Schedule == null || (appCancel.Schedule != null && appCancel.Schedule.SentToMHRS != true))
                    appCancel.Schedule = null;
                appCancel.CurrentStateDefID = Appointment.States.Cancelled;
                if (appCancel.Action != null && appCancel.Action is AdmissionAppointment)
                {
                    AdmissionAppointment admApp = (AdmissionAppointment)appCancel.Action;
                    admApp.CurrentStateDefID = AdmissionAppointment.States.Cancelled;
                }

                context.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public void CheckAppointmentForApprove(AppointmentForUpdateDeleteApproveDVO appForApproveDVO)
        {
            TTObjectContext context = new TTObjectContext(false);
            Appointment appForApprove = context.GetObject<Appointment>(new Guid(appForApproveDVO.appointmentObjectID));
            if (appForApprove.CurrentStateDefID == Appointment.States.Completed)
            {
                throw new TTException(SystemMessage.GetMessageV2(294, TTUtils.CultureService.GetText("M26737", "Randevu zaten onaylanmış.")));
            }

            if (appForApprove.Resource.ObjectID != TTUser.CurrentUser.TTObjectID)
            {
                if (CheckAppointmentRight(appForApprove.AppointmentDefinition, Common.AppointmentApproveRightDefID, (Resource)appForApprove.MasterResource) == false) //Onayla
                {
                    throw new TTException(SystemMessage.GetMessageV2(295, TTUtils.CultureService.GetText("M26728", "Randevu onaylama için yetkiniz yok.")));
                }
            }

            if (appForApprove.SubActionProcedure == null && appForApprove.Action == null)
            {
                ApproveAppointment(appForApprove);
                return;
            }
            else
            {
                if (appForApprove.Action != null)
                {
                    if (appForApprove.Action is AdmissionAppointment)
                    {
                        throw new TTException(SystemMessage.GetMessageV2(297, TTUtils.CultureService.GetText("M25336", "Bu randevuyu buradan onaylayamazsınız, onaylamak için bilgi işleme başvurunuz.")));
                    }
                }

                ApproveAppointment(appForApprove);
                return;
            }
        }

        private void ApproveAppointment(Appointment app)
        {
            try
            {
                TTObjectContext context = new TTObjectContext(false);
                Appointment appCancel = (Appointment)context.GetObject(app.ObjectID, "Appointment");
                appCancel.CurrentStateDefID = Appointment.States.Completed;
                context.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public AppointmentToUpdateDVO CheckAppointmentForUpdate(AppointmentForUpdateDeleteApproveDVO appForUpdateDVO)
        {
            TTObjectContext context = new TTObjectContext(false);
            AppointmentToUpdateDVO appointmentToUpdateDVO = new AppointmentToUpdateDVO();
            Appointment appForUpdate = context.GetObject<Appointment>(new Guid(appForUpdateDVO.appointmentObjectID));
            if (CheckAppointmentRight(appForUpdate.AppointmentDefinition, Common.AppointmentAddRightDefID, (Resource)appForUpdate.MasterResource) == false) //Ekleme
            {
                throw new TTException(SystemMessage.GetMessageV2(298, TTUtils.CultureService.GetText("M26724", "Randevu değiştirme için yetkiniz yok.")));
            }

            if (appForUpdate.CurrentStateDefID == Appointment.States.Completed)
            {
                throw new TTException(SystemMessage.GetMessageV2(299, TTUtils.CultureService.GetText("M26729", "Randevu onaylanmış, değiştirilemez.")));
            }

            if (appForUpdate.CurrentStateDefID == Appointment.States.Cancelled)
            {
                throw new TTException(SystemMessage.GetMessageV2(300, TTUtils.CultureService.GetText("M26725", "Randevu iptal edilmiş, değiştirilemez.")));
            }

            if (appForUpdate.AppointmentDefinition != null)
            {
                appointmentToUpdateDVO.appCarrierDisabled = true;
                appointmentToUpdateDVO.txtPatientDisabled = true;
                appointmentToUpdateDVO.TCKNoDisabled = true;
                appointmentToUpdateDVO.appDefDisabled = true;
                appointmentToUpdateDVO.appMasterResourceDisabled = appForUpdate.AppointmentDefinition.GiveToMaster != true;
                if (appForUpdate.Action != null || appForUpdate.SubActionProcedure != null)
                {
                    TTObject ttObject = null;
                    if (appForUpdate.Action != null)
                        ttObject = (TTObject)appForUpdate.Action;
                    if (appForUpdate.SubActionProcedure != null)
                    {
                        if (Common.IsAttributeExists(typeof(PlanPlannedActionAttribute), appForUpdate.SubActionProcedure.EpisodeAction))
                            ttObject = (TTObject)appForUpdate.SubActionProcedure.EpisodeAction;
                        else
                            ttObject = (TTObject)appForUpdate.SubActionProcedure;
                    }

                    appointmentToUpdateDVO.CurrentObject = ttObject;

                    if (Common.IsAttributeExists(typeof(AdmissionAppointmentDefinitionAttribute), ttObject))
                    {
                        IAdmissionAppointmentDef def = (IAdmissionAppointmentDef)appForUpdate.Action;
                        appointmentToUpdateDVO._admissionAppointmentDef = def;
                    }

                    if (Common.IsAttributeExists(typeof(AppointmentDefinitionAttribute), ttObject))
                    {
                        IAppointmentDef def = (IAppointmentDef)ttObject;
                        appointmentToUpdateDVO._appointmentDef = def;
                    }

                    if (Common.IsAttributeExists(typeof(PlanPlannedActionAttribute), ttObject))
                    {
                        IPlanPlannedAction def = (IPlanPlannedAction)ttObject;
                        IList<PlannedAction> plannedActions = def.GetMySiblingObjectListForAppointment();
                        appointmentToUpdateDVO.objectList = new List<TTObject>();
                        foreach (PlannedAction plannedAction in plannedActions)
                        {
                            appointmentToUpdateDVO.objectList.Add(plannedAction);
                        }

                        appointmentToUpdateDVO._plannedAppointmentDef = def;
                        appointmentToUpdateDVO.plannedActions = plannedActions;
                    }

                    if (Common.IsAttributeExists(typeof(SplitBySubActionProcedureAppointmentAttribute), ttObject))
                    {
                        ISplitBySubActionProcedureAppointment def = (ISplitBySubActionProcedureAppointment)ttObject;
                        IList<SubActionProcedure> subActionProcedures = def.GetMySiblingObjectListForAppointment();
                        appointmentToUpdateDVO.objectList = new List<TTObject>();
                        foreach (SubActionProcedure subActionProcedure in subActionProcedures)
                        {
                            appointmentToUpdateDVO.objectList.Add(subActionProcedure);
                        }

                        appointmentToUpdateDVO._splitBySubActionProcedureAppointmentDef = def;
                        appointmentToUpdateDVO.subActionProcedures = subActionProcedures;
                    }
                }
            }

            return appointmentToUpdateDVO;
        }

        public void checkTCKNo(Int64 tckNo)
        {
            if (!Common.CheckMernisNumber(Convert.ToInt64(tckNo)))
                throw new Exception(TTUtils.CultureService.GetText("M25693", "Geçersiz TC Kimlik Numarası."));
        }

        private void UpdateAppointment(AppointmentToSaveDVO appointmentToSaveDVO)
        {
            if (appointmentToSaveDVO._retAppointment == null)
                return;
            TTObjectContext _context = new TTObjectContext(false);
            Appointment appUpdated = (Appointment)_context.GetObject(new Guid(appointmentToSaveDVO._myOldAppointment.objectID), "Appointment");
            appUpdated.AppDate = appUpdated.StartTime = appointmentToSaveDVO._retAppointment.AppDate; // appointmentToSaveDVO._retAppointment.AppDate;
            appUpdated.EndTime = appointmentToSaveDVO._retAppointment.EndTime;
            appUpdated.StartTime = appointmentToSaveDVO._retAppointment.StartTime;
            appUpdated.Resource = appointmentToSaveDVO._retAppointment.Resource;
            appUpdated.BreakAppointment = appointmentToSaveDVO._retAppointment.BreakAppointment;
            appUpdated.Notes = appointmentToSaveDVO._retAppointment.Notes;
            appUpdated.Schedule = appointmentToSaveDVO._retAppointment.Schedule;
            appUpdated.AppointmentType = appointmentToSaveDVO._retAppointment.AppointmentType;
            appUpdated.AppointmentUpdate = true;
            if (appUpdated.Action != null)
            {
                appUpdated.Action.WorkListDate = appointmentToSaveDVO._retAppointment.StartTime;
                if (appUpdated.Action is AdmissionAppointment)
                {
                    if (appointmentToSaveDVO._retAppointment.Action != null && appointmentToSaveDVO._retAppointment.Action is AdmissionAppointment)
                        ((AdmissionAppointment)appUpdated.Action).NotRequiredQuota = ((AdmissionAppointment)appointmentToSaveDVO._retAppointment.Action).NotRequiredQuota;
                }
            }

            if (appUpdated.SubActionProcedure != null)
                appUpdated.SubActionProcedure.WorkListDate = appointmentToSaveDVO._retAppointment.StartTime;
            _context.Save();
        }

        private DateTime GetStartTimeForOrderedAppointment(Schedule schedule, int order)
        {
            TimeSpan spanTotalDuration = schedule.EndTime.Value.Subtract(schedule.StartTime.Value);
            double durationInterval = TimeSpan.FromTicks(spanTotalDuration.Ticks / schedule.CountLimit.Value).TotalMinutes;
            DateTime newStartTime = schedule.StartTime.Value.AddMinutes(durationInterval * order);
            return newStartTime;
        }

        private DateTime GetEndTimeForOrderedAppointment(Schedule schedule, int order)
        {
            TimeSpan spanTotalDuration = schedule.EndTime.Value.Subtract(schedule.StartTime.Value);
            double durationInterval = TimeSpan.FromTicks(spanTotalDuration.Ticks / schedule.CountLimit.Value).TotalMinutes;
            DateTime newEndTime = schedule.StartTime.Value.AddMinutes((durationInterval * order) + durationInterval);
            return newEndTime;
        }

        private bool IsAppointmentDateExceededEpisodeClosingDate(TTObject CurrentObject, DateTime AppStartTime)
        {
            DateTime dateLimit = new DateTime();
            //DateTime episodeOpeningDate = new DateTime();
            Episode episode = null;
            if (CurrentObject is EpisodeAction)
            {
                EpisodeAction ea = (EpisodeAction)CurrentObject;
                episode = ea.Episode;
            }
            else if (CurrentObject is SubActionProcedure)
            {
                SubActionProcedure sa = (SubActionProcedure)CurrentObject;
                episode = sa.Episode;
            }
            else
            {
                return false;
            }

            if (episode != null)
            {
                if (episode.PatientStatus != null && (int)episode.PatientStatus == PatientStatusEnum.Outpatient.GetHashCode())
                {
                    if (episode.Payer.IsSGK)
                    {
                        int limit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("SGKSPECIALITYCONTROLDAYLIMIT", "10"));
                        dateLimit = Convert.ToDateTime(episode.OpeningDate.Value.Date).AddDays(1 * (limit) + 1).Date;
                        return AppStartTime > dateLimit;
                    }
                }
            }

            return false;
        }

        private IList GetOverlapNonWorkSchedules(TTObjectContext objectContext, DateTime schDate, DateTime startTime, DateTime endTime, string resourceID)
        {
            return Schedule.GetByInjection(objectContext, "WHERE RESOURCE = '" + resourceID + "' AND ISWORKHOUR = 0 AND SCHEDULEDATE = TODATE('" + schDate.ToString("yyyy-MM-dd HH:mm:ss") + "') AND ((STARTTIME >= TODATE('" + startTime.ToString("yyyy-MM-dd HH:mm:ss") + "') AND STARTTIME < TODATE('" + endTime.ToString("yyyy-MM-dd HH:mm:ss") + "')) OR (ENDTIME > TODATE('" + startTime.ToString("yyyy-MM-dd HH:mm:ss") + "') AND ENDTIME <= TODATE('" + endTime.ToString("yyyy-MM-dd HH:mm:ss") + "')) OR (STARTTIME <= TODATE('" + startTime.ToString("yyyy-MM-dd HH:mm:ss") + "') AND ENDTIME >= TODATE('" + endTime.ToString("yyyy-MM-dd HH:mm:ss") + "')))");
        }

        private IBindingList GetOverlapAppointments(DateTime appDate, DateTime startTime, DateTime endTime, string patientID, AppointmentDefinition appDef, Appointment _myOldAppointment, TTObject CurrentObject)
        {
            TTObjectContext _newEditableObjectContext = new TTObjectContext(false);
            string injection = String.Empty;
            if (_myOldAppointment != null)
                injection = " AND OBJECTID <> '" + _myOldAppointment.ObjectID.ToString() + "' ";
            if (CurrentObject != null)
            {
                if (CurrentObject is BaseAction)
                    injection += " AND ACTION <> " + ConnectionManager.GuidToString(CurrentObject.ObjectID);
                else if (CurrentObject is SubActionProcedure)
                    injection += " AND SUBACTIONPROCEDURE <> " + ConnectionManager.GuidToString(CurrentObject.ObjectID);
            }

            return Appointment.GetByInjection(_newEditableObjectContext, "WHERE PATIENT = '" + patientID + "' " + injection + " AND BREAKAPPOINTMENT = 0 AND CURRENTSTATEDEFID <> " + ConnectionManager.GuidToString(Appointment.States.Cancelled) + " AND APPDATE = TODATE('" + appDate.ToString("yyyy-MM-dd HH:mm:ss") + "') AND ((STARTTIME >= TODATE('" + startTime.ToString("yyyy-MM-dd HH:mm:59") + "') AND STARTTIME < TODATE('" + endTime.ToString("yyyy-MM-dd HH:mm:00") + "')) OR (ENDTIME > TODATE('" + startTime.ToString("yyyy-MM-dd HH:mm:59") + "') AND ENDTIME <= TODATE('" + endTime.ToString("yyyy-MM-dd HH:mm:59") + "')) OR (STARTTIME <= TODATE('" + startTime.ToString("yyyy-MM-dd HH:mm:59") + "') AND ENDTIME >= TODATE('" + endTime.ToString("yyyy-MM-dd HH:mm:59") + "'))) AND APPOINTMENTDEFINITION <> " + ConnectionManager.GuidToString(appDef.ObjectID));
        }

        private IBindingList GetOverlapAppointments(DateTime appDate, DateTime startTime, DateTime endTime, string resourceID, Appointment _myOldAppointment, TTObject CurrentObject)
        {
            TTObjectContext _newEditableObjectContext = new TTObjectContext(false);
            string injection = String.Empty;
            if (_myOldAppointment != null)
                injection = " AND OBJECTID <> '" + _myOldAppointment.ObjectID.ToString() + "' ";
            if (CurrentObject != null)
            {
                if (CurrentObject is BaseAction)
                    injection += " AND ACTION <> '" + CurrentObject.ObjectID.ToString() + "' ";
                else if (CurrentObject is SubActionProcedure)
                    injection += " AND SUBACTIONPROCEDURE <> '" + CurrentObject.ObjectID.ToString() + "' ";
            }

            return Appointment.GetByInjection(_newEditableObjectContext, "WHERE RESOURCE = '" + resourceID + "'" + injection + " AND BREAKAPPOINTMENT = 0 AND CURRENTSTATEDEFID <> '" + Appointment.States.Cancelled + "' AND APPDATE = TODATE('" + appDate.ToString("yyyy-MM-dd HH:mm:ss") + "') AND ((STARTTIME >= TODATE('" + startTime.ToString("yyyy-MM-dd HH:mm:59") + "') AND STARTTIME < TODATE('" + endTime.ToString("yyyy-MM-dd HH:mm:00") + "')) OR (ENDTIME > TODATE('" + startTime.ToString("yyyy-MM-dd HH:mm:59") + "') AND ENDTIME <= TODATE('" + endTime.ToString("yyyy-MM-dd HH:mm:59") + "')) OR (STARTTIME <= TODATE('" + startTime.ToString("yyyy-MM-dd HH:mm:59") + "') AND ENDTIME >= TODATE('" + endTime.ToString("yyyy-MM-dd HH:mm:59") + "')))");
        }

        private bool IsOverlapResource(Appointment app, Appointment _myOldAppointment, TTObject CurrentObject)
        {
            string resourceID = app.Resource.ObjectID.ToString();
            IList appList = GetOverlapAppointments(app.AppDate.Value, app.StartTime.Value, app.EndTime.Value, resourceID, _myOldAppointment, CurrentObject);
            return appList.Count > 0;
        }

        private bool IsOverlapPatient(AppointmentDefinition appDef, Appointment app, Appointment _myOldAppointment, TTObject CurrentObject)
        {
            if (app.Patient == null)
                return false;
            string patientID = app.Patient.ObjectID.ToString();
            IList appList = GetOverlapAppointments(app.AppDate.Value, app.StartTime.Value, app.EndTime.Value, patientID, appDef, _myOldAppointment, CurrentObject);
            return appList.Count > 0;
        }

        private bool IsOverlapNonWorkHour(TTObjectContext objectContext, Appointment app, Appointment _myOldAppointment, TTObject CurrentObject)
        {
            string resourceID = app.Resource.ObjectID.ToString();
            IList schList = GetOverlapNonWorkSchedules(objectContext, app.AppDate.Value, app.StartTime.Value, app.EndTime.Value, resourceID);
            return schList.Count > 0;
        }
        private int _nextAvailableAppointmentOrder = 0;
        private int nextAvailableAppointmentOrder(Schedule sch)
        {
            if (_nextAvailableAppointmentOrder > 0)
                return _nextAvailableAppointmentOrder;
            using (TTObjectContext context = new TTObjectContext(true))
            {
                string injectionStr = "";
                injectionStr += " AND CURRENTSTATEDEFID <> '" + Appointment.States.Cancelled + "' ORDER BY STARTTIME";
                IBindingList apps = Appointment.GetByAppDateAndResource(context, Convert.ToDateTime(sch.StartTime.Value.Date), Convert.ToDateTime(sch.EndTime.Value.Date), sch.Resource.ObjectID.ToString(), injectionStr);
                foreach (Appointment app in apps)
                {
                    if (app.BreakAppointment == false)
                        if (app.Schedule != null && app.Schedule.ObjectID == sch.ObjectID)
                            _nextAvailableAppointmentOrder += 1;
                        else if (app.StartTime >= sch.StartTime && app.EndTime <= sch.EndTime)
                            _nextAvailableAppointmentOrder += 1;
                }
                return _nextAvailableAppointmentOrder;
            }
        }

        private void CreateAdmissionAppointment(Appointment newAppointment, TTObjectContext objectContext, Schedule selectedAppointmentSchedule, bool isBreak, AppointmentToSaveDVO appointmentToSaveDVO)
        {
            AdmissionAppointment admissionAppointment = (AdmissionAppointment)objectContext.CreateObject("AdmissionAppointment");
            admissionAppointment.CurrentStateDefID = AdmissionAppointment.States.New;
            //admissionAppointment.NotRequiredQuota = chkNotRequiredQuota.Checked;
            newAppointment = (Appointment)objectContext.CreateObject("Appointment");
            Patient currentPatient = appointmentToSaveDVO.appointmentToSave.Patient;
            if (currentPatient != null)
            {
                admissionAppointment.PatientName = currentPatient.Name;
                admissionAppointment.PatientSurname = currentPatient.Surname;
                admissionAppointment.PatientUniqueRefNo = currentPatient.UniqueRefNo;
                admissionAppointment.PatientPhone = (currentPatient.PatientAddress != null ? currentPatient.PatientAddress.HomePhone : null);
                admissionAppointment.SelectedPatient = currentPatient;
                admissionAppointment.SelectedPatientFiltered = currentPatient.FullName;
            }
            else
            {
                ArrayList nameTokens = Common.Tokenize(appointmentToSaveDVO.txtPatient, false);
                if (nameTokens.Count > 1)
                {
                    for (int i = 0; i < nameTokens.Count - 1; i++)
                    {
                        if (i == 0)
                            admissionAppointment.PatientName = nameTokens[i].ToString();
                        else
                            admissionAppointment.PatientName = admissionAppointment.PatientName + " " + nameTokens[i].ToString();
                    }

                    admissionAppointment.PatientSurname = nameTokens[nameTokens.Count - 1].ToString();
                }
                else
                {
                    if (String.IsNullOrEmpty(appointmentToSaveDVO.txtPatient))
                    {
                        throw new Exception(SystemMessage.GetMessageV2(266, TTUtils.CultureService.GetText("M25774", "Hasta adı boş geçilemez.")));
                    }

                    admissionAppointment.PatientName = appointmentToSaveDVO.txtPatient;
                    admissionAppointment.PatientSurname = "";
                }

                admissionAppointment.PatientUniqueRefNo = !string.IsNullOrEmpty(appointmentToSaveDVO.TCKNo.ToString()) ? Convert.ToInt64(appointmentToSaveDVO.TCKNo) : 0;
                newAppointment.Notes = "(";
                newAppointment.Notes += appointmentToSaveDVO.TCKNo.ToString();
                newAppointment.Notes += ") , ";
                if (!string.IsNullOrEmpty(appointmentToSaveDVO.PhoneNumber))
                {
                    admissionAppointment.PatientPhone = appointmentToSaveDVO.PhoneNumber;
                    newAppointment.Notes += "(";
                    newAppointment.Notes += appointmentToSaveDVO.PhoneNumber;
                    newAppointment.Notes += ") , ";
                }

                admissionAppointment.PhoneType = appointmentToSaveDVO.osPhoneType;
            }

            if (appointmentToSaveDVO.appointmentToSave.AppointmentDefinition.GiveToMaster == true)
                newAppointment.MasterResource = null;
            else
                newAppointment.MasterResource = appointmentToSaveDVO.appointmentToSave.MasterResource;
            newAppointment.Resource = appointmentToSaveDVO.appointmentToSave.Resource;
            admissionAppointment.AppointmentDefinition = appointmentToSaveDVO.appointmentToSave.AppointmentDefinition;
            newAppointment.Schedule = selectedAppointmentSchedule;
            newAppointment.BreakAppointment = isBreak;
            if (selectedAppointmentSchedule != null && !(selectedAppointmentSchedule.Duration > 0))
            {
                newAppointment.StartTime = GetStartTimeForOrderedAppointment(selectedAppointmentSchedule, nextAvailableAppointmentOrder(selectedAppointmentSchedule));
                newAppointment.EndTime = GetEndTimeForOrderedAppointment(selectedAppointmentSchedule, nextAvailableAppointmentOrder(selectedAppointmentSchedule));
            }
            else
            {
                newAppointment.StartTime = appointmentToSaveDVO.appointmentToSave.StartTime;
                newAppointment.EndTime = appointmentToSaveDVO.appointmentToSave.EndTime;
            }

            newAppointment.CurrentStateDefID = Appointment.States.New;
            if (appointmentToSaveDVO.appointmentToSave.AppointmentType != null)
                newAppointment.AppointmentType = (AppointmentTypeEnum)appointmentToSaveDVO.appointmentToSave.AppointmentType;
            newAppointment.Notes += appointmentToSaveDVO.appointmentToSave.Notes;
            newAppointment.AppDate = appointmentToSaveDVO.appointmentToSave.AppDate;
            newAppointment.Patient = appointmentToSaveDVO.appointmentToSave.Patient;
            newAppointment.AppointmentDefinition = appointmentToSaveDVO.appointmentToSave.AppointmentDefinition;
            newAppointment.Action = (BaseAction)admissionAppointment;
            newAppointment.AppointmentCarrier = appointmentToSaveDVO.appointmentToSave.AppointmentCarrier;
            newAppointment.GivenBy = (ResUser)Common.CurrentResource;
            IAppointmentDef appObject = (IAppointmentDef)appointmentToSaveDVO.CurrentObject;
            if (appObject is BaseAction)
            {
                if (appObject is EpisodeAction)
                    newAppointment.InitialObjectID = ((EpisodeAction)appObject).ObjectID.ToString();
            }
            else if (appObject is SubActionProcedure)
                newAppointment.InitialObjectID = ((SubActionProcedure)appObject).ObjectID.ToString();
            if (appointmentToSaveDVO._myOldAppointment == null)
            {
                objectContext.Update();
                admissionAppointment.CurrentStateDefID = AdmissionAppointment.States.Appointment;
                objectContext.Save();
                //PrintAdmissionAppointmentInfoReport(newAppointment);
            }
            else
            {
                appointmentToSaveDVO._retAppointment = newAppointment;
                UpdateAppointment(appointmentToSaveDVO);
                //this.Close();
            }
            //ClearForm();
            //RefreshAppointmentsInListView();
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Randevu_Verme, TTRoleNames.Randevu_Guncelleme)]
        public Patient.MernisPatientModel GetPatientInfoFromKPS(string kimlikNo)
        {
            #region KPS
            Patient.MernisPatientModel mernisPatientModel = new Patient.MernisPatientModel();
            if (TTObjectClasses.SystemParameter.GetParameterValue("ISKPSACTIVE", "TRUE") == "TRUE")
            {
                try
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    Patient p = new Patient(objectContext);
                    if (TTObjectClasses.SystemParameter.GetParameterValue("KIMLIKNOILEADRESSORGUPARAM", "FALSE") == "TRUE")//eski servis
                    {
                        String _uniqueRefNo = kimlikNo;
                        p.UniqueRefNo = Convert.ToInt64(_uniqueRefNo);
                        if (_uniqueRefNo.Length > 2)
                        {
                            Int32 firstTwodigits = Convert.ToInt32(_uniqueRefNo.Substring(0, 2));
                            if (firstTwodigits != 99 && firstTwodigits != 98)
                            {
                                KPSServis.KPSServisSonucuKisiTemelBilgisi response = KPSServis.WebMethods.TcKimlikNoIleKisiSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(_uniqueRefNo));
                                if (string.IsNullOrEmpty(response.Hata))
                                {
                                    mernisPatientModel = Patient.GetPatientandAdresInfoFromKPS_OLD(response, p, true, objectContext);
                                    mernisPatientModel.KPSUniqueRefNo = Convert.ToInt64(_uniqueRefNo);
                                }
                                else//KPS servisten dönen hata
                                {
                                    TTUtils.InfoMessageService.Instance.ShowMessage(response.Hata);
                                }
                            }
                            else //if (p.Foreign == true && p.ForeignUniqueRefNo.Value > 0)
                            {
                                KPSServis.KPSServisSonucuYabanciKisiBilgisi response = KPSServis.WebMethods.YabanciTcKimlikNoIleKisiSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(_uniqueRefNo));
                                if (string.IsNullOrEmpty(response.Hata))
                                {
                                    mernisPatientModel = Patient.GetForeignPatientandAdresInfoFromKPS_OLD(response, p, true, objectContext);
                                    mernisPatientModel.KPsForeignUniqueRefNo = Convert.ToInt64(_uniqueRefNo);
                                }
                                else//KPS servisten dönen hata
                                {
                                    TTUtils.InfoMessageService.Instance.ShowMessage(response.Hata);
                                }
                            }
                        }
                    }
                    else
                    {
                        String _uniqueRefNo = kimlikNo;
                        p.UniqueRefNo = Convert.ToInt64(_uniqueRefNo);

                        mernisPatientModel = Patient.GetPatientandAdresInfoFromKPS(p, true, objectContext);
                        if (mernisPatientModel == null)
                            mernisPatientModel = fillMernisPatientModel(p);
                        if (mernisPatientModel.KPSForeign)
                            mernisPatientModel.KPsForeignUniqueRefNo = Convert.ToInt64(kimlikNo);
                        else
                            mernisPatientModel.KPSUniqueRefNo = Convert.ToInt64(kimlikNo);
                    }
                }
                catch (Exception ex)
                {
                    TTUtils.Logger.WriteException("Error in KPSServis", ex);
                }
            }
            return mernisPatientModel;
            #endregion
        }

        partial void PreScript_AppointmentForm(AppointmentFormViewModel viewModel, Appointment appointment, TTObjectContext objectContext)
        {
            ApplySecurity();
            viewModel.ReadOnly = false;
            SetDefaultDateTimeValues(viewModel);
            ShowAppointmentForm(viewModel);
        }

        partial void PreScript_AppointmentListForm(AppointmentFormViewModel viewModel, Appointment appointment, TTObjectContext objectContext)
        {
            ApplySecurityForSearch();
            viewModel.ReadOnly = false;
            SetDefaultDateTimeValuesForSearch(viewModel);
            FillAppointmentStateItems(viewModel);
            ShowAppointmentListForm(viewModel);
        }

        private void FillAppointmentStateItems(AppointmentFormViewModel viewModel)
        {
            TTObjectDef objDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"];
            TTDefCollection<TTObjectStateDef> stateDefList = objDef.StateDefs;
            viewModel.SelectedAppointmentStateItems = new List<AppointmentStateItem>();
            viewModel.AppointmentStateItems = new List<AppointmentStateItem>();
            foreach (TTObjectStateDef _stateDef in stateDefList)
            {
                AppointmentStateItem appState = new AppointmentStateItem();
                appState.StateDefID = _stateDef.StateDefID.ToString();
                appState.StateDefName = _stateDef.DisplayText;
                appState.StateStatus = _stateDef.Status.ToString().ToUpperInvariant();
                viewModel.AppointmentStateItems.Add(appState);
            }
        }

        public Patient.MernisPatientModel fillMernisPatientModel(Patient p)
        {
            Patient.MernisPatientModel mpm = new Patient.MernisPatientModel();
            mpm.KPSForeign = p.Foreign.HasValue ? p.Foreign.Value : false;
            mpm.KPSName = p.Name;
            mpm.KPSSurname = p.Surname;

            return mpm;
        }
    }
}

namespace Core.Models
{
    public partial class AppointmentFormViewModel
    {
        public bool recurrenceVisible
        {
            get;
            set;
        }

        public List<TTObject> objectsList
        {
            get;
            set;
        }

        public bool objectsVisible
        {
            get;
            set;
        }

        public bool lblPlannedActionsVisible
        {
            get;
            set;
        }

        public bool chkGroupPlanVisible
        {
            get;
            set;
        }

        public DateTime AppDate
        {
            get;
            set;
        }

        public string txtPatient
        {
            get;
            set;
        }

        public Int64 TCKNo
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string Note
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

        public List<AppointmentCarrier> ObjectAppointmentCarrierList
        {
            get;
            set;
        }


        public List<AppointmentTypeListDVO> AppointmentTypeList
        {
            get;
            set;
        }

        public IAppointmentDef AppointmentDef
        {
            get;
            set;
        }

        public TTObject CurrentObject
        {
            get;
            set;
        }

        public TTObject StarterObject
        {
            get;
            set;
        }

        public Guid CurrentObjectTransDefID
        {
            get;
            set;
        }

        public Patient currentPatient
        {
            get;
            set;
        }

        public bool isAdmissionAppointment
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

        public PhoneTypeEnum osPhoneType
        {
            get;
            set;
        }

        public GivenAppointment selectedAppointmentSchedule
        {
            get;
            set;
        }

        public GivenAppointment _myOldAppointment
        {
            get;
            set;
        }

        public bool patientSearchFormVisible
        {
            get;
            set;
        }

        public AppointmentToUpdateDVO appointmentToUpdateDVO
        {
            get;
            set;
        }

        public bool appCarrierDisabled
        {
            get;
            set;
        }

        public ISplitBySubActionProcedureAppointment _splitBySubActionProcedureAppointmentDef
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

        public bool txtPatientDisabled
        {
            get;
            set;
        }

        public IAdmissionAppointmentDef _admissionAppointmentDef
        {
            get;
            set;
        }

        public IAppointmentDef _appointmentDef
        {
            get;
            set;
        }

        public IList<PlannedAction> plannedActions
        {
            get;
            set;
        }

        public IList<SubActionProcedure> subActionProcedures
        {
            get;
            set;
        }

        public IPlanPlannedAction _plannedAppointmentDef
        {
            get;
            set;
        }

        public bool TCKNoDisabled
        {
            get;
            set;
        }

        public Resource ProcedureDoctor
        {
            get;
            set;
        }
        public DateTime appListStartDate
        {
            get;
            set;
        }
        public DateTime appListEndDate
        {
            get;
            set;
        }
        public bool filterAppListByAppDef
        {
            get;
            set;
        }
        public string MasterResourceCaption
        {
            get;
            set;
        }
        public string SubResourceCaption
        {
            get;
            set;
        }
        //public List<AppointmentListItem> appointmentListItems
        //{
        //    get;
        //    set;
        //}
        //public AppointmentListItem selectedAppointmentListItem
        //{
        //    get;
        //    set;
        //}
        //public string injectionSQL { get; set; }
        //public string criteria { get; set; }
        public bool isAppointmentListForm
        {
            get;
            set;
        }
        public Patient.MernisPatientModel MernisPatientModel;

        public List<AppointmentStateItem> AppointmentStateItems
        {
            get;
            set;
        }

        public AppointmentDefinition AppointmentDefinitionToList
        {
            get;
            set;
        }
        public AppointmentCarrier AppointmentCarrierToList
        {
            get;
            set;
        }
        public Resource ResourceToList
        {
            get;
            set;
        }
        public Resource MasterResourceToList
        {
            get;
            set;
        }
        public AppointmentTypeListDVO AppointmentTypeToList
        {
            get;
            set;
        }

        public List<AppointmentStateItem> SelectedAppointmentStateItems
        {
            get;
            set;
        }
    }

    public class AppointmentStateItem
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
        public string StateStatus
        {
            get;
            set;
        }
    }
    public class ResourceAndColorDVO
    {
        public Guid resourceObjectID
        {
            get;
            set;
        }

        public string resourceColor
        {
            get;
            set;
        }
    }

    public class AppointmentToSaveDVO
    {
        public Appointment appointmentToSave
        {
            get;
            set;
        }

        public string txtPatient
        {
            get;
            set;
        }

        public Int64 TCKNo
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public PhoneTypeEnum osPhoneType
        {
            get;
            set;
        }

        public TTObject CurrentObject
        {
            get;
            set;
        }

        public List<GivenAppointment> selectedCalendarItems
        {
            get;
            set;
        }

        public GivenAppointment _myOldAppointment
        {
            get;
            set;
        }

        public int nextAvailableAppointmentOrder
        {
            get;
            set;
        }

        public Appointment _retAppointment
        {
            get;
            set;
        }

        public List<AppointmentCarrier> _carrierList
        {
            get;
            set;
        }

        public bool isBreak
        {
            get;
            set;
        }

        public IAppointmentDef AppointmentDef
        {
            get;
            set;
        }
    }

    public class AppointmentToSaveForKioskDVO
    {
        public Int64 TCKNo
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public PhoneTypeEnum osPhoneType
        {
            get;
            set;
        }

        public string selectedCalendarItemObjectID
        {
            get;
            set;
        }

        public bool isKioskAppointment
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
    }

    public class AppointmentToUpdateDVO
    {
        public List<TTObject> objectList
        {
            get;
            set;
        }

        public bool appCarrierDisabled
        {
            get;
            set;
        }

        public ISplitBySubActionProcedureAppointment _splitBySubActionProcedureAppointmentDef
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

        public bool txtPatientDisabled
        {
            get;
            set;
        }

        public IAdmissionAppointmentDef _admissionAppointmentDef
        {
            get;
            set;
        }

        public IAppointmentDef _appointmentDef
        {
            get;
            set;
        }

        public IList<PlannedAction> plannedActions
        {
            get;
            set;
        }

        public IList<SubActionProcedure> subActionProcedures
        {
            get;
            set;
        }

        public IPlanPlannedAction _plannedAppointmentDef
        {
            get;
            set;
        }

        public bool TCKNoDisabled
        {
            get;
            set;
        }

        public TTObject CurrentObject
        {
            get;
            set;
        }

    }

    public class AppointmentCarrierDVO
    {
        public AppointmentCarrier defaultCarrier
        {
            get;
            set;
        }

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get;
            set;
        }
    }

    public class AppointmentTypeDVO
    {
        public AppointmentTypeListDVO defaultAppType
        {
            get;
            set;
        }

        public List<AppointmentTypeListDVO> AppointmentTypeList
        {
            get;
            set;
        }
    }

    public class AppointmentTypeListDVO
    {
        public Int32 id
        {
            get;
            set;
        }

        public string text
        {
            get;
            set;
        }

        public string AppointmentTypeDisplayText
        {
            get;
            set;
        }

        public AppointmentTypeEnum? AppointmentTypeEnumValue
        {
            get;
            set;
        }

        public AppointmentType AppointmentType
        {
            get;
            set;
        }
    }

    public class MasterResourceInputDVO
    {
        public string masterResourceType
        {
            get;
            set;
        }
        public string subResourceType
        {
            get;
            set;
        }
        public string masterResourceFilter
        {
            get;
            set;
        }
        public string relationParentName
        {
            get;
            set;
        }

        public string appointmentDefObjectID
        {
            get;
            set;
        }

        public string appointmentCarrierObjectID
        {
            get;
            set;
        }

        public string currentPlannedActionMasterResourceID
        {
            get;
            set;
        }

        public bool currentObjectIsPlannedAction
        {
            get;
            set;
        }
        public bool isAppointmentListForm
        {
            get;
            set;
        }

        public string defaultMasterResourceObjectID
        {
            get;
            set;
        }

        public string defaultSubResourceObjectID
        {
            get;
            set;
        }

        public bool isKioskAppointment
        {
            get;
            set;
        }

        public string defaultSpecialityObjectID
        {
            get;
            set;
        }
    }

    public class MasterResourceDVO
    {
        public Resource defaultMasterResource
        {
            get;
            set;
        }

        public List<Resource> MasterResourceList
        {
            get;
            set;
        }

        public List<SpecialityDefinition> SpecialityList
        {
            get;
            set;
        }
    }

    public class SubResourceInputDVO
    {
        public string subResourceType
        {
            get;
            set;
        }

        public string appointmentDefObjectID
        {
            get;
            set;
        }

        public string appointmentCarrierObjectID
        {
            get;
            set;
        }

        public string relationParentName
        {
            get;
            set;
        }

        public string defaultMasterResourceObjectID
        {
            get;
            set;
        }
        public bool isAppointmentListForm
        {
            get;
            set;
        }
        public string defaultSubResourceObjectID
        {
            get;
            set;
        }

        public bool isKioskAppointment
        {
            get;
            set;
        }
    }

    public class SubResourceDVO
    {
        public Resource defaultSubResource
        {
            get;
            set;
        }

        public List<Resource> SubResourceList
        {
            get;
            set;
        }
    }

    public class MHRSActionInputDVO
    {
        public string MHRSActionFilter
        {
            get;
            set;
        }
    }

    public class MHRSActionDVO
    {
        public MHRSActionTypeDefinition defaultMHRSAction
        {
            get;
            set;
        }

        public List<MHRSActionTypeDefinition> MHRSActionList
        {
            get;
            set;
        }
    }

    public class AppointmentInputDVO
    {
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

        public List<ResourceAndColorDVO> AllResourcesAndColors
        {
            get;
            set;
        }

        public DateTime AppDate
        {
            get;
            set;
        }

        public AppointmentTypeEnum? appointmentType
        {
            get;
            set;
        }

        public bool showAppointmentsOfPatient
        {
            get;
            set;
        }

        public string currentView
        {
            get; set;
        }
    }

    public class GivenAppointmentsAndSchedules
    {
        public List<GivenAppointment> GivenAppointments
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

        public List<AppOrSchType> AppOrSchTypes
        {
            get;
            set;
        }
    }

    public class GivenResource
    {
        public string text
        {
            get;
            set;
        }

        public Guid id
        {
            get;
            set;
        }

        public string color
        {
            get;
            set;
        }
    }

    public class AppOrSchType
    {
        public string text
        {
            get;
            set;
        }

        public string id
        {
            get;
            set;
        }
    }

    public class GivenAppointment
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

        public Patient patient
        {
            get;
            set;
        }

        public string txtPatient
        {
            get;
            set;
        }

        public long? TCKNo
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public PhoneTypeEnum? osPhoneType
        {
            get;
            set;
        }

        public Guid masterOwnerObjectID
        {
            get;
            set;
        }

        public AppointmentTypeEnum? appointmentTypeEnum
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

        public string appOrSchTypeID
        {
            get;
            set;
        }

        public string notes
        {
            get;
            set;
        }

        public bool enabled
        {
            get;
            set;
        }

        public string strAppDate
        {
            get;
            set;
        }
        public string strAppTime
        {
            get;
            set;
        }
        public string strType
        {
            get;
            set;
        }
        public string appResources
        {
            get;
            set;
        }
        public string appStatus
        {
            get;
            set;
        }
        public string appCategory
        {
            get;
            set;
        }
        public string rowColor
        {
            get;
            set;
        }
        public int rowButtonType
        {
            get;
            set;
        }
    }

    public class AppointmentListInputDVO
    {
        public AppointmentDefinition appListAppointmentDefinition
        {
            get;
            set;
        }
        public AppointmentCarrier appListAppointmentCarrier
        {
            get;
            set;
        }
        public Resource appListMasterResource
        {
            get;
            set;
        }
        public Resource appListResource
        {
            get;
            set;
        }
        public DateTime appListStartDate
        {
            get;
            set;
        }
        public DateTime appListEndDate
        {
            get;
            set;
        }
        public List<GivenAppointment> appointmentListItems
        {
            get;
            set;
        }
        public bool filterAppListByAppDef
        {
            get;
            set;
        }
        public string criteria
        {
            get;
            set;
        }
        public AppointmentTypeListDVO appListAppointmentType
        {
            get;
            set;
        }

        public string MasterResourceCaption
        {
            get;
            set;
        }
        public string SubResourceCaption
        {
            get;
            set;
        }
        public string injectionSQL
        {
            get;
            set;
        }
        public Patient currentPatient
        {
            get;
            set;
        }
        public List<Resource> MasterResourceList
        {
            get;
            set;
        }
        public List<Guid> SelectedOwnerResources
        {
            get;
            set;
        }

        public List<AppointmentStateItem> SelectedAppointmentStateItems
        {
            get;
            set;
        }
    }

    public class AppointmentForUpdateDeleteApproveDVO
    {
        public string appointmentObjectID
        {
            get;
            set;
        }
    }

    public class AppointmentListItem
    {
        public Appointment appointment
        {
            get;
            set;
        }
        public string strAppDate
        {
            get;
            set;
        }
        public string strAppTime
        {
            get;
            set;
        }
        public string strType
        {
            get;
            set;
        }
        public string patientFullName
        {
            get;
            set;
        }
        public string appResources
        {
            get;
            set;
        }
        public string appStatus
        {
            get;
            set;
        }
        public string appCategory
        {
            get;
            set;
        }
        public string appNotes
        {
            get;
            set;
        }
        public string Color
        {
            get;
            set;
        }
    }
}