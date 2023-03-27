
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
    /// Bağlı Birlik Demirbaş Detayı Gönderme
    /// </summary>
    public partial class SendDetailDependentStoreForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            base.UnBindControlEvents();
        }

        private void cmdList_Click()
        {
#region SendDetailDependentStoreForm_cmdList_Click
   if (_SendDetailDependentStore.FixedAssetDefinition != null)
            {
                Guid stockID = new Guid();
                IList stocks  = Stock.GetStockFromStoreAndMaterial(_SendDetailDependentStore.ObjectContext, _SendDetailDependentStore.FixedAssetDefinition.ObjectID, _SendDetailDependentStore.Store.ObjectID);
                if (stocks.Count == 0)
                    TTVisual.InfoBox.Show("Bu malzemenin mevcudu bulunmamaktadır");
                if (stocks.Count == 1)
                    stockID = (Guid)((Stock.GetStockFromStoreAndMaterial_Class)stocks[0]).ObjectID;
                if (stocks.Count > 1)
                    TTVisual.InfoBox.Show("Hatalı stok bilgi işleme haber verin.");

                IList sendingFixedAssetMaterials = _SendDetailDependentStore.ObjectContext.QueryObjects("FIXEDASSETMATERIALDEFINITION", "STOCK =" + ConnectionManager.GuidToString(stockID));
                if (sendingFixedAssetMaterials.Count > 0)
                {
                    this.FixedAssetDefinition.Enabled = false;
                    this.cmdList.Enabled = false;
                    foreach (FixedAssetMaterialDefinition fixedAssetMaterialDefinition in sendingFixedAssetMaterials)
                    {
                        SendDetailFixedAsset sendDetailFixedAsset = new SendDetailFixedAsset(_SendDetailDependentStore.ObjectContext);
                        sendDetailFixedAsset.FixedAssetMaterialDefinition = fixedAssetMaterialDefinition;
                        sendDetailFixedAsset.SendDetailDependentStore = _SendDetailDependentStore;
                    }
                }
                else
                {
                    TTVisual.InfoBox.Show("Hiçbir detay bulunamadı.", MessageIconEnum.InformationMessage);
                }
            }
#endregion SendDetailDependentStoreForm_cmdList_Click
        }

        protected override void PreScript()
        {
#region SendDetailDependentStoreForm_PreScript
    base.PreScript();
#endregion SendDetailDependentStoreForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region SendDetailDependentStoreForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            DependentStoreDefinition sendingStore = new DependentStoreDefinition();
            IList sendingStores = _SendDetailDependentStore.ObjectContext.QueryObjects("DEPENDENTSTOREDEFINITION", "SITE IS NOT NULL");
            if(sendingStores.Count == 0)
                throw new TTException("İşlemin yapılacağı bağlı birlik deposu bulunamadığından işleme devam edemezsiniz.");
            if (sendingStores.Count == 1)
                sendingStore = (DependentStoreDefinition)sendingStores[0];
            else
            {
                MultiSelectForm mSelectForm = new MultiSelectForm();
                foreach (DependentStoreDefinition dependentStoreDefinition in sendingStores)
                {
                    mSelectForm.AddMSItem(dependentStoreDefinition.Name, dependentStoreDefinition.ObjectID.ToString(), dependentStoreDefinition);
                }
                string mkey = mSelectForm.GetMSItem(this, "İlgili Bağlı Brilik Deposunu Seçiniz", true);
                if (string.IsNullOrEmpty(mkey))
                {
                    throw new TTException("İşlemin yapılacağı bağlı birlik deposu seçilmeden işleme devam edemezsiniz.");
                }
                else
                {
                    sendingStore = mSelectForm.MSSelectedItemObject as DependentStoreDefinition;
                }
            }
            _SendDetailDependentStore.Store = sendingStore;
#endregion SendDetailDependentStoreForm_ClientSidePreScript

        }
    }
}