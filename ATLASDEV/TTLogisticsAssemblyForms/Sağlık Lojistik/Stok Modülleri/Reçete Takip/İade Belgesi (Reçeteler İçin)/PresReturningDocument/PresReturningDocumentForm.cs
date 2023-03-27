
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
    /// İade Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresReturningDocumentForm : BasePresReturningDocumentForm
    {
        protected override void PreScript()
        {
#region PresReturningDocumentForm_PreScript
    base.PreScript();
             
            if (this._PresReturningDocument.CurrentStateDefID == PresReturningDocument.States.New)
                MaterialPresReturningDocMaterial.ListFilterExpression = "STOCKS.STORE= " + ConnectionManager.GuidToString(this._PresReturningDocument.Store.ObjectID) + " AND STOCKS.INHELD > 0";

            if (_PresReturningDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _ReturningDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                if (_PresReturningDocument.DestinationStore is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_PresReturningDocument.DestinationStore).GoodsAccountant;

                stockActionSignDetail = _PresReturningDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSorumlusu;
                if (_PresReturningDocument.DestinationStore is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_PresReturningDocument.DestinationStore).GoodsResponsible;

                stockActionSignDetail = _PresReturningDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                if (_PresReturningDocument.DestinationStore is MainStoreDefinition)
                {
                    ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                    if (user.SelectedSecMasterResource != null && user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                        stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                }

                stockActionSignDetail = _PresReturningDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.DepoSorumlusu;
                if (_ReturningDocument.Store is SubStoreDefinition)
                    stockActionSignDetail.SignUser = ((SubStoreDefinition)_PresReturningDocument.Store).StoreResponsible;
                else if (_ReturningDocument.Store is PharmacyStoreDefinition)
                    stockActionSignDetail.SignUser = ((PharmacyStoreDefinition)_PresReturningDocument.Store).StoreResponsible;
            }
#endregion PresReturningDocumentForm_PreScript

            }
                }
}