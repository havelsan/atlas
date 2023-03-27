
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainStoreProductionConsumptionDocumentMaterial")] 

    /// <summary>
    /// Ana Depodan Sarf İmal İstihsal Belgesinde malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class MainStoreProductionConsumptionDocumentMaterial : StockActionDetailOut
    {
        public class MainStoreProductionConsumptionDocumentMaterialList : TTObjectCollection<MainStoreProductionConsumptionDocumentMaterial> { }
                    
        public class ChildMainStoreProductionConsumptionDocumentMaterialCollection : TTObject.TTChildObjectCollection<MainStoreProductionConsumptionDocumentMaterial>
        {
            public ChildMainStoreProductionConsumptionDocumentMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainStoreProductionConsumptionDocumentMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Mevcut
    /// </summary>
        public double? Existing
        {
            get { return (double?)this["EXISTING"]; }
            set { this["EXISTING"] = value; }
        }

        protected MainStoreProductionConsumptionDocumentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainStoreProductionConsumptionDocumentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainStoreProductionConsumptionDocumentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainStoreProductionConsumptionDocumentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainStoreProductionConsumptionDocumentMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINSTOREPRODUCTIONCONSUMPTIONDOCUMENTMATERIAL", dataRow) { }
        protected MainStoreProductionConsumptionDocumentMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINSTOREPRODUCTIONCONSUMPTIONDOCUMENTMATERIAL", dataRow, isImported) { }
        public MainStoreProductionConsumptionDocumentMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainStoreProductionConsumptionDocumentMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainStoreProductionConsumptionDocumentMaterial() : base() { }

    }
}