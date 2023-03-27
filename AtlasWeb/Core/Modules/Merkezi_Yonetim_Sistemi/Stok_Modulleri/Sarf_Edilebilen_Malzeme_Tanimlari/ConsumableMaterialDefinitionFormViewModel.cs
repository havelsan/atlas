//$7DD0A23D
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using TTDataDictionary;
using System.Collections.Generic;
using System.ComponentModel;
using Core.Controllers;

namespace Core.Controllers
{
    public partial class ConsumableMaterialDefinitionServiceController
    {
        partial void AfterContextSaveScript_ConsumableMaterialDefinitionForm(ConsumableMaterialDefinitionFormViewModel viewModel, ConsumableMaterialDefinition consumableMaterialDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (consumableMaterialDefinition.CreationDate == null || ((DateTime)consumableMaterialDefinition.CreationDate).ToShortDateString() == Common.RecTime().ToShortDateString())
            {
                /*if (!(consumableMaterialDefinition.MaterialPrices.Count > 0))
                    updateGetMaterialPriceByIlacAra(consumableMaterialDefinition, objectContext);
                    Sitem direk gidip yapmamamlý ?? 
                */
            }


            objectContext.Save();
        }

        public void updateGetMaterialPriceByIlacAra(ConsumableMaterialDefinition consumableMaterialDefinition, TTObjectContext context)
        {
            try
            {
                MedulaYardimciIslemler.guncelSutSorguGirisDVO guncelSutSorguGirisDVO = new MedulaYardimciIslemler.guncelSutSorguGirisDVO();
                guncelSutSorguGirisDVO.saglikTesisKodu = 11069941;
                guncelSutSorguGirisDVO.tarih = null;

                MedulaYardimciIslemler.guncelSutSorguCevapDVO guncelSutSorguCevapDVO = MedulaYardimciIslemler.WebMethods.guncelSutKodlariSync(Sites.SiteLocalHost, guncelSutSorguGirisDVO);
                if (guncelSutSorguCevapDVO.sonucKodu == "0000")
                {

                    MedulaYardimciIslemler.sutFiyatDVO[] sutKodlariList = guncelSutSorguCevapDVO.sutKodlari;
                    foreach (MedulaYardimciIslemler.sutFiyatDVO item in sutKodlariList)
                    {
                        if (item.turu == 5)
                        {
                            UpdateMaterialPriceOutput updateMaterial = new UpdateMaterialPriceOutput();
                            updateMaterial.Price = item.fiyat;
                            updateMaterial.Desciption = item.adi;
                            updateMaterial.Code = item.sutKodu;
                            updateMaterial.SutAppandix = item.listeAdi;
                            updateMaterial.ActivationDate = item.gecerlilikTarihi;
                            if(consumableMaterialDefinition.Code == updateMaterial.Code)
                            {
                                List<PricingDetailDVO> pricingDetailDefinitions = new List<PricingDetailDVO>();
                                pricingDetailDefinitions = PricingDetailDefinitionForMaterial(context, updateMaterial);
                                //Yapýlacak!!
                                context.Save();
                                break;
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}

namespace Core.Models
{
    public partial class ConsumableMaterialDefinitionFormViewModel : BaseViewModel
    {
        public MaterialPriceDetail MaterialPriceDetail { get; set; }

        public List<MaterialDocumentation> MaterialDocumentations { get; set; }

        public RevenueSubAccountCodeDefinition RevenueSubAccountCodeDef { get; set; }

        public List<MaterialTreeDefinition> MaterialTreeDefList { get; set; }

    }

    public class MaterialPriceDetail
    {
        public Currency MaterialPrice { get; set; }
    }


    public class MaterialProcedures_Output
    {
        public Guid ObjectID { get; set; }
        public Material_Output Material { get; set; }

        public ProcedureDefinition_Output ProcedureDefinition { get; set; }
    }

    public class Material_Output
    {
        public string Name { get; set; }

        public Guid ObjectID { get; set; }
    }

    public class ProcedureDefinition_Output
    {
        public string Name { get; set; }

        public Guid ObjectID { get; set; }

        public string Code { get; set; }
        public string ID { get; set; }
    }

    public class LoadModelComponentConsumableMaterial
    {
        public ShelfAndRowOnStock shelfAndRowOnStock { get; set; }
        public BindingList<StockLocation.GetStockLocation_Class> getStockLocationClasses { get; set; }

        public BindingList<MaterialPrice.MaterialPriceByMaterialForDefinition_Class> materialPrices { get; set; }

        public GetCriticalStockLevels_Class getCritical { get; set; }

        public List<ProcedureDefinition_Output> materialProcedures { get; set; }
        public List<FirstInStockUnitePrice> firstInStockUnitePrices { get; set; }

        public List<LogDataSource> logDataSources { get; set; }

        public LogisticDashboardViewModel doSearchaccountingTerm { get; set; }

        public List<MaterialType_Output> MaterialTypeListIsGroupList { get; set; }
        public List<MaterialTreeDefinition> MaterialTreeDefinitions { get; set; }

        public List<MaterialSpecialty> MaterialSpecialtyList { get; set; }

        public List<EquivalentConsMaterial> equivalentMaterialList { get; set; }
    }

    public class MaterialType_Output
    {
        public string MaterialTypeCode { get; set; }
        public Guid? MaterialTypeObjectID { get; set; }
        public string MaterialTypeName { get; set; }

    }

    public class FirstInStockUnitePrice
    {
        public Guid stockActionObjectid { get; set; }
        public Guid ObjectDefID { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Tif { get; set; }
        public string UnitePrice { get; set; }
    }

    public class FirstIN_Input
    {
        public Guid MaterialObjectID { get; set; }
        public Guid StoreObjcetID { get; set; }
    }

    public class LoadModelComponentConsumableMaterial_Input
    {
        public Guid MaterialID { get; set; }
        public Guid StoreID { get; set; }
        public int? Shelf { get; set; }
        public int? Row { get; set; }
        public string Equivalent { get; set; }
    }


    public class UpdateMaterialPriceOutput
    {
        public double Price { get; set; }
        public string Desciption { get; set; }
        public string Code { get; set; }
        public string SutAppandix { get; set; }
        public string ActivationDate { get; set; }

    }


    public class MaterialPriceByMedulaSUT_Input
    {
        public UpdateMaterialPriceOutput updateMaterial { get; set; }
        // public ConsumableMaterialDefinition consumableMaterialDefinition { get; set; }
    }

    public class PricingDetailDVO
    {
        public PricingDetailDefinition oldPricingDetailDefinition { get; set; }
        public PricingDetailDefinition newPricingDetailDefinition { get; set; }
    }

    public class pricePatientOutputDTO
    {
        public List<pricePatienList> unUpdatedPatienList { get; set; }
        public List<pricePatienList> UpdatedPatienList { get; set; }
        public string totalUpdatePatientPriceCount { get; set; }
        public DateTime priceEndDate { get; set; }
        public DateTime priceStartDate { get; set; }
    }
    public class RepaitUnUpdate_Intput
    {
        public List<pricePatienList> unUpdatedPatienList { get; set; }
    }
    public class pricePatienList
    {
        public string AccTrxObjID { get; set; }
        public string PatientNameAndSurname { get; set; }
        public string PatientProtocolNo { get; set; }
        public DateTime TrasnactionDate { get; set; }
        public string OldPrice { get; set; }
        public string NewPrice { get; set; }
        public string Desciption { get; set; }
    }

}
