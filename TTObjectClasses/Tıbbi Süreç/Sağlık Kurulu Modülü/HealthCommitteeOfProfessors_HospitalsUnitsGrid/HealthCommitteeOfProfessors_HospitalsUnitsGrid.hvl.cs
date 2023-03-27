
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeOfProfessors_HospitalsUnitsGrid")] 

    /// <summary>
    /// Havale Edilen Birimler XXXXXXler
    /// </summary>
    public  partial class HealthCommitteeOfProfessors_HospitalsUnitsGrid : HospitalsUnitsGrid
    {
        public class HealthCommitteeOfProfessors_HospitalsUnitsGridList : TTObjectCollection<HealthCommitteeOfProfessors_HospitalsUnitsGrid> { }
                    
        public class ChildHealthCommitteeOfProfessors_HospitalsUnitsGridCollection : TTObject.TTChildObjectCollection<HealthCommitteeOfProfessors_HospitalsUnitsGrid>
        {
            public ChildHealthCommitteeOfProfessors_HospitalsUnitsGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeOfProfessors_HospitalsUnitsGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected HealthCommitteeOfProfessors_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeOfProfessors_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeOfProfessors_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeOfProfessors_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeOfProfessors_HospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEOFPROFESSORS_HOSPITALSUNITSGRID", dataRow) { }
        protected HealthCommitteeOfProfessors_HospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEOFPROFESSORS_HOSPITALSUNITSGRID", dataRow, isImported) { }
        public HealthCommitteeOfProfessors_HospitalsUnitsGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeOfProfessors_HospitalsUnitsGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeOfProfessors_HospitalsUnitsGrid() : base() { }

    }
}