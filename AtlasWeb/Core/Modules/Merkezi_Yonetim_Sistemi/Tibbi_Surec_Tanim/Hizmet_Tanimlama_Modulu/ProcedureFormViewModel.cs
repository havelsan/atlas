//$3897D7DD
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Collections.Generic;
using System.ComponentModel;
using AutoMapper;
using static TTObjectClasses.MedulaYardimciIslemler;

namespace Core.Controllers
{
    public partial class ProcedureDefinitionServiceController
    {

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public object GetSubProcedureDefinitions([FromBody] DataSourceLoadOptions loadOptions, [FromQuery] string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var result1 = objectContext.QueryObjects<ProcedureDefinition>("ObjectID = '" + key + "'").ToList().Select(x => new { ObjectID = x.ObjectID, Name = x.Name }).FirstOrDefault();
                    return result1;
                }
            }
            else
            {
                LoadResult result = null;
                string searchText = loadOptions.Params.searchText;
                if (!string.IsNullOrEmpty(searchText))
                {
                    searchText = "NAME_SHADOW like '%" + searchText.ToUpperInvariant() + "%'";
                }
                using (var objectContext = new TTObjectContext(true))
                {
                    TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetAllProcedureDefinitions"];
                    Dictionary<string, object> paramList = new Dictionary<string, object>();
                    result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, searchText);
                }
                return result;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public object GetPricingListListDefinition([FromBody] DataSourceLoadOptions loadOptions, [FromQuery] string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var result1 = objectContext.QueryObjects<PricingListDefinition>("ObjectID = '" + key + "'").ToList().Select(x => new { ObjectID = x.ObjectID, Name = x.Name }).FirstOrDefault();
                    return result1;
                }
            }
            else
            {
                LoadResult result = null;

                string definitionName = loadOptions.Params.definitionName;
                string searchText = loadOptions.Params.searchText;
                string injectionFilter = loadOptions.Params.injectionFilter;
                using (var objectContext = new TTObjectContext(true))
                {
                    TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName.Trim()];
                    TTList resultList = TTList.NewList(objectContext, listDef, string.Empty);


                    result = DevexpressLoader.Load(objectContext, resultList, loadOptions, new Dictionary<string, object>(), searchText, injectionFilter, String.Empty);
                }
                return result;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public object GetPricingListGroupListDefinition([FromBody] DataSourceLoadOptions loadOptions, [FromQuery] string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var result1 = objectContext.QueryObjects<PricingListGroupDefinition>("ObjectID = '" + key + "'").ToList().Select(x => new { ObjectID = x.ObjectID, Description = x.Description, ExternalCode = x.ExternalCode }).FirstOrDefault();
                    return result1;
                }
            }
            else
            {
                LoadResult result = null;

                string definitionName = loadOptions.Params.definitionName;
                string searchText = loadOptions.Params.searchText;
                string injectionFilter = loadOptions.Params.injectionFilter;
                using (var objectContext = new TTObjectContext(true))
                {
                    TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName.Trim()];
                    TTList resultList = TTList.NewList(objectContext, listDef, string.Empty);

                    result = DevexpressLoader.Load(objectContext, resultList, loadOptions, new Dictionary<string, object>(), searchText, injectionFilter, String.Empty);
                    if (loadOptions.Params.pricingListGroup != null && loadOptions.Params.pricingListGroup.Count > 0)
                    {
                        List<Guid?> pricingListGroupIDs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Guid?>>(loadOptions.Params.pricingListGroup.ToString());
                        string pricingListGroupFilter = Common.CreateFilterExpressionOfGuidList("WHERE 1=1", "OBJECTID", pricingListGroupIDs.Where(x => x.HasValue).Select(x => x.Value).ToList());

                        var result1 = PricingListGroupDefinition.GetPricingListGroupDefinitions(objectContext, pricingListGroupFilter);
                        var data = result.GetData<PricingListGroupDefinition.GetPricingListGroupDefinitions_Class>();
                        foreach (var item in result1)
                        {
                            if (!data.Any(x => x.ObjectID == item.ObjectID))
                                data.Add(item);
                        }
                        result.data = data;
                    }
                }
                return result;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<PricingDetailDefinitionGridModel> SaveAndUpdatePricingDetail(PricingDetailDefinitionSave_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                if (input.PriceDetails == null)
                    return null;

                if (input.PriceDetails.Any(x => x.StartDate.HasValue == false || x.EndDate.HasValue == false))
                    throw new TTException("Fiyat Baþlangýç ve Bitiþ tarihleri boþ olamaz.");
                if (input.PriceDetails.Any(x => string.IsNullOrWhiteSpace(x.Description)))
                    throw new TTException("Fiyat Adý boþ olamaz.");
                if (input.PriceDetails.Any(x => string.IsNullOrWhiteSpace(x.ExternalCode)))
                    throw new TTException("Fiyat Kodu boþ olamaz.");
                if (input.PriceDetails.Any(x => x.Price.HasValue == false))
                    throw new TTException("Hizmet Fiyatý boþ olamaz.");
                #region Update
                List<PricingDetailDefinitionGridModel> updateList = input.PriceDetails.Where(x => x.IsNew == false).ToList();
                foreach (PricingDetailDefinitionGridModel item in updateList)
                {
                    PricingDetailDefinition pricingDetailDefinition = objectContext.GetObject<PricingDetailDefinition>(item.ObjectID);
                    pricingDetailDefinition.ExternalCode = item.ExternalCode;
                    pricingDetailDefinition.Description = item.Description;
                    pricingDetailDefinition["PRICINGLIST"] = item.PricingList;
                    pricingDetailDefinition["PRICINGLISTGROUP"] = item.PricingListGroup;
                    pricingDetailDefinition.DateStart = item.StartDate;
                    pricingDetailDefinition.DateEnd = item.EndDate;
                    pricingDetailDefinition.Price = item.Price;
                    pricingDetailDefinition.Point = item.Point;
                    pricingDetailDefinition.InPatientDiscountPercent = item.InPatientDiscountPercent;
                    pricingDetailDefinition.OutPatientDiscountPercent = item.OutPatientDiscountPercent;
                }
                #endregion

                #region New
                List<PricingDetailDefinitionGridModel> newList = input.PriceDetails.Where(x => x.IsNew == true).ToList();
                if (newList.Count > 0)
                {
                    List<ProcedureDefinition> procedureDefinitionList = new List<ProcedureDefinition>();
                    ProcedureDefinition procedureDefinition = objectContext.GetObject<ProcedureDefinition>(input.ProcedureDefObjectID);
                    procedureDefinitionList.Add(procedureDefinition);
                    if (input.CreateProcedurePriceWithSameCode && !string.IsNullOrWhiteSpace(procedureDefinition.SUTCode))
                    {
                        List<ProcedureDefinition> sameCodeProcDefs = objectContext.QueryObjects<ProcedureDefinition>(" SUTCODE = '" + procedureDefinition.SUTCode + "' AND ISACTIVE = 1 AND OBJECTID <> '" + procedureDefinition.ObjectID + "'").ToList();
                        if (sameCodeProcDefs.Count > 0)
                            procedureDefinitionList.AddRange(sameCodeProcDefs);
                    }

                    foreach (PricingDetailDefinitionGridModel item in newList)
                    {
                        PricingDetailDefinition pricingDetailDefinition = new PricingDetailDefinition(objectContext);
                        pricingDetailDefinition.ExternalCode = item.ExternalCode;
                        pricingDetailDefinition.Description = item.Description;
                        pricingDetailDefinition["PRICINGLIST"] = item.PricingList;
                        pricingDetailDefinition["PRICINGLISTGROUP"] = item.PricingListGroup;
                        pricingDetailDefinition.DateStart = item.StartDate;
                        pricingDetailDefinition.DateEnd = item.EndDate;
                        pricingDetailDefinition.Price = item.Price;
                        pricingDetailDefinition.Point = item.Point;
                        pricingDetailDefinition.InPatientDiscountPercent = item.InPatientDiscountPercent;
                        pricingDetailDefinition.OutPatientDiscountPercent = item.OutPatientDiscountPercent;
                        pricingDetailDefinition.CurrencyType = CurrencyTypeDefinition.GetByQref(objectContext, "TL")[0];
                        pricingDetailDefinition.IsActive = true;

                        foreach (ProcedureDefinition procedure in procedureDefinitionList)
                        {
                            ProcedurePriceDefinition procedurePrice = new ProcedurePriceDefinition(objectContext);
                            procedurePrice.PricingDetail = pricingDetailDefinition;
                            procedurePrice.ProcedureObject = procedure;
                        }

                        List<PricingDetailDefinition> oldPricingDetailDefinitionList = objectContext.QueryObjects<PricingDetailDefinition>(" EXTERNALCODE = '" + pricingDetailDefinition.ExternalCode + "' AND PRICINGLIST = '" + pricingDetailDefinition.PricingList.ObjectID + "' AND OBJECTID <> '" + pricingDetailDefinition.ObjectID + "'").ToList();
                        foreach (PricingDetailDefinition oldPrice in oldPricingDetailDefinitionList)
                        {
                            if (oldPrice.DateEnd > pricingDetailDefinition.DateStart)
                            {
                                oldPrice.DateEnd = pricingDetailDefinition.DateStart.Value.AddSeconds(-1);
                            }
                        }
                    }
                }
                objectContext.Save();
                return GetPricingDetailDefsForProcedure(input.ProcedureDefObjectID).pricingDetailDefinitionGridModel;
                #endregion
            }
        }

        [HttpPost]
        public List<SUTPriceDefinitionGridModel> GetChangedSUTPrice(GetSUTChanges_Input inputDVO)
        {
            IEnumerable<PricingDetailDefinition> pricingDetailDefinitionList = null;

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                PricingListDefinition pricingListDefinition = objectContext.GetObject<PricingListDefinition>(new Guid("47466669-d190-4d13-af74-21a23d8a5ddb"), false);
                if (pricingListDefinition == null)
                    throw new TTException("SUT Hizmet Fiyat Listesi tanýmý bulunamadý.");

                //Aktif olan ve Fiyat Listesi "SUT Hizmet Fiyat Listesi" olan PricingDetailDefinition listesi
                pricingDetailDefinitionList = objectContext.QueryObjects<PricingDetailDefinition>("GETDATE() BETWEEN DATESTART AND DATEEND AND PRICINGLIST = '" + pricingListDefinition.ObjectID + "'");
            }

            MedulaYardimciIslemler.guncelSutSorguGirisDVO input = new MedulaYardimciIslemler.guncelSutSorguGirisDVO();

            input.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu(); // Pursaklar : 11060019 , Gaziler : 11069941

            if (inputDVO.InputDate.HasValue)
                input.tarih = inputDVO.InputDate.Value.ToString("dd/MM/yyyy");
            else
                input.tarih = null;

            MedulaYardimciIslemler.guncelSutSorguCevapDVO medulaResult = MedulaYardimciIslemler.WebMethods.guncelSutKodlariSync(Sites.SiteLocalHost, input);
            List<MedulaYardimciIslemler.sutFiyatDVO> sutHizmetList = null;
            if (medulaResult.sonucKodu == "0000" && medulaResult.sutKodlari != null)
                sutHizmetList = medulaResult.sutKodlari.Where(x => x.turu != 5).ToList();
            else
                return null;

            string[] turAdiArray = new string[]
            {
                "Muayene iþlemi",
                "Yatak Ýþlemleri",
                "Diþ iþlemi",
                "Konsultasyon",
                "Malzemeler",
                "Ameliyat ve giriþimler",
                "Tetkik ve radyoloji bilgileri",
                "Tahlil iþlemleri",
                "Diðer iþlemler",
                "Kan iþlemler"
            };

            List<SUTTuru> sutProcedureTypes = new List<SUTTuru>();

            for (int i = 0; i < 10; i++)
            {
                string turAdi = string.Empty;

                sutProcedureTypes.Add(new SUTTuru
                {
                    turu = i + 1,
                    turAdi = turAdiArray[i]
                });
            }

            List<SUTPriceDefinitionGridModel> gridModel = new List<SUTPriceDefinitionGridModel>();

            var queryNotExistsProcedures = from sh in sutHizmetList
                                           join pdd in pricingDetailDefinitionList
                                           on sh.sutKodu equals pdd.ExternalCode into t
                                           from od in t.DefaultIfEmpty()
                                           where od == null
                                           select new SUTPriceDefinitionGridModel
                                           {
                                               adi = sh.adi,
                                               fiyat = sh.fiyat,
                                               listeAdi = sh.listeAdi,
                                               eskiFiyat = null,
                                               IsExists = false,
                                               IsExistText = "Yok",
                                               PricingDetailDefObjectID = null,
                                               sutKodu = sh.sutKodu,
                                               turAdi = sutProcedureTypes.FirstOrDefault(x => x.turu == sh.turu).turAdi,
                                               turu = sh.turu
                                           };

            var query = from pdd in pricingDetailDefinitionList
                        join sh in sutHizmetList
                        on pdd.ExternalCode equals sh.sutKodu
                        into t
                        from od in t.DefaultIfEmpty()
                        where od != null && od.fiyat != pdd.Price
                        select new SUTPriceDefinitionGridModel
                        {
                            adi = od.adi,
                            eskiFiyat = pdd.Price,
                            fiyat = od.fiyat,
                            gecerlilikTarihi = od.gecerlilikTarihi,
                            listeAdi = od.listeAdi,
                            sutKodu = od.sutKodu,
                            turAdi = sutProcedureTypes.FirstOrDefault(x => x.turu == od.turu).turAdi,
                            turu = od.turu,
                            PricingDetailDefObjectID = pdd.ObjectID
                        };

            //List<sutFiyatDVO> notExistsProcedures = queryNotExistsProcedures.ToList();
            //Sistemde kayýtlý olan hizmetlere ait ProcedurePriceDefinition ile medula servisinden dönen hizmetlerin kesiþimi.
            gridModel.AddRange(query);
            gridModel.AddRange(queryNotExistsProcedures);

            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<sutFiyatDVO, SUTPriceDefinitionGridModel>();
            });

            //foreach (var item in pricingDetailDefinitionList)
            //{
            //    var medulatSUT = sutHizmetList.FirstOrDefault(x => x.sutKodu == item.ExternalCode);
            //    SUTPriceDefinitionGridModel model = new SUTPriceDefinitionGridModel();
            //    model = Mapper.Map<sutFiyatDVO, SUTPriceDefinitionGridModel>(medulatSUT);
            //    model.PricingDetailDefObjectID = item.ObjectID;
            //    model.turAdi = sutProcedureTypes.FirstOrDefault(x => x.turu == medulatSUT.turu).turAdi;
            //    model.eskiFiyat = item.Price;
            //    gridModel.Add(model);
            //}

            //foreach (var item in notExistsProcedures)
            //{
            //    SUTPriceDefinitionGridModel model = new SUTPriceDefinitionGridModel();
            //    model = Mapper.Map<sutFiyatDVO, SUTPriceDefinitionGridModel>(item);
            //    model.PricingDetailDefObjectID = null;
            //    model.turAdi = sutProcedureTypes.FirstOrDefault(x => x.turu == item.turu).turAdi;
            //    model.eskiFiyat = null;
            //    model.IsExists = false;
            //    model.IsExistText = "Yok";
            //    gridModel.Add(model);
            //}

            return gridModel;
        }

        [HttpPost]
        public bool UpdateSUTPrices(UpdatePriceDefinition_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                if (input != null && input.UpdateList != null && input.UpdateList.Count > 0)
                {
                    #region PricingListDefinition

                    PricingListDefinition pricingListDefinition = objectContext.GetObject<PricingListDefinition>(new Guid("47466669-d190-4d13-af74-21a23d8a5ddb"), false);
                    if (pricingListDefinition == null)
                        throw new TTException("SUT Hizmet Fiyat Listesi tanýmý bulunamadý.");
                    #endregion

                    //Yeni fiyat oluþturmak için seçilen hizmetlere ait eski fiyat bilgileri. (Bu fiyatlarýn DateEnd'i güncellenecek.)
                    string filter = Common.CreateFilterExpressionOfGuidList("", "OBJECTID", input.UpdateList.Select(x => x.PricingDetailDefObjectID.Value).ToList());
                    var pricingDetailDefList = objectContext.QueryObjects<PricingDetailDefinition>(filter);
                    //

                    foreach (var oldPricingDetailDef in pricingDetailDefList)
                    {
                        oldPricingDetailDef.DateEnd = input.StartDate.AddSeconds(-1);

                        SUTPriceDefinitionGridModel newPrice = input.UpdateList.FirstOrDefault(x => x.PricingDetailDefObjectID.Value == oldPricingDetailDef.ObjectID);

                        PricingDetailDefinition pricingDetailDefinition = new PricingDetailDefinition(objectContext);
                        pricingDetailDefinition.ExternalCode = newPrice.sutKodu;
                        pricingDetailDefinition.Description = oldPricingDetailDef.Description;
                        pricingDetailDefinition.PricingList = pricingListDefinition;
                        pricingDetailDefinition.PricingListGroup = oldPricingDetailDef.PricingListGroup;
                        pricingDetailDefinition.DateStart = input.StartDate;
                        pricingDetailDefinition.DateEnd = new DateTime(2100, 1, 1);
                        pricingDetailDefinition.Price = newPrice.fiyat;
                        pricingDetailDefinition.Point = Math.Round(newPrice.fiyat / 0.593, 2);
                        pricingDetailDefinition.InPatientDiscountPercent = oldPricingDetailDef.InPatientDiscountPercent;
                        pricingDetailDefinition.OutPatientDiscountPercent = oldPricingDetailDef.OutPatientDiscountPercent;
                        pricingDetailDefinition.CurrencyType = CurrencyTypeDefinition.GetByQref(objectContext, "TL")[0];
                        pricingDetailDefinition.IsActive = true;

                        //Eski fiyat ile eþlemiþ diðer hizmetler yeni fiyat ile tekrar eþleþtirilir.
                        foreach (ProcedurePriceDefinition ppd in oldPricingDetailDef.ProcedurePrice.Select(""))
                        {
                            ProcedurePriceDefinition procedurePrice = new ProcedurePriceDefinition(objectContext);
                            procedurePrice.PricingDetail = pricingDetailDefinition;
                            procedurePrice.ProcedureObject = ppd.ProcedureObject;
                            procedurePrice.IsActive = true;
                        }
                    }

                    objectContext.Save();
                }
                return true;
            }
        }

        [HttpPost]
        public bool UpdateSUT()
        {
            MedulaYardimciIslemler.guncelSutSorguGirisDVO input = new MedulaYardimciIslemler.guncelSutSorguGirisDVO();

            input.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu(); // Pursaklar : 11060019 , Gaziler : 11069941
            input.tarih = null;

            MedulaYardimciIslemler.guncelSutSorguCevapDVO medulaResult = MedulaYardimciIslemler.WebMethods.guncelSutKodlariSync(Sites.SiteLocalHost, input);
            List<MedulaYardimciIslemler.sutFiyatDVO> sutHizmetList = null;
            if (medulaResult.sonucKodu == "0000" && medulaResult.sutKodlari != null)
            {
                //Medula SUT Hizmet Listesi
                sutHizmetList = medulaResult.sutKodlari.Where(x => x.turu != 5).ToList();
                if (sutHizmetList != null && sutHizmetList.Count > 0)
                {
                    using (TTObjectContext objectContext = new TTObjectContext(false))
                    {
                        SUTHizmetEKEnum? GetEKEnum(string listeAdi)
                        {
                            SUTHizmetEKEnum? sutHizmetEKEnum = null;
                            switch (listeAdi)
                            {
                                case "EK-2A":
                                    sutHizmetEKEnum = SUTHizmetEKEnum.EK2A;
                                    break;
                                case "EK-2A-2":
                                    sutHizmetEKEnum = SUTHizmetEKEnum.EK2A2;
                                    break;
                                case "EK-2B":
                                    sutHizmetEKEnum = SUTHizmetEKEnum.EK2B;
                                    break;
                                case "EK-2C":
                                    sutHizmetEKEnum = SUTHizmetEKEnum.EK2C;
                                    break;
                                case "EK-2C(*)":
                                    sutHizmetEKEnum = SUTHizmetEKEnum.EK2CStar;
                                    break;
                                case "EK-2Ç":
                                    sutHizmetEKEnum = SUTHizmetEKEnum.EK2Tooth;
                                    break;
                                default:
                                    sutHizmetEKEnum = SUTHizmetEKEnum.Other;
                                    break;
                            }
                            return sutHizmetEKEnum;
                        }

                        IEnumerable<SUT> sutList = objectContext.QueryObjects<SUT>("");

                        //SUT tablsounda mevcut olan medula hizmetleri (güncellenecekler)
                        var instersectionQuery = from sut in sutList
                                                 join sutHizmet in sutHizmetList on
                                                 sut.Kod equals sutHizmet.sutKodu into t
                                                 from od in t.DefaultIfEmpty()
                                                 where od != null
                                                 select sut;

                        var intersection = instersectionQuery.ToList();
                        foreach (var sut in intersection)
                        {
                            var medulaHizmet = sutHizmetList.FirstOrDefault(x => x.sutKodu == sut.Kod);
                            //Ýlk harf büyük sonrasý küçük
                            sut.Ad = medulaHizmet.adi.First() + medulaHizmet.adi.Substring(1).ToLower();
                            sut.Ek = GetEKEnum(medulaHizmet.listeAdi);
                            sut.Kod = medulaHizmet.sutKodu;
                            sut.Fiyat = medulaHizmet.fiyat;
                            sut.Puan = Math.Round(medulaHizmet.fiyat / 0.593, 2);
                            sut.IsActive = true;
                        }

                        //SUT tablosunda olmayan medula hizmetleri (Yeni kayýt edilecekler)
                        var notExistsInSUTQuery = from sutHizmet in sutHizmetList
                                                  join sut in sutList
                                                  on sutHizmet.sutKodu equals sut.Kod
                                                  into t
                                                  from od in t.DefaultIfEmpty()
                                                  where od == null
                                                  select sutHizmet;
                        var notExistsInSUT = notExistsInSUTQuery.ToList();
                        foreach (var medulaHizmet in notExistsInSUT)
                        {
                            SUT sut = new SUT(objectContext);
                            //Ýlk harf büyük sonrasý küçük
                            sut.Ad = medulaHizmet.adi.Substring(0, 1) + medulaHizmet.adi.Substring(1).ToLower();
                            sut.Kod = medulaHizmet.sutKodu;
                            sut.Tarih = DateTime.Now;
                            sut.Fiyat = medulaHizmet.fiyat;
                            sut.Puan = Math.Round(medulaHizmet.fiyat / 0.593, 2);
                            sut.Ek = GetEKEnum(medulaHizmet.listeAdi);
                            sut.IsActive = true;
                        }

                        //Medula hizmetleri içerisinde olmayan ama SUT tablosunda olan hizmetler. (Pasife çekilecek)
                        var notExistsInMedulaSUTHizmetQuery = from sut in sutList
                                                              join sutHizmet in sutHizmetList
                                                              on sut.Kod equals sutHizmet.sutKodu
                                                              into t
                                                              from od in t.DefaultIfEmpty()
                                                              where od == null
                                                              select sut;
                        var notExistsInMedulaSUTHizmet = notExistsInMedulaSUTHizmetQuery.ToList();
                        foreach (var sut in notExistsInMedulaSUTHizmet)
                        {
                            sut.IsActive = false;
                        }

                        objectContext.Save();
                    }
                }
            }
            return true;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ProcedureDefinitionFormViewModel GetPricingDetailDefsForProcedure(Guid procedureDefObjectId)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                ProcedureDefinition proc = objectContext.GetObject<ProcedureDefinition>(procedureDefObjectId);
                ProcedureDefinitionFormViewModel result = new ProcedureDefinitionFormViewModel();
                SUT sut = null;
                if (!string.IsNullOrWhiteSpace(proc.SUTCode))
                {
                    sut = objectContext.QueryObjects<SUT>("KOD = '" + proc.SUTCode + "'").FirstOrDefault();
                    if (sut != null)
                    {
                        result.procedureDefInfo.SUTCode = sut.Kod;
                        result.procedureDefInfo.SUTName = sut.Ad;
                    }
                }

                foreach (var procPrice in proc.ProcedurePrice.OrderByDescending(x => x.PricingDetail.DateStart))
                {
                    PricingDetailDefinition price = procPrice.PricingDetail;
                    if (price != null)
                    {
                        PricingDetailDefinitionGridModel gridModel = new PricingDetailDefinitionGridModel();
                        gridModel.ObjectID = price.ObjectID;
                        gridModel.ExternalCode = price.ExternalCode;
                        gridModel.EndDate = price.DateEnd;
                        gridModel.StartDate = price.DateStart;
                        gridModel.Description = price.Description;
                        gridModel.IsActive = price.IsActive;
                        gridModel.InPatientDiscountPercent = price.InPatientDiscountPercent;
                        gridModel.OutPatientDiscountPercent = price.OutPatientDiscountPercent;
                        gridModel.Point = price.Point;
                        gridModel.Price = price.Price;
                        gridModel.PricingList = price.PricingList.ObjectID;
                        if (price.PricingListGroup != null)
                            gridModel.PricingListGroup = price.PricingListGroup.ObjectID;
                        gridModel.CurrencyType = price.CurrencyType;

                        result.pricingDetailDefinitionGridModel.Add(gridModel);
                    }
                }
                return result;
            }
        }

        [HttpPost]
        public LoadResult GetProcedureDefinitionList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(true))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetProcedureDefinitionListDefinition"];
                Dictionary<string, object> paramList = new Dictionary<string, object>();

                //string searchType = loadOptions.Params.searchType;
                //if (!string.IsNullOrEmpty(searchType))
                //{
                //    searchType = " MedulaProcedureType = " + loadOptions.Params.searchType;
                //}

                string searchType = "";
                searchType = " ProcedureType  IS NOt NULL";

                //loadOptions.Sort = new SortingInfo[1];
                //loadOptions.Sort[0] = new SortingInfo();
                //loadOptions.Sort[0].Desc = false;
                //loadOptions.Sort[0].Selector = " NAME";

                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, searchType);
                objectContext.FullPartialllyLoadedObjects();
            }
            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public object GetDiagnosisDefinitions([FromBody] DataSourceLoadOptions loadOptions, [FromQuery] string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var result1 = objectContext.QueryObjects<DiagnosisDefinition>("ObjectID = '" + key + "'").ToList().Select(x => new { ObjectID = x.ObjectID, Name = x.Code + "-" + x.Name }).FirstOrDefault();
                    return result1;
                }
            }
            else
            {
                LoadResult result = null;
                //BindingList<DiagnosisDefinition> result;
                string searchText = loadOptions.Params.searchText;
                if (!string.IsNullOrEmpty(searchText))
                {
                    searchText = " NAME_SHADOW like '%" + searchText.ToUpperInvariant() + "%' OR CODE like '%" + searchText.ToUpperInvariant() + "%'";
                }
                using (var objectContext = new TTObjectContext(true))
                {
                    TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].QueryDefs["GetDiagnosisDefinitions"];
                    Dictionary<string, object> paramList = new Dictionary<string, object>();
                    result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, searchText);
                }
                //if (!string.IsNullOrEmpty(searchText))
                //{
                //    searchText = "AND NAME_SHADOW like '%" + searchText.ToUpperInvariant() + "%' OR CODE like '%" + searchText.ToUpperInvariant() + "%'";
                //}
                //using (var objectContext = new TTObjectContext(true))
                //{
                //    result = DiagnosisDefinition.GetDiagnosisDefinitions(objectContext,searchText);
                //}
                return result;
            }
        }


        public void Global_PostScript(TTObjectContext objectContext, PackageProcedureDefinition[] packageProcedureDefinitions, SubProcedureDefinition[] subProcedureDefinitions, RequiredDiagnoseProcedure[] requiredDiagnoseProcedures, Guid objectID, Type type)
        {
            objectContext.AddToRawObjectList(packageProcedureDefinitions);
            objectContext.AddToRawObjectList(subProcedureDefinitions);
            objectContext.AddToRawObjectList(requiredDiagnoseProcedures);
            objectContext.ProcessRawObjects();

            //var procedureDefinition = (LaboratoryTestDefinition)objectContext.GetLoadedObject(objectID);
            var procedureDefinition = Convert.ChangeType(objectContext.GetLoadedObject(objectID), type);

            if (subProcedureDefinitions != null)
            {
                foreach (var item in subProcedureDefinitions)
                {
                    var subProcedureDefinitionsImported = (SubProcedureDefinition)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)subProcedureDefinitionsImported).IsDeleted)
                        continue;
                    subProcedureDefinitionsImported.ParentProcedureDefinition = (ProcedureDefinition)procedureDefinition;
                }
            }



            if (requiredDiagnoseProcedures != null)
            {
                foreach (var item in requiredDiagnoseProcedures)
                {
                    var requiredDiagnoseProceduresImported = (RequiredDiagnoseProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)requiredDiagnoseProceduresImported).IsDeleted)
                        continue;
                    requiredDiagnoseProceduresImported.ProcedureDefinition = (ProcedureDefinition)procedureDefinition;
                }
            }

        }

        [HttpGet]
        public List<ProcedureMaterialMatchData> SaveOrUpdateMatch(Guid ProcedureID, Guid MaterialID, Guid StoreID, int Amount, Guid? MatchObjectID = null)
        {
            List<ProcedureMaterialMatchData> list = new List<ProcedureMaterialMatchData>();

            using (var objectContext = new TTObjectContext(false))
            {
                ProcedureMaterialMatch match;
                ProcedureDefinition proc = objectContext.GetObject<ProcedureDefinition>(ProcedureID);
                if(proc.ProcedureMaterialMatches.Where(matchItem => matchItem.Material.ObjectID == MaterialID).FirstOrDefault() != null && MatchObjectID == null)
                {
                    throw new TTException("Hizmet bu malzeme ile daha önce eþleþtirilmiþ");

                }

                ProcedureMaterialMatchData matchObject = new ProcedureMaterialMatchData();
                if (MatchObjectID == null)
                    match = new ProcedureMaterialMatch(objectContext);
                else
                    match = objectContext.GetObject<ProcedureMaterialMatch>((Guid)MatchObjectID);

                Material material = objectContext.GetObject<Material>(MaterialID);
                Store store = objectContext.GetObject<Store>(StoreID);

                match.Procedure = proc;
                match.Material = material;
                match.Store = store;
                match.Amount = Amount;
                objectContext.Save();


                list = CreateMatchingGridDataSource(objectContext, ProcedureID);
            }
            return list;
        }


        public List<ProcedureMaterialMatchData> CreateMatchingGridDataSource(TTObjectContext objectContext, Guid ProcedureObjectID)
        {
            List<ProcedureMaterialMatch> matchingList = new List<ProcedureMaterialMatch>();
            List<ProcedureMaterialMatchData> list = new List<ProcedureMaterialMatchData>();
            string filter = string.Empty;
            filter = " WHERE this.PROCEDURE='" + ProcedureObjectID + "'";
            matchingList = ProcedureMaterialMatch.GetMatchingObjectList(objectContext, filter).ToList();

            foreach (ProcedureMaterialMatch item in matchingList)
            {
                ProcedureMaterialMatchData matchObject = new ProcedureMaterialMatchData();
                matchObject.MatchID = item.ObjectID;
                matchObject.Material = item.Material;
                matchObject.Store = item.Store;
                matchObject.Amount = item.Amount;

                list.Add(matchObject);
            }
            objectContext.FullPartialllyLoadedObjects();

            return list;
        }

        [HttpGet]
        public List<ProcedureMaterialMatchData> DeleteMatchObject(Guid? MatchObjectID, Guid ProcedureID)
        {
            List<ProcedureMaterialMatchData> list = new List<ProcedureMaterialMatchData>();
            using (var objectContext = new TTObjectContext(false))
            {

                ProcedureMaterialMatch match = objectContext.GetObject<ProcedureMaterialMatch>((Guid)MatchObjectID);
                ((ITTObject)match).Delete();
                objectContext.Save();
                list = CreateMatchingGridDataSource(objectContext, ProcedureID);

                return list;
            }
        }

        #region KULLANILMAYAN METHODLAR
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<ProcedureDefinition> GetProcedureDefinitionList1()
        {
            List<ProcedureDefinition> list = new List<ProcedureDefinition>();
            using (var objContext = new TTObjectContext(false))
            {
                //return ProcedureDefinition.GetAllProcedureDefinitions(objContext, "").ToList<ProcedureDefinition>();
                System.ComponentModel.BindingList<ProcedureDefinition.GetProcedureDefinitionListDefinition_Class> aa = ProcedureDefinition.GetProcedureDefinitionListDefinition("");

                for (int i = 0; i < 50; i++)
                {
                    ProcedureDefinition pd = new ProcedureDefinition(objContext);

                    pd.Code = aa[i].Code;
                    pd.Name = aa[i].Name;
                    pd.Qref = aa[i].Qref;
                    list.Add(pd);
                }

                return list;

            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public object GetProcedureDefinitionList2(DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;

            using (var objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName.Trim()];
                TTList ttList = TTList.NewList(objectContext, listDef, string.Empty);

                result = DevexpressLoader.Load(objectContext, ttList, loadOptions, new Dictionary<string, object>(), searchText);
            }
            return result.data;

        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<ProcedureDefinition> GetProcedureDefinitionList5()
        {

            using (var objContext = new TTObjectContext(false))
            {
                return ProcedureDefinition.GetAllProcedureDefinitions(objContext, " WHERE ISACTIVE = 1").ToList<ProcedureDefinition>();
            }
            //return null;
        }
        #endregion

    }


}

