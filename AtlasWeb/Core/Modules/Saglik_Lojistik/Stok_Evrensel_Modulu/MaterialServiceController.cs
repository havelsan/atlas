//$789B7037
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class MaterialServiceController : Controller
    {
        public class GetVatrateFromMaterialTS_Input
        {
            public TTObjectClasses.Material material
            {
                get;
                set;
            }

            public System.DateTime? date
            {
                get;
                set;
            }
        }

        [HttpPost]
        public long GetVatrateFromMaterialTS(GetVatrateFromMaterialTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.material != null)
                    input.material = (TTObjectClasses.Material)objectContext.AddObject(input.material);
                var ret = Material.GetVatrateFromMaterialTS(input.material, input.date);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetStockCardListReportQuery_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }

            public int STATUS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetStockCardListReportQuery_Class> GetStockCardListReportQuery(GetStockCardListReportQuery_Input input)
        {
            var ret = Material.GetStockCardListReportQuery(input.OBJECTID, input.STATUS);
            return ret;
        }

        [HttpPost]
        public BindingList<Material.GetMaterialDependStockCardReportQuery_Class> GetMaterialDependStockCardReportQuery()
        {
            var ret = Material.GetMaterialDependStockCardReportQuery();
            return ret;
        }

        public class GetTreatmentMaterial_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material> GetTreatmentMaterial(GetTreatmentMaterial_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Material.GetTreatmentMaterial(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMaterialListQuery_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetMaterialListQuery_Class> GetMaterialListQuery(GetMaterialListQuery_Input input)
        {
            var ret = Material.GetMaterialListQuery(input.injectionSQL);
            return ret;
        }

        public class GetDrugAndMagistrals_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetDrugAndMagistrals_Class> GetDrugAndMagistrals(GetDrugAndMagistrals_Input input)
        {
            var ret = Material.GetDrugAndMagistrals(input.injectionSQL);
            return ret;
        }

        public class GetMaterialDetail_Input
        {
            public string MATERIALOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetMaterialDetail_Class> GetMaterialDetail(GetMaterialDetail_Input input)
        {
            var ret = Material.GetMaterialDetail(input.MATERIALOBJECTID);
            return ret;
        }

        public class GetMaterialPricingDetail_Input
        {
            public string MATERIALOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetMaterialPricingDetail_Class> GetMaterialPricingDetail(GetMaterialPricingDetail_Input input)
        {
            var ret = Material.GetMaterialPricingDetail(input.MATERIALOBJECTID);
            return ret;
        }

        [HttpPost]
        public BindingList<Material.GetStockCardListByGroupReportQuery_Class> GetStockCardListByGroupReportQuery()
        {
            var ret = Material.GetStockCardListByGroupReportQuery();
            return ret;
        }

        [HttpPost]
        public BindingList<Material.OLAP_Material_Class> OLAP_Material()
        {
            var ret = Material.OLAP_Material();
            return ret;
        }

        public class GetMaterialInheldReportQuery_Input
        {
            public string STOCKCARDID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetMaterialInheldReportQuery_Class> GetMaterialInheldReportQuery(GetMaterialInheldReportQuery_Input input)
        {
            var ret = Material.GetMaterialInheldReportQuery(input.STOCKCARDID);
            return ret;
        }

        public class GetMaterial_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material> GetMaterial(GetMaterial_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Material.GetMaterial(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMaterials_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetMaterials_Class> GetMaterials(GetMaterials_Input input)
        {
            var ret = Material.GetMaterials(input.injectionSQL);
            return ret;
        }

        [HttpPost]
        public BindingList<Material.GetMaterialWithNoEffectivePrice_Class> GetMaterialWithNoEffectivePrice()
        {
            var ret = Material.GetMaterialWithNoEffectivePrice();
            return ret;
        }

        public class GetMaterialBarcodeLevelDetail_Input
        {
            public string MATERIALOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetMaterialBarcodeLevelDetail_Class> GetMaterialBarcodeLevelDetail(GetMaterialBarcodeLevelDetail_Input input)
        {
            var ret = Material.GetMaterialBarcodeLevelDetail(input.MATERIALOBJECTID);
            return ret;
        }

        [HttpPost]
        public BindingList<Material.GetMaterialNonDependStockCard_Class> GetMaterialNonDependStockCard()
        {
            var ret = Material.GetMaterialNonDependStockCard();
            return ret;
        }

        public class GetStockCardsToActReportQuery_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime FINISHDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetStockCardsToActReportQuery_Class> GetStockCardsToActReportQuery(GetStockCardsToActReportQuery_Input input)
        {
            var ret = Material.GetStockCardsToActReportQuery(input.OBJECTID, input.STARTDATE, input.FINISHDATE);
            return ret;
        }

        [HttpPost]
        public BindingList<Material> GetMaterialWithoutStockCard()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Material.GetMaterialWithoutStockCard(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMaterialsWithPrice_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetMaterialsWithPrice_Class> GetMaterialsWithPrice(GetMaterialsWithPrice_Input input)
        {
            var ret = Material.GetMaterialsWithPrice(input.injectionSQL);
            return ret;
        }

        public class OLAP_Material_WithDate_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.OLAP_Material_WithDate_Class> OLAP_Material_WithDate(OLAP_Material_WithDate_Input input)
        {
            var ret = Material.OLAP_Material_WithDate(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetMaterialWithMultiEffectivePriceByPriceList_Input
        {
            public string PRICELIST
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetMaterialWithMultiEffectivePriceByPriceList_Class> GetMaterialWithMultiEffectivePriceByPriceList(GetMaterialWithMultiEffectivePriceByPriceList_Input input)
        {
            var ret = Material.GetMaterialWithMultiEffectivePriceByPriceList(input.PRICELIST);
            return ret;
        }

        public class GetMaterialByBarcode_Input
        {
            public string BARCODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material> GetMaterialByBarcode(GetMaterialByBarcode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Material.GetMaterialByBarcode(objectContext, input.BARCODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOldMaterialListQuery_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetOldMaterialListQuery_Class> GetOldMaterialListQuery(GetOldMaterialListQuery_Input input)
        {
            var ret = Material.GetOldMaterialListQuery(input.injectionSQL);
            return ret;
        }

        public class ProductMatchMaterialQuery_Input
        {
            public Guid STORE
            {
                get;
                set;
            }

            public int ALL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.ProductMatchMaterialQuery_Class> ProductMatchMaterialQuery(ProductMatchMaterialQuery_Input input)
        {
            var ret = Material.ProductMatchMaterialQuery(input.STORE, input.ALL);
            return ret;
        }

        [HttpPost]
        public BindingList<Material.ProductNotMatchMaterialQuery_Class> ProductNotMatchMaterialQuery()
        {
            var ret = Material.ProductNotMatchMaterialQuery();
            return ret;
        }

        public class GetDrugAndMaterialListQuery_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetDrugAndMaterialListQuery_Class> GetDrugAndMaterialListQuery(GetDrugAndMaterialListQuery_Input input)
        {
            var ret = Material.GetDrugAndMaterialListQuery(input.injectionSQL);
            return ret;
        }

        public class GetPrescriptionMaterialListQuery_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Material.GetPrescriptionMaterialListQuery_Class> GetPrescriptionMaterialListQuery(GetPrescriptionMaterialListQuery_Input input)
        {
            var ret = Material.GetPrescriptionMaterialListQuery(input.injectionSQL);
            return ret;
        }

        public class VEM_STOK_KART_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Material.VEM_STOK_KART_Class> VEM_STOK_KART(VEM_STOK_KART_Input input)
        {
            var ret = Material.VEM_STOK_KART(input.injectionSQL);
            return ret;
        }
    }
}