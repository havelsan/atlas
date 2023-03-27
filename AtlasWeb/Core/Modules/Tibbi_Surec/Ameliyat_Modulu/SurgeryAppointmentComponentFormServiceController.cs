//$DA10073D
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Text;
using static Core.Controllers.MedicalStuffReportServiceController;
using Newtonsoft.Json;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class SurgeryAppointmentComponentFormServiceController : BaseEpisodeActionWorkListServiceController
    {

        [HttpGet]
        public SurgeryAppointmentComponentFormViewModel getSurgeryAppointmentCompoentViewModel()
        {
            SurgeryAppointmentComponentFormViewModel viewModel = new SurgeryAppointmentComponentFormViewModel();
            viewModel._SearchCriteria = new SurgeryAppointmentListSearchCriteria();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {

                viewModel._SearchCriteria.AppointmentStartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                viewModel._SearchCriteria.AppointmentEndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
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
                    surgeryRoom.Name = surgeryRoom.SurgeryDepartment.Name + " - " + surgeryRoom.Name;
                    viewModel.SurgeryRoomList.Add(surgeryRoom);
                }

                BindingList<ResUser> doctorList = ResUser.DoctorListObjectNQL(objectContext, " AND ISACTIVE = 1");
                viewModel.DoctorList = new List<ResUser>();

                foreach (var doctor in doctorList)
                {
                    viewModel.DoctorList.Add(doctor);
                }

                viewModel._SearchCriteria.SurgeryDepartments = new List<ResSection>();
                //viewModel._SearchCriteria.SurgeryRooms = new List<ResSection>();
               // viewModel._SearchCriteria.Doctors = new List<ResUser>();

            }
            return viewModel;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Yatan_Hasta_Listesi)]
        public List<SurgeryAppointmentListItem> GetSurgeryWorkList(SurgeryAppointmentListSearchCriteria sc)
        {
            List<SurgeryAppointmentListItem> workListItems = new List<SurgeryAppointmentListItem>(); 
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                int workListMaxItemCount = Common.WorklistMaxItemCount();                              
                string whereCriteria = string.Empty;
                string whereCriteria_For_SurgeryAppointment = string.Empty;               

                if (sc.AppointmentStartDate == null || sc.AppointmentEndDate == null)
                {
                    throw new Exception("Başlangıç Bitiş Tarihi girilmeden sorgulama yapılamaz");
                }

                if(sc.isCalledByAppointmentForm == false)
                {
                    if (sc.AppointmentStartDate.HasValue)
                        sc.AppointmentStartDate = Convert.ToDateTime(sc.AppointmentStartDate.Value.ToShortDateString() + " " + "00:00:00");

                    if (sc.AppointmentEndDate.HasValue)
                        sc.AppointmentEndDate = Convert.ToDateTime(sc.AppointmentEndDate.Value.ToShortDateString() + " " + "23:59:59");

                }



                // Hasta seçildi ise diğer sorgular kale alınmayacak
                if (sc.PatientId != null && sc.PatientId != Guid.Empty)
                {
                    whereCriteria_For_SurgeryAppointment = " And this.Patient = '" + sc.PatientId.ToString() + "' ";
                }
                else
                {
                    if(sc.isCalledByAppointmentForm == false)
                    {
                        whereCriteria_For_SurgeryAppointment += " AND this.PLANNEDSURGERYSTARTDATE BETWEEN " + GetDateAsString(sc.AppointmentStartDate) + " AND " + GetDateAsString(sc.AppointmentEndDate);
                    }
                    else
                    {
                        whereCriteria_For_SurgeryAppointment += " AND this.PLANNEDSURGERYSTARTDATE < " + GetDateAsString(sc.AppointmentStartDate) + " AND this.PLANNEDSURGERYENDDATE > " + GetDateAsString(sc.AppointmentStartDate);
                    }

                    /* string whereCriteria_Resource = string.Empty;
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
                     */
                    if (sc.SurgeryDepartments != null)
                    {
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
                    }
                    
                    string whereCriteria_SurgeryRoom = string.Empty;
                    if (sc.SurgeryRooms != null)
                        whereCriteria += " AND this.SURGERYROOM = '" + sc.SurgeryRooms.ObjectID + "'";

                    /*foreach (var resource in sc.SurgeryRooms)
                    {
                        if (string.IsNullOrEmpty(whereCriteria_SurgeryRoom))
                            whereCriteria_SurgeryRoom = " AND this.SURGERYROOM IN (''";
                        whereCriteria_SurgeryRoom += ",'" + resource.ObjectID + "'";
                    }

                    if (!string.IsNullOrEmpty(whereCriteria_SurgeryRoom))
                    {
                        whereCriteria += whereCriteria_SurgeryRoom + ") ";
                    }*/


                    string whereCriteria_SurgeryDoctor = string.Empty;

                    /*foreach (var resource in sc.Doctors)
                    {
                        if (string.IsNullOrEmpty(whereCriteria_SurgeryDoctor))
                            whereCriteria_SurgeryDoctor = " AND this.PROCEDUREDOCTOR IN (''";
                        whereCriteria_SurgeryDoctor += ",'" + resource.ObjectID + "'";
                    }

                    if (!string.IsNullOrEmpty(whereCriteria_SurgeryDoctor))
                    {
                        whereCriteria += whereCriteria_SurgeryDoctor + ") ";
                    }*/
                    if (sc.Doctors != null)
                        whereCriteria += " AND this.ProcedureDoctor = '" + sc.Doctors.ObjectID + "'";

                    whereCriteria_For_SurgeryAppointment += whereCriteria;

                }

                if (!String.IsNullOrEmpty(sc.SubEpisodeProtocolNo))
                {
                    string filterExpression = "";
                    if (sc.SubEpisodeProtocolNo.Contains("-"))
                        filterExpression += " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.SubEpisodeProtocolNo.Trim() + "'";
                    else
                    {
                        filterExpression += " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.SubEpisodeProtocolNo.Trim() + "%'";
                    }
                    if (!String.IsNullOrEmpty(whereCriteria_For_SurgeryAppointment))
                        whereCriteria_For_SurgeryAppointment += filterExpression;
                }

                // SORGULAR

                if (!string.IsNullOrEmpty(whereCriteria_For_SurgeryAppointment)) // Ameliyat Sorgu
                {
                    var SurgeryAppointmentList = SurgeryAppointment.GetSurgeryAppointmentsForWL(objectContext, whereCriteria_For_SurgeryAppointment);
                    foreach (var surgeryAppointmentFWL in SurgeryAppointmentList)
                    {
                        SurgeryAppointmentListItem workListItem = new SurgeryAppointmentListItem();

                        workListItem.AppointmentDate = (DateTime)surgeryAppointmentFWL.PlannedSurgeryStartDate;
                        workListItem.AppointmentDoctor = surgeryAppointmentFWL.ProcedureDoctor.Name;
                        workListItem.AppointmentObjectId = surgeryAppointmentFWL.ObjectID;
                        workListItem.ObjectDefName = surgeryAppointmentFWL.ObjectDef.Name;
                        workListItem.PatientName = surgeryAppointmentFWL.Patient.Name + " " + surgeryAppointmentFWL.Patient.Surname;
                        workListItem.ProtocolNo = surgeryAppointmentFWL.Surgery != null ? surgeryAppointmentFWL.Surgery.SubEpisode.ProtocolNo : "";
                        workListItem.SurgeryDepartment = surgeryAppointmentFWL.MasterResource != null ? surgeryAppointmentFWL.MasterResource.Name : "";
                        workListItem.SurgeryRoom = surgeryAppointmentFWL.SurgeryRoom != null ? surgeryAppointmentFWL.SurgeryRoom.Name : "";
                        workListItem.isApproveCompleted = false;
                        workListItem.isApprovedByDoctor = false;
                        workListItem.isApprovedByHeadDoctor = false;
                        workListItem.isCompleted = false;
                        workListItem.isCancelled = false;
                        workListItem.SurgeryMaterials = surgeryAppointmentFWL.SurgeryAppointmentMaterials.ToList();
                        

                        foreach (var procedure in surgeryAppointmentFWL.SurgeryAppointmentProcedures)
                        {
                            workListItem.SurgeryProcedure += procedure.ProcedureDefinition.Name + ",";
                        }
                        if (!String.IsNullOrEmpty(workListItem.SurgeryProcedure))
                            workListItem.SurgeryProcedure = workListItem.SurgeryProcedure.Remove(workListItem.SurgeryProcedure.LastIndexOf(","), 1);
                        if (surgeryAppointmentFWL.CurrentStateDefID == SurgeryAppointment.States.DoctorApproval)
                        {
                            workListItem.Status = "Doktor Onayında";
                        }else if (surgeryAppointmentFWL.CurrentStateDefID == SurgeryAppointment.States.HeadDoctorApproval)
                        {
                            workListItem.Status = "Başhekim Onayında";
                            workListItem.isApprovedByDoctor = true;
                        }
                        else if (surgeryAppointmentFWL.CurrentStateDefID == SurgeryAppointment.States.Approved)
                        {
                            workListItem.Status = "Onaylandı";
                            workListItem.isApprovedByDoctor = true;
                            workListItem.isApprovedByHeadDoctor = true;
                        }
                        else if (surgeryAppointmentFWL.CurrentStateDefID == SurgeryAppointment.States.DoctorApproval)
                        {
                            workListItem.Status = "İşlem Tamamlandı";
                            workListItem.isApprovedByDoctor = true;
                            workListItem.isApprovedByHeadDoctor = true;
                            workListItem.isCompleted = true;
                        }
                        else
                        {
                            workListItem.Status = "İptal Edildi";
                            workListItem.isCancelled = true;
                        }

                       
                        workListItems.Add(workListItem);
                    }
                }

                workListItems = workListItems.OrderBy(t => t.PatientName).ToList();
                return workListItems;
            }
        }

        [HttpGet]
        public bool UpdateSurgeryAppointment(Guid appointmentObjectId, bool isDoctorApprove, bool isCancelled)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                var surgeryAppointment = objectContext.GetObject<SurgeryAppointment>(appointmentObjectId, false);
                if (surgeryAppointment == null)
                    throw new Exception("Ameliyat Randevusu nesnesi bulunamamıştır");

                if (isCancelled == true)
                {
                    surgeryAppointment.CurrentStateDefID = SurgeryAppointment.States.Cancelled;
                }
                else if (isDoctorApprove == true)
                {
                    if (!Common.CurrentUser.HasRole(TTRoleNames.Tabip))
                        throw new Exception("Bu işlemi yapabilmek için doktor yetkisine sahip olmanız gerekmektedir.");
                    if (Common.CurrentResource.ObjectID == surgeryAppointment.ProcedureDoctor.ObjectID)
                    {
                        bool isHeadDoctorApproveActive = TTObjectClasses.SystemParameter.GetParameterValue("AMELIYATRANDEVUBASHEKIMONAYAKTIF", "FALSE") == "FALSE" ? false : true;

                        if (isHeadDoctorApproveActive == true)
                            surgeryAppointment.CurrentStateDefID = SurgeryAppointment.States.HeadDoctorApproval;
                        else
                            surgeryAppointment.CurrentStateDefID = SurgeryAppointment.States.Approved;
                    }
                    else
                        throw new Exception("Bu işlemi yapabilmek için randevunun doktoru olmanız gerekmektedir.");
                }
                else if (isDoctorApprove == false)
                {
                    if (!Common.CurrentUser.HasRole(TTRoleNames.Bastabip))
                        throw new Exception("Bu işlemi yapabilmek için Baştabip yetkisine sahip olmanız gerekmektedir.");
                    surgeryAppointment.CurrentStateDefID = SurgeryAppointment.States.Approved;
                }
                objectContext.Save();
            }
            return true;
        }

        public List<MasterView> SaveAppointmentMaterial(Guid AppointmentID, Guid ProcedureID, Guid MaterialID, Guid StoreID, int Amount)
        {
            List<MasterView> list = new List<MasterView>();
            using (var objectContext = new TTObjectContext(false))
            {
                SurgeryAppointmentMaterial surgeryMaterial = new SurgeryAppointmentMaterial(objectContext);
                ProcedureDefinition proc = objectContext.GetObject<ProcedureDefinition>(ProcedureID);
                Material material = objectContext.GetObject<Material>(MaterialID);
                Store store = objectContext.GetObject<Store>(StoreID);
                SurgeryAppointment appointment = objectContext.GetObject<SurgeryAppointment>(AppointmentID);
                surgeryMaterial.Procedure = proc;
                surgeryMaterial.Material = material;
                surgeryMaterial.Store = store;
                surgeryMaterial.Amount = Amount;
                surgeryMaterial.SurgeryAppointment = appointment;

                objectContext.Save();

                list = GetSurgeryMaterials(AppointmentID);
            }
            return list;
        }

        [HttpPost]
        public List<Store> GetStoresList()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                MatchingFormViewModel viewModel = new MatchingFormViewModel();
                List<Store> StoreList = Store.GetAllStores(objectContext).ToList();
                StoreList = StoreList.Where(store => store.IsActive == true).ToList();
                objectContext.FullPartialllyLoadedObjects();

                return StoreList;
            }
        }

        [HttpPost]
        public List<MasterView> GetSurgeryMaterials(Guid ApppointmentId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<MasterView> MasterData = new List<MasterView>();
                List<SurgeryAppointmentMaterial> surgeryMaterialList = SurgeryAppointmentMaterial.GetSurgeryAppointmentMaterials(objectContext, ApppointmentId.ToString()).ToList();
                
                if (surgeryMaterialList.Count > 0)
                {
                    foreach (SurgeryAppointmentMaterial material in surgeryMaterialList)
                    {
                        var procExist = MasterData.Where(data => data.Procedure.ObjectID == material.Procedure.ObjectID).FirstOrDefault();
                        if (procExist == null)
                        {
                            MasterView master = new MasterView();
                            master.Details = new List<DetailView>();
                            master.Procedure = material.Procedure;
                            MasterData.Add(master);
                            objectContext.FullPartialllyLoadedObjects();
                            procExist = master;
                        }
                        DetailView detail = new DetailView();
                        detail.MaterialName = material.Material.Name;
                        detail.StoreName = material.Store.Name;
                        detail.Amount = material.Amount;
                        procExist.Details.Add(detail);
                    }
                }

                return MasterData;
            }
        }
    }


}

