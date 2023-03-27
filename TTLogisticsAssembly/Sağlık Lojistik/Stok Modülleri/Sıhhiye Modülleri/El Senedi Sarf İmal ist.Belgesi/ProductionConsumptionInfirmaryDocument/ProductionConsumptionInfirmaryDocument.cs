
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// El Senedi Sarf İmal İstihsal Belgesi
    /// </summary>
    public  partial class ProductionConsumptionInfirmaryDocument : StockAction, IStockConsumptionTransaction, IProductionConsumptionInfirmaryDocument
    {
        public partial class GetProductionConsumptionInfirmaryCensusReportQuery_Class : TTReportNqlObject 
        {
        }

        #region Methods
        #region IStockConsumptionTransaction Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        override protected void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew)
            {
                StartDate = new DateTime(TTObjectDefManager.ServerTime.Date.Year, TTObjectDefManager.ServerTime.Date.Month, 1);
                EndDate = StartDate.Value.AddMonths(1).AddDays(-1);
            }
        }
        
#endregion Methods

    }
}