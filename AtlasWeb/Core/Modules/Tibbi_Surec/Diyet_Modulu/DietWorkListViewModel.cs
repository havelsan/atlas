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
using TTStorageManager.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class DietWorkListServiceController : Controller
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Diyet_Uzmani)]
        public List<DietWorkListItemModel> GetDietActionWorkList(DietWorkListSearchCriteria dwlssc)
        {
            string whereCriteria = " WHERE 1=1";
            if (dwlssc.diettype != null && dwlssc.diettype.ObjectID != null && dwlssc.diettype.ObjectID != Guid.Empty)
            {
                whereCriteria += " AND THIS.ProcedureObject.OBJECTID='" + dwlssc.diettype.ObjectID + "'";
            }

            if (dwlssc.physicalstateclinic != null && dwlssc.physicalstateclinic.ObjectID != null && dwlssc.physicalstateclinic.ObjectID != Guid.Empty)
            {
                whereCriteria += " AND THIS.PERIODICORDER.INPATIENTPHYSICIANAPPLICATION.INPATIENTTREATMENTCLINICAPP.BASEINPATIENTADMISSION.PHYSICALSTATECLINIC.OBJECTID='" + dwlssc.physicalstateclinic.ObjectID + "'";
            }

            if (dwlssc.treatmentclinic != null && dwlssc.treatmentclinic.ObjectID != null && dwlssc.treatmentclinic.ObjectID != Guid.Empty)
            {
                whereCriteria += " AND THIS.PERIODICORDER.INPATIENTPHYSICIANAPPLICATION.INPATIENTTREATMENTCLINICAPP.MASTERRESOURCE.OBJECTID='" + dwlssc.treatmentclinic.ObjectID + "'";
            }

            if (dwlssc.responsibledoctor != null && dwlssc.responsibledoctor.ObjectID != null && dwlssc.responsibledoctor.ObjectID != Guid.Empty)
            {
                whereCriteria += " AND THIS.PERIODICORDER.INPATIENTPHYSICIANAPPLICATION.INPATIENTTREATMENTCLINICAPP.PROCEDUREDOCTOR.OBJECTID='" + dwlssc.responsibledoctor.ObjectID + "'";
            }
            
            if (dwlssc.workListStartDate != null)
            {
                whereCriteria += " AND THIS.WORKLISTDATE >= TODATE('" + Convert.ToDateTime(dwlssc.workListStartDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }

            if (dwlssc.workListEndDate != null)
            {
                whereCriteria += " AND THIS.WORKLISTDATE <= TODATE('" + Convert.ToDateTime(dwlssc.workListEndDate.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }

            if (!String.IsNullOrEmpty(dwlssc.dietWorkListStateItem))
            {
                whereCriteria += " AND THIS.CURRENTSTATEDEFID ='" + dwlssc.dietWorkListStateItem + "'";
            }

            /* SADECE İLİŞKİL OLDUĞU BİRİME AİT DİYET DETAYLARI*/
            if (!TTUser.CurrentUser.IsSuperUser)
            {
                var _res = Common.CurrentResource.UserResources;
                string _resCriteriea = " AND THIS.MASTERRESOURCE IN (''";

                foreach (UserResource item in _res)
                {
                    _resCriteriea += ",'" + item.Resource.ObjectID + "'";
                }

                _resCriteriea += ")";

                if (_res.Count > 0)
                {
                    whereCriteria += _resCriteriea;
                }
            }
            
            if (!dwlssc.inpatientStatus) 
            {
                  whereCriteria += " AND THIS.PERIODICORDER.INPATIENTPHYSICIANAPPLICATION.CURRENTSTATEDEFID NOT IN  ('" + InPatientPhysicianApplication.States.Discharged + "','"+ InPatientPhysicianApplication.States.PreDischarged + "')";
            }

            System.ComponentModel.BindingList<DietOrderDetail.GetDietOrderDetailForWorkList_Class> workList = DietOrderDetail.GetDietOrderDetailForWorkList(whereCriteria);
            List<DietWorkListItemModel> dwlList = new List<DietWorkListItemModel>();
            DietWorkListItemModel dwl = null;
            foreach (var item in workList)
            {
                dwl = new DietWorkListItemModel();
                dwl.Bed = item.Yatakadi;
                dwl.Breakfast = item.Breakfast.HasValue ? item.Breakfast.Value : false;
                dwl.DietType = item.Name;
                dwl.Dinner = item.Dinner.HasValue ? item.Dinner.Value : false;
                dwl.Lunch = item.Lunch.HasValue ? item.Lunch.Value : false;
                dwl.NightBreakfast = item.NightBreakfast.HasValue ? item.NightBreakfast.Value : false;
                dwl.ObjectDefID = item.ObjectDefID.HasValue ? item.ObjectDefID.Value.ToString() : "";
                dwl.ObjectDefName = item.Objectdefname.ToString();
                dwl.ObjectID = item.ObjectID.HasValue ? item.ObjectID.Value.ToString() : "";
                dwl.PatientNameSurname = item.Hastaadi + " " + item.Hastasoyadi;
                dwl.PatientStatus = item.PatientStatus.HasValue ? Common.GetEnumValueDefOfEnumValue(item.PatientStatus.Value).DisplayText : "";
                dwl.PhysicianClinic = item.Yattigiklinikadi;
                dwl.ResponsibleDoctor = item.Sorumludoktoradi;
                dwl.Room = item.Odaadi;
                dwl.RoomGroupName = item.Odagrupadi;
                dwl.Snack1 = item.Snack1.HasValue ? item.Snack1.Value : false;
                dwl.Snack2 = item.Snack2.HasValue ? item.Snack2.Value : false;
                dwl.Snack3 = item.Snack3.HasValue ? item.Snack3.Value : false;
                dwl.TreatmentClinic = item.Tedaviklinikadi;
                dwl.CurrentState = item.Currentstatename.ToString();
                dwl.WorkListDate = Convert.ToDateTime(item.WorkListDate.Value.ToShortDateString());
                dwl.CurrentSateDefID = item.CurrentStateDefID.HasValue ? item.CurrentStateDefID.Value.ToString() : "";
                dwl.OrderDescription = item.OrderDescription;
                dwlList.Add(dwl);
            }

            return dwlList;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Diyet_Uzmani)]
        public void ApproveAllSelectedDietRecordsByID(List<DietWorkListItemModel> dwli)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                for (int i = 0; i < dwli.Count; i++)
                {
                    DietOrderDetail dod = objectContext.GetObject(new Guid(dwli[i].ObjectID), dwli[i].ObjectDefName) as DietOrderDetail;
                    if (dod.CurrentStateDefID == DietOrderDetail.States.Execution)
                    {
                        dod.CurrentStateDefID = DietOrderDetail.States.Completed;
                    }
                }

                objectContext.Save();
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Diyet_Uzmani)]
        public List<DietRationCountItem> GetDietOrderDetailRationCount(DietWorkListRaitonSearchCriteria dwlrsc)
        {
            string whereCriteria = string.Empty;

            whereCriteria = createWhereCriteria(dwlrsc, true);

            List<DietOrderDetail.GetDietOrderDetailRationCount_Class> workList = DietOrderDetail.GetDietOrderDetailRationCount(whereCriteria).ToList();
            workList = workList.OrderBy(x => x.Name).ToList();

            List<DietWorkListItemModel> dwlList = new List<DietWorkListItemModel>();
            List<DietRationCountItem> drciList = null;
            DietRationCountItem drci = null;

            if (workList.Count > 0)
            {
                drciList = new List<DietRationCountItem>();
                int index = 0;
                foreach (var item in workList)
                {
                    bool isNew = drci == null || drci.DietName != item.Name ? true : false;

                    if (isNew )
                    {
                        if (index > 0)
                        {
                            drci.TotalCount = drci.BreakfastCount + drci.LunchCount + drci.DinnerCount + drci.NightBreakfastCount + drci.Snack1Count + drci.Snack2Count + drci.Snack3Count;
                            drciList.Add(drci);
                        }
                        drci = new DietRationCountItem();

                        drci.DietName = item.Name;
                    }

                    if (item.Type.ToString() == "Breakfast")
                    {
                        drci.BreakfastCount = Convert.ToInt32(item.Count);
                    }
                    else if (item.Type.ToString() == "Lunch")
                    {
                        drci.LunchCount = Convert.ToInt32(item.Count);
                    }
                    else if(item.Type.ToString() == "Dinner")
                    {
                        drci.DinnerCount = Convert.ToInt32(item.Count);
                    }
                    else if(item.Type.ToString() == "NightBreakfast")
                    {
                        drci.NightBreakfastCount = Convert.ToInt32(item.Count);
                    }
                    else if(item.Type.ToString() == "Snack1")
                    {
                        drci.Snack1Count = Convert.ToInt32(item.Count);
                    }
                    else if(item.Type.ToString() == "Snack2")
                    {
                        drci.Snack2Count = Convert.ToInt32(item.Count);
                    }
                    else if (item.Type.ToString() == "Snack3")
                    {
                        drci.Snack3Count = Convert.ToInt32(item.Count);
                    }

                    index++;

                    
                }

                drciList.Add(drci);
                drci.TotalCount = drci.BreakfastCount + drci.LunchCount + drci.DinnerCount + drci.NightBreakfastCount + drci.Snack1Count + drci.Snack2Count + drci.Snack3Count;

                return drciList;
            }
            else
                return null;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Diyet_Uzmani)]
        public void SetDietOrderDetailIsReported(DietWorkListRaitonSearchCriteria dwlrsc)
        {
            string whereCriteria = string.Empty;

            whereCriteria = createWhereCriteria(dwlrsc, false);

            using (var objectContext = new TTObjectContext(false))
            {
                List<DietOrderDetail> workList = DietOrderDetail.GetDietOrderDetaillistForReport(objectContext,whereCriteria).ToList();

                foreach (DietOrderDetail diet in workList)
                {
                    if (dwlrsc.additionalReport && diet.IsReported == false)
                        diet.AdditionalRation = true;// ek rasyon olarak alındı bilgisi

                    diet.IsReported = true;

                    if (diet.ReportDate == null)
                        diet.ReportDate = Common.RecTime();
                }

                objectContext.Save();
            }

        }

        private string createWhereCriteria(DietWorkListRaitonSearchCriteria dwlrsc,bool getAllreadyReported)
        {
            string whereCriteria = string.Empty;

            if (dwlrsc.workListStartDate != null)
            {
                whereCriteria += " AND THIS.WORKLISTDATE >= TODATE('" + Convert.ToDateTime(dwlrsc.workListStartDate.Value.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }

            if (dwlrsc.workListEndDate != null)
            {
                whereCriteria += " AND THIS.WORKLISTDATE <= TODATE('" + Convert.ToDateTime(dwlrsc.workListEndDate.Value.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }

            if (dwlrsc.treatmentclinic != null && dwlrsc.treatmentclinic.ObjectID.ToString() != "00000000-0000-0000-0000-000000000000")
                whereCriteria += " AND THIS.PERIODICORDER.INPATIENTPHYSICIANAPPLICATION.INPATIENTTREATMENTCLINICAPP.MASTERRESOURCE.OBJECTID = '" + dwlrsc.treatmentclinic.ObjectID.ToString() + "'";

            if (dwlrsc.physicalstateclinic != null && dwlrsc.physicalstateclinic.ObjectID != null && dwlrsc.physicalstateclinic.ObjectID.ToString() != "00000000-0000-0000-0000-000000000000")
                whereCriteria += " AND THIS.PERIODICORDER.INPATIENTPHYSICIANAPPLICATION.INPATIENTTREATMENTCLINICAPP.BASEINPATIENTADMISSION.PHYSICALSTATECLINIC.OBJECTID = '" + dwlrsc.physicalstateclinic.ObjectID.ToString() + "'";

            if (!(dwlrsc.includeReported == true && getAllreadyReported == true))
            {
                whereCriteria += " AND IFNULL(IsReported,0) = 0";
            }

            whereCriteria += " AND CURRENTSTATE = '" + DietOrderDetail.States.Completed + "'";

            return whereCriteria;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<MealTypes> GetMealTypes()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var res = MealTypes.GetAllMealTypes(objectContext, "").ToList<MealTypes>();
                objectContext.FullPartialllyLoadedObjects();
                return res;
            }
        }
    }
}

