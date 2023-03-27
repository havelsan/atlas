
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
    /// Sayman Onayı
    /// </summary>
    public partial class DistributionDocumentApprovalForm : BaseDistributionDocumentForm
    {
        protected override void PreScript()
        {
            #region DistributionDocumentApprovalForm_PreScript
            base.PreScript();
            if (_DistributionDocument.DistributionDepStoreObjectID != null)
            {
                this.DropStateButton(DistributionDocument.States.New);
                this.DropStateButton(DistributionDocument.States.Cancelled);
            }
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

            foreach (ITTGridRow stockActionOutDetailRow in DistributionDocumentMaterials.Rows)
                if (stockActionOutDetailRow.Cells[MaterialDistributionDocumentMaterial.Name].Value != null)
                    stockActionOutDetailRow.Cells[AmountDistributionDocumentMaterial.Name].Value = stockActionOutDetailRow.Cells[AcceptedAmountDistributionDocumentMaterial.Name].Value;


            if ((bool)this._DistributionDocument.IsAutoDistribution)
                this.DistributionDocumentMaterials.AllowUserToAddRows = false;

            
            #endregion DistributionDocumentApprovalForm_PreScript

        }
        #region DistributionDocumentApprovalForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == DistributionDocument.States.Completed)
                {
                 

                    _DistributionDocument.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                }
            }

        }

        #endregion DistributionDocumentApprovalForm_Methods
    }
}