
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TestObject")] 

    /// <summary>
    /// .
    /// </summary>
    public  partial class TestObject : TTObject
    {
        public class TestObjectList : TTObjectCollection<TestObject> { }
                    
        public class ChildTestObjectCollection : TTObject.TTChildObjectCollection<TestObject>
        {
            public ChildTestObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTestObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Name Of Object
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public int? Telephone
        {
            get { return (int?)this["TELEPHONE"]; }
            set { this["TELEPHONE"] = value; }
        }

    /// <summary>
    /// Address Of Object
    /// </summary>
        public string Address
        {
            get { return (string)this["ADDRESS"]; }
            set { this["ADDRESS"] = value; }
        }

        public SKRSILKodlari City
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("CITY"); }
            set { this["CITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TestObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TestObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TestObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TestObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TestObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TESTOBJECT", dataRow) { }
        protected TestObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TESTOBJECT", dataRow, isImported) { }
        public TestObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TestObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TestObject() : base() { }

    }
}