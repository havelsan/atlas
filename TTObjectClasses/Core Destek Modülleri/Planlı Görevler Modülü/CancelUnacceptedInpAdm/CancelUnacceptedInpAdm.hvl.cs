
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CancelUnacceptedInpAdm")] 

    public  partial class CancelUnacceptedInpAdm : BaseScheduledTask
    {
        public class CancelUnacceptedInpAdmList : TTObjectCollection<CancelUnacceptedInpAdm> { }
                    
        public class ChildCancelUnacceptedInpAdmCollection : TTObject.TTChildObjectCollection<CancelUnacceptedInpAdm>
        {
            public ChildCancelUnacceptedInpAdmCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCancelUnacceptedInpAdmCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CancelUnacceptedInpAdm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CancelUnacceptedInpAdm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CancelUnacceptedInpAdm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CancelUnacceptedInpAdm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CancelUnacceptedInpAdm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CANCELUNACCEPTEDINPADM", dataRow) { }
        protected CancelUnacceptedInpAdm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CANCELUNACCEPTEDINPADM", dataRow, isImported) { }
        public CancelUnacceptedInpAdm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CancelUnacceptedInpAdm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CancelUnacceptedInpAdm() : base() { }

    }
}