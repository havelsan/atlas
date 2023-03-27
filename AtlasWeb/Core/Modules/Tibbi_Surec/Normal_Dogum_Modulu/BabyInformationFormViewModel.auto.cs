//$B7EC5C15
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
    public partial class BabyObstetricInformationServiceController : Controller
{
    [HttpGet]
    public BabyInformationFormViewModel BabyInformationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BabyInformationFormLoadInternal(input);
    }

    [HttpPost]
    public BabyInformationFormViewModel BabyInformationFormLoad(FormLoadInput input)
    {
        return BabyInformationFormLoadInternal(input);
    }

    private BabyInformationFormViewModel BabyInformationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("4a0db5f5-7f8b-4497-9376-0bd6cf01f0b4");
        var objectDefID = Guid.Parse("21ed357e-33bf-4a60-b10b-7902ea386869");
        var viewModel = new BabyInformationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BabyObstetricInformation = objectContext.GetObject(id.Value, objectDefID) as BabyObstetricInformation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BabyObstetricInformation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BabyObstetricInformation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BabyObstetricInformation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BabyObstetricInformation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BabyInformationForm(viewModel, viewModel._BabyObstetricInformation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BabyObstetricInformation = new BabyObstetricInformation(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BabyObstetricInformation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BabyObstetricInformation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BabyObstetricInformation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BabyObstetricInformation);
                PreScript_BabyInformationForm(viewModel, viewModel._BabyObstetricInformation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BabyInformationForm(BabyInformationFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return BabyInformationFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel BabyInformationFormInternal(BabyInformationFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("4a0db5f5-7f8b-4497-9376-0bd6cf01f0b4");
        objectContext.AddToRawObjectList(viewModel.Apgars);
        objectContext.AddToRawObjectList(viewModel.SKRSCinsiyets);
        objectContext.AddToRawObjectList(viewModel.SKRSDogumYontemis);
        objectContext.AddToRawObjectList(viewModel.SKRSDogumSirasis);
        objectContext.AddToRawObjectList(viewModel.SKRSDogumunGerceklestigiYers);
        objectContext.AddToRawObjectList(viewModel.SKRSBebekOlumNedenleris);
        objectContext.AddToRawObjectList(viewModel._BabyObstetricInformation);
        objectContext.ProcessRawObjects();
        var babyObstetricInformation = (BabyObstetricInformation)objectContext.GetLoadedObject(viewModel._BabyObstetricInformation.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(babyObstetricInformation, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BabyObstetricInformation, formDefID);
        var transDef = babyObstetricInformation.TransDef;
        PostScript_BabyInformationForm(viewModel, babyObstetricInformation, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(babyObstetricInformation);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(babyObstetricInformation);
        AfterContextSaveScript_BabyInformationForm(viewModel, babyObstetricInformation, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_BabyInformationForm(BabyInformationFormViewModel viewModel, BabyObstetricInformation babyObstetricInformation, TTObjectContext objectContext);
    partial void PostScript_BabyInformationForm(BabyInformationFormViewModel viewModel, BabyObstetricInformation babyObstetricInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BabyInformationForm(BabyInformationFormViewModel viewModel, BabyObstetricInformation babyObstetricInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BabyInformationFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.Apgars = objectContext.LocalQuery<Apgar>().ToArray();
        viewModel.SKRSCinsiyets = objectContext.LocalQuery<SKRSCinsiyet>().ToArray();
        viewModel.SKRSDogumYontemis = objectContext.LocalQuery<SKRSDogumYontemi>().ToArray();
        viewModel.SKRSDogumSirasis = objectContext.LocalQuery<SKRSDogumSirasi>().ToArray();
        viewModel.SKRSDogumunGerceklestigiYers = objectContext.LocalQuery<SKRSDogumunGerceklestigiYer>().ToArray();
        viewModel.SKRSBebekOlumNedenleris = objectContext.LocalQuery<SKRSBebekOlumNedenleri>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSCinsiyetList", viewModel.SKRSCinsiyets);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDogumYontemiList", viewModel.SKRSDogumYontemis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDogumSirasiList", viewModel.SKRSDogumSirasis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDogumunGerceklestigiYerList", viewModel.SKRSDogumunGerceklestigiYers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBebekOlumNedenleriList", viewModel.SKRSBebekOlumNedenleris);
    }
}
}


namespace Core.Models
{
    public partial class BabyInformationFormViewModel
    {
        public TTObjectClasses.BabyObstetricInformation _BabyObstetricInformation
        {
            get;
            set;
        }

        public TTObjectClasses.Apgar[] Apgars
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSCinsiyet[] SKRSCinsiyets
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDogumYontemi[] SKRSDogumYontemis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDogumSirasi[] SKRSDogumSirasis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDogumunGerceklestigiYer[] SKRSDogumunGerceklestigiYers
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSBebekOlumNedenleri[] SKRSBebekOlumNedenleris
        {
            get;
            set;
        }
        public string PhotoString { get; set; }
    }
}
