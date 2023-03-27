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
    public class OrtezProtezWorkListServiceController : Controller
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Ortez_Protez_Is_Listesi)]
        public List<OrtezProtezWorkListItemModel> GetOrtezProtezActionWorkList(OrtezProtezWorkListSearchCriteria dwlssc)
        {
            string whereCriteria = " ";
            if (!string.IsNullOrEmpty(dwlssc.kabulNo))
            {
                whereCriteria += " AND THIS.ORTHESISPROSTHESISREQUEST.SubEpisode.ProtocolNo= '" + dwlssc.kabulNo + "'";
            }
            else
            {
                if (dwlssc.patienttype == 0)//ayaktan
                {
                    whereCriteria += " AND THIS.Episode.PatientStatus ='" + dwlssc.patienttype + "'";
                }
                else if (dwlssc.patienttype == 1) //Yatan
                    whereCriteria += " AND THIS.Episode.PatientStatus IN(1,2,3)";

                if (dwlssc.workListStartDate != null)
                {
                    whereCriteria += " \t AND THIS.ORTHESISPROSTHESISREQUEST.RequestDate >= TODATE('" + Convert.ToDateTime(dwlssc.workListStartDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                }

                if (dwlssc.workListEndDate != null)
                {
                    whereCriteria += " AND THIS.ORTHESISPROSTHESISREQUEST.RequestDate <= TODATE('" + Convert.ToDateTime(dwlssc.workListEndDate.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                }

                if (dwlssc.requesterDoctor != null)
                {
                    TTUser _user = TTUser.GetAllUsers().Where(u => u.TTObjectID == dwlssc.requesterDoctor.ObjectID).First();

                    whereCriteria += " AND THIS.ORTHESISPROSTHESISREQUEST.ProcedureDoctor= '" + dwlssc.requesterDoctor.ObjectID + "'";/*THIS.ORTHESISPROSTHESISREQUEST.RequesterUsr =*/
                }

                if (!string.IsNullOrEmpty(dwlssc.uniqueRefno))
                {
                    whereCriteria += " AND THIS.Episode.Patient.UniqueRefNo= '" + dwlssc.uniqueRefno + "'";
                }
                else if (!string.IsNullOrEmpty(dwlssc.patientObjectID))
                {
                    whereCriteria += " AND THIS.Episode.Patient.OBJECTID ='" + dwlssc.patientObjectID + "'";
                }
            }

            if (dwlssc.ortezProtezWorkListStateItem != null && dwlssc.ortezProtezWorkListStateItem.Count > 0)
            {
                System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
                string comma = "";
                _tempString.Append(" AND THIS.ORTHESISPROSTHESISREQUEST.CURRENTSTATEDEFID IN(");

                for (int i = 0; i < dwlssc.ortezProtezWorkListStateItem.Count; i++)
                {
                    _tempString.Append(comma);
                    _tempString.Append("'" + dwlssc.ortezProtezWorkListStateItem[i].StateDefID + "'");
                    comma = ",";
                    //var s = TTDefinitionManagement.TTObjectDefManager.Instance.AllTTObjectStateDefs[new Guid(dwlssc.ortezProtezWorkListStateItem[i].StateDefID)];
                    //_tempString += ",'STATES." + s.Name.ToUpperInvariant() + "'";
                }
                _tempString.Append(") ");
                //whereCriteria += " AND THIS.ORTHESISPROSTHESISREQUEST.CURRENTSTATE IN(" + _tempString + ")";
                //whereCriteria += " AND THIS.ORTHESISPROSTHESISREQUEST.CURRENTSTATEDEFID IN(" + _tempString + ")";
                whereCriteria += _tempString.ToString();
            }
            else
            {
                System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
                string comma = "";
                _tempString.Append(" AND THIS.ORTHESISPROSTHESISREQUEST.CURRENTSTATEDEFID IN(");

                EpisodeActionWorkListServiceController eawsc = new EpisodeActionWorkListServiceController();
                EpisodeActionWorkListServiceController.StateOutputDVO sud = new EpisodeActionWorkListServiceController.StateOutputDVO();

                List<EpisodeActionWorkListItem> _episodeActionWorkListItems = new List<EpisodeActionWorkListItem>();
                EpisodeActionWorkListItem _episodeActionWorkListItem = new EpisodeActionWorkListItem();

                _episodeActionWorkListItem.ObjectDefName = "ORTHESISPROSTHESISREQUEST";
                _episodeActionWorkListItem.ObjectDefID = "29f8be50-7930-426f-94f5-83536cc7a4c4";
                _episodeActionWorkListItems.Add(_episodeActionWorkListItem);

                sud = eawsc.GetEpisodeActionStateDefinition(_episodeActionWorkListItems, "e0444b60-fa7f-40bc-ba42-8f06556aee7c");

                for (int i = 0; i < sud.WorkListSearchStateItem.Count; i++)
                {
                    _tempString.Append(comma);
                    _tempString.Append("'" + sud.WorkListSearchStateItem[i].StateDefID + "'");
                    comma = ",";
                }
                _tempString.Append(") ");
                whereCriteria += _tempString.ToString();

                eawsc.Dispose();
            }

            if (!TTUser.CurrentUser.IsSuperUser)
            {
                var _res = Common.CurrentResource.UserResources;
                string _resCriteriea = " AND THIS.ORTHESISPROSTHESISREQUEST.MASTERRESOURCE IN (''";

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


            System.ComponentModel.BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisForWorkList_Class> workList = OrthesisProsthesisProcedure.GetOrthesisProsthesisForWorkList(whereCriteria);
            List<OrtezProtezWorkListItemModel> dwlList = new List<OrtezProtezWorkListItemModel>();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                OrtezProtezWorkListItemModel dwl = null;
                WorkListDefinition workListDefinition = getWorkListDefinition();

                foreach (var item in workList)
                {
                    EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject(item.Episodeactionid.Value, "EPISODEACTION");

                    if (dwlList.Count > 0 && dwlList[dwlList.Count - 1].ProcedureObjectID == item.Procid.ToString())
                    {
                        continue;//aynı objectid li kayıt gelirse brancdate i büyük olan kalsın sen devam et o state e geçtiği en son tarih
                    }
                    else
                    {
                        if (TTUser.CurrentUser.HasRight(episodeAction.CurrentStateDef.FormDef, episodeAction, workListDefinition.RightDefID.Value))
                        {
                            dwl = new OrtezProtezWorkListItemModel();
                            dwl.ObjectID = item.Episodeactionid.HasValue ? item.Episodeactionid.ToString() : "0";
                            dwl.Amount = item.Procedureamount.HasValue ? item.Procedureamount.ToString() : "0";
                            dwl.BranchDate = item.BranchDate.HasValue ? item.BranchDate.Value : DateTime.MinValue;
                            dwl.ProcedureName = item.Procedurename;
                            dwl.ProcedureCode = item.Procedurecode;
                            dwl.CodeandName = item.Procedurecode + " - " + item.Procedurename;
                            dwl.CurrentState = item.Currentstate.ToString();
                            dwl.Kurum = item.Kurum != null ? item.Kurum.ToString() : "";
                            dwl.ProcedureObjectID = item.Procid.HasValue ? item.Procid.ToString() : "0";
                            dwl.PatientNameSurname = item.Hastaadi + " " + item.Hastasoyadi;
                            dwl.Protocolno = item.ProtocolNo.HasValue ? item.ProtocolNo.ToString() : "0";
                            dwl.Side = item.Side.HasValue ? Common.GetEnumValueDefOfEnumValue(item.Side).ToString() : "";
                            dwl.SigortaliTuruAdi = item.sigortaliTuruAdi != null ? item.sigortaliTuruAdi.ToString() : "";
                            dwl.Technician = item.Technician != null ? item.Technician.ToString() : "";
                            dwl.UniqueRefno = item.UniqueRefNo.HasValue ? item.UniqueRefNo.ToString() : "";
                            dwl.RequestDate = item.RequestDate.HasValue ? item.RequestDate.Value : DateTime.MinValue;
                            dwl.KabulNo = item.Kabulno != null ? item.Kabulno.ToString() : "";

                            dwlList.Add(dwl);
                        }
                    }
                }
            }

            return dwlList;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Ortez_Protez_Is_Listesi)]
        public OrtezProtezWorkListSearchCriteria GetModelInfo()
        {
            UserOption _userOption = GetUserOption();
            OrtezProtezWorkListSearchCriteria _search = new OrtezProtezWorkListSearchCriteria();

            if (_userOption == null || _userOption.OptionValue == null)
            {
                _search.workListStartDate = Convert.ToDateTime(TTObjectClasses.SystemParameter.GetParameterValue("ORTEZWORKLISTSTARTDATE", DateTime.Now.AddDays(-30).ToString("dd.MM.yyyy")));
                _search.workListEndDate = Common.RecTime();
                _search.patienttype = -1;
                _search.kabulNo = null;
                _search.uniqueRefno = null;
                _search.patientObjectID = null;
            }
            else
            {
                _search = ((Core.Models.OrtezProtezWorkListSearchCriteria)_userOption.OptionValue);
                _search.workListStartDate = Convert.ToDateTime(TTObjectClasses.SystemParameter.GetParameterValue("ORTEZWORKLISTSTARTDATE", DateTime.Now.AddDays(-30).ToString("dd.MM.yyyy")));
                _search.workListEndDate = Common.RecTime();
                _search.kabulNo = null;
                _search.uniqueRefno = null;
                _search.patientObjectID = null;
                _search.requesterDoctor = null;
                //_search.patienttype = -1;
                //_search.ortezProtezWorkListStateItem = ((Core.Models.OrtezProtezWorkListSearchCriteria)_userOption.OptionValue).ortezProtezWorkListStateItem;

            }

            return _search;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Ortez_Protez_Is_Listesi)]
        public void SaveUserOption(OrtezProtezWorkListSearchCriteria userOptionInputDVO)
        {

            ResUser myUser = Common.CurrentResource;
            myUser.SaveUserOptionValue(UserOptionType.OrthesisWorklistSearchFilter, userOptionInputDVO);
        }

        [HttpPost]
        public UserOption GetUserOption()
        {

            ResUser myUser = Common.CurrentResource;
            UserOption myUserOption = myUser.GetUserOption(UserOptionType.OrthesisWorklistSearchFilter);
            return myUserOption;
        }

        protected virtual WorkListDefinition getWorkListDefinition()
        {
            //TODO BB, worklistdef i şimdilik böyle çektim. Değişecek
            TTObjectContext objectContext = new TTObjectContext(true);
            WorkListDefinition _workListDefinition = (WorkListDefinition)objectContext.GetObject(new Guid("e0444b60-fa7f-40bc-ba42-8f06556aee7c"), "WorkListDefinition");
            return _workListDefinition;
        }

    }
}

