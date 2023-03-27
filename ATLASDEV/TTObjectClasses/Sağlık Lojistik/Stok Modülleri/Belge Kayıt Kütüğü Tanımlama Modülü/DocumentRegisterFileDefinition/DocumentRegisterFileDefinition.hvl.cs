
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DocumentRegisterFileDefinition")] 

    /// <summary>
    /// Belge Kayıt Kütüğü Tanımları
    /// </summary>
    public  partial class DocumentRegisterFileDefinition : TTDefinitionSet
    {
        public class DocumentRegisterFileDefinitionList : TTObjectCollection<DocumentRegisterFileDefinition> { }
                    
        public class ChildDocumentRegisterFileDefinitionCollection : TTObject.TTChildObjectCollection<DocumentRegisterFileDefinition>
        {
            public ChildDocumentRegisterFileDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDocumentRegisterFileDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DocumentRegisterFileDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DocumentRegisterFileDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DocumentRegisterFileDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DocumentRegisterFileDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DocumentRegisterFileDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOCUMENTREGISTERFILEDEFINITION", dataRow) { }
        protected DocumentRegisterFileDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOCUMENTREGISTERFILEDEFINITION", dataRow, isImported) { }
        public DocumentRegisterFileDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DocumentRegisterFileDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DocumentRegisterFileDefinition() : base() { }

    }
}