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
using TTUtils;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class InfectionCommitteeWorkListServiceController : BaseEpisodeActionWorkListServiceController
    {
        private object renderer;

        [HttpGet]
        public InfectionCommitteeWorkListViewModel LoadInfectionCommitteeWorkListViewModel()
        {
            var viewModel = new InfectionCommitteeWorkListViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.WorkList = new List<InfectionCommitteeWorkListItem>();

                viewModel._SearchCriteria = new InfectionCommitteeWorkListSearchCriteria();
                viewModel._SearchCriteria.WorkListStartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                viewModel._SearchCriteria.WorkListEndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                viewModel._SearchCriteria.MinAge = 0;
                viewModel._SearchCriteria.MaxAge = 150;
                viewModel._SearchCriteria.SelectedState = 0;
                #region Birim Listesi

                /****** Klinik Birim Listesi ******/

                viewModel.ResourceList = new List<ResSection>();
                BindingList<ResSection> query = ResSection.GetPoliclinicAndClinics(objectContext);
                foreach (ResSection section in query)
                {
                    viewModel.ResourceList.Add(section);
                }


                #endregion

                viewModel.DoctorList = ResUser.ClinicDoctorListNQL(null).ToList();
                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Enfeksiyon_Komitesi_Yeni)]
        public InfectionCommitteeWorkListViewModel GetInfectionCommitteeWorkList(InfectionCommitteeWorkListSearchCriteria sc)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                int workListMaxItemCount = Common.WorklistMaxItemCount();
                int counter = 0;

                var CurrentUser = Common.CurrentResource;
                var viewModel = new InfectionCommitteeWorkListViewModel();
                viewModel.WorkList = new List<InfectionCommitteeWorkListItem>();
                viewModel.maxWorklistItemCount = 0;
                string filterExp = string.Empty;

                if (sc.WorkListStartDate.HasValue)
                    sc.WorkListStartDate = Convert.ToDateTime(sc.WorkListStartDate.Value.ToShortDateString() + " " + "00:00:00");

                if (sc.WorkListEndDate.HasValue)
                    sc.WorkListEndDate = Convert.ToDateTime(sc.WorkListEndDate.Value.ToShortDateString() + " " + "23:59:59");

                // Hasta seçildi ise diğer sorgular kale alınmayacak Konsültasyon , inPatientPhysicianApplication
                if (!string.IsNullOrEmpty(sc.PatientObjectID))
                {

                    filterExp = filterExp + " AND THIS.EPISODE.PATIENT.OBJECTID = '" + sc.PatientObjectID + "' ";
                }

                if (!String.IsNullOrEmpty(sc.ProtocolNo))
                {
                    if (sc.ProtocolNo.Contains("-"))
                        filterExp = filterExp + " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                    else
                    {
                        filterExp = filterExp + " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";

                    }
                }

                if (sc.Resources != null)
                {
                    if (sc.Resources.Count > 0)
                    {
                        List<Guid> resourceID = new List<Guid>();
                        foreach (ResSection section in sc.Resources)
                            resourceID.Add(section.ObjectID);
                        if (string.IsNullOrEmpty(filterExp))
                            filterExp = " AND " + Common.CreateFilterExpressionOfGuidList(filterExp, "MASTERRESOURCE", resourceID);
                        else
                            filterExp = Common.CreateFilterExpressionOfGuidList(filterExp, "MASTERRESOURCE", resourceID);
                    }

                }

                if(sc.SelectedDoctor != null)
                {
                    if (sc.SelectedDoctor.Count > 0)
                    {
                        if (string.IsNullOrEmpty(filterExp))
                            filterExp = " AND " + Common.CreateFilterExpressionOfGuidList(filterExp, "PROCEDUREDOCTOR", sc.SelectedDoctor);
                        else
                            filterExp = Common.CreateFilterExpressionOfGuidList(filterExp, "PROCEDUREDOCTOR", sc.SelectedDoctor);
                    }
                }

                if (sc.MaxAge < 150)
                {
                    DateTime maxDate = Common.RecTime().AddYears(-sc.MaxAge);
                    filterExp = filterExp + " AND THIS.EPISODE.PATIENT.BIRTHDATE >= " + Globals.CreateNQLToDateParameter(maxDate);
                }

                if (sc.MinAge > 0)
                {
                    DateTime minDate = Common.RecTime().AddYears(-sc.MinAge);
                    filterExp = filterExp + " AND THIS.EPISODE.PATIENT.BIRTHDATE <= " + Globals.CreateNQLToDateParameter(minDate);
                }

                if (sc.SelectedState == 0)
                    filterExp = filterExp + "AND CURRENTSTATE IS UNCOMPLETED";
                else if (sc.SelectedState == 1)
                    filterExp = filterExp + "AND CURRENTSTATE IS SUCCESSFUL";
                else if (sc.SelectedState == 3)
                    filterExp = filterExp + "AND CURRENTSTATE IS UNSUCCESSFUL";

                BindingList<InfectionCommittee.InfectionCommitteeWorkListNQL_Class> workListItems = InfectionCommittee.InfectionCommitteeWorkListNQL(sc.WorkListStartDate.Value, sc.WorkListEndDate.Value, filterExp);
                foreach (var wlItem in workListItems)
                {
                    InfectionCommittee infectionCommittee = (InfectionCommittee)objectContext.GetObject(wlItem.ObjectID.Value, wlItem.ObjectDefID.Value);
                    if (this.HasWorkListWorkListRight(objectContext, infectionCommittee))
                    {
                        InfectionCommitteeWorkListItem workListItem = new InfectionCommitteeWorkListItem();
                        workListItem.ObjectID = wlItem.ObjectID.Value;
                        workListItem.ObjectDefID = wlItem.ObjectDefID.Value.ToString();
                        workListItem.ObjectDefName = wlItem.ObjectDefName;
                        workListItem.Date = wlItem.Islem_tarihi.Value;
                        workListItem.PatientNameSurname = wlItem.Adsoyad.ToString();
                        workListItem.KabulNo = wlItem.Kabul_no;
                        workListItem.UniqueRefno = wlItem.Tc_kimlik_no.ToString();
                        workListItem.MasterResource = wlItem.Servis;
                        workListItem.RoomResource = wlItem.Yatak_servis;
                        workListItem.Room = wlItem.Oda.ToString();
                        workListItem.Bed = wlItem.Yatak.ToString();
                        if (infectionCommittee.InfectionCommitteeDetails[0].DrugOrder.RequestedByUser != null)
                            workListItem.DoctorName = infectionCommittee.InfectionCommitteeDetails[0].DrugOrder.RequestedByUser.Person.Name + " " + infectionCommittee.InfectionCommitteeDetails[0].DrugOrder.RequestedByUser.Person.Surname;
                        workListItem.InpatientDate = wlItem.Yatis_tarihi.Value;
                        viewModel.WorkList.Add(workListItem);
                    }
                }
                viewModel.WorkList = viewModel.WorkList.OrderByDescending(dr => dr.Date).ToList();
                return viewModel;
            }
        }
    }
}
namespace Core.Models
{
    public partial class InfectionCommitteeWorkListViewModel : BaseEpisodeActionWorkListFormViewModel
    {
        public List<InfectionCommitteeWorkListItem> WorkList;
        public InfectionCommitteeWorkListSearchCriteria _SearchCriteria
        {
            get;
            set;
        }

