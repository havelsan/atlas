
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class ResArchiveRoomServiceController : Controller
    {
        [HttpGet]
        public ArchiveRoomsDefFormViewModel ArchiveRoomsDefForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ArchiveRoomsDefFormLoadInternal(input);
        }

        [HttpPost]
        public ArchiveRoomsDefFormViewModel ArchiveRoomsDefFormLoad(FormLoadInput input)
        {
            return ArchiveRoomsDefFormLoadInternal(input);
        }

        [HttpGet]
        public ArchiveRoomsDefFormViewModel ArchiveRoomsDefFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("dbdb9f33-8641-4ef3-bb0a-9300d218d635");
            var objectDefID = Guid.Parse("bfa83824-3ffd-4bd7-8e64-cde4f4ae8140");
            var viewModel = new ArchiveRoomsDefFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ResArchiveRoom = objectContext.GetObject(id.Value, objectDefID) as ResArchiveRoom;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ResArchiveRoom, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ResArchiveRoom, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ResArchiveRoom);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ResArchiveRoom);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_ArchiveRoomsDefForm(viewModel, viewModel._ResArchiveRoom, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ResArchiveRoom = new ResArchiveRoom(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ResArchiveRoom, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ResArchiveRoom, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ResArchiveRoom);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ResArchiveRoom);
                    PreScript_ArchiveRoomsDefForm(viewModel, viewModel._ResArchiveRoom, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ArchiveRoomsDefForm(ArchiveRoomsDefFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ArchiveRoomsDefFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel ArchiveRoomsDefFormInternal(ArchiveRoomsDefFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("dbdb9f33-8641-4ef3-bb0a-9300d218d635");
            objectContext.AddToRawObjectList(viewModel.ResFloors);
            objectContext.AddToRawObjectList(viewModel.ResBuildingWings);
            objectContext.AddToRawObjectList(viewModel.ResBuildings);
            objectContext.AddToRawObjectList(viewModel._ResArchiveRoom);
            objectContext.AddToRawObjectList(viewModel.CabinetList);
            objectContext.AddToRawObjectList(viewModel.ShelfList);
            objectContext.ProcessRawObjects();

            var resArchiveRoom = (ResArchiveRoom)objectContext.GetLoadedObject(viewModel._ResArchiveRoom.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(resArchiveRoom, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ResArchiveRoom, formDefID);
            var transDef = resArchiveRoom.TransDef;
            if (viewModel.CabinetList != null)
            {
                foreach (var item in viewModel.CabinetList)
                {
                    var ArchiveRoomCabinetImported = (ResCabinet)objectContext.GetLoadedObject(item.ObjectID);
                    if(ArchiveRoomCabinetImported.EnabledType == null)
                    {
                        ArchiveRoomCabinetImported.EnabledType = ResourceEnableType.UnEnable;
                    }
                    if (((ITTObject)ArchiveRoomCabinetImported).IsDeleted)
                        continue;
                    ArchiveRoomCabinetImported.ResArchiveRoom = resArchiveRoom;
                }
            }

            if(viewModel.CabinetShelf != null)
            {

            }

            //if (viewModel.ShelfList != null)
            //{
            //    foreach (var item in viewModel.ShelfList)
            //    {
            //        var ShelfImported = (ResShelf)objectContext.GetLoadedObject(item.ObjectID);
            //        if (((ITTObject)ShelfImported).IsDeleted)
            //            continue;
            //        ShelfImported.ResCabinet = viewModel.CabinetList.Where(data => data.ObjectID == ShelfImported.ResCabinet.ObjectID).FirstOrDefault();
            //    }
            //}
            PostScript_ArchiveRoomsDefForm(viewModel, resArchiveRoom, transDef, objectContext);
            if (resArchiveRoom.EnabledType == null)
            {
                resArchiveRoom.EnabledType = ResourceEnableType.UnEnable;
            }
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(resArchiveRoom);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(resArchiveRoom);
            AfterContextSaveScript_ArchiveRoomsDefForm(viewModel, resArchiveRoom, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_ArchiveRoomsDefForm(ArchiveRoomsDefFormViewModel viewModel, ResArchiveRoom resArchiveRoom, TTObjectContext objectContext);
        partial void PostScript_ArchiveRoomsDefForm(ArchiveRoomsDefFormViewModel viewModel, ResArchiveRoom resArchiveRoom, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ArchiveRoomsDefForm(ArchiveRoomsDefFormViewModel viewModel, ResArchiveRoom resArchiveRoom, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(ArchiveRoomsDefFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ResFloors = objectContext.LocalQuery<ResFloor>().ToArray();
            viewModel.ResBuildingWings = objectContext.LocalQuery<ResBuildingWing>().ToArray();
            viewModel.ResBuildings = objectContext.LocalQuery<ResBuilding>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "FloorListDefinition", viewModel.ResFloors);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "WingListDefinition", viewModel.ResBuildingWings);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BuildinglistDefinition", viewModel.ResBuildings);
        }
    }
}


namespace Core.Models
{
    public partial class ArchiveRoomsDefFormViewModel
    {
        public TTObjectClasses.ResArchiveRoom _ResArchiveRoom
        {
            get;
            set;
        }

        public TTObjectClasses.ResFloor[] ResFloors
        {
            get;
            set;
        }

        public TTObjectClasses.ResBuildingWing[] ResBuildingWings
        {
            get;
            set;
        }

        public TTObjectClasses.ResBuilding[] ResBuildings
        {
            get;
            set;
        }
    }
}
