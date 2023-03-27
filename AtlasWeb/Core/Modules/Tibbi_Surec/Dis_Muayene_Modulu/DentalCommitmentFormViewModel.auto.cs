//$27AB3341
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
    public partial class DentalCommitmentServiceController : Controller
{
    [HttpGet]
    public DentalCommitmentFormViewModel DentalCommitmentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DentalCommitmentFormLoadInternal(input);
    }

    [HttpPost]
    public DentalCommitmentFormViewModel DentalCommitmentFormLoad(FormLoadInput input)
    {
        return DentalCommitmentFormLoadInternal(input);
    }

    private DentalCommitmentFormViewModel DentalCommitmentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("c9efd409-5c8d-4ba3-b67a-fd8a00565888");
        var objectDefID = Guid.Parse("8a70a7e8-1e62-46e8-b3aa-8e73b01932eb");
        var viewModel = new DentalCommitmentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DentalCommitment = objectContext.GetObject(id.Value, objectDefID) as DentalCommitment;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DentalCommitment, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalCommitment, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DentalCommitment);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DentalCommitment);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DentalCommitmentForm(viewModel, viewModel._DentalCommitment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DentalCommitment = new DentalCommitment(objectContext);
                viewModel.DentalCommitmentProstethisesGridList = new TTObjectClasses.DentalCommitmentProsthesis[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DentalCommitment, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalCommitment, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DentalCommitment);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DentalCommitment);
                PreScript_DentalCommitmentForm(viewModel, viewModel._DentalCommitment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DentalCommitmentForm(DentalCommitmentFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return DentalCommitmentFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel DentalCommitmentFormInternal(DentalCommitmentFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("c9efd409-5c8d-4ba3-b67a-fd8a00565888");
        objectContext.AddToRawObjectList(viewModel.DentalProsthesisDefinitions);
        objectContext.AddToRawObjectList(viewModel.TownDefinitionss);
        objectContext.AddToRawObjectList(viewModel.Citys);
        objectContext.AddToRawObjectList(viewModel.DentalCommitmentProstethisesGridList);
        objectContext.AddToRawObjectList(viewModel._DentalCommitment);
        objectContext.ProcessRawObjects();
        var dentalCommitment = (DentalCommitment)objectContext.GetLoadedObject(viewModel._DentalCommitment.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(dentalCommitment, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DentalCommitment, formDefID);
        if (viewModel.DentalCommitmentProstethisesGridList != null)
        {
            foreach (var item in viewModel.DentalCommitmentProstethisesGridList)
            {
                var dentalCommitmentProstethisesImported = (DentalCommitmentProsthesis)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)dentalCommitmentProstethisesImported).IsDeleted)
                    continue;
                dentalCommitmentProstethisesImported.DentalCommitment = dentalCommitment;
            }
        }

        var transDef = dentalCommitment.TransDef;
        PostScript_DentalCommitmentForm(viewModel, dentalCommitment, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(dentalCommitment);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(dentalCommitment);
        AfterContextSaveScript_DentalCommitmentForm(viewModel, dentalCommitment, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_DentalCommitmentForm(DentalCommitmentFormViewModel viewModel, DentalCommitment dentalCommitment, TTObjectContext objectContext);
    partial void PostScript_DentalCommitmentForm(DentalCommitmentFormViewModel viewModel, DentalCommitment dentalCommitment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DentalCommitmentForm(DentalCommitmentFormViewModel viewModel, DentalCommitment dentalCommitment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DentalCommitmentFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DentalCommitmentProstethisesGridList = viewModel._DentalCommitment.DentalCommitmentProstethises.OfType<DentalCommitmentProsthesis>().ToArray();
        viewModel.DentalProsthesisDefinitions = objectContext.LocalQuery<DentalProsthesisDefinition>().ToArray();
        viewModel.TownDefinitionss = objectContext.LocalQuery<TownDefinitions>().ToArray();
        viewModel.Citys = objectContext.LocalQuery<City>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TownListDefinition", viewModel.TownDefinitionss);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CityListDefinition", viewModel.Citys);
    }
}
}


namespace Core.Models
{
    public partial class DentalCommitmentFormViewModel
    {
        public TTObjectClasses.DentalCommitment _DentalCommitment
        {
            get;
            set;
        }

        public TTObjectClasses.DentalCommitmentProsthesis[] DentalCommitmentProstethisesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DentalProsthesisDefinition[] DentalProsthesisDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.TownDefinitions[] TownDefinitionss
        {
            get;
            set;
        }

        public TTObjectClasses.City[] Citys
        {
            get;
            set;
        }
    }
}
