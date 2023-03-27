
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChildStateTest")] 

    public  partial class ChildStateTest : XXXBaseStateTest
    {
        public class ChildStateTestList : TTObjectCollection<ChildStateTest> { }
                    
        public class ChildChildStateTestCollection : TTObject.TTChildObjectCollection<ChildStateTest>
        {
            public ChildChildStateTestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChildStateTestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("a44d4de1-d121-4ba6-b5f4-90476ad65bd8"); } }
            public static Guid Cancelled { get { return new Guid("dfd79e9b-b021-409d-9da7-bb0be1354a5c"); } }
            public static Guid New2 { get { return new Guid("da2da9e0-19be-4a95-95ef-f556dc886970"); } }
        }

        protected ChildStateTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChildStateTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChildStateTest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChildStateTest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChildStateTest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHILDSTATETEST", dataRow) { }
        protected ChildStateTest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHILDSTATETEST", dataRow, isImported) { }
        public ChildStateTest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChildStateTest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChildStateTest() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}