
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="XXXBaseStateTest")] 

    public  partial class XXXBaseStateTest : TTObject
    {
        public class XXXBaseStateTestList : TTObjectCollection<XXXBaseStateTest> { }
                    
        public class ChildXXXBaseStateTestCollection : TTObject.TTChildObjectCollection<XXXBaseStateTest>
        {
            public ChildXXXBaseStateTestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildXXXBaseStateTestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("1cf2955a-22b5-4103-a10e-0bea0626a7f0"); } }
            public static Guid New { get { return new Guid("bc76ebf3-a2dc-43db-8b8a-33b43b50e2bc"); } }
            public static Guid Fazla1 { get { return new Guid("58623671-9b8c-4600-85fd-7ccf7ae42af6"); } }
            public static Guid Fazla2 { get { return new Guid("fd046e37-7e41-4619-879d-8f8d90b95583"); } }
        }

        protected XXXBaseStateTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected XXXBaseStateTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected XXXBaseStateTest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected XXXBaseStateTest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected XXXBaseStateTest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "XXXBASESTATETEST", dataRow) { }
        protected XXXBaseStateTest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "XXXBASESTATETEST", dataRow, isImported) { }
        public XXXBaseStateTest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public XXXBaseStateTest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public XXXBaseStateTest() : base() { }

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