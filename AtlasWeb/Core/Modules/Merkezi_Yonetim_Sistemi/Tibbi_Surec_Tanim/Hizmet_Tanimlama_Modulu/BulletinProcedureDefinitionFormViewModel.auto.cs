//$6D2A870E
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
    public partial class BulletinProcedureDefinitionServiceController : Controller
    {

        [HttpGet]
        public BulletinProcedureDefinitionFormViewModel BulletinProcedureDefinitionForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return BulletinProcedureDefinitionFormInternal(input);
        }

        [HttpPost]
        public BulletinProcedureDefinitionFormViewModel BulletinProcedureDefinitionFormLoad(FormLoadInput input)
        {
            return BulletinProcedureDefinitionFormInternal(input);
        }

        private BulletinProcedureDefinitionFormViewModel BulletinProcedureDefinitionFormInternal(FormLoadInput input)
        {
            Guid? id = input.Id;

            var formDefID = Guid.Parse("779fd195-a10d-4ec8-a3e5-23a4bb688eeb");
            var objectDefID = Guid.Parse("7e56397e-11d1-4732-9c66-cb507024ca93");
            var viewModel = new BulletinProcedureDefinitionFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._BulletinProcedureDefinition = objectContext.GetObject(id.Value, objectDefID) as BulletinProcedureDefinition;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BulletinProcedureDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BulletinProcedureDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BulletinProcedureDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BulletinProcedureDefinition);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_BulletinProcedureDefinitionForm(viewModel, viewModel._BulletinProcedureDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._BulletinProcedureDefinition = new BulletinProcedureDefinition(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BulletinProcedureDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BulletinProcedureDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BulletinProcedureDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BulletinProcedureDefinition);
                    PreScript_BulletinProcedureDefinitionForm(viewModel, viewModel._BulletinProcedureDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel BulletinProcedureDefinitionForm(BulletinProcedureDefinitionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return BulletinProcedureDefinitionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel BulletinProcedureDefinitionFormInternal(BulletinProcedureDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("779fd195-a10d-4ec8-a3e5-23a4bb688eeb");
            objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
            objectContext.AddToRawObjectList(viewModel._BulletinProcedureDefinition);
            objectContext.ProcessRawObjects();

            var bulletinProcedureDefinition = (BulletinProcedureDefinition)objectContext.GetLoadedObject(viewModel._BulletinProcedureDefinition.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(bulletinProcedureDefinition, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BulletinProcedureDefinition, formDefID);
            var transDef = bulletinProcedureDefinition.TransDef;
            PostScript_BulletinProcedureDefinitionForm(viewModel, bulletinProcedureDefinition, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(bulletinProcedureDefinition);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(bulletinProcedureDefinition);
            AfterContextSaveScript_BulletinProcedureDefinitionForm(viewModel, bulletinProcedureDefinition, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_BulletinProcedureDefinitionForm(BulletinProcedureDefinitionFormViewModel viewModel, BulletinProcedureDefinition bulletinProcedureDefinition, TTObjectContext objectContext);
        partial void PostScript_BulletinProcedureDefinitionForm(BulletinProcedureDefinitionFormViewModel viewModel, BulletinProcedureDefinition bulletinProcedureDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_BulletinProcedureDefinitionForm(BulletinProcedureDefinitionFormViewModel viewModel, BulletinProcedureDefinition bulletinProcedureDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(BulletinProcedureDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
        }
    }
}


namespace Core.Models
{
    public partial class BulletinProcedureDefinitionFormViewModel
    {
        public TTObjectClasses.BulletinProcedureDefinition _BulletinProcedureDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }
    }
}
