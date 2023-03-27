
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
    /// Bağlı Birlik İlk Giriş
    /// </summary>
    public partial class DepStoreFirstInNewForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdGetDepStock.Click += new TTControlEventDelegate(cmdGetDepStock_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdGetDepStock.Click -= new TTControlEventDelegate(cmdGetDepStock_Click);
            base.UnBindControlEvents();
        }

        private void cmdGetDepStock_Click()
        {
#region DepStoreFirstInNewForm_cmdGetDepStock_Click
   if (_DepStoreFirstInAction.DependentStore != null)
            {
                IList depStocks = _DepStoreFirstInAction.ObjectContext.QueryObjects("STOCK", "STORE = " + ConnectionManager.GuidToString(_DepStoreFirstInAction.DependentStore.ObjectID) + " AND INHELD > 0");
                foreach (Stock dStock in depStocks)
                {
                    foreach (StockLevel level in dStock.StockLevels)
                    {
                        if (level.Amount > 0)
                        {
                            DepStoreFirstInActionDet depStoreFirstInActionDet = new DepStoreFirstInActionDet(_DepStoreFirstInAction.ObjectContext);
                            depStoreFirstInActionDet.Material = dStock.Material;
                            depStoreFirstInActionDet.Amount = level.Amount;
                            depStoreFirstInActionDet.StockLevelType = level.StockLevelType;
                            depStoreFirstInActionDet.UnitPrice  = (Currency)dStock.TotalInPrice / dStock.TotalIn;
                            depStoreFirstInActionDet.DepStoreFirstInAction = _DepStoreFirstInAction;
                            if (dStock.Material is FixedAssetDefinition && dStock.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                            {
                                IList fixedAssetMaterialDefinitions = FixedAssetMaterialDefinition.GetFixedAssetMaterialsByMaterialAndStore(_DepStoreFirstInAction.ObjectContext,dStock.Material.ObjectID,_DepStoreFirstInAction.DependentStore.ObjectID);
                                foreach (FixedAssetMaterialDefinition famd in fixedAssetMaterialDefinitions)
                                {
                                    DepStoreFixedAssetDetail depStoreFixedAssetDetail = new DepStoreFixedAssetDetail(_DepStoreFirstInAction.ObjectContext);
                                    depStoreFixedAssetDetail.FixedAssetMaterialDefinition = famd;
                                    depStoreFixedAssetDetail.DepStoreFirstInActionDet = depStoreFirstInActionDet;
                                }
                            }
                        }
                    }
                    
                }
            }
            else
            {
                throw new TTException("Bağlı Birlik Deposu seçmelisiniz.");
            }
#endregion DepStoreFirstInNewForm_cmdGetDepStock_Click
        }
    }
}