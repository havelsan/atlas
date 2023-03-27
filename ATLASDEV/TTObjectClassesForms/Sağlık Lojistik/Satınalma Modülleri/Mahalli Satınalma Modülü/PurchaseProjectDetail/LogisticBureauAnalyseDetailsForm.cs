
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
    /// Lojistik İnceleme
    /// </summary>
    public partial class LogisticBureauAnalyseDetails : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdRefresh.Click += new TTControlEventDelegate(cmdRefresh_Click);
            ApproveDetailsGrid.CellValueChanged += new TTGridCellEventDelegate(ApproveDetailsGrid_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdRefresh.Click -= new TTControlEventDelegate(cmdRefresh_Click);
            ApproveDetailsGrid.CellValueChanged -= new TTGridCellEventDelegate(ApproveDetailsGrid_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void cmdRefresh_Click()
        {
#region LogisticBureauAnalyseDetails_cmdRefresh_Click
   _PurchaseProjectDetail.CheckRemoteAnswers();
#endregion LogisticBureauAnalyseDetails_cmdRefresh_Click
        }

        private void ApproveDetailsGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region LogisticBureauAnalyseDetails_ApproveDetailsGrid_CellValueChanged
   if (ApproveDetailsGrid.CurrentCell.OwningColumn.Name == "Amount" || ApproveDetailsGrid.CurrentCell.OwningColumn.Name == "ApproveType")
            {
                _PurchaseProjectDetail.CalculateApproveDetails();
                RestAmount.Text = (Convert.ToDouble(DemandedAmount.Text) - (Convert.ToDouble(ApprovedAmount.Text) + Convert.ToDouble(CancelledAmount.Text))).ToString();
            }
#endregion LogisticBureauAnalyseDetails_ApproveDetailsGrid_CellValueChanged
        }

        protected override void PreScript()
        {
#region LogisticBureauAnalyseDetails_PreScript
    //TODO:Saymanlık mevcutlarının ve ihtiyaç fazlalarının görülebilmesi.
            
            this.DropStateButton(PurchaseProjectDetail.States.Cancelled);
#endregion LogisticBureauAnalyseDetails_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region LogisticBureauAnalyseDetails_PostScript
    base.PostScript(transDef);
            
            _PurchaseProjectDetail.CheckDetailAmounts();
#endregion LogisticBureauAnalyseDetails_PostScript

            }
                }
}