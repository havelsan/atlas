
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Test_Class")] 

    public  partial class Test_Class : TTObject
    {
        public class Test_ClassList : TTObjectCollection<Test_Class> { }
                    
        public class ChildTest_ClassCollection : TTObject.TTChildObjectCollection<Test_Class>
        {
            public ChildTest_ClassCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTest_ClassCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? test
        {
            get { return (int?)this["TEST"]; }
            set { this["TEST"] = value; }
        }

        public string ID
        {
            get { return (string)this["ID"]; }
            set { this["ID"] = value; }
        }

        protected Test_Class(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Test_Class(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Test_Class(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Test_Class(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Test_Class(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TEST_CLASS", dataRow) { }
        protected Test_Class(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TEST_CLASS", dataRow, isImported) { }
        protected Test_Class(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Test_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Test_Class() : base() { }

    }
}