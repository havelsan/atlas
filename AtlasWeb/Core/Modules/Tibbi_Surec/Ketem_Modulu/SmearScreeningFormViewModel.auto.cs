//$88EE2CDF
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
    public partial class SmearScreeningServiceController : Controller
    {
        [HttpGet]
        public SmearScreeningFormViewModel SmearScreeningForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return SmearScreeningFormLoadInternal(input);
        }

        [HttpPost]
        public SmearScreeningFormViewModel SmearScreeningFormLoad(FormLoadInput input)
        {
            return SmearScreeningFormLoadInternal(input);
        }


        public SmearScreeningFormViewModel SmearScreeningFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("4108b6a5-d47e-4033-ab17-ff1e1faf05b2");
            var objectDefID = Guid.Parse("daa5b1e1-3102-4c33-92c7-e486e996bb54");
            var viewModel = new SmearScreeningFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._SmearScreening = objectContext.GetObject(id.Value, objectDefID) as SmearScreening;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SmearScreening, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SmearScreening, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SmearScreening);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SmearScreening);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_SmearScreeningForm(viewModel, viewModel._SmearScreening, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._SmearScreening = new SmearScreening(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SmearScreening, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SmearScreening, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SmearScreening);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SmearScreening);
                    PreScript_SmearScreeningForm(viewModel, viewModel._SmearScreening, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel SmearScreeningForm(SmearScreeningFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return SmearScreeningFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel SmearScreeningFormInternal(SmearScreeningFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("4108b6a5-d47e-4033-ab17-ff1e1faf05b2");
            objectContext.AddToRawObjectList(viewModel.AnamnesisInfos);
            objectContext.AddToRawObjectList(viewModel.SKRSAlkolKullanimis);
            objectContext.AddToRawObjectList(viewModel.SKRSMaddeKullanimis);
            objectContext.AddToRawObjectList(viewModel.SKRSSigaraKullanimis);
            objectContext.AddToRawObjectList(viewModel.SubEpisodes);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.SKRSMesleklers);
            objectContext.AddToRawObjectList(viewModel.SKRSOgrenimDurumus);
            objectContext.AddToRawObjectList(viewModel.SKRSSigortaliTurus);
            objectContext.AddToRawObjectList(viewModel.SKRSMedeniHalis);
            objectContext.AddToRawObjectList(viewModel.SKRSKullanilanAilePlanlamasiAPYontemis);
            objectContext.AddToRawObjectList(viewModel._SmearScreening);
            objectContext.ProcessRawObjects();

            var smearScreening = (SmearScreening)objectContext.GetLoadedObject(viewModel._SmearScreening.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(smearScreening, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SmearScreening, formDefID);
            var transDef = smearScreening.TransDef;
            PostScript_SmearScreeningForm(viewModel, smearScreening, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(smearScreening);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(smearScreening);
            AfterContextSaveScript_SmearScreeningForm(viewModel, smearScreening, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_SmearScreeningForm(SmearScreeningFormViewModel viewModel, SmearScreening smearScreening, TTObjectContext objectContext);
        partial void PostScript_SmearScreeningForm(SmearScreeningFormViewModel viewModel, SmearScreening smearScreening, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_SmearScreeningForm(SmearScreeningFormViewModel viewModel, SmearScreening smearScreening, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(SmearScreeningFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.AnamnesisInfos = objectContext.LocalQuery<AnamnesisInfo>().ToArray();
            viewModel.SKRSAlkolKullanimis = objectContext.LocalQuery<SKRSAlkolKullanimi>().ToArray();
            viewModel.SKRSMaddeKullanimis = objectContext.LocalQuery<SKRSMaddeKullanimi>().ToArray();
            viewModel.SKRSSigaraKullanimis = objectContext.LocalQuery<SKRSSigaraKullanimi>().ToArray();
            viewModel.SubEpisodes = objectContext.LocalQuery<SubEpisode>().ToArray();
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            viewModel.SKRSMesleklers = objectContext.LocalQuery<SKRSMeslekler>().ToArray();
            viewModel.SKRSOgrenimDurumus = objectContext.LocalQuery<SKRSOgrenimDurumu>().ToArray();
            viewModel.SKRSSigortaliTurus = objectContext.LocalQuery<SKRSSigortaliTuru>().ToArray();
            viewModel.SKRSMedeniHalis = objectContext.LocalQuery<SKRSMedeniHali>().ToArray();
            viewModel.SKRSKullanilanAilePlanlamasiAPYontemis = objectContext.LocalQuery<SKRSKullanilanAilePlanlamasiAPYontemi>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAlkolKullanimiList", viewModel.SKRSAlkolKullanimis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMaddeKullanimiList", viewModel.SKRSMaddeKullanimis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSSigaraKullanimiList", viewModel.SKRSSigaraKullanimis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMesleklerList", viewModel.SKRSMesleklers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOgrenimDurumuList", viewModel.SKRSOgrenimDurumus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSSigortaliTuruList", viewModel.SKRSSigortaliTurus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKullanilanAilePlanlamasiAPYontemiList", viewModel.SKRSKullanilanAilePlanlamasiAPYontemis);
        }
    }
}


namespace Core.Models
{
    public partial class SmearScreeningFormViewModel
    {
        public TTObjectClasses.SmearScreening _SmearScreening
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

        public TTObjectClasses.SKRSSigortaliTuru[] SKRSSigortaliTurus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMedeniHali[] SKRSMedeniHalis
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
