
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Test_Classes")] 

    public  partial class Test_Classes : Test_Class
    {
        public class Test_ClassesList : TTObjectCollection<Test_Classes> { }
                    
        public class ChildTest_ClassesCollection : TTObject.TTChildObjectCollection<Test_Classes>
        {
            public ChildTest_ClassesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTest_ClassesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected Test_Classes(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Test_Classes(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Test_Classes(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Test_Classes(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Test_Classes(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TEST_CLASSES", dataRow) { }
        protected Test_Classes(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TEST_CLASSES", dataRow, isImported) { }
        protected Test_Classes(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Test_Classes(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Test_Classes() : base() { }

    }
}