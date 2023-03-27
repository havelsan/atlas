
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
    /// Depodan Sarf İşlemi (Reçeteler İçin)
    /// </summary>
    public partial class BasePresSubStoreConsumptionForm : StockActionBaseForm
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
#region BasePresSubStoreConsumptionForm_PreScript
    base.PreScript();
            base.PreScript();
            if (this._ResSubStoreConsumption.CurrentStateDefID == ResSubStoreConsumption.States.New)
            {
                string filterExpression = string.Empty;
                if (this._ResSubStoreConsumption.Store != null && this._ResSubStoreConsumption.Store is DependentStoreDefinition)
                    filterExpression = "STOCKS.STORE = " + ConnectionManager.GuidToString(this._ResSubStoreConsumption.Store.ObjectID) + " AND STOCKS.INHELD > 0";
                else
                    filterExpression = "STOCKS.STORE = " + ConnectionManager.GuidToString(this._ResSubStoreConsumption.Store.ObjectID) + " AND STOCKCARD.MAINSTORECHECKBOX = 1 AND STOCKS.INHELD > 0";

                ((ITTListBoxColumn)((ITTGridColumn)this.ResSubStoreConsumptionDetails.Columns["MaterialResSubStoreConsumptionDetail"])).ListFilterExpression = filterExpression;
            }
#endregion BasePresSubStoreConsumptionForm_PreScript

            }
                }
}