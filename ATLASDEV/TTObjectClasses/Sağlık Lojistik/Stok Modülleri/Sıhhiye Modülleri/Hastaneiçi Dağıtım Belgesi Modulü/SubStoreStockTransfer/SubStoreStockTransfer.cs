
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
    /// Depolar Arası Transfer
    /// </summary>
    public  partial class SubStoreStockTransfer : StockAction, IAutoDocumentNumber, ICheckStockActionOutDetail, IDistributionDocument, IStockReservation, IStockTransferTransaction
    {
        #region Methods
        #region ICheckStockActionOutDetail Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #region IStockOutTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        #region IStockTransferTransaction Members
        public void SetDestinationStore(Store value)
        {
            DestinationStore = value;
        }
        #endregion 
        #endregion
    }
}