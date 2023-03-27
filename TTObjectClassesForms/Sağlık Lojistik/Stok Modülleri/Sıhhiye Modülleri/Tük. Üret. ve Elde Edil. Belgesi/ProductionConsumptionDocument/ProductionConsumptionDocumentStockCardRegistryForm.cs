
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
    /// Tüketim, Üretim ve Elde Edilenler Belgesi
    /// </summary>
    public partial class ProductionConsumptionDocumentStockCardRegistryForm : BaseProductionConsumptionDocumentForm
    {
        protected override void PreScript()
        {
#region ProductionConsumptionDocumentStockCardRegistryForm_PreScript
    base.PreScript();
            if (_ProductionConsumptionDocument.ProductionDepStoreObjectID != null)
            {
                this.DropStateButton (ProductionConsumptionDocument.States.New);
                this.DropStateButton (ProductionConsumptionDocument.States.Cancelled);
            }
#endregion ProductionConsumptionDocumentStockCardRegistryForm_PreScript

            }
            
#region ProductionConsumptionDocumentStockCardRegistryForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null && transDef.ToStateDefID == ProductionConsumptionDocument.States.Completed)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _ProductionConsumptionDocument.ObjectID.ToString());
                parameter.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_ProductionConsumptionDocumentReport), true, 1, parameter);
            }

        }
        
#endregion ProductionConsumptionDocumentStockCardRegistryForm_Methods
    }
}