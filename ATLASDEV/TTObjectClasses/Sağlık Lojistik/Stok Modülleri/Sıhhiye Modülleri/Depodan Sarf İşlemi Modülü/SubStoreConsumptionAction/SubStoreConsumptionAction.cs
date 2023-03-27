
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
    /// Depodan Sarf İşlemi için kullanılan temel sınıftır
    /// </summary>
    public partial class SubStoreConsumptionAction : StockAction, IStockOutTransaction, ICheckStockActionOutDetail
    {
        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
            #region PreTransition_New2Approval

            if (Store is DependentStoreDefinition)
            {
                if (((DependentStoreDefinition)Store).Site != null)
                {
                    throw new TTException(SystemMessage.GetMessage(1130));
                }
            }

            #endregion PreTransition_New2Approval
        }
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
            #region PreTransition_New2Completed
            CheckStockActionOutDetails();
            #endregion PreTransition_New2Completed
        }
        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SubStoreConsumptionAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SubStoreConsumptionAction.States.New && toState == SubStoreConsumptionAction.States.Approval)
                PreTransition_New2Approval();
            if (fromState == SubStoreConsumptionAction.States.New && toState == SubStoreConsumptionAction.States.Completed)
                PreTransition_New2Completed();
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