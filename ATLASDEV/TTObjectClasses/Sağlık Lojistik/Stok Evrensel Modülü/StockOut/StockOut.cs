
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
    /// Stok Çıkışlarının Yapılması İçin kullanılan sınıftır
    /// </summary>
    public partial class StockOut : StockAction, IStockOutTransaction, ICheckStockActionOutDetail
    {
        #region Methods
        #region ICheckStockActionOutDetail Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #region IStockOutTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        public void CreateProductionDocument()
        {
            TTObjectContext context = new TTObjectContext(false);
            ProductionConsumptionDocument productionConsumptionDocument = new ProductionConsumptionDocument(context);
            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.New;
            productionConsumptionDocument.Store = Store;

            IList mainStores = MainStoreDefinition.GetAllMainStores(context);
            if (mainStores.Count == 0)
                throw new TTException(SystemMessage.GetMessage(372));
            if (mainStores.Count == 1)
            {
                productionConsumptionDocument.DestinationStore = (MainStoreDefinition)mainStores[0];
            }
            else
            {
                throw new TTException(SystemMessage.GetMessage(1044));
            }

            productionConsumptionDocument.Update();


            foreach (StockOutMaterial stockOutMaterial in StockOutMaterials)
            {
                ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = productionConsumptionDocument.ProductionConsumptionDocumentOutMaterials.AddNew();
                productionConsumptionDocumentMaterialOut.Material = stockOutMaterial.Material;
                productionConsumptionDocumentMaterialOut.Amount = stockOutMaterial.Amount;
                productionConsumptionDocumentMaterialOut.StockLevelType = stockOutMaterial.StockLevelType;
                foreach (StockTransaction stockTransaction in stockOutMaterial.StockTransactions)
                {
                    StockCollectedTrx stockCollectedTrx = new StockCollectedTrx(context);
                    stockCollectedTrx.StockTransaction = stockTransaction;
                    productionConsumptionDocumentMaterialOut.StockCollectedTrxs.Add(stockCollectedTrx);
                }
            }
            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.Approval;
            context.Save();
            context.Dispose();
        }

        #endregion Methods
        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockOut).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == StockOut.States.Completed && toState == StockOut.States.Cancelled)
                PreTransition_Completed2Cancelled();

        }
        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_New2Completed

            foreach (StockActionDetail stockActionDetail in StockActionDetails)
            {
                if (stockActionDetail.SubActionMaterial.Count > 0)
                {
                    BaseTreatmentMaterial material = (BaseTreatmentMaterial)stockActionDetail.SubActionMaterial[0];
                    if (material.CurrentStateDefID != BaseTreatmentMaterial.States.Cancelled)
                        material.CurrentStateDefID = BaseTreatmentMaterial.States.Cancelled;
                }
            }


            #endregion PreTransition_New2Completed
        }
    }
}