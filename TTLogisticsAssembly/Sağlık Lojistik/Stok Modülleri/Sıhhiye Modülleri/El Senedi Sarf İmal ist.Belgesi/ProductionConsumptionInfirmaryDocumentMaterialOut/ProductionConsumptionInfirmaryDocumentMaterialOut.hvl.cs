
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductionConsumptionInfirmaryDocumentMaterialOut")] 

    /// <summary>
    /// Sarf İmal İstihsal Belgesi Sarf malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class ProductionConsumptionInfirmaryDocumentMaterialOut : StockActionDetailOut
    {
        public class ProductionConsumptionInfirmaryDocumentMaterialOutList : TTObjectCollection<ProductionConsumptionInfirmaryDocumentMaterialOut> { }
                    
        public class ChildProductionConsumptionInfirmaryDocumentMaterialOutCollection : TTObject.TTChildObjectCollection<ProductionConsumptionInfirmaryDocumentMaterialOut>
        {
            public ChildProductionConsumptionInfirmaryDocumentMaterialOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductionConsumptionInfirmaryDocumentMaterialOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Mevcut
    /// </summary>
        public double? Existing
        {
            get { return (double?)this["EXISTING"]; }
            set { this["EXISTING"] = value; }
        }

        protected ProductionConsumptionInfirmaryDocumentMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductionConsumptionInfirmaryDocumentMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductionConsumptionInfirmaryDocumentMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductionConsumptionInfirmaryDocumentMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductionConsumptionInfirmaryDocumentMaterialOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTIONCONSUMPTIONINFIRMARYDOCUMENTMATERIALOUT", dataRow) { }
        protected ProductionConsumptionInfirmaryDocumentMaterialOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTIONCONSUMPTIONINFIRMARYDOCUMENTMATERIALOUT", dataRow, isImported) { }
        public ProductionConsumptionInfirmaryDocumentMaterialOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductionConsumptionInfirmaryDocumentMaterialOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductionConsumptionInfirmaryDocumentMaterialOut() : base() { }

    }
}