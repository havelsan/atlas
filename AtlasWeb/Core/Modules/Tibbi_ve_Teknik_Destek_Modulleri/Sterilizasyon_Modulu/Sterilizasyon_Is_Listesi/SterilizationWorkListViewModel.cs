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
    public class SterilizationWorkListServiceController : Controller
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<SterilizationWorkListItemModel> GetSterilizationActionWorkList(SterilizationWorkListSearchCriteria dwlssc)
        {
            string whereCriteria = " ";

            if (dwlssc.workListStartDate != null)
            {
                whereCriteria += " \t AND THIS.RequestDate >= TODATE('" + Convert.ToDateTime(dwlssc.workListStartDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }

            if (dwlssc.workListEndDate != null)
            {
                whereCriteria += " AND THIS.RequestDate <= TODATE('" + Convert.ToDateTime(dwlssc.workListEndDate.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }

            if (dwlssc.requesterDoctor != null)
            {
                //TTUser _user = TTUser.GetAllUsers().Where(u => u.TTObjectID == dwlssc.requesterDoctor.ObjectID).First();

                whereCriteria += " AND THIS.SterilizationRequest.RequestUser= '" + dwlssc.requesterDoctor.ObjectID + "'";/*THIS.ORTHESISPROSTHESISREQUEST.RequesterUsr =*/
            }

            if ( dwlssc.selectedSterilizationWorkListStateItem != Guid.Empty)
            {
                whereCriteria += " AND THIS.CURRENTSTATE= '" + dwlssc.selectedSterilizationWorkListStateItem + "'";
            }

            //if (dwlssc.sterilizationWorkListStateItem != null)
            //{
            //    whereCriteria += " AND THIS.CURRENTSTATE= '" + dwlssc.sterilizationWorkListStateItem + "'";
            //}

            if (!TTUser.CurrentUser.IsSuperUser)
            {
                string _resCriteriea = " AND THIS.ReusableMaterial.OwnerResource IN (''";

                foreach (ResSection item in dwlssc.selectedResourceList)
                {
                    _resCriteriea += ",'" + item.ObjectID + "'";
                }

                _resCriteriea += ")";

                if (dwlssc.selectedResourceList.Count > 0)
                {
                    whereCriteria += _resCriteriea;
                }
            }


            int index = 0;
            System.ComponentModel.BindingList<SterilizationHistory.GetSterilizationHistoryForWorkList_Class> workList = SterilizationHistory.GetSterilizationHistoryForWorkList(whereCriteria);
            List<SterilizationWorkListItemModel> dwlList = new List<SterilizationWorkListItemModel>();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                SterilizationWorkListItemModel dwl = null;
                WorkListDefinition workListDefinition = getWorkListDefinition();

                foreach (var item in workList)
                {
                    dwl = new SterilizationWorkListItemModel();
                    dwl.ObjectID = item.ObjectID.HasValue ? item.ObjectID.ToString() : "0";
                    dwl.MaterialName = item.Materialname != null ? item.Materialname.ToString() : "";
                    dwl.MaterialID = item.Materialid.HasValue ? item.Materialid.ToString() : "0";
                    dwl.RequestDate = item.RequestDate.HasValue ? item.RequestDate.Value : DateTime.MinValue;
                    dwl.CurrentState = item.Currentstate.ToString();
                    dwl.PackageMethod = item.PackageMethod.HasValue ? item.PackageMethod.Value.ToString() : "";
                    dwl.IndicatorSelection = item.IndicatorSelection.HasValue ? item.IndicatorSelection.Value.ToString() : "";
                    dwl.Sterilization = item.Sterilization.HasValue ? item.Sterilization.Value.ToString() : "";
                    dwl.ResSterilizationDevice = item.ResSterilizationDevice.HasValue ? item.ResSterilizationDevice.Value.ToString() : "";
                    dwl.DeviceLoopNo = item.DeviceLoopNo.HasValue ? item.DeviceLoopNo.Value : 1;
                    dwl.SterilizationUser = item.Kabuleden.HasValue ? item.Kabuleden.Value.ToString() : "0";
                    dwl.DeliveredUserAfterUser = item.Teslimalan.HasValue ? item.Teslimalan.Value.ToString() : "0";

                    #region Sonraki State bilgisi
                    if (index == 0)
                    {
                        List<TTDefinitionManagement.TTObjectStateDef> _list = Common.GetAllObjectStateDefs("STERILIZATIONHISTORY");
                        var nextStateList = Common.GetNextStateDefs(_list.Where(z => z.DisplayText == item.Currentstate.ToString()).FirstOrDefault());
                        if(nextStateList!= null && nextStateList.Count >0)
                        dwl.nextStateText = nextStateList.First().DisplayText;
                    }
                    else
                        dwl.nextStateText = dwlList[0].nextStateText;
                    #endregion

                    dwlList.Add(dwl);
                }
            }

            //SterilizationWorkListItemModel dwl2 = new SterilizationWorkListItemModel();
            //dwl2.ObjectID = "1";
            //dwl2.MaterialName = "22sdasd";
            //dwl2.MaterialID = "0";
            //dwl2.RequestDate = DateTime.MinValue;
            //dwl2.CurrentState = "sadasd";
            //dwl2.PackageMethod = "0";
            //dwl2.IndicatorSelection = "1";
            //dwl2.Sterilization = "2";
            //List<TTDefinitionManagement.TTObjectStateDef> _list2 = Common.GetAllObjectStateDefs("STERILIZATIONHISTORY");
            //dwl2.nextStateText = Common.GetNextStateDefs(_list2.Where(z => z.DisplayText == "Sterilizasyon İstendi").First()).First().DisplayText;
            //dwlList.Add(dwl2);

            return dwlList;

        }

        //TODO: Nida
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void SaveSterilizationHistory(List<SterilizationWorkListItemModel> workListItemModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<ResSterilizationDevice> rsd = new List<ResSterilizationDevice>();
                SterilizationHistory _sterilizationHistory = null;

                foreach (SterilizationWorkListItemModel item in workListItemModel)
                {
                   
                    _sterilizationHistory = (SterilizationHistory)objectContext.GetObject(new Guid(item.ObjectID), "SterilizationHistory");

                    //
                    if (!string.IsNullOrEmpty(item.PackageMethod ))
                        _sterilizationHistory.PackageMethod = (SterilizationPackageMethodEnum)(Enum.Parse(typeof(SterilizationPackageMethodEnum), item.PackageMethod));

                    if (!string.IsNullOrEmpty(item.IndicatorSelection))
                        _sterilizationHistory.IndicatorSelection = (IndicatorSelectionEnum)(Enum.Parse(typeof(IndicatorSelectionEnum), item.IndicatorSelection));

                    Guid resSterilizationDeviceGuid;
                    if (Guid.TryParse(item.ResSterilizationDevice, out resSterilizationDeviceGuid))
                        _sterilizationHistory.ResSterilizationDevice = (ResSterilizationDevice)objectContext.GetObject(resSterilizationDeviceGuid, "ResSterilizationDevice");


                    Guid sterilizationUserGuid;
                    if (Guid.TryParse(item.SterilizationUser, out sterilizationUserGuid))
                        _sterilizationHistory.SterilizationUser = (ResUser)objectContext.GetObject(sterilizationUserGuid, "ResUser");


                    Guid deliveredUserAfterUserGuid;
                    if ( Guid.TryParse(item.DeliveredUserAfterUser, out deliveredUserAfterUserGuid))
                        _sterilizationHistory.DeliveredUserAfterUser = (ResUser)objectContext.GetObject(deliveredUserAfterUserGuid, "ResUser");

                    _sterilizationHistory.CurrentStateDefID = Common.GetNextStateDefs(_sterilizationHistory.CurrentStateDef).First().StateDefID;
                   
                    if (_sterilizationHistory.CurrentStateDefID == SterilizationHistory.States.Sterilization)
                    {
                        if (string.IsNullOrEmpty(item.ResSterilizationDevice))
                            throw new Exception("Cihaz seçmeden devam edilemez..");
                        if (rsd.Where(x => x.ObjectID.ToString() == item.ResSterilizationDevice).Count() == 0)
                        {
                            rsd.Add(_sterilizationHistory.ResSterilizationDevice);

                            _sterilizationHistory.DeviceLoopNo += 1;
                        }
                    }
                }

                objectContext.Save();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public SterilizationFilterList GetModelInfo()
        {
            var objectContext = new TTObjectContext(false);

            SterilizationFilterList _search = new SterilizationFilterList();

            //_search.workListStartDate = Common.RecTime();
            //_search.workListEndDate = Common.RecTime();

            _search.resourceList = new List<ResSection>();
            var CurrentResource = Common.CurrentResource;

            foreach (var useResource in CurrentResource.UserResources)
            {
                if (useResource.Resource is ResSection)
                {
                    _search.resourceList.Add(useResource.Resource);
                }

            }
            #region DeviceList
            _search.deviceList = ResSterilizationDevice.GetAllActiveSterilizationDevice(objectContext).ToList<ResSterilizationDevice>();
            #endregion

            #region STATEDEFS

            List<TTDefinitionManagement.TTObjectStateDef> _list = Common.GetAllObjectStateDefs("STERILIZATIONHISTORY");

            StateDef stateDef = null;
            _search.sterilizationWorkListStateItem = new List<StateDef>();

            foreach (TTDefinitionManagement.TTObjectStateDef item in _list)
            {
                stateDef = new StateDef();

                stateDef.StateDefID = item.StateDefID;
                stateDef.DisplayText = item.DisplayText;

                _search.sterilizationWorkListStateItem.Add(stateDef);
            }

            #endregion

            BindingList<ResUser> _tempUserList = ResUser.GetAllUser(objectContext, " WHERE THIS.ISACTIVE = 1");

            _search.sterilizationUserList = _tempUserList.ToList().Where(u => u.UserType == UserTypeEnum.SterilizationWorker).ToList();
            _search.deliveredUserAfterUserList = _tempUserList.ToList();

            //_search.requesterDoctor = _tempUserList.Where(u => u.ObjectID == Common.CurrentUser.TTObjectID).First();

            objectContext.Dispose();
            return _search;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
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
    public partial class SterilizationWorkListViewModel
    {
        public List<SterilizationWorkListItemModel> SterilizationActionList;
        public SterilizationWorkListSearchCriteria _sterilizationWorkListSearchCriteria
        {
            get;
            set;
        }

        public SterilizationWorkListViewModel()
        {
            this._sterilizationWorkListSearchCriteria = new SterilizationWorkListSearchCriteria();
            this.SterilizationActionList = new List<SterilizationWorkListItemModel>();
        }
    }

    public class SterilizationWorkListItemModel
    {
        public string ObjectID { get; set; }
        public string MaterialName { get; set; }
        public string MaterialID { get; set; }
        public DateTime RequestDate { get; set; }
        public string ResSectionName { get; set; }
        public string CurrentState { get; set; }
        public string PackageMethod { get; set; }
        public string IndicatorSelection { get; set; }
        public string Sterilization { get; set; }
        public string ResSterilizationDevice { get; set; }
        public int DeviceLoopNo { get; set; }
        public string SterilizationUser { get; set; }
        public string DeliveredUserAfterUser { get; set; }

        public string nextStateText { get; set; }

    }

    [Serializable]
    public class SterilizationWorkListSearchCriteria
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



        public ResUser requesterDoctor { get; set; }

        public List<ResSection> selectedResourceList { get; set; }

        public List<ResSterilizationDevice> selectedDeviceList { get; set; }

        public Guid selectedSterilizationWorkListStateItem { get; set; }

        public SterilizationWorkListSearchCriteria()
        {
            //this.workListStartDate = Convert.ToDateTime(TTObjectClasses.SystemParameter.GetParameterValue("ORTEZWORKLISTSTARTDATE", DateTime.Now.AddDays(-15).ToString("dd.MM.yyyy")));
            //this.workListEndDate = DateTime.Now;
        }
    }

    public class SterilizationFilterList
    {
        public List<StateDef> sterilizationWorkListStateItem { get; set; }

        public List<ResSection> resourceList { get; set; }

        public List<ResSterilizationDevice> deviceList { get; set; }

        public List<ResUser> sterilizationUserList { get; set; }

        public List<ResUser> deliveredUserAfterUserList { get; set; }
    }

    [Serializable]
    public class StateDef
    {
        public Guid StateDefID { get; set; }
        public string DisplayText { get; set; }
    }

}