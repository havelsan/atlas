
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresDelRecDoctDesMatlOut")] 

    public  partial class PresDelRecDoctDesMatlOut : DeleteRecordDocumentDestroyableMaterialOut
    {
        public class PresDelRecDoctDesMatlOutList : TTObjectCollection<PresDelRecDoctDesMatlOut> { }
                    
        public class ChildPresDelRecDoctDesMatlOutCollection : TTObject.TTChildObjectCollection<PresDelRecDoctDesMatlOut>
        {
            public ChildPresDelRecDoctDesMatlOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresDelRecDoctDesMatlOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PresDeleteRecordDocumentDestroyable PresDeleteRecordDocumentDestroyable
        {
            get 
            {   
                if (StockAction is PresDeleteRecordDocumentDestroyable)
                    return (PresDeleteRecordDocumentDestroyable)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected PresDelRecDoctDesMatlOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresDelRecDoctDesMatlOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresDelRecDoctDesMatlOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresDelRecDoctDesMatlOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresDelRecDoctDesMatlOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESDELRECDOCTDESMATLOUT", dataRow) { }
        protected PresDelRecDoctDesMatlOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESDELRECDOCTDESMATLOUT", dataRow, isImported) { }
        public PresDelRecDoctDesMatlOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresDelRecDoctDesMatlOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresDelRecDoctDesMatlOut() : base() { }

    }
}