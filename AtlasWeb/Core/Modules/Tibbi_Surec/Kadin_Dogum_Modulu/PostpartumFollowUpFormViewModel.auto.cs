//$7B1150C0
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
    public partial class PostpartumFollowUpServiceController : Controller
    {
        [HttpGet]
        public PostpartumFollowUpFormViewModel PostpartumFollowUpForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return PostpartumFollowUpFormLoadInternal(input);
        }

        [HttpPost]
        public PostpartumFollowUpFormViewModel PostpartumFollowUpFormLoad(FormLoadInput input)
        {
            return PostpartumFollowUpFormLoadInternal(input);
        }
        [HttpGet]
        public PostpartumFollowUpFormViewModel PostpartumFollowUpFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("c4d98147-6846-4a0a-b31a-5950304db082");
            var objectDefID = Guid.Parse("81ec64a9-2ee0-4765-aea5-043ce7897c85");
            var viewModel = new PostpartumFollowUpFormViewModel();
            viewModel.ActiveIDsModel = input.Model;

            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PostpartumFollowUp = objectContext.GetObject(id.Value, objectDefID) as PostpartumFollowUp;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PostpartumFollowUp, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PostpartumFollowUp, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PostpartumFollowUp);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PostpartumFollowUp);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_PostpartumFollowUpForm(viewModel, viewModel._PostpartumFollowUp, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PostpartumFollowUp = new PostpartumFollowUp(objectContext);
                    viewModel.WomanHealthOperationsGridList = new TTObjectClasses.WomanHealthOperations[] { };
                    viewModel.DangerSignsGridList = new TTObjectClasses.PostpartumDangerSigns[] { };
                    viewModel.ComplicationDiagnosisGridList = new TTObjectClasses.ComplicationDiagnosis[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PostpartumFollowUp, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PostpartumFollowUp, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PostpartumFollowUp);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PostpartumFollowUp);
                    PreScript_PostpartumFollowUpForm(viewModel, viewModel._PostpartumFollowUp, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel PostpartumFollowUpForm(PostpartumFollowUpFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return PostpartumFollowUpFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel PostpartumFollowUpFormInternal(PostpartumFollowUpFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("c4d98147-6846-4a0a-b31a-5950304db082");
            objectContext.AddToRawObjectList(viewModel.SKRSKadinSagligiIslemleris);
            objectContext.AddToRawObjectList(viewModel.SKRSGebelikLohusalikSeyrindeTehlikeIsaretis);
            objectContext.AddToRawObjectList(viewModel.SKRSICDs);
            objectContext.AddToRawObjectList(viewModel.SKRSKonjenitalAnomaliliDogumVarligis);
            objectContext.AddToRawObjectList(viewModel.SKRSUterusInvolusyons);
            objectContext.AddToRawObjectList(viewModel.SKRSPostpartumDepresyons);
            objectContext.AddToRawObjectList(viewModel.SKRSDVitaminiLojistigiveDestegis);
            objectContext.AddToRawObjectList(viewModel.SKRSDemirLojistigiveDestegis);
            objectContext.AddToRawObjectList(viewModel.SKRSKacinciLohusaIzlems);
            objectContext.AddToRawObjectList(viewModel.WomanHealthOperationsGridList);
            objectContext.AddToRawObjectList(viewModel.DangerSignsGridList);
            objectContext.AddToRawObjectList(viewModel.ComplicationDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel._PostpartumFollowUp);
            objectContext.ProcessRawObjects();

            var postpartumFollowUp = (PostpartumFollowUp)objectContext.GetLoadedObject(viewModel._PostpartumFollowUp.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(postpartumFollowUp, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PostpartumFollowUp, formDefID);

            if (viewModel.WomanHealthOperationsGridList != null)
            {
                foreach (var item in viewModel.WomanHealthOperationsGridList)
                {
                    var womanHealthOperationsImported = (WomanHealthOperations)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)womanHealthOperationsImported).IsDeleted)
                        continue;
                    womanHealthOperationsImported.PostpartumFollowUp = postpartumFollowUp;
                }
            }

            if (viewModel.DangerSignsGridList != null)
            {
                foreach (var item in viewModel.DangerSignsGridList)
                {
                    var dangerSignsImported = (PostpartumDangerSigns)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)dangerSignsImported).IsDeleted)
                        continue;
                    dangerSignsImported.PostpartumFollowUp = postpartumFollowUp;
                }
            }

            if (viewModel.ComplicationDiagnosisGridList != null)
            {
                foreach (var item in viewModel.ComplicationDiagnosisGridList)
                {
                    var complicationDiagnosisImported = (ComplicationDiagnosis)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)complicationDiagnosisImported).IsDeleted)
                        continue;
                    complicationDiagnosisImported.PostpartumFollowUp = postpartumFollowUp;
                }
            }
            var transDef = postpartumFollowUp.TransDef;
            PostScript_PostpartumFollowUpForm(viewModel, postpartumFollowUp, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(postpartumFollowUp);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(postpartumFollowUp);
            AfterContextSaveScript_PostpartumFollowUpForm(viewModel, postpartumFollowUp, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_PostpartumFollowUpForm(PostpartumFollowUpFormViewModel viewModel, PostpartumFollowUp postpartumFollowUp, TTObjectContext objectContext);
        partial void PostScript_PostpartumFollowUpForm(PostpartumFollowUpFormViewModel viewModel, PostpartumFollowUp postpartumFollowUp, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_PostpartumFollowUpForm(PostpartumFollowUpFormViewModel viewModel, PostpartumFollowUp postpartumFollowUp, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(PostpartumFollowUpFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.WomanHealthOperationsGridList = viewModel._PostpartumFollowUp.WomanHealthOperations.OfType<WomanHealthOperations>().ToArray();
            viewModel.DangerSignsGridList = viewModel._PostpartumFollowUp.DangerSigns.OfType<PostpartumDangerSigns>().ToArray();
            viewModel.ComplicationDiagnosisGridList = viewModel._PostpartumFollowUp.ComplicationDiagnosis.OfType<ComplicationDiagnosis>().ToArray();
            viewModel.SKRSKadinSagligiIslemleris = objectContext.LocalQuery<SKRSKadinSagligiIslemleri>().ToArray();
            viewModel.SKRSGebelikLohusalikSeyrindeTehlikeIsaretis = objectContext.LocalQuery<SKRSGebelikLohusalikSeyrindeTehlikeIsareti>().ToArray();
            viewModel.SKRSICDs = objectContext.LocalQuery<SKRSICD>().ToArray();
            viewModel.SKRSKonjenitalAnomaliliDogumVarligis = objectContext.LocalQuery<SKRSKonjenitalAnomaliliDogumVarligi>().ToArray();
            viewModel.SKRSUterusInvolusyons = objectContext.LocalQuery<SKRSUterusInvolusyon>().ToArray();
            viewModel.SKRSPostpartumDepresyons = objectContext.LocalQuery<SKRSPostpartumDepresyon>().ToArray();
            viewModel.SKRSDVitaminiLojistigiveDestegis = objectContext.LocalQuery<SKRSDVitaminiLojistigiveDestegi>().ToArray();
            viewModel.SKRSDemirLojistigiveDestegis = objectContext.LocalQuery<SKRSDemirLojistigiveDestegi>().ToArray();
            viewModel.SKRSKacinciLohusaIzlems = objectContext.LocalQuery<SKRSKacinciLohusaIzlem>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKadinSagligiIslemleriList", viewModel.SKRSKadinSagligiIslemleris);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGebelikLohusalikSeyrindeTehlikeIsaretiList", viewModel.SKRSGebelikLohusalikSeyrindeTehlikeIsaretis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDList", viewModel.SKRSICDs);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKonjenitalAnomaliliDogumVarligiList", viewModel.SKRSKonjenitalAnomaliliDogumVarligis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSUterusInvolusyonList", viewModel.SKRSUterusInvolusyons);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSPostpartumDepresyonList", viewModel.SKRSPostpartumDepresyons);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDVitaminiLojistigiveDestegiList", viewModel.SKRSDVitaminiLojistigiveDestegis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDemirLojistigiveDestegiList", viewModel.SKRSDemirLojistigiveDestegis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKacinciLohusaIzlemList", viewModel.SKRSKacinciLohusaIzlems);
        }
    }
}


namespace Core.Models
{
    public partial class PostpartumFollowUpFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PostpartumFollowUp _PostpartumFollowUp
        {
            get;
            set;
        }

        public TTObjectClasses.WomanHealthOperations[] WomanHealthOperationsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PostpartumDangerSigns[] DangerSignsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ComplicationDiagnosis[] ComplicationDiagnosisGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKadinSagligiIslemleri[] SKRSKadinSagligiIslemleris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGebelikLohusalikSeyrindeTehlikeIsareti[] SKRSGebelikLohusalikSeyrindeTehlikeIsaretis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSICD[] SKRSICDs
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKonjenitalAnomaliliDogumVarligi[] SKRSKonjenitalAnomaliliDogumVarligis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSUterusInvolusyon[] SKRSUterusInvolusyons
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSPostpartumDepresyon[] SKRSPostpartumDepresyons
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

        public TTObjectClasses.SKRSKacinciLohusaIzlem[] SKRSKacinciLohusaIzlems
        {
            get;
            set;
        }
    }
}
