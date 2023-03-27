using System;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Linq;
using static TTObjectClasses.TreatmentDischarge;
using System.ComponentModel;
using TTDefinitionManagement;
using Newtonsoft.Json;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class SurgeryWorkListServiceController : BaseEpisodeActionWorkListServiceController
    {
        [HttpGet]
        public SurgeryWorkListViewModel LoadSurgeryWorkListViewModel()
        {
            var viewModel = new SurgeryWorkListViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.WorkList = new List<SurgeryWorkListItem>();

                viewModel.SelectedSurgeryStatusItem = new SelectedSurgeryStatusItem();

                viewModel._SearchCriteria = new SurgeryWorkListSearchCriteria();
                viewModel._SearchCriteria.WorkListStartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                viewModel._SearchCriteria.WorkListEndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");

                //viewModel._SearchCriteria.AdmissionStartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                //viewModel._SearchCriteria.AdmissionEndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");

                #region Birim Listesi

                /****** Klinik Birim Listesi ******/

                viewModel.ResourceList = new List<ResSection>();
                var CurrentResource = Common.CurrentResource;
                foreach (var userResource in CurrentResource.UserResources)
                {
                    if (userResource.Resource is ResWard)
                    {
                        var resource = viewModel.ResourceList.Where(t => t.ObjectID == userResource.Resource.ObjectID).FirstOrDefault();
                        if (resource == null)
                            viewModel.ResourceList.Add(userResource.Resource);
                    }
                }
                viewModel.ResourceList = viewModel.ResourceList.Where(c => c.IsActive == true).OrderBy(x => x.Name).ToList<ResSection>();

                viewModel._SearchCriteria.Resources = new List<ResSection>();
                if (viewModel.ResourceList.Count > 0)
                {
                    foreach (var res in viewModel.ResourceList)
                    {
                        viewModel._SearchCriteria.Resources.Add(res);
                    }
                }

                BindingList<ResSurgeryDepartment> surgeryDeptList = ResSurgeryDepartment.GetActiveSurgeryDepartments(objectContext);
                viewModel.SurgeryDepartmentList = new List<ResSection>();

                foreach (var surgeryDept in surgeryDeptList)
                {
                    viewModel.SurgeryDepartmentList.Add(surgeryDept);
                }

                BindingList<ResSurgeryRoom> surgeryRoomList = ResSurgeryRoom.GetActiveSurgeryRooms(objectContext);
                viewModel.SurgeryRoomList = new List<ResSection>();

                foreach (var surgeryRoom in surgeryRoomList)
                {
                    viewModel.SurgeryRoomList.Add(surgeryRoom);
                }

                BindingList<ResSurgeryDesk> surgeryDeskList = ResSurgeryDesk.GetActiveSurgeryDesks(objectContext);
                viewModel.SurgeryDeskList = new List<ResSection>();

                foreach (var surgeryDesk in surgeryDeskList)
                {
                    viewModel.SurgeryDeskList.Add(surgeryDesk);
                }

                //viewModel._SearchCriteria.Resources = new List<ResSection>(); yukarı taşındı
                viewModel._SearchCriteria.SurgeryDepartments = new List<ResSection>();
                viewModel._SearchCriteria.SurgeryRooms = new List<ResSection>();
                viewModel._SearchCriteria.SurgeryDesks = new List<ResSection>();
                viewModel._SearchCriteria.InpatientDoctors = new List<ResUser>();
                viewModel._SearchCriteria.SurgeryDoctors = new List<ResUser>();
                viewModel._SearchCriteria.AnesthesiaDoctors = new List<ResUser>();
                viewModel._SearchCriteria.AdmissionTypes = new List<ProvizyonTipi>();
                viewModel._SearchCriteria.SurgeryProcedures = new List<SurgeryDefinition>();

                var selectedResource = CurrentResource.SelectedInPatientResource;
                if (selectedResource != null && selectedResource is ResWard)
                {
                    viewModel._SearchCriteria.Resources.Add(selectedResource);
                }

                else if (selectedResource != null && selectedResource is ResDepartment)
                {

                    ResDepartment resDepartment = (ResDepartment)objectContext.GetObject(selectedResource.ObjectID, "ResDepartment");
                    foreach (var sResource in resDepartment.SurgeryDepartment)
                    {
                        viewModel._SearchCriteria.SurgeryDepartments.Add(sResource);
                    }
                }

                #endregion

                #region Doktor Listesi

                BindingList<ResUser> doctorList = ResUser.DoctorListObjectNQL(objectContext, " AND ISACTIVE = 1");
                viewModel.InpatientDoctorList = new List<ResUser>();
                viewModel.SurgeryDoctorList = new List<ResUser>();
                viewModel.AnesthesiaDoctorList = new List<ResUser>();

                foreach (var doctor in doctorList)
                {
                    viewModel.InpatientDoctorList.Add(doctor);
                    viewModel.SurgeryDoctorList.Add(doctor);
                    viewModel.AnesthesiaDoctorList.Add(doctor);
                }

                #endregion

                BindingList<ProvizyonTipi> admissionTypeList = objectContext.QueryObjects<ProvizyonTipi>("ISACTIVE = 1", "PROVIZYONTIPIADI");
                viewModel.AdmissionTypeList = new List<ProvizyonTipi>();

                foreach (var admissionType in admissionTypeList)
                {
                    viewModel.AdmissionTypeList.Add(admissionType);
                }

                //BindingList<SurgeryDefinition> surgeryProcedureList = objectContext.QueryObjects<SurgeryDefinition>("ISACTIVE = 1 AND SURGERYPROCEDURETYPE IN (0,1)","NAME");
                //viewModel.SurgeryProcedureList = new List<SurgeryDefinition>();

                //foreach (var surgeryProcedure in surgeryProcedureList)
                //{
                //    viewModel.SurgeryProcedureList.Add(surgeryProcedure);
                //}

                #region EpisodeAction Tipi Seçimi

                viewModel._SearchCriteria.Surgery_EA = true;
                viewModel._SearchCriteria.AnesthesiaAndReanimation_EA = false;
                #endregion

                #region  state sorguları

                viewModel._SearchCriteria.Request = false; // default
                viewModel._SearchCriteria.Surgery = true;
                viewModel._SearchCriteria.Postponed = false;
                viewModel._SearchCriteria.Completed = false;


                viewModel._SearchCriteria.Waiting = true;// default
                viewModel._SearchCriteria.Continue = false;
                viewModel._SearchCriteria.Reanimation = false;
                viewModel._SearchCriteria.Rejected = false;

                #endregion
                viewModel._SearchCriteria.OnlyOwnPatient = false;

                viewModel.SurgeryStatusDefinitionList = new List<SurgeryStatusDefinition>();
                var statusDefinitionList = SurgeryStatusDefinition.GetSurgeryStatusDefinitionList(objectContext, "");
                foreach (var status in statusDefinitionList)
                {
                    viewModel.SurgeryStatusDefinitionList.Add(status);
                }

                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }
        }

        [HttpPost]
        public object GetSurgeryProcedures(DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;

            using (var objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName.Trim()];
                TTList ttList = TTList.NewList(objectContext, listDef, string.Empty);

                result = DevexpressLoader.Load(objectContext, ttList, loadOptions, new Dictionary<string, object>(), searchText);
            }
            return result.data;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Yatan_Hasta_Listesi)]
        public SurgeryWorkListViewModel GetSurgeryWorkList(SurgeryWorkListSearchCriteria sc)
        {

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                int workListMaxItemCount = Common.WorklistMaxItemCount();
                int counter = 0;

                // GENEL 
                var CurrentUser = Common.CurrentResource;
                var viewModel = new SurgeryWorkListViewModel();
                viewModel.WorkList = new List<SurgeryWorkListItem>();
                viewModel.maxWorklistItemCount = 0;
                //
                string whereCriteria = string.Empty;
                string whereCriteria_For_Surgery = string.Empty;
                string whereCriteria_For_SubSurgery = string.Empty;
                string whereCriteria_For_SurgeryExtension = string.Empty;
                string whereCriteria_For_AnesthesiaAndReanimation = string.Empty;

                if (sc.WorkListStartDate == null || sc.WorkListEndDate == null)
                {
                    throw new Exception("Başlangıç Bitiş Tarihi girilmeden sorgulama yapılamaz");
                }

                if (sc.WorkListStartDate.HasValue)
                    sc.WorkListStartDate = Convert.ToDateTime(sc.WorkListStartDate.Value.ToShortDateString() + " " + "00:00:00");

                if (sc.WorkListEndDate.HasValue)
                    sc.WorkListEndDate = Convert.ToDateTime(sc.WorkListEndDate.Value.ToShortDateString() + " " + "23:59:59");

                dynamic selectedSurgeryProcedures = null;
                if (!String.IsNullOrEmpty(sc.selectedSurgeryProceduresStr))
                    selectedSurgeryProcedures = JsonConvert.DeserializeObject(sc.selectedSurgeryProceduresStr);

                // Hasta seçildi ise diğer sorgular kale alınmayacak
                if (!string.IsNullOrEmpty(sc.PatientObjectID))
                {
                    whereCriteria_For_Surgery = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                    whereCriteria_For_SubSurgery = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                    whereCriteria_For_SurgeryExtension = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                    whereCriteria_For_AnesthesiaAndReanimation = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                }
                else
                {
                    //if (sc.Resources == null || sc.Resources.Count == 0)
                    //    throw new Exception("En az bir servis seçilmeden sorgulama yapılamaz");

                    if (!String.IsNullOrEmpty(sc.PatientNo))
                    {
                        string filterExpression = "";

                        int i = 0;

                        bool result = int.TryParse(sc.PatientNo.Trim(), out i);

                        if (result)
                            filterExpression += " AND THIS.EPISODE.PATIENT.ID = " + sc.PatientNo.Trim() + " ";
                        else
                        {
                            throw new Exception("Arşiv numarası nümerik olmalıdır.");
                        }

                        whereCriteria_For_Surgery += filterExpression;
                        whereCriteria_For_SubSurgery += filterExpression;
                        whereCriteria_For_SurgeryExtension += filterExpression;
                        whereCriteria_For_AnesthesiaAndReanimation += filterExpression;
                    }

                    string whereCriteria_SurgeryProcedure = string.Empty;
                    if (selectedSurgeryProcedures != null)
                    {
                        foreach (var procedure in selectedSurgeryProcedures)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_SurgeryProcedure))
                                whereCriteria_SurgeryProcedure = " (''";
                            whereCriteria_SurgeryProcedure += ",'" + procedure.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryProcedure))
                        {
                            whereCriteria_SurgeryProcedure = whereCriteria_SurgeryProcedure + ") ";
                        }
                    }
                    // Ameliyat için 
                    if (sc.Surgery_EA == true)
                    {
                        #region Surgery
                        // Birim ile ilgili sorgular 
                        whereCriteria = string.Empty;
                        string whereCriteria_Resource = string.Empty;
                        foreach (var resource in sc.Resources)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_Resource))
                                whereCriteria_Resource = " AND this.FROMRESOURCE IN (''";
                            whereCriteria_Resource += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_Resource))
                        {
                            whereCriteria += whereCriteria_Resource + ") ";
                        }

                        string whereCriteria_SurgeryDepartment = string.Empty;
                        foreach (var resource in sc.SurgeryDepartments)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_SurgeryDepartment))
                                whereCriteria_SurgeryDepartment = " AND this.MASTERRESOURCE IN (''";
                            whereCriteria_SurgeryDepartment += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryDepartment))
                        {
                            whereCriteria += whereCriteria_SurgeryDepartment + ") ";
                        }

                        string whereCriteria_SurgeryRoom = string.Empty;
                        foreach (var resource in sc.SurgeryRooms)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_SurgeryRoom))
                                whereCriteria_SurgeryRoom = " AND this.SURGERYROOM IN (''";
                            whereCriteria_SurgeryRoom += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryRoom))
                        {
                            whereCriteria += whereCriteria_SurgeryRoom + ") ";
                        }

                        string whereCriteria_SurgeryDesk = string.Empty;
                        foreach (var resource in sc.SurgeryDesks)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_SurgeryDesk))
                                whereCriteria_SurgeryDesk = " AND this.SURGERYDESK IN (''";
                            whereCriteria_SurgeryDesk += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryDesk))
                        {
                            whereCriteria += whereCriteria_SurgeryDesk + ") ";
                        }

                        // Başlangış - Bitiş Tarihi ile ilgili sorgular 
                        whereCriteria_For_Surgery += " AND this.PLANNEDSURGERYDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                        string whereCriteria_SurgeryDoctor = string.Empty;
                        // Yanlız kendi Hastalarım sorgusu
                        if (sc.OnlyOwnPatient == true)
                            whereCriteria_For_Surgery += " AND this.ProcedureDoctor = '" + CurrentUser.ObjectID + "'";
                        else
                        {
                            foreach (var resource in sc.SurgeryDoctors)
                            {
                                if (string.IsNullOrEmpty(whereCriteria_SurgeryDoctor))
                                    whereCriteria_SurgeryDoctor = " AND this.PROCEDUREDOCTOR IN (''";
                                whereCriteria_SurgeryDoctor += ",'" + resource.ObjectID + "'";
                            }

                            if (!string.IsNullOrEmpty(whereCriteria_SurgeryDoctor))
                            {
                                whereCriteria += whereCriteria_SurgeryDoctor + ") ";
                            }
                        }
                        string whereCriteria_AnesthesiaDoctor = string.Empty;

                        foreach (var resource in sc.AnesthesiaDoctors)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_AnesthesiaDoctor))
                                whereCriteria_AnesthesiaDoctor = " AND this.ANESTHESIAANDREANIMATION.PROCEDUREDOCTOR IN (''";
                            whereCriteria_AnesthesiaDoctor += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_AnesthesiaDoctor))
                        {
                            whereCriteria += whereCriteria_AnesthesiaDoctor + ") ";
                        }

                        whereCriteria_For_Surgery += whereCriteria;

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryProcedure))
                        {
                            whereCriteria_For_Surgery += " AND THIS.SubactionProcedures(PROCEDUREOBJECT IN " + whereCriteria_SurgeryProcedure + ").EXISTS ";
                        }

                        string surgery_States = string.Empty;
                        if (sc.Request)//İstekte
                        {
                            surgery_States += "( this.CURRENTSTATEDEFID IN( States.SurgeryRequest ) AND ( IsDelayedSurgery = 0 OR IsDelayedSurgery IS NULL))";
                        }
                        if (sc.Surgery)//Devam Ediyor
                        {
                            if (!string.IsNullOrEmpty(surgery_States))
                                surgery_States += " OR this.CURRENTSTATEDEFID IN( States.Surgery,States.WaitingForSubSurgeries)";
                            else
                                surgery_States += " this.CURRENTSTATEDEFID IN( States.Surgery,States.WaitingForSubSurgeries)";
                        }
                        if (sc.Postponed)//Ertelendi
                        {
                            if (!string.IsNullOrEmpty(surgery_States))
                                surgery_States += " OR ( this.CURRENTSTATEDEFID IN( States.SurgeryRequest ) AND IsDelayedSurgery = 1)";
                            else
                                surgery_States += " ( this.CURRENTSTATEDEFID IN( States.SurgeryRequest ) AND IsDelayedSurgery = 1)";
                        }
                        if (sc.Completed)//Tamamlandı
                        {
                            if (!string.IsNullOrEmpty(surgery_States))
                                surgery_States += " OR this.CURRENTSTATEDEFID IN(States.Completed)";
                            else
                                surgery_States += " this.CURRENTSTATEDEFID IN(States.Completed)";
                        }

                        if (!string.IsNullOrEmpty(surgery_States))
                        {
                            whereCriteria_For_Surgery += " AND (" + surgery_States + ")";
                        }
                        #endregion
                        #region Subsurgery
                        //Subsurgery
                        // Birim ile ilgili sorgular 
                        whereCriteria = string.Empty;
                        whereCriteria_Resource = string.Empty;
                        foreach (var resource in sc.Resources)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_Resource))
                                whereCriteria_Resource = " AND this.SURGERY.FROMRESOURCE IN (''";
                            whereCriteria_Resource += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_Resource))
                        {
                            whereCriteria += whereCriteria_Resource + ") ";
                        }

                        whereCriteria_SurgeryDepartment = string.Empty;
                        foreach (var resource in sc.SurgeryDepartments)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_SurgeryDepartment))
                                whereCriteria_SurgeryDepartment = " AND this.SURGERY.MASTERRESOURCE IN (''";
                            whereCriteria_SurgeryDepartment += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryDepartment))
                        {
                            whereCriteria += whereCriteria_SurgeryDepartment + ") ";
                        }

                        whereCriteria_SurgeryRoom = string.Empty;
                        foreach (var resource in sc.SurgeryRooms)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_SurgeryRoom))
                                whereCriteria_SurgeryRoom = " AND this.SURGERY.SURGERYROOM IN (''";
                            whereCriteria_SurgeryRoom += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryRoom))
                        {
                            whereCriteria += whereCriteria_SurgeryRoom + ") ";
                        }

                        whereCriteria_SurgeryDesk = string.Empty;
                        foreach (var resource in sc.SurgeryDesks)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_SurgeryDesk))
                                whereCriteria_SurgeryDesk = " AND this.SURGERY.SURGERYDESK IN (''";
                            whereCriteria_SurgeryDesk += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryDesk))
                        {
                            whereCriteria += whereCriteria_SurgeryDesk + ") ";
                        }

                        // Başlangış - Bitiş Tarihi ile ilgili sorgular 
                        whereCriteria_For_SubSurgery += " AND this.SURGERY.PLANNEDSURGERYDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                        // Yanlız kendi Hastalarım sorgusu
                        if (sc.OnlyOwnPatient == true)
                            whereCriteria_For_SubSurgery += " AND this.ProcedureDoctor = '" + CurrentUser.ObjectID + "'";
                        else
                        {
                            foreach (var resource in sc.SurgeryDoctors)
                            {
                                if (string.IsNullOrEmpty(whereCriteria_SurgeryDoctor))
                                    whereCriteria_SurgeryDoctor = " AND this.PROCEDUREDOCTOR IN (''";
                                whereCriteria_SurgeryDoctor += ",'" + resource.ObjectID + "'";
                            }

                            if (!string.IsNullOrEmpty(whereCriteria_SurgeryDoctor))
                            {
                                whereCriteria += whereCriteria_SurgeryDoctor + ") ";
                            }
                        }
                        whereCriteria_AnesthesiaDoctor = string.Empty;

                        foreach (var resource in sc.AnesthesiaDoctors)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_AnesthesiaDoctor))
                                whereCriteria_AnesthesiaDoctor = " AND this.SURGERY.ANESTHESIAANDREANIMATION.PROCEDUREDOCTOR IN (''";
                            whereCriteria_AnesthesiaDoctor += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_AnesthesiaDoctor))
                        {
                            whereCriteria += whereCriteria_AnesthesiaDoctor + ") ";
                        }

                        whereCriteria_For_SubSurgery += whereCriteria;

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryProcedure))
                        {
                            whereCriteria_For_SubSurgery += " AND THIS.SURGERY.SubactionProcedures(PROCEDUREOBJECT IN " + whereCriteria_SurgeryProcedure + ").EXISTS ";
                        }

                        string subSurgery_States = string.Empty;
                        if (sc.Request)//İstekte
                        {
                            subSurgery_States += " ( this.CURRENTSTATEDEFID IN( States.SubSurgeryReport ) AND ( this.SURGERY.IsDelayedSurgery = 0 OR this.SURGERY.IsDelayedSurgery IS NULL))";
                        }
                        if (sc.Surgery)//Devam Ediyor
                        {
                            if (!string.IsNullOrEmpty(subSurgery_States))
                                subSurgery_States += " OR this.CURRENTSTATEDEFID IN(States.SubSurgeryReport)";
                            else
                                subSurgery_States += " this.CURRENTSTATEDEFID IN(States.SubSurgeryReport)";
                        }
                        if (sc.Postponed)//Ertelendi
                        {
                            if (!string.IsNullOrEmpty(subSurgery_States))
                                subSurgery_States += " OR ( this.CURRENTSTATEDEFID IN( States.SubSurgeryReport ) AND this.SURGERY.IsDelayedSurgery = 1)";
                            else
                                subSurgery_States += " ( this.CURRENTSTATEDEFID IN( States.SubSurgeryReport ) AND this.SURGERY.IsDelayedSurgery = 1)";
                        }
                        if (sc.Completed)//Tamamlandı
                        {
                            if (!string.IsNullOrEmpty(subSurgery_States))
                                subSurgery_States += " OR this.CURRENTSTATEDEFID IN(States.Completed)";
                            else
                                subSurgery_States += " this.CURRENTSTATEDEFID IN(States.Completed)";
                        }


                        if (!string.IsNullOrEmpty(subSurgery_States))
                        {
                            whereCriteria_For_SubSurgery += " AND (" + subSurgery_States + ")";
                        }
                        #endregion
                        #region SurgeryExtension
                        //SurgeryExtension için
                        // Birim ile ilgili sorgular 
                        whereCriteria = string.Empty;
                        whereCriteria_Resource = string.Empty;
                        foreach (var resource in sc.Resources)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_Resource))
                                whereCriteria_Resource = " AND this.MAINSURGERY.FROMRESOURCE IN (''";
                            whereCriteria_Resource += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_Resource))
                        {
                            whereCriteria += whereCriteria_Resource + ") ";
                        }

                        whereCriteria_SurgeryDepartment = string.Empty;
                        foreach (var resource in sc.SurgeryDepartments)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_SurgeryDepartment))
                                whereCriteria_SurgeryDepartment = " AND this.MAINSURGERY.MASTERRESOURCE IN (''";
                            whereCriteria_SurgeryDepartment += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryDepartment))
                        {
                            whereCriteria += whereCriteria_SurgeryDepartment + ") ";
                        }

                        whereCriteria_SurgeryRoom = string.Empty;
                        foreach (var resource in sc.SurgeryRooms)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_SurgeryRoom))
                                whereCriteria_SurgeryRoom = " AND this.MAINSURGERY.SURGERYROOM IN (''";
                            whereCriteria_SurgeryRoom += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryRoom))
                        {
                            whereCriteria += whereCriteria_SurgeryRoom + ") ";
                        }

                        whereCriteria_SurgeryDesk = string.Empty;
                        foreach (var resource in sc.SurgeryDesks)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_SurgeryDesk))
                                whereCriteria_SurgeryDesk = " AND this.MAINSURGERY.SURGERYDESK IN (''";
                            whereCriteria_SurgeryDesk += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryDesk))
                        {
                            whereCriteria += whereCriteria_SurgeryDesk + ") ";
                        }

                        // Başlangış - Bitiş Tarihi ile ilgili sorgular 
                        whereCriteria_For_SurgeryExtension += " AND this.MAINSURGERY.PLANNEDSURGERYDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                        // Yanlız kendi Hastalarım sorgusu
                        if (sc.OnlyOwnPatient == true)
                            whereCriteria_For_SurgeryExtension += " AND this.MAINSURGERY.PROCEDUREDOCTOR = '" + CurrentUser.ObjectID + "'";
                        else
                        {
                            foreach (var resource in sc.SurgeryDoctors)
                            {
                                if (string.IsNullOrEmpty(whereCriteria_SurgeryDoctor))
                                    whereCriteria_SurgeryDoctor = " AND this.MAINSURGERY.PROCEDUREDOCTOR IN (''";
                                whereCriteria_SurgeryDoctor += ",'" + resource.ObjectID + "'";
                            }

                            if (!string.IsNullOrEmpty(whereCriteria_SurgeryDoctor))
                            {
                                whereCriteria += whereCriteria_SurgeryDoctor + ") ";
                            }
                        }
                        whereCriteria_AnesthesiaDoctor = string.Empty;

                        foreach (var resource in sc.AnesthesiaDoctors)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_AnesthesiaDoctor))
                                whereCriteria_AnesthesiaDoctor = " AND this.MAINSURGERY.ANESTHESIAANDREANIMATION.PROCEDUREDOCTOR IN (''";
                            whereCriteria_AnesthesiaDoctor += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_AnesthesiaDoctor))
                        {
                            whereCriteria += whereCriteria_AnesthesiaDoctor + ") ";
                        }
                        whereCriteria_For_SurgeryExtension += whereCriteria;

                        if (!string.IsNullOrEmpty(whereCriteria_SurgeryProcedure))
                        {
                            whereCriteria_For_SurgeryExtension += " AND THIS.MAINSURGERY.SubactionProcedures(PROCEDUREOBJECT IN " + whereCriteria_SurgeryProcedure + ").EXISTS ";
                        }

                        string surgeryExtension_States = string.Empty;
                        if (sc.Request)//İstekte
                        {
                            surgeryExtension_States += " ( this.CURRENTSTATEDEFID IN( States.Application ) AND ( this.MAINSURGERY.IsDelayedSurgery = 0 OR this.MAINSURGERY.IsDelayedSurgery IS NULL))";
                        }
                        if (sc.Surgery)//Devam Ediyor
                        {
                            if (!string.IsNullOrEmpty(surgeryExtension_States))
                                surgeryExtension_States += " OR ( this.CURRENTSTATEDEFID IN( States.Application ) AND ( this.MAINSURGERY.IsDelayedSurgery = 0 OR this.MAINSURGERY.IsDelayedSurgery IS NULL))";
                            else
                                surgeryExtension_States += " ( this.CURRENTSTATEDEFID IN( States.Application ) AND ( this.MAINSURGERY.IsDelayedSurgery = 0 OR this.MAINSURGERY.IsDelayedSurgery IS NULL))";
                        }
                        if (sc.Postponed)//Ertelendi
                        {
                            if (!string.IsNullOrEmpty(surgeryExtension_States))
                                surgeryExtension_States += " OR ( this.CURRENTSTATEDEFID IN( States.Application ) AND this.MAINSURGERY.IsDelayedSurgery = 1)";
                            else
                                surgeryExtension_States += " ( this.CURRENTSTATEDEFID IN( States.Application ) AND this.MAINSURGERY.IsDelayedSurgery = 1)";
                        }
                        if (sc.Completed)//Tamamlandı
                        {
                            if (!string.IsNullOrEmpty(surgeryExtension_States))
                                surgeryExtension_States += " OR this.CURRENTSTATEDEFID IN(States.Completed)";
                            else
                                surgeryExtension_States += " this.CURRENTSTATEDEFID IN(States.Completed)";
                        }


                        if (!string.IsNullOrEmpty(surgeryExtension_States))
                        {
                            whereCriteria_For_SurgeryExtension += " AND (" + surgeryExtension_States + ")";
                        }
                        #endregion
                    }

                    //AnesthesiaAndReanimation için
                    if (sc.AnesthesiaAndReanimation_EA == true)
                    {
                        // Birim ile ilgili sorgular 
                        whereCriteria = string.Empty;
                        string whereCriteria_Resource = string.Empty;
                        foreach (var resource in sc.Resources)
                        {
                            if (string.IsNullOrEmpty(whereCriteria_Resource))
                                whereCriteria_Resource = " AND this.FROMRESOURCE IN (''";
                            whereCriteria_Resource += ",'" + resource.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(whereCriteria_Resource))
                        {
                            whereCriteria += whereCriteria_Resource + ") ";
                        }

                        // Başlangış - Bitiş Tarihi ile ilgili sorgular 
                        whereCriteria_For_AnesthesiaAndReanimation += " AND this.PLANNEDANESTHESIADATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                        // Yanlız kendi Hastalarım sorgusu
                        if (sc.OnlyOwnPatient == true)
                            whereCriteria_For_AnesthesiaAndReanimation += " AND this.PROCEDUREDOCTOR = '" + CurrentUser.ObjectID + "'";

                        whereCriteria_For_AnesthesiaAndReanimation += whereCriteria;


                        string surgeryAnesthesia_States = string.Empty;
                        if (sc.Waiting)//Bekleyenler
                        {
                            if (!string.IsNullOrEmpty(surgeryAnesthesia_States))
                                surgeryAnesthesia_States += ",";
                            surgeryAnesthesia_States += "States.Request,States.RequestAcception,States.ReturnedToDoctor";
                        }
                        if (sc.Continue)//Devam Ediyor
                        {
                            if (!string.IsNullOrEmpty(surgeryAnesthesia_States))
                                surgeryAnesthesia_States += ",";
                            surgeryAnesthesia_States += "States.AnesthesiaExpend,States.SurgeryAnestesia";
                        }
                        if (sc.Reanimation)//Uyandırma Odasında
                        {
                            if (!string.IsNullOrEmpty(surgeryAnesthesia_States))
                                surgeryAnesthesia_States += ",";
                            surgeryAnesthesia_States += "States.AnesthesiaReport";
                        }
                        if (sc.AnesthesiaCompleted)//Tamamlandı
                        {
                            if (!string.IsNullOrEmpty(surgeryAnesthesia_States))
                                surgeryAnesthesia_States += ",";
                            surgeryAnesthesia_States += "States.Completed";
                        }
                        if (sc.Rejected)//İptal edildi.
                        {
                            if (!string.IsNullOrEmpty(surgeryAnesthesia_States))
                                surgeryAnesthesia_States += ",";
                            surgeryAnesthesia_States += "States.Cancelled";
                        }

                        if (!string.IsNullOrEmpty(surgeryAnesthesia_States))
                        {
                            whereCriteria_For_AnesthesiaAndReanimation += " AND this.CURRENTSTATEDEFID IN(" + surgeryAnesthesia_States + ")";
                        }
                    }

                }

                if (!String.IsNullOrEmpty(sc.SEProtocolNo))
                {
                    string filterExpression = "";
                    if (sc.SEProtocolNo.Contains("-"))
                        filterExpression += " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.SEProtocolNo.Trim() + "'";
                    else
                    {
                        filterExpression += " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.SEProtocolNo.Trim() + "%'";
                    }
                    if (!String.IsNullOrEmpty(whereCriteria_For_Surgery))
                        whereCriteria_For_Surgery += filterExpression;
                    if (!String.IsNullOrEmpty(whereCriteria_For_SubSurgery))
                        whereCriteria_For_SubSurgery += filterExpression;
                    if (!String.IsNullOrEmpty(whereCriteria_For_SurgeryExtension))
                        whereCriteria_For_SurgeryExtension += filterExpression;
                    if (!String.IsNullOrEmpty(whereCriteria_For_AnesthesiaAndReanimation))
                        whereCriteria_For_AnesthesiaAndReanimation += filterExpression;
                }

                if (sc.AdmissionStartDate.HasValue && sc.AdmissionEndDate.HasValue)
                {
                    string filterExpression = "";
                    filterExpression += " AND THIS.SUBEPISODE.OPENINGDATE BETWEEN " + GetDateAsString(sc.AdmissionStartDate.Value) + " AND " + GetDateAsString(sc.AdmissionEndDate.Value);
                    if (!String.IsNullOrEmpty(whereCriteria_For_Surgery))
                        whereCriteria_For_Surgery += filterExpression;
                    if (!String.IsNullOrEmpty(whereCriteria_For_SubSurgery))
                        whereCriteria_For_SubSurgery += filterExpression;
                    if (!String.IsNullOrEmpty(whereCriteria_For_SurgeryExtension))
                        whereCriteria_For_SurgeryExtension += filterExpression;
                    if (!String.IsNullOrEmpty(whereCriteria_For_AnesthesiaAndReanimation))
                        whereCriteria_For_AnesthesiaAndReanimation += filterExpression;
                }

                string whereCriteria_InpatientDoctor = string.Empty;
                whereCriteria = string.Empty;
                foreach (var resource in sc.InpatientDoctors)
                {
                    if (string.IsNullOrEmpty(whereCriteria_InpatientDoctor))
                        whereCriteria_InpatientDoctor = " AND this.SUBEPISODE.INPATIENTADMISSION.ACTIVEINPATIENTTRTMENTCLCAPP.PROCEDUREDOCTOR IN (''";
                    whereCriteria_InpatientDoctor += ",'" + resource.ObjectID + "'";
                }

                if (!string.IsNullOrEmpty(whereCriteria_InpatientDoctor))
                {
                    whereCriteria += whereCriteria_InpatientDoctor + ") ";
                }


                string whereCriteria_AdmissionType = string.Empty;

                foreach (var admissionType in sc.AdmissionTypes)
                {
                    if (string.IsNullOrEmpty(whereCriteria_AdmissionType))
                        whereCriteria_AdmissionType = " AND THIS.SUBEPISODE.PATIENTADMISSION.ADMISSIONTYPE IN (''";
                    whereCriteria_AdmissionType += ",'" + admissionType.ObjectID + "'";
                }

                if (!string.IsNullOrEmpty(whereCriteria_AdmissionType))
                {
                    whereCriteria += whereCriteria_AdmissionType + ") ";
                }

                if (!String.IsNullOrEmpty(whereCriteria))
                {
                    if (!String.IsNullOrEmpty(whereCriteria_For_Surgery))
                        whereCriteria_For_Surgery += whereCriteria;
                    if (!String.IsNullOrEmpty(whereCriteria_For_SubSurgery))
                        whereCriteria_For_SubSurgery += whereCriteria;
                    if (!String.IsNullOrEmpty(whereCriteria_For_SurgeryExtension))
                        whereCriteria_For_SurgeryExtension += whereCriteria;
                    if (!String.IsNullOrEmpty(whereCriteria_For_AnesthesiaAndReanimation))
                        whereCriteria_For_AnesthesiaAndReanimation += whereCriteria;
                }

                // SORGULAR

                if (!string.IsNullOrEmpty(whereCriteria_For_Surgery)) // Ameliyat Sorgu
                {
                    var SurgeryList = Surgery.GetSurgeryForWL(objectContext, whereCriteria_For_Surgery);
                    foreach (var surgeryFWL in SurgeryList)
                    {
                        Surgery surgery = (Surgery)objectContext.GetObject((Guid)surgeryFWL.ObjectID, "Surgery");
                        // GENEL 
                        if (this.HasWorkListWorkListRight(objectContext, surgery))// BASEDEN KULLANILIYOR  
                        {
                            SurgeryWorkListItem workListItem = new SurgeryWorkListItem();
                            //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                            var episode = surgery.Episode;
                            var subepisode = surgery.SubEpisode;

                            workListItem.ObjectDefID = surgeryFWL.ObjectDefID.ToString();
                            workListItem.ObjectDefName = surgeryFWL.ObjectDefName;
                            workListItem.ObjectID = (Guid)surgeryFWL.ObjectID;
                            // Ikon set etmece
                            string PriorityStatus = surgeryFWL.Prioritystatus;
                            this.setWorkListIkonPropertyies(PriorityStatus, surgery.Episode.Patient, workListItem);
                            //

                            workListItem.HasTightContactIsolation = surgery.SubEpisode.HasTightContactIsolation == true ? true : false;
                            workListItem.HasFallingRisk = surgery.SubEpisode.HasFallingRisk == true ? true : false;
                            workListItem.HasDropletIsolation = surgery.SubEpisode.HasDropletIsolation == true ? true : false;
                            workListItem.HasAirborneContactIsolation = surgery.SubEpisode.HasAirborneContactIsolation == true ? true : false;
                            workListItem.HasContactIsolation = surgery.SubEpisode.HasContactIsolation == true ? true : false;

                            if (surgeryFWL.PlannedSurgeryDate != null)
                                workListItem.Date = Convert.ToDateTime(surgeryFWL.PlannedSurgeryDate);
                            if (surgeryFWL.SurgeryStartTime != null)
                                workListItem.SurgeryStartTime = Convert.ToDateTime(surgeryFWL.SurgeryStartTime);
                            if (surgeryFWL.SurgeryEndTime != null)
                                workListItem.SurgeryEndTime = Convert.ToDateTime(surgeryFWL.SurgeryEndTime);
                            workListItem.PatientNameSurname = surgeryFWL.Patientnamesurname.ToString();
                            workListItem.KabulNo = surgeryFWL.Kabulno == null ? "" : surgeryFWL.Kabulno.ToString();
                            workListItem.UniqueRefno = surgeryFWL.UniqueRefNo == null ? "" : surgeryFWL.UniqueRefNo.ToString();
                            workListItem.EpisodeActionName = surgeryFWL.Episodeactionname == null ? "" : surgeryFWL.Episodeactionname.ToString();
                            workListItem.StateName = surgeryFWL.Statename == null ? "" : surgeryFWL.Statename.ToString();
                            workListItem.StatusName = surgeryFWL.Surgerystatusdefinitionname != null ? surgeryFWL.Surgerystatusdefinitionname : "";
                            workListItem.SurgeryDepartment = surgeryFWL.Surgerydepartment == null ? "" : surgeryFWL.Surgerydepartment.ToString();
                            workListItem.SurgeryRoom = surgeryFWL.Surgeryroom == null ? "" : surgeryFWL.Surgeryroom.ToString();
                            workListItem.SurgeryDesk = surgeryFWL.Surgerydesk == null ? "" : surgeryFWL.Surgerydesk.ToString();
                            workListItem.InpatientClinic = surgeryFWL.Inpatientclinic == null ? "" : surgeryFWL.Inpatientclinic.ToString();
                            workListItem.SurgeryDoctorName = surgeryFWL.Operator == null ? "" : surgeryFWL.Operator.ToString();
                            workListItem.AnesthesiaDoctorName = surgeryFWL.Anesthesist == null ? "" : surgeryFWL.Anesthesist.ToString();
                            workListItem.AdmissionType = surgeryFWL.Admissiontype == null ? "" : surgeryFWL.Admissiontype.ToString();  // Geliş Sebebi
                            workListItem.PayerName = surgeryFWL.Payername == null ? "" : surgeryFWL.Payername.ToString();
                            if (surgeryFWL.BirthDate != null)
                                workListItem.BirthDate = surgeryFWL.BirthDate;// Doğum Tarihi
                            workListItem.FatherName = surgeryFWL.FatherName == null ? "" : surgeryFWL.FatherName.ToString();  // Baba adı
                            workListItem.TelNo = surgeryFWL.Telno == null ? "" : surgeryFWL.Telno.ToString();  // Telefon Numarası
                            workListItem.HastaTuru = surgeryFWL.Hastaturu == null ? "" : surgeryFWL.Hastaturu.ToString();
                            workListItem.BasvuruTuru = surgeryFWL.Basvuruturu == null ? "" : surgeryFWL.Basvuruturu.ToString();
                            workListItem.OncelikDurumu = surgeryFWL.Oncelikdurumu == null ? "" : surgeryFWL.Oncelikdurumu.ToString();

                            // NQL le çekilemeyenler
                            workListItem.Diagnosis = subepisode.GetDiagnosisAsStringForWorkList();

                            viewModel.WorkList.Add(workListItem);
                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                viewModel.maxWorklistItemCount += counter;
                                break;
                            }
                            //
                        }
                    }
                }

                if (!string.IsNullOrEmpty(whereCriteria_For_SubSurgery)) // Ameliyat Ek İşlemleri Sorgu
                {
                    var SubSurgeryList = SubSurgery.GetSubSurgeryForWL(objectContext, whereCriteria_For_SubSurgery);
                    foreach (var subSurgeryFWL in SubSurgeryList)
                    {
                        SubSurgery subSurgery = (SubSurgery)objectContext.GetObject((Guid)subSurgeryFWL.ObjectID, "SubSurgery");
                        // GENEL 
                        if (this.HasWorkListWorkListRight(objectContext, subSurgery))// BASEDEN KULLANILIYOR  
                        {
                            SurgeryWorkListItem workListItem = new SurgeryWorkListItem();
                            //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                            var episode = subSurgery.Episode;
                            var subepisode = subSurgery.SubEpisode;

                            workListItem.ObjectDefID = subSurgeryFWL.ObjectDefID.ToString();
                            workListItem.ObjectDefName = subSurgeryFWL.ObjectDefName;
                            workListItem.ObjectID = (Guid)subSurgeryFWL.ObjectID;
                            // Ikon set etmece
                            string PriorityStatus = subSurgeryFWL.Prioritystatus;
                            this.setWorkListIkonPropertyies(PriorityStatus, subSurgery.Episode.Patient, workListItem);
                            //

                            workListItem.HasTightContactIsolation = subSurgery.SubEpisode.HasTightContactIsolation == true ? true : false;
                            workListItem.HasFallingRisk = subSurgery.SubEpisode.HasFallingRisk == true ? true : false;
                            workListItem.HasDropletIsolation = subSurgery.SubEpisode.HasDropletIsolation == true ? true : false;
                            workListItem.HasAirborneContactIsolation = subSurgery.SubEpisode.HasAirborneContactIsolation == true ? true : false;
                            workListItem.HasContactIsolation = subSurgery.SubEpisode.HasContactIsolation == true ? true : false;

                            if (subSurgeryFWL.PlannedSurgeryDate != null)
                                workListItem.Date = Convert.ToDateTime(subSurgeryFWL.PlannedSurgeryDate);
                            if (subSurgeryFWL.SurgeryStartTime != null)
                                workListItem.SurgeryStartTime = Convert.ToDateTime(subSurgeryFWL.SurgeryStartTime);
                            if (subSurgeryFWL.SurgeryEndTime != null)
                                workListItem.SurgeryEndTime = Convert.ToDateTime(subSurgeryFWL.SurgeryEndTime);
                            workListItem.PatientNameSurname = subSurgeryFWL.Patientnamesurname.ToString();
                            workListItem.KabulNo = subSurgeryFWL.Kabulno == null ? "" : subSurgeryFWL.Kabulno.ToString();
                            workListItem.UniqueRefno = subSurgeryFWL.UniqueRefNo == null ? "" : subSurgeryFWL.UniqueRefNo.ToString();
                            workListItem.EpisodeActionName = subSurgeryFWL.Episodeactionname == null ? "" : subSurgeryFWL.Episodeactionname.ToString();
                            workListItem.StateName = subSurgeryFWL.Statename == null ? "" : subSurgeryFWL.Statename.ToString();
                            workListItem.StatusName = "";
                            workListItem.SurgeryDepartment = subSurgeryFWL.Surgerydepartment == null ? "" : subSurgeryFWL.Surgerydepartment.ToString();
                            workListItem.SurgeryRoom = subSurgeryFWL.Surgeryroom == null ? "" : subSurgeryFWL.Surgeryroom.ToString();
                            workListItem.SurgeryDesk = subSurgeryFWL.Surgerydesk == null ? "" : subSurgeryFWL.Surgerydesk.ToString();
                            workListItem.InpatientClinic = subSurgeryFWL.Inpatientclinic == null ? "" : subSurgeryFWL.Inpatientclinic.ToString();
                            workListItem.SurgeryDoctorName = subSurgeryFWL.Operator == null ? "" : subSurgeryFWL.Operator.ToString();
                            workListItem.AnesthesiaDoctorName = subSurgeryFWL.Anesthesist == null ? "" : subSurgeryFWL.Anesthesist.ToString();
                            workListItem.AdmissionType = subSurgeryFWL.Admissiontype == null ? "" : subSurgeryFWL.Admissiontype.ToString();  // Geliş Sebebi
                            workListItem.PayerName = subSurgeryFWL.Payername == null ? "" : subSurgeryFWL.Payername.ToString();
                            if (subSurgeryFWL.BirthDate != null)
                                workListItem.BirthDate = subSurgeryFWL.BirthDate;// Doğum Tarihi
                            workListItem.FatherName = subSurgeryFWL.FatherName == null ? "" : subSurgeryFWL.FatherName.ToString();  // Baba adı
                            workListItem.TelNo = subSurgeryFWL.Telno == null ? "" : subSurgeryFWL.Telno.ToString();  // Telefon Numarası
                            workListItem.HastaTuru = subSurgeryFWL.Hastaturu == null ? "" : subSurgeryFWL.Hastaturu.ToString();
                            workListItem.BasvuruTuru = subSurgeryFWL.Basvuruturu == null ? "" : subSurgeryFWL.Basvuruturu.ToString();
                            workListItem.OncelikDurumu = subSurgeryFWL.Oncelikdurumu == null ? "" : subSurgeryFWL.Oncelikdurumu.ToString();

                            // NQL le çekilemeyenler
                            workListItem.Diagnosis = subepisode.GetDiagnosisAsStringForWorkList();

                            viewModel.WorkList.Add(workListItem);
                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                viewModel.maxWorklistItemCount += counter;
                                break;
                            }
                            //
                        }
                    }
                }

                if (!string.IsNullOrEmpty(whereCriteria_For_SurgeryExtension)) // Ameliyat Ek İşlemleri Sorgu
                {
                    var SurgeryExtensionList = SurgeryExtension.GetSurgeryExtensionForWL(objectContext, whereCriteria_For_SurgeryExtension);
                    foreach (var surgeryExtensionFWL in SurgeryExtensionList)
                    {
                        SurgeryExtension surgeryExtension = (SurgeryExtension)objectContext.GetObject((Guid)surgeryExtensionFWL.ObjectID, "SurgeryExtension");
                        // GENEL 
                        if (this.HasWorkListWorkListRight(objectContext, surgeryExtension))// BASEDEN KULLANILIYOR  
                        {
                            SurgeryWorkListItem workListItem = new SurgeryWorkListItem();
                            //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                            var episode = surgeryExtension.Episode;
                            var subepisode = surgeryExtension.SubEpisode;

                            workListItem.ObjectDefID = surgeryExtensionFWL.ObjectDefID.ToString();
                            workListItem.ObjectDefName = surgeryExtensionFWL.ObjectDefName;
                            workListItem.ObjectID = (Guid)surgeryExtensionFWL.ObjectID;
                            // Ikon set etmece
                            string PriorityStatus = surgeryExtensionFWL.Prioritystatus;
                            this.setWorkListIkonPropertyies(PriorityStatus, surgeryExtension.Episode.Patient, workListItem);
                            //

                            workListItem.HasTightContactIsolation = surgeryExtension.SubEpisode.HasTightContactIsolation == true ? true : false;
                            workListItem.HasFallingRisk = surgeryExtension.SubEpisode.HasFallingRisk == true ? true : false;
                            workListItem.HasDropletIsolation = surgeryExtension.SubEpisode.HasDropletIsolation == true ? true : false;
                            workListItem.HasAirborneContactIsolation = surgeryExtension.SubEpisode.HasAirborneContactIsolation == true ? true : false;
                            workListItem.HasContactIsolation = surgeryExtension.SubEpisode.HasContactIsolation == true ? true : false;

                            if (surgeryExtensionFWL.PlannedSurgeryDate != null)
                                workListItem.Date = Convert.ToDateTime(surgeryExtensionFWL.PlannedSurgeryDate);
                            if (surgeryExtensionFWL.SurgeryStartTime != null)
                                workListItem.SurgeryStartTime = Convert.ToDateTime(surgeryExtensionFWL.SurgeryStartTime);
                            if (surgeryExtensionFWL.SurgeryEndTime != null)
                                workListItem.SurgeryEndTime = Convert.ToDateTime(surgeryExtensionFWL.SurgeryEndTime);
                            workListItem.PatientNameSurname = surgeryExtensionFWL.Patientnamesurname.ToString();
                            workListItem.KabulNo = surgeryExtensionFWL.Kabulno == null ? "" : surgeryExtensionFWL.Kabulno.ToString();
                            workListItem.UniqueRefno = surgeryExtensionFWL.UniqueRefNo == null ? "" : surgeryExtensionFWL.UniqueRefNo.ToString();
                            workListItem.EpisodeActionName = surgeryExtensionFWL.Episodeactionname == null ? "" : surgeryExtensionFWL.Episodeactionname.ToString();
                            workListItem.StateName = surgeryExtensionFWL.Statename == null ? "" : surgeryExtensionFWL.Statename.ToString();
                            workListItem.StatusName = "";
                            workListItem.SurgeryDepartment = surgeryExtensionFWL.Surgerydepartment == null ? "" : surgeryExtensionFWL.Surgerydepartment.ToString();
                            workListItem.SurgeryRoom = surgeryExtensionFWL.Surgeryroom == null ? "" : surgeryExtensionFWL.Surgeryroom.ToString();
                            workListItem.SurgeryDesk = surgeryExtensionFWL.Surgerydesk == null ? "" : surgeryExtensionFWL.Surgerydesk.ToString();
                            workListItem.InpatientClinic = surgeryExtensionFWL.Inpatientclinic == null ? "" : surgeryExtensionFWL.Inpatientclinic.ToString();
                            workListItem.SurgeryDoctorName = surgeryExtensionFWL.Operator == null ? "" : surgeryExtensionFWL.Operator.ToString();
                            workListItem.AnesthesiaDoctorName = surgeryExtensionFWL.Anesthesist == null ? "" : surgeryExtensionFWL.Anesthesist.ToString();
                            workListItem.AdmissionType = surgeryExtensionFWL.Admissiontype == null ? "" : surgeryExtensionFWL.Admissiontype.ToString();  // Geliş Sebebi
                            workListItem.PayerName = surgeryExtensionFWL.Payername == null ? "" : surgeryExtensionFWL.Payername.ToString();
                            if (surgeryExtensionFWL.BirthDate != null)
                                workListItem.BirthDate = surgeryExtensionFWL.BirthDate;// Doğum Tarihi
                            workListItem.FatherName = surgeryExtensionFWL.FatherName == null ? "" : surgeryExtensionFWL.FatherName.ToString();  // Baba adı
                            workListItem.TelNo = surgeryExtensionFWL.Telno == null ? "" : surgeryExtensionFWL.Telno.ToString();  // Telefon Numarası
                            workListItem.HastaTuru = surgeryExtensionFWL.Hastaturu == null ? "" : surgeryExtensionFWL.Hastaturu.ToString();
                            workListItem.BasvuruTuru = surgeryExtensionFWL.Basvuruturu == null ? "" : surgeryExtensionFWL.Basvuruturu.ToString();
                            workListItem.OncelikDurumu = surgeryExtensionFWL.Oncelikdurumu == null ? "" : surgeryExtensionFWL.Oncelikdurumu.ToString();

                            // NQL le çekilemeyenler
                            workListItem.Diagnosis = subepisode.GetDiagnosisAsStringForWorkList();

                            viewModel.WorkList.Add(workListItem);
                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                viewModel.maxWorklistItemCount += counter;
                                break;
                            }
                            //
                        }
                    }
                }

                if (!string.IsNullOrEmpty(whereCriteria_For_AnesthesiaAndReanimation)) // Ameliyat Ek İşlemleri Sorgu
                {
                    var AnesthesiaAndReanimationList = AnesthesiaAndReanimation.GetAnesthesiaAndReanimationForWL(objectContext, whereCriteria_For_AnesthesiaAndReanimation);
                    foreach (var anesthesiaAndReanimationFWL in AnesthesiaAndReanimationList)
                    {
                        AnesthesiaAndReanimation anesthesiaAndReanimation = (AnesthesiaAndReanimation)objectContext.GetObject((Guid)anesthesiaAndReanimationFWL.ObjectID, "AnesthesiaAndReanimation");
                        // GENEL 
                        if (this.HasWorkListWorkListRight(objectContext, anesthesiaAndReanimation))// BASEDEN KULLANILIYOR  
                        {
                            SurgeryWorkListItem workListItem = new SurgeryWorkListItem();
                            //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                            var episode = anesthesiaAndReanimation.Episode;
                            var subepisode = anesthesiaAndReanimation.SubEpisode;

                            workListItem.ObjectDefID = anesthesiaAndReanimationFWL.ObjectDefID.ToString();
                            workListItem.ObjectDefName = anesthesiaAndReanimationFWL.ObjectDefName;
                            workListItem.ObjectID = (Guid)anesthesiaAndReanimationFWL.ObjectID;
                            // Ikon set etmece
                            string PriorityStatus = anesthesiaAndReanimationFWL.Prioritystatus;
                            this.setWorkListIkonPropertyies(PriorityStatus, anesthesiaAndReanimation.Episode.Patient, workListItem);
                            //

                            workListItem.HasTightContactIsolation = anesthesiaAndReanimation.SubEpisode.HasTightContactIsolation == true ? true : false;
                            workListItem.HasFallingRisk = anesthesiaAndReanimation.SubEpisode.HasFallingRisk == true ? true : false;
                            workListItem.HasDropletIsolation = anesthesiaAndReanimation.SubEpisode.HasDropletIsolation == true ? true : false;
                            workListItem.HasAirborneContactIsolation = anesthesiaAndReanimation.SubEpisode.HasAirborneContactIsolation == true ? true : false;
                            workListItem.HasContactIsolation = anesthesiaAndReanimation.SubEpisode.HasContactIsolation == true ? true : false;

                            if (anesthesiaAndReanimationFWL.AnesthesiaReportDate != null)
                                workListItem.Date = Convert.ToDateTime(anesthesiaAndReanimationFWL.AnesthesiaReportDate);
                            else if (anesthesiaAndReanimationFWL.Anesthesiarequestdate != null)
                                workListItem.Date = Convert.ToDateTime(anesthesiaAndReanimationFWL.Anesthesiarequestdate);
                            if (anesthesiaAndReanimationFWL.AnesthesiaStartDateTime != null)
                                workListItem.SurgeryStartTime = Convert.ToDateTime(anesthesiaAndReanimationFWL.AnesthesiaStartDateTime);
                            if (anesthesiaAndReanimationFWL.AnesthesiaEndDateTime != null)
                                workListItem.SurgeryEndTime = Convert.ToDateTime(anesthesiaAndReanimationFWL.AnesthesiaEndDateTime);
                            workListItem.PatientNameSurname = anesthesiaAndReanimationFWL.Patientnamesurname.ToString();
                            workListItem.KabulNo = anesthesiaAndReanimationFWL.Kabulno == null ? "" : anesthesiaAndReanimationFWL.Kabulno.ToString();
                            workListItem.UniqueRefno = anesthesiaAndReanimationFWL.UniqueRefNo == null ? "" : anesthesiaAndReanimationFWL.UniqueRefNo.ToString();
                            workListItem.EpisodeActionName = anesthesiaAndReanimationFWL.Episodeactionname == null ? "" : anesthesiaAndReanimationFWL.Episodeactionname.ToString();
                            workListItem.StateName = anesthesiaAndReanimationFWL.Statename == null ? "" : anesthesiaAndReanimationFWL.Statename.ToString();
                            workListItem.StatusName = "";
                            workListItem.SurgeryDepartment = anesthesiaAndReanimationFWL.Surgerydepartment == null ? "" : anesthesiaAndReanimationFWL.Surgerydepartment.ToString();
                            workListItem.SurgeryRoom = anesthesiaAndReanimationFWL.Surgeryroom == null ? "" : anesthesiaAndReanimationFWL.Surgeryroom.ToString();
                            workListItem.SurgeryDesk = anesthesiaAndReanimationFWL.Surgerydesk == null ? "" : anesthesiaAndReanimationFWL.Surgerydesk.ToString();
                            workListItem.InpatientClinic = anesthesiaAndReanimationFWL.Inpatientclinic == null ? "" : anesthesiaAndReanimationFWL.Inpatientclinic.ToString();
                            workListItem.SurgeryDoctorName = anesthesiaAndReanimationFWL.Operator == null ? "" : anesthesiaAndReanimationFWL.Operator.ToString();
                            workListItem.AnesthesiaDoctorName = anesthesiaAndReanimationFWL.Anesthesist == null ? "" : anesthesiaAndReanimationFWL.Anesthesist.ToString();
                            workListItem.AdmissionType = anesthesiaAndReanimationFWL.Admissiontype == null ? "" : anesthesiaAndReanimationFWL.Admissiontype.ToString();  // Geliş Sebebi
                            workListItem.PayerName = anesthesiaAndReanimationFWL.Payername == null ? "" : anesthesiaAndReanimationFWL.Payername.ToString();
                            if (anesthesiaAndReanimationFWL.BirthDate != null)
                                workListItem.BirthDate = anesthesiaAndReanimationFWL.BirthDate;// Doğum Tarihi
                            workListItem.FatherName = anesthesiaAndReanimationFWL.FatherName == null ? "" : anesthesiaAndReanimationFWL.FatherName.ToString();  // Baba adı
                            workListItem.TelNo = anesthesiaAndReanimationFWL.Telno == null ? "" : anesthesiaAndReanimationFWL.Telno.ToString();  // Telefon Numarası
                            workListItem.HastaTuru = anesthesiaAndReanimationFWL.Hastaturu == null ? "" : anesthesiaAndReanimationFWL.Hastaturu.ToString();
                            workListItem.BasvuruTuru = anesthesiaAndReanimationFWL.Basvuruturu == null ? "" : anesthesiaAndReanimationFWL.Basvuruturu.ToString();
                            workListItem.OncelikDurumu = anesthesiaAndReanimationFWL.Oncelikdurumu == null ? "" : anesthesiaAndReanimationFWL.Oncelikdurumu.ToString();

                            // NQL le çekilemeyenler
                            workListItem.Diagnosis = subepisode.GetDiagnosisAsStringForWorkList();

                            viewModel.WorkList.Add(workListItem);
                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                viewModel.maxWorklistItemCount += counter;
                                break;
                            }
                            //
                        }
                    }
                }
                viewModel.WorkList = viewModel.WorkList.OrderByDescending(dr => dr.Date).ToList();
                return viewModel;
            }
        }

        public void ChangeSurgeryStatusDefinition(SelectedSurgeryStatusItem SelectedSurgeryStatusItem)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                foreach (var surgeryItem in SelectedSurgeryStatusItem.SurgeryObjectIdList)
                {
                    Surgery _surgery = objectContext.GetObject(surgeryItem, SelectedSurgeryStatusItem.SurgeryObjectDefName) as Surgery;
                    _surgery.SurgeryStatusDefinition = SelectedSurgeryStatusItem.SelectedSurgeryStatusDefinition;
                    _surgery.SurgeryStatusDefinitionTime = Common.RecTime();
                }
                objectContext.Save();
            }
        }
    }

}
namespace Core.Models
{
    public partial class SurgeryWorkListViewModel : BaseEpisodeActionWorkListFormViewModel
    {
        public List<SurgeryWorkListItem> WorkList;
        public SurgeryWorkListSearchCriteria _SearchCriteria
        {
            get;
            set;
        }

