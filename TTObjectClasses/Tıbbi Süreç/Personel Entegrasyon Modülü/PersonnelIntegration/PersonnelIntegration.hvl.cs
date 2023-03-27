
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PersonnelIntegration")] 

    public  partial class PersonnelIntegration : BaseAction
    {
        public class PersonnelIntegrationList : TTObjectCollection<PersonnelIntegration> { }
                    
        public class ChildPersonnelIntegrationCollection : TTObject.TTChildObjectCollection<PersonnelIntegration>
        {
            public ChildPersonnelIntegrationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPersonnelIntegrationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected PersonnelIntegration(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PersonnelIntegration(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PersonnelIntegration(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PersonnelIntegration(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PersonnelIntegration(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PERSONNELINTEGRATION", dataRow) { }
        protected PersonnelIntegration(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PERSONNELINTEGRATION", dataRow, isImported) { }
        public PersonnelIntegration(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PersonnelIntegration(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PersonnelIntegration() : base() { }

    }
}