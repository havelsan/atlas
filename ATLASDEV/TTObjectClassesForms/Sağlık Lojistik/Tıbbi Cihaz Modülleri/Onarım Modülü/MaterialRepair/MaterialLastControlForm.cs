
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
    /// Son Kontrol[Stok Numaralı]
    /// </summary>
    public partial class MaterialLastControlForm : RepairBaseForm
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
#region MaterialLastControlForm_cmdSIIB_Click
   ProductionConsumptionDocument productionConsumptionDocument = new ProductionConsumptionDocument(_Repair.ObjectContext);
            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.New;
            productionConsumptionDocument.Store = _MaterialRepair.WorkShop.Store ;

            IList mainStores = MainStoreDefinition.GetAllMainStores(_Repair.ObjectContext);
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
                    throw new TTException(SystemMessage.GetMessage(371));
                productionConsumptionDocument.DestinationStore = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
            }
            
            productionConsumptionDocument.Update();


            foreach (UsedConsumedMaterail usedConsumedMaterial in _MaterialRepair.UsedConsumedMaterails)
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
                            StockCollectedTrx stockCollectedTrx = new StockCollectedTrx(_MaterialRepair.ObjectContext);
                            stockCollectedTrx.StockTransaction = stockTransaction;
                            productionConsumptionDocumentMaterialOut.StockCollectedTrxs.Add(stockCollectedTrx);
                        }
                    }
                }
            }
            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.Approval;
            this.cmdSIIB.Enabled = false ;
            this.DropStateButton(MaterialRepair.States.Repair);
            this.DropStateButton(MaterialRepair.States.HEK);
            this.DropStateButton(MaterialRepair.States.FirmRepair);
            this.DropStateButton(MaterialRepair.States.GuarantyRepair);
            this.cmdOK.Visible = false;
#endregion MaterialLastControlForm_cmdSIIB_Click
        }

        protected override void PreScript()
        {
#region MaterialLastControlForm_PreScript
    base.PreScript();
            switch (_MaterialRepair.StateIDBeforeLastControl)
            {
                case "409bb493-582b-4e96-bc47-bf7f29c9eee3": //HEK
                    this.DropStateButton(MaterialRepair.States.FirmRepair);
                    this.DropStateButton(MaterialRepair.States.GuarantyRepair);
                    this.DropStateButton(MaterialRepair.States.Repair);
                    break;
                case "83a133a8-32e1-4926-b9ea-12fc8098f812": //Firma Onarımı
                    this.DropStateButton(MaterialRepair.States.HEK);
                    this.DropStateButton(MaterialRepair.States.GuarantyRepair);
                    this.DropStateButton(MaterialRepair.States.Repair);
                    break;
                case "998be4cc-4f4d-41cf-be81-983aeb1dde84": //Garanti Onarımı
                    this.DropStateButton(MaterialRepair.States.FirmRepair);
                    this.DropStateButton(MaterialRepair.States.HEK);
                    this.DropStateButton(MaterialRepair.States.Repair);
                    break;
                case "62858f10-e150-46d8-ae1c-73469d60b132": //Onarım
                    this.DropStateButton(MaterialRepair.States.FirmRepair);
                    this.DropStateButton(MaterialRepair.States.GuarantyRepair);
                    this.DropStateButton(MaterialRepair.States.HEK);
                    break;
                default:
                    throw new TTUtils.TTCallAdminException();
                    //break;
            }
            if(_MaterialRepair.UsedConsumedMaterails.Count == 0)
            {
                this.cmdSIIB.Enabled = false ;
            }
#endregion MaterialLastControlForm_PreScript

            }
                }
}