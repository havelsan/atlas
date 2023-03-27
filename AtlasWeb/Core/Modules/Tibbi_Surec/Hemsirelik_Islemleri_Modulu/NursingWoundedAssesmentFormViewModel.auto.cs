//$2F62B8B0
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
    public partial class NursingWoundedAssesmentServiceController : Controller
    {

        [HttpGet]
        public NursingWoundedAssesmentFormViewModel NursingWoundedAssesmentForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return NursingWoundedAssesmentFormLoadInternal(input);
        }

        [HttpPost]
        public NursingWoundedAssesmentFormViewModel NursingWoundedAssesmentFormLoad(FormLoadInput input)
        {
            return NursingWoundedAssesmentFormLoadInternal(input);
        }

        [HttpGet]
        public NursingWoundedAssesmentFormViewModel NursingWoundedAssesmentFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("dc22c2a2-c9a9-442a-b3dc-0f720a418b19");
            var objectDefID = Guid.Parse("97151ed7-9436-4ecc-9886-66918a76faf4");
            var viewModel = new NursingWoundedAssesmentFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._NursingWoundedAssesment = objectContext.GetObject(id.Value, objectDefID) as NursingWoundedAssesment;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingWoundedAssesment, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingWoundedAssesment, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingWoundedAssesment);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingWoundedAssesment);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_NursingWoundedAssesmentForm(viewModel, viewModel._NursingWoundedAssesment, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._NursingWoundedAssesment = new NursingWoundedAssesment(objectContext);
                    var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                    viewModel._NursingWoundedAssesment.CurrentStateDefID = entryStateID;
                    viewModel.WoundPhotosGridList = new TTObjectClasses.WoundPhoto[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingWoundedAssesment, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingWoundedAssesment, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingWoundedAssesment);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingWoundedAssesment);
                    PreScript_NursingWoundedAssesmentForm(viewModel, viewModel._NursingWoundedAssesment, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel NursingWoundedAssesmentForm(NursingWoundedAssesmentFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return NursingWoundedAssesmentFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel NursingWoundedAssesmentFormInternal(NursingWoundedAssesmentFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("dc22c2a2-c9a9-442a-b3dc-0f720a418b19");
            objectContext.AddToRawObjectList(viewModel.WoundSideInfos);
            objectContext.AddToRawObjectList(viewModel.WoundLocalizationDefs);
            objectContext.AddToRawObjectList(viewModel.WoundStageDefs);
            objectContext.AddToRawObjectList(viewModel.WoundPhotosGridList);
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._NursingWoundedAssesment, entryStateID);
            objectContext.ProcessRawObjects(false);

            var nursingWoundedAssesment = (NursingWoundedAssesment)objectContext.GetLoadedObject(viewModel._NursingWoundedAssesment.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingWoundedAssesment, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingWoundedAssesment, formDefID);

            if (viewModel.WoundPhotosGridList != null)
            {
                foreach (var item in viewModel.WoundPhotosGridList)
                {
                    var woundPhotosImported = (WoundPhoto)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)woundPhotosImported).IsDeleted)
                        continue;
                    woundPhotosImported.NursingWound = nursingWoundedAssesment;
                }
            }
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingWoundedAssesment);
            PostScript_NursingWoundedAssesmentForm(viewModel, nursingWoundedAssesment, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingWoundedAssesment);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingWoundedAssesment);
            AfterContextSaveScript_NursingWoundedAssesmentForm(viewModel, nursingWoundedAssesment, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_NursingWoundedAssesmentForm(NursingWoundedAssesmentFormViewModel viewModel, NursingWoundedAssesment nursingWoundedAssesment, TTObjectContext objectContext);
        partial void PostScript_NursingWoundedAssesmentForm(NursingWoundedAssesmentFormViewModel viewModel, NursingWoundedAssesment nursingWoundedAssesment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_NursingWoundedAssesmentForm(NursingWoundedAssesmentFormViewModel viewModel, NursingWoundedAssesment nursingWoundedAssesment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(NursingWoundedAssesmentFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.WoundPhotosGridList = viewModel._NursingWoundedAssesment.WoundPhotos.OfType<WoundPhoto>().ToArray();
            viewModel.WoundSideInfos = objectContext.LocalQuery<WoundSideInfo>().ToArray();
            viewModel.WoundLocalizationDefs = objectContext.LocalQuery<WoundLocalizationDef>().ToArray();
            viewModel.WoundStageDefs = objectContext.LocalQuery<WoundStageDef>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "WoundSideInfoList", viewModel.WoundSideInfos);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "WoundStageDefList", viewModel.WoundStageDefs);
        }
    }
}


namespace Core.Models
{
    public partial class NursingWoundedAssesmentFormViewModel
    {
        public TTObjectClasses.NursingWoundedAssesment _NursingWoundedAssesment
        {
            get;
            set;
        }

        public TTObjectClasses.WoundPhoto[] WoundPhotosGridList
        {
            get;
            set;
        }

        public TTObjectClasses.WoundSideInfo[] WoundSideInfos
        {
            get;
            set;
        }

        public TTObjectClasses.WoundLocalizationDef[] WoundLocalizationDefs
        {
            get;
            set;
        }

        public TTObjectClasses.WoundStageDef[] WoundStageDefs
        {
            get;
            set;
        }
    }
}
