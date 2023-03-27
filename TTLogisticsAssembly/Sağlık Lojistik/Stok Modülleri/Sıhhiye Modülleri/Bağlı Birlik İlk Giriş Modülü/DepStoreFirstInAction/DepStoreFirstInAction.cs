
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
    /// Bağlı Birlik İlk Giriş İşlemi
    /// </summary>
    public  partial class DepStoreFirstInAction : BaseAction, IWorkListBaseAction
    {
        
                    
        protected void PreTransition_New2SendDependentStore()
        {
            // From State : New   To State : SendDependentStore
#region PreTransition_New2SendDependentStore
            

            bool err = false;
            string errMsg = "\r\n";
            foreach (DepStoreFirstInActionDet detail in DepStoreFirstInActionDetails)
            {
                if (detail.Material is FixedAssetDefinition && detail.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                {
                    if (detail.Amount != detail.DepStoreFixedAssetDetails.Count)
                    {
                        err = true;
                        errMsg += detail.Material.Name + " isimli malzemenin Demirbaş Detayları Eksik. Olması Gereken : " + detail.Amount.ToString() + " Olan : " + detail.DepStoreFixedAssetDetails.Count.ToString() + "\r\n"; 
                    }
                }
            }
            if (err)
            {
                throw new TTException(errMsg);
            }
            

#endregion PreTransition_New2SendDependentStore
        }

        protected void PostTransition_New2SendDependentStore()
        {
            // From State : New   To State : SendDependentStore
#region PostTransition_New2SendDependentStore
            
            SendFirstInTargetSite();

#endregion PostTransition_New2SendDependentStore
        }

#region Methods
        public void SendFirstInTargetSite()
        {
//            TTObjectContext ctx = new TTObjectContext(false);
//            List<TTObject> list = new List<TTObject>();
//            list.Add((TTObject)this);
//            foreach (DepStoreFirstInActionDet depStoreFirstInActionDet in this.DepStoreFirstInActionDetails)
//            {
//                foreach (DepStoreFixedAssetDetail fixedAssetDetail in depStoreFirstInActionDet.DepStoreFixedAssetDetails)
//                {
//                    list.Add(fixedAssetDetail);
//                    FixedAssetMaterialDefinition fixedAssetMaterialDefinition = (FixedAssetMaterialDefinition)ctx.GetObject(fixedAssetDetail.FixedAssetMaterialDefinition.ObjectID,fixedAssetDetail.FixedAssetMaterialDefinition.ObjectDef) ;
//                    fixedAssetMaterialDefinition.Resource = null;
//                    fixedAssetMaterialDefinition.Stock = null;
//                    list.Add(fixedAssetMaterialDefinition);
//                }
//                list.Add((TTObject)depStoreFirstInActionDet);
//            }
//            ctx.Dispose();
//            Sites site = (Sites)this.DependentStore.Site;
//            DepStoreFirstInAction.RemoteMethods.CreateDepStoreFirstIn(site.ObjectID, list);
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DepStoreFirstInAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DepStoreFirstInAction.States.New && toState == DepStoreFirstInAction.States.SendDependentStore)
                PreTransition_New2SendDependentStore();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DepStoreFirstInAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DepStoreFirstInAction.States.New && toState == DepStoreFirstInAction.States.SendDependentStore)
                PostTransition_New2SendDependentStore();
        }

    }
}