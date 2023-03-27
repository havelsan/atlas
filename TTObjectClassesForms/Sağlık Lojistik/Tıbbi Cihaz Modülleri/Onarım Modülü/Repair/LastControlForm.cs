
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
    /// Son Kontrol
    /// </summary>
    public partial class LastControlForm : RepairBaseForm
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
#region LastControlForm_cmdSIIB_Click
   ProductionConsumptionDocument productionConsumptionDocument = new ProductionConsumptionDocument(_Repair.ObjectContext);
            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.New;
            productionConsumptionDocument.Store = _Repair.WorkShop.Store;

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
                    throw new TTException(SystemMessage.GetMessage(372));
                productionConsumptionDocument.DestinationStore = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
            }

            productionConsumptionDocument.Update();


            foreach (UsedConsumedMaterail usedConsumedMaterial in _Repair.UsedConsumedMaterails)
            {
                if (usedConsumedMaterial.StockOut != null)
                {
                    foreach (StockOutMaterial stockOutMaterial in usedConsumedMaterial.StockOut.StockOutMaterials)
                    {
                        ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = productionConsumptionDocument.ProductionConsumptionDocumentOutMaterials.AddNew();
                        productionConsumptionDocumentMaterialOut.Material = stockOutMaterial.Material;
                        productionConsumptionDocumentMaterialOut.Amount = stockOutMaterial.Amount;
                        productionConsumptionDocumentMaterialOut.StockLevelType = stockOutMaterial.StockLevelType;
                        foreach (StockTransaction stockTransaction in stockOutMaterial.StockTransactions)
                        {
                            StockCollectedTrx stockCollectedTrx = new StockCollectedTrx(_Repair.ObjectContext);
                            stockCollectedTrx.StockTransaction = stockTransaction;
                            productionConsumptionDocumentMaterialOut.StockCollectedTrxs.Add(stockCollectedTrx);
                        }
                    }
                }
            }
            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.Approval;
            this.cmdSIIB.Enabled = false;
            this.DropStateButton(Repair.States.Repair);
            this.DropStateButton(Repair.States.HEK);
            this.DropStateButton(Repair.States.FirmRepair);
            this.DropStateButton(Repair.States.GuarantyRepair);
            this.cmdOK.Visible = false;
#endregion LastControlForm_cmdSIIB_Click
        }

        protected override void PreScript()
        {
#region LastControlForm_PreScript
    base.PreScript();

            switch (_Repair.StateIDBeforeLastControl)
            {
                case "3afb41ab-805b-4277-83dc-e5793b6407f4": //HEK
                    this.DropStateButton(Repair.States.FirmRepair);
                    this.DropStateButton(Repair.States.GuarantyRepair);
                    this.DropStateButton(Repair.States.Repair);
                    break;
                case "783357cf-70e8-4c3b-91e4-7bcd14ccdf54": //Firma Onarımı
                    this.DropStateButton(Repair.States.HEK);
                    this.DropStateButton(Repair.States.GuarantyRepair);
                    this.DropStateButton(Repair.States.Repair);
                    break;
                case "b3f598c9-16b7-432a-bd8b-926eb20fc6c2": //Garanti Onarımı
                    this.DropStateButton(Repair.States.FirmRepair);
                    this.DropStateButton(Repair.States.HEK);
                    this.DropStateButton(Repair.States.Repair);
                    break;
                case "3c0dbf63-c1d4-42ed-8edc-3d80c73facec": //Onarım
                    this.DropStateButton(Repair.States.FirmRepair);
                    this.DropStateButton(Repair.States.GuarantyRepair);
                    this.DropStateButton(Repair.States.HEK);
                    break;
                default:
                    throw new TTUtils.TTCallAdminException();
                    //break;
            }
            if (_Repair.UsedConsumedMaterails.Count == 0)
            {
                this.cmdSIIB.Enabled = false;
            }
#endregion LastControlForm_PreScript

            }
                }
}