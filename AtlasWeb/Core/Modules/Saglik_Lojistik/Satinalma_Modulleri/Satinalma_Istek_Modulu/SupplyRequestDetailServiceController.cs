//$36C80D8A
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
    public partial class SupplyRequestDetailServiceController : Controller
    {
        public class GetSupplyReqDetsByStoreAndDemandType_Input
        {
            public Guid STORE
            {
                get;
                set;
            }

            public SupplyRequestTypeEnum DEMANDTYPE
            {
                get;
                set;
            }
        }

        public class GetSupplyReqDetsByStoreAndDemandType_Output
        {
            public List<SupplyRequestPoolDetail> supplyRequestPoolDetails
            {
                get;
                set;
            }

            public List<SupplyRequestDetail> supplyRequestDetails
            {
                get;
                set;
            }
        }

        public class ExcessStocks_Output
        {
            public List<ExcessStockItem> excessStockList
            {
                get;
                set;
            }

            public List<ExcessStockItemForStore> excessStockStoreList
            {
                get;
                set;
            }
        }

        public class ExcessStockItem
        {
            public string siraNo
            {
                get;
                set;
            }

            public string malzemeKodu
            {
                get;
                set;
            }

            public string malzemeDigerAciklama
            {
                get;
                set;
            }

            public string malzemeAdi
            {
                get;
                set;
            }

            public string adeti
            {
                get;
                set;
            }

            public string vergiliBirimFiyat
            {
                get;
                set;
            }

            public DateTime? tarih
            {
                get;
                set;
            }

            public string ilAdi
            {
                get;
                set;
            }

            public string ilKodu
            {
                get;
                set;
            }

            public string birimAdi
            {
                get;
                set;
            }
        }

        public class ExcessStockItemForStore
        {
            public string depoAdi
            {
                get;
                set;
            }

            public string adeti
            {
                get;
                set;
            }
        }

        public class MKYSExcessStockItem_Input
        {
            public string malzemeAdi
            {
                get;
                set;
            }

            public string malzemeKodu
            {
                get;
                set;
            }

            public string ilAdi
            {
                get;
                set;
            }

            public string birimAdi
            {
                get;
                set;
            }
        }

        public class HospitalExcessStockItem_Input
        {
            public string malzemeObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public ExcessStocks_Output GetHospitalExcessStocks(HospitalExcessStockItem_Input input)
        {
            TTObjectContext context = new TTObjectContext(false);
            var existingStocks = context.QueryObjects("STOCK", "MATERIAL='" + input.malzemeObjectID + "' AND INHELD > 0");
            ExcessStocks_Output output = new Controllers.SupplyRequestDetailServiceController.ExcessStocks_Output();
            if (existingStocks.Count > 0)
            {
                output.excessStockStoreList = new List<ExcessStockItemForStore>();
                foreach (Stock item in existingStocks)
                {
                    ExcessStockItemForStore newExcessItem = new ExcessStockItemForStore();
                    newExcessItem.adeti = item.Inheld.Value.ToString();
                    newExcessItem.depoAdi = String.IsNullOrEmpty(item.Store.Name) ? string.Empty : item.Store.Name;
                    output.excessStockStoreList.Add(newExcessItem);
                }
            }
            else
            {
                throw new Exception(TTUtils.CultureService.GetText("M26408", "Malzemenin Depolarda Mevcudu Bulunamamıştır."));
            }

            return output;
        }

        [HttpPost]
        public ExcessStocks_Output GetMKYSExcessStocks(MKYSExcessStockItem_Input input)
        {
            MkysServis.ihtiyacFazlasiKriterItem kriter = new MkysServis.ihtiyacFazlasiKriterItem();
            if (!String.IsNullOrEmpty(input.ilAdi))
            {
                kriter.ilAdi = input.ilAdi.ToUpper();
            }

            if (!String.IsNullOrEmpty(input.birimAdi))
            {
                kriter.birimAdi = input.birimAdi.ToUpper();
            }

            kriter.malzemeAdi = input.malzemeAdi;
            kriter.malzemeKodu = input.malzemeKodu;
            MkysServis.ihtiyacFazlasiItem[] items = MkysServis.WebMethods.ihtiyacFazlasiGetDataSync(Sites.SiteLocalHost, kriter);
            ExcessStocks_Output output = new Controllers.SupplyRequestDetailServiceController.ExcessStocks_Output();
            output.excessStockList = new List<ExcessStockItem>();
            if (output.excessStockList.Count > 0)
            {
                foreach (MkysServis.ihtiyacFazlasiItem sinif in items)
                {
                    ExcessStockItem newExcessItem = new ExcessStockItem();
                    newExcessItem.siraNo = sinif.siraNo == null ? string.Empty : sinif.siraNo.ToString();
                    newExcessItem.malzemeKodu = String.IsNullOrEmpty(sinif.malzemeKodu) ? string.Empty : sinif.malzemeKodu;
                    newExcessItem.malzemeAdi = String.IsNullOrEmpty(sinif.malzemeAdi) ? string.Empty : sinif.malzemeAdi;
                    newExcessItem.malzemeDigerAciklama = String.IsNullOrEmpty(sinif.malzemeDigerAciklama) ? string.Empty : sinif.malzemeDigerAciklama;
                    newExcessItem.adeti = sinif.adeti.ToString();
                    newExcessItem.vergiliBirimFiyat = sinif.vergiliBirimFiyat.ToString();
                    newExcessItem.tarih = sinif.tarih;
                    newExcessItem.ilAdi = String.IsNullOrEmpty(sinif.ilAdi) ? string.Empty : sinif.ilAdi;
                    newExcessItem.ilKodu = String.IsNullOrEmpty(sinif.ilKodu) ? string.Empty : sinif.ilKodu;
                    newExcessItem.birimAdi = String.IsNullOrEmpty(sinif.birimAdi) ? string.Empty : sinif.birimAdi;
                    output.excessStockList.Add(newExcessItem);
                }
            }
            else
            {
                throw new Exception("Malzemenin MKYS Sisteminde İhtiyaç Fazlası Mevcudu Bulunamamıştır.");
            }

            return output;
        }

        [HttpPost]
        public GetSupplyReqDetsByStoreAndDemandType_Output GetSupplyReqDetsByStoreAndDemandType(GetSupplyReqDetsByStoreAndDemandType_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                GetSupplyReqDetsByStoreAndDemandType_Output output = new Controllers.SupplyRequestDetailServiceController.GetSupplyReqDetsByStoreAndDemandType_Output();
                output.supplyRequestDetails = new List<SupplyRequestDetail>();
                output.supplyRequestPoolDetails = new List<SupplyRequestPoolDetail>();
                Dictionary<Material, SupplyRequestPoolDetail> details = new Dictionary<Material, SupplyRequestPoolDetail>();
                var supplyRequestDetails = SupplyRequestDetail.GetSupplyReqDetsByStoreAndDemandType(objectContext, input.STORE, input.DEMANDTYPE);
                foreach (SupplyRequestDetail det in supplyRequestDetails)
                {
                    if (details.ContainsKey(det.Material))
                    {
                        details[det.Material].TotalRequestAmount += det.RequestAmount;
                        details[det.Material].Amount += det.PurchaseAmount;
                        details[det.Material].PurchaseAmount += det.PurchaseAmount;
                        details[det.Material].SupplyRequestDetails.Add(det);
                    }
                    else
                    {
                        SupplyRequestPoolDetail poolDetail = new SupplyRequestPoolDetail(objectContext);
                        poolDetail.TotalRequestAmount = det.RequestAmount;
                        poolDetail.Amount = det.PurchaseAmount;
                        poolDetail.DistributionType = det.Material.StockCard.DistributionType;
                        poolDetail.PurchaseAmount = det.PurchaseAmount;
                        poolDetail.ExcessAmount = 0;
                        poolDetail.Material = det.Material;
                        poolDetail.SupplyRequestDetails.Add(det);
                        details.Add(det.Material, poolDetail);
                    }

                    output.supplyRequestDetails.Add(det);
                }

                foreach (KeyValuePair<Material, SupplyRequestPoolDetail> poolDetail in details)
                    output.supplyRequestPoolDetails.Add(poolDetail.Value);
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        [HttpPost]
        public StockCardInfo_Output GetStockCardInfoByMaterial(StockCardInfo_Input input)
        {
            TTObjectContext context = new TTObjectContext(false);
            StockCardInfo_Output output = null;
            var existingMaterial = context.QueryObjects("MATERIAL", "OBJECTID='" + input.MaterialID + "'");
            if (existingMaterial.Count > 0)
            {
                output = new StockCardInfo_Output();
                if (!String.IsNullOrEmpty(((Material)existingMaterial[0]).StockCard.NATOStockNO))
                {
                    output.NatoStockNo = ((Material)existingMaterial[0]).StockCard.NATOStockNO;
                }
            }

            return output;
        }

        public class StockCardInfo_Output
        {
            public string NatoStockNo
            {
                get;
                set;
            }
        }

        public class StockCardInfo_Input
        {
            public string MaterialID
            {
                get;
                set;
            }
        }
    }
}