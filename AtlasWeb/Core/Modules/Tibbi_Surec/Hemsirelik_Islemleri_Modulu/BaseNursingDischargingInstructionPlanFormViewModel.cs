//$7E22E7EB
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class BaseNursingDischargingInstructionPlanServiceController
    {
        partial void PreScript_BaseNursingDischargingInstructionPlanForm(BaseNursingDischargingInstructionPlanFormViewModel viewModel, BaseNursingDischargingInstructionPlan baseNursingDischargingInstructionPlan, TTObjectContext objectContext)
        {
            if (((ITTObject)baseNursingDischargingInstructionPlan).IsNew)
            {
                System.ComponentModel.BindingList<DischargingInstructionPlanDefinition> AllNursingDischargInstDefList = DischargingInstructionPlanDefinition.GetAllDischargingInstructionPlanDefinitionList(objectContext);
                List<NursingDischargingInstructionPlan> nList = new List<NursingDischargingInstructionPlan>();
                foreach (var _nursingDischargInstructionPlan in AllNursingDischargInstDefList)
                {
                    NursingDischargingInstructionPlan ss = new NursingDischargingInstructionPlan(objectContext);
                    ss.DischargingInstructionPlan = _nursingDischargInstructionPlan;
                    ss.PatientGetInstruction = false;
                    nList.Add(ss);
                }

                viewModel.NursingDischargingInstructionPlansGridList = nList.ToArray();
                viewModel.DischargingInstructionPlanDefinitions = AllNursingDischargInstDefList.ToArray();
            }
            else
            {
                if (!viewModel.ReadOnly)
                {
                    using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                    {
                        viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)baseNursingDischargingInstructionPlan);
                    }
                }
            }

            if (baseNursingDischargingInstructionPlan.ApplicationUser == null)
                baseNursingDischargingInstructionPlan.ApplicationUser = Common.CurrentResource;

            NursingApplication app = objectContext.GetObject<NursingApplication>(new Guid(viewModel.ActiveIDsModel.EpisodeActionId.ToString()));
            if(app.BaseNursingDataEntries.Where(entry => entry is BaseNursingDischargingInstructionPlan && entry.CurrentStateDefID != BaseNursingDataEntry.States.Cancelled).FirstOrDefault() != null)
            {
                viewModel.ReportCountControl = true;
            }
            else
            {
                viewModel.ReportCountControl = false;
            }
        }
    }
}

namespace Core.Models
{
    public partial class BaseNursingDischargingInstructionPlanFormViewModel
    {
        public bool ReportCountControl { get; set; }
    }
}