namespace Core.Models
{
    public partial class OrtezProtezWorkListViewModel
    {
        public List<OrtezProtezWorkListItemModel> OrtezProtezActionList;
        public OrtezProtezWorkListSearchCriteria _ortezProtezWorkListSearchCriteria
        {
            get;
            set;
        }

        public OrtezProtezWorkListViewModel()
        {
            this._ortezProtezWorkListSearchCriteria = new OrtezProtezWorkListSearchCriteria();
            this.OrtezProtezActionList = new List<OrtezProtezWorkListItemModel>();
        }
    }

    public class OrtezProtezWorkListItemModel
    {
        public string ObjectID
        {
            get;
            set;
        }
        public string UniqueRefno { get; set; }
        public string PatientNameSurname { get; set; }
        public DateTime RequestDate { get; set; }
        public string Amount { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureCode { get; set; }
        public string CodeandName { get; set; }
        public string ProcedureObjectID { get; set; }
        public string Side { get; set; }
        public string Technician { get; set; }
        public string Protocolno { get; set; }
        public string Kurum { get; set; }
        public string SigortaliTuruAdi { get; set; }
        public DateTime BranchDate { get; set; }
        public string CurrentState { get; set; }
        public string KabulNo { get; set; }

    }

    [Serializable]
    public class OrtezProtezWorkListSearchCriteria
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

        public int patienttype
        {
            get;
            set;
        }

        public List<EpisodeActionWorkListStateItem> ortezProtezWorkListStateItem
        {
            get;
            set;
        }

        public string uniqueRefno
        {
            get;
            set;
        }

        public string patientObjectID
        {
            get;
            set;
        }

        public string kabulNo
        {
            get;
            set;
        }

        public ResUser requesterDoctor { get; set; }

        public OrtezProtezWorkListSearchCriteria()
        {
            //this.workListStartDate = Convert.ToDateTime(TTObjectClasses.SystemParameter.GetParameterValue("ORTEZWORKLISTSTARTDATE", DateTime.Now.AddDays(-15).ToString("dd.MM.yyyy")));
            //this.workListEndDate = DateTime.Now;
        }
    }

}