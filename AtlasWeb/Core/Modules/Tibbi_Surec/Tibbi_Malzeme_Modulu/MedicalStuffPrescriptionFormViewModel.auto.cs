//$00F3A498
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
    public partial class MedicalStuffPrescriptionServiceController : Controller
    {
        [HttpGet]
        public MedicalStuffPrescriptionFormViewModel MedicalStuffPrescriptionForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return MedicalStuffPrescriptionFormLoadInternal(input);
        }

        [HttpPost]
        public MedicalStuffPrescriptionFormViewModel MedicalStuffPrescriptionFormLoad(FormLoadInput input)
        {
            return MedicalStuffPrescriptionFormLoadInternal(input);
        }

        private MedicalStuffPrescriptionFormViewModel MedicalStuffPrescriptionFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("b6575da6-09ab-468c-a3ea-55f80d00caa5");
            var objectDefID = Guid.Parse("3edb39a0-54d0-48d9-b85d-6554ce6fc729");
            var viewModel = new MedicalStuffPrescriptionFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MedicalStuffPrescription = objectContext.GetObject(id.Value, objectDefID) as MedicalStuffPrescription;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedicalStuffPrescription, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalStuffPrescription, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MedicalStuffPrescription);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MedicalStuffPrescription);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_MedicalStuffPrescriptionForm(viewModel, viewModel._MedicalStuffPrescription, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MedicalStuffPrescription = new MedicalStuffPrescription(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedicalStuffPrescription, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalStuffPrescription, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MedicalStuffPrescription);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MedicalStuffPrescription);
                    PreScript_MedicalStuffPrescriptionForm(viewModel, viewModel._MedicalStuffPrescription, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel MedicalStuffPrescriptionForm(MedicalStuffPrescriptionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return MedicalStuffPrescriptionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel MedicalStuffPrescriptionFormInternal(MedicalStuffPrescriptionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("b6575da6-09ab-468c-a3ea-55f80d00caa5");
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.MedicalStuffDefinitions);
            objectContext.AddToRawObjectList(viewModel.MedicalStuffGroups);
            objectContext.AddToRawObjectList(viewModel.MedicalStuffPlaceOfUsages);
            objectContext.AddToRawObjectList(viewModel.MedicalStuffGridGridList);
            objectContext.AddToRawObjectList(viewModel._MedicalStuffPrescription);
            objectContext.AddToRawObjectList(viewModel.MedicalStuffUsageTypes);
            objectContext.ProcessRawObjects();
            var medicalStuffPrescription = (MedicalStuffPrescription)objectContext.GetLoadedObject(viewModel._MedicalStuffPrescription.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(medicalStuffPrescription, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalStuffPrescription, formDefID);
            if (viewModel.MedicalStuffGridGridList != null)
            {
                foreach (var item in viewModel.MedicalStuffGridGridList)
                {
                    var medicalStuffImported = (MedicalStuff)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)medicalStuffImported).IsDeleted)
                        continue;
                    medicalStuffImported.MedicalStuffPrescription = medicalStuffPrescription;
                }
            }

            var transDef = medicalStuffPrescription.TransDef;
            PostScript_MedicalStuffPrescriptionForm(viewModel, medicalStuffPrescription, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(medicalStuffPrescription);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(medicalStuffPrescription);
            AfterContextSaveScript_MedicalStuffPrescriptionForm(viewModel, medicalStuffPrescription, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }

        partial void PreScript_MedicalStuffPrescriptionForm(MedicalStuffPrescriptionFormViewModel viewModel, MedicalStuffPrescription medicalStuffPrescription, TTObjectContext objectContext);
        partial void PostScript_MedicalStuffPrescriptionForm(MedicalStuffPrescriptionFormViewModel viewModel, MedicalStuffPrescription medicalStuffPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_MedicalStuffPrescriptionForm(MedicalStuffPrescriptionFormViewModel viewModel, MedicalStuffPrescription medicalStuffPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(MedicalStuffPrescriptionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.MedicalStuffGridGridList = viewModel._MedicalStuffPrescription.MedicalStuff.OfType<MedicalStuff>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.MedicalStuffDefinitions = objectContext.LocalQuery<MedicalStuffDefinition>().ToArray();
            viewModel.MedicalStuffGroups = objectContext.LocalQuery<MedicalStuffGroup>().ToArray();
            viewModel.MedicalStuffPlaceOfUsages = objectContext.LocalQuery<MedicalStuffPlaceOfUsage>().ToArray();
            viewModel.MedicalStuffUsageTypes = objectContext.LocalQuery<MedicalStuffUsageType>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MedicalStuffGroupListDef", viewModel.MedicalStuffGroups);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MedicalStuffPlaceListDef", viewModel.MedicalStuffPlaceOfUsages);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MedicalStuffUsageTypeListDef", viewModel.MedicalStuffUsageTypes);
        }
    }
}


namespace Core.Models
{
    public partial class MedicalStuffPrescriptionFormViewModel : BaseViewModel
    {
        public TTObjectClasses.MedicalStuffPrescription _MedicalStuffPrescription
        {
            get;
            set;
        }

        public TTObjectClasses.MedicalStuff[] MedicalStuffGridGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.MedicalStuffDefinition[] MedicalStuffDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.MedicalStuffGroup[] MedicalStuffGroups
        {
            get;
            set;
        }

        public TTObjectClasses.MedicalStuffPlaceOfUsage[] MedicalStuffPlaceOfUsages
        {
            get;
            set;
        }

        public TTObjectClasses.MedicalStuffUsageType[] MedicalStuffUsageTypes
        {
            get;
            set;
        }
    }
}
