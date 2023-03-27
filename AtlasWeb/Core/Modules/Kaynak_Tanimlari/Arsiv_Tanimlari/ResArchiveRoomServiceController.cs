//$9A533AA5
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class ResArchiveRoomServiceController : Controller
    {
        [HttpPost]
        public List<RoomModel> FillRoomList()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<RoomModel> result = new List<RoomModel>();
                List<ResArchiveRoom> roomList = ResArchiveRoom.GetArchiveRoomListDef(objectContext, "").ToList();
                foreach (ResArchiveRoom item in roomList)
                {
                    RoomModel model = new RoomModel();
                    model.ObjectID = item.ObjectID;
                    model.RoomName = item.Name;
                    model.BuildingName = item.ResBuilding.Name;
                    if(item.ResBuildingWing != null)
                        model.WingName = item.ResBuildingWing.Name;
                    if (item.ResFloor != null)
                        model.FloorName = item.ResFloor.Name;
                    model.Active = item.IsActive;
                    model.Room = item;
                    result.Add(model);
                }
                return result;
            }
        }
    }
}