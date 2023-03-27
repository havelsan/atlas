//$F2171FB8
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class NursingPupilSymptomsServiceController
    {
        partial void PreScript_NursingPupilSymptomsForm(NursingPupilSymptomsFormViewModel viewModel, NursingPupilSymptoms nursingPupilSymptoms, TTObjectContext objectContext)
        {
            if (nursingPupilSymptoms.ApplicationUser == null)
                nursingPupilSymptoms.ApplicationUser = Common.CurrentResource;

            if (!((ITTObject)nursingPupilSymptoms).IsNew && !viewModel.ReadOnly)
            {
                using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                {
                    viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)nursingPupilSymptoms);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class NursingPupilSymptomsFormViewModel
    {
    }
}