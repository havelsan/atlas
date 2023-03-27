//$D1014BFE
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class UserSearchCriteriaServiceController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Icmal_Islemleri, TTRoleNames.Fatura_Tahsilat_Islemleri, TTRoleNames.Fatura_Islemleri, TTRoleNames.Tig_Islemleri)]
        public List<UserSearchCriteriaModel> GetUserSearchCriteria([FromQuery] string pageName)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<UserSearchCriteria.GetUserSearchCriteria_Class> uscReportQueryList = UserSearchCriteria.GetUserSearchCriteria(objectContext, "WHERE RESUSER = '" + Common.CurrentResource.ObjectID + "' AND PAGENAME = '" + pageName.Replace("'", "''") + "' AND CURRENTSTATE <> STATES.CANCELLED ORDER BY NAME").ToList();
                List<UserSearchCriteriaModel> uscList = uscReportQueryList.Select(x => new UserSearchCriteriaModel{ObjectID = x.ObjectID, IsDefault = x.IsDefault, Name = x.Name, PageName = x.PageName}).ToList();
                return uscList;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Icmal_Islemleri, TTRoleNames.Fatura_Tahsilat_Islemleri, TTRoleNames.Fatura_Islemleri, TTRoleNames.Tig_Islemleri)]
        public string GetSearchCriteriaValue([FromQuery] Guid objectID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                return objectContext.GetObject<UserSearchCriteria>(objectID).Value;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Icmal_Islemleri, TTRoleNames.Fatura_Tahsilat_Islemleri, TTRoleNames.Fatura_Islemleri, TTRoleNames.Tig_Islemleri)]
        public OperationStatus SaveUserSearchCriteria(UserSearchCriteriaModel userSearchCriteria)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (!userSearchCriteria.ObjectID.HasValue)
                    {
                        UserSearchCriteria newUserSearchCrieria = new UserSearchCriteria(objectContext);
                        newUserSearchCrieria.ResUser = Common.CurrentResource;
                        newUserSearchCrieria.Name = userSearchCriteria.Name;
                        newUserSearchCrieria.PageName = userSearchCriteria.PageName;
                        newUserSearchCrieria.Value = userSearchCriteria.Value;
                        newUserSearchCrieria.IsDefault = userSearchCriteria.IsDefault.HasValue ? userSearchCriteria.IsDefault : false;
                        newUserSearchCrieria.CurrentStateDefID = UserSearchCriteria.States.InUse;
                    }
                    else
                    {
                        UserSearchCriteria usc = objectContext.GetObject<UserSearchCriteria>(userSearchCriteria.ObjectID.Value);
                        usc.Value = userSearchCriteria.Value.ToString();
                        usc.IsDefault = userSearchCriteria.IsDefault.HasValue ? userSearchCriteria.IsDefault : false;
                    }

                    objectContext.Save();
                    return new OperationStatus{Status = true, CustomMessage = TTUtils.CultureService.GetText("M26283", "Kayıt işlemi başarılı olarak tamamlandı.")};
                }
                catch (TTException ex)
                {
                    return new OperationStatus{Status = false, ErrorMessage = ex.Message};
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Icmal_Islemleri, TTRoleNames.Fatura_Tahsilat_Islemleri, TTRoleNames.Fatura_Islemleri, TTRoleNames.Tig_Islemleri)]
        public OperationStatus DeleteUserSearchCriteria(UserSearchCriteriaModel userSearchCriteria)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                if (userSearchCriteria.ObjectID.HasValue)
                {
                    try
                    {
                        UserSearchCriteria usc = objectContext.GetObject<UserSearchCriteria>(userSearchCriteria.ObjectID.Value);
                        usc.CurrentStateDefID = UserSearchCriteria.States.Cancelled;
                        objectContext.Save();
                        return new OperationStatus{Status = true, CustomMessage = TTUtils.CultureService.GetText("M26889", "Silme işlemi başarılı olarak tamamlandı.")};
                    }
                    catch (TTException ex)
                    {
                        return new OperationStatus{Status = false, ErrorMessage = ex.Message};
                    }
                }
                else
                    throw new TTException(TTUtils.CultureService.GetText("M26885", "Silinecek veri seçilmedi."));
            }
        }
    }
}

namespace Core.Models
{
    public class UserSearchCriteriaModel
    {
        public Guid? ObjectID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string PageName
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public bool ? IsDefault
        {
            get;
            set;
        }
    }
}