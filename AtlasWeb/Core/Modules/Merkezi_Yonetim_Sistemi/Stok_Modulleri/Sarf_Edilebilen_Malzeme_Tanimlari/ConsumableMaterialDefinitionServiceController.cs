//$04813D5A
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Data;
using TTUtils;
using TTDefinitionManagement;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class ConsumableMaterialDefinitionServiceController : Controller
    {

        public LoadModelComponentConsumableMaterial loadModelComponent(LoadModelComponentConsumableMaterial_Input input)
        {
            LoadModelComponentConsumableMaterial loadModel = new LoadModelComponentConsumableMaterial();
            loadModel.MaterialTreeDefinitions = this.GetMaterialTree();
            loadModel.getStockLocationClasses = this.GetStockLocation();
            loadModel.shelfAndRowOnStock = this.GetShelfAndRowOnStock(input);
            loadModel.materialPrices = this.GetMaterailPrices(input.MaterialID.ToString());
            loadModel.getCritical = this.GetCriticalStockLevels(input.StoreID.ToString(), input.MaterialID.ToString());
            loadModel.materialProcedures = this.GetMaterialProcedures(input.MaterialID);
            loadModel.firstInStockUnitePrices = this.GetMaterialInStock(input);
            loadModel.logDataSources = new List<LogDataSource>();// this.GetObjectAuditRecords(input.MaterialID);
            loadModel.doSearchaccountingTerm = this.GetAccountingTerm(input.StoreID);
            loadModel.MaterialTypeListIsGroupList = this.getMaterialTypeList();
            loadModel.MaterialSpecialtyList = this.GetMaterialSpecialtyList(input);
            loadModel.equivalentMaterialList = this.GetEquivalentMaterial(input);
            return loadModel;
        }

        public List<EquivalentConsMaterial> GetEquivalentMaterial(LoadModelComponentConsumableMaterial_Input input)
        {
            List<EquivalentConsMaterial> outputforall = new List<EquivalentConsMaterial>();
            using (var context = new TTObjectContext(false))
            {
                IBindingList equvalentMats = context.QueryObjects(typeof(EquivalentConsMaterial).Name, "CONSUMABLEMATERIALDEFINITION =" + TTConnectionManager.ConnectionManager.GuidToString(input.MaterialID));
                foreach (var item in equvalentMats)
                {
                    outputforall.Add((EquivalentConsMaterial)item);
                }
                return outputforall;
            }
        }


        public void updateMaterialPriceByMedulaSUT(MaterialPriceByMedulaSUT_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                try
                {
                    List<PricingDetailDVO> pricingDetailDefinitions = new List<PricingDetailDVO>();
                    pricingDetailDefinitions = PricingDetailDefinitionForMaterial(context, input.updateMaterial);

                    foreach (PricingDetailDVO pricingDetailDVO in pricingDetailDefinitions)
                    {
                        if (pricingDetailDVO.newPricingDetailDefinition != null && pricingDetailDVO.oldPricingDetailDefinition != null)
                        {
                            // Yeni, Medulaya Gönderilmeyecek, ve Hizmet Kaydý Baþarýsýz durumdaki ve fiyat baþlangýç tarihinden sonraki accTrx ler
                            IBindingList accTrxListForPriceUpdate = context.QueryObjects("ACCOUNTTRANSACTION", "SUBACTIONMATERIAL IS NOT NULL "
                                         + " AND CURRENTSTATEDEFID IN ('934b9f03-d262-428d-8cb8-5e8ab927e3d5','33784c3f-d601-49c4-b8da-6fa502f6a9cf','6856675b-95fb-41cf-bade-6a1993626cc7')"
                                         + " AND PRICINGDETAIL = '" + pricingDetailDVO.oldPricingDetailDefinition.ObjectID.ToString()
                                         + "' AND TRANSACTIONDATE >= " + Globals.CreateNQLToDateParameter(DateTime.Parse(input.updateMaterial.ActivationDate)));

                            foreach (AccountTransaction accTrx in accTrxListForPriceUpdate)
                            {
                                if (accTrx.SubActionMaterial.Material is ConsumableMaterialDefinition)
                                {
                                    // (SGK ve kurum payý) ise satýþ fiyatý + %12 , Malzeme için diðer durumlarda alýþ fiyatý kullanýldýðý için güncelleme yapýlmaz
                                    if (accTrx.SubEpisodeProtocol.Payer.IsSGKAll && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                                        accTrx.UnitPrice = Math.Round((double)(pricingDetailDVO.newPricingDetailDefinition.Price.Value * 1.12), 2);
                                }

                            }
                        }
                        else if (pricingDetailDVO.newPricingDetailDefinition != null && pricingDetailDVO.oldPricingDetailDefinition == null) // Eski fiyatý olmayýp (PricingDetail i null) 0 fiyatlý ücretlenmiþler için
                        {
                            IBindingList accTrxListForPriceUpdate = null;

                            // Yeni, Medulaya Gönderilmeyecek, ve Hizmet Kaydý Baþarýsýz durumdaki ve fiyat baþlangýç tarihinden sonraki accTrx ler
                            accTrxListForPriceUpdate = context.QueryObjects("ACCOUNTTRANSACTION", "SUBACTIONMATERIAL IS NOT NULL AND PRICINGDETAIL IS NULL"
                                         + " AND CURRENTSTATEDEFID IN ('934b9f03-d262-428d-8cb8-5e8ab927e3d5','33784c3f-d601-49c4-b8da-6fa502f6a9cf','6856675b-95fb-41cf-bade-6a1993626cc7')"
                                         + " AND SUBACTIONMATERIAL.MATERIAL.CODE = '" + input.updateMaterial.Code // Malzeme için Code dan bakýlýr
                                         + "' AND TRANSACTIONDATE >= " + Globals.CreateNQLToDateParameter(DateTime.Parse(input.updateMaterial.ActivationDate)));

                            foreach (AccountTransaction accTrx in accTrxListForPriceUpdate)
                            {
                                if (accTrx.SubActionMaterial.Material is ConsumableMaterialDefinition)
                                {
                                    // (SGK ve kurum payý) ise satýþ fiyatý + %12 , Malzeme için diðer durumlarda alýþ fiyatý kullanýldýðý için güncelleme yapýlmaz
                                    if (accTrx.SubEpisodeProtocol.Payer.IsSGKAll && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                                        accTrx.UnitPrice = Math.Round((double)(pricingDetailDVO.newPricingDetailDefinition.Price.Value * 1.12), 2);
                                }
                            }
                        }
                    }
                    context.Save();
                }
                catch
                {

                }
            }
        }

        public pricePatientOutputDTO updatePatientMaterialPrice(string materialObjId)
        {
            pricePatientOutputDTO dTO = new pricePatientOutputDTO();
            DateTime nowTime = Common.RecTime();
            using (TTObjectContext context = new TTObjectContext(false))
            {
                ConsumableMaterialDefinition consumableMaterial = context.GetObject<ConsumableMaterialDefinition>(new Guid(materialObjId));

                MaterialPrice oldMaterialPrice = consumableMaterial.MaterialPrices.Where(x => x.PricingDetail.DateEnd < nowTime &&
                                                                               x.PricingDetail.ExternalCode == consumableMaterial.Code &&
                                                                               x.PricingDetail.PricingList.ObjectID.ToString() == "bfe21eaf-3f71-4bbc-990b-066c5dfbd259").FirstOrDefault();
                MaterialPrice newMaterialPrice = consumableMaterial.MaterialPrices.Where(x => x.PricingDetail.DateEnd > nowTime &&
                                                                               x.PricingDetail.ExternalCode == consumableMaterial.Code &&
                                                                               x.PricingDetail.PricingList.ObjectID.ToString() == "bfe21eaf-3f71-4bbc-990b-066c5dfbd259").FirstOrDefault();
                if (newMaterialPrice != null)
                {
                    dTO.priceEndDate = newMaterialPrice.PricingDetail.DateEnd.Value;
                    dTO.priceStartDate = newMaterialPrice.PricingDetail.DateStart.Value;

                    List<pricePatienList> unUpdatedPatienList = new List<pricePatienList>();
                    List<pricePatienList> UpdatedPatienList = new List<pricePatienList>();

                    IBindingList accTrxListForPriceUpdate = context.QueryObjects("ACCOUNTTRANSACTION", "SUBACTIONMATERIAL IS NOT NULL "
                                            + " AND CURRENTSTATEDEFID IN ('934b9f03-d262-428d-8cb8-5e8ab927e3d5','33784c3f-d601-49c4-b8da-6fa502f6a9cf','6856675b-95fb-41cf-bade-6a1993626cc7')"
                                            + " AND PRICINGDETAIL = '" + oldMaterialPrice.PricingDetail.ObjectID.ToString() + "'");

                    foreach (AccountTransaction accTrx in accTrxListForPriceUpdate)
                    {
                        if (accTrx.UnitPrice != newMaterialPrice.PricingDetail.Price)
                        {
                            pricePatienList unUpdatedPatien = new pricePatienList();
                            unUpdatedPatien.AccTrxObjID = accTrx.ObjectID.ToString();
                            unUpdatedPatien.OldPrice = oldMaterialPrice.PricingDetail.Price.ToString();
                            unUpdatedPatien.NewPrice = newMaterialPrice.PricingDetail.Price.ToString();
                            unUpdatedPatien.TrasnactionDate = (DateTime)accTrx.TransactionDate;
                            unUpdatedPatien.Desciption = "Yapýlamayan Ýþlem";
                            unUpdatedPatien.PatientNameAndSurname = accTrx.SubEpisodeProtocol.SubEpisode.Episode.Patient.Name + " " + accTrx.SubEpisodeProtocol.SubEpisode.Episode.Patient.Surname;
                            unUpdatedPatien.PatientProtocolNo = accTrx.SubEpisodeProtocol.SubEpisode.ProtocolNo;
                            unUpdatedPatienList.Add(unUpdatedPatien);
                        }
                        else
                        {
                            pricePatienList UpdatedPatien = new pricePatienList();
                            UpdatedPatien.NewPrice = newMaterialPrice.PricingDetail.Price.ToString();
                            UpdatedPatien.OldPrice = "-";
                            UpdatedPatien.TrasnactionDate = (DateTime)accTrx.TransactionDate;
                            UpdatedPatien.Desciption = "Ýþlem Baþarýlý Sona Erdi";
                            UpdatedPatien.PatientNameAndSurname = accTrx.SubEpisodeProtocol.Episode.Patient.Name + " " + accTrx.SubEpisodeProtocol.Episode.Patient.Surname;
                            UpdatedPatien.PatientProtocolNo = accTrx.SubEpisodeProtocol.SubEpisode.ProtocolNo;
                            UpdatedPatienList.Add(UpdatedPatien);
                        }
                    }

                    dTO.unUpdatedPatienList = unUpdatedPatienList;
                    dTO.UpdatedPatienList = UpdatedPatienList;
                    dTO.totalUpdatePatientPriceCount = UpdatedPatienList.Count.ToString() + " kadar hastanýn ilaç fiyatý güncellenmiþtir ";
                }
                return dTO;
            }
        }


        [HttpPost]
        public void UpdateRepaitPatientPrice(RepaitUnUpdate_Intput input)
        {
            using (var context = new TTObjectContext(false))
            {

                foreach (pricePatienList item in input.unUpdatedPatienList)
                {
                    AccountTransaction accTrx = context.GetObject<AccountTransaction>(new Guid(item.AccTrxObjID));
                    try
                    {
                        accTrx.UnitPrice = Math.Round(Convert.ToDouble(item.NewPrice), 2);
                        context.Save();
                    }
                    catch (Exception e)
                    {

                    }
                }

            }
        }

        public List<PricingDetailDVO> PricingDetailDefinitionForMaterial(TTObjectContext context, UpdateMaterialPriceOutput updateMaterial)
        {
            DateTime nowTime = Common.RecTime();
            List<PricingDetailDVO> pddReturnMaterialList = new List<PricingDetailDVO>();
            IBindingList pricingDetailDefinition = context.QueryObjects("PRICINGDETAILDEFINITION", "PRICINGLIST = 'bfe21eaf-3f71-4bbc-990b-066c5dfbd259' AND EXTERNALCODE='" + updateMaterial.Code
                                      + "' AND DATESTART < " + TTUtils.Globals.CreateNQLToDateParameter(nowTime) + " AND DATEEND > " + TTUtils.Globals.CreateNQLToDateParameter(nowTime));

            if (pricingDetailDefinition.Count == 0)
            {
                PricingDetailDefinition pdd = new PricingDetailDefinition(context);
                pdd.DateStart = DateTime.Parse(updateMaterial.ActivationDate);
                pdd.DateEnd = new DateTime(2100, 1, 1, 0, 0, 0);
                pdd.Description = updateMaterial.Desciption;
                pdd.CurrencyType = (CurrencyTypeDefinition)context.GetObject(new Guid("e3a4f2d5-4f74-406c-8258-37316ea8e9d1"), typeof(CurrencyTypeDefinition).Name);
                pdd.PricingList = (PricingListDefinition)context.GetObject(new Guid("bfe21eaf-3f71-4bbc-990b-066c5dfbd259"), typeof(PricingListDefinition).Name);
                pdd.PricingListGroup = (PricingListGroupDefinition)context.GetObject(new Guid("39d65056-3d97-4b85-94d7-0280c806391c"), typeof(PricingListGroupDefinition).Name);
                pdd.Price = updateMaterial.Price;
                pdd.ExternalCode = updateMaterial.Code;

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
                        pdd.DateStart = DateTime.Parse(updateMaterial.ActivationDate);
                        pdd.DateEnd = new DateTime(2100, 1, 1, 0, 0, 0);
                        pdd.Description = updateMaterial.Desciption;
                        pdd.CurrencyType = (CurrencyTypeDefinition)context.GetObject(new Guid("e3a4f2d5-4f74-406c-8258-37316ea8e9d1"), typeof(CurrencyTypeDefinition).Name);
                        pdd.PricingList = (PricingListDefinition)context.GetObject(new Guid("bfe21eaf-3f71-4bbc-990b-066c5dfbd259"), typeof(PricingListDefinition).Name);
                        pdd.PricingListGroup = (PricingListGroupDefinition)context.GetObject(new Guid("39d65056-3d97-4b85-94d7-0280c806391c"), typeof(PricingListGroupDefinition).Name);
                        pdd.Price = updateMaterial.Price;
                        pdd.ExternalCode = updateMaterial.Code;

                        DateTime nD = ((DateTime)pdd.DateStart).AddDays(-1);
                        pDet.DateEnd = new DateTime(nD.Year, nD.Month, nD.Day, 23, 59, 59);

                        IBindingList mPrice = context.QueryObjects("MATERIALPRICE", "PRICINGDETAIL='" + pDet.ObjectID + "'");

                        foreach (MaterialPrice item in mPrice)
                        {
                            MaterialPrice materialPrice = new MaterialPrice(context);
                            materialPrice.Material = item.Material;
                            materialPrice.PricingDetail = pdd;
                            item.Material.CurrentPrice = updateMaterial.Price;
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



        public List<UpdateMaterialPriceOutput> updateMaterialPriceBySutKodu()
        {
            List<UpdateMaterialPriceOutput> updateMaterialPriceOutputList = new List<UpdateMaterialPriceOutput>();

            try
            {

                MedulaYardimciIslemler.guncelSutSorguGirisDVO guncelSutSorguGirisDVO = new MedulaYardimciIslemler.guncelSutSorguGirisDVO();
                guncelSutSorguGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu(); // Pursaklar : 11060019 , Gaziler : 11069941
                guncelSutSorguGirisDVO.tarih = null;

                MedulaYardimciIslemler.guncelSutSorguCevapDVO guncelSutSorguCevapDVO = MedulaYardimciIslemler.WebMethods.guncelSutKodlariSync(Sites.SiteLocalHost, guncelSutSorguGirisDVO);
                if (guncelSutSorguCevapDVO.sonucKodu == "0000")
                {

                    MedulaYardimciIslemler.sutFiyatDVO[] sutKodlariList = guncelSutSorguCevapDVO.sutKodlari.Where(x => x.turu == 5).ToArray();
                    var query = from sutKod in sutKodlariList
                                select new UpdateMaterialPriceOutput
                                {
                                    Price = sutKod.fiyat,
                                    Desciption = sutKod.adi,
                                    Code = sutKod.sutKodu,
                                    SutAppandix = sutKod.listeAdi,
                                    ActivationDate = sutKod.gecerlilikTarihi
                                };
                    updateMaterialPriceOutputList = query.ToList();
                }
                else
                {
                    throw new TTException(guncelSutSorguCevapDVO.sonucMesaji);
                }
            }
            catch (Exception ex)
            {
                throw new TTException(ex.Message);
            }

            return updateMaterialPriceOutputList;
        }

        public List<MaterialSpecialty> GetMaterialSpecialtyList(LoadModelComponentConsumableMaterial_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                List<MaterialSpecialty> MaterialSpecialtyList = context.QueryObjects<MaterialSpecialty>("MATERIAL ='" + input.MaterialID + "'").ToList();
                return MaterialSpecialtyList;
            }
        }

        public List<MaterialTreeDefinition> GetMaterialTree()
        {
            List<MaterialTreeDefinition> output = new List<MaterialTreeDefinition>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                output = objectContext.QueryObjects<MaterialTreeDefinition>("ISACTIVE=1 AND GROUPCODE <> '150-03-01' ").ToList();
            }

            return output;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LoadResult RevenueSubAccountCodeList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            var injection = string.Empty;
            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;
            using (var objectContext = new TTObjectContext(true))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RevenueSubAccountCodeDefinition"].QueryDefs["GetRevenueSubAccountCodeDefinitions"];
                var paramList = new Dictionary<string, object>();

                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }



        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public BindingList<MaterialPrice.MaterialPriceByMaterialForDefinition_Class> GetMaterailPrices(string objectid)

        {
            BindingList<MaterialPrice.MaterialPriceByMaterialForDefinition_Class> Drg = MaterialPrice.MaterialPriceByMaterialForDefinition(objectid);
            return Drg;
        }

        public LogisticDashboardViewModel GetAccountingTerm(Guid storeObjectID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                LogisticDashboardViewModel model = new LogisticDashboardViewModel();
                Store store = (Store)objectContext.GetObject(storeObjectID, typeof(Store));
                List<CostActionAccountingTerm> accounting = new List<CostActionAccountingTerm>();
                if (store is MainStoreDefinition)
                {
                    foreach (AccountingTerm term in ((MainStoreDefinition)store).Accountancy.AccountingTerms)
                    {
                        CostActionAccountingTerm accont = new CostActionAccountingTerm();
                        accont.ObjId = term.ObjectID.ToString();
                        accont.Desciption = term.Description;
                        accont.StartDate = (DateTime)term.StartDate;
                        accont.Status = term.Status;
                        accounting.Add(accont);
                    }

                    model.IsMainStoreFlag = true;
                }
                else
                    model.IsMainStoreFlag = false;
                accounting.Sort(delegate (CostActionAccountingTerm ps1, CostActionAccountingTerm ps2)
                {
                    return DateTime.Compare(ps1.StartDate, ps2.StartDate);
                }

                );
                accounting = accounting.OrderByDescending(ps1 => ps1.StartDate).ToList();
                model.costActionAccountingTerm = accounting;
                model.activeCostActionAccountingTerm = accounting.FirstOrDefault(x => x.Status == AccountingTermStatusEnum.Open);
                objectContext.FullPartialllyLoadedObjects();
                return model;
            }
        }
        public List<LogDataSource> GetObjectAuditRecords([FromQuery]Guid auditObjectID)
        {
            List<LogDataSource> arr = new List<LogDataSource>();
            DataTable _allDataDataTable = TTAuditRecord.GetObjectAuditRecords(auditObjectID, null, null, false);
            for (int i = 0; i < _allDataDataTable.Rows.Count; i++)
            {
                TTAuditRecord audit = new TTAuditRecord(_allDataDataTable.Rows[i]);
                arr.Add(LogDataSource.CreateFromAudit(audit));
            }
            return arr;
        }

        public BindingList<StockLocation.GetStockLocation_Class> GetStockLocation()
        {
            BindingList<StockLocation.GetStockLocation_Class> stockLocationIsGroupList = new BindingList<StockLocation.GetStockLocation_Class>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                stockLocationIsGroupList = StockLocation.GetStockLocation(objectContext, " WHERE ISGROUP = '1' ");
            }
            return stockLocationIsGroupList;
        }

        public List<ProcedureDefinition_Output> GetMaterialProcedures(Guid material)
        {
            List<ProcedureDefinition_Output> procedures = new List<ProcedureDefinition_Output>();
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<MaterialProcedures.GetMaterialProcedures_Class> materialProcedures = MaterialProcedures.GetMaterialProcedures(material);
                foreach (MaterialProcedures.GetMaterialProcedures_Class item in materialProcedures)
                {
                    ProcedureDefinition pd = objectContext.GetObject<ProcedureDefinition>(item.Pdobjectid.Value);
                    ProcedureDefinition_Output output = new ProcedureDefinition_Output();
                    output.ObjectID = pd.ObjectID;
                    output.Name = pd.Name;
                    output.ID = pd.ID.ToString();
                    output.Code = pd.Code;
                    procedures.Add(output);
                }
            }
            return procedures;
        }

        public int StockCardMkysKayitID(Guid ObjectID)
        {
            var objectContext = new TTObjectContext(false);
            StockCard stockCard = objectContext.GetObject<StockCard>(ObjectID);
            if (stockCard.MalzemeGetData != null)
            {
                return stockCard.MalzemeGetData.malzemeKayitID.Value;
            }
            else
            {
                return 0;
            }

        }


        [HttpGet]
        public GetCriticalStockLevels_Class GetCriticalStockLevels(string StoreID, string MaterialObjectID)
        {

            List<Stock.GetCriticalStockLevelsNQL_Class> list = Stock.GetCriticalStockLevelsNQL(new Guid(StoreID), " AND MATERIAL =" + "'" + MaterialObjectID + "'", null).ToList();
            GetCriticalStockLevels_Class output;
            if (list.Count > 0)
            {
                output = new GetCriticalStockLevels_Class
                {

                    Inheld = list[list.Count - 1].Inheld,
                    MinimumLevel = list[list.Count - 1].MinimumLevel,
                    MaximumLevel = list[list.Count - 1].MaximumLevel,
                    CriticalLevel = list[list.Count - 1].CriticalLevel
                };
            }
            else
            {
                output = new GetCriticalStockLevels_Class
                {
                    Inheld = 0,
                    MinimumLevel = 0,
                    MaximumLevel = 0,
                    CriticalLevel = 0
                };
            }

            return output;

        }

        public ShelfAndRowOnStock GetShelfAndRowOnStock(LoadModelComponentConsumableMaterial_Input input)
        {
            ShelfAndRowOnStock shelfAndRowOnStock_Output = new ShelfAndRowOnStock();
            using (var objectContext = new TTObjectContext(false))
            {
                StoreLocation location = new StoreLocation(objectContext);
                BindingList<Stock> stockList = (BindingList<Stock>)objectContext.QueryObjects("STOCK", "STORE = '" + input.StoreID + "' AND MATERIAL = '" + input.MaterialID + "'");


                foreach (Stock _stock in stockList)
                {
                    if (_stock.StoreLocations.Count > 0)
                    {
                        shelfAndRowOnStock_Output.Shelf = _stock.Shelf;
                        shelfAndRowOnStock_Output.Row = _stock.Row;
                        if (_stock.StoreLocations[0].StockLocation != null)
                        {
                            shelfAndRowOnStock_Output.StockLocationID = _stock.StoreLocations[0].StockLocation.ObjectID;
                        }

                    }
                }
                BindingList<StockLocation> stockLocation = (BindingList<StockLocation>)objectContext.QueryObjects("STOCKLOCATION", "OBJECTID = '" + shelfAndRowOnStock_Output.StockLocationID + "'");
                if (stockLocation.Count > 0)
                {
                    foreach (StockLocation _stockLocation in stockLocation)
                    {
                        shelfAndRowOnStock_Output.StockLocation = _stockLocation;
                    }
                }
            }
            return shelfAndRowOnStock_Output;

        }



        public List<FirstInStockUnitePrice> GetMaterialInStock(LoadModelComponentConsumableMaterial_Input inputDVO)
        {
            List<FirstInStockUnitePrice> list = new List<FirstInStockUnitePrice>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {

                BindingList<Stock.GetStockFromStoreAndMaterial_Class> stocks = Stock.GetStockFromStoreAndMaterial(inputDVO.MaterialID, inputDVO.StoreID);
                if (stocks.Count > 0)
                {
                    IBindingList stockTransactions = objectContext.QueryObjects(typeof(StockTransaction).Name, " INOUT = 1 AND STOCK =" + TTConnectionManager.ConnectionManager.GuidToString((Guid)(stocks[0].ObjectID)) + " AND CURRENTSTATEDEFID =" + TTConnectionManager.ConnectionManager.GuidToString(StockTransaction.States.Completed));
                    foreach (StockTransaction item in stockTransactions)
                    {
                        if (item.StockActionDetail.StockAction != null)
                        {
                            FirstInStockUnitePrice firtIn = new FirstInStockUnitePrice();
                            firtIn.stockActionObjectid = item.StockActionDetail.StockAction.ObjectID;
                            firtIn.ObjectDefID = item.StockActionDetail.StockAction.ObjectDef.ID;
                            firtIn.ExpirationDate = item.ExpirationDate;
                            firtIn.TransactionDate = item.StockActionDetail.StockAction.TransactionDate;
                            firtIn.UnitePrice = item.UnitPrice.ToString();

                            IBindingList documentRecordLogs = objectContext.QueryObjects(typeof(DocumentRecordLog).Name, " STOCKACTION = '" + item.StockActionDetail.StockAction.ObjectID + "'");
                            foreach (DocumentRecordLog log in documentRecordLogs)
                            {
                                firtIn.Tif = log.DocumentRecordLogNumber.ToString();
                            }

                            list.Add(firtIn);
                        }
                    }
                }
            }
            list = list.OrderByDescending(x => x.TransactionDate).ToList();
            return list;
        }








        [HttpGet]
        public PricingDetailDefinition GetMaterialPriceDetails(Material material)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PricingListDefinition pricingListDefinition = objectContext.GetObject(new Guid("bfe21eaf-3f71-4bbc-990b-066c5dfbd259"), typeof(PricingListDefinition)) as PricingListDefinition;
                var materialPricingDetails = material.GetMaterialPricingDetail(pricingListDefinition, Common.RecTime());
                if (materialPricingDetails.Count > 0)
                    return (PricingDetailDefinition)materialPricingDetails[0];
                else
                    return null;
            }
        }

   

        [HttpGet]
        public List<MaterialDocumentation> GetMaterialDocumentationDetails(Material material)
        {
            List<MaterialDocumentation> list = new List<MaterialDocumentation>();
            using (var objectContext = new TTObjectContext(false))
            {
                IBindingList materialDocumentations = objectContext.QueryObjects("MATERIALDOCUMENTATION", " Material = '" + material.ObjectID + "'");
                foreach (var doc in materialDocumentations)
                {
                    list.Add((MaterialDocumentation)doc);
                }
            }
            return list;
        }



        [HttpPost]
        public void DeleteMaterialProcedures(MaterialProcedures_Output obj)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                MaterialProcedures matProc = objectContext.GetObject<MaterialProcedures>(obj.ObjectID);
                ((ITTObject)matProc).Delete();
                objectContext.Save();
            }
        }

        [HttpPost]
        public bool AddMaterialProcedure(MaterialProcedures_Output procedures_Input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                var objectExists = objectContext.QueryObjects<MaterialProcedures>($"MATERIAL = '{procedures_Input.Material.ObjectID}' AND PROCEDUREDEFINITION = '{procedures_Input.ProcedureDefinition.ObjectID}'").Any();
                if (objectExists)
                {
                    return false;
                }
                var obj = new MaterialProcedures(objectContext);
                obj.Material = objectContext.GetObject<Material>(procedures_Input.Material.ObjectID);
                obj.ProcedureDefinition = objectContext.GetObject<ProcedureDefinition>(procedures_Input.ProcedureDefinition.ObjectID);
                objectContext.Save();
                return true;
            }

        }
        public class SaveShelfAndRowOnStock_Input
        {
            public Guid MaterialID
            {
                get;
                set;
            }
            public Guid StoreID
            {
                get;
                set;
            }

            public int? Shelf { get; set; }
            public int? Row { get; set; }
        }

        public class StoreLocationInformation_Input
        {
            public Guid StockLocationID
            {
                get;
                set;
            }
            public Guid StockObjID
            {
                get;
                set;
            }
            public Guid MaterialID
            {
                get;
                set;
            }
            public Guid StoreID
            {
                get;
                set;
            }
        }

        public void SaveStoreLocation(StoreLocationInformation_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                var objectContext2 = new TTObjectContext(false);
                StoreLocation location = new StoreLocation(objectContext);
                BindingList<Stock> stockList = (BindingList<Stock>)objectContext.QueryObjects("STOCK", "STORE = '" + input.StoreID + "' AND MATERIAL = '" + input.MaterialID + "'");
                foreach (Stock _stock in stockList)
                {
                    location.Stock = _stock;
                }

                BindingList<StockLocation> stockLocation = (BindingList<StockLocation>)objectContext.QueryObjects("STOCKLOCATION", "OBJECTID = '" + input.StockLocationID + "'");
                foreach (StockLocation _stockLocation in stockLocation)
                {
                    location.StockLocation = _stockLocation;
                }

                if (location.Stock != null)
                {
                    BindingList<StoreLocation> _StoreLocations = (BindingList<StoreLocation>)objectContext2.QueryObjects("STORELOCATION", "STOCK = '" + location.Stock.ObjectID + "'");
                    foreach (StoreLocation _xStoreLocation in _StoreLocations)
                    {
                        _xStoreLocation.StockLocation = location.StockLocation;
                        objectContext2.Save();
                        objectContext2.Dispose();
                    }

                    if (_StoreLocations.Count > 0)
                    {
                        objectContext.Dispose();
                    }
                    else
                    {
                        objectContext.Save();
                    }
                }

            }
        }

        public void SaveShelfAndRowOnStock(SaveShelfAndRowOnStock_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<Stock> stockList = (BindingList<Stock>)objectContext.QueryObjects("STOCK", "STORE = '" + input.StoreID + "' AND MATERIAL = '" + input.MaterialID + "'");
                foreach (Stock _stock in stockList)
                {
                    _stock.Shelf = input.Shelf;
                    _stock.Row = input.Row;
                }
                objectContext.Save();
                objectContext.Dispose();
            }
        }




        public class ShelfAndRowOnStock_Output
        {
            public int? Shelf { get; set; }
            public int? Row { get; set; }
            public Guid? StockLocationID { get; set; }
            public StockLocation StockLocation { get; set; }

        }




        public class MaterialType_Input
        {
            public Guid MaterialID
            {
                get;
                set;
            }
            public Guid StoreID
            {
                get;
                set;
            }
        }

        public List<MaterialType_Output> getMaterialTypeList()
        {
            List<MaterialType_Output> materialType_Output = new List<MaterialType_Output>();
            using (var objectContext = new TTObjectContext(false))
            {
                List<MalzemeTuru> MalzemeTuruList = new List<MalzemeTuru>();
                MalzemeTuruList = objectContext.QueryObjects<MalzemeTuru>().ToList();

                foreach (MalzemeTuru _MalzemeTuru in MalzemeTuruList)
                {
                    if (_MalzemeTuru != null)
                    {
                        MaterialType_Output materialType = new MaterialType_Output();
                        materialType.MaterialTypeCode = _MalzemeTuru.malzemeTuruKodu;
                        materialType.MaterialTypeName = _MalzemeTuru.malzemeTuruAdi;
                        materialType.MaterialTypeObjectID = _MalzemeTuru.ObjectID;
                        materialType_Output.Add(materialType);
                    }
                }

            }
            return materialType_Output;

        }

        public class UploadFile_Input
        {

            public IList<FormFile> File { get; set; }
            public string FileName { get; set; }
            public string Material { get; set; }
            public DateTime FileUpdateDate { get; set; }
            public Boolean IsNew { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            var result = await MultipartRequestHelper.BindMultiPartFormDataToViewModel<UploadFile_Input>(this);
            var objectResult = result as ObjectResult;
            var viewModel = objectResult.Value as UploadFile_Input;

            using (var context = new TTObjectContext(false))
            {
                Material _material = context.GetObject<Material>(new Guid(viewModel.Material));
                Guid savePoint = context.BeginSavePoint();
                if (viewModel != null)
                {
                    if (viewModel.File != null)
                    {
                        MaterialDocumentation doc = new MaterialDocumentation(context);
                        var formFile = viewModel.File.FirstOrDefault();
                        if (StreamHelpers.ToByteArray(formFile.OpenReadStream()).Length <= 10000000)
                        {

                            if (FileTypeCheck.fileTypeCheck(StreamHelpers.ToByteArray(formFile.OpenReadStream()), viewModel.FileName))
                            {
                                doc.File = StreamHelpers.ToByteArray(formFile.OpenReadStream());
                                doc.FileName = viewModel.FileName;
                                doc.FileUpdateDate = DateTime.Now;
                                _material.MaterialDocumentations.Add(doc);
                                context.Save();
                            }
                            else
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25690", "Geçersiz dosya tipi!"));
                        }
                        else
                        {
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25077", "10 Mb'dan büyük dosya yükleyemezsiniz!"));
                        }
                    }
                }
            }

            return Ok();
        }

        public class DownloadFileInput
        {
            public Guid id { get; set; }
        }

        [HttpPost]
        public IActionResult DownloadFile(DownloadFileInput input)
        {

            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    MaterialDocumentation doc = (MaterialDocumentation)objectContext.GetObject(input.id, typeof(MaterialDocumentation));
                    if (doc.File != null)
                    {
                        Byte[] memoryStream = (byte[])doc.File;
                        System.IO.Stream myInputStream = new System.IO.MemoryStream(memoryStream);
                        myInputStream.Position = 0;
                        var contentType = "";
                        if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".DOCX")
                        {
                            contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".PNG")
                        {
                            contentType = "image/png";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".JPG"
                            || doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".JPEG")
                        {
                            contentType = "image/jpeg";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".DOC")
                        {
                            contentType = "application/msword";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".PPT")
                        {
                            contentType = "application/vnd.ms-powerpoint";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".PPTX")
                        {
                            contentType = " application/vnd.openxmlformats-officedocument.presentationml.presentation";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".PDF")
                        {
                            contentType = "application/pdf";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".XLS")
                        {
                            contentType = "application/vnd.ms-excel";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".XLSX")
                        {
                            contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".XLSM")
                        {
                            contentType = "application/vnd.ms-excel.sheet.macroEnabled.12";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".MP3")
                        {
                            contentType = "audio/mpeg";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".MP4")
                        {
                            contentType = "video/mp4";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".AVI")
                        {
                            contentType = "video/avi";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".WMA")
                        {
                            contentType = "audio/x-ms-wma";
                        }
                        else
                            return null;
                        var response = new FileStreamResult(myInputStream, contentType);
                        response.FileDownloadName = doc.FileName;
                        objectContext.FullPartialllyLoadedObjects();
                        return response;
                    }
                    else
                    {
                        throw new FileNotFoundException("Document ilgili input ile bulunamadý. Input Body : " + JSONHelper.ToJSON(input));
                    }
                }
                catch (Exception f)
                {
                    throw f;
                }
            }
        }
    }
}