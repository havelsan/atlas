
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
    /// Ana Depodan Sarf İmal İstihsal Belgesi 
    /// </summary>
    public partial class MainStoreProductionConsumptionDocumentForm : BaseMainStoreProductionConsumptionDocument
    {
        protected override void PreScript()
        {
#region MainStoreProductionConsumptionDocumentForm_PreScript
    base.PreScript();
            
            if(this._MainStoreProductionConsumptionDocument.CurrentStateDefID==MainStoreProductionConsumptionDocument.States.New)
                ((ITTListBoxColumn)((ITTGridColumn)this.StockActionOutDetails.Columns["Material"])).ListFilterExpression ="STOCKS.STORE='"+this._MainStoreProductionConsumptionDocument.Store.ObjectID.ToString()+"' AND STOCKCARD.MAINSTORECHECKBOX=1 AND STOCKS.INHELD>0" ;
#endregion MainStoreProductionConsumptionDocumentForm_PreScript

            }
                }
}