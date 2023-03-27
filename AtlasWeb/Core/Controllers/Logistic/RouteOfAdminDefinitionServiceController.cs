using Core.Models;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class RouteOfAdminDefinitionServiceController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<RoutOfAdminList> listRouteOfAdmin()
        {
            List<RoutOfAdminList> roaList = new List<RoutOfAdminList>();

            roaList = RouteOfAdmin.GetRouteOfAdminDefinitionQuery(string.Empty).Select(p => new RoutOfAdminList()
            {
                Code = p.Code.Value,
                IsActive = p.IsActive,
                Name = p.Name,
                ObjectID = p.ObjectID.Value
                
            }).ToList();

            return roaList;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<UpdateRoAListOfSKRS> getUpdateSKRSList()
        {
            TTObjectContext context = new TTObjectContext(false);
            List<UpdateRoAListOfSKRS> updateListOfSKRS = new List<UpdateRoAListOfSKRS>();

            var skrsList = SKRSIlacKullanimSekli.GetSKRSIlacKullanimSekli(string.Empty).ToList();
            var routeOfAdmin = RouteOfAdmin.GetRouteOfAdminDefinitionQuery(string.Empty).ToList();

            var notExistSKRS = from skrs in skrsList
                               join x in routeOfAdmin
                               on skrs.KODU equals x.Code.ToString() into t
                               from od in t.DefaultIfEmpty()
                               where od == null
                               select skrs;

            updateListOfSKRS = notExistSKRS.Select(p => new UpdateRoAListOfSKRS()
            {
                Code = Int32.Parse(p.KODU),
                IsActive = p.IsActive,
                Name = p.ADI,
                SKRSIlacObjectID = p.ObjectID.Value
            }).ToList();

            return updateListOfSKRS;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string UpdateSKRSList(UpdateROAInputDTO input)
        {
            string ReturnMessage = string.Empty;
            if (input.updateListOfSKRS.Count == 0)
                throw new TTException("Güncellenecek Liste Bulunamadı.");

            try
            {
                foreach (UpdateRoAListOfSKRS item in input.updateListOfSKRS)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    RouteOfAdmin newRouteOfAdmin = new RouteOfAdmin(context);
                    newRouteOfAdmin.Code = item.Code;
                    newRouteOfAdmin.Name = item.Name;
                    newRouteOfAdmin.IsActive = item.IsActive;
                    context.Save();
                    context.Dispose();
                }
                ReturnMessage = " SKRS Güncellemesi Tamamlandı.";
            }

            catch (Exception ex)
            {
                ReturnMessage += ex.Message + " , ";
            }
            return ReturnMessage;
        }
    }

    public class UpdateROAInputDTO
    {
        public List<UpdateRoAListOfSKRS> updateListOfSKRS { get; set; }
    }

    public class UpdateRoAListOfSKRS
    {
        public Guid SKRSIlacObjectID { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public bool? IsActive { get; set; }
    }

    public class RoutOfAdminList
    {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public bool? IsActive { get; set; }
    }
}
