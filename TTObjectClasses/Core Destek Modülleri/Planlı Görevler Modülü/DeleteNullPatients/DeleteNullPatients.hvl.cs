
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DeleteNullPatients")] 

    public  partial class DeleteNullPatients : BaseScheduledTask
    {
        public class DeleteNullPatientsList : TTObjectCollection<DeleteNullPatients> { }
                    
        public class ChildDeleteNullPatientsCollection : TTObject.TTChildObjectCollection<DeleteNullPatients>
        {
            public ChildDeleteNullPatientsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDeleteNullPatientsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DeleteNullPatients(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DeleteNullPatients(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DeleteNullPatients(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DeleteNullPatients(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DeleteNullPatients(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DELETENULLPATIENTS", dataRow) { }
        protected DeleteNullPatients(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DELETENULLPATIENTS", dataRow, isImported) { }
        public DeleteNullPatients(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DeleteNullPatients(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DeleteNullPatients() : base() { }

    }
}