        public List<ResSection> ResourceList { get; set; }

        public List<ResUser.ClinicDoctorListNQL_Class> DoctorList { get; set; }

        public InfectionCommitteeWorkListViewModel()
        {
            this._SearchCriteria = new InfectionCommitteeWorkListSearchCriteria();
            this.WorkList = new List<InfectionCommitteeWorkListItem>();
        }
    }

    [Serializable]
    public class InfectionCommitteeWorkListSearchCriteria : BaseEpisodeActionWorkListSearchCriteria
    {
        public List<ResSection> Resources
        {
            get;
            set;
        }
        public string ProtocolNo { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int SelectedState { get; set; }
        public List<Guid> SelectedDoctor { get; set; }
    }


    public class InfectionCommitteeWorkListItem : BaseEpisodeActionWorkListItem
    {
        public DateTime Date
        {
            get;
            set;
        }
        public string PatientNameSurname
        {
            get;
            set;
        }
        public string KabulNo
        {
            get;
            set;
        }

        public string UniqueRefno
        {
            get;
            set;
        }

        public string MasterResource
        {
            get;
            set;
        }
        public string RoomResource
        {
            get;
            set;
        }
        public string Room
        {
            get;
            set;
        }
        public string Bed
        {
            get;
            set;
        }
        public string DoctorName
        {
            get;
            set;
        }
        public DateTime InpatientDate
        {
            get;
            set;
        }
    }

}
