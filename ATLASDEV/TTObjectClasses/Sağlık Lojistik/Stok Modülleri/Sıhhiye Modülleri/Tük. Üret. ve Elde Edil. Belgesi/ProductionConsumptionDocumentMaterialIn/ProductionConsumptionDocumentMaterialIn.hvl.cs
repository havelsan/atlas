
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductionConsumptionDocumentMaterialIn")] 

    /// <summary>
    /// Sarf İmal İstihsal Belgesi İmal Edilen malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class ProductionConsumptionDocumentMaterialIn : StockActionDetailIn
    {
        public class ProductionConsumptionDocumentMaterialInList : TTObjectCollection<ProductionConsumptionDocumentMaterialIn> { }
                    
        public class ChildProductionConsumptionDocumentMaterialInCollection : TTObject.TTChildObjectCollection<ProductionConsumptionDocumentMaterialIn>
        {
            public ChildProductionConsumptionDocumentMaterialInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductionConsumptionDocumentMaterialInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ProductionConsumptionDocumentMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductionConsumptionDocumentMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductionConsumptionDocumentMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductionConsumptionDocumentMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductionConsumptionDocumentMaterialIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTIONCONSUMPTIONDOCUMENTMATERIALIN", dataRow) { }
        protected ProductionConsumptionDocumentMaterialIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTIONCONSUMPTIONDOCUMENTMATERIALIN", dataRow, isImported) { }
        public ProductionConsumptionDocumentMaterialIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductionConsumptionDocumentMaterialIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductionConsumptionDocumentMaterialIn() : base() { }

    }
}