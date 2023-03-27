using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.ComponentModel;
using TTObjectClasses;
using Infrastructure.Filters;
using TTInstanceManagement;



namespace Core.Models
{

    public class DrugOutForInputReciepeTypeFormViewModel
    {
        public PrescriptionTypeEnum PrescriptionType
        {
            get; set;
        }
        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }
        public Guid DoctorID
        {
            get;
            set;
        }
        public Guid Store
        {
            get;
            set;
        }
        public List<string> MaterialList
        {
            get;
            set;
        }

        public bool allMaterials
        {
            get; set;
        }

        //public List<string> DrugSpecifications
        //{
        //    get; set;
        //}

        //public bool allDrugSpecification
        //{
        //    get; set;
        //}
        public string SelectedStockOutTypeList

        {
            get;
            set;
        }
    }
    public class DrugOutForRecipeTypeFormViewModel
    {

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }
       
       
        public Guid? BudgetTypeDefinitionObjectID
        {
            get;
            set;
        }
        public List<Store> StoreList
        {
            get;
            set;
        }

        public Guid StoreID
        {
            get;
            set;
        }

        public List<string> MaterialList
        {
            get;
            set;
        }

        public List<string> SelectedMaterialList
        {
            get;
            set;
        }

        public List<Guid> SelectedFilterStores
        {
            get;
            set;
        }

        public List<string> StoresName
        {
            get;
            set;
        }

        public List<Guid> SelectedStockOutTypeList
        {
            get;
            set;
        }

        public bool showUnused
        {
            get;
            set;
        }
        public int filterAmount
        {
            get;
            set;
        }
        public List<Guid> DoctorIDList
        {
            get;
            set;
        }
        public int DayQueryNumber
        {
            get;
            set;
        }

        public List<int> VademecumList
        {
            get;
            set;
        }

        public List<Guid> OutStoreIDList
        {
            get;
            set;
        }
        public Enum MKYS_CikisIslemTuru
        {
            get; set;
        }
    }

    public class DrugOutForRecipeTypeResultModel
    {
        public string Patient { get; set; }
        public string Material { get; set; }
        public double Amount { get; set; }
        public string MKYS_teslimAlanObjectId { get; set; }
    }



  


}
namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DrugOutForRecipeTypeServiceController : Controller
    {

        public List<DrugOutForRecipeTypeResultModel> GetDrugOutForRecipeTypes(DrugOutForInputReciepeTypeFormViewModel viewModel)
        {
            List<DrugOutForRecipeTypeResultModel> output = new List<DrugOutForRecipeTypeResultModel>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                //DateTime startDate = new DateTime(2018, 01, 01);
                // PrescriptionTypeEnum type = PrescriptionTypeEnum.GreenPrescription;
                DrugOutForRecipeTypeFormViewModel view = new DrugOutForRecipeTypeFormViewModel();
                if (viewModel.SelectedStockOutTypeList == "f8155e0a-8527-4886-89b8-3aa7c25bc267")
                {
                    BindingList<KScheduleMaterial.PrescriptionTypeQuery_Class> inTRXs = KScheduleMaterial.PrescriptionTypeQuery(viewModel.PrescriptionType, viewModel.StartDate, viewModel.EndDate
                   , viewModel.DoctorID, viewModel.Store, viewModel.MaterialList, viewModel.allMaterials);





                    foreach (KScheduleMaterial.PrescriptionTypeQuery_Class inTrx in inTRXs)
                    {
                        DrugOutForRecipeTypeResultModel drugOutForRecipe = new DrugOutForRecipeTypeResultModel();
                        TTObjectContext context = new TTObjectContext(true);
                        Patient patient = context.GetObject<Patient>(inTrx.Patient.Value);
                        Material material = context.GetObject<Material>(inTrx.Material.Value);
                        ResUser resUser = context.GetObject<ResUser>(inTrx.MKYS_TeslimAlanObjID.Value);
                        drugOutForRecipe.Patient = patient.FullName;
                        drugOutForRecipe.Material = material.Name;
                        drugOutForRecipe.Amount = Convert.ToDouble(inTrx.Nqlcolumn);
                        drugOutForRecipe.MKYS_teslimAlanObjectId = resUser.Name;
                        output.Add(drugOutForRecipe);
                    }
                }
                else if (viewModel.SelectedStockOutTypeList == "eeb68b1e-fb6e-4348-a2e3-6e0b0f6b1c60")
                {
                    BindingList<DistributionDocumentMaterial.PrescriptionTypeDistQuery_Class> inTRXs = DistributionDocumentMaterial.PrescriptionTypeDistQuery(viewModel.StartDate, viewModel.EndDate, viewModel.PrescriptionType,
                       viewModel.allMaterials, viewModel.MaterialList, viewModel.Store);


                    foreach (DistributionDocumentMaterial.PrescriptionTypeDistQuery_Class inTrx in inTRXs)
                    {
                        DrugOutForRecipeTypeResultModel drugOutForRecipe = new DrugOutForRecipeTypeResultModel();
                        TTObjectContext context = new TTObjectContext(true);
                        Material material = context.GetObject<Material>(inTrx.Material.Value);
                        Store store = context.GetObject<Store>(inTrx.DestinationStore.Value);
                        drugOutForRecipe.Material = material.Name;
                        drugOutForRecipe.Amount = Convert.ToDouble(inTrx.Nqlcolumn);
                        drugOutForRecipe.MKYS_teslimAlanObjectId = store.Name;
                        output.Add(drugOutForRecipe);
                    }

                }
                return output;

            }
        }



        public BindingList<MaterialModel> GetMaterialsBySelectedStores(DrugOutForRecipeTypeFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                string filter = "WHERE STOCKS.STORE =  ";

                if (viewModel.SelectedFilterStores.Count > 0)
                {
                    foreach (var item in viewModel.SelectedFilterStores)
                    {
                        filter += "'" + item.ToString() + "' " + " OR STOCKS.STORE = ";

                    }
                    filter = filter.Remove(filter.LastIndexOf("OR STOCKS.STORE = "));
                }

                else
                {
                    filter += "'" + viewModel.StoreID + "' ";
                }

                BindingList<Material.GetMaterialsForMultiSelectForm_Class> resultList = new BindingList<Material.GetMaterialsForMultiSelectForm_Class>();
                BindingList<Material.GetMaterialsForMultiSelectForm_Class> materialList = Material.GetMaterialsForMultiSelectForm(objectContext, filter);

                BindingList<MaterialModel> result = new BindingList<MaterialModel>();



                foreach (Material.GetMaterialsForMultiSelectForm_Class material in materialList)
                {
                    MaterialModel tmp = new MaterialModel
                    {
                        Name = material.Name,
                        ID = material.ObjectID
                    };

                    result.Add(tmp);
                }

                return result;
            }


        }



        public class DataSources
        {
            public List<ResUser.ClinicDoctorListNQL_Class> DoctorList
            {
                get;
                set;
            }
            
            public List<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> ActiveIngredientList
            {
                get;
                set;
            }
        }

        [HttpPost]
        public List<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> GetActiveIngredientDefinitions()
        {
            return ActiveIngredientDefinition.GetActiveIngredientDefinitions("").ToList();
        }

        [HttpPost]
        public DataSources FillDataSources()
        {
            DataSources dataSources = new DataSources
            {
                DoctorList = ResUser.ClinicDoctorListNQL(null).ToList(),
                ActiveIngredientList = ActiveIngredientDefinition.GetActiveIngredientDefinitions("").ToList()
            };

            return dataSources;
        }
        [HttpPost]
        public List<SubStoreDefinition.GetSubStoreDefinition_Class> FillStoreDataSources()
        {
            string filter = "WHERE THIS.ISACTIVE = 1";
            List<SubStoreDefinition.GetSubStoreDefinition_Class> OutStoreList = SubStoreDefinition.GetSubStoreDefinition(filter).ToList();
            return OutStoreList;
        }

    }

}