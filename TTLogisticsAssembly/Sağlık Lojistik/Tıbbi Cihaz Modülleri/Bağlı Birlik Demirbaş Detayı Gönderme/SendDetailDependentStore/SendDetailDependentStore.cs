
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
    /// Bağlı Birlik Demirbaş Detayı Gönderme
    /// </summary>
    public  partial class SendDetailDependentStore : BaseAction, IWorkListBaseAction
    {
        
                    
        protected void PostTransition_New2Create()
        {
            // From State : New   To State : Create
#region PostTransition_New2Create
            
            SendTargetSite();

#endregion PostTransition_New2Create
        }

        protected void PreTransition_Create2Completed()
        {
            // From State : Create   To State : Completed
#region PreTransition_Create2Completed
            
            

            TTObjectContext context = new TTObjectContext(true);
            Dictionary<Guid, double> allStocks = new Dictionary<Guid, double>();
            Queue<FixedAssetMaterialDefinition> famdQueue = new Queue<FixedAssetMaterialDefinition>();
            double requestAmount = 0;
            foreach (Stock stock in FixedAssetDefinition.Stocks.Select("INHELD > 0"))
            {
                double count = FixedAssetDefinition.FixedAssetMaterialDefinitions.Select("STOCK =" + ConnectionManager.GuidToString(stock.ObjectID)).Count;
                if (stock.Inheld > count)
                {
                    allStocks.Add(stock.ObjectID, (double)stock.Inheld - count );
                    requestAmount = requestAmount + ((double)stock.Inheld - count);
                }
            }
            IList term = context.QueryObjects("ACCOUNTINGTERM", "STATUS =1");
            Accountancy accountancy = null;
            if (term.Count > 0)
            {
               accountancy = ((AccountingTerm)term[0]).Accountancy;
            }
            else
            {
                throw new TTException(TTUtils.CultureService.GetText("M25102", "Açık hesap dönemi bulunamadı"));
            }
            foreach (FixedAssetMaterialDefinition fixedAssetMaterialDefinition in FixedAssetDefinition.FixedAssetMaterialDefinitions.Select("ACCOUNTANCY =" + ConnectionManager.GuidToString(accountancy.ObjectID) + "AND STOCK IS NULL"))
            {
                famdQueue.Enqueue(fixedAssetMaterialDefinition);
            }
           
            if (requestAmount > famdQueue.Count)
            {
                throw new TTException(TTUtils.CultureService.GetText("M27255", "Yeterli miktarda demirbaş bulunamadı!"));
            }

            foreach (KeyValuePair<Guid, double> stock in allStocks)
            {
                Stock updateStock = (Stock)ObjectContext.GetObject(stock.Key, "STOCK");
                for (int i = 0; i < stock.Value ; i++)
                {
                    FixedAssetMaterialDefinition updateFamd = famdQueue.Dequeue();
                    updateFamd.Stock = updateStock;
                }
            }

#endregion PreTransition_Create2Completed
        }

#region Methods
        public void SendTargetSite()
        {
//            TTObjectContext ctx = new TTObjectContext(false);
//            List<TTObject> list = new List<TTObject>();
//            list.Add(this.FixedAssetDefinition);
//            foreach (SendDetailFixedAsset sendDetailFixedAsset in this.SendDetailFixedAssets)
//            {
//                FixedAssetMaterialDefinition fixedAssetMaterialDefinition = (FixedAssetMaterialDefinition)ctx.GetObject(sendDetailFixedAsset.FixedAssetMaterialDefinition.ObjectID, sendDetailFixedAsset.FixedAssetMaterialDefinition.ObjectDef);
//                fixedAssetMaterialDefinition.Resource = null;
//                fixedAssetMaterialDefinition.Stock = null;
//                list.Add(fixedAssetMaterialDefinition);
//            }
//            ctx.Dispose();
//            Sites site = ((DependentStoreDefinition)this.Store).Site;
//            SendDetailDependentStore.RemoteMethods.CreateSendDetail(site.ObjectID, list);
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SendDetailDependentStore).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SendDetailDependentStore.States.Create && toState == SendDetailDependentStore.States.Completed)
                PreTransition_Create2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SendDetailDependentStore).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SendDetailDependentStore.States.New && toState == SendDetailDependentStore.States.Create)
                PostTransition_New2Create();
        }

    }
}