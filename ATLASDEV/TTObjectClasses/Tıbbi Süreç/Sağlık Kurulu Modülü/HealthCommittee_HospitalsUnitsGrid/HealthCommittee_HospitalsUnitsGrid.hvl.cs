
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommittee_HospitalsUnitsGrid")] 

    /// <summary>
    /// XXXXXXler/Birimler
    /// </summary>
    public  partial class HealthCommittee_HospitalsUnitsGrid : HospitalsUnitsGrid
    {
        public class HealthCommittee_HospitalsUnitsGridList : TTObjectCollection<HealthCommittee_HospitalsUnitsGrid> { }
                    
        public class ChildHealthCommittee_HospitalsUnitsGridCollection : TTObject.TTChildObjectCollection<HealthCommittee_HospitalsUnitsGrid>
        {
            public ChildHealthCommittee_HospitalsUnitsGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommittee_HospitalsUnitsGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected HealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEE_HOSPITALSUNITSGRID", dataRow) { }
        protected HealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEE_HOSPITALSUNITSGRID", dataRow, isImported) { }
        public HealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommittee_HospitalsUnitsGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommittee_HospitalsUnitsGrid() : base() { }

    }
}