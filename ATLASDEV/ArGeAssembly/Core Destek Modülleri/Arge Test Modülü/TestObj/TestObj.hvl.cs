
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TestObj")] 

    public  partial class TestObj : TTObject
    {
        public class TestObjList : TTObjectCollection<TestObj> { }
                    
        public class ChildTestObjCollection : TTObject.TTChildObjectCollection<TestObj>
        {
            public ChildTestObjCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTestObjCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string EMAIL
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

        public string PHONE
        {
            get { return (string)this["PHONE"]; }
            set { this["PHONE"] = value; }
        }

        public int? ID
        {
            get { return (int?)this["ID"]; }
            set { this["ID"] = value; }
        }

        public string NAME
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected TestObj(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TestObj(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TestObj(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TestObj(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TestObj(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TESTOBJ", dataRow) { }
        protected TestObj(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TESTOBJ", dataRow, isImported) { }
        public TestObj(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TestObj(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TestObj() : base() { }

    }
}