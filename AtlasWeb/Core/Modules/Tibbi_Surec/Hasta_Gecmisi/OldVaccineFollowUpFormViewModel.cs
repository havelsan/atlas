//$1A410246
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
    public partial class VaccineFollowUpServiceController
    {
        partial void PreScript_OldVaccineFollowUpForm(OldVaccineFollowUpFormViewModel viewModel, VaccineFollowUp vaccineFollowUp, TTObjectContext objectContext)
        {
            viewModel.VaccineDataList = new List<VaccineData>();
            foreach (var item in viewModel._VaccineFollowUp.VaccineDetails)
            {
                VaccineData vaccine = new VaccineData{ApplicationDate = item.ApplicationDate != null ? item.ApplicationDate.Value.ToString("yyyy/MM/dd HH:mm") : "", AppointmentDate = item.AppointmentDate.Value.ToString("yyyy/MM/dd HH:mm"), Notes = item.Notes != null ? item.Notes : "", PeriodName = item.PeriodName, PeriodRange = item.PeriodRange.ToString(), PeriodUnit = Common.GetDisplayTextOfDataTypeEnum(item.PeriodUnit), VaccineName = item.VaccineName};
                viewModel.VaccineDataList.Add(vaccine);
            }
        }
    }
}

namespace Core.Models
{
    public partial class OldVaccineFollowUpFormViewModel
    {
        public List<VaccineData> VaccineDataList
        {
            get;
            set;
        }
    }

    public class VaccineData
    {
        public string VaccineName
        {
            get;
            set;
        }

        public string PeriodName
        {
            get;
            set;
        }

        public string PeriodRange
        {
            get;
            set;
        }

        public string PeriodUnit
        {
            get;
            set;
        }

        public string AppointmentDate
        {
            get;
            set;
        }

        public string ApplicationDate
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }
    }
}