namespace Core.Models
{
    public partial class DietWorkListViewModel
    {
        public List<DietWorkListItemModel> DietActionList;
        public DietWorkListSearchCriteria _dietWorkListSearchCriteria
        {
            get;
            set;
        }

        public DietWorkListViewModel()
        {
            this._dietWorkListSearchCriteria = new DietWorkListSearchCriteria();
            this.DietActionList = new List<DietWorkListItemModel>();
        }
    }

    public class DietWorkListItemModel
    {
        public string ObjectID
        {
            get;
            set;
        }

        public string ObjectDefID
        {
            get;
            set;
        }

        public string ObjectDefName
        {
            get;
            set;
        }

        public string DietType
        {
            get;
            set;
        }

        public bool Breakfast
        {
            get;
            set;
        }

        public bool Lunch
        {
            get;
            set;
        }

        public bool Dinner
        {
            get;
            set;
        }

        public bool NightBreakfast
        {
            get;
            set;
        }

        public bool Snack1
        {
            get;
            set;
        }

        public bool Snack2
        {
            get;
            set;
        }

        public bool Snack3
        {
            get;
            set;
        }

        public string PatientNameSurname
        {
            get;
            set;
        }

        public string PatientStatus
        {
            get;
            set;
        }

        public string TreatmentClinic
        {
            get;
            set;
        }

