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
using Core.Security;
using Newtonsoft.Json.Linq;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class LogisticDashboardController : Controller
    {
        public class QueryInputDVO
        {
            public string ObjId
            {
                get;
                set;
            }

            public string Store
            {
                get;
                set;
            }

            public DateTime? Months
            {
                get;
                set;
            }

            public string Material
            {
                get;
                set;
            }

            public string accountingTermObjId
            {
                get;
                set;
            }

            public bool selectMonth
            {
                get;
                set;
            }
        }

        public class SubStoreWorksInputDVO
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int AllReport { get; set; }
            public string Store { get; set; }
        }

        public class SubStoreWorksOutputDVO
        {
            public string StoreName { get; set; }
            public int StockActionID { get; set; }
            public string DestinationStore { get; set; }
            public DateTime WorklistDate { get; set; }
            public string StateName { get; set; }
            public string ObjectName { get; set; }
            public Guid ObjectID { get; set; }
        }

        public class QueryVademecumInteractionDVO
        {
            public string episodeID
            {
                get;
                set;
            }
            public List<VademecumOnline.Product> prdList
            {
                get;
                set;
            }

            public List<VademecumOnline.Disease> diseaseList
            {
                get;
                set;
            }

            public List<VademecumOnline.ICDCode> icdCodeList
            {
                get;
                set;
            }

            public List<VademecumOnline.Symptom> symptomList
            {
                get;
                set;
            }

            public List<VademecumOnline.Nutrition> nutritionList
            {
                get;
                set;
            }

            public VademecumOnline.PatientCharacteristics patientCharacteristics
            {
                get;
                set;
            }
        }

        public class QueryVademecumInteractionDVONew
        {
            public string episodeID
            {
                get;
                set;
            }
            public List<Guid> prdList
            {
                get;
                set;
            }

            public List<VademecumOnline.Disease> diseaseList
            {
                get;
                set;
            }

            public List<VademecumOnline.ICDCode> icdCodeList
            {
                get;
                set;
            }

            public List<VademecumOnline.Symptom> symptomList
            {
                get;
                set;
            }

            public List<VademecumOnline.Nutrition> nutritionList
            {
                get;
                set;
            }

            public VademecumOnline.PatientCharacteristics patientCharacteristics
            {
                get;
                set;
            }
        }

        public class VademecumProductDVO
        {
            public string id
            {
                get;
                set;
            }
        }

        public class DiagnosisByEpisode_Input
        {
            public string episodeID { get; set; }
        }

        public class DiagnosisByEpisode_Output
        {
            public List<DiagnosisItem> diagnosisList { get; set; }
            //public VademecumOnline.PatientCharacteristics characteristicModel { get; set; }
        }

        public class DiagnosisItem
        {
            public string diagnosisName { get; set; }
            public string diagnosisCode { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DiagnosisByEpisode_Output FetchDiagnoses(DiagnosisByEpisode_Input inputdvo)
        {
            TTObjectContext context = new TTObjectContext(true);
            //Episode episode = (Episode)context.GetObject(new Guid(inputdvo.episodeID), typeof(Episode));
            //CharacteristicModel characteristicModel = episode.GetPatientCharacteristics();
            List<DiagnosisItem> diagnosisListForMyOutput = new List<DiagnosisItem>();
            //VademecumOnline.PatientCharacteristics patientCharacteristics = null;
            BindingList<DiagnosisGrid.GetDiagnosisByEpisode_Class> diagnosisList = DiagnosisGrid.GetDiagnosisByEpisode(context, inputdvo.episodeID);
            foreach (DiagnosisGrid.GetDiagnosisByEpisode_Class item in diagnosisList)
            {
                DiagnosisItem diagnosisItem = new DiagnosisItem();
                diagnosisItem.diagnosisName = item.Name;
                diagnosisItem.diagnosisCode = item.Code;
                diagnosisListForMyOutput.Add(diagnosisItem);
            }
            //if(characteristicModel != null)
            //{
            //    patientCharacteristics = new VademecumOnline.PatientCharacteristics();
            //    patientCharacteristics.weight = String.IsNullOrEmpty(characteristicModel.Weight) ? 0 : Int32.Parse(characteristicModel.Weight.Trim());
            //    patientCharacteristics.height = String.IsNullOrEmpty(characteristicModel.Height) ? 0 : Int32.Parse(characteristicModel.Height.Trim());
            //    patientCharacteristics.birthdate = characteristicModel.BirthDate;
            //    patientCharacteristics.pregnancyDate = characteristicModel.PregnancyDate;
            //    patientCharacteristics.gender = characteristicModel.Gender;
            //    patientCharacteristics.smokingHabit = characteristicModel.SmokingHabit;
            //    patientCharacteristics.drugHabit = characteristicModel.DrugHabit;
            //    patientCharacteristics.pregnant = characteristicModel.IsPregnant;
            //}

            DiagnosisByEpisode_Output output = new DiagnosisByEpisode_Output();
            output.diagnosisList = diagnosisListForMyOutput;
            //output.characteristicModel = patientCharacteristics;
            return output;
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LogisticDashboardViewModel GetRoleControlDashboard()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                LogisticDashboardViewModel model = new LogisticDashboardViewModel();
                if (TTUser.CurrentUser.HasRole(TTRoleNames.Dasboard_Maliyet_Analizi) != true)
                {
                    model.hasRoleDashboardCostAction = false;
                }
                else
                {
                    model.hasRoleDashboardCostAction = true;
                }
                if (TTUser.CurrentUser.HasRole(TTRoleNames.Dashboard_Malzeme_Mevcut_Durumu) != true)
                {
                    model.hasRoleDashboardMaterialStatus = false;
                }
                else
                {
                    model.hasRoleDashboardMaterialStatus = true;
                }

                if (TTUser.CurrentUser.HasRole(TTRoleNames.Dashboard_Min_Max_Seviye) != true)
                {
                    model.hasRoleDashboardMinMax = false;
                }
                else
                {
                    model.hasRoleDashboardMinMax = true;
                }

                if (TTUser.CurrentUser.HasRole(TTRoleNames.Cep_Depo_Miad_Guncelleme)) // Lojistik Veri Düzeltme Yetkisi
                {
                    model.hasRoleSubStoreExpDateUpdate = true;
                }
                else
                {
                    model.hasRoleSubStoreExpDateUpdate = false;
                }

                if (TTUser.CurrentUser.HasRole(TTRoleNames.Cep_Depo_Bekleyen_Isler))
                {
                    model.hasRoleSubStoreWaitingWorks = true;
                }
                else
                {
                    model.hasRoleSubStoreWaitingWorks = false;
                }

                string openCloseTerm = TTObjectClasses.SystemParameter.GetParameterValue("OPENCLOSETERM", "FALSE");
                if (openCloseTerm == "TRUE")
                {
                    if (TTUser.CurrentUser.HasRole(TTRoleNames.Donem_Acma_Kapatma_Islemi_Yeni))
                    {
                        model.hasRoleOpenCloseTerm = false;
                    }
                    else
                    {
                        model.hasRoleOpenCloseTerm = true;
                    }
                }
                else
                {
                    model.hasRoleOpenCloseTerm = true;
                }
                IBindingList budgetTypeList = objectContext.QueryObjects("BUDGETTYPEDEFINITION", string.Empty);
                model.budgetTypeSources = new List<BudgetTypeSource>();
                model.budgetTypeSources.Add(new BudgetTypeSource
                {
                    objectID = new Guid().ToString(),
                    name = "Tümü"
                });
                foreach (BudgetTypeDefinition budget in budgetTypeList)
                {
                    BudgetTypeSource budgetTypeSource = new BudgetTypeSource();
                    budgetTypeSource.objectID = budget.ObjectID.ToString();
                    budgetTypeSource.name = budget.Name;
                    model.budgetTypeSources.Add(budgetTypeSource);
                }
                model.defaultBudgetType = model.budgetTypeSources.FirstOrDefault(x => x.name == "Döner Sermaye");
                objectContext.FullPartialllyLoadedObjects();
                return model;
            }
        }



        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Dashboard_Ana_Ekran)]
        public LogisticDashboardViewModel Query3(QueryInputDVO inputdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                LogisticDashboardViewModel model = new LogisticDashboardViewModel();
                Store store = (Store)objectContext.GetObject(new Guid(inputdvo.Store), typeof(Store));
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

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Dashboard_Ana_Ekran)]
        public LogisticDashboardViewModel Query2(QueryInputDVO inputdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                LogisticDashboardViewModel model = new LogisticDashboardViewModel();
                List<CostActionSelectBox> costActionDesciption = new List<CostActionSelectBox>();
                List<ArchitectureInfo> architectureInfo = new List<Models.ArchitectureInfo>();
                //BindingList<CostAction> allCostActions = (BindingList<CostAction>)objectContext.QueryObjects("COSTACTION", "STORE = '" + inputdvo.Store + "' AND CURRENTSTATEDEFID = " + TTConnectionManager.ConnectionManager.GuidToString(CostAction.States.Completed), "STARTDATE");
                BindingList<CostAction> allCostActions = (BindingList<CostAction>)objectContext.QueryObjects("COSTACTION", "ACCOUNTINGTERM = '" + inputdvo.accountingTermObjId + "' AND CURRENTSTATEDEFID = " + TTConnectionManager.ConnectionManager.GuidToString(CostAction.States.Completed), "STARTDATE");
                foreach (CostAction costAct in allCostActions)
                {
                    CostActionSelectBox cs = new CostActionSelectBox();
                    cs.Objetid = costAct.ObjectID.ToString();
                    cs.costActionDesciption = TTUtils.Globals.NoTurkish(costAct.CostActionDesciption.Replace(" ", ""));
                    costActionDesciption.Add(cs);
                    foreach (CostActionMaterial materialCost in costAct.CostActionMaterials)
                    {
                        ArchitectureInfo architectureInfoDetail = new ArchitectureInfo();
                        architectureInfoDetail.yearKey = TTUtils.Globals.NoTurkish(costAct.CostActionDesciption.Replace(" ", ""));
                        architectureInfoDetail.year = costAct.CostActionDesciption;
                        architectureInfoDetail.cluster = Convert.ToDouble(materialCost.AvarageUnitePrice);
                        architectureInfoDetail.ObjId = materialCost.Material.ObjectID.ToString();
                        architectureInfoDetail.MaterialName = materialCost.Material.Name;
                        architectureInfo.Add(architectureInfoDetail);
                    }
                }

                model.architectureInfo = architectureInfo;
                model.costActionSelectBox = costActionDesciption;
                objectContext.FullPartialllyLoadedObjects();
                return model;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Dashboard_Ana_Ekran)]
        public LogisticDashboardViewModel Query(QueryInputDVO inputdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                LogisticDashboardViewModel model = new LogisticDashboardViewModel();
                List<DashboardGridItemModel> dashboardGridList = new List<DashboardGridItemModel>();
                List<CostActionSelectBox> costActionDesciption = new List<CostActionSelectBox>();
                List<Stock> stockListDetay = new List<Stock>();
                model.MinMaxCalcTypes = new List<MinMaxCalcTypeEnum>();
                model.MinMaxCalcTypes.Add(MinMaxCalcTypeEnum.Monthly);
                model.MinMaxCalcTypes.Add(MinMaxCalcTypeEnum.ThreeMonths);
                model.MinMaxCalcTypes.Add(MinMaxCalcTypeEnum.SixMonths);
                model.MinMaxCalcTypes.Add(MinMaxCalcTypeEnum.Yearly);
                if (inputdvo.ObjId != null)
                {
                    BindingList<CostAction> c = (BindingList<CostAction>)objectContext.QueryObjects("COSTACTION", "OBJECTID = '" + inputdvo.ObjId + "'");
                    foreach (CostActionMaterial costActionMaterialsDetail in c[0].CostActionMaterials)
                    {
                        DashboardGridItemModel dashboardListItemModel = new DashboardGridItemModel();
                        dashboardListItemModel.ObjectID = costActionMaterialsDetail.ObjectID.ToString();
                        dashboardListItemModel.Material = costActionMaterialsDetail.Material.ObjectID.ToString();
                        dashboardListItemModel.MaterialName = costActionMaterialsDetail.Material.ToString();
                        dashboardListItemModel.AvarageUnitePrice = Convert.ToDouble(costActionMaterialsDetail.AvarageUnitePrice);
                        dashboardListItemModel.DifAvarageUnitePrice = Convert.ToDouble(costActionMaterialsDetail.DifAvarageUnitePrice);
                        dashboardListItemModel.MaterialPrice = Convert.ToDouble(costActionMaterialsDetail.MaterialPrice);
                        dashboardListItemModel.PreviousMonthPrice = Convert.ToDouble(costActionMaterialsDetail.PreviousMonthPrice);
                        dashboardListItemModel.PreviousMothInheld = Convert.ToDouble(costActionMaterialsDetail.PreviousMothInheld);
                        dashboardListItemModel.ProfitAndLoss = Convert.ToDouble(costActionMaterialsDetail.ProfitAndLoss);
                        dashboardListItemModel.TotalAmount = Convert.ToDouble(costActionMaterialsDetail.TotalAmount);
                        dashboardListItemModel.TotalOutAmunt = Convert.ToDouble(costActionMaterialsDetail.TotalOutAmunt);
                        dashboardListItemModel.TotalPrice = Convert.ToDouble(costActionMaterialsDetail.TotalPrice);
                        dashboardListItemModel.TransferredAmount = Convert.ToDouble(costActionMaterialsDetail.TransferredAmount);
                        dashboardGridList.Add(dashboardListItemModel);
                    }

                    model.dashboardGridItemModel = dashboardGridList;
                }

                if (inputdvo.Material != null)
                {
                    BindingList<Stock> stockList = (BindingList<Stock>)objectContext.QueryObjects("STOCK", "STORE = '" + inputdvo.Store + "' AND MATERIAL = '" + inputdvo.Material + "'"); //+ inputdvo.Store
                    List<MaterialDetail> materialDetail = new List<MaterialDetail>();
                    Dictionary<StockTransactionDefinition, Dictionary<string, double>> dictionaryIn = new Dictionary<StockTransactionDefinition, Dictionary<string, double>>();
                    Dictionary<StockTransactionDefinition, Dictionary<string, double>> dictionaryOut = new Dictionary<StockTransactionDefinition, Dictionary<string, double>>();
                    List<StockGiris> stockGirisList = new List<StockGiris>();
                    List<StockCikis> stockCikisList = new List<StockCikis>();
                    List<StockActionWorkListDashboardItemModel> stockactionlist = new List<StockActionWorkListDashboardItemModel>();
                    List<StockDataInformation> StockDataInformation = new List<StockDataInformation>();
                    List<StockDataLevelType> StockDataLevelType = new List<StockDataLevelType>();
                    List<StockBudgetType> StockBudgetTypes = new List<StockBudgetType>();
                    List<MaterialInheldMaxMin> MaterialInheldMaxMin = new List<Models.MaterialInheldMaxMin>();
                    foreach (Stock st in stockList)
                    {
                        MaterialDetail detail = new MaterialDetail();
                        MaterialInheldMaxMin inheldS = new Models.MaterialInheldMaxMin();
                        detail.barcode = st.Material.Barcode;
                        detail.distibutiontype = st.Material.StockCard.DistributionType.DistributionType;
                        detail.Inheld = Convert.ToInt32(st.Inheld);
                        detail.materialName = st.Material.Name;
                        if (st.MaximumLevel != null)
                            detail.StockInheldMaxLevel = Convert.ToDouble(st.MaximumLevel);
                        else
                            detail.StockInheldMaxLevel = 0.0;
                        if (st.MinimumLevel != null)
                            detail.StockInheldMinLevel = Convert.ToDouble(st.MinimumLevel);
                        else
                            detail.StockInheldMinLevel = 0.0;
                        inheldS.inheld = detail.Inheld;
                        inheldS.maxInheld = detail.StockInheldMaxLevel;
                        inheldS.minInheld = detail.StockInheldMinLevel;
                        MaterialInheldMaxMin.Add(inheldS);
                        if (st.Material.MaterialPicture != null)
                        {
                            //TODO: RESİM BURDA YÜKLENECEK!!!!
                            /* TypeConverter objConverter = TypeDescriptor.GetConverter(st.Material.MaterialPicture.GetType());
                                 byte[] data = (byte[])objConverter.ConvertTo(st.Material.MaterialPicture, typeof(byte[]));
                                 detail.materialPicture = data;*/
                        }

                        detail.ObjectID = st.Material.ObjectID.ToString();
                        detail.totalIn = Convert.ToDouble(st.TotalIn);
                        detail.totalInPrice = Convert.ToDouble(st.TotalInPrice).ToString() + " ₺";
                        detail.totalOut = Convert.ToDouble(st.TotalOut);
                        detail.totalOutPrice = Convert.ToDouble(st.TotalOutPrice).ToString() + " ₺";
                        detail.materialMKYSCod = st.Material.StockCard.NATOStockNO;
                        detail.storageConditions = st.Material.StorageConditions;
                        detail.estimatedTimeOfCheck = st.Material.EstimatedTimeOfCheck.ToString() + " - GÜN";
                        BindingList<StockTransaction.LOTOutableStockTransactions_Class> outableStockTransactions = StockTransaction.LOTOutableStockTransactions(st.ObjectID);
                        foreach (StockTransaction.LOTOutableStockTransactions_Class outableStockTransaction in outableStockTransactions)
                        {
                            StockDataInformation stockDataInformation = new StockDataInformation();
                            stockDataInformation.LotNo = outableStockTransaction.LotNo;
                            if (outableStockTransaction.ExpirationDate == null)
                                stockDataInformation.ExpirationDate = DateTime.MinValue;
                            else
                                stockDataInformation.ExpirationDate = (DateTime)outableStockTransaction.ExpirationDate;
                            stockDataInformation.ResAmount = (Currency)CurrencyType.ConvertFrom(outableStockTransaction.Restamount);
                            StockDataInformation.Add(stockDataInformation);
                        }

                        BindingList<StockTransaction.OutableStockTrasnactionByBudgetType_Class> budgetTransactions = StockTransaction.OutableStockTrasnactionByBudgetType(st.ObjectID);
                        foreach (StockTransaction.OutableStockTrasnactionByBudgetType_Class budget in budgetTransactions)
                        {
                            StockBudgetType stockBudgetType = new StockBudgetType();
                            BindingList<BudgetTypeDefinition> budDef = (BindingList<BudgetTypeDefinition>)objectContext.QueryObjects("BUDGETTYPEDEFINITION", "OBJECTID = '" + budget.BudgetTypeDefinition.ToString() + "'");
                            stockBudgetType.BudgetType = budDef[0].Name;
                            stockBudgetType.Amount = (Currency)CurrencyType.ConvertFrom(budget.Restamount);
                            StockBudgetTypes.Add(stockBudgetType);
                        }

                        detail.StockBudgetType = StockBudgetTypes;
                        foreach (StockLevel level in st.StockLevels)
                        {
                            StockDataLevelType stockDataLevelType = new Models.StockDataLevelType();
                            StockLevelType type = level.StockLevelType;
                            stockDataLevelType.StockLevelType = (TTObjectClasses.StockLevelTypeEnum)type.StockLevelTypeStatus;
                            stockDataLevelType.Amount = (Currency)level.Amount;
                            StockDataLevelType.Add(stockDataLevelType);
                        }

                        detail.MaterialInheldMaxMin = MaterialInheldMaxMin;
                        detail.StockDataInformation = StockDataInformation;
                        detail.StockDataLevelType = StockDataLevelType;
                        #region giriş çıkış grafikleri doldurma
                        DateTime StartDate = DateTime.Now;
                        DateTime EndDate = DateTime.Now;
                        BindingList<StockTransaction> transactionsByDatesAndStocks = new BindingList<StockTransaction>();
                        if (inputdvo.accountingTermObjId != null)
                        {
                            AccountingTerm term = (AccountingTerm)objectContext.GetObject(new Guid(inputdvo.accountingTermObjId), typeof(AccountingTerm));
                            StartDate = (DateTime)term.StartDate;
                            EndDate = (DateTime)term.EndDate;

                            // nql = " AND STOCKACTIONDETAIL.STOCKACTION.ACCOUNTINGTERM.STARTDATE BETWEEN " + Globals.CreateNQLToDateParameter((DateTime)StartDate) + " AND " + Globals.CreateNQLToDateParameter((DateTime)EndDate) + " AND STOCKACTIONDETAIL.STOCKACTION.ACCOUNTINGTERM.ENDDATE BETWEEN " + Globals.CreateNQLToDateParameter((DateTime)StartDate) + " AND " + Globals.CreateNQLToDateParameter((DateTime)EndDate);
                        }
                        else
                        {
                            string strEnd = "31/12/";
                            string strStart = "01/01/";
                            DateTime time = DateTime.Now;
                            strStart += time.Year.ToString();
                            strEnd += time.Year.ToString();
                            StartDate = Convert.ToDateTime(strStart);
                            EndDate = Convert.ToDateTime(strEnd);
                            // nql = "AND TRANSACTIONDATE BETWEEN " + Globals.CreateNQLToDateParameter((DateTime)StartDate) + " AND " + Globals.CreateNQLToDateParameter((DateTime)EndDate);
                        }
                        transactionsByDatesAndStocks = StockTransaction.GetCompTransByDatesAndStock(objectContext, st.ObjectID, StartDate, EndDate, "");

                        foreach (StockTransaction stockTransaction in transactionsByDatesAndStocks) //st.StockTransactions.Select(" CURRENTSTATEDEFID = " + TTConnectionManager.ConnectionManager.GuidToString(StockTransaction.States.Completed) + nql)) // , "STOCKACTIONDETAIL.STOCKACTION.STOCKACTIONID"
                        {
                            if (stockTransaction.InOut == TransactionTypeEnum.In) // GİRİŞ
                            {
                                if (dictionaryIn.ContainsKey(stockTransaction.StockTransactionDefinition))
                                {
                                    Dictionary<string, double> temp = dictionaryIn[stockTransaction.StockTransactionDefinition];
                                    if (temp.ContainsKey(ProducerByStockTranactionIN(stockTransaction)))
                                    {
                                        temp[ProducerByStockTranactionIN(stockTransaction)] += Convert.ToDouble(stockTransaction.Amount);
                                    }
                                    else
                                    {
                                        temp.Add(ProducerByStockTranactionIN(stockTransaction), Convert.ToDouble(stockTransaction.Amount));
                                    }

                                    dictionaryIn[stockTransaction.StockTransactionDefinition] = temp;
                                }
                                else
                                {
                                    Dictionary<string, double> temp2 = new Dictionary<string, double>();
                                    temp2.Add(ProducerByStockTranactionIN(stockTransaction), Convert.ToDouble(stockTransaction.Amount));
                                    dictionaryIn.Add(stockTransaction.StockTransactionDefinition, temp2);
                                }
                            }

                            if (stockTransaction.InOut == TransactionTypeEnum.Out) //ÇIKIŞ 
                            {
                                if (dictionaryOut.ContainsKey(stockTransaction.StockTransactionDefinition))
                                {
                                    Dictionary<string, double> temp = dictionaryOut[stockTransaction.StockTransactionDefinition];
                                    if (temp.ContainsKey(ProducerByStockTranactionOUT(stockTransaction)))
                                    {
                                        temp[ProducerByStockTranactionOUT(stockTransaction)] += Convert.ToDouble(stockTransaction.Amount);
                                    }
                                    else
                                    {
                                        temp.Add(ProducerByStockTranactionOUT(stockTransaction), Convert.ToDouble(stockTransaction.Amount));
                                    }

                                    dictionaryOut[stockTransaction.StockTransactionDefinition] = temp;
                                }
                                else
                                {
                                    Dictionary<string, double> temp2 = new Dictionary<string, double>();
                                    temp2.Add(ProducerByStockTranactionOUT(stockTransaction), Convert.ToDouble(stockTransaction.Amount));
                                    dictionaryOut.Add(stockTransaction.StockTransactionDefinition, temp2);
                                }
                            }

                            if (stockTransaction.StockActionDetail.StockAction is StockAction)
                            {

                                StockAction sa = (StockAction)stockTransaction.StockActionDetail.StockAction;
                                if (stockactionlist.Select(x => x.ObjectID == sa.ObjectID.ToString()).Any())
                                {
                                    StockActionWorkListDashboardItemModel find = stockactionlist.Where(x => x.ObjectID == sa.ObjectID.ToString()).FirstOrDefault();
                                    if (find != null)
                                        find.Amount += (double)stockTransaction.Amount;
                                }
                                else
                                {
                                    StockActionWorkListDashboardItemModel sai = new StockActionWorkListDashboardItemModel();
                                    sai.ObjectID = sa.ObjectID.ToString();
                                    sai.StockActionID = (int)sa.StockActionID.Value;
                                    sai.StockActionType = (TransactionTypeEnum)stockTransaction.StockTransactionDefinition.TransactionType;
                                    if (sa.DestinationStore != null)
                                        sai.DestinationStore = sa.DestinationStore.Name;
                                    sai.StockactionName = sa.ObjectDef.DisplayText;
                                    sai.TransactionDate = (DateTime)sa.WorkListDate.Value.Date;
                                    sai.Amount = (double)stockTransaction.Amount;
                                    if (sa.CurrentStateDef != null)
                                    {
                                        sai.StateName = sa.CurrentStateDef.DisplayText;
                                        sai.StateFormName = sa.CurrentStateDef.FormDef.CodeName;
                                    }

                                    if (sa is KSchedule)
                                    {
                                        if (((KSchedule)sa).Episode != null)
                                            sai.PatientName = ((KSchedule)sa).Episode.Patient.FullName;
                                    }
                                    if (sa is StockOut)
                                    {
                                        foreach (StockActionDetail det in sa.StockActionDetails)
                                        {
                                            IBindingList subActionMaterials = objectContext.QueryObjects(typeof(SubActionMaterial).Name, "STOCKACTIONDETAIL =" + TTConnectionManager.ConnectionManager.GuidToString(det.ObjectID));
                                            if (subActionMaterials.Count > 0)
                                            {
                                                if (((SubActionMaterial)subActionMaterials[0]).Episode != null)
                                                    sai.PatientName = ((SubActionMaterial)subActionMaterials[0]).Episode.Patient.FullName;
                                            }
                                        }
                                    }

                                    stockactionlist.Add(sai);
                                }
                            }
                        }

                        foreach (KeyValuePair<StockTransactionDefinition, Dictionary<string, double>> baseDicItem in dictionaryIn)
                        {
                            double tempTotalAmount = 0;
                            StockGiris stockGirisItem = new StockGiris();
                            List<StockGirisDetay> stockGirisDetayList = new List<StockGirisDetay>();
                            stockGirisItem.Description = baseDicItem.Key.Description;
                            foreach (KeyValuePair<string, double> innerDicItem in baseDicItem.Value)
                            {
                                StockGirisDetay stockGirisDetayItem = new StockGirisDetay();
                                stockGirisDetayItem.description = innerDicItem.Key;
                                stockGirisDetayItem.amount = innerDicItem.Value;
                                tempTotalAmount += innerDicItem.Value;
                                stockGirisDetayList.Add(stockGirisDetayItem);
                            }

                            stockGirisItem.Amount = tempTotalAmount;
                            stockGirisItem.stockGirisDetayList = stockGirisDetayList;
                            stockGirisList.Add(stockGirisItem);
                        }

                        foreach (KeyValuePair<StockTransactionDefinition, Dictionary<string, double>> baseDicItem in dictionaryOut)
                        {
                            double tempTotalAmount = 0;
                            StockCikis stockCikisItem = new StockCikis();
                            List<StockCikisDetay> stockCikisDetayList = new List<StockCikisDetay>();
                            stockCikisItem.Description = baseDicItem.Key.Description;
                            foreach (KeyValuePair<string, double> innerDicItem in baseDicItem.Value)
                            {
                                StockCikisDetay stockCikisDetayItem = new StockCikisDetay();
                                stockCikisDetayItem.description = innerDicItem.Key;
                                stockCikisDetayItem.amount = innerDicItem.Value;
                                tempTotalAmount += innerDicItem.Value;
                                stockCikisDetayList.Add(stockCikisDetayItem);
                            }

                            stockCikisItem.Amount = tempTotalAmount;
                            stockCikisItem.stockCikisDetayList = stockCikisDetayList;
                            stockCikisList.Add(stockCikisItem);
                        }

                        #endregion
                        materialDetail.Add(detail);
                    }

                    model.stockactionlist = stockactionlist;
                    model.stockGiris = stockGirisList;
                    model.stockCikis = stockCikisList;
                    model.materialDetail = materialDetail;
                }
                model.Material = inputdvo.Material;
                objectContext.FullPartialllyLoadedObjects();
                return model;
            }
        }


        public List<SubStoreWorksOutputDVO> getSubStoreWaitingWorks(SubStoreWorksInputDVO input)
        {
            List<SubStoreWorksOutputDVO> WorListOutputList = new List<SubStoreWorksOutputDVO>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<StockAction.GetSubStoreWaitingWorks_Class> list = StockAction.GetSubStoreWaitingWorks(input.StartDate, input.EndDate, input.AllReport, input.Store).ToList();
                foreach (var item in list)
                {
                    SubStoreWorksOutputDVO WorkListModel = new SubStoreWorksOutputDVO();

                    WorkListModel.StoreName = item.Storename;
                    WorkListModel.DestinationStore = item.Destinationstorename;
                    WorkListModel.StockActionID = (int)item.StockActionID.Value;
                    WorkListModel.StateName = item.DisplayText;
                    WorkListModel.WorklistDate = item.WorkListDate.Value;
                    WorkListModel.ObjectName = item.Objtext;
                    WorkListModel.ObjectID = item.ObjectID.Value;

                    WorListOutputList.Add(WorkListModel);
                }

                return WorListOutputList;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.Dashboard_Ana_Ekran)]
        public string ProducerByStockTranactionIN(StockTransaction stockTransaction)
        {
            string supplier = "";
            if (stockTransaction.StockActionDetail.StockAction != null)
            {
                if (stockTransaction.StockActionDetail.StockAction is ChattelDocumentInputWithAccountancy) //GİRİŞ
                {
                    supplier = ((ChattelDocumentInputWithAccountancy)stockTransaction.StockActionDetail.StockAction).Accountancy.Name;
                }
                else if (stockTransaction.StockActionDetail.StockAction is ChattelDocumentWithPurchase) //SATINALMAGİRİŞ
                {
                    supplier = ((ChattelDocumentWithPurchase)stockTransaction.StockActionDetail.StockAction).Supplier.Name;
                }
                else if (stockTransaction.StockActionDetail.StockAction is ReturningDocument) //İADE BELGESİ
                {
                    supplier = ((ReturningDocument)stockTransaction.StockActionDetail.StockAction).Store.Name;
                }
                else if (stockTransaction.StockActionDetail.StockAction is GrantMaterial) //Bağış
                {
                    supplier = ((GrantMaterial)stockTransaction.StockActionDetail.StockAction).MaterialGranttedBy;
                }
                else if (stockTransaction.StockActionDetail.StockAction is MainStoreStockTransfer) //Ambarlar Arası Transfer
                {
                    supplier = ((MainStoreStockTransfer)stockTransaction.StockActionDetail.StockAction).Store.Name;
                }
                else if (stockTransaction.StockActionDetail.StockAction is GeneralProductionAction) //Genel Üretim
                {
                    supplier = ((GeneralProductionAction)stockTransaction.StockActionDetail.StockAction).Store.Name;
                }
                else if (stockTransaction.StockActionDetail.StockAction is ExtendExpirationDate) //miad
                {
                    supplier = ((ExtendExpirationDate)stockTransaction.StockActionDetail.StockAction).Store.Name;
                }
            }
            else
                supplier = TTUtils.CultureService.GetText("M25275", "Bilinmiyor");
            return supplier;
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.Dashboard_Ana_Ekran)]
        public string ProducerByStockTranactionOUT(StockTransaction stockTransaction)
        {
            string destinationpoint = "";
            if (stockTransaction.StockActionDetail.StockAction != null)
            {
                if (stockTransaction.StockActionDetail.StockAction is ChattelDocumentOutputWithAccountancy) //Çıkış
                {
                    destinationpoint = ((ChattelDocumentOutputWithAccountancy)stockTransaction.StockActionDetail.StockAction).Accountancy.Name;
                }
                else if (stockTransaction.StockActionDetail.StockAction is DistributionDocument) //Dağıtım
                {
                    destinationpoint = ((DistributionDocument)stockTransaction.StockActionDetail.StockAction).DestinationStore.Name;
                }
                else if (stockTransaction.StockActionDetail.StockAction is MainStoreStockTransfer) //Ambarlar Arası Transfer
                {
                    destinationpoint = ((MainStoreStockTransfer)stockTransaction.StockActionDetail.StockAction).DestinationStore.Name;
                }
                else if (stockTransaction.StockActionDetail.StockAction is DeleteRecordDocumentDestroyable) //kayıt silme yok edilen
                {
                    destinationpoint = ((DeleteRecordDocumentDestroyable)stockTransaction.StockActionDetail.StockAction).Store.Name;
                }
                else if (stockTransaction.StockActionDetail.StockAction is ExtendExpirationDate) //miad uzatım işlemi
                {
                    destinationpoint = ((ExtendExpirationDate)stockTransaction.StockActionDetail.StockAction).Store.Name;
                }
            }
            else
                destinationpoint = TTUtils.CultureService.GetText("M25275", "Bilinmiyor");
            return destinationpoint;
        }

        public class DynamicComponentInfoDVO
        {
            public string ComponentName
            {
                get;
                set;
            }

            public string ModuleName
            {
                get;
                set;
            }

            public string ModulePath
            {
                get;
                set;
            }

            public string objectID
            {
                get;
                set;
            }
        }

        internal static IEnumerable<string> GetParentFolders(TTModuleDef moduleDef)
        {
            yield return TTUtils.Globals.GetModuleName(moduleDef.Name);
            Guid? folderDefId = moduleDef.FolderDefID;
            while (folderDefId != null)
            {
                TTFolderDef folderDef = null;
                if (TTObjectDefManager.Instance.FolderDefs.ContainsKey(folderDefId))
                {
                    folderDef = TTObjectDefManager.Instance.FolderDefs[folderDefId];
                    yield return TTUtils.Globals.GetModuleName(folderDef.CodeName);
                    folderDefId = folderDef.ParentFolderDefID;
                }

                if (!folderDefId.HasValue)
                    yield break;
            }
        }

        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DynamicComponentInfoDVO GetDynamicComponentInfo([FromQuery] string ObjectId)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                TTObject obj = objectContext.GetObject(new Guid(ObjectId), typeof(StockAction));
                var subFolders = GetParentFolders(obj.ObjectDef.ModuleDef);
                var folderPath = string.Join("/", subFolders.Reverse());
                var moduleName = obj.ObjectDef.ModuleDef.Name.GetTsModuleName();
                var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
                dynamicComponentInfo.ComponentName = obj.CurrentStateDef.FormDef.CodeName;
                dynamicComponentInfo.ModuleName = moduleName;
                dynamicComponentInfo.ModulePath = modulePath;
                dynamicComponentInfo.objectID = ObjectId;
                objectContext.FullPartialllyLoadedObjects();
                return dynamicComponentInfo;
            }
        }

        static object GetAuthTokenLock = new object();

        private string GetAuthToken()
        {
            lock (GetAuthTokenLock)
            {
                TTObjectContext context = new TTObjectContext(false);
                var tp = GetTokenFromSystemParameter(context);
                if (tp.LastUpdate.Value.AddMinutes(2) < TTObjectClasses.Common.RecTime())
                {
                    string BaseUrl = TTObjectClasses.SystemParameter.GetParameterValue("VADEMECUMURL", "http://xxxxxx.com");
                    string Username = TTObjectClasses.SystemParameter.GetParameterValue("VADEMECUMUSERNAME", "XXXXXX");
                    string Password = TTObjectClasses.SystemParameter.GetParameterValue("VADEMECUMPASSWORD", "XXXXXX");

                    Uri baseUrl = new Uri(BaseUrl);
                    RestClient client = new RestClient(baseUrl)
                    { Authenticator = new HttpBasicAuthenticator(Username, Password) };

                    RestRequest requestAuth = new RestRequest("v1/auth-token", Method.GET);
                    requestAuth.AddHeader("ApplicationId", "89a15fac0864d562b1ce1aca233db951");
                    IRestResponse responseAuth = client.Execute(requestAuth);
                    TTUtils.Logger.WriteInfo("token response : " + responseAuth.Content);
                    var authResult = JsonConvert.DeserializeObject<VademecumOnline.AuthResult>(responseAuth.Content);

                    if (authResult.data == null || authResult.success == false)
                    {
                        throw new Exception(responseAuth.Content);
                    }
                    tp.Value = authResult.data.Base64Token;
                    context.Save();
                }
                return tp.Value;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string QueryVademecum(QueryVademecumInteractionDVO inputdvo)
        {
            try
            {
                TTObjectContext context = new TTObjectContext(false);

                Episode episode = (Episode)context.GetObject(new Guid(inputdvo.episodeID), typeof(Episode));
                CharacteristicModel characteristicModel = episode.GetPatientCharacteristics();
                VademecumOnline.PatientCharacteristics patientCharacteristics = null;
                if (characteristicModel != null)
                {
                    patientCharacteristics = new VademecumOnline.PatientCharacteristics();
                    patientCharacteristics.weight = String.IsNullOrEmpty(characteristicModel.Weight) ? 0 : Int32.Parse(characteristicModel.Weight.Trim());
                    patientCharacteristics.height = String.IsNullOrEmpty(characteristicModel.Height) ? 0 : Int32.Parse(characteristicModel.Height.Trim());
                    if (characteristicModel.BirthDate != null)
                        patientCharacteristics.birthdate = String.Format("{0:yyyy-MM-dd}", characteristicModel.BirthDate.Value);
                    if (characteristicModel.PregnancyDate != null)
                        patientCharacteristics.pregnancyDate = String.Format("{0:yyyy-MM-dd}", characteristicModel.PregnancyDate.Value);
                    patientCharacteristics.gender = characteristicModel.Gender;
                    patientCharacteristics.smokingHabit = characteristicModel.SmokingHabit;
                    patientCharacteristics.drugHabit = characteristicModel.DrugHabit;
                    patientCharacteristics.pregnant = characteristicModel.IsPregnant;
                }

                List<VademecumOnline.ICDCode> icdCodeList = new List<VademecumOnline.ICDCode>();
                BindingList<DiagnosisGrid.GetDiagnosisByEpisode_Class> diagnosisList = DiagnosisGrid.GetDiagnosisByEpisode(context, inputdvo.episodeID);
                foreach (DiagnosisGrid.GetDiagnosisByEpisode_Class item in diagnosisList)
                {
                    VademecumOnline.ICDCode icdCode = new VademecumOnline.ICDCode();
                    icdCode.name = item.Code;
                    icdCodeList.Add(icdCode);
                }

                TTObjectClasses.SystemParameter tp = GetTokenFromSystemParameter(context);

                string BaseUrl = TTObjectClasses.SystemParameter.GetParameterValue("VADEMECUMURL", "http://xxxxxx.com");

                Uri baseUrl = new Uri(BaseUrl);
                RestClient client = new RestClient(baseUrl);
                RestRequest request = new RestRequest("v1/interaction", Method.POST);
                request.RequestFormat = DataFormat.Json;
                //request.JsonSerializer.ContentType = "application/x-www-form-urlencoded";
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("ApplicationId", "89a15fac0864d562b1ce1aca233db951");
                request.AddHeader("Authorization", "Basic " + tp.Value);
                var jsonProductList = JsonConvert.SerializeObject(inputdvo.prdList);
                var jsonIcdCodeList = JsonConvert.SerializeObject(icdCodeList);
                var jsonPatientCharacteristics = JsonConvert.SerializeObject(patientCharacteristics);
                request.AddParameter("products", jsonProductList);
                request.AddParameter("icdcodes", jsonIcdCodeList);
                request.AddParameter("patient-characteristics", jsonPatientCharacteristics);
                request.AddParameter("_format", "html", ParameterType.QueryString);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.Content.Contains("\"code\":9001"))
                {
                    TTUtils.Logger.WriteInfo("request response status code : " + response.StatusCode + "Token : " + tp.Value + " Content : " + response.Content);
                    var token = GetAuthToken();
                    if (token == null)
                        return "GetAuthToken returns null";

                    Uri sbaseUrl = new Uri(BaseUrl);
                    RestClient sclient = new RestClient(sbaseUrl);
                    RestRequest srequest = new RestRequest("v1/interaction", Method.POST);
                    srequest.RequestFormat = DataFormat.Json;
                    //srequest.JsonSerializer.ContentType = "application/x-www-form-urlencoded";
                    srequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    srequest.AddHeader("ApplicationId", "89a15fac0864d562b1ce1aca233db951");
                    srequest.AddHeader("Authorization", "Basic " + token);
                    var sjsonProductList = JsonConvert.SerializeObject(inputdvo.prdList);
                    var sjsonIcdCodeList = JsonConvert.SerializeObject(icdCodeList);
                    var sjsonPatientCharacteristics = JsonConvert.SerializeObject(patientCharacteristics);
                    srequest.AddParameter("products", sjsonProductList);
                    srequest.AddParameter("icdcodes", sjsonIcdCodeList);
                    srequest.AddParameter("patient-characteristics", sjsonPatientCharacteristics);
                    srequest.AddParameter("_format", "html", ParameterType.QueryString);
                    IRestResponse sresponse = sclient.Execute(srequest);
                    return sresponse.Content;
                }
                else
                {
                    return response.Content;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string QueryVademecumNew(QueryVademecumInteractionDVONew inputdvo)
        {
            try
            {
                TTObjectContext context = new TTObjectContext(false);

                Episode episode = (Episode)context.GetObject(new Guid(inputdvo.episodeID), typeof(Episode));
                CharacteristicModel characteristicModel = episode.GetPatientCharacteristics();
                VademecumOnline.PatientCharacteristics patientCharacteristics = null;
                if (characteristicModel != null)
                {
                    patientCharacteristics = new VademecumOnline.PatientCharacteristics();
                    patientCharacteristics.weight = String.IsNullOrEmpty(characteristicModel.Weight) ? 0 : Int32.Parse(characteristicModel.Weight.Trim());
                    patientCharacteristics.height = String.IsNullOrEmpty(characteristicModel.Height) ? 0 : Int32.Parse(characteristicModel.Height.Trim());
                    if (characteristicModel.BirthDate != null)
                        patientCharacteristics.birthdate = String.Format("{0:yyyy-MM-dd}", characteristicModel.BirthDate.Value);
                    if (characteristicModel.PregnancyDate != null)
                        patientCharacteristics.pregnancyDate = String.Format("{0:yyyy-MM-dd}", characteristicModel.PregnancyDate.Value);
                    patientCharacteristics.gender = characteristicModel.Gender;
                    patientCharacteristics.smokingHabit = characteristicModel.SmokingHabit;
                    patientCharacteristics.drugHabit = characteristicModel.DrugHabit;
                    patientCharacteristics.pregnant = characteristicModel.IsPregnant;
                }

                List<VademecumOnline.ICDCode> icdCodeList = new List<VademecumOnline.ICDCode>();
                BindingList<DiagnosisGrid.GetDiagnosisByEpisode_Class> diagnosisList = DiagnosisGrid.GetDiagnosisByEpisode(context, inputdvo.episodeID);
                foreach (DiagnosisGrid.GetDiagnosisByEpisode_Class item in diagnosisList)
                {
                    VademecumOnline.ICDCode icdCode = new VademecumOnline.ICDCode();
                    icdCode.name = item.Code;
                    icdCodeList.Add(icdCode);
                }

                List<VademecumOnline.Product> productList = new List<VademecumOnline.Product>();

                BindingList<DrugDefinition.GetVademecumIDByDrugObjectID_Class> drugs = DrugDefinition.GetVademecumIDByDrugObjectID(inputdvo.prdList);
                List<VademecumOnline.Product> prod = new List<VademecumOnline.Product>();
                foreach (DrugDefinition.GetVademecumIDByDrugObjectID_Class d in drugs)
                {
                    VademecumOnline.Product p = new VademecumOnline.Product
                    {
                        id = Convert.ToInt32(d.VademecumProductID.Value),
                    };
                    prod.Add(p);
                }

                productList = prod;

                //productList = DrugDefinition.GetVademecumIDByDrugObjectID(inputdvo.prdList).Select(x => new VademecumOnline.Product { id = Convert.ToInt32(x.VademecumProductID.Value) }).ToList();

                TTObjectClasses.SystemParameter tp = GetTokenFromSystemParameter(context);

                string BaseUrl = TTObjectClasses.SystemParameter.GetParameterValue("VADEMECUMURL", "http://xxxxxx.com");

                Uri baseUrl = new Uri(BaseUrl);
                RestClient client = new RestClient(baseUrl);
                RestRequest request = new RestRequest("v1/interaction", Method.POST);
                request.RequestFormat = DataFormat.Json;
                //request.JsonSerializer.ContentType = "application/x-www-form-urlencoded";
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("ApplicationId", "89a15fac0864d562b1ce1aca233db951");
                request.AddHeader("Authorization", "Basic " + tp.Value);
                var jsonProductList = JsonConvert.SerializeObject(productList);
                var jsonIcdCodeList = JsonConvert.SerializeObject(icdCodeList);
                var jsonPatientCharacteristics = JsonConvert.SerializeObject(patientCharacteristics);
                request.AddParameter("products", jsonProductList);
                request.AddParameter("icdcodes", jsonIcdCodeList);
                request.AddParameter("patient-characteristics", jsonPatientCharacteristics);
                request.AddParameter("_format", "html", ParameterType.QueryString);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.Content.Contains("\"code\":9001"))
                {
                    TTUtils.Logger.WriteInfo("request response status code : " + response.StatusCode + "Token : " + tp.Value + " Content : " + response.Content);
                    var token = GetAuthToken();
                    if (token == null)
                        return "GetAuthToken returns null";

                    Uri sbaseUrl = new Uri(BaseUrl);
                    RestClient sclient = new RestClient(sbaseUrl);
                    RestRequest srequest = new RestRequest("v1/interaction", Method.POST);
                    srequest.RequestFormat = DataFormat.Json;
                    //srequest.JsonSerializer.ContentType = "application/x-www-form-urlencoded";
                    srequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    srequest.AddHeader("ApplicationId", "89a15fac0864d562b1ce1aca233db951");
                    srequest.AddHeader("Authorization", "Basic " + token);
                    var sjsonProductList = JsonConvert.SerializeObject(productList);
                    var sjsonIcdCodeList = JsonConvert.SerializeObject(icdCodeList);
                    var sjsonPatientCharacteristics = JsonConvert.SerializeObject(patientCharacteristics);
                    srequest.AddParameter("products", sjsonProductList);
                    srequest.AddParameter("icdcodes", sjsonIcdCodeList);
                    srequest.AddParameter("patient-characteristics", sjsonPatientCharacteristics);
                    srequest.AddParameter("_format", "html", ParameterType.QueryString);
                    IRestResponse sresponse = sclient.Execute(srequest);
                    return sresponse.Content;
                }
                else
                {
                    return response.Content;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        private static TTObjectClasses.SystemParameter GetTokenFromSystemParameter(TTObjectContext context)
        {
            IBindingList tokenParameter = context.QueryObjects("SYSTEMPARAMETER", "NAME='VADEMECUMTOKEN'");
            TTObjectClasses.SystemParameter tp = null;
            if (tokenParameter.Count > 0)
            {
                tp = (TTObjectClasses.SystemParameter)tokenParameter[0];
            }
            return tp;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string GetVademecumProductByID(VademecumProductDVO inputdvo)
        {
            try
            {
                TTObjectContext context = new TTObjectContext(false);

                var tp = GetTokenFromSystemParameter(context);

                string vademecumURL = TTObjectClasses.SystemParameter.GetParameterValue("VADEMECUMURL", "http://xxxxxx.com");

                string BaseUrl = vademecumURL + "/v1/product-card/" + inputdvo.id + "?_format=html";
                Uri baseUrl = new Uri(BaseUrl);
                RestClient client = new RestClient(baseUrl);
                RestRequest request = new RestRequest(Method.GET);
                request.AddHeader("ApplicationId", "89a15fac0864d562b1ce1aca233db951");
                request.AddHeader("Authorization", "Basic " + tp.Value);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.Content.Contains("\"code\":9001"))
                {
                    TTUtils.Logger.WriteInfo("request response status code : " + response.StatusCode + "Token : " + tp.Value + " Content : " + response.Content);
                    var token = GetAuthToken();
                    if (token == null)
                        return "GetAuthToken returns null";

                    string surl = vademecumURL + "/v1/product-card/" + inputdvo.id + "?_format=html";
                    Uri sbaseUrl = new Uri(surl);
                    RestClient sclient = new RestClient(sbaseUrl);
                    RestRequest srequest = new RestRequest(Method.GET);
                    srequest.AddHeader("ApplicationId", "89a15fac0864d562b1ce1aca233db951");
                    srequest.AddHeader("Authorization", "Basic " + token);
                    IRestResponse sresponse = sclient.Execute(srequest);
                    return sresponse.Content;
                }
                else
                {
                    return response.Content;
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public class CalcMinMaxValueDVO
        {
            public string id
            {
                get;
                set;
            }

            public MinMaxCalcTypeEnum selectedType
            {
                get;
                set;
            }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public List<string> materialObjectID { get; set; }

            public bool AllProducts { get; set; }
            public bool StockHasInheld { get; set; }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Dashboard_Min_Max_Seviye)]
        public List<MinMaxCalculetedItem> CalcMinMaxValue(CalcMinMaxValueDVO inputdvo)
        {
            List<MinMaxCalculetedItem> calcMinMaxItems = new List<Models.MinMaxCalculetedItem>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {

                Store store = (Store)objectContext.GetObject(new Guid(inputdvo.id), typeof(Store));

                //DateTime startDate = DateTime.Now;
                //DateTime firstDayThisMonth = new DateTime(startDate.Year, startDate.Month, 1);
                //DateTime endDate = firstDayThisMonth.AddDays(-1);
                //if (inputdvo.selectedType == MinMaxCalcTypeEnum.Monthly)
                //    startDate = firstDayThisMonth.AddMonths(-1);
                //if (inputdvo.selectedType == MinMaxCalcTypeEnum.ThreeMonths)
                //    startDate = firstDayThisMonth.AddMonths(-3);
                //if (inputdvo.selectedType == MinMaxCalcTypeEnum.SixMonths)
                //    startDate = firstDayThisMonth.AddMonths(-6);
                //if (inputdvo.selectedType == MinMaxCalcTypeEnum.Yearly)
                //{
                //    startDate = new DateTime(DateTime.Now.AddYears(-1).Year, 1, 1);
                //    endDate = new DateTime(DateTime.Now.AddYears(-1).Year, 12, 31);
                //}

                //if (inputdvo.selectedType == MinMaxCalcTypeEnum.PrevYearMonth)
                //{
                //    startDate = new DateTime(DateTime.Now.AddYears(-1).Year, DateTime.Now.Month, 1);
                //    DateTime previusDay = DateTime.Now.AddYears(-1);
                //    endDate = new DateTime(previusDay.Year, previusDay.AddMonths(1).Month, 1).AddDays(-1);
                //}
                if (!inputdvo.StartDate.HasValue || !inputdvo.EndDate.HasValue)
                    throw new TTException("Başlangıç ve Bitiş Tarihleri boş geçilemez!");

                if (inputdvo.materialObjectID[0] != null && inputdvo.materialObjectID.Count > 0 && inputdvo.AllProducts == false)
                {
                    foreach (string id in inputdvo.materialObjectID)
                    {
                        BindingList<StockTransaction.GetMinMaxLevelCalcQueryWithMaterial_Class> calcItems = StockTransaction.GetMinMaxLevelCalcQueryWithMaterial(store.ObjectID, new Guid(id), inputdvo.StartDate.Value, inputdvo.EndDate.Value);

                        if (calcItems.Count > 0)
                        {
                            foreach (StockTransaction.GetMinMaxLevelCalcQueryWithMaterial_Class item in calcItems)
                            {
                                MinMaxCalculetedItem minMaxCalculetedItem = new Models.MinMaxCalculetedItem();
                                minMaxCalculetedItem.StockObjectID = item.Stock.Value.ToString();
                                minMaxCalculetedItem.MaterialName = item.Name;
                                minMaxCalculetedItem.Inheld = (double)item.Inheld;
                                minMaxCalculetedItem.MinLevel = (double)item.MinimumLevel;
                                minMaxCalculetedItem.CriticalLevel = item.CriticalLevel.HasValue ? (double)item.CriticalLevel : 0;
                                minMaxCalculetedItem.MaxLevel = (double)item.MaximumLevel;
                                minMaxCalculetedItem.OutAmount = Convert.ToDouble(item.Outamount);
                                //double bolen = 1;
                                //if (inputdvo.selectedType == MinMaxCalcTypeEnum.Monthly)
                                //    bolen = 1;
                                //if (inputdvo.selectedType == MinMaxCalcTypeEnum.ThreeMonths)
                                //    bolen = 3;
                                //if (inputdvo.selectedType == MinMaxCalcTypeEnum.SixMonths)
                                //    bolen = 6;
                                //if (inputdvo.selectedType == MinMaxCalcTypeEnum.Yearly)
                                //    bolen = 12;
                                //double aylikOran = (Convert.ToDouble(item.Outamount) / bolen);
                                //double oran = (aylikOran / 100) * 10;
                                //minMaxCalculetedItem.CalcMinLevel = Math.Ceiling(aylikOran - oran);
                                //minMaxCalculetedItem.CalcMaxLevel = Math.Ceiling(aylikOran + oran);
                                if (store is MainStoreDefinition)
                                {
                                    minMaxCalculetedItem.CalcMinLevel = Math.Round(Convert.ToDouble(item.Outamount) / (inputdvo.EndDate.Value - inputdvo.StartDate.Value).Days * 30);
                                    minMaxCalculetedItem.CalcCriticalLevel = Math.Round(Convert.ToDouble(item.Outamount) / (inputdvo.EndDate.Value - inputdvo.StartDate.Value).Days * 45);
                                    minMaxCalculetedItem.CalcMaxLevel = Math.Round(Convert.ToDouble(item.Outamount) / (inputdvo.EndDate.Value - inputdvo.StartDate.Value).Days * 60);

                                }
                                else
                                {
                                    minMaxCalculetedItem.CalcMinLevel = Math.Round(Convert.ToDouble(item.Outamount) / (inputdvo.EndDate.Value - inputdvo.StartDate.Value).Days * 1);
                                    minMaxCalculetedItem.CalcCriticalLevel = Math.Round(Convert.ToDouble(item.Outamount) / (inputdvo.EndDate.Value - inputdvo.StartDate.Value).Days * 3);
                                    minMaxCalculetedItem.CalcMaxLevel = Math.Round(Convert.ToDouble(item.Outamount) / (inputdvo.EndDate.Value - inputdvo.StartDate.Value).Days * 5);
                                }
                                //if (minMaxCalculetedItem.CalcMinLevel == minMaxCalculetedItem.CalcMaxLevel)
                                //    minMaxCalculetedItem.CalcMaxLevel = minMaxCalculetedItem.CalcMaxLevel + 1;
                                calcMinMaxItems.Add(minMaxCalculetedItem);
                            }
                        }
                        else
                        {

                            Material material = (Material)objectContext.GetObject(new Guid(id), typeof(Material));
                            if (material.Stocks.Select("STORE= " + TTConnectionManager.ConnectionManager.GuidToString(store.ObjectID)).Count > 0)
                            {
                                Stock materialStock = material.Stocks.Select("STORE= " + TTConnectionManager.ConnectionManager.GuidToString(store.ObjectID))[0];
                                MinMaxCalculetedItem minMaxCalculetedItem = new Models.MinMaxCalculetedItem();
                                minMaxCalculetedItem.StockObjectID = materialStock.ObjectID.ToString();
                                minMaxCalculetedItem.MaterialName = materialStock.Material.Name;
                                minMaxCalculetedItem.Inheld = (double)materialStock.Inheld;
                                minMaxCalculetedItem.MinLevel = (double)materialStock.MinimumLevel;
                                minMaxCalculetedItem.CriticalLevel = materialStock.CriticalLevel.HasValue ? (double)materialStock.CriticalLevel : 0;
                                minMaxCalculetedItem.MaxLevel = (double)materialStock.MaximumLevel;
                                minMaxCalculetedItem.OutAmount = 0;
                                minMaxCalculetedItem.CalcMinLevel = 0;
                                minMaxCalculetedItem.CalcCriticalLevel = 0;
                                minMaxCalculetedItem.CalcMaxLevel = 0;
                                calcMinMaxItems.Add(minMaxCalculetedItem);

                            }
                        }
                    }
                }
                else
                {
                    List<Guid> stockList = new List<Guid>();
                    BindingList<StockTransaction.GetMinMaxLevelCalcQuery_Class> calcItems = StockTransaction.GetMinMaxLevelCalcQuery(store.ObjectID, inputdvo.StartDate.Value, inputdvo.EndDate.Value);
                    foreach (StockTransaction.GetMinMaxLevelCalcQuery_Class item in calcItems)
                    {
                        MinMaxCalculetedItem minMaxCalculetedItem = new Models.MinMaxCalculetedItem();
                        minMaxCalculetedItem.StockObjectID = item.Stock.Value.ToString();
                        minMaxCalculetedItem.MaterialName = item.Name;
                        minMaxCalculetedItem.Inheld = (double)item.Inheld;
                        minMaxCalculetedItem.MinLevel = (double)item.MinimumLevel;
                        minMaxCalculetedItem.CriticalLevel = item.CriticalLevel.HasValue ? (double)item.CriticalLevel : 0;
                        minMaxCalculetedItem.MaxLevel = (double)item.MaximumLevel;
                        minMaxCalculetedItem.OutAmount = Convert.ToDouble(item.Outamount);
                        //double bolen = 1;
                        //if (inputdvo.selectedType == MinMaxCalcTypeEnum.Monthly)
                        //    bolen = 1;
                        //if (inputdvo.selectedType == MinMaxCalcTypeEnum.ThreeMonths)
                        //    bolen = 3;
                        //if (inputdvo.selectedType == MinMaxCalcTypeEnum.SixMonths)
                        //    bolen = 6;
                        //if (inputdvo.selectedType == MinMaxCalcTypeEnum.Yearly)
                        //    bolen = 12;
                        //double aylikOran = (Convert.ToDouble(item.Outamount) / bolen);
                        //double oran = (aylikOran / 100) * 10;
                        //minMaxCalculetedItem.CalcMinLevel = Math.Ceiling(aylikOran - oran);
                        //minMaxCalculetedItem.CalcMaxLevel = Math.Ceiling(aylikOran + oran);
                        if (store is MainStoreDefinition)
                        {
                            minMaxCalculetedItem.CalcMinLevel = Math.Round(Convert.ToDouble(item.Outamount) / (inputdvo.EndDate.Value - inputdvo.StartDate.Value).Days * 30);
                            minMaxCalculetedItem.CalcCriticalLevel = Math.Round(Convert.ToDouble(item.Outamount) / (inputdvo.EndDate.Value - inputdvo.StartDate.Value).Days * 45);
                            minMaxCalculetedItem.CalcMaxLevel = Math.Round(Convert.ToDouble(item.Outamount) / (inputdvo.EndDate.Value - inputdvo.StartDate.Value).Days * 60);
                        }
                        else
                        {
                            minMaxCalculetedItem.CalcMinLevel = Math.Round(Convert.ToDouble(item.Outamount) / (inputdvo.EndDate.Value - inputdvo.StartDate.Value).Days * 1);
                            minMaxCalculetedItem.CalcCriticalLevel = Math.Round(Convert.ToDouble(item.Outamount) / (inputdvo.EndDate.Value - inputdvo.StartDate.Value).Days * 3);
                            minMaxCalculetedItem.CalcMaxLevel = Math.Round(Convert.ToDouble(item.Outamount) / (inputdvo.EndDate.Value - inputdvo.StartDate.Value).Days * 5);
                        }
                        //if (minMaxCalculetedItem.CalcMinLevel == minMaxCalculetedItem.CalcMaxLevel)
                        //    minMaxCalculetedItem.CalcMaxLevel = minMaxCalculetedItem.CalcMaxLevel + 1;
                        calcMinMaxItems.Add(minMaxCalculetedItem);
                        if (stockList.Contains(item.Stock.Value) == false)
                            stockList.Add(item.Stock.Value);
                    }
                    if (inputdvo.AllProducts)
                    {
                        BindingList<Stock> allStocks = store.Stocks.Select("");
                        foreach (Stock otherStock in allStocks)
                        {
                            if (stockList.Contains(otherStock.ObjectID) == false)
                            {
                                MinMaxCalculetedItem minMaxCalculetedItem = new Models.MinMaxCalculetedItem();
                                minMaxCalculetedItem.StockObjectID = otherStock.ObjectID.ToString();
                                minMaxCalculetedItem.MaterialName = otherStock.Material.Name;
                                minMaxCalculetedItem.Inheld = (double)otherStock.Inheld;
                                minMaxCalculetedItem.MinLevel = (double)otherStock.MinimumLevel;
                                minMaxCalculetedItem.CriticalLevel = otherStock.CriticalLevel.HasValue ? (double)otherStock.CriticalLevel : 0;
                                minMaxCalculetedItem.MaxLevel = (double)otherStock.MaximumLevel;
                                minMaxCalculetedItem.OutAmount = 0;
                                minMaxCalculetedItem.CalcMinLevel = 0;
                                minMaxCalculetedItem.CalcCriticalLevel = 0;
                                minMaxCalculetedItem.CalcMaxLevel = 0;
                                calcMinMaxItems.Add(minMaxCalculetedItem);
                            }
                        }
                    }
                }

                if (inputdvo.StockHasInheld == true)
                    calcMinMaxItems = calcMinMaxItems.Where(x => x.Inheld > 0).ToList();

                objectContext.FullPartialllyLoadedObjects();
                return calcMinMaxItems;
            }
        }

        [HttpGet]
        public List<Stock.GetCriticalStockLevelsNQL_Class> GetCriticalStockLevels(Guid storeObjectID)
        {

            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                if (storeObjectID != null && storeObjectID != Guid.Empty)
                    return Stock.GetCriticalStockLevelsNQL(storeObjectID).ToList();
                else
                    throw new TTException("Depo seçilmedi!");
            }
        }

        public List<MaterialTreeDefinition.GetMaterialTreeForStock_Class> FillMaterialTreeForStock()
        {
            List<MaterialTreeDefinition.GetMaterialTreeForStock_Class> output = MaterialTreeDefinition.GetMaterialTreeForStock(" ", null).ToList();
            return output;

        }

        [HttpGet]
        public List<Material.GetMaterialForStockQuery_Class> GetMaterialListDefinition()
        {
            var list = Material.GetMaterialForStockQuery("AND STOCKCARD.JOINEDSTOCKCARD IS NULL", null).ToList();
            return list;
        }

        public class UpdateMinMaxValueDVO
        {
            public List<MinMaxCalculetedItem> MinMaxCalculetedItems
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Dashboard_Min_Max_Seviye)]
        public string UpdateMinMaxValue(UpdateMinMaxValueDVO inputdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                foreach (MinMaxCalculetedItem item in inputdvo.MinMaxCalculetedItems)
                {
                    Stock stock = (Stock)objectContext.GetObject(new Guid(item.StockObjectID), typeof(Stock));
                    stock.MaximumLevel = Math.Round(item.CalcMaxLevel);
                    stock.CriticalLevel = Math.Round(item.CalcCriticalLevel);
                    stock.MinimumLevel = Math.Round(item.CalcMinLevel);
                }

                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
                return TTUtils.CultureService.GetText("M25751", "Güncelleme yapılmıştır.");
            }
        }



        public class LogisticUserMessageData
        {

            public string sentBy { get; set; }
            public string senderBy { get; set; }
            public string valueForMessage { get; set; }
            public string sentByObjectID { get; set; }
            public string senderByObjectID { get; set; }
            public string subject { get; set; }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void SentToUserMessage(LogisticUserMessageData inputdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                UserMessage newMessage = new UserMessage(objectContext);
                newMessage.InitializeSentMessage();
                newMessage.ToUser = (ResUser)newMessage.ObjectContext.GetObject(new Guid(inputdvo.sentByObjectID), typeof(ResUser));
                newMessage.Subject = inputdvo.subject;
                newMessage.MessageBody = inputdvo.valueForMessage;
                newMessage.IsSystemMessage = true;
                newMessage.IsSplashMessage = false;
                newMessage.MessageFeedback = true;
                objectContext.Save();
            }
        }

        public class InStockTransactionInput
        {
            public string store
            {
                get;
                set;
            }
            public List<string> materials
            {
                get;
                set;
            }
            public string accountingTermObjId
            {
                get;
                set;
            }
            public string budgetTypeObjId
            {
                get;
                set;
            }
            public bool isZeroAmount
            {
                get;
                set;
            }
        }

        public class InStockTransactionDVO
        {
            public string materialName
            {
                get;
                set;
            }
            public double restAmount
            {
                get;
                set;
            }
            public BigCurrency unitPrice
            {
                get;
                set;
            }

            public string stockNo
            {
                get;
                set;
            }


            public string BudgetType
            {
                get;
                set;
            }
            public DateTime transactionDate
            {
                get;
                set;
            }
            public Currency inAmount
            {
                get;
                set;
            }
            public double outAmount
            {
                get;
                set;
            }
            public DateTime expirationDate
            {
                get;
                set;
            }
            public Currency minLevel
            {
                get;
                set;
            }
            public Currency maxLevel
            {
                get;
                set;
            }
            public string barcode
            {
                get;
                set;
            }
            public int MKYSTrxID
            {
                get;
                set;
            }
            public Guid stockTransactionObjectID
            {
                get;
                set;
            }
            public string trxDescription
            {
                get;
                set;
            }

            public string destinationDescription
            {
                get;
                set;
            }

            public string auctionNo
            {
                get;
                set;
            }
            public int stockActionId
            {
                get;
                set;
            }
            public string tifNo
            {
                get;
                set;
            }

            public List<Guid> stockTransactionListObjectID { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Dashboard_Ana_Ekran)]
        public List<InStockTransactionDVO> GetInStockTransactions(InStockTransactionInput input)
        {
            List<InStockTransactionDVO> output = new List<InStockTransactionDVO>();
            List<InStockTransactionDVO> outputPTSDevir = new List<InStockTransactionDVO>();
            List<InStockTransactionDVO> outputPTS = new List<InStockTransactionDVO>();
            List<InStockTransactionDVO> outputFull = new List<InStockTransactionDVO>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                AccountingTerm accountingTerm = (AccountingTerm)objectContext.GetObject(new Guid(input.accountingTermObjId), typeof(AccountingTerm));

                Guid materialObjectID = Guid.Empty;
                if (input.materials != null && input.materials.Count() == 0)
                    input.materials.Add(materialObjectID.ToString());

                foreach (var material in input.materials)
                {
                    materialObjectID = new Guid(material);
                    if (accountingTerm.PrevTerm != null)
                    {
                        BindingList<MkysCensusSyncData.GetInStockTransactionID_Class> censusTRXs = MkysCensusSyncData.GetInStockTransactionID(accountingTerm.PrevTerm.ObjectID);
                        List<Guid> censusTRXIDs = censusTRXs.Select(x => x.StockTransactionGuid.Value).ToList();
                        int listCount = censusTRXIDs.Count();

                        BindingList<StockTransaction.GetCensusStockTransactionLikeMKYS_Class> censusInTRXs = new BindingList<StockTransaction.GetCensusStockTransactionLikeMKYS_Class>();
                        for (int i = 0; i < listCount; i = i + 1000)
                        {
                            List<Guid> tempCensusTRXIDs = censusTRXIDs.Skip(i).Take(1000).ToList();
                            BindingList<StockTransaction.GetCensusStockTransactionLikeMKYS_Class> tempCensusInTRXs = StockTransaction.GetCensusStockTransactionLikeMKYS(tempCensusTRXIDs, materialObjectID, new Guid(input.budgetTypeObjId), accountingTerm.StartDate.Value);
                            foreach (StockTransaction.GetCensusStockTransactionLikeMKYS_Class census in tempCensusInTRXs)
                            {
                                censusInTRXs.Add(census);
                            }
                        }

                        foreach (StockTransaction.GetCensusStockTransactionLikeMKYS_Class census in censusInTRXs)
                        {
                            if (input.isZeroAmount == false && Convert.ToDouble(census.Restamount) == 0)
                                continue;
                            InStockTransactionDVO inStockTransactionDVO = new InStockTransactionDVO();
                            inStockTransactionDVO.barcode = census.Barcode;
                            if (census.ExpirationDate.HasValue)
                                inStockTransactionDVO.expirationDate = census.ExpirationDate.Value;
                            inStockTransactionDVO.inAmount = Convert.ToDouble(census.Censusamount);
                            inStockTransactionDVO.materialName = census.Name;
                            inStockTransactionDVO.BudgetType = census.Budgettypename;
                            inStockTransactionDVO.maxLevel = census.MaximumLevel.Value;
                            inStockTransactionDVO.minLevel = census.MinimumLevel.Value;
                            if (census.MKYS_StokHareketID.HasValue)
                                inStockTransactionDVO.MKYSTrxID = census.MKYS_StokHareketID.Value;
                            inStockTransactionDVO.restAmount = Convert.ToDouble(census.Restamount);
                            inStockTransactionDVO.outAmount = inStockTransactionDVO.inAmount - inStockTransactionDVO.restAmount;
                            inStockTransactionDVO.stockNo = census.NATOStockNO;
                            inStockTransactionDVO.stockTransactionObjectID = census.ObjectID.Value;
                            inStockTransactionDVO.stockTransactionListObjectID = new List<Guid>();
                            inStockTransactionDVO.stockTransactionListObjectID.Add(inStockTransactionDVO.stockTransactionObjectID);
                            inStockTransactionDVO.transactionDate = census.TransactionDate.Value;
                            inStockTransactionDVO.unitPrice = census.UnitPrice.Value;
                            inStockTransactionDVO.trxDescription = "Devir";

                            if (census.Trxdefobjectid.Value == new Guid("e5f7428e-3125-413d-8964-8537993b38e4"))
                            {
                                ChattelDocumentWithPurchase chattelDocumentWithPurchase = (ChattelDocumentWithPurchase)objectContext.GetObject(census.Stockactionobjectid.Value, typeof(ChattelDocumentWithPurchase));
                                if (chattelDocumentWithPurchase.Supplier != null)
                                    inStockTransactionDVO.destinationDescription = chattelDocumentWithPurchase.Supplier.Name;
                                inStockTransactionDVO.auctionNo = chattelDocumentWithPurchase.RegistrationAuctionNo;
                                inStockTransactionDVO.tifNo = chattelDocumentWithPurchase.DocumentRecordLogNumbers;
                            }

                            if (census.Trxdefobjectid.Value == new Guid("f38cd74c-6a6b-44bc-9c2b-a57660b771e9"))
                            {
                                ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy = (ChattelDocumentInputWithAccountancy)objectContext.GetObject(census.Stockactionobjectid.Value, typeof(ChattelDocumentInputWithAccountancy));
                                if (chattelDocumentInputWithAccountancy.Accountancy != null)
                                    inStockTransactionDVO.destinationDescription = chattelDocumentInputWithAccountancy.Accountancy.Name;
                                inStockTransactionDVO.tifNo = chattelDocumentInputWithAccountancy.DocumentRecordLogNumbers;
                            }
                            outputPTSDevir.Add(inStockTransactionDVO);
                        }



                        //foreach (InStockTransactionDVO itemDevir in outputPTSDevir)
                        //{
                        //    if (outputPTSDevir.Any(x => x.materialName == itemDevir.materialName && x.trxDescription == itemDevir.trxDescription && x.unitPrice == itemDevir.unitPrice && x.BudgetType == itemDevir.BudgetType && x.MKYSTrxID == itemDevir.MKYSTrxID))
                        //    {
                        //        InStockTransactionDVO dto = outputPTSDevir.Where(x => x.materialName == itemDevir.materialName && x.trxDescription == itemDevir.trxDescription && x.unitPrice == itemDevir.unitPrice && x.BudgetType == itemDevir.BudgetType && x.MKYSTrxID == itemDevir.MKYSTrxID).FirstOrDefault();
                        //        dto.inAmount += itemDevir.inAmount;
                        //        dto.restAmount += itemDevir.restAmount;
                        //        dto.stockTransactionListObjectID.Add(itemDevir.stockTransactionObjectID);
                        //    }
                        //    else
                        //    {
                        //        itemDevir.stockTransactionListObjectID = new List<Guid>();
                        //        itemDevir.stockTransactionListObjectID.Add(itemDevir.stockTransactionObjectID);
                        //        output.Add(itemDevir);
                        //    }
                        //}
                    }

                    BindingList<StockTransaction.GetInStockTransactionLikeMKYS_Class> inTRXs = StockTransaction.GetInStockTransactionLikeMKYS(new Guid(input.store), (DateTime)accountingTerm.StartDate, (DateTime)accountingTerm.EndDate, materialObjectID, new Guid(input.budgetTypeObjId));

                    foreach (StockTransaction.GetInStockTransactionLikeMKYS_Class inTRX in inTRXs)
                    {
                        if (input.isZeroAmount == false && Convert.ToDouble(inTRX.Restamount) == 0)
                            continue;
                        InStockTransactionDVO inStockTransactionDVO = new InStockTransactionDVO();
                        inStockTransactionDVO.barcode = inTRX.Barcode;
                        if (inTRX.ExpirationDate.HasValue)
                            inStockTransactionDVO.expirationDate = inTRX.ExpirationDate.Value;
                        inStockTransactionDVO.inAmount = inTRX.Amount.Value;
                        inStockTransactionDVO.materialName = inTRX.Name;
                        inStockTransactionDVO.BudgetType = inTRX.Budgettypename;
                        inStockTransactionDVO.maxLevel = inTRX.MaximumLevel.Value;
                        inStockTransactionDVO.minLevel = inTRX.MinimumLevel.Value;
                        if (inTRX.MKYS_StokHareketID.HasValue)
                            inStockTransactionDVO.MKYSTrxID = inTRX.MKYS_StokHareketID.Value;
                        inStockTransactionDVO.restAmount = Convert.ToDouble(inTRX.Restamount);
                        inStockTransactionDVO.outAmount = inStockTransactionDVO.inAmount - inStockTransactionDVO.restAmount;
                        inStockTransactionDVO.stockNo = inTRX.NATOStockNO;
                        inStockTransactionDVO.stockTransactionObjectID = inTRX.ObjectID.Value;
                        inStockTransactionDVO.stockTransactionListObjectID = new List<Guid>();
                        inStockTransactionDVO.stockTransactionListObjectID.Add(inStockTransactionDVO.stockTransactionObjectID);
                        inStockTransactionDVO.transactionDate = inTRX.TransactionDate.Value;
                        inStockTransactionDVO.unitPrice = inTRX.UnitPrice.Value;
                        inStockTransactionDVO.trxDescription = inTRX.Description;
                        inStockTransactionDVO.stockActionId = (int)inTRX.StockActionID.Value;

                        if (inTRX.Trxdefobjectid.Value == new Guid("e5f7428e-3125-413d-8964-8537993b38e4") && inTRX.Stockactionobjectid != null)
                        {
                            ChattelDocumentWithPurchase chattelDocumentWithPurchase = (ChattelDocumentWithPurchase)objectContext.GetObject(inTRX.Stockactionobjectid.Value, typeof(ChattelDocumentWithPurchase));
                            if (chattelDocumentWithPurchase.Supplier != null)
                                inStockTransactionDVO.destinationDescription = chattelDocumentWithPurchase.Supplier.Name;
                            inStockTransactionDVO.auctionNo = chattelDocumentWithPurchase.RegistrationAuctionNo;
                            inStockTransactionDVO.tifNo = chattelDocumentWithPurchase.DocumentRecordLogNumbers;
                        }

                        if (inTRX.Trxdefobjectid.Value == new Guid("f38cd74c-6a6b-44bc-9c2b-a57660b771e9") && inTRX.Stockactionobjectid != null)
                        {
                            ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy = (ChattelDocumentInputWithAccountancy)objectContext.GetObject(inTRX.Stockactionobjectid.Value, typeof(ChattelDocumentInputWithAccountancy));
                            if (chattelDocumentInputWithAccountancy.Accountancy != null)
                                inStockTransactionDVO.destinationDescription = chattelDocumentInputWithAccountancy.Accountancy.Name;
                            inStockTransactionDVO.tifNo = chattelDocumentInputWithAccountancy.DocumentRecordLogNumbers;
                        }
                        outputPTS.Add(inStockTransactionDVO);
                    }

                    foreach (InStockTransactionDVO item in outputPTS)
                    {
                        if (output.Any(x => x.materialName == item.materialName && x.trxDescription == item.trxDescription && x.unitPrice == item.unitPrice && x.BudgetType == item.BudgetType && x.MKYSTrxID == item.MKYSTrxID))
                        {
                            InStockTransactionDVO dto = outputPTS.Where(x => x.materialName == item.materialName && x.trxDescription == item.trxDescription && x.unitPrice == item.unitPrice && x.BudgetType == item.BudgetType && x.MKYSTrxID == item.MKYSTrxID).FirstOrDefault();
                            dto.inAmount += item.inAmount;
                            dto.restAmount += item.restAmount;
                            dto.stockTransactionListObjectID.Add(item.stockTransactionObjectID);
                        }
                        else
                        {
                            item.stockTransactionListObjectID = new List<Guid>();
                            item.stockTransactionListObjectID.Add(item.stockTransactionObjectID);
                            output.Add(item);
                        }
                    }

                    outputFull.AddRange(outputPTSDevir);
                    outputFull.AddRange(output);

                    //foreach (InStockTransactionDVO itemDevir in outputPTSDevir)
                    //{
                    //    outputFull.Add(itemDevir);
                    //}
                    //foreach (InStockTransactionDVO itemDevir in output)
                    //{
                    //    outputFull.Add(itemDevir);
                    //}


                }
            }
            outputFull = outputFull.OrderBy(o => o.materialName).ToList();
            return outputFull;
        }

        public class OutStockTransactionInput
        {
            public string inStockTransactionID
            {
                get;
                set;
            }

            public string accountingTermObjId
            {
                get;
                set;
            }

            public List<string> inStockTransactionListID { get; set; }
        }

        public class OutStockTransactionDVO
        {

            public DateTime transactionDate
            {
                get;
                set;
            }

            public string trxType
            {
                get;
                set;
            }

            public string trxDescription
            {
                get;
                set;
            }

            public string storeName
            {
                get;
                set;
            }

            public int documentLogID
            {
                get;
                set;
            }

            public int stockActionID
            {
                get;
                set;
            }

            public Currency amount
            {
                get;
                set;
            }

            public DateTime expirationDate
            {
                get;
                set;
            }

            public Guid stockTransactionObjectID
            {
                get;
                set;
            }

        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Dashboard_Ana_Ekran)]
        public List<OutStockTransactionDVO> GetOutStockTransactions(OutStockTransactionInput input)
        {
            List<OutStockTransactionDVO> output = new List<OutStockTransactionDVO>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                AccountingTerm accountingTerm = (AccountingTerm)objectContext.GetObject(new Guid(input.accountingTermObjId), typeof(AccountingTerm));
                foreach (var item in input.inStockTransactionListID)
                {
                    StockTransaction inStockTransaction = (StockTransaction)objectContext.GetObject(new Guid(item), typeof(StockTransaction));
                    List<StockTransactionDetail> detailList = inStockTransaction.StockTransactionDetails.Where(x => x.OutStockTransaction.TransactionDate >= accountingTerm.StartDate && x.OutStockTransaction.TransactionDate <= accountingTerm.EndDate && x.OutStockTransaction.CurrentStateDefID == StockTransaction.States.Completed).ToList();

                    foreach (StockTransactionDetail detail in detailList)
                    {
                        OutStockTransactionDVO outStockTransactionDVO = new OutStockTransactionDVO();
                        outStockTransactionDVO.amount = detail.OutStockTransaction.Amount.Value;
                        if (detail.OutStockTransaction.ExpirationDate.HasValue)
                            outStockTransactionDVO.expirationDate = detail.OutStockTransaction.ExpirationDate.Value;
                        outStockTransactionDVO.stockTransactionObjectID = detail.OutStockTransaction.ObjectID;
                        outStockTransactionDVO.transactionDate = detail.OutStockTransaction.TransactionDate.Value;
                        outStockTransactionDVO.trxDescription = detail.OutStockTransaction.StockTransactionDefinition.Description;
                        outStockTransactionDVO.trxType = Common.GetDisplayTextOfEnumValue("TransactionTypeEnum", (int)detail.OutStockTransaction.StockTransactionDefinition.TransactionType);

                        if (detail.OutStockTransaction.StockActionDetail.StockAction != null)
                        {
                            if (detail.OutStockTransaction.StockActionDetail.StockAction is ChattelDocumentOutputWithAccountancy) //Çıkış
                            {
                                outStockTransactionDVO.storeName = ((ChattelDocumentOutputWithAccountancy)detail.OutStockTransaction.StockActionDetail.StockAction).Accountancy.Name;
                                DocumentRecordLog doc = detail.OutStockTransaction.StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == detail.OutStockTransaction.BudgetTypeDefinition.MKYS_Butce).FirstOrDefault();
                                if (doc.DocumentRecordLogNumber != null)
                                    outStockTransactionDVO.documentLogID = (int)doc.DocumentRecordLogNumber.Value;
                                outStockTransactionDVO.stockActionID = (int)detail.OutStockTransaction.StockActionDetail.StockAction.StockActionID.Value;
                            }
                            else if (detail.OutStockTransaction.StockActionDetail.StockAction is DistributionDocument) //Dağıtım
                            {
                                outStockTransactionDVO.storeName = ((DistributionDocument)detail.OutStockTransaction.StockActionDetail.StockAction).DestinationStore.Name;
                                DocumentRecordLog doc = detail.OutStockTransaction.StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == detail.OutStockTransaction.BudgetTypeDefinition.MKYS_Butce).FirstOrDefault();
                                if (doc.DocumentRecordLogNumber != null)
                                    outStockTransactionDVO.documentLogID = (int)doc.DocumentRecordLogNumber.Value;
                                outStockTransactionDVO.stockActionID = (int)detail.OutStockTransaction.StockActionDetail.StockAction.StockActionID.Value;
                            }
                            else if (detail.OutStockTransaction.StockActionDetail.StockAction is MainStoreDistributionDoc) // Ana Depo Dağıtım
                            {
                                outStockTransactionDVO.storeName = ((MainStoreDistributionDoc)detail.OutStockTransaction.StockActionDetail.StockAction).DestinationStore.Name;
                                DocumentRecordLog doc = detail.OutStockTransaction.StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == detail.OutStockTransaction.BudgetTypeDefinition.MKYS_Butce).FirstOrDefault();
                                if (doc.DocumentRecordLogNumber != null)
                                    outStockTransactionDVO.documentLogID = (int)doc.DocumentRecordLogNumber.Value;
                                outStockTransactionDVO.stockActionID = (int)detail.OutStockTransaction.StockActionDetail.StockAction.StockActionID.Value;
                            }
                            else if (detail.OutStockTransaction.StockActionDetail.StockAction is MainStoreStockTransfer) //Ambarlar Arası Transfer
                            {
                                outStockTransactionDVO.storeName = ((MainStoreStockTransfer)detail.OutStockTransaction.StockActionDetail.StockAction).DestinationStore.Name;
                                DocumentRecordLog doc = detail.OutStockTransaction.StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == detail.OutStockTransaction.BudgetTypeDefinition.MKYS_Butce).FirstOrDefault();
                                if (doc.DocumentRecordLogNumber != null)
                                    outStockTransactionDVO.documentLogID = (int)doc.DocumentRecordLogNumber.Value;
                                outStockTransactionDVO.stockActionID = (int)detail.OutStockTransaction.StockActionDetail.StockAction.StockActionID.Value;
                            }
                            else if (detail.OutStockTransaction.StockActionDetail.StockAction is DeleteRecordDocumentDestroyable) //kayıt silme yok edilen
                            {
                                outStockTransactionDVO.storeName = ((DeleteRecordDocumentDestroyable)detail.OutStockTransaction.StockActionDetail.StockAction).Store.Name;
                                DocumentRecordLog doc = detail.OutStockTransaction.StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == detail.OutStockTransaction.BudgetTypeDefinition.MKYS_Butce).FirstOrDefault();
                                if (doc.DocumentRecordLogNumber != null)
                                    outStockTransactionDVO.documentLogID = (int)doc.DocumentRecordLogNumber.Value;
                                outStockTransactionDVO.stockActionID = (int)detail.OutStockTransaction.StockActionDetail.StockAction.StockActionID.Value;
                            }
                            else if (detail.OutStockTransaction.StockActionDetail.StockAction is ExtendExpirationDate) //miad uzatım işlemi
                            {
                                outStockTransactionDVO.storeName = ((ExtendExpirationDate)detail.OutStockTransaction.StockActionDetail.StockAction).Store.Name;
                                DocumentRecordLog doc = detail.OutStockTransaction.StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == detail.OutStockTransaction.BudgetTypeDefinition.MKYS_Butce).FirstOrDefault();
                                if (doc != null)
                                {
                                    if (doc.DocumentRecordLogNumber != null)
                                        outStockTransactionDVO.documentLogID = (int)doc.DocumentRecordLogNumber.Value;
                                }
                                outStockTransactionDVO.stockActionID = (int)detail.OutStockTransaction.StockActionDetail.StockAction.StockActionID.Value;
                            }
                            else if (detail.OutStockTransaction.StockActionDetail.StockAction is KSchedule)
                            {
                                outStockTransactionDVO.storeName = ((KSchedule)detail.OutStockTransaction.StockActionDetail.StockAction).InPatientPhysicianApplication.Episode.Patient.FullName;
                                if (detail.OutStockTransaction.StockCollectedTrxs.Count > 0)
                                {
                                    DocumentRecordLog doc = detail.OutStockTransaction.StockCollectedTrxs[0].StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == detail.OutStockTransaction.BudgetTypeDefinition.MKYS_Butce && x.Descriptions == detail.OutStockTransaction.StockActionDetail.StockAction.DestinationStore.Name).FirstOrDefault();
                                    if (doc != null)
                                    {
                                        if (doc.DocumentRecordLogNumber != null)
                                            outStockTransactionDVO.documentLogID = (int)doc.DocumentRecordLogNumber.Value;
                                    }
                                }
                                outStockTransactionDVO.stockActionID = (int)detail.OutStockTransaction.StockActionDetail.StockAction.StockActionID.Value;
                            }
                            else if (detail.OutStockTransaction.StockActionDetail.StockAction is StockOut)
                            {
                                outStockTransactionDVO.storeName = (detail.OutStockTransaction.StockActionDetail.StockAction.StockActionDetails[0]).Patient.FullName;
                            }
                        }
                        output.Add(outStockTransactionDVO);
                    }
                }

            }
            output = output.OrderBy(o => o.transactionDate).ToList();
            return output;
        }

        public class SubStoreExpDateUpdate_Input
        {
            public List<string> materials
            {
                get;
                set;
            }

            public string store
            {
                get;
                set;
            }
            public int beforeDay
            {
                get;
                set;
            }
        }

        public class SubStoreExpDateUpdate_Output
        {
            public Guid transactionObjectID
            {
                get;
                set;
            }

            public string materialName
            {
                get;
                set;
            }
            public double inheld
            {
                get;
                set;
            }
            public DateTime expDate
            {
                get;
                set;
            }
            public int dayDiff
            {
                get;
                set;
            }
            public DateTime? newExpDate
            {
                get;
                set;
            }

        }

        [HttpPost]
        public List<SubStoreExpDateUpdate_Output> SearchExpDate(SubStoreExpDateUpdate_Input input)
        {
            List<SubStoreExpDateUpdate_Output> output = new List<SubStoreExpDateUpdate_Output>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                Store store = (Store)objectContext.GetObject(new Guid(input.store), typeof(Store));
                List<Stock> stocks = new List<Stock>();
                if (input.materials == null || input.materials.Count == 0)
                    stocks = store.Stocks.Select("INHELD > 0").ToList();
                else
                {
                    foreach (string matObjID in input.materials)
                    {
                        Material mat = objectContext.GetObject<Material>(new Guid(matObjID));
                        Stock mStock = store.GetStock(mat);
                        stocks.Add(mStock);
                    }
                }
                foreach (Stock s in stocks)
                {
                    BindingList<StockTransaction.ExpireDateOutableStockTransactionsRQ_Class> outableStocks = StockTransaction.ExpireDateOutableStockTransactionsRQ(s.ObjectID, StockLevelType.NewStockLevel.ObjectID);
                    foreach (StockTransaction.ExpireDateOutableStockTransactionsRQ_Class outtable in outableStocks)
                    {
                        SubStoreExpDateUpdate_Output expOut = new SubStoreExpDateUpdate_Output();
                        expOut.transactionObjectID = outtable.ObjectID.Value;
                        expOut.materialName = s.Material.Name;
                        expOut.inheld = Convert.ToDouble(outtable.Restamount);
                        if (outtable.ExpirationDate.HasValue)
                        {
                            expOut.expDate = outtable.ExpirationDate.Value;
                            expOut.dayDiff = Convert.ToInt32((outtable.ExpirationDate.Value - Common.RecTime()).TotalDays);
                        }
                        else
                            expOut.expDate = DateTime.MinValue;
                        if (input.beforeDay > 0)
                        {
                            if (expOut.dayDiff < input.beforeDay)
                                output.Add(expOut);
                        }
                        else
                            output.Add(expOut);
                    }
                }
                return output;
            }
        }

        [HttpPost]
        public string UpdateExpDate(List<SubStoreExpDateUpdate_Output> input)
        {
            string output = "Güncelleme işlemi başarılıdır.";
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                foreach (SubStoreExpDateUpdate_Output newExp in input)
                {
                    if (newExp.newExpDate.HasValue)
                    {
                        StockTransaction trx = objectContext.GetObject<StockTransaction>(newExp.transactionObjectID);
                        DateTime newExpDate = Common.GetLastDayOfMounth(newExp.newExpDate.Value);
                        trx.ExpirationDate = newExpDate;
                    }
                }
                try
                {
                    objectContext.Save();
                }
                catch (Exception ex)
                {
                    output = ex.Message;
                }
                return output;
            }
        }
    }
}