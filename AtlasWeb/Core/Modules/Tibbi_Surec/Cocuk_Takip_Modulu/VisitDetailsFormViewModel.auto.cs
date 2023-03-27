//$1143B2FC
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
    public partial class ChildGrowthVisitsServiceController : Controller
{
    [HttpGet]
    public VisitDetailsFormViewModel VisitDetailsForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return VisitDetailsFormLoadInternal(input);
    }

    [HttpPost]
    public VisitDetailsFormViewModel VisitDetailsFormLoad(FormLoadInput input)
    {
        return VisitDetailsFormLoadInternal(input);
    }

    private VisitDetailsFormViewModel VisitDetailsFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("299739cc-06d2-4700-9dfd-ac54d5c0cb43");
        var objectDefID = Guid.Parse("27cdfb0a-64ca-4466-ad10-86bee55e67d4");
        var viewModel = new VisitDetailsFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ChildGrowthVisits = objectContext.GetObject(id.Value, objectDefID) as ChildGrowthVisits;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChildGrowthVisits, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChildGrowthVisits, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ChildGrowthVisits);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ChildGrowthVisits);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_VisitDetailsForm(viewModel, viewModel._ChildGrowthVisits, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ChildGrowthVisits = new ChildGrowthVisits(objectContext);
                viewModel.InfantRiskFactorsGridList = new TTObjectClasses.InfantRiskFactors[]{};
                viewModel.ChildBrainDevelopmentRiskFactorsGridList = new TTObjectClasses.ChildBrainDevelopmentRiskFactors[]{};
                viewModel.ParentalActivitiesForPsychologicalDevelopmentGridList = new TTObjectClasses.ParentalActivitiesForPsychologicalDevelopment[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChildGrowthVisits, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChildGrowthVisits, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ChildGrowthVisits);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ChildGrowthVisits);
                PreScript_VisitDetailsForm(viewModel, viewModel._ChildGrowthVisits, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel VisitDetailsForm(VisitDetailsFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return VisitDetailsFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel VisitDetailsFormInternal(VisitDetailsFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("299739cc-06d2-4700-9dfd-ac54d5c0cb43");
        objectContext.AddToRawObjectList(viewModel.SKRSBebeginBeslenmeDurumus);
        objectContext.AddToRawObjectList(viewModel.SKRSGelisimTablosuBilgilerininSorgulanmasis);
        objectContext.AddToRawObjectList(viewModel.SKRSDVitaminiLojistigiveDestegis);
        objectContext.AddToRawObjectList(viewModel.SKRSDemirLojistigiveDestegis);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.SKRSBebekteRiskFaktorleris);
        objectContext.AddToRawObjectList(viewModel.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers);
        objectContext.AddToRawObjectList(viewModel.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris);
        objectContext.AddToRawObjectList(viewModel.InfantRiskFactorsGridList);
        objectContext.AddToRawObjectList(viewModel.ChildBrainDevelopmentRiskFactorsGridList);
        objectContext.AddToRawObjectList(viewModel.ParentalActivitiesForPsychologicalDevelopmentGridList);
        objectContext.AddToRawObjectList(viewModel._ChildGrowthVisits);
        objectContext.ProcessRawObjects();
        var childGrowthVisits = (ChildGrowthVisits)objectContext.GetLoadedObject(viewModel._ChildGrowthVisits.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(childGrowthVisits, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChildGrowthVisits, formDefID);
        if (viewModel.InfantRiskFactorsGridList != null)
        {
            foreach (var item in viewModel.InfantRiskFactorsGridList)
            {
                var infantRiskFactorsImported = (InfantRiskFactors)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)infantRiskFactorsImported).IsDeleted)
                    continue;
                infantRiskFactorsImported.ChildGrowthVisits = childGrowthVisits;
            }
        }

        if (viewModel.ChildBrainDevelopmentRiskFactorsGridList != null)
        {
            foreach (var item in viewModel.ChildBrainDevelopmentRiskFactorsGridList)
            {
                var childBrainDevelopmentRiskFactorsImported = (ChildBrainDevelopmentRiskFactors)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)childBrainDevelopmentRiskFactorsImported).IsDeleted)
                    continue;
                childBrainDevelopmentRiskFactorsImported.ChildGrowthVisits = childGrowthVisits;
            }
        }

        if (viewModel.ParentalActivitiesForPsychologicalDevelopmentGridList != null)
        {
            foreach (var item in viewModel.ParentalActivitiesForPsychologicalDevelopmentGridList)
            {
                var parentalActivitiesForPsychologicalDevelopmentImported = (ParentalActivitiesForPsychologicalDevelopment)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)parentalActivitiesForPsychologicalDevelopmentImported).IsDeleted)
                    continue;
                parentalActivitiesForPsychologicalDevelopmentImported.ChildGrowthVisits = childGrowthVisits;
            }
        }

        var transDef = childGrowthVisits.TransDef;
        PostScript_VisitDetailsForm(viewModel, childGrowthVisits, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(childGrowthVisits);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(childGrowthVisits);
        AfterContextSaveScript_VisitDetailsForm(viewModel, childGrowthVisits, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_VisitDetailsForm(VisitDetailsFormViewModel viewModel, ChildGrowthVisits childGrowthVisits, TTObjectContext objectContext);
    partial void PostScript_VisitDetailsForm(VisitDetailsFormViewModel viewModel, ChildGrowthVisits childGrowthVisits, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_VisitDetailsForm(VisitDetailsFormViewModel viewModel, ChildGrowthVisits childGrowthVisits, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(VisitDetailsFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.InfantRiskFactorsGridList = viewModel._ChildGrowthVisits.InfantRiskFactors.OfType<InfantRiskFactors>().ToArray();
        viewModel.ChildBrainDevelopmentRiskFactorsGridList = viewModel._ChildGrowthVisits.ChildBrainDevelopmentRiskFactors.OfType<ChildBrainDevelopmentRiskFactors>().ToArray();
        viewModel.ParentalActivitiesForPsychologicalDevelopmentGridList = viewModel._ChildGrowthVisits.ParentalActivitiesForPsychologicalDevelopment.OfType<ParentalActivitiesForPsychologicalDevelopment>().ToArray();
        viewModel.SKRSBebeginBeslenmeDurumus = objectContext.LocalQuery<SKRSBebeginBeslenmeDurumu>().ToArray();
        viewModel.SKRSGelisimTablosuBilgilerininSorgulanmasis = objectContext.LocalQuery<SKRSGelisimTablosuBilgilerininSorgulanmasi>().ToArray();
        viewModel.SKRSDVitaminiLojistigiveDestegis = objectContext.LocalQuery<SKRSDVitaminiLojistigiveDestegi>().ToArray();
        viewModel.SKRSDemirLojistigiveDestegis = objectContext.LocalQuery<SKRSDemirLojistigiveDestegi>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SKRSBebekteRiskFaktorleris = objectContext.LocalQuery<SKRSBebekteRiskFaktorleri>().ToArray();
        viewModel.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers = objectContext.LocalQuery<SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler>().ToArray();
        viewModel.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris = objectContext.LocalQuery<SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBebeginBeslenmeDurumuList", viewModel.SKRSBebeginBeslenmeDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGelisimTablosuBilgilerininSorgulanmasiList", viewModel.SKRSGelisimTablosuBilgilerininSorgulanmasis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDVitaminiLojistigiveDestegiList", viewModel.SKRSDVitaminiLojistigiveDestegis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDemirLojistigiveDestegiList", viewModel.SKRSDemirLojistigiveDestegis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NurseListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBebekteRiskFaktorleriList", viewModel.SKRSBebekteRiskFaktorleris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRi", viewModel.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktivit", viewModel.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris);
    }
}
}


namespace Core.Models
{
    public partial class VisitDetailsFormViewModel
    {
        public TTObjectClasses.ChildGrowthVisits _ChildGrowthVisits
        {
            get;
            set;
        }

        public TTObjectClasses.InfantRiskFactors[] InfantRiskFactorsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ChildBrainDevelopmentRiskFactors[] ChildBrainDevelopmentRiskFactorsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ParentalActivitiesForPsychologicalDevelopment[] ParentalActivitiesForPsychologicalDevelopmentGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSBebeginBeslenmeDurumu[] SKRSBebeginBeslenmeDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGelisimTablosuBilgilerininSorgulanmasi[] SKRSGelisimTablosuBilgilerininSorgulanmasis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDVitaminiLojistigiveDestegi[] SKRSDVitaminiLojistigiveDestegis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDemirLojistigiveDestegi[] SKRSDemirLojistigiveDestegis
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSBebekteRiskFaktorleri[] SKRSBebekteRiskFaktorleris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler[] SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri[] SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris
        {
            get;
            set;
        }
    }
}
