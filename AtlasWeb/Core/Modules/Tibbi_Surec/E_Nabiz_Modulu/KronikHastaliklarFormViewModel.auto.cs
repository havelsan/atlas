//$A02BD2E3
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
    public partial class KronikHastaliklarVeriSetiServiceController : Controller
{
    [HttpGet]
    public KronikHastaliklarFormViewModel KronikHastaliklarForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return KronikHastaliklarFormLoadInternal(input);
    }

    [HttpPost]
    public KronikHastaliklarFormViewModel KronikHastaliklarFormLoad(FormLoadInput input)
    {
        return KronikHastaliklarFormLoadInternal(input);
    }

    private KronikHastaliklarFormViewModel KronikHastaliklarFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e5d96dd3-cc30-414a-9fc5-ce6e318fcd76");
        var objectDefID = Guid.Parse("640cec12-e2a9-4429-87d6-9e1cad67e9d1");
        var viewModel = new KronikHastaliklarFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._KronikHastaliklarVeriSeti = objectContext.GetObject(id.Value, objectDefID) as KronikHastaliklarVeriSeti;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._KronikHastaliklarVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KronikHastaliklarVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._KronikHastaliklarVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._KronikHastaliklarVeriSeti);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_KronikHastaliklarForm(viewModel, viewModel._KronikHastaliklarVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._KronikHastaliklarVeriSeti = new KronikHastaliklarVeriSeti(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._KronikHastaliklarVeriSeti, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KronikHastaliklarVeriSeti, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._KronikHastaliklarVeriSeti);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._KronikHastaliklarVeriSeti);
                PreScript_KronikHastaliklarForm(viewModel, viewModel._KronikHastaliklarVeriSeti, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel KronikHastaliklarForm(KronikHastaliklarFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("e5d96dd3-cc30-414a-9fc5-ce6e318fcd76");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SKRSSpirometris);
            objectContext.AddToRawObjectList(viewModel._KronikHastaliklarVeriSeti);
            objectContext.ProcessRawObjects();
            var kronikHastaliklarVeriSeti = (KronikHastaliklarVeriSeti)objectContext.GetLoadedObject(viewModel._KronikHastaliklarVeriSeti.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(kronikHastaliklarVeriSeti, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._KronikHastaliklarVeriSeti, formDefID);
            var transDef = kronikHastaliklarVeriSeti.TransDef;
            PostScript_KronikHastaliklarForm(viewModel, kronikHastaliklarVeriSeti, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(kronikHastaliklarVeriSeti);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(kronikHastaliklarVeriSeti);
            AfterContextSaveScript_KronikHastaliklarForm(viewModel, kronikHastaliklarVeriSeti, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_KronikHastaliklarForm(KronikHastaliklarFormViewModel viewModel, KronikHastaliklarVeriSeti kronikHastaliklarVeriSeti, TTObjectContext objectContext);
    partial void PostScript_KronikHastaliklarForm(KronikHastaliklarFormViewModel viewModel, KronikHastaliklarVeriSeti kronikHastaliklarVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_KronikHastaliklarForm(KronikHastaliklarFormViewModel viewModel, KronikHastaliklarVeriSeti kronikHastaliklarVeriSeti, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(KronikHastaliklarFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SKRSSpirometris = objectContext.LocalQuery<SKRSSpirometri>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSSpirometriList", viewModel.SKRSSpirometris);
    }
}
}


namespace Core.Models
{
    public partial class KronikHastaliklarFormViewModel : BaseViewModel
    {
        public TTObjectClasses.KronikHastaliklarVeriSeti _KronikHastaliklarVeriSeti { get; set; }
        public TTObjectClasses.SKRSSpirometri[] SKRSSpirometris { get; set; }
    }
}
