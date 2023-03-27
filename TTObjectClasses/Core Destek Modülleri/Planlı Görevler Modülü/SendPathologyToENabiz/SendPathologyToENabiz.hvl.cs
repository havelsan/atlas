
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendPathologyToENabiz")] 

    public  partial class SendPathologyToENabiz : BaseScheduledTask
    {
        public class SendPathologyToENabizList : TTObjectCollection<SendPathologyToENabiz> { }
                    
        public class ChildSendPathologyToENabizCollection : TTObject.TTChildObjectCollection<SendPathologyToENabiz>
        {
            public ChildSendPathologyToENabizCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendPathologyToENabizCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendPathologyToENabiz(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendPathologyToENabiz(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendPathologyToENabiz(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendPathologyToENabiz(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendPathologyToENabiz(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDPATHOLOGYTOENABIZ", dataRow) { }
        protected SendPathologyToENabiz(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDPATHOLOGYTOENABIZ", dataRow, isImported) { }
        public SendPathologyToENabiz(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendPathologyToENabiz(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendPathologyToENabiz() : base() { }

    }
}