        public List<ResSection> ResourceList { get; set; }

        public List<ResSection> SurgeryDepartmentList { get; set; }

        public List<ResSection> SurgeryRoomList { get; set; }

        public List<ResSection> SurgeryDeskList { get; set; }

        public List<ResUser> InpatientDoctorList { get; set; }

        public List<ResUser> SurgeryDoctorList { get; set; }

        public List<ResUser> AnesthesiaDoctorList { get; set; }

        public List<SurgeryDefinition> SurgeryProcedureList { get; set; }

        public List<ProvizyonTipi> AdmissionTypeList { get; set; }

        public SurgeryWorkListViewModel()
        {
            this._SearchCriteria = new SurgeryWorkListSearchCriteria();
            this.WorkList = new List<SurgeryWorkListItem>();
        }

        public List<SurgeryStatusDefinition> SurgeryStatusDefinitionList { get; set; }
        public SelectedSurgeryStatusItem SelectedSurgeryStatusItem { get; set; }
    }

    public class SelectedSurgeryStatusItem
    {
        public List<Guid> SurgeryObjectIdList { get; set; }
        public string SurgeryObjectDefName { get; set; }
        public SurgeryStatusDefinition SelectedSurgeryStatusDefinition { get; set; }
    }

    [Serializable]
    public class SurgeryWorkListSearchCriteria : BaseEpisodeActionWorkListSearchCriteria
    {
        //Getirilecek EpisodeAction Tipi(Surgery, SubSurgery ve SurgeryExtension)
        public bool Surgery_EA
        {
            get;
            set;
        }

