
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
    public partial class SubStoreStockTransferNewForm : BaseSubStoreStockTransferForm
    {
        protected override void PreScript()
        {
            #region SubStoreStockTransferNewForm_PreScript
            base.PreScript();

            if (_SubStoreStockTransfer.Store is MainStoreDefinition)
            {
                _SubStoreStockTransfer.MKYS_TeslimEden = ((MainStoreDefinition)_SubStoreStockTransfer.Store).GoodsAccountant.Name;
                _SubStoreStockTransfer.MKYS_TeslimEdenObjID = ((MainStoreDefinition)_SubStoreStockTransfer.Store).GoodsAccountant.ObjectID;
            }
            if (_SubStoreStockTransfer.DestinationStore is SubStoreDefinition)
            {
                _SubStoreStockTransfer.MKYS_TeslimAlan = ((SubStoreDefinition)_SubStoreStockTransfer.DestinationStore).StoreResponsible.Name;
                _SubStoreStockTransfer.MKYS_TeslimAlanObjID = ((SubStoreDefinition)_SubStoreStockTransfer.DestinationStore).StoreResponsible.ObjectID;
            }
            /* if (_SubStoreStockTransfer.StockActionSignDetails.Count == 0)
             {
                 StockActionSignDetail stockActionSignDetail = _SubStoreStockTransfer.StockActionSignDetails.AddNew();
                 stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                 if (_SubStoreStockTransfer.Store is MainStoreDefinition)
                     stockActionSignDetail.SignUser = ((MainStoreDefinition)_SubStoreStockTransfer.Store).GoodsAccountant;

                 stockActionSignDetail = _SubStoreStockTransfer.StockActionSignDetails.AddNew();
                 stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSorumlusu;
                 if (_SubStoreStockTransfer.Store is MainStoreDefinition)
                     stockActionSignDetail.SignUser = ((MainStoreDefinition)_SubStoreStockTransfer.Store).GoodsResponsible;

                 stockActionSignDetail = _SubStoreStockTransfer.StockActionSignDetails.AddNew();
                 stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                 if (_SubStoreStockTransfer.Store is MainStoreDefinition)
                 {

                     if (((MainStoreDefinition)_SubStoreStockTransfer.Store).AccountManager != null)
                     {
                         stockActionSignDetail.SignUser = ((MainStoreDefinition)_SubStoreStockTransfer.Store).AccountManager;
                     }
                     else
                     {
                         ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                         if (user.SelectedSecMasterResource != null && user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                             stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                     }
                 }

                 stockActionSignDetail = _SubStoreStockTransfer.StockActionSignDetails.AddNew();
                 stockActionSignDetail.SignUserType = SignUserTypeEnum.DepoSorumlusu;
                 if (_SubStoreStockTransfer.DestinationStore is SubStoreDefinition)
                     stockActionSignDetail.SignUser = ((SubStoreDefinition)_SubStoreStockTransfer.DestinationStore).StoreResponsible;
                 else if (_SubStoreStockTransfer.DestinationStore is PharmacyStoreDefinition)
                     stockActionSignDetail.SignUser = ((PharmacyStoreDefinition)_SubStoreStockTransfer.DestinationStore).StoreResponsible;
             }*/
            #endregion SubStoreStockTransferNewForm_PreScript

        }
    }
}