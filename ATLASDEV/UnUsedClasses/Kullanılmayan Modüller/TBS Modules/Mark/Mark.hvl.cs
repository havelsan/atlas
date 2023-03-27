
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Mark")] 

    /// <summary>
    /// Marka
    /// </summary>
    public  partial class Mark : TTDefinitionSet
    {
        public class MarkList : TTObjectCollection<Mark> { }
                    
        public class ChildMarkCollection : TTObject.TTChildObjectCollection<Mark>
        {
            public ChildMarkCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMarkCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected Mark(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Mark(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Mark(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Mark(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Mark(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MARK", dataRow) { }
        protected Mark(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MARK", dataRow, isImported) { }
        public Mark(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Mark(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Mark() : base() { }

    }
}