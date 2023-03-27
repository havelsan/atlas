
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSDepartmentDefinition")] 

    public  partial class MPBSDepartmentDefinition : TTDefinitionSet
    {
        public class MPBSDepartmentDefinitionList : TTObjectCollection<MPBSDepartmentDefinition> { }
                    
        public class ChildMPBSDepartmentDefinitionCollection : TTObject.TTChildObjectCollection<MPBSDepartmentDefinition>
        {
            public ChildMPBSDepartmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSDepartmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Fakülte
    /// </summary>
        public MPBSFacultyDefinition Faculty
        {
            get { return (MPBSFacultyDefinition)((ITTObject)this).GetParent("FACULTY"); }
            set { this["FACULTY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSDepartmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSDepartmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSDepartmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSDepartmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSDepartmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSDEPARTMENTDEFINITION", dataRow) { }
        protected MPBSDepartmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSDEPARTMENTDEFINITION", dataRow, isImported) { }
        public MPBSDepartmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSDepartmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSDepartmentDefinition() : base() { }

    }
}