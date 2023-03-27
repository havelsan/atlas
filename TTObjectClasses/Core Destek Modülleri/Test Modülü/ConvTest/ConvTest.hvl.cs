
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ConvTest")] 

    /// <summary>
    /// ConvTest Kılası
    /// </summary>
    public  partial class ConvTest : TTObject
    {
        public class ConvTestList : TTObjectCollection<ConvTest> { }
                    
        public class ChildConvTestCollection : TTObject.TTChildObjectCollection<ConvTest>
        {
            public ChildConvTestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildConvTestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Approove { get { return new Guid("e17333ae-aa18-4907-a41f-82f786cba14d"); } }
            public static Guid Completed { get { return new Guid("dff7f150-5d52-4f9f-8168-58ec715fcb94"); } }
            public static Guid New { get { return new Guid("4f2a01d9-69d5-4602-8943-4a9b9f41c86b"); } }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Telephone
        {
            get { return (string)this["TELEPHONE"]; }
            set { this["TELEPHONE"] = value; }
        }

        public int? No
        {
            get { return (int?)this["NO"]; }
            set { this["NO"] = value; }
        }

        public string FFF
        {
            get { return (string)this["FFF"]; }
            set { this["FFF"] = value; }
        }

        public City City
        {
            get { return (City)((ITTObject)this).GetParent("CITY"); }
            set { this["CITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ConvTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ConvTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ConvTest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ConvTest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ConvTest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONVTEST", dataRow) { }
        protected ConvTest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONVTEST", dataRow, isImported) { }
        public ConvTest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ConvTest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ConvTest() : base() { }

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