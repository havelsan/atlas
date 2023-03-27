
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
    /// İstek Detayları
    /// </summary>
    public partial class ARDDetailForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdRefresh.Click += new TTControlEventDelegate(cmdRefresh_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdRefresh.Click -= new TTControlEventDelegate(cmdRefresh_Click);
            base.UnBindControlEvents();
        }

        private void cmdRefresh_Click()
        {
#region ARDDetailForm_cmdRefresh_Click
   foreach(ARD_AccountancyAmount ard in _AnnualRequirementDetail.ARD_AccountancyAmounts)
            {
                //if (ard.SurplusAmount == null)
                //{
                //    BasePurchaseAction.AccountancySurplusInfo accountancySurplusInfo = new BasePurchaseAction.AccountancySurplusInfo();
                //    accountancySurplusInfo = PurchaseItemDef.RemoteMethods.GetPurchaseItemAccountancySurplusAmounts(ard.Accountancy.AccountancyMilitaryUnit.Site.ObjectID, _AnnualRequirementDetail.PurchaseItemDef.ObjectID, ard.Accountancy.ObjectID);
                //    ard.SurplusAmount = accountancySurplusInfo.SurPlusAmount;
                //}

                //if (ard.Amount == null)
                //{
                //    BasePurchaseAction.AccountancyInheldInfo accountancyInheldInfo = new BasePurchaseAction.AccountancyInheldInfo();
                //    accountancyInheldInfo = PurchaseItemDef.RemoteMethods.GetPurchaseItemAccountancyAmounts(ard.Accountancy.AccountancyMilitaryUnit.Site.ObjectID, _AnnualRequirementDetail.PurchaseItemDef.ObjectID, ard.Accountancy.ObjectID);
                //    ard.Amount = accountancyInheldInfo.Inheld;
                //}
            }
#endregion ARDDetailForm_cmdRefresh_Click
        }

        protected override void PreScript()
        {
#region ARDDetailForm_PreScript
    base.PreScript();
            
            this.DropStateButton(AnnualRequirementDetail.States.Cancelled);
            this.DropStateButton(AnnualRequirementDetail.States.Completed);

            BindingList<ARD_AccountancyAmount> list = _AnnualRequirementDetail.ARD_AccountancyAmounts.Select(null);
            if (list.Count > 0)
                return;
            
            List<Accountancy> accList = Accountancy.GetAllXXXXXXAccountancies();
            foreach(Accountancy acc in accList)
            {
                ARD_AccountancyAmount accAmount = new ARD_AccountancyAmount(_AnnualRequirementDetail.ObjectContext);
                accAmount.AnnualRequirementDetail = _AnnualRequirementDetail;
                accAmount.Accountancy = acc;
            }
#endregion ARDDetailForm_PreScript

            }
                }
}