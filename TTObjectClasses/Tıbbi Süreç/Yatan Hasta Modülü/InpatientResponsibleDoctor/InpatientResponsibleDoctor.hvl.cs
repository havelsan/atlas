
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientResponsibleDoctor")] 

    /// <summary>
    /// Yatan Hasta Doktorlar Sekmesi
    /// </summary>
    public  partial class InpatientResponsibleDoctor : TTObject
    {
        public class InpatientResponsibleDoctorList : TTObjectCollection<InpatientResponsibleDoctor> { }
                    
        public class ChildInpatientResponsibleDoctorCollection : TTObject.TTChildObjectCollection<InpatientResponsibleDoctor>
        {
            public ChildInpatientResponsibleDoctorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientResponsibleDoctorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tarih/Saat
    /// </summary>
        public DateTime? SDateTime
        {
            get { return (DateTime?)this["SDATETIME"]; }
            set { this["SDATETIME"] = value; }
        }

    /// <summary>
    /// Doktor
    /// </summary>
        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientTreatmentClinicApplication InPatientTreatmentClinicApp
        {
            get { return (InPatientTreatmentClinicApplication)((ITTObject)this).GetParent("INPATIENTTREATMENTCLINICAPP"); }
            set { this["INPATIENTTREATMENTCLINICAPP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InpatientResponsibleDoctor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientResponsibleDoctor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientResponsibleDoctor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientResponsibleDoctor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientResponsibleDoctor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTRESPONSIBLEDOCTOR", dataRow) { }
        protected InpatientResponsibleDoctor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTRESPONSIBLEDOCTOR", dataRow, isImported) { }
        public InpatientResponsibleDoctor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientResponsibleDoctor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientResponsibleDoctor() : base() { }

    }
}