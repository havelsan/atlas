
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresInfirmaryDocMaterialIn")] 

    public  partial class PresInfirmaryDocMaterialIn : StockActionDetailIn
    {
        public class PresInfirmaryDocMaterialInList : TTObjectCollection<PresInfirmaryDocMaterialIn> { }
                    
        public class ChildPresInfirmaryDocMaterialInCollection : TTObject.TTChildObjectCollection<PresInfirmaryDocMaterialIn>
        {
            public ChildPresInfirmaryDocMaterialInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresInfirmaryDocMaterialInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PresInfirmaryDocument PresInfirmaryDocument
        {
            get 
            {   
                if (StockAction is PresInfirmaryDocument)
                    return (PresInfirmaryDocument)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected PresInfirmaryDocMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresInfirmaryDocMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresInfirmaryDocMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresInfirmaryDocMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresInfirmaryDocMaterialIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESINFIRMARYDOCMATERIALIN", dataRow) { }
        protected PresInfirmaryDocMaterialIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESINFIRMARYDOCMATERIALIN", dataRow, isImported) { }
        public PresInfirmaryDocMaterialIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresInfirmaryDocMaterialIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresInfirmaryDocMaterialIn() : base() { }

    }
}