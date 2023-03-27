//$BF7EA1B7
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
    public partial class ManagerPrescriptionCountsServiceController : Controller
    {
        [HttpGet]
        public ManagerPrescriptionCountFormViewModel ManagerPrescriptionCountForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ManagerPrescriptionCountFormLoadInternal(input);
        }

        [HttpPost]
        public ManagerPrescriptionCountFormViewModel ManagerPrescriptionCountFormLoad(FormLoadInput input)
        {
            return ManagerPrescriptionCountFormLoadInternal(input);
        }
        
        private ManagerPrescriptionCountFormViewModel ManagerPrescriptionCountFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("7364a6d3-9d62-4a8d-a09e-a9f3d4824f78");
            var objectDefID = Guid.Parse("958a6e62-c856-4df8-866f-60dab0669ca1");
            var viewModel = new ManagerPrescriptionCountFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ManagerPrescriptionCounts = objectContext.GetObject(id.Value, objectDefID) as ManagerPrescriptionCounts;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ManagerPrescriptionCounts, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManagerPrescriptionCounts, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ManagerPrescriptionCounts);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ManagerPrescriptionCounts);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_ManagerPrescriptionCountForm(viewModel, viewModel._ManagerPrescriptionCounts, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ManagerPrescriptionCounts = new ManagerPrescriptionCounts(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ManagerPrescriptionCounts, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManagerPrescriptionCounts, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ManagerPrescriptionCounts);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ManagerPrescriptionCounts);
                    PreScript_ManagerPrescriptionCountForm(viewModel, viewModel._ManagerPrescriptionCounts, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ManagerPrescriptionCountForm(ManagerPrescriptionCountFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ManagerPrescriptionCountFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel ManagerPrescriptionCountFormInternal(ManagerPrescriptionCountFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("7364a6d3-9d62-4a8d-a09e-a9f3d4824f78");
            objectContext.AddToRawObjectList(viewModel._ManagerPrescriptionCounts);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.ProcessRawObjects();

            var managerPrescriptionCounts = (ManagerPrescriptionCounts)objectContext.GetLoadedObject(viewModel._ManagerPrescriptionCounts.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(managerPrescriptionCounts, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManagerPrescriptionCounts, formDefID);
            var transDef = managerPrescriptionCounts.TransDef;
            PostScript_ManagerPrescriptionCountForm(viewModel, managerPrescriptionCounts, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(managerPrescriptionCounts);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(managerPrescriptionCounts);
            AfterContextSaveScript_ManagerPrescriptionCountForm(viewModel, managerPrescriptionCounts, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_ManagerPrescriptionCountForm(ManagerPrescriptionCountFormViewModel viewModel, ManagerPrescriptionCounts managerPrescriptionCounts, TTObjectContext objectContext);
        partial void PostScript_ManagerPrescriptionCountForm(ManagerPrescriptionCountFormViewModel viewModel, ManagerPrescriptionCounts managerPrescriptionCounts, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ManagerPrescriptionCountForm(ManagerPrescriptionCountFormViewModel viewModel, ManagerPrescriptionCounts managerPrescriptionCounts, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(ManagerPrescriptionCountFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserDefinitionList", viewModel.ResUsers);
        }
    }
}


namespace Core.Models
{
    public partial class ManagerPrescriptionCountFormViewModel
    {
        public TTObjectClasses.ManagerPrescriptionCounts _ManagerPrescriptionCounts
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }
    }
}
