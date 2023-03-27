
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodBnkBloodGroup")] 

    /// <summary>
    /// Kan Grubu
    /// </summary>
    public  partial class BloodBnkBloodGroup : EpisodeAction
    {
        public class BloodBnkBloodGroupList : TTObjectCollection<BloodBnkBloodGroup> { }
                    
        public class ChildBloodBnkBloodGroupCollection : TTObject.TTChildObjectCollection<BloodBnkBloodGroup>
        {
            public ChildBloodBnkBloodGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodBnkBloodGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Reject { get { return new Guid("e2b77189-f41d-4e17-bd95-140a9cda1f99"); } }
            public static Guid BloodGroupTestApprove { get { return new Guid("d27b1e08-62ca-4de1-a907-0733e12b64e8"); } }
            public static Guid BloodGroupTestProcedure { get { return new Guid("fde48293-e470-4f47-ae29-19a866ccc528"); } }
            public static Guid BloodGroupTestRequest { get { return new Guid("89c3abbe-13e4-49ea-9082-a6123f2a5d6b"); } }
            public static Guid BloodGroupTestComplete { get { return new Guid("fcaa45d8-6995-4f84-9821-59603389cfb8"); } }
            public static Guid BloodGroupTestBarcodeControl { get { return new Guid("65b3a812-01f4-4bdc-842c-b659705beb67"); } }
            public static Guid BloodGroupTest { get { return new Guid("f21611fa-c067-47ae-a914-7ab453fa49da"); } }
        }

        virtual protected void CreateBloodBnkBloodGroupTestsCollection()
        {
            _BloodBnkBloodGroupTests = new BloodBnkBloodGroupTest.ChildBloodBnkBloodGroupTestCollection(this, new Guid("a6a34abc-d9ba-48a3-90f5-372c725277a0"));
            ((ITTChildObjectCollection)_BloodBnkBloodGroupTests).GetChildren();
        }

        protected BloodBnkBloodGroupTest.ChildBloodBnkBloodGroupTestCollection _BloodBnkBloodGroupTests = null;
        public BloodBnkBloodGroupTest.ChildBloodBnkBloodGroupTestCollection BloodBnkBloodGroupTests
        {
            get
            {
                if (_BloodBnkBloodGroupTests == null)
                    CreateBloodBnkBloodGroupTestsCollection();
                return _BloodBnkBloodGroupTests;
            }
        }

        protected BloodBnkBloodGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodBnkBloodGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodBnkBloodGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodBnkBloodGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodBnkBloodGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODBNKBLOODGROUP", dataRow) { }
        protected BloodBnkBloodGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODBNKBLOODGROUP", dataRow, isImported) { }
        public BloodBnkBloodGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodBnkBloodGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodBnkBloodGroup() : base() { }

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