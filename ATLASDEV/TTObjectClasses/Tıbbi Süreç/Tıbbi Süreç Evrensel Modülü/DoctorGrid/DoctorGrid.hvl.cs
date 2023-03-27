
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DoctorGrid")] 

    /// <summary>
    /// Doktor Grid
    /// </summary>
    public  partial class DoctorGrid : TTObject
    {
        public class DoctorGridList : TTObjectCollection<DoctorGrid> { }
                    
        public class ChildDoctorGridCollection : TTObject.TTChildObjectCollection<DoctorGrid>
        {
            public ChildDoctorGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoctorGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public InpatientAdmission InpatientAdmission
        {
            get { return (InpatientAdmission)((ITTObject)this).GetParent("INPATIENTADMISSION"); }
            set { this["INPATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientExamination PatientExamination
        {
            get { return (PatientExamination)((ITTObject)this).GetParent("PATIENTEXAMINATION"); }
            set { this["PATIENTEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DispatchToOtherHospital DispatchToOtherHospital
        {
            get { return (DispatchToOtherHospital)((ITTObject)this).GetParent("DISPATCHTOOTHERHOSPITAL"); }
            set { this["DISPATCHTOOTHERHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public UnavailableToWorkReport UnavailableToWorkReport
        {
            get { return (UnavailableToWorkReport)((ITTObject)this).GetParent("UNAVAILABLETOWORKREPORT"); }
            set { this["UNAVAILABLETOWORKREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DoctorGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DoctorGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DoctorGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DoctorGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DoctorGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOCTORGRID", dataRow) { }
        protected DoctorGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOCTORGRID", dataRow, isImported) { }
        public DoctorGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DoctorGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DoctorGrid() : base() { }

    }
}