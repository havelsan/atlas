
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
    /// MSB İlaç Ãœretim İşlemi için kullanılan temel sınıftır
    /// </summary>
    public  partial class MilitaryDrugProductionProcedure : StockAction, IStockOutTransaction, ICheckStockActionOutDetail
    {
        public partial class GetMilitaryDrugProductionProcedureAnalysisDetails_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_Released2Completed()
        {
            // From State : Released   To State : Completed
#region PostTransition_Released2Completed
            
            
            
            BindingList<MainStoreDefinition> mainStores = MainStoreDefinition.GetAllMainStores(ObjectContext);
            MainStoreDefinition mainStore = null;
            if (mainStores.Count > 0)
                mainStore = mainStores[0];

            ProductionConsumptionDocument productionConsumptionDocument = new ProductionConsumptionDocument(ObjectContext);
            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.New;
            productionConsumptionDocument.Store = Store;
            productionConsumptionDocument.DestinationStore = mainStore;
            productionConsumptionDocument.Update();

            foreach (MilitaryDrugProductionProcedureMaterialOut outMaterial in MilitaryDrugProductionProcedureOutMaterials)
            {
                ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = productionConsumptionDocument.ProductionConsumptionDocumentOutMaterials.AddNew();
                productionConsumptionDocumentMaterialOut.Material = outMaterial.Material;
                productionConsumptionDocumentMaterialOut.Amount = outMaterial.Amount;
                productionConsumptionDocumentMaterialOut.StockLevelType = outMaterial.StockLevelType;
                foreach (StockTransaction stockTransaction in outMaterial.StockTransactions)
                {
                    StockCollectedTrx stockCollectedTrx = new StockCollectedTrx(ObjectContext);
                    stockCollectedTrx.StockTransaction = stockTransaction;
                    productionConsumptionDocumentMaterialOut.StockCollectedTrxs.Add(stockCollectedTrx);
                }
            }

            ProductionConsumptionDocumentMaterialIn productionConsumptionDocumentMaterialIn = productionConsumptionDocument.ProductionConsumptionDocumentInMaterials.AddNew();
            productionConsumptionDocumentMaterialIn.Material = ProducedMaterial.Material;
            productionConsumptionDocumentMaterialIn.Amount = ProducedMaterialAmount;
            productionConsumptionDocumentMaterialIn.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
            productionConsumptionDocumentMaterialIn.UnitPrice = 0;

            if(ExpirationDateOfProduction == null)
                productionConsumptionDocumentMaterialIn.ExpirationDate = Common.GetLastDayOfMounth(DateTime.MinValue);
            else
                productionConsumptionDocumentMaterialIn.ExpirationDate = Common.GetLastDayOfMounth((DateTime)ExpirationDateOfProduction);
            productionConsumptionDocumentMaterialIn.LotNo = SerialNO;

            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.Approval;

#endregion PostTransition_Released2Completed
        }

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
        public int RepeatCount
        {
            get
            {
                int i = 0;
                if (CurrentStateDefID.HasValue)
                {
                    Guid currentStateDefID = CurrentStateDefID.Value;
                    foreach (TTObjectState objectState in GetStateHistory())
                    {
                        if (objectState.StateDefID.Equals(currentStateDefID))
                            i++;
                    }
                }
                else
                {
                    i = 1;
                }
                return i;
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MilitaryDrugProductionProcedure).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MilitaryDrugProductionProcedure.States.Released && toState == MilitaryDrugProductionProcedure.States.Completed)
                PostTransition_Released2Completed();
        }

    }
}