        public string PhysicianClinic
        {
            get;
            set;
        }

        public string RoomGroupName
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

        public string ResponsibleDoctor
        {
            get;
            set;
        }

        public string CurrentState
        {
            get;
            set;
        }

        public DateTime WorkListDate
        {
            get;
            set;
        }

        public string CurrentSateDefID
        {
            get;
            set;
        }

        public string OrderDescription
        {
            get;
            set;
        }
    }

    public class DietWorkListSearchCriteria
    {
        public DateTime workListStartDate
        {
            get;
            set;
        }

        public DateTime workListEndDate
        {
            get;
            set;
        }

        public ResClinic physicalstateclinic
        {
            get;
            set;
        }

        public ResClinic treatmentclinic
        {
            get;
            set;
        }

        public ResUser responsibledoctor
        {
            get;
            set;
        }

        public DietDefinition diettype
        {
            get;
            set;
        }

        public string dietWorkListStateItem
        {
            get;
            set;
        }

        public bool inpatientStatus
        {
            get;
            set;
        }

        public DietWorkListSearchCriteria()
        {
            //this.workListStartDate = DateTime.Now;
            //this.workListEndDate = DateTime.Now;
            //this.physicalstateclinic = null;
            //this.treatmentclinic = null;
            //this.responsibledoctor = null;
            //this.diettype = null;
            //this.dietWorkListStateItem = String.Empty;
        }
    }

