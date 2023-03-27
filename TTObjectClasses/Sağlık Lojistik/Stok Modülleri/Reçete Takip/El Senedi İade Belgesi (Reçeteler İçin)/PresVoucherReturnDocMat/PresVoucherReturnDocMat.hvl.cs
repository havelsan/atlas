
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresVoucherReturnDocMat")] 

    public  partial class PresVoucherReturnDocMat : VoucherReturnDocumentMaterial
    {
        public class PresVoucherReturnDocMatList : TTObjectCollection<PresVoucherReturnDocMat> { }
                    
        public class ChildPresVoucherReturnDocMatCollection : TTObject.TTChildObjectCollection<PresVoucherReturnDocMat>
        {
            public ChildPresVoucherReturnDocMatCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresVoucherReturnDocMatCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public VoucherReturnDocument VoucherReturnDocument
        {
            get 
            {   
                if (StockAction is VoucherReturnDocument)
                    return (VoucherReturnDocument)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected PresVoucherReturnDocMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresVoucherReturnDocMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresVoucherReturnDocMat(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresVoucherReturnDocMat(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresVoucherReturnDocMat(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESVOUCHERRETURNDOCMAT", dataRow) { }
        protected PresVoucherReturnDocMat(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESVOUCHERRETURNDOCMAT", dataRow, isImported) { }
        public PresVoucherReturnDocMat(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresVoucherReturnDocMat(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresVoucherReturnDocMat() : base() { }

    }
}