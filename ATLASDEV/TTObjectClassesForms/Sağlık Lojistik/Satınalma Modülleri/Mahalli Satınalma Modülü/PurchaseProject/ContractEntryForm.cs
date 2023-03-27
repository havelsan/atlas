
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
    /// Sözleşme Giriş
    /// </summary>
    public partial class ContractEntryForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdPrepareContracts.Click += new TTControlEventDelegate(cmdPrepareContracts_Click);
            Contracts.CellContentClick += new TTGridCellEventDelegate(Contracts_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdPrepareContracts.Click -= new TTControlEventDelegate(cmdPrepareContracts_Click);
            Contracts.CellContentClick -= new TTGridCellEventDelegate(Contracts_CellContentClick);
            base.UnBindControlEvents();
        }

        private void cmdPrepareContracts_Click()
        {
#region ContractEntryForm_cmdPrepareContracts_Click
   //_PurchaseProject.PrepareContracts();
            Contract c = new Contract(_PurchaseProject.ObjectContext);
            c.CurrentStateDefID = Contract.States.Active;
            c.PurchaseProject = _PurchaseProject;
            c.PaymentAccountancy = _PurchaseProject.PaymentAccountancy;
            ContractForm cf = new ContractForm();
            cf.ShowEdit(this.FindForm(), c, true);
#endregion ContractEntryForm_cmdPrepareContracts_Click
        }

        private void Contracts_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ContractEntryForm_Contracts_CellContentClick
   if (Contracts.CurrentCell.OwningColumn == Contracts.Columns[Details.Name])
            {
                Contract c = (Contract)Contracts.CurrentCell.OwningRow.TTObject;
                ContractForm cf = new ContractForm();
                cf.ShowEdit(this.FindForm(), c, true);
            }

            if (Contracts.CurrentCell.OwningColumn == Contracts.Columns[Delete.Name])
            {
                Contract c = (Contract)Contracts.CurrentCell.OwningRow.TTObject;
                c.ContractDetails.DeleteChildren();
                ((ITTObject)c).Delete();
            }
#endregion ContractEntryForm_Contracts_CellContentClick
        }

        protected override void PreScript()
        {
#region ContractEntryForm_PreScript
    base.PreScript();

            if (_PurchaseProject.CurrentStateDefID == PurchaseProject.States.Completed)
                cmdPrepareContracts.Enabled = false;
            else
                cmdPrepareContracts.Enabled = true;
#endregion ContractEntryForm_PreScript

            }
            
#region ContractEntryForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            //            if (transDef != null && transDef.ToStateDefID == PurchaseProject.States.Completed)
            //            {
            //                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            //                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            //                objectID.Add("VALUE", _PurchaseProject.ObjectID.ToString());
            //                parameter.Add("TTOBJECTID", objectID);
            //                if (_PurchaseProject.PurchaseMainType != PurchaseMainTypeEnum.DirectPurchase)
            //                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SozlesmeyeDavet), true, 1, parameter);
            //                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KararBelgesiRaporu), true, 1, parameter);
            //            }
        }
        
#endregion ContractEntryForm_Methods
    }
}