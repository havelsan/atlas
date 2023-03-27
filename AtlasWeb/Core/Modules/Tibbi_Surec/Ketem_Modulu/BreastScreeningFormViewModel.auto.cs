//$80BF5878
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
    public partial class BreastScreeningServiceController : Controller
    {

        [HttpGet]
        public BreastScreeningFormViewModel BreastScreeningForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return BreastScreeningFormLoadInternal(input);
        }

        [HttpPost]
        public BreastScreeningFormViewModel BreastScreeningFormLoad(FormLoadInput input)
        {
            return BreastScreeningFormLoadInternal(input);
        }

        public BreastScreeningFormViewModel BreastScreeningFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("10c5bc95-f9e4-44d0-8da6-4120644257c0");
            var objectDefID = Guid.Parse("9604dc7d-4835-4762-8d2d-c2c690e244da");
            var viewModel = new BreastScreeningFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._BreastScreening = objectContext.GetObject(id.Value, objectDefID) as BreastScreening;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BreastScreening, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BreastScreening, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BreastScreening);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BreastScreening);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_BreastScreeningForm(viewModel, viewModel._BreastScreening, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._BreastScreening = new BreastScreening(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BreastScreening, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BreastScreening, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BreastScreening);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BreastScreening);
                    PreScript_BreastScreeningForm(viewModel, viewModel._BreastScreening, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel BreastScreeningForm(BreastScreeningFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return BreastScreeningFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel BreastScreeningFormInternal(BreastScreeningFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("10c5bc95-f9e4-44d0-8da6-4120644257c0");
            objectContext.AddToRawObjectList(viewModel.SubEpisodes);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.SKRSMesleklers);
            objectContext.AddToRawObjectList(viewModel.SKRSOgrenimDurumus);
            objectContext.AddToRawObjectList(viewModel.SKRSMedeniHalis);
            objectContext.AddToRawObjectList(viewModel.SigortaliTurus);
            objectContext.AddToRawObjectList(viewModel.AnamnesisInfos);
            objectContext.AddToRawObjectList(viewModel.SKRSAlkolKullanimis);
            objectContext.AddToRawObjectList(viewModel.SKRSMaddeKullanimis);
            objectContext.AddToRawObjectList(viewModel.SKRSSigaraKullanimis);
            objectContext.AddToRawObjectList(viewModel.SKRSKullanilanAilePlanlamasiAPYontemis);
            objectContext.AddToRawObjectList(viewModel._BreastScreening);
            objectContext.ProcessRawObjects();

            var breastScreening = (BreastScreening)objectContext.GetLoadedObject(viewModel._BreastScreening.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(breastScreening, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BreastScreening, formDefID);
            var transDef = breastScreening.TransDef;
            PostScript_BreastScreeningForm(viewModel, breastScreening, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(breastScreening);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(breastScreening);
            AfterContextSaveScript_BreastScreeningForm(viewModel, breastScreening, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_BreastScreeningForm(BreastScreeningFormViewModel viewModel, BreastScreening breastScreening, TTObjectContext objectContext);
        partial void PostScript_BreastScreeningForm(BreastScreeningFormViewModel viewModel, BreastScreening breastScreening, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_BreastScreeningForm(BreastScreeningFormViewModel viewModel, BreastScreening breastScreening, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(BreastScreeningFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.SubEpisodes = objectContext.LocalQuery<SubEpisode>().ToArray();
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            viewModel.SKRSMesleklers = objectContext.LocalQuery<SKRSMeslekler>().ToArray();
            viewModel.SKRSOgrenimDurumus = objectContext.LocalQuery<SKRSOgrenimDurumu>().ToArray();
            viewModel.SKRSMedeniHalis = objectContext.LocalQuery<SKRSMedeniHali>().ToArray();
            viewModel.SigortaliTurus = objectContext.LocalQuery<SigortaliTuru>().ToArray();
            viewModel.AnamnesisInfos = objectContext.LocalQuery<AnamnesisInfo>().ToArray();
            viewModel.SKRSAlkolKullanimis = objectContext.LocalQuery<SKRSAlkolKullanimi>().ToArray();
            viewModel.SKRSMaddeKullanimis = objectContext.LocalQuery<SKRSMaddeKullanimi>().ToArray();
            viewModel.SKRSSigaraKullanimis = objectContext.LocalQuery<SKRSSigaraKullanimi>().ToArray();
            viewModel.SKRSKullanilanAilePlanlamasiAPYontemis = objectContext.LocalQuery<SKRSKullanilanAilePlanlamasiAPYontemi>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMesleklerList", viewModel.SKRSMesleklers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOgrenimDurumuList", viewModel.SKRSOgrenimDurumus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SigortaliTuruDefinitionList", viewModel.SigortaliTurus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAlkolKullanimiList", viewModel.SKRSAlkolKullanimis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMaddeKullanimiList", viewModel.SKRSMaddeKullanimis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSSigaraKullanimiList", viewModel.SKRSSigaraKullanimis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKullanilanAilePlanlamasiAPYontemiList", viewModel.SKRSKullanilanAilePlanlamasiAPYontemis);
        }
    }
}


namespace Core.Models
{
    public partial class BreastScreeningFormViewModel
    {
        public TTObjectClasses.BreastScreening _BreastScreening
        {
            get;
            set;
        }

        public TTObjectClasses.SubEpisode[] SubEpisodes
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.Patient[] Patients
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMeslekler[] SKRSMesleklers
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSOgrenimDurumu[] SKRSOgrenimDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMedeniHali[] SKRSMedeniHalis
        {
            get;
            set;
        }

        public TTObjectClasses.SigortaliTuru[] SigortaliTurus
        {
            get;
            set;
        }

        public TTObjectClasses.AnamnesisInfo[] AnamnesisInfos
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSAlkolKullanimi[] SKRSAlkolKullanimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMaddeKullanimi[] SKRSMaddeKullanimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSSigaraKullanimi[] SKRSSigaraKullanimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKullanilanAilePlanlamasiAPYontemi[] SKRSKullanilanAilePlanlamasiAPYontemis
        {
            get;
            set;
        }
    }
}
