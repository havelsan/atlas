
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StoreConsumption")] 

    /// <summary>
    /// Depodan Sarf bilgileri için kullanılan sınıftır
    /// </summary>
    public  abstract  partial class StoreConsumption : StockOut
    {
        public class StoreConsumptionList : TTObjectCollection<StoreConsumption> { }
                    
        public class ChildStoreConsumptionCollection : TTObject.TTChildObjectCollection<StoreConsumption>
        {
            public ChildStoreConsumptionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStoreConsumptionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("c50d4cfb-c8e6-4384-a295-34915fac03d0"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("233e7cb1-4ca2-45dd-99d3-995b946dc78a"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("a7f5e22a-ff1c-40b5-a2d1-d65328cb6a9e"); } }
        }

        protected StoreConsumption(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StoreConsumption(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StoreConsumption(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StoreConsumption(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StoreConsumption(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STORECONSUMPTION", dataRow) { }
        protected StoreConsumption(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STORECONSUMPTION", dataRow, isImported) { }
        public StoreConsumption(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StoreConsumption(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StoreConsumption() : base() { }

    }
}