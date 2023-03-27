
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// İkmal Onay
    /// </summary>
    public partial class SupplyApprovalForm_MaintenanceO : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdSIIB.Click += new TTControlEventDelegate(cmdSIIB_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdSIIB.Click -= new TTControlEventDelegate(cmdSIIB_Click);
            base.UnBindControlEvents();
        }

        private void cmdSIIB_Click()
        {
#region SupplyApprovalForm_MaintenanceO_cmdSIIB_Click
   ProductionConsumptionDocument productionConsumptionDocument = new ProductionConsumptionDocument(_MaintenanceOrder.ObjectContext);
            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.New;
            productionConsumptionDocument.Store = _MaintenanceOrder.ResDivision.Store ;
            
            IList mainStores = MainStoreDefinition.GetAllMainStores(_MaintenanceOrder.ObjectContext);
            if (mainStores.Count == 0)
                throw new TTException(SystemMessage.GetMessage(372));
            if (mainStores.Count == 1)
            {
                productionConsumptionDocument.DestinationStore = (MainStoreDefinition)mainStores[0];
            }
            else
            {
                MultiSelectForm mSelectForm = new MultiSelectForm();
                foreach (MainStoreDefinition mainStore in mainStores)
                    mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.ToString(), mainStore);

                string mkey = mSelectForm.GetMSItem(this, "İlgili Ana Depoyu Seçiniz", true);
                if (string.IsNullOrEmpty(mkey))
                    throw new TTException(SystemMessage.GetMessage(372));
                productionConsumptionDocument.DestinationStore = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
            }
            
            productionConsumptionDocument.Update();

            
            foreach (UsedConsumedMaterail usedConsumedMaterial in _MaintenanceOrder.UsedConsumedMaterails)
            {
                 if (usedConsumedMaterial.StockOut != null)
                {
                    foreach (StockOutMaterial stockOutMaterial in usedConsumedMaterial.StockOut.StockOutMaterials)
                    {
                        ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = productionConsumptionDocument.ProductionConsumptionDocumentOutMaterials.AddNew();
                        productionConsumptionDocumentMaterialOut.Material = stockOutMaterial.Material;
                        productionConsumptionDocumentMaterialOut.Amount = stockOutMaterial.Amount;
                        productionConsumptionDocumentMaterialOut.StockLevelType = stockOutMaterial.StockLevelType ;
                        foreach (StockTransaction stockTransaction in stockOutMaterial.StockTransactions)
                        {
                            StockCollectedTrx stockCollectedTrx = new StockCollectedTrx(_MaintenanceOrder.ObjectContext);
                            stockCollectedTrx.StockTransaction = stockTransaction;
                            productionConsumptionDocumentMaterialOut.StockCollectedTrxs.Add(stockCollectedTrx);
                        }
                    }
                }
            }
            
            foreach (WorkStep workStep in _MaintenanceOrder.WorkSteps)
            {
                foreach (UsedConsumedMaterail workStepMaterial in workStep.UsedConsumedMaterails)
                {
                    if (workStepMaterial.StockOut != null)
                    {
                        foreach (StockOutMaterial stockOutMaterial in workStepMaterial.StockOut.StockOutMaterials)
                        {
                            ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = productionConsumptionDocument.ProductionConsumptionDocumentOutMaterials.AddNew();
                            productionConsumptionDocumentMaterialOut.Material = stockOutMaterial.Material;
                            productionConsumptionDocumentMaterialOut.Amount = stockOutMaterial.Amount;
                            productionConsumptionDocumentMaterialOut.StockLevelType = stockOutMaterial.StockLevelType;
                            foreach (StockTransaction stockTransaction in stockOutMaterial.StockTransactions)
                            {
                                StockCollectedTrx stockCollectedTrx = new StockCollectedTrx(_MaintenanceOrder.ObjectContext);
                                stockCollectedTrx.StockTransaction = stockTransaction;
                                productionConsumptionDocumentMaterialOut.StockCollectedTrxs.Add(stockCollectedTrx);
                            }
                        }
                    }
                }
                
            }
            if (_MaintenanceOrder.MaintenanceOrderType.TypeCode == "IS")
            {
                ProductionConsumptionDocumentMaterialIn productionConsumptionDocumentMaterialIn = productionConsumptionDocument.ProductionConsumptionDocumentInMaterials.AddNew();
                productionConsumptionDocumentMaterialIn.Material = _MaintenanceOrder.FixedAssetDefinition;
                productionConsumptionDocumentMaterialIn.Amount = _MaintenanceOrder.ManufacturingAmount;
                productionConsumptionDocumentMaterialIn.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                productionConsumptionDocumentMaterialIn.UnitPrice = 0;
                productionConsumptionDocumentMaterialIn.ExpirationDate = DateTime.Now;

                for (int count = 0; count < ((int)_MaintenanceOrder.ManufacturingAmount); count++)
                {
                    FixedAssetInDetail fixedAssetInDetail = productionConsumptionDocumentMaterialIn.FixedAssetInDetails.AddNew();
                    fixedAssetInDetail.Description = _MaintenanceOrder.FixedAssetDefinition.Name;
                    fixedAssetInDetail.ProductionDate = DateTime.Now;
                }
            }
            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.Approval;
            this.cmdSIIB.Enabled = false ;
#endregion SupplyApprovalForm_MaintenanceO_cmdSIIB_Click
        }
    }
}