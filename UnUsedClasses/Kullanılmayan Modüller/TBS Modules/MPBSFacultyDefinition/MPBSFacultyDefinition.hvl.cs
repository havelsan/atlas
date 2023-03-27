
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSFacultyDefinition")] 

    /// <summary>
    /// Fakülte Tanımlama
    /// </summary>
    public  partial class MPBSFacultyDefinition : TTDefinitionSet
    {
        public class MPBSFacultyDefinitionList : TTObjectCollection<MPBSFacultyDefinition> { }
                    
        public class ChildMPBSFacultyDefinitionCollection : TTObject.TTChildObjectCollection<MPBSFacultyDefinition>
        {
            public ChildMPBSFacultyDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSFacultyDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Üniversite
    /// </summary>
        public MPBSUniversityDefinition University
        {
            get { return (MPBSUniversityDefinition)((ITTObject)this).GetParent("UNIVERSITY"); }
            set { this["UNIVERSITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSFacultyDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSFacultyDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSFacultyDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSFacultyDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSFacultyDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSFACULTYDEFINITION", dataRow) { }
        protected MPBSFacultyDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSFACULTYDEFINITION", dataRow, isImported) { }
        public MPBSFacultyDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSFacultyDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSFacultyDefinition() : base() { }

    }
}