//$B1402EBB
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
    public partial class InpatientAdmissionServiceController
    {

        partial void PreScript_InPatientAdmissionClinicProcedure(InPatientAdmissionClinicProcedureViewModel viewModel, InpatientAdmission inpatientAdmission, TTObjectContext objectContext)
        {
            this.ArrangeButtons(viewModel);
        }

        partial void AfterContextSaveScript_InPatientAdmissionClinicProcedure(InPatientAdmissionClinicProcedureViewModel viewModel, InpatientAdmission inpatientAdmission, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
           // this.ArrangeButtons(viewModel);
        }
        public void ArrangeButtons(InPatientAdmissionClinicProcedureViewModel viewModel)
        {

            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();
            foreach (var trans in viewModel.OutgoingTransitions)
            {
                if (trans.ToStateDefID == InpatientAdmission.States.Discharged)
                    removedOutgoingTransitions.Add(trans);
              
            }
            foreach (var removedtrans in removedOutgoingTransitions)
            {
                viewModel.OutgoingTransitions.Remove(removedtrans);
            }
        }
    }
}

namespace Core.Models
{
    public partial class InPatientAdmissionClinicProcedureViewModel
    {
    }
}