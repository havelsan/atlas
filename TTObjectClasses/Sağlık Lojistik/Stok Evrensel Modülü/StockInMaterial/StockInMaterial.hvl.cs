
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockInMaterial")] 

    /// <summary>
    /// Stok Girişlerinin Yapılması İçin kullanılan sınıftır
    /// </summary>
    public  partial class StockInMaterial : StockActionDetailIn
    {
        public class StockInMaterialList : TTObjectCollection<StockInMaterial> { }
                    
        public class ChildStockInMaterialCollection : TTObject.TTChildObjectCollection<StockInMaterial>
        {
            public ChildStockInMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockInMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected StockInMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockInMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockInMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockInMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockInMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKINMATERIAL", dataRow) { }
        protected StockInMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKINMATERIAL", dataRow, isImported) { }
        public StockInMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockInMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockInMaterial() : base() { }

    }
}