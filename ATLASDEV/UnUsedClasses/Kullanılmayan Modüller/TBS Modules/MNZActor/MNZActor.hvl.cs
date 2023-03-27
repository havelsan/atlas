
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZActor")] 

    /// <summary>
    /// DE_Aktor
    /// </summary>
    public  partial class MNZActor : TTObject
    {
        public class MNZActorList : TTObjectCollection<MNZActor> { }
                    
        public class ChildMNZActorCollection : TTObject.TTChildObjectCollection<MNZActor>
        {
            public ChildMNZActorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZActorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanımlama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected MNZActor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZActor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZActor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZActor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZActor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZACTOR", dataRow) { }
        protected MNZActor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZACTOR", dataRow, isImported) { }
        public MNZActor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZActor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZActor() : base() { }

    }
}