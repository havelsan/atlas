//$AE758851
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class ResArchiveRoomServiceController
    {
        partial void PreScript_ArchiveRoomsDefForm(ArchiveRoomsDefFormViewModel viewModel, ResArchiveRoom resArchiveRoom, TTObjectContext objectContext)
        {

            viewModel.RoomList = new List<RoomModel>();
            List<ResArchiveRoom> roomList = ResArchiveRoom.GetArchiveRoomListDef(objectContext, "").ToList();
            foreach (ResArchiveRoom item in roomList)
            {
                RoomModel model = new RoomModel();
                model.ObjectID = item.ObjectID;
                model.RoomName = item.Name;
                model.BuildingName = item.ResBuilding.Name;
                if (item.ResBuildingWing != null)
                    model.WingName = item.ResBuildingWing.Name;
                if (item.ResFloor != null)
                    model.FloorName = item.ResFloor.Name;
                model.Active = item.IsActive;
                model.Room = item;
                viewModel.RoomList.Add(model);
            }

            viewModel.CabinetList = resArchiveRoom.ResCabinets.ToList();
            viewModel.ShelfList = new List<ResShelf>();

            foreach (var item in viewModel.CabinetList)
            {
                viewModel.ShelfList = viewModel.ShelfList.Concat(item.ResShelves).ToList();
            }
        }

    }
}

namespace Core.Models
{
    public class RoomModel
    {
        public Guid ObjectID { get; set; }
        public string RoomName { get; set; }
        public string BuildingName { get; set; }
        public string WingName { get; set; }
        public string FloorName { get; set; }
        public bool? Active { get; set; }
        public ResArchiveRoom Room { get; set; }
    }
    public partial class ArchiveRoomsDefFormViewModel : BaseViewModel
    {
        public List <RoomModel> RoomList { get; set; }
        public List<ResCabinet> CabinetList { get; set; }
        public List<ResShelf> ShelfList { get; set; }
        public List<CabinetShelf> CabinetShelf { get; set; }


    }
    public class CabinetShelf
    {
        public Guid CabinetObjectID { get; set; }
        public Guid ShelfObjectID { get; set; }
    }
}
