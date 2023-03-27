
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CreatePAForMHRS")] 

    /// <summary>
    /// MHRS Randevuları için otomatik kabul oluşturur
    /// </summary>
    public  partial class CreatePAForMHRS : BaseScheduledTask
    {
        public class CreatePAForMHRSList : TTObjectCollection<CreatePAForMHRS> { }
                    
        public class ChildCreatePAForMHRSCollection : TTObject.TTChildObjectCollection<CreatePAForMHRS>
        {
            public ChildCreatePAForMHRSCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCreatePAForMHRSCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CreatePAForMHRS(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CreatePAForMHRS(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CreatePAForMHRS(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CreatePAForMHRS(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CreatePAForMHRS(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CREATEPAFORMHRS", dataRow) { }
        protected CreatePAForMHRS(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CREATEPAFORMHRS", dataRow, isImported) { }
        public CreatePAForMHRS(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CreatePAForMHRS(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CreatePAForMHRS() : base() { }

    }
}