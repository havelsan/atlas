using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using System.ComponentModel;
using TTObjectClasses;
using Infrastructure.Filters;
using Core.Security;
using TTInstanceManagement;
using TTUtils;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class FavoriteDrugReportServiceController : Controller
    {

        public class GetFavoriteDrugs_Input
        {
            public FavoriteDrugReportFormViewModel viewModel { get; set; }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<FavoriteDrug_Output> GetFavoriteDrugs(GetFavoriteDrugs_Input input)
        {
            List<FavoriteDrug_Output> output = new List<FavoriteDrug_Output>();
            bool allUser = false;
            if (input.viewModel.SelectedDoctorList.Count == 0)
                allUser = true;
            BindingList<FavoriteDrug.GetFavoriteDrugListRQ_Class> favoriteDrugs = FavoriteDrug.GetFavoriteDrugListRQ(input.viewModel.SelectedDoctorList, input.viewModel.SelectedDrug, allUser);
            foreach (FavoriteDrug.GetFavoriteDrugListRQ_Class favorite in favoriteDrugs)
            {
                FavoriteDrug_Output outputItem = new FavoriteDrug_Output();
                outputItem.DoctorName = favorite.Doctorname;
                outputItem.DrugName = favorite.Drugname;
                outputItem.Amount = favorite.Sayi.Value;
                output.Add(outputItem);
            }
            return output;
        }

        public class DataSources
        {
            public List<ResUser.ClinicDoctorListNQL_Class> DoctorList { get; set; }
        }

        [HttpPost]
        public DataSources FillDataSources()
        {
            DataSources dataSources = new DataSources
            {
                DoctorList = ResUser.ClinicDoctorListNQL(null).ToList(),
            };

            return dataSources;
        }
    }

}

namespace Core.Models
{
    public class FavoriteDrugReportFormViewModel
    {
        public List<Guid> SelectedDoctorList { get; set; }
        public Guid SelectedDrug { get; set; }
    }

    public class FavoriteDrug_Output
    {
        public string DoctorName { get; set; }
        public string DrugName { get; set; }
        public long Amount { get; set; }
    }
}
