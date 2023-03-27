
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Folder2")] 

    public  partial class Folder2 : Folder
    {
        public class Folder2List : TTObjectCollection<Folder2> { }
                    
        public class ChildFolder2Collection : TTObject.TTChildObjectCollection<Folder2>
        {
            public ChildFolder2Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFolder2Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? y
        {
            get { return (int?)this["Y"]; }
            set { this["Y"] = value; }
        }

        protected Folder2(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Folder2(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Folder2(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Folder2(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Folder2(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FOLDER2", dataRow) { }
        protected Folder2(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FOLDER2", dataRow, isImported) { }
        public Folder2(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Folder2(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Folder2() : base() { }

    }
}