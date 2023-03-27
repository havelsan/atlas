
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TestSubGroup")] 

    /// <summary>
    /// Tetkik Alt Grupları
    /// </summary>
    public  partial class TestSubGroup : TTObject
    {
        public class TestSubGroupList : TTObjectCollection<TestSubGroup> { }
                    
        public class ChildTestSubGroupCollection : TTObject.TTChildObjectCollection<TestSubGroup>
        {
            public ChildTestSubGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTestSubGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tetkik Alt Grubu
    /// </summary>
        public string TetkikSubGroup
        {
            get { return (string)this["TETKIKSUBGROUP"]; }
            set { this["TETKIKSUBGROUP"] = value; }
        }

        protected TestSubGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TestSubGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TestSubGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TestSubGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TestSubGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TESTSUBGROUP", dataRow) { }
        protected TestSubGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TESTSUBGROUP", dataRow, isImported) { }
        protected TestSubGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TestSubGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TestSubGroup() : base() { }

    }
}