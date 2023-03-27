
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;
using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Tüketim, Ãœretim ve Elde Edilenler Belgesi  için kullanılan temel sınıftır
    /// </summary>
    public partial class ProductionConsumptionDocument : StockAction, IStockConsumptionTransaction, IAutoDocumentNumber, IStockProductionTransaction, IAutoDocumentRecordLog, IProductionConsumptionDocument
    {
        public partial class GetProductionConsumptionDocumentCensusReportQuery_Class : TTReportNqlObject
        {
        }

        

        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
            #region PreTransition_New2Approval
            //this.MaterialRepeatControl();
            #endregion PreTransition_New2Approval
        }

        protected void PostTransition_New2Approval()
        {
            // From State : New   To State : Approval
            #region PostTransition_New2Approval


            if (Store is IUnitStoreDefinition)
            {
                SendDocumentToTargetSite();
            }

            #endregion PostTransition_New2Approval
        }

        protected void PostTransition_StockCardRegistry2Completed()
        {
            // From State : StockCardRegistry   To State : Completed
            #region PostTransition_StockCardRegistry2Completed


            if (ProductionDepStoreObjectID != null)
            {
                UpdateDocumentToTargetSite();
            }

            #endregion PostTransition_StockCardRegistry2Completed
        }

        protected void PostTransition_AutoCreate2Approval()
        {
            // From State : AutoCreate   To State : Approval
            #region PostTransition_AutoCreate2Approval

            if (Store is IUnitStoreDefinition)
            {
                SendDocumentToTargetSite();
            }

            #endregion PostTransition_AutoCreate2Approval
        }

        #region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew)
            {
                StartDate = new DateTime(TTObjectDefManager.ServerTime.Date.Year, TTObjectDefManager.ServerTime.Date.Month, 1);
                DateTime endDate = StartDate.Value.AddMonths(1).AddDays(-1);
                EndDate = Convert.ToDateTime(endDate.ToShortDateString() + " " + "23:59:59");
            }
        }


        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> inRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> outRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (ProductionConsumptionDocumentMaterialIn detail in ProductionConsumptionDocumentInMaterials)
                {
                    foreach (StockTransaction inTrx in detail.StockTransactions.Where(d => d.CurrentStateDefID == StockTransaction.States.Completed).ToList())
                    {
                        if (inTrx.InOut == TransactionTypeEnum.In)
                        {
                            if (inTrx.BudgetTypeDefinition.MKYS_Butce == null)
                                throw new TTException(inTrx.BudgetTypeDefinition.Name + " bütcesi MKYS ile eşleştirilmemiştir. Lütfen eşleştirip işleme öyle devam ediniz.");
                            MKYS_EButceTurEnum butce = (MKYS_EButceTurEnum)inTrx.BudgetTypeDefinition.MKYS_Butce;
                            if (inRecordLogs.ContainsKey(butce))
                            {
                                if (inRecordLogs[butce].Contains(detail) == false)
                                    inRecordLogs[butce].Add(detail);
                            }
                            else
                            {
                                List<StockActionDetail> dets = new List<StockActionDetail>();
                                dets.Add(detail);
                                inRecordLogs.Add(butce, dets);
                            }
                        }
                    }
                }

                foreach (ProductionConsumptionDocumentMaterialOut detail in ProductionConsumptionDocumentOutMaterials)
                {
                    foreach (StockTransaction outTrx in detail.StockTransactions.Where(d => d.CurrentStateDefID == StockTransaction.States.Completed).ToList())
                    {
                        if (outTrx.InOut == TransactionTypeEnum.Out)
                        {
                            if (outTrx.BudgetTypeDefinition.MKYS_Butce == null)
                                throw new TTException(outTrx.BudgetTypeDefinition.Name + " bütcesi MKYS ile eşleştirilmemiştir. Lütfen eşleştirip işleme öyle devam ediniz.");
                            MKYS_EButceTurEnum butce = (MKYS_EButceTurEnum)outTrx.BudgetTypeDefinition.MKYS_Butce;
                            if (outRecordLogs.ContainsKey(butce))
                            {
                                if (outRecordLogs[butce].Contains(detail) == false)
                                    outRecordLogs[butce].Add(detail);
                            }
                            else
                            {
                                List<StockActionDetail> dets = new List<StockActionDetail>();
                                dets.Add(detail);
                                outRecordLogs.Add(butce, dets);
                            }
                        }
                    }
                }

                if (inRecordLogs.Count > 0)
                {
                    _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                    foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> inLog in inRecordLogs)
                    {
                        string place = Store.Name;
                        AutoDocumentRecordLogAttribute.DocumentRecordLogContent logContent = new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.In, this, inLog.Value.Count, place, inLog.Key);

                        _documentRecordLogContents.Add(logContent);
                    }
                }

                if (outRecordLogs.Count > 0)
                {
                   // _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                    foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> outLog in outRecordLogs)
                    {
                        string place = Store.Name;
                        AutoDocumentRecordLogAttribute.DocumentRecordLogContent logContent = new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.Out, this, outLog.Value.Count, place, outLog.Key);

                        _documentRecordLogContents.Add(logContent);
                    }
                }
                return _documentRecordLogContents;
            }
        }

        public void SendDocumentToTargetSite()
        {
            TTObjectContext ctx = new TTObjectContext(true);

            if ((bool)AccountingTerm.Accountancy.AccountancyMilitaryUnit.IsSupported)
            {
                TTObjectContext trashContext = new TTObjectContext(false);
                List<TTObject> list = new List<TTObject>();
                StockOut stockOut = new StockOut(trashContext);
                stockOut.CurrentStateDefID = StockOut.States.New;
                foreach (ProductionConsumptionDocumentMaterialOut detail in ProductionConsumptionDocumentOutMaterials)
                {
                    if (((StockActionDetail)detail).Status != StockActionDetailStatusEnum.Cancelled)
                    {
                        foreach (StockCollectedTrx collected in detail.StockCollectedTrxs.Select(string.Empty))
                        {
                            StockOutMaterial stockOutMaterial = new StockOutMaterial(trashContext);
                            stockOutMaterial.Material = collected.StockTransaction.Stock.Material;
                            stockOutMaterial.Amount = collected.StockTransaction.Amount;
                            stockOutMaterial.StockLevelType = collected.StockTransaction.StockLevelType;
                            stockOutMaterial.Status = StockActionDetailStatusEnum.New;
                            if (collected.StockTransaction.Stock.Material.StockCard.StockMethod == StockMethodEnum.LotUsed || collected.StockTransaction.Stock.Material.StockCard.StockMethod == StockMethodEnum.ExpirationDated)
                            {
                                OuttableLot outtableLot = new OuttableLot(trashContext);
                                outtableLot.LotNo = collected.StockTransaction.LotNo;
                                outtableLot.ExpirationDate = collected.StockTransaction.ExpirationDate;
                                outtableLot.Amount = collected.StockTransaction.Amount;
                                outtableLot.StockActionDetailOut = stockOutMaterial;
                            }
                            if (collected.StockTransaction.Stock.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
                            {
                                foreach (QRCodeTransaction qRCodeTransaction in collected.StockTransaction.QRCodeTransactions)
                                {
                                    QRCodeOutDetail qRCodeOutDetail = new QRCodeOutDetail(trashContext);
                                    qRCodeOutDetail.QRCodeTransaction = qRCodeTransaction;
                                    qRCodeOutDetail.StockActionDetail = stockOutMaterial;
                                }
                            }
                            stockOutMaterial.StockAction = stockOut;
                        }
                    }
                }
                list.Add(stockOut);
                foreach (StockOutMaterial matDetail in stockOut.StockOutMaterials)
                {
                    list.Add(matDetail);

                    foreach (OuttableLot lot in matDetail.OuttableLots)
                    {
                        list.Add(lot);
                    }
                    foreach (QRCodeOutDetail qRCodeOutDetail in matDetail.QRCodeOutDetails)
                    {
                        list.Add(qRCodeOutDetail);
                        list.Add(qRCodeOutDetail.QRCodeTransaction);
                    }
                }

                Guid guid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", ""));
                Sites hsite = (Sites)ObjectContext.GetObject(guid, "SITES");

                list.Add(hsite);
                list.Add(((StockAction)this).AccountingTerm.Accountancy);
                list.Add((TTObject)this);
                foreach (ProductionConsumptionDocumentMaterialOut matDetOut in ProductionConsumptionDocumentOutMaterials)
                {
                    list.Add((TTObject)matDetOut);
                }

                Sites site = (Sites)AccountingTerm.Accountancy.AccountancyMilitaryUnit.Site;
                //ProductionConsumptionDocument.RemoteMethods.CreateProductionDoc(site.ObjectID, list);
                trashContext.Dispose();
            }
        }

        public void UpdateDocumentToTargetSite()
        {
            List<TTObject> list = new List<TTObject>();
            TTObjectContext ctx = new TTObjectContext(false);
            list.Add((TTObject)this);
            ctx.Dispose();
            Sites site = (Sites)((DependentStoreDefinition)Store).Site;
            //  ProductionConsumptionDocument.RemoteMethods.UpdateProductionDoc(site.ObjectID, list);

        }
        #region IAutoDocumentRecordLog Member
        public Guid GetObjectID()
        {
            return ObjectID;
        }

        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> GetDocumentRecordLogContents()
        {
            return DocumentRecordLogContents;
        }
        #endregion
        #region IStockConsumptionTransaction Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #region IStockProductionTransaction Members
        public StockActionDetailIn.ChildStockActionDetailInCollection GetStockActionInDetails()
        {
            return StockActionInDetails;
        }

        public Store GetStore()
        {
            return Store;
        }

        public Store GetDestinationStore()
        {
            return DestinationStore;
        }
        #endregion
        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ProductionConsumptionDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProductionConsumptionDocument.States.New && toState == ProductionConsumptionDocument.States.Approval)
                PreTransition_New2Approval();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ProductionConsumptionDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProductionConsumptionDocument.States.New && toState == ProductionConsumptionDocument.States.Approval)
                PostTransition_New2Approval();
            else if (fromState == ProductionConsumptionDocument.States.StockCardRegistry && toState == ProductionConsumptionDocument.States.Completed)
                PostTransition_StockCardRegistry2Completed();
            else if (fromState == ProductionConsumptionDocument.States.AutoCreate && toState == ProductionConsumptionDocument.States.Approval)
                PostTransition_AutoCreate2Approval();
        }

    }
}