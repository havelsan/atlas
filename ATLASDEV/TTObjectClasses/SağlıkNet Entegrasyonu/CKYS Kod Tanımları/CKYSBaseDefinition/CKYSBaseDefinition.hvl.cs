
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CKYSBaseDefinition")] 

    public  partial class CKYSBaseDefinition : TerminologyManagerDef
    {
        public class CKYSBaseDefinitionList : TTObjectCollection<CKYSBaseDefinition> { }
                    
        public class ChildCKYSBaseDefinitionCollection : TTObject.TTChildObjectCollection<CKYSBaseDefinition>
        {
            public ChildCKYSBaseDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCKYSBaseDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CKYSBaseDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CKYSBaseDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CKYSBaseDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CKYSBaseDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CKYSBaseDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CKYSBASEDEFINITION", dataRow) { }
        protected CKYSBaseDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CKYSBASEDEFINITION", dataRow, isImported) { }
        public CKYSBaseDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CKYSBaseDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CKYSBaseDefinition() : base() { }

    }
}