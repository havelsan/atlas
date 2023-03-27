using System;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Linq;
using System.ComponentModel;
using System.Text;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class SafeSurgeryChecklistWorkListServiceController
    {
        public SafeSurgeryChecklistWorkListViewModel LoadSafeSurgeryWorkListViewModel()
        {
            var viewModel = new SafeSurgeryChecklistWorkListViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.WorkList = new List<SafeSurgeryChecklistItem>();

                viewModel._SearchCriteria = new SafeSurgeryChecklistSearchCriteria();
                viewModel._SearchCriteria.WorkListStartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                viewModel._SearchCriteria.WorkListEndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                return viewModel;
            }
        }



        public SafeSurgeryChecklistWorkListViewModel GetChecklistWorkList(SafeSurgeryChecklistSearchCriteria _sc)
        {
            string filter = string.Empty;

            var viewModel = new SafeSurgeryChecklistWorkListViewModel();
            viewModel.WorkList = new List<SafeSurgeryChecklistItem>();

            if (_sc == null)
            {
                throw new Exception("Arama kriterleri girilmeden sorgulama yapýlamaz.");
            }

            if (_sc.WorkListStartDate == null || _sc.WorkListEndDate == null)
            {
                if (String.IsNullOrEmpty(_sc.PatientObjectID))
                    throw new Exception("Baþlangýç - Bitiþ Tarihi girilmeden sorgulama yapýlamaz.");
            }
            if (_sc.WorkListStartDate.HasValue)
                _sc.WorkListStartDate = Convert.ToDateTime(_sc.WorkListStartDate.Value.ToShortDateString() + " " + "00:00:00");

            if (_sc.WorkListEndDate.HasValue)
                _sc.WorkListEndDate = Convert.ToDateTime(_sc.WorkListEndDate.Value.ToShortDateString() + " " + "23:59:59");

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                List<SafeSurgeryChecklistItem> checkListItems = new List<SafeSurgeryChecklistItem>();
                if (!string.IsNullOrEmpty(_sc.PatientObjectID))
                {
                    filter += " AND this.Surgery.Episode.Patient.OBJECTID = '" + _sc.PatientObjectID + "' ";
                }
                else
                {
                    filter += " AND this.Surgery.RequestDate BETWEEN " + GetDateAsString(_sc.WorkListStartDate) + " AND " + GetDateAsString(_sc.WorkListEndDate);
                    if (_sc.ActionStatus != null && _sc.ActionStatus.Count > 0)
                    {
                        filter += " AND ( ";
                        if (_sc.ActionStatus.Exists(x => x.TypeID == 0))
                        {
                            filter += " this.CURRENTSTATEDEFID IN (";
                            filter += "'" + SafeSurgeryCheckList.States.BeforeAnesthesia + "', ";
                            filter += "'" + SafeSurgeryCheckList.States.BeforeSurgicalIncision + "', ";
                            filter += "'" + SafeSurgeryCheckList.States.BeforeLeavingSurgery + "', ";
                            filter += "'" + SafeSurgeryCheckList.States.Completed + "', ";
                            filter = filter.Remove(filter.LastIndexOf(',')) + ")";


                        }
                        if (_sc.ActionStatus.Exists(x => x.TypeID == 1))
                        {
                            if (_sc.ActionStatus.Exists(x => x.TypeID == 0))
                            {
                                filter += " OR ";
                            }
                            filter += "this.CURRENTSTATEDEFID IN (";
                            filter += "'" + SafeSurgeryCheckList.States.BeforeSurgicalIncision + "', ";
                            filter += "'" + SafeSurgeryCheckList.States.BeforeLeavingSurgery + "', ";
                            filter += "'" + SafeSurgeryCheckList.States.Completed + "', ";
                            filter = filter.Remove(filter.LastIndexOf(',')) + ")";
                        }
                        if (_sc.ActionStatus.Exists(x => x.TypeID == 2))
                        {
                            if (_sc.ActionStatus.Exists(x => x.TypeID == 0) || _sc.ActionStatus.Exists(x => x.TypeID == 1))
                            {
                                filter += " OR ";
                            }
                            filter += "this.CURRENTSTATEDEFID IN (";
                            filter += "'" + SafeSurgeryCheckList.States.BeforeLeavingSurgery + "', ";
                            filter += "'" + SafeSurgeryCheckList.States.Completed + "', ";
                            filter = filter.Remove(filter.LastIndexOf(',')) + ")";
                        }
                        if (_sc.ActionStatus.Exists(x => x.TypeID == 3))
                        {
                            if (_sc.ActionStatus.Exists(x => x.TypeID == 0) || _sc.ActionStatus.Exists(x => x.TypeID == 1) || _sc.ActionStatus.Exists(x => x.TypeID == 2))
                            {
                                filter += " OR ";
                            }
                            filter += "this.CURRENTSTATEDEFID IN (";
                            filter += "'" + SafeSurgeryCheckList.States.Completed + "', ";
                            filter = filter.Remove(filter.LastIndexOf(',')) + ")";
                        }
                        filter += ")";
                    }
                }

                var list = SafeSurgeryCheckList.GetSafeSurgeryChecklistWL(filter);
                foreach(SafeSurgeryCheckList.GetSafeSurgeryChecklistWL_Class item in list)
                {
                    SafeSurgeryChecklistItem workListItem = new SafeSurgeryChecklistItem();
                    workListItem.PatientNameSurname = item.Name + " " + item.Surname;
                    workListItem.RequestDate = item.RequestDate;
                    if(item.CurrentStateDefID == SafeSurgeryCheckList.States.Completed)
                    {
                        workListItem.isCompleted = true;
                        workListItem.CompletedStatus = "Tamamlandý";
                    }
                    else
                    {
                        workListItem.isCompleted = false;
                        workListItem.CompletedStatus = "Tamamlanmadý";

                    }
                    workListItem.ObjectDefID = item.ObjectDefID.ToString();
                    workListItem.ObjectDefName = item.ObjectDefName;
                    workListItem.ObjectID = (Guid)item.ObjectID;

                    checkListItems.Add(workListItem);
                }
                viewModel.WorkList = checkListItems;

            }
            return viewModel;
        }

        public string GetDateAsString(DateTime? dateTime)
        {
            return "TODATE('" + Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd HH:mm:ss") + "')";
        }



    }
}
namespace Core.Models
{
    public partial class SafeSurgeryChecklistWorkListViewModel
    {
        public List<SafeSurgeryChecklistItem> WorkList;
        public SafeSurgeryChecklistSearchCriteria _SearchCriteria
        {
            get;
            set;
        }

        public SafeSurgeryChecklistWorkListViewModel()
        {
            this._SearchCriteria = new SafeSurgeryChecklistSearchCriteria();
            this.WorkList = new List<SafeSurgeryChecklistItem>();
        }
    }

    [Serializable]
    public class SafeSurgeryChecklistSearchCriteria
    {
        public DateTime? WorkListStartDate
        {
            get;
            set;
        }
        public DateTime? WorkListEndDate
        {
            get;
            set;
        }
        public string PatientObjectID
        {
            get;
            set;
        }
        public List <CheckListObject> ActionStatus
        {
            get;
            set;
        }

    }


    public class SafeSurgeryChecklistItem
    {
        public DateTime? RequestDate
        {
            get;
            set;
        }

        public string PatientNameSurname
        {
            get;
            set;
        }

        public string UniqueRefno
        {
            get;
            set;
        }

        public bool isCompleted
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
        public Guid? ObjectID
        {
            get;
            set;
        }
        public string CompletedStatus
        {
            get;
            set;
        }
    }

    public class CheckListObject
    {
        public string TypeName
        {
            get;
            set;
        }

        public int TypeID
        {
            get;
            set;
        }
    }


}
