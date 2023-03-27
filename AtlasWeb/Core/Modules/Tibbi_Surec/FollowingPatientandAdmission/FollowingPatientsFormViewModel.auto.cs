//$AA2F8571
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
    public partial class FollowingPatientsServiceController : Controller
    {
        [HttpGet]
        public FollowingPatientsFormViewModel FollowingPatientsForm(Guid? id)
        {
            var formDefID = Guid.Parse("6bd3e3f6-8048-4176-b884-c26ef9cfe026");
            var objectDefID = Guid.Parse("d2ab5127-576a-40e6-b5b1-f22c55ed89e6");
            var viewModel = new FollowingPatientsFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._FollowingPatients = objectContext.GetObject(id.Value, objectDefID) as FollowingPatients;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._FollowingPatients, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._FollowingPatients, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._FollowingPatients);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._FollowingPatients);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_FollowingPatientsForm(viewModel, viewModel._FollowingPatients, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._FollowingPatients = new FollowingPatients(objectContext);
                    var entryStateID = Guid.Parse("b9cc4ac5-aa61-46f1-962c-afbece4f3e29");
                    viewModel._FollowingPatients.CurrentStateDefID = entryStateID;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._FollowingPatients, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._FollowingPatients, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._FollowingPatients);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._FollowingPatients);
                    PreScript_FollowingPatientsForm(viewModel, viewModel._FollowingPatients, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel FollowingPatientsForm(FollowingPatientsFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return FollowingPatientsFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel FollowingPatientsFormInternal(FollowingPatientsFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("6bd3e3f6-8048-4176-b884-c26ef9cfe026");
            var entryStateID = Guid.Parse("b9cc4ac5-aa61-46f1-962c-afbece4f3e29");
            objectContext.AddToRawObjectList(viewModel._FollowingPatients, entryStateID);
            objectContext.ProcessRawObjects(false);

            var followingPatients = (FollowingPatients)objectContext.GetLoadedObject(viewModel._FollowingPatients.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(followingPatients, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._FollowingPatients, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(followingPatients);
            PostScript_FollowingPatientsForm(viewModel, followingPatients, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(followingPatients);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(followingPatients);
            AfterContextSaveScript_FollowingPatientsForm(viewModel, followingPatients, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_FollowingPatientsForm(FollowingPatientsFormViewModel viewModel, FollowingPatients followingPatients, TTObjectContext objectContext);
        partial void PostScript_FollowingPatientsForm(FollowingPatientsFormViewModel viewModel, FollowingPatients followingPatients, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_FollowingPatientsForm(FollowingPatientsFormViewModel viewModel, FollowingPatients followingPatients, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(FollowingPatientsFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class FollowingPatientsFormViewModel
    {
        public TTObjectClasses.FollowingPatients _FollowingPatients
        {
            get;
            set;
        }
    }
}
