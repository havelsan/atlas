
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
    /// Depoya Göre Sayım Emri Belgesi
    /// </summary>
    public partial class BaseCensusOrderByStoreForm : StockActionBaseForm
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
#region BaseCensusOrderByStoreForm_PreScript
    base.PreScript();
            
               if (this._CensusOrderByStore.CurrentStateDef.ObjectDefID == CensusOrderByStore.States.New)
            {
                string filterExpression = string.Empty;
                if (this._CensusOrderByStore.Store != null && this._CensusOrderByStore.Store is  DependentStoreDefinition)
                    filterExpression = "STOCKS.STORE = " + ConnectionManager.GuidToString(this._CensusOrderByStore.Store.ObjectID) + " AND STOCKS.INHELD > 0";
                else
                    filterExpression = "STOCKS.STORE = " + ConnectionManager.GuidToString(this._CensusOrderByStore.Store.ObjectID) + " AND (STOCKS.EXPENDABLE = 1 OR (STOCKS.STOCKEXPENDABLEDETAILS.STARTDATE < GETDATE() AND STOCKS.STOCKEXPENDABLEDETAILS.ENDDATE > GETDATE()))";

                //((ITTListBoxColumn)((ITTGridColumn)this.SubStoreConsumptionActionDetails.Columns["Material"])).ListFilterExpression = filterExpression;
            }
#endregion BaseCensusOrderByStoreForm_PreScript

            }
                }
}