namespace Core.Models
{


    public class SurgeryAppointmentListItem
    {
        public Guid AppointmentObjectId { get; set; }
        public string ObjectDefName { get; set; }
        public string ProtocolNo { get; set; }
        public string PatientName { get; set; }
        public string Clinic { get; set; }
        public string SurgeryDepartment { get; set; }
        public string SurgeryRoom { get; set; }
        public string SurgeryProcedure { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentDoctor { get; set; }
        public string Status { get; set; }
        public bool isApprovedByDoctor { get; set; }
        public bool isApprovedByHeadDoctor { get; set; }
        public bool isApproveCompleted { get; set; }
        public bool isCompleted { get; set; }
        public bool isCancelled { get; set; }
        public List <SurgeryAppointmentMaterial> SurgeryMaterials { get; set; }
        public List<MasterView> MasterData { get; set; }

    }

    public class SurgeryAppointmentComponentFormViewModel
    {
        public SurgeryAppointmentListSearchCriteria _SearchCriteria { get; set; }
        public List<ResSection> SurgeryDepartmentList { get; set; }
        public List<ResSection> SurgeryRoomList { get; set; }
        public List<ResSection> ResourceList { get; set; }
        public List<ResUser> DoctorList { get; set; }
    }

    public class SurgeryAppointmentListSearchCriteria
    {
        public DateTime? AppointmentStartDate { get; set; }
        public DateTime? AppointmentEndDate { get; set; }
        public List<ResSection> SurgeryDepartments { get; set; }
        public List<ResSection> Resources { get; set; }
        public ResUser Doctors { get; set; }
        public ResSection SurgeryRooms { get; set; }
        public string SubEpisodeProtocolNo { get; set; }
        public Guid? PatientId { get; set; }
        public bool isCalledByAppointmentForm { get; set; }
        public bool searchForAppointmentCount = false;
    }

    public class MasterView
    {
        public ProcedureDefinition Procedure { get; set; }
        public List<DetailView> Details { get; set; }
    }

    public class DetailView
    {
      //  public MasterView Procedure { get; set; }
        public Guid MatchObjectID { get; set; }
        public string MaterialName { get; set; }
        public string StoreName { get; set; }
        public int? Amount { get; set; }

    }

}