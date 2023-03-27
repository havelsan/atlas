//$0516A8D0
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
    public partial class CigaretteExaminationServiceController : Controller
    {
        [HttpGet]
        public CigaretteAssessmentFormViewModel CigaretteAssessmentForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return CigaretteAssessmentFormLoadInternal(input);
        }

        [HttpPost]
        public CigaretteAssessmentFormViewModel CigaretteAssessmentFormLoad(FormLoadInput input)
        {
            return CigaretteAssessmentFormLoadInternal(input);
        }

        [HttpGet]
        public CigaretteAssessmentFormViewModel CigaretteAssessmentFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("82f52ce8-074b-4946-a218-51330d50d759");
            var objectDefID = Guid.Parse("88544dd9-413f-4312-94cc-c133f960ab5f");
            var viewModel = new CigaretteAssessmentFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._CigaretteExamination = objectContext.GetObject(id.Value, objectDefID) as CigaretteExamination;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CigaretteExamination, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CigaretteExamination, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._CigaretteExamination);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._CigaretteExamination);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_CigaretteAssessmentForm(viewModel, viewModel._CigaretteExamination, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._CigaretteExamination = new CigaretteExamination(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CigaretteExamination, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CigaretteExamination, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._CigaretteExamination);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._CigaretteExamination);
                    PreScript_CigaretteAssessmentForm(viewModel, viewModel._CigaretteExamination, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel CigaretteAssessmentForm(CigaretteAssessmentFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return CigaretteAssessmentFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel CigaretteAssessmentFormInternal(CigaretteAssessmentFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("82f52ce8-074b-4946-a218-51330d50d759");
            objectContext.AddToRawObjectList(viewModel.SubEpisodes);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.SKRSMedeniHalis);
            objectContext.AddToRawObjectList(viewModel.SKRSOgrenimDurumus);
            objectContext.AddToRawObjectList(viewModel.SKRSMesleklers);
            objectContext.AddToRawObjectList(viewModel._CigaretteExamination);
            objectContext.ProcessRawObjects();

            var cigaretteExamination = (CigaretteExamination)objectContext.GetLoadedObject(viewModel._CigaretteExamination.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(cigaretteExamination, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CigaretteExamination, formDefID);
            var transDef = cigaretteExamination.TransDef;
            PostScript_CigaretteAssessmentForm(viewModel, cigaretteExamination, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(cigaretteExamination);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(cigaretteExamination);
            AfterContextSaveScript_CigaretteAssessmentForm(viewModel, cigaretteExamination, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_CigaretteAssessmentForm(CigaretteAssessmentFormViewModel viewModel, CigaretteExamination cigaretteExamination, TTObjectContext objectContext);
        partial void PostScript_CigaretteAssessmentForm(CigaretteAssessmentFormViewModel viewModel, CigaretteExamination cigaretteExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_CigaretteAssessmentForm(CigaretteAssessmentFormViewModel viewModel, CigaretteExamination cigaretteExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(CigaretteAssessmentFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.SubEpisodes = objectContext.LocalQuery<SubEpisode>().ToArray();
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            viewModel.SKRSMedeniHalis = objectContext.LocalQuery<SKRSMedeniHali>().ToArray();
            viewModel.SKRSOgrenimDurumus = objectContext.LocalQuery<SKRSOgrenimDurumu>().ToArray();
            viewModel.SKRSMesleklers = objectContext.LocalQuery<SKRSMeslekler>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMesleklerList", viewModel.SKRSMedeniHalis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOgrenimDurumuList", viewModel.SKRSOgrenimDurumus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMesleklerList", viewModel.SKRSMesleklers);
        }
    }
}


namespace Core.Models
{
    public partial class CigaretteAssessmentFormViewModel
    {
        public TTObjectClasses.CigaretteExamination _CigaretteExamination
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

        public TTObjectClasses.SKRSMedeniHali[] SKRSMedeniHalis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSOgrenimDurumu[] SKRSOgrenimDurumus
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
