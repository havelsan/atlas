using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Models.DataSourceOptionsParser;
using Core.Services;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using TTConnectionManager;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTObjectClasses.DTOs;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.FsTasinirWebServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class EntryOperationController : Controller
    {
        public List<Guid> InStockActionObjectDefIds = new List<Guid>()
        {
            Guid.Parse("3799bd27-4d89-4cd5-83e3-7aea9801138e"),
            Guid.Parse("1c5c4fc6-72e8-4c58-8d6a-21e17d1eacf3"),
            Guid.Parse("6dfc9fd8-2488-4d88-a109-c205546f8c25")
        };

        [HttpPost]
        public bool CancelStockAction([FromBody]Guid StockActionObjectId)
        {
            using (var context = new TTObjectContext(false))
            {
                var stockAction = context.GetObject<StockAction>(StockActionObjectId);
                if (stockAction != null)
                {
                    if (stockAction is GrantMaterial)
                    {
                        ((GrantMaterial)stockAction).CurrentStateDefID = GrantMaterial.States.Cancelled;
                    }
                    else if (stockAction is ChattelDocumentInputWithAccountancy)
                    {
                        ((ChattelDocumentInputWithAccountancy)stockAction).CurrentStateDefID = ChattelDocumentInputWithAccountancy.States.Cancelled;
                    }
                    else if (stockAction is ChattelDocumentWithPurchase)
                    {
                        ((ChattelDocumentWithPurchase)stockAction).CurrentStateDefID = ChattelDocumentWithPurchase.States.Cancelled;
                    }
                    context.Save();
                    return true;
                }
                return false;
            }
        }

        [HttpGet]
        public StockActionDTO GetWaybillForInputDocument(Guid storeId, string waybillNumber)
        {
            string integrationType = TTObjectClasses.SystemParameter.GetParameterValue("PURCHASESERVICENAME", "");
            if (integrationType == "XXXXXX")
            {
                return ConvertXXXXXXToDTO(storeId, waybillNumber);
            }
            else if (integrationType == "FASTSOFT")
            {
                return ConvertFastSoftToDTO(storeId, waybillNumber);
            }
            return null;
        }

        private StockActionDTO ConvertXXXXXXToDTO(Guid storeId, string waybillNumber)
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                StockActionDTO stockActionDTO = new StockActionDTO();
                string bolumId = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPBOLUMID", "");
                string ehipWsUsername = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI", "");
                string ehipWsPassword = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI", "");
                XXXXXXTasinirMal.IslemSonuc sonuc = XXXXXXTasinirMal.WebMethods.GetEhipWsEntegreKeyByBolumIdSync(Sites.SiteLocalHost, bolumId, ehipWsUsername, ehipWsPassword);
                XXXXXXTasinirMal.MuayeneAramaKriterInfoWS muayeneKR = new XXXXXXTasinirMal.MuayeneAramaKriterInfoWS();

                var storeRecordNo = context.MainStoreDefinition.FirstOrDefault(p => p.ObjectId == storeId).StoreRecordNo;
                muayeneKR.MkysDepoKodu = storeRecordNo.Value.ToString();
                muayeneKR.IrsaliyeNo = waybillNumber;
                XXXXXXTasinirMal.MuayeneKabulInfoWS[] kabulInfoList = XXXXXXTasinirMal.WebMethods.MuayeneKabulGetSync(Sites.SiteLocalHost, sonuc.Mesaj, muayeneKR).ToArray();
                string exp = string.Empty;
                try
                {
                    if (kabulInfoList.Count() == 1)
                    {
                        XXXXXXTasinirMal.MuayeneKabulInfoWS kabulDetay = kabulInfoList[0];
                        stockActionDTO.BuyMethod = (int)(MKYS_EAlimYontemiEnum)Enum.Parse(typeof(MKYS_EAlimYontemiEnum), (Convert.ToInt32(kabulDetay.AlimYontemId) - 1).ToString());
                        switch (kabulDetay.ButceTurId)
                        {
                            case "B": //GENEL BÜTÇE
                                stockActionDTO.BudgetType = new Guid("57c410cc-afea-487a-8327-76e91a696a02");
                                break;
                            case "D": //DÖNER SERMAYE
                                stockActionDTO.BudgetType = new Guid("3511171d-06ae-4434-ad44-3579ee616ecb");
                                break;
                            default:
                                exp += kabulDetay.ButceTurId + " - Bütçe Türü Tanımlı Değildir \n";
                                break;
                        }
                        var supplier = context.Supplier.FirstOrDefault(p => p.TaxNo == kabulDetay.FirmaVergiNo && p.Name.Contains(kabulDetay.FirmaAdi)); //TODO CultureInvariant
                        if (supplier != null)
                        {
                            stockActionDTO.CompanyId = supplier.ObjectId;
                        }
                        else
                        {
                            exp += kabulDetay.FirmaVergiNo + " - " + kabulDetay.FirmaAdi + " Firma Sistemde Tanımlı Değildir. \n";
                        }

                        if (kabulDetay.IhaleTarihi == DateTime.MinValue) //TODO : karşı tarafdan isa geliyor.
                        {
                            stockActionDTO.TenderDate = DateTime.Now;
                        }
                        else
                        {
                            stockActionDTO.TenderDate = kabulDetay.IhaleTarihi;
                        }

                        stockActionDTO.ControlNumber = kabulDetay.MuayeneNo.ToString();
                        stockActionDTO.ControlDate = kabulDetay.MuayeneTarihi;
                        stockActionDTO.TakenByName = kabulDetay.TeslimAlan;
                        stockActionDTO.DelivererName = kabulDetay.TeslimEden;
                        stockActionDTO.BreederDocumentDate = kabulDetay.IrsaliyeTarihi;
                        stockActionDTO.TenderNumber = kabulDetay.IKN;
                        stockActionDTO.PatientFullName = kabulDetay.HastaAdSoyad;
                        List<MaterialDTO> materialDTOList = new List<MaterialDTO>();
                        foreach (XXXXXXTasinirMal.MuayeneKabulKalemInfoWS kalemdetay in kabulDetay.MuayeneKalemleri)
                        {
                            MaterialDTO materialDTO = new MaterialDTO();
                            if (kalemdetay.Barkod != null)
                            {
                                List<AtlasModel.Material> materialList = null;
                                if (!String.IsNullOrEmpty(kalemdetay.Barkod))
                                {
                                    materialList = context.Material.Where(p => p.Barcode == kalemdetay.Barkod && p.MkysMalzemeKodu == kalemdetay.MalzemeKayitId).ToList();
                                }
                                else
                                {
                                    materialList = context.Material.Where(p => p.MkysMalzemeKodu == kalemdetay.MalzemeKayitId).ToList();
                                }
                                if (materialList.Count == 1)
                                {
                                    materialDTO.ObjectID = materialList.FirstOrDefault().ObjectId;
                                    materialDTO.MaterialID = materialList.FirstOrDefault().ObjectId;
                                    materialDTO.Amount = Convert.ToDecimal(kalemdetay.Miktar);
                                    materialDTO.UnitPriceWithOutVat = Convert.ToDecimal(kalemdetay.AlisFiyati);
                                    materialDTO.VatRate = kalemdetay.KdvOran;
                                    materialDTO.UnitPriceWithInVat = Convert.ToDecimal(kalemdetay.KdvTutar);
                                    materialDTO.DiscountRate = kalemdetay.IndirimOrani;
                                    materialDTO.DiscountAmount = Convert.ToDecimal(kalemdetay.IndirimTutar);
                                    materialDTO.Price = Convert.ToDecimal(kalemdetay.Tutar);
                                    materialDTO.ExpirationDate = kalemdetay.SonKullanmaTarihi;
                                    materialDTO.LotNo = kalemdetay.LotNo;
                                    materialDTO.RetrievalYear = Common.RecTime().Year;
                                }
                                else if (materialList.Count > 1)
                                {
                                    exp += kalemdetay.Barkod + "-" + kalemdetay.MalzemeAdi + TTUtils.CultureService.GetText("M25076", "1 den fazla malzeme bulunmuştur");
                                }
                                else
                                {
                                    exp += kalemdetay.Barkod + " - " + kalemdetay.MalzemeAdi + " Malzeme Bilgisi Sistemde Bulunmamaktadır.";
                                }
                            }
                            materialDTOList.Add(materialDTO);
                        }
                        stockActionDTO.MaterialList = materialDTOList.ToArray();
                    }
                    else if (kabulInfoList.Count() > 1)
                    {
                        exp += CultureService.GetText("M25277", "Birden Fazla Kayıt Bulunmuştur.");
                    }
                    else
                    {
                        exp += CultureService.GetText("M26090", "İrsaliyeli Kayıt Bulunamamıştır.");
                    }

                    if (!string.IsNullOrEmpty(exp))
                    {
                        throw new Exception(exp);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                return stockActionDTO;
            }
        }

        private StockActionDTO ConvertFastSoftToDTO(Guid storeId, string waybillNumber)
        {
            StockActionDTO stockActionDTO = new StockActionDTO();
            string birim_ID = TTObjectClasses.SystemParameter.GetParameterValue("FASTSOFTBIRIMID", "");
            FsTasinirWebServis.MuayeneFaturaAramaKriterInfoWS AramaKriter = new FsTasinirWebServis.MuayeneFaturaAramaKriterInfoWS
            {
                FaturaNo = waybillNumber
            };
            Guid siteID = Sites.SiteLocalHost;
            string exp = string.Empty;
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                try
                {
                    MuayeneFaturaInfoWS[] MuayeneFaturaInfo = FsTasinirWebServis.WebMethods.MuayeneFaturaGetSync(siteID, "", "", birim_ID, AramaKriter);
                    if (MuayeneFaturaInfo.Count() == 1)
                    {
                        MuayeneFaturaInfoWS kabulDetay = MuayeneFaturaInfo[0];
                        stockActionDTO.BuyMethod = (int)(MKYS_EAlimYontemiEnum)Enum.Parse(typeof(MKYS_EAlimYontemiEnum), (Convert.ToInt32(kabulDetay.AlimYontemId) - 1).ToString());
                        switch (kabulDetay.ButceTurId)
                        {
                            case "B": //GENEL BÜTÇE
                                stockActionDTO.BudgetType = new Guid("57c410cc-afea-487a-8327-76e91a696a02");
                                break;
                            case "D": //DÖNER SERMAYE
                                stockActionDTO.BudgetType = new Guid("3511171d-06ae-4434-ad44-3579ee616ecb");
                                break;
                            default:
                                exp += kabulDetay.ButceTurId + " - Bütçe Türü Tanımlı Değildir \n";
                                break;
                        }
                        var supplier = context.Supplier.FirstOrDefault(p => p.TaxNo == kabulDetay.FirmaVergiNo && p.Name.Contains(kabulDetay.FirmaAdi)); //TODO CultureInvariant
                        if (supplier != null)
                        {
                            stockActionDTO.CompanyId = supplier.ObjectId;
                        }
                        else
                        {
                            exp += kabulDetay.FirmaVergiNo + " - " + kabulDetay.FirmaAdi + " Firma Sistemde Tanımlı Değildir. \n";
                        }
                        if (kabulDetay.IhaleTarihi == DateTime.MinValue) //TODO : karşı tarafdan isa geliyor.
                        {
                            stockActionDTO.TenderDate = DateTime.Now;
                        }
                        else
                        {
                            stockActionDTO.TenderDate = kabulDetay.IhaleTarihi;
                        }
                        stockActionDTO.ControlNumber = kabulDetay.MuayeneNo.ToString();
                        stockActionDTO.ControlDate = kabulDetay.MuayeneTarihi;
                        stockActionDTO.TakenByName = kabulDetay.TeslimAlan;
                        stockActionDTO.DelivererName = kabulDetay.TeslimEden;
                        stockActionDTO.BreederDocumentDate = kabulDetay.IrsaliyeTarihi;
                        List<MaterialDTO> materialDTOList = new List<MaterialDTO>();
                        if (kabulDetay.MuayeneFaturaKalemList == null)
                        {
                            exp += "Fatura detayları bulunamadı.\n";
                        }
                        else
                        {
                            foreach (MuayeneFaturaKalemInfoWS kalemdetay in kabulDetay.MuayeneFaturaKalemList)
                            {
                                MaterialDTO materialDTO = new MaterialDTO();
                                if (kalemdetay.Barkod != null)
                                {
                                    List<AtlasModel.Material> materialList = null;
                                    if (!String.IsNullOrEmpty(kalemdetay.Barkod))
                                    {
                                        materialList = context.Material.Where(p => p.Barcode == kalemdetay.Barkod && p.MkysMalzemeKodu == kalemdetay.MalzemeKayitId).ToList();
                                    }
                                    else
                                    {
                                        materialList = context.Material.Where(p => p.MkysMalzemeKodu == kalemdetay.MalzemeKayitId).ToList();
                                    }
                                    if (materialList.Count == 1)
                                    {
                                        materialDTO.ObjectID = materialList.FirstOrDefault().ObjectId;
                                        materialDTO.MaterialID = materialList.FirstOrDefault().ObjectId;
                                        materialDTO.Amount = Convert.ToDecimal(kalemdetay.Miktar);
                                        materialDTO.UnitPriceWithOutVat = Convert.ToDecimal(kalemdetay.AlisFiyati);
                                        materialDTO.VatRate = kalemdetay.KdvOrani;
                                        materialDTO.UnitPriceWithInVat = Convert.ToDecimal(kalemdetay.KdvTutar);
                                        materialDTO.DiscountRate = kalemdetay.IndirimOrani;
                                        materialDTO.DiscountAmount = Convert.ToDecimal(kalemdetay.Tutar - kalemdetay.NetTutar);
                                        materialDTO.Price = Convert.ToDecimal(kalemdetay.Tutar);
                                        materialDTO.ExpirationDate = kalemdetay.SonKullanmaTarihi;
                                        materialDTO.RetrievalYear = Common.RecTime().Year;
                                    }
                                    else if (materialList.Count > 1)
                                    {
                                        exp += kalemdetay.Barkod + "-" + kalemdetay.MalzemeAdi + CultureService.GetText("M25076", "1 den fazla malzeme bulunmuştur");
                                    }
                                    else
                                    {
                                        exp += kalemdetay.Barkod + " - " + kalemdetay.MalzemeAdi + " Malzeme Bilgisi Sistemde Bulunmamaktadır.";
                                    }
                                }
                                materialDTOList.Add(materialDTO);

                            }
                            stockActionDTO.MaterialList = materialDTOList.ToArray();
                        }
                    }
                    else if (MuayeneFaturaInfo.Count() > 1)
                    {
                        exp += CultureService.GetText("M25277", "Birden Fazla Kayıt Bulunmuştur.");
                    }
                    else
                    {
                        exp += CultureService.GetText("M26090", "İrsaliyeli Kayıt Bulunamamıştır.");
                    }

                    if (!string.IsNullOrEmpty(exp))
                    {
                        throw new Exception(exp);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }

            return stockActionDTO;
        }

        [HttpPost]
        public List<UTSReceiveNotificationResultDTO> MakeUTSReceiveNotificationForAll(List<UTSReceiveNotificationSendDTO> list)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
                ChattelDocumentDetailWithPurchase chattelDocumentDetailWithPurchase;
                UTSServis.VidAlmaBildirimiIstek almaBildirimiIstek;
                UTSServis.BildirimCevap almaBildirimiCevap = null;
                UTSReceiveNotificationResultDTO res;
                List<UTSReceiveNotificationResultDTO> results = new List<UTSReceiveNotificationResultDTO>();
                foreach (var item in list)
                {
                    chattelDocumentDetailWithPurchase = context.GetObject<ChattelDocumentDetailWithPurchase>(new Guid(item.ObjectId));

                    almaBildirimiIstek = new UTSServis.VidAlmaBildirimiIstek
                    {
                        ADT = item.Amount,
                        VBI = item.IncomingDeliveryNotifID
                    };

                    try
                    {
                        almaBildirimiCevap = UTSServis.WebMethods.VIDAlmaBildirimiSync(new Guid(siteID), almaBildirimiIstek);
                    }
                    catch
                    {
                        // todo
                    }

                    res = new UTSReceiveNotificationResultDTO
                    {
                        ObjectId = item.ObjectId
                    };

                    if (almaBildirimiCevap != null && !string.IsNullOrEmpty(almaBildirimiCevap.SNC))
                    {
                        res.ReceiveNotificationID = almaBildirimiCevap.SNC;
                        chattelDocumentDetailWithPurchase.ReceiveNotificationID = almaBildirimiCevap.SNC;
                        context.Save();
                    }
                    else if (almaBildirimiCevap != null)
                    {
                        res.Message = almaBildirimiCevap.MSJ[0].KOD;
                    }

                    results.Add(res);
                }
                return results;
            }
        }

        [HttpGet]
        public StockActionXMLDTO GetXMLForStockAction(Guid StockActionId)
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                var stockAction = context.StockAction.Find(StockActionId);
                return new StockActionXMLDTO()
                {
                    XMLIn = stockAction.MKYS_GelenVeri,
                    XMLOut = stockAction.MKYS_GidenVeri
                };
            }
        }

        [HttpPost]
        public StockActionDTO CreateTicket(InputFor_ChattelDocumentCreate model)
        {
            string errorMessage = string.Empty;
            using (var context = new TTObjectContext(false))
            {
                ReceivedDataFromMkys item = model.SelectedReceivedDataItems.FirstOrDefault();
                var stockActionDTO = new StockActionDTO();
                stockActionDTO.IsFromMKYS = true;
                IBindingList accountancyList = context.QueryObjects("ACCOUNTANCY", "ACCOUNTANCYCODE = '" + item.gonderenBirimID.ToString() + "'");

                if (accountancyList.Count > 0)
                {
                    stockActionDTO.CompanyFrom = ((Accountancy)accountancyList[0]).Name;
                    stockActionDTO.CompanyFromId = ((Accountancy)accountancyList[0]).ObjectID;
                }
                else
                {
                    Accountancy newAccountancy = new Accountancy(context);
                    newAccountancy.AccountancyCode = item.gonderenBirimID.ToString();
                    newAccountancy.AccountancyNO = item.gonderenBirimID.ToString();
                    newAccountancy.Address = "";
                    newAccountancy.Name = item.gonderenBirimAdi.ToUpper();
                    newAccountancy.QREF = item.gonderenBirimAdi.ToUpper().Substring(0, 5);
                    context.Save();
                    stockActionDTO.CompanyFromId = newAccountancy.ObjectID;
                    stockActionDTO.CompanyFrom = newAccountancy.Name;
                }
                if (model.Store == null)
                {
                    errorMessage += " Giriş Yapılacak Depo Seçilmemiştir. ";
                }

                if (!(model.Store is MainStoreDefinition))
                {
                    errorMessage += " Giriş Yapılacak Depo Ana Depo Olmalıdır. ";
                }
                stockActionDTO.MainStore = model.Store.Name;
                stockActionDTO.MainStoreId = model.Store.ObjectID;
                switch (item.turu)
                {
                    case "CH":
                        stockActionDTO.SupplyType = (int)MKYS_ETedarikTurEnum.stokFazlasiDevir;
                        stockActionDTO.BuyMethod = (int)MKYS_EAlimYontemiEnum.bos;
                        break;
                    case "CR":
                        stockActionDTO.SupplyType = (int)MKYS_ETedarikTurEnum.bagliSaglikTsisisndenDevir;
                        stockActionDTO.BuyMethod = (int)MKYS_EAlimYontemiEnum.bos;
                        break;
                    case "CG":
                        stockActionDTO.SupplyType = (int)MKYS_ETedarikTurEnum.ihtiyacFazlasiDevir;
                        stockActionDTO.BuyMethod = (int)MKYS_EAlimYontemiEnum.bos;
                        break;
                    case "C*":
                        stockActionDTO.SupplyType = (int)MKYS_ETedarikTurEnum.tedarikPaylasimDevirGiris;
                        stockActionDTO.BuyMethod = (int)MKYS_EAlimYontemiEnum.bos;
                        break;
                }
                stockActionDTO.Description = Common.RecTime().ToLongDateString() + " MKYS Kurumlardan Gelen Belgeler  İle Otomatik Oluşturulan Belge.";
                stockActionDTO.BreederDocumentNumber = item.cikisBelgeNo.ToString();
                stockActionDTO.BreederDocumentDate = item.cikisBelgeTarihi;
                //stockActionDTO.ActionRecordNo = item.islemKayitNo;

                if (item.gonderenButceTuruAdi.Contains("DÖNER") == true)
                {
                    stockActionDTO.BudgetType = new Guid("3511171d-06ae-4434-ad44-3579ee616ecb");
                }
                else if (item.gonderenButceTuruAdi.Contains("GENEL") == true)
                {
                    stockActionDTO.BudgetType = new Guid("57c410cc-afea-487a-8327-76e91a696a02");
                }
                else
                {
                    errorMessage += " Bütçe türü için " + item.gonderenButceTuruAdi + " isimli bütçe türü sistemde bulunamamıştır.";
                }
                stockActionDTO.DelivererName = item.gonderenBirimAdi;

                List<MaterialDTO> materialList = new List<MaterialDTO>();
                foreach (MkysServis.devirFisiItem detItem in item.details)
                {
                    MaterialDTO materialDTO = new MaterialDTO();

                    //chatDetIn.StockAction = chatDocument;
                    IBindingList mat = null;

                    if (!String.IsNullOrEmpty(detItem.urunBarkodu))
                    {
                        mat = context.QueryObjects("MATERIAL", "ISACTIVE = 1 AND BARCODE= '" + detItem.urunBarkodu + "' AND MKYSMALZEMEKODU ='" + detItem.malzemeKayitID + "'"); //ISACTIVE ÖZELLİĞİ VERİ BOZUK OLDUGUNDAN KOYULDU KALDIRILACAK.
                        if (mat.Count == 0)
                        {
                            mat = context.QueryObjects("MATERIAL", "ISACTIVE = 1 AND BARCODE= '" + detItem.urunBarkodu + "'");
                        }
                    }
                    else
                        mat = context.QueryObjects("MATERIAL", "ISACTIVE = 1 AND  MKYSMALZEMEKODU ='" + detItem.malzemeKayitID + "'");
                    if (mat.Count == 1)
                    {
                        Material material = (Material)mat[0];
                        if (material is DrugDefinition)
                        {
                            stockActionDTO.MaterialGroup = MKYS_EMalzemeGrupEnum.ilac;
                        }
                        else if (material is ConsumableMaterialDefinition)
                        {
                            stockActionDTO.MaterialGroup = MKYS_EMalzemeGrupEnum.tibbiSarf;
                        }
                        else if (material is FixedAssetDefinition)
                        {
                            stockActionDTO.MaterialGroup = MKYS_EMalzemeGrupEnum.tibbiCihaz;
                        }
                        else
                        {
                            stockActionDTO.MaterialGroup = MKYS_EMalzemeGrupEnum.diger;
                        }

                        if (stockActionDTO.MaterialGroup == MKYS_EMalzemeGrupEnum.ilac || stockActionDTO.MaterialGroup == MKYS_EMalzemeGrupEnum.tibbiSarf)
                        {
                            materialDTO.MaterialID = material.ObjectID;
                            materialDTO.Amount = detItem.miktar;
                            materialDTO.NotDiscountedUnitPrice = detItem.vergiliBirimFiyat;
                            materialDTO.DiscountRate = 0;
                            materialDTO.ProductionDate = detItem.uretimTarihi;
                            materialDTO.ExpirationDate = detItem.sonKullanmaTarihi;
                            materialDTO.RetrievalYear = detItem.edinmeYili;
                            //materialDTO.UnitPriceWithInVat = materialDTO.UnitPriceWithOutVat + materialDTO.UnitPriceWithOutVat * materialDTO.VatRate / 100;
                            //materialDTO.UnitPrice = materialDTO.UnitPriceWithInVat - materialDTO.UnitPriceWithInVat * materialDTO.DiscountRate / 100;
                            //materialDTO.DiscountAmount = materialDTO.Amount * (materialDTO.UnitPriceWithInVat - materialDTO.UnitPrice);
                            //materialDTO.Price = materialDTO.Amount * materialDTO.UnitPrice;
                            materialDTO.LotNo = detItem.lotNo;
                            materialDTO.SerialNo = detItem.seriNo;
                            materialList.Add(materialDTO);
                        }
                        else
                        {
                            errorMessage += stockActionDTO.MaterialGroup.ToString() + " türündeki malzemenin sisteme giriş izni yoktur.";
                        }
                    }
                    else
                    {
                        errorMessage += detItem.malzemeKayitID + " kayıt idli " + detItem.malzemeAdi + " isimli malzeme sistemde bulunamamıştır.";
                    }
                }
                stockActionDTO.MaterialList = materialList.ToArray();
                return stockActionDTO;
            }
        }

        [HttpPost]
        public string SendToMKYS(MKYSRequestDTO model)
        {
            using (var context = new TTObjectContext(false))
            {
                var stockAction = context.GetObject<StockAction>(model.StockActionId);
                return stockAction.SendMKYSForInputDocument(model.MKYSPwd);
            }
        }

        [HttpPost]
        public string SendDeleteToMkys(MKYSRequestDTO model)
        {
            using (var context = new TTObjectContext(false))
            {
                var stockAction = context.GetObject<StockAction>(model.StockActionId);
                var log = stockAction.DocumentRecordLogs.Select(string.Empty).FirstOrDefault();
                try
                {
                    string message = stockAction.SendDeleteMessageToMkys(false, model.ReceiptNumber, model.MKYSPwd);
                    log.MKYSStatus = MKYSControlEnum.CancelledSent;
                    log.ReceiptNumber = null;
                    context.Save();
                    return message;
                }
                catch (Exception e)
                {
                    log.MKYSStatus = MKYSControlEnum.Cancelled;
                    context.Save();
                    return e.Message;
                }
            }
        }

        [HttpPost]
        public List<MaterialDTO> GetMaterials(MaterialPropertyRequestDTO model)
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                var query = from item in context.Material
                            join distributionType in context.DistributionTypeDefinition on item.StockCard.DistributionTypeRef equals distributionType.ObjectId
                            where model.MaterialIds.Contains(item.ObjectId)
                            select new MaterialDTO
                            {
                                Name = item.Name,
                                Barcode = item.Barcode,
                                NATOStockNO = item.StockCard.NATOStockNO,
                                MaterialID = item.ObjectId,
                                ObjectID = item.ObjectId,
                                DistributionTypeName = distributionType.DistributionType
                            };
                var data = query.ToList();

                if (model.Date.HasValue)
                {
                    var materialVatRates = context.MaterialVatRate.Where(p => model.MaterialIds.Contains(p.MaterialRef.Value) && p.StartDate <= model.Date.Value && p.EndDate >= model.Date.Value).FirstOrDefault();
                    data.ForEach(p =>
                    {
                        p.VatRate = materialVatRates?.VatRate ?? 0;
                    });
                }
                return data;
            }
        }

        [HttpGet]
        public decimal? GetVatRate(Guid materialId, DateTime date)
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                var materialVatRates = context.MaterialVatRate.Where(p => p.MaterialRef == materialId && p.StartDate <= date && p.EndDate >= date).FirstOrDefault();
                return materialVatRates?.VatRate;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]

        public LoadResult GetMaterialList([FromBody] DataSourceLoadOptions loadOptions, [FromQuery] MKYS_EMalzemeGrupEnum materialGroup)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                TTQueryDef queryDef;
                if (materialGroup != MKYS_EMalzemeGrupEnum.ilac)
                {
                    queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialListQuery"];
                }
                else
                {
                    queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugListQuery"];
                }

                var paramList = new Dictionary<string, object>();
                var injection = string.Empty;
                paramList = GetFilter(paramList, materialGroup, ref injection);
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }


        private Dictionary<string, object> GetFilter(Dictionary<string, object> filter, MKYS_EMalzemeGrupEnum materialGroup, ref string injection)
        {
            if (materialGroup == MKYS_EMalzemeGrupEnum.tibbiSarf)
            {
                filter.Add("OBJECTDEFID", "58d34696-808e-47de-87e0-1f001d0928a7");
                injection = "MKYSMALZEMEKODU IS NOT NULL";
            }
            if (materialGroup == MKYS_EMalzemeGrupEnum.ilac)
            {
                filter.Add("OBJECTDEFID", "65a2337c-bc3c-4c6b-9575-ad47fa7a9a89");
                injection = "MKYSMALZEMEKODU IS NOT NULL";
            }
            if (materialGroup == MKYS_EMalzemeGrupEnum.tibbiCihaz)
            {
                filter.Add("OBJECTDEFID", "f38f2111-0ee4-4b9f-9707-a63ac02d29f4");
                injection = "MKYSMALZEMEKODU IS NOT NULL";
            }
            return filter;
        }

        [HttpGet]
        public List<BudgetTypeDTO> GetBudgetTypes()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var budgetTypes = objectContext.QueryObjects<BudgetTypeDefinition>().Select(p => new BudgetTypeDTO()
                {
                    Code = p.Code,
                    Name = p.Name,
                    ObjectID = p.ObjectID
                }).ToList();
                return budgetTypes;
            }
        }

        [HttpPost]
        public LoadResult GetSuppliers([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].QueryDefs["SupplierDefFormNQL"];

                var paramList = new Dictionary<string, object>();
                var injection = string.Empty;
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }

        [HttpPost]
        public LoadResult GetAccountancyList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].QueryDefs["GetAccountancyList"];

                var paramList = new Dictionary<string, object>();
                var injection = string.Empty;
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }

        [HttpPost]
        public string SaveOperation([FromBody] StockActionDTO model)
        {
            string result = string.Empty;
            try
            {
                if (model.SupplyType == (int)MKYS_ETedarikTurEnum.satinalma)
                {
                    result = ChattelDocumentWithPurchase.CreateFromDTO(model);
                }
                else if (model.SupplyType == (int)MKYS_ETedarikTurEnum.bagisVeYardim)
                {
                    result = GrantMaterial.CreateFromDTO(model);
                }
                else
                {
                    result = ChattelDocumentInputWithAccountancy.CreateFromDTO(model);
                }
                if (!string.IsNullOrEmpty(result))
                {
                    return result;
                }
                return "İşlem başarıyla kaydedilmiştir.";
            }
            catch (Exception e)
            {
                throw new Exception("İşlem başarıyla kaydedilmiştir.");
            }
        }

        [HttpGet]
        [Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public UserConfigDTO GetUserConfig(int optionType)
        {
            var userID = Common.CurrentUser.TTObjectID.ToString();
            using (var objectContext = new TTObjectContext(false))
            {
                var userConfigurations = objectContext.QueryObjects<UserOption>($"resuser = '{userID}' and optiontype = {optionType}");
                return userConfigurations.Select(p => new UserConfigDTO()
                {
                    Value = p.Value
                }).FirstOrDefault();
            }
        }

        [HttpPost]
        [Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<StockActionDataDTO> GetStockActionInData(StockActionInputDTO input)
        {
            return QueryStockAction(input);
        }

        [HttpGet]
        public StockActionDTO GetStockAction(Guid StockActionObjectDefID, Guid StockActionObjectID)
        {
            return ConvertToStockActionDTO(StockActionObjectDefID, StockActionObjectID);
        }

        private StockActionDTO ConvertToStockActionDTO(Guid StockActionObjectDefID, Guid StockActionObjectID)
        {
            StockActionDTO stockActionDTO = new StockActionDTO();
            using (var objectContext = new TTObjectContext(false))
            {
                StockAction stockAction = (StockAction)objectContext.GetObject(StockActionObjectID, StockActionObjectDefID);
                if (stockAction != null)
                {
                    stockActionDTO.MaterialGroup = stockAction.MKYS_EMalzemeGrup;
                    stockActionDTO.OperationNumber = stockAction.StockActionID.ToString();
                    stockActionDTO.StockActionObjectId = stockAction.ObjectID;
                    stockActionDTO.TicketDate = stockAction.TransactionDate.Value;
                    if (stockAction.DocumentRecordLogs.Any())
                    {
                        stockActionDTO.TicketNumber = stockAction.DocumentRecordLogs.FirstOrDefault().DocumentRecordLogNumber.ToString();
                        stockActionDTO.ReceiptNumber = stockAction.DocumentRecordLogs.FirstOrDefault().ReceiptNumber ?? -1;
                    }
                    stockActionDTO.MainStoreId = stockAction.Store.ObjectID;
                    stockActionDTO.MainStore = stockAction.Store.Name;
                    stockActionDTO.BudgetType = stockAction.BudgetTypeDefinition?.ObjectID;
                    stockActionDTO.SupplyType = (int)stockAction.MKYS_ETedarikTuru;
                    stockActionDTO.BuyMethod = (int)stockAction.MKYS_EAlimYontemi;
                    stockActionDTO.Description = stockAction.Description;
                    var audit = GetAudit(stockAction.ObjectID);
                    if (audit != null)
                    {
                        stockActionDTO.CreateDate = audit.Date;
                        stockActionDTO.CreatedBy = audit.AccountName;
                    }
                    stockActionDTO.Deliverer = stockAction.MKYS_TeslimEdenObjID;
                    stockActionDTO.DelivererName = stockAction.MKYS_TeslimEden;
                    stockActionDTO.TakenBy = stockAction.MKYS_TeslimAlanObjID;
                    stockActionDTO.TakenByName = stockAction.MKYS_TeslimAlan;
                    if (stockAction is ChattelDocumentWithPurchase)
                    {
                        var chattelPurchaseAction = (ChattelDocumentWithPurchase)stockAction;
                        stockActionDTO.PatientOnly = chattelPurchaseAction.InPatientPhysicianApplication != null;
                        stockActionDTO.PatientFullName = chattelPurchaseAction.InPatientPhysicianApplication?.SubEpisode.ProtocolNo + " " + ((ChattelDocumentWithPurchase)stockAction).PatientFullName;
                        stockActionDTO.Company = chattelPurchaseAction.Supplier.Name;
                        stockActionDTO.CompanyId = chattelPurchaseAction.Supplier.ObjectID;
                        stockActionDTO.BreederDocumentNumber = chattelPurchaseAction.Waybill;
                        stockActionDTO.BreederDocumentDate = chattelPurchaseAction.WaybillDate;
                        stockActionDTO.TenderNumber = chattelPurchaseAction.RegistrationAuctionNo;
                        stockActionDTO.TenderDate = chattelPurchaseAction.AuctionDate;
                        stockActionDTO.ControlDate = chattelPurchaseAction.ExaminationReportDate;
                        stockActionDTO.ControlNumber = chattelPurchaseAction.ExaminationReportNo;
                        stockActionDTO.IsFormReadOnly = ChattelDocumentWithPurchase.States.Completed == stockAction.CurrentStateDefID
                            || ChattelDocumentWithPurchase.States.Cancelled == stockAction.CurrentStateDefID;
                    }
                    else if (stockAction is ChattelDocumentInputWithAccountancy)
                    {
                        var chattelInputAction = ((ChattelDocumentInputWithAccountancy)stockAction);
                        stockActionDTO.CompanyFrom = chattelInputAction.Accountancy.Name;
                        stockActionDTO.CompanyFromId = chattelInputAction.Accountancy.ObjectID;
                        stockActionDTO.BreederDocumentNumber = chattelInputAction.Waybill;
                        stockActionDTO.BreederDocumentDate = chattelInputAction.WaybillDate;
                        stockActionDTO.IsFormReadOnly = ChattelDocumentInputWithAccountancy.States.Completed == stockAction.CurrentStateDefID
                           || ChattelDocumentInputWithAccountancy.States.Cancelled == stockAction.CurrentStateDefID;
                    }
                    else if (stockAction is GrantMaterial)
                    {
                        stockActionDTO.CompanyFrom = ((GrantMaterial)stockAction).MaterialGranttedBy;
                        stockActionDTO.IsFormReadOnly = GrantMaterial.States.Completed == stockAction.CurrentStateDefID
                           || GrantMaterial.States.Cancelled == stockAction.CurrentStateDefID;
                    }
                    List<MaterialDTO> materialList = new List<MaterialDTO>();
                    if (stockAction.IsPTSAction == true)
                    {
                        //TODO
                    }
                    else
                    {
                        foreach (StockActionDetail stockActionDetail in stockAction.StockActionDetails.Select(string.Empty))
                        {
                            MaterialDTO dto = new MaterialDTO();
                            dto.MaterialID = stockActionDetail.Material.ObjectID;
                            dto.Name = stockActionDetail.Material.Name;
                            dto.NATOStockNO = stockActionDetail.Material.StockCard.NATOStockNO;
                            dto.Barcode = stockActionDetail.Material.Barcode;
                            dto.DistributionTypeName = stockActionDetail.Material.StockCard.DistributionType.DistributionType;
                            dto.Amount = Convert.ToDecimal(stockActionDetail.Amount);
                            if (stockActionDetail is ChattelDocumentDetailWithPurchase)
                            {
                                dto.UnitPriceWithOutVat = Convert.ToDecimal(((ChattelDocumentDetailWithPurchase)stockActionDetail).UnitPriceWithOutVat);
                                dto.ReceiveNotificationID = ((ChattelDocumentDetailWithPurchase)stockActionDetail).ReceiveNotificationID;
                            }
                            else
                            {
                                dto.UnitPriceWithOutVat = Convert.ToDecimal(((StockActionDetailIn)stockActionDetail).NotDiscountedUnitPrice);
                            }
                            dto.VatRate = Convert.ToDecimal(((StockActionDetailIn)stockActionDetail).VatRate);
                            dto.UnitPriceWithInVat = dto.UnitPriceWithOutVat + dto.UnitPriceWithOutVat * dto.VatRate / 100;
                            dto.DiscountRate = Convert.ToDecimal(((StockActionDetailIn)stockActionDetail).DiscountRate);
                            dto.UnitPrice = dto.UnitPriceWithInVat - dto.UnitPriceWithInVat * dto.DiscountRate / 100;
                            dto.DiscountAmount = (dto.Amount ?? 0) * (dto.UnitPriceWithInVat - dto.UnitPrice);
                            dto.Price = (dto.Amount ?? 0) * dto.UnitPrice;
                            dto.LotNo = ((StockActionDetailIn)stockActionDetail).LotNo;
                            dto.SerialNo = ((StockActionDetailIn)stockActionDetail).SerialNo;
                            dto.RetrievalYear = ((StockActionDetailIn)stockActionDetail).RetrievalYear;
                            dto.ProductionDate = ((StockActionDetailIn)stockActionDetail).ProductionDate;
                            materialList.Add(dto);
                        }
                    }
                    stockActionDTO.RecordType = stockActionDTO.IsFormReadOnly ? 1 : 2;

                    stockActionDTO.MaterialList = materialList.ToArray();
                }
            }
            return stockActionDTO;
        }

        private LogDataSource GetAudit(Guid auditObjectID)
        {
            DataTable _allDataDataTable = TTAuditRecord.GetObjectAuditRecords(auditObjectID, null, null, false);
            if (_allDataDataTable.Rows.Count > 0)
            {
                TTAuditRecord audit = new TTAuditRecord(_allDataDataTable.Rows[0]);
                return LogDataSource.CreateFromAudit(audit);
            }
            return null;
        }

        private List<StockActionDataDTO> QueryStockAction(StockActionInputDTO inputdvo)
        {
            List<StockActionDataDTO> result = new List<StockActionDataDTO>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                inputdvo.StartDate = Convert.ToDateTime(inputdvo.StartDate.ToShortDateString() + " 00:00:00");
                inputdvo.EndDate = Convert.ToDateTime(inputdvo.EndDate.ToShortDateString() + " 23:59:59");

                List<StockActionWorkListItemModel> stockactionlist = new List<StockActionWorkListItemModel>();
                List<StockAction> lookupList = new List<StockAction>();

                string filterExpresion = "";
                filterExpresion += " AND " + Common.CreateFilterExpressionOfGuidList(filterExpresion, "OBJECTDEFID", InStockActionObjectDefIds);
                if (inputdvo.BudgetType.HasValue)
                {
                    filterExpresion += $" AND BudgetTypeDefinition =  {ConnectionManager.GuidToString(inputdvo.BudgetType.Value)}";
                }
                //if (string.IsNullOrEmpty(inputdvo.StateType) == false)
                //    filiterExpresion = " AND CURRENTSTATE IS " + inputdvo.StateType;

                if (!string.IsNullOrEmpty(inputdvo.OperationNumber))
                {
                    lookupList = StockAction.StockActionWorkListNQLNoDate(objectContext, "AND STOCKACTIONID in (" + inputdvo.OperationNumber + ")" + filterExpresion).ToList();
                }
                else if (!string.IsNullOrEmpty(inputdvo.TIFNumber))
                {
                    IBindingList documentRecordLogs = objectContext.QueryObjects("DOCUMENTRECORDLOG", "DOCUMENTRECORDLOGNUMBER ='" + inputdvo.TIFNumber + "'" + filterExpresion);
                    foreach (DocumentRecordLog d in documentRecordLogs)
                    {
                        lookupList.Add(d.StockAction);
                    }
                }
                else if (!string.IsNullOrEmpty(inputdvo.ReceiptNumber))
                {
                    IBindingList documentRecordLogs = objectContext.QueryObjects("DOCUMENTRECORDLOG", "RECEIPTNUMBER ='" + inputdvo.ReceiptNumber + "'" + filterExpresion);
                    foreach (DocumentRecordLog d in documentRecordLogs)
                    {
                        lookupList.Add(d.StockAction);
                    }
                }
                else
                {
                    lookupList = StockAction.StockActionWorkListNQL(objectContext, inputdvo.StartDate, inputdvo.EndDate, inputdvo.StoreId, filterExpresion).ToList();
                }

                foreach (StockAction stockAction in lookupList.Where(p => p.CurrentStateDefID != null))
                {
                    bool flag = true;
                    if (TTUser.CurrentUser.HasRight(stockAction.CurrentStateDef.FormDef, stockAction, 1003))
                    {
                        StockActionDataDTO dto = new StockActionDataDTO();

                        dto.StockActionObjectID = stockAction.ObjectID;
                        dto.StockActionID = stockAction.StockActionID.ToString();
                        if (stockAction.Store != null)
                            dto.Store = stockAction.Store.Name;
                        if (stockAction.DestinationStore != null)
                            dto.DestinationStore = stockAction.DestinationStore.Name;

                        dto.TransactionDate = stockAction.WorkListDate?.ToString("dd.MM.yyyy HH:mm:ss");
                        dto.State = stockAction.CurrentStateDef.DisplayText;

                        foreach (DocumentRecordLog log in stockAction.DocumentRecordLogs)
                        {
                            dto.ReceiptNumber = log.ReceiptNumber?.ToString();
                        }

                        if (stockAction is ChattelDocumentWithPurchase)
                        {
                            dto.PatientNameSurname = ((ChattelDocumentWithPurchase)stockAction).InPatientPhysicianApplication?.Episode?.Patient.FullName;
                            dto.PatientProtocolNumber = ((ChattelDocumentWithPurchase)stockAction).InPatientPhysicianApplication?.SubEpisode.ProtocolNo;
                            dto.DestinationStore = ((ChattelDocumentWithPurchase)stockAction).Supplier.Name;
                            dto.StockActionObjectDefID = Guid.Parse("3799bd27-4d89-4cd5-83e3-7aea9801138e");
                            if (string.IsNullOrEmpty(inputdvo.StockHareketId))
                            {
                                flag = string.IsNullOrEmpty(inputdvo.BillNumber) || ((ChattelDocumentWithPurchase)stockAction).Waybill == inputdvo.BillNumber;
                                flag = flag && (!inputdvo.SupplierId.HasValue || ((ChattelDocumentWithPurchase)stockAction).Supplier.ObjectID == inputdvo.SupplierId);
                                flag = flag && (string.IsNullOrEmpty(inputdvo.Supplier) || CultureInfo.CurrentCulture.CompareInfo.IndexOf(((ChattelDocumentWithPurchase)stockAction).Supplier.Name, inputdvo.Supplier, CompareOptions.IgnoreCase) >= 0);
                                flag = flag && !inputdvo.AccountancyId.HasValue;
                                flag = flag && (!inputdvo.InPatientPhysicianApplication.HasValue || ((ChattelDocumentWithPurchase)stockAction).InPatientPhysicianApplication?.ObjectID == inputdvo.InPatientPhysicianApplication);
                                flag = flag && ((inputdvo.PatientSpecial == true && ((ChattelDocumentWithPurchase)stockAction).InPatientPhysicianApplication != null)
                                    || inputdvo.PatientSpecial != true);
                            }
                        }
                        else if (stockAction is ChattelDocumentInputWithAccountancy)
                        {
                            dto.PatientNameSurname = ((ChattelDocumentInputWithAccountancy)stockAction).InPatientPhysicianApplication?.Episode?.Patient.FullName;
                            dto.PatientProtocolNumber = ((ChattelDocumentInputWithAccountancy)stockAction).InPatientPhysicianApplication?.SubEpisode.ProtocolNo;
                            dto.DestinationStore = ((ChattelDocumentInputWithAccountancy)stockAction).Accountancy.Name;
                            dto.StockActionObjectDefID = Guid.Parse("1c5c4fc6-72e8-4c58-8d6a-21e17d1eacf3");
                            if (string.IsNullOrEmpty(inputdvo.StockHareketId))
                            {
                                flag = string.IsNullOrEmpty(inputdvo.BillNumber) || ((ChattelDocumentInputWithAccountancy)stockAction).Waybill == inputdvo.BillNumber;
                                flag = flag && (!inputdvo.AccountancyId.HasValue || ((ChattelDocumentInputWithAccountancy)stockAction).Accountancy.ObjectID == inputdvo.AccountancyId);
                                flag = flag && string.IsNullOrEmpty(inputdvo.Supplier) && !inputdvo.SupplierId.HasValue;
                                flag = flag && (!inputdvo.InPatientPhysicianApplication.HasValue || ((ChattelDocumentInputWithAccountancy)stockAction).InPatientPhysicianApplication?.ObjectID == inputdvo.InPatientPhysicianApplication);
                                flag = flag && ((inputdvo.PatientSpecial == true && ((ChattelDocumentInputWithAccountancy)stockAction).InPatientPhysicianApplication != null)
                                    || inputdvo.PatientSpecial != true);
                            }
                        }
                        else if (stockAction is GrantMaterial)
                        {
                            dto.DestinationStore = ((GrantMaterial)stockAction).MaterialGranttedBy;
                            dto.StockActionObjectDefID = Guid.Parse("6dfc9fd8-2488-4d88-a109-c205546f8c25");
                            if (string.IsNullOrEmpty(inputdvo.StockHareketId))
                            {
                                flag = string.IsNullOrEmpty(inputdvo.BillNumber);
                                flag = flag && (string.IsNullOrEmpty(inputdvo.Supplier) || CultureInfo.CurrentCulture.CompareInfo.IndexOf(((GrantMaterial)stockAction).MaterialGranttedBy, inputdvo.Supplier, CompareOptions.IgnoreCase) >= 0);
                                flag = flag && !inputdvo.AccountancyId.HasValue;
                                flag = flag && inputdvo.PatientSpecial != true;
                            }
                        }


                        if (inputdvo.Material.HasValue)
                        {
                            flag = flag && stockAction.StockActionDetails.Any(p => p.Material.ObjectID == inputdvo.Material);
                        }
                        if (!string.IsNullOrEmpty(inputdvo.StockHareketId))
                        {
                            bool transactionFlag = false;
                            foreach (var sad in stockAction.StockActionDetails.Select(string.Empty))
                            {
                                foreach (var transaction in sad.StockTransactions.Select(string.Empty))
                                {
                                    transactionFlag = transaction.MKYS_StokHareketID == Convert.ToInt32(inputdvo.StockHareketId);
                                    if (transactionFlag)
                                    {
                                        break;
                                    }
                                }
                                if (transactionFlag)
                                {
                                    break;
                                }
                            }

                            flag = flag && transactionFlag;
                        }

                        if (flag)
                        {
                            result.Add(dto);
                        }
                    }
                }

                return result;
            }
        }
    }
}