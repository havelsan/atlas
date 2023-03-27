
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
    /// Tüketim, Üretim ve Elde Edilenler Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PrescriptionConsumptionDocumentStockCardRegistryForm : BasePrescriptionConsumptionDocumentForm
    {
        protected override void PreScript()
        {
#region PrescriptionConsumptionDocumentStockCardRegistryForm_PreScript
    base.PreScript();
            if (_PrescriptionConsumptionDocument.ProductionDepStoreObjectID != null)
            {
                this.DropStateButton (PrescriptionConsumptionDocument.States.New);
                this.DropStateButton (PrescriptionConsumptionDocument.States.Cancelled);
            }
#endregion PrescriptionConsumptionDocumentStockCardRegistryForm_PreScript

            }
            
#region PrescriptionConsumptionDocumentStockCardRegistryForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null && transDef.ToStateDefID == PrescriptionConsumptionDocument.States.Completed)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _PrescriptionConsumptionDocument.ObjectID.ToString());
                parameter.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_ProductionConsumptionDocumentReport), true, 1, parameter);
            }

        }
        
#endregion PrescriptionConsumptionDocumentStockCardRegistryForm_Methods
    }
}