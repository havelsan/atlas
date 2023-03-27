
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRPatientGroup")] 

    /// <summary>
    /// DLR009_Hasta Grubu
    /// </summary>
    public  partial class MLRPatientGroup : TTObject
    {
        public class MLRPatientGroupList : TTObjectCollection<MLRPatientGroup> { }
                    
        public class ChildMLRPatientGroupCollection : TTObject.TTChildObjectCollection<MLRPatientGroup>
        {
            public ChildMLRPatientGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRPatientGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hastalar
    /// </summary>
        public string PatientID
        {
            get { return (string)this["PATIENTID"]; }
            set { this["PATIENTID"] = value; }
        }

    /// <summary>
    /// Hasta Sayısı
    /// </summary>
        public string NumberOfPatients
        {
            get { return (string)this["NUMBEROFPATIENTS"]; }
            set { this["NUMBEROFPATIENTS"] = value; }
        }

    /// <summary>
    /// Klinik No
    /// </summary>
        public string ClinicID
        {
            get { return (string)this["CLINICID"]; }
            set { this["CLINICID"] = value; }
        }

        protected MLRPatientGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRPatientGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRPatientGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRPatientGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRPatientGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRPATIENTGROUP", dataRow) { }
        protected MLRPatientGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRPATIENTGROUP", dataRow, isImported) { }
        public MLRPatientGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRPatientGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRPatientGroup() : base() { }

    }
}