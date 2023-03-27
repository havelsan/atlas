
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
    /// Stok Çıkış
    /// </summary>
    public partial class StockOutForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region StockOutForm_PreScript
    base.PreScript();
            
            this.DropStateButton(StockOut.States.Cancelled);
#endregion StockOutForm_PreScript

            }
            
#region StockOutForm_Methods
        //        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
//        {
//            base.AfterContextSavedScript(transDef);
//
//            if (transDef != null)
//            {
//                if (transDef.ToStateDefID == StockOut.States.Completed)
//                {
//                    if ((bool)_StockOut.CreateRemote.HasValue && _StockOut.CreateRemote.Value)
//                    {
//                        TTObjectContext context = new TTObjectContext(false);
//                        ProductionConsumptionDocument productionConsumptionDocument = new ProductionConsumptionDocument(context);
//                        productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.New;
//                        productionConsumptionDocument.Store = _StockOut.Store;
//
//                        IList mainStores = MainStoreDefinition.GetAllMainStores(context);
//                        if (mainStores.Count == 0)
//                            throw new TTException("İşlemin yapılacağı ana depo bulunamadığından işleme devam edemezsiniz.");
//                        if (mainStores.Count == 1)
//                        {
//                            productionConsumptionDocument.DestinationStore = (MainStoreDefinition)mainStores[0];
//                        }
//                        else
//                        {
//                            throw new TTException("Birden fazla ana depo bulundu işleme devam edemezsiniz.");
//                        }
//                        
//                        productionConsumptionDocument.ProductionDepStoreObjectID = _StockOut.ProductionDepStoreObjectID;
//                        productionConsumptionDocument.Update();
//
//                        foreach (StockOutMaterial stockOutMaterial in _StockOut.StockOutMaterials)
//                        {
//                            ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = productionConsumptionDocument.ProductionConsumptionDocumentOutMaterials.AddNew();
//                            productionConsumptionDocumentMaterialOut.Material = stockOutMaterial.Material;
//                            productionConsumptionDocumentMaterialOut.Amount = stockOutMaterial.Amount;
//                            productionConsumptionDocumentMaterialOut.StockLevelType = stockOutMaterial.StockLevelType;
//                            foreach (StockTransaction stockTransaction in stockOutMaterial.StockTransactions)
//                            {
//                                StockCollectedTrx stockCollectedTrx = new StockCollectedTrx(context);
//                                stockCollectedTrx.StockTransaction = stockTransaction;
//                                productionConsumptionDocumentMaterialOut.StockCollectedTrxs.Add(stockCollectedTrx);
//                            }
//                        }
//                        productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.Approval;
//                        context.Save();
//                        context.Dispose();
//                    }
//                }
//            }
//
//        }
        
#endregion StockOutForm_Methods
    }
}