
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresReturningDocMaterial")] 

    public  partial class PresReturningDocMaterial : ReturningDocumentMaterial
    {
        public class PresReturningDocMaterialList : TTObjectCollection<PresReturningDocMaterial> { }
                    
        public class ChildPresReturningDocMaterialCollection : TTObject.TTChildObjectCollection<PresReturningDocMaterial>
        {
            public ChildPresReturningDocMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresReturningDocMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PresReturningDocument PresReturningDocument
        {
            get 
            {   
                if (StockAction is PresReturningDocument)
                    return (PresReturningDocument)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected PresReturningDocMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresReturningDocMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresReturningDocMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresReturningDocMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresReturningDocMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESRETURNINGDOCMATERIAL", dataRow) { }
        protected PresReturningDocMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESRETURNINGDOCMATERIAL", dataRow, isImported) { }
        public PresReturningDocMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresReturningDocMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresReturningDocMaterial() : base() { }

    }
}