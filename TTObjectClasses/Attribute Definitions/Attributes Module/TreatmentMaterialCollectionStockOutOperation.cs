
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
    public partial class TreatmentMaterialCollectionStockOutOperation : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            Dictionary<Store,StockOutStores> storesDictionary = new Dictionary<Store,StockOutStores>();
            SubStoreDefinition subStoreDefinition=null;
            foreach (BaseTreatmentMaterial baseTreatmentMaterial in Interface.GetTreatmentMaterials())
            {
                if(storesDictionary.ContainsKey(baseTreatmentMaterial.Store) == false )
                {
                    StockOutStores stockOutStores = new StockOutStores();
                    stockOutStores.store = baseTreatmentMaterial.Store;
                    stockOutStores.treatmentMaterials.Add(baseTreatmentMaterial);
                    storesDictionary.Add(baseTreatmentMaterial.Store,stockOutStores);
                    subStoreDefinition = (SubStoreDefinition)stockOutStores.store;
                }

                else
                {
                    StockOutStores stockOutStores = storesDictionary[baseTreatmentMaterial.Store];
                    stockOutStores.treatmentMaterials.Add(baseTreatmentMaterial);
                    subStoreDefinition = (SubStoreDefinition)stockOutStores.store;
                }
            }

            //            SubStoreDefinition subStoreDefinition = (SubStoreDefinition)ObjectContext.GetObject(new Guid("00b9ebed-3128-4c74-af29-2e21957a2399"), "SUBSTOREDEFINITION");
            StockOut stockOut = new StockOut(ObjectContext);
            stockOut.CurrentStateDefID = StockOut.States.New;

            // TODO : Burada set edilen depo collectiondan geliyor olmasy lazym.
            stockOut.Store = subStoreDefinition;
            // TODO : ObjectContext Update in memory birden fazla state için yapylabildi?inde a?a?ydaki yapy ona uygun hale getirilmelidir.
            foreach (KeyValuePair<Store,StockOutStores> stockOutStore in storesDictionary)
            {
                if(stockOut.CurrentStateDefID != StockOut.States.Completed)
                {
                    foreach(BaseTreatmentMaterial treatmentMaterial in stockOutStore.Value.treatmentMaterials)
                    {
                        StockActionDetailOut stockActionDetailOut = (StockActionDetailOut)stockOut.StockActionOutDetails.AddNew();
                        stockActionDetailOut.Material = treatmentMaterial.Material;
                        stockActionDetailOut.Amount   = treatmentMaterial.Amount;
                        StockLevelType stockLevelType = (StockLevelType)ObjectContext.GetObject(new Guid("20576ee2-ac52-4093-b45e-d17df8b48337"),"STOCKLEVELTYPE");
                        stockActionDetailOut.StockLevelType = stockLevelType;
                        stockOut.CurrentStateDefID = StockOut.States.Completed;
                    }
                }
            }
#endregion Body
        }

#region Methods
        public class StockOutStores
        {
           public  IList<BaseTreatmentMaterial> treatmentMaterials = new List<BaseTreatmentMaterial>();
           public  Store store;
        }
#endregion Methods

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}