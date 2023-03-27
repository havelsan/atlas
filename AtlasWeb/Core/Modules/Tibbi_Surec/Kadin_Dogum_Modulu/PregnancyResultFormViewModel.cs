//$80BCAB38
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class PregnancyResultServiceController
    {
        partial void PreScript_PregnancyResultForm(PregnancyResultFormViewModel viewModel, PregnancyResult pregnancyResult, TTObjectContext objectContext)
        {
            if (viewModel._PregnancyResult.Pregnancy == null)
            {
                Guid? activePatientObjectID = viewModel.GetSelectedPatientID();
                if (activePatientObjectID.HasValue)
                {
                    Patient patient = objectContext.GetObject<Patient>(activePatientObjectID.Value);
                    List<Pregnancy> pregnancyList = new List<Pregnancy>();
                    pregnancyList.Add(patient.ActivePregnancy);
                    viewModel.Pregnancys = new Pregnancy[pregnancyList.Count()];
                    viewModel.Pregnancys = pregnancyList.ToArray();
                    viewModel._PregnancyResult.Pregnancy = patient.ActivePregnancy;
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class PregnancyResultFormViewModel
    {
    }
}
