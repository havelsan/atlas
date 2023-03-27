//$44C0C6E3
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class InfectionCommitteeServiceController : Controller
    {
        [HttpGet]
        public InfectionCommitteeFormViewModel InfectionCommitteeForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return InfectionCommitteeFormLoadInternal(input);
        }

        [HttpPost]
        public InfectionCommitteeFormViewModel InfectionCommitteeFormLoad(FormLoadInput input)
        {
            return InfectionCommitteeFormLoadInternal(input);
        }

        private InfectionCommitteeFormViewModel InfectionCommitteeFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("7ab98de4-e0bc-409e-a984-e0102cadf9d4");
            var objectDefID = Guid.Parse("d9e9c681-f598-4e39-b706-6c460f608bfa");
            var viewModel = new InfectionCommitteeFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._InfectionCommittee = objectContext.GetObject(id.Value, objectDefID) as InfectionCommittee;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InfectionCommittee, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InfectionCommittee, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InfectionCommittee);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InfectionCommittee);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_InfectionCommitteeForm(viewModel, viewModel._InfectionCommittee, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._InfectionCommittee = new InfectionCommittee(objectContext);
                    var entryStateID = Guid.Parse("0f6725bb-6cd7-41d6-b8d0-cfb2b2761bd8");
                    viewModel._InfectionCommittee.CurrentStateDefID = entryStateID;
                    viewModel.InpatientDrugOrdersGridList = new TTObjectClasses.InfectionCommitteeDetail[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InfectionCommittee, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InfectionCommittee, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._InfectionCommittee);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._InfectionCommittee);
                    PreScript_InfectionCommitteeForm(viewModel, viewModel._InfectionCommittee, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel InfectionCommitteeForm(InfectionCommitteeFormViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("7ab98de4-e0bc-409e-a984-e0102cadf9d4");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.DrugOrders);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.Episodes);
                objectContext.AddToRawObjectList(viewModel.Patients);
                objectContext.AddToRawObjectList(viewModel.ResSections);
                objectContext.AddToRawObjectList(viewModel.InpatientDrugOrdersGridList);
                var entryStateID = Guid.Parse("0f6725bb-6cd7-41d6-b8d0-cfb2b2761bd8");
                objectContext.AddToRawObjectList(viewModel._InfectionCommittee, entryStateID);
                objectContext.ProcessRawObjects(false);
                var infectionCommittee = (InfectionCommittee)objectContext.GetLoadedObject(viewModel._InfectionCommittee.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(infectionCommittee, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InfectionCommittee, formDefID);
                if (viewModel.InpatientDrugOrdersGridList != null)
                {
                    foreach (var item in viewModel.InpatientDrugOrdersGridList)
                    {
                        var infectionCommitteeDetailsImported = (InfectionCommitteeDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)infectionCommitteeDetailsImported).IsDeleted)
                            continue;
                        infectionCommitteeDetailsImported.InfectionCommittee = infectionCommittee;
                    }
                }

                var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(infectionCommittee);
                PostScript_InfectionCommitteeForm(viewModel, infectionCommittee, transDef, objectContext);
                objectContext.AdvanceStateForNewObjects();
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(infectionCommittee);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(infectionCommittee);
                AfterContextSaveScript_InfectionCommitteeForm(viewModel, infectionCommittee, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();
            }

            return retViewModel;
        }

        partial void PreScript_InfectionCommitteeForm(InfectionCommitteeFormViewModel viewModel, InfectionCommittee infectionCommittee, TTObjectContext objectContext);
        partial void PostScript_InfectionCommitteeForm(InfectionCommitteeFormViewModel viewModel, InfectionCommittee infectionCommittee, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_InfectionCommitteeForm(InfectionCommitteeFormViewModel viewModel, InfectionCommittee infectionCommittee, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(InfectionCommitteeFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.InpatientDrugOrdersGridList = viewModel._InfectionCommittee.InfectionCommitteeDetails.OfType<InfectionCommitteeDetail>().ToArray();

            viewModel.DrugOrders = objectContext.LocalQuery<DrugOrder>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            PrepareDTO(viewModel, objectContext);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        }

        void PrepareDTO(InfectionCommitteeFormViewModel viewModel, TTObjectContext objectContext)
        {
            List<InFectionCommitteeDetailDTO> dtoList = new List<InFectionCommitteeDetailDTO>();
            List<InFectionCommitteeDetailDTO> anotherDrugList = new List<InFectionCommitteeDetailDTO>();
            foreach (InfectionCommitteeDetail detail in viewModel._InfectionCommittee.InfectionCommitteeDetails)
            {
                InFectionCommitteeDetailDTO detailDTO = new InFectionCommitteeDetailDTO();
                detailDTO.InfectionCommitteeDetail = detail;
                detailDTO.PlannedStartTime = detail.DrugOrder.PlannedStartTime;
                detailDTO.PlannedEndTime = detail.DrugOrder.DrugOrderDetails[detail.DrugOrder.DrugOrderDetails.Count - 1].OrderPlannedDate;
                detailDTO.DrugName = detail.DrugOrder.Material.Name;
                detailDTO.Frequency = detail.DrugOrder.HospitalTimeSchedule.Name;
                detailDTO.DoseAmount = detail.DrugOrder.DoseAmount.Value;
                detailDTO.Day = detail.DrugOrder.Day.Value;
                detailDTO.UsageNote = detail.DrugOrder.UsageNote;
                detailDTO.IsImmediate = detail.DrugOrder.IsImmediate.Value ? true : false;
                detailDTO.PatientOwnDrug = detail.DrugOrder.PatientOwnDrug.Value ? true : false;
                detailDTO.CaseOfNeed = detail.DrugOrder.CaseOfNeed.Value ? true : false;
                detailDTO.DrugOrderType = detail.DrugOrder.DrugOrderType;
                detailDTO.DoctorName = detail.DrugOrder.RequestedByUser.Person.FullName;
                dtoList.Add(detailDTO);
            }
            IBindingList did = objectContext.QueryObjects("DRUGORDERINTRODUCTIONDET", "DRUGORDER=" + TTConnectionManager.ConnectionManager.GuidToString(viewModel._InfectionCommittee.InfectionCommitteeDetails[0].DrugOrder.ObjectID));
            DrugOrderIntroduction doi = ((DrugOrderIntroductionDet)did[0]).DrugOrderIntroduction;
            foreach (DrugOrderIntroductionDet det in doi.DrugOrderIntroductionDetails)
            {
                if (viewModel.DrugOrders.Contains(det.DrugOrder) == false)
                {
                    InFectionCommitteeDetailDTO detailDTO = new InFectionCommitteeDetailDTO();
                    detailDTO.PlannedStartTime = det.DrugOrder.PlannedStartTime;
                    if (det.DrugOrder.DrugOrderDetails.Count > 0)
                        detailDTO.PlannedEndTime = det.DrugOrder.DrugOrderDetails[det.DrugOrder.DrugOrderDetails.Count - 1].OrderPlannedDate;
                    detailDTO.DrugName = det.DrugOrder.Material.Name;
                    detailDTO.Frequency = det.DrugOrder.HospitalTimeSchedule.Name;
                    detailDTO.DoseAmount = det.DrugOrder.DoseAmount.Value;
                    detailDTO.Day = det.DrugOrder.Day.Value;
                    detailDTO.UsageNote = det.DrugOrder.UsageNote;
                    detailDTO.IsImmediate = det.DrugOrder.IsImmediate.Value ? true : false;
                    detailDTO.PatientOwnDrug = det.DrugOrder.PatientOwnDrug.Value ? true : false;
                    detailDTO.CaseOfNeed = det.DrugOrder.CaseOfNeed.Value ? true : false;
                    detailDTO.DrugOrderType = det.DrugOrder.DrugOrderType;
                    detailDTO.DoctorName = det.DrugOrder.RequestedByUser.Person.FullName;
                    anotherDrugList.Add(detailDTO);
                }
            }

            viewModel.InfectionCommitteeDetailDTOList = dtoList.ToArray();
            viewModel.OrderDTOList = anotherDrugList.ToArray();
        }
    }
}


namespace Core.Models
{
    public partial class InfectionCommitteeFormViewModel : BaseViewModel
    {
        public TTObjectClasses.InfectionCommittee _InfectionCommittee { get; set; }
        public TTObjectClasses.InfectionCommitteeDetail[] InpatientDrugOrdersGridList { get; set; }
        public InFectionCommitteeDetailDTO[] InfectionCommitteeDetailDTOList { get; set; }
        public InFectionCommitteeDetailDTO[] OrderDTOList { get; set; }
        public TTObjectClasses.DrugOrder[] DrugOrders { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
    }
}
