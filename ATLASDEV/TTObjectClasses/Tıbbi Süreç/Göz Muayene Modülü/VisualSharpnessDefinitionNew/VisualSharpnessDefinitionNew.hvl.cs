
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VisualSharpnessDefinitionNew")] 

    public  partial class VisualSharpnessDefinitionNew : TTDefinitionSet
    {
        public class VisualSharpnessDefinitionNewList : TTObjectCollection<VisualSharpnessDefinitionNew> { }
                    
        public class ChildVisualSharpnessDefinitionNewCollection : TTObject.TTChildObjectCollection<VisualSharpnessDefinitionNew>
        {
            public ChildVisualSharpnessDefinitionNewCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVisualSharpnessDefinitionNewCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string SharpnessValue
        {
            get { return (string)this["SHARPNESSVALUE"]; }
            set { this["SHARPNESSVALUE"] = value; }
        }

        protected VisualSharpnessDefinitionNew(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VisualSharpnessDefinitionNew(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VisualSharpnessDefinitionNew(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VisualSharpnessDefinitionNew(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VisualSharpnessDefinitionNew(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VISUALSHARPNESSDEFINITIONNEW", dataRow) { }
        protected VisualSharpnessDefinitionNew(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VISUALSHARPNESSDEFINITIONNEW", dataRow, isImported) { }
        public VisualSharpnessDefinitionNew(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VisualSharpnessDefinitionNew(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VisualSharpnessDefinitionNew() : base() { }

    }
}