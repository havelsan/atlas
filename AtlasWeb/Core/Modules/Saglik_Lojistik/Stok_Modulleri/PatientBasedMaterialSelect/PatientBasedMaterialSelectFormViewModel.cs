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
using System.Collections;

namespace Core.Controllers
{


    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class PatientBasedMaterialSelectServiceController : Controller
    {

        [HttpPost]
        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Everyone)]
        public BindingList<DrugActiveIngredient> GetDrugActiveIngredient(string materialObjecId)
        {
            using (var context = new TTObjectContext(false))
            {
                try
                {
                    BindingList<DrugActiveIngredient> list = DrugActiveIngredient.GetAll(context, "");
                    return list;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public class GetEquivalentDrug_Output
        {
            public Guid? ObjectID
            {
                get; set;

            }

            public string Name
            {
                get;
                set;
            }

            public string Barcode
            {
                get; set;
            }

            public string OriginalName
            {
                get; set;

            }

            public string NATOStockNO
            {
                get; set;

            }

            public string Code
            {
                get; set;

            }

            public double Inheld
            {
                get; set;

            }

            public Guid? Store
            {
                get; set;
            }

            public string Distributiontypename
            {
                get; set;
            }
        }
        public class GetEquivalentDrug_Input
        {
            public Guid materialObjectID
            {
                get;
                set;
            }

            public Guid storeObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public BindingList<Material.GetMaterialsForMultiSelectForm_Class> GetEquivalentDrug(GetEquivalentDrug_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Material material = (Material)objectContext.GetObject(input.materialObjectID, typeof(Material));

                string filter = " WHERE STOCKCARD IS NOT NULL";
                filter += " AND STOCKS.STORE='" + input.storeObjectID.ToString() + "'";
                filter += " AND OBJECTID IN (";


                if (material is DrugDefinition)
                {

                    DrugDefinition drugDef = (DrugDefinition)material;
                    IList allEquivalentDrugs = drugDef.GetEquivalentDrugs();
                    foreach (DrugDefinition drug in allEquivalentDrugs)
                    {
                        filter += "'" + drug.ObjectID.ToString() + "',";
                    }
                    filter += "'" + material.ObjectID.ToString() + "'";
                }

                filter += ")";

                BindingList<Material.GetMaterialsForMultiSelectForm_Class> materialList = Material.GetMaterialsForMultiSelectForm(objectContext, filter);
                return materialList;

            }
        }

        public class EquivalentInfo
        {
            public string drugObjectId
            {
                get;
                set;
            }

            public string name
            {
                get;
                set;
            }

            public string barcode
            {
                get;
                set;
            }
        }
        public class MaterialFilterWithPatient_Input
        {

            public string StoreObjectId
            {
                get;
                set;
            }
            public Guid PatientObjectID
            {
                get;
                set;
            }
        }
        [HttpPost]
        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Everyone)]
        public List<Material> MaterialListByStore(MaterialFilterWithPatient_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                try
                {
                    List<Material> materialList = new List<Material>();
                    List<StockTransaction.GetMaterialReservedForPatient_Class> list;
                    string filterExpression = "";
                    if (input.PatientObjectID == null || input.PatientObjectID == Guid.Empty)
                    {
                        filterExpression += "AND PATIENT IS NOT NULL";
                        list = StockTransaction.GetMaterialReservedForPatient(new Guid(input.StoreObjectId), filterExpression, null).ToList();
                    }
                    else
                    {
                        filterExpression += "AND PATIENT = " + "'" + input.PatientObjectID + "'";
                        list = StockTransaction.GetMaterialReservedForPatient(new Guid(input.StoreObjectId), filterExpression, null).ToList();
                    }
                     
                    foreach (var materialInfo in list)
                    {
                        materialList.Add(context.GetObject<Material>(new Guid(materialInfo.Materialobjectid.ToString())));
                    }
                    return materialList;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

    }
}

namespace Core.Models
{
    public class PatientBasedMaterialSelectFormViewModel
    {

    }

}
