
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ArrangePrivatePatient")] 

    /// <summary>
    /// Gizlilik bitiş Tarihi Olan Hastaları Düzenler
    /// </summary>
    public  partial class ArrangePrivatePatient : BaseScheduledTask
    {
        public class ArrangePrivatePatientList : TTObjectCollection<ArrangePrivatePatient> { }
                    
        public class ChildArrangePrivatePatientCollection : TTObject.TTChildObjectCollection<ArrangePrivatePatient>
        {
            public ChildArrangePrivatePatientCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildArrangePrivatePatientCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ArrangePrivatePatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ArrangePrivatePatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ArrangePrivatePatient(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ArrangePrivatePatient(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ArrangePrivatePatient(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARRANGEPRIVATEPATIENT", dataRow) { }
        protected ArrangePrivatePatient(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARRANGEPRIVATEPATIENT", dataRow, isImported) { }
        public ArrangePrivatePatient(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ArrangePrivatePatient(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ArrangePrivatePatient() : base() { }

    }
}