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
    public partial class MaterialMultiSelectServiceController : Controller
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
        public class MaterialFilter_Input
        {

            public string StoreObjectId
            {
                get;
                set;
            }

            public string SubstanceMaterialId
            {
                get;
                set;
            }
            public bool FilterByStockCard
            {
                get;
                set;
            }
            public bool FilterByStockInheld
            {
                get;
                set;
            }
            public bool FilterByExpendableMaterial
            {
                get;
                set;
            }
        }


        public class MaterialListByStore_Output{
            public BindingList<Material.GetMaterialsForMultiSelectForm_Class> materialList { get; set; }
            public bool storeType { get; set; }
        }

        [HttpPost]
        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Everyone)]
        public MaterialListByStore_Output MaterialListByStore(MaterialFilter_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                try
                {
                    MaterialListByStore_Output returnOutput = new MaterialListByStore_Output();
                    returnOutput.materialList = new BindingList<Material.GetMaterialsForMultiSelectForm_Class>();
                    returnOutput.storeType = true;
                    string filter = " WHERE 1=1 ";

                    if (input.FilterByStockInheld)
                        filter += " AND STOCKS.INHELD > 0 ";

                    if (input.FilterByStockCard)
                        filter += " AND  STOCKCARD IS NOT NULL ";

                    if (input.FilterByExpendableMaterial)
                        filter += " AND ISEXPENDABLEMATERIAL = 1";


                    Guid StoreObjectId = new Guid(input.StoreObjectId);
                    if (StoreObjectId != Guid.Empty)
                        filter += " AND STOCKS.STORE='" + StoreObjectId.ToString() + "'";

                    Guid SubstanceMaterialId = new Guid(input.SubstanceMaterialId);
                    if (SubstanceMaterialId != Guid.Empty)
                        SubstanceMaterialId = new Guid(input.SubstanceMaterialId);
                    else
                    {
                        BindingList<Material.GetMaterialsForMultiSelectForm_Class> listreturn = new BindingList<Material.GetMaterialsForMultiSelectForm_Class>();
                        BindingList<Material.GetMaterialsForMultiSelectForm_Class> list = Material.GetMaterialsForMultiSelectForm(context, filter);
                        foreach (Material.GetMaterialsForMultiSelectForm_Class material in list)
                        {
                            Store store = (Store)context.GetObject(StoreObjectId, "STORE");
                            Material m = (Material)context.GetObject((Guid)material.ObjectID, "MATERIAL");
                            if (store is PharmacyStoreDefinition || store is PharmacySubStoreDefinition)
                            {
                                if (m is DrugDefinition)
                                {
                                    listreturn.Add(material);

                                }
                            }
                            else
                            {
                                listreturn.Add(material);
                                returnOutput.storeType = false;
                            }


                        }
                        returnOutput.materialList = listreturn;
                        return returnOutput;
                    }

                    ActiveIngredientDefinition def = context.GetObject<ActiveIngredientDefinition>(SubstanceMaterialId);
                    BindingList<DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient_Class> DrugActiveIngredient_List = DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient(context, new Guid(input.SubstanceMaterialId));
                    BindingList<Material.GetMaterialsForMultiSelectForm_Class> resultList = new BindingList<Material.GetMaterialsForMultiSelectForm_Class>();
                    foreach (DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient_Class drugActiveIngredient in DrugActiveIngredient_List)
                    {
                        if (drugActiveIngredient.Drugdefinition != null)
                        {
                            string filterExpression = filter + " AND ObjectID ='" + drugActiveIngredient.Drugdefinition.ToString() + "'";
                            BindingList<Material.GetMaterialsForMultiSelectForm_Class> materialList = Material.GetMaterialsForMultiSelectForm(context, filterExpression);
                            foreach (Material.GetMaterialsForMultiSelectForm_Class material in materialList)
                            {
                                resultList.Add(material);
                            }
                        }
                    }
                    returnOutput.materialList = resultList;
                    return returnOutput;
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
    public class MaterialMultiSelectFormViewModel
    {

    }

}
