//$E2CB3308
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
    public partial class TraditionalMedicineServiceController : Controller
    {
        [HttpGet]
        public GetatExaminationFormViewModel GetatExaminationForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return GetatExaminationFormInternal(input);
        }

        [HttpPost]
        public GetatExaminationFormViewModel GetatExaminationFormLoad(FormLoadInput input)
        {
            return GetatExaminationFormInternal(input);
        }

        [HttpGet]
        public GetatExaminationFormViewModel GetatExaminationFormInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("89ddd13c-1d2a-45e3-a82c-bf2911297494");
            var objectDefID = Guid.Parse("d739aae8-dd6d-4b4e-beeb-7f90220c9724");
            var viewModel = new GetatExaminationFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._TraditionalMedicine = objectContext.GetObject(id.Value, objectDefID) as TraditionalMedicine;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._TraditionalMedicine, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TraditionalMedicine, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._TraditionalMedicine);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._TraditionalMedicine);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_GetatExaminationForm(viewModel, viewModel._TraditionalMedicine, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._TraditionalMedicine = new TraditionalMedicine(objectContext);
                    viewModel.TraditionalMedAppRegionGridList = new TTObjectClasses.TraditionalMedAppRegion[] { };
                    viewModel.TraditionalMedAppCasesGridList = new TTObjectClasses.TradititionalMedAppCases[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._TraditionalMedicine, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TraditionalMedicine, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._TraditionalMedicine);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._TraditionalMedicine);
                    PreScript_GetatExaminationForm(viewModel, viewModel._TraditionalMedicine, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel GetatExaminationForm(GetatExaminationFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return GetatExaminationFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel GetatExaminationFormInternal(GetatExaminationFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("89ddd13c-1d2a-45e3-a82c-bf2911297494");
            objectContext.AddToRawObjectList(viewModel.SKRSGETATUygulamaTurus);
            objectContext.AddToRawObjectList(viewModel.SKRSGETATUygulamaBolgesis);
            objectContext.AddToRawObjectList(viewModel.SKRSGETATUygulandigiDurumlars);
            objectContext.AddToRawObjectList(viewModel.SKRSGETATUygulamaBirimis);
            objectContext.AddToRawObjectList(viewModel.SKRSGETATTedaviSonucus);
            objectContext.AddToRawObjectList(viewModel.TraditionalMedAppRegionGridList);
            objectContext.AddToRawObjectList(viewModel.TraditionalMedAppCasesGridList);
            objectContext.AddToRawObjectList(viewModel._TraditionalMedicine);
            objectContext.ProcessRawObjects();

            var traditionalMedicine = (TraditionalMedicine)objectContext.GetLoadedObject(viewModel._TraditionalMedicine.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(traditionalMedicine, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TraditionalMedicine, formDefID);

            if (viewModel.TraditionalMedAppRegionGridList != null)
            {
                foreach (var item in viewModel.TraditionalMedAppRegionGridList)
                {
                    var traditionalMedAppRegionImported = (TraditionalMedAppRegion)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)traditionalMedAppRegionImported).IsDeleted)
                        continue;
                    traditionalMedAppRegionImported.TraditionalMedicine = traditionalMedicine;
                }
            }

            if (viewModel.TraditionalMedAppCasesGridList != null)
            {
                foreach (var item in viewModel.TraditionalMedAppCasesGridList)
                {
                    var traditionalMedAppCasesImported = (TradititionalMedAppCases)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)traditionalMedAppCasesImported).IsDeleted)
                        continue;
                    traditionalMedAppCasesImported.TraditionalMedicine = traditionalMedicine;
                }
            }
            var transDef = traditionalMedicine.TransDef;
            PostScript_GetatExaminationForm(viewModel, traditionalMedicine, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(traditionalMedicine);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(traditionalMedicine);
            AfterContextSaveScript_GetatExaminationForm(viewModel, traditionalMedicine, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_GetatExaminationForm(GetatExaminationFormViewModel viewModel, TraditionalMedicine traditionalMedicine, TTObjectContext objectContext);
        partial void PostScript_GetatExaminationForm(GetatExaminationFormViewModel viewModel, TraditionalMedicine traditionalMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_GetatExaminationForm(GetatExaminationFormViewModel viewModel, TraditionalMedicine traditionalMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(GetatExaminationFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.TraditionalMedAppRegionGridList = viewModel._TraditionalMedicine.TraditionalMedAppRegion.OfType<TraditionalMedAppRegion>().ToArray();
            viewModel.TraditionalMedAppCasesGridList = viewModel._TraditionalMedicine.TraditionalMedAppCases.OfType<TradititionalMedAppCases>().ToArray();
            viewModel.SKRSGETATUygulamaTurus = objectContext.LocalQuery<SKRSGETATUygulamaTuru>().ToArray();
            viewModel.SKRSGETATUygulamaBolgesis = objectContext.LocalQuery<SKRSGETATUygulamaBolgesi>().ToArray();
            viewModel.SKRSGETATUygulandigiDurumlars = objectContext.LocalQuery<SKRSGETATUygulandigiDurumlar>().ToArray();
            viewModel.SKRSGETATUygulamaBirimis = objectContext.LocalQuery<SKRSGETATUygulamaBirimi>().ToArray();
            viewModel.SKRSGETATTedaviSonucus = objectContext.LocalQuery<SKRSGETATTedaviSonucu>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGETATUygulamaTuruList", viewModel.SKRSGETATUygulamaTurus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGETATUygulamaBolgesiList", viewModel.SKRSGETATUygulamaBolgesis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGETATUygulandigiDurumlarList", viewModel.SKRSGETATUygulandigiDurumlars);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGETATUygulamaBirimiList", viewModel.SKRSGETATUygulamaBirimis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSGETATTedaviSonucuList", viewModel.SKRSGETATTedaviSonucus);
        }
    }
}


namespace Core.Models
{
    public partial class GetatExaminationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.TraditionalMedicine _TraditionalMedicine
        {
            get;
            set;
        }

        public TTObjectClasses.TraditionalMedAppRegion[] TraditionalMedAppRegionGridList
        {
            get;
            set;
        }

        public TTObjectClasses.TradititionalMedAppCases[] TraditionalMedAppCasesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGETATUygulamaTuru[] SKRSGETATUygulamaTurus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGETATUygulamaBolgesi[] SKRSGETATUygulamaBolgesis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGETATUygulandigiDurumlar[] SKRSGETATUygulandigiDurumlars
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGETATUygulamaBirimi[] SKRSGETATUygulamaBirimis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSGETATTedaviSonucu[] SKRSGETATTedaviSonucus
        {
            get;
            set;
        }
    }
}
