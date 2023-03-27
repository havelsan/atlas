
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdvanceDocumentGroup")] 

    /// <summary>
    /// Avans Alındısı Döküman Grubu
    /// </summary>
    public  partial class AdvanceDocumentGroup : AccountDocumentGroup
    {
        public class AdvanceDocumentGroupList : TTObjectCollection<AdvanceDocumentGroup> { }
                    
        public class ChildAdvanceDocumentGroupCollection : TTObject.TTChildObjectCollection<AdvanceDocumentGroup>
        {
            public ChildAdvanceDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdvanceDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected AdvanceDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdvanceDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdvanceDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdvanceDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdvanceDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADVANCEDOCUMENTGROUP", dataRow) { }
        protected AdvanceDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADVANCEDOCUMENTGROUP", dataRow, isImported) { }
        public AdvanceDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdvanceDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdvanceDocumentGroup() : base() { }

    }
}