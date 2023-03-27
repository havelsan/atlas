using Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.Collections;
using TTDefinitionManagement;
using TTInstanceManagement;
using Infrastructure.Filters;
using Infrastructure.Models;
using Core.Services;
using System;
using TTObjectClasses;
using TTUtils;
using TTStorageManager.Security;
using System.ComponentModel;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using TTDataDictionary;
using System.Drawing;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using TTConnectionManager;
using System.Xml;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class LogisticAddAndUpdateController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LogisticAddAndUpdateViewModel GetMkysKurumlariGuncelle()
        {
            LogisticAddAndUpdateViewModel model = new LogisticAddAndUpdateViewModel();
            ReturnAccountancy returnAccountancy = new ReturnAccountancy();
            List<ReturnAccountancyItem> NewAccountancyList = new List<ReturnAccountancyItem>();
            List<ReturnAccountancyItem> UpdateAccountancyList = new List<ReturnAccountancyItem>();

            MkysServis.birimItem[] birimItemList = MkysServis.WebMethods.disKurumlarListesiSync(Sites.SiteLocalHost, null, 0);

            foreach (MkysServis.birimItem item in birimItemList)
            {
                if (string.IsNullOrEmpty(item.birimAdi))
                    continue;

                var objectContext = new TTInstanceManagement.TTObjectContext(false);
                var accountancys = objectContext.QueryObjects<Accountancy>("ACCOUNTANCYNO = '" + item.birimKayitNo + "'");

                ReturnAccountancyItem accountancyItem = null;
                if (accountancys.Count > 0)
                {
                    accountancyItem.AccountancyCode = item.birimKodu.ToString();
                    accountancyItem.AccountancyNO = item.birimKayitNo.ToString();
                    accountancyItem.AccountancyName = item.birimAdi.ToUpper();
                    UpdateAccountancyList.Add(accountancyItem);
                }
                else
                {
                    accountancyItem.AccountancyCode = item.birimKodu.ToString();
                    accountancyItem.AccountancyNO = item.birimKayitNo.ToString();
                    accountancyItem.AccountancyName = item.birimAdi.ToUpper();
                    NewAccountancyList.Add(accountancyItem);
                }
            }
            returnAccountancy.NewAccountancyList = NewAccountancyList;
            returnAccountancy.UpdateAccountancyList = UpdateAccountancyList;
            model.returnAccountancy = returnAccountancy;
            return model;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public CreateMkysKurumlari_OutputDVO CreateMkysKurumlari(CreateMkysKurumlari_InputDVO inputList)
        {
            CreateMkysKurumlari_OutputDVO outputDVO = new CreateMkysKurumlari_OutputDVO();
            string returnMessage = string.Empty;
            if (inputList.CreateAccountancyList != null)
            {
                foreach (ReturnAccountancyItem newAccountancy in inputList.CreateAccountancyList)
                {
                    var objectContext = new TTInstanceManagement.TTObjectContext(false);
                    Accountancy accountancy = new Accountancy(objectContext);
                    accountancy.AccountancyCode = newAccountancy.AccountancyCode;
                    accountancy.AccountancyNO = newAccountancy.AccountancyNO;
                    accountancy.Address = "";
                    accountancy.Name = newAccountancy.AccountancyName.ToUpper();
                    if (newAccountancy.AccountancyName.Length >= 5)
                        accountancy.QREF = newAccountancy.AccountancyName.ToUpper().Substring(0, 5);
                    else
                        accountancy.QREF = newAccountancy.AccountancyName.ToUpper();
                    objectContext.Save();
                    objectContext.Dispose();
                    returnMessage += newAccountancy.AccountancyName + " - ";
                }
                returnMessage += TTUtils.CultureService.GetText("M26369", "Kurumlar Eklendi.");
            }
            else
            {
                returnMessage = TTUtils.CultureService.GetText("M26366", "Kurum Seçilmeden İşlem Gerçekleştirilemez.");
            }
            outputDVO.returnMessage = returnMessage;

            return outputDVO;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public UpdateMkysKurumlari_OutputDVO UpdateMkysKurumlari(UpdateMkysKurumlari_InputDVO inputList)
        {
            UpdateMkysKurumlari_OutputDVO outputDVO = new UpdateMkysKurumlari_OutputDVO();
            string returnMessage = string.Empty;
            if (inputList.UpdateAccountancyList != null)
            {
                foreach (ReturnAccountancyItem updateAccountancy in inputList.UpdateAccountancyList)
                {
                    var objectContext = new TTInstanceManagement.TTObjectContext(false);
                    var accountancyList = objectContext.QueryObjects<Accountancy>("ACCOUNTANCYNO = '" + updateAccountancy.AccountancyCode + "'");

                    Accountancy accountancy = accountancyList.FirstOrDefault();
                    accountancy.AccountancyCode = updateAccountancy.AccountancyCode;
                    accountancy.AccountancyNO = updateAccountancy.AccountancyNO;
                    accountancy.Address = "";
                    accountancy.Name = updateAccountancy.AccountancyName.ToUpper();
                    if (updateAccountancy.AccountancyName.Length >= 5)
                        accountancy.QREF = updateAccountancy.AccountancyName.ToUpper().Substring(0, 5);
                    else
                        accountancy.QREF = updateAccountancy.AccountancyName.ToUpper();
                    objectContext.Save();
                    objectContext.Dispose();
                    returnMessage += updateAccountancy.AccountancyName + " - ";
                }
                returnMessage += TTUtils.CultureService.GetText("M26370", "Kurumlar Güncellendi.");
            }
            else
            {
                returnMessage = TTUtils.CultureService.GetText("M26366", "Kurum Seçilmeden İşlem Gerçekleştirilemez.");
            }
            outputDVO.returnMessage = returnMessage;

            return outputDVO;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LogisticAddAndUpdateViewModel GetMkysFirmalariGuncelle()
        {
            LogisticAddAndUpdateViewModel model = new LogisticAddAndUpdateViewModel();
            ReturnSupplier returnSupplier = new ReturnSupplier();
            List<ReturnSupplierItem> NewSupplierList = new List<ReturnSupplierItem>();
            List<ReturnSupplierItem> UpdateSupplierList = new List<ReturnSupplierItem>();

            MkysServis.firmaBilgileriGetTumuSonuc[] firmaBilgileriGetTumu = MkysServis.WebMethods.firmaBilgileriGetTumuSync(Sites.SiteLocalHost);
            foreach (MkysServis.firmaBilgileriGetTumuSonuc item in firmaBilgileriGetTumu)
            {
                var objectContext = new TTInstanceManagement.TTObjectContext(false);
                var supplierList = objectContext.QueryObjects<Supplier>("TAXNO = '" + item.vergiNumarasi + "'");
                ReturnSupplierItem supplier = new ReturnSupplierItem();
                if (supplierList.Count > 0)
                {
                    supplier.GLNNo = item.vergiNumarasi;
                    supplier.Name = item.unvan;
                    supplier.TaxNo = item.vergiNumarasi;
                    supplier.TaxOfficeName = item.vergiDairesi;
                    UpdateSupplierList.Add(supplier);
                }
                else
                {
                    supplier.GLNNo = item.vergiNumarasi;
                    supplier.Name = item.unvan;
                    supplier.TaxNo = item.vergiNumarasi;
                    supplier.TaxOfficeName = item.vergiDairesi;
                    NewSupplierList.Add(supplier);
                }

            }
            returnSupplier.NewSupplierList = NewSupplierList;
            returnSupplier.UpdateSupplierList = UpdateSupplierList;
            model.returnSupplier = returnSupplier;
            return model;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public CreateMkysFirma_OutputDVO CreateMkysFirma(CreateMkysFirma_InputDVO inputList)
        {
            CreateMkysFirma_OutputDVO outputDVO = new CreateMkysFirma_OutputDVO();
            string returnMessage = string.Empty;
            if (inputList.CreateSupplerList != null)
            {
                foreach (ReturnSupplierItem newSuppler in inputList.CreateSupplerList)
                {
                    var objectContext = new TTInstanceManagement.TTObjectContext(false);
                    Supplier supplier = new Supplier(objectContext);
                    supplier.ActivityType = ActivityTypeEnum.Firm;
                    supplier.Address = "";
                    supplier.Email = "";
                    supplier.Fax = "";
                    supplier.GLNNo = newSuppler.GLNNo;
                    supplier.Name = newSuppler.Name;
                    supplier.TaxNo = newSuppler.TaxNo;
                    supplier.TaxOfficeName = newSuppler.TaxOfficeName;
                    supplier.Type = SupplierTypeEnum.Producer;
                    objectContext.Save();
                    objectContext.Dispose();
                    returnMessage += supplier.Name + " - ";
                }
                returnMessage += " Firmalar Eklendi.";
            }
            else
            {
                returnMessage = TTUtils.CultureService.GetText("M25676", "Firma Seçilmeden İşlem Gerçekleştirilemez.");
            }
            outputDVO.returnMessage = returnMessage;

            return outputDVO;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public UpdateMkysFirma_OutputDVO UpdateMkysFirma(UpdateMkysFirma_InputDVO inputList)
        {
            UpdateMkysFirma_OutputDVO outputDVO = new UpdateMkysFirma_OutputDVO();
            string returnMessage = string.Empty;
            if (inputList.UpdateSupplierList != null)
            {
                foreach (ReturnSupplierItem updateSuppler in inputList.UpdateSupplierList)
                {
                    var objectContext = new TTInstanceManagement.TTObjectContext(false);
                    var supplierList = objectContext.QueryObjects<Supplier>("TAXNO = '" + updateSuppler.TaxNo + "'");

                    Supplier supplier = supplierList.FirstOrDefault();
                    supplier.ActivityType = ActivityTypeEnum.Firm;
                    supplier.Address = "";
                    supplier.Email = "";
                    supplier.Fax = "";
                    supplier.GLNNo = updateSuppler.GLNNo;
                    supplier.Name = updateSuppler.Name;
                    supplier.TaxNo = updateSuppler.TaxNo;
                    supplier.TaxOfficeName = updateSuppler.TaxOfficeName;
                    supplier.Type = SupplierTypeEnum.Producer;
                    objectContext.Save();
                    objectContext.Dispose();
                    returnMessage += supplier.Name + " - ";
                }
                returnMessage += TTUtils.CultureService.GetText("M25679", "Firmalar Güncellendi.");
            }
            else
            {
                returnMessage = TTUtils.CultureService.GetText("M25676", "Firma Seçilmeden İşlem Gerçekleştirilemez.");
            }
            outputDVO.returnMessage = returnMessage;

            return outputDVO;
        }



        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LogisticAddAndUpdateViewModel GetMkysStockCardGuncelle(StockCardType stockCardTypes)
        {
            LogisticAddAndUpdateViewModel model = new LogisticAddAndUpdateViewModel();
            ReturnStockCard returnStockCard = new ReturnStockCard();
            List<StockCardItem> NewStockCardList = new List<StockCardItem>();
            List<StockCardItem> UpdateStockCardList = new List<StockCardItem>();


            var degisiklikTarihi = new DateTime(stockCardTypes.SelectedDateTime.Year, stockCardTypes.SelectedDateTime.Month, stockCardTypes.SelectedDateTime.Day); //new DateTime(1900, 1, 1);
            MkysServis.malzemeTibbiSarfItem[] mkysData = MkysServis.WebMethods.malzemetibbiSarfGetDataSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, stockCardTypes.MKYSPassword, degisiklikTarihi);

            if (mkysData.Length == 0)
            {
                throw new TTException("Mkys Kullanıcı adı ve şifrenizi kontrol ediniz.");
            }

            string stockcardfilter = string.Empty;
            if (stockCardTypes.StockCardTypeString == "IL")
            {
                stockcardfilter = " WHERE MALZEMEGETDATA IS NOT NULL AND STOCKCARDCLASS = 'e7df9662-24b7-4be9-9535-245fac550b64'";
            }
            else if (stockCardTypes.StockCardTypeString == "TK")
            {
                stockcardfilter = " WHERE MALZEMEGETDATA IS NOT NULL AND  STOCKCARDCLASS in ('24bbb539-5333-4f3a-a7a5-9be8ff46f8f6','99448e9e-e63b-4fe2-a83b-ddf8c50fb6bc')";
            }
            else if (stockCardTypes.StockCardTypeString == "TS")
            {
                stockcardfilter = " WHERE MALZEMEGETDATA IS NOT NULL AND STOCKCARDCLASS = '3be0c240-9b0b-4c79-8faf-59b04a028b2d'";
            }
            else
            {
                stockcardfilter = string.Empty;

            }

            var stockcardList = StockCard.GetStockCard(stockcardfilter).ToList();
            var malzemeGetDataList = mkysData.Where(x => x.malzemeTurID == stockCardTypes.StockCardTypeString).ToList();

            #region eskiyeniaynıkart
            var oldNewCardSame = from mkys in malzemeGetDataList
                                 where mkys.eskiMalzemeKodu == mkys.malzemeKodu
                                 select mkys;
            var oldNewCardSameList = oldNewCardSame.ToList();

            var existsSameInMKYSQuery = from mkys in oldNewCardSameList
                                        join stockcard in stockcardList
                                        on mkys.malzemeKodu equals stockcard.NATOStockNO into t
                                        from od in t.DefaultIfEmpty()
                                        where od != null && mkys.aktif != od.IsActive
                                        select mkys;
            var notExistsInMKYS = existsSameInMKYSQuery.ToList();
            foreach (var item in notExistsInMKYS)
            {
                if (stockcardList.FirstOrDefault(x => x.NATOStockNO == item.malzemeKodu).DistributionType != item.olcuBirimID)
                {
                    StockCardItem stockCardItem = new StockCardItem();
                    stockCardItem.StockCardName = String.IsNullOrEmpty(item.malzemeAdi) ? "?" : item.malzemeAdi;
                    stockCardItem.StockCardCode = item.malzemeKodu;
                    stockCardItem.StockCardDistribution = item.olcuBirimID;
                    stockCardItem.MKYSKayitID = item.malzemeKayitID;
                    stockCardItem.isActive = item.aktif;
                    stockCardItem.Desciption = "Aktiflik,Ölçü Birimi Güncellemesi";

                    stockCardItem.UpdateStockCardObjectID = stockcardList.Where(x => x.NATOStockNO == item.malzemeKodu).FirstOrDefault().ObjectID;

                    UpdateStockCardList.Add(stockCardItem);
                }
                else
                {
                    StockCardItem stockCardItem = new StockCardItem();
                    stockCardItem.StockCardName = String.IsNullOrEmpty(item.malzemeAdi) ? "?" : item.malzemeAdi;
                    stockCardItem.StockCardCode = item.malzemeKodu;
                    stockCardItem.StockCardDistribution = item.olcuBirimID;
                    stockCardItem.MKYSKayitID = item.malzemeKayitID;
                    stockCardItem.isActive = item.aktif;
                    stockCardItem.Desciption = "Aktiflik Güncellemesi";
                    UpdateStockCardList.Add(stockCardItem);
                }

            }
            var notExistsSameInMKYSQuery = from mkys in oldNewCardSameList
                                           join stockcard in stockcardList
                                          on mkys.malzemeKodu equals stockcard.NATOStockNO
                                          into t
                                           from od in t.DefaultIfEmpty()
                                           where od == null
                                           select mkys;
            var notExistssameInMKYS = notExistsSameInMKYSQuery.ToList();
            foreach (var item in notExistssameInMKYS)
            {

                StockCardItem stockCardItem = new StockCardItem();
                stockCardItem.StockCardName = String.IsNullOrEmpty(item.malzemeAdi) ? "?" : item.malzemeAdi;
                stockCardItem.StockCardCode = item.malzemeKodu;
                stockCardItem.StockCardDistribution = item.olcuBirimID;
                stockCardItem.MKYSKayitID = item.malzemeKayitID;
                stockCardItem.isActive = item.aktif;
                stockCardItem.Desciption = "Sistemde bulunamadı.";
                NewStockCardList.Add(stockCardItem);
            }
            #endregion

            #region eskiyenifarklı
            var oldNewCardNotSame = from mkys in malzemeGetDataList
                                    where mkys.eskiMalzemeKodu != mkys.malzemeKodu
                                    select mkys;
            var oldNewCardNotSameList = oldNewCardNotSame.ToList();


            var existsNotSameInMKYSQuery = from mkys in oldNewCardNotSameList
                                           join stockcard in stockcardList
                                           on mkys.eskiMalzemeKodu equals stockcard.NATOStockNO into t
                                           from od in t.DefaultIfEmpty()
                                           where od != null
                                           select mkys;
            var notSameExistsInMKYS = existsNotSameInMKYSQuery.ToList();

            foreach (var item in notSameExistsInMKYS)
            {
                StockCardItem stockCardItem = new StockCardItem();
                stockCardItem.StockCardName = String.IsNullOrEmpty(item.malzemeAdi) ? "?" : item.malzemeAdi;
                stockCardItem.StockCardCode = item.malzemeKodu;
                stockCardItem.StockCardDistribution = item.olcuBirimID;
                stockCardItem.MKYSKayitID = item.malzemeKayitID;
                stockCardItem.isActive = item.aktif;
                stockCardItem.Desciption = "Taşınır kodu Değişem İşlem";

                stockCardItem.UpdateStockCardObjectID = stockcardList.Where(x => x.NATOStockNO == item.malzemeKodu).FirstOrDefault().ObjectID;

                UpdateStockCardList.Add(stockCardItem);
            }
            #endregion

            #region eskiyokyeni

            var newCardNotSame = from mkys in malzemeGetDataList
                                 where mkys.eskiMalzemeKodu == null
                                 select mkys;
            var newCardNotSameList = newCardNotSame.ToList();


            var notNewExistsInMKYSQuery = from mkys in newCardNotSameList
                                          join stockcard in stockcardList
                                         on mkys.malzemeKodu equals stockcard.NATOStockNO
                                         into t
                                          from od in t.DefaultIfEmpty()
                                          where od == null
                                          select mkys;
            var notExistsNewInMKYS = notNewExistsInMKYSQuery.ToList();
            foreach (var item in notExistsNewInMKYS)
            {

                StockCardItem stockCardItem = new StockCardItem();
                stockCardItem.StockCardName = String.IsNullOrEmpty(item.malzemeAdi) ? "?" : item.malzemeAdi;
                stockCardItem.StockCardCode = item.malzemeKodu;
                stockCardItem.StockCardDistribution = item.olcuBirimID;
                stockCardItem.MKYSKayitID = item.malzemeKayitID;
                stockCardItem.isActive = item.aktif;
                stockCardItem.Desciption = "Sistemde bulunamadı.";
                NewStockCardList.Add(stockCardItem);
            }

            //mkys tablsounda mevcut olan stockcardları (güncellenecekler)
            var instersectionQuery = from mkys in newCardNotSameList
                                     join stockcard in stockcardList
                                     on mkys.malzemeKodu equals stockcard.NATOStockNO into t
                                     from od in t.DefaultIfEmpty()
                                     where od != null && mkys.aktif != od.IsActive
                                     select mkys;

            var intersection = instersectionQuery.ToList();
            foreach (var item in intersection)
            {
                if (stockcardList.FirstOrDefault(x => x.NATOStockNO == item.malzemeKodu).DistributionType != item.olcuBirimID)
                {
                    StockCardItem stockCardItem = new StockCardItem();
                    stockCardItem.StockCardName = String.IsNullOrEmpty(item.malzemeAdi) ? "?" : item.malzemeAdi;
                    stockCardItem.StockCardCode = item.malzemeKodu;
                    stockCardItem.StockCardDistribution = item.olcuBirimID;
                    stockCardItem.MKYSKayitID = item.malzemeKayitID;
                    stockCardItem.isActive = item.aktif;
                    stockCardItem.Desciption = "Aktiflik,Ölçü Birimi Güncellemesi";

                    stockCardItem.UpdateStockCardObjectID = stockcardList.Where(x => x.NATOStockNO == item.malzemeKodu).FirstOrDefault().ObjectID;

                    UpdateStockCardList.Add(stockCardItem);
                }
                else
                {
                    StockCardItem stockCardItem = new StockCardItem();
                    stockCardItem.StockCardName = String.IsNullOrEmpty(item.malzemeAdi) ? "?" : item.malzemeAdi;
                    stockCardItem.StockCardCode = item.malzemeKodu;
                    stockCardItem.StockCardDistribution = item.olcuBirimID;
                    stockCardItem.MKYSKayitID = item.malzemeKayitID;
                    stockCardItem.isActive = item.aktif;
                    stockCardItem.Desciption = "Aktiflik Güncellemesi";

                    stockCardItem.UpdateStockCardObjectID = stockcardList.Where(x => x.NATOStockNO == item.malzemeKodu).FirstOrDefault().ObjectID;

                    UpdateStockCardList.Add(stockCardItem);
                }
            }
            #endregion

            returnStockCard.NewStockCardList = NewStockCardList;
            returnStockCard.UpdateStockCardList = UpdateStockCardList;
            model.returnStockCard = returnStockCard;
            return model;
        }

        public StockCardClass ReturnStockCardClass(string cod)
        {
            using (var objectContext = new TTInstanceManagement.TTObjectContext(false))
            {
                StockCardClass returnClass = null;
                IList stockcardClasses = objectContext.QueryObjects(typeof(StockCardClass).Name, "CODE LIKE '" + cod + "'");
                if (stockcardClasses.Count == 1)
                {
                    returnClass = (StockCardClass)stockcardClasses[0];
                }
                else
                {
                    string temp = string.Empty;
                    string[] splitMalzemeKodu = cod.Split('-');
                    for (int i = 0; i < splitMalzemeKodu.Length - 1; i++)
                    {
                        temp += splitMalzemeKodu[i];
                        if (i != splitMalzemeKodu.Length - 2)
                        {
                            temp += "-";
                        }
                    }
                    if (string.IsNullOrEmpty(temp) == false)
                        returnClass = ReturnStockCardClass(temp);
                }
                return returnClass;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public CreateMkysStockCard_OutputDVO CreateMkysStockCard(CreateMkysStockCard_InputDVO inputList)
        {
            CreateMkysStockCard_OutputDVO outputDVO = new CreateMkysStockCard_OutputDVO();
            string returnMessage = string.Empty;
            if (inputList.CreateStockCardList != null)
            {
                foreach (StockCardItem stockCardItem in inputList.CreateStockCardList)
                {
                    var objectContext = new TTInstanceManagement.TTObjectContext(false);

                    MalzemeGetData malzemeGetData = new MalzemeGetData(objectContext);
                    malzemeGetData.aktif = stockCardItem.isActive;
                    malzemeGetData.degisiklikTarihi = Common.RecTime();
                    malzemeGetData.gunlemeTarihi = Common.RecTime();
                    malzemeGetData.IsActive = stockCardItem.isActive;
                    malzemeGetData.malzemeAdi = String.IsNullOrEmpty(stockCardItem.StockCardName) ? "?" : stockCardItem.StockCardName;
                    malzemeGetData.malzemeKayitID = stockCardItem.MKYSKayitID;
                    malzemeGetData.malzemeKodu = stockCardItem.StockCardCode;

                    StockCard stockCard = new StockCard(objectContext);
                    stockCard.Name = String.IsNullOrEmpty(stockCardItem.StockCardName) ? "?" : stockCardItem.StockCardName;
                    stockCard.NATOStockNO = stockCardItem.StockCardCode;
                    stockCard.RepairCheckbox = false;
                    stockCard.ProductionCheckbox = true;
                    stockCard.MainStoreCheckbox = true;
                    stockCard.ProductionCheckbox = false;
                    stockCard.CardAmount = 1;
                    stockCard.CardOrderNO = 0;
                    stockCard.Status = StockCardStatusEnum.NewCard;
                    stockCard.StockMethod = StockMethodEnum.StockNumbered;
                    stockCard.CreationDate = Common.RecTime();
                    stockCard.IsActive = stockCardItem.isActive;
                    stockCard.MalzemeGetData = malzemeGetData;
                    StockCardClass otherClass = this.ReturnStockCardClass(stockCardItem.StockCardCode);
                    stockCard.StockCardClass = otherClass;
                    IList defList = objectContext.QueryObjects(typeof(DistributionTypeDefinition).Name, "QREF LIKE '" + stockCardItem.StockCardDistribution + "'");
                    stockCard.DistributionType = (DistributionTypeDefinition)defList[0];
                    objectContext.Save();
                    objectContext.Dispose();
                    returnMessage += stockCard.Name + " - ";
                }
                returnMessage += " Stok Kartı Eklendi.";
            }
            else
            {
                returnMessage = TTUtils.CultureService.GetText("İşlem Sırasında Hata Oluşmuştur.");
            }
            outputDVO.returnMessage = returnMessage;
            return outputDVO;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public UpdateMkysStockCard_OutputDVO UpdateMkysStockCard(UpdateMkysStockCard_InputDVO inputList)
        {
            UpdateMkysStockCard_OutputDVO outputDVO = new UpdateMkysStockCard_OutputDVO();
            string returnMessage = string.Empty;
            if (inputList.UpdateStockCardList != null)
            {
                foreach (StockCardItem updateStockCard in inputList.UpdateStockCardList)
                {
                    var objectContext = new TTInstanceManagement.TTObjectContext(false);
                    StockCard stockCard = objectContext.GetObject<StockCard>((Guid)updateStockCard.UpdateStockCardObjectID);
                    stockCard.Name = updateStockCard.StockCardName;
                    stockCard.NATOStockNO = updateStockCard.StockCardCode;
                    stockCard.IsActive = updateStockCard.isActive;
                    IList defList = objectContext.QueryObjects(typeof(DistributionTypeDefinition).Name, "QREF LIKE '" + updateStockCard.StockCardDistribution + "'");
                    stockCard.DistributionType = (DistributionTypeDefinition)defList[0];
                    objectContext.Save();
                    objectContext.Dispose();
                    returnMessage += updateStockCard.StockCardName + " - ";
                }
                returnMessage += TTUtils.CultureService.GetText("M26953", "Stok Kartıları Güncellendi.");
            }
            else
            {
                returnMessage = TTUtils.CultureService.GetText("İşlem Sırasında Hata Oluşmuştur.");
            }
            outputDVO.returnMessage = returnMessage;

            return outputDVO;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LogisticAddAndUpdateViewModel GetReturnFirstStockIn(ReturnFirstStockIn_Input returnFirstStockIn_Input)
        {
            TTObjectContext context = new TTObjectContext(false);
            LogisticAddAndUpdateViewModel model = new LogisticAddAndUpdateViewModel();
            MainStoreDefinition mainStoreDefinition = (MainStoreDefinition)context.GetObject(new Guid(returnFirstStockIn_Input.mainStoreDefinition), typeof(MainStoreDefinition));


            List<StockFirstInGridItem> firstInGridItemList = new List<StockFirstInGridItem>();
            IBindingList stockactionList = context.QueryObjects("STOCKFIRSTIN", " STORE = " + TTConnectionManager.ConnectionManager.GuidToString(mainStoreDefinition.ObjectID) + " AND CURRENTSTATEDEFID = " + TTConnectionManager.ConnectionManager.GuidToString(StockFirstIn.States.Completed));
            if (stockactionList.Count > 0)
            {
                foreach (StockAction st in stockactionList)
                {
                    StockFirstInGridItem stockFirstInGridItem = new StockFirstInGridItem();
                    stockFirstInGridItem.stockActionObjID = st.ObjectID.ToString();
                    stockFirstInGridItem.stockActionNo = st.StockActionID.ToString();
                    firstInGridItemList.Add(stockFirstInGridItem);
                }
            }
            model.StockFirstInGridItemList = firstInGridItemList;
            return model;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LogisticAddAndUpdateViewModel GetDetailsOfFirstStockIn(GetDetailsOfFirstStockIn_Input getDetailsOfFirstStockIn_Input)
        {
            TTObjectContext context = new TTObjectContext(false);
            LogisticAddAndUpdateViewModel model = new LogisticAddAndUpdateViewModel();
            List<StockFirstInDetailGridItem> returnFirstStockInList = new List<StockFirstInDetailGridItem>();
            IBindingList stockActionDetailList = context.QueryObjects("STOCKACTIONDETAILIN", " STOCKACTION = '" + getDetailsOfFirstStockIn_Input.stockActionObjID + "'");
            if (stockActionDetailList.Count > 0)
            {
                foreach (StockActionDetailIn stDet in stockActionDetailList)
                {
                    StockFirstInDetailGridItem firstStockInDetail = new StockFirstInDetailGridItem();
                    firstStockInDetail.StockActionDetailObjID = stDet.ObjectID.ToString();
                    firstStockInDetail.MaterialName = stDet.Material.Name;
                    if (((TTObjectClasses.StockFirstInDetail)stDet).MkysStokHareketID != null)
                        firstStockInDetail.MKYS_StokHareketID = ((TTObjectClasses.StockFirstInDetail)stDet).MkysStokHareketID.ToString();
                    else
                        firstStockInDetail.MKYS_StokHareketID = "";
                    firstStockInDetail.ExpirationDate = (DateTime)stDet.ExpirationDate;
                    firstStockInDetail.Amount = stDet.Amount.ToString();
                    firstStockInDetail.OldPrice = stDet.UnitPrice.ToString();
                    firstStockInDetail.Barcode = stDet.Material.Barcode;
                    if (stDet.Material.StockCard != null)
                        firstStockInDetail.NatoStockNo = stDet.Material.StockCard.NATOStockNO;
                    firstStockInDetail.NewPrice = "";
                    returnFirstStockInList.Add(firstStockInDetail);
                }
            }
            model.StockFirstInDetailGridItemList = returnFirstStockInList;
            return model;
        }



        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool UpdateUnitPriceForSelectedItems(UpdateUnitPriceForSelectedItems_Input input)
        {
            try
            {

                foreach (StockFirstInDetailGridItem item in input.StockFirstInDetailGridItems)
                {
                    if (string.IsNullOrEmpty(item.NewPrice))
                    {
                        continue;
                    }

                    TTObjectContext context = new TTObjectContext(false);
                    StockActionDetailIn detailIn = (StockActionDetailIn)context.GetObject(new Guid(item.StockActionDetailObjID), typeof(StockActionDetailIn));
                    detailIn.UnitPrice = BigCurrency.Parse(item.NewPrice);

                    StockTransaction transaction = detailIn.StockTransactions.Select("INOUT = 1").FirstOrDefault();
                    transaction.UnitPrice = BigCurrency.Parse(item.NewPrice);

                    Dictionary<Guid, StockTransaction> allTrx = new Dictionary<Guid, StockTransaction>();
                    allTrx = StockTrxUpdateAction.FindStockTransactionAllTrx(transaction, allTrx);
                    foreach (KeyValuePair<Guid, StockTransaction> trx in allTrx)
                    {
                        if (trx.Value.CurrentStateDefID != StockTransaction.States.Cancelled)
                        {
                            trx.Value.UnitPrice = BigCurrency.Parse(item.NewPrice);
                            TrxStockPriceUpdate(trx.Value, false);
                            IList colletedTrxs = context.QueryObjects("STOCKCOLLECTEDTRX", "STOCKTRANSACTION =" + ConnectionManager.GuidToString(trx.Value.ObjectID));
                            if (colletedTrxs.Count > 0)
                            {
                                foreach (StockCollectedTrx colletedTrx in colletedTrxs)
                                {
                                    foreach (StockTransaction siibTrx in colletedTrx.StockActionDetail.StockTransactions.Select(string.Empty))
                                    {
                                        siibTrx.UnitPrice = BigCurrency.Parse(item.NewPrice);
                                        TrxStockPriceUpdate(siibTrx, false);
                                    }
                                }
                            }
                        }
                    }
                    context.Save();
                    context.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private void TrxStockPriceUpdate(StockTransaction stockTransaction, bool cancelled)
        {
            if (stockTransaction.Amount.HasValue == false || stockTransaction.Amount.Value == 0)
                throw new TTException(TTUtils.CultureService.GetText("M26947", "Stok değerleri 0 ile güncellenemez."));

            switch (stockTransaction.MaintainLevelCode)
            {
                case MaintainLevelCodeEnum.IncreaseInheld:
                    if (cancelled)
                    {
                        stockTransaction.Stock.TotalInPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    else
                    {
                        stockTransaction.Stock.TotalInPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    break;
                case MaintainLevelCodeEnum.DecreaseInheld:
                    if (cancelled)
                    {
                        stockTransaction.Stock.TotalOutPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    else
                    {
                        stockTransaction.Stock.TotalOutPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    break;
                case MaintainLevelCodeEnum.IncreaseConsigned:
                    if (cancelled)
                    {
                        stockTransaction.Stock.TotalInPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    else
                    {
                        stockTransaction.Stock.TotalInPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    break;
                case MaintainLevelCodeEnum.DecreaseConsigned:
                    if (cancelled)
                    {
                        stockTransaction.Stock.TotalOutPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    else
                    {
                        stockTransaction.Stock.TotalOutPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    break;
                case MaintainLevelCodeEnum.IncreaseInheld__DecreaseConsigned:
                    break;
                case MaintainLevelCodeEnum.DecreaseInheld__IncreaseConsigned:
                    break;
                case MaintainLevelCodeEnum.ReturnInheld:
                    if (cancelled)
                    {
                        stockTransaction.Stock.TotalInPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    else
                    {
                        stockTransaction.Stock.TotalInPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    break;
                default:
                    throw new TTException(TTUtils.CultureService.GetText("M25902", "Hatalı işlem kodu!"));
            }
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void ilacAra()
        {
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            BindingList<DrugDefinition> drugs = readOnlyContext.QueryObjects<DrugDefinition>("INPATIENTREPORTTYPE is null");
            List<DrugDefinition> restDrug = drugs.ToList();
            foreach (DrugDefinition drug in drugs)
            {
                if (drug.Stocks.Select(string.Empty).Count > 0)
                {
                    XXXXXXMedulaServices.IlacAraGirisDVO girisDVO = new XXXXXXMedulaServices.IlacAraGirisDVO();
                    girisDVO.ilacAdi = drug.Name;
                    girisDVO.barkod = drug.Barcode;
                    restDrug.Remove(drug);
                    try
                    {
                        XXXXXXMedulaServices XXXXXXMedulaService = new XXXXXXMedulaServices();
                        MedulaYardimciIslemler.ilacAraCevapDVO response = XXXXXXMedulaService.IlacAra(girisDVO);
                        if (response != null)
                        {
                            if (response.sonucKodu == "0000" && response.ilaclar != null)
                            {
                                TTObjectContext context = new TTObjectContext(false);
                                DrugDefinition drugDefinition = (DrugDefinition)context.GetObject(drug.ObjectID, typeof(DrugDefinition));
                                drugDefinition.OutpatientReportType = (DrugReportType)Convert.ToInt16(response.ilaclar[0].ayaktanOdenme);
                                drugDefinition.InpatientReportType = (DrugReportType)Convert.ToInt16(response.ilaclar[0].yatanOdenme);
                                context.Save();
                                context.Dispose();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        foreach (DrugDefinition drugDefinition in restDrug)
                        {
                            if (drugDefinition.Stocks.Select(string.Empty).Count > 0)
                            {
                                XXXXXXMedulaServices.IlacAraGirisDVO girisDVONew = new XXXXXXMedulaServices.IlacAraGirisDVO();
                                girisDVONew.ilacAdi = drug.Name;
                                girisDVONew.barkod = drug.Barcode;
                                restDrug.Remove(drug);
                                XXXXXXMedulaServices XXXXXXMedulaService = new XXXXXXMedulaServices();
                                MedulaYardimciIslemler.ilacAraCevapDVO response = XXXXXXMedulaService.IlacAra(girisDVONew);
                                if (response != null)
                                {
                                    if (response.sonucKodu == "0000" && response.ilaclar != null)
                                    {
                                        TTObjectContext context = new TTObjectContext(false);
                                        DrugDefinition drugDef = (DrugDefinition)context.GetObject(drug.ObjectID, typeof(DrugDefinition));
                                        drugDef.OutpatientReportType = (DrugReportType)Convert.ToInt16(response.ilaclar[0].ayaktanOdenme);
                                        drugDef.InpatientReportType = (DrugReportType)Convert.ToInt16(response.ilaclar[0].yatanOdenme);
                                        context.Save();
                                        context.Dispose();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        [HttpPost]
        public List<Material.GetUTSMaterialDetails_Class> GetUTSMaterials()
        {
            using (TTObjectContext readOnlyContext = new TTObjectContext(true))
            {
                List<Material.GetUTSMaterialDetails_Class> existentUTSMaterials = Material.GetUTSMaterialDetails(readOnlyContext).ToList();
                return existentUTSMaterials;
            }
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<UTSUnusedGridDataModel> GetUTSUnUsedList(UTSUnlist_Input input)
        {
            DateTime startDate = new DateTime(input.UTSUsedStartDate.Year, input.UTSUsedStartDate.Month, input.UTSUsedStartDate.Day, 0, 0, 0);
            DateTime endDate = new DateTime(input.UTSUsedEndDate.Year, input.UTSUsedEndDate.Month, input.UTSUsedEndDate.Day, 23, 59, 59);
            List<UTSUnusedGridDataModel> uTSUnusedGridDataModels = new List<UTSUnusedGridDataModel>();

            using (TTObjectContext readOnlyContext = new TTObjectContext(true))
            {
                //IBindingList subActionMaterials = readOnlyContext.QueryObjects(typeof(SubActionMaterial).Name, "STOCKACTIONDETAIL IS NOT NULL AND " +
                //     "MATERIAL.ISINDIVIDUALTRACKINGREQUIRED = 1 AND CURRENTSTATEDEFID <>" + TTConnectionManager.ConnectionManager.GuidToString(SubActionMaterial.States.Cancelled) +
                //     " AND ACTIONDATE > " + TTUtils.Globals.CreateNQLToDateParameter(startDate) + " AND ACTIONDATE < " + TTUtils.Globals.CreateNQLToDateParameter(endDate));

                BindingList<SubActionMaterial.GetUnUsedUTSNotification_Class> getUnUsedUTs = SubActionMaterial.GetUnUsedUTSNotification(endDate, startDate);

                foreach (SubActionMaterial.GetUnUsedUTSNotification_Class subActionMaterial in getUnUsedUTs)
                {
                    SubActionMaterial actionMaterial = (SubActionMaterial)readOnlyContext.GetObject((Guid)(subActionMaterial.ObjectID), typeof(SubActionMaterial).Name);
                    IBindingList stockTransactions = actionMaterial.StockActionDetail.StockTransactions.Select(string.Empty);
                    foreach (StockTransaction st in stockTransactions)
                    {
                        // var utsNotDetCount = st.UTSNotificationDetails.Select(x => x.CurrentStateDefID != UTSNotificationDetail.States.Cancelled).ToList().Count;
                        // if (st.Amount != utsNotDetCount)
                        //  {
                        StockAction stockAction = st.GetFirstInTransaction().StockActionDetail.StockAction;
                        UTSUnusedGridDataModel uTSUnused = new UTSUnusedGridDataModel();
                        uTSUnused.SubActionMaterailObjID = actionMaterial.ObjectID;
                        uTSUnused.StockTransactionID = st.ObjectID.ToString();
                        uTSUnused.Amount = st.Amount.ToString();
                        uTSUnused.Barcode = actionMaterial.Material.Barcode;
                        uTSUnused.ProtocolNo = actionMaterial.SubEpisode.ProtocolNo;
                        uTSUnused.LotNo = ((StockActionDetailIn)(st.GetFirstInTransaction().StockActionDetail)).LotNo;
                        uTSUnused.MaterialName = actionMaterial.Material.Name;
                        uTSUnused.UTSAmount = subActionMaterial.Utsamount.ToString();// utsNotDetCount.ToString();
                        uTSUnused.UTSAlmaBildirimID = ((StockActionDetailIn)(st.GetFirstInTransaction().StockActionDetail)).ReceiveNotificationID;
                        if (stockAction.DocumentRecordLogs.Count > 0)
                            uTSUnused.MKYSTifNo = stockAction.DocumentRecordLogs.FirstOrDefault().DocumentRecordLogNumber.ToString();
                        else
                            uTSUnused.MKYSTifNo = "";
                        uTSUnused.StockActionID = stockAction.StockActionID.ToString();
                        uTSUnused.StockActionObjID = stockAction.ObjectID.ToString();
                        //uTSUnused.UTSErrorMessege = "";
                        uTSUnusedGridDataModels.Add(uTSUnused);
                        // }
                    }
                }
            }
            return uTSUnusedGridDataModels;
        }


        [HttpPost]
        public List<ENabizMaterialGrid> GetErrorENabizMaterialList(ENabizMaterialInput input)
        {
            using (TTObjectContext readOnlyContext = new TTObjectContext(true))
            {
                List<ENabizMaterialGrid> returnGridList = new List<ENabizMaterialGrid>();
                IBindingList sendToENabizs = readOnlyContext.QueryObjects(typeof(SendToENabiz).Name, " INTERNALOBJECTDEFNAME = 'ENABIZMATERIAL' AND STATUS NOT IN (1,4,0) AND RECORDDATE >"
                    + TTUtils.Globals.CreateNQLToDateParameter(input.startDate) + " AND RECORDDATE <" + TTUtils.Globals.CreateNQLToDateParameter(input.endDate) + " AND Packagecode = 102 "
                    + " AND SUBEPISODE.SENT101PACKAGE = 1 ");


                foreach (SendToENabiz eNabiz in sendToENabizs)
                {
                    ENabizMaterialGrid nabizMaterialGrid = new ENabizMaterialGrid();

                    ENabizMaterial eNabizMaterial = (ENabizMaterial)readOnlyContext.GetObject(eNabiz.InternalObjectID.Value, typeof(ENabizMaterial));
                    if (eNabizMaterial.CurrentStateDefID == ENabizMaterial.States.Completed)
                    {
                        nabizMaterialGrid.ProtocolNO = eNabiz.SubEpisode.ProtocolNo;
                        nabizMaterialGrid.ApplicationDate = eNabizMaterial.ApplicationDate.ToString();
                        nabizMaterialGrid.RequestDate = eNabizMaterial.RequestDate.ToString();
                        nabizMaterialGrid.MaterialName = eNabizMaterial.SubActionMaterial.Material.Name;
                        nabizMaterialGrid.MaterialBarcode = eNabizMaterial.SubActionMaterial.Material.Barcode;
                        if (eNabiz.ResponseOfENabizs.Select(string.Empty).Count > 0)
                        {
                            nabizMaterialGrid.SendDate = eNabiz.ResponseOfENabizs.Select(string.Empty).LastOrDefault().SendDate.ToString();
                            nabizMaterialGrid.ResponseMessage = eNabiz.ResponseOfENabizs.Select(string.Empty).LastOrDefault().ResponseMessage;
                        }
                        returnGridList.Add(nabizMaterialGrid);

                    }
                }
                return returnGridList;
            }
        }

        [HttpPost]
        public string AddToEnabizListEMaterials(ENabizMaterialInput input)
        {
            string sonuc = "";
            using (TTObjectContext context = new TTObjectContext(false))
            {
                try
                {
                    BindingList<SendToENabiz.GetSentToENabizMaterial_Class> sendToEnabizs = SendToENabiz.GetSentToENabizMaterial(input.endDate, input.startDate);
                    foreach (SendToENabiz.GetSentToENabizMaterial_Class sendToENabiz in sendToEnabizs)
                    {
                        bool update = false;
                        ENabizMaterial eNabizMaterial = (ENabizMaterial)context.GetObject(sendToENabiz.InternalObjectID.Value, sendToENabiz.InternalObjectDefName);
                        if (eNabizMaterial.CurrentStateDefID != ENabizMaterial.States.Cancelled)
                        {
                            if (eNabizMaterial.RequestDate < eNabizMaterial.SubActionMaterial.SubEpisode.OpeningDate)
                            {
                                eNabizMaterial.RequestDate = eNabizMaterial.SubActionMaterial.SubEpisode.OpeningDate.Value.AddMinutes(1);
                                eNabizMaterial.ApplicationDate = eNabizMaterial.SubActionMaterial.SubEpisode.OpeningDate.Value.AddMinutes(2);
                                update = true;
                            }

                            if (eNabizMaterial.RequestDate > eNabizMaterial.ApplicationDate)
                            {
                                eNabizMaterial.ApplicationDate = eNabizMaterial.RequestDate.Value.AddMinutes(1);
                                update = true;
                            }

                            if (eNabizMaterial.ApplicationDate < Common.RecTime() && update == false)
                                update = true;

                            if (update && sendToENabiz.Status != SendToENabizEnum.ToBeSent)
                            {
                                SendToENabiz updateSendToENabiz = (SendToENabiz)context.GetObject((Guid)(sendToENabiz.ObjectID), typeof(SendToENabiz).Name);
                                updateSendToENabiz.Status = SendToENabizEnum.ToBeSent;
                            }
                        }
                    }
                    context.Save();
                    context.Dispose();
                    sonuc = "E-Nabız Liste Güncelleme Başarılı";
                    return sonuc;
                }
                catch (Exception ex)
                {
                    sonuc = ex.Message;
                    return sonuc;
                }
            }
        }


        public class SarfBildirimi_Input
        {
            public Guid StockTransaction { get; set; }
        }


        public string ITSSarfBildir(SarfBildirimi_Input input)
        {
            TTObjectContext context = new TTObjectContext(false);
            StockTransaction stockTransaction = (StockTransaction)context.GetObject(input.StockTransaction, typeof(StockTransaction));

            BindingList<ITSSendTransaction.GetITSTrx_Class> sendBeforeCheck =
            ITSSendTransaction.GetITSTrx(stockTransaction.ObjectID, " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(ITSSendTransaction.States.Send));

            string returnITSMessage = "";
            if (sendBeforeCheck.Count > 0)
            {
                throw new TTException(" ITS Bildirimi daha önce yapılmıştır");
            }
            else
            {
                try
                {
                    List<XXXXXXSarfBildirimReceiverService.XXXXXXSarfTypeURUN> urunList = new List<XXXXXXSarfBildirimReceiverService.XXXXXXSarfTypeURUN>();
                    XXXXXXSarfBildirimReceiverService.XXXXXXSarfTypeURUN urun = new XXXXXXSarfBildirimReceiverService.XXXXXXSarfTypeURUN();
                    urun.GTIN = stockTransaction.StockActionDetail.Material.Barcode;
                    urun.SN = stockTransaction.SerialNo;
                    urun.XD = (DateTime)stockTransaction.ExpirationDate;
                    urun.BN = stockTransaction.LotNo;
                    urunList.Add(urun);

                    XXXXXXSarfBildirimReceiverService.XXXXXXSarfCevapType response = new XXXXXXSarfBildirimReceiverService.XXXXXXSarfCevapType();
                    XXXXXXSarfBildirimReceiverService.XXXXXXSarfType request = new XXXXXXSarfBildirimReceiverService.XXXXXXSarfType();
                    request.URUNLER = urunList.ToArray();
                    request.DT = "D";
                    request.FR = TTObjectClasses.SystemParameter.GetParameterValue("ITSGLN", "");
                    request.ISACIKLAMA = "";
                    response = XXXXXXSarfBildirimReceiverService.WebMethods.XXXXXXSarfBildirSync(Sites.SiteLocalHost, request);

                    ITSSendTransaction sendTransaction = new ITSSendTransaction(context);
                    sendTransaction.StockTransaction = stockTransaction;
                    sendTransaction.NotificationID = response.BILDIRIMID;
                    sendTransaction.TransactionDate = Common.RecTime();
                    sendTransaction.CurrentStateDefID = ITSSendTransaction.States.Send;
                    context.Save();

                    returnITSMessage = response.ToString();
                    return returnITSMessage;

                }
                catch (Exception ex)
                {
                    throw new TTException(ex.Message);
                }
            }
        }

        public class ITSSendInputDTO
        {
            public List<ITSSendList> itsSendList { get; set; }
        }


        public class ITSSendList
        {
            public Guid StockTransactionObjectID { get; set; }
            public string drugName { get; set; }
            public string drugBarcode { get; set; }
            public string lotNO { get; set; }
            public string serialNo { get; set; }
            public string status { get; set; }
            public DateTime expirationDate { get; set; }

        }

        public List<ITSSendList> GetStockActionITSDetailrugList(string stockActionID)
        {
            TTObjectContext context = new TTObjectContext(false);
            List<ITSSendList> sendOfITMaterial = new List<ITSSendList>();
            IBindingList stockTransactionList = context.QueryObjects(typeof(StockTransaction).Name, " STOCKACTIONDETAIL.STOCKACTION.STOCKACTIONID = '" + stockActionID + "' AND STOCKACTIONDETAIL.STOCKACTION.ISPTSACTION = 1 AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(StockTransaction.States.Completed));

            foreach (StockTransaction stockTransaction in stockTransactionList)
            {
                ITSSendList itsMat = new ITSSendList();
                itsMat.drugName = stockTransaction.StockActionDetail.Material.Name;
                itsMat.drugBarcode = stockTransaction.StockActionDetail.Material.Barcode;
                itsMat.lotNO = stockTransaction.LotNo;
                itsMat.serialNo = stockTransaction.SerialNo;
                itsMat.expirationDate = (DateTime)stockTransaction.ExpirationDate;
                itsMat.StockTransactionObjectID = stockTransaction.ObjectID;
                BindingList<ITSSendTransaction.GetITSTrx_Class> sendTransaction = ITSSendTransaction.GetITSTrx(stockTransaction.ObjectID);
                if (sendTransaction.Count > 0)
                {
                    if (sendTransaction[0].CurrentStateDefID == ITSSendTransaction.States.Cancelled)
                        itsMat.status = "Gönderim İptal Edildi.";
                    else
                        itsMat.status = "Gönderildi";
                }
                else
                {
                    itsMat.status = "Gönderilmedi";
                }
                sendOfITMaterial.Add(itsMat);
            }
            return sendOfITMaterial;
        }
        public List<ITSSendList> SendToIts(ITSSendInputDTO input)
        {
            List<ITSSendList> resultList = new List<ITSSendList>();

            foreach (ITSSendList sentItem in input.itsSendList)
            {
                ITSSendList resultItem = new ITSSendList();
                TTObjectContext context = new TTObjectContext(false);
                StockTransaction stockTransaction = (StockTransaction)context.GetObject(sentItem.StockTransactionObjectID, typeof(StockTransaction));
                BindingList<ITSSendTransaction.GetITSTrx_Class> sendBeforeCheck =
                ITSSendTransaction.GetITSTrx(stockTransaction.ObjectID, " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(ITSSendTransaction.States.Send));

                if (sendBeforeCheck.Count > 0)
                {
                    resultItem.status = "Gönderilmiş";
                    resultItem.drugName = sentItem.drugName;
                    resultItem.drugBarcode = sentItem.drugBarcode;
                    resultItem.lotNO = sentItem.lotNO;
                    resultItem.serialNo = sentItem.serialNo;
                    resultItem.expirationDate = (DateTime)sentItem.expirationDate;
                    resultList.Add(resultItem);
                }
                else
                {
                    try
                    {
                        List<XXXXXXSarfBildirimReceiverService.XXXXXXSarfTypeURUN> urunList = new List<XXXXXXSarfBildirimReceiverService.XXXXXXSarfTypeURUN>();
                        XXXXXXSarfBildirimReceiverService.XXXXXXSarfTypeURUN urun = new XXXXXXSarfBildirimReceiverService.XXXXXXSarfTypeURUN();
                        urun.GTIN = stockTransaction.StockActionDetail.Material.Barcode;
                        urun.SN = stockTransaction.SerialNo;
                        urun.XD = (DateTime)stockTransaction.ExpirationDate;
                        urun.BN = stockTransaction.LotNo;
                        urunList.Add(urun);

                        XXXXXXSarfBildirimReceiverService.XXXXXXSarfCevapType response = new XXXXXXSarfBildirimReceiverService.XXXXXXSarfCevapType();
                        XXXXXXSarfBildirimReceiverService.XXXXXXSarfType request = new XXXXXXSarfBildirimReceiverService.XXXXXXSarfType();
                        request.URUNLER = urunList.ToArray();
                        request.DT = "D";
                        request.FR = TTObjectClasses.SystemParameter.GetParameterValue("ITSGLN", "");
                        request.ISACIKLAMA = "";
                        response = XXXXXXSarfBildirimReceiverService.WebMethods.XXXXXXSarfBildirSync(Sites.SiteLocalHost, request);
                        if (string.IsNullOrEmpty(response.BILDIRIMID) == false)
                        {
                            ITSSendTransaction sendTransaction = new ITSSendTransaction(context);
                            sendTransaction.StockTransaction = stockTransaction;
                            sendTransaction.NotificationID = response.BILDIRIMID;
                            sendTransaction.TransactionDate = Common.RecTime();
                            sendTransaction.CurrentStateDefID = ITSSendTransaction.States.Send;
                            context.Save();
                            context.Dispose();

                            resultItem.drugName = sentItem.drugName;
                            resultItem.drugBarcode = sentItem.drugBarcode;
                            resultItem.lotNO = sentItem.lotNO;
                            resultItem.serialNo = sentItem.serialNo;
                            resultItem.expirationDate = (DateTime)sentItem.expirationDate;
                            resultItem.status = " Gönderildi.";

                            resultList.Add(resultItem);
                        }
                        else
                        {
                            resultItem.drugName = sentItem.drugName;
                            resultItem.drugBarcode = sentItem.drugBarcode;
                            resultItem.lotNO = sentItem.lotNO;
                            resultItem.serialNo = sentItem.serialNo;
                            resultItem.expirationDate = (DateTime)sentItem.expirationDate;
                            resultItem.status = "Gönderilemedi.";

                            resultList.Add(resultItem);
                        }


                    }
                    catch (Exception ex)
                    {
                        resultItem.drugName = sentItem.drugName;
                        resultItem.drugBarcode = sentItem.drugBarcode;
                        resultItem.lotNO = sentItem.lotNO;
                        resultItem.serialNo = sentItem.serialNo;
                        resultItem.expirationDate = (DateTime)sentItem.expirationDate;
                        resultItem.status = ex.Message;
                        resultList.Add(resultItem);
                    }
                }
            }
            return resultList;
        }


        public class XMLReadDocumentFile
        {
            public string xmlFileName { get; set; }

            public string xmlFile { get; set; }

            public StockAction stockAction { get; set; }
        }

        [HttpPost]
        public List<ITSSendList> GetItsReceiptNotificationFileRead(XMLReadDocumentFile documentFile)
        {
            List<ITSSendList> sendOfITMaterial = new List<ITSSendList>();
            try
            {
                XmlDocument document = new XmlDocument();
                documentFile.xmlFile = documentFile.xmlFile.Replace("-<", "<");
                document.LoadXml(documentFile.xmlFile);
                sendOfITMaterial = this.SendITSActionDetails(document);
            }
            catch (TTException ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.InnerException.Message.ToString());
                }
                else
                {
                    throw new Exception("Hata mesajı alınamadı. Sistem Yöneticisine başvurun.");
                }
            }
            return sendOfITMaterial;
        }

        public List<ITSSendList> SendITSActionDetails(XmlDocument document)
        {
            List<ITSSendList> itsSendList = new List<ITSSendList>();

            XmlNodeList xnList = document.SelectNodes("transfer/carrier/carrier/productList/serialNumber");
            XmlNodeList sourceGLNList = document.SelectNodes("transfer/sourceGLN");
            XmlNodeList destinationGLNList = document.SelectNodes("transfer/destinationGLN");
            XmlNodeList actionTypeList = document.SelectNodes("transfer/actionType");
            XmlNodeList productList = document.SelectNodes("transfer/carrier/productList");
            XmlNodeList serialList = document.SelectNodes("transfer/carrier/productList/serialNumber");
            XmlNodeList documentNumberList = document.SelectNodes("transfer/documentNumber");
            XmlNodeList documentDateList = document.SelectNodes("transfer/documentDate");

            string sourceGLN = string.Empty;
            string destinationGLN = string.Empty;
            string actionType = string.Empty;
            string GTIN = string.Empty;
            string lotNumber = string.Empty;
            string expirationDate = string.Empty;
            string serialNumber = string.Empty;
            string documentNumber = string.Empty;
            string documentDate = string.Empty;

            foreach (XmlNode xn in sourceGLNList)
                sourceGLN = xn.InnerText;

            foreach (XmlNode xn in destinationGLNList)
                destinationGLN = xn.InnerText;

            foreach (XmlNode xn in actionTypeList)
                actionType = xn.InnerText;

            foreach (XmlNode xn in documentNumberList)
                documentNumber = xn.InnerText;

            foreach (XmlNode xn in documentDateList)
                documentDate = xn.InnerText;



            foreach (XmlNode xn in productList)
            {
                TTObjectContext context = new TTObjectContext(false);

                IBindingList checkOfSystemPTS = context.QueryObjects(typeof(ChattelDocumentWithPurchase).Name, " ISPTSACTION = 1 AND WAYBILL ='" + documentNumber + "' AND CURRENTSTATE <> STATES.Cancelled");
                IBindingList checkWithAccOfSystemPTS = context.QueryObjects(typeof(ChattelDocumentInputWithAccountancy).Name, " ISPTSACTION = 1 AND WAYBILL ='" + documentNumber + "' AND CURRENTSTATE <> STATES.Cancelled");

                if (checkOfSystemPTS.Count > 0)
                {
                    ChattelDocumentWithPurchase chattelDocument = (ChattelDocumentWithPurchase)checkOfSystemPTS[0];
                    foreach (var item in chattelDocument.StockActionDetails)
                    {
                        ITSSendList itsSendItem = new ITSSendList();
                        itsSendItem.StockTransactionObjectID = item.StockTransactions.Select("INOUT = 1").FirstOrDefault().ObjectID;
                        itsSendItem.drugBarcode = item.Material.Barcode;
                        itsSendItem.drugName = item.Material.Name;
                        itsSendItem.status = "-";
                        itsSendItem.lotNO = item.StockTransactions.Select("INOUT = 1").FirstOrDefault().LotNo;
                        itsSendItem.serialNo = item.StockTransactions.Select("INOUT = 1").FirstOrDefault().SerialNo;
                        itsSendItem.expirationDate = (DateTime)item.StockTransactions.Select("INOUT = 1").FirstOrDefault().ExpirationDate;
                        itsSendList.Add(itsSendItem);
                    }
                }
                else if (checkWithAccOfSystemPTS.Count > 0)
                {

                    ChattelDocumentInputWithAccountancy chattelDocument = (ChattelDocumentInputWithAccountancy)checkWithAccOfSystemPTS[0];
                    foreach (var item in chattelDocument.StockActionDetails)
                    {
                        ITSSendList itsSendItem = new ITSSendList();
                        itsSendItem.StockTransactionObjectID = item.StockTransactions.Select("INOUT = 1").FirstOrDefault().ObjectID;
                        itsSendItem.drugBarcode = item.Material.Barcode;
                        itsSendItem.drugName = item.Material.Name;
                        itsSendItem.status = "-";
                        itsSendItem.lotNO = item.StockTransactions.Select("INOUT = 1").FirstOrDefault().LotNo;
                        itsSendItem.serialNo = item.StockTransactions.Select("INOUT = 1").FirstOrDefault().SerialNo;
                        itsSendItem.expirationDate = (DateTime)item.StockTransactions.Select("INOUT = 1").FirstOrDefault().ExpirationDate;
                        itsSendList.Add(itsSendItem);
                    }
                }
                else
                {
                    throw new Exception("Giriş İşlemi Bulnamadı Lütfen önce giriş işlemini tamamlayınız.");
                }
            }


            ITSSendInputDTO input = new ITSSendInputDTO();
            input.itsSendList = itsSendList;

            return this.SendToIts(input);
        }

        public List<UpdateMaterialPriceListDTO> GetMaterialPriceUpdate(int materialType)
        {
            List<UpdateMaterialPriceListDTO> materialPriceUpdateList = new List<UpdateMaterialPriceListDTO>();
            if (materialType == 0)
            {
                materialPriceUpdateList = UpdateMaterialPrice.UpdateMaterialPriceRQ(MaterialTypeEnum.Medicine).Select(p => new UpdateMaterialPriceListDTO()
                {
                    Code = p.Code,
                    MaterialName = p.Desciption,
                    ObjectID = p.ObjectID.Value,
                    DiscountPercent = p.DiscountPercent,
                    Price = p.Price

                }).ToList();

            }
            else
            {
                materialPriceUpdateList = UpdateMaterialPrice.UpdateMaterialPriceRQ(MaterialTypeEnum.Material).Select(p => new UpdateMaterialPriceListDTO()
                {
                    Code = p.Code,
                    MaterialName = p.Desciption,
                    ObjectID = p.ObjectID.Value,
                    DiscountPercent = p.DiscountPercent,
                    Price = p.Price

                }).ToList();

            }

            return materialPriceUpdateList;

        }

        public class InputPriceDTO
        {

            public DateTime startDateOfPrice { get; set; }
            public List<UpdateMaterialPriceListDTO> selectedMaterials { get; set; }
        }

        public class UpdateMaterialPriceListDTO
        {
            public Guid ObjectID { get; set; }
            public string Code { get; set; }
            public string MaterialName { get; set; }
            public double? Price { get; set; }
            public double? DiscountPercent { get; set; }
        }

        public void UpdateMaterialPriceForSeletectedMats(InputPriceDTO inputDTO)
        {
            foreach (UpdateMaterialPriceListDTO updateMaterial in inputDTO.selectedMaterials)
            {
                TTObjectContext context = new TTObjectContext(false);
                UpdateMaterialPrice upMat = context.GetObject<UpdateMaterialPrice>(updateMaterial.ObjectID);
                List<PricingDetailDVO> pricingDetailDefinitions = new List<PricingDetailDVO>();

                if (upMat.MaterialType == MaterialTypeEnum.Material)
                {
                    pricingDetailDefinitions = PricingDetailDefinitionForMaterial(context, upMat, inputDTO.startDateOfPrice);
                }
                else if (upMat.MaterialType == MaterialTypeEnum.Medicine)
                {
                    pricingDetailDefinitions = PricingDetailDefinitionForMedicine(context, upMat, inputDTO.startDateOfPrice);
                }

                // Eski fiyatlı oluşmuş AccountTransaction ların fiyatları güncellenir
                foreach (PricingDetailDVO pricingDetailDVO in pricingDetailDefinitions)
                {
                    if (pricingDetailDVO.newPricingDetailDefinition != null && pricingDetailDVO.oldPricingDetailDefinition != null)
                    {
                        // Yeni, Medulaya Gönderilmeyecek, ve Hizmet Kaydı Başarısız durumdaki ve fiyat başlangıç tarihinden sonraki accTrx ler
                        IBindingList accTrxListForPriceUpdate = context.QueryObjects("ACCOUNTTRANSACTION", "SUBACTIONMATERIAL IS NOT NULL "
                                     + " AND CURRENTSTATEDEFID IN ('934b9f03-d262-428d-8cb8-5e8ab927e3d5','33784c3f-d601-49c4-b8da-6fa502f6a9cf','6856675b-95fb-41cf-bade-6a1993626cc7')"
                                     + " AND PRICINGDETAIL = '" + pricingDetailDVO.oldPricingDetailDefinition.ObjectID.ToString()
                                     + "' AND TRANSACTIONDATE >= " + Globals.CreateNQLToDateParameter(upMat.DateStart.Value));

                        foreach (AccountTransaction accTrx in accTrxListForPriceUpdate)
                        {
                            if (accTrx.SubActionMaterial.Material is ConsumableMaterialDefinition)
                            {
                                // (SGK ve kurum payı) ise satış fiyatı + %12 , Malzeme için diğer durumlarda alış fiyatı kullanıldığı için güncelleme yapılmaz
                                if (accTrx.SubEpisodeProtocol.Payer.IsSGKAll && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                                    accTrx.UnitPrice = Math.Round((double)(pricingDetailDVO.newPricingDetailDefinition.Price.Value * 1.12), 2);
                            }
                            else
                            {
                                // ilaç ise direkt unitprice ı güncelle 
                                accTrx.UnitPrice = Math.Round((double)pricingDetailDVO.newPricingDetailDefinition.Price.Value, 2);
                            }
                        }
                    }
                    else if (pricingDetailDVO.newPricingDetailDefinition != null && pricingDetailDVO.oldPricingDetailDefinition == null) // Eski fiyatı olmayıp (PricingDetail i null) 0 fiyatlı ücretlenmişler için
                    {
                        IBindingList accTrxListForPriceUpdate = null;

                        if (upMat.MaterialType == MaterialTypeEnum.Material)
                        {
                            // Yeni, Medulaya Gönderilmeyecek, ve Hizmet Kaydı Başarısız durumdaki ve fiyat başlangıç tarihinden sonraki accTrx ler
                            accTrxListForPriceUpdate = context.QueryObjects("ACCOUNTTRANSACTION", "SUBACTIONMATERIAL IS NOT NULL AND PRICINGDETAIL IS NULL"
                                         + " AND CURRENTSTATEDEFID IN ('934b9f03-d262-428d-8cb8-5e8ab927e3d5','33784c3f-d601-49c4-b8da-6fa502f6a9cf','6856675b-95fb-41cf-bade-6a1993626cc7')"
                                         + " AND SUBACTIONMATERIAL.MATERIAL.CODE = '" + upMat.Code // Malzeme için Code dan bakılır
                                         + "' AND TRANSACTIONDATE >= " + Globals.CreateNQLToDateParameter(upMat.DateStart.Value));
                        }
                        else if (upMat.MaterialType == MaterialTypeEnum.Medicine)
                        {
                            // Yeni, Medulaya Gönderilmeyecek, ve Hizmet Kaydı Başarısız durumdaki ve fiyat başlangıç tarihinden sonraki accTrx ler
                            accTrxListForPriceUpdate = context.QueryObjects("ACCOUNTTRANSACTION", "SUBACTIONMATERIAL IS NOT NULL AND PRICINGDETAIL IS NULL"
                                         + " AND CURRENTSTATEDEFID IN ('934b9f03-d262-428d-8cb8-5e8ab927e3d5','33784c3f-d601-49c4-b8da-6fa502f6a9cf','6856675b-95fb-41cf-bade-6a1993626cc7')"
                                         + " AND SUBACTIONMATERIAL.MATERIAL.BARCODE = '" + upMat.Code // İlaç için Barcode dan bakılır
                                         + "' AND TRANSACTIONDATE >= " + Globals.CreateNQLToDateParameter(upMat.DateStart.Value));
                        }

                        foreach (AccountTransaction accTrx in accTrxListForPriceUpdate)
                        {
                            if (accTrx.SubActionMaterial.Material is ConsumableMaterialDefinition)
                            {
                                // (SGK ve kurum payı) ise satış fiyatı + %12 , Malzeme için diğer durumlarda alış fiyatı kullanıldığı için güncelleme yapılmaz
                                if (accTrx.SubEpisodeProtocol.Payer.IsSGKAll && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                                    accTrx.UnitPrice = Math.Round((double)(pricingDetailDVO.newPricingDetailDefinition.Price.Value * 1.12), 2);
                            }
                            else
                            {
                                // ilaç ise direkt unitprice ı güncelle 
                                accTrx.UnitPrice = Math.Round((double)pricingDetailDVO.newPricingDetailDefinition.Price.Value, 2);
                            }
                        }
                    }
                }
                upMat.Updated = true;
                context.Save();
                context.Dispose();
            }
        }

        public List<PricingDetailDVO> PricingDetailDefinitionForMaterial(TTObjectContext context, UpdateMaterialPrice updateMaterial, DateTime startDateOfPrice)
        {
            DateTime nowTime = Common.RecTime();
            List<PricingDetailDVO> pddReturnMaterialList = new List<PricingDetailDVO>();
            IBindingList pricingDetailDefinition = context.QueryObjects("PRICINGDETAILDEFINITION", "PRICINGLIST = 'bfe21eaf-3f71-4bbc-990b-066c5dfbd259' AND EXTERNALCODE='" + updateMaterial.Code
                                      + "' AND DATESTART < " + TTUtils.Globals.CreateNQLToDateParameter(nowTime) + " AND DATEEND > " + TTUtils.Globals.CreateNQLToDateParameter(nowTime));

            if (pricingDetailDefinition.Count == 0)
            {
                PricingDetailDefinition pdd = new PricingDetailDefinition(context);
                pdd.DateStart = startDateOfPrice;
                pdd.DateEnd = new DateTime(2100, 1, 1, 0, 0, 0);
                pdd.Description = updateMaterial.Desciption;
                pdd.CurrencyType = (CurrencyTypeDefinition)context.GetObject(new Guid("e3a4f2d5-4f74-406c-8258-37316ea8e9d1"), typeof(CurrencyTypeDefinition).Name);
                pdd.PricingList = (PricingListDefinition)context.GetObject(new Guid("bfe21eaf-3f71-4bbc-990b-066c5dfbd259"), typeof(PricingListDefinition).Name);
                pdd.PricingListGroup = (PricingListGroupDefinition)context.GetObject(new Guid("39d65056-3d97-4b85-94d7-0280c806391c"), typeof(PricingListGroupDefinition).Name);
                pdd.Price = updateMaterial.Price;
                pdd.ExternalCode = updateMaterial.Code;
                pdd.DiscountPercent = updateMaterial.DiscountPercent;

                IBindingList material = context.QueryObjects("MATERIAL", "CODE = '" + updateMaterial.Code + "'");
                if (material.Count > 0)
                {
                    MaterialPrice materialPrice = new MaterialPrice(context);
                    materialPrice.Material = (Material)material[0];
                    materialPrice.PricingDetail = pdd;
                }
                else
                {
                    throw new TTException(updateMaterial.Code + " Kodlu Malzeme Bulunamamıştır. Önce Malzemenin Tanımının Yapılması Gerekmektedir.");
                }


                PricingDetailDVO pricingDetailDVO = new PricingDetailDVO();
                pricingDetailDVO.oldPricingDetailDefinition = null;
                pricingDetailDVO.newPricingDetailDefinition = pdd;
                pddReturnMaterialList.Add(pricingDetailDVO);
            }
            else
            {
                foreach (PricingDetailDefinition pDet in pricingDetailDefinition)
                {
                    if (pDet.Price != updateMaterial.Price)
                    {
                        PricingDetailDefinition pdd = new PricingDetailDefinition(context);
                        pdd.DateStart = startDateOfPrice;
                        pdd.DateEnd = new DateTime(2100, 1, 1, 0, 0, 0);
                        pdd.Description = updateMaterial.Desciption;
                        pdd.CurrencyType = (CurrencyTypeDefinition)context.GetObject(new Guid("e3a4f2d5-4f74-406c-8258-37316ea8e9d1"), typeof(CurrencyTypeDefinition).Name);
                        pdd.PricingList = (PricingListDefinition)context.GetObject(new Guid("bfe21eaf-3f71-4bbc-990b-066c5dfbd259"), typeof(PricingListDefinition).Name);
                        pdd.PricingListGroup = (PricingListGroupDefinition)context.GetObject(new Guid("39d65056-3d97-4b85-94d7-0280c806391c"), typeof(PricingListGroupDefinition).Name);
                        pdd.Price = updateMaterial.Price;
                        pdd.ExternalCode = updateMaterial.Code;
                        pdd.DiscountPercent = updateMaterial.DiscountPercent;

                        DateTime nD = ((DateTime)startDateOfPrice).AddDays(-1);
                        pDet.DateEnd = new DateTime(nD.Year, nD.Month, nD.Day, 23, 59, 59);

                        IBindingList mPrice = context.QueryObjects("MATERIALPRICE", "PRICINGDETAIL='" + pDet.ObjectID + "'");

                        foreach (MaterialPrice item in mPrice)
                        {
                            MaterialPrice materialPrice = new MaterialPrice(context);
                            materialPrice.Material = item.Material;
                            materialPrice.PricingDetail = pdd;

                            // Malzemenin CurrentPrice ve discount u set edilir
                            item.Material.CurrentPrice = updateMaterial.Price;
                            item.Material.Discount = updateMaterial.DiscountPercent;
                        }

                        PricingDetailDVO pricingDetailDVO = new PricingDetailDVO();
                        pricingDetailDVO.oldPricingDetailDefinition = pDet;
                        pricingDetailDVO.newPricingDetailDefinition = pdd;
                        pddReturnMaterialList.Add(pricingDetailDVO);
                    }
                }
            }
            return pddReturnMaterialList;
        }


        public List<PricingDetailDVO> PricingDetailDefinitionForMedicine(TTObjectContext context, UpdateMaterialPrice updateMaterial, DateTime startDateOfPrice)
        {
            DateTime nowTime = Common.RecTime();
            List<PricingDetailDVO> pddReturnMedicineList = new List<PricingDetailDVO>();
            IBindingList drugList = context.QueryObjects("DRUGDEFINITION", "BARCODE = '" + updateMaterial.Code + "'");

            if (drugList.Count == 0)
                throw new TTException(updateMaterial.Code + " Kodlu İlaç Sistemde Bulunamamıştır. Önce İlaç Tanımının Yapılması Gerekmektedir.");

            foreach (DrugDefinition drug in drugList)
            {
                if (drug.CurrentPrice != updateMaterial.Price)
                {
                    PricingDetailDVO pricingDetailDVO = new PricingDetailDVO();
                    DateTime nD = ((DateTime)startDateOfPrice).AddDays(-1);
                    MaterialPrice oldMaterialPrice = drug.MaterialPrices.Where(x => x.PricingDetail.DateStart < nowTime &&
                                                                               x.PricingDetail.DateEnd > nowTime &&
                                                                               x.PricingDetail.ExternalCode == updateMaterial.Code &&
                                                                               x.PricingDetail.PricingList.ObjectID.ToString() == "57c5a43f-2083-433a-9f05-94c49c284436").FirstOrDefault();
                    if (oldMaterialPrice != null)
                    {
                        oldMaterialPrice.PricingDetail.DateEnd = new DateTime(nD.Year, nD.Month, nD.Day, 23, 59, 59);
                        pricingDetailDVO.oldPricingDetailDefinition = oldMaterialPrice.PricingDetail;
                    }
                    else
                        pricingDetailDVO.oldPricingDetailDefinition = null;

                    drug.CurrentPrice = updateMaterial.Price;
                    drug.Discount = updateMaterial.DiscountPercent;
                    double discount = Math.Round(drug.Discount.Value, 2, MidpointRounding.AwayFromZero);

                    double packageAmount = 1;
                    if (drug.PackageAmount != null && drug.PackageAmount != 0)
                        packageAmount = drug.PackageAmount.Value;

                    Currency dumyUnitPrice = (Currency)(drug.CurrentPrice * (1 - drug.Discount)) / packageAmount;
                    Currency UnitPrice = Math.Round((double)dumyUnitPrice, 2, MidpointRounding.AwayFromZero);
                    Currency PriceWithOutDiscount = Math.Round((drug.CurrentPrice.Value / packageAmount), 2, MidpointRounding.AwayFromZero);

                    PricingDetailDefinition pdd = new PricingDetailDefinition(context);
                    pdd.DateStart = startDateOfPrice;
                    pdd.DateEnd = new DateTime(2100, 1, 1, 0, 0, 0);
                    pdd.Description = updateMaterial.Desciption;
                    pdd.CurrencyType = (CurrencyTypeDefinition)context.GetObject(new Guid("e3a4f2d5-4f74-406c-8258-37316ea8e9d1"), typeof(CurrencyTypeDefinition).Name);
                    pdd.PricingList = (PricingListDefinition)context.GetObject(new Guid("57c5a43f-2083-433a-9f05-94c49c284436"), typeof(PricingListDefinition).Name);
                    pdd.PricingListGroup = (PricingListGroupDefinition)context.GetObject(new Guid("b3e200fb-9caa-405d-9d92-01f75948b452"), typeof(PricingListGroupDefinition).Name);
                    pdd.Price = UnitPrice;
                    pdd.ExternalCode = updateMaterial.Code;
                    pdd.DiscountPercent = discount;
                    pdd.PriceWithOutDiscount = PriceWithOutDiscount;

                    MaterialPrice materialPrice = new MaterialPrice(context);
                    materialPrice.Material = drug;
                    materialPrice.PricingDetail = pdd;

                    pricingDetailDVO.newPricingDetailDefinition = pdd;
                    pddReturnMedicineList.Add(pricingDetailDVO);
                }
            }
            return pddReturnMedicineList;
        }



        public class ITSDrugQRCode
        {
            public Guid drugObjectID { get; set; }
            public string lotNo { get; set; }
            public string seriNO { get; set; }
            public string sonucMesaj { get; set; }

        }

        public ITSDrugQRCode ITSQCodeRead(string qrCode)
        {
            TTObjectContext context = new TTObjectContext(false);
            Code2D code2D = new Code2D(qrCode);
            ITSDrugQRCode drug = new ITSDrugQRCode();
            BindingList<Material> drugs = Material.GetMaterialByBarcode(context, code2D.Barcode.ToString());
            if (drugs.Count > 0)
            {
                if (drugs[0] is DrugDefinition)
                {
                    drug.drugObjectID = drugs[0].ObjectID;
                    drug.lotNo = code2D.BatchNo;
                    drug.seriNO = code2D.PackageCode;
                    BindingList<StockTransaction.GetPTSInByMaterial_Class> stockTrxList =
                        StockTransaction.GetPTSInByMaterial(drug.drugObjectID, " AND LOTNO ='" + drug.lotNo + "' AND SERIALNO ='" + drug.seriNO + "'");
                    SarfBildirimi_Input input = new SarfBildirimi_Input();
                    if (stockTrxList.Count > 0)
                    {
                        input.StockTransaction = stockTrxList[0].ObjectID.Value;
                        drug.sonucMesaj = ITSSarfBildir(input);
                    }
                    else
                    {
                        throw new TTException("Stok Hateketi bulunamamıştır.");
                    }
                }
            }
            return drug;
        }


        public List<SarfIptalDVO_Output> ITSQCodeReadSarfIptal(string qrCode)
        {
            string filterExp = string.Empty;
            TTObjectContext context = new TTObjectContext(false);
            Code2D code2D = new Code2D(qrCode);
            List<SarfIptalDVO_Output> returnDrugList = new List<SarfIptalDVO_Output>();

            filterExp = " STOCKTRANSACTION.STOCKACTIONDETAIL.MATERIAL.BARCODE = '" + code2D.Barcode.ToString() + "'";
            filterExp += " AND STOCKTRANSACTION.LOTNO = '" + code2D.BatchNo + "'";
            filterExp += " AND STOCKTRANSACTION.SERIALNO = '" + code2D.PackageCode + "'";
            filterExp += " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(ITSSendTransaction.States.Send);

            IBindingList itsSendTrx = context.QueryObjects(typeof(ITSSendTransaction).Name, filterExp);
            if (itsSendTrx.Count > 0)
            {
                SarfIptalDVO_Output drug = new SarfIptalDVO_Output();
                ITSSendTransaction getITS = (ITSSendTransaction)itsSendTrx[0];
                drug.DrugBarcode = getITS.StockTransaction.StockActionDetail.Material.Barcode;
                drug.DrugLotNO = getITS.StockTransaction.LotNo;
                drug.DrugSerialNo = getITS.StockTransaction.SerialNo;
                drug.DrugName = getITS.StockTransaction.StockActionDetail.Material.Name;
                drug.DrugTransactionDate = (DateTime)getITS.TransactionDate;
                drug.StockTransaction = getITS.StockTransaction.ObjectID;
                returnDrugList.Add(drug);
            }
            return returnDrugList;
        }


        public string SarfIptalSelectedMaterials(List<SarfIptalDVO_Output> inputDVO)
        {
            string outputMessage = "";
            foreach (SarfIptalDVO_Output item in inputDVO)
            {
                TTObjectContext context = new TTObjectContext(false);
                BindingList<ITSSendTransaction.GetITSTrx_Class> itsList = ITSSendTransaction.GetITSTrx(item.StockTransaction);
                foreach (ITSSendTransaction.GetITSTrx_Class trx in itsList)
                {
                    ITSSendTransaction sendTransaction = (ITSSendTransaction)context.GetObject(trx.ObjectID.Value, typeof(ITSSendTransaction));
                    sendTransaction.CurrentStateDefID = ITSSendTransaction.States.Cancelled;
                    StockTransaction stockTransaction = (StockTransaction)context.GetObject(item.StockTransaction, typeof(StockTransaction));

                    ReturnNotification.ItsRequest request = new ReturnNotification.ItsRequest();
                    List<ReturnNotification.ItsRequestPRODUCT> productList = new List<ReturnNotification.ItsRequestPRODUCT>();

                    ReturnNotification.ItsRequestPRODUCT product = new ReturnNotification.ItsRequestPRODUCT();
                    product.GTIN = stockTransaction.StockActionDetail.Material.Barcode;
                    product.SN = stockTransaction.SerialNo;
                    product.XD = (DateTime)stockTransaction.ExpirationDate;
                    product.BN = stockTransaction.LotNo;
                    productList.Add(product);

                    request.PRODUCTS = productList.ToArray();
                    request.PRODUCTS[0] = product;
                    request.TOGLN = TTObjectClasses.SystemParameter.GetParameterValue("ITSGLN", "");

                    ReturnNotification.ItsResponse response = new ReturnNotification.ItsResponse();
                    response = ReturnNotification.WebMethods.sendReturnNotificationSync(Sites.SiteLocalHost, request);
                    outputMessage += response.NOTIFICATIONID;
                }
            }

            return outputMessage + " işlemleri bildirildi.";
        }

        public class SarfIptalDVO_Input
        {
            public Guid drugObjectID { get; set; }
            public DateTime trxStartDate { get; set; }
            public DateTime trxEndDate { get; set; }
            public string lotNo { get; set; }
            public string seriNo { get; set; }
        }

        public class SarfIptalDVO_Output
        {
            public string DrugName { get; set; }
            public string DrugBarcode { get; set; }
            public string DrugLotNO { get; set; }
            public string DrugSerialNo { get; set; }
            public DateTime DrugTransactionDate { get; set; }
            public Guid StockTransaction { get; set; }
        }

        public List<SarfIptalDVO_Output> GetITSDrugList(SarfIptalDVO_Input input)
        {
            string filterExp = string.Empty;
            if (input.drugObjectID != Guid.Empty)
            {
                filterExp += " AND STOCKTRANSACTION.STOCKACTIONDETAIL.MATERIAL = " + ConnectionManager.GuidToString(input.drugObjectID);
            }
            if (string.IsNullOrEmpty(input.lotNo) == false)
            {
                filterExp += " AND STOCKTRANSACTION.LOTNO = '" + input.lotNo + "'";
            }
            if (string.IsNullOrEmpty(input.seriNo) == false)
            {
                filterExp += " AND STOCKTRANSACTION.SERIALNO = '" + input.seriNo + "'";
            }

            try
            {
                List<SarfIptalDVO_Output> sarfIptalDVOs = new List<SarfIptalDVO_Output>();
                BindingList<ITSSendTransaction.ITSComplatedTRXRQ_Class> sendComplatedITSList = ITSSendTransaction.ITSComplatedTRXRQ(input.trxStartDate, input.trxEndDate, filterExp);
                foreach (ITSSendTransaction.ITSComplatedTRXRQ_Class itsSendTrx in sendComplatedITSList)
                {
                    SarfIptalDVO_Output output = new SarfIptalDVO_Output();
                    output.DrugName = itsSendTrx.Drugname;
                    output.DrugBarcode = itsSendTrx.Barcode;
                    output.DrugTransactionDate = (DateTime)itsSendTrx.TransactionDate;
                    output.DrugSerialNo = itsSendTrx.SerialNo;
                    output.DrugLotNO = itsSendTrx.LotNo;
                    output.StockTransaction = itsSendTrx.Stocktransaction.Value;
                    sarfIptalDVOs.Add(output);
                }
                return sarfIptalDVOs;

            }
            catch (Exception ex)
            {
                throw new TTException(ex.Message);
            }

        }

        public class ITSNotSerialNo
        {
            public string DrugName { get; set; }
            public string DrugBarcode { get; set; }
            public string DrugLotNO { get; set; }
            public string DrugSerialNo { get; set; }
            public DateTime TransactionDate { get; set; }
            public string PatientNameAndSurname { get; set; }
            public string ProtocolNo { get; set; }
            public Guid StockTransactionObjID { get; set; }
        }

        public class ITSNotSerialNoList_Input
        {
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            public Guid? selectedDrugID { get; set; }
        }

        public List<ITSNotSerialNo> ITSNotSerialNoList(ITSNotSerialNoList_Input input)
        {
            try
            {
                DateTime startDate = new DateTime(input.startDate.Year, input.startDate.Month, input.startDate.Day, 0, 0, 0);
                DateTime endDate = new DateTime(input.endDate.Year, input.endDate.Month, input.endDate.Day, 23, 59, 59);
                List<ITSNotSerialNo> returnList = new List<ITSNotSerialNo>();
                TTObjectContext context = new TTObjectContext(false);
                List<Guid> itsGuidList = new List<Guid>();
                if (input.selectedDrugID == null || input.selectedDrugID == Guid.Empty)
                {
                    IBindingList itsDrugList = context.QueryObjects(typeof(DrugDefinition).Name, " ISITSDRUG = 1 ");
                    foreach (DrugDefinition item in itsDrugList)
                    {
                        itsGuidList.Add(item.ObjectID);
                    }
                }
                else
                    itsGuidList.Add(input.selectedDrugID.Value);

                BindingList<StockTransaction.GetStockTrxNullLotAndSeriNo_Class> getTrx = StockTransaction.GetStockTrxNullLotAndSeriNo(itsGuidList, startDate, endDate);
                foreach (StockTransaction.GetStockTrxNullLotAndSeriNo_Class item in getTrx)
                {
                    StockTransaction stx = (StockTransaction)context.GetObject(item.ObjectID.Value, typeof(StockTransaction));
                    ITSNotSerialNo itsMat = new ITSNotSerialNo();

                    itsMat.TransactionDate = (DateTime)stx.TransactionDate;
                    itsMat.StockTransactionObjID = stx.ObjectID;
                    itsMat.DrugBarcode = stx.Stock.Material.Barcode;
                    itsMat.DrugLotNO = stx.LotNo;
                    itsMat.DrugName = stx.Stock.Material.Name;
                    itsMat.DrugSerialNo = stx.SerialNo;

                    if (stx.StockTransactionDefinition.ObjectID == new Guid("f8155e0a-8527-4886-89b8-3aa7c25bc267"))
                    {
                        if (((KSchedule)stx.StockActionDetail.StockAction).InPatientPhysicianApplication != null)
                        {
                            itsMat.ProtocolNo = ((KSchedule)stx.StockActionDetail.StockAction).InPatientPhysicianApplication.SubEpisode.ProtocolNo;
                            itsMat.PatientNameAndSurname = ((KSchedule)stx.StockActionDetail.StockAction).InPatientPhysicianApplication.Episode.Patient.Name + " " +
                                ((KSchedule)stx.StockActionDetail.StockAction).InPatientPhysicianApplication.Episode.Patient.Surname;
                        }
                    }
                    else
                    {
                        if (stx.StockActionDetail.SubActionMaterial.Count > 0)
                        {
                            itsMat.ProtocolNo = stx.StockActionDetail.SubActionMaterial[0].SubEpisode.ProtocolNo;
                            itsMat.PatientNameAndSurname = stx.StockActionDetail.SubActionMaterial[0].Episode.Patient.Name + " " +
                              stx.StockActionDetail.SubActionMaterial[0].Episode.Patient.Surname;
                        }
                    }

                    returnList.Add(itsMat);
                }
                return returnList;
            }
            catch (Exception ex)
            {
                throw new TTException(ex.Message);
            }
        }

        public string UpdateSerialNO(List<ITSNotSerialNo> selectedList)
        {
            try
            {
                foreach (ITSNotSerialNo item in selectedList)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    StockTransaction stx = (StockTransaction)context.GetObject(item.StockTransactionObjID, typeof(StockTransaction));
                    stx.LotNo = item.DrugLotNO;
                    stx.SerialNo = item.DrugSerialNo;
                    context.Save();
                    context.Dispose();
                }
                return "İşlem Başarılı";
            }
            catch (Exception ex)
            {
                throw new TTException(ex.Message);
            }
        }

        public class GetStockActionInDetails_Input
        {
            public string stockActionID { get; set; }
        }

        public class GetStockActionInDetails_Output
        {
            public bool error { get; set; }
            public string errorMessage { get; set; }
            public List<StockActionInDetailDTO> stockActionDetails { get; set; }
        }

        [HttpPost]
        public GetStockActionInDetails_Output GetStockActionInDetails(GetStockActionInDetails_Input input)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                GetStockActionInDetails_Output output = new GetStockActionInDetails_Output();
                output.stockActionDetails = new List<StockActionInDetailDTO>();
                IBindingList findStockAction = context.QueryObjects("STOCKACTION", "STOCKACTIONID = " + input.stockActionID);
                if (findStockAction.Count > 0)
                {
                    StockAction stockAction = (StockAction)findStockAction[0];
                    if (stockAction is ChattelDocumentWithPurchase || stockAction is ChattelDocumentInputWithAccountancy)
                    {
                        if (stockAction.CurrentStateDefID != ChattelDocumentWithPurchase.States.Cancelled || stockAction.CurrentStateDefID != ChattelDocumentInputWithAccountancy.States.Cancelled)
                        {

                            if (stockAction.DocumentRecordLogs.Select("MKYSSTATUS = 1").Count > 0)
                            {
                                output.error = true;
                                output.errorMessage = input.stockActionID + " nolu işlem MKYS ye gönderilmiş. İşleme devam etmek için MKYS işlemini iptal etmeniz gerekmektedir.";
                            }
                            else
                            {
                                if (stockAction is ChattelDocumentWithPurchase)
                                {
                                    ChattelDocumentWithPurchase purchase = (ChattelDocumentWithPurchase)stockAction;
                                    foreach (ChattelDocumentDetailWithPurchase purchaseDetail in purchase.ChattelDocumentDetailsWithPurchase)
                                    {
                                        StockActionInDetailDTO detail = new StockActionInDetailDTO();
                                        detail.Amount = purchaseDetail.Amount.Value;
                                        detail.Barcode = purchaseDetail.Material.Barcode;
                                        detail.DiscountAmount = purchaseDetail.DiscountAmount.Value;
                                        if (purchaseDetail.DiscountRate.HasValue)
                                            detail.DiscountRate = purchaseDetail.DiscountRate.Value;
                                        else
                                            detail.DiscountRate = 0;
                                        detail.DistributionTypeName = purchaseDetail.Material.StockCard.DistributionType.DistributionType;
                                        detail.MaterialName = purchaseDetail.Material.Name;
                                        detail.NATOStockNO = purchaseDetail.Material.StockCard.NATOStockNO;
                                        detail.ObjectID = purchaseDetail.ObjectID;
                                        detail.OldAmount = purchaseDetail.Amount.Value;
                                        detail.OldUnitPriceWithOutVat = purchaseDetail.UnitPriceWithOutVat.Value;
                                        detail.OldVatRate = purchaseDetail.VatRate.Value;
                                        detail.Price = purchaseDetail.Price.Value;
                                        detail.UnitPrice = purchaseDetail.UnitPrice.Value;
                                        detail.UnitPriceWithInVat = purchaseDetail.UnitPriceWithInVat.Value;
                                        detail.UnitPriceWithOutVat = purchaseDetail.UnitPriceWithOutVat.Value;
                                        detail.VatRate = purchaseDetail.VatRate.Value;
                                        output.stockActionDetails.Add(detail);
                                    }
                                }
                                if (stockAction is ChattelDocumentInputWithAccountancy)
                                {
                                    ChattelDocumentInputWithAccountancy inputAccountancy = (ChattelDocumentInputWithAccountancy)stockAction;
                                    foreach (ChattelDocumentInputDetailWithAccountancy inputDetail in inputAccountancy.ChattelDocumentInputDetailsWithAccountancy)
                                    {
                                        StockActionInDetailDTO detail = new StockActionInDetailDTO();
                                        detail.Amount = inputDetail.Amount.Value;
                                        detail.Barcode = inputDetail.Material.Barcode;
                                        if (inputDetail.DiscountAmount.HasValue)
                                            detail.DiscountAmount = inputDetail.DiscountAmount.Value;
                                        else
                                            detail.DiscountAmount = 0;
                                        if (inputDetail.DiscountRate.HasValue)
                                            detail.DiscountRate = inputDetail.DiscountRate.Value;
                                        else
                                            detail.DiscountRate = 0;
                                        detail.DistributionTypeName = inputDetail.Material.StockCard.DistributionType.DistributionType;
                                        detail.MaterialName = inputDetail.Material.Name;
                                        detail.NATOStockNO = inputDetail.Material.StockCard.NATOStockNO;
                                        detail.ObjectID = inputDetail.ObjectID;
                                        detail.OldAmount = inputDetail.Amount.Value;
                                        detail.OldUnitPriceWithOutVat = inputDetail.NotDiscountedUnitPrice.Value;
                                        detail.OldVatRate = inputDetail.VatRate.Value;
                                        detail.Price = inputDetail.Price.Value;
                                        detail.UnitPrice = inputDetail.UnitPrice.Value;
                                        detail.UnitPriceWithInVat = inputDetail.UnitPrice.Value;
                                        detail.UnitPriceWithOutVat = inputDetail.NotDiscountedUnitPrice.Value;
                                        detail.VatRate = inputDetail.VatRate.Value;
                                        output.stockActionDetails.Add(detail);
                                    }
                                }
                            }
                        }
                        else
                        {
                            output.error = true;
                            output.errorMessage = input.stockActionID + " nolu işlem iptal edilmiş.";
                        }
                    }
                    else
                    {
                        output.error = true;
                        output.errorMessage = input.stockActionID + " nolu işlem Satınlama Yolu İle Giriş veya Taşınır Mal Giriş işlemi değildir.";
                    }

                }
                else
                {
                    output.error = true;
                    output.errorMessage = input.stockActionID + " nolu işlem bulunamadı";
                }
                return output;
            }
        }


        public class UpdateStockActionInDetails_Input
        {
            public List<StockActionInDetailDTO> stockActionDetails { get; set; }
        }


        [HttpPost]
        public string UpdateStockActionInDetails(UpdateStockActionInDetails_Input input)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                string output = string.Empty;
                foreach (StockActionInDetailDTO detail in input.stockActionDetails)
                {
                    StockActionDetailIn stockActionDetailIn = (StockActionDetailIn)context.GetObject(detail.ObjectID, typeof(StockActionDetailIn));
                    if (stockActionDetailIn.StockAction.DocumentRecordLogs.Select("MKYSSTATUS = 1").Count > 0)
                    {
                        output = stockActionDetailIn.StockAction.StockActionID.ToString() + " numaralı işlem MKYS ye gönderilmiştir.Bu nedenle güncelleme işlemi durdurulmuştur.";
                    }
                    else
                    {
                        if (stockActionDetailIn is ChattelDocumentDetailWithPurchase || stockActionDetailIn is ChattelDocumentInputDetailWithAccountancy)
                        {
                            if (stockActionDetailIn is ChattelDocumentDetailWithPurchase)
                            {

                                ChattelDocumentDetailWithPurchase purchaseDetail = (ChattelDocumentDetailWithPurchase)stockActionDetailIn;
                                StockTransaction stockTransaction = purchaseDetail.StockTransactions.Select(string.Empty)[0];

                                Currency difrenceAmount = detail.Amount - purchaseDetail.Amount.Value;
                                if (difrenceAmount > 0)
                                {
                                    purchaseDetail.Amount = detail.Amount;
                                    stockTransaction.Amount += difrenceAmount;
                                    stockTransaction.Stock.Inheld += difrenceAmount;
                                    stockTransaction.Stock.TotalIn += difrenceAmount;
                                    stockTransaction.Stock.TotalInPrice += (BigCurrency)difrenceAmount * stockTransaction.UnitPrice;
                                    stockTransaction.Stock.StockLevels.Select(string.Empty)[0].Amount += difrenceAmount;
                                }

                                BigCurrency difrenceUnitPrice = detail.UnitPrice - purchaseDetail.UnitPrice.Value;
                                if (difrenceUnitPrice != 0)
                                {
                                    purchaseDetail.UnitPrice = detail.UnitPrice;
                                    Dictionary<Guid, StockTransaction> allTrx = new Dictionary<Guid, StockTransaction>();
                                    allTrx = StockTrxUpdateAction.FindStockTransactionAllTrx(stockTransaction, allTrx);
                                    foreach (KeyValuePair<Guid, StockTransaction> trx in allTrx)
                                    {
                                        if (trx.Value.CurrentStateDefID != StockTransaction.States.Cancelled)
                                        {
                                            trx.Value.UnitPrice = detail.UnitPrice;
                                            TrxStockPriceUpdate(trx.Value, false);
                                            IList colletedTrxs = context.QueryObjects("STOCKCOLLECTEDTRX", "STOCKTRANSACTION =" + ConnectionManager.GuidToString(trx.Value.ObjectID));
                                            if (colletedTrxs.Count > 0)
                                            {
                                                foreach (StockCollectedTrx colletedTrx in colletedTrxs)
                                                {
                                                    foreach (StockTransaction siibTrx in colletedTrx.StockActionDetail.StockTransactions.Select(string.Empty))
                                                    {
                                                        siibTrx.UnitPrice = detail.UnitPrice;
                                                        TrxStockPriceUpdate(siibTrx, false);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                purchaseDetail.DiscountAmount = detail.DiscountAmount;
                                purchaseDetail.DiscountRate = detail.DiscountRate;
                                purchaseDetail.NotDiscountedUnitPrice = detail.NotDiscountedUnitPrice;
                                purchaseDetail.Price = detail.Price;
                                purchaseDetail.UnitPriceWithInVat = detail.UnitPriceWithInVat;
                                purchaseDetail.UnitPriceWithOutVat = detail.UnitPriceWithOutVat;
                                purchaseDetail.VatRate = detail.VatRate;
                                purchaseDetail.TotalPriceNotDiscount = detail.NotDiscountedUnitPrice * (BigCurrency)detail.Amount;
                            }
                            if (stockActionDetailIn is ChattelDocumentInputDetailWithAccountancy)
                            {

                                ChattelDocumentInputDetailWithAccountancy inputAccountancyDetail = (ChattelDocumentInputDetailWithAccountancy)stockActionDetailIn;
                                StockTransaction stockTransaction = inputAccountancyDetail.StockTransactions.Select(string.Empty)[0];

                                Currency difrenceAmount = detail.Amount - inputAccountancyDetail.Amount.Value;
                                if (difrenceAmount > 0)
                                {
                                    inputAccountancyDetail.Amount = detail.Amount;
                                    stockTransaction.Amount += difrenceAmount;
                                    stockTransaction.Stock.Inheld += difrenceAmount;
                                    stockTransaction.Stock.TotalIn += difrenceAmount;
                                    stockTransaction.Stock.TotalInPrice += (BigCurrency)difrenceAmount * stockTransaction.UnitPrice;
                                    stockTransaction.Stock.StockLevels.Select(string.Empty)[0].Amount += difrenceAmount;
                                }

                                BigCurrency difrenceUnitPrice = detail.UnitPrice - inputAccountancyDetail.UnitPrice.Value;
                                if (difrenceUnitPrice != 0)
                                {
                                    inputAccountancyDetail.UnitPrice = detail.UnitPrice;
                                    Dictionary<Guid, StockTransaction> allTrx = new Dictionary<Guid, StockTransaction>();
                                    allTrx = StockTrxUpdateAction.FindStockTransactionAllTrx(stockTransaction, allTrx);
                                    foreach (KeyValuePair<Guid, StockTransaction> trx in allTrx)
                                    {
                                        if (trx.Value.CurrentStateDefID != StockTransaction.States.Cancelled)
                                        {
                                            trx.Value.UnitPrice = detail.UnitPrice;
                                            TrxStockPriceUpdate(trx.Value, false);
                                            IList colletedTrxs = context.QueryObjects("STOCKCOLLECTEDTRX", "STOCKTRANSACTION =" + ConnectionManager.GuidToString(trx.Value.ObjectID));
                                            if (colletedTrxs.Count > 0)
                                            {
                                                foreach (StockCollectedTrx colletedTrx in colletedTrxs)
                                                {
                                                    foreach (StockTransaction siibTrx in colletedTrx.StockActionDetail.StockTransactions.Select(string.Empty))
                                                    {
                                                        siibTrx.UnitPrice = detail.UnitPrice;
                                                        TrxStockPriceUpdate(siibTrx, false);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                inputAccountancyDetail.DiscountAmount = detail.DiscountAmount;
                                inputAccountancyDetail.DiscountRate = detail.DiscountRate;
                                inputAccountancyDetail.NotDiscountedUnitPrice = detail.UnitPriceWithOutVat;
                                inputAccountancyDetail.Price = detail.Price;
                                inputAccountancyDetail.VatRate = detail.VatRate;
                                inputAccountancyDetail.TotalPriceNotDiscount = detail.NotDiscountedUnitPrice * (BigCurrency)detail.Amount;
                            }
                            try
                            {
                                context.Save();
                                output = "Güncelleme Tamamlandı.";
                            }
                            catch (Exception ex)
                            {

                                output = ex.Message;
                            }
                        }
                        else
                        {
                            output = stockActionDetailIn.StockAction.StockActionID.ToString() + " nolu işlem Satınlama Yolu İle Giriş veya Taşınır Mal Giriş işlemi değildir.";
                        }
                    }
                }
                context.Dispose();
                return output;
            }
        }

        public class GetInStockTransactionForITS_Input
        {
            public string stockActionID { get; set; }
            public Guid? materialObjectID { get; set; }
            public Guid? storeObjectID { get; set; }
            public Guid? budgetTypeID { get; set; }
        }

        public class GetInStockTransactionForITS_Output
        {
            public bool error { get; set; }
            public string errorMessage { get; set; }
            public List<StockTransactionForITS> outTRX;
        }

        public class StockTransactionForITS
        {
            public Guid stockTransactionObjectID { get; set; }
            public string natoStockNo { get; set; }
            public string barcode { get; set; }
            public Guid materialObjectID { get; set; }
            public string materialName { get; set; }
            public string distributionTypeName { get; set; }
            public Currency inAmount { get; set; }
            public Currency restAmount { get; set; }
            public Currency readAmount { get; set; }
            public BigCurrency unitPrice { get; set; }
            public DateTime expirationDate { get; set; }
            public string lotNo { get; set; }
            public string serialNo { get; set; }
            public int? mkysHareketID { get; set; }
        }

        [HttpPost]
        public GetInStockTransactionForITS_Output GetInStockTransactionForITS(GetInStockTransactionForITS_Input input)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                GetInStockTransactionForITS_Output output = new GetInStockTransactionForITS_Output();
                output.outTRX = new List<StockTransactionForITS>();
                if (string.IsNullOrEmpty(input.stockActionID) == false)
                {
                    IBindingList stockactions = context.QueryObjects("STOCKACTION", "STOCKACTIONID =" + input.stockActionID);
                    if (stockactions.Count > 0)
                    {
                        if (((StockAction)stockactions[0]).IsPTSAction == true)
                        {
                            output.error = true;
                            output.errorMessage = input.stockActionID + " numaralı işlem zaten bir PTS işlemidir.";
                        }
                        else
                        {
                            if (stockactions[0] is ChattelDocumentWithPurchase || stockactions[0] is ChattelDocumentInputWithAccountancy)
                            {
                                StockAction stockAction = (StockAction)stockactions[0];
                                if (stockAction.DocumentRecordLogs.Where(x => x.MKYSStatus == MKYSControlEnum.CompletedSent).Any())
                                {
                                    foreach (ChattelDocumentDetailWithPurchase detail in stockAction.StockActionDetails)
                                    {
                                        if (detail.Material is DrugDefinition)
                                        {
                                            DrugDefinition drugDefinition = (DrugDefinition)detail.Material;
                                            if (drugDefinition.IsITSDrug == true)
                                            {
                                                foreach (StockTransaction trx in detail.StockTransactions.Select(string.Empty))
                                                {
                                                    if (trx.RestAmount.HasValue && trx.RestAmount.Value > 0)
                                                    {
                                                        StockTransactionForITS itsTrx = new StockTransactionForITS();
                                                        itsTrx.barcode = drugDefinition.Barcode;
                                                        itsTrx.distributionTypeName = drugDefinition.StockCard.DistributionType.DistributionType;
                                                        itsTrx.expirationDate = trx.ExpirationDate.Value;
                                                        itsTrx.inAmount = trx.Amount.Value;
                                                        itsTrx.lotNo = trx.LotNo;
                                                        itsTrx.materialObjectID = drugDefinition.ObjectID;
                                                        itsTrx.materialName = drugDefinition.Name;
                                                        itsTrx.mkysHareketID = trx.MKYS_StokHareketID;
                                                        itsTrx.natoStockNo = drugDefinition.StockCard.NATOStockNO;
                                                        itsTrx.restAmount = CurrencyType.ConvertFrom(trx.RestAmount).Value;
                                                        itsTrx.readAmount = itsTrx.restAmount;
                                                        itsTrx.unitPrice = trx.UnitPrice.Value;
                                                        itsTrx.serialNo = trx.SerialNo;
                                                        itsTrx.stockTransactionObjectID = trx.ObjectID;
                                                        output.outTRX.Add(itsTrx);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    output.error = true;
                                    output.errorMessage = input.stockActionID + " numaralı işlem MKYS ye bildirilmemiş.";
                                }

                            }
                            else
                            {
                                output.error = true;
                                output.errorMessage = input.stockActionID + " numaralı işlem bir giriş işlemi değildir.";
                            }
                        }
                    }
                    else
                    {
                        output.error = true;
                        output.errorMessage = input.stockActionID + " numaralı bir stok işlemi bulunamadı.";
                    }
                }
                else
                {
                    BindingList<Stock.GetStockFromStoreAndMaterial_Class> stocks = Stock.GetStockFromStoreAndMaterial(input.materialObjectID.Value, input.storeObjectID.Value);
                    if (stocks.Count > 0)
                    {
                        Stock stock = (Stock)context.GetObject(stocks[0].ObjectID.Value, typeof(Stock));
                        if (stock.Inheld > 0)
                        {
                            BindingList<StockTransaction.GetOutableInTrxForPTS_Class> restTrx = StockTransaction.GetOutableInTrxForPTS(stock.ObjectID, input.budgetTypeID.Value);
                            foreach (StockTransaction.GetOutableInTrxForPTS_Class inTRX in restTrx)
                            {
                                StockTransactionForITS itsTrx = new StockTransactionForITS();
                                itsTrx.barcode = inTRX.Barcode;
                                itsTrx.distributionTypeName = inTRX.DistributionType;
                                itsTrx.expirationDate = inTRX.ExpirationDate.Value;
                                itsTrx.inAmount = inTRX.Amount.Value;
                                itsTrx.lotNo = inTRX.LotNo;
                                itsTrx.materialObjectID = inTRX.Materialobjectid.Value;
                                itsTrx.materialName = inTRX.Name;
                                itsTrx.mkysHareketID = inTRX.MKYS_StokHareketID;
                                itsTrx.natoStockNo = inTRX.NATOStockNO;
                                itsTrx.restAmount = CurrencyType.ConvertFrom(inTRX.Restamount).Value;
                                itsTrx.readAmount = itsTrx.restAmount;
                                itsTrx.unitPrice = inTRX.UnitPrice.Value;
                                itsTrx.serialNo = inTRX.SerialNo;
                                itsTrx.stockTransactionObjectID = inTRX.ObjectID.Value;
                                output.outTRX.Add(itsTrx);
                            }
                        }
                        else
                        {
                            output.error = true;
                            output.errorMessage = "Seçmiş olduğunuz ilacın ilgili depoda mevcudu bulunmamaktadır.";
                        }
                    }
                    else
                    {
                        output.error = true;
                        output.errorMessage = "Seçmiş olduğunuz ilacın ilgili depoda mevcudu bulunmamaktadır.";
                    }
                }

                return output;
            }
        }

        [HttpPost]
        public StockTransactionForITS QRCodeRead(string qrCode)
        {
            TTObjectContext context = new TTObjectContext(false);
            Code2D code2D = new Code2D(qrCode);
            StockTransactionForITS drug = new StockTransactionForITS();
            BindingList<Material> drugs = Material.GetMaterialByBarcode(context, code2D.Barcode.ToString());
            if (drugs.Count > 0)
            {
                if (drugs[0] is DrugDefinition)
                {
                    DrugDefinition drugDefinition = (DrugDefinition)drugs[0];
                    drug.barcode = drugDefinition.Barcode;
                    drug.distributionTypeName = drugDefinition.StockCard.DistributionType.DistributionType;
                    drug.expirationDate = code2D.ExpirationDate;
                    if (drugDefinition.PackageAmount.HasValue)
                        drug.inAmount = drugDefinition.PackageAmount.Value;
                    else
                        drug.inAmount = 0;
                    drug.restAmount = drug.inAmount;
                    drug.lotNo = code2D.BatchNo;
                    drug.materialName = drugDefinition.Name;
                    drug.materialObjectID = drugDefinition.ObjectID;
                    drug.natoStockNo = drugDefinition.StockCard.NATOStockNO;
                    drug.serialNo = code2D.PackageCode;
                }
            }
            return drug;
        }

        public class CreateITSFixedAction_Input
        {
            public Guid StoreObjectID { get; set; }
            public List<StockTransactionForITS> outTrxs;
            public List<StockTransactionForITS> inTrxs;
        }

        public class CreateITSFixedAction_Output
        {
            public bool result { get; set; }
            public string resultMessage { get; set; }
        }

        [HttpPost]
        public CreateITSFixedAction_Output CreateITSFixedAction(CreateITSFixedAction_Input input)
        {
            CreateITSFixedAction_Output output = new CreateITSFixedAction_Output();
            TTObjectContext context = new TTObjectContext(false);
            try
            {
                Store store = (Store)context.GetObject(input.StoreObjectID, typeof(Store));
                ITSFixed itsFixed = new ITSFixed(context);
                itsFixed.Store = store;
                itsFixed.CurrentStateDefID = ITSFixed.States.New;
                foreach (StockTransactionForITS outTrx in input.outTrxs)
                {
                    ITSFixedMaterialOut fixedMaterialOut = new ITSFixedMaterialOut(context);
                    Material material = (Material)context.GetObject(outTrx.materialObjectID, typeof(Material));
                    StockTransaction stockTransaction = (StockTransaction)context.GetObject(outTrx.stockTransactionObjectID, typeof(StockTransaction));
                    if (itsFixed.BudgetTypeDefinition == null)
                        itsFixed.BudgetTypeDefinition = stockTransaction.BudgetTypeDefinition;
                    fixedMaterialOut.Material = material;
                    fixedMaterialOut.Amount = outTrx.restAmount;
                    fixedMaterialOut.StockLevelType = StockLevelType.NewStockLevel;
                    fixedMaterialOut.Status = StockActionDetailStatusEnum.New;
                    fixedMaterialOut.UserSelectedOutableTrx = true;
                    OuttableLot outtableLot = new OuttableLot(context);
                    outtableLot.Amount = outTrx.restAmount;
                    outtableLot.BudgetTypeName = stockTransaction.BudgetTypeDefinition.Name;
                    outtableLot.ExpirationDate = outTrx.expirationDate;
                    outtableLot.isUse = true;
                    outtableLot.LotNo = outTrx.lotNo;
                    outtableLot.RestAmount = outTrx.restAmount;
                    outtableLot.SerialNo = outTrx.serialNo;
                    outtableLot.StockActionDetailOut = fixedMaterialOut;
                    outtableLot.TrxObjectID = outTrx.stockTransactionObjectID;
                    fixedMaterialOut.ITSFixed = itsFixed;
                }

                foreach (StockTransactionForITS inTrx in input.inTrxs)
                {
                    ITSFixedMaterialIn fixedMaterialIn = new ITSFixedMaterialIn(context);
                    Material material = (Material)context.GetObject(inTrx.materialObjectID, typeof(Material));
                    fixedMaterialIn.Material = material;
                    fixedMaterialIn.Amount = inTrx.inAmount;
                    fixedMaterialIn.ExpirationDate = inTrx.expirationDate;
                    fixedMaterialIn.LotNo = inTrx.lotNo;
                    fixedMaterialIn.SerialNo = inTrx.serialNo;
                    fixedMaterialIn.UnitPrice = inTrx.unitPrice;
                    fixedMaterialIn.NotDiscountedUnitPrice = inTrx.unitPrice;
                    fixedMaterialIn.OutStockTransactionID = inTrx.stockTransactionObjectID;
                    fixedMaterialIn.StockLevelType = StockLevelType.NewStockLevel;
                    fixedMaterialIn.Status = StockActionDetailStatusEnum.New;
                    fixedMaterialIn.ITSFixed = itsFixed;
                }

                context.Update();
                itsFixed.CurrentStateDefID = ITSFixed.States.Completed;
                context.Save();

                TTObjectContext updateContext = new TTObjectContext(false);
                ITSFixed updateFixed = (ITSFixed)context.GetObject(itsFixed.ObjectID, typeof(ITSFixed));
                foreach (ITSFixedMaterialIn inDetail in updateFixed.ITSFixedInMaterials)
                {
                    StockTransaction transaction = (StockTransaction)updateContext.GetObject(inDetail.OutStockTransactionID.Value, typeof(StockTransaction));
                    foreach (StockTransaction trx in inDetail.StockTransactions.Select(string.Empty))
                    {
                        trx.MKYS_StokHareketID = transaction.MKYS_StokHareketID;
                    }
                }
                updateContext.Save();
                updateContext.Dispose();
                output.result = true;
                output.resultMessage = "İşlem Başarılı";
            }
            catch (Exception ex)
            {
                output.result = false;
                output.resultMessage = ex.Message;
            }
            finally
            {
                context.Dispose();
            }
            return output;
        }

        public class BudgetTypeDefinitionDTO
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
        }


        [HttpPost]
        public List<BudgetTypeDefinitionDTO> GetBudgetTypes()
        {
            List<BudgetTypeDefinitionDTO> output = new List<BudgetTypeDefinitionDTO>();
            TTObjectContext context = new TTObjectContext(false);
            BindingList<BudgetTypeDefinition> budgetTypeList = context.QueryObjects<BudgetTypeDefinition>();
            foreach (BudgetTypeDefinition budgetType in budgetTypeList)
            {
                BudgetTypeDefinitionDTO outputItem = new BudgetTypeDefinitionDTO();
                outputItem.ObjectID = budgetType.ObjectID;
                outputItem.Name = budgetType.Name;
                output.Add(outputItem);
            }
            return output;
        }



        public class GetCovid19StockAction_Input
        {
            public string covid19StockActionID { get; set; }
            public string covid19TifID { get; set; }
            public Guid covid19StoreID { get; set; }

        }
        public class GetCovid19StockAction_Output
        {
            public int ActionType { get; set; }

            public DateTime? DocumentDateTime { get; set; }
            public DateTime AuctionDate { get; set; }
            public string RegistrationAuctionNo { get; set; }
            public DateTime ExaminationReportDate { get; set; }
            public string ExaminationReportNo { get; set; }
            public DateTime WaybillDate { get; set; }
            public string Waybill { get; set; }
            public string Description { get; set; }
            public string MKYS_TeslimAlan { get; set; }
            public string MKYS_TeslimEden { get; set; }
            public Accountancy Accountancy { get; set; }
            public List<StockActionDetailCovid19> DetailsCovid19 { get; set; }
            public Supplier Supplier { get; set; }
            public int? ReceiptNumber { get; set; }

            public Guid StockActionObjectID { get; set; }
            public Guid DocumentRecordLogID { get; set; }
            public string DocumentRecordLogNumber { get; set; }
            public string StockActionID { get; set; }

        }

        public class StockActionDetailCovid19
        {
            public string MaterialName { get; set; }
            public string Barcode { get; set; }
            public string NatoStockNo { get; set; }
            public Guid MaterialObjectID { get; set; }
            public Guid StockActionDetailID { get; set; } //makbuzDetayKayitNo
            public BigCurrency? NotDiscountedUnitPrice { get; set; } //vergisizBirimFiyat
            public BigCurrency? DiscountRate { get; set; }//indirimOrani
            public long? VatRate { get; set; }//kdvOrani
            public int? MKYS_StokHareketID { get; set; }
            public double? Amount { get; set; }

        }



        [HttpPost]
        public GetCovid19StockAction_Output GetCovid19StockAction(GetCovid19StockAction_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                GetCovid19StockAction_Output output = new GetCovid19StockAction_Output();
                output.DetailsCovid19 = new List<StockActionDetailCovid19>();

                IBindingList purchaseAction;
                if (String.IsNullOrEmpty(input.covid19TifID) == false)
                {
                    purchaseAction = objectContext.QueryObjects("DOCUMENTRECORDLOG", "DOCUMENTRECORDLOGNUMBER=" + input.covid19TifID + " AND STOCKACTION.STORE = " + ConnectionManager.GuidToString(input.covid19StoreID) + "AND STOCKACTION.MKYS_ETEDARIKTURU in (50,51) AND RECEIPTNUMBER IS NOT NULL ");
                }
                else if (String.IsNullOrEmpty(input.covid19StockActionID) == false)
                {
                    StockAction st = objectContext.QueryObjects<StockAction>("STOCKACTIONID='" + input.covid19StockActionID + "'").FirstOrDefault();
                    if (st != null)
                        purchaseAction = objectContext.QueryObjects("DOCUMENTRECORDLOG", "STOCKACTION=" + ConnectionManager.GuidToString(st.ObjectID) + " AND STOCKACTION.STORE = " + ConnectionManager.GuidToString(input.covid19StoreID) + "AND STOCKACTION.MKYS_ETEDARIKTURU in(51,50) AND RECEIPTNUMBER IS NOT NULL");
                    else
                        throw new Exception("Güncellenebilecek bir fiş bulunamadı.");
                }
                else
                {
                    throw new Exception("İşlem Numarsı Olmadan İşlem Yapılamaz.");
                }


                if (purchaseAction.Count > 0)
                {
                    DocumentRecordLog documentRecordLog = (DocumentRecordLog)purchaseAction[0];
                    output.StockActionID = documentRecordLog.StockAction.StockActionID.ToString();
                    output.ReceiptNumber = documentRecordLog.ReceiptNumber;
                    output.StockActionObjectID = documentRecordLog.StockAction.ObjectID;
                    output.DocumentDateTime = documentRecordLog.DocumentDateTime;
                    output.DocumentRecordLogID = documentRecordLog.ObjectID;
                    output.DocumentRecordLogNumber = documentRecordLog.DocumentRecordLogNumber.ToString();

                    if (documentRecordLog.StockAction is ChattelDocumentInputWithAccountancy)
                    {
                        ChattelDocumentInputWithAccountancy cdiwa = (ChattelDocumentInputWithAccountancy)documentRecordLog.StockAction;
                        output.Waybill = cdiwa.Waybill;
                        output.WaybillDate = (DateTime)cdiwa.WaybillDate;
                        output.MKYS_TeslimAlan = cdiwa.MKYS_TeslimAlan;
                        output.MKYS_TeslimEden = cdiwa.MKYS_TeslimEden;
                        output.Accountancy = cdiwa.Accountancy;
                        output.Description = cdiwa.Description;
                        output.ActionType = 1;

                        foreach (ChattelDocumentInputDetailWithAccountancy detail in cdiwa.ChattelDocumentInputDetailsWithAccountancy)
                        {
                            StockActionDetailCovid19 detailCovid19 = new StockActionDetailCovid19();
                            detailCovid19.DiscountRate = detail.DiscountRate;
                            detailCovid19.MaterialName = detail.Material.Name;
                            detailCovid19.MaterialObjectID = detail.Material.ObjectID;
                            detailCovid19.MKYS_StokHareketID = detail.MKYS_StokHareketID;
                            detailCovid19.NotDiscountedUnitPrice = detail.NotDiscountedUnitPrice;
                            detailCovid19.StockActionDetailID = detail.ObjectID;
                            detailCovid19.VatRate = detail.VatRate;
                            detailCovid19.Amount = detail.Amount;
                            detailCovid19.Barcode = detail.Material.Barcode;
                            detailCovid19.NatoStockNo = detail.Material.StockCard.NATOStockNO;
                            output.DetailsCovid19.Add(detailCovid19);
                        }
                    }
                    else if (documentRecordLog.StockAction is ChattelDocumentWithPurchase)
                    {
                        ChattelDocumentWithPurchase purchase = (ChattelDocumentWithPurchase)documentRecordLog.StockAction;
                        output.Supplier = purchase.Supplier;
                        output.AuctionDate = (DateTime)purchase.AuctionDate;
                        output.Description = purchase.Description;
                        output.ExaminationReportDate = (DateTime)purchase.ExaminationReportDate;
                        output.ExaminationReportNo = purchase.ExaminationReportNo;
                        output.MKYS_TeslimAlan = purchase.MKYS_TeslimAlan;
                        output.MKYS_TeslimEden = purchase.MKYS_TeslimEden;
                        output.RegistrationAuctionNo = purchase.RegistrationAuctionNo;
                        output.Waybill = purchase.Waybill;
                        output.WaybillDate = (DateTime)purchase.WaybillDate;
                        output.ActionType = 2;
                        foreach (ChattelDocumentDetailWithPurchase detail in purchase.ChattelDocumentDetailsWithPurchase)
                        {
                            StockActionDetailCovid19 detailCovid19 = new StockActionDetailCovid19();
                            detailCovid19.DiscountRate = detail.DiscountRate;
                            detailCovid19.MaterialName = detail.Material.Name;
                            detailCovid19.MaterialObjectID = detail.Material.ObjectID;
                            detailCovid19.MKYS_StokHareketID = detail.MKYS_StokHareketID;
                            detailCovid19.NotDiscountedUnitPrice = detail.NotDiscountedUnitPrice;
                            detailCovid19.StockActionDetailID = detail.ObjectID;
                            detailCovid19.VatRate = detail.VatRate;
                            detailCovid19.Amount = detail.Amount;
                            detailCovid19.Barcode = detail.Material.Barcode;
                            detailCovid19.NatoStockNo = detail.Material.StockCard.NATOStockNO;
                            output.DetailsCovid19.Add(detailCovid19);
                        }

                    }
                    else
                    {
                        throw new Exception("Güncellenebilecek bir fiş bulunamadı.");
                    }
                }
                else
                {
                    throw new Exception("Güncellenebilecek bir fiş bulunamadı.");
                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }


        public class UpdateStockActionCovid19_Input
        {
            public Guid StockActionObjectID { get; set; }
            public Guid DocumentRecordLogID { get; set; }
            public GetCovid19StockAction_Output covid19ActionChange { get; set; }
            public string mkyspass { get; set; }
        }


        [HttpPost]
        public string UpdateStockActionCovid19MKYS(UpdateStockActionCovid19_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    StockAction st = objectContext.GetObject<StockAction>(input.StockActionObjectID);
                    DocumentRecordLog recordLog = objectContext.GetObject<DocumentRecordLog>(input.DocumentRecordLogID);
                    recordLog.DocumentDateTime = input.covid19ActionChange.DocumentDateTime;
                    recordLog.MKYSStatus = MKYSControlEnum.Completed;

                    MkysServis.makbuzUpdateItem updateItem = new MkysServis.makbuzUpdateItem();
                    updateItem.ayniyatMakbuzId = recordLog.ReceiptNumber.Value;
                    updateItem.butceTurID = (MkysServis.EButceTurID)(int)recordLog.BudgeType.Value;
                    updateItem.dayanagiBelgeNo = input.covid19ActionChange.Waybill;
                    updateItem.dayanagiBelgeTarihi = input.covid19ActionChange.WaybillDate;
                    updateItem.depoKayitNo = (int)((MainStoreDefinition)st.Store).StoreRecordNo;
                    updateItem.makbuzNo = Int32.Parse(recordLog.DocumentRecordLogNumber.Value.ToString());
                    updateItem.fisAciklama = input.covid19ActionChange.Description;
                    updateItem.teslimAlan = input.covid19ActionChange.MKYS_TeslimAlan;
                    updateItem.teslimEden = input.covid19ActionChange.MKYS_TeslimEden;
                    updateItem.makbuzTarihi = (DateTime)recordLog.DocumentDateTime;
                    updateItem.hbysID = TTObjectClasses.SystemParameter.GetParameterValue("MKYS_HBYS_ID", "Atlas");

                    MkysServis.makbuzDetayUpdateItem makbuzDetayList = new MkysServis.makbuzDetayUpdateItem();
                    List<MkysServis.makbuzDetayUpdateItem> makbuzDetayUpdateItem = new List<MkysServis.makbuzDetayUpdateItem>();

                    if (st is ChattelDocumentInputWithAccountancy) //taşınır giriş
                    {
                        ChattelDocumentInputWithAccountancy chattelInput = (ChattelDocumentInputWithAccountancy)st;
                        chattelInput.Accountancy = input.covid19ActionChange.Accountancy;
                        chattelInput.Description = input.covid19ActionChange.Description;
                        chattelInput.MKYS_TeslimAlan = input.covid19ActionChange.MKYS_TeslimAlan;
                        chattelInput.MKYS_TeslimEden = input.covid19ActionChange.MKYS_TeslimEden;
                        chattelInput.Waybill = input.covid19ActionChange.Waybill;
                        chattelInput.WaybillDate = input.covid19ActionChange.WaybillDate;

                        if (((MainStoreDefinition)st.Store).GoodsResponsible != null && ((MainStoreDefinition)st.Store).GoodsResponsible.UniqueNo != null)
                            updateItem.firmaVergiKayitNo = ((MainStoreDefinition)st.Store).GoodsResponsible.UniqueNo;


                        var details = chattelInput.StockActionDetails;

                        foreach (StockActionDetailCovid19 detailItem in input.covid19ActionChange.DetailsCovid19)
                        {
                            ChattelDocumentInputDetailWithAccountancy detail = (ChattelDocumentInputDetailWithAccountancy)details.FirstOrDefault(x => x.ObjectID == detailItem.StockActionDetailID);
                            detail.NotDiscountedUnitPrice = detailItem.NotDiscountedUnitPrice;
                            detail.VatRate = detailItem.VatRate;
                            detail.DiscountRate = detailItem.DiscountRate;

                            var kdvlifiyat = detailItem.NotDiscountedUnitPrice + (detailItem.NotDiscountedUnitPrice * (BigCurrency)Convert.ToDouble(detailItem.VatRate) / 100);
                            var indirimlifiyat = kdvlifiyat - (kdvlifiyat * detailItem.DiscountRate / 100);

                            detail.TotalDiscountAmount = (kdvlifiyat * detailItem.DiscountRate / 100) * detailItem.Amount;
                            detail.TotalPriceNotDiscount = detailItem.Amount * kdvlifiyat;
                            detail.UnitPrice = indirimlifiyat;

                            MkysServis.makbuzDetayUpdateItem updateDetailItem = new MkysServis.makbuzDetayUpdateItem();
                            updateDetailItem.indirimOrani = detail.DiscountRate;
                            updateDetailItem.kdvOrani = detail.VatRate;
                            updateDetailItem.vergisizBirimFiyat = detail.NotDiscountedUnitPrice.Value;


                            StockTransaction stockTransaction = detail.StockTransactions.Select(string.Empty)[0];
                            updateDetailItem.hbysMakbuzDetayKayitNo = stockTransaction.ObjectID.ToString();
                            updateDetailItem.makbuzDetayKayitNo = ((StockActionDetailIn)stockTransaction.StockActionDetail).VoucherDetailRecordNo.Value; //MKYSDen geleceği için şimdilik hatalı gelebilir.

                            Dictionary<Guid, StockTransaction> allTrx = new Dictionary<Guid, StockTransaction>();
                            allTrx = StockTrxUpdateAction.FindStockTransactionAllTrx(stockTransaction, allTrx).Where(x => x.Value.CurrentStateDefID != StockTransaction.States.Cancelled).ToDictionary(x => x.Key, x => x.Value);
                            foreach (KeyValuePair<Guid, StockTransaction> trx in allTrx)
                            {
                                trx.Value.UnitPrice = detail.UnitPrice;
                                TrxStockPriceUpdate(trx.Value, false);
                                IList colletedTrxs = objectContext.QueryObjects("STOCKCOLLECTEDTRX", "STOCKTRANSACTION =" + ConnectionManager.GuidToString(trx.Value.ObjectID));
                                if (colletedTrxs.Count > 0)
                                {
                                    foreach (StockCollectedTrx colletedTrx in colletedTrxs)
                                    {
                                        foreach (StockTransaction siibTrx in colletedTrx.StockActionDetail.StockTransactions.Select(string.Empty))
                                        {
                                            siibTrx.UnitPrice = detail.UnitPrice;
                                            TrxStockPriceUpdate(siibTrx, false);
                                        }
                                    }
                                }
                            }
                            makbuzDetayUpdateItem.Add(updateDetailItem);
                            
                        }
                    }
                    else //satınalma
                    {
                        ChattelDocumentWithPurchase chattelInput = (ChattelDocumentWithPurchase)st;
                        chattelInput.AuctionDate = input.covid19ActionChange.AuctionDate;
                        chattelInput.RegistrationAuctionNo = input.covid19ActionChange.RegistrationAuctionNo;
                        chattelInput.ExaminationReportDate = input.covid19ActionChange.ExaminationReportDate;
                        chattelInput.ExaminationReportNo = input.covid19ActionChange.ExaminationReportNo;
                        chattelInput.WaybillDate = input.covid19ActionChange.WaybillDate;
                        chattelInput.Waybill = input.covid19ActionChange.Waybill;
                        chattelInput.Description = input.covid19ActionChange.Description;
                        chattelInput.MKYS_TeslimAlan = input.covid19ActionChange.MKYS_TeslimAlan;
                        chattelInput.MKYS_TeslimEden = input.covid19ActionChange.MKYS_TeslimEden;
                        chattelInput.Supplier = input.covid19ActionChange.Supplier;

                        if (chattelInput.Supplier.TaxNo != null)
                        {
                            updateItem.firmaVergiKayitNo = chattelInput.Supplier.TaxNo.ToString();
                        }
                        else if (chattelInput.Supplier.SupplierNumber != null)
                        {
                            updateItem.firmaVergiKayitNo = chattelInput.Supplier.SupplierNumber.ToString();
                        }
                        updateItem.ihaleKayitNo = input.covid19ActionChange.RegistrationAuctionNo;
                        updateItem.ihaleTarihi = input.covid19ActionChange.AuctionDate;
                        updateItem.muayeneNo = input.covid19ActionChange.ExaminationReportNo;
                        updateItem.muayeneTarihi = input.covid19ActionChange.ExaminationReportDate;


                        var details = chattelInput.StockActionDetails;

                        foreach (StockActionDetailCovid19 detailItem in input.covid19ActionChange.DetailsCovid19)
                        {
                            ChattelDocumentDetailWithPurchase detail = (ChattelDocumentDetailWithPurchase)details.FirstOrDefault(x => x.ObjectID == detailItem.StockActionDetailID);
                            detail.NotDiscountedUnitPrice = detailItem.NotDiscountedUnitPrice;
                            detail.VatRate = detailItem.VatRate;
                            detail.DiscountRate = detailItem.DiscountRate;

                            var kdvlifiyat = detailItem.NotDiscountedUnitPrice + (detailItem.NotDiscountedUnitPrice * (BigCurrency)Convert.ToDouble(detailItem.VatRate) / 100);
                            var indirimlifiyat = kdvlifiyat - (kdvlifiyat * detailItem.DiscountRate / 100);

                            detail.UnitPriceWithOutVat = detailItem.NotDiscountedUnitPrice;
                            detail.UnitPriceWithInVat = kdvlifiyat;

                            detail.TotalPriceNotDiscount = detailItem.Amount * kdvlifiyat;
                            detail.TotalDiscountAmount = (kdvlifiyat * detailItem.DiscountRate / 100) * detailItem.Amount;
                            detail.UnitPrice = indirimlifiyat;

                            MkysServis.makbuzDetayUpdateItem updateDetailItem = new MkysServis.makbuzDetayUpdateItem();
                            updateDetailItem.indirimOrani = detail.DiscountRate;
                            updateDetailItem.kdvOrani = detail.VatRate;
                            updateDetailItem.vergisizBirimFiyat = detail.UnitPriceWithOutVat.Value;

                            StockTransaction stockTransaction = detail.StockTransactions.Select(string.Empty)[0];
                            updateDetailItem.hbysMakbuzDetayKayitNo = stockTransaction.ObjectID.ToString();
                            updateDetailItem.makbuzDetayKayitNo = ((StockActionDetailIn)stockTransaction.StockActionDetail).VoucherDetailRecordNo.Value; //MKYSDen geleceği için şimdilik hatalı gelebilir.

                            Dictionary<Guid, StockTransaction> allTrx = new Dictionary<Guid, StockTransaction>();
                            allTrx = StockTrxUpdateAction.FindStockTransactionAllTrx(stockTransaction, allTrx).Where(x => x.Value.CurrentStateDefID != StockTransaction.States.Cancelled).ToDictionary(x => x.Key, x => x.Value);
                            foreach (KeyValuePair<Guid, StockTransaction> trx in allTrx)
                            {
                                trx.Value.UnitPrice = detail.UnitPrice;
                                TrxStockPriceUpdate(trx.Value, false);
                                IList colletedTrxs = objectContext.QueryObjects("STOCKCOLLECTEDTRX", "STOCKTRANSACTION =" + ConnectionManager.GuidToString(trx.Value.ObjectID));
                                if (colletedTrxs.Count > 0)
                                {
                                    foreach (StockCollectedTrx colletedTrx in colletedTrxs)
                                    {
                                        foreach (StockTransaction siibTrx in colletedTrx.StockActionDetail.StockTransactions.Select(string.Empty))
                                        {
                                            siibTrx.UnitPrice = detail.UnitPrice;
                                            TrxStockPriceUpdate(siibTrx, false);
                                        }
                                    }
                                }
                            }
                            makbuzDetayUpdateItem.Add(updateDetailItem);
                        }
                    }
                    updateItem.makbuzDetayList = makbuzDetayUpdateItem.ToArray();

                    MkysServis.makbuzUpdateSonuc covid19MakbuzUpdateSonuc = MkysServis.WebMethods.covid19makbuzUpdateSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, input.mkyspass, updateItem);
                    if (covid19MakbuzUpdateSonuc.basariDurumu == true)
                    {
                        recordLog.MKYSStatus = MKYSControlEnum.CompletedSent;
                        objectContext.Save();
                        return "İşlem Tamamlandı. MKYS MESAJI :" + covid19MakbuzUpdateSonuc.mesaj;
                    }
                    else
                    {
                        return "MKYS' ye gönderilmesi tarafında hata alındı!! HATA MESAJI: " + covid19MakbuzUpdateSonuc.mesaj;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
