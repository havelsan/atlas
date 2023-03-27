//$3BF8B302
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
    public partial class ProstateScreeningServiceController : Controller
    {
        [HttpGet]
        public ProstateScreeningFormViewModel ProstateScreeningForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ProstateScreeningFormLoadInternal(input);
        }

        [HttpPost]
        public ProstateScreeningFormViewModel ProstateScreeningFormLoad(FormLoadInput input)
        {
            return ProstateScreeningFormLoadInternal(input);
        }


        [HttpGet]
        public ProstateScreeningFormViewModel ProstateScreeningFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("f98ef899-be43-42f0-a78f-c822f2051e29");
            var objectDefID = Guid.Parse("6cfaa242-0fc1-4579-95fd-dd65d5c52132");
            var viewModel = new ProstateScreeningFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ProstateScreening = objectContext.GetObject(id.Value, objectDefID) as ProstateScreening;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ProstateScreening, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ProstateScreening, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ProstateScreening);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ProstateScreening);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_ProstateScreeningForm(viewModel, viewModel._ProstateScreening, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ProstateScreening = new ProstateScreening(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ProstateScreening, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ProstateScreening, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ProstateScreening);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ProstateScreening);
                    PreScript_ProstateScreeningForm(viewModel, viewModel._ProstateScreening, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ProstateScreeningForm(ProstateScreeningFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ProstateScreeningFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel ProstateScreeningFormInternal(ProstateScreeningFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("f98ef899-be43-42f0-a78f-c822f2051e29");
            objectContext.AddToRawObjectList(viewModel.AnamnesisInfos);
            objectContext.AddToRawObjectList(viewModel.SKRSAlkolKullanimis);
            objectContext.AddToRawObjectList(viewModel.SKRSSigaraKullanimis);
            objectContext.AddToRawObjectList(viewModel.SubEpisodes);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.SKRSMesleklers);
            objectContext.AddToRawObjectList(viewModel._ProstateScreening);
            objectContext.ProcessRawObjects();

            var prostateScreening = (ProstateScreening)objectContext.GetLoadedObject(viewModel._ProstateScreening.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(prostateScreening, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ProstateScreening, formDefID);
            var transDef = prostateScreening.TransDef;
            PostScript_ProstateScreeningForm(viewModel, prostateScreening, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(prostateScreening);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(prostateScreening);
            AfterContextSaveScript_ProstateScreeningForm(viewModel, prostateScreening, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_ProstateScreeningForm(ProstateScreeningFormViewModel viewModel, ProstateScreening prostateScreening, TTObjectContext objectContext);
        partial void PostScript_ProstateScreeningForm(ProstateScreeningFormViewModel viewModel, ProstateScreening prostateScreening, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ProstateScreeningForm(ProstateScreeningFormViewModel viewModel, ProstateScreening prostateScreening, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(ProstateScreeningFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.AnamnesisInfos = objectContext.LocalQuery<AnamnesisInfo>().ToArray();
            viewModel.SKRSAlkolKullanimis = objectContext.LocalQuery<SKRSAlkolKullanimi>().ToArray();
            viewModel.SKRSSigaraKullanimis = objectContext.LocalQuery<SKRSSigaraKullanimi>().ToArray();
            viewModel.SubEpisodes = objectContext.LocalQuery<SubEpisode>().ToArray();
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            viewModel.SKRSMesleklers = objectContext.LocalQuery<SKRSMeslekler>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAlkolKullanimiList", viewModel.SKRSAlkolKullanimis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSSigaraKullanimiList", viewModel.SKRSSigaraKullanimis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMesleklerList", viewModel.SKRSMesleklers);
        }
    }
}


namespace Core.Models
{
    public partial class ProstateScreeningFormViewModel
    {
        public TTObjectClasses.ProstateScreening _ProstateScreening
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
    }
}
