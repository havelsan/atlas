
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FreePrescriptionEntryDet")] 

    public  partial class FreePrescriptionEntryDet : StockActionDetailOut
    {
        public class FreePrescriptionEntryDetList : TTObjectCollection<FreePrescriptionEntryDet> { }
                    
        public class ChildFreePrescriptionEntryDetCollection : TTObject.TTChildObjectCollection<FreePrescriptionEntryDet>
        {
            public ChildFreePrescriptionEntryDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFreePrescriptionEntryDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public FreePrescriptionEntry FreePrescriptionEntry
        {
            get 
            {   
                if (StockAction is FreePrescriptionEntry)
                    return (FreePrescriptionEntry)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected FreePrescriptionEntryDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FreePrescriptionEntryDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FreePrescriptionEntryDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FreePrescriptionEntryDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FreePrescriptionEntryDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FREEPRESCRIPTIONENTRYDET", dataRow) { }
        protected FreePrescriptionEntryDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FREEPRESCRIPTIONENTRYDET", dataRow, isImported) { }
        public FreePrescriptionEntryDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FreePrescriptionEntryDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FreePrescriptionEntryDet() : base() { }

    }
}