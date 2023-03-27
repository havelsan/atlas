
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
    /// İade Belgesi
    /// </summary>
    public partial class ReturningDocumentApprovalForm : BaseReturningDocumentForm
    {
        protected override void PreScript()
        {
            #region ReturningDocumentApprovalForm_PreScript
            base.PreScript();
            foreach (ReturningDocumentMaterial returningDocumentMaterial in _ReturningDocument.ReturningDocumentMaterials)
            {

                if (returningDocumentMaterial.Amount == null || returningDocumentMaterial.Amount == 0 || returningDocumentMaterial.Amount != returningDocumentMaterial.RequireAmount)
                    returningDocumentMaterial.Amount = returningDocumentMaterial.RequireAmount;
            }
            if (_ReturningDocument.CurrentStateDefID == ReturningDocument.States.Approval)
            {
                if (_ReturningDocument.ReturnDepStoreObjectID != null)
                {
                    this.DropStateButton(ReturningDocument.States.New);
                    this.DropStateButton(ReturningDocument.States.Cancelled);
                }
            }

            if (_ReturningDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _ReturningDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden;
                if (_ReturningDocument.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_ReturningDocument.Store).GoodsAccountant;

                stockActionSignDetail = _ReturningDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
                if (_ReturningDocument.DestinationStore is SubStoreDefinition)
                    stockActionSignDetail.SignUser = ((SubStoreDefinition)_ReturningDocument.DestinationStore).StoreResponsible;
            }

            _ReturningDocument.SendMYKSProperties();
            #endregion ReturningDocumentApprovalForm_PreScript

        }

        #region ChattelDocumentInputWithAccountancyApproveForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == ReturningDocument.States.Completed)
                {
                   
                    _ReturningDocument.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                }
            }

        }

        #endregion ChattelDocumentInputWithAccountancyApproveForm_Methods
    }
}