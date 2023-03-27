
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
    /// Genel Ãœretim İşlemi
    /// </summary>
    public partial class GeneralProductionAction : StockAction, IGeneralProductionAction, IStockOutTransaction, ICheckStockActionOutDetail, IAutoDocumentRecordLog
    {
        public partial class GeneralProductionReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GeneralProductionReportQuery2_Class : TTReportNqlObject
        {
        }

        protected void PreTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
            #region PreTransition_Approval2Completed

            //             Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            //            TTReportTool.PropertyCache<object> pc1 = new TTReportTool.PropertyCache<object>();
            //            pc1.Add("VALUE",this.ObjectID.ToString());
            //            parameters.Add("TTOBJECTID", pc1);
            //            TTReportTool.TTReport.PrintReport((typeof(TTReportClasses.I_ProductionDocumentReport)), true, 1, parameters);

            /*ProductionConsumptionDocument productionConsumptionDocument = new ProductionConsumptionDocument(this.ObjectContext);
            
            IList mainStores = MainStoreDefinition.GetAllMainStores(this.ObjectContext);
            if (mainStores.Count == 0)
                throw new TTException("İşlemin yapılacağı ana depo bulunamadığından işleme devam edemezsiniz.");
            if (mainStores.Count == 1)
            {
                productionConsumptionDocument.DestinationStore = (MainStoreDefinition)mainStores[0];
            }

            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.New;
            productionConsumptionDocument.Store = (Store)this.Store;
            productionConsumptionDocument.Update();

            DistributionDocument distributionDocument = new DistributionDocument(this.ObjectContext);

            distributionDocument.CurrentStateDefID = DistributionDocument.States.New;
            distributionDocument.Store = (MainStoreDefinition)mainStores[0];
            distributionDocument.DestinationStore = (Store)this.Store;
            distributionDocument.Update();

            foreach (GeneralProductionOutDet outMaterial in this.GeneralProductionOutDets)
            {
                ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = productionConsumptionDocument.ProductionConsumptionDocumentOutMaterials.AddNew();
                productionConsumptionDocumentMaterialOut.Material = outMaterial.Material;
                productionConsumptionDocumentMaterialOut.Amount = outMaterial.Amount;
                productionConsumptionDocumentMaterialOut.StockLevelType = outMaterial.StockLevelType;
                foreach (StockTransaction stockTransaction in outMaterial.StockTransactions.Select(String.Empty))
                {
                    StockCollectedTrx stockCollectedTrx = new StockCollectedTrx(this.ObjectContext);
                    stockCollectedTrx.StockTransaction = stockTransaction;
                    productionConsumptionDocumentMaterialOut.StockCollectedTrxs.Add(stockCollectedTrx);
                }
                
            }
            
            ProductionConsumptionDocumentMaterialIn productionConsumptionDocumentMaterialIn = productionConsumptionDocument.ProductionConsumptionDocumentInMaterials.AddNew();
            productionConsumptionDocumentMaterialIn.Material = this.Material;
            productionConsumptionDocumentMaterialIn.Amount = this.Amount;
            productionConsumptionDocumentMaterialIn.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
            productionConsumptionDocumentMaterialIn.UnitPrice = this.UnitPrice ;

            DistributionDocumentMaterial disDocMaterial = distributionDocument.DistributionDocumentMaterials.AddNew();
            disDocMaterial.Material = this.Material;
            disDocMaterial.AcceptedAmount = this.Amount;
            disDocMaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;

            
            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.Approval;
            distributionDocument.CurrentStateDefID = DistributionDocument.States.New;*/

            GeneralProductionInDet generalProductionInDet = new GeneralProductionInDet(ObjectContext);
            generalProductionInDet.Amount = Amount;
            generalProductionInDet.UnitPrice = UnitPrice;
            generalProductionInDet.Material = Material;
            generalProductionInDet.ProductionDate = ActionDate;
            generalProductionInDet.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
            generalProductionInDet.NotDiscountedUnitPrice = UnitPrice;
            generalProductionInDet.Update();
            GeneralProductionInDets.Add(generalProductionInDet);



            #endregion PreTransition_Approval2Completed
        }

        protected void UndoTransition_Approval2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Approval   To State : Completed
            #region UndoTransition_Approval2Completed
            NoBackStateBack();
            #endregion UndoTransition_Approval2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(GeneralProductionAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == GeneralProductionAction.States.Approval && toState == GeneralProductionAction.States.Completed)
                PreTransition_Approval2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(GeneralProductionAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == GeneralProductionAction.States.Approval && toState == GeneralProductionAction.States.Completed)
                UndoTransition_Approval2Completed(transDef);
        }


        #region Methods
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
        #region ICheckStockActionOutDetail Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #region IGeneralProductionAction Members
        public Currency? GetAmount()
        {
            return Amount;
        }
        public void SetAmount(Currency? value)
        {
            Amount = value;
        }

        public bool? GetInMkysControl()
        {
            return InMkysControl;
        }
        public void SetInMkysControl(bool? value)
        {
            InMkysControl = value;
        }

        public bool? GetOutMkysControl()
        {
            return OutMkysControl;
        }
        public void SetOutMkysControl(bool? value)
        {
            OutMkysControl = value;
        }

        public BigCurrency? GetUnitPrice()
        {
            return UnitPrice;
        }
        public void SetUnitPrice(BigCurrency? value)
        {
            UnitPrice = value;
        }

        public int? GetMKYS_AyniyatMakbuzIDGiris()
        {
            return MKYS_AyniyatMakbuzIDGiris;
        }
        public void SetMKYS_AyniyatMakbuzIDGiris(int? value)
        {
            MKYS_AyniyatMakbuzIDGiris = value;
        }

        public Material GetMaterial()
        {
            return Material;
        }
        public void SetMaterial(Material value)
        {
            Material = value; 
        }
        #endregion
        #region IStockInTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }
        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public StockActionDetailIn.ChildStockActionDetailInCollection GetStockActionInDetails()
        {
            return StockActionInDetails;
        }

        public Store GetStore()
        {
            return Store;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion

        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> inRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> outRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (GeneralProductionInDet detail in _GeneralProductionInDets)
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

                foreach (GeneralProductionOutDet detail in GeneralProductionOutDets)
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

                _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                if (inRecordLogs.Count > 0)
                {
                    //_documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                    foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> inLog in inRecordLogs)
                    {
                        string place = ((MainStoreDefinition)Store).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)Store).Accountancy.Name;
                        AutoDocumentRecordLogAttribute.DocumentRecordLogContent logContent = new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.In, this, inLog.Value.Count, place, inLog.Key);

                        _documentRecordLogContents.Add(logContent);
                    }
                }

                if (outRecordLogs.Count > 0)
                {
                     //_documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                    foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> outLog in outRecordLogs)
                    {
                        string place = ((MainStoreDefinition)Store).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)Store).Accountancy.Name;
                        AutoDocumentRecordLogAttribute.DocumentRecordLogContent logContent = new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.Out, this, outLog.Value.Count, place, outLog.Key);

                        _documentRecordLogContents.Add(logContent);
                    }
                }
                return _documentRecordLogContents;
            }
        }

 
        #endregion Methods


    }
}