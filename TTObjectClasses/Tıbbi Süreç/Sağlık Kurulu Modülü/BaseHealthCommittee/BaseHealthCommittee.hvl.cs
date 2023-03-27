
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseHealthCommittee")] 

    public  partial class BaseHealthCommittee : EpisodeActionWithDiagnosis
    {
        public class BaseHealthCommitteeList : TTObjectCollection<BaseHealthCommittee> { }
                    
        public class ChildBaseHealthCommitteeCollection : TTObject.TTChildObjectCollection<BaseHealthCommittee>
        {
            public ChildBaseHealthCommitteeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseHealthCommitteeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateHospitalsUnitsCollection()
        {
            _HospitalsUnits = new BaseHealthCommittee_HospitalsUnitsGrid.ChildBaseHealthCommittee_HospitalsUnitsGridCollection(this, new Guid("ff0e539c-35c7-4433-b816-85371786ad29"));
            ((ITTChildObjectCollection)_HospitalsUnits).GetChildren();
        }

        protected BaseHealthCommittee_HospitalsUnitsGrid.ChildBaseHealthCommittee_HospitalsUnitsGridCollection _HospitalsUnits = null;
    /// <summary>
    /// Child collection for BaseHealthCommittee_HospitalsUnits
    /// </summary>
        public BaseHealthCommittee_HospitalsUnitsGrid.ChildBaseHealthCommittee_HospitalsUnitsGridCollection HospitalsUnits
        {
            get
            {
                if (_HospitalsUnits == null)
                    CreateHospitalsUnitsCollection();
                return _HospitalsUnits;
            }
        }

        virtual protected void CreateExternalDoctorsCollection()
        {
            _ExternalDoctors = new BaseHealthCommittee_ExtDoctorGrid.ChildBaseHealthCommittee_ExtDoctorGridCollection(this, new Guid("f6428a1b-a512-490a-ae65-084379b423a9"));
            ((ITTChildObjectCollection)_ExternalDoctors).GetChildren();
        }

        protected BaseHealthCommittee_ExtDoctorGrid.ChildBaseHealthCommittee_ExtDoctorGridCollection _ExternalDoctors = null;
    /// <summary>
    /// Child collection for BaseHealthCommittee_ExtDoctors
    /// </summary>
        public BaseHealthCommittee_ExtDoctorGrid.ChildBaseHealthCommittee_ExtDoctorGridCollection ExternalDoctors
        {
            get
            {
                if (_ExternalDoctors == null)
                    CreateExternalDoctorsCollection();
                return _ExternalDoctors;
            }
        }

        protected BaseHealthCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseHealthCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseHealthCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseHealthCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseHealthCommittee(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEHEALTHCOMMITTEE", dataRow) { }
        protected BaseHealthCommittee(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEHEALTHCOMMITTEE", dataRow, isImported) { }
        public BaseHealthCommittee(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseHealthCommittee(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseHealthCommittee() : base() { }

    }
}