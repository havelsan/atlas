
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
    /// Depodan Sarf İşlemi (Reçeteler İçin)
    /// </summary>
    public  partial class ResSubStoreConsumption : StockAction, IBasePrescriptionTransaction, ICheckStockActionOutDetail, IStockOutTransaction
    {
        protected void PreTransition_Approval2Cancelled()
        {
            // From State : Approval   To State : Cancelled
#region PreTransition_Approval2Cancelled
            

            foreach (ResSubStoreConsumptionDetail resSubStoreConsumptionDetail in ResSubStoreConsumptionDetails)
                resSubStoreConsumptionDetail.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_Approval2Cancelled
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            

            foreach (ResSubStoreConsumptionDetail resSubStoreConsumptionDetail in ResSubStoreConsumptionDetails)
                resSubStoreConsumptionDetail.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ResSubStoreConsumption).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ResSubStoreConsumption.States.Approval && toState == ResSubStoreConsumption.States.Cancelled)
                PreTransition_Approval2Cancelled();
            else if (fromState == ResSubStoreConsumption.States.Completed && toState == ResSubStoreConsumption.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }
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
        #endregion
    }
}