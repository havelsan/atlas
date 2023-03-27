//$53BA709F
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class WomanSpecialityObjectServiceController : Controller
{
    [HttpGet]
    public OldWomanSpecialityFormViewModel OldWomanSpecialityForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldWomanSpecialityFormLoadInternal(input);
    }

    [HttpPost]
    public OldWomanSpecialityFormViewModel OldWomanSpecialityFormLoad(FormLoadInput input)
    {
        return OldWomanSpecialityFormLoadInternal(input);
    }

    private OldWomanSpecialityFormViewModel OldWomanSpecialityFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("d38a6c28-902d-4e2d-ad22-a8cf3e54799d");
        var objectDefID = Guid.Parse("b62d311a-65be-4ab9-9352-539628da7580");
        var viewModel = new OldWomanSpecialityFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._WomanSpecialityObject = objectContext.GetObject(id.Value, objectDefID) as WomanSpecialityObject;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._WomanSpecialityObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._WomanSpecialityObject, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._WomanSpecialityObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._WomanSpecialityObject);
                PreScript_OldWomanSpecialityForm(viewModel, viewModel._WomanSpecialityObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._WomanSpecialityObject = new WomanSpecialityObject(objectContext);
                viewModel.PregnancyComplicationsGridList = new TTObjectClasses.PregnancyComplications[]{};
                viewModel.ObligedRiskFactorsGridList = new TTObjectClasses.ObligedRiskFactors[]{};
                viewModel.PregnancyDangerSignGridList = new TTObjectClasses.PregnancyDangerSign[]{};
                viewModel.FetusFollowGridList = new TTObjectClasses.FetusFollow[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._WomanSpecialityObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._WomanSpecialityObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._WomanSpecialityObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._WomanSpecialityObject);
                PreScript_OldWomanSpecialityForm(viewModel, viewModel._WomanSpecialityObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void OldWomanSpecialityForm(OldWomanSpecialityFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("d38a6c28-902d-4e2d-ad22-a8cf3e54799d");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.PregnancyFollows);
            objectContext.AddToRawObjectList(viewModel.SKRSGebelikteRiskFaktorleris);
            objectContext.AddToRawObjectList(viewModel.SKRSGebelikBildirimiZorunluRiskFaktorleris);
            objectContext.AddToRawObjectList(viewModel.SKRSGebelikLohusalikSeyrindeTehlikeIsaretis);
            objectContext.AddToRawObjectList(viewModel.SKRSKacinciGebeIzlems);
            objectContext.AddToRawObjectList(viewModel.SKRSKadinSagligiIslemleris);
            objectContext.AddToRawObjectList(viewModel.SKRSKonjenitalAnomaliliDogumVarligis);
            objectContext.AddToRawObjectList(viewModel.SKRSIdrardaProteins);
            objectContext.AddToRawObjectList(viewModel.SKRSDVitaminiLojistigiveDestegis);
            objectContext.AddToRawObjectList(viewModel.SKRSDemirLojistigiveDestegis);
            objectContext.AddToRawObjectList(viewModel.Infertilitys);
            objectContext.AddToRawObjectList(viewModel.Gynecologys);
            objectContext.AddToRawObjectList(viewModel.PregnancyComplicationsGridList);
            objectContext.AddToRawObjectList(viewModel.ObligedRiskFactorsGridList);
            objectContext.AddToRawObjectList(viewModel.PregnancyDangerSignGridList);
            objectContext.AddToRawObjectList(viewModel.FetusFollowGridList);
            objectContext.AddToRawObjectList(viewModel._WomanSpecialityObject);
            objectContext.ProcessRawObjects();
            var womanSpecialityObject = (WomanSpecialityObject)objectContext.GetLoadedObject(viewModel._WomanSpecialityObject.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(womanSpecialityObject, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._WomanSpecialityObject, formDefID);
            var pregnancyFollowImported = womanSpecialityObject.PregnancyFollow;
            if (pregnancyFollowImported != null)
            {
                if (viewModel.PregnancyComplicationsGridList != null)
                {
                    foreach (var item in viewModel.PregnancyComplicationsGridList)
                    {
                        var pregnancyComplicationsImported = (PregnancyComplications)objectContext.GetLoadedObject(item.ObjectID);
                        pregnancyComplicationsImported.PregnancyFollow = pregnancyFollowImported;
                    }
                }

                if (viewModel.ObligedRiskFactorsGridList != null)
                {
                    foreach (var item in viewModel.ObligedRiskFactorsGridList)
                    {
                        var obligedRiskFactorsImported = (ObligedRiskFactors)objectContext.GetLoadedObject(item.ObjectID);
                        obligedRiskFactorsImported.PregnancyFollow = pregnancyFollowImported;
                    }
                }

                if (viewModel.PregnancyDangerSignGridList != null)
                {
                    foreach (var item in viewModel.PregnancyDangerSignGridList)
                    {
                        var pregnancyDangerSignImported = (PregnancyDangerSign)objectContext.GetLoadedObject(item.ObjectID);
                        pregnancyDangerSignImported.PregnancyFollow = pregnancyFollowImported;
                    }
                }

                if (viewModel.FetusFollowGridList != null)
                {
                    foreach (var item in viewModel.FetusFollowGridList)
                    {
                        var fetusFollowImported = (FetusFollow)objectContext.GetLoadedObject(item.ObjectID);
                        fetusFollowImported.PregnancyFollow = pregnancyFollowImported;
                    }
                }
            }

            var transDef = womanSpecialityObject.TransDef;
            PostScript_OldWomanSpecialityForm(viewModel, womanSpecialityObject, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_OldWomanSpecialityForm(viewModel, womanSpecialityObject, transDef, objectContext);
        }
    }

    partial void PreScript_OldWomanSpecialityForm(OldWomanSpecialityFormViewModel viewModel, WomanSpecialityObject womanSpecialityObject, TTObjectContext objectContext);
    partial void PostScript_OldWomanSpecialityForm(OldWomanSpecialityFormViewModel viewModel, WomanSpecialityObject womanSpecialityObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldWomanSpecialityForm(OldWomanSpecialityFormViewModel viewModel, WomanSpecialityObject womanSpecialityObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldWomanSpecialityFormViewModel viewModel, TTObjectContext objectContext)
    {
        var pregnancyFollow = viewModel._WomanSpecialityObject.PregnancyFollow;
        if (pregnancyFollow != null)
        {
            viewModel.PregnancyComplicationsGridList = pregnancyFollow.PregnancyComplications.OfType<PregnancyComplications>().ToArray();
            viewModel.ObligedRiskFactorsGridList = pregnancyFollow.ObligedRiskFactors.OfType<ObligedRiskFactors>().ToArray();
            viewModel.PregnancyDangerSignGridList = pregnancyFollow.PregnancyDangerSign.OfType<PregnancyDangerSign>().ToArray();
            viewModel.FetusFollowGridList = pregnancyFollow.FetusFollow.OfType<FetusFollow>().ToArray();
        }

        viewModel.PregnancyFollows = objectContext.LocalQuery<PregnancyFollow>().ToArray();
        viewModel.SKRSGebelikteRiskFaktorleris = objectContext.LocalQuery<SKRSGebelikteRiskFaktorleri>().ToArray();
        viewModel.SKRSGebelikBildirimiZorunluRiskFaktorleris = objectContext.LocalQuery<SKRSGebelikBildirimiZorunluRiskFaktorleri>().ToArray();
        viewModel.SKRSGebelikLohusalikSeyrindeTehlikeIsaretis = objectContext.LocalQuery<SKRSGebelikLohusalikSeyrindeTehlikeIsareti>().ToArray();
        viewModel.SKRSKacinciGebeIzlems = objectContext.LocalQuery<SKRSKacinciGebeIzlem>().ToArray();
        viewModel.SKRSKadinSagligiIslemleris = objectContext.LocalQuery<SKRSKadinSagligiIslemleri>().ToArray();
        viewModel.SKRSKonjenitalAnomaliliDogumVarligis = objectContext.LocalQuery<SKRSKonjenitalAnomaliliDogumVarligi>().ToArray();
        viewModel.SKRSIdrardaProteins = objectContext.LocalQuery<SKRSIdrardaProtein>().ToArray();
        viewModel.SKRSDVitaminiLojistigiveDestegis = objectContext.LocalQuery<SKRSDVitaminiLojistigiveDestegi>().ToArray();
        viewModel.SKRSDemirLojistigiveDestegis = objectContext.LocalQuery<SKRSDemirLojistigiveDestegi>().ToArray();
        viewModel.Infertilitys = objectContext.LocalQuery<Infertility>().ToArray();
        viewModel.Gynecologys = objectContext.LocalQuery<Gynecology>().ToArray();
    }
}
}

namespace Core.Models
{
    public partial class OldWomanSpecialityFormViewModel : BaseViewModel
    {
        public TTObjectClasses.WomanSpecialityObject _WomanSpecialityObject
        {
            get;
            set;
        }

        public TTObjectClasses.PregnancyComplications[] PregnancyComplicationsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ObligedRiskFactors[] ObligedRiskFactorsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PregnancyDangerSign[] PregnancyDangerSignGridList
        {
            get;
            set;
        }

        public TTObjectClasses.FetusFollow[] FetusFollowGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PregnancyFollow[] PregnancyFollows
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGebelikteRiskFaktorleri[] SKRSGebelikteRiskFaktorleris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGebelikBildirimiZorunluRiskFaktorleri[] SKRSGebelikBildirimiZorunluRiskFaktorleris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGebelikLohusalikSeyrindeTehlikeIsareti[] SKRSGebelikLohusalikSeyrindeTehlikeIsaretis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKacinciGebeIzlem[] SKRSKacinciGebeIzlems
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKadinSagligiIslemleri[] SKRSKadinSagligiIslemleris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKonjenitalAnomaliliDogumVarligi[] SKRSKonjenitalAnomaliliDogumVarligis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSIdrardaProtein[] SKRSIdrardaProteins
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

        public TTObjectClasses.Infertility[] Infertilitys
        {
            get;
            set;
        }

        public TTObjectClasses.Gynecology[] Gynecologys
        {
            get;
            set;
        }
    }
}