    public class DietWorkListRaitonSearchCriteria
    {
        public DateTime? workListStartDate
        {
            get;
            set;
        }

        public DateTime? workListEndDate
        {
            get;
            set;
        }

        public ResClinic physicalstateclinic
        {
            get;
            set;
        }

        public ResClinic treatmentclinic
        {
            get;
            set;
        }

        public bool includeReported { get; set; }//raporlananları da getir

        public bool additionalReport { get; set; }//ek rasyon olup olmadığını tutar

        public DietWorkListRaitonSearchCriteria()
        {
            //this.physicalstateclinic = new ResClinic();
            //this.treatmentclinic = new ResClinic();
        }
    }

    public class DietRationCountItem
    {
        public int BreakfastCount { get; set; }
        public int LunchCount { get; set; }
        public int DinnerCount { get; set; }
        public int NightBreakfastCount { get; set; }
        public int Snack1Count { get; set; }
        public int Snack2Count { get; set; }
        public int Snack3Count { get; set; }
        public string DietName { get; set; }
        public int TotalCount { get; set; }

        public DietRationCountItem()
        {
            this.BreakfastCount = 0;
            this.LunchCount = 0;
            this.DinnerCount = 0;
            this.NightBreakfastCount = 0;
            this.Snack1Count = 0;
            this.Snack2Count = 0;
            this.Snack3Count = 0;
            this.TotalCount = 0;
        }
    }


 
}