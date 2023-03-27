using Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.Collections;
using TTDefinitionManagement;
using TTInstanceManagement;
using Infrastructure.Filters;
using Infrastructure.Models;
using Core.Services;
using System;
using TTObjectClasses;
using TTUtils;
using TTStorageManager.Security;
using System.ComponentModel;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using TTDataDictionary;
using System.Drawing;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;


namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class LogisticReportController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LogisticReportViewModel GetLogisticReport()
        {
            LogisticReportViewModel model = new LogisticReportViewModel();
            List<Report> ReportList = new List<Report>();
            TTObjectContext context = new TTObjectContext(false);

            IBindingList menuDef = context.QueryObjects("MENUDEFINITION", "PARENTMENU = '497d1091-33ea-4bc3-9e1d-0ece82d12b18' AND ORDERNO IN ('1','4') ");
            if (menuDef.Count > 0)
            {
                List<Report> ReportItem = new List<Report>(); //Bu gerekli midir? 
                foreach (MenuDefinition defMain in menuDef)
                {
                    Report reportMain = new Report();
                    reportMain.id = defMain.ObjectID;
                    reportMain.caption = defMain.Caption;
                    reportMain.name = defMain.ObjectDefinitionName;
                    reportMain.items = innerReportMedhot(defMain.ObjectID);
                    ReportList.Add(reportMain); 
                 }
            }

            foreach (Report controlReportItem in ReportList)
            {
                if (!(controlReportItem.items.Count > 0))
                {
                    ReportList.Remove(controlReportItem);
                }
            }

            model.Reports = ReportList;
            return model;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public SubStoreModel GetMySubStoreModel()
        {
            SubStoreModel model = new SubStoreModel();
            List<SubStoreItem> subStoreList = new List<SubStoreItem>();
            TTObjectContext context = new TTObjectContext(false);

            IBindingList returnedStoreList = context.QueryObjects("STORE", "OBJECTDEFID IN('009d82e7-40a9-444f-b8c6-a3ca69eca81c', '626c8928-9f64-4557-be52-2b68d15ea19d') AND ISACTIVE = 1");
            if (returnedStoreList.Count > 0)
            {
                foreach (Store item in returnedStoreList)
                {
                    SubStoreItem subStoreItem = new SubStoreItem();
                    subStoreItem.id = item.ObjectID.ToString();
                    subStoreItem.name = item.Name;
                    subStoreList.Add(subStoreItem);
                }
            }

            model.Stores = subStoreList;
            return model;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string GetMyStoreObjectID()
        {
            string filterExp = string.Empty;
            if (Common.CurrentUser.IsSuperUser == false)
            {
                TTObjectContext context = new TTObjectContext(false);
                List<Store> selectableStores = new List<Store>();
                foreach (UserResource usableStore in Common.CurrentResource.UserResources)
                {
                    if (selectableStores.Contains(usableStore.Resource.Store) == false)
                        selectableStores.Add(usableStore.Resource.Store);
                }

                if (selectableStores.Count > 0)
                {
                    filterExp = "OBJECTID IN(";

                    foreach (Store s in selectableStores)
                        filterExp = filterExp + TTConnectionManager.ConnectionManager.GuidToString(s.ObjectID) + ",";

                    filterExp = filterExp.TrimEnd(',');
                    filterExp = filterExp + ")";
                }
            }
            return filterExp;
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<Report> innerReportMedhot(Guid parentMenuObjID)
        {
            TTObjectContext context = new TTObjectContext(false);
            List<Report> innerReport = new List<Report>();
            IBindingList menuDefInner = context.QueryObjects("MENUDEFINITION", "PARENTMENU =" + TTConnectionManager.ConnectionManager.GuidToString(parentMenuObjID) + "AND ISDISABLED = 0 ORDER BY CAPTION ");
            if (menuDefInner.Count > 0)
            {
                foreach (MenuDefinition innerDef in menuDefInner)
                {
                    if (HasRightReportMenuDefinition(innerDef))
                    {
                        Report reportInner = new Report();
                        reportInner.id = innerDef.ObjectID;
                        reportInner.caption = innerDef.Caption;
                        reportInner.name = innerDef.ObjectDefinitionName;
                        reportInner.items = innerReportMedhot(innerDef.ObjectID);
                        innerReport.Add(reportInner);
                    }
                }
            }
            return innerReport;
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public static bool HasRightReportMenuDefinition(MenuDefinition menuDefinition)
        {
            if (Common.CurrentUser.IsSuperUser == true)
                return true;

            if (menuDefinition.MenuGroup.HasValue && menuDefinition.MenuGroup == MenuTypeEnum.ReportMenu)
            {
                string mdName = menuDefinition.ObjectDefinitionName;
                if (string.IsNullOrEmpty(mdName))
                    return false;
                if (TTObjectDefManager.Instance.ReportDefs.ContainsKey(mdName))
                {
                    TTReportDef reportDef = TTObjectDefManager.Instance.ReportDefs[mdName];
                    if (TTUser.CurrentUser.HasRight(reportDef, null, (int)TTSecurityAuthority.RightsEnum.PreviewReport) == true)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
