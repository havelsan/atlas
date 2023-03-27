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
    public partial class DrugNotExistStockReportServiceController : Controller
    {

        public class GetNotExistDrugs_Input
        {
            public DrugNotExistStockReportFormViewModel viewModel { get; set; }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<GetNotExistDrug_Output> GetNotExistDrugs(GetNotExistDrugs_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                bool allSpec = true;
                List<int> specList = new List<int>();
                if (input.viewModel.SelectedSpecificationList != null && input.viewModel.SelectedSpecificationList.Count > 0)
                {
                    allSpec = false;
                    specList = input.viewModel.SelectedSpecificationList;
                }

                bool allShape = true;
                List<int> shapeList = new List<int>();
                if (input.viewModel.SelectedShapeTypeList != null && input.viewModel.SelectedShapeTypeList.Count > 0)
                {
                    allShape = false;
                    shapeList = input.viewModel.SelectedShapeTypeList;
                }

                bool allIngredient = true;
                List<Guid> ingredientList = new List<Guid>();
                if (input.viewModel.SelectedActiveIngredients != null && input.viewModel.SelectedActiveIngredients.Count > 0)
                {
                    allIngredient = false;
                    ingredientList = input.viewModel.SelectedActiveIngredients;
                }

                bool allDrugs = true;
                List<Guid> drugIDs = new List<Guid>();
                if (input.viewModel.SelectedMaterialList != null && input.viewModel.SelectedMaterialList.Count > 0)
                {
                    allDrugs = false;
                    drugIDs = input.viewModel.SelectedMaterialList;
                }

                List<GetNotExistDrug_Output> output = new List<GetNotExistDrug_Output>();
                BindingList<DrugDefinition.GetDrugNotExistStock_Class> notExistDrugs = DrugDefinition.GetDrugNotExistStock(input.viewModel.SelectedStore, specList, allSpec, allShape, shapeList, allIngredient, ingredientList,allDrugs,drugIDs);
                foreach (DrugDefinition.GetDrugNotExistStock_Class drug in notExistDrugs)
                {
                    DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject(drug.ObjectID.Value, typeof(DrugDefinition));
                    GetNotExistDrug_Output outputItem = new GetNotExistDrug_Output();
                    outputItem.DrugName = drugDefinition.Name;
                    outputItem.Barcode = drugDefinition.Barcode;
                    if (drugDefinition.DrugActiveIngredients.Select(string.Empty).Count > 0)
                    {
                        DrugActiveIngredient activeIngredient = drugDefinition.DrugActiveIngredients.Where(x => x.IsParentIngredient == true).FirstOrDefault();
                        if (activeIngredient != null)
                        {
                            outputItem.IngredientName = activeIngredient.ActiveIngredient.Name;
                        }
                        else
                        {
                            outputItem.IngredientName = drugDefinition.DrugActiveIngredients[0].ActiveIngredient.Name;
                        }

                    }
                    outputItem.Amount = 0;
                    output.Add(outputItem);
                }
                return output;
            }
        }

        public class DataSources
        {
            public List<ResUser.ClinicDoctorListNQL_Class> DoctorList { get; set; }
            public List<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> ActiveIngredientList { get; set; }
        }

        [HttpPost]
        public DataSources FillDataSources()
        {
            DataSources dataSources = new DataSources
            {
                ActiveIngredientList = ActiveIngredientDefinition.GetActiveIngredientDefinitions("").ToList()
            };

            return dataSources;
        }
    }

}

namespace Core.Models
{
    public class DrugNotExistStockReportFormViewModel
    {
        public Guid SelectedStore { get; set; }
        public List<int> SelectedSpecificationList { get; set; }
        public List<int> SelectedShapeTypeList { get; set; }
        public List<Guid> SelectedActiveIngredients { get; set; }
        public List<Guid> SelectedMaterialList { get; set; }
    }

    public class GetNotExistDrug_Output
    {
        public string DrugName { get; set; }
        public string Barcode { get; set; }
        public string IngredientName { get; set; }
        public long Amount { get; set; }
    }
}