namespace Core.Models
{
    public partial class ProcedureFormViewModel : BaseViewModel
    {
    }

    public class PricingDetailDefinition_Input
    {
        public List<PricingDetailDefinitionGridModel> PriceDetails = new List<PricingDetailDefinitionGridModel>();
        public Guid ProcedureDefObjectID { get; set; }
    }

    public class PricingDetailDefinitionSave_Input
    {
        public List<PricingDetailDefinitionGridModel> PriceDetails;
        public Guid ProcedureDefObjectID;
        public bool CreateProcedurePriceWithSameCode { get; set; }
    }

    public class PricingDetailDefinitionGridModel
    {
        public string ExternalCode;
        //Name'i
        public string Description;
        //PricingListListDefinition
        public Guid? PricingList;
        //PricingListGroupListDefinition
        public Guid? PricingListGroup;
        public DateTime? StartDate;
        public DateTime? EndDate;
        public double? Price;
        public double? Point;
        public CurrencyTypeDefinition CurrencyType;
        public double? InPatientDiscountPercent;
        public double? OutPatientDiscountPercent;
        public bool? IsActive;
        public Guid ObjectID { get; set; }
        public bool IsNew { get; set; }
        public string SUTCode { get; set; }
        public string SUTName { get; set; }
    }

    public class ProcedureDefInfo
    {
        public string SUTName { get; set; }
        public string SUTCode { get; set; }
    }

