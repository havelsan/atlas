
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
    public partial class PresDistributionDocumentApprovalForm : BasePresDistributionDocumentForm
    {
        protected override void PreScript()
        {
#region PresDistributionDocumentApprovalForm_PreScript
    base.PreScript();
            if(_PresDistributionDocument.DistributionDepStoreObjectID != null)
            {
                this.DropStateButton(PresDistributionDocument.States.New);
                this.DropStateButton(PresDistributionDocument.States.Cancelled);
            }
            if (_PresDistributionDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _PresDistributionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                if (_PresDistributionDocument.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_PresDistributionDocument.Store).GoodsAccountant;

                stockActionSignDetail = _PresDistributionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSorumlusu;
                if (_PresDistributionDocument.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_PresDistributionDocument.Store).GoodsResponsible;

                stockActionSignDetail = _PresDistributionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                if (_PresDistributionDocument.Store is MainStoreDefinition)
                {
                    ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                    if (user.SelectedSecMasterResource != null && user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                        stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                }

                stockActionSignDetail = _PresDistributionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.DepoSorumlusu;
                if (_PresDistributionDocument.DestinationStore is SubStoreDefinition)
                    stockActionSignDetail.SignUser = ((SubStoreDefinition)_PresDistributionDocument.DestinationStore).StoreResponsible;
                else if (_PresDistributionDocument.DestinationStore is PharmacyStoreDefinition)
                    stockActionSignDetail.SignUser = ((PharmacyStoreDefinition)_PresDistributionDocument.DestinationStore).StoreResponsible;
            }

            
            foreach (ITTGridRow stockActionOutDetailRow in PresDistributionDocumentMaterials.Rows)
                if (stockActionOutDetailRow.Cells[MaterialPresDistributionDocMaterial.Name].Value != null)
                stockActionOutDetailRow.Cells[AmountPresDistributionDocMaterial.Name].Value = stockActionOutDetailRow.Cells[AcceptedAmountPresDistributionDocMaterial.Name].Value;
#endregion PresDistributionDocumentApprovalForm_PreScript

            }
                }
}