//$C89E12DD
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
    public partial class PhototherapyServiceController : Controller
    {
        [HttpGet]
        public PhototherapyFormViewModel PhototherapyForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return PhototherapyFormLoadInternal(input);
        }

        [HttpPost]
        public PhototherapyFormViewModel PhototherapyFormLoad(FormLoadInput input)
        {
            return PhototherapyFormLoadInternal(input);
        }

        private PhototherapyFormViewModel PhototherapyFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("266d2af0-876f-4a98-a076-51fec38da0c3");
            var objectDefID = Guid.Parse("25365087-7b3e-4010-98c8-05b4670a4144");
            var viewModel = new PhototherapyFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Phototherapy = objectContext.GetObject(id.Value, objectDefID) as Phototherapy;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Phototherapy, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Phototherapy, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Phototherapy);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Phototherapy);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_PhototherapyForm(viewModel, viewModel._Phototherapy, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Phototherapy = new Phototherapy(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Phototherapy, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Phototherapy, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Phototherapy);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Phototherapy);
                    PreScript_PhototherapyForm(viewModel, viewModel._Phototherapy, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel PhototherapyForm(PhototherapyFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return PhototherapyFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel PhototherapyFormInternal(PhototherapyFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("266d2af0-876f-4a98-a076-51fec38da0c3");
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel._Phototherapy);
            objectContext.ProcessRawObjects();

            var phototherapy = (Phototherapy)objectContext.GetLoadedObject(viewModel._Phototherapy.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(phototherapy, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Phototherapy, formDefID);
            var transDef = phototherapy.TransDef;
            PostScript_PhototherapyForm(viewModel, phototherapy, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(phototherapy);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(phototherapy);
            AfterContextSaveScript_PhototherapyForm(viewModel, phototherapy, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_PhototherapyForm(PhototherapyFormViewModel viewModel, Phototherapy phototherapy, TTObjectContext objectContext);
        partial void PostScript_PhototherapyForm(PhototherapyFormViewModel viewModel, Phototherapy phototherapy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_PhototherapyForm(PhototherapyFormViewModel viewModel, Phototherapy phototherapy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(PhototherapyFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorAndNurseList", viewModel.ResUsers);
        }
    }
}


namespace Core.Models
{
    public partial class PhototherapyFormViewModel
    {
        public TTObjectClasses.Phototherapy _Phototherapy
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
