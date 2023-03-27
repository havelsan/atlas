
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
    /// Teklifler
    /// </summary>
    public partial class ProposalForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region ProposalForm_PreScript
    //            for (int i = 0; i < PurchaseItemProposalsGrid.Rows.Count - 1; i++)
//            {
//                (((ITTListDefComboBoxColumn)(ITTGridColumn)PurchaseItemProposalsGrid.Columns["TradeName"])).ListFilterExpression = "PURCHASEITEMDEF = " + PurchaseItemProposalsGrid.Columns["PurchaseItem"]
//            }
#endregion ProposalForm_PreScript

            }
                }
}