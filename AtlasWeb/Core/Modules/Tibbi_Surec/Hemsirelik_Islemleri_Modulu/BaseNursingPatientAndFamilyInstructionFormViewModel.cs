//$D20ED65D
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
    public partial class BaseNursingPatientAndFamilyInstructionServiceController
    {
        partial void PreScript_BaseNursingPatientAndFamilyInstructionForm(BaseNursingPatientAndFamilyInstructionFormViewModel viewModel, BaseNursingPatientAndFamilyInstruction baseNursingPatientAndFamilyInstruction, TTObjectContext objectContext)
        {
            System.ComponentModel.BindingList<PatientAndFamilyInstructionDefinition> AllPatientFamilyInstDefList = PatientAndFamilyInstructionDefinition.GetAllPatientFamilyInstDefList(objectContext);
            if (((ITTObject)baseNursingPatientAndFamilyInstruction).IsNew)
            {
                List<NursingPatientAndFamilyInstruction> nList = new List<NursingPatientAndFamilyInstruction>();
                foreach (var _patientAndFamilyInstruction in AllPatientFamilyInstDefList)
                {
                    NursingPatientAndFamilyInstruction ss = new NursingPatientAndFamilyInstruction(objectContext);
                    ss.PatientAndFamilyInstruction = _patientAndFamilyInstruction;
                    ss.CompanionGetInstruction = false;
                    ss.PatientGetInstruction = false;
                    nList.Add(ss);
                }

                viewModel.NursingPatientAndFamilyInstructionsGridList = nList.ToArray();
                viewModel.PatientAndFamilyInstructionDefinitions = AllPatientFamilyInstDefList.ToArray();
            }
            else
            {
                if (!viewModel.ReadOnly)
                {
                    using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                    {
                        viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)baseNursingPatientAndFamilyInstruction);
                    }
                }
            }

            if (baseNursingPatientAndFamilyInstruction.ApplicationUser == null)
                baseNursingPatientAndFamilyInstruction.ApplicationUser = Common.CurrentResource;
        }
    }
}

namespace Core.Models
{
    public partial class BaseNursingPatientAndFamilyInstructionFormViewModel
    {
    }
}