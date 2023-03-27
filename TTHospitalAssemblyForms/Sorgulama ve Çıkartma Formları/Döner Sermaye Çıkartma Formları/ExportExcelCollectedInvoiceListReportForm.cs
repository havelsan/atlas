
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
    public partial class ExportExcelCollectedInvoiceListReport : BaseExportExcelUnboundForm
    {
        override protected void BindControlEvents()
        {
            applyButton.Click += new TTControlEventDelegate(applyButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            applyButton.Click -= new TTControlEventDelegate(applyButton_Click);
            base.UnBindControlEvents();
        }

        private void applyButton_Click()
        {
#region ExportExcelCollectedInvoiceListReport_applyButton_Click
   try
            {
                string actionID = baseActionIDTextBox.Text;
                if (string.IsNullOrEmpty(actionID))
                    throw new Exception("Toplu Fatura İşlem Numarası boş olamaz.");

                if (TTUtils.Globals.IsNumeric(actionID) == false)
                    throw new Exception("Toplu Fatura İşlem Numarası sayısal olmalıdır.");

                TTObjectContext readOnlyObjectContext = new TTObjectContext(true);
                BindingList<BaseAction> baseActions = readOnlyObjectContext.QueryObjects<BaseAction>("ID = " + actionID);
                if (baseActions.Count <= 0)
                    throw new Exception(actionID + " numaralı işlem bulunamamıştır.");

                BaseAction baseAction = baseActions[0];
                _exportParameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                cache.Add("VALUE", baseAction.ObjectID.ToString());

                _exportParameters.Add("TTOBJECTID", cache);
                
                exportButton.ReadOnly = false;
                
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion ExportExcelCollectedInvoiceListReport_applyButton_Click
        }

#region ExportExcelCollectedInvoiceListReport_Methods
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            _exportReportType = typeof(TTReportClasses.I_CollectedInvoiceListReport_SE);
        }
        
#endregion ExportExcelCollectedInvoiceListReport_Methods
    }
}