
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VisualSharpnessDefinition")] 

    public  partial class VisualSharpnessDefinition : TTDefinitionSet
    {
        public class VisualSharpnessDefinitionList : TTObjectCollection<VisualSharpnessDefinition> { }
                    
        public class ChildVisualSharpnessDefinitionCollection : TTObject.TTChildObjectCollection<VisualSharpnessDefinition>
        {
            public ChildVisualSharpnessDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVisualSharpnessDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sharpness Value
    /// </summary>
        public string SharpnessValue
        {
            get { return (string)this["SHARPNESSVALUE"]; }
            set { this["SHARPNESSVALUE"] = value; }
        }

        protected VisualSharpnessDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VisualSharpnessDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VisualSharpnessDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VisualSharpnessDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VisualSharpnessDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VISUALSHARPNESSDEFINITION", dataRow) { }
        protected VisualSharpnessDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VISUALSHARPNESSDEFINITION", dataRow, isImported) { }
        public VisualSharpnessDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VisualSharpnessDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VisualSharpnessDefinition() : base() { }

    }
}