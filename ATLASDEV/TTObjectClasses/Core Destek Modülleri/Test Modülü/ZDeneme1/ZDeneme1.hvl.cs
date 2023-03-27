
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ZDeneme1")] 

    public  partial class ZDeneme1 : TTObject
    {
        public class ZDeneme1List : TTObjectCollection<ZDeneme1> { }
                    
        public class ChildZDeneme1Collection : TTObject.TTChildObjectCollection<ZDeneme1>
        {
            public ChildZDeneme1Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildZDeneme1Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("d1b5c702-86ec-40c7-bb17-aaa545595a40"); } }
            public static Guid Approve { get { return new Guid("f42f280a-0341-4518-8825-324cbde04d35"); } }
            public static Guid BloodEntry { get { return new Guid("6e5e03b9-7679-4ede-aa86-8ca73986c72d"); } }
            public static Guid Completed { get { return new Guid("ae61a8a2-cafc-4369-9326-41e06f590683"); } }
            public static Guid Cancelled { get { return new Guid("798644f9-108d-48dd-b350-15430e70a4bd"); } }
            public static Guid Rejected { get { return new Guid("9a346f7b-aac9-4c75-adb8-9c8b346224b7"); } }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public DateTime? BirthDate
        {
            get { return (DateTime?)this["BIRTHDATE"]; }
            set { this["BIRTHDATE"] = value; }
        }

        public City City
        {
            get { return (City)((ITTObject)this).GetParent("CITY"); }
            set { this["CITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKanGrubu BloodType
        {
            get { return (SKRSKanGrubu)((ITTObject)this).GetParent("BLOODTYPE"); }
            set { this["BLOODTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ZDeneme1(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ZDeneme1(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ZDeneme1(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ZDeneme1(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ZDeneme1(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ZDENEME1", dataRow) { }
        protected ZDeneme1(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ZDENEME1", dataRow, isImported) { }
        public ZDeneme1(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ZDeneme1(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ZDeneme1() : base() { }

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