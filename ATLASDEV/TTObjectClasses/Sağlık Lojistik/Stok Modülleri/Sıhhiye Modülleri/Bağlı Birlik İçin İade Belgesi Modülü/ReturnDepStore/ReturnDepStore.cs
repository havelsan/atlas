
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
    /// Bağlı Birlik İçin İade Belgesi
    /// </summary>
    public  partial class ReturnDepStore : StockAction, IStockOutTransaction, ICheckStockActionOutDetail, IReturnDepStore
    {
        
                    
        protected void PreTransition_New2AccountancyApproval()
        {
            // From State : New   To State : AccountancyApproval
#region PreTransition_New2AccountancyApproval
            //
//            foreach(ReturnDepStoreMaterial detmat in this.ReturnDepStoreMaterials)
//            {
//                if(detmat.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
//                    throw new TTException(" Seri numaralı demirbaşın detaylarında sorun bulunmaktadır. Bilgi işleme haber veriniz.");
//            }
#endregion PreTransition_New2AccountancyApproval
        }

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

        protected void PreTransition_UnitApproval2Completed()
        {
            // From State : UnitApproval   To State : Completed
#region PreTransition_UnitApproval2Completed
            
            
            foreach(ReturnDepStoreMaterial material in ReturnDepStoreMaterials)
            {
                foreach (FixedAssetOutDetail outdetail in material.FixedAssetOutDetails)
                {
                    outdetail.Accountancy = AccountingTerm.Accountancy;
                }
            }
#endregion PreTransition_UnitApproval2Completed
        }

#region Methods
        #region IReturnDepStore Members

        public void GoToUnitApprovalState()
        {
            CurrentStateDefID = ReturnDepStore.States.UnitApproval;
        }
        
        public void GoToCancelState()
        {
            CurrentStateDefID = ReturnDepStore.States.Cancelled ;
        }


        #endregion
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
        public void SendDocumentToTargetSite()
        {
            TTObjectContext ctx = new TTObjectContext(false);
//            IUnitStoreDefinition unitStore = (IUnitStoreDefinition)ctx.GetObject(this.Store.ObjectID, typeof(IUnitStoreDefinition));
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
                foreach (ReturnDepStoreMaterial matDet in ReturnDepStoreMaterials)
                {
                    foreach (FixedAssetOutDetail fixedAssetDetail in matDet.FixedAssetOutDetails)
                    {
                        list.Add(fixedAssetDetail);
                        FixedAssetMaterialDefinition fixedAssetMaterialDefinition = (FixedAssetMaterialDefinition)ctx.GetObject(fixedAssetDetail.FixedAssetMaterialDefinition.ObjectID, fixedAssetDetail.FixedAssetMaterialDefinition.ObjectDef);
                        fixedAssetMaterialDefinition.Resource = null;
                        fixedAssetMaterialDefinition.Stock = null;
                        list.Add(fixedAssetMaterialDefinition);
                    }
                    
                    foreach(OuttableLot outtableLot in matDet.OuttableLots)
                    {
                        if ((bool)outtableLot.isUse)
                        {
                            list.Add(outtableLot);
                        }
                    }
                    
                    list.Add((TTObject)matDet);
                }

                Sites site = (Sites)AccountingTerm.Accountancy.AccountancyMilitaryUnit.Site;
               // ReturnDepStore.RemoteMethods.CreateReturnDocument(site.ObjectID, list);
            }
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ReturnDepStore).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ReturnDepStore.States.New && toState == ReturnDepStore.States.AccountancyApproval)
                PreTransition_New2AccountancyApproval();
            else if (fromState == ReturnDepStore.States.UnitApproval && toState == ReturnDepStore.States.Completed)
                PreTransition_UnitApproval2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ReturnDepStore).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ReturnDepStore.States.New && toState == ReturnDepStore.States.AccountancyApproval)
                PostTransition_New2AccountancyApproval();
        }


    }
}