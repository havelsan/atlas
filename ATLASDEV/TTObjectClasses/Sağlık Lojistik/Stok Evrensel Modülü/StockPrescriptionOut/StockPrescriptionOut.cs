
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
    /// Reçete Çıkış
    /// </summary>
    public  partial class StockPrescriptionOut : StockAction, IStockOutTransaction, IBasePrescriptionTransaction
    {
        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            

            foreach (StockPrescriptionOutMat stockPrescriptionOutMat in StockPrescriptionOutMaterials)
                stockPrescriptionOutMat.Status = StockActionDetailStatusEnum.Cancelled;
                

#endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockPrescriptionOut).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StockPrescriptionOut.States.Completed && toState == StockPrescriptionOut.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }
        #region Methods
        #region IStockOutTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }

        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        #endregion

    }
}