
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
    /// E1 Belgesi
    /// </summary>
    public partial class E1Form : TTForm
    {
        override protected void BindControlEvents()
        {
            Store.SelectedObjectChanged += new TTControlEventDelegate(Store_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Store.SelectedObjectChanged -= new TTControlEventDelegate(Store_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void Store_SelectedObjectChanged()
        {
#region E1Form_Store_SelectedObjectChanged
   BindingList<KSchedule> kSchedules = KSchedule.GetKSchedule(_E1.ObjectContext, (DateTime)_E1.StartDate, (DateTime)_E1.EndDate, this.Store.SelectedObjectID.ToString());
            
            if(kSchedules.Count != 0)
            {
                foreach (KSchedule kSchedule in kSchedules)
                {
                    for(int i=0; i<kSchedule.StockActionOutDetails.Count;i++)
                    {
                        E1Material e1Material = new E1Material(_E1.ObjectContext);
                        e1Material.Material = kSchedule.StockActionOutDetails[i].Material;
                        e1Material.Amount =  kSchedule.StockActionOutDetails[i].Amount;
                        e1Material.StockLevelType = ((KScheduleMaterial)kSchedule.StockActionOutDetails[i]).StockLevelType;
                        BindingList<Stock> stocks = Stock.GetStoreMaterial(_E1.ObjectContext, _E1.Store.ObjectID, e1Material.Material.ObjectID);
                        if(stocks.Count > 0)
                        {
                            Stock stock = stocks[0];
                            e1Material.Inheld = stock.Inheld;
                        }
                        if(((KScheduleMaterial)kSchedule.StockActionOutDetails[i]).QuarantinaNO != null)
                        {
                            e1Material.QuarantineNO = ((KScheduleMaterial)kSchedule.StockActionOutDetails[i]).QuarantinaNO.ToString();
                        }
                        _E1.StockActionOutDetails.Add(e1Material);
                    }
                }
            }

            
            //            BindingList<KSchedule> kSchedules = KSchedule.GetKSchedule(_E1.ObjectContext, (DateTime)_E1.StartDate, (DateTime)_E1.EndDate, this.Store.SelectedObjectID.ToString());
            //            TTObjectContext context = new TTObjectContext(true);
//
            //            if(kSchedules.Count != 0)
            //            {
            //                foreach (KSchedule kSchedule in kSchedules)
            //                {
            //                    for(int i=0; i<kSchedule.StockActionOutDetails.Count;i++)
            //                    {
            //                        ITTGridRow newRow = this.StockActionOutDetails.Rows.Add();
            //                        newRow.Cells["Material"].Value = kSchedule.StockActionOutDetails[i].Material.ObjectID;
            //                        newRow.Cells["Amount"].Value =  kSchedule.StockActionOutDetails[i].Amount.ToString();
            //                        BindingList<Stock> stocks = Stock.GetStoreMaterial(_E1.ObjectContext, _E1.Store.ObjectID.ToString(),newRow.Cells["Material"].Value.ToString());
            //                        if(stocks.Count > 0)
            //                        {
            //                            Stock stock = stocks[0];
            //                            newRow.Cells["Inheld"].Value = stock.Inheld;
            //                        }
//
            //                        newRow.Cells["QuarantineNO"].Value = ((KScheduleMaterial)kSchedule.StockActionOutDetails[i]).QuarantinaNO.ToString();
            //                    }
            //                }
            //            }
#endregion E1Form_Store_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region E1Form_PreScript
    base.PreScript();
#endregion E1Form_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region E1Form_ClientSidePreScript
    base.ClientSidePreScript();
            
            if(this._E1.CurrentStateDefID == E1.States.Record)
            {
                E1DateEntryForm dateEntryForm = new E1DateEntryForm();
                DialogResult dialogResult = dateEntryForm.ShowEdit(this, this._E1, true);
                
                if(dialogResult == DialogResult.OK)
                {
                    foreach(StockCollectedTrx stockCollectedTrx in dateEntryForm.stockCollectedTrxList)
                    {
                        E1Material pFound = this.ContainsMaterial(stockCollectedTrx.StockActionDetail.Material);
                        if(pFound != null)
                        {
                            pFound.Amount += stockCollectedTrx.StockActionDetail.Amount;
                        }
                        else
                        {
                            E1Material E1Material = new E1Material(this._E1.ObjectContext);
                            E1Material.Amount = stockCollectedTrx.StockActionDetail.Amount;
                            E1Material.Material = stockCollectedTrx.StockActionDetail.Material;
                            E1Material.StockLevelType = stockCollectedTrx.StockActionDetail.StockLevelType;
                            E1Material.Material.StockCard.DistributionType = stockCollectedTrx.StockActionDetail.Material.StockCard.DistributionType;
                            
                            this._E1.StockActionOutDetails.Add(E1Material);
                        }
                    }
                }
            }
            
            E1 e1 = _E1;
            ITTObject ttObject = (ITTObject)e1;

            TTDateTimePicker startDate, endDate;
            if (ttObject.IsNew)
            {
                startDate = ((TTDateTimePicker)this.StartDate);
                startDate.Enabled = false;
                endDate = ((TTDateTimePicker)this.EndDate);
                endDate.Enabled = false;
            }

            
            
            if(this._E1.CurrentStateDefID == E1.States.Record)
            {
                this.TransactionDate.Enabled = false;
                this.StartDate.Enabled = false;
                this.EndDate.Enabled = false;
                //  this.Store.Enabled = false;
            }
            else  if(this._E1.CurrentStateDefID == E1.States.Approved)
            {
                this.TransactionDate.Enabled = false;
                this.StartDate.Enabled = false;
                this.EndDate.Enabled = false;
                //this.Store.Enabled = false;
                
                for (int i=0; i<=StockActionOutDetails.Rows.Count-1; i++)
                {
                    StockActionOutDetails.Rows[i].Cells["Material"].ReadOnly = true;
                    StockActionOutDetails.Rows[i].Cells["Amount"].ReadOnly = true;
                    StockActionOutDetails.Rows[i].Cells["Inheld"].ReadOnly = true;
                    StockActionOutDetails.Rows[i].Cells["QuarantineNO"].ReadOnly = true;
                }
            }
#endregion E1Form_ClientSidePreScript

        }

#region E1Form_Methods
        private E1Material ContainsMaterial(Material pMat)
        {
            E1Material pRetVal = null;
            foreach(E1Material pOut in this._E1.StockActionOutDetails)
            {
                if(pOut.Material.ObjectID == pMat.ObjectID)
                {
                    pRetVal = pOut;
                    break;
                }
            }
            return pRetVal;
        }
        
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            
            if(transDef != null && transDef.ToStateDefID == E1.States.Completed)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> selectedDate = new TTReportTool.PropertyCache<object>();
                selectedDate.Add("VALUE", DateTime.Now);
                parameter.Add("DATE", selectedDate);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_E1Report), true, 1, parameter);
            }
        }
        
#endregion E1Form_Methods
    }
}