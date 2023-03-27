//$D83F609E
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
    public partial class LaboratoryProcedureServiceController : Controller
{
    [HttpGet]
    public LaboratoryCokluOzelDurumFormViewModel LaboratoryCokluOzelDurumForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return LaboratoryCokluOzelDurumFormLoadInternal(input);
    }

    [HttpPost]
    public LaboratoryCokluOzelDurumFormViewModel LaboratoryCokluOzelDurumFormLoad(FormLoadInput input)
    {
        return LaboratoryCokluOzelDurumFormLoadInternal(input);
    }

    private LaboratoryCokluOzelDurumFormViewModel LaboratoryCokluOzelDurumFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("bda837ec-1ffa-4074-a91d-9e33bc943b47");
        var objectDefID = Guid.Parse("f87eac33-a91e-4934-a010-edf6029d2d18");
        var viewModel = new LaboratoryCokluOzelDurumFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._LaboratoryProcedure = objectContext.GetObject(id.Value, objectDefID) as LaboratoryProcedure;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._LaboratoryProcedure, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LaboratoryProcedure, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._LaboratoryProcedure);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._LaboratoryProcedure);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_LaboratoryCokluOzelDurumForm(viewModel, viewModel._LaboratoryProcedure, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel LaboratoryCokluOzelDurumForm(LaboratoryCokluOzelDurumFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("bda837ec-1ffa-4074-a91d-9e33bc943b47");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.OzelDurums);
            objectContext.AddToRawObjectList(viewModel.ttgridOzelDurumGridList);
            objectContext.AddToRawObjectList(viewModel._LaboratoryProcedure);
            objectContext.ProcessRawObjects();
            var laboratoryProcedure = (LaboratoryProcedure)objectContext.GetLoadedObject(viewModel._LaboratoryProcedure.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(laboratoryProcedure, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._LaboratoryProcedure, formDefID);
            if (viewModel.ttgridOzelDurumGridList != null)
            {
                foreach (var item in viewModel.ttgridOzelDurumGridList)
                {
                    var cokluOzelDurumImported = (CokluOzelDurum)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)cokluOzelDurumImported).IsDeleted)
                        continue;
                    cokluOzelDurumImported.LaboratoryProcedure = laboratoryProcedure;
                }
            }

            var transDef = laboratoryProcedure.TransDef;
            PostScript_LaboratoryCokluOzelDurumForm(viewModel, laboratoryProcedure, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(laboratoryProcedure);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(laboratoryProcedure);
            AfterContextSaveScript_LaboratoryCokluOzelDurumForm(viewModel, laboratoryProcedure, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_LaboratoryCokluOzelDurumForm(LaboratoryCokluOzelDurumFormViewModel viewModel, LaboratoryProcedure laboratoryProcedure, TTObjectContext objectContext);
    partial void PostScript_LaboratoryCokluOzelDurumForm(LaboratoryCokluOzelDurumFormViewModel viewModel, LaboratoryProcedure laboratoryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_LaboratoryCokluOzelDurumForm(LaboratoryCokluOzelDurumFormViewModel viewModel, LaboratoryProcedure laboratoryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(LaboratoryCokluOzelDurumFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ttgridOzelDurumGridList = viewModel._LaboratoryProcedure.CokluOzelDurum.OfType<CokluOzelDurum>().ToArray();
        viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
    }
}
}


namespace Core.Models
{
    public partial class LaboratoryCokluOzelDurumFormViewModel : BaseViewModel
    {
        public TTObjectClasses.LaboratoryProcedure _LaboratoryProcedure { get; set; }
        public TTObjectClasses.CokluOzelDurum[] ttgridOzelDurumGridList { get; set; }
        public TTObjectClasses.OzelDurum[] OzelDurums { get; set; }
    }
}
