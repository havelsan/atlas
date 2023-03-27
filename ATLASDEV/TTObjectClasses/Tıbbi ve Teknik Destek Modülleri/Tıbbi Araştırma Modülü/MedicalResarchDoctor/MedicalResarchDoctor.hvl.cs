
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalResarchDoctor")] 

    public  partial class MedicalResarchDoctor : TTObject
    {
        public class MedicalResarchDoctorList : TTObjectCollection<MedicalResarchDoctor> { }
                    
        public class ChildMedicalResarchDoctorCollection : TTObject.TTChildObjectCollection<MedicalResarchDoctor>
        {
            public ChildMedicalResarchDoctorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalResarchDoctorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public MedicalResarch MedicalResarch
        {
            get { return (MedicalResarch)((ITTObject)this).GetParent("MEDICALRESARCH"); }
            set { this["MEDICALRESARCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalResarchDoctor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalResarchDoctor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalResarchDoctor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalResarchDoctor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalResarchDoctor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALRESARCHDOCTOR", dataRow) { }
        protected MedicalResarchDoctor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALRESARCHDOCTOR", dataRow, isImported) { }
        public MedicalResarchDoctor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalResarchDoctor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalResarchDoctor() : base() { }

    }
}