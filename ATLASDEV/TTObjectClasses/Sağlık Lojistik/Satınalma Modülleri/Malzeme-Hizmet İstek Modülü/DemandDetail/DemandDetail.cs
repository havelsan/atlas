
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
    /// Malzeme/Hizmet İstek modülünde her istek kalemi için detayların ana sınıfıdır
    /// </summary>
    public partial class DemandDetail : TTObject
    {
        public partial class SatınalmaIstek_DemandDetailQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetManagerialMatterReportQuery_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "PURCHASEITEMDEF":
                    {
                        PurchaseItemDef value = (PurchaseItemDef)newValue;
                        #region PURCHASEITEMDEF_SetParentScript
                        if (Demand.MasterResource.Store != null)
                        {
                            StoreStocks = value.GetItemStocks(Demand.MasterResource.Store);
                        }
                        #endregion PURCHASEITEMDEF_SetParentScript
                    }
                    break;

            }
        }

        #region Methods
        public void SetPurchaseItemStoreStocks()
        {
            if (Demand.MasterResource.Store == null)
                return;

            List<Guid> existingStoreStocks = new List<Guid>();
            foreach (DemandDetailStoreStock dds in DemandDetailStoreStocks)
            {
                existingStoreStocks.Add(dds.Store.ObjectID);
                dds.Amount = PurchaseItemDef.GetItemStocks(dds.Store);
                foreach (DemandDetStoreStockDetail dddet in dds.StoreStockDetails)
                {
                    dddet.Amount = dddet.Material.StockInheld(dds.Store);
                }
            }

            //this.DemandDetailStoreStocks.DeleteChildren(); Silmemek, Güncellemek lazım
            foreach (Store s in Store.GetAllStores(ObjectContext))
            {
                if (Demand.MasterResource.Store.ObjectID != s.ObjectID)
                {
                    if (s is SubStoreDefinition || s is PharmacyStoreDefinition || s is MainStoreDefinition)
                    {
                        if (PurchaseItemDef.GetItemStocks(s) > 0)
                        {
                            if (existingStoreStocks.Contains(s.ObjectID) == false)
                            {
                                DemandDetailStoreStock ddss = new DemandDetailStoreStock(ObjectContext);
                                ddss.Amount = PurchaseItemDef.GetItemStocks(s);
                                if (s is MainStoreDefinition)
                                    AccountancyAmount = ddss.Amount;
                                ddss.Store = s;
                                ddss.DemandDetail = this;
                                ddss.TransferAmount = 0;
                                foreach (Material material in PurchaseItemDef.StockCard.Materials)
                                {
                                    DemandDetStoreStockDetail ddssd = new DemandDetStoreStockDetail(ObjectContext);
                                    ddssd.DemandDetailStoreStock = ddss;
                                    ddssd.Material = material;
                                    ddssd.Amount = material.StockInheld(s);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AddTransferForDemand()
        {

            ArrayList list = new ArrayList();
            foreach (TransferForDemand tfd in Demand.TransferForDemands)
            {
                if (tfd.DemandDetail.PurchaseItemDef.ObjectID == PurchaseItemDef.ObjectID)
                    list.Add(tfd);
            }

            foreach (TransferForDemand transferForDemand in list)
            {
                ((ITTObject)transferForDemand).Delete();
            }

            double totalTransferAmount = 0;
            foreach (DemandDetailStoreStock ddss in DemandDetailStoreStocks)
            {
                if (ddss.TransferAmount > 0)
                {
                    foreach (DemandDetStoreStockDetail ddssd in ddss.StoreStockDetails)
                    {
                        if (ddssd.Amount > 0)
                        {
                            TransferForDemand newTf = new TransferForDemand(ObjectContext);
                            newTf.CurrentStateDefID = TransferForDemand.States.New;
                            newTf.DemandDetail = this;
                            newTf.Demand = Demand;
                            newTf.Store = ddss.Store;
                            newTf.Amount = ddssd.TransferAmount;
                            newTf.Material = ddssd.Material;
                            newTf.DemandDetStoreStockDetail = ddssd;
                            totalTransferAmount += (double)ddssd.TransferAmount;
                        }
                    }
                }
            }
            TransferAmount = totalTransferAmount;
        }

        #endregion Methods

    }
}