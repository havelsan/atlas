//$9FAC866E
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using static Core.Controllers.DrugOrderIntroductionServiceController;
using Microsoft.AspNetCore.Mvc;
using Core.Modules.Saglik_Lojistik.Eczane_Modulleri.Ilac_Direktifi_Giris_Modulu;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class FavoriteDrugServiceController : Controller
    {
        public class GetFavoriteDrugsWithObjectID_Input
        {
            public Guid RESUSER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<FavoriteDrug.GetFavoriteDrugsWithObjectID_Class> GetFavoriteDrugsWithObjectID(GetFavoriteDrugsWithObjectID_Input input)
        {
            var ret = FavoriteDrug.GetFavoriteDrugsWithObjectID(input.RESUSER);
            return ret;
        }

        public class GetFavoriteDrugs_Input
        {
            public Guid RESUSER
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<FavoriteDrug.GetFavoriteDrugs_Class> GetFavoriteDrugs(GetFavoriteDrugs_Input input)
        {
            var ret = FavoriteDrug.GetFavoriteDrugs(input.RESUSER);
            return ret;
        }

        public class GetFavoriteDrugsWithResUser_Input
        {
            public Guid RESUSER
            {
                get;
                set;
            }

            public bool inheldStatus
            {
                get;
                set;
            }
            public List<DrugIngredient> drugIngredients
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Ilac_Direktif_Giris_Yeni, TTRoleNames.Ilac_Direktif_Giris_Tamam)]
        public List<DrugInfo> GetFavoriteDrugsWithResUserOld(GetFavoriteDrugsWithResUser_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DrugInfo> searchDrugs = new List<DrugInfo>();
                List<DrugInfo> searchInheldDrugs = new List<DrugInfo>();
                BindingList<FavoriteDrug.GetFavoriteDrugsWithObjectID_Class> drugs = FavoriteDrug.GetFavoriteDrugsWithObjectID(input.RESUSER);
                foreach (FavoriteDrug.GetFavoriteDrugsWithObjectID_Class drug in drugs)
                {
                    DrugDefinition favoriteDrug = (DrugDefinition)objectContext.GetObject((Guid)drug.DrugDefinition, typeof(DrugDefinition));
                    if (input.drugIngredients != null && input.drugIngredients.Count > 0)
                    {
                        List<Guid> drugIngredients = favoriteDrug.DrugActiveIngredients.Select(t => t.ActiveIngredient.ObjectID).ToList();
                        bool isContainIngredient = false;
                        foreach (DrugIngredient ingredient in input.drugIngredients)
                        {
                            if (drugIngredients.Contains(ingredient.Objectid))
                                isContainIngredient = true;
                        }

                        if (isContainIngredient == false)
                            continue;
                    }

                    DrugInfo drugInfo = new DrugInfo();
                    drugInfo.drugObjectId = favoriteDrug.ObjectID.ToString();
                    drugInfo.name = favoriteDrug.Name;
                    drugInfo.inheldStatus = favoriteDrug.PharmacyInheldStatus;
                    drugInfo.drugShapeTypeEnum = favoriteDrug.DrugShapeType;
                    drugInfo.Color = ColorHelper.GetFontColor(favoriteDrug.Color);
                    drugInfo.SgkReturnPay = DrugDefinition.GetSgkReturnPayText(favoriteDrug.SgkReturnPay);
                    drugInfo.barcode = favoriteDrug.Barcode;

                    if (string.IsNullOrEmpty(favoriteDrug.Description))
                    {
                        if (favoriteDrug.MaterialDescriptionShowType != null)
                        {
                            if(favoriteDrug.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.Order || favoriteDrug.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.All)
                                drugInfo.DrugDescription = favoriteDrug.Description;
                            else
                                drugInfo.DrugDescription = string.Empty;
                        }
                        else
                            drugInfo.DrugDescription = favoriteDrug.Description;
                    }
                    else
                        drugInfo.DrugDescription = string.Empty;


                    drugInfo.isPatientOwnDrug = false;
                    drugInfo.drugType = DrugOrder.GetDrugUsedType(favoriteDrug);
                    if (favoriteDrug.DivisibleDrug.HasValue)
                        drugInfo.isDivisibleDrug = favoriteDrug.DivisibleDrug.Value;
                    else
                        drugInfo.isDivisibleDrug = false;

                    if (favoriteDrug.RouteOfAdmin != null)
                        drugInfo.drugUsageTypeEnum = favoriteDrug.RouteOfAdmin.DrugUsageType;
                    if (favoriteDrug.PrescriptionType != null)
                        drugInfo.prescriptionTypeEnum = favoriteDrug.PrescriptionType;
                    if (favoriteDrug.PatientSafetyFrom.HasValue)
                        drugInfo.PatientSafetyFrom = favoriteDrug.PatientSafetyFrom;
                    else
                        drugInfo.PatientSafetyFrom = false;
                    if (favoriteDrug.InfectionApproval != null)
                        drugInfo.InfectionApproval = favoriteDrug.InfectionApproval.Value;
                    else
                        drugInfo.InfectionApproval = false;
                    drugInfo.ActiveIngeridents = new List<DrugIngredient>();
                    if (favoriteDrug.DrugActiveIngredients.Count > 0)
                    {
                        foreach (DrugActiveIngredient dactiveIngredient in favoriteDrug.DrugActiveIngredients)
                        {
                            DrugIngredient drugIngredient = new DrugIngredient();
                            drugIngredient.Objectid = dactiveIngredient.ActiveIngredient.ObjectID;
                            drugIngredient.Name = dactiveIngredient.ActiveIngredient.Name;
                            drugInfo.ActiveIngeridents.Add(drugIngredient);
                        }
                    }
                    searchDrugs.Add(drugInfo);
                    if (drugInfo.inheldStatus == "Var")
                        searchInheldDrugs.Add(drugInfo);
                }

                if (input.inheldStatus)
                    searchDrugs = searchInheldDrugs;
                objectContext.FullPartialllyLoadedObjects();
                return searchDrugs;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Ilac_Direktif_Giris_Yeni, TTRoleNames.Ilac_Direktif_Giris_Tamam)]
        public List<DrugInfo> GetFavoriteDrugsWithResUser(GetFavoriteDrugsWithResUser_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DrugInfo> searchDrugs = new List<DrugInfo>();
                List<DrugInfo> searchInheldDrugs = new List<DrugInfo>();
                List<DrugInfo> searchContainsIngredient = new List<DrugInfo>();

                var pharmacy = Store.GetPharmacyStore(objectContext);

                var drugs = FavoriteDrug.GetFavoriteDrugDefsWithResUser(input.RESUSER, pharmacy.ObjectID);

                var groupedDrugs = from d in drugs
                                   group d by new { d.DrugDefinition, d.Barcode, d.DrugUsageType, d.Name, d.PrescriptionType, d.PatientSafetyFrom, d.Inheld, d.SgkReturnPay, d.DrugShapeType, d.ShowZeroOnDrugOrder, d.Color, d.Drugingredientobjectid, d.Drugingredientname, d.Drugdescription, d.DivisibleDrug }
                        into dGroup
                                   select new { favoriteDrug = dGroup, toplamMiktar = dGroup.Sum(x => x.Miktar) };
                Dictionary<Guid, DrugInfo> infoDic = new Dictionary<Guid, DrugInfo>();
                foreach (var item in groupedDrugs.OrderByDescending(x => x.toplamMiktar))
                {
                    var favoriteDrug = item.favoriteDrug.Key;
                    if (infoDic.ContainsKey((Guid)favoriteDrug.DrugDefinition))
                    {
                        DrugIngredient drugIngredient = new DrugIngredient();
                        drugIngredient.Name = favoriteDrug.Drugingredientname;
                        drugIngredient.Objectid = (Guid)favoriteDrug.Drugingredientobjectid;
                        infoDic[((Guid)favoriteDrug.DrugDefinition)].ActiveIngeridents.Add(drugIngredient);
                    }
                    else
                    {
                        var inheld = Convert.ToInt32(favoriteDrug.Inheld);
                        if (favoriteDrug.ShowZeroOnDrugOrder != null && favoriteDrug.ShowZeroOnDrugOrder.Value)
                            inheld = 0;

                        DrugInfo drugInfo = new DrugInfo();
                        drugInfo.drugObjectId = favoriteDrug.DrugDefinition.ToString();
                        drugInfo.name = favoriteDrug.Name;

                        drugInfo.SgkReturnPay = DrugDefinition.GetSgkReturnPayText(favoriteDrug.SgkReturnPay);
                        drugInfo.drugShapeTypeEnum = favoriteDrug.DrugShapeType;
                        drugInfo.Color = ColorHelper.GetFontColor(favoriteDrug.Color);
                        drugInfo.DrugDescription = favoriteDrug.Drugdescription;
                        if (favoriteDrug.DivisibleDrug.HasValue)
                            drugInfo.isDivisibleDrug = favoriteDrug.DivisibleDrug.Value;
                        else
                            drugInfo.isDivisibleDrug = false;

                        string showPharmacyStockInHeld = TTObjectClasses.SystemParameter.GetParameterValue("SHOWPHARMACYSTOCKINHELD", "FALSE");
                        if (showPharmacyStockInHeld == "FALSE")
                        {
                            if (inheld > 0)
                                drugInfo.inheldStatus = "Var";
                            else
                                drugInfo.inheldStatus = TTUtils.CultureService.GetText("M24703", "Yok");

                        }
                        else
                        {
                            drugInfo.inheldStatus = inheld.ToString();
                        }


                        drugInfo.barcode = favoriteDrug.Barcode;
                        drugInfo.drugUsageTypeEnum = favoriteDrug.DrugUsageType;
                        if (favoriteDrug.PrescriptionType != null)
                            drugInfo.prescriptionTypeEnum = favoriteDrug.PrescriptionType;
                        if (favoriteDrug.PatientSafetyFrom.HasValue)
                            drugInfo.PatientSafetyFrom = favoriteDrug.PatientSafetyFrom;
                        else
                            drugInfo.PatientSafetyFrom = false;

                        drugInfo.ActiveIngeridents = new List<DrugIngredient>();
                        if (favoriteDrug.Drugingredientobjectid.HasValue)
                        {
                            DrugIngredient drugIngredient = new DrugIngredient();
                            drugIngredient.Objectid = favoriteDrug.Drugingredientobjectid.Value;
                            drugIngredient.Name = favoriteDrug.Drugingredientname;
                            drugInfo.ActiveIngeridents.Add(drugIngredient);
                            infoDic.Add(favoriteDrug.DrugDefinition.Value, drugInfo);
                        }

                        //if (item.DrugSpecifications.Count > 0)
                        //    drugInfo.DrugSpecifications = item.DrugSpecifications.Where(x => x.DrugSpecification.HasValue).Select(x => x.DrugSpecification.Value).ToList();

                        searchDrugs.Add(drugInfo);

                        if (input.drugIngredients != null && input.drugIngredients.Count > 0)
                        {
                            List<Guid> drugIngredients = drugInfo.ActiveIngeridents.Select(t => t.Objectid).ToList();
                            bool isContainIngredient = false;
                            foreach (DrugIngredient ingredient in input.drugIngredients)
                            {
                                if (drugIngredients.Contains(ingredient.Objectid))
                                    isContainIngredient = true;
                            }

                            if (isContainIngredient)
                            {
                                if (input.inheldStatus)
                                {
                                    if (inheld > 0)
                                        searchContainsIngredient.Add(drugInfo);
                                }
                                else
                                {
                                    searchContainsIngredient.Add(drugInfo);
                                }
                            }
                        }

                        if (inheld > 0)
                            searchInheldDrugs.Add(drugInfo);
                    }
                }
                if (input.drugIngredients != null && input.drugIngredients.Count > 0)
                {
                    searchDrugs = searchContainsIngredient;
                }
                else
                {
                    if (input.inheldStatus)
                        searchDrugs = searchInheldDrugs;
                }

                objectContext.FullPartialllyLoadedObjects();
                return searchDrugs;
            }
        }
    }
}