        public bool AnesthesiaAndReanimation_EA
        {
            get;
            set;
        }
        // Surgery_EA, SubSurgery_EA, SurgeryExtension_EA ise state sorguları

        public bool Request // İstekte 
        {
            get;
            set;
        }

        public bool Surgery // Devam Ediyor
        {
            get;
            set;
        }

        public bool Postponed // Ertelendi
        {
            get;
            set;
        }
        public bool Completed // Tamamlandı
        {
            get;
            set;
        }

        // AnesthesiaAndReanimation_EA ise state sorguları

        public bool Waiting // bekleyenler 
        {
            get;
            set;
        }

        public bool Continue // Devam Eden
        {
            get;
            set;
        }

        public bool Reanimation // Uyandırma Odasında
        {
            get;
            set;
        }
        public bool AnesthesiaCompleted // Tamamlandı
        {
            get;
            set;
        }

        public bool Rejected // İptal edildi.
        {
            get;
            set;
        }

        public bool OnlyOwnPatient // Yalnız Kendi Hastaları
        {
            get;
            set;
        }

        public DateTime? AdmissionStartDate // Kabul Başlangıç Tarihi
        {
            get;
            set;
        }

        public DateTime? AdmissionEndDate // Kabul Bitiş Tarihi
        {
            get;
            set;
        }

