
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid")] 

    public  partial class HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid : HospitalsUnitsGrid
    {
        public class HCExaminationFromOtherDepartments_PrevHospitalsUnitsGridList : TTObjectCollection<HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid> { }
                    
        public class ChildHCExaminationFromOtherDepartments_PrevHospitalsUnitsGridCollection : TTObject.TTChildObjectCollection<HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid>
        {
            public ChildHCExaminationFromOtherDepartments_PrevHospitalsUnitsGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCExaminationFromOtherDepartments_PrevHospitalsUnitsGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public HealthCommitteeExaminationFromOtherDepartments HCExaminationFromOtherDeps
        {
            get { return (HealthCommitteeExaminationFromOtherDepartments)((ITTObject)this).GetParent("HCEXAMINATIONFROMOTHERDEPS"); }
            set { this["HCEXAMINATIONFROMOTHERDEPS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCEXAMINATIONFROMOTHERDEPARTMENTS_PREVHOSPITALSUNITSGRID", dataRow) { }
        protected HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCEXAMINATIONFROMOTHERDEPARTMENTS_PREVHOSPITALSUNITSGRID", dataRow, isImported) { }
        public HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid() : base() { }

    }
}