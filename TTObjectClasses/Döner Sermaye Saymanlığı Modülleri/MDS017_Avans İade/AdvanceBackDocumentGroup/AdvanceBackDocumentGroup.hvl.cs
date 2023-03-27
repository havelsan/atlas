
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdvanceBackDocumentGroup")] 

    /// <summary>
    /// Avans İade Döküman Grubu
    /// </summary>
    public  partial class AdvanceBackDocumentGroup : AccountDocumentGroup
    {
        public class AdvanceBackDocumentGroupList : TTObjectCollection<AdvanceBackDocumentGroup> { }
                    
        public class ChildAdvanceBackDocumentGroupCollection : TTObject.TTChildObjectCollection<AdvanceBackDocumentGroup>
        {
            public ChildAdvanceBackDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdvanceBackDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected AdvanceBackDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdvanceBackDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdvanceBackDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdvanceBackDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdvanceBackDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADVANCEBACKDOCUMENTGROUP", dataRow) { }
        protected AdvanceBackDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADVANCEBACKDOCUMENTGROUP", dataRow, isImported) { }
        public AdvanceBackDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdvanceBackDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdvanceBackDocumentGroup() : base() { }

    }
}