        public string SEProtocolNo // Kabul No
        {
            get;
            set;
        }

        public string PatientNo // Arşiv No
        {
            get;
            set;
        }

        public List<ResSection> Resources
        {
            get;
            set;
        }

        public List<ResSection> SurgeryDepartments
        {
            get;
            set;
        }

        public List<ResSection> SurgeryRooms
        {
            get;
            set;
        }

        public List<ResSection> SurgeryDesks
        {
            get;
            set;
        }

        public List<ResUser> InpatientDoctors
        {
            get;
            set;
        }

        public List<ResUser> SurgeryDoctors
        {
            get;
            set;
        }

        public List<ResUser> AnesthesiaDoctors
        {
            get;
            set;
        }
        public List<SurgeryDefinition> SurgeryProcedures
        {
            get;
            set;
        }

        public string selectedSurgeryProceduresStr
        {
            get;
            set;
        }

        public List<ProvizyonTipi> AdmissionTypes
        {
            get;
            set;
        }

    }


    public class SurgeryWorkListItem : BaseEpisodeActionWorkListItem
    {

        // Yatan hasta ikonları için 
        public bool HasTightContactIsolation
        {
            get;
            set;
        }

        public bool HasFallingRisk
        {
            get;
            set;
        }

        public bool HasDropletIsolation
        {
            get;
            set;
        }

