
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
    public partial class SubActionMaterialStockOutOperation : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            StockOutStores stockOutStores = new StockOutStores();
            stockOutStores.store = Interface.GetMySubActionMaterial().Store;
            stockOutStores.subActionMaterials.Add(Interface.GetMySubActionMaterial());
            
            //SubStoreDefinition subStoreDefinition = (SubStoreDefinition) stockOutStores.store;//ObjectContext.GetObject(new Guid("00b9ebed-3128-4c74-af29-2e21957a2399"), "SUBSTOREDEFINITION");
            Store store = stockOutStores.store;
            StockOut stockOut = new StockOut(ObjectContext);
            stockOut.CurrentStateDefID = StockOut.States.New;
            // TODO : Burada set edilen depo collectiondan geliyor olması lazım.
            
            stockOut.Store = store;
            stockOut.Update();
            StockActionDetailOut stockActionDetailOut = (StockActionDetailOut)stockOut.StockActionOutDetails.AddNew();
            stockActionDetailOut.Material = Interface.GetMySubActionMaterial().Material;
            stockActionDetailOut.Amount = Interface.GetMySubActionMaterial().Amount;
            StockLevelType stockLevelType = (StockLevelType)ObjectContext.GetObject(new Guid("20576ee2-ac52-4093-b45e-d17df8b48337"),"STOCKLEVELTYPE");
            stockActionDetailOut.StockLevelType = stockLevelType;
            stockOut.CurrentStateDefID = StockOut.States.Completed;
#endregion Body
        }

#region Methods
        public class StockOutStores
        {
            public  IList<SubActionMaterial> subActionMaterials = new List<SubActionMaterial>();
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