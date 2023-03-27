
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
    public partial class DemandStatusQueryForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdQuery.Click += new TTControlEventDelegate(cmdQuery_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdQuery.Click -= new TTControlEventDelegate(cmdQuery_Click);
            base.UnBindControlEvents();
        }

        private void cmdQuery_Click()
        {
#region DemandStatusQueryForm_cmdQuery_Click
   if(string.IsNullOrEmpty(txtDemandNo.Text))
                InfoBox.Show("İstek numarası girmediniz");
            else
            {
                TTObjectContext context = new TTObjectContext(true);
                IList demands = context.QueryObjects(typeof(Demand).Name , "REQUESTNO = '" + txtDemandNo.Text + "'");
                if(demands.Count == 0)
                {
                    InfoBox.Show("Bu istek numarasına sahip bir istek bulunamadı");
                    return;
                }

                Demand demand = (Demand)demands[0];
                foreach(DemandDetail detail in demand.DemandDetails)
                {
                    ITTGridRow addedRow = this.DemandDetails.Rows.Add();
                    addedRow.Cells[PurchaseItemDef.Name].Value = detail.PurchaseItemDef.ItemName;
                    if(detail.PurchaseProjectDetail == null)
                    {
                        addedRow.Cells[Status.Name].Value = "İhale süreci başlamamıştır";
                        continue;
                    }
                    else
                    {
                        if(detail.PurchaseProjectDetail.ContractDetail == null)
                        {
                            addedRow.Cells[Status.Name].Value = "Sözleşmesi yapılmıştır";
                            continue;
                        }
                        else
                        {
                            addedRow.Cells[Status.Name].Value = "İhale sürecindedir";
                            continue;
                        }
                    }
                }
            }
#endregion DemandStatusQueryForm_cmdQuery_Click
        }
    }
}