        public bool HasAirborneContactIsolation
        {
            get;
            set;
        }

        public bool HasContactIsolation
        {
            get;
            set;
        }

        // Kolonları İçin 
        public DateTime Date //Tarih
        {
            get;
            set;
        }
        public DateTime SurgeryStartTime //Tarih
        {
            get;
            set;
        }
        public DateTime SurgeryEndTime //Tarih
        {
            get;
            set;
        }
        public string PatientNameSurname //Adı Soyadı
        {
            get;
            set;
        }

        public string EpisodeActionName //İşlem
        {
            get;
            set;
        }

        public string StateName //Durumu
        {
            get;
            set;
        }

        public string StatusName // Ameliyat Durumu--> Ameliyat Başladı/Bitti 
        {
            get;
            set;
        }

        public string SurgeryDepartment //  Ameliyathane Birim 
        {
            get;
            set;
        }

        public string SurgeryRoom //  Ameliyathane Odası 
        {
            get;
            set;
        }

        public string SurgeryDesk //  Ameliyathane Masası 
        {
            get;
            set;
        }

        public string SurgeryDoctorName // Ameliyat Doktor Adı
        {
            get;
            set;
        }

        public string AnesthesiaDoctorName // Ameliyat Doktor Adı
        {
            get;
            set;
        }

        public string InpatientClinic //Servisi
        {
            get;
            set;
        }
        public string InpatientDoctorName // Yatış Doktor Adı
        {
            get;
            set;
        }

        public string SurgeryNote //  Ameliyat Notu 
        {
            get;
            set;
        }

        public string SurgeryResult //  Ameliyat Sonucu 
        {
            get;
            set;
        }

        // Gizli Kolonları için

        public string UniqueRefno // Kimlik No
        {
            get;
            set;
        }

        public string KabulNo //Kabul No
        {
            get;
            set;
        }

        public string AdmissionType // Geliş Sebebi
        {
            get;
            set;
        }

        public string PayerName // Kurumu
        {
            get;
            set;
        }
        public DateTime? BirthDate // Doğum Tarihi
        {
            get;
            set;
        }

        public string FatherName // Baba adı
        {
            get;
            set;
        }

        public string TelNo // Telefon Numarası
        {
            get;
            set;
        }

        public string HastaTuru
        {
            get;
            set;
        }
        public string BasvuruTuru
        {
            get;
            set;
        }

        public string OncelikDurumu
        {
            get;
            set;
        }
        public string Diagnosis
        {
            get;
            set;
        }
    }

}
