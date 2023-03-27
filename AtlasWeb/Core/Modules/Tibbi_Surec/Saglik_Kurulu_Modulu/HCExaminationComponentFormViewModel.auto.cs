//$C0CDCEF5
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
    public partial class HCExaminationComponentServiceController : Controller
    {
        [HttpGet]
        public HCExaminationComponentFormViewModel HCExaminationComponentForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return HCExaminationComponentFormLoadInternal(input);
        }

        [HttpPost]
        public HCExaminationComponentFormViewModel HCExaminationComponentFormLoad(FormLoadInput input)
        {
            return HCExaminationComponentFormLoadInternal(input);
        }

        private HCExaminationComponentFormViewModel HCExaminationComponentFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("e62371f8-1f15-46ce-bf32-40840d8c59fe");
            var objectDefID = Guid.Parse("003a4a92-8258-42cb-a31a-5405ba36988b");
            var viewModel = new HCExaminationComponentFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._HCExaminationComponent = objectContext.GetObject(id.Value, objectDefID) as HCExaminationComponent;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HCExaminationComponent, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HCExaminationComponent, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._HCExaminationComponent);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._HCExaminationComponent);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_HCExaminationComponentForm(viewModel, viewModel._HCExaminationComponent, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._HCExaminationComponent = new HCExaminationComponent(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HCExaminationComponent, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HCExaminationComponent, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._HCExaminationComponent);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._HCExaminationComponent);
                    PreScript_HCExaminationComponentForm(viewModel, viewModel._HCExaminationComponent, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel HCExaminationComponentForm(HCExaminationComponentFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return HCExaminationComponentFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel HCExaminationComponentFormInternal(HCExaminationComponentFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("e62371f8-1f15-46ce-bf32-40840d8c59fe");
            objectContext.AddToRawObjectList(viewModel.ReasonForExaminationDefinitions);
            objectContext.AddToRawObjectList(viewModel._HCExaminationComponent);
            objectContext.AddToRawObjectList(viewModel.HCExaminationDisabledRatios);
            objectContext.ProcessRawObjects();
            var hCExaminationComponent = (HCExaminationComponent)objectContext.GetLoadedObject(viewModel._HCExaminationComponent.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(hCExaminationComponent, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HCExaminationComponent, formDefID);
            if (viewModel.HCExaminationDisabledRatios != null)
            {
                foreach (var item in viewModel.HCExaminationDisabledRatios)
                {
                    var hcExaminationDisabledRatioLoaded = (HCExaminationDisabledRatio)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)hcExaminationDisabledRatioLoaded).IsDeleted)
                        continue;
                    hcExaminationDisabledRatioLoaded.HCExaminationComponent = hCExaminationComponent;
                }
            }
            var transDef = hCExaminationComponent.TransDef;
            PostScript_HCExaminationComponentForm(viewModel, hCExaminationComponent, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(hCExaminationComponent);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(hCExaminationComponent);
            AfterContextSaveScript_HCExaminationComponentForm(viewModel, hCExaminationComponent, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }

        partial void PreScript_HCExaminationComponentForm(HCExaminationComponentFormViewModel viewModel, HCExaminationComponent hCExaminationComponent, TTObjectContext objectContext);
        partial void PostScript_HCExaminationComponentForm(HCExaminationComponentFormViewModel viewModel, HCExaminationComponent hCExaminationComponent, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_HCExaminationComponentForm(HCExaminationComponentFormViewModel viewModel, HCExaminationComponent hCExaminationComponent, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(HCExaminationComponentFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ReasonForExaminationDefinitions = objectContext.LocalQuery<ReasonForExaminationDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "HealthCommitteeExaminationReasonListDefinition", viewModel.ReasonForExaminationDefinitions);
            viewModel.CozgerSpecReqAreas = objectContext.LocalQuery<CozgerSpecReqArea>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CozgerSpecReqAreaListDef", viewModel.CozgerSpecReqAreas);
            viewModel.CozgerSpecReqLevels = objectContext.LocalQuery<CozgerSpecReqLevel>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CozgerSpecReqLevelListDef", viewModel.CozgerSpecReqLevels);
            viewModel.HCExaminationDisabledRatios = objectContext.LocalQuery<HCExaminationDisabledRatio>().ToArray();
        }
    }
}


namespace Core.Models
{
    public partial class HCExaminationComponentFormViewModel : BaseViewModel
    {
        public TTObjectClasses.HCExaminationComponent _HCExaminationComponent
        {
            get;
            set;
        }

        public TTObjectClasses.ReasonForExaminationDefinition[] ReasonForExaminationDefinitions
        {
            get;
            set;
        }
    }
}
