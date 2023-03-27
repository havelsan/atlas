
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
    /// Ayıklama İşlemi
    /// </summary>
    public partial class ShellingProcedureForm : BaseShellingProcedureForm
    {
        protected override void PreScript()
        {
#region ShellingProcedureForm_PreScript
    base.PreScript();

            if (this._ShellingProcedure.CurrentStateDefID == ShellingProcedure.States.New)
            {
                ((ITTListBoxColumn)((ITTGridColumn)this.ShellingProcedureOutMaterials.Columns["Material"])).ListFilterExpression = "STOCKS.STORE = " + ConnectionManager.GuidToString(this._ShellingProcedure.Store.ObjectID) + " AND STOCKS.INHELD > 0 AND STOCKS.STOCKLEVELS.STOCKLEVELTYPE = " + ConnectionManager.GuidToString(TTObjectClasses.StockLevelType.HekStockLevel.ObjectID);
                tttabcontrol1.HideTabPage(InMaterialTabpage);
            }
#endregion ShellingProcedureForm_PreScript

            }
                }
}