    public class ProcedureDefinitionFormViewModel
    {
        public List<PricingDetailDefinitionGridModel> pricingDetailDefinitionGridModel = new List<PricingDetailDefinitionGridModel>();
        public ProcedureDefInfo procedureDefInfo = new ProcedureDefInfo();
    }

    public class SUTPriceDefinitionGridModel : sutFiyatDVO
    {
        public Guid? PricingDetailDefObjectID { get; set; }
        public string turAdi { get; set; }
        public double? eskiFiyat { get; set; }
        public bool IsExists { get; set; } = true;
        public string IsExistText { get; set; } = "Var";
    }

    public class UpdatePriceDefinition_Input
    {
        public List<SUTPriceDefinitionGridModel> UpdateList = new List<SUTPriceDefinitionGridModel>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class SUTTuru
    {
        public int turu { get; set; }
        public string turAdi { get; set; }
    }

    public class GetSUTChanges_Input
    {
        public DateTime? InputDate { get; set; }
    }

    public class ProcedureMaterialMatchData
    {
        public Guid MatchID { get; set; }
        public Material Material { get; set; }
        public Store Store { get; set; }
        public int? Amount { get; set; }
    }

    public class MatchingFormViewModel
    {
        public List<Store> stores { get; set; }
        public List<ProcedureMaterialMatchData> matches { get; set; }
    }

}
