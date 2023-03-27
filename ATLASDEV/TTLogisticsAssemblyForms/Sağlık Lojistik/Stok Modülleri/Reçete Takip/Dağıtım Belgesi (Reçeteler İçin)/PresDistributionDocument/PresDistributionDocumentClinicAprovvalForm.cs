
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
    /// Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresDistributionDocumentClinicAprovvalForm : BasePresDistributionDocumentForm
    {
        protected override void PreScript()
        {
#region PresDistributionDocumentClinicAprovvalForm_PreScript
    base.PreScript();
            MaterialPresDistributionDocMaterial.ListFilterExpression = "STOCKS.STORE=" + ConnectionManager.GuidToString(this._DistributionDocument.Store.ObjectID) + " AND STOCKS.INHELD > 0";

            if (_DistributionDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _DistributionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                if (_DistributionDocument.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_DistributionDocument.Store).GoodsAccountant;

                stockActionSignDetail = _DistributionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSorumlusu;
                if (_DistributionDocument.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_DistributionDocument.Store).GoodsResponsible;

                stockActionSignDetail = _DistributionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                if (_DistributionDocument.Store is MainStoreDefinition)
                {
                    ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                    if (user.SelectedSecMasterResource != null && user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                        stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                }

                stockActionSignDetail = _DistributionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.DepoSorumlusu;
                if (_DistributionDocument.DestinationStore is SubStoreDefinition)
                    stockActionSignDetail.SignUser = ((SubStoreDefinition)_DistributionDocument.DestinationStore).StoreResponsible;
                else if (_DistributionDocument.DestinationStore is PharmacyStoreDefinition)
                    stockActionSignDetail.SignUser = ((PharmacyStoreDefinition)_DistributionDocument.DestinationStore).StoreResponsible;
            }
#endregion PresDistributionDocumentClinicAprovvalForm_PreScript

            }
                }
}