using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.ComponentModel;
using TTObjectClasses;
using Infrastructure.Filters;
using TTInstanceManagement;



namespace Core.Models
{


    public class MovableTransactionOutVoucherFormViewModel
    {

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }

        public Guid? BudgetTypeDefinitionObjectID
        {
            get;
            set;
        }

        public Guid StoreID
        {
            get;
            set;
        }

        public List<Material> MaterialList
        {
            get;
            set;
        }

        public List<MaterialModel> SelectedMaterialList
        {
            get;
            set;
        }

        public List<Guid> SelectedFilterStores
        {
            get;
            set;
        }

        public List<string> StoresName
        {
            get;
            set;
        }

        public List<Guid> SelectedStockOutTypeList
        {
            get;
            set;
        }

        public bool showUnused
        {
            get;
            set;
        }
        public int filterAmount
        {
            get;
            set;
        }
        public List<Guid> DoctorIDList
        {
            get;
            set;
        }
        public int DayQueryNumber
        {
            get;
            set;
        }

        public List<int> VademecumList
        {
            get;
            set;
        }
        public Boolean getEHU
        {
            get;
            set;
        }
        public List<Guid> OutStoreIDList
        {
            get;
            set;
        }
        public Enum MKYS_CikisIslemTuru
        {
            get; set;
        }

    }

    public class MovableTransactionOutVoucherResultModel
    {
        public DateTime? OutVoucherDate { get; set; }
        public string BudgetType { get; set; }
        public int? MKYSStockActionID { get; set; }
        public double UnitPrice { get; set; } // kdv'li birim fiyat bilgisini tutar.
        public double VoucherTotalAmount { get; set; }
        public string VoucherTotalAmountString { get; set; }
        public string OutPlace { get; set; } // fisin nereye/kime cikildigi bilgisini tutar.
        public Guid? OutPlaceID { get; set; }
        public Guid MaterialObjectID { get; set; }
        public Guid StockActionID { get; set; }
        public long? DocumentRecordLogID { get; set; }//giris tif numarasi
        public Guid StockTransactionObjectID { get; set; }
        public string FirstMaterialName { get; set; }

        public string MaterialNatoStockNo { get; set; }
        public string MaterialBarcode { get; set; }

        public double Amount { get; set; } //miktar 
        public Guid? InStockActionDetail { get; set; }

    }
    public class InputModelForSecondLevel
    {
        public Guid StockTransactionObjectID;
    }


    public class OutVoucherSecondLevelResultModel
    {
        public DateTime VoucherDate { get; set; }
        public string BudgetType { get; set; }
        public string TakeInType { get; set; }
        public string CompanyName { get; set; }
        public DateTime? BidDate { get; set; }
        public string BidNumber { get; set; }
        public double TotalAmount { get; set; }
        public Guid ObjectID { get; set; }
    }

    public class OutVoucherThirdLevelResultModel
    {
        public string TransactionCode { get; set; }
        public string Barcode { get; set; }
        public double Amount { get; set; }
        public string StoreStock { get; set; }
        public string MaterialName { get; set; }
        public Guid MaterialObjectID { get; set; }
        public Guid StockActionObjectID { get; set; }
        public Guid StockActionDetailObjectID { get; set; }
        public double VoucherAmount { get; set; }
        public double UnitPrice { get; set; }
        public string UnitType { get; set; }
        public string VoucherAmountString { get; set; }

    }

    public class InputModelForThirdLevel
    {
        public Guid StockActionObjectID;
    }

    public class MaterialModel
    {
        public string Name { get; set; }
        public Guid? ID { get; set; }
    }


}
namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class MovableTransactionOutVoucherServiceController : Controller
    {

        public List<MovableTransactionOutVoucherResultModel> GetMovableTransactionOutVouchers(MovableTransactionOutVoucherFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {

                List<MovableTransactionOutVoucherResultModel> stockactionlist = new List<MovableTransactionOutVoucherResultModel>();
                string filiterExpresion = "";
                string vFiliter = "";
                string materialFilter = "";

                List<StockTransaction> querylist = new List<StockTransaction>();
                BindingList<StockTransaction> bindingQueryList = new BindingList<StockTransaction>(querylist); //??

                if (viewModel.showUnused == true)
                {
                    DateTime date = viewModel.EndDate;
                    DateTime givenDate = date.AddDays((-1) * viewModel.DayQueryNumber);
                    //string GuidList = "";
                    BindingList<StockTransaction.GetUsedMaterials_Class> UsedMaterials = StockTransaction.GetUsedMaterials(givenDate, date, viewModel.StoreID, filiterExpresion);

                    if (viewModel.filterAmount != 0)
                    {
                        filiterExpresion += " AND THIS.Amount <= " + viewModel.filterAmount + " ";
                        bindingQueryList = StockTransaction.GetMovableOutVoucherTransaction(objectContext, viewModel.StartDate, givenDate, filiterExpresion);
                    }

                    else
                    {
                        List<Guid> materials = new List<Guid>();
                        if (UsedMaterials.Count != 0)
                        {


                            foreach (StockTransaction.GetUsedMaterials_Class usedMaterial in UsedMaterials)
                            {
                                //if(usedMaterial.TransactionDate> DateTime.Parse("01.01.2019")) 
                                if (materials.Contains(usedMaterial.ObjectID.Value) == false)
                                    materials.Add(usedMaterial.ObjectID.Value);

                                // GuidList += "'" + usedMaterial + "', ";
                            }
                            //GuidList = GuidList.Remove(GuidList.LastIndexOf(','));
                            //  filiterExpresion += " AND THIS.TransactionDate> TODATE('01.01.2019','dd.MM.yyyy')";

                        }



                        bindingQueryList = StockTransaction.GetAllOutMaterialByDate(objectContext, viewModel.StoreID, givenDate);
                        BindingList<StockTransaction> notusableTrx = new BindingList<StockTransaction>();
                        foreach (StockTransaction trx in bindingQueryList)
                        {
                            if (materials.Contains(trx.Stock.Material.ObjectID) == false)
                                notusableTrx.Add(trx);
                        }

                        bindingQueryList = notusableTrx;
                    }

                }

                else
                {

                    if (viewModel.DoctorIDList != null && viewModel.DoctorIDList.Count > 0)
                    {
                        //string filiterForDoctor = "AND ";
                        List<Guid> GuidList = new List<Guid>();

                        //foreach (Guid ID in viewModel.DoctorIDList)
                        //{
                        //    filiterForDoctor += " this.RequestedByUser.OBJECTID = '" + ID + "'" + " OR";
                        //}
                        filiterExpresion = filiterExpresion + "AND ";
                        filiterExpresion += Common.CreateFilterExpressionOfGuidList("", "STOCKACTIONDETAIL.STOCKACTION.MKYS_TeslimAlanObjID", viewModel.DoctorIDList);

                        /*BindingList<BaseDrugOrder.GetDrugBasedOnDoctor_Class> list = new BindingList<BaseDrugOrder.GetDrugBasedOnDoctor_Class>();
                        list = BaseDrugOrder.GetDrugBasedOnDoctor(filiterForDoctor);

                        if (list != null && list.Count != 0)
                        {
                            foreach (BaseDrugOrder.GetDrugBasedOnDoctor_Class material in list)
                            {
                                if (material.Material != null)
                                    GuidList.Add(material.Material.Value);
                            }
                            filiterExpresion += "AND " + Common.CreateFilterExpressionOfGuidList("", "StockActionDetail.Material", GuidList);
                        }
                        else if (list == null || list.Count == 0)
                            return null;*/

                    }


                    if (viewModel.OutStoreIDList != null && viewModel.OutStoreIDList.Count > 0)
                    {
                        filiterExpresion += "AND " + Common.CreateFilterExpressionOfGuidList("", "StockActionDetail.StockAction.DestinationStore", viewModel.OutStoreIDList);
                    }
                    //if (viewModel.DoctorIDList == null || viewModel.DoctorIDList.Count == 0)
                    //    return null;

                    if (viewModel.SelectedFilterStores.Count > 0)
                    {
                        filiterExpresion += " AND (STOCK.Store = ";
                        vFiliter += " AND (this.Stocks.Store = ";
                        foreach (var item in viewModel.SelectedFilterStores)
                        {
                            filiterExpresion += "'" + item.ToString() + "' " + " OR STOCK.Store = ";
                            vFiliter += "'" + item.ToString() + "' " + " OR this.Stocks.Store = ";
                        }
                        filiterExpresion = filiterExpresion.Remove(filiterExpresion.LastIndexOf(" OR STOCK.Store = ")) + ")";
                        vFiliter = vFiliter.Remove(vFiliter.LastIndexOf(" OR this.Stocks.Store = ")) + ")";

                    }

                    else
                    {
                        filiterExpresion += " AND STOCK.Store = ";
                        filiterExpresion += "'" + viewModel.StoreID + "'";
                        vFiliter += " this.Stocks.Store = ";
                        vFiliter += "'" + viewModel.StoreID + "'";
                    }
                    if (viewModel.BudgetTypeDefinitionObjectID != null)
                    {
                        filiterExpresion += " AND BudgetTypeDefinition = '" + viewModel.BudgetTypeDefinitionObjectID + "'";
                    }

                    if (viewModel.SelectedStockOutTypeList != null && viewModel.SelectedStockOutTypeList.Count > 0)
                    {

                        filiterExpresion += " AND " + Common.CreateFilterExpressionOfGuidList("", "StockTransactionDefinition", viewModel.SelectedStockOutTypeList);
                    }

                    if (viewModel.VademecumList.Count != 0)
                    {
                        vFiliter += " AND (";
                        foreach (int item in viewModel.VademecumList)
                        {
                            vFiliter += "this.DrugSpecifications.DrugSpecification = '" + item + "'" + " OR ";
                        }
                        vFiliter = vFiliter.Remove(vFiliter.LastIndexOf(" OR ")) + ")";

                        BindingList<DrugDefinition.GetDrugDefinitionForReport_Class> query = new BindingList<DrugDefinition.GetDrugDefinitionForReport_Class>();
                        query = DrugDefinition.GetDrugDefinitionForReport(vFiliter);

                        if (query.Count != 0)
                        {
                            materialFilter += " AND (this.StockActionDetail.Material.OBJECTID = ";
                            //  filiterExpresion += " AND (this.StockActionDetail.Material.OBJECTID = ";
                            foreach (DrugDefinition.GetDrugDefinitionForReport_Class material in query)
                            {
                                materialFilter += "'" + material.Materialobjeid + "'" + " OR this.StockActionDetail.Material.OBJECTID = ";
                                //      filiterExpresion += "'" + material.Materialobjeid + "'" + " OR this.StockActionDetail.Material.OBJECTID = ";
                            }
                            materialFilter = materialFilter.Remove(materialFilter.LastIndexOf(" OR this.StockActionDetail.Material.OBJECTID = ")) + ")";
                            filiterExpresion += materialFilter;
                            //   filiterExpresion = filiterExpresion.Remove(filiterExpresion.LastIndexOf(" OR this.StockActionDetail.Material.OBJECTID = ")) + ")";
                        }

                    }
                    if (viewModel.getEHU == true)
                    {
                        BindingList<DrugDefinition.GetEHUDrugID_Class> ehuList = new BindingList<DrugDefinition.GetEHUDrugID_Class>();

                        ehuList = DrugDefinition.GetEHUDrugID();
                        if (viewModel.VademecumList.Count != 0)
                        {
                            materialFilter = materialFilter.Remove(materialFilter.LastIndexOf(")"));
                            foreach (DrugDefinition.GetEHUDrugID_Class material in ehuList)
                            {
                                materialFilter += " OR this.StockActionDetail.Material.OBJECTID = '" + material.Materialid + "' ";
                            }
                            materialFilter = materialFilter + ")";
                            filiterExpresion += materialFilter;
                        }
                        else
                        {
                            filiterExpresion += "AND (";
                            foreach (DrugDefinition.GetEHUDrugID_Class material in ehuList)
                            {
                                filiterExpresion += "this.StockActionDetail.Material.OBJECTID = '" + material.Materialid + "' " + " OR ";
                            }
                            filiterExpresion = filiterExpresion.Remove(filiterExpresion.LastIndexOf(" OR ")) + ")";
                        }


                    }
                    if (viewModel.SelectedMaterialList.Count > 0 && viewModel.getEHU == false)
                    {
                        if (viewModel.VademecumList.Count != 0)
                        {
                            materialFilter = materialFilter.Remove(materialFilter.LastIndexOf(")"));
                            foreach (MaterialModel selectedItem in viewModel.SelectedMaterialList)
                            {
                                materialFilter += " OR this.StockActionDetail.Material.OBJECTID = '" + selectedItem.ID + "' ";
                            }
                            materialFilter = materialFilter + ")";
                            filiterExpresion += materialFilter;
                        }

                        else
                        {
                            filiterExpresion += "AND (";
                            foreach (MaterialModel selectedItem in viewModel.SelectedMaterialList)
                            {
                                filiterExpresion += "this.StockActionDetail.Material.OBJECTID = '" + selectedItem.ID + "' " + " OR ";
                            }
                            filiterExpresion = filiterExpresion.Remove(filiterExpresion.LastIndexOf(" OR ")) + ")";
                        }
                    }


                    bindingQueryList = StockTransaction.GetMovableOutVoucherTransaction(objectContext, viewModel.StartDate, viewModel.EndDate, filiterExpresion);


                }


                foreach (StockTransaction transaction in bindingQueryList)
                {

                    if (transaction is StockTransaction)
                    {
                        MovableTransactionOutVoucherResultModel result = new MovableTransactionOutVoucherResultModel();
                        result.UnitPrice = (double)transaction.UnitPrice;
                        if (transaction.BudgetTypeDefinition != null)
                            result.BudgetType = transaction.BudgetTypeDefinition.Name;
                        result.OutVoucherDate = transaction.TransactionDate;
                        result.Amount = (double)transaction.Amount;
                        result.FirstMaterialName = transaction.StockActionDetail.Material.Name;
                        result.MaterialBarcode = transaction.StockActionDetail.Material.Barcode;
                        result.MaterialNatoStockNo = transaction.StockActionDetail.Material.StockCard.NATOStockNO;
                        result.VoucherTotalAmount = (double)transaction.Amount * (double)transaction.UnitPrice;
                        result.VoucherTotalAmount = System.Math.Round(result.VoucherTotalAmount, 2);
                        result.MKYSStockActionID = transaction.MKYS_StokHareketID;
                        result.InStockActionDetail = StockTransactionDetail.GetInStockActionID(transaction.ObjectID).First().StockAction;

                        result.StockActionID = transaction.StockActionDetail.StockAction.ObjectID;
                        if (transaction.StockTransactionDefinition.ObjectID.ToString().Equals("eeb68b1e-fb6e-4348-a2e3-6e0b0f6b1c60"))
                        {
                            BindingList<DistributionDocument.GetDestinationStore_Class> destStore = DistributionDocument.GetDestinationStore(result.StockActionID);
                            foreach (DistributionDocument.GetDestinationStore_Class destination in destStore)
                            {
                                result.OutPlace = destination.Name;
                                result.OutPlaceID = destination.Id;
                            }
                        }
                        else if (transaction.StockTransactionDefinition.ObjectID.ToString().Equals("ef3cf819-f18a-4b9e-89fe-620641f3ff42"))
                        {
                            result.OutPlace = "Atık Depo";
                        }
                        else if (transaction.StockTransactionDefinition.ObjectID.ToString().Equals("f8155e0a-8527-4886-89b8-3aa7c25bc267"))
                        {
                            BindingList<KSchedule.GetOutPlace_Class> forOut = KSchedule.GetOutPlace(result.StockActionID);
                            foreach (KSchedule.GetOutPlace_Class destination in forOut)
                            {
                                result.OutPlace = destination.Name + " " + destination.Surname;
                            }
                        }
                        else if (transaction.StockTransactionDefinition.ObjectID.ToString().Equals("2c1a8b51-4001-43d6-8559-3bbc4771eccb"))
                        {
                            BindingList<ChattelDocumentOutputWithAccountancy.GetAccountancyForOutReport_Class> forOut = ChattelDocumentOutputWithAccountancy.GetAccountancyForOutReport(result.StockActionID);
                            foreach (ChattelDocumentOutputWithAccountancy.GetAccountancyForOutReport_Class destination in forOut)
                            {
                                result.OutPlace = destination.Name;
                                result.OutPlaceID = destination.Id;
                            }
                        }
                        else if (transaction.StockTransactionDefinition.ObjectID.ToString().Equals("0899912a-e828-4e81-a84a-808d20971a22"))
                        {
                            BindingList<ReturningDocument.GetDestStoreFromReturningDocument_Class> forOut = ReturningDocument.GetDestStoreFromReturningDocument(result.StockActionID);
                            foreach (ReturningDocument.GetDestStoreFromReturningDocument_Class destination in forOut)
                            {
                                result.OutPlace = destination.Destinationstore;
                                result.OutPlaceID = destination.Id;
                            }
                        }
                        else if (transaction.StockTransactionDefinition.ObjectID.ToString().Equals("7282fb68-22c3-4b94-8dd1-6bf19d305498"))
                        {
                            BindingList<MainStoreStockTransfer.GetDestStoreForTransfer_Class> forOut = MainStoreStockTransfer.GetDestStoreForTransfer(result.StockActionID);
                            foreach (MainStoreStockTransfer.GetDestStoreForTransfer_Class destination in forOut)
                            {
                                result.OutPlace = destination.Destinationstore;
                                result.OutPlaceID = destination.Id;
                            }
                        }
                        else if (transaction.StockTransactionDefinition.ObjectID.ToString().Equals("fe3b0bc0-6558-41ab-8f70-d99ffce60d34"))
                        {
                            BindingList<SubStoreStockTransfer.GetDestSubStoreStockTransfer_Class> forOut = SubStoreStockTransfer.GetDestSubStoreStockTransfer(result.StockActionID);
                            foreach (SubStoreStockTransfer.GetDestSubStoreStockTransfer_Class destination in forOut)
                            {
                                result.OutPlace = destination.Destinationstore;
                                result.OutPlaceID = destination.ObjectID;
                            }
                        }
                        else if (transaction.StockTransactionDefinition.ObjectID.ToString().Equals("b8690f41-827d-413b-aa46-d971e3d6638e"))
                        {
                            var baseTreatmentMaterial = BaseTreatmentMaterial.GetTreatmentMatByParameter(" AND STOCKACTIONDETAIL =" + TTConnectionManager.ConnectionManager.GuidToString(transaction.StockActionDetail.ObjectID)).FirstOrDefault();
                            if (baseTreatmentMaterial != null)
                                result.OutPlace = baseTreatmentMaterial.ProtocolNo + " "+  baseTreatmentMaterial.Patientname + " " + baseTreatmentMaterial.Patientsurname;
                            else
                                result.OutPlace = "*";//Basetreatmentmaterial silinmiş ama stockoutiptal olmadıgı için bulamıyor.!!
                           
                        }
                        else
                        {
                            result.OutPlace = "-";
                        }

                        result.StockTransactionObjectID = transaction.ObjectID;
                        BindingList<TTObjectClasses.DocumentRecordLog.GetTifNumber_Class> documentRecord = DocumentRecordLog.GetTifNumber(result.StockActionID);
                        foreach (TTObjectClasses.DocumentRecordLog.GetTifNumber_Class x in documentRecord)
                        {
                            result.DocumentRecordLogID = x.DocumentRecordLogNumber;
                        }

                        if (viewModel.VademecumList.Count > 0)
                        {
                            if (transaction.Stock.Material is DrugDefinition)
                            {
                                foreach (int spesification in viewModel.VademecumList)
                                {
                                    if (((DrugDefinition)transaction.Stock.Material).DrugSpecifications.Select(x => x.DrugSpecification == (DrugSpecificationEnum)spesification).Any())
                                    {
                                        stockactionlist.Add(result);
                                        break;
                                    }
                                }
                            }

                        }
                        else
                        {
                            stockactionlist.Add(result);
                        }
                    }
                }

                if (viewModel.OutStoreIDList != null && viewModel.OutStoreIDList.Count > 0)
                {
                    stockactionlist = stockactionlist.Where(x => x.OutPlaceID != null && viewModel.OutStoreIDList.Contains(new Guid(x.OutPlaceID.ToString()))).ToList();
                }
                return stockactionlist;
            }

        }

        public BindingList<MaterialModel> GetMaterialsBySelectedStores(MovableTransactionOutVoucherFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                string filter = "WHERE STOCKS.STORE =  ";

                if (viewModel.SelectedFilterStores.Count > 0)
                {
                    foreach (var item in viewModel.SelectedFilterStores)
                    {
                        filter += "'" + item.ToString() + "' " + " OR STOCKS.STORE = ";

                    }
                    filter = filter.Remove(filter.LastIndexOf("OR STOCKS.STORE = "));
                }

                else
                {
                    filter += "'" + viewModel.StoreID + "' ";
                }

                BindingList<Material.GetMaterialsForMultiSelectForm_Class> resultList = new BindingList<Material.GetMaterialsForMultiSelectForm_Class>();
                BindingList<Material.GetMaterialsForMultiSelectForm_Class> materialList = Material.GetMaterialsForMultiSelectForm(objectContext, filter);

                BindingList<MaterialModel> result = new BindingList<MaterialModel>();



                foreach (Material.GetMaterialsForMultiSelectForm_Class material in materialList)
                {
                    MaterialModel model = new MaterialModel();
                    model.Name = material.Name;
                    model.ID = material.ObjectID;

                    result.Add(model);
                }

                return result;
            }


        }

        public List<OutVoucherSecondLevelResultModel> GetOutVoucherForSecondLevel(InputModelForSecondLevel input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {

                BindingList<StockTransactionDetail> inStockTransaction = StockTransactionDetail.GetInTransactionVoucherForOutMaterials(objectContext, input.StockTransactionObjectID);
                List<OutVoucherSecondLevelResultModel> resultList = new List<OutVoucherSecondLevelResultModel>();

                foreach (StockTransactionDetail transaction in inStockTransaction)
                {
                    OutVoucherSecondLevelResultModel model = new OutVoucherSecondLevelResultModel();
                    StockTransaction inTransaction = transaction.InStockTransaction;
                    StockAction inVoucher = inTransaction.StockActionDetail.StockAction;
                    List<Material> VoucherMaterials = new List<Material>();
                    String filtre = " THIS.OBJECTID = '" + inTransaction.ObjectID + "'";
                    BindingList<StockTransaction.GetMaterialsForPrice_Class> pricelist = new BindingList<StockTransaction.GetMaterialsForPrice_Class>();
                    pricelist = StockTransaction.GetMaterialsForPrice(filtre);

                    BaseChattelDocument Chattel = null;
                    Guid ActionObjectID = inVoucher.ObjectID;
                    int sActionID = (int)inVoucher.StockActionID.Value;
                    try
                    {
                        Chattel = (BaseChattelDocument)objectContext.GetObject<BaseChattelDocument>(ActionObjectID);
                    }
                    catch (Exception e)
                    {

                    }
                    if (Chattel != null)
                    {

                        if (Chattel is ChattelDocumentWithPurchase)
                        {
                            Guid objectID;
                            BindingList<ChattelDocumentDetailWithPurchase.GetPurchaseDetail_Class> ChattelDetail = ChattelDocumentDetailWithPurchase.GetPurchaseDetail(ActionObjectID);
                            foreach (ChattelDocumentDetailWithPurchase.GetPurchaseDetail_Class detail in ChattelDetail)
                            {
                                objectID = (Guid)detail.ObjectID;
                                ChattelDocumentDetailWithPurchase chattelDetail = (ChattelDocumentDetailWithPurchase)objectContext.GetObject<ChattelDocumentDetailWithPurchase>(objectID);
                                chattelDetail.CalculatePricesWithKdv();
                                model.TotalAmount = (double)chattelDetail.Price;
                                model.TotalAmount = System.Math.Round(model.TotalAmount, 3);
                            }
                            model.BidDate = ((ChattelDocumentWithPurchase)Chattel).AuctionDate;
                            model.BidNumber = ((ChattelDocumentWithPurchase)Chattel).RegistrationAuctionNo;
                            model.CompanyName = ((ChattelDocumentWithPurchase)Chattel).Supplier.Name;

                        }

                        else if (Chattel is IChattelDocumentWithAccountancy)
                        {
                            foreach (StockTransaction.GetMaterialsForPrice_Class m in pricelist)
                            {
                                model.TotalAmount = (double)(m.Amount) * (double)(m.UnitPrice);
                                model.TotalAmount = System.Math.Round(model.TotalAmount, 3);
                            }
                            model.CompanyName = ((IChattelDocumentWithAccountancy)Chattel).GetAccountancy().GetName();

                        }
                    }

                    model.ObjectID = inVoucher.ObjectID;
                    if (inVoucher.MKYS_EAlimYontemi != null)
                        model.TakeInType = Common.GetDisplayTextOfEnumValue("MKYS_EAlimYontemiEnum", (int)(inVoucher.MKYS_EAlimYontemi));
                    if (inVoucher.TransactionDate != null)
                        model.VoucherDate = (DateTime)inVoucher.TransactionDate;
                    if (inTransaction.BudgetTypeDefinition != null)
                        model.BudgetType = inTransaction.BudgetTypeDefinition.Name;
                    //if(inVoucher.TotalPrice != null)
                    //    model.TotalAmount = (float)inVoucher.TotalPrice;

                    resultList.Add(model);

                }

                return resultList;
            }

        }

        public List<OutVoucherThirdLevelResultModel> GetOutVoucherDetailsForThirdLevel(InputModelForThirdLevel input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {

                List<OutVoucherThirdLevelResultModel> resultList = new List<OutVoucherThirdLevelResultModel>();
                StockAction action = objectContext.GetObject<StockAction>(input.StockActionObjectID);
                List<StockActionDetailIn> detailList = action.StockActionInDetails.ToList<StockActionDetailIn>();

                foreach (StockActionDetailIn actiondetail in detailList)
                {
                    OutVoucherThirdLevelResultModel model = new OutVoucherThirdLevelResultModel();

                    model.MaterialName = actiondetail.Material.Name_Shadow;
                    model.MaterialObjectID = actiondetail.Material.ObjectID;
                    model.StockActionObjectID = action.ObjectID;
                    model.StockActionDetailObjectID = actiondetail.ObjectID;
                    model.TransactionCode = actiondetail.Material.NATOStockNO;
                    model.Barcode = actiondetail.Material.Barcode;
                    model.Amount = (double)actiondetail.Amount;
                    model.StoreStock = actiondetail.StoreStock.ToString();
                    model.UnitPrice = (double)actiondetail.UnitPrice;
                    model.VoucherAmount = (model.Amount) * (model.UnitPrice);
                    model.VoucherAmount = System.Math.Round(model.VoucherAmount, 2);
                    model.VoucherAmountString = model.VoucherAmount.ToString("0.###");
                    model.UnitType = actiondetail.Material.DistributionTypeName;

                    resultList.Add(model);

                }
                return resultList;
            }

        }



        [HttpPost]
        public List<ResUser.ClinicDoctorListNQL_Class> FillDataSources()
        {
            List<ResUser.ClinicDoctorListNQL_Class> DoctorList = ResUser.ClinicDoctorListNQL(null).ToList();
            return DoctorList;
        }
        [HttpPost]
        public List<SubStoreDefinition.GetSubStoreDefinition_Class> FillStoreDataSources()
        {
            string filter = "WHERE THIS.ISACTIVE = 1";
            List<SubStoreDefinition.GetSubStoreDefinition_Class> OutStoreList = SubStoreDefinition.GetSubStoreDefinition(filter).ToList();
            return OutStoreList;
        }

    }

}