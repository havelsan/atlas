//$6C657C49
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
    public partial class InheldIncreasingProcessServiceController : Controller
    {
        [HttpGet]
        public InheldIncreasingProcessFormViewModel InheldIncreasingProcessForm(Guid? id)
        {
            var formDefID = Guid.Parse("9e2c20f6-fdcb-4a84-a1a8-d8d816133f8c");
            var objectDefID = Guid.Parse("c1574cb9-f8fb-4a99-8afe-cbf88ba30caa");
            var viewModel = new InheldIncreasingProcessFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._InheldIncreasingProcess = objectContext.GetObject(id.Value, objectDefID) as InheldIncreasingProcess;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InheldIncreasingProcess, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InheldIncreasingProcess, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InheldIncreasingProcess);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InheldIncreasingProcess);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_InheldIncreasingProcessForm(viewModel, viewModel._InheldIncreasingProcess, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._InheldIncreasingProcess = new InheldIncreasingProcess(objectContext);
                    var entryStateID = Guid.Parse("4719aa6f-900a-4ba8-9700-1e1ad0b27049");
                    viewModel._InheldIncreasingProcess.CurrentStateDefID = entryStateID;
                    viewModel.InheldIncreasingProcessDetsGridList = new TTObjectClasses.InheldIncreasingProcessDet[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InheldIncreasingProcess, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InheldIncreasingProcess, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._InheldIncreasingProcess);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._InheldIncreasingProcess);
                    PreScript_InheldIncreasingProcessForm(viewModel, viewModel._InheldIncreasingProcess, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel InheldIncreasingProcessForm(InheldIncreasingProcessFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return InheldIncreasingProcessFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel InheldIncreasingProcessFormInternal(InheldIncreasingProcessFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("9e2c20f6-fdcb-4a84-a1a8-d8d816133f8c");
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.InheldIncreasingProcessDetsGridList);
            var entryStateID = Guid.Parse("4719aa6f-900a-4ba8-9700-1e1ad0b27049");
            objectContext.AddToRawObjectList(viewModel._InheldIncreasingProcess, entryStateID);
            objectContext.ProcessRawObjects(false);

            var inheldIncreasingProcess = (InheldIncreasingProcess)objectContext.GetLoadedObject(viewModel._InheldIncreasingProcess.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inheldIncreasingProcess, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InheldIncreasingProcess, formDefID);

            if (viewModel.InheldIncreasingProcessDetsGridList != null)
            {
                foreach (var item in viewModel.InheldIncreasingProcessDetsGridList)
                {
                    var inheldIncreasingProcessDetsImported = (InheldIncreasingProcessDet)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)inheldIncreasingProcessDetsImported).IsDeleted)
                        continue;
                    inheldIncreasingProcessDetsImported.InheldIncreasingProcess = inheldIncreasingProcess;
                }
            }
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(inheldIncreasingProcess);
            PostScript_InheldIncreasingProcessForm(viewModel, inheldIncreasingProcess, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inheldIncreasingProcess);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inheldIncreasingProcess);
            AfterContextSaveScript_InheldIncreasingProcessForm(viewModel, inheldIncreasingProcess, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_InheldIncreasingProcessForm(InheldIncreasingProcessFormViewModel viewModel, InheldIncreasingProcess inheldIncreasingProcess, TTObjectContext objectContext);
        partial void PostScript_InheldIncreasingProcessForm(InheldIncreasingProcessFormViewModel viewModel, InheldIncreasingProcess inheldIncreasingProcess, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_InheldIncreasingProcessForm(InheldIncreasingProcessFormViewModel viewModel, InheldIncreasingProcess inheldIncreasingProcess, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(InheldIncreasingProcessFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.InheldIncreasingProcessDetsGridList = viewModel._InheldIncreasingProcess.InheldIncreasingProcessDets.OfType<InheldIncreasingProcessDet>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        }
    }
}


namespace Core.Models
{
    public partial class InheldIncreasingProcessFormViewModel
    {
        public TTObjectClasses.InheldIncreasingProcess _InheldIncreasingProcess
        {
            get;
            set;
        }

        public TTObjectClasses.InheldIncreasingProcessDet[] InheldIncreasingProcessDetsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }
    }
}
