
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
    /// Majistral İlaç Hazırlama
    /// </summary>
    public  partial class MagistralPreparationAction : StockAction, IStockOutTransaction, ICheckStockActionOutDetail
    {
        protected void PostTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
#region PostTransition_Approval2Completed
            
            
            
            
            
            
            /*
            ProductionConsumptionDocument productionConsumptionDocument = new ProductionConsumptionDocument(this.ObjectContext);
            
            IList mainStores = MainStoreDefinition.GetAllMainStores(this.ObjectContext);
            if (mainStores.Count == 0)
                throw new TTException(SystemMessage.GetMessage(372));
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

            BigCurrency  totalCost = 0;
            foreach (MagistralPreparationUsedDetail outMaterial in this.MagistralPreparationUsedDetails)
            {
                ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = productionConsumptionDocument.ProductionConsumptionDocumentOutMaterials.AddNew();
                productionConsumptionDocumentMaterialOut.Material = outMaterial.Material;
                productionConsumptionDocumentMaterialOut.Amount = outMaterial.Amount;
                productionConsumptionDocumentMaterialOut.StockLevelType = outMaterial.StockLevelType;
                foreach (StockTransaction stockTransaction in outMaterial.StockTransactions)
                {
                    StockCollectedTrx stockCollectedTrx = new StockCollectedTrx(this.ObjectContext);
                    stockCollectedTrx.StockTransaction = stockTransaction;
                    totalCost = totalCost + ((BigCurrency)stockTransaction.UnitPrice * (BigCurrency)stockTransaction.Amount) ;
                    productionConsumptionDocumentMaterialOut.StockCollectedTrxs.Add(stockCollectedTrx);
                }
                
            }
            foreach (MagistralPreparationDetail inMaterial in this.MagistralPreparationDetails)
            {
                ProductionConsumptionDocumentMaterialIn productionConsumptionDocumentMaterialIn = productionConsumptionDocument.ProductionConsumptionDocumentInMaterials.AddNew();
                productionConsumptionDocumentMaterialIn.Material = inMaterial.MagistralPreparationDef;
                productionConsumptionDocumentMaterialIn.Amount = inMaterial.Amount;
                productionConsumptionDocumentMaterialIn.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                productionConsumptionDocumentMaterialIn.UnitPrice = totalCost / inMaterial.Amount;
                productionConsumptionDocumentMaterialIn.ExpirationDate  = inMaterial.ExpirationDate;

                DistributionDocumentMaterial disDocMaterial = distributionDocument.DistributionDocumentMaterials.AddNew();
                disDocMaterial.Material = inMaterial.MagistralPreparationDef;
                disDocMaterial.AcceptedAmount = inMaterial.Amount;
                disDocMaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;

            }
            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.Approval;
            distributionDocument.CurrentStateDefID = DistributionDocument.States.Approval ;

    */










#endregion PostTransition_Approval2Completed
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MagistralPreparationAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MagistralPreparationAction.States.Approval && toState == MagistralPreparationAction.States.Completed)
                PostTransition_Approval2Completed();
        }
        #region Methods
        #region ICheckStockActionOutDetail Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #region IStockInTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
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
        #endregion
    }
}