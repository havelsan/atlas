
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductionConsumptionInfirmaryDocumentMaterialIn")] 

    /// <summary>
    /// Sarf İmal İstihsal Belgesi İmal malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class ProductionConsumptionInfirmaryDocumentMaterialIn : StockActionDetailIn
    {
        public class ProductionConsumptionInfirmaryDocumentMaterialInList : TTObjectCollection<ProductionConsumptionInfirmaryDocumentMaterialIn> { }
                    
        public class ChildProductionConsumptionInfirmaryDocumentMaterialInCollection : TTObject.TTChildObjectCollection<ProductionConsumptionInfirmaryDocumentMaterialIn>
        {
            public ChildProductionConsumptionInfirmaryDocumentMaterialInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductionConsumptionInfirmaryDocumentMaterialInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ProductionConsumptionInfirmaryDocumentMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductionConsumptionInfirmaryDocumentMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductionConsumptionInfirmaryDocumentMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductionConsumptionInfirmaryDocumentMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductionConsumptionInfirmaryDocumentMaterialIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTIONCONSUMPTIONINFIRMARYDOCUMENTMATERIALIN", dataRow) { }
        protected ProductionConsumptionInfirmaryDocumentMaterialIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTIONCONSUMPTIONINFIRMARYDOCUMENTMATERIALIN", dataRow, isImported) { }
        public ProductionConsumptionInfirmaryDocumentMaterialIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductionConsumptionInfirmaryDocumentMaterialIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductionConsumptionInfirmaryDocumentMaterialIn() : base() { }

    }
}