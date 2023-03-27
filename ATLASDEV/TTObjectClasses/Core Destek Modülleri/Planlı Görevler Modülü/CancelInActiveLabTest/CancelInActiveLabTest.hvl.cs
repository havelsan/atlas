
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CancelInActiveLabTest")] 

    /// <summary>
    /// 10 günü geçen ve işlem görmemiş testleri iptal eder
    /// </summary>
    public  partial class CancelInActiveLabTest : BaseScheduledTask
    {
        public class CancelInActiveLabTestList : TTObjectCollection<CancelInActiveLabTest> { }
                    
        public class ChildCancelInActiveLabTestCollection : TTObject.TTChildObjectCollection<CancelInActiveLabTest>
        {
            public ChildCancelInActiveLabTestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCancelInActiveLabTestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CancelInActiveLabTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CancelInActiveLabTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CancelInActiveLabTest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CancelInActiveLabTest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CancelInActiveLabTest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CANCELINACTIVELABTEST", dataRow) { }
        protected CancelInActiveLabTest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CANCELINACTIVELABTEST", dataRow, isImported) { }
        public CancelInActiveLabTest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CancelInActiveLabTest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CancelInActiveLabTest() : base() { }

    }
}