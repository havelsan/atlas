
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresDistributionDocMaterial")] 

    public  partial class PresDistributionDocMaterial : DistributionDocumentMaterial
    {
        public class PresDistributionDocMaterialList : TTObjectCollection<PresDistributionDocMaterial> { }
                    
        public class ChildPresDistributionDocMaterialCollection : TTObject.TTChildObjectCollection<PresDistributionDocMaterial>
        {
            public ChildPresDistributionDocMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresDistributionDocMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PresDistributionDocument PresDistributionDocument
        {
            get 
            {   
                if (StockAction is PresDistributionDocument)
                    return (PresDistributionDocument)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected PresDistributionDocMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresDistributionDocMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresDistributionDocMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresDistributionDocMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresDistributionDocMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESDISTRIBUTIONDOCMATERIAL", dataRow) { }
        protected PresDistributionDocMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESDISTRIBUTIONDOCMATERIAL", dataRow, isImported) { }
        public PresDistributionDocMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresDistributionDocMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresDistributionDocMaterial() : base() { }

    }
}