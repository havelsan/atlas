
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSUniversityDefinition")] 

    /// <summary>
    /// Üniversite Tanımlama
    /// </summary>
    public  partial class MPBSUniversityDefinition : TTDefinitionSet
    {
        public class MPBSUniversityDefinitionList : TTObjectCollection<MPBSUniversityDefinition> { }
                    
        public class ChildMPBSUniversityDefinitionCollection : TTObject.TTChildObjectCollection<MPBSUniversityDefinition>
        {
            public ChildMPBSUniversityDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSUniversityDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MPBSUniversityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSUniversityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSUniversityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSUniversityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSUniversityDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSUNIVERSITYDEFINITION", dataRow) { }
        protected MPBSUniversityDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSUNIVERSITYDEFINITION", dataRow, isImported) { }
        public MPBSUniversityDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSUniversityDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSUniversityDefinition() : base() { }

    }
}