using System;
using System.Collections.Generic;
using TTDataDictionary;

namespace Core.Models
{
    public class LogisticAddAndUpdateViewModel
    {
        public ReturnAccountancy returnAccountancy { get; set; }

        public ReturnSupplier returnSupplier { get; set; }

        public ReturnStockCard returnStockCard { get; set; }

        public object Material { get; set; }

        public List<StockFirstInDetailGridItem> StockFirstInDetailGridItemList { get; set; }

        public List<StockFirstInGridItem> StockFirstInGridItemList { get; set; }
    }


    public class StockCardType
    {
        public string StockCardTypeString { get; set; }
        public DateTime SelectedDateTime { get; set; }
        public string MKYSPassword { get; set; }
    }

    public class ReturnAccountancy
    {
        public List<ReturnAccountancyItem> NewAccountancyList { get; set; }
        public List<ReturnAccountancyItem> UpdateAccountancyList { get; set; }
    }

    public class ReturnAccountancyItem
    {
        public string AccountancyCode { get; set; }
        public string AccountancyNO { get; set; }
        public string AccountancyName { get; set; }
    }

    public class CreateMkysKurumlari_InputDVO
    {
        public List<ReturnAccountancyItem> CreateAccountancyList { get; set; }
    }
    public class CreateMkysKurumlari_OutputDVO
    {
        public string returnMessage { get; set; }
    }
    public class UpdateMkysKurumlari_InputDVO
    {
        public List<ReturnAccountancyItem> UpdateAccountancyList { get; set; }
    }
    public class UpdateMkysKurumlari_OutputDVO
    {
        public string returnMessage { get; set; }
    }




    public class ReturnSupplier
    {
        public List<ReturnSupplierItem> NewSupplierList { get; set; }
        public List<ReturnSupplierItem> UpdateSupplierList { get; set; }
    }

    public class ReturnSupplierItem
    {
        public string GLNNo { get; set; }
        public string Name { get; set; }
        public string TaxNo { get; set; }
        public string TaxOfficeName { get; set; }

    }
    public class CreateMkysFirma_InputDVO
    {
        public List<ReturnSupplierItem> CreateSupplerList { get; set; }
    }
    public class CreateMkysFirma_OutputDVO
    {
        public string returnMessage { get; set; }
    }
    public class UpdateMkysFirma_InputDVO
    {
        public List<ReturnSupplierItem> UpdateSupplierList { get; set; }
    }
    public class UpdateMkysFirma_OutputDVO
    {
        public string returnMessage { get; set; }
    }

    public class ReturnStockCard
    {
        public List<StockCardItem> NewStockCardList { get; set; }
        public List<StockCardItem> UpdateStockCardList { get; set; }
    }
    public class StockCardItem
    {
        public string StockCardName { get; set; }
        public string StockCardCode { get; set; }
        public string StockCardDistribution { get; set; }
        public int MKYSKayitID { get; set; }
        public bool isActive { get; set; }
        public string Desciption { get; set; }
        public Guid? UpdateStockCardObjectID { get; set; }

        public bool Ilac { get; set; }
    }
    public class CreateMkysStockCard_InputDVO
    {
        public List<StockCardItem> CreateStockCardList { get; set; }
    }
    public class CreateMkysStockCard_OutputDVO
    {
        public string returnMessage { get; set; }
    }
    public class UpdateMkysStockCard_InputDVO
    {
        public List<StockCardItem> UpdateStockCardList { get; set; }
    }
    public class UpdateMkysStockCard_OutputDVO
    {
        public string returnMessage { get; set; }
    }


    public class StockFirstInGridItem
    {
        public string stockActionObjID { get; set; }
        public string stockActionNo { get; set; }

    }


    public class StockFirstInDetailGridItem
    {
        public string StockActionDetailObjID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string MaterialName { get; set; }
        public string Amount { get; set; }
        public string OldPrice { get; set; }
        public string NewPrice { get; set; }

        public string MKYS_StokHareketID {get;set;}
        public string Barcode { get; set; }
        public string NatoStockNo { get; set; }


    }

    public class ReturnFirstStockIn_Input
    {
        public string mainStoreDefinition { get; set; }
    }
    public class GetDetailsOfFirstStockIn_Input
    {
        public string stockActionObjID { get; set; }
    }
    public class UpdateUnitPriceForSelectedItems_Input
    {
        public List<StockFirstInDetailGridItem> StockFirstInDetailGridItems { get; set; }
    }


    public class UTSUnlist_Input
    {
        public DateTime UTSUsedStartDate { get; set; }
        public DateTime UTSUsedEndDate { get; set; }
    }
    public class UTSUnusedGridDataModel
    {
        public string StockTransactionID { get; set; }
        public Guid SubActionMaterailObjID { get; set; }
        public string ProtocolNo { get; set; }
        public string MaterialName { get; set; }
        public string Barcode { get; set; }
        public string LotNo { get; set; }
        public string Amount { get; set; }
        public string UTSAlmaBildirimID { get; set; }
        public string StockActionID { get; set; }
        public string MKYSTifNo { get; set; }
        public string UTSAmount { get; set; }
        public string StockActionObjID { get; set; }

        public string UTSErrorMessege { get; set; }
    }

    public class ENabizMaterialInput
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }

    public class ENabizMaterialGrid
    {
        public string ProtocolNO { get; set; }
        public string SendDate { get; set; }
        public string ResponseMessage { get; set; }
        public string MaterialBarcode { get; set; }
        public string MaterialName { get; set; }
        public string ApplicationDate { get; set; }
        public string RequestDate { get; set; }

    }

    public class StockActionInDetailDTO
    {
        public Guid ObjectID { get; set; }
        public string MaterialName { get; set; }
        public string NATOStockNO { get; set; }
        public string Barcode { get; set; }
        public string DistributionTypeName { get; set; }
        public Currency OldAmount { get; set; }
        public Currency Amount { get; set; }
        public BigCurrency OldUnitPriceWithOutVat { get; set; }
        public BigCurrency UnitPriceWithOutVat { get; set; }
        public long OldVatRate { get; set; }
        public long VatRate { get; set; }
        public Currency UnitPriceWithInVat { get; set; }
        public BigCurrency DiscountRate { get; set; }
        public BigCurrency NotDiscountedUnitPrice { get; set; }
        public BigCurrency UnitPrice { get; set; }
        public BigCurrency DiscountAmount { get; set; }
        public BigCurrency Price { get; set; }
    }
}
