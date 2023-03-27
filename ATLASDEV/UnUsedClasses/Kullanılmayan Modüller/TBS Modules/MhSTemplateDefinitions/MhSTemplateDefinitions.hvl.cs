
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSTemplateDefinitions")] 

    /// <summary>
    /// Fiş Tanımlama
    /// </summary>
    public  partial class MhSTemplateDefinitions : TTObject
    {
        public class MhSTemplateDefinitionsList : TTObjectCollection<MhSTemplateDefinitions> { }
                    
        public class ChildMhSTemplateDefinitionsCollection : TTObject.TTChildObjectCollection<MhSTemplateDefinitions>
        {
            public ChildMhSTemplateDefinitionsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSTemplateDefinitionsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MhSTemplateDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSTemplateDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSTemplateDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSTemplateDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSTemplateDefinitions(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSTEMPLATEDEFINITIONS", dataRow) { }
        protected MhSTemplateDefinitions(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSTEMPLATEDEFINITIONS", dataRow, isImported) { }
        public MhSTemplateDefinitions(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSTemplateDefinitions(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSTemplateDefinitions() : base() { }

    }
}