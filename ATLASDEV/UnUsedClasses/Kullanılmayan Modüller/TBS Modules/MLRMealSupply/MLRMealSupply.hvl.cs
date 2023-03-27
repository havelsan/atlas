
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRMealSupply")] 

    /// <summary>
    /// DLR002_Yemek Malzeme
    /// </summary>
    public  partial class MLRMealSupply : TTObject
    {
        public class MLRMealSupplyList : TTObjectCollection<MLRMealSupply> { }
                    
        public class ChildMLRMealSupplyCollection : TTObject.TTChildObjectCollection<MLRMealSupply>
        {
            public ChildMLRMealSupplyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRMealSupplyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Toplam Kalori
    /// </summary>
        public int? TotalSupplyCalorie
        {
            get { return (int?)this["TOTALSUPPLYCALORIE"]; }
            set { this["TOTALSUPPLYCALORIE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public int? AmountOfSupply
        {
            get { return (int?)this["AMOUNTOFSUPPLY"]; }
            set { this["AMOUNTOFSUPPLY"] = value; }
        }

    /// <summary>
    /// Yemek Bileşenleri
    /// </summary>
        public MLRMeal Meal
        {
            get { return (MLRMeal)((ITTObject)this).GetParent("MEAL"); }
            set { this["MEAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yemek Malzeme Malzeme
    /// </summary>
        public MLRSupply Supply
        {
            get { return (MLRSupply)((ITTObject)this).GetParent("SUPPLY"); }
            set { this["SUPPLY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MLRMealSupply(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRMealSupply(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRMealSupply(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRMealSupply(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRMealSupply(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRMEALSUPPLY", dataRow) { }
        protected MLRMealSupply(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRMEALSUPPLY", dataRow, isImported) { }
        public MLRMealSupply(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRMealSupply(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRMealSupply() : base() { }

    }
}