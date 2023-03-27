
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
    /// Bağlı Birlik İçin Dağıtım Belgesi
    /// </summary>
    public  partial class DistributionDepStore : StockAction, IDistributionDepStore, IStockInTransaction, ICheckStockActionInDetail
    {
        
                    
        protected void PostTransition_New2AccountancyApproval()
        {
            // From State : New   To State : AccountancyApproval
#region PostTransition_New2AccountancyApproval
            
            if (TransDef != null)
            {
                SendDocumentToTargetSite();
            }

#endregion PostTransition_New2AccountancyApproval
        }

#region Methods
        public void SendDocumentToTargetSite()
        {
//            TTObjectContext ctx = new TTObjectContext(true);
//            UnitStoreDefinition unitStore = (UnitStoreDefinition)ctx.GetObject(this.Store.ObjectID, typeof(UnitStoreDefinition));
//            if (unitStore == null)
//                return;

            if ((bool)AccountingTerm.Accountancy.AccountancyMilitaryUnit.IsSupported)
            {
                Guid guid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", ""));
                Sites hsite = (Sites)ObjectContext.GetObject(guid, "SITES");

                List<TTObject> list = new List<TTObject>();
                list.Add(hsite);
                list.Add(((StockAction)this).AccountingTerm.Accountancy);
                list.Add((TTObject)this);
                foreach (DistributionDepStoreMat matDet in DistributionDepStoreMats)
                {
                    list.Add((TTObject)matDet);
                }
                Sites site = (Sites)AccountingTerm.Accountancy.AccountancyMilitaryUnit.Site;
                //DistributionDepStore.RemoteMethods.CreateDistributionDoc(site.ObjectID, list);
            }
        }
        #region IDistributionDepStore Members

        public void GoToUnitApprovalState()
        {
            CurrentStateDefID = DistributionDepStore.States.UnitApproval;
        }
        
        public void GoToCancelState()
        {
            CurrentStateDefID = DistributionDepStore.States.Cancelled;
        }

        #endregion
        #region ICheckStockActionInDetail Members
        public StockActionDetailIn.ChildStockActionDetailInCollection GetStockActionInDetails()
        {
            return StockActionInDetails;
        }
        #endregion 
        #region IStockInTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Store GetStore()
        {
            return Store;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DistributionDepStore).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DistributionDepStore.States.New && toState == DistributionDepStore.States.AccountancyApproval)
                PostTransition_New2AccountancyApproval();
        }


    }
}