//$72C578DC
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
    public partial class ResCabinetServiceController : Controller
    {
            [HttpGet]
            public CabinetDefinitionFormViewModel CabinetDefinitionForm(Guid? id)
            {
                var input = new FormLoadInput();
                input.Id = id;
                return CabinetDefinitionFormLoadInternal(input);
            }

            [HttpPost]
            public CabinetDefinitionFormViewModel CabinetDefinitionFormLoad(FormLoadInput input)
            {
                return CabinetDefinitionFormLoadInternal(input);
            }

            [HttpGet]
            public CabinetDefinitionFormViewModel CabinetDefinitionFormLoadInternal(FormLoadInput input)
            {
                Guid? id = input.Id;
                var formDefID = Guid.Parse("cf7dccc5-fcb7-4faa-af15-b9937a86f36e");
                var objectDefID = Guid.Parse("aec5f655-fe7b-4fda-9e25-af8ead8f86dd");
                var viewModel = new CabinetDefinitionFormViewModel();
                viewModel.ActiveIDsModel = input.Model;

                if (id.HasValue && id.Value != Guid.Empty)
                {
                    using (var objectContext = new TTObjectContext(false))
                    {
                        viewModel._ResCabinet = objectContext.GetObject(id.Value, objectDefID) as ResCabinet;
                        viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ResCabinet, formDefID);
                        viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ResCabinet, formDefID);
                        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ResCabinet);
                        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ResCabinet);
                        objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                        ContextToViewModel(viewModel, objectContext);

                        PreScript_CabinetDefinitionForm(viewModel, viewModel._ResCabinet, objectContext);
                        objectContext.FullPartialllyLoadedObjects();
                    }
                }
                else
                {
                    using (var objectContext = new TTObjectContext(false))
                    {
                        viewModel._ResCabinet = new ResCabinet(objectContext);
                        viewModel.ResShelvesGridList = new TTObjectClasses.ResShelf[] { };
                        viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ResCabinet, formDefID);
                        viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ResCabinet, formDefID);
                        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ResCabinet);
                        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ResCabinet);
                        PreScript_CabinetDefinitionForm(viewModel, viewModel._ResCabinet, objectContext);
                        objectContext.FullPartialllyLoadedObjects();
                    }
                }
                return viewModel;
            }

            [HttpPost]
            public BaseViewModel CabinetDefinitionForm(CabinetDefinitionFormViewModel viewModel)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    return CabinetDefinitionFormInternal(viewModel, objectContext);
                }
            }

            internal BaseViewModel CabinetDefinitionFormInternal(CabinetDefinitionFormViewModel viewModel, TTObjectContext objectContext)
            {
                var retViewModel = new BaseViewModel();
                var formDefID = Guid.Parse("cf7dccc5-fcb7-4faa-af15-b9937a86f36e");
                objectContext.AddToRawObjectList(viewModel.ResArchiveRooms);
                objectContext.AddToRawObjectList(viewModel.ResShelvesGridList);
                objectContext.AddToRawObjectList(viewModel._ResCabinet);
                objectContext.ProcessRawObjects();

                var resCabinet = (ResCabinet)objectContext.GetLoadedObject(viewModel._ResCabinet.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(resCabinet, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ResCabinet, formDefID);

                if (viewModel.ResShelvesGridList != null)
                {
                    foreach (var item in viewModel.ResShelvesGridList)
                    {
                        var resShelvesImported = (ResShelf)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)resShelvesImported).IsDeleted)
                            continue;
                        resShelvesImported.ResCabinet = resCabinet;
                    }
                }
                var transDef = resCabinet.TransDef;
                PostScript_CabinetDefinitionForm(viewModel, resCabinet, transDef, objectContext);
                if (resCabinet.EnabledType == null)
                {
                    resCabinet.EnabledType = ResourceEnableType.UnEnable;
                }
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(resCabinet);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(resCabinet);
                AfterContextSaveScript_CabinetDefinitionForm(viewModel, resCabinet, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();
                return retViewModel;
            }


            partial void PreScript_CabinetDefinitionForm(CabinetDefinitionFormViewModel viewModel, ResCabinet resCabinet, TTObjectContext objectContext);
            partial void PostScript_CabinetDefinitionForm(CabinetDefinitionFormViewModel viewModel, ResCabinet resCabinet, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
            partial void AfterContextSaveScript_CabinetDefinitionForm(CabinetDefinitionFormViewModel viewModel, ResCabinet resCabinet, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

            void ContextToViewModel(CabinetDefinitionFormViewModel viewModel, TTObjectContext objectContext)
            {
                viewModel.ResShelvesGridList = viewModel._ResCabinet.ResShelves.OfType<ResShelf>().ToArray();
                viewModel.ResCabinets = objectContext.LocalQuery<ResCabinet>().ToArray();
                viewModel.ResArchiveRooms = objectContext.LocalQuery<ResArchiveRoom>().ToArray();
                ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ArchiveRoomListDef", viewModel.ResArchiveRooms);
            }
        }
    }



namespace Core.Models
{
    public partial class CabinetDefinitionFormViewModel
    {
        public TTObjectClasses.ResCabinet _ResCabinet
        {
            get;
            set;
        }

        public TTObjectClasses.ResShelf[] ResShelvesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResCabinet[] ResCabinets
        {
            get;
            set;
        }

        public TTObjectClasses.ResArchiveRoom[] ResArchiveRooms
        {
            get;
            set;
        }
    }
}
