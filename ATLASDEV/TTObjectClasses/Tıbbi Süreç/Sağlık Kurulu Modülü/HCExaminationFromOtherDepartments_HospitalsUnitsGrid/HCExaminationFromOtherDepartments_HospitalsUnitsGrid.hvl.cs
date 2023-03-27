
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCExaminationFromOtherDepartments_HospitalsUnitsGrid")] 

    /// <summary>
    /// XXXXXXler/Birimler
    /// </summary>
    public  partial class HCExaminationFromOtherDepartments_HospitalsUnitsGrid : HospitalsUnitsGrid
    {
        public class HCExaminationFromOtherDepartments_HospitalsUnitsGridList : TTObjectCollection<HCExaminationFromOtherDepartments_HospitalsUnitsGrid> { }
                    
        public class ChildHCExaminationFromOtherDepartments_HospitalsUnitsGridCollection : TTObject.TTChildObjectCollection<HCExaminationFromOtherDepartments_HospitalsUnitsGrid>
        {
            public ChildHCExaminationFromOtherDepartments_HospitalsUnitsGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCExaminationFromOtherDepartments_HospitalsUnitsGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected HCExaminationFromOtherDepartments_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCExaminationFromOtherDepartments_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCExaminationFromOtherDepartments_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCExaminationFromOtherDepartments_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCExaminationFromOtherDepartments_HospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCEXAMINATIONFROMOTHERDEPARTMENTS_HOSPITALSUNITSGRID", dataRow) { }
        protected HCExaminationFromOtherDepartments_HospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCEXAMINATIONFROMOTHERDEPARTMENTS_HOSPITALSUNITSGRID", dataRow, isImported) { }
        public HCExaminationFromOtherDepartments_HospitalsUnitsGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCExaminationFromOtherDepartments_HospitalsUnitsGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCExaminationFromOtherDepartments_HospitalsUnitsGrid() : base() { }

    }
}