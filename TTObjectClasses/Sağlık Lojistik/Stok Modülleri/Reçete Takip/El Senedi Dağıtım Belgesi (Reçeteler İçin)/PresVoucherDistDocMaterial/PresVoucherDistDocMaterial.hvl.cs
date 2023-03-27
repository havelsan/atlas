
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresVoucherDistDocMaterial")] 

    public  partial class PresVoucherDistDocMaterial : VoucherReturnDocumentMaterial
    {
        public class PresVoucherDistDocMaterialList : TTObjectCollection<PresVoucherDistDocMaterial> { }
                    
        public class ChildPresVoucherDistDocMaterialCollection : TTObject.TTChildObjectCollection<PresVoucherDistDocMaterial>
        {
            public ChildPresVoucherDistDocMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresVoucherDistDocMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PresVoucherDistributingDoc PresVoucherDistributingDoc
        {
            get 
            {   
                if (StockAction is PresVoucherDistributingDoc)
                    return (PresVoucherDistributingDoc)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected PresVoucherDistDocMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresVoucherDistDocMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresVoucherDistDocMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresVoucherDistDocMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresVoucherDistDocMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESVOUCHERDISTDOCMATERIAL", dataRow) { }
        protected PresVoucherDistDocMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESVOUCHERDISTDOCMATERIAL", dataRow, isImported) { }
        public PresVoucherDistDocMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresVoucherDistDocMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresVoucherDistDocMaterial() : base() { }

    }
}