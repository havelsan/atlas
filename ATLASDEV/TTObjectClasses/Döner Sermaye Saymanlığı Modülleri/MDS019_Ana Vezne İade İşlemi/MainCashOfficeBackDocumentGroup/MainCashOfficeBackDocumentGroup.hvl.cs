
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainCashOfficeBackDocumentGroup")] 

    /// <summary>
    /// Vezne İade Döküman Grubu
    /// </summary>
    public  partial class MainCashOfficeBackDocumentGroup : AccountDocumentGroup
    {
        public class MainCashOfficeBackDocumentGroupList : TTObjectCollection<MainCashOfficeBackDocumentGroup> { }
                    
        public class ChildMainCashOfficeBackDocumentGroupCollection : TTObject.TTChildObjectCollection<MainCashOfficeBackDocumentGroup>
        {
            public ChildMainCashOfficeBackDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainCashOfficeBackDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MainCashOfficeBackDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainCashOfficeBackDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainCashOfficeBackDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainCashOfficeBackDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainCashOfficeBackDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINCASHOFFICEBACKDOCUMENTGROUP", dataRow) { }
        protected MainCashOfficeBackDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINCASHOFFICEBACKDOCUMENTGROUP", dataRow, isImported) { }
        public MainCashOfficeBackDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainCashOfficeBackDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainCashOfficeBackDocumentGroup() : base() { }

    }
}