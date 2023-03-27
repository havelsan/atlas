using Infrastructure.Filters;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TTDataDictionary;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses; 
using TTUtils;
using TTStorageManager.Security;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers.Laundry
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class LaundryApiController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public HasLaundryRolesModel HasLaundryRoles()
        {
            HasLaundryRolesModel result = new HasLaundryRolesModel();
            TTUser currentUser = Common.CurrentResource.GetMyTTUser();
            result.hasLaundryDefinitionFormRole = currentUser.HasRole(TTRoleNames.LaundryDefinitionForm);
            result.hasLaundryMainFormRole = false;
            result.hasCleaningFormRole = currentUser.HasRole(TTRoleNames.CleaningForm);
            result.hasLaundryStatusFormRole = currentUser.HasRole(TTRoleNames.LaundryStatusForm);
            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.LaundryDefinitionForm)]
        public bool SaveNewLinenGroup(LinenGroupModel newGroup)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    LinenGroup lg = new LinenGroup(objectContext);
                    lg.IntegrationCode = newGroup.IntegrationCode;
                    lg.Name = newGroup.Name;
                    objectContext.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.LaundryDefinitionForm)]
        public bool DeleteLinenDefinition(DeleteLinenDefinitionModel deleteModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    ITTObject tempItem = null;
                    if (deleteModel.Type == 1)//Group
                    {
                        LinenGroup lg = objectContext.GetObject<LinenGroup>(deleteModel.ObjectID.Value) as LinenGroup;
                        tempItem = (ITTObject)lg;
                    }
                    else if (deleteModel.Type == 2)//Location
                    {
                        LinenLocation ll = objectContext.GetObject<LinenLocation>(deleteModel.ObjectID.Value) as LinenLocation;
                        tempItem = (ITTObject)ll;
                    }
                    else if (deleteModel.Type == 3)//Type
                    {
                        LinenType lt = objectContext.GetObject<LinenType>(deleteModel.ObjectID.Value) as LinenType;
                        tempItem = (ITTObject)lt;
                    }
                    tempItem.Delete();
                    objectContext.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.LaundryDefinitionForm)]
        public bool UpdateLinenGroup(LinenGroupModel group)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (group.ObjectID.HasValue)
                    {
                        LinenGroup lg = objectContext.GetObject<LinenGroup>(group.ObjectID.Value) as LinenGroup;
                        if (!string.IsNullOrEmpty(group.IntegrationCode))
                            lg.IntegrationCode = group.IntegrationCode;
                        if (!string.IsNullOrEmpty(group.Name))
                            lg.Name = group.Name;
                        objectContext.Save();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.LaundryDefinitionForm)]
        public bool UpdateLinenType(LinenTypeModel typeModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (typeModel.ObjectID.HasValue)
                    {
                        LinenType lt = objectContext.GetObject<LinenType>(typeModel.ObjectID.Value) as LinenType;
                        if (!string.IsNullOrEmpty(typeModel.IntegrationCode))
                            lt.IntegrationCode = typeModel.IntegrationCode;
                        if (!string.IsNullOrEmpty(typeModel.Type))
                            lt.Type = typeModel.Type;
                        if (typeModel.MaxWashingCount != null)
                            lt.MaxWashingCount = typeModel.MaxWashingCount;
                        if (typeModel.LinenGroup.HasValue && typeModel.LinenGroup != Guid.Empty)
                            lt.LinenGroup =   objectContext.GetObject<LinenGroup>(typeModel.LinenGroup.Value) as LinenGroup;
                        objectContext.Save();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.LaundryDefinitionForm)]
        public bool UpdateLinenLocation(LinenLocationModel location)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (location.ObjectID.HasValue)
                    {
                        LinenLocation ll = objectContext.GetObject<LinenLocation>(location.ObjectID.Value) as LinenLocation;
                        if (!string.IsNullOrEmpty(location.IntegrationCode))
                            ll.IntegrationCode = location.IntegrationCode;
                        if (!string.IsNullOrEmpty(location.Location))
                            ll.Location = location.Location;
                        if (!string.IsNullOrEmpty(location.MahalNo))
                            ll.MahalNo = location.MahalNo;

                        objectContext.Save();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.LaundryDefinitionForm)]
        public bool SaveNewLinenLocation(LinenLocationModel newLocation)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    LinenLocation ll = new LinenLocation(objectContext);
                    ll.IntegrationCode = newLocation.IntegrationCode;
                    ll.Location = newLocation.Location;
                    ll.MahalNo = newLocation.MahalNo;
                    objectContext.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.LaundryDefinitionForm)]
        public bool SaveNewLinenType(LinenTypeModel newType)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    LinenType lt = new LinenType(objectContext);
                    lt.IntegrationCode = newType.IntegrationCode;
                    lt.MaxWashingCount = newType.MaxWashingCount;
                    lt.Type = newType.Type;
                    
                    if(newType.LinenGroup != null && newType.LinenGroup != Guid.Empty)
                    {
                        LinenGroup lg = objectContext.GetObject<LinenGroup>(newType.LinenGroup.Value) as LinenGroup;
                        lt.LinenGroup = lg;
                    }
                    
                    objectContext.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.LaundryDefinitionForm,TTRoleNames.LaundryStatusForm)]
        public List<LinenGroupModel> GetAllLinenGroups()
        {
            List<LinenGroupModel> result = new List<LinenGroupModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var dpTermList = objectContext.QueryObjects<LinenGroup>().ToArray();
                    var query =
                        from i in dpTermList
                        select new LinenGroupModel { ObjectID = i.ObjectID, Name = i.Name,IntegrationCode = i.IntegrationCode };
                    result = query.OrderByDescending(x => x.Name).ToList();
                    objectContext.FullPartialllyLoadedObjects();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.LaundryDefinitionForm, TTRoleNames.LaundryStatusForm)]
        public List<LinenLocationModel> GetAllLinenLocations()
        {
            List<LinenLocationModel> result = new List<LinenLocationModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var dpTermList = objectContext.QueryObjects<LinenLocation>().ToArray();
                    var query =
                        from i in dpTermList
                        select new LinenLocationModel { ObjectID = i.ObjectID, Location = i.Location, IntegrationCode = i.IntegrationCode ,MahalNo = i.MahalNo};
                    result = query.OrderByDescending(x => x.Location).ToList();
                    objectContext.FullPartialllyLoadedObjects();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.LaundryDefinitionForm, TTRoleNames.LaundryStatusForm)]
        public List<LinenTypeModel> GetAllLinenTypes()
        {
            List<LinenTypeModel> result = new List<LinenTypeModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var dpTermList = objectContext.QueryObjects<LinenType>().ToArray();
                    var query =
                        from i in dpTermList
                        select new LinenTypeModel { ObjectID = i.ObjectID, LinenGroup = i.LinenGroup != null ? i.LinenGroup.ObjectID:Guid.Empty, IntegrationCode = i.IntegrationCode, MaxWashingCount = i.MaxWashingCount,Type = i.Type};
                    result = query.OrderByDescending(x => x.Type).ToList();
                    objectContext.FullPartialllyLoadedObjects();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.LaundryStatusForm)]
        public List<LaundryStatusResultModel> SearchLaundryStatus(LaundryStatusQueryModel queryModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<LaundryStatusResultModel> result = new List<LaundryStatusResultModel>();
                List<LinenTypeModel> linenTypes = GetAllLinenTypes();
                List<LinenGroupModel> linenGroups = GetAllLinenGroups();
                List<LinenLocationModel> linenLocations = GetAllLinenLocations();

                Random rnd = new Random();

                for (int i = 0; i < 10; i++)
                {
                    LaundryStatusResultModel resultItem = new LaundryStatusResultModel();

                    if (queryModel.Group.HasValue)
                        resultItem.Group = queryModel.Group.Value;
                    else
                    {
                        int groupRndCount = rnd.Next(linenLocations.Count);
                        resultItem.Group = linenGroups[groupRndCount].ObjectID.Value;
                    }

                    if (queryModel.Type.HasValue)
                        resultItem.Type = queryModel.Type.Value;
                    else
                    {
                        int typeRndCount = rnd.Next(linenTypes.Count);
                        resultItem.Type = linenTypes[typeRndCount].ObjectID.Value;
                    }

                    if (queryModel.Location.HasValue)
                        resultItem.Location = queryModel.Location.Value;
                    else
                    {
                        int locationRndCount = rnd.Next(linenLocations.Count);
                        resultItem.Location = linenLocations[locationRndCount].ObjectID.Value;
                    }

                    resultItem.ExpiredCount = rnd.Next(200);

                    //resultItem.ExceededMWC = rnd.Next(100);
                    if (queryModel.ExpiredLinens.HasValue && queryModel.ExpiredLinens.Value)
                        resultItem.UsedCount = resultItem.ExpiredCount;
                    else
                        resultItem.UsedCount = rnd.Next(300);

                    resultItem.TotalCount =  resultItem.ExpiredCount + resultItem.UsedCount;//resultItem.ExceededMWC +
                    result.Add(resultItem);
                }
                return result;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.CleaningForm)]
        public List<BedCleaningFormResultModel> SearchBedWithStatus( int QueryBedStatus)
        {
            List<BedCleaningFormResultModel> result = new List<BedCleaningFormResultModel>();
            using (var objectContext = new TTObjectContext(true))
            {
                try
                {
                    string sqlAdd = "";
                    if (QueryBedStatus == 1)//Temiz
                        sqlAdd = " AND ISCLEAN = 1";
                    else if(QueryBedStatus == 2)
                        sqlAdd = " AND (ISCLEAN IS NULL OR ISCLEAN = 0) ";
                    var bedList = objectContext.QueryObjects<ResBed>(" ISACTIVE = 1 " +sqlAdd).ToArray();
                   
                    foreach (var item in bedList)
                    {
                        BedCleaningFormResultModel tempItem = new BedCleaningFormResultModel();
                        tempItem.ObjectID = item.ObjectID;
                        if (item.IsClean.HasValue)
                            tempItem.IsClean = item.IsClean;
                        else
                            tempItem.IsClean = false;

                        tempItem.Bed = item.Name;
                        if (item.Room != null)
                        {
                            tempItem.Room = item.Room.Name;
                            if(item.Room.RoomGroup != null)
                            {
                                tempItem.RoomGroup = item.Room.RoomGroup.Name;
                                if (item.Room.RoomGroup.Ward != null)
                                    tempItem.ResSection = item.Room.RoomGroup.Ward.Name;
                            }
                        }
                        result.Add(tempItem);
                    }
                    result = result.OrderByDescending(x => x.Bed).ToList();
                    objectContext.FullPartialllyLoadedObjects();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }


        public class SetCleaningStatus_Model
        {
            public List<BedCleaningFormResultModel> Beds { get; set; }
            public int Type { get; set; }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.CleaningForm)]
        public bool SetCleaningStatus(SetCleaningStatus_Model input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                bool IsClean = false;
                if (input.Type == 1)
                    IsClean = true;
                foreach (BedCleaningFormResultModel item in input.Beds)
                {
                    ResBed resBed = objectContext.GetObject<ResBed>(item.ObjectID.Value) as ResBed;
                    resBed.IsClean = IsClean;
                }
                objectContext.Save();
                return true;
            }
        }

    }
}